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
    public partial class WelcomeBar : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected string UserName = string.Empty;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.UserName = this.MyContext.UserName + "[" + this.MyContext.CurrentUser.FK_Role.DisplayValue + "]";
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            this.AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnExit.Attributes.Add("onclick", "return confirm('您确认要退出系统？')");
            AjaxPro.Utility.RegisterTypeForAjax(typeof(CWXT.WelcomeBarAjax));
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.SwitchUser();
        }
    }
}