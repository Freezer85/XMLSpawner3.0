using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000018 RID: 24
	public class SpawnPackSubNode : TreeNode
	{
		// Token: 0x06000197 RID: 407 RVA: 0x000217A3 File Offset: 0x0001F9A3
		public SpawnPackSubNode(string item)
		{
			this._Item = item;
			base.Text = item;
		}

		// Token: 0x0400027B RID: 635
		private string _Item;
	}
}
