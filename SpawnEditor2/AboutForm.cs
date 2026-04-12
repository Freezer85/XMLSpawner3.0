using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000002 RID: 2
	public partial class AboutForm : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public AboutForm(SpawnEditor editor)
		{
			this._Editor = editor;
			this.InitializeComponent();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000027B8 File Offset: 0x000009B8
		private void TestForm_Load(object sender, EventArgs e)
		{
			if (this._Editor.TopMost)
			{
				base.TopMost = true;
			}
			this.labelVersion.Text = string.Format("Version {0}", Assembly.GetAssembly(typeof(SpawnEditor)).GetName().Version);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002807 File Offset: 0x00000A07
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002810 File Offset: 0x00000A10
		private void linkDonation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				this.VisitLink();
			}
			catch
			{
				MessageBox.Show("Unable to open link.");
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002844 File Offset: 0x00000A44
		private void VisitLink()
		{
			this.linkDonation.LinkVisited = true;
			Process.Start(this.linkDonation.Text);
		}

		// Token: 0x0400000D RID: 13
		private SpawnEditor _Editor;
	}
}
