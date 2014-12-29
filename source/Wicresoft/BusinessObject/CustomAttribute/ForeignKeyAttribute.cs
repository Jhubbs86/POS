using System;


namespace  Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for ForeignKeyAttribute.
	/// </summary>
	/// 
	[AttributeUsage(AttributeTargets.All, AllowMultiple=true, Inherited = false)]
	public class ForeignKeyAttribute:System.Attribute
	{
		public ForeignKeyAttribute(string tablename,string pkid,string displayname,string mappingname)
		{
			this.tableName = tablename;
			this.pkid = pkid;
			this.displayName = displayname;
			this.mappingName = mappingname;
			this.descText = this.mappingName;
		}

		public ForeignKeyAttribute(string tablename,string pkid,string displayname,string mappingname,string descText)
		{
			this.tableName = tablename;
			this.pkid = pkid;
			this.displayName = displayname;
			this.mappingName = mappingname;
			this.descText = descText;
		}

		private string tableName;
		public string TableName
		{
			get{ return tableName;}
			set{ tableName = value;}
		}
		private string pkid;
		public string PKID
		{
			get{ return pkid; }
			set{ pkid = value; }
		}
		private string displayName;
		public string DisplayName
		{
			get{ return displayName; }
			set{ displayName = value; }
		}

		private string mappingName;
		public string MappingName
		{
			get { return mappingName; }
			set { mappingName = value; }
		}

		/// <summary>
		/// 外键字段的文字描述信息
		/// 将来可能应用于ObjectView
		/// </summary>
		/// <remarks>2006-3-9	TONY</remarks>
		public string DescText
		{
			get { return this.descText; }
			set { this.descText = value; }
		}
		private string descText;
	}
}
