using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// ������ͼ�������ռ䣬����λ��BusinessView�µĵ�һ��
	/// </summary>
	public class OperationLogDefaultView : BusinessObjectView
	{
		public OperationLogDefaultView() : base("OperationLog", "������־")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("Description", "��������", true));
			vic.Add(new ViewItem("CreateUser", "������", true, "UserDefaultView"));
			vic.Add(new ViewItem("CreateTime",	"����ʱ��", true));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Module", "����ģ��", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
			this.tblSchema = rule.GetOperationLogList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
