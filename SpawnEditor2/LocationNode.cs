using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x0200000A RID: 10
	public class LocationNode : TreeNode
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00007468 File Offset: 0x00005668
		public LocationNode(LocationTree ltree)
		{
			this._LTree = ltree;
			this.UpdateNode();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00007480 File Offset: 0x00005680
		public void UpdateNode()
		{
			base.Text = this._LTree.Map.ToString();
			base.Nodes.Clear();
			ParentNode root = this._LTree.Root;
			if (root == null || root.Children == null)
			{
				return;
			}
			foreach (object node in root.Children)
			{
				base.Nodes.Add(new LocationSubNode(node, this._LTree.Map));
			}
		}

		// Token: 0x04000096 RID: 150
		private LocationTree _LTree;
	}
}
