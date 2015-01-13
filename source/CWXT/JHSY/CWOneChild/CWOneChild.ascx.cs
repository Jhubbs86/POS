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
using System.Drawing;

using Wicresoft.BusinessObject;

namespace CWXT.JHSY.CWOneChild
{
    public partial class CWOneChild : System.Web.UI.UserControl
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
            GlobalFacade.Utils.SetReadonly(this);
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
            BusinessMapping.CWOneChild bo = new BusinessMapping.CWOneChild();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWOneChild");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                this.txtCWID.Text = bo.FK_CWID.Value.ToString();
                this.txtIDCardNo.Text = bo.IDCardNo.Value;
                this.txtChildName.Text = bo.ChildName.Value;
                this.txtSex.Text = bo.Sex.Value.ToString();
                this.txtFathIDCardNo.Text = bo.FathIDCardNo.Value;
                this.txtMothIDCardNo.Text = bo.MothIDCardNo.Value;
                this.txtOneChildNo.Text = bo.OneChildNo.Value;
                this.txtIssueOrg.Text = bo.IssueOrg.Value;
                if (bo.BirthDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtBirthDate.Text = bo.BirthDate.Value.ToString("yyyy-MM-dd");

                this.txtInSchool.Text = bo.InSchool.Value;
                this.txtFamilyAddress.Text = bo.FamilyAddress.Value;
                this.txtFamilyIncome.Text = bo.FamilyIncome.Value.ToString();
                this.txtInsuNo.Text = bo.InsuNo.Value;
                this.txtMemo.Text = bo.Memo.Value;
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

        private void validatetxtCWID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if()
            //{
            //    this.validatetxtCWID.ErrorMessage = "请选择所属村镇";
            //    args.IsValid = false;
            //    return;
            //}
        }

        private void validatetxtSex_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtSex.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtSex.Text.Trim()))
            //{
            //    this.validatetxtSex.ErrorMessage = "性别只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtBirthDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtBirthDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtBirthDate.Text.Trim()))
            //{
            //    this.validatetxtBirthDate.ErrorMessage = "出生年月只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtFamilyIncome_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtFamilyIncome.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtFamilyIncome.Text.Trim()))
            //{
            //    this.validatetxtFamilyIncome.ErrorMessage = "家庭人均收入只能为数字类型";
            //    args.IsValid = false;
            //}
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWOneChild bo = new BusinessMapping.CWOneChild();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.txtCWID.Text.Trim() != "")
                bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

            bo.IDCardNo.Value = this.txtIDCardNo.Text.Trim();
            bo.ChildName.Value = this.txtChildName.Text.Trim();
            if (this.txtSex.Text.Trim() != "")
                bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

            bo.FathIDCardNo.Value = this.txtFathIDCardNo.Text.Trim();
            bo.MothIDCardNo.Value = this.txtMothIDCardNo.Text.Trim();
            bo.OneChildNo.Value = this.txtOneChildNo.Text.Trim();
            bo.IssueOrg.Value = this.txtIssueOrg.Text.Trim();
            if (this.txtBirthDate.Text != "")
                bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

            bo.InSchool.Value = this.txtInSchool.Text.Trim();
            bo.FamilyAddress.Value = this.txtFamilyAddress.Text.Trim();
            if (this.txtFamilyIncome.Text.Trim() != "")
                bo.FamilyIncome.Value = Convert.ToDecimal(this.txtFamilyIncome.Text.Trim());

            bo.InsuNo.Value = this.txtInsuNo.Text.Trim();

            bo.CreateUser.Value = userID;
            bo.CreateTime.Value = DateTime.Now;

            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWOneChild bo = new BusinessMapping.CWOneChild();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWOneChild");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                if (this.txtCWID.Text.Trim() != "")
                    bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

                bo.IDCardNo.Value = this.txtIDCardNo.Text.Trim();
                bo.ChildName.Value = this.txtChildName.Text.Trim();
                if (this.txtSex.Text.Trim() != "")
                    bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

                bo.FathIDCardNo.Value = this.txtFathIDCardNo.Text.Trim();
                bo.MothIDCardNo.Value = this.txtMothIDCardNo.Text.Trim();
                bo.OneChildNo.Value = this.txtOneChildNo.Text.Trim();
                bo.IssueOrg.Value = this.txtIssueOrg.Text.Trim();
                if (this.txtBirthDate.Text != "")
                    bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

                bo.InSchool.Value = this.txtInSchool.Text.Trim();
                bo.FamilyAddress.Value = this.txtFamilyAddress.Text.Trim();
                if (this.txtFamilyIncome.Text.Trim() != "")
                    bo.FamilyIncome.Value = Convert.ToDecimal(this.txtFamilyIncome.Text.Trim());

                bo.InsuNo.Value = this.txtInsuNo.Text.Trim();

                bo.ModifyUser.Value = userID;
                bo.ModifyTime.Value = DateTime.Now;
                bo.Memo.Value = this.txtMemo.Text.Trim();

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

        private void InitializeComponent() { }

        private void AppendServerEvents()
        {
            this.validatetxtCWID.ServerValidate += new ServerValidateEventHandler(validatetxtCWID_ServerValidate);
            this.validatetxtSex.ServerValidate += new ServerValidateEventHandler(validatetxtSex_ServerValidate);
            this.validatetxtBirthDate.ServerValidate += new ServerValidateEventHandler(validatetxtBirthDate_ServerValidate);
            this.validatetxtFamilyIncome.ServerValidate += new ServerValidateEventHandler(validatetxtFamilyIncome_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}