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
            //vic.Add(new ViewItem("Sex", "性别", true,""));
            //vic.Add(new ViewItem("Nation", "民族", true, ""));
            //vic.Add(new ViewItem("Politics", "政治面貌", true, ""));
            //vic.Add(new ViewItem("IsHolder", "是否户主", true, ""));
            vic.Add(new ViewItem("HolderName", "户主姓名", true));
            vic.Add(new ViewItem("HolderIDCardNo", "户主身份证号", true));
            //vic.Add(new ViewItem("HolderPorp", "户口性质", true,""));

            //vic.Add(new ViewItem("HolderAddress", "户籍地址", true));
            //vic.Add(new ViewItem("LiveAddress", "居住地址", true));
            //vic.Add(new ViewItem("LinkPhone", "联系电话", true));
            //vic.Add(new ViewItem("WorkUnit", "工作单位", true));
            //vic.Add(new ViewItem("MarrigeStatus", "结婚状况", true));
            //vic.Add(new ViewItem("MarrigeDate", "结婚登记日期", true));
            //vic.Add(new ViewItem("MarrigeNo", "结婚登记证明号", true));
            //vic.Add(new ViewItem("MarrigeName", "对象姓名", true));
            //vic.Add(new ViewItem("MarrigeIDCardNo", "对象身份证号", true));
            //vic.Add(new ViewItem("Children", "子女情况", true));
            //vic.Add(new ViewItem("IsSingle", "是否独生", true));
            //vic.Add(new ViewItem("ChildName1", "小孩姓名1", true));
            //vic.Add(new ViewItem("ChildIDCardNo1", "小孩身份证号1", true));
            //vic.Add(new ViewItem("ChildAddress1", "小孩户籍地址1", true));
            //vic.Add(new ViewItem("BirthNo1", "小孩出生证号1", true));
            //vic.Add(new ViewItem("BirthDate1", "出生日期1", true));
            //vic.Add(new ViewItem("AdoptNo1", "收养文书号1", true));
            //vic.Add(new ViewItem("ChildName2", "小孩姓名2", true));
            //vic.Add(new ViewItem("ChildIDCardNo2", "小孩身份证号2", true));
            //vic.Add(new ViewItem("ChildAddress2", "小孩户籍地址2", true));
            //vic.Add(new ViewItem("BirthNo2", "小孩出生证号2", true));
            //vic.Add(new ViewItem("BirthDate2", "出生日期2", true));
            //vic.Add(new ViewItem("AdoptNo2", "收养文书号2", true));
            //vic.Add(new ViewItem("ChildName3", "小孩姓名3", true));
            //vic.Add(new ViewItem("ChildIDCardNo3", "小孩身份证号3", true));
            //vic.Add(new ViewItem("ChildAddress3", "小孩户籍地址3", true));
            //vic.Add(new ViewItem("BirthNo3", "小孩出生证号3", true));
            //vic.Add(new ViewItem("BirthDate3", "出生日期3", true));
            //vic.Add(new ViewItem("AdoptNo3", "收养文书号3", true));

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
            BusinessRule.JHSY.CWPerInfo rule = new BusinessRule.JHSY.CWPerInfo();
            this.tblSchema = rule.GetCWPerInfoList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);

            return totalCount;
        }
    }
}