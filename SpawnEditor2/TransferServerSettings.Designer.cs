namespace SpawnEditor2
{
	// Token: 0x0200001D RID: 29
	public partial class TransferServerSettings : global::System.Windows.Forms.Form
	{
		// Token: 0x06000211 RID: 529 RVA: 0x00024697 File Offset: 0x00022897
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000246B8 File Offset: 0x000228B8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.grpTransferServer = new global::System.Windows.Forms.GroupBox();
			this.listItems = new global::System.Windows.Forms.ListBox();
			this.cmbItemMap = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.cmbCarried = new global::System.Windows.Forms.ComboBox();
			this.txtItemID = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.cmbMovable = new global::System.Windows.Forms.ComboBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.cmbVisible = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.cmbItemInContainers = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.cmbStatics = new global::System.Windows.Forms.ComboBox();
			this.txtItemType = new global::System.Windows.Forms.TextBox();
			this.label43 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cmbBlessed = new global::System.Windows.Forms.ComboBox();
			this.btnDLItems = new global::System.Windows.Forms.Button();
			this.grpSpawner = new global::System.Windows.Forms.GroupBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.numAvgSpawnTime = new global::System.Windows.Forms.NumericUpDown();
			this.cmbAvgSpawnTime = new global::System.Windows.Forms.ComboBox();
			this.chkAvgSpawnTime = new global::System.Windows.Forms.CheckBox();
			this.chkSpawnerWithinSelectionWindow = new global::System.Windows.Forms.CheckBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.cmbRunning = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.cmbProximity = new global::System.Windows.Forms.ComboBox();
			this.cmbSpawnerMap = new global::System.Windows.Forms.ComboBox();
			this.cmbModified = new global::System.Windows.Forms.ComboBox();
			this.chkModified = new global::System.Windows.Forms.CheckBox();
			this.dtModified = new global::System.Windows.Forms.DateTimePicker();
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
			this.btnDLSpawners = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.transferServer = new global::System.Windows.Forms.GroupBox();
			this.txtTransferServerPort = new global::System.Windows.Forms.TextBox();
			this.txtTransferServerAddress = new global::System.Windows.Forms.TextBox();
			this.label40 = new global::System.Windows.Forms.Label();
			this.label41 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.listCreatures = new global::System.Windows.Forms.ListBox();
			this.cmbCreatureMap = new global::System.Windows.Forms.ComboBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.cmbControlled = new global::System.Windows.Forms.ComboBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.cmbInnocent = new global::System.Windows.Forms.ComboBox();
			this.txtCreatureType = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnDLCreatures = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.chkShowPlayers = new global::System.Windows.Forms.CheckBox();
			this.chkShowCreatures = new global::System.Windows.Forms.CheckBox();
			this.chkShowTips = new global::System.Windows.Forms.CheckBox();
			this.chkShowItems = new global::System.Windows.Forms.CheckBox();
			this.btnDLPlayers = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.listPlayers = new global::System.Windows.Forms.ListBox();
			this.cmbPlayerMap = new global::System.Windows.Forms.ComboBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.cmbCriminal = new global::System.Windows.Forms.ComboBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cmbAccessLevel = new global::System.Windows.Forms.ComboBox();
			this.btnRenew = new global::System.Windows.Forms.Button();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.tabPage4 = new global::System.Windows.Forms.TabPage();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.cmbModifiedBy = new global::System.Windows.Forms.ComboBox();
			this.chkModifiedBy = new global::System.Windows.Forms.CheckBox();
			this.txtModifiedBy = new global::System.Windows.Forms.TextBox();
			this.cmbModifiedNotBy = new global::System.Windows.Forms.ComboBox();
			this.grpTransferServer.SuspendLayout();
			this.grpSpawner.SuspendLayout();
			this.numAvgSpawnTime.BeginInit();
			this.transferServer.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			base.SuspendLayout();
			this.grpTransferServer.Controls.Add(this.listItems);
			this.grpTransferServer.Controls.Add(this.cmbItemMap);
			this.grpTransferServer.Controls.Add(this.label7);
			this.grpTransferServer.Controls.Add(this.cmbCarried);
			this.grpTransferServer.Controls.Add(this.txtItemID);
			this.grpTransferServer.Controls.Add(this.label14);
			this.grpTransferServer.Controls.Add(this.label9);
			this.grpTransferServer.Controls.Add(this.cmbMovable);
			this.grpTransferServer.Controls.Add(this.label8);
			this.grpTransferServer.Controls.Add(this.cmbVisible);
			this.grpTransferServer.Controls.Add(this.label6);
			this.grpTransferServer.Controls.Add(this.cmbItemInContainers);
			this.grpTransferServer.Controls.Add(this.label5);
			this.grpTransferServer.Controls.Add(this.cmbStatics);
			this.grpTransferServer.Controls.Add(this.txtItemType);
			this.grpTransferServer.Controls.Add(this.label43);
			this.grpTransferServer.Controls.Add(this.label10);
			this.grpTransferServer.Controls.Add(this.cmbBlessed);
			this.grpTransferServer.Controls.Add(this.btnDLItems);
			this.grpTransferServer.Location = new global::System.Drawing.Point(0, 0);
			this.grpTransferServer.Name = "grpTransferServer";
			this.grpTransferServer.Size = new global::System.Drawing.Size(336, 312);
			this.grpTransferServer.TabIndex = 209;
			this.grpTransferServer.TabStop = false;
			this.grpTransferServer.Text = "Item Filters";
			this.listItems.HorizontalScrollbar = true;
			this.listItems.Location = new global::System.Drawing.Point(208, 64);
			this.listItems.Name = "listItems";
			this.listItems.Size = new global::System.Drawing.Size(120, 212);
			this.listItems.TabIndex = 221;
			this.listItems.SelectedIndexChanged += new global::System.EventHandler(this.listItems_SelectedIndexChanged);
			this.cmbItemMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemMap.Items.AddRange(new object[] { "Current map", "All maps" });
			this.cmbItemMap.Location = new global::System.Drawing.Point(8, 280);
			this.cmbItemMap.Name = "cmbItemMap";
			this.cmbItemMap.Size = new global::System.Drawing.Size(96, 21);
			this.cmbItemMap.TabIndex = 220;
			this.label7.Location = new global::System.Drawing.Point(24, 88);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 16);
			this.label7.TabIndex = 31;
			this.label7.Text = "Carried:";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbCarried.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCarried.Items.AddRange(new object[] { "No Restriction", "Carried Only", "Not Carried" });
			this.cmbCarried.Location = new global::System.Drawing.Point(80, 88);
			this.cmbCarried.Name = "cmbCarried";
			this.cmbCarried.Size = new global::System.Drawing.Size(120, 21);
			this.cmbCarried.TabIndex = 30;
			this.txtItemID.Location = new global::System.Drawing.Point(272, 16);
			this.txtItemID.Name = "txtItemID";
			this.txtItemID.Size = new global::System.Drawing.Size(56, 20);
			this.txtItemID.TabIndex = 23;
			this.txtItemID.Text = "";
			this.label14.Location = new global::System.Drawing.Point(232, 16);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(48, 16);
			this.label14.TabIndex = 29;
			this.label14.Text = "ItemID:";
			this.label9.Location = new global::System.Drawing.Point(24, 112);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(56, 16);
			this.label9.TabIndex = 28;
			this.label9.Text = "Movable:";
			this.label9.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbMovable.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMovable.Items.AddRange(new object[] { "No Restriction", "Movable Only", "Not Movable" });
			this.cmbMovable.Location = new global::System.Drawing.Point(80, 112);
			this.cmbMovable.Name = "cmbMovable";
			this.cmbMovable.Size = new global::System.Drawing.Size(120, 21);
			this.cmbMovable.TabIndex = 27;
			this.label8.Location = new global::System.Drawing.Point(32, 136);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(48, 16);
			this.label8.TabIndex = 26;
			this.label8.Text = "Visible:";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbVisible.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVisible.Items.AddRange(new object[] { "No Restriction", "Visible Only", "Not Visible" });
			this.cmbVisible.Location = new global::System.Drawing.Point(80, 136);
			this.cmbVisible.Name = "cmbVisible";
			this.cmbVisible.Size = new global::System.Drawing.Size(120, 21);
			this.cmbVisible.TabIndex = 25;
			this.label6.Location = new global::System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(72, 16);
			this.label6.TabIndex = 22;
			this.label6.Text = "InContainers:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbItemInContainers.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemInContainers.Items.AddRange(new object[] { "No Restriction", "InContainers Only", "Not InContainers" });
			this.cmbItemInContainers.Location = new global::System.Drawing.Point(80, 64);
			this.cmbItemInContainers.Name = "cmbItemInContainers";
			this.cmbItemInContainers.Size = new global::System.Drawing.Size(120, 21);
			this.cmbItemInContainers.TabIndex = 21;
			this.label5.Location = new global::System.Drawing.Point(32, 40);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(48, 16);
			this.label5.TabIndex = 20;
			this.label5.Text = "Statics:";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbStatics.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatics.Items.AddRange(new object[] { "No Restriction", "Statics Only", "No Statics" });
			this.cmbStatics.Location = new global::System.Drawing.Point(80, 40);
			this.cmbStatics.Name = "cmbStatics";
			this.cmbStatics.Size = new global::System.Drawing.Size(120, 21);
			this.cmbStatics.TabIndex = 19;
			this.txtItemType.Location = new global::System.Drawing.Point(40, 16);
			this.txtItemType.Name = "txtItemType";
			this.txtItemType.Size = new global::System.Drawing.Size(160, 20);
			this.txtItemType.TabIndex = 9;
			this.txtItemType.Text = "";
			this.label43.Location = new global::System.Drawing.Point(8, 16);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(32, 16);
			this.label43.TabIndex = 11;
			this.label43.Text = "Type:";
			this.label43.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label10.Location = new global::System.Drawing.Point(32, 160);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(48, 16);
			this.label10.TabIndex = 30;
			this.label10.Text = "Blessed:";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbBlessed.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBlessed.Items.AddRange(new object[] { "No Restriction", "Blessed Only", "Not Blessed" });
			this.cmbBlessed.Location = new global::System.Drawing.Point(80, 160);
			this.cmbBlessed.Name = "cmbBlessed";
			this.cmbBlessed.Size = new global::System.Drawing.Size(120, 21);
			this.cmbBlessed.TabIndex = 29;
			this.btnDLItems.Location = new global::System.Drawing.Point(120, 280);
			this.btnDLItems.Name = "btnDLItems";
			this.btnDLItems.Size = new global::System.Drawing.Size(96, 24);
			this.btnDLItems.TabIndex = 213;
			this.btnDLItems.Text = "Get Items";
			this.btnDLItems.Click += new global::System.EventHandler(this.btnDLItems_Click);
			this.grpSpawner.Controls.Add(this.cmbModifiedNotBy);
			this.grpSpawner.Controls.Add(this.txtModifiedBy);
			this.grpSpawner.Controls.Add(this.cmbModifiedBy);
			this.grpSpawner.Controls.Add(this.chkModifiedBy);
			this.grpSpawner.Controls.Add(this.label18);
			this.grpSpawner.Controls.Add(this.numAvgSpawnTime);
			this.grpSpawner.Controls.Add(this.cmbAvgSpawnTime);
			this.grpSpawner.Controls.Add(this.chkAvgSpawnTime);
			this.grpSpawner.Controls.Add(this.chkSpawnerWithinSelectionWindow);
			this.grpSpawner.Controls.Add(this.label17);
			this.grpSpawner.Controls.Add(this.cmbRunning);
			this.grpSpawner.Controls.Add(this.label16);
			this.grpSpawner.Controls.Add(this.cmbProximity);
			this.grpSpawner.Controls.Add(this.cmbSpawnerMap);
			this.grpSpawner.Controls.Add(this.cmbModified);
			this.grpSpawner.Controls.Add(this.chkModified);
			this.grpSpawner.Controls.Add(this.dtModified);
			this.grpSpawner.Controls.Add(this.chkNameCase);
			this.grpSpawner.Controls.Add(this.chkEntryCase);
			this.grpSpawner.Controls.Add(this.label4);
			this.grpSpawner.Controls.Add(this.label3);
			this.grpSpawner.Controls.Add(this.label1);
			this.grpSpawner.Controls.Add(this.cmbSequential);
			this.grpSpawner.Controls.Add(this.cmbInContainers);
			this.grpSpawner.Controls.Add(this.cmbSmartSpawning);
			this.grpSpawner.Controls.Add(this.txtSpawnerEntry);
			this.grpSpawner.Controls.Add(this.label38);
			this.grpSpawner.Controls.Add(this.txtSpawnerName);
			this.grpSpawner.Controls.Add(this.label30);
			this.grpSpawner.Controls.Add(this.btnDLSpawners);
			this.grpSpawner.Controls.Add(this.button1);
			this.grpSpawner.Location = new global::System.Drawing.Point(0, 0);
			this.grpSpawner.Name = "grpSpawner";
			this.grpSpawner.Size = new global::System.Drawing.Size(336, 312);
			this.grpSpawner.TabIndex = 210;
			this.grpSpawner.TabStop = false;
			this.grpSpawner.Text = "Spawner Filters";
			this.label18.Location = new global::System.Drawing.Point(280, 232);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(48, 16);
			this.label18.TabIndex = 229;
			this.label18.Text = "minutes";
			this.numAvgSpawnTime.DecimalPlaces = 1;
			this.numAvgSpawnTime.Location = new global::System.Drawing.Point(208, 232);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numAvgSpawnTime;
			int[] bits = new int[4];
			bits[0] = 65535;
			decimal num = new decimal(bits);
			numericUpDown.Maximum = num;
			this.numAvgSpawnTime.Name = "numAvgSpawnTime";
			this.numAvgSpawnTime.Size = new global::System.Drawing.Size(72, 20);
			this.numAvgSpawnTime.TabIndex = 228;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numAvgSpawnTime;
			int[] bits2 = new int[4];
			bits2[0] = 10;
			decimal num2 = new decimal(bits2);
			numericUpDown2.Value = num2;
			this.cmbAvgSpawnTime.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAvgSpawnTime.Items.AddRange(new object[] { "less than", "greater than" });
			this.cmbAvgSpawnTime.Location = new global::System.Drawing.Point(120, 232);
			this.cmbAvgSpawnTime.Name = "cmbAvgSpawnTime";
			this.cmbAvgSpawnTime.Size = new global::System.Drawing.Size(88, 21);
			this.cmbAvgSpawnTime.TabIndex = 226;
			this.chkAvgSpawnTime.Location = new global::System.Drawing.Point(8, 232);
			this.chkAvgSpawnTime.Name = "chkAvgSpawnTime";
			this.chkAvgSpawnTime.Size = new global::System.Drawing.Size(112, 16);
			this.chkAvgSpawnTime.TabIndex = 227;
			this.chkAvgSpawnTime.Text = "Avg. Spawn Time";
			this.chkSpawnerWithinSelectionWindow.Location = new global::System.Drawing.Point(8, 256);
			this.chkSpawnerWithinSelectionWindow.Name = "chkSpawnerWithinSelectionWindow";
			this.chkSpawnerWithinSelectionWindow.Size = new global::System.Drawing.Size(160, 16);
			this.chkSpawnerWithinSelectionWindow.TabIndex = 224;
			this.chkSpawnerWithinSelectionWindow.Text = "Within Selection Window";
			this.chkSpawnerWithinSelectionWindow.CheckedChanged += new global::System.EventHandler(this.chkSpawnerWithinSelectionWindow_CheckedChanged);
			this.label17.Location = new global::System.Drawing.Point(16, 160);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(112, 16);
			this.label17.TabIndex = 223;
			this.label17.Text = "Running:";
			this.label17.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbRunning.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRunning.Items.AddRange(new object[] { "No Restriction", "Running Only", "Not Running" });
			this.cmbRunning.Location = new global::System.Drawing.Point(128, 160);
			this.cmbRunning.Name = "cmbRunning";
			this.cmbRunning.Size = new global::System.Drawing.Size(152, 21);
			this.cmbRunning.TabIndex = 222;
			this.label16.Location = new global::System.Drawing.Point(16, 136);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(112, 16);
			this.label16.TabIndex = 221;
			this.label16.Text = "ProximityTriggered:";
			this.label16.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbProximity.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProximity.Items.AddRange(new object[] { "No Restriction", "ProximityTriggered Only", "Not ProximityTriggered " });
			this.cmbProximity.Location = new global::System.Drawing.Point(128, 136);
			this.cmbProximity.Name = "cmbProximity";
			this.cmbProximity.Size = new global::System.Drawing.Size(152, 21);
			this.cmbProximity.TabIndex = 220;
			this.cmbSpawnerMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpawnerMap.Items.AddRange(new object[] { "Current map", "All maps" });
			this.cmbSpawnerMap.Location = new global::System.Drawing.Point(8, 280);
			this.cmbSpawnerMap.Name = "cmbSpawnerMap";
			this.cmbSpawnerMap.Size = new global::System.Drawing.Size(96, 21);
			this.cmbSpawnerMap.TabIndex = 219;
			this.cmbModified.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModified.Items.AddRange(new object[] { "before", "after" });
			this.cmbModified.Location = new global::System.Drawing.Point(72, 184);
			this.cmbModified.Name = "cmbModified";
			this.cmbModified.Size = new global::System.Drawing.Size(56, 21);
			this.cmbModified.TabIndex = 25;
			this.chkModified.Location = new global::System.Drawing.Point(8, 186);
			this.chkModified.Name = "chkModified";
			this.chkModified.Size = new global::System.Drawing.Size(72, 16);
			this.chkModified.TabIndex = 26;
			this.chkModified.Text = "Modified";
			this.dtModified.CustomFormat = "MMM dd yyyy h:mm tt";
			this.dtModified.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtModified.Location = new global::System.Drawing.Point(128, 184);
			this.dtModified.Name = "dtModified";
			this.dtModified.Size = new global::System.Drawing.Size(152, 20);
			this.dtModified.TabIndex = 23;
			this.chkNameCase.Location = new global::System.Drawing.Point(224, 16);
			this.chkNameCase.Name = "chkNameCase";
			this.chkNameCase.Size = new global::System.Drawing.Size(104, 16);
			this.chkNameCase.TabIndex = 21;
			this.chkNameCase.Text = "Case sensitive";
			this.chkEntryCase.Location = new global::System.Drawing.Point(224, 40);
			this.chkEntryCase.Name = "chkEntryCase";
			this.chkEntryCase.Size = new global::System.Drawing.Size(104, 16);
			this.chkEntryCase.TabIndex = 22;
			this.chkEntryCase.Text = "Case sensitive";
			this.label4.Location = new global::System.Drawing.Point(56, 112);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(72, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "InContainers:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new global::System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(112, 16);
			this.label3.TabIndex = 19;
			this.label3.Text = "SequentialSpawning:";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label1.Location = new global::System.Drawing.Point(40, 64);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(88, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "SmartSpawning:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbSequential.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSequential.Items.AddRange(new object[] { "No Restriction", "Sequential Only", "Not Sequential" });
			this.cmbSequential.Location = new global::System.Drawing.Point(128, 88);
			this.cmbSequential.Name = "cmbSequential";
			this.cmbSequential.Size = new global::System.Drawing.Size(152, 21);
			this.cmbSequential.TabIndex = 17;
			this.cmbInContainers.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInContainers.Items.AddRange(new object[] { "No Restriction", "InContainer Only", "Not InContainer" });
			this.cmbInContainers.Location = new global::System.Drawing.Point(128, 112);
			this.cmbInContainers.Name = "cmbInContainers";
			this.cmbInContainers.Size = new global::System.Drawing.Size(152, 21);
			this.cmbInContainers.TabIndex = 16;
			this.cmbSmartSpawning.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSmartSpawning.Items.AddRange(new object[] { "No Restriction", "SmartSpawned Only", "Not SmartSpawned" });
			this.cmbSmartSpawning.Location = new global::System.Drawing.Point(128, 64);
			this.cmbSmartSpawning.Name = "cmbSmartSpawning";
			this.cmbSmartSpawning.Size = new global::System.Drawing.Size(152, 21);
			this.cmbSmartSpawning.TabIndex = 15;
			this.txtSpawnerEntry.Location = new global::System.Drawing.Point(40, 40);
			this.txtSpawnerEntry.Name = "txtSpawnerEntry";
			this.txtSpawnerEntry.Size = new global::System.Drawing.Size(176, 20);
			this.txtSpawnerEntry.TabIndex = 13;
			this.txtSpawnerEntry.Text = "";
			this.label38.Location = new global::System.Drawing.Point(5, 40);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(40, 16);
			this.label38.TabIndex = 14;
			this.label38.Text = "Entry:";
			this.txtSpawnerName.Location = new global::System.Drawing.Point(40, 16);
			this.txtSpawnerName.Name = "txtSpawnerName";
			this.txtSpawnerName.Size = new global::System.Drawing.Size(176, 20);
			this.txtSpawnerName.TabIndex = 11;
			this.txtSpawnerName.Text = "";
			this.label30.Location = new global::System.Drawing.Point(5, 16);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(40, 16);
			this.label30.TabIndex = 12;
			this.label30.Text = "Name:";
			this.btnDLSpawners.Location = new global::System.Drawing.Point(120, 280);
			this.btnDLSpawners.Name = "btnDLSpawners";
			this.btnDLSpawners.Size = new global::System.Drawing.Size(96, 24);
			this.btnDLSpawners.TabIndex = 216;
			this.btnDLSpawners.Text = "Get Spawners";
			this.toolTip1.SetToolTip(this.btnDLSpawners, "Retrieve spawners that meet the filtering criteria from the server. Currently loaded spawners will first be cleared.");
			this.btnDLSpawners.Click += new global::System.EventHandler(this.btnDLSpawners_Click);
			this.button1.Location = new global::System.Drawing.Point(224, 280);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(104, 24);
			this.button1.TabIndex = 218;
			this.button1.Text = "Merge Spawners";
			this.toolTip1.SetToolTip(this.button1, "Retrieve spawners that meet the filtering criteria from the server. Currently loaded spawners will NOT be cleared.");
			this.button1.Click += new global::System.EventHandler(this.btnDLSpawners_Click);
			this.transferServer.Controls.Add(this.txtTransferServerPort);
			this.transferServer.Controls.Add(this.txtTransferServerAddress);
			this.transferServer.Controls.Add(this.label40);
			this.transferServer.Controls.Add(this.label41);
			this.transferServer.Location = new global::System.Drawing.Point(8, 0);
			this.transferServer.Name = "transferServer";
			this.transferServer.Size = new global::System.Drawing.Size(344, 48);
			this.transferServer.TabIndex = 211;
			this.transferServer.TabStop = false;
			this.transferServer.Text = "Transfer Server";
			this.txtTransferServerPort.Location = new global::System.Drawing.Point(288, 16);
			this.txtTransferServerPort.Name = "txtTransferServerPort";
			this.txtTransferServerPort.Size = new global::System.Drawing.Size(48, 20);
			this.txtTransferServerPort.TabIndex = 22;
			this.txtTransferServerPort.Text = "8030";
			this.txtTransferServerAddress.Location = new global::System.Drawing.Point(56, 16);
			this.txtTransferServerAddress.Name = "txtTransferServerAddress";
			this.txtTransferServerAddress.Size = new global::System.Drawing.Size(192, 20);
			this.txtTransferServerAddress.TabIndex = 20;
			this.txtTransferServerAddress.Text = "127.0.0.1";
			this.label40.Location = new global::System.Drawing.Point(8, 16);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(56, 16);
			this.label40.TabIndex = 21;
			this.label40.Text = "Address:";
			this.label41.Location = new global::System.Drawing.Point(256, 16);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(48, 16);
			this.label41.TabIndex = 23;
			this.label41.Text = "Port:";
			this.groupBox1.Controls.Add(this.listCreatures);
			this.groupBox1.Controls.Add(this.cmbCreatureMap);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.cmbControlled);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.cmbInnocent);
			this.groupBox1.Controls.Add(this.txtCreatureType);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnDLCreatures);
			this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(336, 312);
			this.groupBox1.TabIndex = 212;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Creature Filters";
			this.listCreatures.HorizontalScrollbar = true;
			this.listCreatures.Location = new global::System.Drawing.Point(208, 64);
			this.listCreatures.Name = "listCreatures";
			this.listCreatures.Size = new global::System.Drawing.Size(120, 212);
			this.listCreatures.TabIndex = 222;
			this.listCreatures.SelectedIndexChanged += new global::System.EventHandler(this.listCreatures_SelectedIndexChanged);
			this.cmbCreatureMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCreatureMap.Items.AddRange(new object[] { "Current map", "All maps" });
			this.cmbCreatureMap.Location = new global::System.Drawing.Point(8, 280);
			this.cmbCreatureMap.Name = "cmbCreatureMap";
			this.cmbCreatureMap.Size = new global::System.Drawing.Size(96, 21);
			this.cmbCreatureMap.TabIndex = 220;
			this.label15.Location = new global::System.Drawing.Point(8, 40);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(64, 16);
			this.label15.TabIndex = 34;
			this.label15.Text = "Controlled:";
			this.label15.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbControlled.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbControlled.Items.AddRange(new object[] { "No Restriction", "Controlled Only", "Not Controlled" });
			this.cmbControlled.Location = new global::System.Drawing.Point(80, 40);
			this.cmbControlled.Name = "cmbControlled";
			this.cmbControlled.Size = new global::System.Drawing.Size(120, 21);
			this.cmbControlled.TabIndex = 33;
			this.label11.Location = new global::System.Drawing.Point(16, 64);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(56, 16);
			this.label11.TabIndex = 32;
			this.label11.Text = "Notoriety:";
			this.label11.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbInnocent.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInnocent.Items.AddRange(new object[] { "No Restriction", "Innocents Only", "Invulnerable Only", "Attackable Only" });
			this.cmbInnocent.Location = new global::System.Drawing.Point(80, 64);
			this.cmbInnocent.Name = "cmbInnocent";
			this.cmbInnocent.Size = new global::System.Drawing.Size(120, 21);
			this.cmbInnocent.TabIndex = 31;
			this.txtCreatureType.Location = new global::System.Drawing.Point(40, 16);
			this.txtCreatureType.Name = "txtCreatureType";
			this.txtCreatureType.Size = new global::System.Drawing.Size(160, 20);
			this.txtCreatureType.TabIndex = 6;
			this.txtCreatureType.Text = "";
			this.label2.Location = new global::System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(32, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Type:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnDLCreatures.Location = new global::System.Drawing.Point(120, 280);
			this.btnDLCreatures.Name = "btnDLCreatures";
			this.btnDLCreatures.Size = new global::System.Drawing.Size(96, 24);
			this.btnDLCreatures.TabIndex = 214;
			this.btnDLCreatures.Text = "Get Creatures";
			this.btnDLCreatures.Click += new global::System.EventHandler(this.btnDLCreatures_Click);
			this.groupBox2.Controls.Add(this.chkShowPlayers);
			this.groupBox2.Controls.Add(this.chkShowCreatures);
			this.groupBox2.Controls.Add(this.chkShowTips);
			this.groupBox2.Controls.Add(this.chkShowItems);
			this.groupBox2.Location = new global::System.Drawing.Point(8, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(344, 56);
			this.groupBox2.TabIndex = 210;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Display Filters";
			this.chkShowPlayers.Location = new global::System.Drawing.Point(176, 32);
			this.chkShowPlayers.Name = "chkShowPlayers";
			this.chkShowPlayers.Size = new global::System.Drawing.Size(160, 16);
			this.chkShowPlayers.TabIndex = 5;
			this.chkShowPlayers.Text = "Show Players";
			this.chkShowCreatures.Location = new global::System.Drawing.Point(8, 32);
			this.chkShowCreatures.Name = "chkShowCreatures";
			this.chkShowCreatures.Size = new global::System.Drawing.Size(160, 16);
			this.chkShowCreatures.TabIndex = 4;
			this.chkShowCreatures.Text = "Show Creatures";
			this.chkShowTips.Location = new global::System.Drawing.Point(8, 16);
			this.chkShowTips.Name = "chkShowTips";
			this.chkShowTips.Size = new global::System.Drawing.Size(80, 16);
			this.chkShowTips.TabIndex = 12;
			this.chkShowTips.Text = "Show Tips";
			this.chkShowItems.Location = new global::System.Drawing.Point(176, 16);
			this.chkShowItems.Name = "chkShowItems";
			this.chkShowItems.Size = new global::System.Drawing.Size(160, 16);
			this.chkShowItems.TabIndex = 8;
			this.chkShowItems.Text = "Show Items";
			this.btnDLPlayers.Location = new global::System.Drawing.Point(120, 280);
			this.btnDLPlayers.Name = "btnDLPlayers";
			this.btnDLPlayers.Size = new global::System.Drawing.Size(96, 24);
			this.btnDLPlayers.TabIndex = 215;
			this.btnDLPlayers.Text = "Get Players";
			this.btnDLPlayers.Click += new global::System.EventHandler(this.btnDLPlayers_Click);
			this.btnCancel.Location = new global::System.Drawing.Point(248, 448);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 217;
			this.btnCancel.Text = "Close";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.groupBox3.Controls.Add(this.listPlayers);
			this.groupBox3.Controls.Add(this.cmbPlayerMap);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.cmbCriminal);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.cmbAccessLevel);
			this.groupBox3.Controls.Add(this.btnDLPlayers);
			this.groupBox3.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(336, 312);
			this.groupBox3.TabIndex = 219;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Player Filters";
			this.listPlayers.HorizontalScrollbar = true;
			this.listPlayers.Location = new global::System.Drawing.Point(208, 64);
			this.listPlayers.Name = "listPlayers";
			this.listPlayers.Size = new global::System.Drawing.Size(120, 212);
			this.listPlayers.TabIndex = 222;
			this.listPlayers.SelectedIndexChanged += new global::System.EventHandler(this.listPlayers_SelectedIndexChanged);
			this.cmbPlayerMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayerMap.Items.AddRange(new object[] { "Current map", "All maps" });
			this.cmbPlayerMap.Location = new global::System.Drawing.Point(8, 280);
			this.cmbPlayerMap.Name = "cmbPlayerMap";
			this.cmbPlayerMap.Size = new global::System.Drawing.Size(96, 21);
			this.cmbPlayerMap.TabIndex = 220;
			this.label12.Location = new global::System.Drawing.Point(8, 38);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(72, 16);
			this.label12.TabIndex = 32;
			this.label12.Text = "Notoriety:";
			this.label12.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbCriminal.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCriminal.Items.AddRange(new object[] { "No Restriction", "Innocents Only", "Criminals Only", "Murderers Only" });
			this.cmbCriminal.Location = new global::System.Drawing.Point(80, 38);
			this.cmbCriminal.Name = "cmbCriminal";
			this.cmbCriminal.Size = new global::System.Drawing.Size(120, 21);
			this.cmbCriminal.TabIndex = 31;
			this.label13.Location = new global::System.Drawing.Point(8, 16);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(72, 16);
			this.label13.TabIndex = 30;
			this.label13.Text = "AccessLevel:";
			this.label13.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cmbAccessLevel.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAccessLevel.Items.AddRange(new object[] { "No Restriction", "Player Only", "Staff Only", "Counselor Only", "GM Only", "Seer Only", "Administrator Only" });
			this.cmbAccessLevel.Location = new global::System.Drawing.Point(80, 16);
			this.cmbAccessLevel.Name = "cmbAccessLevel";
			this.cmbAccessLevel.Size = new global::System.Drawing.Size(120, 21);
			this.cmbAccessLevel.TabIndex = 29;
			this.btnRenew.Location = new global::System.Drawing.Point(8, 448);
			this.btnRenew.Name = "btnRenew";
			this.btnRenew.Size = new global::System.Drawing.Size(208, 24);
			this.btnRenew.TabIndex = 220;
			this.btnRenew.Text = "Renew Session Authentication";
			this.toolTip1.SetToolTip(this.btnRenew, "Registers the current Spawn Editor session with the server.  Must be logged in to the server via the UO client with a staff level account.");
			this.btnRenew.Click += new global::System.EventHandler(this.btnRenew_Click);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new global::System.Drawing.Point(8, 104);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.ShowToolTips = true;
			this.tabControl1.Size = new global::System.Drawing.Size(344, 336);
			this.tabControl1.TabIndex = 221;
			this.tabPage1.Controls.Add(this.grpSpawner);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new global::System.Drawing.Size(336, 310);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Spawners";
			this.tabPage2.Controls.Add(this.grpTransferServer);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new global::System.Drawing.Size(336, 310);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Items";
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new global::System.Drawing.Size(336, 310);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Creatures";
			this.tabPage4.Controls.Add(this.groupBox3);
			this.tabPage4.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new global::System.Drawing.Size(336, 310);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Players";
			this.cmbModifiedBy.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModifiedBy.Items.AddRange(new object[] { "first", "last" });
			this.cmbModifiedBy.Location = new global::System.Drawing.Point(72, 208);
			this.cmbModifiedBy.Name = "cmbModifiedBy";
			this.cmbModifiedBy.Size = new global::System.Drawing.Size(56, 21);
			this.cmbModifiedBy.TabIndex = 231;
			this.chkModifiedBy.Location = new global::System.Drawing.Point(8, 208);
			this.chkModifiedBy.Name = "chkModifiedBy";
			this.chkModifiedBy.Size = new global::System.Drawing.Size(72, 16);
			this.chkModifiedBy.TabIndex = 232;
			this.chkModifiedBy.Text = "Modified";
			this.txtModifiedBy.Location = new global::System.Drawing.Point(192, 208);
			this.txtModifiedBy.Name = "txtModifiedBy";
			this.txtModifiedBy.Size = new global::System.Drawing.Size(128, 20);
			this.txtModifiedBy.TabIndex = 233;
			this.txtModifiedBy.Text = "";
			this.cmbModifiedNotBy.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModifiedNotBy.Items.AddRange(new object[] { "by", "not by" });
			this.cmbModifiedNotBy.Location = new global::System.Drawing.Point(128, 208);
			this.cmbModifiedNotBy.Name = "cmbModifiedNotBy";
			this.cmbModifiedNotBy.Size = new global::System.Drawing.Size(64, 21);
			this.cmbModifiedNotBy.TabIndex = 234;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(358, 478);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.btnRenew);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.transferServer);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.Name = "TransferServerSettings";
			this.Text = "Transfer Server Settings";
			base.Load += new global::System.EventHandler(this.TransferServerSettings_Load);
			this.grpTransferServer.ResumeLayout(false);
			this.grpSpawner.ResumeLayout(false);
			this.numAvgSpawnTime.EndInit();
			this.transferServer.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002B8 RID: 696
		internal global::System.Windows.Forms.GroupBox grpTransferServer;

		// Token: 0x040002B9 RID: 697
		internal global::System.Windows.Forms.TextBox txtItemType;

		// Token: 0x040002BA RID: 698
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.Label label38;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040002BD RID: 701
		private global::System.Windows.Forms.GroupBox transferServer;

		// Token: 0x040002BE RID: 702
		internal global::System.Windows.Forms.TextBox txtTransferServerPort;

		// Token: 0x040002BF RID: 703
		internal global::System.Windows.Forms.TextBox txtTransferServerAddress;

		// Token: 0x040002C0 RID: 704
		private global::System.Windows.Forms.Label label40;

		// Token: 0x040002C1 RID: 705
		private global::System.Windows.Forms.Label label41;

		// Token: 0x040002C2 RID: 706
		internal global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002C3 RID: 707
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002C4 RID: 708
		internal global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002C9 RID: 713
		private global::System.Windows.Forms.Button btnDLItems;

		// Token: 0x040002CA RID: 714
		private global::System.Windows.Forms.Button btnDLCreatures;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.Button btnDLPlayers;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.Button btnDLSpawners;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.TextBox txtItemID;

		// Token: 0x040002D1 RID: 721
		internal global::System.Windows.Forms.CheckBox chkNameCase;

		// Token: 0x040002D2 RID: 722
		internal global::System.Windows.Forms.CheckBox chkEntryCase;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040002D5 RID: 725
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040002D7 RID: 727
		internal global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040002D9 RID: 729
		internal global::System.Windows.Forms.GroupBox grpSpawner;

		// Token: 0x040002DA RID: 730
		internal global::System.Windows.Forms.ComboBox cmbSequential;

		// Token: 0x040002DB RID: 731
		internal global::System.Windows.Forms.ComboBox cmbSmartSpawning;

		// Token: 0x040002DC RID: 732
		internal global::System.Windows.Forms.TextBox txtSpawnerEntry;

		// Token: 0x040002DD RID: 733
		internal global::System.Windows.Forms.TextBox txtSpawnerName;

		// Token: 0x040002DE RID: 734
		internal global::System.Windows.Forms.TextBox txtCreatureType;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.ComboBox cmbStatics;

		// Token: 0x040002E0 RID: 736
		private global::System.Windows.Forms.ComboBox cmbItemInContainers;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.ComboBox cmbVisible;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.ComboBox cmbMovable;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.ComboBox cmbBlessed;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.ComboBox cmbInnocent;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.ComboBox cmbCriminal;

		// Token: 0x040002E8 RID: 744
		internal global::System.Windows.Forms.CheckBox chkShowPlayers;

		// Token: 0x040002E9 RID: 745
		internal global::System.Windows.Forms.CheckBox chkShowCreatures;

		// Token: 0x040002EA RID: 746
		internal global::System.Windows.Forms.CheckBox chkShowTips;

		// Token: 0x040002EB RID: 747
		internal global::System.Windows.Forms.CheckBox chkShowItems;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.ComboBox cmbAccessLevel;

		// Token: 0x040002EE RID: 750
		internal global::System.Windows.Forms.ComboBox cmbInContainers;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.ComboBox cmbCarried;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.ComboBox cmbControlled;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.DateTimePicker dtModified;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.Button btnRenew;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.CheckBox chkModified;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.ComboBox cmbModified;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.ComboBox cmbItemMap;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.ComboBox cmbCreatureMap;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.ComboBox cmbPlayerMap;

		// Token: 0x040002FF RID: 767
		private global::System.Windows.Forms.ComboBox cmbSpawnerMap;

		// Token: 0x04000300 RID: 768
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000301 RID: 769
		internal global::System.Windows.Forms.ComboBox cmbProximity;

		// Token: 0x04000302 RID: 770
		private global::System.Windows.Forms.ListBox listItems;

		// Token: 0x04000303 RID: 771
		private global::System.Windows.Forms.ListBox listCreatures;

		// Token: 0x04000304 RID: 772
		private global::System.Windows.Forms.ListBox listPlayers;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000306 RID: 774
		internal global::System.Windows.Forms.ComboBox cmbRunning;

		// Token: 0x04000307 RID: 775
		internal global::System.Windows.Forms.CheckBox chkSpawnerWithinSelectionWindow;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.ComboBox cmbAvgSpawnTime;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.CheckBox chkAvgSpawnTime;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.NumericUpDown numAvgSpawnTime;

		// Token: 0x0400030C RID: 780
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.ComboBox cmbModifiedBy;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.CheckBox chkModifiedBy;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.TextBox txtModifiedBy;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.ComboBox cmbModifiedNotBy;

		// Token: 0x04000311 RID: 785
		private global::System.ComponentModel.IContainer components;
	}
}
