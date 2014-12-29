using System;
using System.Data;
using System.Collections;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
    /// <summary>
    /// Summary description for User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// ��ȡ�û��б�
        /// </summary>
        /// <param name="totalCount">��¼����</param>
        /// <param name="pageSize">ҳ��С��һ��ȡ���ļ�¼����</param>
        /// <param name="pageIndex">ҳ�루1��ʼ��</param>
        /// <param name="obType">��������</param>
        /// <param name="subfilter">ɸѡ��������</param>
        /// <returns>�����</returns>
        public DataTable GetUserList(out int totalCount, int pageSize, int pageIndex,
            Common.OrderByType obType, BusinessFilter subfilter)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessObjectCollection boc = new BusinessObjectCollection("User");
            boc.SessionInstance = session;
            BusinessFilter filter = new BusinessFilter("User");

            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            if (subfilter != null)
                filter.AddFilter(subfilter, AndOr.AND);

            boc.AddFilter(filter);
            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.DESC) ? true : false);

            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }        
    }
}
