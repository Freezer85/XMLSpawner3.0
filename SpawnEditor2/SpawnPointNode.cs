using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x0200001B RID: 27
	public class SpawnPointNode : TreeNode
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00024471 File Offset: 0x00022671
		public SpawnPoint Spawn
		{
			get
			{
				return this._Spawn;
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00024479 File Offset: 0x00022679
		public SpawnPointNode(SpawnPoint Spawn)
		{
			this._Spawn = Spawn;
			this.UpdateNode();
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00024490 File Offset: 0x00022690
		public void UpdateNode()
		{
			base.Text = this._Spawn.SpawnName;
			base.Nodes.Clear();
			foreach (object obj in this._Spawn.SpawnObjects)
			{
				SpawnObject SpawnObject = (SpawnObject)obj;
				base.Nodes.Add(new SpawnObjectNode(SpawnObject));
			}
		}

		// Token: 0x040002B4 RID: 692
		private SpawnPoint _Spawn;

		// Token: 0x040002B5 RID: 693
		public bool Filtered;

		// Token: 0x040002B6 RID: 694
		public bool Highlighted;
	}
}
