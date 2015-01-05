using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// ������ͼ�������ռ䣬����λ��BusinessView�µĵ�һ��
	/// </summary>
	public class DistrictDefaultView : BusinessObjectView
	{
		public DistrictDefaultView() : base("District", "������")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("Code", "����������", true));
			vic.Add(new ViewItem("FK_Dictionary", "��������", true, "CityDefaultView"));
			vic.Add(new ViewItem("CreateUser", "������"));
			vic.Add(new ViewItem("CreateTime",	"����ʱ��"));
			vic.Add(new ViewItem("ModifyUser", "����޸���"));
			vic.Add(new ViewItem("ModifyTime", "����޸�ʱ��"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("Name", "����������", true);
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
