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

namespace CWXT.JHSY.CWOneChildAward
{
    public partial class CWOneChildAwardList : EnterpriseWebsite.WebUI.ScrollPage
    {
        private DataTable tblSchema;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ucCustomPaging.LoadData(this.GetLastPageNumber(this.dgCWOneChildAward.UniqueID));
            }
            RegisterButtonClientEvent();
        }

        #region Load Data

        private void BindGrid()
        {
            this.dgCWOneChildAward.DataSource = tblSchema.DefaultView;
            this.dgCWOneChildAward.DataBind();

            // 重绑数据源后，设置选中第一条
            if (this.dgCWOneChildAward.Items.Count > 0)
            {
                (this.dgCWOneChildAward.Items[0].Cells[0].Controls[1] as CheckBox).Checked = true;
            }

            // 设置查询条件描述
            if (this.MyContext.GetPageContext(this.ID).Parms[Enums.Constants.QueryDesc] != null)
                this.lblQueryDesc.Text = this.MyContext.GetPageContext(this.ID).Parms[Enums.Constants.QueryDesc].ToString();
        }

        private void LoadData(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            BusinessRule.JHSY.CWOneChildAward rule = new BusinessRule.JHSY.CWOneChildAward();
            this.tblSchema = rule.GetCWOneChildAwardList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.DESC, this.GetLastQueryCondition(this.dgCWOneChildAward.UniqueID));
            ucCustomPaging.TotalRecords = totalCount;

            this.BindGrid();
        }
        #endregion

        #region Create / Edit / Del / View / Query Clicked
        private void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgCWOneChildAward.Items)
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
                PKID = this.dgCWOneChildAward.Items[selectedIndex].Cells[1].Text;
                Wicresoft.Session.Session session = new Wicresoft.Session.Session();
                BusinessMapping.CWOneChildAward bo = new BusinessMapping.CWOneChildAward();
                bo.SessionInstance = session;

                BusinessFilter filter = new BusinessFilter("CWOneChildAward");
                filter.AddFilterItem("PKID", PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
                bo.AddFilter(filter);
                bo.Load();

                if (bo.HaveRecord)
                {
                    bo.IsValid.Value = false;
                    bo.Update();

                    // Reload Data
                    ucCustomPaging.LoadData(ucCustomPaging.CurrentPage);
                }
            }
        }

        private void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            base.PageTransfer("CWOneChildAwardAdd.aspx");
        }

        private void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgCWOneChildAward.Items)
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
                PKID = this.dgCWOneChildAward.Items[selectedIndex].Cells[1].Text;
                base.PageTransfer("CWOneChildAwardEdit.aspx", Enums.Constants.PKID + "=" + PKID);
            }
        }

        private void btnView_Click(object sender, ImageClickEventArgs e)
        {
            string PKID;
            int selectedIndex = -1;

            foreach (DataGridItem item in this.dgCWOneChildAward.Items)
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
                PKID = this.dgCWOneChildAward.Items[selectedIndex].Cells[1].Text;
                base.PageTransfer("CWOneChildAwardView.aspx", Enums.Constants.PKID + "=" + PKID);
            }
        }

        private bool btnQuery_ButtonClick(object sender, EventArgs e)
        {
            base.ShowQueryWindow("CWOneChildAwardQuery.aspx", this.dgCWOneChildAward.UniqueID, this.btnRefreshData.UniqueID);
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
        private void dgCWOneChildAward_PreRender(object sender, EventArgs e)
        {
            base.DGDbClickTransfer(this.dgCWOneChildAward, "CWOneChildAwardView.aspx");
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
            //this.btnNew.Click += new System.Web.UI.ImageClickEventHandler(this.btnNew_Click);
            //this.btnEdit.Click += new System.Web.UI.ImageClickEventHandler(this.btnEdit_Click);
            //this.btnDel.Click += new System.Web.UI.ImageClickEventHandler(this.btnDel_Click);
            //this.btnView.Click += new System.Web.UI.ImageClickEventHandler(this.btnView_Click);
            this.btnRefreshData.Click += new EventHandler(btnRefreshData_Click);
            this.btnQuery.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnQuery_ButtonClick);
            this.dgCWOneChildAward.PreRender += new EventHandler(dgCWOneChildAward_PreRender);
            //this.btnDel.Attributes.Add("onclick", "return ImgBtnConfirmDelete()");

            // 分页控件初始化
            this.ucCustomPaging.DataLoader = new CustomControls.CustomPaging.LoadDataHandler(this.LoadData);
            this.ucCustomPaging.ControlID = this.dgCWOneChildAward.UniqueID;
        }

        private void InitializeComponent()
        {
        }
        #endregion

        private void RegisterButtonClientEvent()
        {
        }
    }
}
