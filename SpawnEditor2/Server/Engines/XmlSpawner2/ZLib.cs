using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Server.Engines.XmlSpawner2
{
	// Token: 0x0200002D RID: 45
	public class ZLib
	{
		// Token: 0x0600025B RID: 603
		[DllImport("zlib")]
		private static extern string zlibVersion();

		// Token: 0x0600025C RID: 604
		[DllImport("zlib")]
		private static extern ZLib.ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

		// Token: 0x0600025D RID: 605
		[DllImport("zlib")]
		private static extern ZLib.ZLibError compress2(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLib.ZLibCompressionLevel level);

		// Token: 0x0600025E RID: 606
		[DllImport("zlib")]
		private static extern ZLib.ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);

		// Token: 0x0600025F RID: 607 RVA: 0x0002A84C File Offset: 0x00028A4C
		public static bool CheckVersion()
		{
			string[] strArray;
			try
			{
				strArray = ZLib.zlibVersion().Split(new char[] { '.' });
			}
			catch (DllNotFoundException)
			{
				return false;
			}
			return strArray[0] == "1";
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0002A898 File Offset: 0x00028A98
		public static byte[] Compress(object source)
		{
			byte[] array;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
				MemoryStream memoryStream = new MemoryStream();
				xmlSerializer.Serialize(memoryStream, source);
				byte[] source2 = memoryStream.ToArray();
				memoryStream.Close();
				int length = source2.Length;
				int destLength = source2.Length + 1;
				byte[] dest = new byte[destLength];
				if (ZLib.compress2(dest, ref destLength, source2, source2.Length, ZLib.ZLibCompressionLevel.Z_BEST_COMPRESSION) != ZLib.ZLibError.Z_OK)
				{
					array = new byte[0];
				}
				else
				{
					byte[] numArray = new byte[destLength + 4];
					Array.Copy(dest, 0, numArray, 4, destLength);
					numArray[0] = (byte)length;
					numArray[1] = (byte)(length >> 8);
					numArray[2] = (byte)(length >> 16);
					numArray[3] = (byte)(length >> 24);
					array = numArray;
				}
			}
			catch (Exception)
			{
				array = new byte[0];
			}
			return array;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0002A950 File Offset: 0x00028B50
		public static object Decompress(byte[] data, Type type)
		{
			object obj;
			try
			{
				int destLen = (int)data[0] | ((int)data[1] << 8) | ((int)data[2] << 16) | ((int)data[3] << 24);
				byte[] source = new byte[data.Length - 4];
				Array.Copy(data, 4, source, 0, data.Length - 4);
				byte[] numArray = new byte[destLen];
				if (ZLib.uncompress(numArray, ref destLen, source, source.Length) != ZLib.ZLibError.Z_OK)
				{
					obj = null;
				}
				else
				{
					MemoryStream memoryStream = new MemoryStream(numArray);
					object obj2 = new XmlSerializer(type).Deserialize(memoryStream);
					memoryStream.Close();
					obj = obj2;
				}
			}
			catch
			{
				obj = null;
			}
			return obj;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0002A9E0 File Offset: 0x00028BE0
		public static byte[] Compress(byte[] data)
		{
			int length = data.Length;
			int length2 = data.Length;
			byte[] dest = new byte[data.Length];
			if (ZLib.compress(dest, ref length2, data, data.Length) != ZLib.ZLibError.Z_OK)
			{
				return null;
			}
			byte[] numArray = new byte[length2 + 4];
			Array.Copy(dest, 0, numArray, 4, length2);
			numArray[0] = (byte)(length & 255);
			numArray[1] = (byte)((length >> 8) & 255);
			numArray[2] = (byte)((length >> 16) & 255);
			numArray[3] = (byte)((length >> 24) & 255);
			return numArray;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0002AA58 File Offset: 0x00028C58
		public static byte[] Decompress(byte[] data)
		{
			int destLen = (int)data[0] | ((int)data[1] << 8) | ((int)data[2] << 16) | ((int)data[3] << 24);
			byte[] source = new byte[data.Length - 4];
			Array.Copy(data, 4, source, 0, data.Length - 4);
			byte[] dest = new byte[destLen];
			if (ZLib.uncompress(dest, ref destLen, source, source.Length) != ZLib.ZLibError.Z_OK)
			{
				return null;
			}
			return dest;
		}

		// Token: 0x02000035 RID: 53
		private enum ZLibError
		{
			// Token: 0x04000386 RID: 902
			Z_VERSION_ERROR = -6,
			// Token: 0x04000387 RID: 903
			Z_BUF_ERROR,
			// Token: 0x04000388 RID: 904
			Z_MEM_ERROR,
			// Token: 0x04000389 RID: 905
			Z_DATA_ERROR,
			// Token: 0x0400038A RID: 906
			Z_STREAM_ERROR,
			// Token: 0x0400038B RID: 907
			Z_ERRNO,
			// Token: 0x0400038C RID: 908
			Z_OK,
			// Token: 0x0400038D RID: 909
			Z_STREAM_END,
			// Token: 0x0400038E RID: 910
			Z_NEED_DICT
		}

		// Token: 0x02000036 RID: 54
		private enum ZLibCompressionLevel
		{
			// Token: 0x04000390 RID: 912
			Z_DEFAULT_COMPRESSION = -1,
			// Token: 0x04000391 RID: 913
			Z_NO_COMPRESSION,
			// Token: 0x04000392 RID: 914
			Z_BEST_SPEED,
			// Token: 0x04000393 RID: 915
			Z_BEST_COMPRESSION = 9
		}
	}
}
