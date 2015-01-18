using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
    /// <summary>
    /// 计生家庭特别扶助统计
    /// </summary>
    public class CWFamilySpecHelpDefaultView : BusinessObjectView
    {
        public CWFamilySpecHelpDefaultView()
            : base("CWFamilySpecHelp", "计生家庭特别扶助统计")
        {
            ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            vic.Add(new ViewItem("AppName", "申请人姓名", true));
            //vic.Add(new ViewItem("Sex", "性别", true, ""));
            //vic.Add(new ViewItem("HolderPorp", "户口性质", true, ""));
            //vic.Add(new ViewItem("HelpType", "扶助类型", true, ""));
            //vic.Add(new ViewItem("RealMonth", "享受时间", true));
            //vic.Add(new ViewItem("HelpMoney", "享受金额", true));
            vic.Add(new ViewItem("HelpNo", "发放证编号", true));
            vic.Add(new ViewItem("HelpYear", "年份", true));

            this.PKField = new ViewItem("PKID", "PKID");

            /// <summary>
            /// GridPicker控件用于显示的字段请根据实际情况修改
            /// </summary>
            this.DisplayField = new ViewItem("AppIDCardNo", "身份证号码", true);
            this.VisibleColumnCollection = vic;
        }

        public override int LoadData(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            BusinessRule.JHSY.CWFamilySpecHelp rule = new BusinessRule.JHSY.CWFamilySpecHelp();
            this.tblSchema = rule.GetCWFamilySpecHelpList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);

            return totalCount;
        }
    }
}
