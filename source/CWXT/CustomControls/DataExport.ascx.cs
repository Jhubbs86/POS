namespace CWXT.CustomControls
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

    /// <summary>
    ///		DataExport 的摘要说明。
    /// </summary>
    partial class DataExport : System.Web.UI.UserControl
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
        }

        public void Export()
        {
            Page.RegisterStartupScript("__DataExport", "<script language=javascript>window.open('" + Request.ApplicationPath + "/CustomControls/IFRame.aspx','','top=300,left=400,width=400,height=280,scroll=no');</script>");
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
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}