using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	public class GetObjectData : TransferMessage
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0002A58A File Offset: 0x0002878A
		public GetObjectData()
		{
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0002A592 File Offset: 0x00028792
		public GetObjectData(int map)
		{
			this.SelectedMap = map;
		}

		// Token: 0x04000345 RID: 837
		public int SelectedMap;

		// Token: 0x04000346 RID: 838
		public string ObjectType;

		// Token: 0x04000347 RID: 839
		public int ItemID;

		// Token: 0x04000348 RID: 840
		public short Statics;

		// Token: 0x04000349 RID: 841
		public short Visible;

		// Token: 0x0400034A RID: 842
		public short Movable;

		// Token: 0x0400034B RID: 843
		public short InContainers;

		// Token: 0x0400034C RID: 844
		public short Carried;

		// Token: 0x0400034D RID: 845
		public short Blessed;

		// Token: 0x0400034E RID: 846
		public short Innocent;

		// Token: 0x0400034F RID: 847
		public short Controlled;

		// Token: 0x04000350 RID: 848
		public short Access;

		// Token: 0x04000351 RID: 849
		public short Criminal;
	}
}
