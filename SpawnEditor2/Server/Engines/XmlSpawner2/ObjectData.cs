using System;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public class ObjectData
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0002A5F6 File Offset: 0x000287F6
		public ObjectData(int x, int y, int map, string name)
		{
			this.X = x;
			this.Y = y;
			this.Map = map;
			this.Name = name;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0002A61B File Offset: 0x0002881B
		public ObjectData()
		{
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0002A623 File Offset: 0x00028823
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04000366 RID: 870
		public int X;

		// Token: 0x04000367 RID: 871
		public int Y;

		// Token: 0x04000368 RID: 872
		public int Map;

		// Token: 0x04000369 RID: 873
		public string Name;
	}
}
