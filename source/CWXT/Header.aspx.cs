using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

using Wicresoft.BusinessObject;

namespace CWXT
{
    public partial class Header : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int parentMenuId = Convert.ToInt32(Request.QueryString["menuid"]);
            strSqlWhere = " PKID IN (SELECT  RoleMenu.FK_Menu FROM dbo.[User] "
               + "LEFT JOIN RoleMenu ON RoleMenu.FK_Role = dbo.[User].FK_Role WHERE dbo.[User].PKID = " + GlobalFacade.SystemContext.GetContext().UserID.ToString() + ")";

            dtMenuItems = new Wicresoft.Session.Session().SqlHelper.ExcuteDataTable(dtMenuItems,
            "SELECT * FROM Menu WHERE IsLeaf=0 AND IsValid = 1 AND Parent = 0 AND " + strSqlWhere
            + " ORDER BY [Parent],[DisplayOrder]", CommandType.Text);

            
            foreach (DataRow dr in dtMenuItems.Rows)
            {
                string url ="Menu.aspx?Parent=" + dr["PKID"].ToString();
                HtmlAnchor a = new HtmlAnchor();
                a.InnerHtml = "[" + dr["Chinesename"].ToString() +"]";
                a.HRef = "javascript:void(0)";
                a.Attributes.Add("onclick", string.Format("MenuItemClick(this,\"{0}\")", url));
                this.divContainer.Controls.Add(a);
            }
        }
        private int parentMenuId = 0;

        private string strSqlWhere;
        private DataTable dtMenuItems;
    }
}