﻿using System;
using System.Data;
using Wicresoft.BusinessObject;

namespace BusinessRule.JHSY
{
	/// <summary>
	/// 计生家庭特别扶助统计 
	/// </summary>
	public class CWFamilySpecHelp
	{
		/// <summary>
		/// 获取计生家庭特别扶助统计列表
		/// </summary>
		/// <param name="totalCount">记录总数</param>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="obType">排续类型</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetCWFamilySpecHelpList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("CWFamilySpecHelp");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("CWFamilySpecHelp");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.DESC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}
		
		/// <summary>
		/// 导出计生家庭特别扶助统计列表
		/// </summary>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetCWFamilySpecHelpListForExport(int pageSize, int pageIndex, BusinessFilter subfilter)
		{
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("CWFamilySpecHelp");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("CWFamilySpecHelp");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			return boc.GetDataTable();
		}
	}
}