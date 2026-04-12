using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000012 RID: 18
	public class RegionFacetNode : TreeNode
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000980A File Offset: 0x00007A0A
		public WorldMap Facet
		{
			get
			{
				return this._Facet;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00009812 File Offset: 0x00007A12
		public RegionFacetNode(WorldMap facet)
		{
			this._Facet = facet;
			this.UpdateNode();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00009827 File Offset: 0x00007A27
		public void UpdateNode()
		{
			base.Text = this._Facet.ToString();
		}

		// Token: 0x040000F7 RID: 247
		private WorldMap _Facet;
	}
}
