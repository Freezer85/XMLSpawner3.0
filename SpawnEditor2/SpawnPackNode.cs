using System;
using System.Collections;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000017 RID: 23
	public class SpawnPackNode : TreeNode
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00021698 File Offset: 0x0001F898
		// (set) Token: 0x06000192 RID: 402 RVA: 0x000216A0 File Offset: 0x0001F8A0
		public string PackName
		{
			get
			{
				return this._packName;
			}
			set
			{
				this._packName = value;
				base.Text = this._packName;
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000216B5 File Offset: 0x0001F8B5
		public SpawnPackNode(string packName, CheckedListBox.ObjectCollection items)
		{
			this._packName = packName;
			this.UpdateNode(items);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000216CB File Offset: 0x0001F8CB
		public SpawnPackNode(string packName, ArrayList items)
		{
			this._packName = packName;
			this.UpdateNode(items);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000216E4 File Offset: 0x0001F8E4
		public void UpdateNode(CheckedListBox.ObjectCollection items)
		{
			base.Text = this._packName;
			base.Nodes.Clear();
			if (items == null || items.Count <= 0)
			{
				return;
			}
			for (int index = 0; index < items.Count; index++)
			{
				base.Nodes.Add(new SpawnPackSubNode((string)items[index]));
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00021744 File Offset: 0x0001F944
		public void UpdateNode(ArrayList items)
		{
			base.Text = this._packName;
			base.Nodes.Clear();
			if (items == null || items.Count <= 0)
			{
				return;
			}
			for (int index = 0; index < items.Count; index++)
			{
				base.Nodes.Add(new SpawnPackSubNode((string)items[index]));
			}
		}

		// Token: 0x0400027A RID: 634
		private string _packName;
	}
}
