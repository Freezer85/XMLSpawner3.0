using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	public class GetSpawnerData : TransferMessage
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0002A5A1 File Offset: 0x000287A1
		// (set) Token: 0x06000230 RID: 560 RVA: 0x0002A5A9 File Offset: 0x000287A9
		public int SelectedMap
		{
			get
			{
				return this.m_Map;
			}
			set
			{
				this.m_Map = value;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0002A5B2 File Offset: 0x000287B2
		public GetSpawnerData()
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0002A5BA File Offset: 0x000287BA
		public GetSpawnerData(int map)
		{
			this.m_Map = map;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0002A5C9 File Offset: 0x000287C9
		public GetSpawnerData(int map, int x, int y, int w, int h)
		{
			this.m_Map = map;
			this.X = x;
			this.Y = y;
			this.Width = w;
			this.Height = h;
		}

		// Token: 0x04000352 RID: 850
		private int m_Map;

		// Token: 0x04000353 RID: 851
		public int X;

		// Token: 0x04000354 RID: 852
		public int Y;

		// Token: 0x04000355 RID: 853
		public int Width;

		// Token: 0x04000356 RID: 854
		public int Height;

		// Token: 0x04000357 RID: 855
		public string NameFilter;

		// Token: 0x04000358 RID: 856
		public string EntryFilter;

		// Token: 0x04000359 RID: 857
		public short ContainerFilter;

		// Token: 0x0400035A RID: 858
		public short SequentialFilter;

		// Token: 0x0400035B RID: 859
		public short SmartSpawnFilter;

		// Token: 0x0400035C RID: 860
		public bool NameCase;

		// Token: 0x0400035D RID: 861
		public bool EntryCase;

		// Token: 0x0400035E RID: 862
		public short Modified;

		// Token: 0x0400035F RID: 863
		public short Proximity;

		// Token: 0x04000360 RID: 864
		public short Running;

		// Token: 0x04000361 RID: 865
		public DateTime ModifiedDate;

		// Token: 0x04000362 RID: 866
		public short SpawnTime;

		// Token: 0x04000363 RID: 867
		public double AvgSpawnTime;

		// Token: 0x04000364 RID: 868
		public string ModifiedName;

		// Token: 0x04000365 RID: 869
		public short ModifiedBy;
	}
}
