using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	public abstract class TransferMessage
	{
		// Token: 0x06000253 RID: 595 RVA: 0x0002A7FA File Offset: 0x000289FA
		public virtual TransferMessage ProcessMessage()
		{
			return new ErrorMessage("Empty ProcessMessage");
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0002A806 File Offset: 0x00028A06
		public virtual byte[] Compress()
		{
			return ZLib.Compress(this);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0002A80E File Offset: 0x00028A0E
		public static TransferMessage Decompress(byte[] data, Type type)
		{
			return ZLib.Decompress(data, type) as TransferMessage;
		}

		// Token: 0x04000375 RID: 885
		public Guid AuthenticationID;

		// Token: 0x04000376 RID: 886
		public bool UseMainThread;
	}
}
