using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000003 RID: 3
	public partial class Amount : Form
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002863 File Offset: 0x00000A63
		public int SpawnAmount
		{
			get
			{
				return (int)this.spnSpawnAmount.Value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002875 File Offset: 0x00000A75
		public string SpawnName
		{
			get
			{
				return this.txtSpawnObject.Text;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002882 File Offset: 0x00000A82
		public Amount(string Name, int Amount)
		{
			this.InitializeComponent();
			this.txtSpawnObject.Text = Name;
			this.spnSpawnAmount.Value = Amount;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002B33 File Offset: 0x00000D33
		private void btnOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002B42 File Offset: 0x00000D42
		private void spnSpawnAmount_Enter(object sender, EventArgs e)
		{
			this.spnSpawnAmount.Select(0, int.MaxValue);
		}
	}
}
