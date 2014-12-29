using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.BaseData
{
	/// <summary>
	/// District ��ժҪ˵����
	/// </summary>
	public class District
	{
		/// <summary>
		/// ��ȡ�������б�
		/// </summary>
		/// <param name="totalCount">��¼����</param>
		/// <param name="pageSize">ҳ��С��һ��ȡ���ļ�¼����</param>
		/// <param name="pageIndex">ҳ�루1��ʼ��</param>
		/// <param name="obType">��������</param>
		/// <param name="subfilter">ɸѡ��������</param>
		/// <returns>�����</returns>
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