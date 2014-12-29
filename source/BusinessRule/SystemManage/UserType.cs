using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// UserType 的摘要说明。
	/// </summary>
	public class UserType
	{
		public static string Teacher = "外教";
		public static string CC = "课程顾问";
		public static string Reception = "前台";
		public static string Tutor = "Tutor";
		public static string CDTutor = "教学主管";
		public static string TMK = "TMK";
		public static string ChargeTMK = "TMK主管";
		public static string GlobalTMK = "总部TMK";
		public static string CD = "中心主任";
		public static string EduAssistant = "助教";
        public static string CityPrincipal = "城市校长";

		/// <summary>
		/// 获取岗位列表
		/// </summary>
		/// <param name="totalCount">记录总数</param>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="obType">排续类型</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetUserTypeList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("UserType");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("UserType");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}
	}
}