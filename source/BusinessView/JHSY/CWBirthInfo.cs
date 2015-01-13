using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
	/// <summary>
	/// 村务出生小孩信息
	/// </summary>
	public class CWBirthInfoDefaultView : BusinessObjectView
	{
		public CWBirthInfoDefaultView() 
			: base("CWBirthInfo", "村务出生小孩信息")
		{
			ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            //vic.Add(new ViewItem("Sex", "性别", true, ""));
            vic.Add(new ViewItem("BirthDate", "出生年月", true));
            vic.Add(new ViewItem("BirthNo", "出生证编号", true));
            //vic.Add(new ViewItem("IsPlan", "是否计划", true, ""));
            //vic.Add(new ViewItem("ExpectDate", "预产期", true));
            //vic.Add(new ViewItem("ChildAddress", "户籍地址", true));
            vic.Add(new ViewItem("HolderName", "户主姓名", true));
            vic.Add(new ViewItem("HolderIDCardNo", "户主身份证号", true));
            //vic.Add(new ViewItem("FathName", "父亲姓名", true));
            //vic.Add(new ViewItem("FathIDCardNo", "父亲身份证号", true));
            //vic.Add(new ViewItem("FathAddress", "父亲户籍地址", true));
            //vic.Add(new ViewItem("FathLinkPhone", "父亲联系方式", true));
            //vic.Add(new ViewItem("MothName", "母亲姓名", true));
            //vic.Add(new ViewItem("MothIDCardNo", "母亲身份证号", true));
            //vic.Add(new ViewItem("MothAddress", "母亲户籍地址", true));
            //vic.Add(new ViewItem("MothLinkPhone", "母亲联系方式", true));
            
			this.PKField = new ViewItem("PKID", "PKID");

			/// <summary>
			/// GridPicker控件用于显示的字段请根据实际情况修改
			/// </summary>
			this.DisplayField = new ViewItem("ChildName", "小孩姓名", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.JHSY.CWBirthInfo rule = new BusinessRule.JHSY.CWBirthInfo();
			this.tblSchema = rule.GetCWBirthInfoList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}
