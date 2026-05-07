using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Server.Engines.XmlSpawner2;
using SpawnEditor2.Forms;
using Ultima;

namespace SpawnEditor2
{
	// Token: 0x02000014 RID: 20
	public partial class SpawnEditor : Form
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00009870 File Offset: 0x00007A70
		public bool SpawnLocationLocked
		{
			get
			{
				return this.chkLockSpawn.Checked;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00009880 File Offset: 0x00007A80
		public SpawnEditor()
		{
			SpawnEditor.Debug("");
			SpawnEditor.Debug("=======================================");
			SpawnEditor.Debug("Starting");
			this.InitializeMapCenters();
			this.InitializeComponent();
			SpawnEditor.Debug("Initialized");
			this.SmallWindow();
			SpawnEditor.Debug("WindowConfigured");
			this._CfgDialog = new Configure(this);
			SpawnEditor.Debug("ConfigurationDialog");
			this._TransferDialog = new TransferServerSettings(this);
			SpawnEditor.Debug("TransferDialog");
			this._SpawnerFilters = new SpawnerFilters(this);
			SpawnEditor.Debug("SpawnerFilters");
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00009994 File Offset: 0x00007B94
		public static void Debug(string msg)
		{
			if (!SpawnEditor._Debug)
			{
				return;
			}
			try
			{
				using (StreamWriter streamWriter = new StreamWriter("debug.log", true))
				{
					streamWriter.WriteLine("{0}: {1}", DateTime.Now, msg);
				}
			}
			catch
			{
			}
		}

		public static void LogWarning(string msg)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter("spawneditor.log", true))
				{
					sw.WriteLine("{0} [WARN]: {1}", DateTime.Now, msg);
				}
			}
			catch { }
		}

