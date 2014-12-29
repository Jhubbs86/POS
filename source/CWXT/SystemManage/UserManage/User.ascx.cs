using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Wicresoft.BusinessObject;

namespace CWXT.SystemManage.UserManage
{
    /// <summary>
    ///		Summary description for User.
    /// </summary>
    public partial class User : System.Web.UI.UserControl
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
            this.tbxAlias.ReadOnly = true;
            this.tbxChineseName.ReadOnly = true;
            this.tbxEnglishName.ReadOnly = true;
            this.rbtnGender.Enabled = false;
            this.cbxIsActive.Enabled = false;
            this.gpRole.Readonly = true;
            this.tbxTitle.ReadOnly = true;
            this.tbxMobile.ReadOnly = true;
            this.tbxEmail.ReadOnly = true;
            this.tbxAddress.ReadOnly = true;
            this.tbxBirthday.ReadOnly = true;
            this.tbxMemo.ReadOnly = true;

            this.rbtnGender.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxAlias.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxChineseName.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxEnglishName.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxTitle.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxMobile.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxEmail.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxAddress.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxBirthday.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxMemo.BackColor = Enums.SystemColor.ReadonlyBackColor;
            this.tbxBirthday.Attributes.Remove("onfocus");
        }

        private void SetEditStatus()
        {
            this.tbxAlias.ReadOnly = true;
        }

        private void SetCreateStatus()
        {
            this.cbxIsActive.Checked = true;
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
            this.LoadBaseInfo(pkid);
            this.SetPageStatus(pageStatus);
        }

        public void LoadBaseInfo(int pkid)
        {
            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                // 显示基本信息
                PresnetUI(bo);
            }
        }

        /// <summary>
        /// 呈现用户对象
        /// </summary>
        /// <param name="bo"></param>
        private void PresnetUI(BusinessMapping.User bo)
        {
            this.tbxAlias.Text = bo.Alias.Value;
            this.tbxChineseName.Text = bo.ChineseName.Value;
            this.tbxEnglishName.Text = bo.EnglishName.Value;
            this.rbtnGender.SelectedValue = (bo.Gender.Value) ? "true" : "false";
            this.cbxIsActive.Checked = bo.IsActive.Value;

            if (bo.FK_Role.Value != 0)
                this.gpRole.SelectedValue = bo.FK_Role.Value.ToString();

            this.tbxTitle.Text = bo.Title.Value;
            this.tbxMobile.Text = bo.Mobile.Value;
            this.tbxEmail.Text = bo.Email.Value;
            this.tbxAddress.Text = bo.Address.Value;

            if (bo.Birthday.Value != DateTime.MinValue)
                this.tbxBirthday.Text = bo.Birthday.Value.ToString("yyyy-MM-dd");

            this.tbxMemo.Text = bo.Memo.Value;
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

        private void validateAlias_ServerValidate(object source, ServerValidateEventArgs args)
        {
            BusinessRule.Common rule = new BusinessRule.Common();
            args.IsValid = rule.IsFieldExclusive("Alias", this.tbxAlias.Text.Trim(), "User", true, this.PKID);
        }

        private void validateRole_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (this.gpRole.SelectedValue != string.Empty && this.gpRole.SelectedValue != "0") ? true : false;
        }
        #endregion

        #region Save | Update
        /// <summary>
        /// 创建新用户（主入口）
        /// </summary>
        public void Save()
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();

            try
            {
                session.BeginTransaction();

                // 插入主档信息
                int userid = InsertUserInfo(session);

                session.Commit();

                // Write Log
                //BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
                //rule.WriteOperationLog("用户信息管理", "新增用户信息");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                session.Rollback();
            }
        }



        /// <summary>
        /// 更新用户信息（主入口）
        /// </summary>
        public void Update()
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();

            try
            {
                session.BeginTransaction();

                // 更新用户主档信息
                UpdateUserInfo(session, this.PKID);

                session.Commit();

                // Write Log
                //BusinessRule.SystemManage.OperationLog rule = new BusinessRule.SystemManage.OperationLog();
                //rule.WriteOperationLog("用户信息管理", "编辑用户信息");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                session.Rollback();
            }
        }

        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="session"></param>
        /// <returns>返回用户对象的PKID</returns>
        private int InsertUserInfo(Wicresoft.Session.Session session)
        {
            // 插入用户信息
            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = session;

            bo.Alias.Value = this.tbxAlias.Text.Trim();
            bo.ChineseName.Value = this.tbxChineseName.Text.Trim();
            bo.EnglishName.Value = this.tbxEnglishName.Text.Trim();
            bo.Gender.Value = Convert.ToBoolean(this.rbtnGender.SelectedValue);
            bo.Password.Value = GlobalFacade.EncryptionManager.EncrytPassword(System.Configuration.ConfigurationManager.AppSettings["DefaultPassword"]);
            bo.IsActive.Value = this.cbxIsActive.Checked;

            if (this.gpRole.SelectedValue != string.Empty && this.gpRole.SelectedValue != "0")
                bo.FK_Role.Value = Convert.ToInt32(this.gpRole.SelectedValue);
            bo.Title.Value = this.tbxTitle.Text.Trim();
            bo.Mobile.Value = this.tbxMobile.Text.Trim();
            bo.Email.Value = this.tbxEmail.Text.Trim();
            bo.Address.Value = this.tbxAddress.Text.Trim();

            if (this.tbxBirthday.Text.Trim() != string.Empty)
                bo.Birthday.Value = Convert.ToDateTime(this.tbxBirthday.Text.Trim());

            bo.Memo.Value = this.tbxMemo.Text.Trim();

            bo.CreateTime.Value = DateTime.Now;
            bo.ModifyTime.Value = DateTime.Now;
            bo.CreateUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
            bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
            bo.Insert();

            return bo.PKID.Value;
        }

        /// <summary>
        /// 更新用户主档信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userid"></param>
        private void UpdateUserInfo(Wicresoft.Session.Session session, int userid)
        {
            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = session;

            BusinessFilter filter = new BusinessFilter("User");
            filter.AddFilterItem("PKID", userid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                bo.Alias.Value = this.tbxAlias.Text.Trim();
                bo.ChineseName.Value = this.tbxChineseName.Text.Trim();
                bo.EnglishName.Value = this.tbxEnglishName.Text.Trim();
                bo.Gender.Value = Convert.ToBoolean(this.rbtnGender.SelectedValue);
                bo.IsActive.Value = this.cbxIsActive.Checked;

                if (this.gpRole.SelectedValue != string.Empty && this.gpRole.SelectedValue != "0")
                    bo.FK_Role.Value = Convert.ToInt32(this.gpRole.SelectedValue);

                bo.Title.Value = this.tbxTitle.Text.Trim();
                bo.Mobile.Value = this.tbxMobile.Text.Trim();
                bo.Email.Value = this.tbxEmail.Text.Trim();
                bo.Address.Value = this.tbxAddress.Text.Trim();

                if (this.tbxBirthday.Text.Trim() != string.Empty)
                    bo.Birthday.Value = Convert.ToDateTime(this.tbxBirthday.Text.Trim());

                bo.Memo.Value = this.tbxMemo.Text.Trim();

                bo.ModifyTime.Value = DateTime.Now;
                bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
                bo.Update();
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
            this.gpRole.BusinessObjectViewName = "RoleDefaultView";

            this.validateAlias.ServerValidate += new ServerValidateEventHandler(validateAlias_ServerValidate);
            this.validateRole.ServerValidate += new ServerValidateEventHandler(validateRole_ServerValidate);
            this.rbtnGender.SelectedIndex = 0;
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
