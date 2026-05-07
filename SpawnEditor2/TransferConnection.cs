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
				SpawnEditor.LogWarning(string.Format("No Message Data Received from Remote Server for {0} ({1})", t, rtype));
				DisableTrackingOnEditor();
				return true;
			}
			if (!(msg is ErrorMessage))
			{
				return false;
			}
			SpawnEditor.LogWarning((msg as ErrorMessage).Message);
			DisableTrackingOnEditor();
			return true;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00024550 File Offset: 0x00022750
		public static TransferMessage ProcessMessage(string Address, int Port, TransferMessage msg)
		{
			if (string.IsNullOrWhiteSpace(Address))
			{
				SpawnEditor.LogWarning("ProcessMessage: empty Address provided, defaulting to 127.0.0.1");
				Address = "127.0.0.1";
			}
			byte[] data = msg.Compress();
			string answerType = null;
			string url = string.Format("tcp://{0}:{1}/RemoteMessaging", Address, Port);
			SpawnEditor.LogWarning(string.Format("ProcessMessage start: requestType={0}, authId={1}, useMainThread={2}, payloadBytes={3}, url={4}", msg.GetType().FullName, msg.AuthenticationID, msg.UseMainThread, (data != null) ? data.Length : 0, url));
			try
			{
				TransferConnection.m_Remote = Activator.GetObject(typeof(RemoteMessaging), url) as RemoteMessaging;
			}
			catch
				{
					SpawnEditor.LogWarning(string.Format("Failed to connect to remote server {0} : {1}", Address, Port));
					// Non mostrare popup bloccante: il problema viene registrato nel log.
					// Manteniamo la disabilitazione del tracking per evitare loop di richieste.
					DisableTrackingOnEditor();
					return null;
				}
			TransferMessage msg2;
			try
			{
				byte[] data2 = TransferConnection.m_Remote.PerformRemoteRequest(msg.GetType().FullName, data, out answerType);
				SpawnEditor.LogWarning(string.Format("ProcessMessage response: requestType={0}, answerType={1}, responseBytes={2}", msg.GetType().FullName, answerType ?? "<null>", (data2 != null) ? data2.Length : 0));
					if (data2 == null)
					{
						SpawnEditor.LogWarning(string.Format("ProcessMessage null response payload for {0}", msg.GetType().FullName));
						MessageBox.Show("No Data Received from Remote Server for " + msg.GetType().FullName);
						DisableTrackingOnEditor();
						return null;
					}
				if (data2.Length < 4)
				{
					SpawnEditor.LogWarning(string.Format("ProcessMessage short response payload: requestType={0}, answerType={1}, responseBytes={2}, bytes=[{3}]", msg.GetType().FullName, answerType ?? "<null>", data2.Length, BitConverter.ToString(data2)));
					MessageBox.Show(string.Format("Invalid compressed response from remote server for {0}. Response length: {1} bytes.", msg.GetType().FullName, data2.Length), "Transfer Diagnostic");
					DisableTrackingOnEditor();
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
				if (type == null)
				{
					SpawnEditor.LogWarning(string.Format("ProcessMessage: could not resolve answer type '{0}' for requestType={1}", answerType ?? "<null>", msg.GetType().FullName));
				}
				msg2 = TransferMessage.Decompress(data2, type);
				SpawnEditor.LogWarning(string.Format("ProcessMessage decoded response: requestType={0}, responseType={1}", msg.GetType().FullName, (msg2 != null) ? msg2.GetType().FullName : "<null>"));
				if (TransferConnection.HasErrors(msg2, type, answerType))
				{
					msg2 = null;
				}
			}
			catch (Exception ex)
			{
				SpawnEditor.LogWarning("ProcessMessage exception: " + ex.Message);
				SpawnEditor.LogError(string.Format("ProcessMessage exception detail: requestType={0}, url={1}, error={2}", msg.GetType().FullName, url, ex));
				DisableTrackingOnEditor();
				msg2 = null;
			}
			return msg2;
		}

		private static void DisableTrackingOnEditor()
		{
			try
			{
				foreach (Form f in Application.OpenForms)
				{
					if (f.GetType().Name == "SpawnEditor")
					{
						Form editor = f;
						if (editor.InvokeRequired)
						{
							editor.BeginInvoke((MethodInvoker)delegate
							{
								try
								{
									var fi = editor.GetType().GetField("chkTracking", BindingFlags.Instance | BindingFlags.NonPublic);
									if (fi != null)
									{
										var chk = fi.GetValue(editor) as CheckBox;
										if (chk != null)
										chk.Checked = false;
									}
								}
								catch { }
							});
						}
						else
						{
							try
							{
								var fi = editor.GetType().GetField("chkTracking", BindingFlags.Instance | BindingFlags.NonPublic);
								if (fi != null)
								{
									var chk = fi.GetValue(editor) as CheckBox;
									if (chk != null)
									chk.Checked = false;
								}
							}
							catch { }
						}
						break;
					}
				}
			}
			catch { }
		}

		// Token: 0x040002B7 RID: 695
		private static RemoteMessaging m_Remote;
	}
}
