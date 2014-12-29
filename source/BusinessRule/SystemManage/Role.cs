using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Role ��ժҪ˵����
	/// </summary>
	public class Role
	{
		/// <summary>
		/// ��ȡ�û����б�
		/// </summary>
		/// <param name="totalCount">��¼����</param>
		/// <param name="pageSize">ҳ��С��һ��ȡ���ļ�¼����</param>
		/// <param name="pageIndex">ҳ�루1��ʼ��</param>
		/// <param name="obType">��������</param>
		/// <param name="subfilter">ɸѡ��������</param>
		/// <returns>�����</returns>
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

        /* �������ƻ�ȡ�û���ID */
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