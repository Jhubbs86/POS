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
using Wicresoft.BusinessObject;

namespace CWXT.SystemManage.UserManage
{
    /// <summary>
    /// CheckPassword 的摘要说明。
    /// </summary>
    public partial class CheckPassword : EnterpriseWebsite.WebUI.ScrollPage
    {
        #region Variables
        static string CAN_CANCEL = "您的密码还有{0}天就要过期，现在是否要修改密码？";
        static string FIRST_LOGIN = "您是第一次登录系统，请立刻修改您的登录密码。";
        static string MUST_MODIFY = "您的登录密码已过期，请立刻修改您的登录密码。";

        string passwordAlertDays = System.Configuration.ConfigurationManager.AppSettings["PasswordAlertDays"];
        string passwordDays = System.Configuration.ConfigurationManager.AppSettings["PasswordDays"];

        private ProcessFlow.AccountController controller = new CWXT.ProcessFlow.AccountController();
        private string InputPwd = null;
        private BusinessMapping.User bo = new BusinessMapping.User();
        private BusinessFilter filter;
        #endregion

        #region Page Load Process
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                switch (controller.CheckResult)
                {
                    case ProcessFlow.AccountController.Result.CAN_CANCEL:
                        if (Session["LastDays"] != null)
                            this.lblMessage.Text = string.Format(CAN_CANCEL, Session["LastDays"].ToString());
                        else
                        {
                            controller.SignOut();
                            base.PageTransfer(Request.ApplicationPath);
                        }
                        break;
                    case ProcessFlow.AccountController.Result.FIRST_LOGIN:
                        this.lblMessage.Text = FIRST_LOGIN;
                        break;
                    case ProcessFlow.AccountController.Result.MUST_MODIFY:
                        this.lblMessage.Text = MUST_MODIFY;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Validation
        private bool RgePage()
        {
            int Flag1 = 0, Flag2 = 0, Flag3 = 0;
            Boolean Flag = false;
            System.Text.RegularExpressions.Regex MyReg;
            MyReg = new System.Text.RegularExpressions.Regex("[a-zA-Z]{1,}");
            if (MyReg.IsMatch(tbxNewPassword.Text.ToString(), 0))
            {
                Flag1 = 1;
            }
            MyReg = new System.Text.RegularExpressions.Regex("[0-9]{1,}");
            if (MyReg.IsMatch(tbxNewPassword.Text.ToString(), 0))
            {
                Flag2 = 1;
            }
            MyReg = new System.Text.RegularExpressions.Regex("[/@/=/./,/</>/;/:/^/=/+/(/)/*/&/^/%/$/#!]{1,}");
            if (MyReg.IsMatch(tbxNewPassword.Text.ToString(), 0))
            {
                Flag3 = 1;
            }
            if (GlobalFacade.EncryptionManager.EncrytPassword(this.tbxOldPassword.Text.Trim().ToString()) == GlobalFacade.EncryptionManager.EncrytPassword(this.tbxNewPassword.Text.Trim().ToString()) && this.validatorOldPwd.IsValid == true)
            {
                GlobalFacade.Utils.ShowMessage("提示：新密码的设置不能和旧密码相同");
                this.ValidatorPwd.ErrorMessage = string.Empty;
                Flag = false;
            }
            else if (Flag1 == 1 && Flag2 == 1 && Flag3 == 1 && this.tbxNewPassword.Text.Trim().Length >= 8)
            {
                Flag = true;
            }
            else
            {
                Flag = false;
                this.ValidatorPwd.ErrorMessage = "新密码格式错误[必须包含数字、字母和特殊符号,必须大于等于8位数]";
            }
            return Flag;
        }

        private void ValidatorPwd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = RgePage();
        }

        private void validatorOldPwd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string Alias = GlobalFacade.SystemContext.GetContext().Alias.ToString();

            BusinessFilter filter = new BusinessFilter("User");
            filter.AddFilterItem("Alias", Alias, Operation.Equal, FilterType.StringType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsActive", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = new Wicresoft.Session.Session();
            bo.AddFilter(filter);
            bo.Load();

            args.IsValid = GlobalFacade.EncryptionManager.VerifyPassword(this.tbxOldPassword.Text.Trim(), bo.Password.Value);
            this.validatorOldPwd.ErrorMessage = "旧密码输入错误";
        }
        #endregion

        #region Save / Cancel
        /// <summary>
        /// 更新密码
        /// </summary>
        private void Save()
        {
            InputPwd = GlobalFacade.EncryptionManager.EncrytPassword(this.tbxNewPassword.Text.Trim().ToString());
            bo.SessionInstance = new Wicresoft.Session.Session();
            filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", GlobalFacade.SystemContext.GetContext().UserID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();
            if (bo.HaveRecord)
            {
                bo.Password.Value = InputPwd;

                // 2006-11-20, Tony
                bo.LastModifyPasswordTime.Value = DateTime.Now;

                bo.Update();
            }
        }

        private bool btnSave_ButtonClick(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Save();
                controller.ProcessLogin(GlobalFacade.SystemContext.GetContext().Alias);
            }
            return false;
        }

        private bool btnCancel_ButtonClick(object sender, EventArgs e)
        {
            switch (controller.CheckResult)
            {
                case ProcessFlow.AccountController.Result.CAN_CANCEL:
                    controller.ProcessLogin(GlobalFacade.SystemContext.GetContext().Alias);
                    base.PageTransfer(Request.ApplicationPath + "/" + Enums.Constants.DefaultUrl);
                    break;
                case ProcessFlow.AccountController.Result.FIRST_LOGIN:
                case ProcessFlow.AccountController.Result.MUST_MODIFY:
                default:
                    controller.SignOut();
                    base.PageTransfer(Request.ApplicationPath);
                    break;
            }
            return false;
        }
        #endregion

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);

            this.btnSave.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSave_ButtonClick);
            this.btnCancel.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnCancel_ButtonClick);
            this.ValidatorPwd.ServerValidate += new ServerValidateEventHandler(ValidatorPwd_ServerValidate);
            this.validatorOldPwd.ServerValidate += new ServerValidateEventHandler(validatorOldPwd_ServerValidate);

        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
