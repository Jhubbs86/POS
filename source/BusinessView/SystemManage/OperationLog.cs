using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// 所有视图的命名空间，必需位于BusinessView下的第一层
	/// </summary>
	public class OperationLogDefaultView : BusinessObjectView
	{
		public OperationLogDefaultView() : base("OperationLog", "操作日志")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("Description", "操作描述", true));
			vic.Add(new ViewItem("CreateUser", "操作者", true, "UserDefaultView"));
			vic.Add(new ViewItem("CreateTime",	"操作时间", true));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Module", "功能模块", true);
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
