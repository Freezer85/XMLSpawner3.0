using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000029 RID: 41
	[Serializable]
	public class ReturnSpawnerUnloadStatus : TransferMessage
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0002A7B4 File Offset: 0x000289B4
		public ReturnSpawnerUnloadStatus(int nspawners, int nmaps)
		{
			this.ProcessedMaps = nmaps;
			this.ProcessedSpawners = nspawners;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0002A7CA File Offset: 0x000289CA
		public ReturnSpawnerUnloadStatus()
		{
		}

		// Token: 0x04000372 RID: 882
		public int ProcessedMaps;

		// Token: 0x04000373 RID: 883
		public int ProcessedSpawners;
	}
}
