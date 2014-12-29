using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.BaseData
{
	/// <summary>
	/// District 的摘要说明。
	/// </summary>
	public class District
	{
		/// <summary>
		/// 获取行政区列表
		/// </summary>
		/// <param name="totalCount">记录总数</param>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="obType">排续类型</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetDistrictList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
			BusinessRule.BaseData.Region rule = new Region();

			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("District");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("District");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddCustomerFilter("District.FK_Dictionary IN (" + rule.GetAuthorizedCitiesPKID(GlobalFacade.SystemContext.GetContext().UserID) + ")", AndOr.AND);

			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}
	}
}