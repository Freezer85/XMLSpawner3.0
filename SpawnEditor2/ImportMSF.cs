using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x02000009 RID: 9
	public class ImportMSF
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00006C44 File Offset: 0x00004E44
		public ImportMSF(SpawnEditor editor)
		{
			this._Editor = editor;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00006C53 File Offset: 0x00004E53
		private static string GetText(XmlElement node, string defaultValue)
		{
			if (node == null)
			{
				return defaultValue;
			}
			return node.InnerText;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00006C60 File Offset: 0x00004E60
		public void DoImportMSF(string filePath)
		{
			if (!File.Exists(filePath))
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filePath);
			XmlElement xmlElement = xmlDocument["MegaSpawners"];
			if (xmlElement != null)
			{
				int num = 0;
				int num2 = 0;
				IEnumerator enumerator = xmlElement.GetElementsByTagName("MegaSpawner").GetEnumerator();
				while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						XmlElement node = (XmlElement)obj;
						try
						{
							this.ImportMegaSpawner(node);
							num++;
						}
						catch
						{
							num2++;
						}
				return;
				}
			}
			MessageBox.Show(this._Editor, "Invalid .msf file. No MegaSpawners node found", "Import MSF Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00006D1C File Offset: 0x00004F1C
		private void ImportMegaSpawner(XmlElement node)
		{
			string text = ImportMSF.GetText(node["Name"], "MegaSpawner");
			bool.Parse(ImportMSF.GetText(node["Active"], "True"));
			MapLocation mapLocation = MapLocation.Parse(ImportMSF.GetText(node["Location"], "Error"));
			WorldMap Map = (WorldMap)Enum.Parse(typeof(WorldMap), ImportMSF.GetText(node["Map"], "Error"));
			string path = Path.Combine(this._Editor.StartingDirectory, "import.log");
			bool flag = false;
			int num = 0;
			int num2 = 4;
			int num3 = 4;
			TimeSpan timeSpan = TimeSpan.FromMinutes(10.0);
			TimeSpan timeSpan2 = TimeSpan.FromMinutes(5.0);
			XmlElement xmlElement = node["EntryLists"];
			int length = 0;
			SpawnObject[] spawnObjectArray = null;
			if (xmlElement != null)
			{
				if (xmlElement.HasAttributes)
				{
					length = int.Parse(xmlElement.Attributes.GetNamedItem("count").Value);
				}
				if (length > 0)
				{
					spawnObjectArray = new SpawnObject[length];
					int index = 0;
					bool flag2 = false;
					foreach (object obj in xmlElement.GetElementsByTagName("EntryList"))
					{
						XmlElement xmlElement2 = (XmlElement)obj;
						if (xmlElement2 != null)
						{
							if (index == 0)
							{
								flag = bool.Parse(ImportMSF.GetText(xmlElement2["GroupSpawn"], "False"));
								timeSpan = TimeSpan.FromSeconds((double)int.Parse(ImportMSF.GetText(xmlElement2["MaxDelay"], "10:00")));
								timeSpan2 = TimeSpan.FromSeconds((double)int.Parse(ImportMSF.GetText(xmlElement2["MinDelay"], "05:00")));
								num2 = int.Parse(ImportMSF.GetText(xmlElement2["WalkRange"], "10"));
								num3 = int.Parse(ImportMSF.GetText(xmlElement2["SpawnRange"], "4"));
							}
							else
							{
								if (flag != bool.Parse(ImportMSF.GetText(xmlElement2["GroupSpawn"], "False")))
								{
									flag2 = true;
									try
									{
										using (StreamWriter streamWriter = new StreamWriter(path, true))
										{
											streamWriter.WriteLine("MSFimport : individual group entry difference: {0} vs {1}", ImportMSF.GetText(xmlElement2["GroupSpawn"], "False"), flag ? 1 : 0);
										}
									}
									catch
									{
									}
								}
								if (timeSpan2 != TimeSpan.FromSeconds((double)int.Parse(ImportMSF.GetText(xmlElement2["MinDelay"], "05:00"))))
								{
									flag2 = true;
									try
									{
										using (StreamWriter streamWriter2 = new StreamWriter(path, true))
										{
											streamWriter2.WriteLine("MSFimport : individual mindelay entry difference: {0} vs {1}", ImportMSF.GetText(xmlElement2["MinDelay"], "05:00"), timeSpan2);
										}
									}
									catch
									{
									}
								}
								if (timeSpan != TimeSpan.FromSeconds((double)int.Parse(ImportMSF.GetText(xmlElement2["MaxDelay"], "10:00"))))
								{
									flag2 = true;
									try
									{
										using (StreamWriter streamWriter3 = new StreamWriter(path, true))
										{
											streamWriter3.WriteLine("MSFimport : individual maxdelay entry difference: {0} vs {1}", ImportMSF.GetText(xmlElement2["MaxDelay"], "10:00"), timeSpan);
										}
									}
									catch
									{
									}
								}
								if (num2 != int.Parse(ImportMSF.GetText(xmlElement2["WalkRange"], "10")))
								{
									flag2 = true;
									try
									{
										using (StreamWriter streamWriter4 = new StreamWriter(path, true))
										{
											streamWriter4.WriteLine("MSFimport : individual homerange entry difference: {0} vs {1}", ImportMSF.GetText(xmlElement2["WalkRange"], "10"), num2);
										}
									}
									catch
									{
									}
								}
								if (num3 != int.Parse(ImportMSF.GetText(xmlElement2["SpawnRange"], "4")))
								{
									flag2 = true;
									try
									{
										using (StreamWriter streamWriter5 = new StreamWriter(path, true))
										{
											streamWriter5.WriteLine("MSFimport : individual spawnrange entry difference: {0} vs {1}", ImportMSF.GetText(xmlElement2["SpawnRange"], "4"), num3);
										}
									}
									catch
									{
									}
								}
							}
							int maxamount = int.Parse(ImportMSF.GetText(xmlElement2["Amount"], "1"));
							string text2 = ImportMSF.GetText(xmlElement2["EntryType"], "");
							num += maxamount;
							spawnObjectArray[index] = new SpawnObject(text2, maxamount);
							index++;
							if (index > length)
							{
								try
								{
									using (StreamWriter streamWriter6 = new StreamWriter(path, true))
									{
										streamWriter6.WriteLine("{0} MSFImport Error; inconsistent entry count {1} {2}", DateTime.Now, mapLocation, Map);
										streamWriter6.WriteLine();
										break;
									}
								}
								catch
								{
									break;
								}
							}
						}
					}
					if (flag2)
					{
						try
						{
							using (StreamWriter streamWriter7 = new StreamWriter(path, true))
							{
								streamWriter7.WriteLine("{0} MSFImport: Individual entry setting differences listed above from spawner at {1} {2}", DateTime.Now, mapLocation, Map);
								streamWriter7.WriteLine();
							}
						}
						catch
						{
						}
					}
				}
			}
			if (mapLocation.Z == -999)
			{
				mapLocation.Z = -32768;
			}
			SpawnPoint Spawn = new SpawnPoint(Guid.NewGuid(), Map, (short)mapLocation.X, (short)mapLocation.Y, (short)(num3 * 2), (short)(num3 * 2));
			Spawn.SpawnName = text;
			Spawn.SpawnHomeRange = num2;
			Spawn.CentreZ = (short)mapLocation.Z;
			Spawn.SpawnMinDelay = timeSpan2.TotalMinutes;
			Spawn.SpawnMaxDelay = timeSpan.TotalMinutes;
			Spawn.SpawnMaxCount = num;
			Spawn.SpawnIsGroup = flag;
			Spawn.IsSelected = false;
			for (int index2 = 0; index2 < spawnObjectArray.Length; index2++)
			{
				Spawn.SpawnObjects.Add(spawnObjectArray[index2]);
			}
			this._Editor.tvwSpawnPoints.Nodes.Add(new SpawnPointNode(Spawn));
		}

		// Token: 0x04000095 RID: 149
		private SpawnEditor _Editor;
	}
}

