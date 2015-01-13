using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
	/// <summary>
	/// 独生子女统计
	/// </summary>
	public class CWOneChildDefaultView : BusinessObjectView
	{
		public CWOneChildDefaultView() 
			: base("CWOneChild", "独生子女统计")
		{
			ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            vic.Add(new ViewItem("ChildName", "姓名", true));
            //vic.Add(new ViewItem("Sex", "性别", true,""));
            vic.Add(new ViewItem("FathIDCardNo", "父亲身份证号", true));
            vic.Add(new ViewItem("MothIDCardNo", "母亲身份证号", true));
            vic.Add(new ViewItem("OneChildNo", "光荣证号", true));
            vic.Add(new ViewItem("IssueOrg", "发证机关", true));
            vic.Add(new ViewItem("BirthDate", "出生年月", true));
            //vic.Add(new ViewItem("InSchool", "就读学校", true));
            //vic.Add(new ViewItem("FamilyAddress", "家庭居住地址", true));
            //vic.Add(new ViewItem("FamilyIncome", "家庭人均收入", true));
            //vic.Add(new ViewItem("InsuNo", "独生子女保险卡号", true));
            
			this.PKField = new ViewItem("PKID", "PKID");

			/// <summary>
			/// GridPicker控件用于显示的字段请根据实际情况修改
			/// </summary>
			this.DisplayField = new ViewItem("IDCardNo", "身份证号", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.JHSY.CWOneChild rule = new BusinessRule.JHSY.CWOneChild();
			this.tblSchema = rule.GetCWOneChildList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
