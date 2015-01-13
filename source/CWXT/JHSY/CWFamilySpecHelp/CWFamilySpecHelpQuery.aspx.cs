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

using Wicresoft.BusinessObject;
using Wicresoft.Session;

namespace CWXT.JHSY.CWFamilySpecHelp
{
    public partial class CWFamilySpecHelpQuery : EnterpriseWebsite.WebUI.ScrollPage
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

		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
			AppendServerEvents();
		}
	
		private void AppendServerEvents()
		{
			this.btnClose.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClose_ButtonClick);
			this.btnQuery.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnQuery_ButtonClick);
			this.btnClear.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClear_ButtonClick);
			this.ucQueryProvider.InitQueryProvider("CWFamilySpecHelpDefaultView");
		}

		private void InitializeComponent(){}
	}
}