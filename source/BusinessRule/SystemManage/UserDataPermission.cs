using System;
using System.Data;
using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
    /// <summary>
    /// UserDataPermission ��ժҪ˵����
    /// </summary>
    public class UserDataPermission
    {
        /// <summary>
        /// ��ȡ�û�Ȩ���б�
        /// </summary>
        /// <param name="totalCount">��¼����</param>
        /// <param name="pageSize">ҳ��С��һ��ȡ���ļ�¼����</param>
        /// <param name="pageIndex">ҳ�루1��ʼ��</param>
        /// <param name="obType">��������</param>
        /// <param name="subfilter">ɸѡ��������</param>
        /// <returns>�����</returns>
        public DataTable GetUserDataPermissionList(out int totalCount, int pageSize, int pageIndex,
            Common.OrderByType obType, BusinessFilter subfilter)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessObjectCollection boc = new BusinessObjectCollection("UserDataPermission");
            boc.SessionInstance = session;
            BusinessFilter filter = new BusinessFilter("UserDataPermission");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            if (subfilter != null)
                filter.AddFilter(subfilter, AndOr.AND);
            boc.AddFilter(filter);
            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);

            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }
    }
}
