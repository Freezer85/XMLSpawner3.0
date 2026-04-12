using System;

namespace SpawnEditor2
{
	// Token: 0x0200000D RID: 13
	public class MapLocation
	{
		// Token: 0x06000047 RID: 71 RVA: 0x0000766C File Offset: 0x0000586C
		public MapLocation(int x, int y, int z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00007690 File Offset: 0x00005890
		public MapLocation()
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000769F File Offset: 0x0000589F
		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000076CC File Offset: 0x000058CC
		public static MapLocation Parse(string value)
		{
			int num = value.IndexOf('(');
			int num2 = value.IndexOf(',', num + 1);
			string text = value.Substring(num + 1, num2 - (num + 1)).Trim();
			int num3 = num2;
			int num4 = value.IndexOf(',', num3 + 1);
			string str2 = value.Substring(num3 + 1, num4 - (num3 + 1)).Trim();
			int num5 = num4;
			int num6 = value.IndexOf(')', num5 + 1);
			string str3 = value.Substring(num5 + 1, num6 - (num5 + 1)).Trim();
			return new MapLocation(Convert.ToInt32(text), Convert.ToInt32(str2), Convert.ToInt32(str3));
		}

		// Token: 0x0400009C RID: 156
		public static readonly MapLocation Zero = new MapLocation(0, 0, 0);

		// Token: 0x0400009D RID: 157
		public int Facet = -1;

		// Token: 0x0400009E RID: 158
		public int X;

		// Token: 0x0400009F RID: 159
		public int Y;

		// Token: 0x040000A0 RID: 160
		public int Z;
	}
}
