using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// 所有视图的命名空间，必需位于BusinessView下的第一层
	/// </summary>
	public class UserLevelDefaultView : BusinessObjectView
	{
		public UserLevelDefaultView() : base("UserLevel", "用户级别")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("CreateUser", "创建者"));
			vic.Add(new ViewItem("CreateTime",	"创建时间"));
			vic.Add(new ViewItem("ModifyUser", "最后修改者"));
			vic.Add(new ViewItem("ModifyTime", "最后修改时间"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("LevelName", "级别名称", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.SystemManage.UserLevel rule = new BusinessRule.SystemManage.UserLevel();
			this.tblSchema = rule.GetUserLevelList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
