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
using Wicresoft.Session;

namespace CWXT.SystemManage.UserManage
{
    /// <summary>
    /// QueryUser 的摘要说明。
    /// </summary>
    public partial class QueryUser : EnterpriseWebsite.WebUI.ScrollPage
    {
        private bool btnQuery_ButtonClick(object sender, EventArgs e)
        {
            string filterDescription;
            BusinessFilter filter = this.ucQueryProvider.GetBusinessFilter(out filterDescription);

            SaveQueryResult(filter, filterDescription);
            GlobalFacade.Utils.CloseWindowAndRefreshParent();
            return false;
        }

        private bool btnClose_ButtonClick(object sender, EventArgs e)
        {
            GlobalFacade.Utils.CloseWindow();
            return false;
        }

        private bool btnClear_ButtonClick(object sender, EventArgs e)
        {
            this.ucQueryProvider.ClearQueryStatus();
            SaveQueryResult(null, string.Empty);
            GlobalFacade.Utils.CloseWindowAndRefreshParent();
            return false;
        }

        private void SaveQueryResult(BusinessFilter filter, string filterDescription)
        {
            this.MyContext.GetPageContext(this.OpenerID).LastQueryCondition[this.ControlID] = filter;
            this.MyContext.GetPageContext(this.OpenerID).Parms[Enums.Constants.QueryDesc] = filterDescription;
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void AppendServerEvents()
        {
            this.btnClose.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClose_ButtonClick);
            this.btnQuery.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnQuery_ButtonClick);
            this.btnClear.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClear_ButtonClick);
            this.ucQueryProvider.InitQueryProvider("UserDefaultView");
        }
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
