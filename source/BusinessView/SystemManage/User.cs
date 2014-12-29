using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// ������ͼ�������ռ䣬����λ��BusinessView�µĵ�һ��
	/// </summary>
    public class UserDefaultView : BusinessObjectView
    {
        public UserDefaultView()
            : base("User", "ϵͳ�û�")
        {
            ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("ChineseName", "������", true));
            vic.Add(new ViewItem("FK_Role", "�û���", true, "RoleDefaultView"));
            vic.Add(new ViewItem("IsActive", "�Ƿ���ְ", true));

            this.PKField = new ViewItem("PKID", "PKID");
            this.DisplayField = new ViewItem("Alias", "Alias", true);
            this.VisibleColumnCollection = vic;
        }

        public override int LoadData(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            BusinessRule.SystemManage.User rule = new BusinessRule.SystemManage.User();
            this.tblSchema = rule.GetUserList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);

            return totalCount;
        }
    }
}