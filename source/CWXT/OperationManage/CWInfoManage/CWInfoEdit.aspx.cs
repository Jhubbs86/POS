using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CWXT.OperationManage.CWInfoManage
{
    public partial class CWInfoEdit : EnterpriseWebsite.WebUI.ScrollPage
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ucCWInfo.LoadData(this.PKID, Enums.PageStatus.Edit);
            }
        }

        private bool btnSave_ButtonClick(object sender, EventArgs e)
        {
            if (this.ucCWInfo.ValidatePage())
            {
                ucCWInfo.Update();
                base.GoBack("CWInfoList.aspx");
            }
            return false;
        }

        private bool btnReturn_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack("CWInfoList.aspx");
            return false;
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            this.AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.btnSave.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSave_ButtonClick);
            this.btnReturn.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnReturn_ButtonClick);
        }

        private void InitializeComponent() { }
    }
}