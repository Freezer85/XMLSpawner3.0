using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000007 RID: 7
	public partial class EntryEdit : Form
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000060D0 File Offset: 0x000042D0
		public EntryEdit(SpawnEditor editor)
		{
			this._Editor = editor;
			this.InitializeComponent();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00006550 File Offset: 0x00004750
		private void EntryEdit_Load(object sender, EventArgs e)
		{
			if (!this._Editor.TopMost)
			{
				return;
			}
			base.TopMost = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00006567 File Offset: 0x00004767
		private void btnOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00006576 File Offset: 0x00004776
		private void fontDialog1_Apply(object sender, EventArgs e)
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00006578 File Offset: 0x00004778
		private void menuItem1_Click(object sender, EventArgs e)
		{
			this.textEntryEdit.Font = new Font(this.textEntryEdit.Font.Name, 8f);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000659F File Offset: 0x0000479F
		private void menuItem2_Click(object sender, EventArgs e)
		{
			this.textEntryEdit.Font = new Font(this.textEntryEdit.Font.Name, 10f);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000065C6 File Offset: 0x000047C6
		private void menuItem3_Click(object sender, EventArgs e)
		{
			this.textEntryEdit.Font = new Font(this.textEntryEdit.Font.Name, 12f);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000065ED File Offset: 0x000047ED
		private void menuItem4_Click(object sender, EventArgs e)
		{
			this.textEntryEdit.Font = new Font(this.textEntryEdit.Font.Name, 14f);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00006614 File Offset: 0x00004814
		private void menuItem5_Click(object sender, EventArgs e)
		{
			this.textEntryEdit.Font = new Font(this.textEntryEdit.Font.Name, 18f);
		}

		// Token: 0x04000093 RID: 147
		private SpawnEditor _Editor;
	}
}
