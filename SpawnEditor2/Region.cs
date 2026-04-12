using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x02000011 RID: 17
	public class Region : IComparable
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00008CE5 File Offset: 0x00006EE5
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00008CED File Offset: 0x00006EED
		public bool LoadFromXml
		{
			get
			{
				return this.m_Load;
			}
			set
			{
				this.m_Load = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00008CF6 File Offset: 0x00006EF6
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00008CFE File Offset: 0x00006EFE
		public string Name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00008D07 File Offset: 0x00006F07
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00008D0F File Offset: 0x00006F0F
		public string Prefix
		{
			get
			{
				return this.m_Prefix;
			}
			set
			{
				this.m_Prefix = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00008D18 File Offset: 0x00006F18
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00008D20 File Offset: 0x00006F20
		public MusicName Music
		{
			get
			{
				return this.m_Music;
			}
			set
			{
				this.m_Music = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00008D29 File Offset: 0x00006F29
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00008D31 File Offset: 0x00006F31
		public MapLocation GoLocation
		{
			get
			{
				return this.m_GoLoc;
			}
			set
			{
				this.m_GoLoc = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00008D3A File Offset: 0x00006F3A
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00008D42 File Offset: 0x00006F42
		public WorldMap Map
		{
			get
			{
				return this.m_Map;
			}
			set
			{
				Region.RemoveRegion(this);
				this.m_Map = value;
				Region.AddRegion(this);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00008D57 File Offset: 0x00006F57
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00008D5F File Offset: 0x00006F5F
		public ArrayList InnBounds
		{
			get
			{
				return this.m_InnBounds;
			}
			set
			{
				this.m_InnBounds = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00008D68 File Offset: 0x00006F68
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00008D70 File Offset: 0x00006F70
		public ArrayList Coords
		{
			get
			{
				return this.m_Coords;
			}
			set
			{
				if (this.m_Coords == value)
				{
					return;
				}
				Region.RemoveRegion(this);
				this.m_Coords = value;
				Region.AddRegion(this);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00008D8F File Offset: 0x00006F8F
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00008D97 File Offset: 0x00006F97
		public int Priority
		{
			get
			{
				return this.m_Priority;
			}
			set
			{
				if (value == this.m_Priority)
				{
					return;
				}
				this.m_Priority = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00008DAA File Offset: 0x00006FAA
		public int UId
		{
			get
			{
				return this.m_UId;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00008DB2 File Offset: 0x00006FB2
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00008DBA File Offset: 0x00006FBA
		public int MinZ
		{
			get
			{
				return this.m_MinZ;
			}
			set
			{
				Region.RemoveRegion(this);
				this.m_MinZ = value;
				Region.AddRegion(this);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00008DCF File Offset: 0x00006FCF
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00008DD7 File Offset: 0x00006FD7
		public int MaxZ
		{
			get
			{
				return this.m_MaxZ;
			}
			set
			{
				Region.RemoveRegion(this);
				this.m_MaxZ = value;
				Region.AddRegion(this);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00008DEC File Offset: 0x00006FEC
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00008DF3 File Offset: 0x00006FF3
		public static bool SupressXmlWarnings
		{
			get
			{
				return Region.m_SupressXmlWarnings;
			}
			set
			{
				Region.m_SupressXmlWarnings = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00008DFB File Offset: 0x00006FFB
		public static ArrayList Regions
		{
			get
			{
				return Region.m_Regions;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008E02 File Offset: 0x00007002
		public Region(string prefix, string name, WorldMap map, int uid)
			: this(prefix, name, map)
		{
			this.m_UId = uid | 1073741824;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008E1C File Offset: 0x0000701C
		public Region(string prefix, string name, WorldMap map)
		{
			this.m_Prefix = prefix;
			this.m_Name = name;
			this.m_Map = map;
			this.m_Priority = 0;
			this.m_GoLoc = MapLocation.Zero;
			this.m_Load = true;
			this.m_UId = Region.m_RegionUID++;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008E8D File Offset: 0x0000708D
		public static bool operator <(Region l, Region r)
		{
			return (!Region.IsNull(l) || !Region.IsNull(r)) && (Region.IsNull(l) || (!Region.IsNull(r) && l.Priority > r.Priority));
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00008EC3 File Offset: 0x000070C3
		public static bool operator >(Region l, Region r)
		{
			return (!Region.IsNull(l) || !Region.IsNull(r)) && !Region.IsNull(l) && (Region.IsNull(r) || l.Priority < r.Priority);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008EF7 File Offset: 0x000070F7
		public static bool operator ==(Region l, Region r)
		{
			if (Region.IsNull(l))
			{
				return Region.IsNull(r);
			}
			return !Region.IsNull(r) && l.UId == r.UId;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00008F20 File Offset: 0x00007120
		public static bool operator !=(Region l, Region r)
		{
			if (Region.IsNull(l))
			{
				return !Region.IsNull(r);
			}
			return Region.IsNull(r) || l.UId != r.UId;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00008F50 File Offset: 0x00007150
		public int CompareTo(object o)
		{
			if (!(o is Region))
			{
				return 0;
			}
			int num = ((Region)o).m_Priority;
			int num2 = this.m_Priority;
			if (num < num2)
			{
				return -1;
			}
			return (num > num2) ? 1 : 0;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00008F84 File Offset: 0x00007184
		public virtual bool Contains(MapLocation p)
		{
			if (this.m_Coords == null)
			{
				return false;
			}
			for (int index = 0; index < this.m_Coords.Count; index++)
			{
				object obj = this.m_Coords[index];
				if (obj is Rectangle && ((Rectangle)obj).Contains(p.X, p.Y))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00008FE5 File Offset: 0x000071E5
		public override string ToString()
		{
			if (this.Prefix != "")
			{
				return string.Format("{0} {1}", this.Prefix, this.Name);
			}
			return this.Name;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00009016 File Offset: 0x00007216
		public static bool IsNull(Region r)
		{
			return r == null;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000901C File Offset: 0x0000721C
		public override bool Equals(object o)
		{
			return o is Region && o != null && (Region)o == this;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00009037 File Offset: 0x00007237
		public override int GetHashCode()
		{
			return this.m_UId;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00009040 File Offset: 0x00007240
		public static Region GetByName(string name, WorldMap map)
		{
			for (int index = 0; index < Region.m_Regions.Count; index++)
			{
				Region region = (Region)Region.m_Regions[index];
				if (region.Map == map && region.Name == name)
				{
					return region;
				}
			}
			return null;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009090 File Offset: 0x00007290
		public static object ParseRectangle(XmlElement rect, bool supports3d)
		{
			int x;
			int y;
			int num;
			int num2;
			if (rect.HasAttribute("x") && rect.HasAttribute("y") && rect.HasAttribute("width") && rect.HasAttribute("height"))
			{
				x = int.Parse(rect.GetAttribute("x"));
				y = int.Parse(rect.GetAttribute("y"));
				num = x + int.Parse(rect.GetAttribute("width"));
				num2 = y + int.Parse(rect.GetAttribute("height"));
			}
			else
			{
				if (!rect.HasAttribute("x1") || !rect.HasAttribute("y1") || !rect.HasAttribute("x2") || !rect.HasAttribute("y2"))
				{
					throw new ArgumentException("Wrong attributes specified.");
				}
				x = int.Parse(rect.GetAttribute("x1"));
				y = int.Parse(rect.GetAttribute("y1"));
				num = int.Parse(rect.GetAttribute("x2"));
				num2 = int.Parse(rect.GetAttribute("y2"));
			}
			return new Rectangle(x, y, num - x, num2 - y);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000091B4 File Offset: 0x000073B4
		public static void Load(string basedir)
		{
			string str = Path.Combine(basedir, "Data\\Regions.xml");
			if (!File.Exists(str))
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(str);
			foreach (object obj in xmlDocument["ServerRegions"].GetElementsByTagName("Facet"))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string attribute = xmlElement.GetAttribute("name");
				WorldMap map = WorldMap.Internal;
				try
				{
					map = (WorldMap)Enum.Parse(typeof(WorldMap), attribute, true);
				}
				catch
				{
				}
				if (map == WorldMap.Internal)
				{
					if (!Region.m_SupressXmlWarnings)
					{
						Console.WriteLine("Regions.xml: Invalid facet name '{0}'", attribute);
					}
				}
				else
				{
					foreach (object obj2 in xmlElement.GetElementsByTagName("region"))
					{
						XmlElement xmlElement2 = (XmlElement)obj2;
						string attribute2 = xmlElement2.GetAttribute("name");
						if (attribute2 != null && attribute2.Length > 0)
						{
							Region region = new Region("", attribute2, map);
							Region.AddRegion(region);
							try
							{
								region.Priority = int.Parse(xmlElement2.GetAttribute("priority"));
							}
							catch
							{
								if (!Region.m_SupressXmlWarnings)
								{
									Console.WriteLine("Regions.xml: Could not parse priority for region '{0}' (assuming TownPriority)", region.Name);
								}
								region.Priority = 50;
							}
							XmlElement xmlElement3 = xmlElement2["go"];
							if (xmlElement3 != null)
							{
								try
								{
									region.GoLocation = MapLocation.Parse(xmlElement3.GetAttribute("location"));
									region.GoLocation.Facet = (int)map;
								}
								catch
								{
									if (!Region.m_SupressXmlWarnings)
									{
										Console.WriteLine("Regions.xml: Could not parse go location for region '{0}'", region.Name);
									}
								}
							}
							XmlElement xmlElement4 = xmlElement2["music"];
							if (xmlElement4 != null)
							{
								try
								{
									region.Music = (MusicName)Enum.Parse(typeof(MusicName), xmlElement4.GetAttribute("name"), true);
								}
								catch
								{
									if (!Region.m_SupressXmlWarnings)
									{
										Console.WriteLine("Regions.xml: Could not parse music for region '{0}'", region.Name);
									}
								}
							}
							XmlElement xmlElement5 = xmlElement2["zrange"];
							if (xmlElement5 != null)
							{
								string attribute3 = xmlElement5.GetAttribute("min");
								if (attribute3 != null && attribute3 != "")
								{
									try
									{
										region.MinZ = int.Parse(attribute3);
									}
									catch
									{
										if (!Region.m_SupressXmlWarnings)
										{
											Console.WriteLine("Regions.xml: Could not parse zrange:min for region '{0}'", region.Name);
										}
									}
								}
								string attribute4 = xmlElement5.GetAttribute("max");
								if (attribute4 != null && attribute4 != "")
								{
									try
									{
										region.MaxZ = int.Parse(attribute4);
									}
									catch
									{
										if (!Region.m_SupressXmlWarnings)
										{
											Console.WriteLine("Regions.xml: Could not parse zrange:max for region '{0}'", region.Name);
										}
									}
								}
							}
							foreach (object obj3 in xmlElement2.GetElementsByTagName("rect"))
							{
								XmlElement rect = (XmlElement)obj3;
								try
								{
									if (region.m_LoadCoords == null)
									{
										region.m_LoadCoords = new ArrayList(1);
									}
									region.m_LoadCoords.Add(Region.ParseRectangle(rect, true));
								}
								catch
								{
									if (!Region.m_SupressXmlWarnings)
									{
										Console.WriteLine("Regions.xml: Error parsing rect for region '{0}'", region.Name);
									}
								}
							}
							foreach (object obj4 in xmlElement2.GetElementsByTagName("inn"))
							{
								XmlElement rect2 = (XmlElement)obj4;
								try
								{
									if (region.InnBounds == null)
									{
										region.InnBounds = new ArrayList(1);
									}
									region.InnBounds.Add(Region.ParseRectangle(rect2, false));
								}
								catch
								{
									if (!Region.m_SupressXmlWarnings)
									{
										Console.WriteLine("Regions.xml: Error parsing inn for region '{0}'", region.Name);
									}
								}
							}
						}
					}
				}
			}
			ArrayList arrayList = new ArrayList(Region.m_Regions);
			for (int index = 0; index < arrayList.Count; index++)
			{
				Region region2 = (Region)arrayList[index];
				if (!region2.LoadFromXml && region2.m_Coords == null)
				{
					region2.Coords = new ArrayList();
				}
				else if (region2.LoadFromXml)
				{
					if (region2.m_LoadCoords == null)
					{
						region2.m_LoadCoords = new ArrayList();
					}
					region2.Coords = region2.m_LoadCoords;
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00009748 File Offset: 0x00007948
		public static void AddRegion(Region region)
		{
			Region.m_Regions.Add(region);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009756 File Offset: 0x00007956
		public static void RemoveRegion(Region region)
		{
			Region.m_Regions.Remove(region);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00009764 File Offset: 0x00007964
		public static Region FindByUId(int uid)
		{
			for (int index = 0; index < Region.m_Regions.Count; index++)
			{
				Region region = (Region)Region.m_Regions[index];
				if (region.UId == uid)
				{
					return region;
				}
			}
			return null;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000097A4 File Offset: 0x000079A4
		public static Region Find(MapLocation p, WorldMap map)
		{
			if (map == WorldMap.Internal)
			{
				return null;
			}
			for (int index = 0; index < Region.m_Regions.Count; index++)
			{
				Region region = (Region)Region.m_Regions[index];
				if (region.Map == map && region.Contains(p))
				{
					return region;
				}
			}
			return null;
		}

		// Token: 0x040000E1 RID: 225
		private static int m_RegionUID = 1;

		// Token: 0x040000E2 RID: 226
		private static bool m_SupressXmlWarnings = true;

		// Token: 0x040000E3 RID: 227
		private static ArrayList m_Regions = new ArrayList();

		// Token: 0x040000E4 RID: 228
		private MusicName m_Music = MusicName.Invalid;

		// Token: 0x040000E5 RID: 229
		private int m_MinZ = -32768;

		// Token: 0x040000E6 RID: 230
		private int m_MaxZ = 32767;

		// Token: 0x040000E7 RID: 231
		public const int LowestPriority = 0;

		// Token: 0x040000E8 RID: 232
		public const int HighestPriority = 150;

		// Token: 0x040000E9 RID: 233
		public const int TownPriority = 50;

		// Token: 0x040000EA RID: 234
		public const int HousePriority = 150;

		// Token: 0x040000EB RID: 235
		public const int InnPriority = 51;

		// Token: 0x040000EC RID: 236
		private int m_Priority;

		// Token: 0x040000ED RID: 237
		private ArrayList m_Coords;

		// Token: 0x040000EE RID: 238
		private ArrayList m_InnBounds;

		// Token: 0x040000EF RID: 239
		private WorldMap m_Map;

		// Token: 0x040000F0 RID: 240
		private string m_Name;

		// Token: 0x040000F1 RID: 241
		private string m_Prefix;

		// Token: 0x040000F2 RID: 242
		private MapLocation m_GoLoc;

		// Token: 0x040000F3 RID: 243
		private int m_UId;

		// Token: 0x040000F4 RID: 244
		private bool m_Load;

		// Token: 0x040000F5 RID: 245
		private ArrayList m_LoadCoords;

		// Token: 0x040000F6 RID: 246
		public static SpawnEditor Editor;
	}
}
