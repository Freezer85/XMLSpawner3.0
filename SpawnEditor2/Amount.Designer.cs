namespace SpawnEditor2
{
	// Token: 0x02000003 RID: 3
	public partial class Amount : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000028AD File Offset: 0x00000AAD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000028CC File Offset: 0x00000ACC
		private void InitializeComponent()
		{
			this.txtSpawnObject = new global::System.Windows.Forms.TextBox();
			this.spnSpawnAmount = new global::System.Windows.Forms.NumericUpDown();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.spnSpawnAmount.BeginInit();
			base.SuspendLayout();
			this.txtSpawnObject.Location = new global::System.Drawing.Point(3, 8);
			this.txtSpawnObject.Name = "txtSpawnObject";
			this.txtSpawnObject.ReadOnly = true;
			this.txtSpawnObject.Size = new global::System.Drawing.Size(208, 20);
			this.txtSpawnObject.TabIndex = 0;
			this.txtSpawnObject.TabStop = false;
			this.txtSpawnObject.Text = "";
			this.spnSpawnAmount.Location = new global::System.Drawing.Point(213, 8);
			this.spnSpawnAmount.Name = "spnSpawnAmount";
			this.spnSpawnAmount.Size = new global::System.Drawing.Size(75, 20);
			this.spnSpawnAmount.TabIndex = 1;
			this.spnSpawnAmount.Enter += new global::System.EventHandler(this.spnSpawnAmount_Enter);
			this.btnOk.Location = new global::System.Drawing.Point(136, 32);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&Ok";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(213, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(292, 61);
			base.Controls.AddRange(new global::System.Windows.Forms.Control[] { this.btnCancel, this.btnOk, this.spnSpawnAmount, this.txtSpawnObject });
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Amount";
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Amount";
			this.spnSpawnAmount.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400000E RID: 14
		private global::System.ComponentModel.Container components;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TextBox txtSpawnObject;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.NumericUpDown spnSpawnAmount;
	}
}
