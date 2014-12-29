namespace CWXT.SystemManage.RoleManage
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

    using Wicresoft.BusinessObject;

    /// <summary>
    ///		Summary description for Role.
    /// </summary>
    public partial class Role : System.Web.UI.UserControl
    {
        #region User Defined
        private int PKID
        {
            get { return (this.Page as EnterpriseWebsite.WebUI.ScrollPage).PKID; }
        }
        #endregion

        #region Set Page Status
        private void SetViewStatus()
        {
            this.tbxRoleCode.ReadOnly = true;
            this.tbxRoleName.ReadOnly = true;
            this.tbxMemo.ReadOnly = true;

            this.tbxRoleCode.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxRoleName.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxMemo.BackColor = Enums.SystemColor.ReadonlyBackColor;
        }

        private void SetEditStatus()
        {

        }

        private void SetCreateStatus()
        {

        }

        private void SetPageStatus(Enums.PageStatus pageStatus)
        {
            switch (pageStatus)
            {
                case Enums.PageStatus.Create:
                    this.SetCreateStatus();
                    break;
                case Enums.PageStatus.Edit:
                    this.SetEditStatus();
                    break;
                case Enums.PageStatus.View:
                    this.SetViewStatus();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Load Data
        public void LoadData(Enums.PageStatus pageStatus)
        {
            this.SetPageStatus(pageStatus);
        }

        public void LoadData(int pkid, Enums.PageStatus pageStatus)
        {
            this.SetPageStatus(pageStatus);
            this.LoadBaseInfo(pkid);
        }

        public void LoadBaseInfo(int pkid)
        {
            BusinessMapping.Role bo = new BusinessMapping.Role();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("Role");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                this.tbxRoleCode.Text = bo.RoleCode.Value;
                this.tbxRoleName.Text = bo.RoleName.Value;
                this.tbxMemo.Text = bo.Memo.Value;
            }
        }
        #endregion

        #region Validate Page
        /// <summary>
        ///	Page的服务端验证
        /// </summary>
        /// <returns>失败 or 成功</returns>
        public bool ValidatePage()
        {
            Page.Validate();
            return Page.IsValid;
        }

        private void valiateRoleCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            BusinessRule.Common rule = new BusinessRule.Common();
            args.IsValid = rule.IsFieldExclusive("RoleCode", this.tbxRoleCode.Text.Trim(), "Role", true, this.PKID);
        }

        private void valiateRoleName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            BusinessRule.Common rule = new BusinessRule.Common();
            args.IsValid = rule.IsFieldExclusive("RoleName", this.tbxRoleName.Text.Trim(), "Role", true, this.PKID);
        }
        #endregion

        #region Save | Update
        public void Save()
        {
            BusinessMapping.Role bo = new BusinessMapping.Role();
            bo.SessionInstance = new Wicresoft.Session.Session();

            bo.RoleCode.Value = this.tbxRoleCode.Text.Trim();
            bo.RoleName.Value = this.tbxRoleName.Text.Trim();
            bo.Memo.Value = this.tbxMemo.Text.Trim();

            bo.CreateTime.Value = bo.ModifyTime.Value = DateTime.Now;
            bo.CreateUser.Value = bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
            bo.Insert();

            //BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
            //rule.WriteOperationLog("用户组管理", "新增用户组");
        }

        public void Update()
        {
            BusinessMapping.Role bo = new BusinessMapping.Role();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("Role");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                bo.RoleCode.Value = this.tbxRoleCode.Text.Trim();
                bo.RoleName.Value = this.tbxRoleName.Text.Trim();
                bo.Memo.Value = this.tbxMemo.Text.Trim();

                bo.ModifyTime.Value = DateTime.Now;
                bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
                bo.Update();

                //BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
                //rule.WriteOperationLog("用户组管理", "编辑用户组");
            }
        }

        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.valiateRoleCode.ServerValidate += new ServerValidateEventHandler(valiateRoleCode_ServerValidate);
            this.valiateRoleName.ServerValidate += new ServerValidateEventHandler(valiateRoleName_ServerValidate);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}
