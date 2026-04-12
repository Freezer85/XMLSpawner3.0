using System;
using System.IO;

namespace SpawnEditor2
{
	// Token: 0x02000008 RID: 8
	public class ImportMap
	{
		// Token: 0x06000036 RID: 54 RVA: 0x0000663B File Offset: 0x0000483B
		public ImportMap(SpawnEditor editor)
		{
			this._Editor = editor;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000664C File Offset: 0x0000484C
		public void DoImportMap(string filename, out int processedmaps, out int processedspawners)
		{
			processedmaps = 0;
			processedspawners = 0;
			int num = 0;
			int num2 = 0;
			if (filename == null || filename.Length <= 0)
			{
				return;
			}
			if (File.Exists(filename))
			{
				string fileName = Path.GetFileName(filename);
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = -1;
				try
				{
					using (StreamReader streamReader = new StreamReader(filename))
					{
						string str;
						while ((str = streamReader.ReadLine()) != null)
						{
							num5++;
							string[] strArray = str.Trim().Split(new char[] { ' ' });
							if (strArray.Length == 2 && strArray[0].ToLower() == "overridemap")
							{
								try
								{
									num6 = int.Parse(strArray[1]);
								}
								catch
								{
								}
							}
							if (strArray.Length != 0 && strArray[0] == "*")
							{
								bool flag = false;
								int num7 = 0;
								int num8 = 0;
								int num9 = 0;
								int num10 = 0;
								int num11 = 0;
								int num12 = 0;
								int num13 = 0;
								int num14 = 0;
								int maxamount = 0;
								string[] strArray2 = null;
								if (strArray.Length != 11 && strArray.Length != 12)
								{
									flag = true;
								}
								else
								{
									strArray2 = strArray[1].Split(new char[] { ':' });
									if (strArray.Length == 11)
									{
										try
										{
											num7 = int.Parse(strArray[2]);
											num8 = int.Parse(strArray[3]);
											num9 = int.Parse(strArray[4]);
											num10 = int.Parse(strArray[5]);
											num11 = int.Parse(strArray[6]);
											num12 = int.Parse(strArray[7]);
											num13 = int.Parse(strArray[8]);
											num14 = int.Parse(strArray[9]);
											maxamount = int.Parse(strArray[10]);
											goto IL_01F1;
										}
										catch
										{
											flag = true;
											goto IL_01F1;
										}
									}
									if (strArray.Length == 12)
									{
										try
										{
											num7 = int.Parse(strArray[2]);
											num8 = int.Parse(strArray[3]);
											num9 = int.Parse(strArray[4]);
											num10 = int.Parse(strArray[5]);
											num11 = int.Parse(strArray[6]);
											num12 = int.Parse(strArray[7]);
											num13 = int.Parse(strArray[8]);
											num14 = int.Parse(strArray[9]);
											int.Parse(strArray[10]);
											maxamount = int.Parse(strArray[11]);
										}
										catch
										{
											flag = true;
										}
									}
								}
								IL_01F1:
								if (!flag && strArray2 != null && strArray2.Length != 0)
								{
									if (num6 >= 0)
									{
										num10 = num6;
									}
									WorldMap Map = WorldMap.Internal;
									switch (num10)
									{
									case 0:
										Map = WorldMap.Felucca;
										break;
									case 1:
										Map = WorldMap.Felucca;
										break;
									case 2:
										Map = WorldMap.Trammel;
										break;
									case 3:
										Map = WorldMap.Ilshenar;
										break;
									case 4:
										Map = WorldMap.Malas;
										break;
									case 5:
										try
										{
											Map = WorldMap.Tokuno;
										}
										catch
										{
										}
										break;
									}
									if (Map == WorldMap.Internal)
									{
										num4++;
									}
									else
									{
										SpawnPoint Spawn = new SpawnPoint(Guid.NewGuid(), Map, (short)num7, (short)num8, (short)(num14 * 2), (short)(num14 * 2));
										Spawn.SpawnName = string.Format("{0}#{1}", fileName, num3);
										Spawn.SpawnHomeRange = num13;
										Spawn.CentreZ = (short)num9;
										Spawn.SpawnMinDelay = (double)num11;
										Spawn.SpawnMaxDelay = (double)num12;
										Spawn.SpawnMaxCount = maxamount;
										Type runUoType = SpawnEditor.FindRunUOType("BaseVendor");
										bool flag2 = false;
										for (int index = 0; index < strArray2.Length; index++)
										{
											Type runUoType2 = SpawnEditor.FindRunUOType(strArray2[index]);
											if (runUoType2 != null && runUoType != null && (runUoType2 == runUoType || runUoType2.IsSubclassOf(runUoType)))
											{
												flag2 = true;
											}
											Spawn.SpawnObjects.Add(new SpawnObject(strArray2[index], maxamount));
										}
										Spawn.IsSelected = false;
										if (flag2)
										{
											Spawn.SpawnSpawnRange = 0;
										}
										this._Editor.tvwSpawnPoints.Nodes.Add(new SpawnPointNode(Spawn));
										num3++;
										if (num10 == 0)
										{
											SpawnPoint Spawn2 = new SpawnPoint(Guid.NewGuid(), WorldMap.Trammel, (short)num7, (short)num8, (short)(num14 * 2), (short)(num14 * 2));
											Spawn2.SpawnName = string.Format("{0}#{1}", fileName, num3);
											Spawn2.SpawnHomeRange = num13;
											Spawn2.CentreZ = (short)num9;
											Spawn2.SpawnMinDelay = (double)num11;
											Spawn2.SpawnMaxDelay = (double)num12;
											Spawn2.SpawnMaxCount = maxamount;
											for (int index2 = 0; index2 < strArray2.Length; index2++)
											{
												Spawn2.SpawnObjects.Add(new SpawnObject(strArray2[index2], maxamount));
											}
											Spawn2.IsSelected = false;
											if (flag2)
											{
												Spawn2.SpawnSpawnRange = 0;
											}
											this._Editor.tvwSpawnPoints.Nodes.Add(new SpawnPointNode(Spawn2));
											num3++;
										}
									}
								}
								else
								{
									num4++;
								}
							}
						}
						streamReader.Close();
					}
				}
				catch
				{
				}
				processedmaps = 1;
				processedspawners = num3;
				return;
			}
			if (!Directory.Exists(filename))
			{
				return;
			}
			string[] strArray3 = null;
			try
			{
				strArray3 = Directory.GetFiles(filename, "*.map");
			}
			catch
			{
			}
			if (strArray3 != null && strArray3.Length != 0)
			{
				foreach (string filename2 in strArray3)
				{
					this.DoImportMap(filename2, out processedmaps, out processedspawners);
					num += processedmaps;
					num2 += processedspawners;
				}
			}
			string[] strArray4 = null;
			try
			{
				strArray4 = Directory.GetDirectories(filename);
			}
			catch
			{
			}
			if (strArray4 != null && strArray4.Length != 0)
			{
				foreach (string filename3 in strArray4)
				{
					this.DoImportMap(filename3, out processedmaps, out processedspawners);
					num += processedmaps;
					num2 += processedspawners;
				}
			}
			processedmaps = num;
			processedspawners = num2;
		}

		// Token: 0x04000094 RID: 148
		private SpawnEditor _Editor;
	}
}
