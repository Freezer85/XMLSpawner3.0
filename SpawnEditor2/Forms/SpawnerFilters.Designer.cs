namespace SpawnEditor2.Forms
{
	// Token: 0x0200001F RID: 31
	public partial class SpawnerFilters : global::System.Windows.Forms.Form
	{
		// Token: 0x06000224 RID: 548 RVA: 0x00028DB8 File Offset: 0x00026FB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00028DD8 File Offset: 0x00026FD8
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.cmbNotes = new global::System.Windows.Forms.ComboBox();
			this.txtNotes = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.txtPropertyTest = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cmbSpawnerMap = new global::System.Windows.Forms.ComboBox();
			this.cmbEntryHas2 = new global::System.Windows.Forms.ComboBox();
			this.chkEntryCase2 = new global::System.Windows.Forms.CheckBox();
			this.txtSpawnerEntry2 = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cmbEntryTypeHas2 = new global::System.Windows.Forms.ComboBox();
			this.txtSpawnerEntryType2 = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbEntryTypeHas = new global::System.Windows.Forms.ComboBox();
			this.cmbEntryHas = new global::System.Windows.Forms.ComboBox();
			this.cmbNameHas = new global::System.Windows.Forms.ComboBox();
			this.txtSpawnerEntryType = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.numAvgSpawnTime = new global::System.Windows.Forms.NumericUpDown();
			this.cmbAvgSpawnTime = new global::System.Windows.Forms.ComboBox();
			this.chkAvgSpawnTime = new global::System.Windows.Forms.CheckBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.cmbRunning = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.cmbProximity = new global::System.Windows.Forms.ComboBox();
			this.chkNameCase = new global::System.Windows.Forms.CheckBox();
			this.chkEntryCase = new global::System.Windows.Forms.CheckBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cmbSequential = new global::System.Windows.Forms.ComboBox();
			this.cmbInContainers = new global::System.Windows.Forms.ComboBox();
			this.cmbSmartSpawning = new global::System.Windows.Forms.ComboBox();
			this.txtSpawnerEntry = new global::System.Windows.Forms.TextBox();
			this.label38 = new global::System.Windows.Forms.Label();
			this.txtSpawnerName = new global::System.Windows.Forms.TextBox();
			this.label30 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnApply = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.numAvgSpawnTime.BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.cmbNotes);
			this.groupBox1.Controls.Add(this.txtNotes);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtPropertyTest);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.cmbSpawnerMap);
			this.groupBox1.Controls.Add(this.cmbEntryHas2);
			this.groupBox1.Controls.Add(this.chkEntryCase2);
			this.groupBox1.Controls.Add(this.txtSpawnerEntry2);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cmbEntryTypeHas2);
			this.groupBox1.Controls.Add(this.txtSpawnerEntryType2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cmbEntryTypeHas);
			this.groupBox1.Controls.Add(this.cmbEntryHas);
			this.groupBox1.Controls.Add(this.cmbNameHas);
			this.groupBox1.Controls.Add(this.txtSpawnerEntryType);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.numAvgSpawnTime);
			this.groupBox1.Controls.Add(this.cmbAvgSpawnTime);
			this.groupBox1.Controls.Add(this.chkAvgSpawnTime);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.cmbRunning);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.cmbProximity);
			this.groupBox1.Controls.Add(this.chkNameCase);
			this.groupBox1.Controls.Add(this.chkEntryCase);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmbSequential);
			this.groupBox1.Controls.Add(this.cmbInContainers);
			this.groupBox1.Controls.Add(this.cmbSmartSpawning);
			this.groupBox1.Controls.Add(this.txtSpawnerEntry);
			this.groupBox1.Controls.Add(this.label38);
			this.groupBox1.Controls.Add(this.txtSpawnerName);
			this.groupBox1.Controls.Add(this.label30);
			this.groupBox1.Location = new global::System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(344, 416);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter Settings";
			this.cmbNotes.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNotes.Items.AddRange(new object[] { "has", "has not" });
			this.cmbNotes.Location = new global::System.Drawing.Point(48, 168);
			this.cmbNotes.Name = "cmbNotes";
			this.cmbNotes.Size = new global::System.Drawing.Size(64, 21);
			this.cmbNotes.TabIndex = 270;
			this.txtNotes.Location = new global::System.Drawing.Point(112, 168);
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new global::System.Drawing.Size(168, 20);
			this.txtNotes.TabIndex = 268;
			this.txtNotes.Text = "";
			this.label8.Location = new global::System.Drawing.Point(8, 168);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(40, 16);
			this.label8.TabIndex = 269;
			this.label8.Text = "Notes:";
			this.txtPropertyTest.Location = new global::System.Drawing.Point(80, 352);
			this.txtPropertyTest.Name = "txtPropertyTest";
			this.txtPropertyTest.Size = new global::System.Drawing.Size(256, 20);
			this.txtPropertyTest.TabIndex = 266;
			this.txtPropertyTest.Text = "";
			this.label7.Location = new global::System.Drawing.Point(8, 352);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(80, 16);
			this.label7.TabIndex = 267;
			this.label7.Text = "Property Test:";
			this.cmbSpawnerMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpawnerMap.Items.AddRange(new object[] { "Current map", "All maps" });
			this.cmbSpawnerMap.Location = new global::System.Drawing.Point(8, 384);
			this.cmbSpawnerMap.Name = "cmbSpawnerMap";
			this.cmbSpawnerMap.Size = new global::System.Drawing.Size(96, 21);
			this.cmbSpawnerMap.TabIndex = 265;
			this.cmbEntryHas2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntryHas2.Items.AddRange(new object[] { "has", "has not" });
			this.cmbEntryHas2.Location = new global::System.Drawing.Point(48, 72);
			this.cmbEntryHas2.Name = "cmbEntryHas2";
			this.cmbEntryHas2.Size = new global::System.Drawing.Size(64, 21);
			this.cmbEntryHas2.TabIndex = 264;
			this.chkEntryCase2.Location = new global::System.Drawing.Point(232, 72);
			this.chkEntryCase2.Name = "chkEntryCase2";
			this.chkEntryCase2.Size = new global::System.Drawing.Size(104, 16);
			this.chkEntryCase2.TabIndex = 263;
			this.chkEntryCase2.Text = "Case sensitive";
			this.txtSpawnerEntry2.Location = new global::System.Drawing.Point(112, 72);
			this.txtSpawnerEntry2.Name = "txtSpawnerEntry2";
			this.txtSpawnerEntry2.Size = new global::System.Drawing.Size(112, 20);
			this.txtSpawnerEntry2.TabIndex = 261;
			this.txtSpawnerEntry2.Text = "";
			this.label6.Location = new global::System.Drawing.Point(8, 72);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(40, 16);
			this.label6.TabIndex = 262;
			this.label6.Text = "Entry:";
			this.cmbEntryTypeHas2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntryTypeHas2.Items.AddRange(new object[] { "has", "has not" });
			this.cmbEntryTypeHas2.Location = new global::System.Drawing.Point(64, 120);
			this.cmbEntryTypeHas2.Name = "cmbEntryTypeHas2";
			this.cmbEntryTypeHas2.Size = new global::System.Drawing.Size(64, 21);
			this.cmbEntryTypeHas2.TabIndex = 260;
			this.txtSpawnerEntryType2.Location = new global::System.Drawing.Point(128, 120);
			this.txtSpawnerEntryType2.Name = "txtSpawnerEntryType2";
			this.txtSpawnerEntryType2.Size = new global::System.Drawing.Size(152, 20);
			this.txtSpawnerEntryType2.TabIndex = 258;
			this.txtSpawnerEntryType2.Text = "";
			this.label5.Location = new global::System.Drawing.Point(8, 120);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(80, 16);
			this.label5.TabIndex = 259;
			this.label5.Text = "Entry Type:";
			this.cmbEntryTypeHas.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntryTypeHas.Items.AddRange(new object[] { "has", "has not" });
			this.cmbEntryTypeHas.Location = new global::System.Drawing.Point(64, 96);
			this.cmbEntryTypeHas.Name = "cmbEntryTypeHas";
			this.cmbEntryTypeHas.Size = new global::System.Drawing.Size(64, 21);
			this.cmbEntryTypeHas.TabIndex = 257;
			this.cmbEntryHas.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntryHas.Items.AddRange(new object[] { "has", "has not" });
			this.cmbEntryHas.Location = new global::System.Drawing.Point(48, 48);
			this.cmbEntryHas.Name = "cmbEntryHas";
			this.cmbEntryHas.Size = new global::System.Drawing.Size(64, 21);
			this.cmbEntryHas.TabIndex = 256;
			this.cmbNameHas.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNameHas.Items.AddRange(new object[] { "has", "has not" });
			this.cmbNameHas.Location = new global::System.Drawing.Point(48, 24);
			this.cmbNameHas.Name = "cmbNameHas";
			this.cmbNameHas.Size = new global::System.Drawing.Size(64, 21);
			this.cmbNameHas.TabIndex = 255;
			this.txtSpawnerEntryType.Location = new global::System.Drawing.Point(128, 96);
			this.txtSpawnerEntryType.Name = "txtSpawnerEntryType";
			this.txtSpawnerEntryType.Size = new global::System.Drawing.Size(152, 20);
			this.txtSpawnerEntryType.TabIndex = 253;
			this.txtSpawnerEntryType.Text = "";
			this.label2.Location = new global::System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(80, 16);
			this.label2.TabIndex = 254;
			this.label2.Text = "Entry Type:";
			this.label18.Location = new global::System.Drawing.Point(280, 312);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(48, 16);
			this.label18.TabIndex = 252;
			this.label18.Text = "minutes";
			this.numAvgSpawnTime.DecimalPlaces = 1;
			this.numAvgSpawnTime.Location = new global::System.Drawing.Point(208, 312);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numAvgSpawnTime;
			int[] bits = new int[4];
			bits[0] = 65535;
			decimal num = new decimal(bits);
			numericUpDown.Maximum = num;
			this.numAvgSpawnTime.Name = "numAvgSpawnTime";
			this.numAvgSpawnTime.Size = new global::System.Drawing.Size(72, 20);
			this.numAvgSpawnTime.TabIndex = 251;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numAvgSpawnTime;
			int[] bits2 = new int[4];
			bits2[0] = 10;
			decimal num2 = new decimal(bits2);
			numericUpDown2.Value = num2;
			this.cmbAvgSpawnTime.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvgSpawnTime.Items.AddRange(new object[] { "less than", "greater than" });
			this.cmbAvgSpawnTime.Location = new global::System.Drawing.Point(120, 312);
			this.cmbAvgSpawnTime.Name = "cmbAvgSpawnTime";
			this.cmbAvgSpawnTime.Size = new global::System.Drawing.Size(88, 21);
			this.cmbAvgSpawnTime.TabIndex = 249;
			this.chkAvgSpawnTime.Location = new global::System.Drawing.Point(8, 312);
			this.chkAvgSpawnTime.Name = "chkAvgSpawnTime";
			this.chkAvgSpawnTime.Size = new global::System.Drawing.Size(112, 16);
			this.chkAvgSpawnTime.TabIndex = 250;
			this.chkAvgSpawnTime.Text = "Avg. Spawn Time";
			this.label17.Location = new global::System.Drawing.Point(16, 288);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(112, 16);
			this.label17.TabIndex = 248;
			this.label17.Text = "Running:";
			this.label17.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbRunning.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRunning.Items.AddRange(new object[] { "No Restriction", "Running Only", "Not Running" });
			this.cmbRunning.Location = new global::System.Drawing.Point(128, 288);
			this.cmbRunning.Name = "cmbRunning";
			this.cmbRunning.Size = new global::System.Drawing.Size(152, 21);
			this.cmbRunning.TabIndex = 247;
			this.label16.Location = new global::System.Drawing.Point(16, 264);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(112, 16);
			this.label16.TabIndex = 246;
			this.label16.Text = "ProximityTriggered:";
			this.label16.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbProximity.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProximity.Items.AddRange(new object[] { "No Restriction", "ProximityTriggered Only", "Not ProximityTriggered " });
			this.cmbProximity.Location = new global::System.Drawing.Point(128, 264);
			this.cmbProximity.Name = "cmbProximity";
			this.cmbProximity.Size = new global::System.Drawing.Size(152, 21);
			this.cmbProximity.TabIndex = 245;
			this.chkNameCase.Location = new global::System.Drawing.Point(232, 24);
			this.chkNameCase.Name = "chkNameCase";
			this.chkNameCase.Size = new global::System.Drawing.Size(104, 16);
			this.chkNameCase.TabIndex = 240;
			this.chkNameCase.Text = "Case sensitive";
			this.chkEntryCase.Location = new global::System.Drawing.Point(232, 48);
			this.chkEntryCase.Name = "chkEntryCase";
			this.chkEntryCase.Size = new global::System.Drawing.Size(104, 16);
			this.chkEntryCase.TabIndex = 241;
			this.chkEntryCase.Text = "Case sensitive";
			this.label4.Location = new global::System.Drawing.Point(56, 240);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(72, 16);
			this.label4.TabIndex = 239;
			this.label4.Text = "InContainers:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new global::System.Drawing.Point(16, 216);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(112, 16);
			this.label3.TabIndex = 238;
			this.label3.Text = "SequentialSpawning:";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label1.Location = new global::System.Drawing.Point(40, 192);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(88, 16);
			this.label1.TabIndex = 237;
			this.label1.Text = "SmartSpawning:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbSequential.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSequential.Items.AddRange(new object[] { "No Restriction", "Sequential Only", "Not Sequential" });
			this.cmbSequential.Location = new global::System.Drawing.Point(128, 216);
			this.cmbSequential.Name = "cmbSequential";
			this.cmbSequential.Size = new global::System.Drawing.Size(152, 21);
			this.cmbSequential.TabIndex = 236;
			this.cmbInContainers.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInContainers.Items.AddRange(new object[] { "No Restriction", "InContainer Only", "Not InContainer" });
			this.cmbInContainers.Location = new global::System.Drawing.Point(128, 240);
			this.cmbInContainers.Name = "cmbInContainers";
			this.cmbInContainers.Size = new global::System.Drawing.Size(152, 21);
			this.cmbInContainers.TabIndex = 235;
			this.cmbSmartSpawning.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSmartSpawning.Items.AddRange(new object[] { "No Restriction", "SmartSpawned Only", "Not SmartSpawned" });
			this.cmbSmartSpawning.Location = new global::System.Drawing.Point(128, 192);
			this.cmbSmartSpawning.Name = "cmbSmartSpawning";
			this.cmbSmartSpawning.Size = new global::System.Drawing.Size(152, 21);
			this.cmbSmartSpawning.TabIndex = 234;
			this.txtSpawnerEntry.Location = new global::System.Drawing.Point(112, 48);
			this.txtSpawnerEntry.Name = "txtSpawnerEntry";
			this.txtSpawnerEntry.Size = new global::System.Drawing.Size(112, 20);
			this.txtSpawnerEntry.TabIndex = 232;
			this.txtSpawnerEntry.Text = "";
			this.label38.Location = new global::System.Drawing.Point(8, 48);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(40, 16);
			this.label38.TabIndex = 233;
			this.label38.Text = "Entry:";
			this.txtSpawnerName.Location = new global::System.Drawing.Point(112, 24);
			this.txtSpawnerName.Name = "txtSpawnerName";
			this.txtSpawnerName.Size = new global::System.Drawing.Size(112, 20);
			this.txtSpawnerName.TabIndex = 230;
			this.txtSpawnerName.Text = "";
			this.label30.Location = new global::System.Drawing.Point(8, 24);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(40, 16);
			this.label30.TabIndex = 231;
			this.label30.Text = "Name:";
			this.btnClose.Location = new global::System.Drawing.Point(208, 448);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(96, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnApply.Location = new global::System.Drawing.Point(64, 448);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new global::System.Drawing.Size(96, 24);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.Click += new global::System.EventHandler(this.btnApply_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(360, 480);
			base.ControlBox = false;
			base.Controls.Add(this.btnApply);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Name = "SpawnerFilters";
			this.Text = "Spawner Display Filter Settings";
			this.groupBox1.ResumeLayout(false);
			this.numAvgSpawnTime.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000319 RID: 793
		private global::System.ComponentModel.Container components;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.Label label18;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.NumericUpDown numAvgSpawnTime;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.ComboBox cmbAvgSpawnTime;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.CheckBox chkAvgSpawnTime;

		// Token: 0x0400031F RID: 799
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000320 RID: 800
		internal global::System.Windows.Forms.ComboBox cmbRunning;

		// Token: 0x04000321 RID: 801
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000322 RID: 802
		internal global::System.Windows.Forms.ComboBox cmbProximity;

		// Token: 0x04000323 RID: 803
		internal global::System.Windows.Forms.CheckBox chkNameCase;

		// Token: 0x04000324 RID: 804
		internal global::System.Windows.Forms.CheckBox chkEntryCase;

		// Token: 0x04000325 RID: 805
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000326 RID: 806
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000327 RID: 807
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000328 RID: 808
		internal global::System.Windows.Forms.ComboBox cmbSequential;

		// Token: 0x04000329 RID: 809
		internal global::System.Windows.Forms.ComboBox cmbInContainers;

		// Token: 0x0400032A RID: 810
		internal global::System.Windows.Forms.ComboBox cmbSmartSpawning;

		// Token: 0x0400032B RID: 811
		internal global::System.Windows.Forms.TextBox txtSpawnerEntry;

		// Token: 0x0400032C RID: 812
		private global::System.Windows.Forms.Label label38;

		// Token: 0x0400032D RID: 813
		internal global::System.Windows.Forms.TextBox txtSpawnerName;

		// Token: 0x0400032E RID: 814
		private global::System.Windows.Forms.Label label30;

		// Token: 0x0400032F RID: 815
		internal global::System.Windows.Forms.TextBox txtSpawnerEntryType;

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000333 RID: 819
		private global::System.Windows.Forms.Button btnApply;

		// Token: 0x04000334 RID: 820
		internal global::System.Windows.Forms.ComboBox cmbNameHas;

		// Token: 0x04000335 RID: 821
		internal global::System.Windows.Forms.ComboBox cmbEntryHas;

		// Token: 0x04000336 RID: 822
		internal global::System.Windows.Forms.ComboBox cmbEntryTypeHas;

		// Token: 0x04000337 RID: 823
		internal global::System.Windows.Forms.ComboBox cmbEntryTypeHas2;

		// Token: 0x04000338 RID: 824
		internal global::System.Windows.Forms.TextBox txtSpawnerEntryType2;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400033A RID: 826
		internal global::System.Windows.Forms.ComboBox cmbEntryHas2;

		// Token: 0x0400033B RID: 827
		internal global::System.Windows.Forms.TextBox txtSpawnerEntry2;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400033D RID: 829
		internal global::System.Windows.Forms.CheckBox chkEntryCase2;

		// Token: 0x0400033E RID: 830
		private global::System.Windows.Forms.ComboBox cmbSpawnerMap;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.TextBox txtPropertyTest;

		// Token: 0x04000341 RID: 833
		internal global::System.Windows.Forms.ComboBox cmbNotes;

		// Token: 0x04000342 RID: 834
		internal global::System.Windows.Forms.TextBox txtNotes;

		// Token: 0x04000343 RID: 835
		private global::System.Windows.Forms.Label label8;
	}
}
