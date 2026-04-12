using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x0200000C RID: 12
	public class LocationTree
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000075D0 File Offset: 0x000057D0
		public Hashtable LastBranch
		{
			get
			{
				return this.m_LastBranch;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000075D8 File Offset: 0x000057D8
		public WorldMap Map
		{
			get
			{
				return this.m_Map;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000075E0 File Offset: 0x000057E0
		public ParentNode Root
		{
			get
			{
				return this.m_Root;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000075E8 File Offset: 0x000057E8
		public LocationTree(string dirname, string fileName, WorldMap map)
		{
			this.m_LastBranch = new Hashtable();
			this.m_Map = map;
			string path = Path.Combine(Path.Combine(dirname, "Data\\Locations\\"), fileName);
			if (!File.Exists(path))
			{
				return;
			}
			XmlTextReader xml = new XmlTextReader(new StreamReader(path));
			xml.WhitespaceHandling = WhitespaceHandling.None;
			this.m_Root = this.Parse(xml);
			xml.Close();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000764E File Offset: 0x0000584E
		private ParentNode Parse(XmlTextReader xml)
		{
			xml.Read();
			xml.Read();
			xml.Read();
			return new ParentNode(xml, null);
		}

		// Token: 0x04000099 RID: 153
		private WorldMap m_Map;

		// Token: 0x0400009A RID: 154
		private ParentNode m_Root;

		// Token: 0x0400009B RID: 155
		private Hashtable m_LastBranch;
	}
}
