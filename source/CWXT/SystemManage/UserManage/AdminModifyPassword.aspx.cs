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
    /// AdminModifyPassword 的摘要说明。
    /// </summary>
    public partial class AdminModifyPassword : EnterpriseWebsite.WebUI.ScrollPage
    {
        private BusinessMapping.User bo = new BusinessMapping.User();
        private BusinessFilter filter;
        private string userid;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 获取用户PKID信息
            userid = this.PKID.ToString();
            Info.Text = null;
            Initialize();
        }
        private void Initialize()
        {
            bo.SessionInstance = new Wicresoft.Session.Session();
            filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", userid, Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();
            if (bo.HaveRecord)
            {
                this.Info.Text = "您正在修改" + bo.ChineseName.Value.ToString() + "[" + bo.Alias.Value.ToString() + "]的个人信息<br/><br/>";
            }
        }
        private void Save()
        {
            string InputPwd = EncryptionManager.EncrytPassword(this.tbxNewPassword.Text.Trim().ToString());
            bo = new BusinessMapping.User();
            bo.SessionInstance = new Wicresoft.Session.Session();
            filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", userid, Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();
            if (bo.HaveRecord)
            {
                bo.Password.Value = InputPwd;

                // 2006-11-20, Tony
                bo.LastModifyPasswordTime.Value = DateTime.Now;

                bo.Update();
                GlobalFacade.Utils.ShowMessageUrl("提示：您的密码已经成功更新...", "UserList.aspx");
            }

        }
        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {

            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();

        }
        private void AppendServerEvents()
        {
            this.btnSave.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSave_ButtonClick);
            this.ValidatorPwd.ServerValidate += new ServerValidateEventHandler(ValidatorPwd_ServerValidate);
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
        private void ValidatorPwd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ValidatePassword(this.tbxNewPassword.Text.Trim().ToString());
        }
        /// <summary>
        /// ValidatePassword验证密码规则的正则表达式
        /// </summary>
        /// <param name="newpwd">获取新密码的字段值</param>
        /// <returns></returns>
        private bool ValidatePassword(string newpwd)
        {
            int Flag1 = 0, Flag2 = 0, Flag3 = 0;
            Boolean isValid = false;
            System.Text.RegularExpressions.Regex MyReg;
            MyReg = new System.Text.RegularExpressions.Regex("[a-zA-Z]{1,}");

            if (MyReg.IsMatch(newpwd, 0))
            {
                Flag1 = 1;
            }

            MyReg = new System.Text.RegularExpressions.Regex("[0-9]{1,}");

            if (MyReg.IsMatch(newpwd, 0))
            {
                Flag2 = 1;
            }
            MyReg = new System.Text.RegularExpressions.Regex("[/@/=/./,/</>/;/:/^/=/+/(/)/*/&/^/%/$/#!]{1,}");

            if (MyReg.IsMatch(newpwd, 0))
            {
                Flag3 = 1;
            }

            if (Flag1 == 1 && Flag2 == 1 && Flag3 == 1 && newpwd.Length >= 8)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        private void ValidatorPwdAgain_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ValidatePassword(this.tbxNewPassword.Text.Trim().ToString());
        }

        private bool btnReturn_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack();
            return true;
        }
    }
}
