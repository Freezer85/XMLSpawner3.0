namespace SpawnEditor2
{
	// Token: 0x02000014 RID: 20
	public partial class SpawnEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x0000A908 File Offset: 0x00008B08
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A928 File Offset: 0x00008B28
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::SpawnEditor2.SpawnEditor));
			this.axUOMap = new global::SpawnEditor2.UOMapControl();
			this.ttpSpawnInfo = new global::System.Windows.Forms.ToolTip(this.components);
			this.btnSaveSpawn = new global::System.Windows.Forms.Button();
			this.btnLoadSpawn = new global::System.Windows.Forms.Button();
			this.mncLoad = new global::System.Windows.Forms.ContextMenu();
			this.mniForceLoad = new global::System.Windows.Forms.MenuItem();
			this.menuItem21 = new global::System.Windows.Forms.MenuItem();
			this.trkZoom = new global::System.Windows.Forms.TrackBar();
			this.chkDrawStatics = new global::System.Windows.Forms.CheckBox();
			this.radShowMobilesOnly = new global::System.Windows.Forms.RadioButton();
			this.radShowItemsOnly = new global::System.Windows.Forms.RadioButton();
			this.radShowAll = new global::System.Windows.Forms.RadioButton();
			this.clbRunUOTypes = new global::System.Windows.Forms.CheckedListBox();
			this.tvwSpawnPoints = new global::System.Windows.Forms.TreeView();
			this.btnResetTypes = new global::System.Windows.Forms.Button();
			this.btnMergeSpawn = new global::System.Windows.Forms.Button();
			this.mncMerge = new global::System.Windows.Forms.ContextMenu();
			this.mniForceMerge = new global::System.Windows.Forms.MenuItem();
			this.menuItem20 = new global::System.Windows.Forms.MenuItem();
			this.chkShowMapTip = new global::System.Windows.Forms.CheckBox();
			this.chkShowSpawns = new global::System.Windows.Forms.CheckBox();
			this.cbxMap = new global::System.Windows.Forms.ComboBox();
			this.chkSyncUO = new global::System.Windows.Forms.CheckBox();
			this.chkHomeRangeIsRelative = new global::System.Windows.Forms.CheckBox();
			this.highlightDetail = new global::System.Windows.Forms.ContextMenu();
			this.btnMove = new global::System.Windows.Forms.Button();
			this.btnRestoreSpawnDefaults = new global::System.Windows.Forms.Button();
			this.btnDeleteSpawn = new global::System.Windows.Forms.Button();
			this.btnUpdateSpawn = new global::System.Windows.Forms.Button();
			this.chkRunning = new global::System.Windows.Forms.CheckBox();
			this.spnMaxCount = new global::System.Windows.Forms.NumericUpDown();
			this.txtName = new global::System.Windows.Forms.TextBox();
			this.spnHomeRange = new global::System.Windows.Forms.NumericUpDown();
			this.spnMinDelay = new global::System.Windows.Forms.NumericUpDown();
			this.spnTeam = new global::System.Windows.Forms.NumericUpDown();
			this.chkGroup = new global::System.Windows.Forms.CheckBox();
			this.spnMaxDelay = new global::System.Windows.Forms.NumericUpDown();
			this.spnSpawnRange = new global::System.Windows.Forms.NumericUpDown();
			this.spnProximityRange = new global::System.Windows.Forms.NumericUpDown();
			this.spnMinRefract = new global::System.Windows.Forms.NumericUpDown();
			this.spnTODStart = new global::System.Windows.Forms.NumericUpDown();
			this.spnMaxRefract = new global::System.Windows.Forms.NumericUpDown();
			this.chkGameTOD = new global::System.Windows.Forms.CheckBox();
			this.chkRealTOD = new global::System.Windows.Forms.CheckBox();
			this.chkAllowGhost = new global::System.Windows.Forms.CheckBox();
			this.chkSmartSpawning = new global::System.Windows.Forms.CheckBox();
			this.chkSequentialSpawn = new global::System.Windows.Forms.CheckBox();
			this.chkSpawnOnTrigger = new global::System.Windows.Forms.CheckBox();
			this.spnDespawn = new global::System.Windows.Forms.NumericUpDown();
			this.spnTODEnd = new global::System.Windows.Forms.NumericUpDown();
			this.spnDuration = new global::System.Windows.Forms.NumericUpDown();
			this.spnProximitySnd = new global::System.Windows.Forms.NumericUpDown();
			this.spnKillReset = new global::System.Windows.Forms.NumericUpDown();
			this.tvwTemplates = new global::System.Windows.Forms.TreeView();
			this.chkTracking = new global::System.Windows.Forms.CheckBox();
			this.btnGo = new global::System.Windows.Forms.Button();
			this.chkInContainer = new global::System.Windows.Forms.CheckBox();
			this.spnTriggerProbability = new global::System.Windows.Forms.NumericUpDown();
			this.spnStackAmount = new global::System.Windows.Forms.NumericUpDown();
			this.chkExternalTriggering = new global::System.Windows.Forms.CheckBox();
			this.chkAllowNPC = new global::System.Windows.Forms.CheckBox();
			this.chkTickReset = new global::System.Windows.Forms.CheckBox();
			this.spnContainerX = new global::System.Windows.Forms.NumericUpDown();
			this.spnContainerY = new global::System.Windows.Forms.NumericUpDown();
			this.spnContainerZ = new global::System.Windows.Forms.NumericUpDown();
			this.chkLockSpawn = new global::System.Windows.Forms.CheckBox();
			this.chkDetails = new global::System.Windows.Forms.CheckBox();
			this.chkSnapRegion = new global::System.Windows.Forms.CheckBox();
			this.treeRegionView = new global::System.Windows.Forms.TreeView();
			this.treeGoView = new global::System.Windows.Forms.TreeView();
			this.checkSpawnFilter = new global::System.Windows.Forms.CheckBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.clbSpawnPack = new global::System.Windows.Forms.CheckedListBox();
			this.btnUpdateFromSpawnPack = new global::System.Windows.Forms.Button();
			this.btnAddToSpawnPack = new global::System.Windows.Forms.Button();
			this.btnUpdateSpawnPacks = new global::System.Windows.Forms.Button();
			this.tvwSpawnPacks = new global::System.Windows.Forms.TreeView();
			this.chkShade = new global::System.Windows.Forms.CheckBox();
			this.cbxShade = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label28 = new global::System.Windows.Forms.Label();
			this.label27 = new global::System.Windows.Forms.Label();
			this.label25 = new global::System.Windows.Forms.Label();
			this.label24 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label21 = new global::System.Windows.Forms.Label();
			this.label22 = new global::System.Windows.Forms.Label();
			this.lblMaxDelay = new global::System.Windows.Forms.Label();
			this.lblHomeRange = new global::System.Windows.Forms.Label();
			this.lblTeam = new global::System.Windows.Forms.Label();
			this.lblMaxCount = new global::System.Windows.Forms.Label();
			this.lblMinDelay = new global::System.Windows.Forms.Label();
			this.btnSendSpawn = new global::System.Windows.Forms.Button();
			this.unloadSpawners = new global::System.Windows.Forms.ContextMenu();
			this.mniUnloadSpawners = new global::System.Windows.Forms.MenuItem();
			this.menuItem19 = new global::System.Windows.Forms.MenuItem();
			this.label30 = new global::System.Windows.Forms.Label();
			this.btnFilterSettings = new global::System.Windows.Forms.Button();
			this.pnlControls = new global::System.Windows.Forms.Panel();
			this.lblTrkMax = new global::System.Windows.Forms.Label();
			this.lblTrkMin = new global::System.Windows.Forms.Label();
			this.tabControl3 = new global::System.Windows.Forms.TabControl();
			this.tabMapSettings = new global::System.Windows.Forms.TabPage();
			this.grpMapControl = new global::System.Windows.Forms.GroupBox();
			this.tabControl2 = new global::System.Windows.Forms.TabControl();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.grpSpawnList = new global::System.Windows.Forms.GroupBox();
			this.lblTotalSpawn = new global::System.Windows.Forms.Label();
			this.tabPage4 = new global::System.Windows.Forms.TabPage();
			this.tabPage5 = new global::System.Windows.Forms.TabPage();
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.lblTransferStatus = new global::System.Windows.Forms.Label();
			this.groupTemplateList = new global::System.Windows.Forms.GroupBox();
			this.btnSaveTemplate = new global::System.Windows.Forms.Button();
			this.btnMergeTemplate = new global::System.Windows.Forms.Button();
			this.btnLoadTemplate = new global::System.Windows.Forms.Button();
			this.label29 = new global::System.Windows.Forms.Label();
			this.grpSpawnTypes = new global::System.Windows.Forms.GroupBox();
			this.lblTotalTypesLoaded = new global::System.Windows.Forms.Label();
			this.mncSpawns = new global::System.Windows.Forms.ContextMenu();
			this.menuItem3 = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteSpawn = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteAllSpawns = new global::System.Windows.Forms.MenuItem();
			this.ofdLoadFile = new global::System.Windows.Forms.OpenFileDialog();
			this.sfdSaveFile = new global::System.Windows.Forms.SaveFileDialog();
			this.stbMain = new global::System.Windows.Forms.StatusBar();
			this.grpSpawnEntries = new global::System.Windows.Forms.GroupBox();
			this.splitPanel3 = new global::System.Windows.Forms.SplitContainer();
			this.entryPer8 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer7 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer6 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer5 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer4 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer3 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer2 = new global::System.Windows.Forms.NumericUpDown();
			this.entryPer1 = new global::System.Windows.Forms.NumericUpDown();
			this.entryMaxD8 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD7 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD6 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD5 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD4 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD3 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD2 = new global::System.Windows.Forms.TextBox();
			this.entryMaxD1 = new global::System.Windows.Forms.TextBox();
			this.entryMinD8 = new global::System.Windows.Forms.TextBox();
			this.entryMinD7 = new global::System.Windows.Forms.TextBox();
			this.entryMinD6 = new global::System.Windows.Forms.TextBox();
			this.entryMinD5 = new global::System.Windows.Forms.TextBox();
			this.entryMinD4 = new global::System.Windows.Forms.TextBox();
			this.entryMinD3 = new global::System.Windows.Forms.TextBox();
			this.entryMinD2 = new global::System.Windows.Forms.TextBox();
			this.entryMinD1 = new global::System.Windows.Forms.TextBox();
			this.entryKills8 = new global::System.Windows.Forms.TextBox();
			this.entryKills7 = new global::System.Windows.Forms.TextBox();
			this.entryKills6 = new global::System.Windows.Forms.TextBox();
			this.entryKills5 = new global::System.Windows.Forms.TextBox();
			this.entryKills4 = new global::System.Windows.Forms.TextBox();
			this.entryKills3 = new global::System.Windows.Forms.TextBox();
			this.entryKills2 = new global::System.Windows.Forms.TextBox();
			this.entryKills1 = new global::System.Windows.Forms.TextBox();
			this.entryReset8 = new global::System.Windows.Forms.TextBox();
			this.entryReset7 = new global::System.Windows.Forms.TextBox();
			this.entryReset6 = new global::System.Windows.Forms.TextBox();
			this.entryReset5 = new global::System.Windows.Forms.TextBox();
			this.entryReset4 = new global::System.Windows.Forms.TextBox();
			this.entryReset3 = new global::System.Windows.Forms.TextBox();
			this.entryReset2 = new global::System.Windows.Forms.TextBox();
			this.entryReset1 = new global::System.Windows.Forms.TextBox();
			this.entryTo8 = new global::System.Windows.Forms.TextBox();
			this.entrySub8 = new global::System.Windows.Forms.TextBox();
			this.chkRK8 = new global::System.Windows.Forms.CheckBox();
			this.entryMax8 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit8 = new global::System.Windows.Forms.Button();
			this.entryText8 = new global::System.Windows.Forms.TextBox();
			this.deleteEntry = new global::System.Windows.Forms.ContextMenu();
			this.menuItem1 = new global::System.Windows.Forms.MenuItem();
			this.menuItem2 = new global::System.Windows.Forms.MenuItem();
			this.menuItem15 = new global::System.Windows.Forms.MenuItem();
			this.chkClr8 = new global::System.Windows.Forms.CheckBox();
			this.entryTo7 = new global::System.Windows.Forms.TextBox();
			this.entrySub7 = new global::System.Windows.Forms.TextBox();
			this.chkRK7 = new global::System.Windows.Forms.CheckBox();
			this.entryMax7 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit7 = new global::System.Windows.Forms.Button();
			this.entryText7 = new global::System.Windows.Forms.TextBox();
			this.chkClr7 = new global::System.Windows.Forms.CheckBox();
			this.entryTo6 = new global::System.Windows.Forms.TextBox();
			this.entrySub6 = new global::System.Windows.Forms.TextBox();
			this.chkRK6 = new global::System.Windows.Forms.CheckBox();
			this.entryMax6 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit6 = new global::System.Windows.Forms.Button();
			this.entryText6 = new global::System.Windows.Forms.TextBox();
			this.chkClr6 = new global::System.Windows.Forms.CheckBox();
			this.entryTo5 = new global::System.Windows.Forms.TextBox();
			this.entrySub5 = new global::System.Windows.Forms.TextBox();
			this.chkRK5 = new global::System.Windows.Forms.CheckBox();
			this.entryMax5 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit5 = new global::System.Windows.Forms.Button();
			this.entryText5 = new global::System.Windows.Forms.TextBox();
			this.chkClr5 = new global::System.Windows.Forms.CheckBox();
			this.entryTo4 = new global::System.Windows.Forms.TextBox();
			this.entrySub4 = new global::System.Windows.Forms.TextBox();
			this.chkRK4 = new global::System.Windows.Forms.CheckBox();
			this.entryMax4 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit4 = new global::System.Windows.Forms.Button();
			this.entryText4 = new global::System.Windows.Forms.TextBox();
			this.chkClr4 = new global::System.Windows.Forms.CheckBox();
			this.entryTo3 = new global::System.Windows.Forms.TextBox();
			this.entrySub3 = new global::System.Windows.Forms.TextBox();
			this.chkRK3 = new global::System.Windows.Forms.CheckBox();
			this.entryMax3 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit3 = new global::System.Windows.Forms.Button();
			this.entryText3 = new global::System.Windows.Forms.TextBox();
			this.chkClr3 = new global::System.Windows.Forms.CheckBox();
			this.entryTo2 = new global::System.Windows.Forms.TextBox();
			this.entrySub2 = new global::System.Windows.Forms.TextBox();
			this.chkRK2 = new global::System.Windows.Forms.CheckBox();
			this.entryMax2 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit2 = new global::System.Windows.Forms.Button();
			this.entryText2 = new global::System.Windows.Forms.TextBox();
			this.chkClr2 = new global::System.Windows.Forms.CheckBox();
			this.entryTo1 = new global::System.Windows.Forms.TextBox();
			this.vScrollBar1 = new global::System.Windows.Forms.VScrollBar();
			this.entrySub1 = new global::System.Windows.Forms.TextBox();
			this.chkRK1 = new global::System.Windows.Forms.CheckBox();
			this.entryMax1 = new global::System.Windows.Forms.NumericUpDown();
			this.btnEntryEdit1 = new global::System.Windows.Forms.Button();
			this.entryText1 = new global::System.Windows.Forms.TextBox();
			this.chkClr1 = new global::System.Windows.Forms.CheckBox();
			this.editEntryMenu1 = new global::System.Windows.Forms.ContextMenu();
			this.grpSpawnEdit = new global::System.Windows.Forms.GroupBox();
			this.btnSendSingleSpawner = new global::System.Windows.Forms.Button();
			this.unloadSingleSpawner = new global::System.Windows.Forms.ContextMenu();
			this.mniUnloadSingleSpawner = new global::System.Windows.Forms.MenuItem();
			this.menuItem23 = new global::System.Windows.Forms.MenuItem();
			this.label26 = new global::System.Windows.Forms.Label();
			this.textTrigObjectProp = new global::System.Windows.Forms.TextBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.textSkillTrigger = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.textSpeechTrigger = new global::System.Windows.Forms.TextBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.textProximityMsg = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.textPlayerTrigProp = new global::System.Windows.Forms.TextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.textNoTriggerOnCarried = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.textTriggerOnCarried = new global::System.Windows.Forms.TextBox();
			this.mainMenu1 = new global::System.Windows.Forms.MainMenu();
			this.menuItem5 = new global::System.Windows.Forms.MenuItem();
			this.menuItem6 = new global::System.Windows.Forms.MenuItem();
			this.menuItem7 = new global::System.Windows.Forms.MenuItem();
			this.menuItem10 = new global::System.Windows.Forms.MenuItem();
			this.menuItem11 = new global::System.Windows.Forms.MenuItem();
			this.menuItem12 = new global::System.Windows.Forms.MenuItem();
			this.menuItem13 = new global::System.Windows.Forms.MenuItem();
			this.menuItem22 = new global::System.Windows.Forms.MenuItem();
			this.menuItem24 = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteInSelectionWindow = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteNotSelected = new global::System.Windows.Forms.MenuItem();
			this.mniToolbarDeleteAllSpawns = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteAllFiltered = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteAllUnfiltered = new global::System.Windows.Forms.MenuItem();
			this.menuItem25 = new global::System.Windows.Forms.MenuItem();
			this.mniModifyInSelectionWindow = new global::System.Windows.Forms.MenuItem();
			this.mniModifiedUnfiltered = new global::System.Windows.Forms.MenuItem();
			this.menuItem8 = new global::System.Windows.Forms.MenuItem();
			this.menuItem9 = new global::System.Windows.Forms.MenuItem();
			this.menuItem17 = new global::System.Windows.Forms.MenuItem();
			this.mniDisplayFilterSettings = new global::System.Windows.Forms.MenuItem();
			this.menuItem14 = new global::System.Windows.Forms.MenuItem();
			this.mniAlwaysOnTop = new global::System.Windows.Forms.MenuItem();
			this.menuItem16 = new global::System.Windows.Forms.MenuItem();
			this.menuItem18 = new global::System.Windows.Forms.MenuItem();
			this.menuItem4 = new global::System.Windows.Forms.MenuItem();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panelRight = new global::System.Windows.Forms.Panel();
			this.splitContainerRightDetails = new global::System.Windows.Forms.SplitContainer();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabBasic = new global::System.Windows.Forms.TabPage();
			this.tabAdvanced = new global::System.Windows.Forms.TabPage();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.label44 = new global::System.Windows.Forms.Label();
			this.txtNotes = new global::System.Windows.Forms.TextBox();
			this.label37 = new global::System.Windows.Forms.Label();
			this.textRegionName = new global::System.Windows.Forms.TextBox();
			this.label36 = new global::System.Windows.Forms.Label();
			this.textWayPoint = new global::System.Windows.Forms.TextBox();
			this.label35 = new global::System.Windows.Forms.Label();
			this.textConfigFile = new global::System.Windows.Forms.TextBox();
			this.label34 = new global::System.Windows.Forms.Label();
			this.textSetObjectName = new global::System.Windows.Forms.TextBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.textTrigObjectName = new global::System.Windows.Forms.TextBox();
			this.labelContainerZ = new global::System.Windows.Forms.Label();
			this.labelContainerY = new global::System.Windows.Forms.Label();
			this.labelContainerX = new global::System.Windows.Forms.Label();
			this.label32 = new global::System.Windows.Forms.Label();
			this.label31 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.textMobTriggerName = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.textMobTrigProp = new global::System.Windows.Forms.TextBox();
			this.tabSpawnTypes = new global::System.Windows.Forms.TabPage();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.textSpawnPackName = new global::System.Windows.Forms.TextBox();
			this.label39 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.helpProvider1 = new global::System.Windows.Forms.HelpProvider();
			this.mcnSpawnPack = new global::System.Windows.Forms.ContextMenu();
			this.mniDeleteType = new global::System.Windows.Forms.MenuItem();
			this.mniDeleteAllTypes = new global::System.Windows.Forms.MenuItem();
			this.mcnSpawnPacks = new global::System.Windows.Forms.ContextMenu();
			this.mniDeletePack = new global::System.Windows.Forms.MenuItem();
			this.openSpawnPacks = new global::System.Windows.Forms.OpenFileDialog();
			this.saveSpawnPacks = new global::System.Windows.Forms.SaveFileDialog();
			this.exportAllSpawnTypes = new global::System.Windows.Forms.SaveFileDialog();
			this.importAllSpawnTypes = new global::System.Windows.Forms.OpenFileDialog();
			this.importMapFile = new global::System.Windows.Forms.OpenFileDialog();
			this.importMSFFile = new global::System.Windows.Forms.OpenFileDialog();
			((global::System.ComponentModel.ISupportInitialize)(this.axUOMap)).BeginInit();
			this.trkZoom.BeginInit();
			this.spnMaxCount.BeginInit();
			this.spnHomeRange.BeginInit();
			this.spnMinDelay.BeginInit();
			this.spnTeam.BeginInit();
			this.spnMaxDelay.BeginInit();
			this.spnSpawnRange.BeginInit();
			this.spnProximityRange.BeginInit();
			this.spnMinRefract.BeginInit();
			this.spnTODStart.BeginInit();
			this.spnMaxRefract.BeginInit();
			this.spnDespawn.BeginInit();
			this.spnTODEnd.BeginInit();
			this.spnDuration.BeginInit();
			this.spnProximitySnd.BeginInit();
			this.spnKillReset.BeginInit();
			this.spnTriggerProbability.BeginInit();
			this.spnStackAmount.BeginInit();
			this.spnContainerX.BeginInit();
			this.spnContainerY.BeginInit();
			this.spnContainerZ.BeginInit();
			this.pnlControls.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabMapSettings.SuspendLayout();
			this.grpMapControl.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.grpSpawnList.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupTemplateList.SuspendLayout();
			this.grpSpawnTypes.SuspendLayout();
			this.grpSpawnEntries.SuspendLayout();
			this.entryPer8.BeginInit();
			this.entryPer7.BeginInit();
			this.entryPer6.BeginInit();
			this.entryPer5.BeginInit();
			this.entryPer4.BeginInit();
			this.entryPer3.BeginInit();
			this.entryPer2.BeginInit();
			this.entryPer1.BeginInit();
			this.entryMax8.BeginInit();
			this.entryMax7.BeginInit();
			this.entryMax6.BeginInit();
			this.entryMax5.BeginInit();
			this.entryMax4.BeginInit();
			this.entryMax3.BeginInit();
			this.entryMax2.BeginInit();
			this.entryMax1.BeginInit();
			this.grpSpawnEdit.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabBasic.SuspendLayout();
			this.tabAdvanced.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabSpawnTypes.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)(this.splitContainerRightDetails)).BeginInit();
			this.splitContainerRightDetails.Panel1.SuspendLayout();
			this.splitContainerRightDetails.Panel2.SuspendLayout();
			this.splitContainerRightDetails.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
			this.splitPanel3.Panel1.SuspendLayout();
			this.splitPanel3.Panel2.SuspendLayout();
			this.splitPanel3.SuspendLayout();
			base.SuspendLayout();
			this.axUOMap.AllowDrop = true;
			this.axUOMap.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.axUOMap.Enabled = true;
			this.axUOMap.Location = new global::System.Drawing.Point(0, 0);
			this.axUOMap.Name = "axUOMap";
			this.axUOMap.Size = new global::System.Drawing.Size(300, 764);
			this.axUOMap.TabIndex = 1;
			this.axUOMap.MouseMoveEvent += new global::SpawnEditor2.UOMapMouseEventHandler(this.axUOMap_MouseMoveEvent);
			this.axUOMap.MouseDownEvent += new global::SpawnEditor2.UOMapMouseEventHandler(this.axUOMap_MouseDownEvent);
			this.axUOMap.MouseUpEvent += new global::SpawnEditor2.UOMapMouseEventHandler(this.axUOMap_MouseUpEvent);
			this.ttpSpawnInfo.AutoPopDelay = 5000;
			this.ttpSpawnInfo.InitialDelay = 500;
			this.ttpSpawnInfo.ReshowDelay = 100;
			this.btnSaveSpawn.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSaveSpawn.Location = new global::System.Drawing.Point(112, 32);
			this.btnSaveSpawn.Name = "btnSaveSpawn";
			this.btnSaveSpawn.Size = new global::System.Drawing.Size(48, 24);
			this.btnSaveSpawn.TabIndex = 2;
			this.btnSaveSpawn.Text = "&Save";
			this.ttpSpawnInfo.SetToolTip(this.btnSaveSpawn, "Saves the current spawn list.");
			this.btnSaveSpawn.Click += new global::System.EventHandler(this.btnSaveSpawn_Click);
			this.btnLoadSpawn.ContextMenu = this.mncLoad;
			this.btnLoadSpawn.Location = new global::System.Drawing.Point(8, 32);
			this.btnLoadSpawn.Name = "btnLoadSpawn";
			this.btnLoadSpawn.Size = new global::System.Drawing.Size(40, 24);
			this.btnLoadSpawn.TabIndex = 0;
			this.btnLoadSpawn.Text = "&Load";
			this.ttpSpawnInfo.SetToolTip(this.btnLoadSpawn, "Clears the currently defined spawns, if any, and loads a spawn file.  Right-Click on the Load button to bring up a menu to force loading a spawn file into the currently selected map.  This can be used to convert a spawn file from one map to another.");
			this.btnLoadSpawn.Click += new global::System.EventHandler(this.btnLoadSpawn_Click);
			this.mncLoad.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniForceLoad, this.menuItem21 });
			this.mncLoad.Popup += new global::System.EventHandler(this.mncLoad_Popup);
			this.mniForceLoad.Index = 0;
			this.mniForceLoad.Text = "Force Load Into Current Map...";
			this.mniForceLoad.Click += new global::System.EventHandler(this.mniForceLoad_Click);
			this.menuItem21.Index = 1;
			this.menuItem21.Text = "Cancel";
			this.trkZoom.AutoSize = false;
			this.trkZoom.LargeChange = 2;
			this.trkZoom.Location = new global::System.Drawing.Point(16, 168);
			this.trkZoom.Maximum = 4;
			this.trkZoom.Minimum = -4;
			this.trkZoom.Name = "trkZoom";
			this.trkZoom.Size = new global::System.Drawing.Size(152, 32);
			this.trkZoom.TabIndex = 5;
			this.trkZoom.TickStyle = global::System.Windows.Forms.TickStyle.TopLeft;
			this.ttpSpawnInfo.SetToolTip(this.trkZoom, "Zooms in/out of map.");
			this.trkZoom.ValueChanged += new global::System.EventHandler(this.trkZoom_ValueChanged);
			this.trkZoom.Scroll += new global::System.EventHandler(this.trkZoom_Scroll);
			this.chkDrawStatics.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.chkDrawStatics.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkDrawStatics.Location = new global::System.Drawing.Point(77, 8);
			this.chkDrawStatics.Name = "chkDrawStatics";
			this.chkDrawStatics.Size = new global::System.Drawing.Size(80, 16);
			this.chkDrawStatics.TabIndex = 1;
			this.chkDrawStatics.Text = "Statics";
			this.ttpSpawnInfo.SetToolTip(this.chkDrawStatics, "Draws static tiles on the map.");
			this.chkDrawStatics.CheckedChanged += new global::System.EventHandler(this.chkDrawStatics_CheckedChanged);
			this.radShowMobilesOnly.Location = new global::System.Drawing.Point(104, 16);
			this.radShowMobilesOnly.Name = "radShowMobilesOnly";
			this.radShowMobilesOnly.Size = new global::System.Drawing.Size(64, 16);
			this.radShowMobilesOnly.TabIndex = 2;
			this.radShowMobilesOnly.Text = "Mobiles";
			this.ttpSpawnInfo.SetToolTip(this.radShowMobilesOnly, "Shows only mobile based spawn objects.");
			this.radShowMobilesOnly.CheckedChanged += new global::System.EventHandler(this.TypeSelectionChanged);
			this.radShowItemsOnly.Location = new global::System.Drawing.Point(56, 16);
			this.radShowItemsOnly.Name = "radShowItemsOnly";
			this.radShowItemsOnly.Size = new global::System.Drawing.Size(64, 16);
			this.radShowItemsOnly.TabIndex = 1;
			this.radShowItemsOnly.Text = "Items";
			this.ttpSpawnInfo.SetToolTip(this.radShowItemsOnly, "Shows only item based spawn objects.");
			this.radShowItemsOnly.CheckedChanged += new global::System.EventHandler(this.TypeSelectionChanged);
			this.radShowAll.Checked = true;
			this.radShowAll.Location = new global::System.Drawing.Point(8, 16);
			this.radShowAll.Name = "radShowAll";
			this.radShowAll.Size = new global::System.Drawing.Size(56, 16);
			this.radShowAll.TabIndex = 0;
			this.radShowAll.TabStop = true;
			this.radShowAll.Text = "All";
			this.ttpSpawnInfo.SetToolTip(this.radShowAll, "Shows all types of spawn objects (items/mobiles).");
			this.radShowAll.CheckedChanged += new global::System.EventHandler(this.TypeSelectionChanged);
			this.clbRunUOTypes.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.clbRunUOTypes.CheckOnClick = true;
			this.clbRunUOTypes.HorizontalScrollbar = true;
			this.clbRunUOTypes.IntegralHeight = false;
			this.clbRunUOTypes.Location = new global::System.Drawing.Point(8, 96);
			this.clbRunUOTypes.Name = "clbRunUOTypes";
			this.clbRunUOTypes.Size = new global::System.Drawing.Size(160, 320);
			this.clbRunUOTypes.TabIndex = 4;
			this.clbRunUOTypes.ThreeDCheckBoxes = true;
			this.ttpSpawnInfo.SetToolTip(this.clbRunUOTypes, "List of all spawnable objects.");
			this.tvwSpawnPoints.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tvwSpawnPoints.ImageIndex = -1;
			this.tvwSpawnPoints.Location = new global::System.Drawing.Point(8, 80);
			this.tvwSpawnPoints.Name = "tvwSpawnPoints";
			this.tvwSpawnPoints.SelectedImageIndex = -1;
			this.tvwSpawnPoints.Size = new global::System.Drawing.Size(196, 514);
			this.tvwSpawnPoints.TabIndex = 3;
			this.ttpSpawnInfo.SetToolTip(this.tvwSpawnPoints, "List of currently defined spawns.  Right-Click for a context menu based on the currently selected spawn.");
			this.tvwSpawnPoints.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tvwSpawnPoints_MouseUp);
			this.tvwTemplates.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tvwTemplates_MouseUp);
			this.btnResetTypes.Location = new global::System.Drawing.Point(8, 35);
			this.btnResetTypes.Name = "btnResetTypes";
			this.btnResetTypes.Size = new global::System.Drawing.Size(160, 20);
			this.btnResetTypes.TabIndex = 3;
			this.btnResetTypes.Text = "&Clear Selections";
			this.ttpSpawnInfo.SetToolTip(this.btnResetTypes, "Clears current selections from the type list.");
			this.btnResetTypes.Click += new global::System.EventHandler(this.btnResetTypes_Click);
			this.btnMergeSpawn.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnMergeSpawn.ContextMenu = this.mncMerge;
			this.btnMergeSpawn.Location = new global::System.Drawing.Point(48, 32);
			this.btnMergeSpawn.Name = "btnMergeSpawn";
			this.btnMergeSpawn.Size = new global::System.Drawing.Size(64, 24);
			this.btnMergeSpawn.TabIndex = 1;
			this.btnMergeSpawn.Text = "&Merge";
			this.ttpSpawnInfo.SetToolTip(this.btnMergeSpawn, "Loads a spawn file WITHOUT clearing the current spawn list.  Right-Click on the Merge button to bring up a menu to force merging a spawn file into the currently selected map.  This can be used to convert a spawn file from one map to another.");
			this.btnMergeSpawn.Click += new global::System.EventHandler(this.btnMergeSpawn_Click);
			this.mncMerge.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniForceMerge, this.menuItem20 });
			this.mniForceMerge.Index = 0;
			this.mniForceMerge.Text = "Force Merge Into Current Map...";
			this.mniForceMerge.Click += new global::System.EventHandler(this.mniForceMerge_Click);
			this.menuItem20.Index = 1;
			this.menuItem20.Text = "Cancel";
			this.chkShowMapTip.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.chkShowMapTip.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkShowMapTip.Checked = true;
			this.chkShowMapTip.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkShowMapTip.Location = new global::System.Drawing.Point(77, 24);
			this.chkShowMapTip.Name = "chkShowMapTip";
			this.chkShowMapTip.Size = new global::System.Drawing.Size(80, 16);
			this.chkShowMapTip.TabIndex = 2;
			this.chkShowMapTip.Text = "Spawn Tip";
			this.ttpSpawnInfo.SetToolTip(this.chkShowMapTip, "Turns on/off the spawn tool tip when hovering over a spawn.");
			this.chkShowSpawns.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.chkShowSpawns.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkShowSpawns.Checked = true;
			this.chkShowSpawns.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkShowSpawns.Location = new global::System.Drawing.Point(77, 40);
			this.chkShowSpawns.Name = "chkShowSpawns";
			this.chkShowSpawns.Size = new global::System.Drawing.Size(80, 16);
			this.chkShowSpawns.TabIndex = 3;
			this.chkShowSpawns.Text = "Spawns";
			this.ttpSpawnInfo.SetToolTip(this.chkShowSpawns, "Turns on/off drawing of spawn points.");
			this.chkShowSpawns.CheckedChanged += new global::System.EventHandler(this.chkShowSpawns_CheckedChanged);
			this.cbxMap.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMap.Location = new global::System.Drawing.Point(85, 80);
			this.cbxMap.Name = "cbxMap";
			this.cbxMap.Size = new global::System.Drawing.Size(77, 21);
			this.cbxMap.TabIndex = 4;
			this.ttpSpawnInfo.SetToolTip(this.cbxMap, "Changes the current map.");
			this.cbxMap.SelectedIndexChanged += new global::System.EventHandler(this.cbxMap_SelectedIndexChanged);
			this.chkSyncUO.Location = new global::System.Drawing.Point(8, 64);
			this.chkSyncUO.Name = "chkSyncUO";
			this.chkSyncUO.Size = new global::System.Drawing.Size(48, 16);
			this.chkSyncUO.TabIndex = 6;
			this.chkSyncUO.Text = "Sync:";
			this.ttpSpawnInfo.SetToolTip(this.chkSyncUO, "Automatically move player to spawner locations when they are selected.");
			this.chkHomeRangeIsRelative.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkHomeRangeIsRelative.Checked = true;
			this.chkHomeRangeIsRelative.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkHomeRangeIsRelative.ContextMenu = this.highlightDetail;
			this.chkHomeRangeIsRelative.Location = new global::System.Drawing.Point(8, 216);
			this.chkHomeRangeIsRelative.Name = "chkHomeRangeIsRelative";
			this.chkHomeRangeIsRelative.Size = new global::System.Drawing.Size(104, 16);
			this.chkHomeRangeIsRelative.TabIndex = 13;
			this.chkHomeRangeIsRelative.Text = "RelativeHome:";
			this.ttpSpawnInfo.SetToolTip(this.chkHomeRangeIsRelative, "Check if the object to be spawned should set its home point base on its spawned location and not the spawners location.");
			this.highlightDetail.Popup += new global::System.EventHandler(this.highlightDetail_Popup);
			this.btnMove.Enabled = false;
			this.btnMove.Location = new global::System.Drawing.Point(192, 408);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new global::System.Drawing.Size(32, 23);
			this.btnMove.TabIndex = 17;
			this.btnMove.Text = "&XY";
			this.ttpSpawnInfo.SetToolTip(this.btnMove, "Adjusted the spawners boundaries.");
			this.btnMove.Click += new global::System.EventHandler(this.btnMove_Click);
			this.btnRestoreSpawnDefaults.Location = new global::System.Drawing.Point(8, 408);
			this.btnRestoreSpawnDefaults.Name = "btnRestoreSpawnDefaults";
			this.btnRestoreSpawnDefaults.Size = new global::System.Drawing.Size(96, 23);
			this.btnRestoreSpawnDefaults.TabIndex = 14;
			this.btnRestoreSpawnDefaults.Text = "Restore Defaults";
			this.ttpSpawnInfo.SetToolTip(this.btnRestoreSpawnDefaults, "Restores the spawn details to the default values.");
			this.btnRestoreSpawnDefaults.Click += new global::System.EventHandler(this.btnRestoreSpawnDefaults_Click);
			this.btnDeleteSpawn.Enabled = false;
			this.btnDeleteSpawn.Location = new global::System.Drawing.Point(104, 408);
			this.btnDeleteSpawn.Name = "btnDeleteSpawn";
			this.btnDeleteSpawn.Size = new global::System.Drawing.Size(88, 23);
			this.btnDeleteSpawn.TabIndex = 16;
			this.btnDeleteSpawn.Text = "&Delete Spawn";
			this.ttpSpawnInfo.SetToolTip(this.btnDeleteSpawn, "Deletes the currently selected spawn.");
			this.btnDeleteSpawn.Click += new global::System.EventHandler(this.btnDeleteSpawn_Click);
			this.btnUpdateSpawn.Enabled = false;
			this.btnUpdateSpawn.Location = new global::System.Drawing.Point(8, 55);
			this.btnUpdateSpawn.Name = "btnUpdateSpawn";
			this.btnUpdateSpawn.Size = new global::System.Drawing.Size(160, 20);
			this.btnUpdateSpawn.TabIndex = 15;
			this.btnUpdateSpawn.Text = "&Add to Spawner";
			this.ttpSpawnInfo.SetToolTip(this.btnUpdateSpawn, "Updates the currently selected spawn with the selected types.");
			this.btnUpdateSpawn.Click += new global::System.EventHandler(this.btnUpdateSpawn_Click);
			this.chkRunning.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkRunning.Checked = true;
			this.chkRunning.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkRunning.ContextMenu = this.highlightDetail;
			this.chkRunning.Location = new global::System.Drawing.Point(8, 200);
			this.chkRunning.Name = "chkRunning";
			this.chkRunning.Size = new global::System.Drawing.Size(104, 16);
			this.chkRunning.TabIndex = 12;
			this.chkRunning.Text = "Running:";
			this.ttpSpawnInfo.SetToolTip(this.chkRunning, "Check if the spawner should be running.");
			this.spnMaxCount.ContextMenu = this.highlightDetail;
			this.spnMaxCount.Location = new global::System.Drawing.Point(96, 60);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.spnMaxCount;
			int[] bits = new int[4];
			bits[0] = 65535;
			decimal num = new decimal(bits);
			numericUpDown.Maximum = num;
			this.spnMaxCount.Name = "spnMaxCount";
			this.spnMaxCount.Size = new global::System.Drawing.Size(72, 20);
			this.spnMaxCount.TabIndex = 4;
			this.ttpSpawnInfo.SetToolTip(this.spnMaxCount, "Absolute maximum number of objects to be spawned by this spawner.");
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.spnMaxCount;
			int[] bits2 = new int[4];
			bits2[0] = 1;
			decimal num2 = new decimal(bits2);
			numericUpDown2.Value = num2;
			this.spnMaxCount.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.txtName.ContextMenu = this.highlightDetail;
			this.txtName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtName.Location = new global::System.Drawing.Point(8, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new global::System.Drawing.Size(472, 20);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "Spawn";
			this.ttpSpawnInfo.SetToolTip(this.txtName, "Name of the spawner.");
			this.txtName.Leave += new global::System.EventHandler(this.txtName_Leave);
			this.txtName.MouseLeave += new global::System.EventHandler(this.txtName_MouseLeave);
			this.txtName.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
			this.txtName.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnHomeRange.BackColor = global::System.Drawing.SystemColors.Window;
			this.spnHomeRange.ContextMenu = this.highlightDetail;
			this.spnHomeRange.Location = new global::System.Drawing.Point(96, 40);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.spnHomeRange;
			int[] bits3 = new int[4];
			bits3[0] = 65535;
			decimal num3 = new decimal(bits3);
			numericUpDown3.Maximum = num3;
			this.spnHomeRange.Name = "spnHomeRange";
			this.spnHomeRange.Size = new global::System.Drawing.Size(72, 20);
			this.spnHomeRange.TabIndex = 2;
			this.ttpSpawnInfo.SetToolTip(this.spnHomeRange, "Maximum wandering range of the spawn from its spawned location.");
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.spnHomeRange;
			int[] bits4 = new int[4];
			bits4[0] = 5;
			decimal num4 = new decimal(bits4);
			numericUpDown4.Value = num4;
			this.spnHomeRange.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnMinDelay.ContextMenu = this.highlightDetail;
			this.spnMinDelay.DecimalPlaces = 1;
			this.spnMinDelay.Location = new global::System.Drawing.Point(96, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.spnMinDelay;
			int[] bits5 = new int[4];
			bits5[0] = 65535000;
			decimal num5 = new decimal(bits5);
			numericUpDown5.Maximum = num5;
			this.spnMinDelay.Name = "spnMinDelay";
			this.spnMinDelay.Size = new global::System.Drawing.Size(72, 20);
			this.spnMinDelay.TabIndex = 6;
			this.ttpSpawnInfo.SetToolTip(this.spnMinDelay, "Minimum delay to respawn (in minutes).");
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.spnMinDelay;
			int[] bits6 = new int[4];
			bits6[0] = 5;
			decimal num6 = new decimal(bits6);
			numericUpDown6.Value = num6;
			this.spnMinDelay.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnMinDelay.ValueChanged += new global::System.EventHandler(this.spnMinDelay_ValueChanged);
			this.spnTeam.ContextMenu = this.highlightDetail;
			this.spnTeam.Location = new global::System.Drawing.Point(96, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.spnTeam;
			int[] bits7 = new int[4];
			bits7[0] = 65535;
			decimal num7 = new decimal(bits7);
			numericUpDown7.Maximum = num7;
			this.spnTeam.Name = "spnTeam";
			this.spnTeam.Size = new global::System.Drawing.Size(72, 20);
			this.spnTeam.TabIndex = 10;
			this.ttpSpawnInfo.SetToolTip(this.spnTeam, "Team that spawned object will belong to.");
			this.spnTeam.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.chkGroup.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkGroup.ContextMenu = this.highlightDetail;
			this.chkGroup.Location = new global::System.Drawing.Point(8, 184);
			this.chkGroup.Name = "chkGroup";
			this.chkGroup.Size = new global::System.Drawing.Size(104, 16);
			this.chkGroup.TabIndex = 11;
			this.chkGroup.Text = "Group:";
			this.ttpSpawnInfo.SetToolTip(this.chkGroup, "Check if the spawned object belongs to a group.");
			this.spnMaxDelay.ContextMenu = this.highlightDetail;
			this.spnMaxDelay.DecimalPlaces = 1;
			this.spnMaxDelay.Location = new global::System.Drawing.Point(96, 100);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.spnMaxDelay;
			int[] bits8 = new int[4];
			bits8[0] = 65535000;
			decimal num8 = new decimal(bits8);
			numericUpDown8.Maximum = num8;
			this.spnMaxDelay.Name = "spnMaxDelay";
			this.spnMaxDelay.Size = new global::System.Drawing.Size(72, 20);
			this.spnMaxDelay.TabIndex = 8;
			this.ttpSpawnInfo.SetToolTip(this.spnMaxDelay, "Maximum delay to respawn (in minutes).");
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.spnMaxDelay;
			int[] bits9 = new int[4];
			bits9[0] = 10;
			decimal num9 = new decimal(bits9);
			numericUpDown9.Value = num9;
			this.spnMaxDelay.Enter += new global::System.EventHandler(this.TextEntryControl_Enter);
			this.spnSpawnRange.ContextMenu = this.highlightDetail;
			this.spnSpawnRange.Location = new global::System.Drawing.Point(96, 140);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.spnSpawnRange;
			int[] bits10 = new int[4];
			bits10[0] = 65535;
			decimal num10 = new decimal(bits10);
			numericUpDown10.Maximum = num10;
			this.spnSpawnRange.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
			this.spnSpawnRange.Name = "spnSpawnRange";
			this.spnSpawnRange.Size = new global::System.Drawing.Size(72, 20);
			this.spnSpawnRange.TabIndex = 180;
			this.ttpSpawnInfo.SetToolTip(this.spnSpawnRange, "Maximum spawning range.  A value of -1 means the range is specified by XY.");
			this.spnSpawnRange.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
			this.spnSpawnRange.ValueChanged += new global::System.EventHandler(this.spnSpawnRange_ValueChanged);
			this.spnProximityRange.ContextMenu = this.highlightDetail;
			this.spnProximityRange.Location = new global::System.Drawing.Point(96, 160);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.spnProximityRange;
			int[] bits11 = new int[4];
			bits11[0] = 65535;
			decimal num11 = new decimal(bits11);
			numericUpDown11.Maximum = num11;
			this.spnProximityRange.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
			this.spnProximityRange.Name = "spnProximityRange";
			this.spnProximityRange.Size = new global::System.Drawing.Size(72, 20);
			this.spnProximityRange.TabIndex = 178;
			this.ttpSpawnInfo.SetToolTip(this.spnProximityRange, "Maximum range within which a player can trigger the spawner.");
			this.spnProximityRange.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
			this.spnMinRefract.ContextMenu = this.highlightDetail;
			this.spnMinRefract.DecimalPlaces = 1;
			this.spnMinRefract.Location = new global::System.Drawing.Point(280, 60);
			global::System.Windows.Forms.NumericUpDown numericUpDown12 = this.spnMinRefract;
			int[] bits12 = new int[4];
			bits12[0] = 65535000;
			decimal num12 = new decimal(bits12);
			numericUpDown12.Maximum = num12;
			this.spnMinRefract.Name = "spnMinRefract";
			this.spnMinRefract.Size = new global::System.Drawing.Size(72, 20);
			this.spnMinRefract.TabIndex = 182;
			this.ttpSpawnInfo.SetToolTip(this.spnMinRefract, "Minimum delay after triggering when the spawner can be triggered again (in minutes).");
			this.spnTODStart.ContextMenu = this.highlightDetail;
			this.spnTODStart.DecimalPlaces = 1;
			this.spnTODStart.Location = new global::System.Drawing.Point(280, 100);
			global::System.Windows.Forms.NumericUpDown numericUpDown13 = this.spnTODStart;
			int[] bits13 = new int[4];
			bits13[0] = 65535;
			decimal num13 = new decimal(bits13);
			numericUpDown13.Maximum = num13;
			this.spnTODStart.Name = "spnTODStart";
			this.spnTODStart.Size = new global::System.Drawing.Size(72, 20);
			this.spnTODStart.TabIndex = 186;
			this.ttpSpawnInfo.SetToolTip(this.spnTODStart, "Starting hour after which spawning can occur.");
			this.spnMaxRefract.ContextMenu = this.highlightDetail;
			this.spnMaxRefract.DecimalPlaces = 1;
			this.spnMaxRefract.Location = new global::System.Drawing.Point(280, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown14 = this.spnMaxRefract;
			int[] bits14 = new int[4];
			bits14[0] = 65535000;
			decimal num14 = new decimal(bits14);
			numericUpDown14.Maximum = num14;
			this.spnMaxRefract.Name = "spnMaxRefract";
			this.spnMaxRefract.Size = new global::System.Drawing.Size(72, 20);
			this.spnMaxRefract.TabIndex = 184;
			this.ttpSpawnInfo.SetToolTip(this.spnMaxRefract, "Maximum delay after triggering when the spawner can be triggered again (in minutes).");
			this.chkGameTOD.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkGameTOD.ContextMenu = this.highlightDetail;
			this.chkGameTOD.Location = new global::System.Drawing.Point(128, 216);
			this.chkGameTOD.Name = "chkGameTOD";
			this.chkGameTOD.Size = new global::System.Drawing.Size(88, 16);
			this.chkGameTOD.TabIndex = 189;
			this.chkGameTOD.Text = "GameTOD:";
			this.ttpSpawnInfo.SetToolTip(this.chkGameTOD, "Time of Day triggering uses game world time.");
			this.chkRealTOD.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkRealTOD.Checked = true;
			this.chkRealTOD.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkRealTOD.ContextMenu = this.highlightDetail;
			this.chkRealTOD.Location = new global::System.Drawing.Point(128, 200);
			this.chkRealTOD.Name = "chkRealTOD";
			this.chkRealTOD.Size = new global::System.Drawing.Size(88, 16);
			this.chkRealTOD.TabIndex = 188;
			this.chkRealTOD.Text = "RealTOD:";
			this.ttpSpawnInfo.SetToolTip(this.chkRealTOD, "Time of Day triggering uses real world time.");
			this.chkAllowGhost.BackColor = global::System.Drawing.SystemColors.Control;
			this.chkAllowGhost.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkAllowGhost.ContextMenu = this.highlightDetail;
			this.chkAllowGhost.Location = new global::System.Drawing.Point(128, 184);
			this.chkAllowGhost.Name = "chkAllowGhost";
			this.chkAllowGhost.Size = new global::System.Drawing.Size(88, 16);
			this.chkAllowGhost.TabIndex = 187;
			this.chkAllowGhost.Text = "AllowGhost:";
			this.ttpSpawnInfo.SetToolTip(this.chkAllowGhost, "Allow the spawner to be triggered by players in ghost form.");
			this.chkSmartSpawning.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkSmartSpawning.ContextMenu = this.highlightDetail;
			this.chkSmartSpawning.Location = new global::System.Drawing.Point(232, 216);
			this.chkSmartSpawning.Name = "chkSmartSpawning";
			this.chkSmartSpawning.Size = new global::System.Drawing.Size(120, 16);
			this.chkSmartSpawning.TabIndex = 192;
			this.chkSmartSpawning.Text = "SmartSpawning:";
			this.ttpSpawnInfo.SetToolTip(this.chkSmartSpawning, "Enable automatic spawning/despawning based upon nearby player activity.");
			this.chkSmartSpawning.CheckedChanged += new global::System.EventHandler(this.checkBox20_CheckedChanged);
			this.chkSequentialSpawn.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkSequentialSpawn.ContextMenu = this.highlightDetail;
			this.chkSequentialSpawn.Location = new global::System.Drawing.Point(232, 200);
			this.chkSequentialSpawn.Name = "chkSequentialSpawn";
			this.chkSequentialSpawn.Size = new global::System.Drawing.Size(120, 16);
			this.chkSequentialSpawn.TabIndex = 191;
			this.chkSequentialSpawn.Text = "SequentialSpawn:";
			this.ttpSpawnInfo.SetToolTip(this.chkSequentialSpawn, "Enable sequential spawning that will advance according to subgroup number.");
			this.chkSpawnOnTrigger.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkSpawnOnTrigger.ContextMenu = this.highlightDetail;
			this.chkSpawnOnTrigger.Location = new global::System.Drawing.Point(232, 184);
			this.chkSpawnOnTrigger.Name = "chkSpawnOnTrigger";
			this.chkSpawnOnTrigger.Size = new global::System.Drawing.Size(120, 16);
			this.chkSpawnOnTrigger.TabIndex = 190;
			this.chkSpawnOnTrigger.Text = "SpawnOnTrigger:";
			this.ttpSpawnInfo.SetToolTip(this.chkSpawnOnTrigger, "Spawn immediately after triggering regardless of min/maxdelay.");
			this.spnDespawn.ContextMenu = this.highlightDetail;
			this.spnDespawn.DecimalPlaces = 1;
			this.spnDespawn.Location = new global::System.Drawing.Point(280, 40);
			global::System.Windows.Forms.NumericUpDown numericUpDown15 = this.spnDespawn;
			int[] bits15 = new int[4];
			bits15[0] = 65535000;
			decimal num15 = new decimal(bits15);
			numericUpDown15.Maximum = num15;
			this.spnDespawn.Name = "spnDespawn";
			this.spnDespawn.Size = new global::System.Drawing.Size(72, 20);
			this.spnDespawn.TabIndex = 194;
			this.ttpSpawnInfo.SetToolTip(this.spnDespawn, "Similar to Duration but for longer timescales.");
			this.spnDespawn.ValueChanged += new global::System.EventHandler(this.numericUpDown6_ValueChanged);
			this.spnTODEnd.ContextMenu = this.highlightDetail;
			this.spnTODEnd.DecimalPlaces = 1;
			this.spnTODEnd.Location = new global::System.Drawing.Point(280, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown16 = this.spnTODEnd;
			int[] bits16 = new int[4];
			bits16[0] = 65535;
			decimal num16 = new decimal(bits16);
			numericUpDown16.Maximum = num16;
			this.spnTODEnd.Name = "spnTODEnd";
			this.spnTODEnd.Size = new global::System.Drawing.Size(72, 20);
			this.spnTODEnd.TabIndex = 195;
			this.ttpSpawnInfo.SetToolTip(this.spnTODEnd, "Ending hour before which spawning can occur.");
			this.spnDuration.ContextMenu = this.highlightDetail;
			this.spnDuration.DecimalPlaces = 1;
			this.spnDuration.Location = new global::System.Drawing.Point(280, 20);
			global::System.Windows.Forms.NumericUpDown numericUpDown17 = this.spnDuration;
			int[] bits17 = new int[4];
			bits17[0] = 65535000;
			decimal num17 = new decimal(bits17);
			numericUpDown17.Maximum = num17;
			this.spnDuration.Name = "spnDuration";
			this.spnDuration.Size = new global::System.Drawing.Size(72, 20);
			this.spnDuration.TabIndex = 198;
			this.ttpSpawnInfo.SetToolTip(this.spnDuration, "Maximum duration of a spawn after which it will be deleted.");
			this.spnProximitySnd.ContextMenu = this.highlightDetail;
			this.spnProximitySnd.Location = new global::System.Drawing.Point(280, 160);
			global::System.Windows.Forms.NumericUpDown numericUpDown18 = this.spnProximitySnd;
			int[] bits18 = new int[4];
			bits18[0] = 65635;
			decimal num18 = new decimal(bits18);
			numericUpDown18.Maximum = num18;
			this.spnProximitySnd.Name = "spnProximitySnd";
			this.spnProximitySnd.Size = new global::System.Drawing.Size(72, 20);
			this.spnProximitySnd.TabIndex = 203;
			this.ttpSpawnInfo.SetToolTip(this.spnProximitySnd, "Sound ID used when the spawner is triggered.");
			global::System.Windows.Forms.NumericUpDown numericUpDown19 = this.spnProximitySnd;
			int[] bits19 = new int[4];
			bits19[0] = 500;
			decimal num19 = new decimal(bits19);
			numericUpDown19.Value = num19;
			this.spnProximitySnd.ValueChanged += new global::System.EventHandler(this.numericUpDown10_ValueChanged);
			this.spnKillReset.ContextMenu = this.highlightDetail;
			this.spnKillReset.Location = new global::System.Drawing.Point(280, 140);
			global::System.Windows.Forms.NumericUpDown numericUpDown20 = this.spnKillReset;
			int[] bits20 = new int[4];
			bits20[0] = 65635;
			decimal num20 = new decimal(bits20);
			numericUpDown20.Maximum = num20;
			this.spnKillReset.Name = "spnKillReset";
			this.spnKillReset.Size = new global::System.Drawing.Size(72, 20);
			this.spnKillReset.TabIndex = 205;
			this.ttpSpawnInfo.SetToolTip(this.spnKillReset, "Number of spawner ticks until the Kill count of the spawner is reset.");
			global::System.Windows.Forms.NumericUpDown numericUpDown21 = this.spnKillReset;
			int[] bits21 = new int[4];
			bits21[0] = 1;
			decimal num21 = new decimal(bits21);
			numericUpDown21.Value = num21;
			this.tvwTemplates.AllowDrop = true;
			this.tvwTemplates.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tvwTemplates.ImageIndex = -1;
			this.tvwTemplates.Location = new global::System.Drawing.Point(8, 48);
			this.tvwTemplates.Name = "tvwTemplates";
			this.tvwTemplates.SelectedImageIndex = -1;
			this.tvwTemplates.Size = new global::System.Drawing.Size(288, 188);
			this.tvwTemplates.Sorted = true;
			this.tvwTemplates.TabIndex = 3;
			this.tvwTemplates.Visible = true;
			this.ttpSpawnInfo.SetToolTip(this.tvwTemplates, "List of currently defined templates.");
			this.chkTracking.Location = new global::System.Drawing.Point(8, 48);
			this.chkTracking.Name = "chkTracking";
			this.chkTracking.Size = new global::System.Drawing.Size(56, 16);
			this.chkTracking.TabIndex = 9;
			this.chkTracking.Text = "Track";
			this.ttpSpawnInfo.SetToolTip(this.chkTracking, "Track player movement on the map.");
			this.chkTracking.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.btnGo.Location = new global::System.Drawing.Point(8, 16);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new global::System.Drawing.Size(48, 24);
			this.btnGo.TabIndex = 8;
			this.btnGo.Text = "&Go";
			this.ttpSpawnInfo.SetToolTip(this.btnGo, "Move the player to the targeted location on the map.");
			this.btnGo.Click += new global::System.EventHandler(this.btnGo_Click);
			this.chkInContainer.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkInContainer.ContextMenu = this.highlightDetail;
			this.chkInContainer.Location = new global::System.Drawing.Point(8, 232);
			this.chkInContainer.Name = "chkInContainer";
			this.chkInContainer.Size = new global::System.Drawing.Size(104, 16);
			this.chkInContainer.TabIndex = 207;
			this.chkInContainer.Text = "InContainer:";
			this.ttpSpawnInfo.SetToolTip(this.chkInContainer, "Check if the spawner is in a container.");
			this.chkInContainer.CheckedChanged += new global::System.EventHandler(this.chkInContainer_CheckedChanged);
			this.spnTriggerProbability.DecimalPlaces = 1;
			this.spnTriggerProbability.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			this.spnTriggerProbability.Location = new global::System.Drawing.Point(120, 56);
			global::System.Windows.Forms.NumericUpDown numericUpDown22 = this.spnTriggerProbability;
			int[] bits22 = new int[4];
			bits22[0] = 1;
			decimal num22 = new decimal(bits22);
			numericUpDown22.Maximum = num22;
			this.spnTriggerProbability.Name = "spnTriggerProbability";
			this.spnTriggerProbability.Size = new global::System.Drawing.Size(56, 20);
			this.spnTriggerProbability.TabIndex = 200;
			this.ttpSpawnInfo.SetToolTip(this.spnTriggerProbability, "Maximum duration of a spawn after which it will be deleted.");
			global::System.Windows.Forms.NumericUpDown numericUpDown23 = this.spnTriggerProbability;
			int[] bits23 = new int[4];
			bits23[0] = 1;
			decimal num23 = new decimal(bits23);
			numericUpDown23.Value = num23;
			this.spnStackAmount.Location = new global::System.Drawing.Point(120, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown24 = this.spnStackAmount;
			int[] bits24 = new int[4];
			bits24[0] = 65535;
			decimal num24 = new decimal(bits24);
			numericUpDown24.Maximum = num24;
			this.spnStackAmount.Name = "spnStackAmount";
			this.spnStackAmount.Size = new global::System.Drawing.Size(56, 20);
			this.spnStackAmount.TabIndex = 202;
			this.ttpSpawnInfo.SetToolTip(this.spnStackAmount, "Maximum wandering range of the spawn from its spawned location.");
			global::System.Windows.Forms.NumericUpDown numericUpDown25 = this.spnStackAmount;
			int[] bits25 = new int[4];
			bits25[0] = 1;
			decimal num25 = new decimal(bits25);
			numericUpDown25.Value = num25;
			this.chkExternalTriggering.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkExternalTriggering.Location = new global::System.Drawing.Point(8, 80);
			this.chkExternalTriggering.Name = "chkExternalTriggering";
			this.chkExternalTriggering.Size = new global::System.Drawing.Size(128, 16);
			this.chkExternalTriggering.TabIndex = 222;
			this.chkExternalTriggering.Text = "ExternalTriggering:";
			this.ttpSpawnInfo.SetToolTip(this.chkExternalTriggering, "Check if the spawned object belongs to a group.");
			this.chkAllowNPC.BackColor = global::System.Drawing.SystemColors.Control;
			this.chkAllowNPC.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkAllowNPC.ContextMenu = this.highlightDetail;
			this.chkAllowNPC.Location = new global::System.Drawing.Point(8, 104);
			this.chkAllowNPC.Name = "chkAllowNPC";
			this.chkAllowNPC.Size = new global::System.Drawing.Size(96, 16);
			this.chkAllowNPC.TabIndex = 234;
			this.chkAllowNPC.Text = "AllowNPC:";
			this.ttpSpawnInfo.SetToolTip(this.chkAllowNPC, "Allow the spawner to be triggered by NPCs as well as players.");
			this.chkTickReset.BackColor = global::System.Drawing.SystemColors.Control;
			this.chkTickReset.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkTickReset.ContextMenu = this.highlightDetail;
			this.chkTickReset.Location = new global::System.Drawing.Point(184, 104);
			this.chkTickReset.Name = "chkTickReset";
			this.chkTickReset.Size = new global::System.Drawing.Size(120, 16);
			this.chkTickReset.TabIndex = 235;
			this.chkTickReset.Text = "DisableTickReset:";
			this.ttpSpawnInfo.SetToolTip(this.chkTickReset, "Matches XmlSpawner's Disable TickReset flag stored in the TickReset XML field.");
			this.spnContainerX.Enabled = false;
			this.spnContainerX.Location = new global::System.Drawing.Point(264, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown26 = this.spnContainerX;
			int[] bits26 = new int[4];
			bits26[0] = 65535;
			decimal num26 = new decimal(bits26);
			numericUpDown26.Maximum = num26;
			this.spnContainerX.Minimum = new decimal(new int[] { 65535, 0, 0, int.MinValue });
			this.spnContainerX.Name = "spnContainerX";
			this.spnContainerX.Size = new global::System.Drawing.Size(56, 20);
			this.spnContainerX.TabIndex = 233;
			this.ttpSpawnInfo.SetToolTip(this.spnContainerX, "Maximum wandering range of the spawn from its spawned location.");
			this.spnContainerY.Enabled = false;
			this.spnContainerY.Location = new global::System.Drawing.Point(264, 56);
			global::System.Windows.Forms.NumericUpDown numericUpDown27 = this.spnContainerY;
			int[] bits27 = new int[4];
			bits27[0] = 65535;
			decimal num27 = new decimal(bits27);
			numericUpDown27.Maximum = num27;
			this.spnContainerY.Minimum = new decimal(new int[] { 65535, 0, 0, int.MinValue });
			this.spnContainerY.Name = "spnContainerY";
			this.spnContainerY.Size = new global::System.Drawing.Size(56, 20);
			this.spnContainerY.TabIndex = 234;
			this.ttpSpawnInfo.SetToolTip(this.spnContainerY, "Maximum wandering range of the spawn from its spawned location.");
			this.spnContainerZ.Enabled = false;
			this.spnContainerZ.Location = new global::System.Drawing.Point(264, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown28 = this.spnContainerZ;
			int[] bits28 = new int[4];
			bits28[0] = 65535;
			decimal num28 = new decimal(bits28);
			numericUpDown28.Maximum = num28;
			this.spnContainerZ.Minimum = new decimal(new int[] { 65535, 0, 0, int.MinValue });
			this.spnContainerZ.Name = "spnContainerZ";
			this.spnContainerZ.Size = new global::System.Drawing.Size(56, 20);
			this.spnContainerZ.TabIndex = 235;
			this.ttpSpawnInfo.SetToolTip(this.spnContainerZ, "Maximum wandering range of the spawn from its spawned location.");
			this.chkLockSpawn.Location = new global::System.Drawing.Point(8, 80);
			this.chkLockSpawn.Name = "chkLockSpawn";
			this.chkLockSpawn.Size = new global::System.Drawing.Size(56, 16);
			this.chkLockSpawn.TabIndex = 10;
			this.chkLockSpawn.Text = "Loc&k";
			this.ttpSpawnInfo.SetToolTip(this.chkLockSpawn, "Lock spawner location during spawn region repositioning or resizing");
			this.chkDetails.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.chkDetails.Location = new global::System.Drawing.Point(77, 56);
			this.chkDetails.Name = "chkDetails";
			this.chkDetails.Size = new global::System.Drawing.Size(80, 16);
			this.chkDetails.TabIndex = 7;
			this.chkDetails.Text = "Details";
			this.ttpSpawnInfo.SetToolTip(this.chkDetails, "Display detailed spawn information");
			this.chkDetails.CheckedChanged += new global::System.EventHandler(this.chkDetails_CheckedChanged);
			this.chkSnapRegion.Location = new global::System.Drawing.Point(8, 96);
			this.chkSnapRegion.Name = "chkSnapRegion";
			this.chkSnapRegion.Size = new global::System.Drawing.Size(72, 16);
			this.chkSnapRegion.TabIndex = 11;
			this.chkSnapRegion.Text = "Snap XY";
			this.ttpSpawnInfo.SetToolTip(this.chkSnapRegion, "When selecting spawners, automatically move to the center of the spawning region instead of to the spawner location");
			this.treeRegionView.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.treeRegionView.CheckBoxes = true;
			this.treeRegionView.ImageIndex = -1;
			this.treeRegionView.Location = new global::System.Drawing.Point(8, 8);
			this.treeRegionView.Name = "treeRegionView";
			this.treeRegionView.SelectedImageIndex = -1;
			this.treeRegionView.Size = new global::System.Drawing.Size(156, 448);
			this.treeRegionView.TabIndex = 0;
			this.ttpSpawnInfo.SetToolTip(this.treeRegionView, "List of regions that have been defined in RunUO Data/Regions.xml.  Move to the region Go location when selected.");
			this.treeRegionView.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.treeRegionView_MouseUp);
			this.treeGoView.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.treeGoView.ImageIndex = -1;
			this.treeGoView.Location = new global::System.Drawing.Point(8, 8);
			this.treeGoView.Name = "treeGoView";
			this.treeGoView.SelectedImageIndex = -1;
			this.treeGoView.Size = new global::System.Drawing.Size(156, 448);
			this.treeGoView.TabIndex = 0;
			this.ttpSpawnInfo.SetToolTip(this.treeGoView, "List of locations taken from RunUO Data/Locations.  Move to the locations when selected.");
			this.treeGoView.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.treeGoView_MouseUp);
			this.checkSpawnFilter.Location = new global::System.Drawing.Point(8, 8);
			this.checkSpawnFilter.Name = "checkSpawnFilter";
			this.checkSpawnFilter.Size = new global::System.Drawing.Size(88, 16);
			this.checkSpawnFilter.TabIndex = 12;
			this.checkSpawnFilter.Text = "Apply Filter";
			this.ttpSpawnInfo.SetToolTip(this.checkSpawnFilter, "Filter the display of spawners based on the Display filter settings.");
			this.checkSpawnFilter.CheckedChanged += new global::System.EventHandler(this.checkSpawnFilter_CheckedChanged);
			this.button1.Location = new global::System.Drawing.Point(8, 35);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(160, 20);
			this.button1.TabIndex = 3;
			this.button1.Text = "Clear Selections";
			this.ttpSpawnInfo.SetToolTip(this.button1, "Clears current selections from the type list.");
			this.button1.Click += new global::System.EventHandler(this.btnSpawnPackClear);
			this.clbSpawnPack.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.clbSpawnPack.CheckOnClick = true;
			this.clbSpawnPack.HorizontalScrollbar = true;
			this.clbSpawnPack.IntegralHeight = false;
			this.clbSpawnPack.Location = new global::System.Drawing.Point(8, 96);
			this.clbSpawnPack.Name = "clbSpawnPack";
			this.clbSpawnPack.Size = new global::System.Drawing.Size(160, 168);
			this.clbSpawnPack.TabIndex = 4;
			this.clbSpawnPack.ThreeDCheckBoxes = true;
			this.ttpSpawnInfo.SetToolTip(this.clbSpawnPack, "List of spawnable objects in this spawn pack.  Right-click to delete.");
			this.clbSpawnPack.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.clbSpawnPack_MouseUp);
			this.btnUpdateFromSpawnPack.Enabled = false;
			this.btnUpdateFromSpawnPack.Location = new global::System.Drawing.Point(8, 55);
			this.btnUpdateFromSpawnPack.Name = "btnUpdateFromSpawnPack";
			this.btnUpdateFromSpawnPack.Size = new global::System.Drawing.Size(160, 20);
			this.btnUpdateFromSpawnPack.TabIndex = 15;
			this.btnUpdateFromSpawnPack.Text = "Add to Spawner";
			this.ttpSpawnInfo.SetToolTip(this.btnUpdateFromSpawnPack, "Updates the currently selected spawn with the selected types.");
			this.btnUpdateFromSpawnPack.Click += new global::System.EventHandler(this.btnUpdateFromSpawnPack_Click);
			this.btnAddToSpawnPack.Location = new global::System.Drawing.Point(8, 75);
			this.btnAddToSpawnPack.Name = "btnAddToSpawnPack";
			this.btnAddToSpawnPack.Size = new global::System.Drawing.Size(160, 20);
			this.btnAddToSpawnPack.TabIndex = 16;
			this.btnAddToSpawnPack.Text = "Add to Spawn Pack";
			this.ttpSpawnInfo.SetToolTip(this.btnAddToSpawnPack, "Adds the selected types to the Current Spawn Pack");
			this.btnAddToSpawnPack.Click += new global::System.EventHandler(this.btnAddToSpawnPack_Click);
			this.btnUpdateSpawnPacks.Location = new global::System.Drawing.Point(8, 75);
			this.btnUpdateSpawnPacks.Name = "btnUpdateSpawnPacks";
			this.btnUpdateSpawnPacks.Size = new global::System.Drawing.Size(160, 20);
			this.btnUpdateSpawnPacks.TabIndex = 17;
			this.btnUpdateSpawnPacks.Text = "Update Spawn Packs";
			this.ttpSpawnInfo.SetToolTip(this.btnUpdateSpawnPacks, "Updates the Current Spawn Pack into the All Spawn Packs list.");
			this.btnUpdateSpawnPacks.Click += new global::System.EventHandler(this.btnUpdateSpawnPacks_Click);
			this.tvwSpawnPacks.ImageIndex = -1;
			this.tvwSpawnPacks.Location = new global::System.Drawing.Point(8, 16);
			this.tvwSpawnPacks.Name = "tvwSpawnPacks";
			this.tvwSpawnPacks.SelectedImageIndex = -1;
			this.tvwSpawnPacks.Size = new global::System.Drawing.Size(160, 128);
			this.tvwSpawnPacks.TabIndex = 0;
			this.ttpSpawnInfo.SetToolTip(this.tvwSpawnPacks, "List of all available Spawn Packs.  Right-click to delete.");
			this.tvwSpawnPacks.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tvwSpawnPacks_MouseUp);
			this.tvwSpawnPacks.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.tvwSpawnPacks_AfterSelect);
			this.chkShade.Location = new global::System.Drawing.Point(8, 114);
			this.chkShade.Name = "chkShade";
			this.chkShade.Size = new global::System.Drawing.Size(80, 16);
			this.chkShade.TabIndex = 16;
			this.chkShade.Text = "Shade by";
			this.ttpSpawnInfo.SetToolTip(this.chkShade, "Display detailed spawn information");
			this.chkShade.CheckedChanged += new global::System.EventHandler(this.chkShade_CheckedChanged);
			this.cbxShade.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxShade.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxShade.Items.AddRange(new object[] { "Density", "Speed" });
			this.cbxShade.Location = new global::System.Drawing.Point(85, 112);
			this.cbxShade.Name = "cbxShade";
			this.cbxShade.Size = new global::System.Drawing.Size(77, 21);
			this.cbxShade.TabIndex = 17;
			this.ttpSpawnInfo.SetToolTip(this.cbxShade, "Changes the current map.");
			this.cbxShade.SelectedIndexChanged += new global::System.EventHandler(this.cbxShade_SelectedIndexChanged);
			this.label9.Location = new global::System.Drawing.Point(602, 16);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(24, 16);
			this.label9.TabIndex = 23;
			this.label9.Text = "Clr";
			this.ttpSpawnInfo.SetToolTip(this.label9, "ClearOnAdvance flag. When checked all entries in that subgroup will be cleared on sequential spawn advancement.");
			this.label8.Location = new global::System.Drawing.Point(566, 16);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(34, 16);
			this.label8.TabIndex = 22;
			this.label8.Text = "R/K";
			this.ttpSpawnInfo.SetToolTip(this.label8, "RestrictKills flag.  When checked kills of that entry will only be counted if they come from the currently active sequential subgroup.");
			this.label7.Location = new global::System.Drawing.Point(512, 16);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(56, 16);
			this.label7.TabIndex = 21;
			this.label7.Text = "MaxD (m)";
			this.ttpSpawnInfo.SetToolTip(this.label7, "Individual MaxDelay for the entry.  Note that spawns cannot occur faster than the main spawner min/maxdelay.");
			this.label6.Location = new global::System.Drawing.Point(464, 16);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(56, 16);
			this.label6.TabIndex = 20;
			this.label6.Text = "MinD (m)";
			this.ttpSpawnInfo.SetToolTip(this.label6, "Individual MinDelay for the entry. Note that spawns cannot occur faster than the main spawner min/maxdelay.");
			this.label5.Location = new global::System.Drawing.Point(400, 16);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(24, 16);
			this.label5.TabIndex = 17;
			this.label5.Text = "To";
			this.ttpSpawnInfo.SetToolTip(this.label5, "Subgroup that the sequential spawn index will be set to when the Reset time is reached without achieving the required number of Kills for the subgroup.");
			this.label4.Location = new global::System.Drawing.Point(432, 16);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(48, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "Kills";
			this.ttpSpawnInfo.SetToolTip(this.label4, "Minimum number of kills required for this subgroup in order to advance the sequential spawn index.  These kills must be completed within the number of spawner ticks given by the spawner KillReset property.");
			this.label3.Location = new global::System.Drawing.Point(352, 16);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(56, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Reset (m)";
			this.ttpSpawnInfo.SetToolTip(this.label3, "Maximum amount of time allowed to reach the number of kills required for this subgroup.  ");
			this.label2.Location = new global::System.Drawing.Point(320, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(32, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Sub";
			this.ttpSpawnInfo.SetToolTip(this.label2, "Subgroup assignment for the entry.");
			this.label1.Location = new global::System.Drawing.Point(216, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(32, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Max";
			this.ttpSpawnInfo.SetToolTip(this.label1, "Maximum number of spawns for the entry.");
			this.label28.Location = new global::System.Drawing.Point(192, 140);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(64, 16);
			this.label28.TabIndex = 204;
			this.label28.Text = "KillReset:";
			this.ttpSpawnInfo.SetToolTip(this.label28, "Number of spawner ticks until the Kill count of the spawner is reset.");
			this.label27.Location = new global::System.Drawing.Point(192, 160);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(104, 16);
			this.label27.TabIndex = 202;
			this.label27.Text = "ProximitySnd:";
			this.ttpSpawnInfo.SetToolTip(this.label27, "Sound ID used when the spawner is triggered.");
			this.label25.Location = new global::System.Drawing.Point(192, 20);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(80, 20);
			this.label25.TabIndex = 197;
			this.label25.Text = "Duration (m):";
			this.ttpSpawnInfo.SetToolTip(this.label25, "Maximum duration of a spawn after which it will be deleted.");
			this.label24.Location = new global::System.Drawing.Point(192, 120);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(80, 16);
			this.label24.TabIndex = 196;
			this.label24.Text = "TODEnd (h):";
			this.ttpSpawnInfo.SetToolTip(this.label24, "Ending hour before which spawning can occur.");
			this.label23.Location = new global::System.Drawing.Point(192, 40);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(80, 20);
			this.label23.TabIndex = 193;
			this.label23.Text = "Despawn (h):";
			this.ttpSpawnInfo.SetToolTip(this.label23, "Similar to Duration but for longer timescales.");
			this.label18.Location = new global::System.Drawing.Point(192, 80);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(88, 16);
			this.label18.TabIndex = 183;
			this.label18.Text = "MaxRefract (m):";
			this.ttpSpawnInfo.SetToolTip(this.label18, "Maximum delay after triggering when the spawner can be triggered again (in minutes).");
			this.label19.Location = new global::System.Drawing.Point(8, 160);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(88, 16);
			this.label19.TabIndex = 177;
			this.label19.Text = "ProximityRange:";
			this.ttpSpawnInfo.SetToolTip(this.label19, "Maximum range within which a player can trigger the spawner.  A value of -1 means that proximity triggering is disabled.");
			this.label20.Location = new global::System.Drawing.Point(192, 100);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(80, 16);
			this.label20.TabIndex = 185;
			this.label20.Text = "TODStart (h):";
			this.ttpSpawnInfo.SetToolTip(this.label20, "Starting hour after which spawning can occur.");
			this.label21.Location = new global::System.Drawing.Point(8, 140);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(80, 16);
			this.label21.TabIndex = 179;
			this.label21.Text = "SpawnRange:";
			this.ttpSpawnInfo.SetToolTip(this.label21, "Maximum spawning range.  A value of -1 means the range is specified by XY.");
			this.label22.Location = new global::System.Drawing.Point(192, 60);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(88, 16);
			this.label22.TabIndex = 181;
			this.label22.Text = "MinRefract (m):";
			this.ttpSpawnInfo.SetToolTip(this.label22, "Minimum delay after triggering when the spawner can be triggered again (in minutes).");
			this.lblMaxDelay.Location = new global::System.Drawing.Point(8, 100);
			this.lblMaxDelay.Name = "lblMaxDelay";
			this.lblMaxDelay.Size = new global::System.Drawing.Size(80, 16);
			this.lblMaxDelay.TabIndex = 7;
			this.lblMaxDelay.Text = "MaxDelay (m)";
			this.ttpSpawnInfo.SetToolTip(this.lblMaxDelay, "Maximum delay to respawn (in minutes).");
			this.lblHomeRange.Location = new global::System.Drawing.Point(8, 40);
			this.lblHomeRange.Name = "lblHomeRange";
			this.lblHomeRange.Size = new global::System.Drawing.Size(72, 20);
			this.lblHomeRange.TabIndex = 1;
			this.lblHomeRange.Text = "HomeRange:";
			this.ttpSpawnInfo.SetToolTip(this.lblHomeRange, "Maximum wandering range of the spawn from its spawned location.");
			this.lblTeam.Location = new global::System.Drawing.Point(8, 120);
			this.lblTeam.Name = "lblTeam";
			this.lblTeam.Size = new global::System.Drawing.Size(80, 16);
			this.lblTeam.TabIndex = 9;
			this.lblTeam.Text = "Team:";
			this.ttpSpawnInfo.SetToolTip(this.lblTeam, "Team that spawned object will belong to.");
			this.lblMaxCount.Location = new global::System.Drawing.Point(8, 60);
			this.lblMaxCount.Name = "lblMaxCount";
			this.lblMaxCount.Size = new global::System.Drawing.Size(64, 20);
			this.lblMaxCount.TabIndex = 3;
			this.lblMaxCount.Text = "MaxCount:";
			this.ttpSpawnInfo.SetToolTip(this.lblMaxCount, "Absolute maximum number of objects to be spawned by this spawner.");
			this.lblMinDelay.Location = new global::System.Drawing.Point(8, 80);
			this.lblMinDelay.Name = "lblMinDelay";
			this.lblMinDelay.Size = new global::System.Drawing.Size(72, 16);
			this.lblMinDelay.TabIndex = 5;
			this.lblMinDelay.Text = "MinDelay (m)";
			this.ttpSpawnInfo.SetToolTip(this.lblMinDelay, "Minimum delay to respawn (in minutes).");
			this.lblMinDelay.Click += new global::System.EventHandler(this.lblMinDelay_Click);
			this.btnSendSpawn.ContextMenu = this.unloadSpawners;
			this.btnSendSpawn.Location = new global::System.Drawing.Point(8, 56);
			this.btnSendSpawn.Name = "btnSendSpawn";
			this.btnSendSpawn.Size = new global::System.Drawing.Size(152, 23);
			this.btnSendSpawn.TabIndex = 206;
			this.btnSendSpawn.Text = "Send to Server";
			this.ttpSpawnInfo.SetToolTip(this.btnSendSpawn, "Send all spawners on the list to the Transfer Server.  Right-click to unload them from the server.");
			this.btnSendSpawn.Click += new global::System.EventHandler(this.btnSendSpawn_Click);
			this.unloadSpawners.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniUnloadSpawners, this.menuItem19 });
			this.unloadSpawners.Popup += new global::System.EventHandler(this.unloadSpawner_Popup);
			this.mniUnloadSpawners.Index = 0;
			this.mniUnloadSpawners.Text = "Unload Spawners from Server";
			this.mniUnloadSpawners.Click += new global::System.EventHandler(this.mniUnloadSpawners_Click);
			this.menuItem19.Index = 1;
			this.menuItem19.Text = "Cancel";
			this.label30.Location = new global::System.Drawing.Point(272, 16);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(40, 16);
			this.label30.TabIndex = 137;
			this.label30.Text = "Per";
			this.ttpSpawnInfo.SetToolTip(this.label30, "Number of spawns of this type created when the entry is spawned.");
			this.btnFilterSettings.Location = new global::System.Drawing.Point(88, 8);
			this.btnFilterSettings.Name = "btnFilterSettings";
			this.btnFilterSettings.Size = new global::System.Drawing.Size(72, 24);
			this.btnFilterSettings.TabIndex = 207;
			this.btnFilterSettings.Text = "Settings";
			this.ttpSpawnInfo.SetToolTip(this.btnFilterSettings, "Open the Display filter settings window.");
			this.btnFilterSettings.Click += new global::System.EventHandler(this.btnFilterSettings_Click);
			this.pnlControls.Controls.Add(this.lblTrkMax);
			this.pnlControls.Controls.Add(this.lblTrkMin);
			this.pnlControls.Controls.Add(this.trkZoom);
			this.pnlControls.Controls.Add(this.tabControl3);
			this.pnlControls.Controls.Add(this.tabControl2);
			this.pnlControls.Controls.Add(this.progressBar1);
			this.pnlControls.Controls.Add(this.lblTransferStatus);
			this.pnlControls.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnlControls.Location = new global::System.Drawing.Point(0, 0);
			this.pnlControls.Name = "pnlControls";
			this.pnlControls.Size = new global::System.Drawing.Size(220, 884);
			this.pnlControls.TabIndex = 0;
			this.lblTrkMax.Location = new global::System.Drawing.Point(180, 184);
			this.lblTrkMax.Name = "lblTrkMax";
			this.lblTrkMax.Size = new global::System.Drawing.Size(29, 16);
			this.lblTrkMax.TabIndex = 15;
			this.lblTrkMax.Text = "max";
			this.lblTrkMin.Location = new global::System.Drawing.Point(12, 184);
			this.lblTrkMin.Name = "lblTrkMin";
			this.lblTrkMin.Size = new global::System.Drawing.Size(29, 16);
			this.lblTrkMin.TabIndex = 14;
			this.lblTrkMin.Text = "min";
			this.tabControl3.Controls.Add(this.tabMapSettings);
			this.tabControl3.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new global::System.Drawing.Size(216, 184);
			this.tabControl3.TabIndex = 7;
			this.tabMapSettings.Controls.Add(this.grpMapControl);
			this.tabMapSettings.Location = new global::System.Drawing.Point(4, 22);
			this.tabMapSettings.Name = "tabMapSettings";
			this.tabMapSettings.Size = new global::System.Drawing.Size(208, 158);
			this.tabMapSettings.TabIndex = 0;
			this.tabMapSettings.Text = "Map Settings";
			this.grpMapControl.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.grpMapControl.Controls.Add(this.cbxMap);
			this.grpMapControl.Controls.Add(this.cbxShade);
			this.grpMapControl.Controls.Add(this.chkShade);
			this.grpMapControl.Controls.Add(this.chkSnapRegion);
			this.grpMapControl.Controls.Add(this.chkLockSpawn);
			this.grpMapControl.Controls.Add(this.chkTracking);
			this.grpMapControl.Controls.Add(this.btnGo);
			this.grpMapControl.Controls.Add(this.chkDetails);
			this.grpMapControl.Controls.Add(this.chkShowSpawns);
			this.grpMapControl.Controls.Add(this.chkShowMapTip);
			this.grpMapControl.Controls.Add(this.chkDrawStatics);
			this.grpMapControl.Controls.Add(this.chkSyncUO);
			this.grpMapControl.Location = new global::System.Drawing.Point(0, 0);
			this.grpMapControl.Name = "grpMapControl";
			this.grpMapControl.Size = new global::System.Drawing.Size(208, 158);
			this.grpMapControl.TabIndex = 0;
			this.grpMapControl.TabStop = false;
			this.tabControl2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Location = new global::System.Drawing.Point(0, 212);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new global::System.Drawing.Size(220, 672);
			this.tabControl2.TabIndex = 6;
			this.tabPage3.Controls.Add(this.grpSpawnList);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new global::System.Drawing.Size(212, 646);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Spawners";
			this.grpSpawnList.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.grpSpawnList.Controls.Add(this.btnFilterSettings);
			this.grpSpawnList.Controls.Add(this.tvwSpawnPoints);
			this.grpSpawnList.Controls.Add(this.btnLoadSpawn);
			this.grpSpawnList.Controls.Add(this.btnMergeSpawn);
			this.grpSpawnList.Controls.Add(this.btnSaveSpawn);
			this.grpSpawnList.Controls.Add(this.lblTotalSpawn);
			this.grpSpawnList.Controls.Add(this.checkSpawnFilter);
			this.grpSpawnList.Controls.Add(this.btnSendSpawn);
			this.grpSpawnList.Location = new global::System.Drawing.Point(0, 0);
			this.grpSpawnList.Name = "grpSpawnList";
			this.grpSpawnList.Size = new global::System.Drawing.Size(212, 648);
			this.grpSpawnList.TabIndex = 1;
			this.grpSpawnList.TabStop = false;
			this.lblTotalSpawn.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.lblTotalSpawn.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalSpawn.Location = new global::System.Drawing.Point(8, 624);
			this.lblTotalSpawn.Name = "lblTotalSpawn";
			this.lblTotalSpawn.Size = new global::System.Drawing.Size(196, 16);
			this.lblTotalSpawn.TabIndex = 4;
			this.tabPage4.Controls.Add(this.treeRegionView);
			this.tabPage4.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new global::System.Drawing.Size(212, 646);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Regions";
			this.tabPage4.ToolTipText = "Currently defined region locations.  Select one to automatically move to its Go location.";
			this.tabPage5.Controls.Add(this.treeGoView);
			this.tabPage5.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new global::System.Drawing.Size(212, 646);
			this.tabPage5.TabIndex = 2;
			this.tabPage5.Text = "Go";
			this.progressBar1.Location = new global::System.Drawing.Point(8, 184);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(152, 16);
			this.progressBar1.TabIndex = 16;
			this.progressBar1.Visible = false;
			this.lblTransferStatus.Location = new global::System.Drawing.Point(8, 168);
			this.lblTransferStatus.Name = "lblTransferStatus";
			this.lblTransferStatus.Size = new global::System.Drawing.Size(152, 16);
			this.lblTransferStatus.TabIndex = 238;
			this.lblTransferStatus.Text = "Status";
			this.lblTransferStatus.Visible = false;
			this.groupTemplateList.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.groupTemplateList.Controls.Add(this.btnSaveTemplate);
			this.btnSaveTemplate.Click += new global::System.EventHandler(this.btnSaveTemplate_Click);
			this.groupTemplateList.Controls.Add(this.btnMergeTemplate);
			this.btnMergeTemplate.Click += new global::System.EventHandler(this.btnMergeTemplate_Click);
			this.groupTemplateList.Controls.Add(this.btnLoadTemplate);
			this.btnLoadTemplate.Click += new global::System.EventHandler(this.btnLoadTemplate_Click);
			this.groupTemplateList.Controls.Add(this.tvwTemplates);
			this.groupTemplateList.Controls.Add(this.label29);
			this.groupTemplateList.Enabled = true;
			this.btnMergeTemplate.Enabled = false;
			this.groupTemplateList.Location = new global::System.Drawing.Point(8, 0);
			this.groupTemplateList.MinimumSize = new global::System.Drawing.Size(200, 220);
			this.groupTemplateList.Name = "groupTemplateList";
			this.groupTemplateList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupTemplateList.Size = new global::System.Drawing.Size(348, 308);
			this.groupTemplateList.TabIndex = 5;
			this.groupTemplateList.TabStop = false;
			this.groupTemplateList.Text = "Spawn Templates";
			this.btnSaveTemplate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSaveTemplate.Location = new global::System.Drawing.Point(284, 16);
			this.btnSaveTemplate.Name = "btnSaveTemplate";
			this.btnSaveTemplate.Size = new global::System.Drawing.Size(56, 24);
			this.btnSaveTemplate.TabIndex = 7;
			this.btnSaveTemplate.Text = "Save";
			this.btnMergeTemplate.Location = new global::System.Drawing.Point(120, 16);
			this.btnMergeTemplate.Name = "btnMergeTemplate";
			this.btnMergeTemplate.Size = new global::System.Drawing.Size(56, 24);
			this.btnMergeTemplate.TabIndex = 6;
			this.btnMergeTemplate.Text = "Copy To";
			this.btnLoadTemplate.Location = new global::System.Drawing.Point(8, 16);
			this.btnLoadTemplate.Name = "btnLoadTemplate";
			this.btnLoadTemplate.Size = new global::System.Drawing.Size(56, 24);
			this.btnLoadTemplate.TabIndex = 5;
			this.btnLoadTemplate.Text = "Load";
			this.label29.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label29.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.label29.Location = new global::System.Drawing.Point(8, 284);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(288, 16);
			this.label29.TabIndex = 4;
			this.grpSpawnTypes.Controls.Add(this.btnAddToSpawnPack);
			this.grpSpawnTypes.Controls.Add(this.radShowMobilesOnly);
			this.grpSpawnTypes.Controls.Add(this.radShowItemsOnly);
			this.grpSpawnTypes.Controls.Add(this.radShowAll);
			this.grpSpawnTypes.Controls.Add(this.btnResetTypes);
			this.grpSpawnTypes.Controls.Add(this.clbRunUOTypes);
			this.grpSpawnTypes.Controls.Add(this.lblTotalTypesLoaded);
			this.grpSpawnTypes.Controls.Add(this.btnUpdateSpawn);
			this.grpSpawnTypes.Location = new global::System.Drawing.Point(0, 0);
			this.grpSpawnTypes.Name = "grpSpawnTypes";
			this.grpSpawnTypes.Size = new global::System.Drawing.Size(176, 440);
			this.grpSpawnTypes.TabIndex = 1;
			this.grpSpawnTypes.TabStop = false;
			this.grpSpawnTypes.Text = "All Spawn Types";
			this.lblTotalTypesLoaded.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.lblTotalTypesLoaded.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotalTypesLoaded.Location = new global::System.Drawing.Point(8, 416);
			this.lblTotalTypesLoaded.Name = "lblTotalTypesLoaded";
			this.lblTotalTypesLoaded.Size = new global::System.Drawing.Size(160, 16);
			this.lblTotalTypesLoaded.TabIndex = 5;
			this.mncSpawns.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem3, this.mniDeleteSpawn, this.mniDeleteAllSpawns });
			this.mncSpawns.Popup += new global::System.EventHandler(this.mncSpawns_Popup);
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "-";
			this.mniDeleteSpawn.Index = 1;
			this.mniDeleteSpawn.Text = "&Delete";
			this.mniDeleteSpawn.Click += new global::System.EventHandler(this.mniDeleteSpawn_Click);
			this.mniDeleteAllSpawns.Index = 2;
			this.mniDeleteAllSpawns.Text = "Delete &All";
			this.mniDeleteAllSpawns.Click += new global::System.EventHandler(this.mniDeleteAllSpawns_Click);
			this.ofdLoadFile.DefaultExt = "xml";
			this.ofdLoadFile.Filter = "Spawn Files (*.xml)|*.xml|All Files (*.*)|*.*";
			this.ofdLoadFile.Title = "Load Spawn File";
			this.sfdSaveFile.DefaultExt = "xml";
			this.sfdSaveFile.FileName = "Spawns";
			this.sfdSaveFile.Filter = "Spawn Files (*.xml)|*.xml|All Files (*.*)|*.*";
			this.sfdSaveFile.Title = "Save Spawn File";
			this.stbMain.Location = new global::System.Drawing.Point(0, 682);
			this.stbMain.Name = "stbMain";
			this.stbMain.Size = new global::System.Drawing.Size(1016, 16);
			this.stbMain.TabIndex = 3;
			this.stbMain.Text = "Spawn Editor";
			this.grpSpawnEntries.Controls.Add(this.entryPer8);
			this.grpSpawnEntries.Controls.Add(this.entryPer7);
			this.grpSpawnEntries.Controls.Add(this.entryPer6);
			this.grpSpawnEntries.Controls.Add(this.entryPer5);
			this.grpSpawnEntries.Controls.Add(this.entryPer4);
			this.grpSpawnEntries.Controls.Add(this.entryPer3);
			this.grpSpawnEntries.Controls.Add(this.entryPer2);
			this.grpSpawnEntries.Controls.Add(this.entryPer1);
			this.grpSpawnEntries.Controls.Add(this.label30);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD8);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD7);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD6);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD5);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD4);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD3);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD2);
			this.grpSpawnEntries.Controls.Add(this.entryMaxD1);
			this.grpSpawnEntries.Controls.Add(this.entryMinD8);
			this.grpSpawnEntries.Controls.Add(this.entryMinD7);
			this.grpSpawnEntries.Controls.Add(this.entryMinD6);
			this.grpSpawnEntries.Controls.Add(this.entryMinD5);
			this.grpSpawnEntries.Controls.Add(this.entryMinD4);
			this.grpSpawnEntries.Controls.Add(this.entryMinD3);
			this.grpSpawnEntries.Controls.Add(this.entryMinD2);
			this.grpSpawnEntries.Controls.Add(this.entryMinD1);
			this.grpSpawnEntries.Controls.Add(this.entryKills8);
			this.grpSpawnEntries.Controls.Add(this.entryKills7);
			this.grpSpawnEntries.Controls.Add(this.entryKills6);
			this.grpSpawnEntries.Controls.Add(this.entryKills5);
			this.grpSpawnEntries.Controls.Add(this.entryKills4);
			this.grpSpawnEntries.Controls.Add(this.entryKills3);
			this.grpSpawnEntries.Controls.Add(this.entryKills2);
			this.grpSpawnEntries.Controls.Add(this.entryKills1);
			this.grpSpawnEntries.Controls.Add(this.entryReset8);
			this.grpSpawnEntries.Controls.Add(this.entryReset7);
			this.grpSpawnEntries.Controls.Add(this.entryReset6);
			this.grpSpawnEntries.Controls.Add(this.entryReset5);
			this.grpSpawnEntries.Controls.Add(this.entryReset4);
			this.grpSpawnEntries.Controls.Add(this.entryReset3);
			this.grpSpawnEntries.Controls.Add(this.entryReset2);
			this.grpSpawnEntries.Controls.Add(this.entryReset1);
			this.grpSpawnEntries.Controls.Add(this.entryTo8);
			this.grpSpawnEntries.Controls.Add(this.entrySub8);
			this.grpSpawnEntries.Controls.Add(this.chkRK8);
			this.grpSpawnEntries.Controls.Add(this.entryMax8);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit8);
			this.grpSpawnEntries.Controls.Add(this.entryText8);
			this.grpSpawnEntries.Controls.Add(this.chkClr8);
			this.grpSpawnEntries.Controls.Add(this.entryTo7);
			this.grpSpawnEntries.Controls.Add(this.entrySub7);
			this.grpSpawnEntries.Controls.Add(this.chkRK7);
			this.grpSpawnEntries.Controls.Add(this.entryMax7);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit7);
			this.grpSpawnEntries.Controls.Add(this.entryText7);
			this.grpSpawnEntries.Controls.Add(this.chkClr7);
			this.grpSpawnEntries.Controls.Add(this.entryTo6);
			this.grpSpawnEntries.Controls.Add(this.entrySub6);
			this.grpSpawnEntries.Controls.Add(this.chkRK6);
			this.grpSpawnEntries.Controls.Add(this.entryMax6);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit6);
			this.grpSpawnEntries.Controls.Add(this.entryText6);
			this.grpSpawnEntries.Controls.Add(this.chkClr6);
			this.grpSpawnEntries.Controls.Add(this.entryTo5);
			this.grpSpawnEntries.Controls.Add(this.entrySub5);
			this.grpSpawnEntries.Controls.Add(this.chkRK5);
			this.grpSpawnEntries.Controls.Add(this.entryMax5);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit5);
			this.grpSpawnEntries.Controls.Add(this.entryText5);
			this.grpSpawnEntries.Controls.Add(this.chkClr5);
			this.grpSpawnEntries.Controls.Add(this.entryTo4);
			this.grpSpawnEntries.Controls.Add(this.entrySub4);
			this.grpSpawnEntries.Controls.Add(this.chkRK4);
			this.grpSpawnEntries.Controls.Add(this.entryMax4);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit4);
			this.grpSpawnEntries.Controls.Add(this.entryText4);
			this.grpSpawnEntries.Controls.Add(this.chkClr4);
			this.grpSpawnEntries.Controls.Add(this.entryTo3);
			this.grpSpawnEntries.Controls.Add(this.entrySub3);
			this.grpSpawnEntries.Controls.Add(this.chkRK3);
			this.grpSpawnEntries.Controls.Add(this.entryMax3);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit3);
			this.grpSpawnEntries.Controls.Add(this.entryText3);
			this.grpSpawnEntries.Controls.Add(this.chkClr3);
			this.grpSpawnEntries.Controls.Add(this.entryTo2);
			this.grpSpawnEntries.Controls.Add(this.entrySub2);
			this.grpSpawnEntries.Controls.Add(this.chkRK2);
			this.grpSpawnEntries.Controls.Add(this.entryMax2);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit2);
			this.grpSpawnEntries.Controls.Add(this.entryText2);
			this.grpSpawnEntries.Controls.Add(this.chkClr2);
			this.grpSpawnEntries.Controls.Add(this.label9);
			this.grpSpawnEntries.Controls.Add(this.label8);
			this.grpSpawnEntries.Controls.Add(this.label7);
			this.grpSpawnEntries.Controls.Add(this.label6);
			this.grpSpawnEntries.Controls.Add(this.label5);
			this.grpSpawnEntries.Controls.Add(this.entryTo1);
			this.grpSpawnEntries.Controls.Add(this.vScrollBar1);
			this.grpSpawnEntries.Controls.Add(this.entrySub1);
			this.grpSpawnEntries.Controls.Add(this.label4);
			this.grpSpawnEntries.Controls.Add(this.label3);
			this.grpSpawnEntries.Controls.Add(this.chkRK1);
			this.grpSpawnEntries.Controls.Add(this.label2);
			this.grpSpawnEntries.Controls.Add(this.label1);
			this.grpSpawnEntries.Controls.Add(this.entryMax1);
			this.grpSpawnEntries.Controls.Add(this.btnEntryEdit1);
			this.grpSpawnEntries.Controls.Add(this.entryText1);
			this.grpSpawnEntries.Controls.Add(this.chkClr1);
			this.grpSpawnEntries.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.grpSpawnEntries.Location = new global::System.Drawing.Point(348, 0);
			this.grpSpawnEntries.MinimumSize = new global::System.Drawing.Size(640, 220);
			this.grpSpawnEntries.Name = "grpSpawnEntries";
			this.grpSpawnEntries.Size = new global::System.Drawing.Size(172, 308);
			this.grpSpawnEntries.TabIndex = 3;
			this.grpSpawnEntries.TabStop = false;
			this.grpSpawnEntries.Text = "Spawn Entries";
			this.grpSpawnEntries.Enter += new global::System.EventHandler(this.grpSpawnEntries_Enter);
			this.grpSpawnEntries.Leave += new global::System.EventHandler(this.grpSpawnEntries_Leave);
			this.entryPer8.Location = new global::System.Drawing.Point(272, 200);
			global::System.Windows.Forms.NumericUpDown numericUpDown29 = this.entryPer8;
			int[] bits29 = new int[4];
			bits29[0] = 65535;
			decimal num29 = new decimal(bits29);
			numericUpDown29.Maximum = num29;
			this.entryPer8.Name = "entryPer8";
			this.entryPer8.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer8.TabIndex = 145;
			this.entryPer7.Location = new global::System.Drawing.Point(272, 176);
			global::System.Windows.Forms.NumericUpDown numericUpDown30 = this.entryPer7;
			int[] bits30 = new int[4];
			bits30[0] = 65535;
			decimal num30 = new decimal(bits30);
			numericUpDown30.Maximum = num30;
			this.entryPer7.Name = "entryPer7";
			this.entryPer7.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer7.TabIndex = 144;
			this.entryPer6.Location = new global::System.Drawing.Point(272, 152);
			global::System.Windows.Forms.NumericUpDown numericUpDown31 = this.entryPer6;
			int[] bits31 = new int[4];
			bits31[0] = 65535;
			decimal num31 = new decimal(bits31);
			numericUpDown31.Maximum = num31;
			this.entryPer6.Name = "entryPer6";
			this.entryPer6.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer6.TabIndex = 143;
			this.entryPer5.Location = new global::System.Drawing.Point(272, 128);
			global::System.Windows.Forms.NumericUpDown numericUpDown32 = this.entryPer5;
			int[] bits32 = new int[4];
			bits32[0] = 65535;
			decimal num32 = new decimal(bits32);
			numericUpDown32.Maximum = num32;
			this.entryPer5.Name = "entryPer5";
			this.entryPer5.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer5.TabIndex = 142;
			this.entryPer4.Location = new global::System.Drawing.Point(272, 104);
			global::System.Windows.Forms.NumericUpDown numericUpDown33 = this.entryPer4;
			int[] bits33 = new int[4];
			bits33[0] = 65535;
			decimal num33 = new decimal(bits33);
			numericUpDown33.Maximum = num33;
			this.entryPer4.Name = "entryPer4";
			this.entryPer4.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer4.TabIndex = 141;
			this.entryPer3.Location = new global::System.Drawing.Point(272, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown34 = this.entryPer3;
			int[] bits34 = new int[4];
			bits34[0] = 65535;
			decimal num34 = new decimal(bits34);
			numericUpDown34.Maximum = num34;
			this.entryPer3.Name = "entryPer3";
			this.entryPer3.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer3.TabIndex = 140;
			this.entryPer2.Location = new global::System.Drawing.Point(272, 56);
			global::System.Windows.Forms.NumericUpDown numericUpDown35 = this.entryPer2;
			int[] bits35 = new int[4];
			bits35[0] = 65535;
			decimal num35 = new decimal(bits35);
			numericUpDown35.Maximum = num35;
			this.entryPer2.Name = "entryPer2";
			this.entryPer2.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer2.TabIndex = 139;
			this.entryPer1.Location = new global::System.Drawing.Point(272, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown36 = this.entryPer1;
			int[] bits36 = new int[4];
			bits36[0] = 65535;
			decimal num36 = new decimal(bits36);
			numericUpDown36.Maximum = num36;
			this.entryPer1.Name = "entryPer1";
			this.entryPer1.Size = new global::System.Drawing.Size(48, 20);
			this.entryPer1.TabIndex = 138;
			this.entryMaxD8.Location = new global::System.Drawing.Point(512, 200);
			this.entryMaxD8.Name = "entryMaxD8";
			this.entryMaxD8.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD8.TabIndex = 136;
			this.entryMaxD8.Text = "";
			this.entryMaxD7.Location = new global::System.Drawing.Point(512, 176);
			this.entryMaxD7.Name = "entryMaxD7";
			this.entryMaxD7.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD7.TabIndex = 135;
			this.entryMaxD7.Text = "";
			this.entryMaxD6.Location = new global::System.Drawing.Point(512, 152);
			this.entryMaxD6.Name = "entryMaxD6";
			this.entryMaxD6.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD6.TabIndex = 134;
			this.entryMaxD6.Text = "";
			this.entryMaxD5.Location = new global::System.Drawing.Point(512, 128);
			this.entryMaxD5.Name = "entryMaxD5";
			this.entryMaxD5.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD5.TabIndex = 133;
			this.entryMaxD5.Text = "";
			this.entryMaxD4.Location = new global::System.Drawing.Point(512, 104);
			this.entryMaxD4.Name = "entryMaxD4";
			this.entryMaxD4.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD4.TabIndex = 132;
			this.entryMaxD4.Text = "";
			this.entryMaxD3.Location = new global::System.Drawing.Point(512, 80);
			this.entryMaxD3.Name = "entryMaxD3";
			this.entryMaxD3.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD3.TabIndex = 131;
			this.entryMaxD3.Text = "";
			this.entryMaxD2.Location = new global::System.Drawing.Point(512, 56);
			this.entryMaxD2.Name = "entryMaxD2";
			this.entryMaxD2.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD2.TabIndex = 130;
			this.entryMaxD2.Text = "";
			this.entryMaxD1.Location = new global::System.Drawing.Point(512, 32);
			this.entryMaxD1.Name = "entryMaxD1";
			this.entryMaxD1.Size = new global::System.Drawing.Size(48, 20);
			this.entryMaxD1.TabIndex = 129;
			this.entryMaxD1.Text = "";
			this.entryMinD8.Location = new global::System.Drawing.Point(464, 200);
			this.entryMinD8.Name = "entryMinD8";
			this.entryMinD8.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD8.TabIndex = 128;
			this.entryMinD8.Text = "";
			this.entryMinD7.Location = new global::System.Drawing.Point(464, 176);
			this.entryMinD7.Name = "entryMinD7";
			this.entryMinD7.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD7.TabIndex = 127;
			this.entryMinD7.Text = "";
			this.entryMinD6.Location = new global::System.Drawing.Point(464, 152);
			this.entryMinD6.Name = "entryMinD6";
			this.entryMinD6.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD6.TabIndex = 126;
			this.entryMinD6.Text = "";
			this.entryMinD5.Location = new global::System.Drawing.Point(464, 128);
			this.entryMinD5.Name = "entryMinD5";
			this.entryMinD5.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD5.TabIndex = 125;
			this.entryMinD5.Text = "";
			this.entryMinD4.Location = new global::System.Drawing.Point(464, 104);
			this.entryMinD4.Name = "entryMinD4";
			this.entryMinD4.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD4.TabIndex = 124;
			this.entryMinD4.Text = "";
			this.entryMinD3.Location = new global::System.Drawing.Point(464, 80);
			this.entryMinD3.Name = "entryMinD3";
			this.entryMinD3.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD3.TabIndex = 123;
			this.entryMinD3.Text = "";
			this.entryMinD2.Location = new global::System.Drawing.Point(464, 56);
			this.entryMinD2.Name = "entryMinD2";
			this.entryMinD2.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD2.TabIndex = 122;
			this.entryMinD2.Text = "";
			this.entryMinD1.Location = new global::System.Drawing.Point(464, 32);
			this.entryMinD1.Name = "entryMinD1";
			this.entryMinD1.Size = new global::System.Drawing.Size(48, 20);
			this.entryMinD1.TabIndex = 121;
			this.entryMinD1.Text = "";
			this.entryKills8.Location = new global::System.Drawing.Point(432, 200);
			this.entryKills8.Name = "entryKills8";
			this.entryKills8.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills8.TabIndex = 120;
			this.entryKills8.Text = "";
			this.entryKills7.Location = new global::System.Drawing.Point(432, 176);
			this.entryKills7.Name = "entryKills7";
			this.entryKills7.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills7.TabIndex = 119;
			this.entryKills7.Text = "";
			this.entryKills6.Location = new global::System.Drawing.Point(432, 152);
			this.entryKills6.Name = "entryKills6";
			this.entryKills6.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills6.TabIndex = 118;
			this.entryKills6.Text = "";
			this.entryKills5.Location = new global::System.Drawing.Point(432, 128);
			this.entryKills5.Name = "entryKills5";
			this.entryKills5.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills5.TabIndex = 117;
			this.entryKills5.Text = "";
			this.entryKills4.Location = new global::System.Drawing.Point(432, 104);
			this.entryKills4.Name = "entryKills4";
			this.entryKills4.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills4.TabIndex = 116;
			this.entryKills4.Text = "";
			this.entryKills3.Location = new global::System.Drawing.Point(432, 80);
			this.entryKills3.Name = "entryKills3";
			this.entryKills3.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills3.TabIndex = 115;
			this.entryKills3.Text = "";
			this.entryKills2.Location = new global::System.Drawing.Point(432, 56);
			this.entryKills2.Name = "entryKills2";
			this.entryKills2.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills2.TabIndex = 114;
			this.entryKills2.Text = "";
			this.entryKills1.Location = new global::System.Drawing.Point(432, 32);
			this.entryKills1.Name = "entryKills1";
			this.entryKills1.Size = new global::System.Drawing.Size(32, 20);
			this.entryKills1.TabIndex = 113;
			this.entryKills1.Text = "";
			this.entryReset8.Location = new global::System.Drawing.Point(352, 200);
			this.entryReset8.Name = "entryReset8";
			this.entryReset8.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset8.TabIndex = 112;
			this.entryReset8.Text = "";
			this.entryReset7.Location = new global::System.Drawing.Point(352, 176);
			this.entryReset7.Name = "entryReset7";
			this.entryReset7.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset7.TabIndex = 111;
			this.entryReset7.Text = "";
			this.entryReset6.Location = new global::System.Drawing.Point(352, 152);
			this.entryReset6.Name = "entryReset6";
			this.entryReset6.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset6.TabIndex = 110;
			this.entryReset6.Text = "";
			this.entryReset5.Location = new global::System.Drawing.Point(352, 128);
			this.entryReset5.Name = "entryReset5";
			this.entryReset5.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset5.TabIndex = 109;
			this.entryReset5.Text = "";
			this.entryReset4.Location = new global::System.Drawing.Point(352, 104);
			this.entryReset4.Name = "entryReset4";
			this.entryReset4.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset4.TabIndex = 108;
			this.entryReset4.Text = "";
			this.entryReset3.Location = new global::System.Drawing.Point(352, 80);
			this.entryReset3.Name = "entryReset3";
			this.entryReset3.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset3.TabIndex = 107;
			this.entryReset3.Text = "";
			this.entryReset2.Location = new global::System.Drawing.Point(352, 56);
			this.entryReset2.Name = "entryReset2";
			this.entryReset2.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset2.TabIndex = 106;
			this.entryReset2.Text = "";
			this.entryReset1.Location = new global::System.Drawing.Point(352, 32);
			this.entryReset1.Name = "entryReset1";
			this.entryReset1.Size = new global::System.Drawing.Size(48, 20);
			this.entryReset1.TabIndex = 105;
			this.entryReset1.Text = "";
			this.entryTo8.Location = new global::System.Drawing.Point(400, 200);
			this.entryTo8.Name = "entryTo8";
			this.entryTo8.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo8.TabIndex = 103;
			this.entryTo8.Text = "";
			this.entrySub8.Location = new global::System.Drawing.Point(320, 200);
			this.entrySub8.Name = "entrySub8";
			this.entrySub8.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub8.TabIndex = 102;
			this.entrySub8.Text = "";
			this.chkRK8.Location = new global::System.Drawing.Point(568, 204);
			this.chkRK8.Name = "chkRK8";
			this.chkRK8.Size = new global::System.Drawing.Size(16, 16);
			this.chkRK8.TabIndex = 99;
			this.chkRK8.Text = "";
			this.entryMax8.Location = new global::System.Drawing.Point(216, 200);
			global::System.Windows.Forms.NumericUpDown numericUpDown37 = this.entryMax8;
			int[] bits37 = new int[4];
			bits37[0] = 65535;
			decimal num37 = new decimal(bits37);
			numericUpDown37.Maximum = num37;
			this.entryMax8.Name = "entryMax8";
			this.entryMax8.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax8.TabIndex = 98;
			this.entryMax8.Click += new global::System.EventHandler(this.entryMax8_Click);
			this.entryMax8.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax8_KeyUp);
			this.entryMax8.ValueChanged += new global::System.EventHandler(this.entryMax8_ValueChanged);
			this.entryMax8.Leave += new global::System.EventHandler(this.entryMax8_Leave);
			this.btnEntryEdit8.Location = new global::System.Drawing.Point(192, 200);
			this.btnEntryEdit8.Name = "btnEntryEdit8";
			this.btnEntryEdit8.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit8.TabIndex = 97;
			this.btnEntryEdit8.Text = "?";
			this.btnEntryEdit8.Click += new global::System.EventHandler(this.btnEntryEdit8_Click);
			this.entryText8.ContextMenu = this.deleteEntry;
			this.entryText8.Location = new global::System.Drawing.Point(8, 200);
			this.entryText8.Name = "entryText8";
			this.entryText8.Size = new global::System.Drawing.Size(184, 20);
			this.entryText8.TabIndex = 95;
			this.entryText8.Text = "";
			this.entryText8.TextChanged += new global::System.EventHandler(this.entryText8_TextChanged);
			this.entryText8.MouseLeave += new global::System.EventHandler(this.entryText8_MouseLeave);
			this.entryText8.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText8_KeyUp);
			this.deleteEntry.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem1, this.menuItem2, this.menuItem15 });
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Delete Entry";
			this.menuItem1.Click += new global::System.EventHandler(this.menuItem1_Click);
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Delete All Entries";
			this.menuItem2.Click += new global::System.EventHandler(this.menuItem2_Click);
			this.menuItem15.Index = 2;
			this.menuItem15.Text = "Add to SpawnPack";
			this.menuItem15.Click += new global::System.EventHandler(this.menuItem15_Click);
			this.chkClr8.Location = new global::System.Drawing.Point(592, 204);
			this.chkClr8.Name = "chkClr8";
			this.chkClr8.Size = new global::System.Drawing.Size(16, 16);
			this.chkClr8.TabIndex = 96;
			this.entryTo7.Location = new global::System.Drawing.Point(400, 176);
			this.entryTo7.Name = "entryTo7";
			this.entryTo7.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo7.TabIndex = 92;
			this.entryTo7.Text = "";
			this.entrySub7.Location = new global::System.Drawing.Point(320, 176);
			this.entrySub7.Name = "entrySub7";
			this.entrySub7.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub7.TabIndex = 91;
			this.entrySub7.Text = "";
			this.entrySub7.TextChanged += new global::System.EventHandler(this.entrySub7_TextChanged);
			this.chkRK7.Location = new global::System.Drawing.Point(568, 176);
			this.chkRK7.Name = "chkRK7";
			this.chkRK7.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK7.TabIndex = 88;
			this.chkRK7.Text = "";
			this.entryMax7.Location = new global::System.Drawing.Point(216, 176);
			global::System.Windows.Forms.NumericUpDown numericUpDown38 = this.entryMax7;
			int[] bits38 = new int[4];
			bits38[0] = 65535;
			decimal num38 = new decimal(bits38);
			numericUpDown38.Maximum = num38;
			this.entryMax7.Name = "entryMax7";
			this.entryMax7.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax7.TabIndex = 87;
			this.entryMax7.Click += new global::System.EventHandler(this.entryMax7_Click);
			this.entryMax7.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax7_KeyUp);
			this.entryMax7.Leave += new global::System.EventHandler(this.entryMax7_Leave);
			this.btnEntryEdit7.Location = new global::System.Drawing.Point(192, 176);
			this.btnEntryEdit7.Name = "btnEntryEdit7";
			this.btnEntryEdit7.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit7.TabIndex = 86;
			this.btnEntryEdit7.Text = "?";
			this.btnEntryEdit7.Click += new global::System.EventHandler(this.btnEntryEdit7_Click);
			this.entryText7.ContextMenu = this.deleteEntry;
			this.entryText7.Location = new global::System.Drawing.Point(8, 176);
			this.entryText7.Name = "entryText7";
			this.entryText7.Size = new global::System.Drawing.Size(184, 20);
			this.entryText7.TabIndex = 84;
			this.entryText7.Text = "";
			this.entryText7.TextChanged += new global::System.EventHandler(this.entryText7_TextChanged);
			this.entryText7.MouseLeave += new global::System.EventHandler(this.entryText7_MouseLeave);
			this.entryText7.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText7_KeyUp);
			this.chkClr7.Location = new global::System.Drawing.Point(592, 176);
			this.chkClr7.Name = "chkClr7";
			this.chkClr7.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr7.TabIndex = 85;
			this.entryTo6.Location = new global::System.Drawing.Point(400, 152);
			this.entryTo6.Name = "entryTo6";
			this.entryTo6.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo6.TabIndex = 81;
			this.entryTo6.Text = "";
			this.entrySub6.Location = new global::System.Drawing.Point(320, 152);
			this.entrySub6.Name = "entrySub6";
			this.entrySub6.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub6.TabIndex = 80;
			this.entrySub6.Text = "";
			this.entrySub6.TextChanged += new global::System.EventHandler(this.entrySub6_TextChanged);
			this.chkRK6.Location = new global::System.Drawing.Point(568, 152);
			this.chkRK6.Name = "chkRK6";
			this.chkRK6.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK6.TabIndex = 77;
			this.chkRK6.Text = "";
			this.entryMax6.Location = new global::System.Drawing.Point(216, 152);
			global::System.Windows.Forms.NumericUpDown numericUpDown39 = this.entryMax6;
			int[] bits39 = new int[4];
			bits39[0] = 65535;
			decimal num39 = new decimal(bits39);
			numericUpDown39.Maximum = num39;
			this.entryMax6.Name = "entryMax6";
			this.entryMax6.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax6.TabIndex = 76;
			this.entryMax6.Click += new global::System.EventHandler(this.entryMax6_Click);
			this.entryMax6.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax6_KeyUp);
			this.entryMax6.Leave += new global::System.EventHandler(this.entryMax6_Leave);
			this.btnEntryEdit6.Location = new global::System.Drawing.Point(192, 152);
			this.btnEntryEdit6.Name = "btnEntryEdit6";
			this.btnEntryEdit6.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit6.TabIndex = 75;
			this.btnEntryEdit6.Text = "?";
			this.btnEntryEdit6.Click += new global::System.EventHandler(this.btnEntryEdit6_Click);
			this.entryText6.ContextMenu = this.deleteEntry;
			this.entryText6.Location = new global::System.Drawing.Point(8, 152);
			this.entryText6.Name = "entryText6";
			this.entryText6.Size = new global::System.Drawing.Size(184, 20);
			this.entryText6.TabIndex = 73;
			this.entryText6.Text = "";
			this.entryText6.TextChanged += new global::System.EventHandler(this.entryText6_TextChanged);
			this.entryText6.MouseLeave += new global::System.EventHandler(this.entryText6_MouseLeave);
			this.entryText6.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText6_KeyUp);
			this.chkClr6.Location = new global::System.Drawing.Point(592, 152);
			this.chkClr6.Name = "chkClr6";
			this.chkClr6.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr6.TabIndex = 74;
			this.entryTo5.Location = new global::System.Drawing.Point(400, 128);
			this.entryTo5.Name = "entryTo5";
			this.entryTo5.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo5.TabIndex = 70;
			this.entryTo5.Text = "";
			this.entrySub5.Location = new global::System.Drawing.Point(320, 128);
			this.entrySub5.Name = "entrySub5";
			this.entrySub5.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub5.TabIndex = 69;
			this.entrySub5.Text = "";
			this.entrySub5.TextChanged += new global::System.EventHandler(this.entrySub5_TextChanged);
			this.chkRK5.Location = new global::System.Drawing.Point(568, 128);
			this.chkRK5.Name = "chkRK5";
			this.chkRK5.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK5.TabIndex = 66;
			this.chkRK5.Text = "";
			this.entryMax5.Location = new global::System.Drawing.Point(216, 128);
			global::System.Windows.Forms.NumericUpDown numericUpDown40 = this.entryMax5;
			int[] bits40 = new int[4];
			bits40[0] = 65535;
			decimal num40 = new decimal(bits40);
			numericUpDown40.Maximum = num40;
			this.entryMax5.Name = "entryMax5";
			this.entryMax5.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax5.TabIndex = 65;
			this.entryMax5.Click += new global::System.EventHandler(this.entryMax5_Click);
			this.entryMax5.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax5_KeyUp);
			this.entryMax5.Leave += new global::System.EventHandler(this.entryMax5_Leave);
			this.btnEntryEdit5.Location = new global::System.Drawing.Point(192, 128);
			this.btnEntryEdit5.Name = "btnEntryEdit5";
			this.btnEntryEdit5.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit5.TabIndex = 64;
			this.btnEntryEdit5.Text = "?";
			this.btnEntryEdit5.Click += new global::System.EventHandler(this.btnEntryEdit5_Click);
			this.entryText5.ContextMenu = this.deleteEntry;
			this.entryText5.Location = new global::System.Drawing.Point(8, 128);
			this.entryText5.Name = "entryText5";
			this.entryText5.Size = new global::System.Drawing.Size(184, 20);
			this.entryText5.TabIndex = 62;
			this.entryText5.Text = "";
			this.entryText5.TextChanged += new global::System.EventHandler(this.entryText5_TextChanged);
			this.entryText5.MouseLeave += new global::System.EventHandler(this.entryText5_MouseLeave);
			this.entryText5.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText5_KeyUp);
			this.chkClr5.Location = new global::System.Drawing.Point(592, 128);
			this.chkClr5.Name = "chkClr5";
			this.chkClr5.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr5.TabIndex = 63;
			this.entryTo4.Location = new global::System.Drawing.Point(400, 104);
			this.entryTo4.Name = "entryTo4";
			this.entryTo4.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo4.TabIndex = 59;
			this.entryTo4.Text = "";
			this.entrySub4.Location = new global::System.Drawing.Point(320, 104);
			this.entrySub4.Name = "entrySub4";
			this.entrySub4.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub4.TabIndex = 58;
			this.entrySub4.Text = "";
			this.entrySub4.TextChanged += new global::System.EventHandler(this.entrySub4_TextChanged);
			this.chkRK4.Location = new global::System.Drawing.Point(568, 104);
			this.chkRK4.Name = "chkRK4";
			this.chkRK4.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK4.TabIndex = 55;
			this.chkRK4.Text = "";
			this.entryMax4.Location = new global::System.Drawing.Point(216, 104);
			global::System.Windows.Forms.NumericUpDown numericUpDown41 = this.entryMax4;
			int[] bits41 = new int[4];
			bits41[0] = 65535;
			decimal num41 = new decimal(bits41);
			numericUpDown41.Maximum = num41;
			this.entryMax4.Name = "entryMax4";
			this.entryMax4.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax4.TabIndex = 54;
			this.entryMax4.Click += new global::System.EventHandler(this.entryMax4_Click);
			this.entryMax4.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax4_KeyUp);
			this.entryMax4.Leave += new global::System.EventHandler(this.entryMax4_Leave);
			this.btnEntryEdit4.Location = new global::System.Drawing.Point(192, 104);
			this.btnEntryEdit4.Name = "btnEntryEdit4";
			this.btnEntryEdit4.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit4.TabIndex = 53;
			this.btnEntryEdit4.Text = "?";
			this.btnEntryEdit4.Click += new global::System.EventHandler(this.btnEntryEdit4_Click);
			this.entryText4.ContextMenu = this.deleteEntry;
			this.entryText4.Location = new global::System.Drawing.Point(8, 104);
			this.entryText4.Name = "entryText4";
			this.entryText4.Size = new global::System.Drawing.Size(184, 20);
			this.entryText4.TabIndex = 51;
			this.entryText4.Text = "";
			this.entryText4.TextChanged += new global::System.EventHandler(this.entryText4_TextChanged);
			this.entryText4.MouseLeave += new global::System.EventHandler(this.entryText4_MouseLeave);
			this.entryText4.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText4_KeyUp);
			this.chkClr4.Location = new global::System.Drawing.Point(592, 104);
			this.chkClr4.Name = "chkClr4";
			this.chkClr4.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr4.TabIndex = 52;
			this.entryTo3.Location = new global::System.Drawing.Point(400, 80);
			this.entryTo3.Name = "entryTo3";
			this.entryTo3.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo3.TabIndex = 48;
			this.entryTo3.Text = "";
			this.entrySub3.Location = new global::System.Drawing.Point(320, 80);
			this.entrySub3.Name = "entrySub3";
			this.entrySub3.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub3.TabIndex = 47;
			this.entrySub3.Text = "";
			this.entrySub3.TextChanged += new global::System.EventHandler(this.entrySub3_TextChanged);
			this.chkRK3.Location = new global::System.Drawing.Point(568, 80);
			this.chkRK3.Name = "chkRK3";
			this.chkRK3.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK3.TabIndex = 44;
			this.chkRK3.Text = "";
			this.entryMax3.Location = new global::System.Drawing.Point(216, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown42 = this.entryMax3;
			int[] bits42 = new int[4];
			bits42[0] = 65535;
			decimal num42 = new decimal(bits42);
			numericUpDown42.Maximum = num42;
			this.entryMax3.Name = "entryMax3";
			this.entryMax3.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax3.TabIndex = 43;
			this.entryMax3.Click += new global::System.EventHandler(this.entryMax3_Click);
			this.entryMax3.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax3_KeyUp);
			this.entryMax3.Leave += new global::System.EventHandler(this.entryMax3_Leave);
			this.btnEntryEdit3.Location = new global::System.Drawing.Point(192, 80);
			this.btnEntryEdit3.Name = "btnEntryEdit3";
			this.btnEntryEdit3.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit3.TabIndex = 42;
			this.btnEntryEdit3.Text = "?";
			this.btnEntryEdit3.Click += new global::System.EventHandler(this.btnEntryEdit3_Click);
			this.entryText3.ContextMenu = this.deleteEntry;
			this.entryText3.Location = new global::System.Drawing.Point(8, 80);
			this.entryText3.Name = "entryText3";
			this.entryText3.Size = new global::System.Drawing.Size(184, 20);
			this.entryText3.TabIndex = 40;
			this.entryText3.Text = "";
			this.entryText3.TextChanged += new global::System.EventHandler(this.entryText3_TextChanged);
			this.entryText3.MouseLeave += new global::System.EventHandler(this.entryText3_MouseLeave);
			this.entryText3.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText3_KeyUp);
			this.chkClr3.Location = new global::System.Drawing.Point(592, 80);
			this.chkClr3.Name = "chkClr3";
			this.chkClr3.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr3.TabIndex = 41;
			this.entryTo2.Location = new global::System.Drawing.Point(400, 56);
			this.entryTo2.Name = "entryTo2";
			this.entryTo2.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo2.TabIndex = 36;
			this.entryTo2.Text = "";
			this.entrySub2.Location = new global::System.Drawing.Point(320, 56);
			this.entrySub2.Name = "entrySub2";
			this.entrySub2.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub2.TabIndex = 35;
			this.entrySub2.Text = "";
			this.entrySub2.TextChanged += new global::System.EventHandler(this.entrySub2_TextChanged);
			this.chkRK2.Location = new global::System.Drawing.Point(568, 56);
			this.chkRK2.Name = "chkRK2";
			this.chkRK2.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK2.TabIndex = 30;
			this.chkRK2.Text = "";
			this.entryMax2.Location = new global::System.Drawing.Point(216, 56);
			global::System.Windows.Forms.NumericUpDown numericUpDown43 = this.entryMax2;
			int[] bits43 = new int[4];
			bits43[0] = 65535;
			decimal num43 = new decimal(bits43);
			numericUpDown43.Maximum = num43;
			this.entryMax2.Name = "entryMax2";
			this.entryMax2.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax2.TabIndex = 27;
			this.entryMax2.Click += new global::System.EventHandler(this.entryMax2_Click);
			this.entryMax2.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax2_KeyUp);
			this.entryMax2.ValueChanged += new global::System.EventHandler(this.entryMax2_ValueChanged_1);
			this.entryMax2.Leave += new global::System.EventHandler(this.entryMax2_Leave);
			this.btnEntryEdit2.Location = new global::System.Drawing.Point(192, 56);
			this.btnEntryEdit2.Name = "btnEntryEdit2";
			this.btnEntryEdit2.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit2.TabIndex = 26;
			this.btnEntryEdit2.Text = "?";
			this.btnEntryEdit2.Click += new global::System.EventHandler(this.btnEntryEdit2_Click);
			this.entryText2.ContextMenu = this.deleteEntry;
			this.entryText2.Location = new global::System.Drawing.Point(8, 56);
			this.entryText2.Name = "entryText2";
			this.entryText2.Size = new global::System.Drawing.Size(184, 20);
			this.entryText2.TabIndex = 24;
			this.entryText2.Text = "";
			this.entryText2.TextChanged += new global::System.EventHandler(this.entryText2_TextChanged);
			this.entryText2.MouseLeave += new global::System.EventHandler(this.entryText2_MouseLeave);
			this.entryText2.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText2_KeyUp);
			this.chkClr2.Location = new global::System.Drawing.Point(592, 56);
			this.chkClr2.Name = "chkClr2";
			this.chkClr2.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr2.TabIndex = 25;
			this.entryTo1.Location = new global::System.Drawing.Point(400, 32);
			this.entryTo1.Name = "entryTo1";
			this.entryTo1.Size = new global::System.Drawing.Size(32, 20);
			this.entryTo1.TabIndex = 16;
			this.entryTo1.Text = "";
			this.vScrollBar1.LargeChange = 9;
			this.vScrollBar1.Location = new global::System.Drawing.Point(616, 16);
			this.vScrollBar1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.vScrollBar1.Maximum = 8;
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new global::System.Drawing.Size(16, 200);
			this.vScrollBar1.TabIndex = 15;
			this.vScrollBar1.MouseEnter += new global::System.EventHandler(this.vScrollBar1_MouseEnter);
			this.vScrollBar1.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
			this.entrySub1.Location = new global::System.Drawing.Point(320, 32);
			this.entrySub1.Name = "entrySub1";
			this.entrySub1.Size = new global::System.Drawing.Size(32, 20);
			this.entrySub1.TabIndex = 13;
			this.entrySub1.Text = "";
			this.entrySub1.TextChanged += new global::System.EventHandler(this.entrySub1_TextChanged);
			this.chkRK1.Location = new global::System.Drawing.Point(568, 32);
			this.chkRK1.Name = "chkRK1";
			this.chkRK1.Size = new global::System.Drawing.Size(16, 24);
			this.chkRK1.TabIndex = 8;
			this.chkRK1.Text = "";
			this.entryMax1.Location = new global::System.Drawing.Point(216, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown44 = this.entryMax1;
			int[] bits44 = new int[4];
			bits44[0] = 65535;
			decimal num44 = new decimal(bits44);
			numericUpDown44.Maximum = num44;
			this.entryMax1.Name = "entryMax1";
			this.entryMax1.Size = new global::System.Drawing.Size(56, 20);
			this.entryMax1.TabIndex = 3;
			this.entryMax1.Click += new global::System.EventHandler(this.entryMax1_Click);
			this.entryMax1.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryMax1_KeyUp);
			this.entryMax1.Leave += new global::System.EventHandler(this.entryMax1_Leave);
			this.btnEntryEdit1.Location = new global::System.Drawing.Point(192, 32);
			this.btnEntryEdit1.Name = "btnEntryEdit1";
			this.btnEntryEdit1.Size = new global::System.Drawing.Size(20, 20);
			this.btnEntryEdit1.TabIndex = 2;
			this.btnEntryEdit1.Text = "?";
			this.btnEntryEdit1.Click += new global::System.EventHandler(this.btnEntryEdit1_Click);
			this.entryText1.ContextMenu = this.deleteEntry;
			this.entryText1.Location = new global::System.Drawing.Point(8, 32);
			this.entryText1.Name = "entryText1";
			this.entryText1.Size = new global::System.Drawing.Size(184, 20);
			this.entryText1.TabIndex = 0;
			this.entryText1.Text = "";
			this.entryText1.TextChanged += new global::System.EventHandler(this.entryText1_TextChanged);
			this.entryText1.MouseLeave += new global::System.EventHandler(this.entryText1_MouseLeave);
			this.entryText1.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.entryText1_KeyUp);
			this.chkClr1.Location = new global::System.Drawing.Point(592, 32);
			this.chkClr1.Name = "chkClr1";
			this.chkClr1.Size = new global::System.Drawing.Size(16, 24);
			this.chkClr1.TabIndex = 1;
			this.grpSpawnEdit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.grpSpawnEdit.Controls.Add(this.btnSendSingleSpawner);
			this.grpSpawnEdit.Controls.Add(this.chkInContainer);
			this.grpSpawnEdit.Controls.Add(this.spnKillReset);
			this.grpSpawnEdit.Controls.Add(this.label28);
			this.grpSpawnEdit.Controls.Add(this.spnProximitySnd);
			this.grpSpawnEdit.Controls.Add(this.label27);
			this.grpSpawnEdit.Controls.Add(this.label26);
			this.grpSpawnEdit.Controls.Add(this.textTrigObjectProp);
			this.grpSpawnEdit.Controls.Add(this.spnDuration);
			this.grpSpawnEdit.Controls.Add(this.label25);
			this.grpSpawnEdit.Controls.Add(this.label24);
			this.grpSpawnEdit.Controls.Add(this.spnTODEnd);
			this.grpSpawnEdit.Controls.Add(this.spnDespawn);
			this.grpSpawnEdit.Controls.Add(this.label23);
			this.grpSpawnEdit.Controls.Add(this.spnMaxRefract);
			this.grpSpawnEdit.Controls.Add(this.spnMinRefract);
			this.grpSpawnEdit.Controls.Add(this.spnSpawnRange);
			this.grpSpawnEdit.Controls.Add(this.spnProximityRange);
			this.grpSpawnEdit.Controls.Add(this.spnTODStart);
			this.grpSpawnEdit.Controls.Add(this.spnTeam);
			this.grpSpawnEdit.Controls.Add(this.spnMaxDelay);
			this.grpSpawnEdit.Controls.Add(this.chkSmartSpawning);
			this.grpSpawnEdit.Controls.Add(this.chkSequentialSpawn);
			this.grpSpawnEdit.Controls.Add(this.chkSpawnOnTrigger);
			this.grpSpawnEdit.Controls.Add(this.chkGameTOD);
			this.grpSpawnEdit.Controls.Add(this.chkRealTOD);
			this.grpSpawnEdit.Controls.Add(this.chkAllowGhost);
			this.grpSpawnEdit.Controls.Add(this.label18);
			this.grpSpawnEdit.Controls.Add(this.label19);
			this.grpSpawnEdit.Controls.Add(this.label20);
			this.grpSpawnEdit.Controls.Add(this.label21);
			this.grpSpawnEdit.Controls.Add(this.label22);
			this.grpSpawnEdit.Controls.Add(this.label17);
			this.grpSpawnEdit.Controls.Add(this.textSkillTrigger);
			this.grpSpawnEdit.Controls.Add(this.label16);
			this.grpSpawnEdit.Controls.Add(this.textSpeechTrigger);
			this.grpSpawnEdit.Controls.Add(this.label15);
			this.grpSpawnEdit.Controls.Add(this.textProximityMsg);
			this.grpSpawnEdit.Controls.Add(this.label14);
			this.grpSpawnEdit.Controls.Add(this.textPlayerTrigProp);
			this.grpSpawnEdit.Controls.Add(this.label12);
			this.grpSpawnEdit.Controls.Add(this.textNoTriggerOnCarried);
			this.grpSpawnEdit.Controls.Add(this.label11);
			this.grpSpawnEdit.Controls.Add(this.textTriggerOnCarried);
			this.grpSpawnEdit.Controls.Add(this.chkHomeRangeIsRelative);
			this.grpSpawnEdit.Controls.Add(this.btnMove);
			this.grpSpawnEdit.Controls.Add(this.btnRestoreSpawnDefaults);
			this.grpSpawnEdit.Controls.Add(this.btnDeleteSpawn);
			this.grpSpawnEdit.Controls.Add(this.lblMaxDelay);
			this.grpSpawnEdit.Controls.Add(this.chkRunning);
			this.grpSpawnEdit.Controls.Add(this.lblHomeRange);
			this.grpSpawnEdit.Controls.Add(this.spnMaxCount);
			this.grpSpawnEdit.Controls.Add(this.txtName);
			this.grpSpawnEdit.Controls.Add(this.spnHomeRange);
			this.grpSpawnEdit.Controls.Add(this.lblTeam);
			this.grpSpawnEdit.Controls.Add(this.lblMaxCount);
			this.grpSpawnEdit.Controls.Add(this.spnMinDelay);
			this.grpSpawnEdit.Controls.Add(this.chkGroup);
			this.grpSpawnEdit.Controls.Add(this.lblMinDelay);
			this.grpSpawnEdit.Location = new global::System.Drawing.Point(5, 0);
			this.grpSpawnEdit.Name = "grpSpawnEdit";
			this.grpSpawnEdit.Size = new global::System.Drawing.Size(488, 536);
			this.grpSpawnEdit.TabIndex = 0;
			this.grpSpawnEdit.TabStop = false;
			this.grpSpawnEdit.Text = "Spawn Details";
			this.grpSpawnEdit.Leave += new global::System.EventHandler(this.grpSpawnEdit_Leave);
			this.btnSendSingleSpawner.ContextMenu = this.unloadSingleSpawner;
			this.btnSendSingleSpawner.Enabled = false;
			this.btnSendSingleSpawner.Location = new global::System.Drawing.Point(224, 408);
			this.btnSendSingleSpawner.Name = "btnSendSingleSpawner";
			this.btnSendSingleSpawner.Size = new global::System.Drawing.Size(120, 23);
			this.btnSendSingleSpawner.TabIndex = 208;
			this.btnSendSingleSpawner.Text = "Send to Server";
			this.btnSendSingleSpawner.Click += new global::System.EventHandler(this.btnSendSpawn_Click);
			this.unloadSingleSpawner.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniUnloadSingleSpawner, this.menuItem23 });
			this.unloadSingleSpawner.Popup += new global::System.EventHandler(this.unloadSingleSpawner_Popup);
			this.mniUnloadSingleSpawner.Index = 0;
			this.mniUnloadSingleSpawner.Text = "Unload Spawner from Server";
			this.mniUnloadSingleSpawner.Click += new global::System.EventHandler(this.mniUnloadSingleSpawner_Click_1);
			this.menuItem23.Index = 1;
			this.menuItem23.Text = "Cancel";
			this.label26.Location = new global::System.Drawing.Point(8, 340);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(112, 20);
			this.label26.TabIndex = 200;
			this.label26.Text = "TrigObjectProp";
			this.textTrigObjectProp.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textTrigObjectProp.Location = new global::System.Drawing.Point(120, 340);
			this.textTrigObjectProp.Name = "textTrigObjectProp";
			this.textTrigObjectProp.Size = new global::System.Drawing.Size(352, 20);
			this.textTrigObjectProp.TabIndex = 199;
			this.textTrigObjectProp.Text = "";
			this.label17.Location = new global::System.Drawing.Point(8, 260);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(112, 20);
			this.label17.TabIndex = 175;
			this.label17.Text = "SkillTrigger";
			this.textSkillTrigger.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textSkillTrigger.Location = new global::System.Drawing.Point(120, 260);
			this.textSkillTrigger.Name = "textSkillTrigger";
			this.textSkillTrigger.Size = new global::System.Drawing.Size(352, 20);
			this.textSkillTrigger.TabIndex = 174;
			this.textSkillTrigger.Text = "";
			this.label16.Location = new global::System.Drawing.Point(8, 280);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(112, 16);
			this.label16.TabIndex = 172;
			this.label16.Text = "SpeechTrigger";
			this.textSpeechTrigger.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textSpeechTrigger.Location = new global::System.Drawing.Point(120, 280);
			this.textSpeechTrigger.Name = "textSpeechTrigger";
			this.textSpeechTrigger.Size = new global::System.Drawing.Size(352, 20);
			this.textSpeechTrigger.TabIndex = 171;
			this.textSpeechTrigger.Text = "";
			this.label15.Location = new global::System.Drawing.Point(8, 300);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(112, 20);
			this.label15.TabIndex = 169;
			this.label15.Text = "ProximityMsg";
			this.textProximityMsg.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textProximityMsg.Location = new global::System.Drawing.Point(120, 300);
			this.textProximityMsg.Name = "textProximityMsg";
			this.textProximityMsg.Size = new global::System.Drawing.Size(352, 20);
			this.textProximityMsg.TabIndex = 168;
			this.textProximityMsg.Text = "";
			this.label14.Location = new global::System.Drawing.Point(8, 320);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(112, 16);
			this.label14.TabIndex = 160;
			this.label14.Text = "PlayerTrigProp";
			this.textPlayerTrigProp.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerTrigProp.Location = new global::System.Drawing.Point(120, 320);
			this.textPlayerTrigProp.Name = "textPlayerTrigProp";
			this.textPlayerTrigProp.Size = new global::System.Drawing.Size(352, 20);
			this.textPlayerTrigProp.TabIndex = 159;
			this.textPlayerTrigProp.Text = "";
			this.label12.Location = new global::System.Drawing.Point(8, 380);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(112, 20);
			this.label12.TabIndex = 154;
			this.label12.Text = "NoTriggerOnCarried";
			this.textNoTriggerOnCarried.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textNoTriggerOnCarried.Location = new global::System.Drawing.Point(120, 380);
			this.textNoTriggerOnCarried.Name = "textNoTriggerOnCarried";
			this.textNoTriggerOnCarried.Size = new global::System.Drawing.Size(352, 20);
			this.textNoTriggerOnCarried.TabIndex = 153;
			this.textNoTriggerOnCarried.Text = "";
			this.label11.Location = new global::System.Drawing.Point(8, 360);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(112, 16);
			this.label11.TabIndex = 151;
			this.label11.Text = "TriggerOnCarried";
			this.textTriggerOnCarried.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textTriggerOnCarried.Location = new global::System.Drawing.Point(120, 360);
			this.textTriggerOnCarried.Name = "textTriggerOnCarried";
			this.textTriggerOnCarried.Size = new global::System.Drawing.Size(352, 20);
			this.textTriggerOnCarried.TabIndex = 150;
			this.textTriggerOnCarried.Text = "";
			this.mainMenu1.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem5, this.menuItem22, this.menuItem8, this.menuItem14, this.menuItem16 });
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem6, this.menuItem7, this.menuItem10, this.menuItem11, this.menuItem12, this.menuItem13 });
			this.menuItem5.Text = "File";
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "Load Spawn Packs";
			this.menuItem6.Click += new global::System.EventHandler(this.menuItem6_Click);
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "Save Spawn Packs";
			this.menuItem7.Click += new global::System.EventHandler(this.menuItem7_Click);
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "Import All Spawn Types";
			this.menuItem10.Click += new global::System.EventHandler(this.menuItem10_Click);
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "Export All Spawn Types";
			this.menuItem11.Click += new global::System.EventHandler(this.menuItem11_Click);
			this.menuItem12.Index = 4;
			this.menuItem12.Text = "Import .map file";
			this.menuItem12.Click += new global::System.EventHandler(this.menuItem12_Click);
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "Import .msf file";
			this.menuItem13.Click += new global::System.EventHandler(this.menuItem13_Click);
			this.menuItem22.Index = 1;
			this.menuItem22.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem24, this.menuItem25 });
			this.menuItem22.Text = "Edit";
			this.menuItem24.Index = 0;
			this.menuItem24.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniDeleteInSelectionWindow, this.mniDeleteNotSelected, this.mniToolbarDeleteAllSpawns, this.mniDeleteAllFiltered, this.mniDeleteAllUnfiltered });
			this.menuItem24.Text = "Delete";
			this.mniDeleteInSelectionWindow.Index = 0;
			this.mniDeleteInSelectionWindow.Text = "Spawns in Selection Window";
			this.mniDeleteInSelectionWindow.Click += new global::System.EventHandler(this.mniDeleteInSelectionWindow_Click);
			this.mniDeleteNotSelected.Index = 1;
			this.mniDeleteNotSelected.Text = "Spawns NOT in Selection Window";
			this.mniDeleteNotSelected.Click += new global::System.EventHandler(this.mniDeleteNotSelected_Click);
			this.mniToolbarDeleteAllSpawns.Index = 2;
			this.mniToolbarDeleteAllSpawns.Text = "All Spawns";
			this.mniToolbarDeleteAllSpawns.Click += new global::System.EventHandler(this.mniToolbarDeleteAllSpawns_Click);
			this.mniDeleteAllFiltered.Index = 3;
			this.mniDeleteAllFiltered.Text = "Filtered Spawns (gray, not displayed) ";
			this.mniDeleteAllFiltered.Click += new global::System.EventHandler(this.mniDeleteAllFiltered_Click);
			this.mniDeleteAllUnfiltered.Index = 4;
			this.mniDeleteAllUnfiltered.Text = "Un-Filtered Spawns (black, displayed) ";
			this.mniDeleteAllUnfiltered.Click += new global::System.EventHandler(this.mniDeleteAllUnfiltered_Click);
			this.menuItem25.Index = 1;
			this.menuItem25.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniModifyInSelectionWindow, this.mniModifiedUnfiltered });
			this.menuItem25.Text = "Modify Properties";
			this.mniModifyInSelectionWindow.Index = 0;
			this.mniModifyInSelectionWindow.Text = "of Spawns in Selection Window";
			this.mniModifyInSelectionWindow.Click += new global::System.EventHandler(this.mniModifyInSelectionWindow_Click);
			this.mniModifiedUnfiltered.Index = 1;
			this.mniModifiedUnfiltered.Text = "of Un-Filtered Spawns (black, displayed)";
			this.mniModifiedUnfiltered.Click += new global::System.EventHandler(this.mniModifiedUnfiltered_Click);
			this.menuItem8.Index = 2;
			this.menuItem8.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem9, this.menuItem17, this.mniDisplayFilterSettings });
			this.menuItem8.Text = "Tools";
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "Setup";
			this.menuItem9.Click += new global::System.EventHandler(this.menuItem9_Click);
			this.menuItem17.Index = 1;
			this.menuItem17.Text = "Transfer Server Settings";
			this.menuItem17.Click += new global::System.EventHandler(this.menuItem17_Click);
			this.mniDisplayFilterSettings.Index = 2;
			this.mniDisplayFilterSettings.Text = "Display Filter Settings";
			this.mniDisplayFilterSettings.Click += new global::System.EventHandler(this.mniDisplayFilterSettings_Click);
			this.menuItem14.Index = 3;
			this.menuItem14.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniAlwaysOnTop });
			this.menuItem14.Text = "Options";
			this.mniAlwaysOnTop.Index = 0;
			this.mniAlwaysOnTop.Text = "Always On Top";
			this.mniAlwaysOnTop.Click += new global::System.EventHandler(this.mniAlwaysOnTop_Click);
			this.menuItem16.Index = 4;
			this.menuItem16.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.menuItem18, this.menuItem4 });
			this.menuItem16.Text = "Help";
			this.menuItem18.Index = 0;
			this.menuItem18.Text = "Help";
			this.menuItem18.Click += new global::System.EventHandler(this.menuItem18_Click);
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "About";
			this.menuItem4.Click += new global::System.EventHandler(this.menuItem4_Click);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Controls.Add(this.panelRight);
			this.panel1.Controls.Add(this.axUOMap);
			this.panel1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.panel1.Location = new global::System.Drawing.Point(220, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1160, 884);
			this.panel1.TabIndex = 5;
			this.panelRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panelRight.Controls.Add(this.splitContainerRightDetails);
			this.panelRight.Location = new global::System.Drawing.Point(640, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new global::System.Drawing.Size(900, 876);
			this.panelRight.TabIndex = 9;
			this.splitContainerRightDetails.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRightDetails.FixedPanel = global::System.Windows.Forms.FixedPanel.None;
			this.splitContainerRightDetails.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainerRightDetails.Name = "splitContainerRightDetails";
			this.splitContainerRightDetails.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainerRightDetails.Panel1.Controls.Add(this.tabControl1);
			this.splitContainerRightDetails.Panel2.Controls.Add(this.panel3);
			this.splitContainerRightDetails.Panel1MinSize = 300;
			this.splitContainerRightDetails.Panel2MinSize = 240;
			this.splitContainerRightDetails.Size = new global::System.Drawing.Size(900, 876);
			this.splitContainerRightDetails.SplitterDistance = 530;
			this.splitContainerRightDetails.SplitterWidth = 6;
			this.splitContainerRightDetails.TabIndex = 10;
			this.tabControl1.Controls.Add(this.tabBasic);
			this.tabControl1.Controls.Add(this.tabAdvanced);
			this.tabControl1.Controls.Add(this.tabSpawnTypes);
			this.tabControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new global::System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(520, 568);
			this.tabControl1.TabIndex = 8;
			this.tabControl1.Leave += new global::System.EventHandler(this.tabControl1_Leave);
			this.tabBasic.Controls.Add(this.grpSpawnEdit);
			this.tabBasic.AutoScroll = true;
			this.tabBasic.Location = new global::System.Drawing.Point(4, 22);
			this.tabBasic.Name = "tabBasic";
			this.tabBasic.Size = new global::System.Drawing.Size(512, 534);
			this.tabBasic.TabIndex = 0;
			this.tabBasic.Text = "Basic";
			this.tabAdvanced.Controls.Add(this.groupBox1);
			this.tabAdvanced.AutoScroll = true;
			this.tabAdvanced.Location = new global::System.Drawing.Point(4, 22);
			this.tabAdvanced.Name = "tabAdvanced";
			this.tabAdvanced.Size = new global::System.Drawing.Size(512, 534);
			this.tabAdvanced.TabIndex = 1;
			this.tabAdvanced.Text = "Advanced";
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.txtNotes);
			this.groupBox1.Controls.Add(this.spnContainerZ);
			this.groupBox1.Controls.Add(this.spnContainerY);
			this.groupBox1.Controls.Add(this.spnContainerX);
			this.groupBox1.Controls.Add(this.chkTickReset);
			this.groupBox1.Controls.Add(this.chkAllowNPC);
			this.groupBox1.Controls.Add(this.label37);
			this.groupBox1.Controls.Add(this.textRegionName);
			this.groupBox1.Controls.Add(this.label36);
			this.groupBox1.Controls.Add(this.textWayPoint);
			this.groupBox1.Controls.Add(this.label35);
			this.groupBox1.Controls.Add(this.textConfigFile);
			this.groupBox1.Controls.Add(this.label34);
			this.groupBox1.Controls.Add(this.textSetObjectName);
			this.groupBox1.Controls.Add(this.label33);
			this.groupBox1.Controls.Add(this.textTrigObjectName);
			this.groupBox1.Controls.Add(this.chkExternalTriggering);
			this.groupBox1.Controls.Add(this.labelContainerZ);
			this.groupBox1.Controls.Add(this.labelContainerY);
			this.groupBox1.Controls.Add(this.labelContainerX);
			this.groupBox1.Controls.Add(this.label32);
			this.groupBox1.Controls.Add(this.spnStackAmount);
			this.groupBox1.Controls.Add(this.spnTriggerProbability);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.textMobTriggerName);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textMobTrigProp);
			this.groupBox1.Location = new global::System.Drawing.Point(5, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBox1.Size = new global::System.Drawing.Size(488, 536);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Spawn Details";
			this.groupBox1.Leave += new global::System.EventHandler(this.groupBox1_Leave);
			this.label44.Location = new global::System.Drawing.Point(8, 344);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(64, 16);
			this.label44.TabIndex = 237;
			this.label44.Text = "Notes:";
			this.txtNotes.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtNotes.Location = new global::System.Drawing.Point(8, 360);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new global::System.Drawing.Size(472, 72);
			this.txtNotes.TabIndex = 236;
			this.txtNotes.Text = "";
			this.label37.Location = new global::System.Drawing.Point(8, 128);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(112, 16);
			this.label37.TabIndex = 232;
			this.label37.Text = "RegionName:";
			this.textRegionName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textRegionName.Location = new global::System.Drawing.Point(120, 128);
			this.textRegionName.Name = "textRegionName";
			this.textRegionName.Size = new global::System.Drawing.Size(360, 20);
			this.textRegionName.TabIndex = 231;
			this.textRegionName.Text = "";
			this.label36.Location = new global::System.Drawing.Point(8, 152);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(112, 16);
			this.label36.TabIndex = 230;
			this.label36.Text = "WaypointName:";
			this.textWayPoint.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textWayPoint.Location = new global::System.Drawing.Point(120, 152);
			this.textWayPoint.Name = "textWayPoint";
			this.textWayPoint.Size = new global::System.Drawing.Size(360, 20);
			this.textWayPoint.TabIndex = 229;
			this.textWayPoint.Text = "";
			this.label35.Location = new global::System.Drawing.Point(8, 176);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(112, 16);
			this.label35.TabIndex = 228;
			this.label35.Text = "ConfigFile:";
			this.textConfigFile.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textConfigFile.Location = new global::System.Drawing.Point(120, 176);
			this.textConfigFile.Name = "textConfigFile";
			this.textConfigFile.Size = new global::System.Drawing.Size(360, 20);
			this.textConfigFile.TabIndex = 227;
			this.textConfigFile.Text = "";
			this.label34.Location = new global::System.Drawing.Point(8, 272);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(112, 16);
			this.label34.TabIndex = 226;
			this.label34.Text = "SetObjectName:";
			this.textSetObjectName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textSetObjectName.Location = new global::System.Drawing.Point(120, 272);
			this.textSetObjectName.Name = "textSetObjectName";
			this.textSetObjectName.Size = new global::System.Drawing.Size(360, 20);
			this.textSetObjectName.TabIndex = 225;
			this.textSetObjectName.Text = "";
			this.label33.Location = new global::System.Drawing.Point(8, 248);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(112, 16);
			this.label33.TabIndex = 224;
			this.label33.Text = "TrigObjectName:";
			this.textTrigObjectName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textTrigObjectName.Location = new global::System.Drawing.Point(120, 248);
			this.textTrigObjectName.Name = "textTrigObjectName";
			this.textTrigObjectName.Size = new global::System.Drawing.Size(360, 20);
			this.textTrigObjectName.TabIndex = 223;
			this.textTrigObjectName.Text = "";
			this.labelContainerZ.Enabled = false;
			this.labelContainerZ.Location = new global::System.Drawing.Point(232, 80);
			this.labelContainerZ.Name = "labelContainerZ";
			this.labelContainerZ.Size = new global::System.Drawing.Size(16, 16);
			this.labelContainerZ.TabIndex = 219;
			this.labelContainerZ.Text = "Z:";
			this.labelContainerY.Enabled = false;
			this.labelContainerY.Location = new global::System.Drawing.Point(232, 56);
			this.labelContainerY.Name = "labelContainerY";
			this.labelContainerY.Size = new global::System.Drawing.Size(16, 16);
			this.labelContainerY.TabIndex = 217;
			this.labelContainerY.Text = "Y:";
			this.labelContainerX.Enabled = false;
			this.labelContainerX.Location = new global::System.Drawing.Point(184, 32);
			this.labelContainerX.Name = "labelContainerX";
			this.labelContainerX.Size = new global::System.Drawing.Size(72, 16);
			this.labelContainerX.TabIndex = 215;
			this.labelContainerX.Text = "Container X:";
			this.label32.Location = new global::System.Drawing.Point(8, 32);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(88, 20);
			this.label32.TabIndex = 201;
			this.label32.Text = "StackAmount:";
			this.label31.Location = new global::System.Drawing.Point(8, 56);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(104, 20);
			this.label31.TabIndex = 199;
			this.label31.Text = "TriggerProbability:";
			this.label13.Location = new global::System.Drawing.Point(8, 200);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(112, 16);
			this.label13.TabIndex = 170;
			this.label13.Text = "MobTriggerName:";
			this.textMobTriggerName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMobTriggerName.Location = new global::System.Drawing.Point(120, 200);
			this.textMobTriggerName.Name = "textMobTriggerName";
			this.textMobTriggerName.Size = new global::System.Drawing.Size(360, 20);
			this.textMobTriggerName.TabIndex = 169;
			this.textMobTriggerName.Text = "";
			this.label10.Location = new global::System.Drawing.Point(8, 224);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(112, 20);
			this.label10.TabIndex = 168;
			this.label10.Text = "MobTrigProp:";
			this.textMobTrigProp.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMobTrigProp.Location = new global::System.Drawing.Point(120, 224);
			this.textMobTrigProp.Name = "textMobTrigProp";
			this.textMobTrigProp.Size = new global::System.Drawing.Size(360, 20);
			this.textMobTrigProp.TabIndex = 167;
			this.textMobTrigProp.Text = "";
			this.tabSpawnTypes.Controls.Add(this.groupBox3);
			this.tabSpawnTypes.Controls.Add(this.groupBox2);
			this.tabSpawnTypes.Controls.Add(this.grpSpawnTypes);
			this.tabSpawnTypes.Location = new global::System.Drawing.Point(4, 22);
			this.tabSpawnTypes.Name = "tabSpawnTypes";
			this.tabSpawnTypes.Size = new global::System.Drawing.Size(512, 534);
			this.tabSpawnTypes.TabIndex = 2;
			this.tabSpawnTypes.Text = "SpawnTypes";
			this.groupBox3.Controls.Add(this.tvwSpawnPacks);
			this.groupBox3.Location = new global::System.Drawing.Point(304, 288);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(200, 244);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "All Spawn Packs";
			this.groupBox2.Controls.Add(this.btnUpdateSpawnPacks);
			this.groupBox2.Controls.Add(this.textSpawnPackName);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.clbSpawnPack);
			this.groupBox2.Controls.Add(this.label39);
			this.groupBox2.Controls.Add(this.btnUpdateFromSpawnPack);
			this.groupBox2.Location = new global::System.Drawing.Point(304, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(200, 288);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Current Spawn Pack";
			this.textSpawnPackName.Location = new global::System.Drawing.Point(8, 16);
			this.textSpawnPackName.Name = "textSpawnPackName";
			this.textSpawnPackName.Size = new global::System.Drawing.Size(160, 20);
			this.textSpawnPackName.TabIndex = 16;
			this.textSpawnPackName.Text = "";
			this.label39.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label39.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.label39.Location = new global::System.Drawing.Point(8, 264);
			this.label39.Name = "label39";
			this.label39.Size = new global::System.Drawing.Size(160, 16);
			this.label39.TabIndex = 5;
			this.panel3.Controls.Add(this.splitPanel3);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 0);
			this.panel3.AutoScroll = false;
			this.panel3.MinimumSize = new global::System.Drawing.Size(0, 220);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(900, 374);
			this.panel3.TabIndex = 7;
			this.panel3.Visible = false;
			this.splitPanel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitPanel3.Location = new global::System.Drawing.Point(0, 0);
			this.splitPanel3.Name = "splitPanel3";
			this.splitPanel3.Orientation = global::System.Windows.Forms.Orientation.Vertical;
			this.splitPanel3.Panel1.Controls.Add(this.groupTemplateList);
			this.splitPanel3.Panel2.Controls.Add(this.grpSpawnEntries);
			this.splitPanel3.Panel1MinSize = 200;
			this.splitPanel3.Panel2MinSize = 640;
			this.splitPanel3.Size = new global::System.Drawing.Size(900, 374);
			this.splitPanel3.SplitterDistance = 250;
			this.splitPanel3.SplitterWidth = 6;
			this.splitPanel3.TabIndex = 11;
			this.mcnSpawnPack.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniDeleteType, this.mniDeleteAllTypes });
			this.mcnSpawnPack.Popup += new global::System.EventHandler(this.mcnSpawnPack_Popup);
			this.mniDeleteType.Index = 0;
			this.mniDeleteType.Text = "Delete Type";
			this.mniDeleteType.Click += new global::System.EventHandler(this.mniDeleteType_Click);
			this.mniDeleteAllTypes.Index = 1;
			this.mniDeleteAllTypes.Text = "Delete Alll Types";
			this.mniDeleteAllTypes.Click += new global::System.EventHandler(this.mniDeleteAllTypes_Click);
			this.mcnSpawnPacks.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[] { this.mniDeletePack });
			this.mniDeletePack.Index = 0;
			this.mniDeletePack.Text = "Delete Pack";
			this.mniDeletePack.Click += new global::System.EventHandler(this.mniDeletePack_Click);
			this.openSpawnPacks.FileName = "SpawnPacks.dat";
			this.openSpawnPacks.InitialDirectory = ".";
			this.saveSpawnPacks.FileName = "SpawnPacks.dat";
			this.saveSpawnPacks.InitialDirectory = ".";
			this.exportAllSpawnTypes.FileName = "SpawnTypes.std";
			this.exportAllSpawnTypes.InitialDirectory = ".";
			this.importAllSpawnTypes.FileName = "SpawnTypes.std";
			this.importAllSpawnTypes.InitialDirectory = ".";
			this.importMapFile.Filter = ".map | *.map";
			this.importMSFFile.Filter = ".msf | *.msf";
			base.AutoScale = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(1420, 780);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.pnlControls);
			base.Controls.Add(this.stbMain);
			base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.Menu = this.mainMenu1;
			base.Name = "SpawnEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Spawn Editor 2";
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.SpawnEditor_Closing);
			base.Load += new global::System.EventHandler(this.SpawnEditor_Load);
			base.Resize += new global::System.EventHandler(this.SpawnEditor_Resize);
			((global::System.ComponentModel.ISupportInitialize)(this.axUOMap)).EndInit();
			this.trkZoom.EndInit();
			this.spnMaxCount.EndInit();
			this.spnHomeRange.EndInit();
			this.spnMinDelay.EndInit();
			this.spnTeam.EndInit();
			this.spnMaxDelay.EndInit();
			this.spnSpawnRange.EndInit();
			this.spnProximityRange.EndInit();
			this.spnMinRefract.EndInit();
			this.spnTODStart.EndInit();
			this.spnMaxRefract.EndInit();
			this.spnDespawn.EndInit();
			this.spnTODEnd.EndInit();
			this.spnDuration.EndInit();
			this.spnProximitySnd.EndInit();
			this.spnKillReset.EndInit();
			this.spnTriggerProbability.EndInit();
			this.spnStackAmount.EndInit();
			this.spnContainerX.EndInit();
			this.spnContainerY.EndInit();
			this.spnContainerZ.EndInit();
			this.pnlControls.ResumeLayout(false);
			this.tabControl3.ResumeLayout(false);
			this.tabMapSettings.ResumeLayout(false);
			this.grpMapControl.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.grpSpawnList.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.groupTemplateList.ResumeLayout(false);
			this.grpSpawnTypes.ResumeLayout(false);
			this.grpSpawnEntries.ResumeLayout(false);
			this.entryPer8.EndInit();
			this.entryPer7.EndInit();
			this.entryPer6.EndInit();
			this.entryPer5.EndInit();
			this.entryPer4.EndInit();
			this.entryPer3.EndInit();
			this.entryPer2.EndInit();
			this.entryPer1.EndInit();
			this.entryMax8.EndInit();
			this.entryMax7.EndInit();
			this.entryMax6.EndInit();
			this.entryMax5.EndInit();
			this.entryMax4.EndInit();
			this.entryMax3.EndInit();
			this.entryMax2.EndInit();
			this.entryMax1.EndInit();
			this.grpSpawnEdit.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabBasic.ResumeLayout(false);
			this.tabAdvanced.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabSpawnTypes.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.splitContainerRightDetails.Panel1.ResumeLayout(false);
			this.splitContainerRightDetails.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)(this.splitContainerRightDetails)).EndInit();
			this.splitContainerRightDetails.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.splitPanel3.Panel1.ResumeLayout(false);
			this.splitPanel3.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
			this.splitPanel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000124 RID: 292
		internal global::SpawnEditor2.UOMapControl axUOMap;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.ToolTip ttpSpawnInfo;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.Panel pnlControls;

		// Token: 0x04000127 RID: 295
		internal global::System.Windows.Forms.TrackBar trkZoom;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.CheckBox chkDrawStatics;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.GroupBox grpMapControl;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.CheckedListBox clbRunUOTypes;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Label lblTotalTypesLoaded;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.RadioButton radShowAll;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.RadioButton radShowItemsOnly;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.RadioButton radShowMobilesOnly;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label lblTotalSpawn;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Button btnLoadSpawn;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Button btnSaveSpawn;

		// Token: 0x04000132 RID: 306
		internal global::System.Windows.Forms.TreeView tvwSpawnPoints;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Button btnResetTypes;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Button btnMergeSpawn;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.OpenFileDialog ofdLoadFile;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.SaveFileDialog sfdSaveFile;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.ContextMenu mncSpawns;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.GroupBox grpSpawnTypes;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.GroupBox grpSpawnList;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.StatusBar stbMain;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.MenuItem menuItem3;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.MenuItem mniDeleteAllSpawns;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.MenuItem mniDeleteSpawn;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.CheckBox chkShowMapTip;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.CheckBox chkShowSpawns;

		// Token: 0x04000140 RID: 320
		internal global::System.Windows.Forms.ComboBox cbxMap;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.CheckBox chkSyncUO;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.ContextMenu mncLoad;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.MenuItem mniForceLoad;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.ContextMenu mncMerge;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.MenuItem mniForceMerge;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.GroupBox grpSpawnEntries;

		// Token: 0x04000147 RID: 327
		internal global::System.Windows.Forms.GroupBox grpSpawnEdit;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.CheckBox chkHomeRangeIsRelative;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.Button btnMove;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.Button btnRestoreSpawnDefaults;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.Button btnDeleteSpawn;

		// Token: 0x0400014C RID: 332
		internal global::System.Windows.Forms.Button btnUpdateSpawn;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.Label lblMaxDelay;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.CheckBox chkRunning;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.Label lblHomeRange;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.NumericUpDown spnMaxCount;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.TextBox txtName;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.NumericUpDown spnHomeRange;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.Label lblTeam;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.Label lblMaxCount;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.NumericUpDown spnMinDelay;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.NumericUpDown spnTeam;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.CheckBox chkGroup;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.NumericUpDown spnMaxDelay;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.Label lblMinDelay;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.NumericUpDown entryMax1;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.VScrollBar vScrollBar1;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.MainMenu mainMenu1;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.MenuItem menuItem8;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.MenuItem menuItem9;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Label label15;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.Label label17;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Label label18;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.Label label21;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.Label label24;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.Panel panelRight;
		private global::System.Windows.Forms.SplitContainer splitPanel3;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.SplitContainer splitContainerRightDetails;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.ContextMenu editEntryMenu1;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Label label25;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Label label27;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.Label label28;

		// Token: 0x0400017C RID: 380
		internal global::System.Windows.Forms.NumericUpDown spnSpawnRange;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.NumericUpDown spnProximityRange;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.CheckBox chkGameTOD;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.CheckBox chkRealTOD;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.CheckBox chkAllowGhost;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.CheckBox chkSmartSpawning;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.CheckBox chkSequentialSpawn;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.CheckBox chkSpawnOnTrigger;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.NumericUpDown spnDuration;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.TextBox textSkillTrigger;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.TextBox textSpeechTrigger;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.TextBox textProximityMsg;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.TextBox textPlayerTrigProp;

		// Token: 0x04000189 RID: 393
		private global::System.Windows.Forms.TextBox textNoTriggerOnCarried;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.TextBox textTriggerOnCarried;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.TextBox textTrigObjectProp;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.NumericUpDown spnMinRefract;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.NumericUpDown spnTODStart;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.NumericUpDown spnMaxRefract;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.NumericUpDown spnDespawn;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.NumericUpDown spnTODEnd;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.TextBox entryMaxD8;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.TextBox entryMaxD7;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.TextBox entryMaxD6;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.TextBox entryMaxD5;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.TextBox entryMaxD4;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.TextBox entryMaxD3;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.TextBox entryMaxD2;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.TextBox entryMaxD1;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.TextBox entryMinD8;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.TextBox entryMinD7;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.TextBox entryMinD6;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.TextBox entryMinD5;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.TextBox entryMinD4;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.TextBox entryMinD3;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.TextBox entryMinD2;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.TextBox entryMinD1;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.TextBox entryKills8;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.TextBox entryKills7;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.TextBox entryKills6;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.TextBox entryKills5;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.TextBox entryKills4;

		// Token: 0x040001A6 RID: 422
		private global::System.Windows.Forms.TextBox entryKills3;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.TextBox entryKills2;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.TextBox entryKills1;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.TextBox entryReset8;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.TextBox entryReset7;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.TextBox entryReset6;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.TextBox entryReset5;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.TextBox entryReset4;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.TextBox entryReset3;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.TextBox entryReset2;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.TextBox entryReset1;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.TextBox entryTo8;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.TextBox entrySub8;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.CheckBox chkRK8;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.NumericUpDown entryMax8;

		// Token: 0x040001B5 RID: 437
		private global::System.Windows.Forms.Button btnEntryEdit8;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.TextBox entryText8;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.CheckBox chkClr8;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.TextBox entryTo7;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.TextBox entrySub7;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.CheckBox chkRK7;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.NumericUpDown entryMax7;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.Button btnEntryEdit7;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.TextBox entryText7;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.CheckBox chkClr7;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.TextBox entryTo6;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.TextBox entrySub6;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.CheckBox chkRK6;

		// Token: 0x040001C2 RID: 450
		private global::System.Windows.Forms.NumericUpDown entryMax6;

		// Token: 0x040001C3 RID: 451
		private global::System.Windows.Forms.Button btnEntryEdit6;

		// Token: 0x040001C4 RID: 452
		private global::System.Windows.Forms.TextBox entryText6;

		// Token: 0x040001C5 RID: 453
		private global::System.Windows.Forms.CheckBox chkClr6;

		// Token: 0x040001C6 RID: 454
		private global::System.Windows.Forms.TextBox entryTo5;

		// Token: 0x040001C7 RID: 455
		private global::System.Windows.Forms.TextBox entrySub5;

		// Token: 0x040001C8 RID: 456
		private global::System.Windows.Forms.CheckBox chkRK5;

		// Token: 0x040001C9 RID: 457
		private global::System.Windows.Forms.NumericUpDown entryMax5;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.Button btnEntryEdit5;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.TextBox entryText5;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.CheckBox chkClr5;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.TextBox entryTo4;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.TextBox entrySub4;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.CheckBox chkRK4;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.NumericUpDown entryMax4;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.Button btnEntryEdit4;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.TextBox entryText4;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.CheckBox chkClr4;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.TextBox entryTo3;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.TextBox entrySub3;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.CheckBox chkRK3;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.NumericUpDown entryMax3;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.Button btnEntryEdit3;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.TextBox entryText3;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.CheckBox chkClr3;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.TextBox entryTo2;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.TextBox entrySub2;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.CheckBox chkRK2;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.NumericUpDown entryMax2;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.Button btnEntryEdit2;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.TextBox entryText2;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.CheckBox chkClr2;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.TextBox entryTo1;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.TextBox entrySub1;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.CheckBox chkRK1;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.Button btnEntryEdit1;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.TextBox entryText1;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.CheckBox chkClr1;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.NumericUpDown spnProximitySnd;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.NumericUpDown spnKillReset;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.GroupBox groupTemplateList;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.TreeView tvwTemplates;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Label label29;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.Button btnLoadTemplate;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.Button btnMergeTemplate;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.Button btnSaveTemplate;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.CheckBox chkDetails;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.Button btnGo;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.CheckBox chkInContainer;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.CheckBox chkTracking;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.TextBox textMobTriggerName;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.TextBox textMobTrigProp;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.NumericUpDown spnTriggerProbability;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.Label label32;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.NumericUpDown spnStackAmount;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.Label labelContainerZ;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.Label labelContainerY;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.CheckBox chkExternalTriggering;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.CheckBox chkAllowNPC;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.CheckBox chkTickReset;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.Label label33;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.Label label34;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.Label label35;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.Label label36;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.Label label37;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.TextBox textRegionName;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.TextBox textWayPoint;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.TextBox textConfigFile;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.TextBox textTrigObjectName;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.TextBox textSetObjectName;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.Label labelContainerX;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.NumericUpDown spnContainerX;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.NumericUpDown spnContainerY;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.NumericUpDown spnContainerZ;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.ContextMenu deleteEntry;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.MenuItem menuItem1;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.MenuItem menuItem2;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.MenuItem menuItem4;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.CheckBox chkLockSpawn;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.CheckBox chkSnapRegion;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.TabControl tabControl2;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.TabPage tabPage5;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.TreeView treeRegionView;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.TreeView treeGoView;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.HelpProvider helpProvider1;

		// Token: 0x0400021C RID: 540
		internal global::System.Windows.Forms.CheckBox checkSpawnFilter;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.TabPage tabBasic;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.TabPage tabAdvanced;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.TabPage tabSpawnTypes;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Label label39;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.TextBox textSpawnPackName;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.CheckedListBox clbSpawnPack;

		// Token: 0x04000226 RID: 550
		internal global::System.Windows.Forms.Button btnAddToSpawnPack;

		// Token: 0x04000227 RID: 551
		internal global::System.Windows.Forms.Button btnUpdateFromSpawnPack;

		// Token: 0x04000228 RID: 552
		internal global::System.Windows.Forms.Button btnUpdateSpawnPacks;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.TreeView tvwSpawnPacks;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.ContextMenu mcnSpawnPack;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.MenuItem mniDeleteType;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.MenuItem mniDeleteAllTypes;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.ContextMenu mcnSpawnPacks;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.MenuItem mniDeletePack;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.MenuItem menuItem5;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.MenuItem menuItem6;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.MenuItem menuItem7;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.OpenFileDialog openSpawnPacks;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.SaveFileDialog saveSpawnPacks;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.MenuItem menuItem10;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.MenuItem menuItem11;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.SaveFileDialog exportAllSpawnTypes;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.OpenFileDialog importAllSpawnTypes;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.ComboBox cbxShade;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.CheckBox chkShade;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.MenuItem menuItem12;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.OpenFileDialog importMapFile;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.MenuItem menuItem13;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.OpenFileDialog importMSFFile;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.MenuItem menuItem14;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.MenuItem menuItem16;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.MenuItem menuItem18;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.MenuItem mniAlwaysOnTop;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.MenuItem menuItem15;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.MenuItem menuItem17;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.TabControl tabControl3;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.TabPage tabMapSettings;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.TextBox txtNotes;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.Label label44;

		// Token: 0x04000248 RID: 584
		internal global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x04000249 RID: 585
		internal global::System.Windows.Forms.Label lblTransferStatus;

		// Token: 0x0400024A RID: 586
		internal global::System.Windows.Forms.Label lblTrkMax;

		// Token: 0x0400024B RID: 587
		internal global::System.Windows.Forms.Label lblTrkMin;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.Button btnSendSpawn;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.MenuItem mniUnloadSpawners;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.MenuItem menuItem19;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.MenuItem menuItem20;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.MenuItem menuItem21;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.Button btnSendSingleSpawner;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.ContextMenu unloadSpawners;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.ContextMenu unloadSingleSpawner;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.MenuItem menuItem23;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.MenuItem mniUnloadSingleSpawner;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.MenuItem menuItem22;

		// Token: 0x04000257 RID: 599
		internal global::System.Windows.Forms.MenuItem mniDeleteInSelectionWindow;

		// Token: 0x04000258 RID: 600
		internal global::System.Windows.Forms.MenuItem mniDeleteNotSelected;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.ContextMenu highlightDetail;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.MenuItem menuItem24;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.MenuItem menuItem25;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.MenuItem mniToolbarDeleteAllSpawns;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.MenuItem mniDisplayFilterSettings;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.Button btnFilterSettings;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.MenuItem mniDeleteAllFiltered;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.MenuItem mniDeleteAllUnfiltered;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.MenuItem mniModifyInSelectionWindow;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.Label label30;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.NumericUpDown entryPer1;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.NumericUpDown entryPer2;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.NumericUpDown entryPer3;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.NumericUpDown entryPer4;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.NumericUpDown entryPer5;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.NumericUpDown entryPer6;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.NumericUpDown entryPer7;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.NumericUpDown entryPer8;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.MenuItem mniModifiedUnfiltered;

		// Token: 0x0400026C RID: 620
		private global::System.ComponentModel.IContainer components;
	}
}
