using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
	/// <summary>
	/// 新婚登记
	/// </summary>
	public class CWNewMarrigeDefaultView : BusinessObjectView
	{
		public CWNewMarrigeDefaultView() 
			: base("CWNewMarrige", "新婚登记")
		{
			ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            vic.Add(new ViewItem("MaleName", "男方姓名", true));
            vic.Add(new ViewItem("MaleAddress", "男方户籍地址", true));
            vic.Add(new ViewItem("MaleLinkPhone", "男方联系方式", true));
            vic.Add(new ViewItem("FemaleIDCardNo", "女方身份证号", true));
            vic.Add(new ViewItem("FemaleName", "女方姓名", true));
            vic.Add(new ViewItem("FemaleAddress", "女方户籍地址", true));
            vic.Add(new ViewItem("FemaleLinkPhone", "女方联系方式", true));
            vic.Add(new ViewItem("MarrigeDate", "结婚登记日期", true));
            //vic.Add(new ViewItem("IsPregnant", "是否怀孕", true,""));
            //vic.Add(new ViewItem("ExpectDate", "预产期", true));
            //vic.Add(new ViewItem("VillageDate", "村委登记日期", true));
            //vic.Add(new ViewItem("MarrigeNo", "结婚登记证号", true));
            
			this.PKField = new ViewItem("PKID", "PKID");

			/// <summary>
			/// GridPicker控件用于显示的字段请根据实际情况修改
			/// </summary>
			this.DisplayField = new ViewItem("MaleIDCardNo", "男方身份证号", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.JHSY.CWNewMarrige rule = new BusinessRule.JHSY.CWNewMarrige();
			this.tblSchema = rule.GetCWNewMarrigeList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
