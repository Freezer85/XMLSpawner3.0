using System;
using System.Collections;

namespace SpawnEditor2
{
	// Token: 0x0200001A RID: 26
	public class SpawnPointAreaComparer : IComparer
	{
		// Token: 0x06000208 RID: 520 RVA: 0x00024434 File Offset: 0x00022634
		public int Compare(object A, object B)
		{
			if (A is SpawnPointNode && B is SpawnPointNode)
			{
				return ((SpawnPointNode)A).Spawn.Area - ((SpawnPointNode)B).Spawn.Area;
			}
			return 0;
		}
	}
}
