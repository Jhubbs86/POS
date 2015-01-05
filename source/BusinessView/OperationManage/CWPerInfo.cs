using System;
using Wicresoft.BusinessObject;

namespace BusinessView
{
    /// <summary>
    /// 村务人员信息
    /// </summary>
    public class CWPerInfoDefaultView : BusinessObjectView
    {
        public CWPerInfoDefaultView()
            : base("CWPerInfo", "村务人员信息")
        {
            ViewItemCollection vic = new ViewItemCollection();
            vic.Add(new ViewItem("FK_CWID", "所属村镇", true, "CWInfoDefaultView"));
            vic.Add(new ViewItem("IDCardNo", "身份证号", true));
            vic.Add(new ViewItem("HolderName", "户主姓名", true));
            vic.Add(new ViewItem("HolderIDCardNo", "户主身份证号", true));

            this.PKField = new ViewItem("PKID", "PKID");

            /// <summary>
            /// GridPicker控件用于显示的字段请根据实际情况修改
            /// </summary>
            this.DisplayField = new ViewItem("Name", "姓名", true);
            this.VisibleColumnCollection = vic;
        }

        public override int LoadData(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            BusinessRule.OperationManage.CWPerInfo rule = new BusinessRule.OperationManage.CWPerInfo();
            this.tblSchema = rule.GetCWPerInfoList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);

            return totalCount;
        }
    }
}