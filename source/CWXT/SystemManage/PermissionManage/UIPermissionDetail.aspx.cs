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

using BusinessRule;
using GlobalFacade;
using BusinessMapping;
using Wicresoft.BusinessObject;
using BusinessRule.SystemManage;

namespace CWXT.SystemManage.PermissionManage
{
    public partial class UIPermissionDetail : EnterpriseWebsite.WebUI.ScrollPage
    {
        public string OutXML;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
                this.SetPageStatus();
                this.BindTree();
            }
           
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMenuRight));

        }

        private void LoadData()
        {
            BusinessFilter filter = new BusinessFilter("Role");
            filter.AddFilterItem("PKID", PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessMapping.Role role = new BusinessMapping.Role();
            role.SessionInstance = new Wicresoft.Session.Session();
            role.AddFilter(filter);
            role.Load();

            if (role.HaveRecord)
            {
                this.tbxRoleCode.Text = role.RoleCode.Value;
                this.tbxRoleName.Text = role.RoleName.Value;
                this.tbxMemo.Text = role.Memo.Value;
            }
        }


        private void SetPageStatus()
        {
            this.tbxRoleCode.ReadOnly = true;
            this.tbxRoleName.ReadOnly = true;
            this.tbxMemo.ReadOnly = true;

            this.tbxRoleCode.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxRoleName.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxMemo.BackColor = Enums.SystemColor.ReadonlyBackColor;
        }

        private void BindTree()
        {
            BusinessRule.SystemManage.UIPermission uiPermission = new BusinessRule.SystemManage.UIPermission();
            uiPermission.RolePKID = this.PKID;

            uiPermission.GenerateMenuTreeXML();
            OutXML = uiPermission.OutXml;
            this.tvFunction.Attributes.Add("oncheck", "OnRegionCheck()");

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
            this.btnReturn.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnReturn_ButtonClick);
            this.btnSaveMenuConfig.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnSaveMenuConfig_ButtonClick);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        private bool btnReturn_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack();
            return false;
        }

        private bool btnSaveMenuConfig_ButtonClick(object sender, EventArgs e)
        {
            base.GoBack();
            return false;
        }
    }
}