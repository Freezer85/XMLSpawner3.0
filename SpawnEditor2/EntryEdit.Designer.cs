namespace SpawnEditor2
{
	// Token: 0x02000007 RID: 7
	public partial class EntryEdit : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000060E5 File Offset: 0x000042E5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00006104 File Offset: 0x00004304
		private void InitializeComponent()
		{
			this.textEntryEdit = new global::System.Windows.Forms.TextBox();
			this.contextMenu1 = new global::System.Windows.Forms.ContextMenu();
			this.menuItem1 = new global::System.Windows.Forms.MenuItem();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.fontDialog1 = new global::System.Windows.Forms.FontDialog();
			this.menuItem2 = new global::System.Windows.Forms.MenuItem();
			this.menuItem3 = new global::System.Windows.Forms.MenuItem();
			this.menuItem4 = new global::System.Windows.Forms.MenuItem();
			this.menuItem5 = new global::System.Windows.Forms.MenuItem();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.textEntryEdit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textEntryEdit.ContextMenu = this.contextMenu1;
			this.textEntryEdit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textEntryEdit.Location = new global::System.Drawing.Point(8, 8);
			this.textEntryEdit.Multiline = true;
			this.textEntryEdit.Name = "textEntryEdit";
			this.textEntryEdit.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textEntryEdit.Size = new global::System.Drawing.Size(320, 224);
			this.textEntryEdit.TabIndex = 0;
			this.textEntryEdit.Text = "";
			this.contextMenu1.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem1, this.menuItem2, this.menuItem3, this.menuItem4, this.menuItem5 });
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Font 8pt";
			this.menuItem1.Click += new global::System.EventHandler(this.menuItem1_Click);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(88, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnOk.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnOk.Location = new global::System.Drawing.Point(8, 248);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "&Ok";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.panel1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.panel1.Controls.Add(this.textEntryEdit);
			this.panel1.Location = new global::System.Drawing.Point(8, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(336, 240);
			this.panel1.TabIndex = 6;
			this.fontDialog1.Apply += new global::System.EventHandler(this.fontDialog1_Apply);
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Font 10pt";
			this.menuItem2.Click += new global::System.EventHandler(this.menuItem2_Click);
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Font 12pt";
			this.menuItem3.Click += new global::System.EventHandler(this.menuItem3_Click);
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Font 14pt";
			this.menuItem4.Click += new global::System.EventHandler(this.menuItem4_Click);
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "Font 18pt";
			this.menuItem5.Click += new global::System.EventHandler(this.menuItem5_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(344, 273);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Name = "EntryEdit";
			base.Load += new global::System.EventHandler(this.EntryEdit_Load);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000087 RID: 135
		private global::System.ComponentModel.Container components;

		// Token: 0x04000088 RID: 136
		public global::System.Windows.Forms.TextBox textEntryEdit;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.FontDialog fontDialog1;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.ContextMenu contextMenu1;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.MenuItem menuItem1;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.MenuItem menuItem2;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.MenuItem menuItem3;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.MenuItem menuItem4;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.MenuItem menuItem5;
	}
}
