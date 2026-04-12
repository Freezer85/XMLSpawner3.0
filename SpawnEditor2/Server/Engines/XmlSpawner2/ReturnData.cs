using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	public class ReturnData : TransferMessage
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0002A6F7 File Offset: 0x000288F7
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0002A6FF File Offset: 0x000288FF
		public string Typename
		{
			get
			{
				return this.m_Typename;
			}
			set
			{
				this.m_Typename = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0002A708 File Offset: 0x00028908
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0002A710 File Offset: 0x00028910
		public object Data
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

		// Token: 0x06000240 RID: 576 RVA: 0x0002A719 File Offset: 0x00028919
		public ReturnData(object data, string type)
		{
			this.m_Data = data;
			this.m_Typename = type;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0002A72F File Offset: 0x0002892F
		public ReturnData(object data)
		{
			this.m_Data = data;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0002A73E File Offset: 0x0002893E
		public ReturnData()
		{
		}

		// Token: 0x0400036C RID: 876
		private object m_Data;

		// Token: 0x0400036D RID: 877
		private string m_Typename;
	}
}
