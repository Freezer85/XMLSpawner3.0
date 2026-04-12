using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x0200000B RID: 11
	public class LocationSubNode : TreeNode
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00007507 File Offset: 0x00005707
		public object Node
		{
			get
			{
				return this._Node;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000750F File Offset: 0x0000570F
		public WorldMap Map
		{
			get
			{
				return this._Map;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00007517 File Offset: 0x00005717
		public LocationSubNode(object node, WorldMap map)
		{
			this._Node = node;
			this._Map = map;
			this.UpdateNode();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00007534 File Offset: 0x00005734
		public void UpdateNode()
		{
			base.Nodes.Clear();
			if (this._Node is ChildNode)
			{
				base.Text = (this._Node as ChildNode).Name;
				return;
			}
			if (!(this._Node is ParentNode))
			{
				return;
			}
			ParentNode parentNode = this._Node as ParentNode;
			base.Text = parentNode.Name;
			if (parentNode.Children == null)
			{
				return;
			}
			foreach (object node in parentNode.Children)
			{
				base.Nodes.Add(new LocationSubNode(node, this.Map));
			}
		}

		// Token: 0x04000097 RID: 151
		private object _Node;

		// Token: 0x04000098 RID: 152
		private WorldMap _Map;
	}
}
