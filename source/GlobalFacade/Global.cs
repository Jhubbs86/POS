using System;

using Wicresoft.BusinessObject;

namespace GlobalFacade
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global
	{
		public Global()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}		
	}

	/// <summary>
	/// 用户级别硬编码
	/// </summary>
	public class UserLevel
	{
		public static string GlobalLevel = "Global";
		public static string CityLevel = "City";
		public static string CenterLevel = "Center";
	}

	/// <summary>
	/// 用户岗位硬编码
	/// </summary>
	public class UserType
	{
		/// <summary>
		/// TMK
		/// </summary>
		public static int Type_1 = 1;
		/// <summary>
		/// 市场
		/// </summary>
		public static int Type_2 = 2;
		/// <summary>
		/// 前台
		/// </summary>
		public static int Type_3 = 3;
		/// <summary>
		/// 课程顾问
		/// </summary>
		public static int Type_4 = 4;
		/// <summary>
		/// 财务
		/// </summary>
		public static int Type_5 = 5;
		/// <summary>
		/// Tutor
		/// </summary>
		public static int Type_6 = 6;
		/// <summary>
		/// 外教
		/// </summary>
		public static int Type_7 = 7;
		/// <summary>
		/// 助教
		/// </summary>
		public static int Type_8 = 8;
		/// <summary>
		/// 中心主任
		/// </summary>
		public static int Type_9 = 9;
		/// <summary>
		/// 管理层
		/// </summary>
		public static int Type_10 = 10;
		/// <summary>
		/// 其他
		/// </summary>
		public static int Type_11 = 11;
		/// <summary>
		/// 教学主管
		/// </summary>
		public static int Type_12 = 12;
		/// <summary>
		/// TMK主管
		/// </summary>
		public static int Type_13 = 13;
		/// <summary>
		/// 总部TMK
		/// </summary>
		public static int Type_14 = 14;
		/// <summary>
		/// 特殊合同处理
		/// </summary>
		public static int Type_15 = 15;
		/// <summary>
		/// 客服督导
		/// </summary>
		public static int Type_16 = 16;
		/// <summary>
		/// 查看课表
		/// </summary>
		public static int Type_17 = 17;
        /// <summary>
        /// 城市校长
        /// </summary>
        public static int Type_18 = 18;
	}

    /// <summary>
    /// 用户组硬编码
    /// </summary>
    public class Role 
    {
        /// <summary>
        /// 总部系统管理员
        /// </summary>
        public static int Role_1 = 1;
        /// <summary>
        /// 总部管理层用户
        /// </summary>
        public static int Role_2 = 2;
        /// <summary>
        /// 城市TMK用户
        /// </summary>
        public static int Role_3 = 3;
        /// <summary>
        /// 中心前台用户
        /// </summary>
        public static int Role_4 = 4;
        /// <summary>
        /// 中心课程顾问用户
        /// </summary>
        public static int Role_5 = 5;
        /// <summary>
        /// 中心财务用户
        /// </summary>
        public static int Role_6 = 6;
        /// <summary>
        /// 中心Tutor用户
        /// </summary>
        public static int Role_7 = 7;
        /// <summary>
        /// 中心外教用户
        /// </summary>
        public static int Role_10 = 10;
        /// <summary>
        /// 中心教学助理用户
        /// </summary>
        public static int Role_11 = 11;
        /// <summary>
        /// 城市校长
        /// </summary>
        public static int Role_15 = 15;
        /// <summary>
        /// 城市TMK主管
        /// </summary>
        public static int Role_22 = 22;
        /// <summary>
        /// 中心主任
        /// </summary>
        public static int Role_31 = 31;
        /// <summary>
        /// 总部TMK主管
        /// </summary>
        public static int Role_47 = 47;
        /// <summary>
        /// 跨城市校长
        /// </summary>
        public static int Role_51 = 51;
        /// <summary>
        /// 总部特殊合同处理管理
        /// </summary>
        public static int Role_53 = 53;
        /// <summary>
        /// 跨城市TMK主管
        /// </summary>
        public static int Role_55 = 55;
    }

	public class UIStyle
	{
		public static string ShortMoneyFormatString = "#0";
		public static string ViewMoneyFormatString = "###,0.##";
		public static string MoneyFormatString = "￥{0:###,0.##}";
		public static string N_MoneyFormatString = "{0:###,0.##}";
		public static string DateFormatStringForList = "{0:yyyy-MM-dd}";
		public static string ShortDateTimeFormatStringForList = "{0:yy-MM-dd HH:mm}";
		public static string DateTimeFormatString = "yyyy-MM-dd HH:mm:ss";
		public static string ShortDateTimeFormatString = "yy-MM-dd HH:mm";
		public static string DateFormatString = "yyyy-MM-dd";
		public static string ShortDateFormatString = "yy-MM-dd";
		public static string TimeFormatString = "HH:mm";

        public static string DateTimeFormatStringM = "yyyy-MM-dd HH:mm";
	}


	public class ExcelExportObject
	{
		private int pagecount = 0;
		private int totalcount = 0;
		private int pagenumber = 0;
		private string NameSpaceAndClassName = string.Empty;
		private string methodname = string.Empty;
		private string fileName = "file";
		private System.Collections.Hashtable hashtable;
		private BusinessFilter queryfilter;

		public int PageSize
		{
			set { pagecount = value;}
			get {return pagecount;}
		}

		public int TotalCount
		{
			set {totalcount = value;}
			get {return totalcount;}
		}

		public int PageNumber
		{
			set {pagenumber = value;}
			get {return pagenumber;}
		}

		public string ClassName
		{
			set {NameSpaceAndClassName = value;}
			get {return NameSpaceAndClassName;}
		}

		public string MethodName
		{
			set {methodname = value;}
			get {return methodname;}
		}

		public BusinessFilter QueryFilter
		{
			set {queryfilter = value;}
			get {return queryfilter;}
		}

		public System.Collections.Hashtable Columns
		{
			set {hashtable = value;}
			get {return hashtable;}
		}

		public String FileName
		{
			get { return this.fileName; }
			set { this.fileName = (value == string.Empty)?this.fileName:value; }
		}
	}

	/// <summary>
	/// 提醒功能 Allen CreateTime：2008-06-25
	/// </summary>
	public class UserAlert
	{
		private string topic;
		private string begintime;
		private string endtime;
		private string alerttime;
		private string alertuser;
		private string memo;

		public string Topic
		{
			get{return this.topic;}
			set{this.topic = value;}
		}

		public string BeginTime
		{
			get{return this.begintime;}
			set{this.begintime = value;}
		}

		public string EndTime
		{
			get{return this.endtime;}
			set{this.endtime = value;}
		}

		public string AlertTime
		{
			get{return this.alerttime;}
			set{this.alerttime = value;}
		}

		public string AlertUser
		{
			get{return this.alertuser;}
			set{this.alertuser = value;}
		}

		
		public string Memo
		{
			get{return this.memo;}
			set{this.memo = value;}
		}
	}
}
