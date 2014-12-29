using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace EnterpriseWebsite.WebUI
{
    /// <summary>
    /// Summary description for ScrollPage.
    /// </summary>
    public class ScrollPage : Page
    {
        public ScrollPage() { }

        /// <summary>
        /// 页面初始化时，获取上下文信息
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.MyContext = GlobalFacade.SystemContext.GetContext();
            //			this.ApplyStyle();
            this.DisableCache();
            this.ShowMessageOnLoadComplete();
            base.OnInit(e);
        }

        /// <summary>
        /// 当页面呈现完毕后，显示提示信息
        /// </summary>
        private void ShowMessageOnLoadComplete()
        {
            string message = Request.QueryString[CWXT.Enums.Constants.Message];
            if (message != null && message != string.Empty && !this.IsPostBack)
            {
                GlobalFacade.Utils.ShowMessage(Server.HtmlDecode(message));
            }
        }

        /// <summary>
        /// 禁用页面缓存
        /// </summary>
        private void DisableCache()
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
        }


        /// <summary>
        /// 切换用户
        /// </summary>
        public void SwitchUser()
        {
            Server.Transfer(Request.ApplicationPath + "/Logout.aspx?__action=switch");
        }

        #region 页面控件样式控制

        private bool hasUploadControl;

        /// <summary>
        /// 遍例所有控件，应用样式
        /// </summary>
        private void ApplyStyle()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                ApplyControlStyle(this.Controls[i]);
            }
        }

        private void ApplyControlStyle(Control ctl)
        {
            if (ctl.HasControls())
            {
                for (int i = 0; i < ctl.Controls.Count; i++)
                {
                    ApplyControlStyle(ctl.Controls[i]);
                }
            }

            CWXT.CustomControls.Upload uploadCtl = ctl as CWXT.CustomControls.Upload;
            if (uploadCtl != null)
            {
                hasUploadControl = true;
            }

            Microsoft.Web.UI.WebControls.TabStrip tab = ctl as Microsoft.Web.UI.WebControls.TabStrip;
            if (tab != null)
            {
                tab.TabDefaultStyle.CssText = CWXT.Enums.Constants.TabDefaultStyle;
                tab.TabHoverStyle.CssText = CWXT.Enums.Constants.TabHoverStyle;
                tab.TabSelectedStyle.CssText = CWXT.Enums.Constants.TabSelectedStyle;
                return;
            }

            Microsoft.Web.UI.WebControls.Toolbar tlb = ctl as Microsoft.Web.UI.WebControls.Toolbar;
            if (tlb != null && tlb.Items.Count > 0)
            {
                foreach (Microsoft.Web.UI.WebControls.ToolbarItem tlbItem in tlb.Items)
                {
                    Microsoft.Web.UI.WebControls.ToolbarButton tlbBtn = tlbItem as Microsoft.Web.UI.WebControls.ToolbarButton;
                    if (tlbBtn != null)
                    {
                        if (tlbBtn.ID != "btnSaveMenuConfig" && tlbBtn.ID != "btnSaveRegionConfig")
                            tlbBtn.DefaultStyle.CssText = CWXT.Enums.Constants.ToolbarButtonDefaultStyle;

                        tlbBtn.HoverStyle.CssText = CWXT.Enums.Constants.ToolbarButtonHoverStyle;
                        tlbBtn.SelectedStyle.CssText = CWXT.Enums.Constants.ToolbarButtonSelectedStyle;

                        switch (tlbBtn.ID)
                        {
                            case "btnQuery":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/preview.png";
                                break;
                            case "btnClose":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/exit.png";
                                tlbBtn.Text = "&nbsp;取消";
                                tlbBtn.ToolTip = "取消";
                                break;
                            case "btnReturn":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/cancel.gif";
                                break;
                            case "btnSave":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/save.gif";
                                break;
                            case "btnSaveSelection":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/save.gif";
                                break;
                            case "btnSaveAll":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/save.gif";
                                break;
                            case "btnClear":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/delete.gif";
                                break;
                            case "btnRetailSales":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/sales.gif";
                                break;
                            case "btnShopContact":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/smsuser.gif";
                                break;
                            case "btnEdit":
                                tlbBtn.ImageUrl = Request.ApplicationPath + "/image/retailer.gif";
                                break;
                        }
                        continue;
                    }

                    Microsoft.Web.UI.WebControls.ToolbarSeparator tlbSep = tlbItem as Microsoft.Web.UI.WebControls.ToolbarSeparator;
                    if (tlbSep != null)
                    {
                        tlbSep.DefaultStyle.CssText = CWXT.Enums.Constants.ToolbarSeparatorDefaultStyle;
                        continue;
                    }

                    Microsoft.Web.UI.WebControls.ToolbarDropDownList tlbDDL = tlbItem as Microsoft.Web.UI.WebControls.ToolbarDropDownList;
                    if (tlbDDL != null)
                    {
                        tlbDDL.DefaultStyle.CssText = CWXT.Enums.Constants.ToolbarDropdownListDefaultStyle;
                        continue;
                    }

                    Microsoft.Web.UI.WebControls.ToolbarLabel tlbLabel = tlbItem as Microsoft.Web.UI.WebControls.ToolbarLabel;
                    if (tlbLabel != null)
                    {
                        tlbLabel.DefaultStyle.CssText = CWXT.Enums.Constants.ToolbarLabelDefaultStyle;
                        continue;
                    }
                }
                return;
            }


            // DataGrid Style
            DataGrid dg = ctl as DataGrid;
            if (dg != null)
            {
                dg.Attributes.Add("sortable", "true");

                foreach (DataGridColumn dgColumn in dg.Columns)
                {
                    dgColumn.HeaderStyle.CssClass = "DGHeaderCellStyle";
                }
            }
        }
        #endregion

        #region 维护页面状态
        /// <summary>
        /// 系统上下文对象
        /// </summary>
        public GlobalFacade.SystemContext MyContext;

        /// <summary>
        /// 以Page的类名作为Page的ID
        /// </summary>
        public override string ID
        {
            get { return this.GetType().GUID.ToString("N"); }
        }

        /// <summary>
        /// 弹出串口的父窗口
        /// </summary>
        public string OpenerID
        {
            get
            {
                if (Request.QueryString[CWXT.Enums.Constants.PageID] != null)
                    return Request.QueryString[CWXT.Enums.Constants.PageID];
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 要记录状态的数据绑定控件ID
        /// </summary>
        public string ControlID
        {
            get
            {
                if (Request.QueryString[CWXT.Enums.Constants.ControlID] != null)
                    return Request.QueryString[CWXT.Enums.Constants.ControlID];
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 数据对象主键标识
        /// </summary>
        public int PKID
        {
            get { return this.MyContext.GetPageContext(this.ID).PKID; }
        }

        /// <summary>
        /// 获取上次状态页码
        /// </summary>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public int GetLastPageNumber(string controlId)
        {
            int pageNumber = Convert.ToInt32(this.MyContext.GetPageContext(this.ID).LastPageNumber[controlId]);
            return (pageNumber > 0) ? pageNumber : 1;
        }

        /// <summary>
        /// 获取上次状态查询条件
        /// </summary>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public Wicresoft.BusinessObject.BusinessFilter GetLastQueryCondition(string controlId)
        {
            return this.MyContext.GetPageContext(this.ID).LastQueryCondition[controlId] as Wicresoft.BusinessObject.BusinessFilter;
        }

        /// <summary>
        /// 获取上次状态排序表达式
        /// </summary>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public string GetLastSortExpression(string controlId)
        {
            return this.MyContext.GetPageContext(this.ID).LastSortExpression[controlId];
        }

        /// <summary>
        /// 保存页面状态
        /// </summary>
        /// <param name="lastPageNumber">页码</param>
        /// <param name="lastQueryCondition">查询条件</param>
        public void SavePageStatus(string controlId, int lastPageNumber)
        {
            GlobalFacade.PageContext ctx = this.MyContext.GetPageContext(this.ID);
            ctx.LastPageNumber[controlId] = lastPageNumber.ToString();
            //			ctx.LastQueryCondition[controlId] = lastQueryCondition;
            //			ctx.LastSortExpression[controlId] = lastSortExpression;

            this.MyContext.SavePageContext(this.ID, ctx);
            GlobalFacade.SystemContext.SaveContext(this.MyContext);
        }
        #endregion

        #region 显示弹出窗口
        /// <summary>
        /// 显示查询窗口（Popup）
        /// </summary>
        /// <remarks>
        /// __level = 1指示该页面需要记录查询状态（QueryProvider中有具体设定）
        /// </remarks>
        public void ShowQueryWindow(string page, string srcControlId, string refreshControlId)
        {
            string script = "<script language='javascript'>if(OpenModalDialog('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "&" + "__level" + "=1" + "')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }

        public void ShowQueryWindow(string page, string srcControlId, string refreshControlId, string queryString)
        {
            string script = "<script language='javascript'>if(OpenModalDialog('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "&" + "__level" + "=1" + "&" + queryString + "')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }

        /// <summary>
        /// 显示明细添加窗口（Popup）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="srcControlId"></param>
        /// <param name="refreshControlId"></param>
        public void ShowAddSubItemWindow(string page, string srcControlId, string refreshControlId)
        {
            //			this.ShowQueryWindow(page, srcControlId, refreshControlId);
            string script = "<script language='javascript'>if(OpenModalDialog('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }

        /// <summary>
        /// 显示明细添加窗口（Open）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="srcControlId"></param>
        /// <param name="refreshControlId"></param>
        public void OpenAddSubItemWindow(string page, string srcControlId, string refreshControlId, string queryString)
        {
            string script = "<script language='javascript'>if(window.open('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "&" + queryString + "',null,'top = 223, left = 280, height=520,width=710,status=no,toolbar=no,menubar=no,location=no')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }

        /// <summary>
        /// 弹出自定义窗口（可最大化，有滚动条）（Open）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="srcControlId"></param>
        /// <param name="refreshControlId"></param>
        public void OpenCustomWindow(string page, string srcControlId, string refreshControlId, string queryString)
        {
            string script = "<script language='javascript'>if(window.open('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "&" + queryString + "',null,'height=450, width=800, top=140,left=300,toolbar=no, menubar=no, scrollbars=yes,location=no,resizable=yes, status=no')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }


        public void ShowAddSubItemWindow(string page, string srcControlId, string refreshControlId, string queryString)
        {
            //			this.ShowQueryWindow(page, srcControlId, refreshControlId, queryString);
            string script = "<script language='javascript'>if(OpenModalDialog('" + page + "?" + CWXT.Enums.Constants.PageID + "=" + this.ID + "&" + CWXT.Enums.Constants.ControlID + "=" + srcControlId + "&" + queryString + "')){__doPostBack('" + refreshControlId + "','');}</script>";
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), this.Page.GetHashCode().ToString(), script);
        }
        #endregion

        #region 当页面滚动时，记录页面位置
        private bool _useScrollPersistence = true;
        /// <summary>
        /// There could be PostBack senarios where we do not want to remember the scroll position. Set this property to false
        /// if you would like the page to forget the current scroll position
        /// </summary>
        public bool UseScrollPersistence
        {
            get { return this._useScrollPersistence; }
            set { this._useScrollPersistence = value; }
        }

        private string _bodyID;
        /// <summary>
        /// Some pages might already have the ID attribute set for the body tag. Setting this property will not render the ID or change
        /// the existing value. It will simply update the javascript written out to the browser.
        /// </summary>
        public string BodyID
        {
            get { return this._bodyID; }
            set { this._bodyID = value; }
        }


        //Last chance. Do we want to maintain the current scroll position
        //Alex 2008-07-28
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            for (int i = 0; i < this.Controls.Count; i++)
            {
                FindDataGrid(this.Controls[i]);
            }
        }
        private void FindDataGrid(Control ctl)
        {
            if (ctl.HasControls())
            {
                for (int i = 0; i < ctl.Controls.Count; i++)
                {
                    FindDataGrid(ctl.Controls[i]);
                }
            }

            DataGrid dg = ctl as DataGrid;
            if (dg != null)
            {
                if (dg.UniqueID == "2904DEA3-81D4-4c0e-A701-862AC8BA7C32" || dg.UniqueID == "2F5872A8-BF33-4f43-8845-9469DAD8F2B6")
                {
                    return;
                }
                if (!IsPostBack)
                {
                    MatchDataGrid(dg);
                }
                SaveDataGrid(dg);
            }
        }
        //匹配
        private void MatchDataGrid(DataGrid dgO)
        {
            string strLastSelectedRecord = string.Empty;
            //			System.Collections.Specialized.StringDictionary coll = GlobalFacade.SystemContext.GetContext().GetPageContext(this.Page.ID).LastSelectedRecord;
            //			if(coll != null)
            //			{
            //				string cachedLastSelectedRecord = coll[dgO.UniqueID];
            //				if(cachedLastSelectedRecord != null && cachedLastSelectedRecord != string.Empty)
            //					strLastSelectedRecord = cachedLastSelectedRecord;
            //			}
            if (Session[dgO.UniqueID + this.Page.ID] != null && Session[dgO.UniqueID + this.Page.ID].ToString() != string.Empty)
            {
                strLastSelectedRecord = Session[dgO.UniqueID + this.Page.ID].ToString();
            }
            if (strLastSelectedRecord == string.Empty)
            {
                return;
            }
            System.Web.UI.WebControls.DataGrid dg = dgO;
            for (int j = 0; j < dg.Items.Count; j++)
            {
                (dg.Items[j].Cells[0].Controls[1] as CheckBox).Checked = false;
            }
            bool flag = false;
            string tempPKID = string.Empty;
            for (int j = 0; j < dg.Items.Count; j++)
            {
                if (strLastSelectedRecord.IndexOf("'" + dg.Items[j].Cells[1].Text + "'") != -1)
                {
                    if (dg.Items[j].Cells[1].Text == tempPKID)
                    {
                        continue;
                    }
                    else
                    {
                        (dg.Items[j].Cells[0].Controls[1] as CheckBox).Checked = true;
                        flag = true;
                        tempPKID = dg.Items[j].Cells[1].Text;
                    }
                }
            }
            if (!flag)
            {
                if (dg.Items.Count > 0)
                {
                    (dg.Items[0].Cells[0].Controls[1] as CheckBox).Checked = true;
                }
            }
        }
        //保存
        private void SaveDataGrid(DataGrid dgO)
        {
            //			GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext((this.Page as EnterpriseWebsite.WebUI.ScrollPage).ID);
            string strLastSelectedRecord = string.Empty;
            //			System.Collections.Specialized.StringDictionary coll = GlobalFacade.SystemContext.GetContext().GetPageContext(this.Page.ID).LastSelectedRecord;
            //			if(coll != null)
            //			{
            //				string cachedLastSelectedRecord = coll[dgO.UniqueID];
            //				if(cachedLastSelectedRecord != null && cachedLastSelectedRecord != string.Empty)
            //					strLastSelectedRecord = cachedLastSelectedRecord;
            //			}
            if (Session[dgO.UniqueID + this.Page.ID] != null && Session[dgO.UniqueID + this.Page.ID].ToString() != string.Empty)
            {
                strLastSelectedRecord = Session[dgO.UniqueID + this.Page.ID].ToString();
            }
            System.Web.UI.WebControls.DataGrid dg = dgO;
            strLastSelectedRecord = string.Empty;
            for (int j = 0; j < dg.Items.Count; j++)
            {
                if ((dg.Items[j].Cells[0].Controls[1] as CheckBox).Checked)
                {
                    if (strLastSelectedRecord.IndexOf("'" + dg.Items[j].Cells[1].Text + "'") != -1)
                    {
                        continue;
                    }
                    else if (strLastSelectedRecord == string.Empty)
                    {
                        strLastSelectedRecord += dg.Items[j].Cells[1].Text;
                    }
                    else
                    {
                        strLastSelectedRecord += "," + dg.Items[j].Cells[1].Text;
                    }
                }
            }
            Session[dgO.UniqueID + this.Page.ID] = "'" + strLastSelectedRecord + "'";
            //			pgCtx.LastSelectedRecord[dgO.UniqueID] = strLastSelectedRecord;
            //			GlobalFacade.SystemContext.GetContext().SavePageContext((this.Page as EnterpriseWebsite.WebUI.ScrollPage).ID, pgCtx);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (UseScrollPersistence)
            {
                RetainScrollPosition();
            }
            this.ApplyStyle();
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //No need processing the HTML if the user does not want to maintain scroll position or already has
            //set the body ID value
            if (UseScrollPersistence && BodyID == null)
            {
                TextWriter tempWriter = new StringWriter();
                base.Render(new HtmlTextWriter(tempWriter));

                string tempHtml = Regex.Replace(tempWriter.ToString(), "<body", "<body id=\"thebody\" ", RegexOptions.IgnoreCase);
                tempHtml = Regex.Replace(tempHtml, "</head>",
                    "<script language=\"javascript\" src=\"SortTable.js.aspx\" defer></script>" +
                    "<script language=\"javascript\" src=\"PageScript.js.aspx\"></script>" +
                    "<script language=\"javascript\" src=\"../../Resources/DatePicker/WdatePicker.js\"></script>" +
                    "<script language=\"javascript\" src=\"Calendar30.js.aspx\"></script>" +
                    "<LINK href=\"CustomerSiteStyle.css.aspx\" rel=\"stylesheet\">" +
                    "</head>",
                    RegexOptions.IgnoreCase);

                if (hasUploadControl)
                    tempHtml = Regex.Replace(tempHtml, "<form",
                        "<form enctype=\"multipart/form-data\"",
                        RegexOptions.IgnoreCase);

                //Alex  2008-07-24
                tempHtml = Regex.Replace(tempHtml, "</body>", "</body><script language=\"javascript\" type=\"text/javascript\">dgLoad();</script>", RegexOptions.IgnoreCase);

                writer.Write(tempHtml);
            }
            else
            {
                base.Render(writer);
            }
        }

        private static string saveScrollPosition = "<script language='javascript'>function saveScrollPosition() {{document.forms[0].__SCROLLPOS.value = {0}.scrollTop;}}{0}.onscroll=saveScrollPosition;</script>";
        private static string setScrollPosition = "<script language='javascript'>function setScrollPosition() {{{0}.scrollTop =\"{1}\";}}{0}.onload=setScrollPosition;</script>";

        //Write out javascript and hidden field
        private void RetainScrollPosition()
        {
            ClientScript.RegisterHiddenField("__SCROLLPOS", "0");
            string __bodyID = BodyID == null ? "thebody" : BodyID;
            ClientScript.RegisterStartupScript(this.GetType(), "saveScroll", string.Format(saveScrollPosition, __bodyID));

            if (Page.IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "setScroll", string.Format(setScrollPosition, __bodyID, Request.Form["__SCROLLPOS"]));
            }
        }
        #endregion

        #region 返回上一页面
        /// <summary>
        /// Go back to the coming url
        /// </summary>
        protected virtual void GoBack()
        {
            if (this.Request.QueryString[CWXT.Enums.Constants.UrlReferrer] != null)
                Response.Redirect(this.Request.QueryString[CWXT.Enums.Constants.UrlReferrer]);
        }

        /// <summary>
        /// Go back to the given url
        /// </summary>
        /// <param name="destUrl"></param>
        protected virtual void GoBack(string destUrl)
        {
            Response.Redirect(destUrl);
        }
        #endregion

        #region 页面切换
        /// <summary>
        /// Transfer the page to an url(without queryString)
        /// </summary>
        /// <param name="destUrl">url to transfer to</param>
        internal virtual void PageTransfer(string destUrl)
        {
            Response.Redirect(string.Format("{2}?{0}={1}", CWXT.Enums.Constants.UrlReferrer, this.Request.Url.AbsolutePath, destUrl));
        }

        /// <summary>
        /// Transfer the page to an url(with queryString)
        /// </summary>
        /// <param name="destUrl">url to transfer to</param>
        /// <param name="queryString">QueryString like this: param1=a&param2=b&param3=c</param>
        internal virtual void PageTransfer(string destUrl, string queryString)
        {
            Response.Redirect(string.Format("{2}?{0}={1}&{3}", CWXT.Enums.Constants.UrlReferrer, this.Request.Url.AbsolutePath, destUrl, queryString));
        }
        #endregion

        #region 双击DataGrid显示View视图
        /// <summary>
        /// Add DataGrid DbClick EventHandler(without queryString, page transfer, no popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        public virtual void DGDbClickTransfer(DataGrid srcDG, string destUrl)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick('{2}?{0}={1}&{3}={4}','{5}','{6}')",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }

        /// <summary>
        /// Add DataGrid DbClick EventHandler(with queryString, page transfer, no popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        /// <param name="queryString">QueryString like this: param1=a&param2=b&param3=c</param>
        public virtual void DGDbClickTransfer(DataGrid srcDG, string destUrl, string queryString)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick('{2}?{0}={1}&{3}&{4}={5}','{6}',{7})",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            queryString,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }

        /// <summary>
        /// Add DataGrid DbClick EventHandler(without queryString, popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        public virtual void DGDbClickTransfer_Popup(DataGrid srcDG, string destUrl)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick_Popup('{2}?{0}={1}&{3}={4}','{5}','{6}')",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }


        /// <summary>
        /// Add DataGrid DbClick EventHandler(without queryString, popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        public virtual void DGDbClickTransfer_Popup_Refresh(DataGrid srcDG, string refreshControlId, string destUrl)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick_Popup_Refresh('{2}?{0}={1}&{3}={4}', '{5}','{6}','{7}')",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            refreshControlId,
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }

        /// <summary>
        /// ccfollowup allen
        /// </summary>
        /// <param name="srcDG"></param>
        /// <param name="refreshControlId"></param>
        /// <param name="destUrl"></param>
        /// <param name="querystring"></param>
        public virtual void DGDbClickTransfer_Popup_Refresh(DataGrid srcDG, string refreshControlId, string destUrl, string querystring)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick_Popup_Refresh('{2}?{0}={1}&{3}={4}&{6}', '{5}','{7}','{8}')",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            refreshControlId,
                            querystring,
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }

        /// <summary>
        /// Add DataGrid DbClick EventHandler(with queryString, popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        /// <param name="queryString">QueryString like this: param1=a&param2=b&param3=c</param>
        public virtual void DGDbClickTransfer_Popup(DataGrid srcDG, string destUrl, string queryString)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick",
                            string.Format("dgItemOnDbClick_Popup1('{2}?{0}={1}&{3}&{4}={5}','{6}','{7}')",
                            CWXT.Enums.Constants.UrlReferrer,
                            this.Request.Url.AbsolutePath,
                            destUrl,
                            queryString,
                            CWXT.Enums.Constants.PKID,
                            dvw[dgItem.ItemIndex]["PKID"],
                            srcDG.UniqueID + this.Page.ID,
                            dvw[dgItem.ItemIndex]["PKID"]));
                    }
                }
            }
        }
        /// <summary>
        /// Add DataGrid DbClick EventHandler(with queryString, popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        /// <param name="queryString">QueryString like this: param1=a&param2=b&param3=c</param>
        public virtual void DGDbClickTransfer_PopupByOPEN(DataGrid srcDG, string destUrl)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                string queryString = string.Empty;
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    queryString = "";
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        queryString += "&versionId=" + dvw[dgItem.ItemIndex]["PKID"];
                        queryString += "&month=" + Convert.ToDateTime(dvw[dgItem.ItemIndex]["CreateTime"].ToString()).Month;
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick", "dgItemOnDbClick_Popup1('" + destUrl + queryString + "')");
                    }
                }
            }
        }

        /// <summary>
        /// Add DataGrid DbClick EventHandler(with queryString, popup window)
        /// </summary>
        /// <param name="srcDG">DataGrid instance</param>
        /// <param name="destUrl">which url to transfer to</param>
        /// <param name="queryString">QueryString like this: param1=a&param2=b&param3=c</param>
        public virtual void DGDbClickTransfer_PopupByOPEN1(DataGrid srcDG, string destUrl)
        {
            System.Data.DataView dvw = srcDG.DataSource as System.Data.DataView;
            if (dvw != null)
            {
                string queryString = string.Empty;
                foreach (DataGridItem dgItem in srcDG.Items)
                {
                    queryString = "";
                    if (dgItem.ItemType == ListItemType.Item || dgItem.ItemType == ListItemType.AlternatingItem)
                    {
                        queryString += "&versionId=" + dvw[dgItem.ItemIndex]["PKID"];
                        queryString += "&year=" + dvw[dgItem.ItemIndex]["FiscalYear"];
                        dgItem.Attributes.Add("title", CWXT.Enums.Constants.DGItemAlterText);
                        dgItem.Attributes.Add("ondblclick", "dgItemOnDbClick_Popup1('" + destUrl + queryString + "')");
                    }
                }
            }
        }

        #endregion
    }
}