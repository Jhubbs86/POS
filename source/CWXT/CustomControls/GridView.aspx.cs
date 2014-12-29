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
using System.Reflection;

using Wicresoft.BusinessObject;

namespace CWXT.CustomControls
{
    /// <summary>
    /// GridView 的摘要说明。
    /// </summary>
    public partial class GridView : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected new string Title;
        protected string GridViewHTML;
        protected string textControlID;
        protected string valueControlID;
        protected string viewObjectGUID;
        protected BusinessObjectView BusinessObjectView;
        public override string UniqueID
        {
            get { return "2904DEA3-81D4-4c0e-A701-862AC8BA7C32"; }
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
            this.btnClose.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClose_ButtonClick);
            this.btnClear.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClear_ButtonClick);
            this.btnQuery.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnQuery_ButtonClick);
            this.ucCustomPaging.DataLoader = new CWXT.CustomControls.CustomPaging.LoadDataHandler(this.LoadData);
            this.ucCustomPaging.ControlID = this.UniqueID;

            ParseParameters();
            AddClientScript();
            SetTitle();
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        #region Toolbar Methods
        private bool btnClear_ButtonClick(object sender, EventArgs e)
        {
            this.ucQueryProvider.ClearQueryStatus();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "__Clear",
                string.Format("<script>SetControlText('{0}','{1}');SetControlText('{2}','{3}');window.close();window.returnValue=true;</script>",
                this.textControlID, string.Empty, this.valueControlID, string.Empty));

            return false;
        }

        private bool btnClose_ButtonClick(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "__CloseWindow", "<script>window.close();window.returnValue=false;</script>");

            // event does not bubble
            return false;
        }

        private bool btnQuery_ButtonClick(object sender, EventArgs e)
        {
            this.ucCustomPaging.LoadData(1);
            return false;
        }
        #endregion

        #region Do Initialization
        private void AddClientScript()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<SCRIPT LANGUAGE='JavaScript'>");
            sb.Append("function SetControlText(ctlID, text)");
            sb.Append("{");
            sb.Append("var parentWnd = window.dialogArguments;");
            sb.Append("parentWnd.document.getElementById(ctlID).value=text;");
            sb.Append("}");
            sb.Append("</SCRIPT>");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "__SetControlText", sb.ToString());
        }

        private void SetTitle()
        {
            this.Title = this.BusinessObjectView.ViewDisplayName;
        }

        private void ParseParameters()
        {
            textControlID = Request.QueryString["textControl"];
            valueControlID = Request.QueryString["valueControl"];
            viewObjectGUID = Request.QueryString["viewObjectGUID"];

            // 优先使用传入的BusinessObjectView，若为NULL则根据ViewName创建
            this.BusinessObjectView = Session[viewObjectGUID] as BusinessObjectView;
            if (this.BusinessObjectView == null)
            {
                BusinessView.Common bv = new BusinessView.Common();
                this.BusinessObjectView = bv.GetBusinessObjectViewFromName(Request.QueryString["viewName"]);
            }
            this.ucQueryProvider.InitQueryProvider(this.BusinessObjectView);
        }
        #endregion

        #region Load Data
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ucCustomPaging.LoadData(1);
            }
        }

        private void BindGrid()
        {
            GridViewHTML = this.GenerateDataGrid(this.BusinessObjectView.tblSchema.DefaultView);
        }

        private void LoadData(int pageNumber, int pageSize)
        {
            BusinessFilter filter = this.ucQueryProvider.GetBusinessFilter();
            filter.AddFilter(this.BusinessObjectView.InitialFilter, AndOr.AND);

            this.BusinessObjectView.CurrentFilter = filter;
            this.ucCustomPaging.TotalRecords = this.BusinessObjectView.LoadData(pageNumber, pageSize);
            this.BindGrid();
        }
        #endregion

        #region Create Paging Grid
        public string GenerateDataGrid(DataView vw)
        {
            if (this.BusinessObjectView != null)
            {
                return string.Format("<table class=\"DGStyle\" sortable=\"true\" cellspacing=\"0\" rules=\"all\" border=\"1\" id=\"{0}\" style=\"border-collapse:collapse;\">{1}{2}</table>",
                    this.UniqueID, GenerateTableHead(), GenerateTableRow(vw));
            }
            else
                return string.Empty;
        }

        private string GenerateTableHead()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<tr class=\"DGHeaderStyle\">");
            sb.Append("<td class=\"DGHeaderCellStyle\" nowrap=\"nowrap\" style=\"width:1%;\">&nbsp;</td>");	// Radio Column

            ViewItemCollection vic = this.BusinessObjectView.VisibleColumnCollection;
            sb.AppendFormat("<td style=\"display:none;\">{0}</td>", vic[0].DisplayName);	// PKID Column

            for (int i = 1; i < vic.Count; i++)
            {
                sb.AppendFormat("<td class=\"DGHeaderCellStyle\">{0}</td>", vic[i].DisplayName);
            }
            sb.Append("</tr>");

            return sb.ToString();
        }

        private string GenerateTableRow(DataView vw)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (vw.Count > 0)
            {
                ViewItemCollection vic = this.BusinessObjectView.VisibleColumnCollection;

                for (int i = 0; i < vw.Count; i++)
                {
                    sb.AppendFormat("<tr class=\"{0}\" onclick=\"SetControlText('{1}', '{2}');SetControlText('{3}','{4}');window.close();window.returnValue=true;\">",
                        (i % 2 == 0) ? "DGItemStyle" : "DGAlternatingItemStyle",
                        this.textControlID, vw[i][this.BusinessObjectView.DisplayField.FieldName].ToString(),
                        this.valueControlID, vw[i][this.BusinessObjectView.PKField.FieldName].ToString());

                    sb.Append("<td><input type=\"radio\" /></td>");		// Radio Column
                    sb.AppendFormat("<td style=\"display:none;\">{0}</td>", vw[i][this.BusinessObjectView.PKField.FieldName].ToString());	// PKID Column

                    for (int j = 1; j < vic.Count; j++)
                    {
                        //						sb.AppendFormat("<td>{0}</td>", GenerateCellControl(vic[j], vw[i][vic[j].FieldName]));
                        sb.AppendFormat("<td>{0}</td>", GenerateCellControl(vic[j], vw[i]));
                    }

                    sb.Append("</tr>");
                }
            }
            return sb.ToString();
        }

        private string GenerateCellControl(ViewItem vi, DataRowView dvw)
        {
            string ctl = string.Empty;

            switch (vi.DisplayType)
            {
                case ViewItemDisplayType.Literal:
                    if (!vi.IsVirtual)
                        ctl = (dvw[vi.FieldName] != DBNull.Value) ? dvw[vi.FieldName].ToString() : string.Empty;
                    else
                        ctl = (dvw[vi.FKFieldName] != DBNull.Value) ? dvw[vi.FKFieldName].ToString() : string.Empty;
                    break;
                case ViewItemDisplayType.SingleObject:
                case ViewItemDisplayType.TreeObject:
                    ctl = (dvw[vi.FKFieldName] != DBNull.Value) ? dvw[vi.FKFieldName].ToString() : string.Empty;
                    break;
                case ViewItemDisplayType.DateTime:
                    if (!vi.IsVirtual)
                        ctl = (dvw[vi.FieldName] != DBNull.Value) ? ((DateTime)dvw[vi.FieldName]).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                    else
                        ctl = (dvw[vi.FKFieldName] != DBNull.Value) ? ((DateTime)dvw[vi.FKFieldName]).ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                    break;
                case ViewItemDisplayType.CheckBox:
                    if (!vi.IsVirtual)
                        ctl = string.Format("<input type=\"checkbox\" {0} onclick=\"return false;\" />", (dvw[vi.FieldName] != DBNull.Value && (bool)dvw[vi.FieldName]) ? "checked=\"checked\"" : string.Empty);
                    else
                        ctl = string.Format("<input type=\"checkbox\" {0} onclick=\"return false;\" />", (dvw[vi.FKFieldName] != DBNull.Value && (bool)dvw[vi.FKFieldName]) ? "checked=\"checked\"" : string.Empty);
                    break;
                default:
                    break;
            }

            return ctl;
        }
        #endregion
    }
}
