using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// UserType ��ժҪ˵����
	/// </summary>
	public class UserType
	{
		public static string Teacher = "���";
		public static string CC = "�γ̹���";
		public static string Reception = "ǰ̨";
		public static string Tutor = "Tutor";
		public static string CDTutor = "��ѧ����";
		public static string TMK = "TMK";
		public static string ChargeTMK = "TMK����";
		public static string GlobalTMK = "�ܲ�TMK";
		public static string CD = "��������";
		public static string EduAssistant = "����";
        public static string CityPrincipal = "����У��";

		/// <summary>
		/// ��ȡ��λ�б�
		/// </summary>
		/// <param name="totalCount">��¼����</param>
		/// <param name="pageSize">ҳ��С��һ��ȡ���ļ�¼����</param>
		/// <param name="pageIndex">ҳ�루1��ʼ��</param>
		/// <param name="obType">��������</param>
		/// <param name="subfilter">ɸѡ��������</param>
		/// <returns>�����</returns>
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