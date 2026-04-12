using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000020 RID: 32
	[Serializable]
	public class ErrorMessage : TransferMessage
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0002A53D File Offset: 0x0002873D
		// (set) Token: 0x06000229 RID: 553 RVA: 0x0002A545 File Offset: 0x00028745
		public string Message
		{
			get
			{
				return this.m_Message;
			}
			set
			{
				this.m_Message = value;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0002A54E File Offset: 0x0002874E
		public ErrorMessage(string message)
		{
			this.m_Message = message;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0002A560 File Offset: 0x00028760
		public ErrorMessage(string message, params string[] args)
		{
			this.m_Message = string.Format(message, args);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0002A582 File Offset: 0x00028782
		public ErrorMessage()
		{
		}

		// Token: 0x04000344 RID: 836
		private string m_Message;
	}
}
