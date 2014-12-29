using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// 所有视图的命名空间，必需位于BusinessView下的第一层
	/// </summary>
    public class UserDefaultView : BusinessObjectView
    {
        public UserDefaultView()
            : base("User", "系统用户")
        {
            ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("ChineseName", "中文名", true));
            vic.Add(new ViewItem("FK_Role", "用户组", true, "RoleDefaultView"));
            vic.Add(new ViewItem("IsActive", "是否在职", true));

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