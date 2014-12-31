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
using Microsoft.Web.UI.WebControls;

using Wicresoft.BusinessObject;

namespace CWXT
{
    public partial class Menu : EnterpriseWebsite.WebUI.ScrollPage
    {
        string strWhere;
        DataTable DataRoots;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                strWhere = " PKID IN (SELECT  RoleMenu.FK_Menu FROM dbo.[User] "
                + "LEFT JOIN RoleMenu ON RoleMenu.FK_Role = dbo.[User].FK_Role WHERE dbo.[User].PKID = " + GlobalFacade.SystemContext.GetContext().UserID.ToString() + ")";

                DataRoots = new Wicresoft.Session.Session().SqlHelper.ExcuteDataTable(DataRoots,
                "SELECT * FROM Menu WHERE IsLeaf=0 AND IsValid = 1 AND ISNULL(URL,'') = '' AND Parent = 0 AND " + strWhere
                + " ORDER BY [Parent],[DisplayOrder]", CommandType.Text);

                FillMenus(DataRoots);
            }
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Menu));
        }


        #region 填充菜单
        public void FillMenus(DataTable dt)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            M2G.Web.UI.TreeViewNode node;
            foreach (DataRow dr in dt.Rows)
            {
                node = new M2G.Web.UI.TreeViewNode();
                node.Text = dr["ChineseName"].ToString();
                DataTable tempTable = GetMenusForParentID(dr["PKID"].ToString());
                FillNode(node, tempTable);
                TreeView1.Nodes.Add(node);
            }
        }

        public void FillNode(M2G.Web.UI.TreeViewNode tvn, DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 0)
                return;
            else
            {
                M2G.Web.UI.TreeViewNode node;
                foreach (DataRow dr in dt.Rows)
                {
                    node = new M2G.Web.UI.TreeViewNode();
                    node.Text = dr["ChineseName"].ToString();
                    if (dr["URL"].ToString() != string.Empty)
                    {
                        node.Target = "header";
                        node.NavigateUrl = dr["URL"].ToString() + "?menuid=" + dr["PKID"].ToString();
                    }
                    DataTable subTempTable = GetMenusForParentID(dr["PKID"].ToString());
                    FillNode(node, subTempTable);
                    tvn.Nodes.Add(node);
                }
            }
        }

        public DataTable GetMenusForParentID(string parent)
        {
            return new Wicresoft.Session.Session().SqlHelper.ExcuteDataTable(null,
                "SELECT * FROM Menu WHERE IsLeaf=0 AND IsValid = 1 AND [Parent]=" + parent +
                " AND " + strWhere + " ORDER BY [Parent],[DisplayOrder]", CommandType.Text);
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}