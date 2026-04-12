using System;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x02000005 RID: 5
	public class ChildNode
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00003E4F File Offset: 0x0000204F
		public ParentNode Parent
		{
			get
			{
				return this.m_Parent;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00003E57 File Offset: 0x00002057
		public string Name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00003E5F File Offset: 0x0000205F
		public MapLocation Location
		{
			get
			{
				return this.m_Location;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003E67 File Offset: 0x00002067
		public ChildNode(XmlTextReader xml, ParentNode parent)
		{
			this.m_Parent = parent;
			this.Parse(xml);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003E80 File Offset: 0x00002080
		private void Parse(XmlTextReader xml)
		{
			this.m_Name = ((!xml.MoveToAttribute("name")) ? "empty" : xml.Value);
			int x = 0;
			int y = 0;
			int z = 0;
			if (xml.MoveToAttribute("x"))
			{
				try
				{
					x = int.Parse(xml.Value);
				}
				catch
				{
				}
			}
			if (xml.MoveToAttribute("y"))
			{
				try
				{
					y = int.Parse(xml.Value);
				}
				catch
				{
				}
			}
			if (xml.MoveToAttribute("z"))
			{
				try
				{
					z = int.Parse(xml.Value);
				}
				catch
				{
				}
			}
			this.m_Location = new MapLocation(x, y, z);
		}

		// Token: 0x04000028 RID: 40
		private ParentNode m_Parent;

		// Token: 0x04000029 RID: 41
		private string m_Name;

		// Token: 0x0400002A RID: 42
		private MapLocation m_Location;
	}
}
