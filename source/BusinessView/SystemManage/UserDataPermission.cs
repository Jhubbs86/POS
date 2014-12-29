using System;
using Wicresoft.BusinessObject;

namespace BusinessView.SystemManage
{
    public class UserDataPermission : BusinessObjectView
    {
        public UserDataPermission()
            : base("UserDataPermission", "用户权限")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("CreateUser", "创建者"));
			vic.Add(new ViewItem("CreateTime",	"创建时间"));
			vic.Add(new ViewItem("ModifyUser", "最后修改者"));
			vic.Add(new ViewItem("ModifyTime", "最后修改时间"));
			vic.Add(new ViewItem("IsValid", "是否有效"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Name", "名称", true);
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
