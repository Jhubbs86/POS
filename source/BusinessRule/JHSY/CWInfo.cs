using System;
using System.Data;
using Wicresoft.BusinessObject;

namespace BusinessRule.JHSY
{
    /// <summary>
    /// 村务信息 
    /// </summary>
    public class CWInfo
    {
        /// <summary>
        /// 获取村务信息列表
        /// </summary>
        /// <param name="totalCount">记录总数</param>
        /// <param name="pageSize">页大小（一次取出的记录数）</param>
        /// <param name="pageIndex">页码（1开始）</param>
        /// <param name="obType">排续类型</param>
        /// <param name="subfilter">筛选条件对象</param>
        /// <returns>结果集</returns>
        public DataTable GetCWInfoList(out int totalCount, int pageSize, int pageIndex,
            Common.OrderByType obType, BusinessFilter subfilter)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessObjectCollection boc = new BusinessObjectCollection("CWInfo");
            boc.SessionInstance = session;
            BusinessFilter filter = new BusinessFilter("CWInfo");
            //filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            if (subfilter != null)
                filter.AddFilter(subfilter, AndOr.AND);
            boc.AddFilter(filter);
            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.DESC) ? true : false);

            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        /// <summary>
        /// 导出村务信息列表
        /// </summary>
        /// <param name="pageSize">页大小（一次取出的记录数）</param>
        /// <param name="pageIndex">页码（1开始）</param>
        /// <param name="subfilter">筛选条件对象</param>
        /// <returns>结果集</returns>
        public DataTable GetCWInfoListForExport(int pageSize, int pageIndex, BusinessFilter subfilter)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessObjectCollection boc = new BusinessObjectCollection("CWInfo");
            boc.SessionInstance = session;
            BusinessFilter filter = new BusinessFilter("CWInfo");
            //filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            if (subfilter != null)
                filter.AddFilter(subfilter, AndOr.AND);
            boc.AddFilter(filter);
            return boc.GetDataTable();
        }
    }
}