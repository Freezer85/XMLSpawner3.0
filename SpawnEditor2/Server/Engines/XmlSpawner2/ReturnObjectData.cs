using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public class ReturnObjectData : TransferMessage
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0002A746 File Offset: 0x00028946
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0002A74E File Offset: 0x0002894E
		public ObjectData[] Data
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

		// Token: 0x06000245 RID: 581 RVA: 0x0002A757 File Offset: 0x00028957
		public ReturnObjectData(ObjectData[] data)
		{
			this.m_Data = data;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0002A766 File Offset: 0x00028966
		public ReturnObjectData()
		{
		}

		// Token: 0x0400036E RID: 878
		private ObjectData[] m_Data;
	}
}
