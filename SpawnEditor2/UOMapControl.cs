using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpawnEditor2
{
	public class UOMapMouseEventArgs : EventArgs
	{
		public int button;
		public int x;
		public int y;
	}

	public delegate void UOMapMouseEventHandler(object sender, UOMapMouseEventArgs e);

	public class UOMapControl : Panel, ISupportInitialize
	{
		private struct MapDrawObject
		{
			public short X, Y, Shape, Size;
			public int Color;
		}

		private struct MapDrawRect
		{
			public short X, Y, Width, Height, Border;
			public int Color;
			public int Index;
		}

		private string _clientPath;
		private short _mapFile;
		private short _zoomLevel;
		private short _xCenter;
		private short _yCenter;
		private bool _drawStatics;

		private ushort[] _radarCol;
		private Bitmap _radarBitmap;
		private sbyte[] _mapHeights;
		private int _mapWidth;
		private int _mapHeight;

		private readonly List<MapDrawObject> _drawObjects = new List<MapDrawObject>();
		private readonly List<MapDrawRect> _drawRects = new List<MapDrawRect>();
		private int _nextRectIndex;

		private bool _initialized;

		public event UOMapMouseEventHandler MouseMoveEvent;
		public event UOMapMouseEventHandler MouseDownEvent;
		public event UOMapMouseEventHandler MouseUpEvent;

		public UOMapControl()
		{
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.Selectable |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw, true);
			TabStop = true;
			BackColor = Color.Black;
		}

		public short MapFile
		{
			get { return _mapFile; }
			set
			{
				if (_mapFile != value)
				{
					_mapFile = value;
					if (_initialized && !string.IsNullOrEmpty(_clientPath))
						LoadMap();
				}
			}
		}

		public short ZoomLevel
		{
			get { return _zoomLevel; }
			set
			{
				_zoomLevel = value;
				Invalidate();
			}
		}

		public short xCenter
		{
			get { return _xCenter; }
			set { _xCenter = value; }
		}

		public short yCenter
		{
			get { return _yCenter; }
			set { _yCenter = value; }
		}

		public bool DrawStatics
		{
			get { return _drawStatics; }
			set
			{
				if (_drawStatics != value)
				{
					_drawStatics = value;
					if (_initialized && !string.IsNullOrEmpty(_clientPath))
						LoadMap();
				}
			}
		}

		public int ReadyState
		{
			get { return 4; }
		}

		public object OcxState { get; set; }

		public Control ContainingControl { get; set; }

		public void BeginInit() { }

		public void EndInit()
		{
			_initialized = true;
		}

		public void SetClientPath(string path)
		{
			_clientPath = path;
			LoadRadarCol();
			LoadMap();
		}

		public void SetCenter(short x, short y)
		{
			_xCenter = x;
			_yCenter = y;
			Invalidate();
		}

		public short CtrlToMapX(short ctrlX)
		{
			double ppt = Math.Pow(2.0, _zoomLevel);
			return (short)(_xCenter + (ctrlX - Width / 2.0) / ppt);
		}

		public short CtrlToMapY(short ctrlY)
		{
			double ppt = Math.Pow(2.0, _zoomLevel);
			return (short)(_yCenter + (ctrlY - Height / 2.0) / ppt);
		}

		public short MapToCtrlX(short mapX)
		{
			double ppt = Math.Pow(2.0, _zoomLevel);
			return (short)((mapX - _xCenter) * ppt + Width / 2.0);
		}

		public short MapToCtrlY(short mapY)
		{
			double ppt = Math.Pow(2.0, _zoomLevel);
			return (short)((mapY - _yCenter) * ppt + Height / 2.0);
		}

		public short GetMapHeight(short x, short y)
		{
			if (_mapHeights == null || x < 0 || y < 0 || x >= _mapWidth || y >= _mapHeight)
				return 0;
			return _mapHeights[(long)x * _mapHeight + y];
		}

		public int AddDrawObject(short x, short y, short shape, short size, int color)
		{
			_drawObjects.Add(new MapDrawObject { X = x, Y = y, Shape = shape, Size = size, Color = color });
			return _drawObjects.Count - 1;
		}

		public int AddDrawRect(short x, short y, short w, short h, short border, int color)
		{
			int index = _nextRectIndex++;
			_drawRects.Add(new MapDrawRect
			{
				X = x,
				Y = y,
				Width = w,
				Height = h,
				Border = border,
				Color = color,
				Index = index
			});
			return index;
		}

		public void RemoveDrawObjects()
		{
			_drawObjects.Clear();
		}

		public void RemoveDrawRects()
		{
			_drawRects.Clear();
			_nextRectIndex = 0;
		}

		public void RemoveDrawRectAt(int index)
		{
			for (int i = _drawRects.Count - 1; i >= 0; i--)
			{
				if (_drawRects[i].Index == index)
				{
					_drawRects.RemoveAt(i);
					break;
				}
			}
		}

		#region MUL File Loading

		private static readonly int[][] DefaultMapDimensions =
		{
			new[] { 7168, 4096 },
			new[] { 7168, 4096 },
			new[] { 2304, 1600 },
			new[] { 2560, 2048 },
			new[] { 1448, 1448 },
			new[] { 1280, 4096 },
		};

		private static readonly int[][] KnownDimensions =
		{
			new[] { 7168, 4096 },
			new[] { 6144, 4096 },
			new[] { 2304, 1600 },
			new[] { 2560, 2048 },
			new[] { 1448, 1448 },
			new[] { 1280, 4096 },
		};

		private void LoadRadarCol()
		{
			if (string.IsNullOrEmpty(_clientPath))
				return;

			string path = Path.Combine(_clientPath, "radarcol.mul");
			if (!File.Exists(path))
				return;

			byte[] data = File.ReadAllBytes(path);
			_radarCol = new ushort[data.Length / 2];
			Buffer.BlockCopy(data, 0, _radarCol, 0, data.Length);
		}

		private bool DetectMapDimensions(long fileSize, out int mapWidth, out int mapHeight)
		{
			long totalBlocks = fileSize / 196;

			foreach (var dim in KnownDimensions)
			{
				int bw = dim[0] / 8;
				int bh = dim[1] / 8;
				if ((long)bw * bh == totalBlocks)
				{
					mapWidth = dim[0];
					mapHeight = dim[1];
					return true;
				}
			}

			if (_mapFile < DefaultMapDimensions.Length)
			{
				int defaultBlockRows = DefaultMapDimensions[_mapFile][1] / 8;
				if (defaultBlockRows > 0 && totalBlocks % defaultBlockRows == 0)
				{
					int blockCols = (int)(totalBlocks / defaultBlockRows);
					mapWidth = blockCols * 8;
					mapHeight = DefaultMapDimensions[_mapFile][1];
					return true;
				}
			}

			mapWidth = 0;
			mapHeight = 0;
			return false;
		}

		private void LoadMap()
		{
			if (string.IsNullOrEmpty(_clientPath) || _radarCol == null)
				return;

			string mapPath = Path.Combine(_clientPath, "map" + _mapFile + ".mul");
			if (!File.Exists(mapPath))
				return;

			long fileSize = new FileInfo(mapPath).Length;

			int mw, mh;
			if (!DetectMapDimensions(fileSize, out mw, out mh))
				return;

			_mapWidth = mw;
			_mapHeight = mh;

			int blockCols = _mapWidth / 8;
			int blockRows = _mapHeight / 8;

			_mapHeights = new sbyte[_mapWidth * (long)_mapHeight];

			if (_radarBitmap != null)
			{
				_radarBitmap.Dispose();
				_radarBitmap = null;
			}

			_radarBitmap = new Bitmap(_mapWidth, _mapHeight, PixelFormat.Format32bppArgb);

			BitmapData bmpData = _radarBitmap.LockBits(
				new Rectangle(0, 0, _mapWidth, _mapHeight),
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppArgb);

			try
			{
				int stride = bmpData.Stride;
				byte[] pixelData = new byte[(long)_mapHeight * stride];

				using (BinaryReader reader = new BinaryReader(
					new BufferedStream(File.OpenRead(mapPath), 65536)))
				{
					byte[] blockBuf = new byte[196];

					for (int bx = 0; bx < blockCols; bx++)
					{
						for (int by = 0; by < blockRows; by++)
						{
							if (reader.Read(blockBuf, 0, 196) < 196)
								break;

							for (int cy = 0; cy < 8; cy++)
							{
								for (int cx = 0; cx < 8; cx++)
								{
									int cellOff = 4 + (cy * 8 + cx) * 3;
									ushort tileId = (ushort)(blockBuf[cellOff] | (blockBuf[cellOff + 1] << 8));
									sbyte z = (sbyte)blockBuf[cellOff + 2];

									int tileX = bx * 8 + cx;
									int tileY = by * 8 + cy;

									_mapHeights[(long)tileX * _mapHeight + tileY] = z;

									ushort radarColor = (tileId < _radarCol.Length) ? _radarCol[tileId] : (ushort)0;
									int argb = Color1555ToArgb(radarColor);

									int pixOff = tileY * stride + tileX * 4;
									pixelData[pixOff] = (byte)(argb);
									pixelData[pixOff + 1] = (byte)(argb >> 8);
									pixelData[pixOff + 2] = (byte)(argb >> 16);
									pixelData[pixOff + 3] = (byte)(argb >> 24);
								}
							}
						}
					}
				}

				if (_drawStatics)
				{
					OverlayStatics(pixelData, stride, blockCols, blockRows);
				}

				Marshal.Copy(pixelData, 0, bmpData.Scan0, pixelData.Length);
			}
			finally
			{
				_radarBitmap.UnlockBits(bmpData);
			}

			Invalidate();
		}

		private void OverlayStatics(byte[] pixelData, int stride, int blockCols, int blockRows)
		{
			string staidxPath = Path.Combine(_clientPath, "staidx" + _mapFile + ".mul");
			string staticsPath = Path.Combine(_clientPath, "statics" + _mapFile + ".mul");

			if (!File.Exists(staidxPath) || !File.Exists(staticsPath))
				return;

			using (BinaryReader idxReader = new BinaryReader(File.OpenRead(staidxPath)))
			using (BinaryReader statReader = new BinaryReader(File.OpenRead(staticsPath)))
			{
				sbyte[] bestZ = new sbyte[64];
				ushort[] bestId = new ushort[64];
				bool[] hasStatic = new bool[64];

				for (int bx = 0; bx < blockCols; bx++)
				{
					for (int by = 0; by < blockRows; by++)
					{
						long blockIndex = (long)bx * blockRows + by;
						long idxPos = blockIndex * 12;

						if (idxPos + 12 > idxReader.BaseStream.Length)
							continue;

						idxReader.BaseStream.Position = idxPos;
						int offset = idxReader.ReadInt32();
						int length = idxReader.ReadInt32();

						if (offset < 0 || length <= 0)
							continue;

						if (offset + length > statReader.BaseStream.Length)
							continue;

						statReader.BaseStream.Position = offset;
						int numStatics = length / 7;

						for (int i = 0; i < 64; i++)
						{
							bestZ[i] = sbyte.MinValue;
							hasStatic[i] = false;
						}

						for (int i = 0; i < numStatics; i++)
						{
							ushort itemId = statReader.ReadUInt16();
							byte xOff = statReader.ReadByte();
							byte yOff = statReader.ReadByte();
							sbyte z = statReader.ReadSByte();
							statReader.ReadUInt16();

							if (xOff < 8 && yOff < 8)
							{
								int ci = yOff * 8 + xOff;
								if (z > bestZ[ci])
								{
									bestZ[ci] = z;
									bestId[ci] = itemId;
									hasStatic[ci] = true;
								}
							}
						}

						for (int cy = 0; cy < 8; cy++)
						{
							for (int cx = 0; cx < 8; cx++)
							{
								int ci = cy * 8 + cx;
								if (!hasStatic[ci])
									continue;

								int radarIdx = 0x4000 + bestId[ci];
								if (radarIdx >= _radarCol.Length)
									continue;

								ushort col = _radarCol[radarIdx];
								if (col == 0)
									continue;

								int tileX = bx * 8 + cx;
								int tileY = by * 8 + cy;
								int argb = Color1555ToArgb(col);

								int pixOff = tileY * stride + tileX * 4;
								pixelData[pixOff] = (byte)(argb);
								pixelData[pixOff + 1] = (byte)(argb >> 8);
								pixelData[pixOff + 2] = (byte)(argb >> 16);
								pixelData[pixOff + 3] = (byte)(argb >> 24);
							}
						}
					}
				}
			}
		}

		private static int Color1555ToArgb(ushort color)
		{
			if (color == 0)
				return unchecked((int)0xFF000000);

			int r = ((color >> 10) & 0x1F) * 255 / 31;
			int g = ((color >> 5) & 0x1F) * 255 / 31;
			int b = (color & 0x1F) * 255 / 31;

			return unchecked((int)(0xFF000000u | (uint)(r << 16) | (uint)(g << 8) | (uint)b));
		}

		#endregion

		#region Rendering

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_radarBitmap == null)
				return;

			Graphics g = e.Graphics;
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.PixelOffsetMode = PixelOffsetMode.Half;

			double ppt = Math.Pow(2.0, _zoomLevel);

			float srcX = (float)(_xCenter - Width / (2.0 * ppt));
			float srcY = (float)(_yCenter - Height / (2.0 * ppt));
			float srcW = (float)(Width / ppt);
			float srcH = (float)(Height / ppt);

			RectangleF destRect = new RectangleF(0, 0, Width, Height);
			RectangleF srcRect = new RectangleF(srcX, srcY, srcW, srcH);

			g.DrawImage(_radarBitmap, destRect, srcRect, GraphicsUnit.Pixel);

			DrawOverlayRects(g, ppt);
			DrawOverlayObjects(g, ppt);
		}

		private void DrawOverlayRects(Graphics g, double ppt)
		{
			for (int i = 0; i < _drawRects.Count; i++)
			{
				MapDrawRect rect = _drawRects[i];

				float rx = (float)((rect.X - _xCenter) * ppt + Width / 2.0);
				float ry = (float)((rect.Y - _yCenter) * ppt + Height / 2.0);
				float rw = (float)(rect.Width * ppt);
				float rh = (float)(rect.Height * ppt);

				if (rw < 1) rw = 1;
				if (rh < 1) rh = 1;

				Color c = ColorFromRgbInt(rect.Color);

				if (rect.Border == 1)
				{
					using (SolidBrush brush = new SolidBrush(Color.FromArgb(48, c)))
					{
						g.FillRectangle(brush, rx, ry, rw, rh);
					}
					using (Pen pen = new Pen(c, 1))
					{
						g.DrawRectangle(pen, rx, ry, rw, rh);
					}
				}
				else
				{
					using (Pen pen = new Pen(c, rect.Border))
					{
						g.DrawRectangle(pen, rx, ry, rw, rh);
					}
				}
			}
		}

		private void DrawOverlayObjects(Graphics g, double ppt)
		{
			for (int i = 0; i < _drawObjects.Count; i++)
			{
				MapDrawObject obj = _drawObjects[i];

				float ox = (float)((obj.X - _xCenter) * ppt + Width / 2.0);
				float oy = (float)((obj.Y - _yCenter) * ppt + Height / 2.0);
				float sz = obj.Size;
				Color c = ColorFromRgbInt(obj.Color);

				switch (obj.Shape)
				{
					case 1:
						using (SolidBrush brush = new SolidBrush(c))
						{
							g.FillEllipse(brush, ox - sz / 2f, oy - sz / 2f, sz, sz);
						}
						break;
					case 2:
						using (SolidBrush brush = new SolidBrush(c))
						{
							g.FillRectangle(brush, ox - sz / 2f, oy - sz / 2f, sz, sz);
						}
						break;
					case 3:
						using (Pen pen = new Pen(c, 2))
						{
							g.DrawLine(pen, ox - sz / 2f, oy, ox + sz / 2f, oy);
							g.DrawLine(pen, ox, oy - sz / 2f, ox, oy + sz / 2f);
						}
						break;
					case 6:
						using (SolidBrush brush = new SolidBrush(c))
						{
							PointF[] pts =
							{
								new PointF(ox, oy - sz / 2f),
								new PointF(ox - sz / 2f, oy + sz / 2f),
								new PointF(ox + sz / 2f, oy + sz / 2f)
							};
							g.FillPolygon(brush, pts);
						}
						break;
					default:
						using (SolidBrush brush = new SolidBrush(c))
						{
							g.FillEllipse(brush, ox - sz / 2f, oy - sz / 2f, sz, sz);
						}
						break;
				}
			}
		}

		private static Color ColorFromRgbInt(int color)
		{
			int r = (color >> 16) & 0xFF;
			int gv = (color >> 8) & 0xFF;
			int b = color & 0xFF;
			return Color.FromArgb(255, r, gv, b);
		}

		#endregion

		#region Mouse Events

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			Focus();
			int button = 0;
			if (e.Button == MouseButtons.Left) button = 1;
			else if (e.Button == MouseButtons.Right) button = 2;

			if (MouseDownEvent != null)
				MouseDownEvent(this, new UOMapMouseEventArgs { x = e.X, y = e.Y, button = button });
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			int button = 0;
			if (e.Button == MouseButtons.Left) button = 1;
			else if (e.Button == MouseButtons.Right) button = 2;

			if (MouseUpEvent != null)
				MouseUpEvent(this, new UOMapMouseEventArgs { x = e.X, y = e.Y, button = button });
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			int button = 0;
			if (e.Button == MouseButtons.Left) button = 1;
			else if (e.Button == MouseButtons.Right) button = 2;

			if (MouseMoveEvent != null)
				MouseMoveEvent(this, new UOMapMouseEventArgs { x = e.X, y = e.Y, button = button });
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			Focus();
		}

		#endregion

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_radarBitmap != null)
				{
					_radarBitmap.Dispose();
					_radarBitmap = null;
				}
			}
			base.Dispose(disposing);
		}
	}
}
