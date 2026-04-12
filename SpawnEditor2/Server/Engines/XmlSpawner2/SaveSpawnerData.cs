using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	public class SaveSpawnerData : TransferMessage
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0002A7D2 File Offset: 0x000289D2
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0002A7DA File Offset: 0x000289DA
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

		// Token: 0x06000251 RID: 593 RVA: 0x0002A7E3 File Offset: 0x000289E3
		public SaveSpawnerData(byte[] data)
		{
			this.Data = data;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0002A7F2 File Offset: 0x000289F2
		public SaveSpawnerData()
		{
		}

		// Token: 0x04000374 RID: 884
		private byte[] m_Data;
	}
}
