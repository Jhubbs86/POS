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
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            ProcessFlow.AccountController controller = new ProcessFlow.AccountController();
            controller.SignOut();

            string action = Request.QueryString["__action"];

            if (action != null && action == "exit")
                Response.Write("<script language='javascript'>top.opener=null;top.close();</script>");
            else
                Response.Write("<script language='javascript'>window.top.location.href='" + Enums.Constants.DefaultUrl + "'</script>");
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
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