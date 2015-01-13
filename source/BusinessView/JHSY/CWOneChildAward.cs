using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
	/// <summary>
	/// 独生子女奖励费统计
	/// </summary>
	public class CWOneChildAwardDefaultView : BusinessObjectView
	{
		public CWOneChildAwardDefaultView() 
			: base("CWOneChildAward", "独生子女奖励费统计")
		{
			ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            vic.Add(new ViewItem("OwnName", "享受人姓名", true));
            vic.Add(new ViewItem("ChildIDCardNo", "孩子身份证号", true));
            vic.Add(new ViewItem("ChildName", "孩子姓名", true));
            vic.Add(new ViewItem("BirthDate", "出生年月", true));
            vic.Add(new ViewItem("OneChildNo", "独生子女光荣证号", true));
            //vic.Add(new ViewItem("RealMonth", "享受月数", true));
            //vic.Add(new ViewItem("AwardFee", "金额", true));
            //vic.Add(new ViewItem("LinkPhone", "联系电话", true));
            //vic.Add(new ViewItem("AuthName", "持卡人姓名", true));
            //vic.Add(new ViewItem("ABCNo", "农行卡号", true));
            //vic.Add(new ViewItem("AuthIDCardNo", "持卡人身份证号", true));
            //vic.Add(new ViewItem("AwardYear", "年份", true));
            
			this.PKField = new ViewItem("PKID", "PKID");

			/// <summary>
			/// GridPicker控件用于显示的字段请根据实际情况修改
			/// </summary>
			this.DisplayField = new ViewItem("OwnIDCardNo", "享受人身份证号", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.JHSY.CWOneChildAward rule = new BusinessRule.JHSY.CWOneChildAward();
			this.tblSchema = rule.GetCWOneChildAwardList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
