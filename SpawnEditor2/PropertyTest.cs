using System;
using System.Collections;
using System.Reflection;

namespace SpawnEditor2
{
	// Token: 0x02000010 RID: 16
	public class PropertyTest
	{
		// Token: 0x06000051 RID: 81 RVA: 0x0000783D File Offset: 0x00005A3D
		private static bool IsParsable(Type t)
		{
			return t == PropertyTest.typeofTimeSpan;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000784A File Offset: 0x00005A4A
		private static object Parse(object o, Type t, string value)
		{
			MethodBase method = t.GetMethod("Parse", PropertyTest.m_ParseTypes);
			PropertyTest.m_ParseParams[0] = value;
			return method.Invoke(o, PropertyTest.m_ParseParams);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000786F File Offset: 0x00005A6F
		public static bool IsNumeric(Type t)
		{
			return Array.IndexOf(PropertyTest.m_NumericTypes, t) >= 0;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007882 File Offset: 0x00005A82
		private static bool IsType(Type t)
		{
			return t == PropertyTest.typeofType;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000788F File Offset: 0x00005A8F
		private static bool IsChar(Type t)
		{
			return t == PropertyTest.typeofChar;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000789C File Offset: 0x00005A9C
		private static bool IsString(Type t)
		{
			return t == PropertyTest.typeofString;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000078A9 File Offset: 0x00005AA9
		private static bool IsEnum(Type t)
		{
			return t.IsEnum;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000078B4 File Offset: 0x00005AB4
		private static string InternalGetValue(object o, PropertyInfo p, int index)
		{
			Type propertyType = p.PropertyType;
			object obj = null;
			if (propertyType.IsArray)
			{
				try
				{
					object obj2 = p.GetValue(o, null);
					int lowerBound = ((Array)obj2).GetLowerBound(0);
					int upperBound = ((Array)obj2).GetUpperBound(0);
					if (index <= lowerBound && index <= upperBound)
					{
						obj = ((Array)obj2).GetValue(index);
					}
					goto IL_005B;
				}
				catch
				{
					goto IL_005B;
				}
			}
			obj = p.GetValue(o, null);
			IL_005B:
			string str = ((obj != null) ? ((!PropertyTest.IsNumeric(propertyType)) ? ((!PropertyTest.IsChar(propertyType)) ? ((!PropertyTest.IsString(propertyType)) ? obj.ToString() : string.Format("\"{0}\"", obj)) : string.Format("'{0}' ({1} [0x{1:X}])", obj, (int)obj)) : string.Format("{0} (0x{0:X})", obj)) : "(-null-)");
			return string.Format("{0} = {1}", p.Name, str);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00007998 File Offset: 0x00005B98
		public static string GetPropertyValue(object o, string name, out Type ptype)
		{
			ptype = null;
			if (o == null || name == null)
			{
				return null;
			}
			Type type = o.GetType();
			object o2 = null;
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			string[] strArray = PropertyTest.ParseString(name, 2, ".");
			string str = strArray[0];
			PropertyTest.ParseString(str, 4, ",");
			string[] strArray2 = strArray[0].Split(new char[] { '[' });
			int index = 0;
			if (strArray2.Length > 1)
			{
				str = strArray2[0];
				string[] strArray3 = strArray2[1].Split(new char[] { ']' });
				if (strArray3.Length != 0)
				{
					try
					{
						index = int.Parse(strArray3[0]);
					}
					catch
					{
					}
				}
			}
			if (strArray.Length == 2)
			{
				PropertyInfo propertyInfo = PropertyTest.LookupPropertyInfo(type, str);
				if (propertyInfo != null)
				{
					if (!propertyInfo.CanWrite)
					{
						return "Property is read only.";
					}
					ptype = propertyInfo.PropertyType;
					if (ptype.IsArray)
					{
						try
						{
							object obj = propertyInfo.GetValue(o, null);
							int lowerBound = ((Array)obj).GetLowerBound(0);
							int upperBound = ((Array)obj).GetUpperBound(0);
							if (index <= lowerBound && index <= upperBound)
							{
								o2 = ((Array)obj).GetValue(index);
							}
							goto IL_011E;
						}
						catch
						{
							goto IL_011E;
						}
					}
					o2 = propertyInfo.GetValue(o, null);
					IL_011E:
					return PropertyTest.GetPropertyValue(o2, strArray[1], out ptype);
				}
				else
				{
					PropertyInfo[] array = properties;
					int i = 0;
					while (i < array.Length)
					{
						PropertyInfo propertyInfo2 = array[i];
						if (PropertyTest.Insensitive.Equals(propertyInfo2.Name, str))
						{
							if (!propertyInfo2.CanWrite)
							{
								return "Property is read only.";
							}
							ptype = propertyInfo2.PropertyType;
							if (ptype.IsArray)
							{
								try
								{
									object obj2 = propertyInfo2.GetValue(o, null);
									int lowerBound2 = ((Array)obj2).GetLowerBound(0);
									int upperBound2 = ((Array)obj2).GetUpperBound(0);
									if (index <= lowerBound2 && index <= upperBound2)
									{
										o2 = ((Array)obj2).GetValue(index);
									}
									goto IL_01BF;
								}
								catch
								{
									goto IL_01BF;
								}
							}
							o2 = propertyInfo2.GetValue(o, null);
							IL_01BF:
							return PropertyTest.GetPropertyValue(o2, strArray[1], out ptype);
						}
						else
						{
							i++;
						}
					}
				}
			}
			else
			{
				PropertyInfo p = PropertyTest.LookupPropertyInfo(type, str);
				if (p != null)
				{
					if (!p.CanRead)
					{
						return "Property is write only.";
					}
					ptype = p.PropertyType;
					return PropertyTest.InternalGetValue(o, p, index);
				}
				else
				{
					PropertyInfo[] array = properties;
					int i = 0;
					while (i < array.Length)
					{
						PropertyInfo p2 = array[i];
						if (PropertyTest.Insensitive.Equals(p2.Name, str))
						{
							if (!p2.CanRead)
							{
								return "Property is write only.";
							}
							ptype = p2.PropertyType;
							return PropertyTest.InternalGetValue(o, p2, index);
						}
						else
						{
							i++;
						}
					}
				}
			}
			return "Property not found.";
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00007C3C File Offset: 0x00005E3C
		public static PropertyInfo LookupPropertyInfo(Type type, string propname)
		{
			if (type == null || propname == null)
			{
				return null;
			}
			PropertyInfo propertyInfo = null;
			PropertyTest.TypeInfo typeInfo = null;
			foreach (object obj in PropertyTest.PropertyInfoList)
			{
				PropertyTest.TypeInfo typeInfo2 = (PropertyTest.TypeInfo)obj;
				if (typeInfo2.t == type)
				{
					typeInfo = typeInfo2;
					foreach (object obj2 in typeInfo2.plist)
					{
						PropertyInfo propertyInfo2 = (PropertyInfo)obj2;
						if (PropertyTest.Insensitive.Equals(propertyInfo2.Name, propname))
						{
							propertyInfo = propertyInfo2;
						}
					}
				}
			}
			if (propertyInfo != null)
			{
				return propertyInfo;
			}
			foreach (PropertyInfo propertyInfo3 in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
			{
				if (PropertyTest.Insensitive.Equals(propertyInfo3.Name, propname))
				{
					if (typeInfo == null)
					{
						typeInfo = new PropertyTest.TypeInfo();
						typeInfo.t = type;
						PropertyTest.PropertyInfoList.Add(typeInfo);
					}
					typeInfo.plist.Add(propertyInfo3);
					return propertyInfo3;
				}
			}
			return null;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007D7C File Offset: 0x00005F7C
		public static string[] ParseString(string str, int nitems, string delimstr)
		{
			if (str == null || delimstr == null)
			{
				return null;
			}
			char[] separator = delimstr.ToCharArray();
			str = str.Trim();
			return str.Split(separator, nitems);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00007DA8 File Offset: 0x00005FA8
		public static string[] ParseToMatchingParen(string str, char opendelim, char closedelim)
		{
			int num = 1;
			int num2 = 0;
			int length = str.Length;
			for (int index = 0; index < str.Length; index++)
			{
				if (str[index] == opendelim)
				{
					num++;
				}
				if (str[index] == closedelim)
				{
					num2++;
				}
				if (num == num2)
				{
					length = index;
					break;
				}
			}
			string[] strArray = new string[]
			{
				str.Substring(0, length),
				""
			};
			if (length + 1 < str.Length)
			{
				strArray[1] = str.Substring(length + 1, str.Length - length - 1);
			}
			return strArray;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007E38 File Offset: 0x00006038
		public static string ParseForKeywords(object o, string valstr, bool literal, out Type ptype)
		{
			ptype = null;
			if (valstr == null || valstr.Length <= 0)
			{
				return null;
			}
			string str = valstr.Trim();
			string[] strArray = PropertyTest.ParseString(str, 2, "[");
			string str2 = null;
			if (strArray.Length > 1)
			{
				str2 = PropertyTest.ParseToMatchingParen(strArray[1], '[', ']')[0];
			}
			string[] strArray2 = strArray[0].Trim().Split(new char[] { ',' });
			if (str2 != null && str2.Length > 0 && strArray2 != null && strArray2.Length != 0)
			{
				strArray2[strArray2.Length - 1] = str2;
			}
			string name = strArray2[0].Trim();
			char ch = str[0];
			if (ch == '.' || ch == '-' || ch == '+' || (ch >= '0' && ch <= '9'))
			{
				ptype = ((str.IndexOf(".") < 0) ? typeof(int) : typeof(double));
				return str;
			}
			if (ch == '"' || ch == '(')
			{
				ptype = typeof(string);
				return str;
			}
			if (ch == '#')
			{
				ptype = typeof(string);
				return str.Substring(1);
			}
			if (str.ToLower() == "true" || str.ToLower() == "false")
			{
				ptype = typeof(bool);
				return str;
			}
			if (!literal)
			{
				return PropertyTest.ParseGetValue(PropertyTest.GetPropertyValue(o, name, out ptype), ptype);
			}
			ptype = typeof(string);
			return str;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007F98 File Offset: 0x00006198
		public static string ParseGetValue(string str, Type ptype)
		{
			if (str == null)
			{
				return null;
			}
			string[] strArray = str.Split("=".ToCharArray(), 2);
			if (strArray.Length <= 1)
			{
				return null;
			}
			if (PropertyTest.IsNumeric(ptype))
			{
				return strArray[1].Trim().Split(" ".ToCharArray(), 2)[0];
			}
			return strArray[1].Trim();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007FF0 File Offset: 0x000061F0
		public static bool CheckPropertyString(object o, string testString, out string status_str)
		{
			status_str = null;
			if (o == null)
			{
				return false;
			}
			if (testString == null || testString.Length < 1)
			{
				status_str = "Null property test string";
				return false;
			}
			string[] strArray = PropertyTest.ParseString(testString, 2, "&|");
			if (strArray.Length < 2)
			{
				return PropertyTest.CheckSingleProperty(o, testString, out status_str);
			}
			bool flag = PropertyTest.CheckSingleProperty(o, strArray[0], out status_str);
			bool flag2 = PropertyTest.CheckPropertyString(o, strArray[1], out status_str);
			int num = testString.IndexOf("&");
			int num2 = testString.IndexOf("|");
			if ((num > 0 && num2 <= 0) || (num > 0 && num < num2))
			{
				return flag && flag2;
			}
			return ((num2 > 0 && num <= 0) || (num2 > 0 && num2 < num)) && (flag || flag2);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000809C File Offset: 0x0000629C
		public static bool CheckSingleProperty(object o, string testString, out string status_str)
		{
			status_str = null;
			if (o == null)
			{
				return false;
			}
			string[] strArray = PropertyTest.ParseString(testString, 2, "=><!");
			if (strArray.Length < 2)
			{
				status_str = "invalid property string : " + testString;
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (testString.IndexOf("=") > 0)
			{
				flag = true;
			}
			else if (testString.IndexOf("!") > 0)
			{
				flag2 = true;
			}
			else if (testString.IndexOf(">") > 0)
			{
				flag3 = true;
			}
			else if (testString.IndexOf("<") > 0)
			{
				flag4 = true;
			}
			if (!flag && !flag3 && !flag4 && !flag2)
			{
				return false;
			}
			Type ptype;
			string s = PropertyTest.ParseForKeywords(o, strArray[0].Trim(), false, out ptype);
			if (ptype == null)
			{
				status_str = strArray[0] + " : " + s;
				return false;
			}
			Type ptype2;
			string s2 = PropertyTest.ParseForKeywords(o, strArray[1].Trim(), false, out ptype2);
			if (ptype2 == null)
			{
				status_str = strArray[1] + " : " + s2;
				return false;
			}
			int fromBase = 10;
			int fromBase2 = 10;
			if (PropertyTest.IsNumeric(ptype) && s.StartsWith("0x"))
			{
				fromBase = 16;
			}
			if (PropertyTest.IsNumeric(ptype2) && s2.StartsWith("0x"))
			{
				fromBase2 = 16;
			}
			if (ptype2 == typeof(TimeSpan) || ptype == typeof(TimeSpan))
			{
				if (flag)
				{
					try
					{
						if (TimeSpan.Parse(s) == TimeSpan.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid timespan comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (TimeSpan.Parse(s) != TimeSpan.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid timespan comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (TimeSpan.Parse(s) > TimeSpan.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid timespan comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (TimeSpan.Parse(s) < TimeSpan.Parse(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid timespan comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype2 == typeof(DateTime) || ptype == typeof(DateTime))
			{
				if (flag)
				{
					try
					{
						if (DateTime.Parse(s) == DateTime.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid DateTime comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (DateTime.Parse(s) != DateTime.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid DateTime comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (DateTime.Parse(s) > DateTime.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid DateTime comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (DateTime.Parse(s) < DateTime.Parse(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid DateTime comparison : {0}" + testString;
					return false;
				}
			}
			if (PropertyTest.IsNumeric(ptype2) && PropertyTest.IsNumeric(ptype))
			{
				if (flag)
				{
					try
					{
						if (Convert.ToInt64(s, fromBase) == Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (Convert.ToInt64(s, fromBase) != Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (Convert.ToInt64(s, fromBase) > Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (Convert.ToInt64(s, fromBase) < Convert.ToInt64(s2, fromBase2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid int comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype2 == typeof(double) && PropertyTest.IsNumeric(ptype))
			{
				if (flag)
				{
					try
					{
						if ((double)Convert.ToInt64(s, fromBase) == double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if ((double)Convert.ToInt64(s, fromBase) != double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if ((double)Convert.ToInt64(s, fromBase) > double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if ((double)Convert.ToInt64(s, fromBase) < double.Parse(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid int comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype == typeof(double) && PropertyTest.IsNumeric(ptype2))
			{
				if (flag)
				{
					try
					{
						if (double.Parse(s) == (double)Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (double.Parse(s) != (double)Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (double.Parse(s) > (double)Convert.ToInt64(s2, fromBase2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (double.Parse(s) < (double)Convert.ToInt64(s2, fromBase2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid int comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype == typeof(double) && ptype2 == typeof(double))
			{
				if (flag)
				{
					try
					{
						if (double.Parse(s) == double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (double.Parse(s) != double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (double.Parse(s) > double.Parse(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid int comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (double.Parse(s) < double.Parse(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid int comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype2 == typeof(bool) && ptype == typeof(bool))
			{
				try
				{
					if (Convert.ToBoolean(s) == Convert.ToBoolean(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid bool comparison : {0}" + testString;
					return false;
				}
			}
			if (ptype2 == typeof(double) || ptype2 == typeof(double))
			{
				if (flag)
				{
					try
					{
						if (Convert.ToDouble(s) == Convert.ToDouble(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid double comparison : {0}" + testString;
						return false;
					}
				}
				if (flag2)
				{
					try
					{
						if (Convert.ToDouble(s) != Convert.ToDouble(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid double comparison : {0}" + testString;
						return false;
					}
				}
				if (flag3)
				{
					try
					{
						if (Convert.ToDouble(s) > Convert.ToDouble(s2))
						{
							return true;
						}
						return false;
					}
					catch
					{
						status_str = "invalid double comparison : {0}" + testString;
						return false;
					}
				}
				if (!flag4)
				{
					return false;
				}
				try
				{
					if (Convert.ToDouble(s) < Convert.ToDouble(s2))
					{
						return true;
					}
					return false;
				}
				catch
				{
					status_str = "invalid double comparison : {0}" + testString;
					return false;
				}
			}
			if (flag)
			{
				if (s == s2)
				{
					return true;
				}
			}
			else if (flag2 && s != s2)
			{
				return true;
			}
			return false;
		}

		// Token: 0x040000D9 RID: 217
		public static ArrayList PropertyInfoList = new ArrayList();

		// Token: 0x040000DA RID: 218
		private static Type typeofTimeSpan = typeof(TimeSpan);

		// Token: 0x040000DB RID: 219
		private static Type[] m_ParseTypes = new Type[] { typeof(string) };

		// Token: 0x040000DC RID: 220
		private static object[] m_ParseParams = new object[1];

		// Token: 0x040000DD RID: 221
		private static Type[] m_NumericTypes = new Type[]
		{
			typeof(byte),
			typeof(sbyte),
			typeof(short),
			typeof(ushort),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong)
		};

		// Token: 0x040000DE RID: 222
		private static Type typeofType = typeof(Type);

		// Token: 0x040000DF RID: 223
		private static Type typeofChar = typeof(char);

		// Token: 0x040000E0 RID: 224
		private static Type typeofString = typeof(string);

		// Token: 0x0200002E RID: 46
		public class TypeInfo
		{
			// Token: 0x04000378 RID: 888
			public ArrayList plist = new ArrayList();

			// Token: 0x04000379 RID: 889
			public Type t;
		}

		// Token: 0x0200002F RID: 47
		public class Insensitive
		{
			// Token: 0x1700005D RID: 93
			// (get) Token: 0x06000266 RID: 614 RVA: 0x0002AAC9 File Offset: 0x00028CC9
			public static IComparer Comparer
			{
				get
				{
					return PropertyTest.Insensitive.m_Comparer;
				}
			}

			// Token: 0x06000267 RID: 615 RVA: 0x0002AAD0 File Offset: 0x00028CD0
			private Insensitive()
			{
			}

			// Token: 0x06000268 RID: 616 RVA: 0x0002AAD8 File Offset: 0x00028CD8
			public static int Compare(string a, string b)
			{
				return PropertyTest.Insensitive.m_Comparer.Compare(a, b);
			}

			// Token: 0x06000269 RID: 617 RVA: 0x0002AAE6 File Offset: 0x00028CE6
			public static bool Equals(string a, string b)
			{
				return (a == null && b == null) || (a != null && b != null && a.Length == b.Length && PropertyTest.Insensitive.m_Comparer.Compare(a, b) == 0);
			}

			// Token: 0x0600026A RID: 618 RVA: 0x0002AB15 File Offset: 0x00028D15
			public static bool StartsWith(string a, string b)
			{
				return a != null && b != null && a.Length >= b.Length && PropertyTest.Insensitive.m_Comparer.Compare(a.Substring(0, b.Length), b) == 0;
			}

			// Token: 0x0600026B RID: 619 RVA: 0x0002AB48 File Offset: 0x00028D48
			public static bool EndsWith(string a, string b)
			{
				return a != null && b != null && a.Length >= b.Length && PropertyTest.Insensitive.m_Comparer.Compare(a.Substring(a.Length - b.Length), b) == 0;
			}

			// Token: 0x0600026C RID: 620 RVA: 0x0002AB81 File Offset: 0x00028D81
			public static bool Contains(string a, string b)
			{
				if (a == null || b == null || a.Length < b.Length)
				{
					return false;
				}
				a = a.ToLower();
				b = b.ToLower();
				return a.IndexOf(b) >= 0;
			}

			// Token: 0x0400037A RID: 890
			private static IComparer m_Comparer = CaseInsensitiveComparer.Default;
		}
	}
}
