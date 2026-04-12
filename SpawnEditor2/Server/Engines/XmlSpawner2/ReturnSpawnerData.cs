using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class ReturnSpawnerData : TransferMessage
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0002A76E File Offset: 0x0002896E
		// (set) Token: 0x06000248 RID: 584 RVA: 0x0002A776 File Offset: 0x00028976
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

		// Token: 0x06000249 RID: 585 RVA: 0x0002A77F File Offset: 0x0002897F
		public ReturnSpawnerData(byte[] stream)
		{
			this.m_Data = stream;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0002A78E File Offset: 0x0002898E
		public ReturnSpawnerData()
		{
		}

		// Token: 0x0400036F RID: 879
		private byte[] m_Data;
	}
}
