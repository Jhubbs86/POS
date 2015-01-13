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

namespace CWXT.JHSY.CWBirthInfo
{
    public partial class CWBirthInfo : System.Web.UI.UserControl
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
            BusinessMapping.CWBirthInfo bo = new BusinessMapping.CWBirthInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWBirthInfo");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                this.txtCWID.Text = bo.FK_CWID.Value.ToString();
                this.txtChildName.Text = bo.ChildName.Value;
                this.txtSex.Text = bo.Sex.Value.ToString();
                if (bo.BirthDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtBirthDate.Text = bo.BirthDate.Value.ToString("yyyy-MM-dd");

                this.txtBirthNo.Text = bo.BirthNo.Value;
                this.txtIsPlan.Text = bo.IsPlan.Value.ToString();
                if (bo.ExpectDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtExpectDate.Text = bo.ExpectDate.Value.ToString("yyyy-MM-dd");

                this.txtChildAddress.Text = bo.ChildAddress.Value;
                this.txtHolderName.Text = bo.HolderName.Value;
                this.txtHolderIDCardNo.Text = bo.HolderIDCardNo.Value;
                this.txtFathName.Text = bo.FathName.Value;
                this.txtFathIDCardNo.Text = bo.FathIDCardNo.Value;
                this.txtFathAddress.Text = bo.FathAddress.Value;
                this.txtFathLinkPhone.Text = bo.FathLinkPhone.Value;
                this.txtMothName.Text = bo.MothName.Value;
                this.txtMothIDCardNo.Text = bo.MothIDCardNo.Value;
                this.txtMothAddress.Text = bo.MothAddress.Value;
                this.txtMothLinkPhone.Text = bo.MothLinkPhone.Value;
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
            //if (!string.IsNullOrEmpty(this.txtSex.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtSex.Text.Trim()))
            //{
            //    this.validatetxtSex.ErrorMessage = "性别只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtBirthDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtBirthDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtBirthDate.Text.Trim()))
            //{
            //    this.validatetxtBirthDate.ErrorMessage = "出生年月只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtIsPlan_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtIsPlan.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtIsPlan.Text.Trim()))
            //{
            //    this.validatetxtIsPlan.ErrorMessage = "是否计划只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtExpectDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtExpectDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtExpectDate.Text.Trim()))
            //{
            //    this.validatetxtExpectDate.ErrorMessage = "预产期只能为数字类型";
            //    args.IsValid = false;
            //}
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWBirthInfo bo = new BusinessMapping.CWBirthInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.txtCWID.Text.Trim() != "")
                bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

            bo.ChildName.Value = this.txtChildName.Text.Trim();
            if (this.txtSex.Text.Trim() != "")
                bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

            if (this.txtBirthDate.Text != "")
                bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

            bo.BirthNo.Value = this.txtBirthNo.Text.Trim();
            if (this.txtIsPlan.Text.Trim() != "")
                bo.IsPlan.Value = Convert.ToInt32(this.txtIsPlan.Text.Trim());

            if (this.txtExpectDate.Text != "")
                bo.ExpectDate.Value = Convert.ToDateTime(this.txtExpectDate.Text);

            bo.ChildAddress.Value = this.txtChildAddress.Text.Trim();
            bo.HolderName.Value = this.txtHolderName.Text.Trim();
            bo.HolderIDCardNo.Value = this.txtHolderIDCardNo.Text.Trim();
            bo.FathName.Value = this.txtFathName.Text.Trim();
            bo.FathIDCardNo.Value = this.txtFathIDCardNo.Text.Trim();
            bo.FathAddress.Value = this.txtFathAddress.Text.Trim();
            bo.FathLinkPhone.Value = this.txtFathLinkPhone.Text.Trim();
            bo.MothName.Value = this.txtMothName.Text.Trim();
            bo.MothIDCardNo.Value = this.txtMothIDCardNo.Text.Trim();
            bo.MothAddress.Value = this.txtMothAddress.Text.Trim();
            bo.MothLinkPhone.Value = this.txtMothLinkPhone.Text.Trim();

            bo.CreateUser.Value = userID;
            bo.CreateTime.Value = DateTime.Now;

            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWBirthInfo bo = new BusinessMapping.CWBirthInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWBirthInfo");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                if (this.txtCWID.Text.Trim() != "")
                    bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

                bo.ChildName.Value = this.txtChildName.Text.Trim();
                if (this.txtSex.Text.Trim() != "")
                    bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

                if (this.txtBirthDate.Text != "")
                    bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

                bo.BirthNo.Value = this.txtBirthNo.Text.Trim();
                if (this.txtIsPlan.Text.Trim() != "")
                    bo.IsPlan.Value = Convert.ToInt32(this.txtIsPlan.Text.Trim());

                if (this.txtExpectDate.Text != "")
                    bo.ExpectDate.Value = Convert.ToDateTime(this.txtExpectDate.Text);

                bo.ChildAddress.Value = this.txtChildAddress.Text.Trim();
                bo.HolderName.Value = this.txtHolderName.Text.Trim();
                bo.HolderIDCardNo.Value = this.txtHolderIDCardNo.Text.Trim();
                bo.FathName.Value = this.txtFathName.Text.Trim();
                bo.FathIDCardNo.Value = this.txtFathIDCardNo.Text.Trim();
                bo.FathAddress.Value = this.txtFathAddress.Text.Trim();
                bo.FathLinkPhone.Value = this.txtFathLinkPhone.Text.Trim();
                bo.MothName.Value = this.txtMothName.Text.Trim();
                bo.MothIDCardNo.Value = this.txtMothIDCardNo.Text.Trim();
                bo.MothAddress.Value = this.txtMothAddress.Text.Trim();
                bo.MothLinkPhone.Value = this.txtMothLinkPhone.Text.Trim();

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
            this.validatetxtIsPlan.ServerValidate += new ServerValidateEventHandler(validatetxtIsPlan_ServerValidate);
            this.validatetxtExpectDate.ServerValidate += new ServerValidateEventHandler(validatetxtExpectDate_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}