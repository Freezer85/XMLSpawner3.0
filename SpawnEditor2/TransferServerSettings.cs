using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.Engines.XmlSpawner2;

namespace SpawnEditor2
{
	// Token: 0x0200001D RID: 29
	public partial class TransferServerSettings : Form
	{
		// Token: 0x06000210 RID: 528 RVA: 0x0002467C File Offset: 0x0002287C
		public TransferServerSettings(SpawnEditor editor)
		{
			this._Editor = editor;
			this.InitializeComponent();
			this.InitializeSettings();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00027817 File Offset: 0x00025A17
		private void TransferServerSettings_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0002781C File Offset: 0x00025A1C
		private void InitializeSettings()
		{
			this.cmbStatics.SelectedIndex = 0;
			this.cmbVisible.SelectedIndex = 0;
			this.cmbMovable.SelectedIndex = 0;
			this.cmbItemInContainers.SelectedIndex = 2;
			this.cmbCarried.SelectedIndex = 2;
			this.cmbBlessed.SelectedIndex = 0;
			this.cmbControlled.SelectedIndex = 0;
			this.cmbInnocent.SelectedIndex = 0;
			this.cmbAccessLevel.SelectedIndex = 0;
			this.cmbCriminal.SelectedIndex = 0;
			this.cmbSmartSpawning.SelectedIndex = 0;
			this.cmbSequential.SelectedIndex = 0;
			this.cmbInContainers.SelectedIndex = 0;
			this.cmbModified.SelectedIndex = 0;
			this.cmbProximity.SelectedIndex = 0;
			this.cmbRunning.SelectedIndex = 0;
			this.dtModified.Value = DateTime.Now;
			this.cmbAvgSpawnTime.SelectedIndex = 0;
			this.cmbModifiedBy.SelectedIndex = 0;
			this.cmbModifiedNotBy.SelectedIndex = 0;
			this.cmbSpawnerMap.SelectedIndex = 0;
			this.cmbCreatureMap.SelectedIndex = 0;
			this.cmbItemMap.SelectedIndex = 0;
			this.cmbPlayerMap.SelectedIndex = 0;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00027950 File Offset: 0x00025B50
		internal void DisplayStatusIndicator(string text)
		{
			this._Editor.progressBar1.Visible = true;
			this._Editor.lblTransferStatus.Visible = true;
			this._Editor.trkZoom.Visible = false;
			this._Editor.lblTrkMin.Visible = false;
			this._Editor.lblTrkMax.Visible = false;
			this._Editor.lblTransferStatus.BringToFront();
			this._Editor.progressBar1.BringToFront();
			this._Editor.lblTransferStatus.Text = text;
			this._Editor.lblTransferStatus.Refresh();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000279F4 File Offset: 0x00025BF4
		internal void HideStatusIndicator()
		{
			this._Editor.progressBar1.Visible = false;
			this._Editor.lblTransferStatus.Visible = false;
			this._Editor.trkZoom.Visible = true;
			this._Editor.lblTrkMin.Visible = true;
			this._Editor.lblTrkMax.Visible = true;
			this._Editor.trkZoom.Refresh();
			this._Editor.lblTrkMin.Refresh();
			this._Editor.lblTrkMax.Refresh();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00027A88 File Offset: 0x00025C88
		private void btnDLCreatures_Click(object sender, EventArgs e)
		{
			GetObjectData getObjectData = new GetObjectData();
			getObjectData.SelectedMap = ((this.cmbCreatureMap.SelectedIndex != 1) ? this._Editor.cbxMap.SelectedIndex : (-1));
			getObjectData.ObjectType = ((this.txtCreatureType.Text == null || this.txtCreatureType.Text.Trim().Length <= 0) ? "BaseCreature" : this.txtCreatureType.Text.Trim());
			getObjectData.Controlled = (short)this.cmbControlled.SelectedIndex;
			getObjectData.Innocent = (short)this.cmbInnocent.SelectedIndex;
			getObjectData.AuthenticationID = this._Editor.SessionID;
			string text = this.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this.DisplayStatusIndicator("Getting Creature Info...");
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, getObjectData);
			if (transferMessage is ReturnObjectData)
			{
				this._Editor.MobLocArray = ((ReturnObjectData)transferMessage).Data;
				if (this._Editor.MobLocArray.Length == 0)
				{
					MessageBox.Show(this, "No Creatures found.", "Empty Download", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				this.listCreatures.Items.Clear();
				this.listCreatures.Sorted = false;
				for (int index = 0; index < this._Editor.MobLocArray.Length; index++)
				{
					this.listCreatures.Items.Add(this._Editor.MobLocArray[index]);
				}
				this.listCreatures.Sorted = true;
				this.chkShowCreatures.Text = string.Format("Show Creatures ({0})", this._Editor.MobLocArray.Length);
				this.chkShowCreatures.Checked = true;
				this.DisplayStatusIndicator("Updating Display...");
				this._Editor.RefreshSpawnPoints();
			}
			this.HideStatusIndicator();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00027C78 File Offset: 0x00025E78
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00027C80 File Offset: 0x00025E80
		private void btnDLItems_Click(object sender, EventArgs e)
		{
			GetObjectData getObjectData = new GetObjectData();
			getObjectData.SelectedMap = ((this.cmbItemMap.SelectedIndex != 1) ? this._Editor.cbxMap.SelectedIndex : (-1));
			getObjectData.Movable = (short)this.cmbMovable.SelectedIndex;
			getObjectData.Visible = (short)this.cmbVisible.SelectedIndex;
			getObjectData.Statics = (short)this.cmbStatics.SelectedIndex;
			getObjectData.InContainers = (short)this.cmbItemInContainers.SelectedIndex;
			getObjectData.Blessed = (short)this.cmbBlessed.SelectedIndex;
			getObjectData.Carried = (short)this.cmbCarried.SelectedIndex;
			getObjectData.ItemID = -1;
			if (this.txtItemID.Text != null && this.txtItemID.Text.Length > 0)
			{
				try
				{
					getObjectData.ItemID = ((!this.txtItemID.Text.StartsWith("0x")) ? int.Parse(this.txtItemID.Text) : Convert.ToInt32(this.txtItemID.Text, 16));
				}
				catch
				{
				}
			}
			getObjectData.ObjectType = ((this.txtItemType.Text == null || this.txtItemType.Text.Trim().Length <= 0) ? "Item" : this.txtItemType.Text.Trim());
			getObjectData.AuthenticationID = this._Editor.SessionID;
			string text = this.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this.DisplayStatusIndicator("Getting Item Info...");
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, getObjectData);
			if (transferMessage is ReturnObjectData)
			{
				this._Editor.ItemLocArray = ((ReturnObjectData)transferMessage).Data;
				if (this._Editor.ItemLocArray.Length == 0)
				{
					MessageBox.Show(this, "No Items found.", "Empty Download", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				this.listItems.Items.Clear();
				this.listItems.Sorted = false;
				for (int index = 0; index < this._Editor.ItemLocArray.Length; index++)
				{
					this.listItems.Items.Add(this._Editor.ItemLocArray[index]);
				}
				this.listItems.Sorted = true;
				this.chkShowItems.Text = string.Format("Show Items ({0})", this._Editor.ItemLocArray.Length);
				this.chkShowItems.Checked = true;
				this.DisplayStatusIndicator("Updating Display...");
				this._Editor.RefreshSpawnPoints();
			}
			this.HideStatusIndicator();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00027F30 File Offset: 0x00026130
		private void btnDLPlayers_Click(object sender, EventArgs e)
		{
			GetObjectData getObjectData = new GetObjectData();
			getObjectData.SelectedMap = ((this.cmbPlayerMap.SelectedIndex != 1) ? this._Editor.cbxMap.SelectedIndex : (-1));
			getObjectData.ObjectType = "PlayerMobile";
			getObjectData.Access = (short)this.cmbAccessLevel.SelectedIndex;
			getObjectData.Criminal = (short)this.cmbCriminal.SelectedIndex;
			getObjectData.AuthenticationID = this._Editor.SessionID;
			string text = this.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this.DisplayStatusIndicator("Getting Player Info...");
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, getObjectData);
			if (transferMessage is ReturnObjectData)
			{
				this._Editor.PlayerLocArray = ((ReturnObjectData)transferMessage).Data;
				if (this._Editor.PlayerLocArray.Length == 0)
				{
					MessageBox.Show(this, "No Players found.", "Empty Download", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				this.listPlayers.Items.Clear();
				this.listPlayers.Sorted = false;
				for (int index = 0; index < this._Editor.PlayerLocArray.Length; index++)
				{
					this.listPlayers.Items.Add(this._Editor.PlayerLocArray[index]);
				}
				this.listPlayers.Sorted = true;
				this.chkShowPlayers.Text = string.Format("Show Players ({0})", this._Editor.PlayerLocArray.Length);
				this.chkShowPlayers.Checked = true;
				this.DisplayStatusIndicator("Updating Display...");
				this._Editor.RefreshSpawnPoints();
			}
			this.HideStatusIndicator();
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000280E8 File Offset: 0x000262E8
		private void btnDLSpawners_Click(object sender, EventArgs e)
		{
			GetSpawnerData getSpawnerData = new GetSpawnerData();
			if (sender == this.btnDLSpawners)
			{
				this._Editor.tvwSpawnPoints.Nodes.Clear();
			}
			getSpawnerData.SelectedMap = ((this.cmbSpawnerMap.SelectedIndex != 1) ? this._Editor.cbxMap.SelectedIndex : (-1));
			if (this.chkSpawnerWithinSelectionWindow.Checked && this._Editor._SelectionWindow != null)
			{
				getSpawnerData.X = (int)this._Editor._SelectionWindow.X;
				getSpawnerData.Y = (int)this._Editor._SelectionWindow.Y;
				getSpawnerData.Width = (int)this._Editor._SelectionWindow.Width;
				getSpawnerData.Height = (int)this._Editor._SelectionWindow.Height;
			}
			else
			{
				getSpawnerData.Width = -1;
				getSpawnerData.Height = -1;
			}
			getSpawnerData.NameFilter = this.txtSpawnerName.Text;
			getSpawnerData.NameCase = this.chkNameCase.Checked;
			getSpawnerData.EntryFilter = this.txtSpawnerEntry.Text;
			getSpawnerData.EntryCase = this.chkEntryCase.Checked;
			getSpawnerData.ContainerFilter = (short)this.cmbInContainers.SelectedIndex;
			getSpawnerData.SmartSpawnFilter = (short)this.cmbSmartSpawning.SelectedIndex;
			getSpawnerData.SequentialFilter = (short)this.cmbSequential.SelectedIndex;
			getSpawnerData.Proximity = (short)this.cmbProximity.SelectedIndex;
			getSpawnerData.Running = (short)this.cmbRunning.SelectedIndex;
			if (this.chkAvgSpawnTime.Checked)
			{
				getSpawnerData.AvgSpawnTime = (double)this.numAvgSpawnTime.Value;
				getSpawnerData.SpawnTime = (short)(this.cmbAvgSpawnTime.SelectedIndex + 1);
			}
			else
			{
				getSpawnerData.SpawnTime = 0;
			}
			getSpawnerData.Modified = ((!this.chkModified.Checked) ? (short)0 : ((short)(this.cmbModified.SelectedIndex + 1)));
			getSpawnerData.ModifiedDate = this.dtModified.Value;
			getSpawnerData.ModifiedBy = ((!this.chkModifiedBy.Checked) ? (short)0 : ((short)(this.cmbModifiedBy.SelectedIndex + 1 + this.cmbModifiedNotBy.SelectedIndex * 2)));
			getSpawnerData.ModifiedName = this.txtModifiedBy.Text;
			getSpawnerData.AuthenticationID = this._Editor.SessionID;
			string text = this.txtTransferServerAddress.Text;
			int Port = -1;
			try
			{
				Port = int.Parse(this.txtTransferServerPort.Text);
			}
			catch
			{
			}
			this.DisplayStatusIndicator("Downloading Spawners...");
			SpawnEditor.LogWarning(string.Format("GetSpawners request: server={0}:{1}, map={2}, withinSelection={3}, nameFilter='{4}', entryFilter='{5}', containerFilter={6}, smartFilter={7}, sequentialFilter={8}, proximity={9}, running={10}, modified={11}, modifiedBy={12}", text, Port, getSpawnerData.SelectedMap, this.chkSpawnerWithinSelectionWindow.Checked, getSpawnerData.NameFilter ?? string.Empty, getSpawnerData.EntryFilter ?? string.Empty, getSpawnerData.ContainerFilter, getSpawnerData.SmartSpawnFilter, getSpawnerData.SequentialFilter, getSpawnerData.Proximity, getSpawnerData.Running, getSpawnerData.Modified, getSpawnerData.ModifiedBy));
			TransferMessage transferMessage = TransferConnection.ProcessMessage(text, Port, getSpawnerData);
			if (transferMessage == null)
			{
				SpawnEditor.LogWarning("GetSpawners response: <null>");
			}
			else
			{
				SpawnEditor.LogWarning("GetSpawners response type: " + transferMessage.GetType().FullName);
			}
			if (transferMessage is ReturnSpawnerData)
			{
				byte[] data = ((ReturnSpawnerData)transferMessage).Data;
				SpawnEditor.LogWarning(string.Format("GetSpawners payload length: {0}", (data != null) ? data.Length : 0));
				if (data == null || data.Length == 0)
				{
					MessageBox.Show(this, "No Spawners found.", "Empty Download", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this._Editor.LoadSpawnFile(new MemoryStream(data), null, WorldMap.Internal);
				}
			}
			else if (transferMessage is ErrorMessage)
			{
				SpawnEditor.LogWarning("GetSpawners error: " + ((ErrorMessage)transferMessage).Message);
			}
			this.DisplayStatusIndicator("Updating Display...");
			this._Editor.RefreshSpawnPoints();
			this.HideStatusIndicator();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000283D8 File Offset: 0x000265D8
		private void btnRenew_Click(object sender, EventArgs e)
		{
			this._Editor.SessionID = Guid.NewGuid();
			this._Editor.SendAuthCommand(this._Editor.SessionID);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00028400 File Offset: 0x00026600
		private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			ObjectData objectData = this.listPlayers.SelectedItem as ObjectData;
			if (objectData == null)
			{
				return;
			}
			this._Editor.cbxMap.SelectedIndex = objectData.Map;
			this._Editor.axUOMap.SetCenter((short)objectData.X, (short)objectData.Y);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00028458 File Offset: 0x00026658
		private void listItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			ObjectData objectData = this.listItems.SelectedItem as ObjectData;
			if (objectData == null)
			{
				return;
			}
			this._Editor.cbxMap.SelectedIndex = objectData.Map;
			this._Editor.axUOMap.SetCenter((short)objectData.X, (short)objectData.Y);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000284B0 File Offset: 0x000266B0
		private void listCreatures_SelectedIndexChanged(object sender, EventArgs e)
		{
			ObjectData objectData = this.listCreatures.SelectedItem as ObjectData;
			if (objectData == null)
			{
				return;
			}
			this._Editor.cbxMap.SelectedIndex = objectData.Map;
			this._Editor.axUOMap.SetCenter((short)objectData.X, (short)objectData.Y);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00028506 File Offset: 0x00026706
		private void chkSpawnerWithinSelectionWindow_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkSpawnerWithinSelectionWindow.Checked)
			{
				this.cmbSpawnerMap.SelectedIndex = 0;
				this.cmbSpawnerMap.Enabled = false;
				return;
			}
			this.cmbSpawnerMap.Enabled = true;
		}

		// Token: 0x040002E7 RID: 743
		private SpawnEditor _Editor;
	}
}
