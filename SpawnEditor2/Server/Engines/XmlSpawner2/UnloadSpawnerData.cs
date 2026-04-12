using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	public class UnloadSpawnerData : TransferMessage
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0002A824 File Offset: 0x00028A24
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0002A82C File Offset: 0x00028A2C
		public byte[] Data
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0002A835 File Offset: 0x00028A35
		public UnloadSpawnerData(byte[] data)
		{
			this.Data = data;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0002A844 File Offset: 0x00028A44
		public UnloadSpawnerData()
		{
		}

		// Token: 0x04000377 RID: 887
		private byte[] m_Data;
	}
}
