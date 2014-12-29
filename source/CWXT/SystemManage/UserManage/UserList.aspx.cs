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

namespace CWXT.SystemManage.UserManage
{
    /// <summary>
    /// UserListM 的摘要说明。
    /// </summary>
    public partial class UserList : EnterpriseWebsite.WebUI.ScrollPage
    {
        private DataTable tblSchema;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ucCustomPaging.LoadData(this.GetLastPageNumber(this.dgUser.UniqueID));
            }
        }

        #region Load Data

        private void BindGrid()
        {
            this.dgUser.DataSource = tblSchema.DefaultView;
            this.dgUser.DataBind();

            // 重绑数据源后，设置选中第一条
            if (this.dgUser.Items.Count > 0)
            {
                (this.dgUser.Items[0].Cells[0].Controls[1] as CheckBox).Checked = true;
            }

            // 设置查询条件描述
            string queryDesc = this.MyContext.GetPageContext(this.ID).Parms[Enums.Constants.QueryDesc] as string;
            if (queryDesc != null && queryDesc != string.Empty)
                this.lblQueryDesc.Text = queryDesc;
            else
            {
                //this.lblQueryDesc.Text = "默认不显示数据";
                this.lblQueryDesc.Text = "";
            }
        }

        private void LoadData(int pageNumber, int pageSize)
        {
            //BusinessFilter filter = new BusinessFilter("User");

            //if (this.GetLastQueryCondition(this.dgUser.UniqueID) != null && this.GetLastQueryCondition(this.dgUser.UniqueID).Filter.ToString() != string.Empty && this.GetLastQueryCondition(this.dgUser.UniqueID).Filter.ToString().Trim() != "AND (1=1")
            //{
            //    filter.AddFilter(this.GetLastQueryCondition(this.dgUser.UniqueID), AndOr.AND);
            //}

            int totalCount = 0;
            BusinessRule.SystemManage.User rule = new BusinessRule.SystemManage.User();
            //if (filter.Filter.Trim() == "AND (1=1" || ((filter.Filter == null || filter.Filter == string.Empty) && (filter.CustomFilter == null || filter.CustomFilter == string.Empty)))
            //{
            //    filter.AddFilterItem("PKID", "-1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            //}
            this.tblSchema = rule.GetUserList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.GetLastQueryCondition(this.dgUser.UniqueID));
            ucCustomPaging.TotalRecords = totalCount;

            this.BindGrid();
        }
        #endregion

        #region Create / Edit / Del / View / Query Clicked
        private void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgUser.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (((System.Web.UI.WebControls.RadioButton)item.Cells[0].Controls[1]).Checked)
                    {
                        selectedIndex = item.ItemIndex;
                        break;
                    }
                }
            }

            if (selectedIndex != -1)
            {
                PKID = this.dgUser.Items[selectedIndex].Cells[1].Text;
                Wicresoft.Session.Session session = new Wicresoft.Session.Session();
                BusinessMapping.User bo = new BusinessMapping.User();
                bo.SessionInstance = session;

                BusinessFilter filter = new BusinessFilter("User");
                filter.AddFilterItem("PKID", PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
                bo.AddFilter(filter);
                bo.Load();

                if (bo.IsReserved.Value)
                {
                    GlobalFacade.Utils.ShowMessage(Enums.Constants.RecordReserved);
                }
                else
                {
                    bo.ModifyUser.Value = this.MyContext.UserID;
                    bo.ModifyTime.Value = DateTime.Now;
                    bo.IsValid.Value = false;
                    bo.Update();

                    //BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
                    //rule.WriteOperationLog("用户信息管理", "删除用户信息");

                    // Reload Data
                    ucCustomPaging.LoadData(ucCustomPaging.CurrentPage);
                }
            }
        }

        private void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            base.PageTransfer("CreateUser.aspx");
        }

        private void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgUser.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (((System.Web.UI.WebControls.RadioButton)item.Cells[0].Controls[1]).Checked)
                    {
                        selectedIndex = item.ItemIndex;
                        break;
                    }
                }
            }

            if (selectedIndex != -1)
            {
                PKID = this.dgUser.Items[selectedIndex].Cells[1].Text;
                base.PageTransfer("EditUser.aspx", Enums.Constants.PKID + "=" + PKID);
            }
        }

        private void btnView_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgUser.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (((System.Web.UI.WebControls.RadioButton)item.Cells[0].Controls[1]).Checked)
                    {
                        selectedIndex = item.ItemIndex;
                        break;
                    }
                }
            }

            if (selectedIndex != -1)
            {
                PKID = this.dgUser.Items[selectedIndex].Cells[1].Text;
                base.PageTransfer("ViewUser.aspx", Enums.Constants.PKID + "=" + PKID);
            }
        }

        private bool btnQuery_ButtonClick(object sender, EventArgs e)
        {
            base.ShowQueryWindow("QueryUser.aspx", this.dgUser.UniqueID, this.btnRefreshData.UniqueID);
            return false;
        }

        private bool btnModifyUserPasssword_ButtonClick(object sender, EventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgUser.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    if (((System.Web.UI.WebControls.RadioButton)item.Cells[0].Controls[1]).Checked)
                    {
                        selectedIndex = item.ItemIndex;
                        break;
                    }
                }
            }

            if (selectedIndex != -1)
            {
                PKID = this.dgUser.Items[selectedIndex].Cells[1].Text;
                base.PageTransfer("AdminModifyPassword.aspx", Enums.Constants.PKID + "=" + PKID);
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Refresh DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            ucCustomPaging.LoadData(1);
        }

        /// <summary>
        /// Add DataGrid DoubleClick Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUser_PreRender(object sender, EventArgs e)
        {
            base.DGDbClickTransfer(this.dgUser, "ViewUser.aspx");
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
            this.btnNew.Click += new System.Web.UI.ImageClickEventHandler(this.btnNew_Click);
            this.btnEdit.Click += new System.Web.UI.ImageClickEventHandler(this.btnEdit_Click);
            this.btnDel.Click += new System.Web.UI.ImageClickEventHandler(this.btnDel_Click);
            this.btnView.Click += new System.Web.UI.ImageClickEventHandler(this.btnView_Click);
            this.btnRefreshData.Click += new EventHandler(btnRefreshData_Click);
            this.btnQuery.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnQuery_ButtonClick);
            this.btnModifyUserPasssword.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnModifyUserPasssword_ButtonClick);
            this.dgUser.PreRender += new EventHandler(dgUser_PreRender);
            this.btnDel.Attributes.Add("onclick", "return ImgBtnConfirmDelete()");

            // 分页控件初始化
            this.ucCustomPaging.DataLoader = new CustomControls.CustomPaging.LoadDataHandler(this.LoadData);
            this.ucCustomPaging.ControlID = this.dgUser.UniqueID;
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
