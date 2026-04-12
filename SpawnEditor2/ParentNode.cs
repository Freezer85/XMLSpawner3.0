using System;
using System.Collections;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x0200000F RID: 15
	public class ParentNode
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00007774 File Offset: 0x00005974
		public ParentNode Parent
		{
			get
			{
				return this.m_Parent;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004D RID: 77 RVA: 0x0000777C File Offset: 0x0000597C
		public object[] Children
		{
			get
			{
				return this.m_Children;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00007784 File Offset: 0x00005984
		public string Name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000778C File Offset: 0x0000598C
		public ParentNode(XmlTextReader xml, ParentNode parent)
		{
			this.m_Parent = parent;
			this.Parse(xml);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000077A4 File Offset: 0x000059A4
		private void Parse(XmlTextReader xml)
		{
			this.m_Name = ((!xml.MoveToAttribute("name")) ? "empty" : xml.Value);
			if (xml.IsEmptyElement)
			{
				this.m_Children = new object[0];
				return;
			}
			ArrayList arrayList = new ArrayList();
			while (xml.Read() && xml.NodeType == XmlNodeType.Element)
			{
				if (xml.Name == "child")
				{
					ChildNode childNode = new ChildNode(xml, this);
					arrayList.Add(childNode);
				}
				else
				{
					arrayList.Add(new ParentNode(xml, this));
				}
			}
			this.m_Children = arrayList.ToArray();
		}

		// Token: 0x040000D6 RID: 214
		private ParentNode m_Parent;

		// Token: 0x040000D7 RID: 215
		private object[] m_Children;

		// Token: 0x040000D8 RID: 216
		private string m_Name;
	}
}
