using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;

namespace CWXT.CustomControls
{
    public partial class CustomPaging : System.Web.UI.UserControl
    {
        #region Public Properties
        public int TotalPages
        {
            get { return int.Parse(this.lblTotalPages.Text); }
            set { this.lblTotalPages.Text = value.ToString(); }
        }
        public int CurrentPage
        {
            get { return int.Parse(this.lblCurrentPage.Text); }
            set { this.lblCurrentPage.Text = value.ToString(); }
        }
        public int NewPage
        {
            get
            {
                // 全角转换成半角
                this.tbxNewPage.Text = GlobalFacade.Utils.SBCToDBC(this.tbxNewPage.Text);

                if (System.Text.RegularExpressions.Regex.IsMatch(this.tbxNewPage.Text.Trim(), @"^[\d]+\.[\d]*$"))
                    this.tbxNewPage.Text = Convert.ToInt32(Convert.ToDouble(this.tbxNewPage.Text.Trim())).ToString();
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.tbxNewPage.Text.Trim(), @"^[\d]+$"))
                    this.tbxNewPage.Text = "1";
                if (Convert.ToInt32(this.tbxNewPage.Text) > this.TotalPages)
                    this.tbxNewPage.Text = this.TotalPages.ToString();
                if (Convert.ToInt32(this.tbxNewPage.Text) < 1)
                    this.tbxNewPage.Text = "1";

