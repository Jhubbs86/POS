using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

using Wicresoft.BusinessObject;

namespace CWXT.Enums
{
    /// <summary>
    /// Indicates the status of a page
    /// </summary>
    public enum PageStatus
    {
        Create = 0,
        Edit,
        View
    }

    public enum ProjectType
    {
        DailyWorkProject = 1,
        MarketSurveyProject = 2,
        GroupSendProject = 3,
        UserDefinedGroupSend = 4
    }

    /// <summary>
    /// 用户组硬编码
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        public static int Role_1 = 1;
        /// <summary>
        /// 商务助理
        /// </summary>
        public static int Role_2 = 2;
        /// <summary>
        /// 商务部部长
        /// </summary>
        public static int Role_3 = 3;
        /// <summary>
        /// 预算分析
        /// </summary>
        public static int Role_4 = 4;
        /// <summary>
        /// 财务部经理
        /// </summary>
        public static int Role_5 = 5;
        /// <summary>
        /// 运营主管
        /// </summary>
        public static int Role_6 = 6;
        /// <summary>
        /// 运营专员
        /// </summary>
        public static int Role_7 = 7;
        /// <summary>
        /// 运营部经理
        /// </summary>
        public static int Role_8 = 8;
    }

    /// <summary>
    /// allen 添加
    /// </summary>
    public class SetOrder
    {
        public ListItemCollection items;
        public ListItemCollection itemsTemp;

        public SetOrder()
        {
            this.items = new ListItemCollection();
            this.itemsTemp = new ListItemCollection();

            //支付记录
            items.Add(new ListItem("BusinessRule_OperationManage_PayHistory_GetPayHistoryListWithDataPermissionForExport", "ContractID,StudentID,ChineseName,CC_Alias,Tutor_Alias,Amount,CommissionCharge,FinancePaymentTypeName,PaymentFormName,PaytoName,CenterName,PayTime,CreateUser_Alias"));
            itemsTemp.Add(new ListItem("BusinessRule_OperationManage_PayHistory_GetPayHistoryListWithDataPermissionForExport"));

            //特殊合同审批
            items.Add(new ListItem("BusinessRule_OperationManage_SpecialContractRequest_GetSpecialContractRequestForExport", "RequestID,ClientName,ClientEnglishName,CenterName,ContractTypeName,LevelNum,ExtraLevel,OriginalPrice,CurrentPrice,EndDate,ModifyUserName,ModifyTime,IsUsed"));
            itemsTemp.Add(new ListItem("BusinessRule_OperationManage_SpecialContractRequest_GetSpecialContractRequestForExport"));
        }
    }

    public class ToExcel
    {
        private static int pagecount = 0;
        private static int totalcount = 0;
        private static int pagenumber = 0;
        private static string NameSpaceAndClassName = string.Empty;
        private static string methodname = string.Empty;
        private static System.Collections.Hashtable hashtable;
        private static BusinessFilter queryfilter;

        public int PageSize
        {
            set { pagecount = value; }
            get { return pagecount; }
        }

        public int TotalCount
        {
            set { totalcount = value; }
            get { return totalcount; }
        }

        public int PageNumber
        {
            set { pagenumber = value; }
            get { return pagenumber; }
        }

        public string ClassName
        {
            set { NameSpaceAndClassName = value; }
            get { return NameSpaceAndClassName; }
        }

        public string MethodName
        {
            set { methodname = value; }
            get { return methodname; }
        }

        public BusinessFilter QueryFilter
        {
            set { queryfilter = value; }
            get { return queryfilter; }
        }

        public System.Collections.Hashtable HashTable
        {
            set { hashtable = value; }
            get { return hashtable; }
        }

    }

    public struct SystemColor
    {
        public static Color ReadonlyBackColor = Color.FromArgb(0xF1F1F1);
    }

    public class Constants
    {
        public const string Finished = "1";
        public const string NotFinished = "0";
        public const int PageSize = 15;
        public const string UrlReferrer = "__UrlReferrer";
        public const string PKID = "__PKID";
        public const string Message = "__Message";
        public const string PageID = "__PageID";
        public const string ControlID = "__ControlID";
        public const string QueryDesc = "__QueryDesc";
        public const string ExcelExport = "__ExcelExport";
        public const string DGItemAlterText = "双击查看";
        public const string AndChsText = "且";
        public const string OrChsText = "或";
        public const string Yes = "是";
        public const string No = "否";
        public const string Have = "有";
        public const string NotHave = "无";
        public const string Reg_Frequence = "^(0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24)$";
        public const string Reg_BeginTime = "^(0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23):(0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|46|47|48|49|50|51|52|53|54|55|56|57|58|59):(0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33|34|35|36|37|38|39|40|41|42|43|44|45|46|47|48|49|50|51|52|53|54|55|56|57|58|59)$";
        public const string DefaultUrl = "Default.aspx";
        public const string LoginError = "登录失败！";
        public const string VerificationCodeError = "验证码输入有误！";
        public const string ProjectNotValid = "项目未启用，无法完成发送";
        public const string RecordReserved = "系统保留记录，不能被删除！";

        //		Report2000	
        //		public static string ReportURL = System.Configuration.ConfigurationSettings.AppSettings["ReportServer"] + "{0}&rs:ClearSession=true&rs:Format=HTML4.0&rs:Command=Render&rc:Area=Toolbar&rc:LinkTarget=_top&rc:JavaScript=True&rc:Toolbar=True";
        //		Report2005	
        public static string ReportURL = System.Configuration.ConfigurationManager.AppSettings["ReportServer"] + "{0}&rs:ClearSession=true&rs:Format=HTML4.0&rs:Command=Render&rc:Area=Toolbar&rc:Parameters=False&rc:LinkTarget=_top&rc:JavaScript=True&rc:Toolbar=True";

        public const string TabSelectedStyle = "padding:5 5 5 5;font-size:9pt;font-family:Tahoma;font-weight:bold;background-color:#5f5f5f;color:#ffffff;border-left:solid 0px #000000;border-top:solid 0px #000000;border-right:solid 0px #000000;border-bottom:0px;background:url(TAB_FOCUS.gif.aspx);width:60px;height:28px;text-align:center;";
        public const string TabHoverStyle = "";
        public const string TabDefaultStyle = "padding:5 5 5 5;font-size:9pt;font-family:Tahoma;font-weight:bold;background-color:#ffffff;color:#a1a1a1;border-left:solid 0px #000000;border-top:solid 0px #000000;border-right:solid 0px #000000;border-bottom:0px;background:url(TAB_BLUR.gif.aspx);width:60px;height:28px;text-align:center;";

        public const string ToolbarButtonDefaultStyle = "border:solid 1px #f1f1f1;cursor:hand;";
        public const string ToolbarButtonHoverStyle = "border:solid 1px Gray;background-color:#e1e1e1;";
        public const string ToolbarButtonSelectedStyle = "border:solid 1px Gray;";
        public const string ToolbarSeparatorDefaultStyle = "border:solid 1px #f1f1f1;cursor:hand;";
        public const string ToolbarDropdownListDefaultStyle = "border:0px; cursor:hand;";
        public const string ToolbarLabelDefaultStyle = "border:0px;";
    }
}