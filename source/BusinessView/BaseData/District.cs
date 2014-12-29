using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// 所有视图的命名空间，必需位于BusinessView下的第一层
	/// </summary>
	public class DistrictDefaultView : BusinessObjectView
	{
		public DistrictDefaultView() : base("District", "行政区")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("Code", "行政区代码", true));
			vic.Add(new ViewItem("FK_Dictionary", "所属城市", true, "CityDefaultView"));
			vic.Add(new ViewItem("CreateUser", "创建者"));
			vic.Add(new ViewItem("CreateTime",	"创建时间"));
			vic.Add(new ViewItem("ModifyUser", "最后修改者"));
			vic.Add(new ViewItem("ModifyTime", "最后修改时间"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Name", "行政区名称", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.BaseData.District rule = new BusinessRule.BaseData.District();
			this.tblSchema = rule.GetDistrictList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
