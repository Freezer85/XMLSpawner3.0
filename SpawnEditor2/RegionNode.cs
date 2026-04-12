using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000013 RID: 19
	public class RegionNode : TreeNode
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00009840 File Offset: 0x00007A40
		public Region Region
		{
			get
			{
				return this._Region;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00009848 File Offset: 0x00007A48
		public RegionNode(Region region)
		{
			this._Region = region;
			this.UpdateNode();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000985D File Offset: 0x00007A5D
		public void UpdateNode()
		{
			base.Text = this._Region.Name;
		}

		// Token: 0x040000F8 RID: 248
		private Region _Region;
	}
}
