using System;
using System.Collections;

namespace SpawnEditor2
{
	// Token: 0x02000015 RID: 21
	public class SpawnObject
	{
		// Token: 0x06000189 RID: 393 RVA: 0x0002145C File Offset: 0x0001F65C
		public SpawnObject(string name, int maxamount)
		{
			this.TypeName = name;
			this.Count = maxamount;
			this.SubGroup = 0;
			this.SequentialResetTime = 0.0;
			this.SequentialResetTo = 0;
			this.KillsNeeded = 0;
			this.RestrictKillsToSubgroup = false;
			this.ClearOnAdvance = true;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000214DC File Offset: 0x0001F6DC
		public SpawnObject(string name, int maxamount, int subgroup, double sequentialresettime, int sequentialresetto, int killsneeded, bool restrictkills, bool clearadvance, double mindelay, double maxdelay, int spawnsper)
		{
			this.TypeName = name;
			this.Count = maxamount;
			this.SubGroup = subgroup;
			this.SequentialResetTime = sequentialresettime;
			this.SequentialResetTo = sequentialresetto;
			this.KillsNeeded = killsneeded;
			this.RestrictKillsToSubgroup = restrictkills;
			this.ClearOnAdvance = clearadvance;
			this.MinDelay = mindelay;
			this.MaxDelay = maxdelay;
			this.SpawnsPerTick = spawnsper;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00021570 File Offset: 0x0001F770
		internal static string GetParm(string str, string separator)
		{
			string[] strArray = SpawnObject.SplitString(str, separator);
			if (strArray.Length > 1)
			{
				string[] strArray2 = strArray[1].Split(new char[] { ':' });
				if (strArray2.Length != 0)
				{
					return strArray2[0];
				}
			}
			return null;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000215A8 File Offset: 0x0001F7A8
		public override string ToString()
		{
			return this.TypeName + "=" + this.Count.ToString();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000215C8 File Offset: 0x0001F7C8
		public static string[] SplitString(string str, string separator)
		{
			if (str == null || separator == null)
			{
				return null;
			}
			int startIndex = 0;
			int length = 0;
			ArrayList arrayList = new ArrayList();
			while (length >= 0)
			{
				length = str.IndexOf(separator);
				if (length < 0)
				{
					arrayList.Add(str);
					break;
				}
				string str2 = str.Substring(startIndex, length);
				arrayList.Add(str2);
				str = str.Substring(length + separator.Length, str.Length - (length + separator.Length));
			}
			string[] strArray = new string[arrayList.Count];
			for (int index = 0; index < arrayList.Count; index++)
			{
				strArray[index] = (string)arrayList[index];
			}
			return strArray;
		}

		// Token: 0x0400026E RID: 622
		public bool RestrictKillsToSubgroup;

		// Token: 0x0400026F RID: 623
		public bool ClearOnAdvance = true;

		// Token: 0x04000270 RID: 624
		public double MinDelay = -1.0;

		// Token: 0x04000271 RID: 625
		public double MaxDelay = -1.0;

		// Token: 0x04000272 RID: 626
		public int SpawnsPerTick = 1;

		// Token: 0x04000273 RID: 627
		public string TypeName;

		// Token: 0x04000274 RID: 628
		public int Count;

		// Token: 0x04000275 RID: 629
		public int SubGroup;

		// Token: 0x04000276 RID: 630
		public double SequentialResetTime;

		// Token: 0x04000277 RID: 631
		public int SequentialResetTo;

		// Token: 0x04000278 RID: 632
		public int KillsNeeded;
	}
}
