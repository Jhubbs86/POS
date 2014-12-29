using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// OperationLog 的摘要说明。
	/// </summary>
	public class OperationLog
	{
		/// <summary>
		/// 获取操作日志列表
		/// </summary>
		/// <param name="totalCount">记录总数</param>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="obType">排续类型</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetOperationLogList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("OperationLog");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("OperationLog");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}


		/// <summary>
		/// 写操作日志
		/// </summary>
		/// <param name="module">功能模块</param>
		/// <param name="description">操作描述</param>
		public void WriteOperationLog(string module, string description)
		{
			BusinessMapping.OperationLog bo = new BusinessMapping.OperationLog();
			bo.SessionInstance = new Wicresoft.Session.Session();

			bo.Module.Value = module;
			bo.Description.Value = description;
			bo.CreateUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
			bo.CreateTime.Value = DateTime.Now;
			bo.Insert();
		}
	}
}