		public static void LogError(string msg)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter("spawneditor.log", true))
				{
					sw.WriteLine("{0} [ERROR]: {1}", DateTime.Now, msg);
				}
			}
			catch { }
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000099FC File Offset: 0x00007BFC
		private void InitializeMapCenters()
		{
			this.MapLoc[1] = new MapLocation();
			this.MapLoc[1].X = 3072;
			this.MapLoc[1].Y = 2048;
			this.MapLoc[0] = new MapLocation();
			this.MapLoc[0].X = 3072;
			this.MapLoc[0].Y = 2048;
			this.MapLoc[2] = new MapLocation();
			this.MapLoc[2].X = 1150;
			this.MapLoc[2].Y = 800;
			this.MapLoc[3] = new MapLocation();
			this.MapLoc[3].X = 1280;
			this.MapLoc[3].Y = 1024;
			this.MapLoc[4] = new MapLocation();
			this.MapLoc[4].X = 700;
			this.MapLoc[4].Y = 700;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00009B00 File Offset: 0x00007D00
		public static Type FindRunUOType(string name)
		{
			if (name == null)
			{
				return null;
			}
			Type type = null;
			string str = name.ToLower();
			if (SpawnEditor.typeHash.Contains(str))
			{
				return (Type)SpawnEditor.typeHash[str];
			}
			foreach (object obj in SpawnEditor.AssemblyList)
			{
				Type[] types = ((Assembly)obj).GetTypes();
				if (types != null)
				{
					for (int index = 0; index < types.Length; index++)
					{
						if (types[index].Name.ToLower().Equals(str))
						{
							type = types[index];
							break;
						}
					}
				}
				if (type != null)
				{
					break;
				}
			}
			SpawnEditor.typeHash.Add(str, type);
			return type;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public string ExceptionMessage(Exception se)
		{
			if (se == null)
			{
				return null;
			}
			if (this._ExtendedDiagnostics)
			{
				return se.ToString();
			}
			return se.Message;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009BEC File Offset: 0x00007DEC
		internal void AssignCenter(short X, short Y, short facet)
		{
			this.MapLoc[(int)facet].X = (int)X;
			this.MapLoc[(int)facet].Y = (int)Y;
			this.axUOMap.SetCenter(X, Y);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00009C18 File Offset: 0x00007E18
		internal void EnableSelectionWindowOption(bool enabled)
		{
			if (enabled)
			{
				this._TransferDialog.chkSpawnerWithinSelectionWindow.Checked = true;
				this._TransferDialog.chkSpawnerWithinSelectionWindow.Enabled = true;
				this.mniDeleteInSelectionWindow.Enabled = true;
				this.mniDeleteNotSelected.Enabled = true;
				this.mniModifyInSelectionWindow.Enabled = true;
				return;
			}
			this._TransferDialog.chkSpawnerWithinSelectionWindow.Checked = false;
			this._TransferDialog.chkSpawnerWithinSelectionWindow.Enabled = false;
			this.mniDeleteInSelectionWindow.Enabled = false;
			this.mniDeleteNotSelected.Enabled = false;
			this.mniModifyInSelectionWindow.Enabled = false;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00009CB8 File Offset: 0x00007EB8
		private void SpawnEditor_Load(object sender, EventArgs e)
		{
			SpawnEditor.Debug("Loading");
			this.StartingDirectory = Directory.GetCurrentDirectory();
			if (!this._CfgDialog.IsValidConfiguration)
			{
				SpawnEditor.Debug("OpeningConfiguration");
				this._CfgDialog.ShowDialog();
				if (!this._CfgDialog.IsValidConfiguration)
				{
					SpawnEditor.Debug("Invalid configuration after Configure dialog -> Exiting");
					MessageBox.Show(this, "Spawn Editor has not been configured properly." + Environment.NewLine + "Exiting...", "Configuration Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Application.Exit();
				}
			}
			try
			{
				this.cbxShade.SelectedIndex = 0;
				foreach (object obj in Enum.GetValues(typeof(WorldMap)))
				{
					WorldMap worldMap = (WorldMap)obj;
					if (worldMap != WorldMap.Internal)
					{
						this.cbxMap.Items.Add(worldMap);
					}
				}
				string mulPath = this._CfgDialog.CfgMulPathValue;
				if (string.IsNullOrEmpty(mulPath) || !Directory.Exists(mulPath))
				{
					mulPath = Path.GetDirectoryName(this._CfgDialog.CfgUoClientPathValue);
				}
				string setPath = mulPath.TrimEnd('\\') + "\\";
				bool hasMul = File.Exists(Path.Combine(setPath, "map0.mul"));
				SpawnEditor.Debug("SetClientPath = " + setPath + " | map0.mul exists: " + hasMul);
				this.axUOMap.SetClientPath(setPath);
				this.axUOMap.ZoomLevel = this._CfgDialog.CfgZoomLevelValue;
				this.trkZoom.Value = (int)this.axUOMap.ZoomLevel;
				try
				{
					SpawnEditor.Debug("CfgRunUoPathValue = " + (this._CfgDialog.CfgRunUoPathValue ?? "<null>"));
				}
				catch
				{
				}
				try
				{
					SpawnEditor.Debug("CfgUoClientPathValue = " + (this._CfgDialog.CfgUoClientPathValue ?? "<null>"));
				}
				catch
				{
				}
				SpawnEditor.Debug("Map control ready, refreshing spawn points.");
				this.RefreshSpawnPoints();
				ArrayList arrayList = new ArrayList();
				string directoryName = Path.GetDirectoryName(this._CfgDialog.CfgRunUoPathValue);
				this.LoadCustomAssemblies(directoryName);
				if (File.Exists(directoryName + "\\Scripts\\Output\\Scripts.dll"))
				{
					Assembly assembly2 = Assembly.LoadFrom(directoryName + "\\Scripts\\Output\\Scripts.dll");
					if (assembly2 != null)
					{
						arrayList.AddRange(assembly2.GetTypes());
						SpawnEditor.AssemblyList.Add(assembly2);
					}
				}
				if (File.Exists(directoryName + "\\Scripts\\Output\\Scripts.CS.dll"))
				{
					Assembly assembly3 = Assembly.LoadFrom(directoryName + "\\Scripts\\Output\\Scripts.CS.dll");
					if (assembly3 != null)
					{
						arrayList.AddRange(assembly3.GetTypes());
						SpawnEditor.AssemblyList.Add(assembly3);
					}
				}
				if (File.Exists(directoryName + "\\Scripts\\Output\\Scripts.VB.dll"))
				{
					Assembly assembly4 = Assembly.LoadFrom(directoryName + "\\Scripts\\Output\\Scripts.VB.dll");
					if (assembly4 != null)
					{
						arrayList.AddRange(assembly4.GetTypes());
						SpawnEditor.AssemblyList.Add(assembly4);
					}
				}
				this._RunUOScriptTypes = (Type[])arrayList.ToArray(typeof(Type));
				this.LoadTypes();
				this.LoadSpawnPacks();
				this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.LoadDefaultSpawnValues();
				if (Directory.Exists(Path.GetDirectoryName(this._CfgDialog.CfgRunUoPathValue)))
				{
					this.ofdLoadFile.InitialDirectory = this._CfgDialog.CfgRunUoPathValue;
					this.sfdSaveFile.InitialDirectory = this._CfgDialog.CfgRunUoPathValue;
					this.FillRegionTree();
					this.treeRegionView.Refresh();
					this.FillGoTree(Path.GetDirectoryName(this._CfgDialog.CfgRunUoPathValue));
					this.treeGoView.Refresh();
				}
				this.cbxMap.SelectedIndex = (int)this._CfgDialog.CfgStartingMapValue;
				this.chkDrawStatics.Checked = this._CfgDialog.CfgStartingStaticsValue;
				this.mniAlwaysOnTop.Checked = this._CfgDialog.CfgStartingOnTopValue;
				base.TopMost = this.mniAlwaysOnTop.Checked;
				if (this._CfgDialog.CfgStartingXValue >= 0 && this._CfgDialog.CfgStartingYValue >= 0)
				{
					base.Location = new Point(this._CfgDialog.CfgStartingXValue, this._CfgDialog.CfgStartingYValue);
				}
				if (this._CfgDialog.CfgStartingWidthValue >= 0 && this._CfgDialog.CfgStartingHeightValue >= 0)
				{
					base.Size = new Size(this._CfgDialog.CfgStartingWidthValue, this._CfgDialog.CfgStartingHeightValue);
				}
				this.chkDetails.Checked = this._CfgDialog.CfgStartingDetailsValue;
				this._CfgDialog.ConfigureTransferServer();
			}
			catch (Exception ex8)
			{
				SpawnEditor.Debug("SpawnEditor_Load exception: " + ex8.ToString());
				MessageBox.Show(this, "Error loading the required RunUO executables. Please check that the paths specified in Setup are valid." + Environment.NewLine + ex8.ToString(), "Configuration Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A464 File Offset: 0x00008664
		private void LoadCustomAssemblies(string rootPath)
		{
			if (rootPath == null || rootPath.Length == 0)
			{
				return;
			}
			string path = Path.Combine(rootPath, "Data/Assemblies.cfg");
			if (!File.Exists(path))
			{
				return;
			}
			try
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					string path2;
					while ((path2 = streamReader.ReadLine()) != null)
					{
						path2.Trim();
						if (path2 != null && !(path2.ToLower() == "ultima.dll") && !(path2.ToLower() == "uomaplib.dll") && !(path2.ToLower() == "axuomaplib.dll"))
						{
							string str = Path.Combine(rootPath, path2);
							if (File.Exists(str))
							{
								Assembly.LoadFrom(str);
							}
						}
					}
					streamReader.Close();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A530 File Offset: 0x00008730
		private void FillGoTree(string dirpath)
		{
			LocationTree ltree = new LocationTree(dirpath, "felucca.xml", WorldMap.Felucca);
			LocationTree ltree2 = new LocationTree(dirpath, "trammel.xml", WorldMap.Trammel);
			LocationTree ltree3 = new LocationTree(dirpath, "ilshenar.xml", WorldMap.Ilshenar);
			LocationTree ltree4 = new LocationTree(dirpath, "malas.xml", WorldMap.Malas);
			LocationTree ltree5 = new LocationTree(dirpath, "tokuno.xml", WorldMap.Tokuno);
			this.treeGoView.Nodes.Add(new LocationNode(ltree2));
			this.treeGoView.Nodes.Add(new LocationNode(ltree));
			this.treeGoView.Nodes.Add(new LocationNode(ltree3));
			this.treeGoView.Nodes.Add(new LocationNode(ltree4));
			this.treeGoView.Nodes.Add(new LocationNode(ltree5));
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A5F4 File Offset: 0x000087F4
		private void LoadDefaultSpawnValues()
		{
			this.txtName.Text = this._CfgDialog.CfgSpawnNameValue + this.tvwSpawnPoints.Nodes.Count.ToString();
			this.spnHomeRange.Value = this._CfgDialog.CfgSpawnHomeRangeValue;
			this.spnMaxCount.Value = this._CfgDialog.CfgSpawnMaxCountValue;
			this.spnMinDelay.Value = this._CfgDialog.CfgSpawnMinDelayValue;
			this.spnMaxDelay.Value = this._CfgDialog.CfgSpawnMaxDelayValue;
			this.spnTeam.Value = this._CfgDialog.CfgSpawnTeamValue;
			this.chkGroup.Checked = this._CfgDialog.CfgSpawnGroupValue;
			this.chkRunning.Checked = this._CfgDialog.CfgSpawnRunningValue;
			this.chkHomeRangeIsRelative.Checked = this._CfgDialog.CfgSpawnRelativeHomeValue;
			this.spnSpawnRange.Value = -1m;
			this.spnProximityRange.Value = -1m;
			this.spnDuration.Value = 0m;
			this.spnDespawn.Value = 0m;
			this.spnMinRefract.Value = 0m;
			this.spnMaxRefract.Value = 0m;
			this.spnTODStart.Value = 0m;
			this.spnTODEnd.Value = 0m;
			this.spnKillReset.Value = 1m;
			this.spnProximitySnd.Value = 500m;
			this.chkAllowGhost.Checked = false;
			this.chkSpawnOnTrigger.Checked = false;
			this.chkSequentialSpawn.Checked = false;
			this.chkSmartSpawning.Checked = false;
			this.chkInContainer.Checked = false;
			this.chkRealTOD.Checked = true;
			this.chkGameTOD.Checked = false;
			this.textSkillTrigger.Text = null;
			this.textSpeechTrigger.Text = null;
			this.textProximityMsg.Text = null;
			this.textMobTriggerName.Text = null;
			this.textMobTrigProp.Text = null;
			this.textPlayerTrigProp.Text = null;
			this.textTrigObjectProp.Text = null;
			this.textTriggerOnCarried.Text = null;
			this.textNoTriggerOnCarried.Text = null;
			this.spnTriggerProbability.Value = 1m;
			this.spnStackAmount.Value = 1m;
			this.spnContainerX.Value = 0m;
			this.spnContainerY.Value = 0m;
			this.spnContainerZ.Value = 0m;
			this.chkExternalTriggering.Checked = false;
			this.textTrigObjectName.Text = null;
			this.textSetObjectName.Text = null;
			this.textRegionName.Text = null;
			this.textConfigFile.Text = null;
			this.textWayPoint.Text = null;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00015C80 File Offset: 0x00013E80
		[STAThread]
		private static void Main(string[] args)
		{
			for (int index = 0; index < args.Length; index++)
			{
				if (args[index].ToLower() == "-debug")
				{
					SpawnEditor._Debug = true;
				}
			}
			Application.ThreadException += new SpawnEditor.CustomExceptionHandler().OnThreadException;
			Application.Run(new SpawnEditor());
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00015CD4 File Offset: 0x00013ED4
		private void ClearEntries()
		{
			this.entryText1.Text = null;
			this.entryText2.Text = null;
			this.entryText3.Text = null;
			this.entryText4.Text = null;
			this.entryText5.Text = null;
			this.entryText6.Text = null;
			this.entryText7.Text = null;
			this.entryText8.Text = null;
			this.entryMax1.Value = 0m;
			this.entryMax2.Value = 0m;
			this.entryMax3.Value = 0m;
			this.entryMax4.Value = 0m;
			this.entryMax5.Value = 0m;
			this.entryMax6.Value = 0m;
			this.entryMax7.Value = 0m;
			this.entryMax8.Value = 0m;
			this.entryPer1.Value = 0m;
			this.entryPer2.Value = 0m;
			this.entryPer3.Value = 0m;
			this.entryPer4.Value = 0m;
			this.entryPer5.Value = 0m;
			this.entryPer6.Value = 0m;
			this.entryPer7.Value = 0m;
			this.entryPer8.Value = 0m;
			this.entrySub1.Text = null;
			this.entrySub2.Text = null;
			this.entrySub3.Text = null;
			this.entrySub4.Text = null;
			this.entrySub5.Text = null;
			this.entrySub6.Text = null;
			this.entrySub7.Text = null;
			this.entrySub8.Text = null;
			this.entryReset1.Text = null;
			this.entryReset2.Text = null;
			this.entryReset3.Text = null;
			this.entryReset4.Text = null;
			this.entryReset5.Text = null;
			this.entryReset6.Text = null;
			this.entryReset7.Text = null;
			this.entryReset8.Text = null;
			this.entryTo1.Text = null;
			this.entryTo2.Text = null;
			this.entryTo3.Text = null;
			this.entryTo4.Text = null;
			this.entryTo5.Text = null;
			this.entryTo6.Text = null;
			this.entryTo7.Text = null;
			this.entryTo8.Text = null;
			this.entryKills1.Text = null;
			this.entryKills2.Text = null;
			this.entryKills3.Text = null;
			this.entryKills4.Text = null;
			this.entryKills5.Text = null;
			this.entryKills6.Text = null;
			this.entryKills7.Text = null;
			this.entryKills8.Text = null;
			this.entryMinD1.Text = null;
			this.entryMinD2.Text = null;
			this.entryMinD3.Text = null;
			this.entryMinD4.Text = null;
			this.entryMinD5.Text = null;
			this.entryMinD6.Text = null;
			this.entryMinD7.Text = null;
			this.entryMinD8.Text = null;
			this.entryMaxD1.Text = null;
			this.entryMaxD2.Text = null;
			this.entryMaxD3.Text = null;
			this.entryMaxD4.Text = null;
			this.entryMaxD5.Text = null;
			this.entryMaxD6.Text = null;
			this.entryMaxD7.Text = null;
			this.entryMaxD8.Text = null;
			this.chkRK1.Checked = false;
			this.chkRK2.Checked = false;
			this.chkRK3.Checked = false;
			this.chkRK4.Checked = false;
			this.chkRK5.Checked = false;
			this.chkRK6.Checked = false;
			this.chkRK7.Checked = false;
			this.chkRK8.Checked = false;
			this.chkClr1.Checked = false;
			this.chkClr2.Checked = false;
			this.chkClr3.Checked = false;
			this.chkClr4.Checked = false;
			this.chkClr5.Checked = false;
			this.chkClr6.Checked = false;
			this.chkClr7.Checked = false;
			this.chkClr8.Checked = false;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00016151 File Offset: 0x00014351
		private void UpdateSpawnNode()
		{
			if (this.SelectedSpawnNode != null)
			{
				this.SelectedSpawnNode.UpdateNode();
			}
			this.tvwSpawnPoints.Update();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00016174 File Offset: 0x00014374
		private string TrimmedString(string val)
		{
			if (val == null)
			{
				return null;
			}
			string str = val.Trim();
			if (str != null && str.Length == 0)
			{
				str = null;
			}
			return str;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001619C File Offset: 0x0001439C
		private void UpdateSpawnDetails(SpawnPoint Spawn)
		{
			if (Spawn == null)
			{
				return;
			}
			this.txtName.Text = this.txtName.Text.Trim();
			if (this.txtName.Text.Length == 0)
			{
				MessageBox.Show(this, "You must specify a name for the spawner!", "Spawn Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Spawn.SpawnName = this.txtName.Text;
			Spawn.SpawnHomeRangeIsRelative = this.chkHomeRangeIsRelative.Checked;
			Spawn.SpawnHomeRange = (int)this.spnHomeRange.Value;
			Spawn.SpawnIsGroup = this.chkGroup.Checked;
			Spawn.SpawnIsRunning = this.chkRunning.Checked;
			Spawn.SpawnMaxCount = (int)this.spnMaxCount.Value;
			Spawn.SpawnMaxDelay = (double)this.spnMaxDelay.Value;
			Spawn.SpawnMinDelay = (double)this.spnMinDelay.Value;
			Spawn.SpawnTeam = (int)this.spnTeam.Value;
			Spawn.SpawnSpawnRange = (int)this.spnSpawnRange.Value;
			Spawn.SpawnProximityRange = (int)this.spnProximityRange.Value;
			Spawn.SpawnDuration = (double)this.spnDuration.Value;
			Spawn.SpawnDespawn = (double)this.spnDespawn.Value;
			Spawn.SpawnMinRefract = (double)this.spnMinRefract.Value;
			Spawn.SpawnMaxRefract = (double)this.spnMaxRefract.Value;
			Spawn.SpawnTODStart = (double)this.spnTODStart.Value;
			Spawn.SpawnTODEnd = (double)this.spnTODEnd.Value;
			Spawn.SpawnKillReset = (int)this.spnKillReset.Value;
			Spawn.SpawnProximitySnd = (int)this.spnProximitySnd.Value;
			Spawn.SpawnAllowGhost = this.chkAllowGhost.Checked;
			Spawn.SpawnSpawnOnTrigger = this.chkSpawnOnTrigger.Checked;
			Spawn.SpawnSequentialSpawn = ((!this.chkSequentialSpawn.Checked) ? (-1) : 0);
			Spawn.SpawnSmartSpawning = this.chkSmartSpawning.Checked;
			Spawn.SpawnTODMode = ((!this.chkRealTOD.Checked) ? 1 : 0);
			Spawn.SpawnInContainer = this.chkInContainer.Checked;
			Spawn.SpawnSkillTrigger = this.TrimmedString(this.textSkillTrigger.Text);
			Spawn.SpawnSpeechTrigger = this.TrimmedString(this.textSpeechTrigger.Text);
			Spawn.SpawnProximityMsg = this.TrimmedString(this.textProximityMsg.Text);
			Spawn.SpawnMobTriggerName = this.TrimmedString(this.textMobTriggerName.Text);
			Spawn.SpawnMobTrigProp = this.TrimmedString(this.textMobTrigProp.Text);
			Spawn.SpawnPlayerTrigProp = this.TrimmedString(this.textPlayerTrigProp.Text);
			Spawn.SpawnTrigObjectProp = this.TrimmedString(this.textTrigObjectProp.Text);
			Spawn.SpawnTriggerOnCarried = this.TrimmedString(this.textTriggerOnCarried.Text);
			Spawn.SpawnNoTriggerOnCarried = this.TrimmedString(this.textNoTriggerOnCarried.Text);
			Spawn.SpawnTriggerProbability = (double)this.spnTriggerProbability.Value;
			Spawn.SpawnStackAmount = (int)this.spnStackAmount.Value;
			Spawn.SpawnNotes = this.txtNotes.Text;
			Spawn.SpawnContainerX = (int)this.spnContainerX.Value;
			Spawn.SpawnContainerY = (int)this.spnContainerY.Value;
			Spawn.SpawnContainerZ = (int)this.spnContainerZ.Value;
			Spawn.SpawnExternalTriggering = this.chkExternalTriggering.Checked;
			Spawn.SpawnObjectPropertyItemName = this.TrimmedString(this.textTrigObjectName.Text);
			Spawn.SpawnSetPropertyItemName = this.TrimmedString(this.textSetObjectName.Text);
			Spawn.SpawnRegionName = this.TrimmedString(this.textRegionName.Text);
			Spawn.SpawnConfigFile = this.TrimmedString(this.textConfigFile.Text);
			Spawn.SpawnWaypoint = this.TrimmedString(this.textWayPoint.Text);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000165C8 File Offset: 0x000147C8
		private int RandomColor(int val)
		{
			Random random = new Random(339);
			int num = 0;
			for (int index = 0; index < val; index++)
			{
				num = random.Next(16777215);
			}
			return num;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000165FC File Offset: 0x000147FC
		private void UpdateSpawnEntries()
		{
			if (this.SelectedSpawn == null || this.SelectedSpawn.SpawnObjects == null)
			{
				return;
			}
			int num = this.vScrollBar1.Value;
			if (this.SelectedSpawn.SpawnObjects.Count > 7)
			{
				this.vScrollBar1.Maximum = this.SelectedSpawn.SpawnObjects.Count + 2;
			}
			int num2 = 0;
			int num3 = 0;
			foreach (object obj in this.SelectedSpawn.SpawnObjects)
			{
				SpawnObject spawnObject = (SpawnObject)obj;
				if (num2++ >= num)
				{
					switch (num3)
					{
					case 0:
						spawnObject.TypeName = this.entryText1.Text;
						spawnObject.Count = (int)this.entryMax1.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer1.Value;
						if (this.entrySub1.Text != null && this.entrySub1.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub1.Text);
								goto IL_0133;
							}
							catch
							{
								goto IL_0133;
							}
							goto IL_012B;
						}
						goto IL_012B;
						IL_0133:
						if (this.entryReset1.Text != null && this.entryReset1.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset1.Text);
								goto IL_0180;
							}
							catch
							{
								goto IL_0180;
							}
							goto IL_0170;
						}
						goto IL_0170;
						IL_0180:
						if (this.entryTo1.Text != null && this.entryTo1.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo1.Text);
								goto IL_01C4;
							}
							catch
							{
								goto IL_01C4;
							}
							goto IL_01BC;
						}
						goto IL_01BC;
						IL_01C4:
						if (this.entryKills1.Text != null && this.entryKills1.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills1.Text);
								goto IL_0208;
							}
							catch
							{
								goto IL_0208;
							}
							goto IL_0200;
						}
						goto IL_0200;
						IL_0208:
						if (this.entryMinD1.Text != null && this.entryMinD1.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD1.Text);
								goto IL_0255;
							}
							catch
							{
								goto IL_0255;
							}
							goto IL_0245;
						}
						goto IL_0245;
						IL_0255:
						if (this.entryMaxD1.Text != null && this.entryMaxD1.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD1.Text);
								goto IL_02A2;
							}
							catch
							{
								goto IL_02A2;
							}
							goto IL_0292;
						}
						goto IL_0292;
						IL_02A2:
						spawnObject.RestrictKillsToSubgroup = this.chkRK1.Checked;
						spawnObject.ClearOnAdvance = this.chkClr1.Checked;
						break;
						IL_0292:
						spawnObject.MaxDelay = -1.0;
						goto IL_02A2;
						IL_0245:
						spawnObject.MinDelay = -1.0;
						goto IL_0255;
						IL_0200:
						spawnObject.KillsNeeded = 0;
						goto IL_0208;
						IL_01BC:
						spawnObject.SequentialResetTo = 0;
						goto IL_01C4;
						IL_0170:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_0180;
						IL_012B:
						spawnObject.SubGroup = 0;
						goto IL_0133;
					case 1:
						spawnObject.TypeName = this.entryText2.Text;
						spawnObject.Count = (int)this.entryMax2.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer2.Value;
						if (this.entrySub2.Text != null && this.entrySub2.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub2.Text);
								goto IL_034F;
							}
							catch
							{
								goto IL_034F;
							}
							goto IL_0347;
						}
						goto IL_0347;
						IL_034F:
						if (this.entryReset2.Text != null && this.entryReset2.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset2.Text);
								goto IL_039C;
							}
							catch
							{
								goto IL_039C;
							}
							goto IL_038C;
						}
						goto IL_038C;
						IL_039C:
						if (this.entryTo2.Text != null && this.entryTo2.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo2.Text);
								goto IL_03E0;
							}
							catch
							{
								goto IL_03E0;
							}
							goto IL_03D8;
						}
						goto IL_03D8;
						IL_03E0:
						if (this.entryKills2.Text != null && this.entryKills2.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills2.Text);
								goto IL_0424;
							}
							catch
							{
								goto IL_0424;
							}
							goto IL_041C;
						}
						goto IL_041C;
						IL_0424:
						if (this.entryMinD2.Text != null && this.entryMinD2.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD2.Text);
								goto IL_0471;
							}
							catch
							{
								goto IL_0471;
							}
							goto IL_0461;
						}
						goto IL_0461;
						IL_0471:
						if (this.entryMaxD2.Text != null && this.entryMaxD2.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD2.Text);
								goto IL_04BE;
							}
							catch
							{
								goto IL_04BE;
							}
							goto IL_04AE;
						}
						goto IL_04AE;
						IL_04BE:
						spawnObject.RestrictKillsToSubgroup = this.chkRK2.Checked;
						spawnObject.ClearOnAdvance = this.chkClr2.Checked;
						break;
						IL_04AE:
						spawnObject.MaxDelay = -1.0;
						goto IL_04BE;
						IL_0461:
						spawnObject.MinDelay = -1.0;
						goto IL_0471;
						IL_041C:
						spawnObject.KillsNeeded = 0;
						goto IL_0424;
						IL_03D8:
						spawnObject.SequentialResetTo = 0;
						goto IL_03E0;
						IL_038C:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_039C;
						IL_0347:
						spawnObject.SubGroup = 0;
						goto IL_034F;
					case 2:
						spawnObject.TypeName = this.entryText3.Text;
						spawnObject.Count = (int)this.entryMax3.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer3.Value;
						if (this.entrySub3.Text != null && this.entrySub3.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub3.Text);
								goto IL_056B;
							}
							catch
							{
								goto IL_056B;
							}
							goto IL_0563;
						}
						goto IL_0563;
						IL_056B:
						if (this.entryReset3.Text != null && this.entryReset3.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset3.Text);
								goto IL_05B8;
							}
							catch
							{
								goto IL_05B8;
							}
							goto IL_05A8;
						}
						goto IL_05A8;
						IL_05B8:
						if (this.entryTo3.Text != null && this.entryTo3.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo3.Text);
								goto IL_05FC;
							}
							catch
							{
								goto IL_05FC;
							}
							goto IL_05F4;
						}
						goto IL_05F4;
						IL_05FC:
						if (this.entryKills3.Text != null && this.entryKills3.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills3.Text);
								goto IL_0640;
							}
							catch
							{
								goto IL_0640;
							}
							goto IL_0638;
						}
						goto IL_0638;
						IL_0640:
						if (this.entryMinD3.Text != null && this.entryMinD3.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD3.Text);
								goto IL_068D;
							}
							catch
							{
								goto IL_068D;
							}
							goto IL_067D;
						}
						goto IL_067D;
						IL_068D:
						if (this.entryMaxD3.Text != null && this.entryMaxD3.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD3.Text);
								goto IL_06DA;
							}
							catch
							{
								goto IL_06DA;
							}
							goto IL_06CA;
						}
						goto IL_06CA;
						IL_06DA:
						spawnObject.RestrictKillsToSubgroup = this.chkRK3.Checked;
						spawnObject.ClearOnAdvance = this.chkClr3.Checked;
						break;
						IL_06CA:
						spawnObject.MaxDelay = -1.0;
						goto IL_06DA;
						IL_067D:
						spawnObject.MinDelay = -1.0;
						goto IL_068D;
						IL_0638:
						spawnObject.KillsNeeded = 0;
						goto IL_0640;
						IL_05F4:
						spawnObject.SequentialResetTo = 0;
						goto IL_05FC;
						IL_05A8:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_05B8;
						IL_0563:
						spawnObject.SubGroup = 0;
						goto IL_056B;
					case 3:
						spawnObject.TypeName = this.entryText4.Text;
						spawnObject.Count = (int)this.entryMax4.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer4.Value;
						if (this.entrySub4.Text != null && this.entrySub4.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub4.Text);
								goto IL_0787;
							}
							catch
							{
								goto IL_0787;
							}
							goto IL_077F;
						}
						goto IL_077F;
						IL_0787:
						if (this.entryReset4.Text != null && this.entryReset4.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset4.Text);
								goto IL_07D4;
							}
							catch
							{
								goto IL_07D4;
							}
							goto IL_07C4;
						}
						goto IL_07C4;
						IL_07D4:
						if (this.entryTo4.Text != null && this.entryTo4.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo4.Text);
								goto IL_0818;
							}
							catch
							{
								goto IL_0818;
							}
							goto IL_0810;
						}
						goto IL_0810;
						IL_0818:
						if (this.entryKills4.Text != null && this.entryKills4.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills4.Text);
								goto IL_085C;
							}
							catch
							{
								goto IL_085C;
							}
							goto IL_0854;
						}
						goto IL_0854;
						IL_085C:
						if (this.entryMinD4.Text != null && this.entryMinD4.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD4.Text);
								goto IL_08A9;
							}
							catch
							{
								goto IL_08A9;
							}
							goto IL_0899;
						}
						goto IL_0899;
						IL_08A9:
						if (this.entryMaxD4.Text != null && this.entryMaxD4.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD4.Text);
								goto IL_08F6;
							}
							catch
							{
								goto IL_08F6;
							}
							goto IL_08E6;
						}
						goto IL_08E6;
						IL_08F6:
						spawnObject.RestrictKillsToSubgroup = this.chkRK4.Checked;
						spawnObject.ClearOnAdvance = this.chkClr4.Checked;
						break;
						IL_08E6:
						spawnObject.MaxDelay = -1.0;
						goto IL_08F6;
						IL_0899:
						spawnObject.MinDelay = -1.0;
						goto IL_08A9;
						IL_0854:
						spawnObject.KillsNeeded = 0;
						goto IL_085C;
						IL_0810:
						spawnObject.SequentialResetTo = 0;
						goto IL_0818;
						IL_07C4:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_07D4;
						IL_077F:
						spawnObject.SubGroup = 0;
						goto IL_0787;
					case 4:
						spawnObject.TypeName = this.entryText5.Text;
						spawnObject.Count = (int)this.entryMax5.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer5.Value;
						if (this.entrySub5.Text != null && this.entrySub5.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub5.Text);
								goto IL_09A3;
							}
							catch
							{
								goto IL_09A3;
							}
							goto IL_099B;
						}
						goto IL_099B;
						IL_09A3:
						if (this.entryReset5.Text != null && this.entryReset5.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset5.Text);
								goto IL_09F0;
							}
							catch
							{
								goto IL_09F0;
							}
							goto IL_09E0;
						}
						goto IL_09E0;
						IL_09F0:
						if (this.entryTo5.Text != null && this.entryTo5.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo5.Text);
								goto IL_0A34;
							}
							catch
							{
								goto IL_0A34;
							}
							goto IL_0A2C;
						}
						goto IL_0A2C;
						IL_0A34:
						if (this.entryKills5.Text != null && this.entryKills5.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills5.Text);
								goto IL_0A78;
							}
							catch
							{
								goto IL_0A78;
							}
							goto IL_0A70;
						}
						goto IL_0A70;
						IL_0A78:
						if (this.entryMinD5.Text != null && this.entryMinD5.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD5.Text);
								goto IL_0AC5;
							}
							catch
							{
								goto IL_0AC5;
							}
							goto IL_0AB5;
						}
						goto IL_0AB5;
						IL_0AC5:
						if (this.entryMaxD5.Text != null && this.entryMaxD5.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD5.Text);
								goto IL_0B12;
							}
							catch
							{
								goto IL_0B12;
							}
							goto IL_0B02;
						}
						goto IL_0B02;
						IL_0B12:
						spawnObject.RestrictKillsToSubgroup = this.chkRK5.Checked;
						spawnObject.ClearOnAdvance = this.chkClr5.Checked;
						break;
						IL_0B02:
						spawnObject.MaxDelay = -1.0;
						goto IL_0B12;
						IL_0AB5:
						spawnObject.MinDelay = -1.0;
						goto IL_0AC5;
						IL_0A70:
						spawnObject.KillsNeeded = 0;
						goto IL_0A78;
						IL_0A2C:
						spawnObject.SequentialResetTo = 0;
						goto IL_0A34;
						IL_09E0:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_09F0;
						IL_099B:
						spawnObject.SubGroup = 0;
						goto IL_09A3;
					case 5:
						spawnObject.TypeName = this.entryText6.Text;
						spawnObject.Count = (int)this.entryMax6.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer6.Value;
						if (this.entrySub6.Text != null && this.entrySub6.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub6.Text);
								goto IL_0BBF;
							}
							catch
							{
								goto IL_0BBF;
							}
							goto IL_0BB7;
						}
						goto IL_0BB7;
						IL_0BBF:
						if (this.entryReset6.Text != null && this.entryReset6.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset6.Text);
								goto IL_0C0C;
							}
							catch
							{
								goto IL_0C0C;
							}
							goto IL_0BFC;
						}
						goto IL_0BFC;
						IL_0C0C:
						if (this.entryTo6.Text != null && this.entryTo6.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo6.Text);
								goto IL_0C50;
							}
							catch
							{
								goto IL_0C50;
							}
							goto IL_0C48;
						}
						goto IL_0C48;
						IL_0C50:
						if (this.entryKills6.Text != null && this.entryKills6.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills6.Text);
								goto IL_0C94;
							}
							catch
							{
								goto IL_0C94;
							}
							goto IL_0C8C;
						}
						goto IL_0C8C;
						IL_0C94:
						if (this.entryMinD6.Text != null && this.entryMinD6.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD6.Text);
								goto IL_0CE1;
							}
							catch
							{
								goto IL_0CE1;
							}
							goto IL_0CD1;
						}
						goto IL_0CD1;
						IL_0CE1:
						if (this.entryMaxD6.Text != null && this.entryMaxD6.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD6.Text);
								goto IL_0D2E;
							}
							catch
							{
								goto IL_0D2E;
							}
							goto IL_0D1E;
						}
						goto IL_0D1E;
						IL_0D2E:
						spawnObject.RestrictKillsToSubgroup = this.chkRK6.Checked;
						spawnObject.ClearOnAdvance = this.chkClr6.Checked;
						break;
						IL_0D1E:
						spawnObject.MaxDelay = -1.0;
						goto IL_0D2E;
						IL_0CD1:
						spawnObject.MinDelay = -1.0;
						goto IL_0CE1;
						IL_0C8C:
						spawnObject.KillsNeeded = 0;
						goto IL_0C94;
						IL_0C48:
						spawnObject.SequentialResetTo = 0;
						goto IL_0C50;
						IL_0BFC:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_0C0C;
						IL_0BB7:
						spawnObject.SubGroup = 0;
						goto IL_0BBF;
					case 6:
						spawnObject.TypeName = this.entryText7.Text;
						spawnObject.Count = (int)this.entryMax7.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer7.Value;
						if (this.entrySub7.Text != null && this.entrySub7.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub7.Text);
								goto IL_0DDB;
							}
							catch
							{
								goto IL_0DDB;
							}
							goto IL_0DD3;
						}
						goto IL_0DD3;
						IL_0DDB:
						if (this.entryReset7.Text != null && this.entryReset7.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset7.Text);
								goto IL_0E28;
							}
							catch
							{
								goto IL_0E28;
							}
							goto IL_0E18;
						}
						goto IL_0E18;
						IL_0E28:
						if (this.entryTo7.Text != null && this.entryTo7.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo7.Text);
								goto IL_0E6C;
							}
							catch
							{
								goto IL_0E6C;
							}
							goto IL_0E64;
						}
						goto IL_0E64;
						IL_0E6C:
						if (this.entryKills7.Text != null && this.entryKills7.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills7.Text);
								goto IL_0EB0;
							}
							catch
							{
								goto IL_0EB0;
							}
							goto IL_0EA8;
						}
						goto IL_0EA8;
						IL_0EB0:
						if (this.entryMinD7.Text != null && this.entryMinD7.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD7.Text);
								goto IL_0EFD;
							}
							catch
							{
								goto IL_0EFD;
							}
							goto IL_0EED;
						}
						goto IL_0EED;
						IL_0EFD:
						if (this.entryMaxD7.Text != null && this.entryMaxD7.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD7.Text);
								goto IL_0F4A;
							}
							catch
							{
								goto IL_0F4A;
							}
							goto IL_0F3A;
						}
						goto IL_0F3A;
						IL_0F4A:
						spawnObject.RestrictKillsToSubgroup = this.chkRK7.Checked;
						spawnObject.ClearOnAdvance = this.chkClr7.Checked;
						break;
						IL_0F3A:
						spawnObject.MaxDelay = -1.0;
						goto IL_0F4A;
						IL_0EED:
						spawnObject.MinDelay = -1.0;
						goto IL_0EFD;
						IL_0EA8:
						spawnObject.KillsNeeded = 0;
						goto IL_0EB0;
						IL_0E64:
						spawnObject.SequentialResetTo = 0;
						goto IL_0E6C;
						IL_0E18:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_0E28;
						IL_0DD3:
						spawnObject.SubGroup = 0;
						goto IL_0DDB;
					case 7:
						spawnObject.TypeName = this.entryText8.Text;
						spawnObject.Count = (int)this.entryMax8.Value;
						spawnObject.SpawnsPerTick = (int)this.entryPer8.Value;
						if (this.entrySub8.Text != null && this.entrySub8.Text.Length > 0)
						{
							try
							{
								spawnObject.SubGroup = int.Parse(this.entrySub8.Text);
								goto IL_0FF7;
							}
							catch
							{
								goto IL_0FF7;
							}
							goto IL_0FEF;
						}
						goto IL_0FEF;
						IL_0FF7:
						if (this.entryReset8.Text != null && this.entryReset8.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTime = (double)int.Parse(this.entryReset8.Text);
								goto IL_1044;
							}
							catch
							{
								goto IL_1044;
							}
							goto IL_1034;
						}
						goto IL_1034;
						IL_1044:
						if (this.entryTo8.Text != null && this.entryTo8.Text.Length > 0)
						{
							try
							{
								spawnObject.SequentialResetTo = int.Parse(this.entryTo8.Text);
								goto IL_1088;
							}
							catch
							{
								goto IL_1088;
							}
							goto IL_1080;
						}
						goto IL_1080;
						IL_1088:
						if (this.entryKills8.Text != null && this.entryKills8.Text.Length > 0)
						{
							try
							{
								spawnObject.KillsNeeded = int.Parse(this.entryKills8.Text);
								goto IL_10CC;
							}
							catch
							{
								goto IL_10CC;
							}
							goto IL_10C4;
						}
						goto IL_10C4;
						IL_10CC:
						if (this.entryMinD8.Text != null && this.entryMinD8.Text.Length > 0)
						{
							try
							{
								spawnObject.MinDelay = (double)int.Parse(this.entryMinD8.Text);
								goto IL_1119;
							}
							catch
							{
								goto IL_1119;
							}
							goto IL_1109;
						}
						goto IL_1109;
						IL_1119:
						if (this.entryMaxD8.Text != null && this.entryMaxD8.Text.Length > 0)
						{
							try
							{
								spawnObject.MaxDelay = (double)int.Parse(this.entryMaxD8.Text);
								goto IL_1166;
							}
							catch
							{
								goto IL_1166;
							}
							goto IL_1156;
						}
						goto IL_1156;
						IL_1166:
						spawnObject.RestrictKillsToSubgroup = this.chkRK8.Checked;
						spawnObject.ClearOnAdvance = this.chkClr8.Checked;
						break;
						IL_1156:
						spawnObject.MaxDelay = -1.0;
						goto IL_1166;
						IL_1109:
						spawnObject.MinDelay = -1.0;
						goto IL_1119;
						IL_10C4:
						spawnObject.KillsNeeded = 0;
						goto IL_10CC;
						IL_1080:
						spawnObject.SequentialResetTo = 0;
						goto IL_1088;
						IL_1034:
						spawnObject.SequentialResetTime = 0.0;
						goto IL_1044;
						IL_0FEF:
						spawnObject.SubGroup = 0;
						goto IL_0FF7;
					}
					if (++num3 > 7)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00017C5C File Offset: 0x00015E5C
		private void DisplaySpawnEntries()
		{
			this.ClearEntries();
			if (this.SelectedSpawn == null)
			{
				this.vScrollBar1.Maximum = 8;
				return;
			}
			if (this.SelectedSpawn.SpawnObjects == null)
			{
				this.vScrollBar1.Maximum = 8;
				return;
			}
			int num = this.vScrollBar1.Value;
			if (this.SelectedSpawn.SpawnObjects.Count > 7)
			{
				this.vScrollBar1.Maximum = this.SelectedSpawn.SpawnObjects.Count + 2;
			}
			int num2 = 0;
			int num3 = 0;
			foreach (object obj in this.SelectedSpawn.SpawnObjects)
			{
				SpawnObject spawnObject = (SpawnObject)obj;
				if (num2++ >= num)
				{
					switch (num3)
					{
					case 0:
						this.entryText1.Text = spawnObject.TypeName;
						this.entryMax1.Value = spawnObject.Count;
						this.entryPer1.Value = spawnObject.SpawnsPerTick;
						this.entrySub1.Text = spawnObject.SubGroup.ToString();
						this.entryReset1.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo1.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills1.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD1.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD1.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD1.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD1.Text = null;
						}
						this.chkRK1.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr1.Checked = spawnObject.ClearOnAdvance;
						break;
					case 1:
						this.entryText2.Text = spawnObject.TypeName;
						this.entryMax2.Value = spawnObject.Count;
						this.entryPer2.Value = spawnObject.SpawnsPerTick;
						this.entrySub2.Text = spawnObject.SubGroup.ToString();
						this.entryReset2.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo2.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills2.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD2.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD2.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD2.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD2.Text = null;
						}
						this.chkRK2.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr2.Checked = spawnObject.ClearOnAdvance;
						break;
					case 2:
						this.entryText3.Text = spawnObject.TypeName;
						this.entryMax3.Value = spawnObject.Count;
						this.entryPer3.Value = spawnObject.SpawnsPerTick;
						this.entrySub3.Text = spawnObject.SubGroup.ToString();
						this.entryReset3.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo3.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills3.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD3.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD3.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD3.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD3.Text = null;
						}
						this.chkRK3.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr3.Checked = spawnObject.ClearOnAdvance;
						break;
					case 3:
						this.entryText4.Text = spawnObject.TypeName;
						this.entryMax4.Value = spawnObject.Count;
						this.entryPer4.Value = spawnObject.SpawnsPerTick;
						this.entrySub4.Text = spawnObject.SubGroup.ToString();
						this.entryReset4.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo4.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills4.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD4.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD4.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD4.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD4.Text = null;
						}
						this.chkRK4.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr4.Checked = spawnObject.ClearOnAdvance;
						break;
					case 4:
						this.entryText5.Text = spawnObject.TypeName;
						this.entryMax5.Value = spawnObject.Count;
						this.entryPer5.Value = spawnObject.SpawnsPerTick;
						this.entrySub5.Text = spawnObject.SubGroup.ToString();
						this.entryReset5.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo5.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills5.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD5.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD5.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD5.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD5.Text = null;
						}
						this.chkRK5.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr5.Checked = spawnObject.ClearOnAdvance;
						break;
					case 5:
						this.entryText6.Text = spawnObject.TypeName;
						this.entryMax6.Value = spawnObject.Count;
						this.entryPer6.Value = spawnObject.SpawnsPerTick;
						this.entrySub6.Text = spawnObject.SubGroup.ToString();
						this.entryReset6.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo6.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills6.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD6.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD6.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD6.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD6.Text = null;
						}
						this.chkRK6.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr6.Checked = spawnObject.ClearOnAdvance;
						break;
					case 6:
						this.entryText7.Text = spawnObject.TypeName;
						this.entryMax7.Value = spawnObject.Count;
						this.entryPer7.Value = spawnObject.SpawnsPerTick;
						this.entrySub7.Text = spawnObject.SubGroup.ToString();
						this.entryReset7.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo7.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills7.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD7.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD7.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD7.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD7.Text = null;
						}
						this.chkRK7.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr7.Checked = spawnObject.ClearOnAdvance;
						break;
					case 7:
						this.entryText8.Text = spawnObject.TypeName;
						this.entryMax8.Value = spawnObject.Count;
						this.entryPer8.Value = spawnObject.SpawnsPerTick;
						this.entrySub8.Text = spawnObject.SubGroup.ToString();
						this.entryReset8.Text = spawnObject.SequentialResetTime.ToString();
						this.entryTo8.Text = spawnObject.SequentialResetTo.ToString();
						this.entryKills8.Text = spawnObject.KillsNeeded.ToString();
						if (spawnObject.MinDelay >= 0.0)
						{
							this.entryMinD8.Text = spawnObject.MinDelay.ToString();
						}
						else
						{
							this.entryMinD8.Text = null;
						}
						if (spawnObject.MaxDelay >= 0.0)
						{
							this.entryMaxD8.Text = spawnObject.MaxDelay.ToString();
						}
						else
						{
							this.entryMaxD8.Text = null;
						}
						this.chkRK8.Checked = spawnObject.RestrictKillsToSubgroup;
						this.chkClr8.Checked = spawnObject.ClearOnAdvance;
						break;
					}
					if (++num3 > 7)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00018714 File Offset: 0x00016914
		private void DisplaySpawnDetails(SpawnPoint Spawn)
		{
			if (Spawn == null)
			{
				return;
			}
			this.txtName.Text = Spawn.SpawnName;
			this.spnHomeRange.Value = Spawn.SpawnHomeRange;
			this.spnMaxCount.Value = Spawn.SpawnMaxCount;
			this.spnMinDelay.Value = (decimal)Spawn.SpawnMinDelay;
			this.spnMaxDelay.Value = (decimal)Spawn.SpawnMaxDelay;
			this.spnTeam.Value = Spawn.SpawnTeam;
			this.chkGroup.Checked = Spawn.SpawnIsGroup;
			this.chkRunning.Checked = Spawn.SpawnIsRunning;
			this.chkHomeRangeIsRelative.Checked = Spawn.SpawnHomeRangeIsRelative;
			this.spnSpawnRange.Value = Spawn.SpawnSpawnRange;
			this.spnProximityRange.Value = Spawn.SpawnProximityRange;
			this.spnDuration.Value = (decimal)Spawn.SpawnDuration;
			this.spnDespawn.Value = (decimal)Spawn.SpawnDespawn;
			this.spnMinRefract.Value = (decimal)Spawn.SpawnMinRefract;
			this.spnMaxRefract.Value = (decimal)Spawn.SpawnMaxRefract;
			this.spnTODStart.Value = (decimal)Spawn.SpawnTODStart;
			this.spnTODEnd.Value = (decimal)Spawn.SpawnTODEnd;
			this.spnKillReset.Value = Spawn.SpawnKillReset;
			this.spnProximitySnd.Value = Spawn.SpawnProximitySnd;
			this.chkAllowGhost.Checked = Spawn.SpawnAllowGhost;
			this.chkSpawnOnTrigger.Checked = Spawn.SpawnSpawnOnTrigger;
			this.chkSequentialSpawn.Checked = Spawn.SpawnSequentialSpawn > -1;
			this.chkSmartSpawning.Checked = Spawn.SpawnSmartSpawning;
			if (Spawn.SpawnTODMode == 0)
			{
				this.chkRealTOD.Checked = true;
				this.chkGameTOD.Checked = false;
			}
			else
			{
				this.chkRealTOD.Checked = false;
				this.chkGameTOD.Checked = true;
			}
			this.chkInContainer.Checked = Spawn.SpawnInContainer;
			this.textSkillTrigger.Text = Spawn.SpawnSkillTrigger;
			this.textSpeechTrigger.Text = Spawn.SpawnSpeechTrigger;
			this.textProximityMsg.Text = Spawn.SpawnProximityMsg;
			this.textMobTriggerName.Text = Spawn.SpawnMobTriggerName;
			this.textMobTrigProp.Text = Spawn.SpawnMobTrigProp;
			this.textPlayerTrigProp.Text = Spawn.SpawnPlayerTrigProp;
			this.textTrigObjectProp.Text = Spawn.SpawnTrigObjectProp;
			this.textTriggerOnCarried.Text = Spawn.SpawnTriggerOnCarried;
			this.textNoTriggerOnCarried.Text = Spawn.SpawnNoTriggerOnCarried;
			this.spnTriggerProbability.Value = (decimal)Spawn.SpawnTriggerProbability;
			this.spnStackAmount.Value = Spawn.SpawnStackAmount;
			this.txtNotes.Text = Spawn.SpawnNotes;
			this.spnContainerX.Value = Spawn.SpawnContainerX;
			this.spnContainerY.Value = Spawn.SpawnContainerY;
			this.spnContainerZ.Value = Spawn.SpawnContainerZ;
			this.chkExternalTriggering.Checked = Spawn.SpawnExternalTriggering;
			this.textTrigObjectName.Text = Spawn.SpawnObjectPropertyItemName;
			this.textSetObjectName.Text = Spawn.SpawnSetPropertyItemName;
			this.textRegionName.Text = Spawn.SpawnRegionName;
			this.textConfigFile.Text = Spawn.SpawnConfigFile;
			this.textWayPoint.Text = Spawn.SpawnWaypoint;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00018AC4 File Offset: 0x00016CC4
		private void FillRegionTree()
		{
			this.treeRegionView.Nodes.Clear();
			for (int index = 0; index < 5; index++)
			{
				this.treeRegionView.Nodes.Add(new RegionFacetNode((WorldMap)index));
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00018B04 File Offset: 0x00016D04
		private void axUOMap_MouseDownEvent(object sender, UOMapMouseEventArgs e)
		{
			short num = this.axUOMap.CtrlToMapX((short)e.x);
			short num2 = this.axUOMap.CtrlToMapY((short)e.y);
			short mapHeight = this.axUOMap.GetMapHeight(num, num2);
			this.RightMouseDown = false;
			this.RightMouseDownStart = DateTime.MaxValue;
			if (e.button == 1)
			{
				if (this.GoToSelected)
				{
					this.SendGoCommand(num, num2, mapHeight, (WorldMap)this.cbxMap.SelectedItem);
					this.GoToSelected = false;
				}
				if (this._SelectionWindow != null && this._SelectionWindow.Index > -1)
				{
					this.axUOMap.RemoveDrawRectAt(this._SelectionWindow.Index);
					this.ClearSelectionWindow();
				}
				this._SelectionWindow = new SpawnEditor.SelectionWindow();
				this._SelectionWindow.X = num;
				this._SelectionWindow.Y = num2;
				this._SelectionWindow.SX = num;
				this._SelectionWindow.SY = num2;
				this._SelectionWindow.Index = this.axUOMap.AddDrawRect(this._SelectionWindow.X, this._SelectionWindow.Y, 1, 1, 2, 16777215);
				this.EnableSelectionWindowOption(true);
			}
			else if (e.button == 2)
			{
				this.RightMouseDown = true;
				this.RightMouseDownStart = DateTime.Now;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00018C58 File Offset: 0x00016E58
		private void axUOMap_MouseUpEvent(object sender, UOMapMouseEventArgs e)
		{
			short num = this.axUOMap.CtrlToMapX((short)e.x);
			short num2 = this.axUOMap.CtrlToMapY((short)e.y);
			this.axUOMap.GetMapHeight(num, num2);
			if (this.RightMouseDown)
			{
				if (this._SelectionWindow != null && this._SelectionWindow.IsWithinWindow(num, num2))
				{
					this.txtName.Text = this.txtName.Text.Trim();
					this.spnSpawnRange.Value = -1m;
					if (this.txtName.Text.Length == 0)
					{
						MessageBox.Show(this, "You must specify a name for the spawner!", "Spawn Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					foreach (object obj in this.tvwSpawnPoints.Nodes)
					{
						((SpawnPointNode)obj).Spawn.IsSelected = false;
					}
					SpawnPointNode SpawnNode = new SpawnPointNode(new SpawnPoint(Guid.NewGuid(), (WorldMap)this.cbxMap.SelectedItem, this._SelectionWindow.Bounds));
					this.SetSpawn(SpawnNode, false);
					SpawnNode.Spawn.CentreZ = short.MinValue;
					this.tvwSpawnPoints.Nodes.Add(SpawnNode);
					this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
					this.ClearSelectionWindow();
					this.SelectedSpawn = SpawnNode.Spawn;
					this.DisplaySpawnDetails(this.SelectedSpawn);
				}
				foreach (object obj2 in this.tvwSpawnPoints.Nodes)
				{
					((SpawnPointNode)obj2).Spawn.IsSelected = false;
				}
				ArrayList arrayList = new ArrayList(this.tvwSpawnPoints.Nodes);
				arrayList.Sort(new SpawnPointAreaComparer());
				foreach (object obj3 in arrayList)
				{
					SpawnPointNode spawnPointNode = (SpawnPointNode)obj3;
					if (spawnPointNode.Spawn.Map == (WorldMap)this.cbxMap.SelectedItem && !spawnPointNode.Filtered && spawnPointNode.Spawn.IsSameArea(num, num2))
					{
						spawnPointNode.Spawn.IsSelected = true;
						this.SelectedSpawn = spawnPointNode.Spawn;
						this.SendGoCommand(spawnPointNode.Spawn);
						this.DisplaySpawnDetails(this.SelectedSpawn);
						this.DisplaySpawnEntries();
						this.tvwSpawnPoints.SelectedNode = spawnPointNode;
						this.tvwSpawnPoints.SelectedNode.EnsureVisible();
						this.SetSelectedSpawnTypes();
						break;
					}
				}
				this.RefreshSpawnPoints();
			}
			else if (this._SelectionWindow != null && this._SelectionWindow.SX == num && this._SelectionWindow.SY == num2)
			{
				if (this._SelectionWindow.Index > -1)
				{
					this.axUOMap.RemoveDrawRectAt(this._SelectionWindow.Index);
					this.ClearSelectionWindow();
				}
				this.AssignCenter(num, num2, (short)this.cbxMap.SelectedIndex);
				this.RefreshSpawnPoints();
			}
			this.trkZoom.Focus();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00018FD4 File Offset: 0x000171D4
		private void axUOMap_MouseMoveEvent(object sender, UOMapMouseEventArgs e)
		{
			short num = this.axUOMap.CtrlToMapX((short)e.x);
			short num2 = this.axUOMap.CtrlToMapY((short)e.y);
			short mapHeight = this.axUOMap.GetMapHeight(num, num2);
			WorldMap worldMap = (WorldMap)this.cbxMap.SelectedItem;
			if (e.button == 0)
			{
				this.trkZoom.Focus();
				this.MouseResize = false;
				string caption = string.Empty;
				bool flag = false;
				short num3 = (short)(6 - (short)this.trkZoom.Value);
				if (this._TransferDialog.chkShowTips.Checked)
				{
					if (this._TransferDialog.chkShowCreatures.Checked && this.MobLocArray != null)
					{
						for (int index = 0; index < this.MobLocArray.Length; index++)
						{
							if (this.MobLocArray[index].Map == (int)worldMap && (int)num < this.MobLocArray[index].X + (int)num3 && (int)num > this.MobLocArray[index].X - (int)num3 && (int)num2 < this.MobLocArray[index].Y + (int)num3 && (int)num2 > this.MobLocArray[index].Y - (int)num3)
							{
								caption = this.MobLocArray[index].Name;
								flag = true;
								break;
							}
						}
					}
					if (this._TransferDialog.chkShowPlayers.Checked && this.PlayerLocArray != null && !flag)
					{
						for (int index2 = 0; index2 < this.PlayerLocArray.Length; index2++)
						{
							if (this.PlayerLocArray[index2].Map == (int)worldMap && (int)num < this.PlayerLocArray[index2].X + (int)num3 && (int)num > this.PlayerLocArray[index2].X - (int)num3 && (int)num2 < this.PlayerLocArray[index2].Y + (int)num3 && (int)num2 > this.PlayerLocArray[index2].Y - (int)num3)
							{
								caption = this.PlayerLocArray[index2].Name;
								flag = true;
								break;
							}
						}
					}
					if (this._TransferDialog.chkShowItems.Checked && this.ItemLocArray != null && !flag)
					{
						for (int index3 = 0; index3 < this.ItemLocArray.Length; index3++)
						{
							if (this.ItemLocArray[index3].Map == (int)worldMap && (int)num < this.ItemLocArray[index3].X + (int)num3 && (int)num > this.ItemLocArray[index3].X - (int)num3 && (int)num2 < this.ItemLocArray[index3].Y + (int)num3 && (int)num2 > this.ItemLocArray[index3].Y - (int)num3)
							{
								caption = this.ItemLocArray[index3].Name;
								flag = true;
								break;
							}
						}
					}
				}
				if (this.chkShowMapTip.Checked && this.chkShowSpawns.Checked && !flag)
				{
					ArrayList arrayList = new ArrayList(this.tvwSpawnPoints.Nodes);
					arrayList.Sort(new SpawnPointAreaComparer());
					foreach (object obj in arrayList)
					{
						SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
						if (spawnPointNode.Spawn.Map == (WorldMap)this.cbxMap.SelectedItem && !spawnPointNode.Filtered && spawnPointNode.Spawn.IsSameArea(num, num2, 1))
						{
							UOMapControl axUOMap = this.axUOMap;
							int num4 = (int)((short)spawnPointNode.Spawn.Bounds.X);
							int num5 = (int)axUOMap.MapToCtrlX((short)num4);
							UOMapControl axUOMap2 = this.axUOMap;
							int num6 = (int)((short)spawnPointNode.Spawn.Bounds.Y);
							int num7 = (int)axUOMap2.MapToCtrlY((short)num6);
							UOMapControl axUOMap3 = this.axUOMap;
							int x2 = spawnPointNode.Spawn.Bounds.X;
							int width = spawnPointNode.Spawn.Bounds.Width;
							int num8 = (int)((short)(x2 + width));
							int num9 = (int)axUOMap3.MapToCtrlX((short)num8) - num5;
							UOMapControl axUOMap4 = this.axUOMap;
							int y2 = spawnPointNode.Spawn.Bounds.Y;
							int height = spawnPointNode.Spawn.Bounds.Height;
							int num10 = (int)((short)(y2 + height));
							int num11 = (int)axUOMap4.MapToCtrlY((short)num10) - num7;
							if (spawnPointNode.Spawn == this.SelectedSpawn && (double)e.x > (double)num5 + (double)num9 * 0.8 && e.x < num5 + num9 && (double)e.y > (double)num7 + (double)num11 * 0.8 && e.y < num7 + num11)
							{
								caption = "Resize";
								this.MouseResize = true;
								break;
							}
							caption = spawnPointNode.Spawn.ToString();
							break;
						}
					}
				}
				this.ttpSpawnInfo.SetToolTip(this.axUOMap, caption);
				if (this._SelectionWindow != null)
				{
					return;
				}
				this.stbMain.Text = string.Format("[X={0} Y={1} H={2}]", num, num2, mapHeight);
				return;
			}
			else if (e.button == 1)
			{
				if (this._SelectionWindow == null)
				{
					return;
				}
				if (this._SelectionWindow.Index > -1)
				{
					this.axUOMap.RemoveDrawRectAt(this._SelectionWindow.Index);
					this._SelectionWindow.Index = -1;
				}
				short num12 = (short)(num - this._SelectionWindow.SX);
				short num13 = (short)(num2 - this._SelectionWindow.SY);
				this._SelectionWindow.Width = (short)Math.Abs(num12);
				this._SelectionWindow.Height = (short)Math.Abs(num13);
				this._SelectionWindow.X = this._SelectionWindow.SX;
				this._SelectionWindow.Y = this._SelectionWindow.SY;
				if (num13 < 0)
				{
					this._SelectionWindow.Y = (short)(this._SelectionWindow.SY + num13);
				}
				if (num12 < 0)
				{
					this._SelectionWindow.X = (short)(this._SelectionWindow.SX + num12);
				}
				foreach (object obj2 in this.tvwSpawnPoints.Nodes)
				{
					((SpawnPointNode)obj2).Spawn.IsSelected = false;
				}
				this.txtName.Text = this._CfgDialog.CfgSpawnNameValue + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.txtName.Refresh();
				this._SelectionWindow.Index = this.axUOMap.AddDrawRect(this._SelectionWindow.X, this._SelectionWindow.Y, this._SelectionWindow.Width, this._SelectionWindow.Height, 2, 16777215);
				this.stbMain.Text = string.Format("[X1={0} Y1={1}] TO [X2={2} Y2={3}] (Width={4}, Height={5})", new object[]
				{
					this._SelectionWindow.X,
					this._SelectionWindow.Y,
					(int)(this._SelectionWindow.X + this._SelectionWindow.Width),
					(int)(this._SelectionWindow.Y + this._SelectionWindow.Height),
					this._SelectionWindow.Width,
					this._SelectionWindow.Height
				});
				return;
			}
			else
			{
				if (e.button != 2)
				{
					return;
				}
				SpawnPoint spawnPoint = null;
				foreach (object obj3 in this.tvwSpawnPoints.Nodes)
				{
					SpawnPointNode spawnPointNode2 = (SpawnPointNode)obj3;
					if (spawnPointNode2.Spawn.Map == (WorldMap)this.cbxMap.SelectedItem && spawnPointNode2.Spawn.IsSelected)
					{
						spawnPoint = spawnPointNode2.Spawn;
						break;
					}
				}
				if (spawnPoint == null)
				{
					return;
				}
				int width2 = spawnPoint.Bounds.Width;
				int height2 = spawnPoint.Bounds.Height;
				int x = spawnPoint.Bounds.X;
				int y = spawnPoint.Bounds.Y;
				if (this.MouseResize)
				{
					spawnPoint.Bounds = new Rectangle(x, y, (int)num - x + 1, (int)num2 - y + 1);
					if (!this.SpawnLocationLocked)
					{
						spawnPoint.CentreX = (short)(spawnPoint.Bounds.X + spawnPoint.Bounds.Width / 2);
						SpawnPoint spawnPoint2 = spawnPoint;
						int y3 = spawnPoint.Bounds.Y;
						int num14 = spawnPoint.Bounds.Height / 2;
						int num15 = (int)((short)(y3 + num14));
						spawnPoint2.CentreY = (short)num15;
					}
					this.spnSpawnRange.Value = -1m;
				}
				else if (DateTime.Now - this.RightMouseDownStart > TimeSpan.FromSeconds(0.4))
				{
					spawnPoint.Bounds = new Rectangle((int)num - width2 / 2, (int)num2 - height2 / 2, width2, height2);
					if (!this.SpawnLocationLocked)
					{
						spawnPoint.CentreX = (short)(spawnPoint.Bounds.X + spawnPoint.Bounds.Width / 2);
						SpawnPoint spawnPoint3 = spawnPoint;
						int y4 = spawnPoint.Bounds.Y;
						int num16 = spawnPoint.Bounds.Height / 2;
						int num17 = (int)((short)(y4 + num16));
						spawnPoint3.CentreY = (short)num17;
					}
				}
				this.RefreshSpawnPoints();
				return;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000199D0 File Offset: 0x00017BD0
		public static double ComputeDensity(SpawnPoint spawn)
		{
			int num = 4 * spawn.SpawnHomeRange * spawn.SpawnHomeRange;
			if (spawn.SpawnHomeRangeIsRelative)
			{
				num = (spawn.Bounds.Height + 2 * spawn.SpawnHomeRange) * (spawn.Bounds.Width + 2 * spawn.SpawnHomeRange);
			}
			int num2 = spawn.SpawnMaxCount;
			double num3 = 0.0;
			if (num > 0)
			{
				num3 = (double)num2 / (double)num;
			}
			return num3;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00019A44 File Offset: 0x00017C44
		private static int ComputeDensityColor(SpawnPoint spawn)
		{
			int num = (int)(SpawnEditor.ComputeDensity(spawn) * 100000.0 + 20.0);
			if (num > 255)
			{
				num = 255;
			}
			return num * 256 * 256 + num;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00019A8C File Offset: 0x00017C8C
		private static int ComputeSpeedColor(SpawnPoint spawn)
		{
			int num = (int)(spawn.SpawnMinDelay + spawn.SpawnMaxDelay) / 2;
			if (num <= 0)
			{
				num = 1;
			}
			int num2 = 1000 / num + 20;
			if (num2 > 255)
			{
				num2 = 255;
			}
			return num2 * 256 * 256 + num2;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00019AD8 File Offset: 0x00017CD8
		internal void ClearSpawnFilter()
		{
			if (this.tvwSpawnPoints == null || this.tvwSpawnPoints.Nodes == null)
			{
				return;
			}
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				((SpawnPointNode)obj).Filtered = false;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00019B4C File Offset: 0x00017D4C
		internal void ApplySpawnFilter()
		{
			if (this.tvwSpawnPoints == null || this.tvwSpawnPoints.Nodes == null)
			{
				return;
			}
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				spawnPointNode.Filtered = !this._SpawnerFilters.HasMatch(spawnPointNode.Spawn);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00019BD4 File Offset: 0x00017DD4
		internal void RefreshSpawnPoints()
		{
			this.axUOMap.RemoveDrawRects();
			this.axUOMap.RemoveDrawObjects();
			this.RefreshRegionView();
			this.DisplayMyLocation();
			if (this.MobLocArray != null && this._TransferDialog.chkShowCreatures.Checked)
			{
				short size = (short)(5 + (short)this.trkZoom.Value);
				for (int index = 0; index < this.MobLocArray.Length; index++)
				{
					short x = (short)this.MobLocArray[index].X;
					short y = (short)this.MobLocArray[index].Y;
					if ((WorldMap)this.cbxMap.SelectedItem == (WorldMap)this.MobLocArray[index].Map)
					{
						this.axUOMap.AddDrawObject(x, y, 1, size, 16776960);
					}
				}
			}
			if (this.PlayerLocArray != null && this._TransferDialog.chkShowPlayers.Checked)
			{
				short size2 = (short)(5 + (short)this.trkZoom.Value);
				for (int index2 = 0; index2 < this.PlayerLocArray.Length; index2++)
				{
					short x2 = (short)this.PlayerLocArray[index2].X;
					short y2 = (short)this.PlayerLocArray[index2].Y;
					if ((WorldMap)this.cbxMap.SelectedItem == (WorldMap)this.PlayerLocArray[index2].Map)
					{
						this.axUOMap.AddDrawObject(x2, y2, 2, size2, 65535);
					}
				}
			}
			if (this.ItemLocArray != null && this._TransferDialog.chkShowItems.Checked)
			{
				short size3 = (short)(5 + (short)this.trkZoom.Value);
				for (int index3 = 0; index3 < this.ItemLocArray.Length; index3++)
				{
					short x3 = (short)this.ItemLocArray[index3].X;
					short y3 = (short)this.ItemLocArray[index3].Y;
					if ((WorldMap)this.cbxMap.SelectedItem == (WorldMap)this.ItemLocArray[index3].Map)
					{
						this.axUOMap.AddDrawObject(x3, y3, 1, size3, 65280);
					}
				}
			}
			bool flag = false;
			int num = 0;
			foreach (object obj in this.tvwTemplates.Nodes)
			{
				SpawnPointNode spawnTemplateNode = (SpawnPointNode)obj;
				if (spawnTemplateNode.Spawn.IsSelected || spawnTemplateNode.Highlighted)
				{
					if (spawnTemplateNode.Filtered)
					{
						spawnTemplateNode.ForeColor = Color.LightGray;
					}
					else
					{
						spawnTemplateNode.ForeColor = this.tvwTemplates.ForeColor;
					}
					if (this.tvwTemplates.SelectedNode != null && (this.tvwTemplates.SelectedNode.Parent == null || this.tvwTemplates.SelectedNode.Parent != spawnTemplateNode))
					{
						this.tvwTemplates.SelectedNode = spawnTemplateNode;
						spawnTemplateNode.BackColor = Color.Yellow;
						spawnTemplateNode.EnsureVisible();
					}
					this.SelectedTemplate = spawnTemplateNode.Spawn;
				}
				else
				{
					spawnTemplateNode.BackColor = this.tvwTemplates.BackColor;
					if (spawnTemplateNode.Filtered)
					{
						spawnTemplateNode.ForeColor = Color.LightGray;
					}
					else
					{
						spawnTemplateNode.ForeColor = this.tvwSpawnPoints.ForeColor;
					}
				}
			}
			foreach (object obj2 in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj2;
				if (spawnPointNode.Spawn.IsSelected || spawnPointNode.Highlighted)
				{
					if (spawnPointNode.Filtered)
					{
						spawnPointNode.ForeColor = Color.LightGray;
					}
					else
					{
						spawnPointNode.ForeColor = this.tvwSpawnPoints.ForeColor;
						num++;
					}
					if (spawnPointNode.Spawn.Map == (WorldMap)this.cbxMap.SelectedItem && this.chkShowSpawns.Checked)
					{
						if (this.chkShade.Checked && this.cbxShade.SelectedIndex == 0)
						{
							short xleft;
							short ytop;
							short width;
							short height;
							if (spawnPointNode.Spawn.SpawnHomeRangeIsRelative)
							{
								xleft = (short)(spawnPointNode.Spawn.Bounds.X - spawnPointNode.Spawn.SpawnHomeRange);
								ytop = (short)(spawnPointNode.Spawn.Bounds.Y - spawnPointNode.Spawn.SpawnHomeRange);
								width = (short)(spawnPointNode.Spawn.Bounds.Width + 2 * spawnPointNode.Spawn.SpawnHomeRange);
								height = (short)(spawnPointNode.Spawn.Bounds.Height + 2 * spawnPointNode.Spawn.SpawnHomeRange);
							}
							else
							{
								xleft = (short)((int)spawnPointNode.Spawn.CentreX - spawnPointNode.Spawn.SpawnHomeRange);
								ytop = (short)((int)spawnPointNode.Spawn.CentreY - spawnPointNode.Spawn.SpawnHomeRange);
								width = (short)(spawnPointNode.Spawn.SpawnHomeRange * 2);
								height = (short)(spawnPointNode.Spawn.SpawnHomeRange * 2);
							}
							this.axUOMap.AddDrawRect(xleft, ytop, width, height, 1, SpawnEditor.ComputeDensityColor(spawnPointNode.Spawn));
						}
						else if (this.chkShade.Checked && this.cbxShade.SelectedIndex == 1)
						{
							short xleft2 = (short)spawnPointNode.Spawn.Bounds.X;
							short ytop2 = (short)spawnPointNode.Spawn.Bounds.Y;
							short width2 = (short)spawnPointNode.Spawn.Bounds.Width;
							short height2 = (short)spawnPointNode.Spawn.Bounds.Height;
							this.axUOMap.AddDrawRect(xleft2, ytop2, width2, height2, 1, SpawnEditor.ComputeSpeedColor(spawnPointNode.Spawn));
						}
						SpawnPoint spawn = spawnPointNode.Spawn;
						UOMapControl axUOMap = this.axUOMap;
						int num2 = (int)((short)spawnPointNode.Spawn.Bounds.X);
						int num3 = (int)((short)spawnPointNode.Spawn.Bounds.Y);
						int num4 = (int)((short)spawnPointNode.Spawn.Bounds.Width);
						int num5 = (int)((short)spawnPointNode.Spawn.Bounds.Height);
						int num6 = 2;
						int color = 16776960;
						int num7 = axUOMap.AddDrawRect((short)num2, (short)num3, (short)num4, (short)num5, (short)num6, color);
						spawn.Index = num7;
						short size4 = (short)(7 + (short)this.trkZoom.Value);
						if (spawnPointNode.Spawn.SpawnInContainer)
						{
							this.axUOMap.AddDrawObject(spawnPointNode.Spawn.CentreX, spawnPointNode.Spawn.CentreY, 6, size4, 16711935);
						}
						else
						{
							this.axUOMap.AddDrawObject(spawnPointNode.Spawn.CentreX, spawnPointNode.Spawn.CentreY, 3, size4, 16711680);
						}
					}
					flag = true;
					if (this.tvwSpawnPoints.SelectedNode != null && (this.tvwSpawnPoints.SelectedNode.Parent == null || this.tvwSpawnPoints.SelectedNode.Parent != spawnPointNode))
					{
						this.tvwSpawnPoints.SelectedNode = spawnPointNode;
						spawnPointNode.BackColor = Color.Yellow;
						spawnPointNode.EnsureVisible();
					}
					this.SelectedSpawn = spawnPointNode.Spawn;
				}
				else
				{
					spawnPointNode.BackColor = this.tvwSpawnPoints.BackColor;
					if (spawnPointNode.Filtered)
					{
						spawnPointNode.ForeColor = Color.LightGray;
					}
					else
					{
						spawnPointNode.ForeColor = this.tvwSpawnPoints.ForeColor;
						num++;
						if (spawnPointNode.Spawn.Map == (WorldMap)this.cbxMap.SelectedItem && this.chkShowSpawns.Checked)
						{
							if (this.chkShade.Checked && this.cbxShade.SelectedIndex == 0)
							{
								short xleft3;
								short ytop3;
								short width3;
								short height3;
								if (spawnPointNode.Spawn.SpawnHomeRangeIsRelative)
								{
									xleft3 = (short)(spawnPointNode.Spawn.Bounds.X - spawnPointNode.Spawn.SpawnHomeRange);
									ytop3 = (short)(spawnPointNode.Spawn.Bounds.Y - spawnPointNode.Spawn.SpawnHomeRange);
									width3 = (short)(spawnPointNode.Spawn.Bounds.Width + 2 * spawnPointNode.Spawn.SpawnHomeRange);
									height3 = (short)(spawnPointNode.Spawn.Bounds.Height + 2 * spawnPointNode.Spawn.SpawnHomeRange);
								}
								else
								{
									xleft3 = (short)((int)spawnPointNode.Spawn.CentreX - spawnPointNode.Spawn.SpawnHomeRange);
									ytop3 = (short)((int)spawnPointNode.Spawn.CentreY - spawnPointNode.Spawn.SpawnHomeRange);
									width3 = (short)(spawnPointNode.Spawn.SpawnHomeRange * 2);
									height3 = (short)(spawnPointNode.Spawn.SpawnHomeRange * 2);
								}
								this.axUOMap.AddDrawRect(xleft3, ytop3, width3, height3, 1, SpawnEditor.ComputeDensityColor(spawnPointNode.Spawn));
							}
							else if (this.chkShade.Checked && this.cbxShade.SelectedIndex == 1)
							{
								short xleft4 = (short)spawnPointNode.Spawn.Bounds.X;
								short ytop4 = (short)spawnPointNode.Spawn.Bounds.Y;
								short width4 = (short)spawnPointNode.Spawn.Bounds.Width;
								short height4 = (short)spawnPointNode.Spawn.Bounds.Height;
								this.axUOMap.AddDrawRect(xleft4, ytop4, width4, height4, 1, SpawnEditor.ComputeSpeedColor(spawnPointNode.Spawn));
							}
							SpawnPoint spawn2 = spawnPointNode.Spawn;
							UOMapControl axUOMap2 = this.axUOMap;
							int num8 = (int)((short)spawnPointNode.Spawn.Bounds.X);
							int num9 = (int)((short)spawnPointNode.Spawn.Bounds.Y);
							int num10 = (int)((short)spawnPointNode.Spawn.Bounds.Width);
							int num11 = (int)((short)spawnPointNode.Spawn.Bounds.Height);
							int num12 = 2;
							int color2 = 255;
							int num13 = axUOMap2.AddDrawRect((short)num8, (short)num9, (short)num10, (short)num11, (short)num12, color2);
							spawn2.Index = num13;
						}
					}
				}
			}
			this.lblTotalSpawn.Text = "Total Spawns = " + num.ToString();
			this.DisplaySpawnEntries();
			if (flag)
			{
				this.btnUpdateSpawn.Enabled = true;
				this.btnUpdateFromSpawnPack.Enabled = true;
				this.btnDeleteSpawn.Enabled = true;
				this.btnSendSingleSpawner.Enabled = true;
				this.btnMove.Enabled = true;
			}
			else
			{
				this.btnUpdateSpawn.Enabled = false;
				this.btnUpdateFromSpawnPack.Enabled = false;
				this.btnDeleteSpawn.Enabled = false;
				this.btnSendSingleSpawner.Enabled = false;
				this.btnMove.Enabled = false;
			}
			if (this._SelectionWindow != null)
			{
				this._SelectionWindow.Index = this.axUOMap.AddDrawRect(this._SelectionWindow.X, this._SelectionWindow.Y, this._SelectionWindow.Width, this._SelectionWindow.Height, 2, 16777215);
			}
			this.axUOMap.Refresh();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0001A73C File Offset: 0x0001893C
		private short GetZoomAdjustedSize(short DefaultSize)
		{
			if (this.axUOMap.ZoomLevel == 0)
			{
				return DefaultSize;
			}
			if (this.axUOMap.ZoomLevel > 0)
			{
				return (short)(Math.Pow(2.0, (double)this.axUOMap.ZoomLevel) * (double)DefaultSize);
			}
			short num = (short)(Math.Pow(2.0, (double)this.axUOMap.ZoomLevel) * (double)DefaultSize);
			if (num > 0)
			{
				return num;
			}
			return 1;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0001A7AC File Offset: 0x000189AC
		private void trkZoom_ValueChanged(object sender, EventArgs e)
		{
			this.axUOMap.ZoomLevel = (short)this.trkZoom.Value;
			this.stbMain.Text = this.DefaultZoomLevelText + this.axUOMap.ZoomLevel.ToString();
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0001A7FF File Offset: 0x000189FF
		private void chkDrawStatics_CheckedChanged(object sender, EventArgs e)
		{
			this.axUOMap.DrawStatics = this.chkDrawStatics.Checked;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0001A817 File Offset: 0x00018A17
		private void TypeSelectionChanged(object sender, EventArgs e)
		{
			if (!(sender is RadioButton) || !((RadioButton)sender).Checked)
			{
				return;
			}
			this.LoadTypes();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0001A835 File Offset: 0x00018A35
		private void LoadSpawnPacks()
		{
			this.ReadSpawnPacks(this.SpawnPackFile);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0001A844 File Offset: 0x00018A44
		private void LoadTypes()
		{
			this.clbRunUOTypes.BeginUpdate();
			this.clbRunUOTypes.Sorted = false;
			this.clbRunUOTypes.Items.Clear();
			foreach (Type type in this._RunUOScriptTypes)
			{
				if (!type.IsAbstract && type.IsPublic && type.IsClass)
				{
					ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
					if (constructor != null)
					{
						object[] customAttributes = constructor.GetCustomAttributes(true);
						bool flag = false;
						object[] array = customAttributes;
						for (int j = 0; j < array.Length; j++)
						{
							if (string.Compare(((Attribute)array[j]).GetType().Name, "ConstructableAttribute", true) == 0)
							{
								flag = true;
								break;
							}
						}
						if (flag && (this.radShowAll.Checked || this.radShowItemsOnly.Checked) && type.BaseType != null && type.BaseType.FullName.StartsWith("Server.Item"))
						{
							this.clbRunUOTypes.Items.Add(type.Name);
						}
						if (flag && (this.radShowAll.Checked || this.radShowMobilesOnly.Checked) && type.BaseType != null && type.BaseType.FullName.StartsWith("Server.Mobile"))
						{
							this.clbRunUOTypes.Items.Add(type.Name);
						}
					}
				}
			}
			this.clbRunUOTypes.Sorted = true;
			this.clbRunUOTypes.EndUpdate();
			this.lblTotalTypesLoaded.Text = "Types Loaded = " + this.clbRunUOTypes.Items.Count.ToString();
			this.SetSelectedSpawnTypes();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0001AA14 File Offset: 0x00018C14
		private void SetSelectedSpawnTypes()
		{
			if (this.tvwSpawnPoints.SelectedNode != null)
			{
				this.SelectedSpawnNode = this.tvwSpawnPoints.SelectedNode as SpawnPointNode;
				SpawnObjectNode spawnObjectNode = this.tvwSpawnPoints.SelectedNode as SpawnObjectNode;
				if (spawnObjectNode != null)
				{
					this.SelectedSpawnNode = (SpawnPointNode)spawnObjectNode.Parent;
				}
				this.clbRunUOTypes.ClearSelected();
				for (int index = 0; index < this.clbRunUOTypes.Items.Count; index++)
				{
					bool flag = false;
					IEnumerator enumerator = this.SelectedSpawnNode.Spawn.SpawnObjects.GetEnumerator();
					while (enumerator.MoveNext())
					{
						if (((SpawnObject)enumerator.Current).TypeName.ToUpper() == this.clbRunUOTypes.Items[index].ToString().ToUpper())
						{
							flag = true;
							break;
						}
					}
					this.clbRunUOTypes.SetItemChecked(index, flag);
				}
				return;
			}
			this.clbRunUOTypes.ClearSelected();
			for (int index2 = 0; index2 < this.clbRunUOTypes.Items.Count; index2++)
			{
				this.clbRunUOTypes.SetItemChecked(index2, false);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0001AB64 File Offset: 0x00018D64
		public void WriteSpawnPacks(string filename)
		{
			try
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(new StreamWriter(filename));
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.WriteStartDocument(true);
				xmlTextWriter.WriteStartElement("SpawnPacks");
				foreach (object obj in this.tvwSpawnPacks.Nodes)
				{
					SpawnPackNode spawnPackNode = (SpawnPackNode)obj;
					xmlTextWriter.WriteStartElement("Pack");
					xmlTextWriter.WriteAttributeString("name", spawnPackNode.PackName);
					for (int index = 0; index < spawnPackNode.Nodes.Count; index++)
					{
						xmlTextWriter.WriteStartElement("T");
						xmlTextWriter.WriteString(spawnPackNode.Nodes[index].Text);
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to save SpawnPack file [",
					filename,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0001ACAC File Offset: 0x00018EAC
		public void ReadSpawnPacks(string filePath)
		{
			if (filePath == null || filePath.Length == 0)
			{
				return;
			}
			if (!File.Exists(filePath))
			{
				return;
			}
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(filePath);
				XmlElement xmlElement = xmlDocument["SpawnPacks"];
				if (xmlElement != null)
				{
					foreach (object obj in xmlElement.GetElementsByTagName("Pack"))
					{
						XmlElement xmlElement3 = (XmlElement)obj;
						string packName = xmlElement3.Attributes.GetNamedItem("name").Value;
						ArrayList items = new ArrayList();
						foreach (object obj2 in xmlElement3.GetElementsByTagName("T"))
						{
							XmlElement xmlElement2 = (XmlElement)obj2;
							items.Add(xmlElement2.InnerText);
						}
						this.tvwSpawnPacks.Nodes.Add(new SpawnPackNode(packName, items));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to read SpawnPack file [",
					filePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0001AE24 File Offset: 0x00019024
		public void ExportSpawnTypes(string filename)
		{
			try
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(new StreamWriter(filename));
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.WriteStartDocument(true);
				xmlTextWriter.WriteStartElement("SpawnTypes");
				for (int index = 0; index < this.clbRunUOTypes.Items.Count; index++)
				{
					xmlTextWriter.WriteStartElement("T");
					xmlTextWriter.WriteString(this.clbRunUOTypes.Items[index].ToString());
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to save Spawn Types file [",
					filename,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0001AF04 File Offset: 0x00019104
		public void ImportSpawnTypes(string filePath)
		{
			if (filePath == null || filePath.Length == 0 || !File.Exists(filePath))
			{
				return;
			}
			this.clbRunUOTypes.BeginUpdate();
			this.clbRunUOTypes.Sorted = false;
			this.clbRunUOTypes.Items.Clear();
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(filePath);
				XmlElement xmlElement = xmlDocument["SpawnTypes"];
				if (xmlElement != null)
				{
					foreach (object obj in xmlElement.GetElementsByTagName("T"))
					{
						XmlNode xmlNode = (XmlNode)obj;
						this.clbRunUOTypes.Items.Add(xmlNode.InnerText);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to read Spawn Types file [",
					filePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.clbRunUOTypes.Sorted = true;
			this.clbRunUOTypes.EndUpdate();
			this.clbRunUOTypes.Refresh();
			this.lblTotalTypesLoaded.Text = "Types Loaded = " + this.clbRunUOTypes.Items.Count.ToString();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0001B06C File Offset: 0x0001926C
		internal void SaveSpawnFile(string FilePath)
		{
			FileStream fileStream;
			try
			{
				fileStream = File.Open(FilePath, FileMode.Create, FileAccess.Write);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to create file [",
					FilePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (fileStream == null)
			{
				MessageBox.Show(this, "Could not save file [" + FilePath + "]", "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			this.SaveSpawnFile(fileStream, FilePath, null);
			try
			{
				fileStream.Close();
			}
			catch
			{
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0001B11C File Offset: 0x0001931C
		private void SaveSpawnFile(Stream fs, string FilePath, SpawnPoint selectedspawn)
		{
			try
			{
				DataSet dataSet = new DataSet("Spawns");
				dataSet.Tables.Add("Points");
				dataSet.Tables["Points"].Columns.Add("Name");
				dataSet.Tables["Points"].Columns.Add("UniqueId");
				dataSet.Tables["Points"].Columns.Add("Map");
				dataSet.Tables["Points"].Columns.Add("X");
				dataSet.Tables["Points"].Columns.Add("Y");
				dataSet.Tables["Points"].Columns.Add("Width");
				dataSet.Tables["Points"].Columns.Add("Height");
				dataSet.Tables["Points"].Columns.Add("CentreX");
				dataSet.Tables["Points"].Columns.Add("CentreY");
				dataSet.Tables["Points"].Columns.Add("CentreZ");
				dataSet.Tables["Points"].Columns.Add("Range");
				dataSet.Tables["Points"].Columns.Add("MaxCount");
				dataSet.Tables["Points"].Columns.Add("MinDelay");
				dataSet.Tables["Points"].Columns.Add("MaxDelay");
				dataSet.Tables["Points"].Columns.Add("Team");
				dataSet.Tables["Points"].Columns.Add("IsGroup");
				dataSet.Tables["Points"].Columns.Add("IsRunning");
				dataSet.Tables["Points"].Columns.Add("IsHomeRangeRelative");
				dataSet.Tables["Points"].Columns.Add("DelayInSec");
				dataSet.Tables["Points"].Columns.Add("Duration");
				dataSet.Tables["Points"].Columns.Add("DespawnTime");
				dataSet.Tables["Points"].Columns.Add("ProximityRange");
				dataSet.Tables["Points"].Columns.Add("ProximityTriggerSound");
				dataSet.Tables["Points"].Columns.Add("ProximityTriggerMessage");
				dataSet.Tables["Points"].Columns.Add("ObjectPropertyName");
				dataSet.Tables["Points"].Columns.Add("ObjectPropertyItemName");
				dataSet.Tables["Points"].Columns.Add("SetPropertyItemName");
				dataSet.Tables["Points"].Columns.Add("ItemTriggerName");
				dataSet.Tables["Points"].Columns.Add("NoItemTriggerName");
				dataSet.Tables["Points"].Columns.Add("MobTriggerName");
				dataSet.Tables["Points"].Columns.Add("MobPropertyName");
				dataSet.Tables["Points"].Columns.Add("PlayerPropertyName");
				dataSet.Tables["Points"].Columns.Add("TriggerProbability");
				dataSet.Tables["Points"].Columns.Add("SpeechTrigger");
				dataSet.Tables["Points"].Columns.Add("SkillTrigger");
				dataSet.Tables["Points"].Columns.Add("InContainer");
				dataSet.Tables["Points"].Columns.Add("ContainerX");
				dataSet.Tables["Points"].Columns.Add("ContainerY");
				dataSet.Tables["Points"].Columns.Add("ContainerZ");
				dataSet.Tables["Points"].Columns.Add("MinRefractory");
				dataSet.Tables["Points"].Columns.Add("MaxRefractory");
				dataSet.Tables["Points"].Columns.Add("TODStart");
				dataSet.Tables["Points"].Columns.Add("TODEnd");
				dataSet.Tables["Points"].Columns.Add("TODMode");
				dataSet.Tables["Points"].Columns.Add("KillReset");
				dataSet.Tables["Points"].Columns.Add("ExternalTriggering");
				dataSet.Tables["Points"].Columns.Add("SequentialSpawning");
				dataSet.Tables["Points"].Columns.Add("RegionName");
				dataSet.Tables["Points"].Columns.Add("AllowGhostTriggering");
				dataSet.Tables["Points"].Columns.Add("SpawnOnTrigger");
				dataSet.Tables["Points"].Columns.Add("ConfigFile");
				dataSet.Tables["Points"].Columns.Add("SmartSpawning");
				dataSet.Tables["Points"].Columns.Add("WayPoint");
				dataSet.Tables["Points"].Columns.Add("Amount");
				dataSet.Tables["Points"].Columns.Add("Notes");
				dataSet.Tables["Points"].Columns.Add("Objects2");
				foreach (object obj in this.tvwSpawnPoints.Nodes)
				{
					SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
					if (!spawnPointNode.Filtered || selectedspawn != null)
					{
						SpawnPoint spawn = spawnPointNode.Spawn;
						if (selectedspawn == null || spawn == selectedspawn)
						{
							DataRow row = dataSet.Tables["Points"].NewRow();
							row["Name"] = spawn.SpawnName;
							row["UniqueId"] = spawn.UnqiueId.ToString();
							row["Map"] = spawn.Map.ToString();
							DataRow dataRow = row;
							string index = "X";
							int local = spawn.Bounds.X;
							dataRow[index] = local;
							DataRow dataRow2 = row;
							string index2 = "Y";
							ValueType local2 = spawn.Bounds.Y;
							dataRow2[index2] = local2;
							DataRow dataRow3 = row;
							string index3 = "Width";
							ValueType local3 = spawn.Bounds.Width;
							dataRow3[index3] = local3;
							DataRow dataRow4 = row;
							string index4 = "Height";
							ValueType local4 = spawn.Bounds.Height;
							dataRow4[index4] = local4;
							row["CentreX"] = spawn.CentreX;
							row["CentreY"] = spawn.CentreY;
							row["CentreZ"] = spawn.CentreZ;
							row["Range"] = spawn.SpawnHomeRange;
							row["MaxCount"] = spawn.SpawnMaxCount;
							row["MinDelay"] = (int)(spawn.SpawnMinDelay * 60.0);
							row["MaxDelay"] = (int)(spawn.SpawnMaxDelay * 60.0);
							row["Team"] = spawn.SpawnTeam;
							row["IsGroup"] = spawn.SpawnIsGroup;
							row["IsRunning"] = spawn.SpawnIsRunning;
							row["IsHomeRangeRelative"] = spawn.SpawnHomeRangeIsRelative;
							row["DelayInSec"] = true;
							row["Duration"] = spawn.SpawnDuration;
							row["DespawnTime"] = spawn.SpawnDespawn;
							row["ProximityRange"] = spawn.SpawnProximityRange;
							row["ProximityTriggerSound"] = spawn.SpawnProximitySnd;
							row["ProximityTriggerMessage"] = spawn.SpawnProximityMsg;
							row["ObjectPropertyName"] = spawn.SpawnTrigObjectProp;
							row["ObjectPropertyItemName"] = spawn.SpawnObjectPropertyItemName;
							row["SetPropertyItemName"] = spawn.SpawnSetPropertyItemName;
							row["ItemTriggerName"] = spawn.SpawnTriggerOnCarried;
							row["NoItemTriggerName"] = spawn.SpawnNoTriggerOnCarried;
							row["MobTriggerName"] = spawn.SpawnMobTriggerName;
							row["MobPropertyName"] = spawn.SpawnMobTrigProp;
							row["PlayerPropertyName"] = spawn.SpawnPlayerTrigProp;
							row["TriggerProbability"] = spawn.SpawnTriggerProbability;
							row["SpeechTrigger"] = spawn.SpawnSpeechTrigger;
							row["SkillTrigger"] = spawn.SpawnSkillTrigger;
							row["InContainer"] = spawn.SpawnInContainer;
							if (spawn.SpawnInContainer)
							{
								row["ContainerX"] = spawn.SpawnContainerX;
								row["ContainerY"] = spawn.SpawnContainerY;
								row["ContainerZ"] = spawn.SpawnContainerZ;
							}
							row["MinRefractory"] = spawn.SpawnMinRefract;
							row["MaxRefractory"] = spawn.SpawnMaxRefract;
							row["TODStart"] = spawn.SpawnTODStart * 60.0;
							row["TODEnd"] = spawn.SpawnTODEnd * 60.0;
							row["TODMode"] = spawn.SpawnTODMode;
							row["KillReset"] = spawn.SpawnKillReset;
							row["ExternalTriggering"] = spawn.SpawnExternalTriggering;
							row["SequentialSpawning"] = spawn.SpawnSequentialSpawn;
							row["RegionName"] = spawn.SpawnRegionName;
							row["AllowGhostTriggering"] = spawn.SpawnAllowGhost;
							row["SpawnOnTrigger"] = spawn.SpawnSpawnOnTrigger;
							row["ConfigFile"] = spawn.SpawnConfigFile;
							row["SmartSpawning"] = spawn.SpawnSmartSpawning;
							row["WayPoint"] = spawn.SpawnWaypoint;
							row["Amount"] = spawn.SpawnStackAmount;
							if (spawn.SpawnNotes != null && spawn.SpawnNotes.Trim().Length > 0)
							{
								row["Notes"] = spawn.SpawnNotes;
							}
							row["Objects2"] = spawn.GetSerializedObjectList2();
							dataSet.Tables["Points"].Rows.Add(row);
						}
					}
				}
				dataSet.WriteXml(fs);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to save file [",
					FilePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0001BEA8 File Offset: 0x0001A0A8
		internal void LoadSpawnFile(string FilePath, WorldMap ForceMap)
		{
			if (!File.Exists(FilePath))
			{
				return;
			}
			FileStream fileStream = null;
			try
			{
				fileStream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to open file [",
					FilePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Load Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.LoadSpawnFile(fileStream, FilePath, ForceMap);
			try
			{
				fileStream.Close();
			}
			catch
			{
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0001BF40 File Offset: 0x0001A140
		internal void LoadSpawnFile(Stream stream, string FilePath, WorldMap ForceMap)
		{
			if (stream == null)
			{
				MessageBox.Show(this, "Unable to Load Spawns: Empty Stream.", "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				this.tvwSpawnPoints.Sorted = false;
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(stream);
				XmlElement xmlElement = xmlDocument["Spawns"];
				if (xmlElement == null)
				{
					MessageBox.Show(this, "Invalid XML root.  Probably not an XmlSpawner file.", "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				new RectangleConverter();
				int num3 = 0;
				XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("Points");
				this.progressBar1.Visible = true;
				this.lblTransferStatus.Visible = true;
				this.trkZoom.Visible = false;
				this.lblTrkMin.Visible = false;
				this.lblTrkMax.Visible = false;
				this.lblTransferStatus.Text = "Processing Spawners...";
				this.lblTransferStatus.Refresh();
				this.progressBar1.Maximum = elementsByTagName.Count;
				this.tvwSpawnPoints.BeginUpdate();
				foreach (object obj in elementsByTagName)
				{
					XmlElement node = (XmlElement)obj;
					num3++;
					this.progressBar1.Value = num3;
					bool ForceGuid = false;
					if (ForceMap != WorldMap.Internal)
					{
						ForceGuid = true;
					}
					this.tvwSpawnPoints.Nodes.Add(new SpawnPointNode(new SpawnPoint(node, ForceMap, ForceGuid)));
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
				this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.txtName.Text = this._CfgDialog.CfgSpawnNameValue + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.RefreshSpawnPoints();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to load file [",
					FilePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Load Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.progressBar1.Visible = false;
			this.lblTransferStatus.Visible = false;
			this.trkZoom.Visible = true;
			this.lblTrkMin.Visible = true;
			this.lblTrkMax.Visible = true;
			this.progressBar1.Refresh();
			this.lblTransferStatus.Refresh();
			this.trkZoom.Refresh();
			this.lblTrkMin.Refresh();
			this.lblTrkMax.Refresh();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0001C208 File Offset: 0x0001A408
		internal void DSLoadSpawnFile(Stream stream, string FilePath, WorldMap ForceMap)
		{
			if (stream == null)
			{
				MessageBox.Show(this, "Unable to Load Spawns: Empty Stream.", "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			try
			{
				this.tvwSpawnPoints.Sorted = false;
				DataSet dataSet = new DataSet("Spawns");
				dataSet.ReadXml(stream);
				new RectangleConverter();
				this.progressBar1.Maximum = dataSet.Tables["Points"].Rows.Count;
				int num3 = 0;
				foreach (object obj in dataSet.Tables["Points"].Rows)
				{
					DataRow SpawnRow = (DataRow)obj;
					num3++;
					this.progressBar1.Value = num3;
					if (ForceMap != WorldMap.Internal)
					{
						if (!dataSet.Tables["Points"].Columns.Contains("Map"))
						{
							dataSet.Tables["Points"].Columns.Add("Map");
						}
						if (!dataSet.Tables["Points"].Columns.Contains("UniqueId"))
						{
							dataSet.Tables["Points"].Columns.Add("UniqueId");
						}
						SpawnRow["Map"] = ForceMap.ToString();
						SpawnRow["UniqueId"] = Guid.NewGuid().ToString();
					}
					this.tvwSpawnPoints.Nodes.Add(new SpawnPointNode(new SpawnPoint(SpawnRow)));
				}
				this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.txtName.Text = this._CfgDialog.CfgSpawnNameValue + this.tvwSpawnPoints.Nodes.Count.ToString();
				this.tvwSpawnPoints.Sorted = true;
				this.RefreshSpawnPoints();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Concat(new string[]
				{
					"Failed to load file [",
					FilePath,
					"] for the following reason:",
					Environment.NewLine,
					this.ExceptionMessage(ex)
				}), "Load Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0001C4A4 File Offset: 0x0001A6A4
		private void btnLoadSpawn_Click(object sender, EventArgs e)
		{
			try
			{
				this.ofdLoadFile.Title = "Load Spawn File";
				if (this.ofdLoadFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Text = "Spawn Editor 2 - " + this.ofdLoadFile.FileName;
					this.stbMain.Text = string.Format("Loading {0}...", this.ofdLoadFile.FileName);
					this.tvwSpawnPoints.Nodes.Clear();
					this.Refresh();
					this.LoadSpawnFile(this.ofdLoadFile.FileName, WorldMap.Internal);
				}
			}
			finally
			{
				this.stbMain.Text = "Finished loading spawn file.";
			}
			this.checkSpawnFilter.Checked = false;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0001C564 File Offset: 0x0001A764
		private void btnMergeSpawn_Click(object sender, EventArgs e)
		{
			try
			{
				this.ofdLoadFile.Title = "Merge Spawn File";
				if (this.ofdLoadFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Text = "Spawn Editor 2 - " + this.ofdLoadFile.FileName;
					this.stbMain.Text = string.Format("Merging {0}...", this.ofdLoadFile.FileName);
					this.Refresh();
					this.LoadSpawnFile(this.ofdLoadFile.FileName, (WorldMap)this.cbxMap.SelectedItem);
				}
			}
			finally
			{
				this.stbMain.Text = "Finished merging spawn file.";
			}
			this.checkSpawnFilter.Checked = false;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0001C624 File Offset: 0x0001A824
		private void btnSaveSpawn_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.sfdSaveFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Text = "Spawn Editor 2 - " + this.sfdSaveFile.FileName;
					this.stbMain.Text = string.Format("Saving {0}...", this.ofdLoadFile.FileName);
					this.Refresh();
					this.SaveSpawnFile(this.sfdSaveFile.FileName);
				}
			}
			finally
			{
				this.stbMain.Text = "Finished saving spawn file.";
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0001C6B8 File Offset: 0x0001A8B8
		private void btnSaveTemplate_Click(object sender, EventArgs e)
		{
			if (this.SelectedSpawnNode == null)
			{
				MessageBox.Show("You must select a spawne first.", "OOPS...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (MessageBox.Show("The selected spawn on the LEFT will be saved as a template.", "INFORMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
			{
				return;
			}
			try
			{
				if (this.sfdSaveFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Text = "Spawn Editor 2 - " + this.sfdSaveFile.FileName;
					this.stbMain.Text = string.Format("Saving {0}...", this.sfdSaveFile.FileName);
					this.Refresh();
					string FilePath = this.sfdSaveFile.FileName;
					FileStream fileStream;
					try
					{
						// Dump CalibrationInfo list (if available) for diagnostics
						try
						{
							var asmList = AppDomain.CurrentDomain.GetAssemblies();
							Type calType = null;
							foreach (var a in asmList)
							{
								calType = a.GetType("Ultima.CalibrationInfo");
								if (calType != null) break;
							}
							if (calType == null)
							{
								SpawnEditor.LogWarning("TrackerLoop: CalibrationInfo type not found in loaded assemblies");
							}
							else
							{
								MethodInfo getList = calType.GetMethod("GetList", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
								object listObj = null;
								if (getList != null)
								{
									listObj = getList.Invoke(null, null);
								}
								else
								{
									FieldInfo defField = calType.GetField("m_DefaultList", BindingFlags.Static | BindingFlags.NonPublic);
									if (defField != null) listObj = defField.GetValue(null);
								}
								if (listObj == null)
								{
									SpawnEditor.LogWarning("TrackerLoop: CalibrationInfo list not available (GetList/m_DefaultList returned null)");
								}
								else
								{
									var ie = listObj as System.Collections.IEnumerable;
									int idx = 0;
									foreach (var entry in ie)
									{
										if (idx >= 8) break;
										Type et = entry.GetType();
										StringBuilder sb = new StringBuilder();
										sb.Append("CalibrationEntry[" + idx + "] Type=" + et.FullName + " ");
										foreach (var f in et.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
										{
											object val = null;
											try { val = f.GetValue(entry); } catch { val = "<err>"; }
											sb.Append(f.Name + "=" + (val ?? "<null>") + " ");
										}
										foreach (var p in et.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
										{
											object val = null;
											try { val = p.GetValue(entry, null); } catch { val = "<err>"; }
											sb.Append(p.Name + "=" + (val ?? "<null>") + " ");
										}
										SpawnEditor.LogWarning(sb.ToString());
										idx++;
									}
								}
							}
						}
						catch (Exception ex)
						{
							SpawnEditor.LogWarning("TrackerLoop: dumping CalibrationInfo failed: " + ex.Message);
						}
						
						fileStream = File.Open(FilePath, FileMode.Create, FileAccess.Write);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, string.Concat(new string[]
						{
							"Failed to create file [",
							FilePath,
							"] for the following reason:",
							Environment.NewLine,
							this.ExceptionMessage(ex)
						}), "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					if (fileStream == null)
					{
						MessageBox.Show(this, "Could not save file [" + FilePath + "]", "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						this.SaveSpawnFile(fileStream, FilePath, this.SelectedSpawnNode.Spawn);
						try
						{
							fileStream.Close();
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				this.stbMain.Text = "Finished saving spawn file.";
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0001C824 File Offset: 0x0001AA24
		private void btnLoadTemplate_Click(object sender, EventArgs e)
		{
			try
			{
				this.ofdLoadFile.Title = "Load Spawn File";
				if (this.ofdLoadFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Text = "Spawn Editor 2 - " + this.ofdLoadFile.FileName;
					this.stbMain.Text = string.Format("Loading {0}...", this.ofdLoadFile.FileName);
					this.Refresh();
					string FilePath = this.ofdLoadFile.FileName;
					WorldMap ForceMap = WorldMap.Internal;
					if (!File.Exists(FilePath))
					{
						return;
					}
					FileStream fileStream = null;
					try
					{
						fileStream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, string.Concat(new string[]
						{
							"Failed to open file [",
							FilePath,
							"] for the following reason:",
							Environment.NewLine,
							this.ExceptionMessage(ex)
						}), "Load Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					if (fileStream == null)
					{
						MessageBox.Show(this, "Unable to Load Spawns: Empty Stream.", "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						try
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.Load(fileStream);
							XmlElement xmlElement = xmlDocument["Spawns"];
							if (xmlElement == null)
							{
								MessageBox.Show(this, "Invalid XML root.  Probably not an XmlSpawner file.", "Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								return;
							}
							new RectangleConverter();
							int num3 = 0;
							XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName("Points");
							this.progressBar1.Visible = true;
							this.lblTransferStatus.Visible = true;
							this.trkZoom.Visible = false;
							this.lblTrkMin.Visible = false;
							this.lblTrkMax.Visible = false;
							this.lblTransferStatus.Text = "Processing Spawners...";
							this.lblTransferStatus.Refresh();
							this.progressBar1.Maximum = elementsByTagName.Count;
							this.tvwTemplates.BeginUpdate();
							foreach (object obj in elementsByTagName)
							{
								XmlElement node = (XmlElement)obj;
								num3++;
								this.progressBar1.Value = num3;
								bool ForceGuid = false;
								this.tvwTemplates.Nodes.Add(new SpawnPointNode(new SpawnPoint(node, ForceMap, ForceGuid)));
							}
							this.tvwTemplates.Update();
							this.tvwTemplates.Refresh();
							this.tvwSpawnPoints.Sorted = true;
							this.tvwTemplates.EndUpdate();
							this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
							this.txtName.Text = this._CfgDialog.CfgSpawnNameValue + this.tvwSpawnPoints.Nodes.Count.ToString();
							this.RefreshSpawnPoints();
						}
						catch (Exception ex2)
						{
							MessageBox.Show(this, string.Concat(new string[]
							{
								"Failed to load file [",
								FilePath,
								"] for the following reason:",
								Environment.NewLine,
								this.ExceptionMessage(ex2)
							}), "Load Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						this.progressBar1.Visible = false;
						this.lblTransferStatus.Visible = false;
						this.trkZoom.Visible = true;
						this.lblTrkMin.Visible = true;
						this.lblTrkMax.Visible = true;
						this.progressBar1.Refresh();
						this.lblTransferStatus.Refresh();
						this.trkZoom.Refresh();
						this.lblTrkMin.Refresh();
						this.lblTrkMax.Refresh();
						this.btnMergeTemplate.Enabled = true;
					}
					try
					{
						fileStream.Close();
					}
					catch
					{
					}
				}
			}
			finally
			{
				this.stbMain.Text = "Finished loading spawn file.";
			}
			this.checkSpawnFilter.Checked = false;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0001CC50 File Offset: 0x0001AE50
		private void btnMergeTemplate_Click(object sender, EventArgs e)
		{
			if (this.SelectedTemplateNode == null)
			{
				MessageBox.Show("You must select a template first.", "OOPS...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.SelectedSpawnNode != null)
			{
				this.SelectedTemplateNode.Spawn.CopyToSpawnArgument(this.SelectedSpawnNode.Spawn);
				this.RefreshSpawnPoints();
				this.UpdateSpawnEntries();
				this.UpdateSpawnNode();
				return;
			}
			MessageBox.Show("You must load a spawn first.", "OOPS...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0001CCC4 File Offset: 0x0001AEC4
		private void btnResetTypes_Click(object sender, EventArgs e)
		{
			this.clbRunUOTypes.ClearSelected();
			for (int index = 0; index < this.clbRunUOTypes.Items.Count; index++)
			{
				this.clbRunUOTypes.SetItemChecked(index, false);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0001CD04 File Offset: 0x0001AF04
		private void btnUpdateSpawn_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tvwSpawnPoints.SelectedNode;
			this.SelectedSpawnNode = selectedNode as SpawnPointNode;
			SpawnObjectNode spawnObjectNode = selectedNode as SpawnObjectNode;
			if (spawnObjectNode != null)
			{
				this.SelectedSpawnNode = spawnObjectNode.Parent as SpawnPointNode;
			}
			if (this.SelectedSpawnNode != null)
			{
				this.SetSpawn(this.SelectedSpawnNode, true);
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0001CD60 File Offset: 0x0001AF60
		private void SetSpawn(SpawnPointNode SpawnNode, bool IsUpdate)
		{
			this.UpdateSpawnDetails(SpawnNode.Spawn);
			foreach (object obj in this.clbRunUOTypes.CheckedItems)
			{
				string name = (string)obj;
				bool flag = false;
				foreach (object obj2 in SpawnNode.Spawn.SpawnObjects)
				{
					SpawnObject spawnObject = (SpawnObject)obj2;
					if (name.ToUpper() == spawnObject.TypeName.ToUpper())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					SpawnNode.Spawn.SpawnObjects.Add(new SpawnObject(name, 1));
				}
			}
			this.UpdateSpawnerMaxCount();
			SpawnNode.UpdateNode();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0001CE5C File Offset: 0x0001B05C
		private void SetSpawnFromSpawnPack(SpawnPointNode SpawnNode, bool IsUpdate)
		{
			this.UpdateSpawnDetails(SpawnNode.Spawn);
			foreach (object obj in this.clbSpawnPack.CheckedItems)
			{
				string name = (string)obj;
				bool flag = false;
				foreach (object obj2 in SpawnNode.Spawn.SpawnObjects)
				{
					SpawnObject spawnObject = (SpawnObject)obj2;
					if (name.ToUpper() == spawnObject.TypeName.ToUpper())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					SpawnNode.Spawn.SpawnObjects.Add(new SpawnObject(name, 1));
				}
			}
			this.UpdateSpawnerMaxCount();
			SpawnNode.UpdateNode();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0001CF58 File Offset: 0x0001B158
		private void btnDeleteSpawn_Click(object sender, EventArgs e)
		{
			this.mniDeleteSpawn_Click(sender, e);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0001CF64 File Offset: 0x0001B164
		private void TextEntryControl_Enter(object sender, EventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox textBox = (TextBox)sender;
				textBox.Select(0, textBox.MaxLength);
				return;
			}
			if (!(sender is NumericUpDown))
			{
				return;
			}
			((UpDownBase)sender).Select(0, int.MaxValue);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0001CFA8 File Offset: 0x0001B1A8
		private void btnConfigure_Click(object sender, EventArgs e)
		{
			this.UpdateMyLocation();
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0001CFB6 File Offset: 0x0001B1B6
		protected override void OnClosing(CancelEventArgs e)
		{
			this.Tracking = false;
			try { this.StopAuthPosTimer(); } catch { }
			base.OnClosing(e);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0001CFC6 File Offset: 0x0001B1C6
		public void ActivateTracking()
		{
			string windowConfig = this._CfgDialog.CfgUoClientWindowValue;
			int pid;
			if (int.TryParse(windowConfig, out pid) && pid > 0)
			{
				// PID mode: inject the HWND into Ultima.Client, then calibrate
				if (this.EnsureClientHandle())
				{
					Client.Calibrate();
				}
			}
			else
			{
				// Legacy window-name mode
				Client.Calibrate();
			}
			new Thread(new ThreadStart(new SpawnEditor.TrackerThread(this).TrackerThreadMain))
			{
				Name = "Tracker Thread"
			}.Start();

			// start auth-position poller only if Track flag is enabled
			try
			{
				if (this.Tracking || (this.chkTracking != null && this.chkTracking.Checked))
				{
					this.StartAuthPosTimer();
				}
			}
			catch { }
		}

		private void StartAuthPosTimer()
		{
			if (this._AuthPosTimer != null) return;
			this._AuthPosTimer = new System.Threading.Timer((s) => { try { this.QueryAndHandleAuthPosition(); } catch { } }, null, 0, this._AuthPosIntervalMs);
		}

		private void StopAuthPosTimer()
		{
			try
			{
				if (this._AuthPosTimer != null)
				{
					this._AuthPosTimer.Dispose();
					this._AuthPosTimer = null;
				}
			}
			catch { }
		}

		private void QueryAndHandleAuthPosition()
		{
			try
			{
				if (this._TransferDialog == null) return;
				string addr = this._TransferDialog.txtTransferServerAddress.Text;
				int port = 8032;
				try { port = int.Parse(this._TransferDialog.txtTransferServerPort.Text); } catch { }
				// debug log removed
				QueryAuthPosition q = new QueryAuthPosition();
				q.AuthenticationID = this.SessionID;
				q.UseMainThread = true;
				TransferMessage resp = null;
				try { resp = TransferConnection.ProcessMessage(addr, port, q); } catch (Exception ex) { SpawnEditor.LogWarning("AuthPoll: ProcessMessage failed: " + ex.Message); return; }
				if (resp == null) { SpawnEditor.LogWarning("AuthPoll: null response"); return; }
				if (resp is ReturnAuthPosition)
				{
					ReturnAuthPosition r = (ReturnAuthPosition)resp;
					this.Invoke((MethodInvoker)delegate {
						this.MyLocation.X = r.X;
						this.MyLocation.Y = r.Y;
						this.MyLocation.Z = r.Z;
						this.MyLocation.Facet = r.Map;
						this.DisplayMyLocation();
					});
					SpawnEditor.LogWarning("AuthPoll: X=" + r.X + " Y=" + r.Y + " Z=" + r.Z + " Map=" + r.Map);
				}
				else if (resp is ErrorMessage)
				{
					SpawnEditor.LogWarning("AuthPoll: Error - " + ((ErrorMessage)resp).Message);
				}
			}
			catch (Exception ex)
			{
				SpawnEditor.LogWarning("QueryAndHandleAuthPosition exception: " + ex.Message);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0001CFF4 File Offset: 0x0001B1F4
		public void UpdateMyLocation()
		{
			// Server-only tracking mode: disable legacy memory-based reading and
			// use the server poller to obtain authenticated player position.
			SpawnEditor.Debug("=== UpdateMyLocation() STARTED (server-only) ===");
			try
			{
				// Query the server and let QueryAndHandleAuthPosition update MyLocation/UI.
				this.QueryAndHandleAuthPosition();
			}
			catch (Exception ex)
			{
				SpawnEditor.LogWarning("UpdateMyLocation: server query failed: " + ex.Message);
			}
			SpawnEditor.Debug("=== UpdateMyLocation() COMPLETED (server-only) ===");
		}

		internal bool TryGetLocationFromMemory(ref int x, ref int y, ref int z, ref int facet)
		{
			try
			{
				string windowConfig = this._CfgDialog.CfgUoClientWindowValue;
				
				int pid;
				if (!int.TryParse(windowConfig, out pid) || pid <= 0)
				{
					return false;
				}

				Process proc;
				try
				{
					proc = Process.GetProcessById(pid);
				}
				catch
				{
					return false;
				}
				if (proc == null || proc.HasExited)
				{
					return false;
				}

				// Try to parse coordinates from the window title if available
				// Some clients include coordinates in the title bar
				string title = proc.MainWindowTitle;
				if (!string.IsNullOrEmpty(title))
				{
					// Look for coordinate patterns like (1234, 5678, 10) in title
					var match = System.Text.RegularExpressions.Regex.Match(title,
						@"\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(-?\d+)\s*\)");
					if (match.Success)
					{
						x = int.Parse(match.Groups[1].Value);
						y = int.Parse(match.Groups[2].Value);
						z = int.Parse(match.Groups[3].Value);
						// Facet not in title - keep current map selection
						facet = this.cbxMap.SelectedIndex;
						if (x >= 0 && x <= 8191 && y >= 0 && y <= 8191 && facet >= 0 && facet <= 5)
						{
							return true;
						}
					}
				}

				// If title parsing failed, do not attempt process memory scanning.
				// Memory-based scanning has been removed; rely on server-provided position only.
				SpawnEditor.LogWarning("TryGetLocationFromMemory: memory scan disabled by configuration");
				return false;
			}
			catch (Exception ex)
			{
				SpawnEditor.LogWarning("TryGetLocationFromMemory failed: " + ex.Message);
				return false;
			}
		}

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr dwSize, out IntPtr lpNumberOfBytesRead);

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		private const int PROCESS_VM_READ = 0x0010;
		private const int CHUNK_SIZE = 0x10000; // 64KB
		private bool _didTargetCoordSearch = false;

		private string HexDump(byte[] buf, int start, int len)
		{
			if (buf == null) return "";
			int end = Math.Min(buf.Length, start + len);
			StringBuilder sb = new StringBuilder();
			for (int i = start; i < end; i++)
			{
				sb.AppendFormat("{0:X2}", buf[i]);
				if ((i - start + 1) % 16 == 0) sb.Append(" ");
			}
			return sb.ToString();
		}

		private void ScanForTargetCoordinatesOnce(int targetX, int targetY)
		{
			// Memory target scanning disabled.
			this._didTargetCoordSearch = true;
			SpawnEditor.LogWarning("ScanForTargetCoordinatesOnce: disabled (memory scanning removed)");
			return;
		}

		private bool _didDiffScan = false;

		private void ScanForChangingCoordinates(int sampleDelayMs)
		{
			// Memory difference scanning disabled.
			this._didDiffScan = true;
			SpawnEditor.LogWarning("ScanForChangingCoordinates: disabled (memory scanning removed)");
			return;
		}

		private bool TryGetLocationFromMemoryByScan(int pid, out int outX, out int outY, out int outZ)
		{
			// Memory scanning disabled — return false to indicate no data.
			outX = outY = outZ = 0;
			SpawnEditor.LogWarning("TryGetLocationFromMemoryByScan: disabled (memory scanning removed)");
			return false;
		}

		/// <summary>
		/// If config contains a PID, inject the process MainWindowHandle into
		/// Ultima.Client.m_Handle via reflection so that Client.Calibrate/FindLocation
		/// can work with ClassicUO and other non-standard clients.
		/// Returns true if the client handle is valid after the call.
		/// </summary>
		internal bool EnsureClientHandle()
		{
			try
			{
				string windowConfig = this._CfgDialog.CfgUoClientWindowValue;
				int pid;
				if (!int.TryParse(windowConfig, out pid) || pid <= 0)
				{
					return false;
				}

				Process proc;
				try
				{
					proc = Process.GetProcessById(pid);
				}
				catch
				{
					return false;
				}
				if (proc == null || proc.HasExited || proc.MainWindowHandle == IntPtr.Zero)
				{
					return false;
				}

				// Inject the HWND into Ultima.Client.m_Handle via reflection
				FieldInfo handleField = typeof(Client).GetField("m_Handle",
					BindingFlags.Static | BindingFlags.NonPublic);
				if (handleField == null)
				{
					SpawnEditor.LogWarning("EnsureClientHandle: Ultima.Client.m_Handle field not found via reflection");
				}
				else
				{
					try
					{
						IntPtr currentHandle = (IntPtr)handleField.GetValue(null);
						SpawnEditor.LogWarning("EnsureClientHandle: currentHandle=" + currentHandle + " proc.MainWindowHandle=" + proc.MainWindowHandle);
						if (currentHandle != proc.MainWindowHandle)
						{
							handleField.SetValue(null, proc.MainWindowHandle);
							SpawnEditor.LogWarning("EnsureClientHandle: m_Handle updated to proc.MainWindowHandle");
						}
					}
					catch (Exception ex)
					{
						SpawnEditor.LogWarning("EnsureClientHandle: reflection set/get failed: " + ex.Message);
					}
				}
				SpawnEditor.LogWarning("EnsureClientHandle: Client.Running=" + Client.Running);
				return Client.Running;
			}
			catch (Exception ex)
			{
				SpawnEditor.LogWarning("EnsureClientHandle failed: " + ex.Message);
				return false;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0001D09C File Offset: 0x0001B29C
		public void DisplayMyLocation()
		{
			if (this.cbxMap.SelectedIndex != this.MyLocation.Facet)
			{
				return;
			}
			this.axUOMap.RemoveDrawObjects();
			this.axUOMap.AddDrawObject((short)this.MyLocation.X, (short)this.MyLocation.Y, 1, 12, 65280);
			this.axUOMap.AddDrawObject((short)this.MyLocation.X, (short)this.MyLocation.Y, 3, 2, 255);

			// Force immediate repaint so the marker updates in real-time
			try
			{
				this.axUOMap.Invalidate();
				this.axUOMap.Update();
			}
			catch { }
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0001D124 File Offset: 0x0001B324
		private void mncSpawns_Popup(object sender, EventArgs e)
		{
			if (this.mncSpawns.SourceControl != this.tvwSpawnPoints)
			{
				return;
			}
			foreach (object obj in this.mncSpawns.MenuItems)
			{
				((MenuItem)obj).Visible = false;
			}
			if (this.tvwSpawnPoints.SelectedNode is SpawnPointNode)
			{
				this.mniDeleteSpawn.Visible = true;
			}
			else if (this.tvwSpawnPoints.SelectedNode is SpawnObjectNode)
			{
				this.mniDeleteSpawn.Visible = true;
			}
			if (this.tvwSpawnPoints.Nodes.Count <= 0)
			{
				return;
			}
			this.mniDeleteAllSpawns.Visible = true;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0001D1F4 File Offset: 0x0001B3F4
		private void btnRestoreSpawnDefaults_Click(object sender, EventArgs e)
		{
			this.LoadDefaultSpawnValues();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0001D1FC File Offset: 0x0001B3FC
		private void tvwSpawnPoints_MouseUp(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = this.tvwSpawnPoints.GetNodeAt(e.X, e.Y);
			if (nodeAt == null)
			{
				return;
			}
			this.tvwSpawnPoints.Refresh();
			this.SelectedSpawnNode = nodeAt as SpawnPointNode;
			SpawnObjectNode spawnObjectNode = nodeAt as SpawnObjectNode;
			if (spawnObjectNode != null)
			{
				this.SelectedSpawnNode = (SpawnPointNode)spawnObjectNode.Parent;
			}
			if (this.SelectedSpawnNode != null)
			{
				this.SelectedSpawn = this.SelectedSpawnNode.Spawn;
				foreach (object obj in this.tvwSpawnPoints.Nodes)
				{
					((SpawnPointNode)obj).Spawn.IsSelected = false;
				}
				this.SelectedSpawn.IsSelected = true;
				this.SendGoCommand(this.SelectedSpawn);
				if (this.SelectedSpawn.Map != (WorldMap)this.cbxMap.SelectedItem)
				{
					this.cbxMap.SelectedItem = this.SelectedSpawn.Map;
				}
				this.DisplaySpawnDetails(this.SelectedSpawn);
				this.DisplaySpawnEntries();
				this.RefreshSpawnPoints();
			}
			if (e.Button == MouseButtons.Right)
			{
				this.tvwSpawnPoints.SelectedNode = nodeAt;
				this.mncSpawns.Show(this.tvwSpawnPoints, new Point(e.X, e.Y));
			}
			this.SetSelectedSpawnTypes();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0001D370 File Offset: 0x0001B570
		private void tvwTemplates_MouseUp(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = this.tvwTemplates.GetNodeAt(e.X, e.Y);
			if (nodeAt == null)
			{
				return;
			}
			this.tvwTemplates.Refresh();
			this.SelectedTemplateNode = nodeAt as SpawnPointNode;
			SpawnObjectNode spawnObjectNode = nodeAt as SpawnObjectNode;
			if (spawnObjectNode != null)
			{
				this.SelectedTemplateNode = (SpawnPointNode)spawnObjectNode.Parent;
			}
			if (this.SelectedTemplateNode != null)
			{
				this.SelectedTemplate = this.SelectedTemplateNode.Spawn;
				foreach (object obj in this.tvwTemplates.Nodes)
				{
					((SpawnPointNode)obj).Spawn.IsSelected = false;
				}
				this.SelectedTemplate.IsSelected = true;
			}
			if (e.Button == MouseButtons.Right)
			{
				this.tvwTemplates.SelectedNode = nodeAt;
				this.mncSpawns.Show(this.tvwTemplates, new Point(e.X, e.Y));
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0001D480 File Offset: 0x0001B680
		private void mniDeleteAllSpawns_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tvwSpawnPoints.SelectedNode;
			if (selectedNode is SpawnObjectNode)
			{
				SpawnPointNode spawnPointNode2 = (SpawnPointNode)selectedNode.Parent;
				if (MessageBox.Show(this, "Are you sure you want to delete all objects from spawn [" + spawnPointNode2.Spawn.SpawnName + "]?", "Delete All Spawn Objects", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					spawnPointNode2.Nodes.Clear();
					if (spawnPointNode2.Spawn.SpawnObjects != null)
					{
						spawnPointNode2.Spawn.SpawnObjects.Clear();
					}
				}
			}
			else
			{
				this.DeleteAllSpawns();
			}
			this.SetSelectedSpawnTypes();
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0001D514 File Offset: 0x0001B714
		private void mniDeleteSpawn_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tvwSpawnPoints.SelectedNode;
			if (selectedNode is SpawnPointNode)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)selectedNode;
				if (MessageBox.Show(this, "Are you sure you want to delete spawn [" + spawnPointNode.Spawn.SpawnName + "] from the list?", "Delete Spawn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					spawnPointNode.Remove();
					this.SelectedSpawn = null;
					this.LoadDefaultSpawnValues();
				}
			}
			else if (selectedNode is SpawnObjectNode)
			{
				SpawnObjectNode spawnObjectNode = (SpawnObjectNode)selectedNode;
				if (MessageBox.Show(this, "Are you sure you want to delete object [" + spawnObjectNode.SpawnObject.TypeName + "] from the spawn?", "Delete Spawn Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					((SpawnPointNode)spawnObjectNode.Parent).Spawn.SpawnObjects.Remove(spawnObjectNode.SpawnObject);
					spawnObjectNode.Remove();
				}
			}
			this.SetSelectedSpawnTypes();
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0001D5E8 File Offset: 0x0001B7E8
		private void mniSetSpawnAmount_Click(object sender, EventArgs e)
		{
			SpawnObjectNode spawnObjectNode = this.tvwSpawnPoints.SelectedNode as SpawnObjectNode;
			if (spawnObjectNode == null)
			{
				return;
			}
			Amount amount = new Amount(spawnObjectNode.SpawnObject.TypeName, spawnObjectNode.SpawnObject.Count);
			if (amount.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			spawnObjectNode.SpawnObject.Count = amount.SpawnAmount;
			spawnObjectNode.UpdateNode();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0001D648 File Offset: 0x0001B848
		private void chkShowSpawns_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0001D650 File Offset: 0x0001B850
		private void btnMove_Click(object sender, EventArgs e)
		{
			this.SelectedSpawnNode = this.tvwSpawnPoints.SelectedNode as SpawnPointNode;
			SpawnObjectNode spawnObjectNode = this.tvwSpawnPoints.SelectedNode as SpawnObjectNode;
			if (spawnObjectNode != null)
			{
				this.SelectedSpawnNode = (SpawnPointNode)spawnObjectNode.Parent;
			}
			if (this.SelectedSpawnNode == null)
			{
				return;
			}
			new Area(this.SelectedSpawnNode.Spawn, this).ShowDialog(this);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0001D6B9 File Offset: 0x0001B8B9
		private void ClearSelectionWindow()
		{
			this._SelectionWindow = null;
			this.EnableSelectionWindowOption(false);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0001D6CC File Offset: 0x0001B8CC
		private void cbxMap_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ClearSelectionWindow();
			this.stbMain.Text = this.cbxMap.SelectedItem.ToString() + " Map Selected";
			this.stbMain.Refresh();
			int num = 0;
			int num2 = 0;
			switch ((WorldMap)this.cbxMap.SelectedItem)
			{
			case WorldMap.Felucca:
				this.axUOMap.MapFile = 0;
				num = this.MapLoc[0].X;
				num2 = this.MapLoc[0].Y;
				break;
			case WorldMap.Trammel:
				this.axUOMap.MapFile = 1;
				num = this.MapLoc[1].X;
				num2 = this.MapLoc[1].Y;
				break;
			case WorldMap.Ilshenar:
				this.axUOMap.MapFile = 2;
				num = this.MapLoc[2].X;
				num2 = this.MapLoc[2].Y;
				break;
			case WorldMap.Malas:
				this.axUOMap.MapFile = 3;
				num = this.MapLoc[3].X;
				num2 = this.MapLoc[3].Y;
				break;
			case WorldMap.Tokuno:
				this.axUOMap.MapFile = 4;
				num = this.MapLoc[4].X;
				num2 = this.MapLoc[4].Y;
				break;
			}
			this.axUOMap.SetCenter((short)num, (short)num2);
			this.axUOMap.xCenter = (short)num;
			this.axUOMap.yCenter = (short)num2;
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000E4 RID: 228
		[DllImport("User32.dll", EntryPoint = "SendMessageA")]
		public static extern int SendMessage(int _WindowHandler, int _WM_USER, int _data, int _id);

		// Token: 0x060000E5 RID: 229
		[DllImport("User32.dll", EntryPoint = "FindWindowA")]
		public static extern int FindWindow(string _ClassName, string _WindowName);

		// Token: 0x060000E6 RID: 230
		[DllImport("User32.dll")]
		public static extern bool SetForegroundWindow(int hWnd);

		[DllImport("User32.dll")]
		private static extern IntPtr GetForegroundWindow();

		private void SendStringToWindow(int windowHandle, string text)
		{
			IntPtr previousForeground = GetForegroundWindow();

			SetForegroundWindow(windowHandle);
			System.Threading.Thread.Sleep(200);

			// Send Enter to open chat line
			SendKeys.SendWait("{ENTER}");
			System.Threading.Thread.Sleep(150);

			// Send each character individually to avoid SendKeys special char issues
			foreach (char c in text)
			{
				// Escape SendKeys special characters: +^%~(){}
				if (c == '+' || c == '^' || c == '%' || c == '~' ||
				    c == '(' || c == ')' || c == '{' || c == '}')
				{
					SendKeys.SendWait("{" + c + "}");
				}
				else
				{
					SendKeys.SendWait(c.ToString());
				}
			}

			// Send Enter to execute command
			System.Threading.Thread.Sleep(100);
			SendKeys.SendWait("{ENTER}");
			System.Threading.Thread.Sleep(100);

			// Restore previous window focus
			if (previousForeground != IntPtr.Zero)
			{
				SetForegroundWindow(previousForeground.ToInt32());
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0001D848 File Offset: 0x0001BA48
		public void SendGoCommand(SpawnPoint Spawn)
		{
			short X = Spawn.CentreX;
			short Y = Spawn.CentreY;
			short Z = Spawn.CentreZ;
			if (this.chkSnapRegion.Checked)
			{
				int x = Spawn.Bounds.X;
				int num = Spawn.Bounds.Width / 2;
				X = (short)(x + num);
				int y = Spawn.Bounds.Y;
				int num2 = Spawn.Bounds.Height / 2;
				Y = (short)(y + num2);
				Z = short.MinValue;
			}
			if (this.chkSyncUO.Checked)
			{
				this.SendGoCommand(X, Y, Z, Spawn.Map);
			}
			this.AssignCenter(X, Y, (short)Spawn.Map);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0001D8F4 File Offset: 0x0001BAF4
		private int GetUoClientWindowHandle()
		{
			if (this._CfgDialog == null)
			{
				return 0;
			}
			string windowConfig = this._CfgDialog.CfgUoClientWindowValue;
			
			// First, try to use it as a process ID
			if (int.TryParse(windowConfig, out int pid) && pid > 0)
			{
				try
				{
					Process proc = Process.GetProcessById(pid);
					if (proc != null)
					{
						// Try to get the main window handle
						if (proc.MainWindowHandle != IntPtr.Zero)
						{
							return proc.MainWindowHandle.ToInt32();
						}
						
						// If no main window, search for any visible window by process ID
						IntPtr foundWindow = FindWindowByProcessId(pid);
						if (foundWindow != IntPtr.Zero)
						{
							return foundWindow.ToInt32();
						}
					}
				}
				catch
				{
					// Process not found, continue to fallback
				}
			}
			
			// Fallback: try to find by window title (if config contains a title, not a PID)
			if (!string.IsNullOrWhiteSpace(windowConfig) && !int.TryParse(windowConfig, out _))
			{
				return SpawnEditor.FindWindow(null, windowConfig);
			}
			
			return 0;
		}

		private IntPtr FindWindowByProcessId(int processId)
		{
			IntPtr result = IntPtr.Zero;
			try
			{
				EnumWindows((hwnd, lParam) =>
				{
					GetWindowThreadProcessId(hwnd, out uint windowProcessId);
					// Check if window is visible
					if (windowProcessId == processId && IsWindowVisible(hwnd))
					{
						result = hwnd;
						return false; // Stop enumeration
					}
					return true; // Continue enumeration
				}, IntPtr.Zero);
			}
			catch { }
			return result;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		public void SendAuthCommand(Guid id)
		{
			int window = this.GetUoClientWindowHandle();
			if (window > 0)
			{
				string str = string.Format("{0}XTS auth {1}", this._CfgDialog.CfgRunUoCmdPrefix, id.ToString());
				this.SendStringToWindow(window, str);
				return;
			}
			MessageBox.Show("Client process not found or not responding.\nMake sure the UO client is running and selected in Setup.", "Client Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
		public void SendGoCommand(short X, short Y, short Z, WorldMap Map)
		{
			int window = this.GetUoClientWindowHandle();
			if (window > 0)
			{
				string empty = string.Empty;
				string str2;
				if (Z == -32768)
				{
					str2 = string.Format("{0}XmlGo {1} {2} {3}", new object[]
					{
						this._CfgDialog.CfgRunUoCmdPrefix,
						Map,
						X,
						Y
					});
				}
				else
				{
					str2 = string.Format("{0}XmlGo {1} {2} {3} {4}", new object[]
					{
						this._CfgDialog.CfgRunUoCmdPrefix,
						Map,
						X,
						Y,
						Z
					});
				}
				SpawnEditor.SetForegroundWindow(window);
			this.SendStringToWindow(window, str2);
				this.MyLocation.X = (int)X;
				this.MyLocation.Y = (int)Y;
				this.MyLocation.Z = (int)Z;
				this.MyLocation.Facet = (int)Map;
				return;
			}
			MessageBox.Show("Client process not found or not responding.\nMake sure the UO client is running and selected in Setup.", "Client Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			this.chkSyncUO.Checked = false;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0001DB5C File Offset: 0x0001BD5C
		private void mniForceLoad_Click(object sender, EventArgs e)
		{
			try
			{
				WorldMap ForceMap = (WorldMap)this.cbxMap.SelectedItem;
				this.ofdLoadFile.Title = "Force Load Spawn File Into " + ForceMap.ToString();
				if (this.ofdLoadFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Refresh();
					this.stbMain.Text = string.Format("Loading {0} into {1}...", this.ofdLoadFile.FileName, ForceMap.ToString());
					this.tvwSpawnPoints.Nodes.Clear();
					this.LoadSpawnFile(this.ofdLoadFile.FileName, ForceMap);
				}
			}
			finally
			{
				this.stbMain.Text = "Finished loading spawn file.";
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0001DC28 File Offset: 0x0001BE28
		private void mniForceMerge_Click(object sender, EventArgs e)
		{
			try
			{
				WorldMap ForceMap = (WorldMap)this.cbxMap.SelectedItem;
				this.ofdLoadFile.Title = "Merge Spawn File Into " + ForceMap.ToString();
				if (this.ofdLoadFile.ShowDialog(this) == DialogResult.OK)
				{
					this.Refresh();
					this.stbMain.Text = string.Format("Merging {0} into {1}...", this.ofdLoadFile.FileName, ForceMap.ToString());
					this.LoadSpawnFile(this.ofdLoadFile.FileName, ForceMap);
				}
			}
			finally
			{
				this.stbMain.Text = "Finished merging spawn file.";
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
		private void lblMinDelay_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0001DCE6 File Offset: 0x0001BEE6
		private void spnMinDelay_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
		private void checkBox20_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0001DCEA File Offset: 0x0001BEEA
		private void numericUpDown10_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0001DCEC File Offset: 0x0001BEEC
		private void numericUpDown6_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0001DCF0 File Offset: 0x0001BEF0
		private void chkDetails_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkDetails.Checked)
			{
				if (this.axUOMap != null && this.tabControl2 != null && this.panel1 != null)
				{
					this.savewindowsize = base.Size;
					this.savemapsize = this.axUOMap.Size;
					this.savelistsize = this.tabControl2.Size;
					this.savepanelsize = this.panel1.Size;
				}
				this.LargeWindow();
				return;
			}
			this.SmallWindow();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0001DD70 File Offset: 0x0001BF70
		private void SmallWindow()
		{
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			if (!this.savewindowsize.IsEmpty && !this.savepanelsize.IsEmpty)
			{
				base.Size = this.savewindowsize;
				this.panel1.Size = this.savepanelsize;
			}
			else
			{
				base.Size = new Size(660, 520);
				this.panel1.Size = new Size(480, 517);
			}
			this.panel1.Visible = true;
			this.tabControl1.Visible = false;
			this.panel3.Visible = false;
			this.axUOMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			if (!this.savemapsize.IsEmpty && !this.savelistsize.IsEmpty)
			{
				this.axUOMap.Size = this.savemapsize;
				this.tabControl2.Size = this.savelistsize;
				return;
			}
			this.axUOMap.Size = new Size(472, 464);
			this.tabControl2.Size = new Size(176, 264);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001DEA4 File Offset: 0x0001C0A4
		private void LargeWindow()
		{
			this.MinimumSize = new Size(660, 520);
			this.MaximumSize = new Size(1035, 780);
			base.Size = new Size(1035, 780);
			this.panel1.Visible = true;
			this.tabControl1.Visible = true;
			this.panel3.Visible = true;
			this.axUOMap.Anchor = AnchorStyles.Top | AnchorStyles.Left;
			this.axUOMap.Size = new Size(472, 464);
			this.tabControl2.Size = new Size(176, 500);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0001DF54 File Offset: 0x0001C154
		private void spnSpawnRange_ValueChanged(object sender, EventArgs e)
		{
			if (this.SelectedSpawn == null || (int)this.spnSpawnRange.Value < 0)
			{
				return;
			}
			int num = (int)this.spnSpawnRange.Value * 2;
			this.SelectedSpawn.Bounds = new Rectangle((int)this.SelectedSpawn.CentreX - num / 2, (int)this.SelectedSpawn.CentreY - num / 2, num, num);
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0001DFC6 File Offset: 0x0001C1C6
		private void trkZoom_Scroll(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0001DFC8 File Offset: 0x0001C1C8
		private void menuItem9_Click(object sender, EventArgs e)
		{
			this._CfgDialog.ShowDialog();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0001DFD6 File Offset: 0x0001C1D6
		private void btnGo_Click(object sender, EventArgs e)
		{
			this.GoToSelected = true;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0001DFDF File Offset: 0x0001C1DF
		private void mncLoad_Popup(object sender, EventArgs e)
		{
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0001DFE1 File Offset: 0x0001C1E1
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkTracking.Checked)
			{
				this.Tracking = true;
				this.ActivateTracking();
				return;
			}
			this.Tracking = false;
			try { this.StopAuthPosTimer(); } catch { }
			this.axUOMap.RemoveDrawObjects();
			this.RefreshSpawnPoints();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0001E016 File Offset: 0x0001C216
		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			this.DisplaySpawnEntries();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0001E020 File Offset: 0x0001C220
		private void btnEntryEdit1_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText1.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText1.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0001E078 File Offset: 0x0001C278
		private void btnEntryEdit2_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText2.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText2.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0001E0D0 File Offset: 0x0001C2D0
		private void btnEntryEdit3_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText3.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText3.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0001E128 File Offset: 0x0001C328
		private void btnEntryEdit4_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText4.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText4.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0001E180 File Offset: 0x0001C380
		private void btnEntryEdit5_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText5.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText5.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
		private void btnEntryEdit6_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText6.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText6.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0001E230 File Offset: 0x0001C430
		private void btnEntryEdit7_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText7.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText7.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0001E288 File Offset: 0x0001C488
		private void btnEntryEdit8_Click(object sender, EventArgs e)
		{
			EntryEdit entryEdit = new EntryEdit(this);
			entryEdit.Text = base.Name;
			entryEdit.textEntryEdit.Text = this.entryText8.Text;
			if (entryEdit.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.entryText8.Text = entryEdit.textEntryEdit.Text;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0001E2DF File Offset: 0x0001C4DF
		private void grpSpawnEntries_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0001E2E1 File Offset: 0x0001C4E1
		private void grpSpawnEntries_Leave(object sender, EventArgs e)
		{
			this.UpdateSpawnEntries();
			this.UpdateSpawnNode();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0001E2EF File Offset: 0x0001C4EF
		private void grpSpawnEdit_Leave(object sender, EventArgs e)
		{
			this.UpdateSpawnDetails(this.SelectedSpawn);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0001E300 File Offset: 0x0001C500
		private void chkInContainer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkInContainer.Checked)
			{
				this.spnContainerX.Enabled = true;
				this.spnContainerY.Enabled = true;
				this.spnContainerZ.Enabled = true;
				this.labelContainerX.Enabled = true;
				this.labelContainerY.Enabled = true;
				this.labelContainerZ.Enabled = true;
				return;
			}
			this.spnContainerX.Enabled = false;
			this.spnContainerY.Enabled = false;
			this.spnContainerZ.Enabled = false;
			this.labelContainerX.Enabled = false;
			this.labelContainerY.Enabled = false;
			this.labelContainerZ.Enabled = false;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0001E3AB File Offset: 0x0001C5AB
		private bool HasEntry(SpawnPoint Spawn, int entrynum)
		{
			return Spawn != null && Spawn.SpawnObjects != null && this.vScrollBar1.Value + entrynum - 1 < Spawn.SpawnObjects.Count;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0001E3D6 File Offset: 0x0001C5D6
		private int GetIndex(SpawnPoint Spawn, int entrynum)
		{
			if (Spawn == null || Spawn.SpawnObjects == null)
			{
				return -1;
			}
			return this.vScrollBar1.Value + entrynum - 1;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0001E3F4 File Offset: 0x0001C5F4
		private void AddEntryOnChange()
		{
			if (this.entrychanged <= 0)
			{
				return;
			}
			if (!this.HasEntry(this.SelectedSpawn, this.entrychanged))
			{
				this.UpdateSpawnEntries();
				this.UpdateSpawnNode();
				if (this.SelectedSpawn != null)
				{
					this.SelectedSpawn.SpawnObjects.Add(new SpawnObject(this.changedentrystring, 1));
				}
				this.UpdateSpawnerMaxCount();
				this.DisplaySpawnEntries();
				this.UpdateSpawnNode();
			}
			else
			{
				this.UpdateSpawnEntries();
				this.UpdateSpawnNode();
			}
			this.entrychanged = 0;
			this.changedentrystring = null;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0001E47E File Offset: 0x0001C67E
		private void entryText1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001E480 File Offset: 0x0001C680
		private void entryText2_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0001E482 File Offset: 0x0001C682
		private void entryMax1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0001E484 File Offset: 0x0001C684
		private void entryMax2_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0001E486 File Offset: 0x0001C686
		private void entryText3_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0001E488 File Offset: 0x0001C688
		private void entryText4_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0001E48A File Offset: 0x0001C68A
		private void entryText5_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0001E48C File Offset: 0x0001C68C
		private void entryText6_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0001E48E File Offset: 0x0001C68E
		private void entryText7_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0001E490 File Offset: 0x0001C690
		private void entryText8_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0001E492 File Offset: 0x0001C692
		private void entryText1_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001E49A File Offset: 0x0001C69A
		private void entryText2_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0001E4A2 File Offset: 0x0001C6A2
		private void entryText3_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001E4AA File Offset: 0x0001C6AA
		private void entryText4_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001E4B2 File Offset: 0x0001C6B2
		private void entryText5_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0001E4BA File Offset: 0x0001C6BA
		private void entryText6_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0001E4C2 File Offset: 0x0001C6C2
		private void entryText7_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0001E4CA File Offset: 0x0001C6CA
		private void entryText8_MouseLeave(object sender, EventArgs e)
		{
			this.AddEntryOnChange();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001E4D2 File Offset: 0x0001C6D2
		private void menuItem4_Click(object sender, EventArgs e)
		{
			new AboutForm(this).Show();
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0001E4DF File Offset: 0x0001C6DF
		private void entryText1_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 1;
			this.changedentrystring = this.entryText1.Text;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0001E4F9 File Offset: 0x0001C6F9
		private void entryText2_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 2;
			this.changedentrystring = this.entryText2.Text;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0001E513 File Offset: 0x0001C713
		private void entryText3_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 3;
			this.changedentrystring = this.entryText3.Text;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0001E52D File Offset: 0x0001C72D
		private void entryText4_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 4;
			this.changedentrystring = this.entryText4.Text;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0001E547 File Offset: 0x0001C747
		private void entryText5_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 5;
			this.changedentrystring = this.entryText5.Text;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0001E561 File Offset: 0x0001C761
		private void entryText6_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 6;
			this.changedentrystring = this.entryText6.Text;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0001E57B File Offset: 0x0001C77B
		private void entryText7_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 7;
			this.changedentrystring = this.entryText7.Text;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0001E595 File Offset: 0x0001C795
		private void entryText8_KeyUp(object sender, KeyEventArgs e)
		{
			this.entrychanged = 8;
			this.changedentrystring = this.entryText8.Text;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0001E5B0 File Offset: 0x0001C7B0
		private void menuItem1_Click(object sender, EventArgs e)
		{
			if (this.SelectedSpawn == null || this.SelectedSpawn.SpawnObjects == null)
			{
				return;
			}
			string name = this.menuItem1.GetContextMenu().SourceControl.Name;
			int index = -1;
			if (name == "entryText1")
			{
				index = this.GetIndex(this.SelectedSpawn, 1);
			}
			else if (name == "entryText2")
			{
				index = this.GetIndex(this.SelectedSpawn, 2);
			}
			else if (name == "entryText3")
			{
				index = this.GetIndex(this.SelectedSpawn, 3);
			}
			else if (name == "entryText4")
			{
				index = this.GetIndex(this.SelectedSpawn, 4);
			}
			else if (name == "entryText5")
			{
				index = this.GetIndex(this.SelectedSpawn, 5);
			}
			else if (name == "entryText6")
			{
				index = this.GetIndex(this.SelectedSpawn, 6);
			}
			else if (name == "entryText7")
			{
				index = this.GetIndex(this.SelectedSpawn, 7);
			}
			else if (name == "entryText8")
			{
				index = this.GetIndex(this.SelectedSpawn, 8);
			}
			if (index < 0 || index >= this.SelectedSpawn.SpawnObjects.Count || MessageBox.Show(this, "Are you sure you want to delete entry [" + ((SpawnObject)this.SelectedSpawn.SpawnObjects[index]).TypeName + "] from the spawn?", "Delete Spawn Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			this.SelectedSpawn.SpawnObjects.RemoveAt(index);
			this.DisplaySpawnEntries();
			this.UpdateSpawnNode();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0001E74C File Offset: 0x0001C94C
		private void menuItem2_Click(object sender, EventArgs e)
		{
			if (this.SelectedSpawn == null || this.SelectedSpawn.SpawnObjects == null || MessageBox.Show(this, "Are you sure you want to delete all entries from spawn [" + this.SelectedSpawn.SpawnName + "]?", "Delete All Spawn Objects", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			this.SelectedSpawn.SpawnObjects.Clear();
			this.DisplaySpawnEntries();
			this.UpdateSpawnNode();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0001E7B8 File Offset: 0x0001C9B8
		private void menuItem15_Click(object sender, EventArgs e)
		{
			if (this.SelectedSpawn == null || this.SelectedSpawn.SpawnObjects == null)
			{
				return;
			}
			string name = this.menuItem15.GetContextMenu().SourceControl.Name;
			int index = -1;
			if (name == "entryText1")
			{
				index = this.GetIndex(this.SelectedSpawn, 1);
			}
			else if (name == "entryText2")
			{
				index = this.GetIndex(this.SelectedSpawn, 2);
			}
			else if (name == "entryText3")
			{
				index = this.GetIndex(this.SelectedSpawn, 3);
			}
			else if (name == "entryText4")
			{
				index = this.GetIndex(this.SelectedSpawn, 4);
			}
			else if (name == "entryText5")
			{
				index = this.GetIndex(this.SelectedSpawn, 5);
			}
			else if (name == "entryText6")
			{
				index = this.GetIndex(this.SelectedSpawn, 6);
			}
			else if (name == "entryText7")
			{
				index = this.GetIndex(this.SelectedSpawn, 7);
			}
			else if (name == "entryText8")
			{
				index = this.GetIndex(this.SelectedSpawn, 8);
			}
			if (index < 0 || index >= this.SelectedSpawn.SpawnObjects.Count)
			{
				return;
			}
			this.clbSpawnPack.Items.Add(((SpawnObject)this.SelectedSpawn.SpawnObjects[index]).TypeName);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0001E926 File Offset: 0x0001CB26
		private void txtName_KeyUp(object sender, KeyEventArgs e)
		{
			this.namechanged = true;
			this.changednamestring = this.txtName.Text;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0001E940 File Offset: 0x0001CB40
		private void txtName_MouseLeave(object sender, EventArgs e)
		{
			if (this.namechanged && this.SelectedSpawn != null)
			{
				this.SelectedSpawn.SpawnName = this.changednamestring;
				this.UpdateSpawnNode();
			}
			this.namechanged = false;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0001E970 File Offset: 0x0001CB70
		private void txtName_Leave(object sender, EventArgs e)
		{
			if (this.namechanged && this.SelectedSpawn != null)
			{
				this.SelectedSpawn.SpawnName = this.changednamestring;
				this.UpdateSpawnNode();
			}
			this.namechanged = false;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0001E9A0 File Offset: 0x0001CBA0
		public void UpdateSpawnerMaxCount()
		{
			if (this.SelectedSpawn == null || this.SelectedSpawn.SpawnObjects == null)
			{
				return;
			}
			int num = 0;
			foreach (object obj in this.SelectedSpawn.SpawnObjects)
			{
				SpawnObject spawnObject = (SpawnObject)obj;
				num += spawnObject.Count;
			}
			this.SelectedSpawn.SpawnMaxCount = num;
			this.spnMaxCount.Value = num;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0001EA38 File Offset: 0x0001CC38
		private void entryMax1_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax1.Value;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0001EA57 File Offset: 0x0001CC57
		private void entryMax1_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0001EA75 File Offset: 0x0001CC75
		private void entryMax1_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax2.Value;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0001EA94 File Offset: 0x0001CC94
		private void entryMax2_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax2.Value;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0001EAB3 File Offset: 0x0001CCB3
		private void entryMax2_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0001EAD1 File Offset: 0x0001CCD1
		private void entryMax2_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax1.Value;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0001EAF0 File Offset: 0x0001CCF0
		private void entryMax3_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax3.Value;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0001EB0F File Offset: 0x0001CD0F
		private void entryMax3_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax3.Value;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0001EB2E File Offset: 0x0001CD2E
		private void entryMax3_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0001EB4C File Offset: 0x0001CD4C
		private void entryMax4_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax4.Value;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001EB6B File Offset: 0x0001CD6B
		private void entryMax4_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax4.Value;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0001EB8A File Offset: 0x0001CD8A
		private void entryMax4_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0001EBA8 File Offset: 0x0001CDA8
		private void entryMax5_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax5.Value;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0001EBC7 File Offset: 0x0001CDC7
		private void entryMax5_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax5.Value;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0001EBE6 File Offset: 0x0001CDE6
		private void entryMax5_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0001EC04 File Offset: 0x0001CE04
		private void entryMax6_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax6.Value;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0001EC23 File Offset: 0x0001CE23
		private void entryMax6_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax6.Value;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0001EC42 File Offset: 0x0001CE42
		private void entryMax6_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0001EC60 File Offset: 0x0001CE60
		private void entryMax7_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax7.Value;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0001EC7F File Offset: 0x0001CE7F
		private void entryMax7_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax7.Value;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0001EC9E File Offset: 0x0001CE9E
		private void entryMax7_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0001ECBC File Offset: 0x0001CEBC
		private void entryMax8_KeyUp(object sender, KeyEventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax8.Value;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001ECDB File Offset: 0x0001CEDB
		private void entryMax8_Click(object sender, EventArgs e)
		{
			this.maxvaluechanged = true;
			this.changedmaxvalue = (int)this.entryMax8.Value;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0001ECFA File Offset: 0x0001CEFA
		private void entryMax8_Leave(object sender, EventArgs e)
		{
			if (!this.maxvaluechanged)
			{
				return;
			}
			this.UpdateSpawnEntries();
			this.UpdateSpawnerMaxCount();
			this.maxvaluechanged = false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0001ED18 File Offset: 0x0001CF18
		private void tabControl1_Leave(object sender, EventArgs e)
		{
			this.UpdateSpawnDetails(this.SelectedSpawn);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0001ED26 File Offset: 0x0001CF26
		private void groupBox1_Leave(object sender, EventArgs e)
		{
			this.UpdateSpawnDetails(this.SelectedSpawn);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001ED34 File Offset: 0x0001CF34
		private void vScrollBar1_MouseEnter(object sender, EventArgs e)
		{
			this.UpdateSpawnEntries();
			this.UpdateSpawnNode();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0001ED44 File Offset: 0x0001CF44
		private void RefreshRegionView()
		{
			foreach (object obj in this.treeRegionView.Nodes)
			{
				foreach (object obj2 in ((TreeNode)obj).Nodes)
				{
					RegionNode regionNode = (RegionNode)obj2;
					Region region = regionNode.Region;
					if (regionNode.Checked && region != null && region.Map == (WorldMap)this.cbxMap.SelectedItem)
					{
						foreach (object obj3 in region.Coords)
						{
							Rectangle rectangle = (Rectangle)obj3;
							this.axUOMap.AddDrawRect((short)rectangle.X, (short)rectangle.Y, (short)rectangle.Width, (short)rectangle.Height, 1, 32512);
						}
					}
				}
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001EE98 File Offset: 0x0001D098
		private void ClearTreeFacetSelection()
		{
			foreach (object obj in this.treeRegionView.Nodes)
			{
				((TreeNode)obj).Checked = false;
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0001EEF4 File Offset: 0x0001D0F4
		private void treeRegionView_MouseUp(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = this.treeRegionView.GetNodeAt(e.X, e.Y);
			if (nodeAt is RegionNode && nodeAt.Checked)
			{
				this.ClearTreeFacetSelection();
				nodeAt.Parent.Checked = true;
				Region region = (nodeAt as RegionNode).Region;
				if (region != null)
				{
					MapLocation goLocation = region.GoLocation;
					this.cbxMap.SelectedItem = region.Map;
					this.AssignCenter((short)goLocation.X, (short)goLocation.Y, (short)region.Map);
					if (this.chkSyncUO.Checked)
					{
						this.SendGoCommand((short)goLocation.X, (short)goLocation.Y, (short)goLocation.Z, (WorldMap)goLocation.Facet);
					}
				}
			}
			else if (nodeAt is RegionFacetNode)
			{
				this.ClearTreeFacetSelection();
				nodeAt.Checked = true;
				this.cbxMap.SelectedItem = ((RegionFacetNode)nodeAt).Facet;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0001EFF8 File Offset: 0x0001D1F8
		private void ClearTreeColor(TreeNode t, Color c)
		{
			if (t == null)
			{
				return;
			}
			t.BackColor = c;
			if (t.Nodes == null)
			{
				return;
			}
			foreach (object obj in t.Nodes)
			{
				TreeNode t2 = (TreeNode)obj;
				this.ClearTreeColor(t2, c);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0001F068 File Offset: 0x0001D268
		private void treeGoView_MouseUp(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = this.treeGoView.GetNodeAt(e.X, e.Y);
			if (!(nodeAt is LocationSubNode))
			{
				return;
			}
			foreach (object obj in this.treeGoView.Nodes)
			{
				TreeNode t = (TreeNode)obj;
				this.ClearTreeColor(t, this.treeGoView.BackColor);
			}
			LocationSubNode locationSubNode = nodeAt as LocationSubNode;
			if (!(locationSubNode.Node is ChildNode))
			{
				return;
			}
			MapLocation location = ((ChildNode)locationSubNode.Node).Location;
			WorldMap map = locationSubNode.Map;
			locationSubNode.BackColor = Color.Yellow;
			this.cbxMap.SelectedItem = map;
			this.AssignCenter((short)location.X, (short)location.Y, (short)map);
			if (!this.chkSyncUO.Checked)
			{
				return;
			}
			this.SendGoCommand((short)location.X, (short)location.Y, (short)location.Z, map);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001F184 File Offset: 0x0001D384
		private void checkSpawnFilter_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.checkSpawnFilter.Checked)
			{
				this.ClearSpawnFilter();
			}
			else
			{
				this.ApplySpawnFilter();
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001F1A8 File Offset: 0x0001D3A8
		private void SpawnEditor_Closing(object sender, CancelEventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to quit?    ", "Spawn Editor 2", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				e.Cancel = true;
				return;
			}
			Environment.CurrentDirectory = this.StartingDirectory;
			this.WriteSpawnPacks(this.SpawnPackFile);
			this._CfgDialog.SaveWindowConfiguration();
			this._CfgDialog.SaveTransferServerConfiguration();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001F200 File Offset: 0x0001D400
		private void btnAddToSpawnPack_Click(object sender, EventArgs e)
		{
			this.clbSpawnPack.Sorted = false;
			foreach (object obj in this.clbRunUOTypes.CheckedItems)
			{
				string str = (string)obj;
				bool flag = false;
				foreach (object obj2 in this.clbSpawnPack.Items)
				{
					string str2 = (string)obj2;
					if (str.ToUpper() == str2.ToUpper())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.clbSpawnPack.Items.Add(str);
				}
			}
			this.clbSpawnPack.Sorted = true;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
		private void btnSpawnPackClear(object sender, EventArgs e)
		{
			this.clbSpawnPack.ClearSelected();
			for (int index = 0; index < this.clbSpawnPack.Items.Count; index++)
			{
				this.clbSpawnPack.SetItemChecked(index, false);
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001F330 File Offset: 0x0001D530
		private void btnUpdateFromSpawnPack_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tvwSpawnPoints.SelectedNode;
			this.SelectedSpawnNode = selectedNode as SpawnPointNode;
			SpawnObjectNode spawnObjectNode = selectedNode as SpawnObjectNode;
			if (spawnObjectNode != null)
			{
				this.SelectedSpawnNode = spawnObjectNode.Parent as SpawnPointNode;
			}
			if (this.SelectedSpawnNode != null)
			{
				this.SetSpawnFromSpawnPack(this.SelectedSpawnNode, true);
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0001F38B File Offset: 0x0001D58B
		private void btnUpdateSpawnPacks_Click(object sender, EventArgs e)
		{
			this.UpdateSpawnPacks(this.textSpawnPackName.Text, this.clbSpawnPack.Items);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0001F3AC File Offset: 0x0001D5AC
		private void UpdateSpawnPacks(string packName, CheckedListBox.ObjectCollection items)
		{
			if (packName == null || packName.Length == 0 || items == null || items.Count == 0)
			{
				return;
			}
			bool flag = false;
			foreach (object obj in this.tvwSpawnPacks.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode is SpawnPackNode)
				{
					SpawnPackNode spawnPackNode = (SpawnPackNode)treeNode;
					if (spawnPackNode.PackName == packName)
					{
						spawnPackNode.UpdateNode(items);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				this.tvwSpawnPacks.Nodes.Add(new SpawnPackNode(packName, items));
			}
			this.tvwSpawnPacks.Update();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001F470 File Offset: 0x0001D670
		private void clbSpawnPack_MouseUp(object sender, MouseEventArgs e)
		{
			int index = this.clbSpawnPack.IndexFromPoint(e.X, e.Y);
			if (index >= 0)
			{
				this.clbSpawnPack.SelectedItem = this.clbSpawnPack.Items[index];
			}
			if (!(this.clbSpawnPack.SelectedItem is string) || e.Button != MouseButtons.Right)
			{
				return;
			}
			this.mcnSpawnPack.Show(this.clbSpawnPack, new Point(e.X, e.Y));
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001F4F8 File Offset: 0x0001D6F8
		private void mcnSpawnPack_Popup(object sender, EventArgs e)
		{
			if (this.mcnSpawnPack.SourceControl != this.clbSpawnPack)
			{
				return;
			}
			foreach (object obj in this.mcnSpawnPack.MenuItems)
			{
				((MenuItem)obj).Visible = false;
			}
			if (this.clbSpawnPack.SelectedItem is string)
			{
				this.mniDeleteType.Visible = true;
			}
			if (this.clbSpawnPack.Items.Count <= 0)
			{
				return;
			}
			this.mniDeleteAllTypes.Visible = true;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
		private void mniDeleteType_Click(object sender, EventArgs e)
		{
			if (!(this.clbSpawnPack.SelectedItem is string))
			{
				return;
			}
			int selectedIndex = this.clbSpawnPack.SelectedIndex;
			if (selectedIndex >= 0)
			{
				string text = "Are you sure you want to delete type [";
				object selectedItem = this.clbSpawnPack.SelectedItem;
				if (MessageBox.Show(this, text + ((selectedItem != null) ? selectedItem.ToString() : null) + "] from the list?", "Delete Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					this.clbSpawnPack.Items.RemoveAt(selectedIndex);
					return;
				}
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0001F624 File Offset: 0x0001D824
		private void mniDeleteAllTypes_Click(object sender, EventArgs e)
		{
			if (!(this.clbSpawnPack.SelectedItem is string) || MessageBox.Show(this, "Are you sure you want to delete all types in [" + this.textSpawnPackName.Text + "]?", "Delete All Types", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			this.clbSpawnPack.Items.Clear();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0001F680 File Offset: 0x0001D880
		private void mniDeletePack_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.tvwSpawnPacks.SelectedNode;
			SpawnPackNode spawnPackNode = selectedNode as SpawnPackNode;
			if (selectedNode is SpawnPackSubNode)
			{
				spawnPackNode = selectedNode.Parent as SpawnPackNode;
			}
			if (spawnPackNode == null || MessageBox.Show(this, "Are you sure you want to remove SpawnPack [" + spawnPackNode.PackName + "] ?", "Remove SpawnPack", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			spawnPackNode.Remove();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001F6E4 File Offset: 0x0001D8E4
		private void tvwSpawnPacks_MouseUp(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = this.tvwSpawnPacks.GetNodeAt(e.X, e.Y);
			if (nodeAt == null)
			{
				return;
			}
			SpawnPackNode spawnPackNode = nodeAt as SpawnPackNode;
			if (nodeAt is SpawnPackSubNode)
			{
				spawnPackNode = (SpawnPackNode)nodeAt.Parent;
			}
			if (spawnPackNode == null || e.Button != MouseButtons.Right)
			{
				return;
			}
			this.tvwSpawnPacks.SelectedNode = spawnPackNode;
			this.mcnSpawnPacks.Show(this.tvwSpawnPacks, new Point(e.X, e.Y));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001F768 File Offset: 0x0001D968
		private void tvwSpawnPacks_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			SpawnPackNode spawnPackNode = node as SpawnPackNode;
			if (node is SpawnPackSubNode)
			{
				spawnPackNode = (SpawnPackNode)node.Parent;
			}
			if (spawnPackNode == null)
			{
				return;
			}
			this.tvwSpawnPacks.SelectedNode = spawnPackNode;
			this.clbSpawnPack.Items.Clear();
			this.clbSpawnPack.Sorted = false;
			foreach (object obj in spawnPackNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.clbSpawnPack.Items.Add(treeNode.Text);
			}
			this.textSpawnPackName.Text = spawnPackNode.PackName;
			this.clbSpawnPack.Sorted = true;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001F840 File Offset: 0x0001DA40
		private void menuItem6_Click(object sender, EventArgs e)
		{
			try
			{
				this.openSpawnPacks.Title = "Load SpawnPacks";
				if (this.openSpawnPacks.ShowDialog(this) == DialogResult.OK)
				{
					this.ReadSpawnPacks(this.openSpawnPacks.FileName);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0001F894 File Offset: 0x0001DA94
		private void menuItem7_Click(object sender, EventArgs e)
		{
			try
			{
				this.saveSpawnPacks.Title = "Save SpawnPacks";
				if (this.saveSpawnPacks.ShowDialog(this) == DialogResult.OK)
				{
					this.WriteSpawnPacks(this.saveSpawnPacks.FileName);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
		private void menuItem10_Click(object sender, EventArgs e)
		{
			try
			{
				this.importAllSpawnTypes.Title = "Import All Spawn Types";
				if (this.importAllSpawnTypes.ShowDialog(this) == DialogResult.OK)
				{
					this.ImportSpawnTypes(this.importAllSpawnTypes.FileName);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001F93C File Offset: 0x0001DB3C
		private void menuItem11_Click(object sender, EventArgs e)
		{
			try
			{
				this.exportAllSpawnTypes.Title = "Export All Spawn Types";
				if (this.exportAllSpawnTypes.ShowDialog(this) == DialogResult.OK)
				{
					this.ExportSpawnTypes(this.exportAllSpawnTypes.FileName);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0001F990 File Offset: 0x0001DB90
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			this.DisplaySpawnEntries();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0001F998 File Offset: 0x0001DB98
		private void entrySub1_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub1.Text == null || this.entrySub1.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub1.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText1.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub1.ForeColor = this.entryText1.ForeColor;
				return;
			}
			this.entryText1.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub1.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001FA4C File Offset: 0x0001DC4C
		private void entryMax2_ValueChanged_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001FA50 File Offset: 0x0001DC50
		private void entrySub2_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub2.Text == null || this.entrySub2.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub2.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText2.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub2.ForeColor = this.entryText2.ForeColor;
				return;
			}
			this.entryText2.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub2.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0001FB04 File Offset: 0x0001DD04
		private void entrySub3_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub3.Text == null || this.entrySub3.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub3.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText3.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub3.ForeColor = this.entryText3.ForeColor;
				return;
			}
			this.entryText3.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub3.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		private void entrySub4_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub4.Text == null || this.entrySub4.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub4.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText4.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub4.ForeColor = this.entryText4.ForeColor;
				return;
			}
			this.entryText4.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub4.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001FC6C File Offset: 0x0001DE6C
		private void entrySub5_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub5.Text == null || this.entrySub5.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub5.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText5.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub5.ForeColor = this.entryText5.ForeColor;
				return;
			}
			this.entryText5.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub5.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001FD20 File Offset: 0x0001DF20
		private void entrySub6_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub6.Text == null || this.entrySub6.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub6.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText6.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub6.ForeColor = this.entryText6.ForeColor;
				return;
			}
			this.entryText6.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub6.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0001FDD4 File Offset: 0x0001DFD4
		private void entrySub7_TextChanged(object sender, EventArgs e)
		{
			if (this.entrySub7.Text == null || this.entrySub7.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub7.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText7.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub7.ForeColor = this.entryText7.ForeColor;
				return;
			}
			this.entryText7.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub7.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0001FE88 File Offset: 0x0001E088
		private void entryMax8_ValueChanged(object sender, EventArgs e)
		{
			if (this.entrySub8.Text == null || this.entrySub8.Text.Length == 0)
			{
				return;
			}
			int val = 0;
			try
			{
				val = int.Parse(this.entrySub8.Text);
			}
			catch
			{
			}
			if (val > 0)
			{
				this.entryText8.ForeColor = Color.FromArgb(this.RandomColor(val));
				this.entrySub8.ForeColor = this.entryText8.ForeColor;
				return;
			}
			this.entryText8.ForeColor = this.grpSpawnEntries.ForeColor;
			this.entrySub8.ForeColor = this.grpSpawnEntries.ForeColor;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0001FF3C File Offset: 0x0001E13C
		private void chkShade_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0001FF44 File Offset: 0x0001E144
		private void cbxShade_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.chkShade.Checked)
			{
				return;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0001FF5C File Offset: 0x0001E15C
		private void menuItem12_Click(object sender, EventArgs e)
		{
			try
			{
				this.importMapFile.Title = "Import from .map file";
				if (this.importMapFile.ShowDialog(this) == DialogResult.OK)
				{
					int processedmaps;
					int processedspawners;
					new ImportMap(this).DoImportMap(this.importMapFile.FileName, out processedmaps, out processedspawners);
					this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
					this.checkSpawnFilter.Checked = false;
					this.RefreshSpawnPoints();
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0001FFF8 File Offset: 0x0001E1F8
		private void menuItem13_Click(object sender, EventArgs e)
		{
			try
			{
				this.importMSFFile.Title = "Import from .msf file";
				if (this.importMSFFile.ShowDialog(this) == DialogResult.OK)
				{
					new ImportMSF(this).DoImportMSF(this.importMSFFile.FileName);
					this.lblTotalSpawn.Text = "Total Spawns = " + this.tvwSpawnPoints.Nodes.Count.ToString();
					this.checkSpawnFilter.Checked = false;
					this.RefreshSpawnPoints();
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00020090 File Offset: 0x0001E290
		private void OpenHelp()
		{
			Process.Start("file://" + Path.Combine(this.StartingDirectory, this.HelpFile));
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000200B4 File Offset: 0x0001E2B4
		private void menuItem18_Click(object sender, EventArgs e)
		{
			try
			{
				this.OpenHelp();
			}
			catch
			{
				MessageBox.Show("Unable to open help file.");
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000200E8 File Offset: 0x0001E2E8
		private void mniAlwaysOnTop_Click(object sender, EventArgs e)
		{
			if (!this.mniAlwaysOnTop.Checked)
			{
				this.mniAlwaysOnTop.Checked = true;
				base.TopMost = true;
				return;
			}
			this.mniAlwaysOnTop.Checked = false;
			base.TopMost = false;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0002011E File Offset: 0x0001E31E
		private void menuItem17_Click(object sender, EventArgs e)
		{
			this._TransferDialog.Show();
			this._TransferDialog.BringToFront();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00020136 File Offset: 0x0001E336
		private void chkShowPlayers_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0002013E File Offset: 0x0001E33E
		private void chkShowCreatures_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00020146 File Offset: 0x0001E346
		private void chkShowItems_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0002014E File Offset: 0x0001E34E
		private void menuItem22_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00020150 File Offset: 0x0001E350
		private int CountUnfilteredNodes()
		{
			if (this.tvwSpawnPoints.Nodes == null || this.tvwSpawnPoints.Nodes.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			for (int index = 0; index < this.tvwSpawnPoints.Nodes.Count; index++)
			{
				if (!((SpawnPointNode)this.tvwSpawnPoints.Nodes[index]).Filtered)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000201C0 File Offset: 0x0001E3C0
		private void btnSendSpawn_Click(object sender, EventArgs e)
		{
			if (this.tvwSpawnPoints.Nodes == null || this.tvwSpawnPoints.Nodes.Count <= 0)
			{
				return;
			}
			SpawnPoint selectedspawn = null;
			int num = this.CountUnfilteredNodes();
			if (sender == this.btnSendSingleSpawner)
			{
				selectedspawn = this.SelectedSpawn;
				num = 1;
			}
			this.UpdateSpawnDetails(this.SelectedSpawn);
			if (MessageBox.Show(this, string.Format("Send {0} spawners to Server {1}?", num, this._TransferDialog.txtTransferServerAddress.Text), "Send Spawners to Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
			{
				return;
			}
			SaveSpawnerData saveSpawnerData = new SaveSpawnerData();
			MemoryStream memoryStream = new MemoryStream();
			this.SaveSpawnFile(memoryStream, "Memory Stream", selectedspawn);
			saveSpawnerData.Data = memoryStream.GetBuffer();
			if (saveSpawnerData.Data == null)
			{
				MessageBox.Show(this, "No Spawners found.", "Empty Send", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			saveSpawnerData.AuthenticationID = this.SessionID;
			saveSpawnerData.UseMainThread = true;
			string text = this._TransferDialog.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this._TransferDialog.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this._TransferDialog.DisplayStatusIndicator("Sending Spawners...");
			SpawnEditor.LogWarning(string.Format("SendSpawners request: server={0}:{1}, selectedOnly={2}, authId={3}, payloadBytes={4}", text, Port, selectedspawn != null, saveSpawnerData.AuthenticationID, (saveSpawnerData.Data != null) ? saveSpawnerData.Data.Length : 0));
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, saveSpawnerData);
			if (transferMessage == null)
			{
				SpawnEditor.LogWarning("SendSpawners response: <null>");
			}
			else
			{
				SpawnEditor.LogWarning("SendSpawners response type: " + transferMessage.GetType().FullName);
			}
			if (transferMessage is ReturnSpawnerSaveStatus)
			{
				int num2 = ((ReturnSpawnerSaveStatus)transferMessage).ProcessedSpawners;
				int processedMaps = ((ReturnSpawnerSaveStatus)transferMessage).ProcessedMaps;
				SpawnEditor.LogWarning(string.Format("SendSpawners success: processedSpawners={0}, processedMaps={1}", num2, processedMaps));
				if (num2 == 0)
				{
					MessageBox.Show(this, "No Spawners sent.", "Empty Send", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show(string.Format("Successfully sent {0} spawners", num2));
				}
			}
			else if (transferMessage is ErrorMessage)
			{
				SpawnEditor.LogWarning("SendSpawners error: " + ((ErrorMessage)transferMessage).Message);
			}
			this._TransferDialog.HideStatusIndicator();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0002035C File Offset: 0x0001E55C
		private void unloadSpawner_Popup(object sender, EventArgs e)
		{
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00020360 File Offset: 0x0001E560
		private void DoUnloadSpawners(SpawnPoint selectedspawn)
		{
			int num = this.CountUnfilteredNodes();
			if (selectedspawn != null)
			{
				num = 1;
			}
			if (MessageBox.Show(this, string.Format("Unload {0} spawners from Server {1}?", num, this._TransferDialog.txtTransferServerAddress.Text), "Unload Spawners from Server", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
			{
				return;
			}
			UnloadSpawnerData unloadSpawnerData = new UnloadSpawnerData();
			MemoryStream memoryStream = new MemoryStream();
			this.SaveSpawnFile(memoryStream, "Memory Stream", selectedspawn);
			unloadSpawnerData.Data = memoryStream.GetBuffer();
			if (unloadSpawnerData.Data == null)
			{
				MessageBox.Show(this, "No Spawners found.", "Empty Unload", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			unloadSpawnerData.AuthenticationID = this.SessionID;
			unloadSpawnerData.UseMainThread = true;
			string text = this._TransferDialog.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this._TransferDialog.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this._TransferDialog.DisplayStatusIndicator("Unloading Spawners...");
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, unloadSpawnerData);
			if (transferMessage is ReturnSpawnerUnloadStatus)
			{
				int num2 = ((ReturnSpawnerUnloadStatus)transferMessage).ProcessedSpawners;
				int processedMaps = ((ReturnSpawnerUnloadStatus)transferMessage).ProcessedMaps;
				if (num2 == 0)
				{
					MessageBox.Show(this, "No Spawners unloaded.", "Empty Unload", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show(string.Format("Successfully unloaded {0} spawners", num2));
				}
			}
			this._TransferDialog.HideStatusIndicator();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000204BC File Offset: 0x0001E6BC
		private void mniUnloadSpawners_Click(object sender, EventArgs e)
		{
			if (this.tvwSpawnPoints.Nodes == null || this.tvwSpawnPoints.Nodes.Count <= 0)
			{
				return;
			}
			this.DoUnloadSpawners(null);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000204E6 File Offset: 0x0001E6E6
		private void unloadSingleSpawner_Popup(object sender, EventArgs e)
		{
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000204E8 File Offset: 0x0001E6E8
		private void mniUnloadSingleSpawner_Click_1(object sender, EventArgs e)
		{
			if (this.tvwSpawnPoints.Nodes == null || this.tvwSpawnPoints.Nodes.Count <= 0)
			{
				return;
			}
			this.DoUnloadSpawners(this.SelectedSpawn);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00020518 File Offset: 0x0001E718
		private void mniDeleteInSelectionWindow_Click(object sender, EventArgs e)
		{
			if (this._SelectionWindow == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (!spawnPointNode.Filtered && spawn.CentreX >= this._SelectionWindow.X && spawn.CentreX <= this._SelectionWindow.X + this._SelectionWindow.Width && spawn.CentreY >= this._SelectionWindow.Y && spawn.CentreY <= this._SelectionWindow.Y + this._SelectionWindow.Height)
				{
					arrayList.Add(spawnPointNode);
					num++;
					spawnPointNode.Highlighted = true;
				}
			}
			this.RefreshSpawnPoints();
			if (MessageBox.Show(this, string.Format("Delete {0} spawners?", num), "Delete Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					TreeNode node = (TreeNode)obj2;
					this.tvwSpawnPoints.Nodes.Remove(node);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			foreach (object obj3 in this.tvwSpawnPoints.Nodes)
			{
				((SpawnPointNode)obj3).Highlighted = false;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00020710 File Offset: 0x0001E910
		private void mniDeleteNotSelected_Click(object sender, EventArgs e)
		{
			if (this._SelectionWindow == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (!spawnPointNode.Filtered && (spawn.CentreX < this._SelectionWindow.X || spawn.CentreX > this._SelectionWindow.X + this._SelectionWindow.Width || spawn.CentreY < this._SelectionWindow.Y || spawn.CentreY > this._SelectionWindow.Y + this._SelectionWindow.Height))
				{
					arrayList.Add(spawnPointNode);
					num++;
					spawnPointNode.Highlighted = true;
				}
			}
			this.RefreshSpawnPoints();
			if (MessageBox.Show(this, string.Format("Delete {0} spawners?", num), "Delete Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					TreeNode node = (TreeNode)obj2;
					this.tvwSpawnPoints.Nodes.Remove(node);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			foreach (object obj3 in this.tvwSpawnPoints.Nodes)
			{
				((SpawnPointNode)obj3).Highlighted = false;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00020908 File Offset: 0x0001EB08
		private void highlightDetail_Popup(object sender, EventArgs e)
		{
			if (!(sender is ContextMenu))
			{
				return;
			}
			Control sourceControl = ((ContextMenu)sender).SourceControl;
			string name = sourceControl.Name;
			if (name == null || name == string.Empty)
			{
				name = sourceControl.Parent.Name;
			}
			bool flag;
			if (this.ControlModHash.Contains(name))
			{
				flag = (bool)this.ControlModHash[name];
			}
			else
			{
				flag = false;
				this.ControlModHash.Add(name, flag ? 1 : 0);
			}
			this.ControlModHash[name] = ((!flag) ? 1 : 0);
			Color color = SystemColors.Window;
			if (sourceControl is CheckBox)
			{
				color = this.tabControl1.BackColor;
			}
			if ((bool)this.ControlModHash[name])
			{
				sourceControl.BackColor = Color.Yellow;
				return;
			}
			sourceControl.BackColor = color;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000209DC File Offset: 0x0001EBDC
		private void DeleteAllSpawns()
		{
			if (this.tvwSpawnPoints.Nodes == null || MessageBox.Show(this, string.Format("Are you sure you want to delete ALL {0} spawns?", this.tvwSpawnPoints.Nodes.Count), "Delete All Spawns", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			this.tvwSpawnPoints.Nodes.Clear();
			this.SelectedSpawn = null;
			this.LoadDefaultSpawnValues();
			this.RefreshSpawnPoints();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00020A4A File Offset: 0x0001EC4A
		private void mniToolbarDeleteAllSpawns_Click(object sender, EventArgs e)
		{
			this.DeleteAllSpawns();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00020A52 File Offset: 0x0001EC52
		private void mniDisplayFilterSettings_Click(object sender, EventArgs e)
		{
			this._SpawnerFilters.Show();
			this._SpawnerFilters.BringToFront();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00020A6A File Offset: 0x0001EC6A
		private void btnFilterSettings_Click(object sender, EventArgs e)
		{
			this._SpawnerFilters.Show();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00020A78 File Offset: 0x0001EC78
		private void mniDeleteAllFiltered_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (spawnPointNode.Filtered)
				{
					arrayList.Add(spawnPointNode);
					num++;
				}
			}
			if (MessageBox.Show(this, string.Format("Delete {0} spawners?", num), "Delete Filtered Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					TreeNode node = (TreeNode)obj2;
					this.tvwSpawnPoints.Nodes.Remove(node);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00020B9C File Offset: 0x0001ED9C
		private void mniDeleteAllUnfiltered_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (!spawnPointNode.Filtered)
				{
					arrayList.Add(spawnPointNode);
					num++;
				}
			}
			if (MessageBox.Show(this, string.Format("Delete {0} spawners?", num), "Delete Unfiltered Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					TreeNode node = (TreeNode)obj2;
					this.tvwSpawnPoints.Nodes.Remove(node);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00020CC0 File Offset: 0x0001EEC0
		private void mniModifiedUnfiltered_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (!spawnPointNode.Filtered)
				{
					arrayList.Add(spawnPointNode);
					num++;
					spawnPointNode.Highlighted = true;
				}
			}
			this.RefreshSpawnPoints();
			if (MessageBox.Show(this, string.Format("Modify {0} spawners?", num), "Modify Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					SpawnPointNode spawnPointNode2 = (SpawnPointNode)obj2;
					this.ApplyModifications(spawnPointNode2.Spawn);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			foreach (object obj3 in this.tvwSpawnPoints.Nodes)
			{
				((SpawnPointNode)obj3).Highlighted = false;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00020E3C File Offset: 0x0001F03C
		private void mniModifyInSelectionWindow_Click(object sender, EventArgs e)
		{
			if (this._SelectionWindow == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			int num = 0;
			foreach (object obj in this.tvwSpawnPoints.Nodes)
			{
				SpawnPointNode spawnPointNode = (SpawnPointNode)obj;
				SpawnPoint spawn = spawnPointNode.Spawn;
				if (!spawnPointNode.Filtered && spawn.CentreX >= this._SelectionWindow.X && spawn.CentreX <= this._SelectionWindow.X + this._SelectionWindow.Width && spawn.CentreY >= this._SelectionWindow.Y && spawn.CentreY <= this._SelectionWindow.Y + this._SelectionWindow.Height)
				{
					arrayList.Add(spawnPointNode);
					num++;
					spawnPointNode.Highlighted = true;
				}
			}
			this.RefreshSpawnPoints();
			if (MessageBox.Show(this, string.Format("Modify {0} spawners?", num), "Modify Spawners", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				this.tvwSpawnPoints.BeginUpdate();
				this.tvwSpawnPoints.Sorted = false;
				foreach (object obj2 in arrayList)
				{
					SpawnPointNode spawnPointNode2 = (SpawnPointNode)obj2;
					this.ApplyModifications(spawnPointNode2.Spawn);
				}
				this.tvwSpawnPoints.Sorted = true;
				this.tvwSpawnPoints.EndUpdate();
			}
			foreach (object obj3 in this.tvwSpawnPoints.Nodes)
			{
				((SpawnPointNode)obj3).Highlighted = false;
			}
			this.RefreshSpawnPoints();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00021030 File Offset: 0x0001F230
		private bool ControlHasBeenSelected(object key)
		{
			return this.ControlModHash.Contains(key) && (bool)this.ControlModHash[key];
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00021054 File Offset: 0x0001F254
		private void ApplyModifications(SpawnPoint spawn)
		{
			if (this.ControlHasBeenSelected(this.txtName.Name))
			{
				spawn.SpawnName = this.txtName.Text;
			}
			if (this.ControlHasBeenSelected(this.spnHomeRange.Name))
			{
				spawn.HomeRange = (int)this.spnHomeRange.Value;
			}
			if (this.ControlHasBeenSelected(this.spnMaxCount.Name))
			{
				spawn.MaxCount = (int)this.spnMaxCount.Value;
			}
			if (this.ControlHasBeenSelected(this.spnMinDelay.Name))
			{
				spawn.MinDelay = (double)this.spnMinDelay.Value;
			}
			if (this.ControlHasBeenSelected(this.spnMaxDelay.Name))
			{
				spawn.MaxDelay = (double)this.spnMaxDelay.Value;
			}
			if (this.ControlHasBeenSelected(this.spnTeam.Name))
			{
				spawn.Team = (int)this.spnTeam.Value;
			}
			if (this.ControlHasBeenSelected(this.spnSpawnRange.Name))
			{
				spawn.SpawnRange = (int)this.spnSpawnRange.Value;
			}
			if (this.ControlHasBeenSelected(this.spnProximityRange.Name))
			{
				spawn.ProximityRange = (int)this.spnProximityRange.Value;
			}
			if (this.ControlHasBeenSelected(this.spnDuration.Name))
			{
				spawn.Duration = (double)this.spnDuration.Value;
			}
			if (this.ControlHasBeenSelected(this.spnDespawn.Name))
			{
				spawn.Despawn = (double)this.spnDespawn.Value;
			}
			if (this.ControlHasBeenSelected(this.spnMinRefract.Name))
			{
				spawn.MinRefract = (double)this.spnMinRefract.Value;
			}
			if (this.ControlHasBeenSelected(this.spnMaxRefract.Name))
			{
				spawn.MaxRefract = (double)this.spnMaxRefract.Value;
			}
			if (this.ControlHasBeenSelected(this.spnTODStart.Name))
			{
				spawn.TODStart = (double)this.spnTODStart.Value;
			}
			if (this.ControlHasBeenSelected(this.spnTODEnd.Name))
			{
				spawn.TODEnd = (double)this.spnTODEnd.Value;
			}
			if (this.ControlHasBeenSelected(this.spnKillReset.Name))
			{
				spawn.KillReset = (int)this.spnKillReset.Value;
			}
			if (this.ControlHasBeenSelected(this.spnProximitySnd.Name))
			{
				spawn.ProximitySnd = (int)this.spnProximitySnd.Value;
			}
			if (this.ControlHasBeenSelected(this.chkGroup.Name))
			{
				spawn.Group = this.chkGroup.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkRunning.Name))
			{
				spawn.Running = this.chkRunning.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkHomeRangeIsRelative.Name))
			{
				spawn.RelativeHome = this.chkHomeRangeIsRelative.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkInContainer.Name))
			{
				spawn.InContainer = this.chkInContainer.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkRealTOD.Name))
			{
				spawn.RealTOD = this.chkRealTOD.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkGameTOD.Name))
			{
				spawn.GameTOD = this.chkGameTOD.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkSpawnOnTrigger.Name))
			{
				spawn.SpawnOnTrigger = this.chkSpawnOnTrigger.Checked;
			}
			if (this.ControlHasBeenSelected(this.chkSequentialSpawn.Name))
			{
				spawn.SequentialSpawn = this.chkSequentialSpawn.Checked;
			}
			if (!this.ControlHasBeenSelected(this.chkSmartSpawning.Name))
			{
				return;
			}
			spawn.SmartSpawning = this.chkSmartSpawning.Checked;
		}

		// Token: 0x040000F9 RID: 249
		private static bool _Debug = false;

		// Token: 0x040000FA RID: 250
		private static ArrayList AssemblyList = new ArrayList();

		// Token: 0x040000FB RID: 251
		private static Hashtable typeHash = new Hashtable();

		// Token: 0x040000FC RID: 252
		private readonly string DefaultZoomLevelText = "Zoom Level:  ";

		// Token: 0x040000FD RID: 253
		private readonly string SpawnPackFile = "SpawnPacks.dat";

		// Token: 0x040000FE RID: 254
		private readonly string HelpFile = "ReadMe.htm";

		// Token: 0x040000FF RID: 255
		internal SpawnEditor.SelectionWindow _SelectionWindow;

		// Token: 0x04000100 RID: 256
		private bool GoToSelected;

		// Token: 0x04000101 RID: 257
		private bool RightMouseDown;

		// Token: 0x04000102 RID: 258
		private bool _ExtendedDiagnostics;

		// Token: 0x04000103 RID: 259
		internal MapLocation[] MapLoc = new MapLocation[5];

		// Token: 0x04000104 RID: 260
		public Guid SessionID = Guid.NewGuid();

		// Token: 0x04000105 RID: 261
		private bool MouseResize;

		// Token: 0x04000106 RID: 262
		private bool Tracking;

		// Token: 0x04000107 RID: 263
		private MapLocation MyLocation = new MapLocation();

		// Token: 0x04000108 RID: 264
		private Size savewindowsize = Size.Empty;

		// Token: 0x04000109 RID: 265
		private Size savemapsize = Size.Empty;

		// Token: 0x0400010A RID: 266
		private Size savelistsize = Size.Empty;

		// Token: 0x0400010B RID: 267
		private Size savepanelsize = Size.Empty;

		// Token: 0x0400010C RID: 268
		private int entrychanged;

		// Token: 0x0400010D RID: 269
		private string changedentrystring;

		// Token: 0x0400010E RID: 270
		private bool namechanged;

		// Token: 0x0400010F RID: 271
		private string changednamestring;

		// Token: 0x04000110 RID: 272
		private bool maxvaluechanged;

		// Token: 0x04000111 RID: 273
		private int changedmaxvalue;

		// Token: 0x04000112 RID: 274
		private Hashtable ControlModHash = new Hashtable();

		// Token: 0x04000113 RID: 275
		private const string SpawnEditorTitle = "Spawn Editor 2";

		// Token: 0x04000114 RID: 276
		private const string SpawnDataSetName = "Spawns";

		// Token: 0x04000115 RID: 277
		private const string SpawnTablePointName = "Points";

		// Token: 0x04000116 RID: 278
		private const string SpawnTableObjectName = "Objects";

		// Token: 0x04000117 RID: 279
		internal Configure _CfgDialog;

		// Token: 0x04000118 RID: 280
		internal TransferServerSettings _TransferDialog;

		// Token: 0x04000119 RID: 281
		internal SpawnerFilters _SpawnerFilters;

		// Token: 0x0400011A RID: 282
		private Type[] _RunUOScriptTypes;

		// Token: 0x0400011B RID: 283
		internal ObjectData[] MobLocArray;

		// Token: 0x0400011C RID: 284
		internal ObjectData[] PlayerLocArray;

		// Token: 0x0400011D RID: 285
		internal ObjectData[] ItemLocArray;

		// Token: 0x0400011E RID: 286
		internal string StartingDirectory;

		// Token: 0x0400011F RID: 287
		private SpawnPoint SelectedSpawn;

		// Token: 0x04000120 RID: 288
		private SpawnPointNode SelectedSpawnNode;

		// Token: 0x04000121 RID: 289
		private SpawnPoint SelectedTemplate;

		// Token: 0x04000122 RID: 290
		private SpawnPointNode SelectedTemplateNode;

		// Token: 0x04000123 RID: 291
		private DateTime RightMouseDownStart;

		// Token: 0x0400026D RID: 621
		private static int tictoc = 0;

		// Timer to poll server for authenticated player's position
		private System.Threading.Timer _AuthPosTimer;
		private int _AuthPosIntervalMs = 1000;

		// Token: 0x02000030 RID: 48
		internal class CustomExceptionHandler
		{
			// Token: 0x0600026E RID: 622 RVA: 0x0002ABC4 File Offset: 0x00028DC4
			public void OnThreadException(object sender, ThreadExceptionEventArgs t)
			{
				DialogResult dialogResult = DialogResult.Cancel;
				try
				{
					dialogResult = this.ShowThreadExceptionDialog(t.Exception);
				}
				catch
				{
					try
					{
						MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
					}
					finally
					{
						Application.Exit();
					}
				}
				if (dialogResult != DialogResult.Abort)
				{
					return;
				}
				Application.Exit();
			}

			// Token: 0x0600026F RID: 623 RVA: 0x0002AC28 File Offset: 0x00028E28
			private DialogResult ShowThreadExceptionDialog(Exception e)
			{
				string text = "An error occurred:\n\n" + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
				SpawnEditor.Debug(text);
				return MessageBox.Show(text, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x02000031 RID: 49
		public class TrackerThread
		{
			// Token: 0x06000271 RID: 625 RVA: 0x0002AC60 File Offset: 0x00028E60
			public TrackerThread(SpawnEditor editor)
			{
				this.Editor = editor;
			}

			// Token: 0x06000272 RID: 626 RVA: 0x0002AC70 File Offset: 0x00028E70
			public void TrackerThreadMain()
			{
				int num = 0;
				int num2 = 0;
				int num3 = -1;
				bool flag = false;
				while (this.Editor != null && this.Editor.Tracking)
				{
					Thread.Sleep(250);
					int x = 0;
					int y = 0;
					int z = 0;
					int facet = -1;
					bool found = this.Editor.TryGetLocationFromMemory(ref x, ref y, ref z, ref facet);
					SpawnEditor.LogWarning("TrackerLoop: TryGetLocationFromMemory returned=" + found + " (cfg=" + this.Editor._CfgDialog.CfgUoClientWindowValue + ")");
					if (!found)
					{
						bool ensured = this.Editor.EnsureClientHandle();
						SpawnEditor.LogWarning("TrackerLoop: EnsureClientHandle returned=" + ensured + " Client.Running=" + Client.Running);
						if (ensured)
						{
							try { this.Editor.ScanForTargetCoordinatesOnce(5557, 1207); } catch { }
							try { this.Editor.ScanForTargetCoordinatesOnce(5597, 1185); } catch { }
							try { this.Editor.ScanForChangingCoordinates(500); } catch { }
						}
						try
						{
							// Ensure calibration has been run for the current client handle before attempting FindLocation
							// inspect ProcessStream status before calibrate
							try
							{
								object ps = Client.ProcessStream;
								if (ps == null)
									SpawnEditor.LogWarning("TrackerLoop: Client.ProcessStream == null before Calibrate()");
								else
								{
									SpawnEditor.LogWarning("TrackerLoop: Client.ProcessStream != null before Calibrate(): type=" + ps.GetType().FullName);
									try
									{
										var prop = ps.GetType().GetProperty("Window", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
										if (prop != null)
									{
										object wnd = prop.GetValue(ps, null);
										SpawnEditor.LogWarning("TrackerLoop: ProcessStream.Window=" + (wnd ?? "<null>"));
									}
									}
									catch (Exception ex)
									{
										SpawnEditor.LogWarning("TrackerLoop: reading ProcessStream.Window failed: " + ex.Message);
									}
								}
							}
							catch (Exception ex)
							{
								SpawnEditor.LogWarning("TrackerLoop: inspecting ProcessStream failed: " + ex.Message);
							}
							Client.Calibrate();
							SpawnEditor.LogWarning("TrackerLoop: Client.Calibrate() called");
							var lp = Client.LocationPointer;
							if (lp == null)
							{
								SpawnEditor.LogWarning("TrackerLoop: LocationPointer is null after Calibrate()");
							}
							else
							{
								SpawnEditor.LogWarning("TrackerLoop: LocationPointer PointerX=" + lp.PointerX + " SizeX=" + lp.SizeX + " PointerY=" + lp.PointerY + " SizeY=" + lp.SizeY);
							}
						}
						catch (Exception ex)
						{
							SpawnEditor.LogWarning("TrackerLoop: Client.Calibrate() threw: " + ex.Message);
						}
						found = Client.FindLocation(ref x, ref y, ref z, ref facet);
						SpawnEditor.LogWarning("TrackerLoop: Client.FindLocation returned=" + found + " -> X=" + x + " Y=" + y + " Z=" + z + " Facet=" + facet);
					}
					if (found)
					{
						if (facet != num3 || x != num || y != num2)
						{
							this.Editor.MyLocation.X = x;
							this.Editor.MyLocation.Y = y;
							this.Editor.MyLocation.Z = z;
							this.Editor.MyLocation.Facet = facet;
							this.Editor.cbxMap.SelectedIndex = facet;
							this.Editor.AssignCenter((short)x, (short)y, (short)facet);
							this.Editor.DisplayMyLocation();
							num = x;
							num2 = y;
							num3 = facet;
							flag = false;
						}
						else if (!flag)
						{
							flag = true;
						}
					}
					else
					{
						SpawnEditor.LogWarning("Tracker: Client not found (PID: " + this.Editor._CfgDialog.CfgUoClientWindowValue + ")");
						// If server-side auth polling is active, keep Track enabled so server updates continue.
						if (this.Editor._AuthPosTimer == null)
						{
							this.Editor.Tracking = false;
							this.Editor.chkTracking.Checked = false;
						}
						else
						{
							SpawnEditor.LogWarning("Tracker: Client not found but auth poller active; keeping Track enabled");
						}
					}
				}
			}

			// Token: 0x0400037B RID: 891
			private SpawnEditor Editor;
		}

		// Token: 0x02000032 RID: 50
		public class SelectionWindow
		{
			// Token: 0x1700005E RID: 94
			// (get) Token: 0x06000273 RID: 627 RVA: 0x0002ADBD File Offset: 0x00028FBD
			public Rectangle Bounds
			{
				get
				{
					return new Rectangle((int)this.X, (int)this.Y, (int)this.Width, (int)this.Height);
				}
			}

			// Token: 0x06000274 RID: 628 RVA: 0x0002ADDC File Offset: 0x00028FDC
			public bool IsWithinWindow(short MapX, short MapY)
			{
				return new Rectangle((int)this.X, (int)this.Y, (int)this.Width, (int)this.Height).Contains((int)MapX, (int)MapY);
			}

			// Token: 0x0400037C RID: 892
			public int Index = -1;

			// Token: 0x0400037D RID: 893
			public short X;

			// Token: 0x0400037E RID: 894
			public short Y;

			// Token: 0x0400037F RID: 895
			public short SX;

			// Token: 0x04000380 RID: 896
			public short SY;

			// Token: 0x04000381 RID: 897
			public short Width;

			// Token: 0x04000382 RID: 898
			public short Height;
		}
	}
}
