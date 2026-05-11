using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SpawnEditor2
{
	// Token: 0x02000006 RID: 6
	public partial class Configure : Form
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00003F44 File Offset: 0x00002144
		private bool ReadRegistryBool(RegistryKey key, string name, bool defaultValue)
		{
			bool flag;
			try
			{
				object v = key.GetValue(name, defaultValue ? bool.TrueString : bool.FalseString);
				if (v == null)
				{
					flag = defaultValue;
				}
				else if (v is bool)
				{
					bool b = (bool)v;
					flag = b;
				}
				else if (v is int)
				{
					int i = (int)v;
					flag = i != 0;
				}
				else if (v is long)
				{
					long j = (long)v;
					flag = j != 0L;
				}
				else
				{
					string s = v as string;
					if (s != null)
					{
						bool parsedBool;
						if (bool.TryParse(s, out parsedBool))
						{
							return parsedBool;
						}
						int parsedInt;
						if (int.TryParse(s, out parsedInt))
						{
							return parsedInt != 0;
						}
					}
					try
					{
						flag = Convert.ToBoolean(v);
					}
					catch
					{
						flag = defaultValue;
					}
				}
			}
			catch
			{
				flag = defaultValue;
			}
			return flag;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000401C File Offset: 0x0000221C
		public bool IsValidConfiguration
		{
			get
			{
				return this._IsValidConfiguration;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004024 File Offset: 0x00002224
		public Configure(SpawnEditor editor)
		{
			this._Editor = editor;
			this.InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.Sizable;
			this.MinimumSize = new Size(516, 455);
			this.SizeGripStyle = SizeGripStyle.Show;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.LoadSavedConfiguration();
		}

		private void LoadSavedConfiguration()
		{
			SpawnEditorSetupFile configuration;
			string configurationPath;
			if (LocalSetupStorage.TryLoadConfiguration(Application.StartupPath, out configuration, out configurationPath))
			{
				this.ApplyStoredConfiguration(configuration);
				this._LoadedConfigurationPath = configurationPath;
				this.RefreshDynamicClientWindowValue();
				this.UpdateConfigurationValidity();
				return;
			}

			this._HKCUKey = Registry.CurrentUser.OpenSubKey(this.AppRegistryKey, false);
			if (this._HKCUKey != null && this._HKCUKey.ValueCount >= 14)
			{
				this.CfgRunUoPathValue = (string)this._HKCUKey.GetValue(this.AppRunUoPathValue, string.Empty);
				this.CfgUoClientPathValue = (string)this._HKCUKey.GetValue(this.AppUoClientPathValue, string.Empty);
				this.CfgMulPathValue = (string)this._HKCUKey.GetValue(this.AppMulPathValue, string.Empty);
				this.CfgZoomLevelValue = short.Parse(this._HKCUKey.GetValue(this.AppZoomLevelValue, "-4") as string);
				this.CfgRunUoCmdPrefix = (string)this._HKCUKey.GetValue(this.AppRunUoCmdPrefixValue, "[");
				this.CfgSpawnNameValue = (string)this._HKCUKey.GetValue(this.AppSpawnNameValue, "Spawner");
				this.CfgSpawnHomeRangeValue = (int)this._HKCUKey.GetValue(this.AppSpawnHomeRangeValue, 5);
				this.CfgSpawnMaxCountValue = (int)this._HKCUKey.GetValue(this.AppSpawnMaxCountValue, 1);
				this.CfgSpawnMinDelayValue = (int)this._HKCUKey.GetValue(this.AppSpawnMinDelayValue, 5);
				this.CfgSpawnMaxDelayValue = (int)this._HKCUKey.GetValue(this.AppSpawnMaxDelayValue, 10);
				this.CfgSpawnTeamValue = (int)this._HKCUKey.GetValue(this.AppSpawnTeamValue, 0);
				this.CfgSpawnGroupValue = this.ReadRegistryBool(this._HKCUKey, this.AppSpawnGroupValue, this.CfgSpawnGroupValue);
				this.CfgSpawnRunningValue = this.ReadRegistryBool(this._HKCUKey, this.AppSpawnRunningValue, this.CfgSpawnRunningValue);
				this.CfgSpawnRelativeHomeValue = this.ReadRegistryBool(this._HKCUKey, this.AppSpawnRelativeHomeValue, this.CfgSpawnRelativeHomeValue);
				this.CfgStartingStaticsValue = this.ReadRegistryBool(this._HKCUKey, this.AppStartingStaticsValue, this.CfgStartingStaticsValue);
				this.CfgStartingDetailsValue = this.ReadRegistryBool(this._HKCUKey, this.AppStartingDetailsValue, this.CfgStartingDetailsValue);
				this.CfgStartingOnTopValue = this.ReadRegistryBool(this._HKCUKey, this.AppStartingOnTopValue, this.CfgStartingOnTopValue);
				this.CfgStartingMapValue = (WorldMap)Enum.Parse(typeof(WorldMap), this._HKCUKey.GetValue(this.AppStartingMapValue, "Trammel") as string);
				this.CfgStartingXValue = (int)this._HKCUKey.GetValue(this.AppStartingXValue, -1);
				this.CfgStartingYValue = (int)this._HKCUKey.GetValue(this.AppStartingYValue, -1);
				this.CfgStartingWidthValue = (int)this._HKCUKey.GetValue(this.AppStartingWidthValue, -1);
				this.CfgStartingHeightValue = (int)this._HKCUKey.GetValue(this.AppStartingHeightValue, -1);
				this.CfgTransferServerAddressValue = (string)this._HKCUKey.GetValue(this.AppTransferServerAddressValue, "127.0.0.1");
				this.CfgTransferServerPortValue = (int)this._HKCUKey.GetValue(this.AppTransferServerPortValue, 8030);
			}

			this.RefreshDynamicClientWindowValue();
			this.UpdateConfigurationValidity();
		}

		private void ApplyStoredConfiguration(SpawnEditorSetupFile configuration)
		{
			if (configuration == null)
			{
				return;
			}

			this.CfgRunUoPathValue = configuration.RunUoExePath ?? string.Empty;
			this.CfgUoClientPathValue = configuration.UltimaClientExePath ?? string.Empty;
			this.CfgMulPathValue = configuration.MulFilesPath ?? string.Empty;
			this.CfgZoomLevelValue = configuration.ZoomLevel;
			this.CfgRunUoCmdPrefix = configuration.RunUoCmdPrefix ?? "[";
			this.CfgSpawnNameValue = configuration.SpawnName ?? "Spawn";
			this.CfgSpawnHomeRangeValue = configuration.SpawnHomeRange;
			this.CfgSpawnMaxCountValue = configuration.SpawnMaxCount;
			this.CfgSpawnMinDelayValue = configuration.SpawnMinDelay;
			this.CfgSpawnMaxDelayValue = configuration.SpawnMaxDelay;
			this.CfgSpawnTeamValue = configuration.SpawnTeam;
			this.CfgSpawnGroupValue = configuration.SpawnGroup;
			this.CfgSpawnRunningValue = configuration.SpawnRunning;
			this.CfgSpawnRelativeHomeValue = configuration.SpawnRelativeHome;
			this.CfgStartingStaticsValue = configuration.StartingStatics;
			this.CfgStartingDetailsValue = configuration.StartingDetails;
			this.CfgStartingMapValue = configuration.StartingMap;
			this.CfgStartingOnTopValue = configuration.StartingOnTop;
			this.CfgStartingXValue = configuration.StartingX;
			this.CfgStartingYValue = configuration.StartingY;
			this.CfgStartingWidthValue = configuration.StartingWidth;
			this.CfgStartingHeightValue = configuration.StartingHeight;
			this.CfgTransferServerAddressValue = string.IsNullOrWhiteSpace(configuration.TransferServerAddress) ? "127.0.0.1" : configuration.TransferServerAddress;
			this.CfgTransferServerPortValue = configuration.TransferServerPort <= 0 ? 8030 : configuration.TransferServerPort;
		}

		private SpawnEditorSetupFile CreateStoredConfiguration()
		{
			return new SpawnEditorSetupFile
			{
				RunUoExePath = this.CfgRunUoPathValue ?? string.Empty,
				UltimaClientExePath = this.CfgUoClientPathValue ?? string.Empty,
				MulFilesPath = this.CfgMulPathValue ?? string.Empty,
				ZoomLevel = this.CfgZoomLevelValue,
				RunUoCmdPrefix = this.CfgRunUoCmdPrefix ?? "[",
				SpawnName = this.CfgSpawnNameValue ?? "Spawn",
				SpawnHomeRange = this.CfgSpawnHomeRangeValue,
				SpawnMaxCount = this.CfgSpawnMaxCountValue,
				SpawnMinDelay = this.CfgSpawnMinDelayValue,
				SpawnMaxDelay = this.CfgSpawnMaxDelayValue,
				SpawnTeam = this.CfgSpawnTeamValue,
				SpawnGroup = this.CfgSpawnGroupValue,
				SpawnRunning = this.CfgSpawnRunningValue,
				SpawnRelativeHome = this.CfgSpawnRelativeHomeValue,
				StartingStatics = this.CfgStartingStaticsValue,
				StartingDetails = this.CfgStartingDetailsValue,
				StartingMap = this.CfgStartingMapValue,
				StartingOnTop = this.CfgStartingOnTopValue,
				StartingX = this.CfgStartingXValue,
				StartingY = this.CfgStartingYValue,
				StartingWidth = this.CfgStartingWidthValue,
				StartingHeight = this.CfgStartingHeightValue,
				TransferServerAddress = this.CfgTransferServerAddressValue ?? "127.0.0.1",
				TransferServerPort = this.CfgTransferServerPortValue
			};
		}

		public void SaveCurrentConfiguration()
		{
			string configurationPath = LocalSetupStorage.GetConfigurationPath(Application.StartupPath, this.CfgUoClientPathValue, this._LoadedConfigurationPath);
			LocalSetupStorage.SaveConfiguration(Application.StartupPath, configurationPath, this.CreateStoredConfiguration());
			this._LoadedConfigurationPath = configurationPath;
		}

		public SetupProfileInfo[] GetAvailableSetupProfiles()
		{
			return LocalSetupStorage.GetProfiles(Application.StartupPath, this.CfgUoClientPathValue, this._LoadedConfigurationPath).ToArray();
		}

		public string GetSetupProfilesDirectory()
		{
			return LocalSetupStorage.GetProfilesDirectory(Application.StartupPath, this.CfgUoClientPathValue, this._LoadedConfigurationPath);
		}

		public void SaveSetupProfile(string filePath, string profileName)
		{
			SpawnEditorSetupFile configuration = this.CreateStoredConfiguration();
			configuration.ProfileName = profileName ?? string.Empty;
			LocalSetupStorage.SaveProfile(filePath, configuration);
		}

		public void DeleteSetupProfile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
			{
				return;
			}

			File.Delete(filePath);
		}

		public bool LoadAndApplySetupProfile(string filePath)
		{
			SpawnEditorSetupFile profile;
			if (!LocalSetupStorage.TryLoadProfile(filePath, out profile))
			{
				return false;
			}

			this.ApplyStoredConfiguration(profile);
			this.RefreshDynamicClientWindowValue();
			this.UpdateConfigurationValidity();
			this.SaveCurrentConfiguration();
			if (this._Editor != null)
			{
				this.ConfigureTransferServer();
			}
			return true;
		}

		private void UpdateConfigurationValidity()
		{
			this._IsValidConfiguration = !string.IsNullOrEmpty(this.CfgRunUoPathValue) && File.Exists(this.CfgRunUoPathValue) && !string.IsNullOrEmpty(this.CfgUoClientPathValue);
		}

		private void RefreshDynamicClientWindowValue()
		{
			this.CfgUoClientWindowValue = this.ResolveClientWindowValue(this.CfgUoClientPathValue);
		}

		private string ResolveClientWindowValue(string clientPath)
		{
			string pidText = this.GetClientProcessIdByPath(clientPath);
			if (!string.IsNullOrEmpty(pidText))
			{
				return pidText;
			}

			string executableName = Path.GetFileName(clientPath ?? string.Empty).ToLowerInvariant();
			if (executableName == "uotd.exe")
			{
				return "Ultima Online Third Dawn";
			}
			if (executableName == "client.exe")
			{
				return "Ultima Online";
			}
			return string.Empty;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000586D File Offset: 0x00003A6D
		private void btnRunUOExe_Click(object sender, EventArgs e)
		{
			if (this.ofdOpenFile.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.txtRunUOExe.Text = this.ofdOpenFile.FileName;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00005895 File Offset: 0x00003A95
		private void btnUltimaClient_Click(object sender, EventArgs e)
		{
			if (this.ofdOpenFile.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			this.txtUltimaClient.Text = this.ofdOpenFile.FileName;
			this.SetClientWindowName();
		}

		private void btnMulPath_Click(object sender, EventArgs e)
		{
			using (var fbd = new global::System.Windows.Forms.FolderBrowserDialog())
			{
				fbd.Description = "Select the folder containing UO map files (map0.mul, statics0.mul, etc.)";
				if (!string.IsNullOrEmpty(this.txtMulPath.Text) && Directory.Exists(this.txtMulPath.Text))
				{
					fbd.SelectedPath = this.txtMulPath.Text;
				}
				if (fbd.ShowDialog(this) == DialogResult.OK)
				{
					this.txtMulPath.Text = fbd.SelectedPath;
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000058C4 File Offset: 0x00003AC4
		private void Configure_Load(object sender, EventArgs e)
		{
			this.InitWindowPicker();
			if (this._Editor.TopMost)
			{
				base.TopMost = true;
			}
			foreach (object obj in Enum.GetValues(typeof(WorldMap)))
			{
				WorldMap worldMap = (WorldMap)obj;
				if (worldMap != WorldMap.Internal)
				{
					this.startingMap.Items.Add(worldMap);
				}
			}
			if (!this._IsValidConfiguration)
			{
				this._HKLMKey = Registry.LocalMachine.OpenSubKey(this.UOTDRegistryKey);
				this.CfgUoClientWindowValue = "Ultima Online Third Dawn";
				if (this._HKLMKey == null)
				{
					this._HKLMKey = Registry.LocalMachine.OpenSubKey(this.T2ARegistryKey);
				}
				if (this._HKLMKey != null)
				{
					this.CfgUoClientPathValue = (string)this._HKLMKey.GetValue(this.UOExePathValue);
					this.txtUltimaClient.Text = this.CfgUoClientPathValue;
					this.SetClientWindowName();
				}
			}
			this.txtRunUOExe.Text = this.CfgRunUoPathValue;
			this.txtUltimaClient.Text = this.CfgUoClientPathValue;
			this.txtMulPath.Text = this.CfgMulPathValue;
			this.RefreshProcessList();
			this.SelectProcessByConfig(this.CfgUoClientWindowValue);
			this.trkZoom.Value = (int)this.CfgZoomLevelValue;
			this.txtCmdPrefix.Text = this.CfgRunUoCmdPrefix;
			this.txtSpawnName.Text = this.CfgSpawnNameValue;
			this.spnSpawnRange.Value = this.CfgSpawnHomeRangeValue;
			this.spnSpawnMaxCount.Value = this.CfgSpawnMaxCountValue;
			this.spnSpawnMinDelay.Value = this.CfgSpawnMinDelayValue;
			this.spnSpawnMaxDelay.Value = this.CfgSpawnMaxDelayValue;
			this.spnSpawnTeam.Value = this.CfgSpawnTeamValue;
			this.chkSpawnGroup.Checked = this.CfgSpawnGroupValue;
			this.chkSpawnRunning.Checked = this.CfgSpawnRunningValue;
			this.chkHomeRangeIsRelative.Checked = this.CfgSpawnRelativeHomeValue;
			this.startingStatics.Checked = this.CfgStartingStaticsValue;
			this.startingDetails.Checked = this.CfgStartingDetailsValue;
			this.startingMap.SelectedIndex = (int)this.CfgStartingMapValue;
			this.startingOnTop.Checked = this.CfgStartingOnTopValue;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005B1C File Offset: 0x00003D1C
		private void SetClientWindowName()
		{
			this.CfgUoClientWindowValue = this.ResolveClientWindowValue(this.txtUltimaClient.Text);
			this.RefreshProcessList();
			this.SelectProcessByConfig(this.CfgUoClientWindowValue);
		}

		private string GetClientProcessIdByPath(string clientPath)
		{
			try
			{
				string path = (clientPath ?? string.Empty).Trim();
				if (string.IsNullOrEmpty(path))
				{
					return null;
				}
				string processName = Path.GetFileNameWithoutExtension(path);
				if (string.IsNullOrEmpty(processName))
				{
					return null;
				}
				Process[] processes = Process.GetProcessesByName(processName);
				if (processes != null && processes.Length > 0)
				{
					Process selected = null;
					foreach (Process p in processes)
					{
						if (p.MainWindowHandle != IntPtr.Zero)
						{
							selected = p;
							break;
						}
					}
					if (selected == null)
					{
						selected = processes[0];
					}
					return selected.Id.ToString();
				}
			}
			catch
			{
			}
			return null;
		}

		#region Window Picker Helpers

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool GetCursorPos(out Point lpPoint);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point point);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr GetAncestor(IntPtr hWnd, uint flags);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(int vKey);

		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

		private const uint GA_ROOT = 2u;
		private const int VK_LBUTTON = 0x01;
		private const int VK_ESCAPE = 0x1B;

		private bool _isSelectingClientPid;
		private DateTime _pickStartTime;
		private Timer _pickWindowTimer;

		private void InitWindowPicker()
		{
			this._pickWindowTimer = new Timer();
			this._pickWindowTimer.Interval = 50;
			this._pickWindowTimer.Tick += this.PickWindowTimer_Tick;
			this._isSelectingClientPid = false;
		}

		private void btnPickClientWindow_Click(object sender, EventArgs e)
		{
			if (this._isSelectingClientPid)
			{
				this.EndPickWindowMode();
				return;
			}

			this._isSelectingClientPid = true;
			this._pickStartTime = DateTime.Now;
			this.lblClientWindow.Text = "Click the client window (Esc to cancel)";
			this.Cursor = Cursors.Cross;
			this._pickWindowTimer.Start();
		}

		private void PickWindowTimer_Tick(object sender, EventArgs e)
		{
			if (!this._isSelectingClientPid)
			{
				return;
			}

			if ((GetAsyncKeyState(VK_ESCAPE) & 0x8000) != 0)
			{
				this.EndPickWindowMode();
				return;
			}

			if ((DateTime.Now - this._pickStartTime).TotalMilliseconds < 250.0)
			{
				return;
			}

			if ((GetAsyncKeyState(VK_LBUTTON) & 0x8000) == 0)
			{
				return;
			}

			Point point;
			if (!GetCursorPos(out point))
			{
				return;
			}

			IntPtr hWnd = WindowFromPoint(point);
			if (hWnd == IntPtr.Zero)
			{
				return;
			}

			hWnd = GetAncestor(hWnd, GA_ROOT);
			if (hWnd == IntPtr.Zero)
			{
				return;
			}

			uint processId;
			GetWindowThreadProcessId(hWnd, out processId);
			if (processId <= 0u)
			{
				return;
			}

			this.CfgUoClientWindowValue = processId.ToString();
			this.RefreshProcessList();
			this.SelectProcessByPid((int)processId);
			this.EndPickWindowMode();
		}

		private void EndPickWindowMode()
		{
			this._isSelectingClientPid = false;
			if (this._pickWindowTimer != null)
			{
				this._pickWindowTimer.Stop();
			}
			this.lblClientWindow.Text = "Client Process (PID):";
			this.Cursor = Cursors.Default;
		}

		#endregion

		#region Process List Helpers

		private static readonly string[] KnownClientNames = new string[]
		{
			"client", "classicuo", "cuoclient", "uotd", "orion", "razor", "classicassist"
		};

		private void RefreshProcessList()
		{
			object previousSelection = this.cmbClientProcess.SelectedItem;
			int previousPid = 0;
			if (previousSelection is ClientProcessItem prev)
			{
				previousPid = prev.Pid;
			}

			this.cmbClientProcess.Items.Clear();
			this.cmbClientProcess.Items.Add(new ClientProcessItem(0, "(none)", ""));

			try
			{
				foreach (Process proc in Process.GetProcesses())
				{
					try
					{
						string name = proc.ProcessName.ToLowerInvariant();
						bool isKnown = false;
						foreach (string known in KnownClientNames)
						{
							if (name.Contains(known))
							{
								isKnown = true;
								break;
							}
						}
						if (!isKnown)
						{
							continue;
						}

						string title = "";
						if (proc.MainWindowHandle != IntPtr.Zero)
						{
							title = proc.MainWindowTitle;
						}
						this.cmbClientProcess.Items.Add(new ClientProcessItem(proc.Id, proc.ProcessName, title));
					}
					catch { }
				}
			}
			catch { }

			// Try to re-select previous PID
			if (previousPid > 0)
			{
				this.SelectProcessByPid(previousPid);
			}
			else
			{
				this.cmbClientProcess.SelectedIndex = 0;
			}
		}

		private void SelectProcessByPid(int pid)
		{
			for (int i = 0; i < this.cmbClientProcess.Items.Count; i++)
			{
				if (this.cmbClientProcess.Items[i] is ClientProcessItem item && item.Pid == pid)
				{
					this.cmbClientProcess.SelectedIndex = i;
					return;
				}
			}
			// PID not in list — add it manually
			if (pid > 0)
			{
				try
				{
					Process proc = Process.GetProcessById(pid);
					string title = proc.MainWindowHandle != IntPtr.Zero ? proc.MainWindowTitle : "";
					var item = new ClientProcessItem(proc.Id, proc.ProcessName, title);
					this.cmbClientProcess.Items.Add(item);
					this.cmbClientProcess.SelectedItem = item;
				}
				catch
				{
					this.cmbClientProcess.SelectedIndex = 0;
				}
			}
		}

		private void SelectProcessByConfig(string configValue)
		{
			if (string.IsNullOrEmpty(configValue))
			{
				this.cmbClientProcess.SelectedIndex = 0;
				return;
			}

			// If config is a PID number, select by PID
			int pid;
			if (int.TryParse(configValue, out pid) && pid > 0)
			{
				this.SelectProcessByPid(pid);
				return;
			}

			// Legacy: config is a window title — try to match by title
			for (int i = 0; i < this.cmbClientProcess.Items.Count; i++)
			{
				if (this.cmbClientProcess.Items[i] is ClientProcessItem item
					&& item.WindowTitle.IndexOf(configValue, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					this.cmbClientProcess.SelectedIndex = i;
					return;
				}
			}

			// Select first real process if available, otherwise (none)
			if (this.cmbClientProcess.Items.Count > 1)
			{
				this.cmbClientProcess.SelectedIndex = 1;
			}
			else
			{
				this.cmbClientProcess.SelectedIndex = 0;
			}
		}

		private void cmbClientProcess_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbClientProcess.SelectedItem is ClientProcessItem item && item.Pid > 0)
			{
				this.CfgUoClientWindowValue = item.Pid.ToString();
			}
		}

		private void btnRefreshProcesses_Click(object sender, EventArgs e)
		{
			this.RefreshProcessList();
		}

		#endregion

		// Token: 0x06000027 RID: 39 RVA: 0x00005B94 File Offset: 0x00003D94
		private void btnOk_Click(object sender, EventArgs e)
		{
			this.CfgRunUoPathValue = this.txtRunUOExe.Text;
			this.CfgUoClientPathValue = this.txtUltimaClient.Text;
			this.CfgMulPathValue = this.txtMulPath.Text;
			if (this.cmbClientProcess.SelectedItem is ClientProcessItem selItem && selItem.Pid > 0)
			{
				this.CfgUoClientWindowValue = selItem.Pid.ToString();
			}
			this.CfgZoomLevelValue = (short)this.trkZoom.Value;
			this.CfgRunUoCmdPrefix = this.txtCmdPrefix.Text;
			this.CfgSpawnNameValue = this.txtSpawnName.Text;
			this.CfgSpawnHomeRangeValue = (int)this.spnSpawnRange.Value;
			this.CfgSpawnMaxCountValue = (int)this.spnSpawnMaxCount.Value;
			this.CfgSpawnMinDelayValue = (int)this.spnSpawnMinDelay.Value;
			this.CfgSpawnMaxDelayValue = (int)this.spnSpawnMaxDelay.Value;
			this.CfgSpawnTeamValue = (int)this.spnSpawnTeam.Value;
			this.CfgSpawnGroupValue = this.chkSpawnGroup.Checked;
			this.CfgSpawnRunningValue = this.chkSpawnRunning.Checked;
			this.CfgSpawnRelativeHomeValue = this.chkHomeRangeIsRelative.Checked;
			this.CfgStartingStaticsValue = this.startingStatics.Checked;
			this.CfgStartingDetailsValue = this.startingDetails.Checked;
			this.CfgStartingMapValue = (WorldMap)this.startingMap.SelectedIndex;
			this.CfgStartingOnTopValue = this.startingOnTop.Checked;
			if (this.CfgRunUoPathValue.Length == 0)
			{
				MessageBox.Show(this, "You must set the path to the RunUO EXE before proceeding!", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (this.CfgUoClientPathValue.Length == 0)
			{
				MessageBox.Show(this, "You must set the path to the Ultima Online client EXE before proceeding!", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			this.RefreshDynamicClientWindowValue();
			this.SaveCurrentConfiguration();
			this._IsValidConfiguration = true;
			base.Close();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00005F54 File Offset: 0x00004154
		public void SaveWindowConfiguration()
		{
			if (this._Editor == null)
			{
				return;
			}
			this.CfgStartingXValue = this._Editor.Location.X;
			this.CfgStartingYValue = this._Editor.Location.Y;
			this.CfgStartingWidthValue = this._Editor.Width;
			this.CfgStartingHeightValue = this._Editor.Height;
			this.SaveCurrentConfiguration();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00006006 File Offset: 0x00004206
		public void ConfigureTransferServer()
		{
			this._Editor._TransferDialog.txtTransferServerAddress.Text = this.CfgTransferServerAddressValue;
			this._Editor._TransferDialog.txtTransferServerPort.Text = this.CfgTransferServerPortValue.ToString();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00006044 File Offset: 0x00004244
		public void SaveTransferServerConfiguration()
		{
			if (this._Editor == null)
			{
				return;
			}
			this.CfgTransferServerAddressValue = this._Editor._TransferDialog.txtTransferServerAddress.Text;
			try
			{
				this.CfgTransferServerPortValue = int.Parse(this._Editor._TransferDialog.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this.SaveCurrentConfiguration();
		}

		// Token: 0x0400002B RID: 43
		private readonly string UOTDRegistryKey = "Software\\Origin Worlds Online\\Ultima Online Third Dawn\\1.0";

		// Token: 0x0400002C RID: 44
		private readonly string T2ARegistryKey = "Software\\Origin Worlds Online\\Ultima Online\\1.0";

		// Token: 0x0400002D RID: 45
		private readonly string UOExePathValue = "ExePath";

		// Token: 0x0400002E RID: 46
		private readonly string AppRegistryKey = "Software\\Spawn Editor";

		// Token: 0x0400002F RID: 47
		private readonly string AppRunUoPathValue = "RunUO Exe Path";

		// Token: 0x04000030 RID: 48
		private readonly string AppUoClientPathValue = "Ultima Client Exe Path";

		// Token: 0x04000031 RID: 49
		private readonly string AppZoomLevelValue = "Zoom Level";

		// Token: 0x04000032 RID: 50
		private readonly string AppRunUoCmdPrefixValue = "RunUO Cmd Prefix";

		// Token: 0x04000033 RID: 51
		private readonly string AppUoClientWindowValue = "Ultima Client Window";

		// Token: 0x04000034 RID: 52
		private readonly string AppSpawnNameValue = "Spawn Name";

		// Token: 0x04000035 RID: 53
		private readonly string AppSpawnHomeRangeValue = "Spawn Home Range";

		// Token: 0x04000036 RID: 54
		private readonly string AppSpawnMaxCountValue = "Spawn Max Count";

		// Token: 0x04000037 RID: 55
		private readonly string AppSpawnMinDelayValue = "Spawn Min Delay";

		// Token: 0x04000038 RID: 56
		private readonly string AppSpawnMaxDelayValue = "Spawn Max Delay";

		// Token: 0x04000039 RID: 57
		private readonly string AppSpawnTeamValue = "Spawn Team";

		// Token: 0x0400003A RID: 58
		private readonly string AppSpawnGroupValue = "Spawn Group";

		// Token: 0x0400003B RID: 59
		private readonly string AppSpawnRunningValue = "Spawn Running";

		// Token: 0x0400003C RID: 60
		private readonly string AppSpawnRelativeHomeValue = "Spawn Relative Home";

		// Token: 0x0400003D RID: 61
		private readonly string AppStartingStaticsValue = "Starting Statics";

		// Token: 0x0400003E RID: 62
		private readonly string AppStartingDetailsValue = "Starting Details";

		// Token: 0x0400003F RID: 63
		private readonly string AppStartingMapValue = "Starting Map";

		// Token: 0x04000040 RID: 64
		private readonly string AppStartingOnTopValue = "Starting On Top";

		// Token: 0x04000041 RID: 65
		private readonly string AppStartingXValue = "Starting X";

		// Token: 0x04000042 RID: 66
		private readonly string AppStartingYValue = "Starting Y";

		// Token: 0x04000043 RID: 67
		private readonly string AppStartingWidthValue = "Starting Width";

		// Token: 0x04000044 RID: 68
		private readonly string AppStartingHeightValue = "Starting Height";

		// Token: 0x04000045 RID: 69
		private readonly string AppTransferServerAddressValue = "Transfer Server Address";

		// Token: 0x04000046 RID: 70
		private readonly string AppTransferServerPortValue = "Transfer Server Port";

		private readonly string AppMulPathValue = "MUL Files Path";

		// Token: 0x04000047 RID: 71
		public string CfgUoClientWindowValue = "Ultima Online Third Dawn";

		// Token: 0x04000048 RID: 72
		public short CfgZoomLevelValue = -4;

		// Token: 0x04000049 RID: 73
		public string CfgRunUoCmdPrefix = "[";

		// Token: 0x0400004A RID: 74
		public string CfgSpawnNameValue = "Spawn";

		// Token: 0x0400004B RID: 75
		public int CfgSpawnHomeRangeValue = 10;

		// Token: 0x0400004C RID: 76
		public int CfgSpawnMaxCountValue = 1;

		// Token: 0x0400004D RID: 77
		public int CfgSpawnMinDelayValue = 5;

		// Token: 0x0400004E RID: 78
		public int CfgSpawnMaxDelayValue = 10;

		// Token: 0x0400004F RID: 79
		public int CfgSpawnTeamValue;

		// Token: 0x04000050 RID: 80
		public bool CfgSpawnGroupValue;

		// Token: 0x04000051 RID: 81
		public bool CfgSpawnRunningValue = true;

		// Token: 0x04000052 RID: 82
		public bool CfgSpawnRelativeHomeValue = true;

		// Token: 0x04000053 RID: 83
		public bool CfgStartingStaticsValue;

		// Token: 0x04000054 RID: 84
		public bool CfgStartingDetailsValue;

		// Token: 0x04000055 RID: 85
		public WorldMap CfgStartingMapValue = WorldMap.Trammel;

		// Token: 0x04000056 RID: 86
		public bool CfgStartingOnTopValue;

		// Token: 0x04000057 RID: 87
		public int CfgStartingXValue = -1;

		// Token: 0x04000058 RID: 88
		public int CfgStartingYValue = -1;

		// Token: 0x04000059 RID: 89
		public int CfgStartingWidthValue = -1;

		// Token: 0x0400005A RID: 90
		public int CfgStartingHeightValue = -1;

		// Token: 0x0400005B RID: 91
		public string CfgTransferServerAddressValue = "127.0.0.1";

		// Token: 0x0400005C RID: 92
		public int CfgTransferServerPortValue = 8030;

		// Token: 0x0400005D RID: 93
		private bool _IsValidConfiguration;

		// Token: 0x0400005E RID: 94
		private RegistryKey _HKLMKey;

		// Token: 0x0400005F RID: 95
		private RegistryKey _HKCUKey;

		private string _LoadedConfigurationPath;

		// Token: 0x04000060 RID: 96
		public string CfgRunUoPathValue;

		// Token: 0x04000061 RID: 97
		public string CfgUoClientPathValue;

		public string CfgMulPathValue = string.Empty;

		// Token: 0x04000086 RID: 134
		private SpawnEditor _Editor;
	}

	internal class ClientProcessItem
	{
		public int Pid { get; private set; }
		public string ProcessName { get; private set; }
		public string WindowTitle { get; private set; }

		public ClientProcessItem(int pid, string processName, string windowTitle)
		{
			this.Pid = pid;
			this.ProcessName = processName;
			this.WindowTitle = windowTitle ?? "";
		}

		public override string ToString()
		{
			if (this.Pid <= 0)
			{
				return this.ProcessName;
			}
			if (!string.IsNullOrEmpty(this.WindowTitle))
			{
				return string.Format("PID {0} - {1} ({2})", this.Pid, this.ProcessName, this.WindowTitle);
			}
			return string.Format("PID {0} - {1}", this.Pid, this.ProcessName);
		}
	}
}
