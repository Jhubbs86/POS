using System;
using Wicresoft.BusinessObject;

namespace BusinessView.SystemManage
{
    public class UserDataPermission : BusinessObjectView
    {
        public UserDataPermission()
            : base("UserDataPermission", "�û�Ȩ��")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("CreateUser", "������"));
			vic.Add(new ViewItem("CreateTime",	"����ʱ��"));
			vic.Add(new ViewItem("ModifyUser", "����޸���"));
			vic.Add(new ViewItem("ModifyTime", "����޸�ʱ��"));
			vic.Add(new ViewItem("IsValid", "�Ƿ���Ч"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Name", "����", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
            BusinessRule.SystemManage.UserDataPermission rule = new BusinessRule.SystemManage.UserDataPermission();
			this.tblSchema = rule.GetUserDataPermissionList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
    }
}
