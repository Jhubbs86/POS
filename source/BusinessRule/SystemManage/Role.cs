using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Role 的摘要说明。
	/// </summary>
	public class Role
	{
		/// <summary>
		/// 获取用户组列表
		/// </summary>
		/// <param name="totalCount">记录总数</param>
		/// <param name="pageSize">页大小（一次取出的记录数）</param>
		/// <param name="pageIndex">页码（1开始）</param>
		/// <param name="obType">排续类型</param>
		/// <param name="subfilter">筛选条件对象</param>
		/// <returns>结果集</returns>
		public DataTable GetRoleList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("Role");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("Role");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);

            filter.AddFilter(filter, AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.DESC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}

        /* 根据名称获取用户组ID */
        public int GetRoleID(string rolename)
        {
            int roleid = -1;

            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessMapping.Role bo = new BusinessMapping.Role();
            bo.SessionInstance = session;

            BusinessFilter filter = new BusinessFilter("Role");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("RoleName", rolename, Operation.Equal, FilterType.StringType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                roleid = bo.PKID.Value;
            }

            return roleid;
        }

        public string GetRoleName(string roleID)
        {
            string rolename = string.Empty;

            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessMapping.Role bo = new BusinessMapping.Role();
            bo.SessionInstance = session;

            BusinessFilter filter = new BusinessFilter("Role");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("PKID", roleID, Operation.Equal, FilterType.StringType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                rolename = bo.RoleName.Value;
            }

            return rolename;
        }
	}
}