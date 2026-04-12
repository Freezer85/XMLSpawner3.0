using System;
using System.Reflection;
using System.Windows.Forms;
using Server.Engines.XmlSpawner2;

namespace SpawnEditor2
{
	// Token: 0x0200001C RID: 28
	public class TransferConnection
	{
		// Token: 0x0600020D RID: 525 RVA: 0x00024518 File Offset: 0x00022718
		public static bool HasErrors(TransferMessage msg, Type t, string rtype)
		{
			if (msg == null)
			{
				MessageBox.Show(string.Format("No Message Data Received from Remote Server for {0} ({1})", t, rtype));
				return true;
			}
			if (!(msg is ErrorMessage))
			{
				return false;
			}
			MessageBox.Show((msg as ErrorMessage).Message);
			return true;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00024550 File Offset: 0x00022750
		public static TransferMessage ProcessMessage(string Address, int Port, TransferMessage msg)
		{
			byte[] data = msg.Compress();
			string answerType = null;
			string url = string.Format("tcp://{0}:{1}/RemoteMessaging", Address, Port);
			try
			{
				TransferConnection.m_Remote = Activator.GetObject(typeof(RemoteMessaging), url) as RemoteMessaging;
			}
			catch
			{
				MessageBox.Show(string.Format("Failed to connect to remote server {0} : {1}", Address, Port));
				return null;
			}
			TransferMessage msg2;
			try
			{
				byte[] data2 = TransferConnection.m_Remote.PerformRemoteRequest(msg.GetType().FullName, data, out answerType);
				if (data2 == null)
				{
					MessageBox.Show("No Data Received from Remote Server for " + msg.GetType().FullName);
					return null;
				}
				Type type = Type.GetType(answerType);
				if (type == null)
				{
					Assembly assembly = Assembly.GetAssembly(typeof(TransferMessage));
					if (assembly != null)
					{
						type = assembly.GetType(answerType);
					}
				}
				msg2 = TransferMessage.Decompress(data2, type);
				if (TransferConnection.HasErrors(msg2, type, answerType))
				{
					msg2 = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				msg2 = null;
			}
			return msg2;
		}

		// Token: 0x040002B7 RID: 695
		private static RemoteMessaging m_Remote;
	}
}
