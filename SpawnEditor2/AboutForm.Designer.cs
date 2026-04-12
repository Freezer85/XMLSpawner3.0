namespace SpawnEditor2
{
	// Token: 0x02000002 RID: 2
	public partial class AboutForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002065 File Offset: 0x00000265
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002084 File Offset: 0x00000284
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::SpawnEditor2.AboutForm));
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label8 = new global::System.Windows.Forms.Label();
			this.linkDonation = new global::System.Windows.Forms.LinkLabel();
			base.SuspendLayout();
			this.pictureBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = (global::System.Drawing.Image)resourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(24, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(312, 176);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.label1.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(70, 32);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(230, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Spawn Editor 2";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labelVersion.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelVersion.Location = new global::System.Drawing.Point(70, 48);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(230, 16);
			this.labelVersion.TabIndex = 2;
			this.labelVersion.Text = "Version ###";
			this.labelVersion.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label3.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(72, 88);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(230, 24);
			this.label3.TabIndex = 3;
			this.label3.Text = "written by ArteGordon, 7/7/05";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label4.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(32, 112);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(296, 64);
			this.label4.TabIndex = 4;
			this.label4.Text = "If you find this, or any of the XmlSpawner2 programs useful, please consider making a donation to the American Epilepsy Foundation, or any other worthy charitable cause.";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label5.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(72, 208);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(248, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "modified from the original Spawn Editor";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label6.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(72, 224);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(200, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "written by BobSmart";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label7.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(72, 240);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(200, 24);
			this.label7.TabIndex = 7;
			this.label7.Text = "April 16, 2003";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.button1.Location = new global::System.Drawing.Point(144, 264);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(88, 24);
			this.button1.TabIndex = 8;
			this.button1.Text = "OK";
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label8.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(70, 64);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(230, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "updated October 5, 2005";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.linkDonation.Location = new global::System.Drawing.Point(48, 176);
			this.linkDonation.Name = "linkDonation";
			this.linkDonation.Size = new global::System.Drawing.Size(264, 16);
			this.linkDonation.TabIndex = 10;
			this.linkDonation.TabStop = true;
			this.linkDonation.Text = "http://www.epilepsyfoundation.org/howtohelp/index.cfm";
			this.linkDonation.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDonation_LinkClicked);
			base.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(360, 297);
			base.ControlBox = false;
			base.Controls.Add(this.linkDonation);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.labelVersion);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox1);
			base.Name = "AboutForm";
			this.Text = "About Spawn Editor 2";
			base.Load += new global::System.EventHandler(this.TestForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.Container components;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label labelVersion;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.LinkLabel linkDonation;
	}
}
