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

using GlobalFacade;
using Wicresoft.BusinessObject;

namespace CWXT.SystemManage.UserManage
{
    /// <summary>
    /// UserModifyPassword 的摘要说明。
    /// </summary>
    public partial class UserModifyPassword : EnterpriseWebsite.WebUI.ScrollPage
    {
        private BusinessMapping.User bo = new BusinessMapping.User();
        private BusinessFilter filter;
        private string userid = null, inputpwd = null;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            userid = this.MyContext.UserID.ToString();
            // 在此处放置用户代码以初始化页面
        }


        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();
        }
        private void AppendServerEvents()
        {
            this.btnSave.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSave_ButtonClick);
            this.ValidatorPwd.ServerValidate += new ServerValidateEventHandler(ValidatorPwd_ServerValidate);
            this.validatorOldPwd.ServerValidate += new ServerValidateEventHandler(validatorOldPwd_ServerValidate);
            this.btnReturn.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnReturn_ButtonClick);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        private bool btnSave_ButtonClick(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Save();
            }
            return false;
        }
        private void Save()
        {
            inputpwd = EncryptionManager.EncrytPassword(this.tbxNewPassword.Text.Trim().ToString());
            bo.SessionInstance = new Wicresoft.Session.Session();
            filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", userid, Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();
            if (bo.HaveRecord)
            {
                bo.Password.Value = inputpwd;

                // 2006-11-20, Tony
                bo.LastModifyPasswordTime.Value = DateTime.Now;

                bo.Update();
                GlobalFacade.Utils.ShowMessageUrl("提示：您的密码已经成功更新..", "../../WorkSpace/MyWorkSpace.aspx");
            }
            else
            {
                GlobalFacade.Utils.ShowMessage("提示：您的帐户不存在...");
            }
        }

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

        private bool btnReturn_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack("../../WorkSpace/MyWorkSpace.aspx");
            return true;
        }
    }
}
