using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	public class ReturnSpawnerSaveStatus : TransferMessage
	{
		// Token: 0x0600024B RID: 587 RVA: 0x0002A796 File Offset: 0x00028996
		public ReturnSpawnerSaveStatus(int nspawners, int nmaps)
		{
			this.ProcessedMaps = nmaps;
			this.ProcessedSpawners = nspawners;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0002A7AC File Offset: 0x000289AC
		public ReturnSpawnerSaveStatus()
		{
		}

		// Token: 0x04000370 RID: 880
		public int ProcessedMaps;

		// Token: 0x04000371 RID: 881
		public int ProcessedSpawners;
	}
}