                return int.Parse(this.tbxNewPage.Text);
            }
        }

        public int PageSize
        {
            get
            {
                System.Collections.Specialized.StringDictionary coll = GlobalFacade.SystemContext.GetContext().GetPageContext(this.Page.ID).LastPageSize;
                if (coll != null)
                {
                    string cachedPageSize = coll[this.ControlID];
                    if (cachedPageSize != null && cachedPageSize != string.Empty && (this.tbxDefaultPageSize.Text == string.Empty || cachedPageSize == this.tbxDefaultPageSize.Text))
                        this.tbxDefaultPageSize.Text = cachedPageSize;
                }

                // 全角转换成半角
                this.tbxDefaultPageSize.Text = GlobalFacade.Utils.SBCToDBC(this.tbxDefaultPageSize.Text);

                if (System.Text.RegularExpressions.Regex.IsMatch(this.tbxDefaultPageSize.Text.Trim(), @"^[\d]+\.[\d]*$"))
                    this.tbxDefaultPageSize.Text = Convert.ToInt32(Convert.ToDouble(this.tbxDefaultPageSize.Text.Trim())).ToString();
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.tbxDefaultPageSize.Text.Trim(), @"^[\d]+$"))
                    this.tbxDefaultPageSize.Text = Enums.Constants.PageSize.ToString();
                if (this.tbxDefaultPageSize.Text == string.Empty)
                    this.tbxDefaultPageSize.Text = Enums.Constants.PageSize.ToString();
                if (Convert.ToInt32(this.tbxDefaultPageSize.Text.Trim()) < 1)
                    this.tbxDefaultPageSize.Text = Enums.Constants.PageSize.ToString();

                this.tbxDefaultPageSize.Text = GlobalFacade.Utils.SBCToDBC(this.tbxDefaultPageSize.Text.Trim());

                GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext(this.Page.ID);
                pgCtx.LastPageSize[this.ControlID] = this.tbxDefaultPageSize.Text;
                GlobalFacade.SystemContext.GetContext().SavePageContext(this.Page.ID, pgCtx);

                if (int.Parse(this.tbxDefaultPageSize.Text) > 200)
                {
                    this.tbxDefaultPageSize.Text = "200";
                    return 200;
                }
                else
                    return int.Parse(this.tbxDefaultPageSize.Text);
            }
            set
            {
                if (value > 200)
                    value = 200;
                else if (value < 1)
                    value = Enums.Constants.PageSize;
                this.tbxDefaultPageSize.Text = value.ToString();

                GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext((this.Page as EnterpriseWebsite.WebUI.ScrollPage).ID);
                pgCtx.LastPageSize[this.ControlID] = value.ToString();
                GlobalFacade.SystemContext.GetContext().SavePageContext((this.Page as EnterpriseWebsite.WebUI.ScrollPage).ID, pgCtx);
            }
        }

        public int TotalRecords
        {
            get { return int.Parse(this.lblTotalRecords.Text); }
            set { this.lblTotalRecords.Text = value.ToString(); }
        }

        public delegate void LoadDataHandler(int pageNumber, int pageSize);
        /// <summary>
        /// 加载数据委托对象，由调用页面实现
        /// </summary>
        public LoadDataHandler DataLoader;


        /// <summary>
        /// 所绑定控件的UniqueID
        /// </summary>
        public string ControlID = string.Empty;
        #endregion

        #region Web Form Designer generated code

        protected override void OnPreRender(EventArgs e)
        {
            if (this.TotalRecords <= 0)
                this.lblRecordDesc.Visible = false;
            else
            {
                int startRecord, endRecord;

                startRecord = (this.CurrentPage - 1) * this.PageSize + 1;
                endRecord = (this.CurrentPage == this.TotalPages) ? this.TotalRecords : startRecord + this.PageSize - 1;

                this.lblRecordDesc.Text = string.Format("显示第 <b>{0}</b> 至 <b>{1}</b> 条&nbsp;&nbsp;", startRecord, endRecord);
                this.lblRecordDesc.Visible = true;
            }
            base.OnPreRender(e);
        }



        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        #region Fire the Event
        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            LoadData(this.CurrentPage);
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage--;
            LoadData(this.CurrentPage);
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage++;
            LoadData(this.CurrentPage);
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.TotalPages;
            LoadData((this.CurrentPage == 0) ? 1 : this.CurrentPage);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (this.NewPage > this.TotalPages)
                this.CurrentPage = this.TotalPages;
            else if (this.NewPage < 1)
                this.CurrentPage = 1;
            else
                this.CurrentPage = this.NewPage;

            LoadData((this.CurrentPage == 0) ? 1 : this.CurrentPage);
        }

        protected void tbxNewPage_TextChanged(object sender, EventArgs e)
        {
            btnGo_Click(sender, e);
        }
        #endregion

        #region Load Data
        public void LoadData(int pageNumber)
        {
            //保存选中PKID Alex 2008-07-25
            if (Page.IsPostBack)
            {
                for (int k = 0; k < this.Page.Controls.Count; k++)
                {
                    for (int i = 0; i < this.Page.Controls[k].Controls.Count; i++)
                    {
                        if (this.Page.Controls[k].Controls[i].UniqueID == this.ControlID)
                        {
                            string strLastSelectedRecord = string.Empty;
                            Session[this.ControlID + this.Page.ID] = strLastSelectedRecord;
                        }
                    }
                }
            }

            DataLoader(pageNumber, this.PageSize);

            this.TotalPages = Convert.ToInt32(Math.Ceiling(this.TotalRecords * 1.0 / this.PageSize));

            if (this.TotalRecords > 0)
            {
                if (this.TotalPages >= pageNumber)
                    this.CurrentPage = pageNumber;
                else
                {
                    this.CurrentPage = this.TotalPages;
                    DataLoader(this.CurrentPage, this.PageSize);
                }
            }
            else
                this.CurrentPage = 0;
            //			this.CurrentPage = (this.TotalRecords > 0)?pageNumber:0;
            CheckNavigateButtonStatus();

            // Save Page Status
            (this.Page as EnterpriseWebsite.WebUI.ScrollPage).SavePageStatus(this.ControlID, this.CurrentPage);
        }

        public void LoadData()
        {
            LoadData(this.CurrentPage);
        }

        private void CheckNavigateButtonStatus()
        {
            if (this.TotalPages == 0 || (this.CurrentPage == 1 && this.TotalPages == 1))	// 0 page or 1 page
            {
                this.btnPrevPage.Enabled = false;
                this.btnNextPage.Enabled = false;
            }
            else if (this.CurrentPage == 1)	// first page, previous page disabled
            {
                this.btnPrevPage.Enabled = false;
                this.btnNextPage.Enabled = true;
            }
            else if (this.CurrentPage == this.TotalPages)	// last page, next page disabled
            {
                this.btnPrevPage.Enabled = true;
                this.btnNextPage.Enabled = false;
            }
            else
            {
                this.btnPrevPage.Enabled = true;
                this.btnNextPage.Enabled = true;
            }
        }
        #endregion
    }
}