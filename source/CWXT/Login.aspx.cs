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

namespace CWXT
{
    public partial class Login : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            //if (!ucVerificationCodeManager.ValidateInputCode(this.tbxVerifyNumber.Text))
            //{
            //    this.valVerifyNumber.ErrorMessage = Enums.Constants.VerificationCodeError;
            //    this.valVerifyNumber.IsValid = false;
            //    return;
            //}

            CWXT.ProcessFlow.AccountController controller = new CWXT.ProcessFlow.AccountController();

            if (!controller.ProcessLogin(this.tbxUserName.Text, this.tbxPassword.Text))
            {
                this.valUserId.ErrorMessage = Enums.Constants.LoginError;
                this.valUserId.IsValid = false;
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
            this.AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.btnLogin.Click += new ImageClickEventHandler(btnLogin_Click);
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