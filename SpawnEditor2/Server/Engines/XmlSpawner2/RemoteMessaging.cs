using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000024 RID: 36
	public class RemoteMessaging : MarshalByRefObject
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000237 RID: 567 RVA: 0x0002A62C File Offset: 0x0002882C
		// (remove) Token: 0x06000238 RID: 568 RVA: 0x0002A660 File Offset: 0x00028860
		public static event RemoteMessaging.Message OnReceiveMessage;

		// Token: 0x06000239 RID: 569 RVA: 0x0002A693 File Offset: 0x00028893
		public RemoteMessaging()
		{
			RemoteMessaging.n_instances++;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0002A6A8 File Offset: 0x000288A8
		~RemoteMessaging()
		{
			RemoteMessaging.n_instances--;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0002A6DC File Offset: 0x000288DC
		public byte[] PerformRemoteRequest(string typeName, byte[] data, out string answerType)
		{
			answerType = null;
			if (RemoteMessaging.OnReceiveMessage != null)
			{
				return RemoteMessaging.OnReceiveMessage(typeName, data, out answerType);
			}
			return null;
		}

		// Token: 0x0400036A RID: 874
		private static int n_instances;

		// Token: 0x02000034 RID: 52
		// (Invoke) Token: 0x06000279 RID: 633
		public delegate byte[] Message(string typeName, byte[] data, out string answerType);
	}
}
