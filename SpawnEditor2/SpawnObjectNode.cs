using System;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000016 RID: 22
	public class SpawnObjectNode : TreeNode
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00021668 File Offset: 0x0001F868
		public SpawnObject SpawnObject
		{
			get
			{
				return this._Object;
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00021670 File Offset: 0x0001F870
		public SpawnObjectNode(SpawnObject SpawnObject)
		{
			this._Object = SpawnObject;
			this.UpdateNode();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00021685 File Offset: 0x0001F885
		public void UpdateNode()
		{
			base.Text = this._Object.ToString();
		}

		// Token: 0x04000279 RID: 633
		private SpawnObject _Object;
	}
}
