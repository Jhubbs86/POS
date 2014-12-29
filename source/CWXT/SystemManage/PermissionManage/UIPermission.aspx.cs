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

using Wicresoft.Session;
using Wicresoft.BusinessObject;

namespace CWXT.SystemManage.PermissionManage
{
    public partial class UIPermission : EnterpriseWebsite.WebUI.ScrollPage
    {
        private DataTable tblSchema;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ucCustomPaging.LoadData(this.GetLastPageNumber(this.dgRole.UniqueID));
            }
        }


        #region Load Data
        private void BindGrid()
        {
            this.dgRole.DataSource = tblSchema.DefaultView;
            this.dgRole.DataBind();

            // 重绑数据源后，设置选中第一条
            if (this.dgRole.Items.Count > 0)
            {
                (this.dgRole.Items[0].Cells[0].Controls[1] as CheckBox).Checked = true;
            }
        }

        private void LoadData(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            BusinessRule.SystemManage.Role rule = new BusinessRule.SystemManage.Role();
            this.tblSchema = rule.GetRoleList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.GetLastQueryCondition(this.dgRole.UniqueID));
            ucCustomPaging.TotalRecords = totalCount;

            this.BindGrid();
        }
        #endregion

        private bool btnConfig_ButtonClick(object sender, EventArgs e)
        {
            string RolePKID;
            int selectindex = -1;

            foreach (DataGridItem item in this.dgRole.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (((System.Web.UI.WebControls.RadioButton)item.Cells[0].Controls[1]).Checked)
                    {
                        selectindex = item.ItemIndex;
                        break;
                    }
                }
            }

            if (selectindex == -1)
                return false;

            RolePKID = this.dgRole.Items[selectindex].Cells[1].Text;
            base.PageTransfer("UIPermissionDetail.aspx", Enums.Constants.PKID + "=" + RolePKID);
            return true;
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.btnConfig.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnConfig_ButtonClick);
            this.dgRole.PreRender += new EventHandler(dgRole_PreRender);

            // 分页控件初始化
            this.ucCustomPaging.DataLoader = new CustomControls.CustomPaging.LoadDataHandler(this.LoadData);
            this.ucCustomPaging.ControlID = this.dgRole.UniqueID;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion

        private void dgRole_PreRender(object sender, EventArgs e)
        {
            base.DGDbClickTransfer(this.dgRole, "UIPermissionDetail.aspx");
        }
    }
}