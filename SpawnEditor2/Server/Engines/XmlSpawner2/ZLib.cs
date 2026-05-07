using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x0200002D RID: 45
	public class ZLib
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0002A898 File Offset: 0x00028A98
		public static byte[] Compress(object source)
		{
			byte[] array;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
				MemoryStream memoryStream = new MemoryStream();
				xmlSerializer.Serialize(memoryStream, source);
				byte[] source2 = memoryStream.ToArray();
				memoryStream.Close();
				int length = source2.Length;
				byte[] compressed = ManagedCompress(source2);
				if (compressed == null)
				{
					array = new byte[0];
				}
				else
				{
					byte[] numArray = new byte[compressed.Length + 4];
					Array.Copy(compressed, 0, numArray, 4, compressed.Length);
					numArray[0] = (byte)length;
					numArray[1] = (byte)(length >> 8);
					numArray[2] = (byte)(length >> 16);
					numArray[3] = (byte)(length >> 24);
					array = numArray;
				}
			}
			catch (Exception ex)
			{
				try
				{
					File.AppendAllText("spawneditor.log", string.Format("{0} [ERROR]: ZLib.Compress exception for {1}: {2}{3}", DateTime.Now, (source != null) ? source.GetType().FullName : "<null>", ex, Environment.NewLine));
				}
				catch
				{
				}
				array = new byte[0];
			}
			return array;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0002A950 File Offset: 0x00028B50
		public static object Decompress(byte[] data, Type type)
		{
			object obj;
			try
			{
				if (data == null || data.Length < 4)
				{
					throw new InvalidDataException(string.Format("Compressed payload too short. Length={0}, Type={1}", (data != null) ? data.Length : 0, (type != null) ? type.FullName : "<null>"));
				}
				int destLen = (int)data[0] | ((int)data[1] << 8) | ((int)data[2] << 16) | ((int)data[3] << 24);
				byte[] decompressed = ManagedDecompress(data, 4, data.Length - 4, destLen);
				if (decompressed == null)
				{
					obj = null;
				}
				else
				{
					MemoryStream memoryStream = new MemoryStream(decompressed);
					object obj2 = new XmlSerializer(type).Deserialize(memoryStream);
					memoryStream.Close();
					obj = obj2;
				}
			}
			catch (Exception ex)
			{
				try
				{
					File.AppendAllText("spawneditor.log", string.Format("{0} [ERROR]: ZLib.Decompress exception for {1}: payloadLength={2}, error={3}{4}", DateTime.Now, (type != null) ? type.FullName : "<null>", (data != null) ? data.Length : 0, ex, Environment.NewLine));
				}
				catch
				{
				}
				System.Windows.Forms.MessageBox.Show("ZLib.Decompress exception: " + ex.ToString(), "ZLib Diagnostic");
				obj = null;
			}
			return obj;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0002A9E0 File Offset: 0x00028BE0
		public static byte[] Compress(byte[] data)
		{
			byte[] compressed = ManagedCompress(data);
			if (compressed == null)
				return null;
			int length = data.Length;
			byte[] numArray = new byte[compressed.Length + 4];
			Array.Copy(compressed, 0, numArray, 4, compressed.Length);
			numArray[0] = (byte)(length & 255);
			numArray[1] = (byte)((length >> 8) & 255);
			numArray[2] = (byte)((length >> 16) & 255);
			numArray[3] = (byte)((length >> 24) & 255);
			return numArray;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0002AA58 File Offset: 0x00028C58
		public static byte[] Decompress(byte[] data)
		{
			int destLen = (int)data[0] | ((int)data[1] << 8) | ((int)data[2] << 16) | ((int)data[3] << 24);
			return ManagedDecompress(data, 4, data.Length - 4, destLen);
		}

		/// <summary>
		/// Compress data in zlib format using managed DeflateStream (adds 2-byte zlib header).
		/// </summary>
		private static byte[] ManagedCompress(byte[] data)
		{
			try
			{
				using (MemoryStream output = new MemoryStream())
				{
					// Write 2-byte zlib header (CMF=0x78, FLG=0xDA for best compression)
					output.WriteByte(0x78);
					output.WriteByte(0xDA);
					using (DeflateStream deflate = new DeflateStream(output, CompressionLevel.Optimal, true))
					{
						deflate.Write(data, 0, data.Length);
					}

					// Compute and append Adler-32 checksum of the uncompressed data (big-endian)
					uint a = 1;
					uint b = 0;
					const uint MOD_ADLER = 65521;
					for (int i = 0; i < data.Length; ++i)
					{
						a = (a + (uint)(data[i])) % MOD_ADLER;
						b = (b + a) % MOD_ADLER;
					}
					uint adler = (b << 16) | a;
					output.WriteByte((byte)((adler >> 24) & 0xFF));
					output.WriteByte((byte)((adler >> 16) & 0xFF));
					output.WriteByte((byte)((adler >> 8) & 0xFF));
					output.WriteByte((byte)(adler & 0xFF));
					return output.ToArray();
				}
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Decompress zlib-format data using managed DeflateStream (skips 2-byte zlib header).
		/// </summary>
		private static byte[] ManagedDecompress(byte[] data, int offset, int count, int expectedLen)
		{
			try
			{
				// zlib format: 2-byte header (CMF+FLG) + deflate data + 4-byte Adler-32
				// Skip the 2-byte zlib header, DeflateStream handles raw deflate
				using (MemoryStream compressed = new MemoryStream(data, offset + 2, count - 2))
				using (DeflateStream deflate = new DeflateStream(compressed, CompressionMode.Decompress))
				using (MemoryStream result = new MemoryStream(expectedLen))
				{
					deflate.CopyTo(result);
					return result.ToArray();
				}
			}
			catch
			{
				return null;
			}
		}

	}
}
