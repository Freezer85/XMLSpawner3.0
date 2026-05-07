using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpawnEditor2.Forms
{
	// Token: 0x0200001F RID: 31
	public partial class SpawnerFilters : Form
	{
		// Token: 0x06000221 RID: 545 RVA: 0x0002853A File Offset: 0x0002673A
		public SpawnerFilters(SpawnEditor editor)
		{
			this.InitializeComponent();
			this._Editor = editor;
			this.InitializeSettings();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
				return;
			}
			base.OnFormClosing(e);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00028558 File Offset: 0x00026758
		private void InitializeSettings()
		{
			this.cmbInContainers.SelectedIndex = 0;
			this.cmbSequential.SelectedIndex = 0;
			this.cmbSmartSpawning.SelectedIndex = 0;
			this.cmbProximity.SelectedIndex = 0;
			this.cmbRunning.SelectedIndex = 0;
			this.cmbAvgSpawnTime.SelectedIndex = 0;
			this.cmbNameHas.SelectedIndex = 0;
			this.cmbEntryHas.SelectedIndex = 0;
			this.cmbEntryTypeHas.SelectedIndex = 0;
			this.cmbEntryHas2.SelectedIndex = 0;
			this.cmbEntryTypeHas2.SelectedIndex = 0;
			this.cmbSpawnerMap.SelectedIndex = 0;
			this.cmbNotes.SelectedIndex = 0;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00028604 File Offset: 0x00026804
		public bool HasMatch(SpawnPoint spawn)
		{
			if (spawn == null || spawn.SpawnObjects == null)
			{
				return false;
			}
			bool flag = true;
			if (this.cmbSpawnerMap.SelectedIndex == 0 && this._Editor.cbxMap.SelectedIndex != (int)spawn.Map)
			{
				flag = false;
			}
			if (flag && this.txtSpawnerName.Text != null && this.txtSpawnerName.Text.Length > 0)
			{
				bool flag2 = false;
				if (this.chkNameCase.Checked)
				{
					if (spawn.SpawnName.IndexOf(this.txtSpawnerName.Text) >= 0)
					{
						flag2 = true;
					}
				}
				else if (spawn.SpawnName.ToLower().IndexOf(this.txtSpawnerName.Text.ToLower()) >= 0)
				{
					flag2 = true;
				}
				if (this.cmbNameHas.SelectedIndex == 0)
				{
					if (!flag2)
					{
						flag = false;
					}
				}
				else if (flag2)
				{
					flag = false;
				}
			}
			if (flag && this.txtSpawnerEntry.Text != null && this.txtSpawnerEntry.Text.Length > 0)
			{
				bool flag3 = false;
				if (spawn.SpawnObjects != null)
				{
					foreach (object obj in spawn.SpawnObjects)
					{
						SpawnObject spawnObject = (SpawnObject)obj;
						if (this.chkEntryCase.Checked)
						{
							if (spawnObject.TypeName != null && spawnObject.TypeName.IndexOf(this.txtSpawnerEntry.Text) >= 0)
							{
								flag3 = true;
								break;
							}
						}
						else if (spawnObject.TypeName != null && spawnObject.TypeName.ToLower().IndexOf(this.txtSpawnerEntry.Text.ToLower()) >= 0)
						{
							flag3 = true;
							break;
						}
					}
				}
				if (this.cmbEntryHas.SelectedIndex == 0)
				{
					if (!flag3)
					{
						flag = false;
					}
				}
				else if (flag3)
				{
					flag = false;
				}
			}
			if (flag && this.txtSpawnerEntry2.Text != null && this.txtSpawnerEntry2.Text.Length > 0)
			{
				bool flag4 = false;
				if (spawn.SpawnObjects != null)
				{
					foreach (object obj2 in spawn.SpawnObjects)
					{
						SpawnObject spawnObject2 = (SpawnObject)obj2;
						if (this.chkEntryCase2.Checked)
						{
							if (spawnObject2.TypeName != null && spawnObject2.TypeName.IndexOf(this.txtSpawnerEntry2.Text) >= 0)
							{
								flag4 = true;
								break;
							}
						}
						else if (spawnObject2.TypeName != null && spawnObject2.TypeName.ToLower().IndexOf(this.txtSpawnerEntry2.Text.ToLower()) >= 0)
						{
							flag4 = true;
							break;
						}
					}
				}
				if (this.cmbEntryHas2.SelectedIndex == 0)
				{
					if (!flag4)
					{
						flag = false;
					}
				}
				else if (flag4)
				{
					flag = false;
				}
			}
			if (flag && this.txtSpawnerEntryType.Text != null && this.txtSpawnerEntryType.Text.Length > 0)
			{
				bool flag5 = false;
				Type runUoType = SpawnEditor.FindRunUOType(this.txtSpawnerEntryType.Text.ToLower());
				if (spawn.SpawnObjects != null && runUoType != null)
				{
					foreach (object obj3 in spawn.SpawnObjects)
					{
						SpawnObject spawnObject3 = (SpawnObject)obj3;
						Type type = null;
						if (spawnObject3.TypeName != null)
						{
							string[] strArray = spawnObject3.TypeName.Split(new char[] { '/' });
							string name = null;
							if (strArray != null && strArray.Length != 0)
							{
								name = strArray[0];
							}
							type = SpawnEditor.FindRunUOType(name);
						}
						if (type != null && (type == runUoType || type.IsSubclassOf(runUoType)))
						{
							flag5 = true;
							break;
						}
					}
				}
				if (this.cmbEntryTypeHas.SelectedIndex == 0)
				{
					if (!flag5)
					{
						flag = false;
					}
				}
				else if (flag5)
				{
					flag = false;
				}
			}
			if (flag && this.txtSpawnerEntryType2.Text != null && this.txtSpawnerEntryType2.Text.Length > 0)
			{
				bool flag6 = false;
				Type runUoType2 = SpawnEditor.FindRunUOType(this.txtSpawnerEntryType2.Text.ToLower());
				if (spawn.SpawnObjects != null && runUoType2 != null)
				{
					foreach (object obj4 in spawn.SpawnObjects)
					{
						SpawnObject spawnObject4 = (SpawnObject)obj4;
						Type type2 = null;
						if (spawnObject4.TypeName != null)
						{
							string[] strArray2 = spawnObject4.TypeName.Split(new char[] { '/' });
							string name2 = null;
							if (strArray2 != null && strArray2.Length != 0)
							{
								name2 = strArray2[0];
							}
							type2 = SpawnEditor.FindRunUOType(name2);
						}
						if (type2 != null && (type2 == runUoType2 || type2.IsSubclassOf(runUoType2)))
						{
							flag6 = true;
							break;
						}
					}
				}
				if (this.cmbEntryTypeHas2.SelectedIndex == 0)
				{
					if (!flag6)
					{
						flag = false;
					}
				}
				else if (flag6)
				{
					flag = false;
				}
			}
			if (flag && this.cmbInContainers.SelectedIndex > 0)
			{
				if (this.cmbInContainers.SelectedIndex == 1 && !spawn.SpawnInContainer)
				{
					flag = false;
				}
				else if (this.cmbInContainers.SelectedIndex == 2 && spawn.SpawnInContainer)
				{
					flag = false;
				}
			}
			if (flag && this.cmbSequential.SelectedIndex > 0)
			{
				if (this.cmbSequential.SelectedIndex == 1 && spawn.SpawnSequentialSpawn < 0)
				{
					flag = false;
				}
				else if (this.cmbSequential.SelectedIndex == 2 && spawn.SpawnSequentialSpawn >= 0)
				{
					flag = false;
				}
			}
			if (flag && this.cmbSmartSpawning.SelectedIndex > 0)
			{
				if (this.cmbSmartSpawning.SelectedIndex == 1 && !spawn.SpawnSmartSpawning)
				{
					flag = false;
				}
				else if (this.cmbSmartSpawning.SelectedIndex == 2 && spawn.SpawnSmartSpawning)
				{
					flag = false;
				}
			}
			if (flag && this.cmbProximity.SelectedIndex > 0)
			{
				if (this.cmbProximity.SelectedIndex == 1 && spawn.SpawnProximityRange < 0)
				{
					flag = false;
				}
				else if (this.cmbProximity.SelectedIndex == 2 && spawn.SpawnProximityRange >= 0)
				{
					flag = false;
				}
			}
			if (flag && this.cmbRunning.SelectedIndex > 0)
			{
				if (this.cmbRunning.SelectedIndex == 1 && !spawn.SpawnIsRunning)
				{
					flag = false;
				}
				else if (this.cmbRunning.SelectedIndex == 2 && spawn.SpawnIsRunning)
				{
					flag = false;
				}
			}
			if (flag && this.chkAvgSpawnTime.Checked)
			{
				double num = (spawn.SpawnMinDelay + spawn.SpawnMaxDelay) / 2.0;
				if (this.cmbAvgSpawnTime.SelectedIndex == 0 && num >= (double)this.numAvgSpawnTime.Value)
				{
					flag = false;
				}
				else if (this.cmbAvgSpawnTime.SelectedIndex == 1 && num <= (double)this.numAvgSpawnTime.Value)
				{
					flag = false;
				}
			}
			string status_str;
			if (flag && this.txtPropertyTest.Text != null && this.txtPropertyTest.Text.Trim().Length > 0 && !PropertyTest.CheckPropertyString(spawn, this.txtPropertyTest.Text, out status_str))
			{
				flag = false;
			}
			if (flag && this.txtNotes.Text != null && this.txtNotes.Text.Trim().Length > 0)
			{
				bool flag7 = false;
				if (spawn.SpawnNotes != null && spawn.SpawnNotes.Length > 0 && spawn.SpawnNotes.ToLower().IndexOf(this.txtNotes.Text.ToLower()) >= 0)
				{
					flag7 = true;
				}
				if (this.cmbNotes.SelectedIndex == 0)
				{
					if (!flag7)
					{
						flag = false;
					}
				}
				else if (flag7)
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0002A4C8 File Offset: 0x000286C8
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0002A4D0 File Offset: 0x000286D0
		private void btnApply_Click(object sender, EventArgs e)
		{
			this._Editor._TransferDialog.DisplayStatusIndicator("Filtering Spawns...");
			if (!this._Editor.checkSpawnFilter.Checked)
			{
				this._Editor.checkSpawnFilter.Checked = true;
			}
			else
			{
				this._Editor.ApplySpawnFilter();
				this._Editor.RefreshSpawnPoints();
			}
			this._Editor._TransferDialog.HideStatusIndicator();
		}

		// Token: 0x04000331 RID: 817
		private SpawnEditor _Editor;
	}
}
