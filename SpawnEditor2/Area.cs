using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpawnEditor2
{
	// Token: 0x02000004 RID: 4
	public partial class Area : Form
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002B58 File Offset: 0x00000D58
		public Area(SpawnPoint Spawn, SpawnEditor Editor)
		{
			this.InitializeComponent();
			this._Spawn = Spawn;
			this._Editor = Editor;
			int num = this._Editor.grpSpawnEdit.Left + this._Editor.grpSpawnEdit.Parent.Left + this._Editor.Left;
			int num2 = this._Editor.grpSpawnEdit.Top + this._Editor.grpSpawnEdit.Parent.Top + this._Editor.btnUpdateSpawn.Top + this._Editor.Top;
			base.Left = num;
			base.Top = num2;
			this.spnX.Value = this._Spawn.Bounds.X;
			this.spnY.Value = this._Spawn.Bounds.Y;
			this.spnWidth.Value = this._Spawn.Bounds.Width;
			this.spnHeight.Value = this._Spawn.Bounds.Height;
			this.spnCentreX.Value = this._Spawn.CentreX;
			this.spnCentreY.Value = this._Spawn.CentreY;
			this.spnCentreZ.Value = this._Spawn.CentreZ;
			this._IsConstructed = true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003948 File Offset: 0x00001B48
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

		// Token: 0x06000013 RID: 19 RVA: 0x0000398C File Offset: 0x00001B8C
		private void SpinBox_ValueChanged(object sender, EventArgs e)
		{
			if (!this._IsConstructed)
			{
				return;
			}
			NumericUpDown numericUpDown = sender as NumericUpDown;
			if (numericUpDown == null)
			{
				return;
			}
			if (numericUpDown == this.spnX)
			{
				SpawnPoint spawn = this._Spawn;
				int x = (int)this.spnX.Value;
				int y = this._Spawn.Bounds.Y;
				int width = this._Spawn.Bounds.Width;
				int height = this._Spawn.Bounds.Height;
				Rectangle rectangle = new Rectangle(x, y, width, height);
				spawn.Bounds = rectangle;
			}
			else if (numericUpDown == this.spnY)
			{
				SpawnPoint spawn2 = this._Spawn;
				int x2 = this._Spawn.Bounds.X;
				int y2 = (int)this.spnY.Value;
				int width2 = this._Spawn.Bounds.Width;
				int height2 = this._Spawn.Bounds.Height;
				Rectangle rectangle2 = new Rectangle(x2, y2, width2, height2);
				spawn2.Bounds = rectangle2;
			}
			else if (numericUpDown == this.spnWidth)
			{
				SpawnPoint spawn3 = this._Spawn;
				int x3 = this._Spawn.Bounds.X;
				int y3 = this._Spawn.Bounds.Y;
				int width3 = (int)this.spnWidth.Value;
				int height3 = this._Spawn.Bounds.Height;
				Rectangle rectangle3 = new Rectangle(x3, y3, width3, height3);
				spawn3.Bounds = rectangle3;
			}
			else if (numericUpDown == this.spnHeight)
			{
				SpawnPoint spawn4 = this._Spawn;
				int x4 = this._Spawn.Bounds.X;
				int y4 = this._Spawn.Bounds.Y;
				int width4 = this._Spawn.Bounds.Width;
				int height4 = (int)this.spnHeight.Value;
				Rectangle rectangle4 = new Rectangle(x4, y4, width4, height4);
				spawn4.Bounds = rectangle4;
			}
			if (!this._Editor.SpawnLocationLocked)
			{
				SpawnPoint spawn5 = this._Spawn;
				int x5 = this._Spawn.Bounds.X;
				int num = this._Spawn.Bounds.Width / 2;
				int num2 = (int)((short)(x5 + num));
				spawn5.CentreX = (short)num2;
				SpawnPoint spawn6 = this._Spawn;
				int y5 = this._Spawn.Bounds.Y;
				int num3 = this._Spawn.Bounds.Height / 2;
				int num4 = (int)((short)(y5 + num3));
				spawn6.CentreY = (short)num4;
			}
			this._Editor.spnSpawnRange.Value = -1m;
			this._Editor.RefreshSpawnPoints();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003C3C File Offset: 0x00001E3C
		private void Area_KeyDown(object sender, KeyEventArgs e)
		{
			int num = 1;
			if (e.Shift)
			{
				num = 5;
			}
			if (e.KeyCode == Keys.Down)
			{
				if (e.Control)
				{
					this.spnHeight.Value += num;
				}
				else
				{
					this.spnY.Value += num;
				}
				e.Handled = true;
				return;
			}
			if (e.KeyCode == Keys.Up)
			{
				if (e.Control)
				{
					this.spnHeight.Value -= num;
				}
				else
				{
					this.spnY.Value -= num;
				}
				e.Handled = true;
				return;
			}
			if (e.KeyCode == Keys.Left)
			{
				if (e.Control)
				{
					this.spnWidth.Value -= num;
				}
				else
				{
					this.spnX.Value -= num;
				}
				e.Handled = true;
				return;
			}
			if (e.KeyCode != Keys.Right)
			{
				return;
			}
			if (e.Control)
			{
				this.spnWidth.Value += num;
			}
			else
			{
				this.spnX.Value += num;
			}
			e.Handled = true;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003DA5 File Offset: 0x00001FA5
		private void Area_Load(object sender, EventArgs e)
		{
			if (!this._Editor.TopMost)
			{
				return;
			}
			base.TopMost = true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003DBC File Offset: 0x00001FBC
		private void spnCentreX_ValueChanged(object sender, EventArgs e)
		{
			if (!this._IsConstructed)
			{
				return;
			}
			this._Spawn.CentreX = (short)this.spnCentreX.Value;
			this._Editor.RefreshSpawnPoints();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003DED File Offset: 0x00001FED
		private void spnCentreY_ValueChanged(object sender, EventArgs e)
		{
			if (!this._IsConstructed)
			{
				return;
			}
			this._Spawn.CentreY = (short)this.spnCentreY.Value;
			this._Editor.RefreshSpawnPoints();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003E1E File Offset: 0x0000201E
		private void spnCentreZ_ValueChanged(object sender, EventArgs e)
		{
			if (!this._IsConstructed)
			{
				return;
			}
			this._Spawn.CentreZ = (short)this.spnCentreZ.Value;
			this._Editor.RefreshSpawnPoints();
		}

		// Token: 0x04000014 RID: 20
		private SpawnEditor _Editor;

		// Token: 0x04000015 RID: 21
		private SpawnPoint _Spawn;

		// Token: 0x04000016 RID: 22
		private bool _IsConstructed;
	}
}
