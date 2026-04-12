using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;

namespace SpawnEditor2
{
	// Token: 0x02000019 RID: 25
	public class SpawnPoint
	{
		// Token: 0x06000198 RID: 408 RVA: 0x000217BC File Offset: 0x0001F9BC
		public void CopyToSpawnArgument(SpawnPoint spawn)
		{
			if (spawn != null)
			{
				spawn.SpawnIsRunning = this.SpawnIsRunning;
				spawn.LoadSpawnObjectsFromString2(this.GetSerializedObjectList2());
				spawn.SpawnProximityRange = this.SpawnProximityRange;
				spawn.SpawnKillReset = this.SpawnKillReset;
				spawn.SpawnProximitySnd = this.SpawnProximitySnd;
				spawn.SpawnSequentialSpawn = this.SpawnSequentialSpawn;
				spawn.SpawnTriggerProbability = this.SpawnTriggerProbability;
				spawn.SpawnStackAmount = this.SpawnStackAmount;
				spawn.Range = this.Range;
				spawn.Index = this.Index;
				spawn.IsSelected = this.IsSelected;
				spawn.XmlFileName = this.XmlFileName;
				spawn.SpawnHomeRange = this.SpawnHomeRange;
				spawn.SpawnHomeRangeIsRelative = this.SpawnHomeRangeIsRelative;
				spawn.SpawnMaxCount = this.SpawnMaxCount;
				spawn.SpawnMinDelay = this.SpawnMinDelay;
				spawn.SpawnMaxDelay = this.SpawnMaxDelay;
				spawn.SpawnTeam = this.SpawnTeam;
				spawn.SpawnIsGroup = this.SpawnIsGroup;
				spawn.Map = this.Map;
				spawn.SpawnDuration = this.SpawnDuration;
				spawn.SpawnDespawn = this.SpawnDespawn;
				spawn.SpawnMinRefract = this.SpawnMinRefract;
				spawn.SpawnMaxRefract = this.SpawnMaxRefract;
				spawn.SpawnTODStart = this.SpawnTODStart;
				spawn.SpawnTODEnd = this.SpawnTODEnd;
				spawn.SpawnAllowGhost = this.SpawnAllowGhost;
				spawn.SpawnSpawnOnTrigger = this.SpawnSpawnOnTrigger;
				spawn.SpawnSmartSpawning = this.SpawnSmartSpawning;
				spawn.SpawnTODMode = this.SpawnTODMode;
				spawn.SpawnSkillTrigger = this.SpawnSkillTrigger;
				spawn.SpawnSpeechTrigger = this.SpawnSpeechTrigger;
				spawn.SpawnProximityMsg = this.SpawnProximityMsg;
				spawn.SpawnMobTriggerName = this.SpawnMobTriggerName;
				spawn.SpawnMobTrigProp = this.SpawnMobTrigProp;
				spawn.SpawnPlayerTrigProp = this.SpawnPlayerTrigProp;
				spawn.SpawnTrigObjectProp = this.SpawnTrigObjectProp;
				spawn.SpawnTriggerOnCarried = this.SpawnTriggerOnCarried;
				spawn.SpawnNoTriggerOnCarried = this.SpawnNoTriggerOnCarried;
				spawn.SpawnInContainer = this.SpawnInContainer;
				spawn.SpawnRegionName = this.SpawnRegionName;
				spawn.SpawnConfigFile = this.SpawnConfigFile;
				spawn.SpawnObjectPropertyItemName = this.SpawnObjectPropertyItemName;
				spawn.SpawnSetPropertyItemName = this.SpawnSetPropertyItemName;
				spawn.SpawnExternalTriggering = this.SpawnExternalTriggering;
				spawn.SpawnWaypoint = this.SpawnWaypoint;
				spawn.SpawnContainerX = this.SpawnContainerX;
				spawn.SpawnContainerY = this.SpawnContainerY;
				spawn.SpawnContainerZ = this.SpawnContainerZ;
				spawn.SpawnNotes = this.SpawnNotes;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00021A28 File Offset: 0x0001FC28
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00021AC4 File Offset: 0x0001FCC4
		public int SpawnSpawnRange
		{
			get
			{
				int width = this.Bounds.Width;
				int height = this.Bounds.Height;
				if (width == height)
				{
					int centreX = (int)this.CentreX;
					int x = this.Bounds.X;
					int num2 = this.Bounds.Width / 2;
					int num3 = x + num2;
					if (centreX == num3)
					{
						int centreY = (int)this.CentreY;
						int y = this.Bounds.Y;
						int num4 = this.Bounds.Height / 2;
						int num5 = y + num4;
						if (centreY == num5)
						{
							return this.Bounds.Width / 2;
						}
					}
				}
				return -1;
			}
			set
			{
				if (value < 0)
				{
					return;
				}
				this.Bounds = new Rectangle((int)this.CentreX - value, (int)this.CentreY - value, value * 2, value * 2);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00021AEC File Offset: 0x0001FCEC
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00021AF4 File Offset: 0x0001FCF4
		public double MinDelay
		{
			get
			{
				return this.SpawnMinDelay;
			}
			set
			{
				this.SpawnMinDelay = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00021AFD File Offset: 0x0001FCFD
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00021B05 File Offset: 0x0001FD05
		public double MaxDelay
		{
			get
			{
				return this.SpawnMaxDelay;
			}
			set
			{
				this.SpawnMaxDelay = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00021B0E File Offset: 0x0001FD0E
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00021B16 File Offset: 0x0001FD16
		public int HomeRange
		{
			get
			{
				return this.SpawnHomeRange;
			}
			set
			{
				this.SpawnHomeRange = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00021B1F File Offset: 0x0001FD1F
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00021B27 File Offset: 0x0001FD27
		public int MaxCount
		{
			get
			{
				return this.SpawnMaxCount;
			}
			set
			{
				this.SpawnMaxCount = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00021B30 File Offset: 0x0001FD30
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00021B38 File Offset: 0x0001FD38
		public int Team
		{
			get
			{
				return this.SpawnTeam;
			}
			set
			{
				this.SpawnTeam = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00021B41 File Offset: 0x0001FD41
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00021B49 File Offset: 0x0001FD49
		public int SpawnRange
		{
			get
			{
				return this.SpawnSpawnRange;
			}
			set
			{
				this.SpawnSpawnRange = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00021B52 File Offset: 0x0001FD52
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00021B5A File Offset: 0x0001FD5A
		public int ProximityRange
		{
			get
			{
				return this.SpawnProximityRange;
			}
			set
			{
				this.SpawnProximityRange = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00021B63 File Offset: 0x0001FD63
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00021B6B File Offset: 0x0001FD6B
		public double Duration
		{
			get
			{
				return this.SpawnDuration;
			}
			set
			{
				this.SpawnDuration = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00021B74 File Offset: 0x0001FD74
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00021B7C File Offset: 0x0001FD7C
		public double Despawn
		{
			get
			{
				return this.SpawnDespawn;
			}
			set
			{
				this.SpawnDespawn = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00021B85 File Offset: 0x0001FD85
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00021B8D File Offset: 0x0001FD8D
		public double MinRefract
		{
			get
			{
				return this.SpawnMinRefract;
			}
			set
			{
				this.SpawnMinRefract = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00021B96 File Offset: 0x0001FD96
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00021B9E File Offset: 0x0001FD9E
		public double MaxRefract
		{
			get
			{
				return this.SpawnMaxRefract;
			}
			set
			{
				this.SpawnMaxRefract = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00021BA7 File Offset: 0x0001FDA7
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00021BAF File Offset: 0x0001FDAF
		public double TODStart
		{
			get
			{
				return this.SpawnTODStart;
			}
			set
			{
				this.SpawnTODStart = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00021BB8 File Offset: 0x0001FDB8
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00021BC0 File Offset: 0x0001FDC0
		public double TODEnd
		{
			get
			{
				return this.SpawnTODEnd;
			}
			set
			{
				this.SpawnTODEnd = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00021BC9 File Offset: 0x0001FDC9
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00021BD1 File Offset: 0x0001FDD1
		public int KillReset
		{
			get
			{
				return this.SpawnKillReset;
			}
			set
			{
				this.SpawnKillReset = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00021BDA File Offset: 0x0001FDDA
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00021BE2 File Offset: 0x0001FDE2
		public int ProximitySnd
		{
			get
			{
				return this.SpawnProximitySnd;
			}
			set
			{
				this.SpawnProximitySnd = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00021BEB File Offset: 0x0001FDEB
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00021BF3 File Offset: 0x0001FDF3
		public bool Group
		{
			get
			{
				return this.SpawnIsGroup;
			}
			set
			{
				this.SpawnIsGroup = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00021BFC File Offset: 0x0001FDFC
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00021C04 File Offset: 0x0001FE04
		public bool Running
		{
			get
			{
				return this.SpawnIsRunning;
			}
			set
			{
				this.SpawnIsRunning = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00021C0D File Offset: 0x0001FE0D
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00021C15 File Offset: 0x0001FE15
		public bool RelativeHome
		{
			get
			{
				return this.SpawnHomeRangeIsRelative;
			}
			set
			{
				this.SpawnHomeRangeIsRelative = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00021C1E File Offset: 0x0001FE1E
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00021C26 File Offset: 0x0001FE26
		public bool InContainer
		{
			get
			{
				return this.SpawnInContainer;
			}
			set
			{
				this.SpawnInContainer = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00021C2F File Offset: 0x0001FE2F
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00021C37 File Offset: 0x0001FE37
		public bool AllowGhost
		{
			get
			{
				return this.SpawnAllowGhost;
			}
			set
			{
				this.SpawnAllowGhost = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00021C40 File Offset: 0x0001FE40
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00021C48 File Offset: 0x0001FE48
		public int TODMode
		{
			get
			{
				return this.SpawnTODMode;
			}
			set
			{
				this.SpawnTODMode = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00021C51 File Offset: 0x0001FE51
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00021C5C File Offset: 0x0001FE5C
		public bool RealTOD
		{
			get
			{
				return this.SpawnTODMode == 0;
			}
			set
			{
				if (value)
				{
					this.SpawnTODMode = 0;
					return;
				}
				this.SpawnTODMode = 1;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00021C70 File Offset: 0x0001FE70
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00021C7B File Offset: 0x0001FE7B
		public bool GameTOD
		{
			get
			{
				return this.SpawnTODMode == 1;
			}
			set
			{
				if (value)
				{
					this.SpawnTODMode = 1;
					return;
				}
				this.SpawnTODMode = 0;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00021C8F File Offset: 0x0001FE8F
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00021C97 File Offset: 0x0001FE97
		public bool SpawnOnTrigger
		{
			get
			{
				return this.SpawnSpawnOnTrigger;
			}
			set
			{
				this.SpawnSpawnOnTrigger = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00021CA0 File Offset: 0x0001FEA0
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00021CAE File Offset: 0x0001FEAE
		public bool SequentialSpawn
		{
			get
			{
				return this.SpawnSequentialSpawn >= 0;
			}
			set
			{
				if (value)
				{
					this.SpawnSequentialSpawn = 0;
					return;
				}
				this.SpawnSequentialSpawn = -1;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00021CC2 File Offset: 0x0001FEC2
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00021CCA File Offset: 0x0001FECA
		public bool SmartSpawning
		{
			get
			{
				return this.SpawnSmartSpawning;
			}
			set
			{
				this.SpawnSmartSpawning = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00021CD3 File Offset: 0x0001FED3
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00021CDB File Offset: 0x0001FEDB
		public string SkillTrigger
		{
			get
			{
				return this.SpawnSkillTrigger;
			}
			set
			{
				this.SpawnSkillTrigger = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00021CE4 File Offset: 0x0001FEE4
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00021CEC File Offset: 0x0001FEEC
		public string SpeechTrigger
		{
			get
			{
				return this.SpawnSpeechTrigger;
			}
			set
			{
				this.SpawnSpeechTrigger = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00021CF5 File Offset: 0x0001FEF5
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00021CFD File Offset: 0x0001FEFD
		public string ProximityMsg
		{
			get
			{
				return this.SpawnProximityMsg;
			}
			set
			{
				this.SpawnProximityMsg = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00021D06 File Offset: 0x0001FF06
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00021D0E File Offset: 0x0001FF0E
		public string PlayerTrigProp
		{
			get
			{
				return this.SpawnPlayerTrigProp;
			}
			set
			{
				this.SpawnPlayerTrigProp = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00021D17 File Offset: 0x0001FF17
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00021D1F File Offset: 0x0001FF1F
		public string TrigObjectProp
		{
			get
			{
				return this.SpawnTrigObjectProp;
			}
			set
			{
				this.SpawnTrigObjectProp = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00021D28 File Offset: 0x0001FF28
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00021D30 File Offset: 0x0001FF30
		public string TriggerOnCarried
		{
			get
			{
				return this.SpawnTriggerOnCarried;
			}
			set
			{
				this.SpawnTriggerOnCarried = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00021D39 File Offset: 0x0001FF39
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00021D41 File Offset: 0x0001FF41
		public string NoTriggerOnCarried
		{
			get
			{
				return this.SpawnNoTriggerOnCarried;
			}
			set
			{
				this.SpawnNoTriggerOnCarried = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00021D4A File Offset: 0x0001FF4A
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00021D52 File Offset: 0x0001FF52
		public int StackAmount
		{
			get
			{
				return this.SpawnStackAmount;
			}
			set
			{
				this.SpawnStackAmount = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00021D5B File Offset: 0x0001FF5B
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00021D63 File Offset: 0x0001FF63
		public double TriggerProbability
		{
			get
			{
				return this.SpawnTriggerProbability;
			}
			set
			{
				this.SpawnTriggerProbability = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00021D6C File Offset: 0x0001FF6C
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00021D74 File Offset: 0x0001FF74
		public bool ExternalTriggering
		{
			get
			{
				return this.SpawnExternalTriggering;
			}
			set
			{
				this.SpawnExternalTriggering = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00021D7D File Offset: 0x0001FF7D
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00021D85 File Offset: 0x0001FF85
		public int ContainerX
		{
			get
			{
				return this.SpawnContainerX;
			}
			set
			{
				this.SpawnContainerX = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00021D8E File Offset: 0x0001FF8E
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00021D96 File Offset: 0x0001FF96
		public int ContainerY
		{
			get
			{
				return this.SpawnContainerY;
			}
			set
			{
				this.SpawnContainerY = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00021D9F File Offset: 0x0001FF9F
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x00021DA7 File Offset: 0x0001FFA7
		public int ContainerZ
		{
			get
			{
				return this.SpawnContainerZ;
			}
			set
			{
				this.SpawnContainerZ = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00021DB0 File Offset: 0x0001FFB0
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00021DB8 File Offset: 0x0001FFB8
		public string RegionName
		{
			get
			{
				return this.SpawnRegionName;
			}
			set
			{
				this.SpawnRegionName = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00021DC1 File Offset: 0x0001FFC1
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00021DC9 File Offset: 0x0001FFC9
		public string WaypointName
		{
			get
			{
				return this.SpawnWaypoint;
			}
			set
			{
				this.SpawnWaypoint = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00021DD2 File Offset: 0x0001FFD2
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00021DDA File Offset: 0x0001FFDA
		public string ConfigFile
		{
			get
			{
				return this.SpawnConfigFile;
			}
			set
			{
				this.SpawnConfigFile = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00021DE3 File Offset: 0x0001FFE3
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00021DEB File Offset: 0x0001FFEB
		public string MobTriggerName
		{
			get
			{
				return this.SpawnMobTriggerName;
			}
			set
			{
				this.SpawnMobTriggerName = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00021DF4 File Offset: 0x0001FFF4
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00021DFC File Offset: 0x0001FFFC
		public string MobTrigProp
		{
			get
			{
				return this.SpawnMobTrigProp;
			}
			set
			{
				this.SpawnMobTrigProp = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00021E05 File Offset: 0x00020005
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00021E0D File Offset: 0x0002000D
		public string TrigObjectName
		{
			get
			{
				return this.SpawnObjectPropertyItemName;
			}
			set
			{
				this.SpawnObjectPropertyItemName = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00021E16 File Offset: 0x00020016
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00021E1E File Offset: 0x0002001E
		public string SetObjectName
		{
			get
			{
				return this.SpawnSetPropertyItemName;
			}
			set
			{
				this.SpawnSetPropertyItemName = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00021E27 File Offset: 0x00020027
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00021E2F File Offset: 0x0002002F
		public Rectangle Bounds
		{
			get
			{
				return this._Bounds;
			}
			set
			{
				this._Bounds = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00021E38 File Offset: 0x00020038
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00021E40 File Offset: 0x00020040
		public int SpawnHomeRange
		{
			get
			{
				return this._SpawnHomeRange;
			}
			set
			{
				this._SpawnHomeRange = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00021E4C File Offset: 0x0002004C
		public int Area
		{
			get
			{
				int width = this.Bounds.Width;
				int height = this.Bounds.Height;
				return width * height;
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00021E78 File Offset: 0x00020078
		public SpawnPoint(Guid unqiueId, WorldMap Map, short MapX, short MapY, short MapWidth, short MapHeight)
		{
			this.UnqiueId = unqiueId;
			this.Map = Map;
			this.Index = -1;
			this.IsSelected = true;
			this.Bounds = new Rectangle((int)(MapX - MapWidth / 2), (int)(MapY - MapHeight / 2), (int)MapWidth, (int)MapHeight);
			this.CentreX = MapX;
			this.CentreY = MapY;
			this.SpawnName = "Spawn Point " + this.Bounds.ToString();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00021F40 File Offset: 0x00020140
		public SpawnPoint(Guid uniqueId, WorldMap Map, Rectangle SpawnBounds)
		{
			this.UnqiueId = uniqueId;
			this.Map = Map;
			this.Index = -1;
			this.IsSelected = true;
			this.Bounds = SpawnBounds;
			int x = this.Bounds.X;
			int num = this.Bounds.Width / 2;
			this.CentreX = (short)(x + num);
			int y = this.Bounds.Y;
			int num2 = this.Bounds.Height / 2;
			this.CentreY = (short)(y + num2);
			this.SpawnName = "Spawn Point " + this.Bounds.ToString();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0002203C File Offset: 0x0002023C
		public SpawnPoint(XmlElement node, WorldMap ForceMap, bool ForceGuid)
		{
			int num = 0;
			Guid guid = Guid.NewGuid();
			if (!ForceGuid)
			{
				string text = SpawnPoint.GetText(node["UniqueId"], "Error");
				if (text != "Error")
				{
					guid = new Guid(text);
				}
			}
			WorldMap worldMap = ForceMap;
			if (ForceMap == WorldMap.Internal)
			{
				worldMap = WorldMap.Trammel;
				try
				{
					worldMap = (WorldMap)Enum.Parse(typeof(WorldMap), SpawnPoint.GetText(node["Map"], "Trammel"));
				}
				catch
				{
				}
			}
			bool flag = false;
			try
			{
				flag = bool.Parse(SpawnPoint.GetText(node["IsHomeRangeRelative"], "false"));
			}
			catch
			{
				num++;
			}
			int x = int.Parse(SpawnPoint.GetText(node["X"], "0"));
			int y = int.Parse(SpawnPoint.GetText(node["Y"], "0"));
			int width = int.Parse(SpawnPoint.GetText(node["Width"], "0"));
			int height = int.Parse(SpawnPoint.GetText(node["Height"], "0"));
			this.UnqiueId = guid;
			this.Map = worldMap;
			this._Bounds = new Rectangle(x, y, width, height);
			this.SpawnName = SpawnPoint.GetText(node["Name"], "Spawner");
			this.CentreX = short.Parse(SpawnPoint.GetText(node["CentreX"], "0"));
			this.CentreY = short.Parse(SpawnPoint.GetText(node["CentreY"], "0"));
			this.CentreZ = short.Parse(SpawnPoint.GetText(node["CentreZ"], "0"));
			this._SpawnHomeRange = int.Parse(SpawnPoint.GetText(node["Range"], "0"));
			this.SpawnMaxCount = int.Parse(SpawnPoint.GetText(node["MaxCount"], "0"));
			bool flag2 = false;
			try
			{
				flag2 = bool.Parse(SpawnPoint.GetText(node["DelayInSec"], "false"));
			}
			catch
			{
				num++;
			}
			if (flag2)
			{
				this.SpawnMinDelay = double.Parse(SpawnPoint.GetText(node["MinDelay"], "0")) / 60.0;
				this.SpawnMaxDelay = double.Parse(SpawnPoint.GetText(node["MaxDelay"], "0")) / 60.0;
			}
			else
			{
				this.SpawnMinDelay = double.Parse(SpawnPoint.GetText(node["MinDelay"], "0"));
				this.SpawnMaxDelay = double.Parse(SpawnPoint.GetText(node["MaxDelay"], "0"));
			}
			this.SpawnTeam = int.Parse(SpawnPoint.GetText(node["Team"], "0"));
			this.SpawnIsGroup = bool.Parse(SpawnPoint.GetText(node["IsGroup"], "false"));
			this.SpawnIsRunning = bool.Parse(SpawnPoint.GetText(node["IsRunning"], "false"));
			this.SpawnHomeRangeIsRelative = flag;
			this.SpawnProximityRange = -1;
			try
			{
				this.SpawnProximityRange = int.Parse(SpawnPoint.GetText(node["ProximityRange"], "-1"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnDuration = double.Parse(SpawnPoint.GetText(node["Duration"], "0"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnDespawn = double.Parse(SpawnPoint.GetText(node["DespawnTime"], "0"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMinRefract = double.Parse(SpawnPoint.GetText(node["MinRefractory"], "0"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMaxRefract = double.Parse(SpawnPoint.GetText(node["MaxRefractory"], "0"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTODStart = double.Parse(SpawnPoint.GetText(node["TODStart"], "0")) / 60.0;
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTODEnd = double.Parse(SpawnPoint.GetText(node["TODEnd"], "0")) / 60.0;
			}
			catch
			{
				num++;
			}
			this.SpawnKillReset = 1;
			try
			{
				this.SpawnKillReset = int.Parse(SpawnPoint.GetText(node["KillReset"], "1"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnProximitySnd = int.Parse(SpawnPoint.GetText(node["ProximityTriggerSound"], "500"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnAllowGhost = bool.Parse(SpawnPoint.GetText(node["AllowGhostTriggering"], "false"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSpawnOnTrigger = bool.Parse(SpawnPoint.GetText(node["SpawnOnTrigger"], "false"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSequentialSpawn = int.Parse(SpawnPoint.GetText(node["SequentialSpawning"], "-1"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSmartSpawning = bool.Parse(SpawnPoint.GetText(node["SmartSpawning"], "false"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTODMode = int.Parse(SpawnPoint.GetText(node["TODMode"], "0"));
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSkillTrigger = SpawnPoint.GetText(node["SkillTrigger"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSpeechTrigger = SpawnPoint.GetText(node["SpeechTrigger"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnProximityMsg = SpawnPoint.GetText(node["ProximityTriggerMessage"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMobTriggerName = SpawnPoint.GetText(node["MobTriggerName"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMobTrigProp = SpawnPoint.GetText(node["MobPropertyName"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnPlayerTrigProp = SpawnPoint.GetText(node["PlayerPropertyName"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTrigObjectProp = SpawnPoint.GetText(node["ObjectPropertyName"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTriggerOnCarried = SpawnPoint.GetText(node["ItemTriggerName"], null);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnNoTriggerOnCarried = SpawnPoint.GetText(node["NoItemTriggerName"], null);
			}
			catch
			{
				num++;
			}
			this.SpawnInContainer = false;
			this.SpawnContainerX = 0;
			this.SpawnContainerY = 0;
			this.SpawnContainerZ = 0;
			try
			{
				this.SpawnInContainer = bool.Parse(SpawnPoint.GetText(node["InContainer"], "false"));
			}
			catch
			{
				num++;
			}
			if (this.SpawnInContainer)
			{
				try
				{
					this.SpawnContainerX = int.Parse(SpawnPoint.GetText(node["ContainerX"], "0"));
				}
				catch
				{
					num++;
				}
				try
				{
					this.SpawnContainerY = int.Parse(SpawnPoint.GetText(node["ContainerY"], "0"));
				}
				catch
				{
					num++;
				}
				try
				{
					this.SpawnContainerZ = int.Parse(SpawnPoint.GetText(node["ContainerZ"], "0"));
				}
				catch
				{
					num++;
				}
			}
			this.SpawnTriggerProbability = 1.0;
			try
			{
				this.SpawnTriggerProbability = double.Parse(SpawnPoint.GetText(node["TriggerProbability"], "1"));
			}
			catch
			{
				num++;
			}
			this.SpawnRegionName = null;
			try
			{
				this.SpawnRegionName = SpawnPoint.GetText(node["RegionName"], null);
			}
			catch
			{
				num++;
			}
			this.SpawnConfigFile = null;
			try
			{
				this.SpawnConfigFile = SpawnPoint.GetText(node["ConfigFile"], null);
			}
			catch
			{
				num++;
			}
			this.SpawnObjectPropertyItemName = null;
			try
			{
				this.SpawnObjectPropertyItemName = SpawnPoint.GetText(node["ObjectPropertyItemName"], null);
			}
			catch
			{
				num++;
			}
			this.SpawnSetPropertyItemName = null;
			try
			{
				this.SpawnSetPropertyItemName = SpawnPoint.GetText(node["SetPropertyItemName"], null);
			}
			catch
			{
				num++;
			}
			this.SpawnStackAmount = 1;
			try
			{
				this.SpawnStackAmount = int.Parse(SpawnPoint.GetText(node["Amount"], "1"));
			}
			catch
			{
				num++;
			}
			this.SpawnExternalTriggering = false;
			try
			{
				this.SpawnExternalTriggering = bool.Parse(SpawnPoint.GetText(node["ExternalTriggering"], "false"));
			}
			catch
			{
				num++;
			}
			this.SpawnWaypoint = null;
			try
			{
				this.SpawnWaypoint = SpawnPoint.GetText(node["Waypoint"], null);
			}
			catch
			{
				num++;
			}
			bool flag3 = true;
			try
			{
				string text2 = SpawnPoint.GetText(node["Objects2"], null);
				if (text2 != null)
				{
					this.LoadSpawnObjectsFromString2(text2);
				}
				else
				{
					flag3 = false;
				}
			}
			catch
			{
				flag3 = false;
			}
			if (!flag3)
			{
				try
				{
					this.LoadSpawnObjectsFromString(SpawnPoint.GetText(node["Objects"], null));
				}
				catch
				{
				}
			}
			try
			{
				this.SpawnNotes = SpawnPoint.GetText(node["Notes"], null);
			}
			catch
			{
			}
			this.IsSelected = false;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00022DAC File Offset: 0x00020FAC
		public SpawnPoint(DataRow SpawnRow)
		{
			int num = 0;
			Guid guid = Guid.NewGuid();
			try
			{
				guid = new Guid((string)SpawnRow["UniqueId"]);
			}
			catch
			{
			}
			WorldMap worldMap = WorldMap.Trammel;
			try
			{
				worldMap = (WorldMap)Enum.Parse(typeof(WorldMap), (string)SpawnRow["Map"], true);
			}
			catch
			{
				num++;
			}
			bool flag = false;
			try
			{
				flag = bool.Parse((string)SpawnRow["IsHomeRangeRelative"]);
			}
			catch
			{
				num++;
			}
			int x = int.Parse((string)SpawnRow["X"]);
			int y = int.Parse((string)SpawnRow["Y"]);
			int width = int.Parse((string)SpawnRow["Width"]);
			int height = int.Parse((string)SpawnRow["Height"]);
			this.UnqiueId = guid;
			this.Map = worldMap;
			this._Bounds = new Rectangle(x, y, width, height);
			this.SpawnName = (string)SpawnRow["Name"];
			this.CentreX = short.Parse((string)SpawnRow["CentreX"]);
			this.CentreY = short.Parse((string)SpawnRow["CentreY"]);
			this.CentreZ = short.Parse((string)SpawnRow["CentreZ"]);
			this._SpawnHomeRange = int.Parse((string)SpawnRow["Range"]);
			this.SpawnMaxCount = int.Parse((string)SpawnRow["MaxCount"]);
			bool flag2 = false;
			try
			{
				flag2 = bool.Parse((string)SpawnRow["DelayInSec"]);
			}
			catch
			{
				num++;
			}
			if (flag2)
			{
				this.SpawnMinDelay = double.Parse((string)SpawnRow["MinDelay"]) / 60.0;
				this.SpawnMaxDelay = double.Parse((string)SpawnRow["MaxDelay"]) / 60.0;
			}
			else
			{
				this.SpawnMinDelay = double.Parse((string)SpawnRow["MinDelay"]);
				this.SpawnMaxDelay = double.Parse((string)SpawnRow["MaxDelay"]);
			}
			this.SpawnTeam = int.Parse((string)SpawnRow["Team"]);
			this.SpawnIsGroup = bool.Parse((string)SpawnRow["IsGroup"]);
			this.SpawnIsRunning = bool.Parse((string)SpawnRow["IsRunning"]);
			this.SpawnHomeRangeIsRelative = flag;
			this.SpawnProximityRange = -1;
			try
			{
				this.SpawnProximityRange = int.Parse((string)SpawnRow["ProximityRange"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnDuration = double.Parse((string)SpawnRow["Duration"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnDespawn = double.Parse((string)SpawnRow["DespawnTime"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMinRefract = double.Parse((string)SpawnRow["MinRefractory"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnMaxRefract = double.Parse((string)SpawnRow["MaxRefractory"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTODStart = double.Parse((string)SpawnRow["TODStart"]) / 60.0;
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnTODEnd = double.Parse((string)SpawnRow["TODEnd"]) / 60.0;
			}
			catch
			{
				num++;
			}
			this.SpawnKillReset = 1;
			try
			{
				this.SpawnKillReset = int.Parse((string)SpawnRow["KillReset"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnProximitySnd = int.Parse((string)SpawnRow["ProximityTriggerSound"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnAllowGhost = bool.Parse((string)SpawnRow["AllowGhostTriggering"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSpawnOnTrigger = bool.Parse((string)SpawnRow["SpawnOnTrigger"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSequentialSpawn = int.Parse((string)SpawnRow["SequentialSpawning"]);
			}
			catch
			{
				num++;
			}
			try
			{
				this.SpawnSmartSpawning = bool.Parse((string)SpawnRow["SmartSpawning"]);
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("TODMode"))
				{
					this.SpawnTODMode = int.Parse((string)SpawnRow["TODMode"]);
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("SkillTrigger"))
				{
					this.SpawnSkillTrigger = (string)SpawnRow["SkillTrigger"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("SpeechTrigger"))
				{
					this.SpawnSpeechTrigger = (string)SpawnRow["SpeechTrigger"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("ProximityTriggerMessage"))
				{
					this.SpawnProximityMsg = (string)SpawnRow["ProximityTriggerMessage"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("MobTriggerName"))
				{
					this.SpawnMobTriggerName = (string)SpawnRow["MobTriggerName"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("MobPropertyName"))
				{
					this.SpawnMobTrigProp = (string)SpawnRow["MobPropertyName"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("PlayerPropertyName"))
				{
					this.SpawnPlayerTrigProp = (string)SpawnRow["PlayerPropertyName"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("ObjectPropertyName"))
				{
					this.SpawnTrigObjectProp = (string)SpawnRow["ObjectPropertyName"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("ItemTriggerName"))
				{
					this.SpawnTriggerOnCarried = (string)SpawnRow["ItemTriggerName"];
				}
			}
			catch
			{
				num++;
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("NoItemTriggerName"))
				{
					this.SpawnNoTriggerOnCarried = (string)SpawnRow["NoItemTriggerName"];
				}
			}
			catch
			{
				num++;
			}
			this.SpawnInContainer = false;
			this.SpawnContainerX = 0;
			this.SpawnContainerY = 0;
			this.SpawnContainerZ = 0;
			try
			{
				if (SpawnRow.Table.Columns.Contains("InContainer"))
				{
					this.SpawnInContainer = bool.Parse((string)SpawnRow["InContainer"]);
				}
			}
			catch
			{
				num++;
			}
			if (this.SpawnInContainer)
			{
				try
				{
					this.SpawnContainerX = int.Parse((string)SpawnRow["ContainerX"]);
				}
				catch
				{
					num++;
				}
				try
				{
					this.SpawnContainerY = int.Parse((string)SpawnRow["ContainerY"]);
				}
				catch
				{
					num++;
				}
				try
				{
					this.SpawnContainerZ = int.Parse((string)SpawnRow["ContainerZ"]);
				}
				catch
				{
					num++;
				}
			}
			this.SpawnTriggerProbability = 1.0;
			try
			{
				if (SpawnRow.Table.Columns.Contains("TriggerProbability"))
				{
					this.SpawnTriggerProbability = double.Parse((string)SpawnRow["TriggerProbability"]);
				}
			}
			catch
			{
				num++;
			}
			this.SpawnRegionName = null;
			try
			{
				if (SpawnRow.Table.Columns.Contains("RegionName"))
				{
					this.SpawnRegionName = (string)SpawnRow["RegionName"];
				}
			}
			catch
			{
				num++;
			}
			this.SpawnConfigFile = null;
			try
			{
				if (SpawnRow.Table.Columns.Contains("ConfigFile"))
				{
					this.SpawnConfigFile = (string)SpawnRow["ConfigFile"];
				}
			}
			catch
			{
				num++;
			}
			this.SpawnObjectPropertyItemName = null;
			try
			{
				if (SpawnRow.Table.Columns.Contains("ObjectPropertyItemName"))
				{
					this.SpawnObjectPropertyItemName = (string)SpawnRow["ObjectPropertyItemName"];
				}
			}
			catch
			{
				num++;
			}
			this.SpawnSetPropertyItemName = null;
			try
			{
				if (SpawnRow.Table.Columns.Contains("SetPropertyItemName"))
				{
					this.SpawnSetPropertyItemName = (string)SpawnRow["SetPropertyItemName"];
				}
			}
			catch
			{
				num++;
			}
			this.SpawnStackAmount = 1;
			try
			{
				if (SpawnRow.Table.Columns.Contains("Amount"))
				{
					this.SpawnStackAmount = int.Parse((string)SpawnRow["Amount"]);
				}
			}
			catch
			{
				num++;
			}
			this.SpawnExternalTriggering = false;
			try
			{
				if (SpawnRow.Table.Columns.Contains("ExternalTriggering"))
				{
					this.SpawnExternalTriggering = bool.Parse((string)SpawnRow["ExternalTriggering"]);
				}
			}
			catch
			{
				num++;
			}
			this.SpawnWaypoint = null;
			try
			{
				if (SpawnRow.Table.Columns.Contains("Waypoint"))
				{
					this.SpawnWaypoint = (string)SpawnRow["Waypoint"];
				}
			}
			catch
			{
				num++;
			}
			bool flag3 = true;
			try
			{
				if (SpawnRow.Table.Columns.Contains("Objects2"))
				{
					this.LoadSpawnObjectsFromString2((string)SpawnRow["Objects2"]);
				}
				else
				{
					flag3 = false;
				}
			}
			catch
			{
				flag3 = false;
			}
			if (!flag3)
			{
				try
				{
					this.LoadSpawnObjectsFromString((string)SpawnRow["Objects"]);
				}
				catch
				{
				}
			}
			try
			{
				if (SpawnRow.Table.Columns.Contains("Notes"))
				{
					this.SpawnNotes = (string)SpawnRow["Notes"];
				}
			}
			catch
			{
			}
			this.IsSelected = false;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00023C1C File Offset: 0x00021E1C
		private static string GetText(XmlElement node, string defaultValue)
		{
			if (node == null)
			{
				return defaultValue;
			}
			return node.InnerText;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00023C2C File Offset: 0x00021E2C
		public bool IsSameArea(short MapX, short MapY, short Range)
		{
			Rectangle rect = new Rectangle((int)(MapX - Range), (int)(MapY - Range), (int)(Range * 2), (int)(Range * 2));
			return this.Bounds.IntersectsWith(rect) || rect.Contains((int)this.CentreX, (int)this.CentreY);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00023C74 File Offset: 0x00021E74
		public bool IsSameArea(short MapX, short MapY)
		{
			int num = 2;
			Rectangle rectangle = new Rectangle((int)MapX - num, (int)MapY - num, num * 2, num * 2);
			return this.Bounds.Contains((int)MapX, (int)MapY) || rectangle.Contains((int)this.CentreX, (int)this.CentreY);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00023CC0 File Offset: 0x00021EC0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.SpawnName);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("==============================");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(this.Bounds.ToString());
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Unique ID: {0}", this.UnqiueId);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Home Range: {0}", this.SpawnHomeRange);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Maximum: {0}", this.SpawnMaxCount);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Delay: {0}m - {1}m", this.SpawnMinDelay, this.SpawnMaxDelay);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Team: {0}", this.SpawnTeam);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Grouped [{0}]", this.SpawnIsGroup ? "True" : "False");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Running [{0}]", this.SpawnIsRunning ? "True" : "False");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Relative Home Range [{0}]", this.SpawnHomeRangeIsRelative ? "True" : "False");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.AppendFormat("Avg. Spawns per 32x32 area [{0:###.####}]", SpawnEditor.ComputeDensity(this) * 1024.0);
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("==============================");
			if (this.SpawnNotes != null && this.SpawnNotes.Length > 0)
			{
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append(this.SpawnNotes);
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append("==============================");
			}
			for (int index = 0; index < this.SpawnObjects.Count; index++)
			{
				SpawnObject spawnObject = this.SpawnObjects[index] as SpawnObject;
				if (spawnObject != null)
				{
					stringBuilder.Append(Environment.NewLine);
					stringBuilder.AppendFormat("{0} [Max:{1}]", spawnObject.TypeName, spawnObject.Count);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00023F44 File Offset: 0x00022144
		public string GetSerializedObjectList()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in this.SpawnObjects)
			{
				SpawnObject spawnObject = (SpawnObject)obj;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(':');
				}
				stringBuilder.AppendFormat("{0}={1}", spawnObject.TypeName, spawnObject.Count);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00023FD4 File Offset: 0x000221D4
		public string GetSerializedObjectList2()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in this.SpawnObjects)
			{
				SpawnObject spawnObject = (SpawnObject)obj;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(":OBJ=");
				}
				stringBuilder.AppendFormat("{0}:MX={1}:SB={2}:RT={3}:TO={4}:KL={5}:RK={6}:CA={7}:DN={8}:DX={9}:SP={10}", new object[]
				{
					spawnObject.TypeName,
					spawnObject.Count,
					spawnObject.SubGroup,
					spawnObject.SequentialResetTime,
					spawnObject.SequentialResetTo,
					spawnObject.KillsNeeded,
					(spawnObject.RestrictKillsToSubgroup) ? 1 : 0,
					(spawnObject.ClearOnAdvance) ? 1 : 0,
					spawnObject.MinDelay,
					spawnObject.MaxDelay,
					spawnObject.SpawnsPerTick
				});
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00024100 File Offset: 0x00022300
		public void LoadSpawnObjectsFromString(string SerializedObjectList)
		{
			this.SpawnObjects.Clear();
			if (SerializedObjectList.Length <= 0)
			{
				return;
			}
			char[] chArray = new char[] { ':' };
			foreach (string str2 in SerializedObjectList.Split(chArray))
			{
				char[] chArray2 = new char[] { '=' };
				string[] strArray = str2.Split(chArray2);
				if (strArray.Length == 2 && strArray[0].Length > 0 && strArray[1].Length > 0)
				{
					int maxamount = 1;
					try
					{
						maxamount = int.Parse(strArray[1]);
					}
					catch
					{
					}
					this.SpawnObjects.Add(new SpawnObject(strArray[0], maxamount));
				}
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000241BC File Offset: 0x000223BC
		public void LoadSpawnObjectsFromString2(string SerializedObjectList)
		{
			this.SpawnObjects.Clear();
			if (SerializedObjectList == null || SerializedObjectList.Length <= 0)
			{
				return;
			}
			foreach (string str in SpawnObject.SplitString(SerializedObjectList, ":OBJ="))
			{
				string[] strArray = SpawnObject.SplitString(str, ":MX=");
				if (strArray.Length == 2 && strArray[0].Length > 0 && strArray[1].Length > 0)
				{
					string parm = SpawnObject.GetParm(str, ":MX=");
					int maxamount = 1;
					try
					{
						maxamount = int.Parse(parm);
					}
					catch
					{
					}
					string parm2 = SpawnObject.GetParm(str, ":SB=");
					int subgroup = 0;
					try
					{
						subgroup = int.Parse(parm2);
					}
					catch
					{
					}
					string parm3 = SpawnObject.GetParm(str, ":RT=");
					double sequentialresettime = 0.0;
					try
					{
						sequentialresettime = double.Parse(parm3);
					}
					catch
					{
					}
					string parm4 = SpawnObject.GetParm(str, ":TO=");
					int sequentialresetto = 0;
					try
					{
						sequentialresetto = int.Parse(parm4);
					}
					catch
					{
					}
					string parm5 = SpawnObject.GetParm(str, ":KL=");
					int killsneeded = 0;
					try
					{
						killsneeded = int.Parse(parm5);
					}
					catch
					{
					}
					string parm6 = SpawnObject.GetParm(str, ":RK=");
					bool restrictkills = false;
					if (parm6 != null)
					{
						try
						{
							restrictkills = int.Parse(parm6) == 1;
						}
						catch
						{
						}
					}
					string parm7 = SpawnObject.GetParm(str, ":CA=");
					bool clearadvance = true;
					if (killsneeded == 0)
					{
						clearadvance = false;
					}
					if (parm7 != null)
					{
						try
						{
							clearadvance = int.Parse(parm7) == 1;
						}
						catch
						{
						}
					}
					string parm8 = SpawnObject.GetParm(str, ":DN=");
					double mindelay = -1.0;
					try
					{
						mindelay = double.Parse(parm8);
					}
					catch
					{
					}
					string parm9 = SpawnObject.GetParm(str, ":DX=");
					double maxdelay = -1.0;
					try
					{
						maxdelay = double.Parse(parm9);
					}
					catch
					{
					}
					string parm10 = SpawnObject.GetParm(str, ":SP=");
					int spawnsper = 1;
					try
					{
						spawnsper = int.Parse(parm10);
					}
					catch
					{
					}
					this.SpawnObjects.Add(new SpawnObject(strArray[0], maxamount, subgroup, sequentialresettime, sequentialresetto, killsneeded, restrictkills, clearadvance, mindelay, maxdelay, spawnsper));
				}
			}
		}

		// Token: 0x0400027C RID: 636
		public bool SpawnIsRunning = true;

		// Token: 0x0400027D RID: 637
		public ArrayList SpawnObjects = new ArrayList();

		// Token: 0x0400027E RID: 638
		public int SpawnProximityRange = -1;

		// Token: 0x0400027F RID: 639
		public int SpawnKillReset = 1;

		// Token: 0x04000280 RID: 640
		public int SpawnProximitySnd = 500;

		// Token: 0x04000281 RID: 641
		public int SpawnSequentialSpawn = -1;

		// Token: 0x04000282 RID: 642
		public double SpawnTriggerProbability = 1.0;

		// Token: 0x04000283 RID: 643
		public int SpawnStackAmount = 1;

		// Token: 0x04000284 RID: 644
		public short CentreX;

		// Token: 0x04000285 RID: 645
		public short CentreY;

		// Token: 0x04000286 RID: 646
		public short CentreZ;

		// Token: 0x04000287 RID: 647
		public short Range;

		// Token: 0x04000288 RID: 648
		public int Index;

		// Token: 0x04000289 RID: 649
		private Rectangle _Bounds;

		// Token: 0x0400028A RID: 650
		public bool IsSelected;

		// Token: 0x0400028B RID: 651
		public string XmlFileName;

		// Token: 0x0400028C RID: 652
		public string SpawnName;

		// Token: 0x0400028D RID: 653
		private int _SpawnHomeRange;

		// Token: 0x0400028E RID: 654
		public bool SpawnHomeRangeIsRelative;

		// Token: 0x0400028F RID: 655
		public int SpawnMaxCount;

		// Token: 0x04000290 RID: 656
		public double SpawnMinDelay;

		// Token: 0x04000291 RID: 657
		public double SpawnMaxDelay;

		// Token: 0x04000292 RID: 658
		public int SpawnTeam;

		// Token: 0x04000293 RID: 659
		public bool SpawnIsGroup;

		// Token: 0x04000294 RID: 660
		public WorldMap Map;

		// Token: 0x04000295 RID: 661
		public Guid UnqiueId;

		// Token: 0x04000296 RID: 662
		public double SpawnDuration;

		// Token: 0x04000297 RID: 663
		public double SpawnDespawn;

		// Token: 0x04000298 RID: 664
		public double SpawnMinRefract;

		// Token: 0x04000299 RID: 665
		public double SpawnMaxRefract;

		// Token: 0x0400029A RID: 666
		public double SpawnTODStart;

		// Token: 0x0400029B RID: 667
		public double SpawnTODEnd;

		// Token: 0x0400029C RID: 668
		public bool SpawnAllowGhost;

		// Token: 0x0400029D RID: 669
		public bool SpawnSpawnOnTrigger;

		// Token: 0x0400029E RID: 670
		public bool SpawnSmartSpawning;

		// Token: 0x0400029F RID: 671
		public int SpawnTODMode;

		// Token: 0x040002A0 RID: 672
		public string SpawnSkillTrigger;

		// Token: 0x040002A1 RID: 673
		public string SpawnSpeechTrigger;

		// Token: 0x040002A2 RID: 674
		public string SpawnProximityMsg;

		// Token: 0x040002A3 RID: 675
		public string SpawnMobTriggerName;

		// Token: 0x040002A4 RID: 676
		public string SpawnMobTrigProp;

		// Token: 0x040002A5 RID: 677
		public string SpawnPlayerTrigProp;

		// Token: 0x040002A6 RID: 678
		public string SpawnTrigObjectProp;

		// Token: 0x040002A7 RID: 679
		public string SpawnTriggerOnCarried;

		// Token: 0x040002A8 RID: 680
		public string SpawnNoTriggerOnCarried;

		// Token: 0x040002A9 RID: 681
		public bool SpawnInContainer;

		// Token: 0x040002AA RID: 682
		public string SpawnRegionName;

		// Token: 0x040002AB RID: 683
		public string SpawnConfigFile;

		// Token: 0x040002AC RID: 684
		public string SpawnObjectPropertyItemName;

		// Token: 0x040002AD RID: 685
		public string SpawnSetPropertyItemName;

		// Token: 0x040002AE RID: 686
		public bool SpawnExternalTriggering;

		// Token: 0x040002AF RID: 687
		public string SpawnWaypoint;

		// Token: 0x040002B0 RID: 688
		public int SpawnContainerX;

		// Token: 0x040002B1 RID: 689
		public int SpawnContainerY;

		// Token: 0x040002B2 RID: 690
		public int SpawnContainerZ;

		// Token: 0x040002B3 RID: 691
		public string SpawnNotes;
	}
}
