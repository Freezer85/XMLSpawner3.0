namespace SpawnEditor2
{
	// Token: 0x02000006 RID: 6
	public partial class Configure : global::System.Windows.Forms.Form
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00004586 File Offset: 0x00002786
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000045A8 File Offset: 0x000027A8
		private void InitializeComponent()
		{
			this.ofdOpenFile = new global::System.Windows.Forms.OpenFileDialog();
			this.txtRunUOExe = new global::System.Windows.Forms.TextBox();
			this.btnRunUOExe = new global::System.Windows.Forms.Button();
			this.lblRunUOExe = new global::System.Windows.Forms.Label();
			this.txtUltimaClient = new global::System.Windows.Forms.TextBox();
			this.lblUltimaClient = new global::System.Windows.Forms.Label();
			this.btnUltimaClient = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.trkZoom = new global::System.Windows.Forms.TrackBar();
			this.grpSpawnEdit = new global::System.Windows.Forms.GroupBox();
			this.chkHomeRangeIsRelative = new global::System.Windows.Forms.CheckBox();
			this.lblMaxDelay = new global::System.Windows.Forms.Label();
			this.chkSpawnRunning = new global::System.Windows.Forms.CheckBox();
			this.lblHomeRange = new global::System.Windows.Forms.Label();
			this.spnSpawnMaxCount = new global::System.Windows.Forms.NumericUpDown();
			this.txtSpawnName = new global::System.Windows.Forms.TextBox();
			this.spnSpawnRange = new global::System.Windows.Forms.NumericUpDown();
			this.lblTeam = new global::System.Windows.Forms.Label();
			this.lblMaxCount = new global::System.Windows.Forms.Label();
			this.spnSpawnMinDelay = new global::System.Windows.Forms.NumericUpDown();
			this.spnSpawnTeam = new global::System.Windows.Forms.NumericUpDown();
			this.chkSpawnGroup = new global::System.Windows.Forms.CheckBox();
			this.spnSpawnMaxDelay = new global::System.Windows.Forms.NumericUpDown();
			this.lblMinDelay = new global::System.Windows.Forms.Label();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.txtCmdPrefix = new global::System.Windows.Forms.TextBox();
			this.lblCmdPrefix = new global::System.Windows.Forms.Label();
			this.lblClientWindow = new global::System.Windows.Forms.Label();
			this.cmbClientProcess = new global::System.Windows.Forms.ComboBox();
			this.btnRefreshProcesses = new global::System.Windows.Forms.Button();
			this.btnPickClientWindow = new global::System.Windows.Forms.Button();
			this.startingStatics = new global::System.Windows.Forms.CheckBox();
			this.startingDetails = new global::System.Windows.Forms.CheckBox();
			this.startingMap = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.startingOnTop = new global::System.Windows.Forms.CheckBox();
			this.trkZoom.BeginInit();
			this.grpSpawnEdit.SuspendLayout();
			this.spnSpawnMaxCount.BeginInit();
			this.spnSpawnRange.BeginInit();
			this.spnSpawnMinDelay.BeginInit();
			this.spnSpawnTeam.BeginInit();
			this.spnSpawnMaxDelay.BeginInit();
			base.SuspendLayout();
			this.ofdOpenFile.DefaultExt = "exe";
			this.ofdOpenFile.Filter = "Executable (*.exe)|*.exe|All Files (*.*)|*.*";
			this.ofdOpenFile.ReadOnlyChecked = true;
			this.txtRunUOExe.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtRunUOExe.Location = new global::System.Drawing.Point(80, 8);
			this.txtRunUOExe.Name = "txtRunUOExe";
			this.txtRunUOExe.ReadOnly = true;
			this.txtRunUOExe.Size = new global::System.Drawing.Size(376, 20);
			this.txtRunUOExe.TabIndex = 1;
			this.txtRunUOExe.Text = "";
			this.btnRunUOExe.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnRunUOExe.Location = new global::System.Drawing.Point(464, 8);
			this.btnRunUOExe.Name = "btnRunUOExe";
			this.btnRunUOExe.Size = new global::System.Drawing.Size(24, 20);
			this.btnRunUOExe.TabIndex = 2;
			this.btnRunUOExe.Text = "...";
			this.btnRunUOExe.Click += new global::System.EventHandler(this.btnRunUOExe_Click);
			this.lblRunUOExe.Location = new global::System.Drawing.Point(8, 8);
			this.lblRunUOExe.Name = "lblRunUOExe";
			this.lblRunUOExe.Size = new global::System.Drawing.Size(80, 20);
			this.lblRunUOExe.TabIndex = 0;
			this.lblRunUOExe.Text = "RunUO.EXE:";
			this.lblRunUOExe.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.txtUltimaClient.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtUltimaClient.Location = new global::System.Drawing.Point(80, 32);
			this.txtUltimaClient.Name = "txtUltimaClient";
			this.txtUltimaClient.ReadOnly = true;
			this.txtUltimaClient.Size = new global::System.Drawing.Size(376, 20);
			this.txtUltimaClient.TabIndex = 4;
			this.txtUltimaClient.Text = "";
			this.lblUltimaClient.Location = new global::System.Drawing.Point(8, 32);
			this.lblUltimaClient.Name = "lblUltimaClient";
			this.lblUltimaClient.Size = new global::System.Drawing.Size(80, 20);
			this.lblUltimaClient.TabIndex = 3;
			this.lblUltimaClient.Text = "Ultima Client:";
			this.lblUltimaClient.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUltimaClient.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnUltimaClient.Location = new global::System.Drawing.Point(464, 32);
			this.btnUltimaClient.Name = "btnUltimaClient";
			this.btnUltimaClient.Size = new global::System.Drawing.Size(24, 20);
			this.btnUltimaClient.TabIndex = 5;
			this.btnUltimaClient.Text = "...";
			this.btnUltimaClient.Click += new global::System.EventHandler(this.btnUltimaClient_Click);
			this.lblMulPath = new global::System.Windows.Forms.Label();
			this.lblMulPath.Location = new global::System.Drawing.Point(8, 56);
			this.lblMulPath.Name = "lblMulPath";
			this.lblMulPath.Size = new global::System.Drawing.Size(80, 20);
			this.lblMulPath.TabIndex = 20;
			this.lblMulPath.Text = "MUL Files:";
			this.lblMulPath.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.txtMulPath = new global::System.Windows.Forms.TextBox();
			this.txtMulPath.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtMulPath.Location = new global::System.Drawing.Point(80, 56);
			this.txtMulPath.Name = "txtMulPath";
			this.txtMulPath.ReadOnly = true;
			this.txtMulPath.Size = new global::System.Drawing.Size(376, 20);
			this.txtMulPath.TabIndex = 21;
			this.txtMulPath.Text = "";
			this.btnMulPath = new global::System.Windows.Forms.Button();
			this.btnMulPath.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnMulPath.Location = new global::System.Drawing.Point(464, 56);
			this.btnMulPath.Name = "btnMulPath";
			this.btnMulPath.Size = new global::System.Drawing.Size(24, 20);
			this.btnMulPath.TabIndex = 22;
			this.btnMulPath.Text = "...";
			this.btnMulPath.Click += new global::System.EventHandler(this.btnMulPath_Click);
			this.label1.Location = new global::System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Default Zoom Level:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.trkZoom.LargeChange = 2;
			this.trkZoom.Location = new global::System.Drawing.Point(112, 80);
			this.trkZoom.Maximum = 4;
			this.trkZoom.Minimum = -4;
			this.trkZoom.Name = "trkZoom";
			this.trkZoom.Size = new global::System.Drawing.Size(240, 45);
			this.trkZoom.TabIndex = 7;
			this.trkZoom.TickStyle = global::System.Windows.Forms.TickStyle.TopLeft;
			this.grpSpawnEdit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.grpSpawnEdit.Controls.Add(this.chkHomeRangeIsRelative);
			this.grpSpawnEdit.Controls.Add(this.lblMaxDelay);
			this.grpSpawnEdit.Controls.Add(this.chkSpawnRunning);
			this.grpSpawnEdit.Controls.Add(this.lblHomeRange);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnMaxCount);
			this.grpSpawnEdit.Controls.Add(this.txtSpawnName);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnRange);
			this.grpSpawnEdit.Controls.Add(this.lblTeam);
			this.grpSpawnEdit.Controls.Add(this.lblMaxCount);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnMinDelay);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnTeam);
			this.grpSpawnEdit.Controls.Add(this.chkSpawnGroup);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnMaxDelay);
			this.grpSpawnEdit.Controls.Add(this.lblMinDelay);
			this.grpSpawnEdit.Location = new global::System.Drawing.Point(336, 128);
			this.grpSpawnEdit.Name = "grpSpawnEdit";
			this.grpSpawnEdit.Size = new global::System.Drawing.Size(152, 200);
			this.grpSpawnEdit.TabIndex = 10;
			this.grpSpawnEdit.TabStop = false;
			this.grpSpawnEdit.Text = "Default Spawn Details";
			this.chkHomeRangeIsRelative.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkHomeRangeIsRelative.Checked = true;
			this.chkHomeRangeIsRelative.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkHomeRangeIsRelative.Location = new global::System.Drawing.Point(8, 176);
			this.chkHomeRangeIsRelative.Name = "chkHomeRangeIsRelative";
			this.chkHomeRangeIsRelative.Size = new global::System.Drawing.Size(102, 16);
			this.chkHomeRangeIsRelative.TabIndex = 13;
			this.chkHomeRangeIsRelative.Text = "Relative Home:";
			this.lblMaxDelay.Location = new global::System.Drawing.Point(8, 104);
			this.lblMaxDelay.Name = "lblMaxDelay";
			this.lblMaxDelay.Size = new global::System.Drawing.Size(80, 16);
			this.lblMaxDelay.TabIndex = 7;
			this.lblMaxDelay.Text = "Max Delay (m)";
			this.chkSpawnRunning.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkSpawnRunning.Checked = true;
			this.chkSpawnRunning.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkSpawnRunning.Location = new global::System.Drawing.Point(8, 160);
			this.chkSpawnRunning.Name = "chkSpawnRunning";
			this.chkSpawnRunning.Size = new global::System.Drawing.Size(102, 16);
			this.chkSpawnRunning.TabIndex = 12;
			this.chkSpawnRunning.Text = "Running:";
			this.lblHomeRange.Location = new global::System.Drawing.Point(8, 44);
			this.lblHomeRange.Name = "lblHomeRange";
			this.lblHomeRange.Size = new global::System.Drawing.Size(80, 16);
			this.lblHomeRange.TabIndex = 1;
			this.lblHomeRange.Text = "Home Range:";
			this.spnSpawnMaxCount.Location = new global::System.Drawing.Point(96, 60);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.spnSpawnMaxCount;
			int[] bits = new int[4];
			bits[0] = 10000;
			decimal num = new decimal(bits);
			numericUpDown.Maximum = num;
			this.spnSpawnMaxCount.Name = "spnSpawnMaxCount";
			this.spnSpawnMaxCount.Size = new global::System.Drawing.Size(48, 20);
			this.spnSpawnMaxCount.TabIndex = 4;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.spnSpawnMaxCount;
			int[] bits2 = new int[4];
			bits2[0] = 1;
			decimal num2 = new decimal(bits2);
			numericUpDown2.Value = num2;
			this.txtSpawnName.Location = new global::System.Drawing.Point(8, 16);
			this.txtSpawnName.Name = "txtSpawnName";
			this.txtSpawnName.Size = new global::System.Drawing.Size(136, 20);
			this.txtSpawnName.TabIndex = 0;
			this.txtSpawnName.Text = "Spawn";
			this.spnSpawnRange.Location = new global::System.Drawing.Point(96, 40);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.spnSpawnRange;
			int[] bits3 = new int[4];
			bits3[0] = 10000;
			decimal num3 = new decimal(bits3);
			numericUpDown3.Maximum = num3;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.spnSpawnRange;
			int[] bits4 = new int[4];
			bits4[0] = 1;
			decimal num4 = new decimal(bits4);
			numericUpDown4.Minimum = num4;
			this.spnSpawnRange.Name = "spnSpawnRange";
			this.spnSpawnRange.Size = new global::System.Drawing.Size(48, 20);
			this.spnSpawnRange.TabIndex = 2;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.spnSpawnRange;
			int[] bits5 = new int[4];
			bits5[0] = 10;
			decimal num5 = new decimal(bits5);
			numericUpDown5.Value = num5;
			this.lblTeam.Location = new global::System.Drawing.Point(8, 124);
			this.lblTeam.Name = "lblTeam";
			this.lblTeam.Size = new global::System.Drawing.Size(80, 16);
			this.lblTeam.TabIndex = 9;
			this.lblTeam.Text = "Team:";
			this.lblMaxCount.Location = new global::System.Drawing.Point(8, 64);
			this.lblMaxCount.Name = "lblMaxCount";
			this.lblMaxCount.Size = new global::System.Drawing.Size(80, 16);
			this.lblMaxCount.TabIndex = 3;
			this.lblMaxCount.Text = "Max Count:";
			this.spnSpawnMinDelay.Location = new global::System.Drawing.Point(96, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.spnSpawnMinDelay;
			int[] bits6 = new int[4];
			bits6[0] = 65535;
			decimal num6 = new decimal(bits6);
			numericUpDown6.Maximum = num6;
			this.spnSpawnMinDelay.Name = "spnSpawnMinDelay";
			this.spnSpawnMinDelay.Size = new global::System.Drawing.Size(48, 20);
			this.spnSpawnMinDelay.TabIndex = 6;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.spnSpawnMinDelay;
			int[] bits7 = new int[4];
			bits7[0] = 5;
			decimal num7 = new decimal(bits7);
			numericUpDown7.Value = num7;
			this.spnSpawnTeam.Location = new global::System.Drawing.Point(96, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.spnSpawnTeam;
			int[] bits8 = new int[4];
			bits8[0] = 65535;
			decimal num8 = new decimal(bits8);
			numericUpDown8.Maximum = num8;
			this.spnSpawnTeam.Name = "spnSpawnTeam";
			this.spnSpawnTeam.Size = new global::System.Drawing.Size(48, 20);
			this.spnSpawnTeam.TabIndex = 10;
			this.chkSpawnGroup.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkSpawnGroup.Location = new global::System.Drawing.Point(8, 144);
			this.chkSpawnGroup.Name = "chkSpawnGroup";
			this.chkSpawnGroup.Size = new global::System.Drawing.Size(102, 16);
			this.chkSpawnGroup.TabIndex = 11;
			this.chkSpawnGroup.Text = "Group:";
			this.spnSpawnMaxDelay.Location = new global::System.Drawing.Point(96, 100);
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.spnSpawnMaxDelay;
			int[] bits9 = new int[4];
			bits9[0] = 65535;
			decimal num9 = new decimal(bits9);
			numericUpDown9.Maximum = num9;
			this.spnSpawnMaxDelay.Name = "spnSpawnMaxDelay";
			this.spnSpawnMaxDelay.Size = new global::System.Drawing.Size(48, 20);
			this.spnSpawnMaxDelay.TabIndex = 8;
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.spnSpawnMaxDelay;
			int[] bits10 = new int[4];
			bits10[0] = 10;
			decimal num10 = new decimal(bits10);
			numericUpDown10.Value = num10;
			this.lblMinDelay.Location = new global::System.Drawing.Point(8, 84);
			this.lblMinDelay.Name = "lblMinDelay";
			this.lblMinDelay.Size = new global::System.Drawing.Size(80, 16);
			this.lblMinDelay.TabIndex = 5;
			this.lblMinDelay.Text = "Min Delay (m)";
			this.btnOk.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnOk.Location = new global::System.Drawing.Point(112, 392);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 11;
			this.btnOk.Text = "&Ok";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.Location = new global::System.Drawing.Point(192, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "&Cancel";
			this.txtCmdPrefix.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtCmdPrefix.Location = new global::System.Drawing.Point(8, 144);
			this.txtCmdPrefix.Name = "txtCmdPrefix";
			this.txtCmdPrefix.Size = new global::System.Drawing.Size(312, 20);
			this.txtCmdPrefix.TabIndex = 9;
			this.txtCmdPrefix.Text = "[";
			this.lblCmdPrefix.Location = new global::System.Drawing.Point(8, 128);
			this.lblCmdPrefix.Name = "lblCmdPrefix";
			this.lblCmdPrefix.Size = new global::System.Drawing.Size(96, 16);
			this.lblCmdPrefix.TabIndex = 8;
			this.lblCmdPrefix.Text = "Command Prefix:";
			this.lblClientWindow.Location = new global::System.Drawing.Point(8, 176);
			this.lblClientWindow.Name = "lblClientWindow";
			this.lblClientWindow.Size = new global::System.Drawing.Size(200, 16);
			this.lblClientWindow.TabIndex = 13;
			this.lblClientWindow.Text = "Client Process (PID):";
			this.cmbClientProcess.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClientProcess.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cmbClientProcess.Location = new global::System.Drawing.Point(8, 192);
			this.cmbClientProcess.Name = "cmbClientProcess";
			this.cmbClientProcess.Size = new global::System.Drawing.Size(200, 21);
			this.cmbClientProcess.TabIndex = 14;
			this.cmbClientProcess.SelectedIndexChanged += new global::System.EventHandler(this.cmbClientProcess_SelectedIndexChanged);
			this.btnRefreshProcesses.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnRefreshProcesses.Location = new global::System.Drawing.Point(212, 192);
			this.btnRefreshProcesses.Name = "btnRefreshProcesses";
			this.btnRefreshProcesses.Size = new global::System.Drawing.Size(50, 21);
			this.btnRefreshProcesses.TabIndex = 15;
			this.btnRefreshProcesses.Text = "Refresh";
			this.btnRefreshProcesses.Click += new global::System.EventHandler(this.btnRefreshProcesses_Click);
			this.btnPickClientWindow.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnPickClientWindow.Location = new global::System.Drawing.Point(266, 192);
			this.btnPickClientWindow.Name = "btnPickClientWindow";
			this.btnPickClientWindow.Size = new global::System.Drawing.Size(44, 21);
			this.btnPickClientWindow.TabIndex = 16;
			this.btnPickClientWindow.Text = "Pick";
			this.btnPickClientWindow.Click += new global::System.EventHandler(this.btnPickClientWindow_Click);
			this.startingStatics.Location = new global::System.Drawing.Point(8, 240);
			this.startingStatics.Name = "startingStatics";
			this.startingStatics.Size = new global::System.Drawing.Size(96, 16);
			this.startingStatics.TabIndex = 15;
			this.startingStatics.Text = "Statics";
			this.startingDetails.Location = new global::System.Drawing.Point(8, 256);
			this.startingDetails.Name = "startingDetails";
			this.startingDetails.Size = new global::System.Drawing.Size(96, 16);
			this.startingDetails.TabIndex = 16;
			this.startingDetails.Text = "Details";
			this.startingMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.startingMap.Location = new global::System.Drawing.Point(8, 296);
			this.startingMap.Name = "startingMap";
			this.startingMap.Size = new global::System.Drawing.Size(77, 21);
			this.startingMap.TabIndex = 17;
			this.label2.Location = new global::System.Drawing.Point(8, 224);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "On Startup:";
			this.startingOnTop.Location = new global::System.Drawing.Point(8, 272);
			this.startingOnTop.Name = "startingOnTop";
			this.startingOnTop.Size = new global::System.Drawing.Size(96, 16);
			this.startingOnTop.TabIndex = 19;
			this.startingOnTop.Text = "On Top";
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(500, 416);
			base.Controls.Add(this.btnMulPath);
			base.Controls.Add(this.txtMulPath);
			base.Controls.Add(this.lblMulPath);
			base.Controls.Add(this.startingOnTop);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.startingMap);
			base.Controls.Add(this.startingDetails);
			base.Controls.Add(this.startingStatics);
			base.Controls.Add(this.btnPickClientWindow);
			base.Controls.Add(this.btnRefreshProcesses);
			base.Controls.Add(this.cmbClientProcess);
			base.Controls.Add(this.lblClientWindow);
			base.Controls.Add(this.lblCmdPrefix);
			base.Controls.Add(this.txtCmdPrefix);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.grpSpawnEdit);
			base.Controls.Add(this.trkZoom);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtUltimaClient);
			base.Controls.Add(this.lblUltimaClient);
			base.Controls.Add(this.btnUltimaClient);
			base.Controls.Add(this.txtRunUOExe);
			base.Controls.Add(this.lblRunUOExe);
			base.Controls.Add(this.btnRunUOExe);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Sizable;
			base.MinimumSize = new global::System.Drawing.Size(516, 455);
			base.Name = "Configure";
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Show;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Spawn Editor Configuration";
			base.Load += new global::System.EventHandler(this.Configure_Load);
			this.trkZoom.EndInit();
			this.grpSpawnEdit.ResumeLayout(false);
			this.spnSpawnMaxCount.EndInit();
			this.spnSpawnRange.EndInit();
			this.spnSpawnMinDelay.EndInit();
			this.spnSpawnTeam.EndInit();
			this.spnSpawnMaxDelay.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.OpenFileDialog ofdOpenFile;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TextBox txtRunUOExe;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Button btnRunUOExe;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Label lblRunUOExe;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.TextBox txtUltimaClient;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Label lblUltimaClient;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Button btnUltimaClient;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.TrackBar trkZoom;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.GroupBox grpSpawnEdit;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Label lblMaxDelay;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.Label lblHomeRange;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Label lblTeam;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Label lblMaxCount;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.Label lblMinDelay;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.CheckBox chkSpawnRunning;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.NumericUpDown spnSpawnMaxCount;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.TextBox txtSpawnName;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.NumericUpDown spnSpawnRange;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.NumericUpDown spnSpawnMinDelay;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.NumericUpDown spnSpawnTeam;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.CheckBox chkSpawnGroup;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.NumericUpDown spnSpawnMaxDelay;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.CheckBox chkHomeRangeIsRelative;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.TextBox txtCmdPrefix;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.Label lblCmdPrefix;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Label lblClientWindow;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.ComboBox cmbClientProcess;

		private global::System.Windows.Forms.Button btnRefreshProcesses;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.CheckBox startingStatics;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.CheckBox startingDetails;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.ComboBox startingMap;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.CheckBox startingOnTop;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Button btnPickClientWindow;

		private global::System.Windows.Forms.Label lblMulPath;

		private global::System.Windows.Forms.TextBox txtMulPath;

		private global::System.Windows.Forms.Button btnMulPath;

		// Token: 0x04000086 RID: 134
		private global::System.ComponentModel.IContainer components;
	}
}
