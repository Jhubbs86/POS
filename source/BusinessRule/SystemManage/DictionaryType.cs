using System;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Summary description for DictionaryType.
	/// </summary>
	public enum DictionaryType
	{
		Region = 1,
		Unknown = int.MinValue
	}

	public class DictionaryTypeConvertor
	{
		private DictionaryTypeConvertor()
		{}

		public static DictionaryType Convert(string typeName)
		{
			switch(typeName)
			{
				case "Region":
					return DictionaryType.Region;
				default:
					return DictionaryType.Unknown;
			}
		}
	}

	public class Level
	{
		public static string Top = "0";
		public static string City = "1";
		public static string Center = "2";
	}
}
