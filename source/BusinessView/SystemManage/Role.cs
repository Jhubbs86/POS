using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// ������ͼ�������ռ䣬����λ��BusinessView�µĵ�һ��
	/// </summary>
	public class RoleDefaultView : BusinessObjectView
	{
		public RoleDefaultView() : base("Role", "�û���")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("RoleCode","�û������", true));
			vic.Add(new ViewItem("FK_UserLevel","�û�����", true, "UserLevelDefaultView"));
			vic.Add(new ViewItem("CreateUser", "������"));
			vic.Add(new ViewItem("CreateTime",	"����ʱ��"));
			vic.Add(new ViewItem("ModifyUser", "����޸���"));
			vic.Add(new ViewItem("ModifyTime", "����޸�ʱ��"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("RoleName", "�û�������", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.SystemManage.Role rule = new BusinessRule.SystemManage.Role();
			this.tblSchema = rule.GetRoleList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
