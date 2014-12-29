﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CWXT.SystemManage.RoleManage
{
    /// <summary>
    /// EditRole 的摘要说明。
    /// </summary>
    public partial class EditRole : EnterpriseWebsite.WebUI.ScrollPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ucRole.LoadData(this.PKID, Enums.PageStatus.Edit);
            }
        }

        private bool btnSave_ButtonClick(object sender, EventArgs e)
        {
            if (this.ucRole.ValidatePage())
            {
                ucRole.Update();
                base.GoBack("RoleList.aspx");
            }
            return false;
        }

        private bool btnReturn_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack("RoleList.aspx");
            return false;
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
            this.AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.btnSave.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSave_ButtonClick);
            this.btnReturn.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnReturn_ButtonClick);
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
