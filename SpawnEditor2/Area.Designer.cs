namespace SpawnEditor2
{
	// Token: 0x02000004 RID: 4
	public partial class Area : global::System.Windows.Forms.Form
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002CE8 File Offset: 0x00000EE8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002D08 File Offset: 0x00000F08
		private void InitializeComponent()
		{
			this.spnX = new global::System.Windows.Forms.NumericUpDown();
			this.spnY = new global::System.Windows.Forms.NumericUpDown();
			this.spnWidth = new global::System.Windows.Forms.NumericUpDown();
			this.spnHeight = new global::System.Windows.Forms.NumericUpDown();
			this.lblY = new global::System.Windows.Forms.Label();
			this.lblX = new global::System.Windows.Forms.Label();
			this.lblWidth = new global::System.Windows.Forms.Label();
			this.lblHeight = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.spnCentreZ = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.spnCentreY = new global::System.Windows.Forms.NumericUpDown();
			this.spnCentreX = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.btnUseMyLocation = new global::System.Windows.Forms.Button();
			this.spnX.BeginInit();
			this.spnY.BeginInit();
			this.spnWidth.BeginInit();
			this.spnHeight.BeginInit();
			this.spnCentreZ.BeginInit();
			this.spnCentreY.BeginInit();
			this.spnCentreX.BeginInit();
			base.SuspendLayout();
			this.spnX.Location = new global::System.Drawing.Point(8, 88);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.spnX;
			int[] bits = new int[4];
			bits[0] = 10000;
			decimal num = new decimal(bits);
			numericUpDown.Maximum = num;
			this.spnX.Name = "spnX";
			this.spnX.Size = new global::System.Drawing.Size(64, 20);
			this.spnX.TabIndex = 1;
			this.spnX.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnX.ValueChanged += new global::System.EventHandler(this.SpinBox_ValueChanged);
			this.spnY.Location = new global::System.Drawing.Point(48, 48);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.spnY;
			int[] bits2 = new int[4];
			bits2[0] = 10000;
			decimal num2 = new decimal(bits2);
			numericUpDown2.Maximum = num2;
			this.spnY.Name = "spnY";
			this.spnY.Size = new global::System.Drawing.Size(64, 20);
			this.spnY.TabIndex = 3;
			this.spnY.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnY.ValueChanged += new global::System.EventHandler(this.SpinBox_ValueChanged);
			this.spnWidth.Location = new global::System.Drawing.Point(88, 88);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.spnWidth;
			int[] bits3 = new int[4];
			bits3[0] = 10000;
			decimal num3 = new decimal(bits3);
			numericUpDown3.Maximum = num3;
			this.spnWidth.Name = "spnWidth";
			this.spnWidth.Size = new global::System.Drawing.Size(64, 20);
			this.spnWidth.TabIndex = 5;
			this.spnWidth.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnWidth.ValueChanged += new global::System.EventHandler(this.SpinBox_ValueChanged);
			this.spnHeight.Location = new global::System.Drawing.Point(48, 128);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.spnHeight;
			int[] bits4 = new int[4];
			bits4[0] = 10000;
			decimal num4 = new decimal(bits4);
			numericUpDown4.Maximum = num4;
			this.spnHeight.Name = "spnHeight";
			this.spnHeight.Size = new global::System.Drawing.Size(64, 20);
			this.spnHeight.TabIndex = 7;
			this.spnHeight.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnHeight.ValueChanged += new global::System.EventHandler(this.SpinBox_ValueChanged);
			this.lblY.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblY.Location = new global::System.Drawing.Point(48, 32);
			this.lblY.Name = "lblY";
			this.lblY.Size = new global::System.Drawing.Size(64, 16);
			this.lblY.TabIndex = 2;
			this.lblY.Text = "Y";
			this.lblY.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblX.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblX.Location = new global::System.Drawing.Point(8, 72);
			this.lblX.Name = "lblX";
			this.lblX.Size = new global::System.Drawing.Size(64, 16);
			this.lblX.TabIndex = 0;
			this.lblX.Text = "X";
			this.lblX.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblWidth.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblWidth.Location = new global::System.Drawing.Point(88, 72);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new global::System.Drawing.Size(64, 16);
			this.lblWidth.TabIndex = 4;
			this.lblWidth.Text = "Width";
			this.lblWidth.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblHeight.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHeight.Location = new global::System.Drawing.Point(48, 112);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new global::System.Drawing.Size(64, 16);
			this.lblHeight.TabIndex = 6;
			this.lblHeight.Text = "Height";
			this.lblHeight.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(176, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(8, 8);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.TabStop = false;
			this.btnCancel.Text = "Cancel";
			this.spnCentreZ.Location = new global::System.Drawing.Point(48, 248);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.spnCentreZ;
			int[] bits5 = new int[4];
			bits5[0] = 65000;
			decimal num5 = new decimal(bits5);
			numericUpDown5.Maximum = num5;
			this.spnCentreZ.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
			this.spnCentreZ.Name = "spnCentreZ";
			this.spnCentreZ.Size = new global::System.Drawing.Size(80, 20);
			this.spnCentreZ.TabIndex = 9;
			this.spnCentreZ.ValueChanged += new global::System.EventHandler(this.spnCentreZ_ValueChanged);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(8, 248);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Z";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.spnCentreY.Location = new global::System.Drawing.Point(48, 224);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.spnCentreY;
			int[] bits6 = new int[4];
			bits6[0] = 10000;
			decimal num6 = new decimal(bits6);
			numericUpDown6.Maximum = num6;
			this.spnCentreY.Name = "spnCentreY";
			this.spnCentreY.Size = new global::System.Drawing.Size(80, 20);
			this.spnCentreY.TabIndex = 11;
			this.spnCentreY.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnCentreY.ValueChanged += new global::System.EventHandler(this.spnCentreY_ValueChanged);
			this.spnCentreX.Location = new global::System.Drawing.Point(48, 200);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.spnCentreX;
			int[] bits7 = new int[4];
			bits7[0] = 10000;
			decimal num7 = new decimal(bits7);
			numericUpDown7.Maximum = num7;
			this.spnCentreX.Name = "spnCentreX";
			this.spnCentreX.Size = new global::System.Drawing.Size(80, 20);
			this.spnCentreX.TabIndex = 12;
			this.spnCentreX.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnCentreX.ValueChanged += new global::System.EventHandler(this.spnCentreX_ValueChanged);
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(8, 224);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(32, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Y";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(8, 200);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(32, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "X";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(24, 176);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(112, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "Spawner Location";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(24, 8);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(112, 16);
			this.label5.TabIndex = 16;
			this.label5.Text = "Spawner Bounds";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.btnUseMyLocation.Location = new global::System.Drawing.Point(8, 272);
			this.btnUseMyLocation.Name = "btnUseMyLocation";
			this.btnUseMyLocation.Size = new global::System.Drawing.Size(144, 23);
			this.btnUseMyLocation.TabIndex = 17;
			this.btnUseMyLocation.Text = "Usa posizione staff";
			this.btnUseMyLocation.UseVisualStyleBackColor = true;
			this.btnUseMyLocation.Click += new global::System.EventHandler(this.btnUseMyLocation_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(160, 304);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnUseMyLocation);
			base.Controls.Add(this.spnCentreX);
			base.Controls.Add(this.spnCentreY);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.spnCentreZ);
			base.Controls.Add(this.lblHeight);
			base.Controls.Add(this.lblWidth);
			base.Controls.Add(this.lblX);
			base.Controls.Add(this.lblY);
			base.Controls.Add(this.spnHeight);
			base.Controls.Add(this.spnWidth);
			base.Controls.Add(this.spnY);
			base.Controls.Add(this.spnX);
			base.Controls.Add(this.btnCancel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.KeyPreview = true;
			base.Name = "Area";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Location and Bounds";
			base.TransparencyKey = global::System.Drawing.Color.Red;
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.Area_KeyDown);
			base.Load += new global::System.EventHandler(this.Area_Load);
			this.spnX.EndInit();
			this.spnY.EndInit();
			this.spnWidth.EndInit();
			this.spnHeight.EndInit();
			this.spnCentreZ.EndInit();
			this.spnCentreY.EndInit();
			this.spnCentreX.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000013 RID: 19
		private global::System.ComponentModel.Container components;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.NumericUpDown spnX;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.NumericUpDown spnY;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.NumericUpDown spnWidth;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.NumericUpDown spnHeight;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label lblY;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label lblX;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label lblWidth;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label lblHeight;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Button btnUseMyLocation;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.NumericUpDown spnCentreZ;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.NumericUpDown spnCentreY;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.NumericUpDown spnCentreX;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label label5;
	}
}
