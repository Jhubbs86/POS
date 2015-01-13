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

namespace CWXT.JHSY.CWNewMarrige
{
    public partial class CWNewMarrige : System.Web.UI.UserControl
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
            BusinessMapping.CWNewMarrige bo = new BusinessMapping.CWNewMarrige();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWNewMarrige");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                this.txtCWID.Text = bo.FK_CWID.Value.ToString();
                this.txtMaleIDCardNo.Text = bo.MaleIDCardNo.Value;
                this.txtMaleName.Text = bo.MaleName.Value;
                this.txtMaleAddress.Text = bo.MaleAddress.Value;
                this.txtMaleLinkPhone.Text = bo.MaleLinkPhone.Value;
                this.txtFemaleIDCardNo.Text = bo.FemaleIDCardNo.Value;
                this.txtFemaleName.Text = bo.FemaleName.Value;
                this.txtFemaleAddress.Text = bo.FemaleAddress.Value;
                this.txtFemaleLinkPhone.Text = bo.FemaleLinkPhone.Value;
                if (bo.MarrigeDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtMarrigeDate.Text = bo.MarrigeDate.Value.ToString("yyyy-MM-dd");

                this.txtIsPregnant.Text = bo.IsPregnant.Value.ToString();
                if (bo.ExpectDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtExpectDate.Text = bo.ExpectDate.Value.ToString("yyyy-MM-dd");

                if (bo.VillageDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                    this.txtVillageDate.Text = bo.VillageDate.Value.ToString("yyyy-MM-dd");

                this.txtMarrigeNo.Text = bo.MarrigeNo.Value;
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

        private void validatetxtMarrigeDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtMarrigeDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtMarrigeDate.Text.Trim()))
            //{
            //    this.validatetxtMarrigeDate.ErrorMessage = "结婚登记日期只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtIsPregnant_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtIsPregnant.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtIsPregnant.Text.Trim()))
            //{
            //    this.validatetxtIsPregnant.ErrorMessage = "是否怀孕只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtExpectDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtExpectDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtExpectDate.Text.Trim()))
            //{
            //    this.validatetxtExpectDate.ErrorMessage = "预产期只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtVillageDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtVillageDate.Text.Trim()) && !GlobalFacade.Utils.IsDateTime(this.txtVillageDate.Text.Trim()))
            //{
            //    this.validatetxtVillageDate.ErrorMessage = "村委登记日期只能为数字类型";
            //    args.IsValid = false;
            //}
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWNewMarrige bo = new BusinessMapping.CWNewMarrige();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.txtCWID.Text.Trim() != "")
                bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

            bo.MaleIDCardNo.Value = this.txtMaleIDCardNo.Text.Trim();
            bo.MaleName.Value = this.txtMaleName.Text.Trim();
            bo.MaleAddress.Value = this.txtMaleAddress.Text.Trim();
            bo.MaleLinkPhone.Value = this.txtMaleLinkPhone.Text.Trim();
            bo.FemaleIDCardNo.Value = this.txtFemaleIDCardNo.Text.Trim();
            bo.FemaleName.Value = this.txtFemaleName.Text.Trim();
            bo.FemaleAddress.Value = this.txtFemaleAddress.Text.Trim();
            bo.FemaleLinkPhone.Value = this.txtFemaleLinkPhone.Text.Trim();
            if (this.txtMarrigeDate.Text != "")
                bo.MarrigeDate.Value = Convert.ToDateTime(this.txtMarrigeDate.Text);

            if (this.txtIsPregnant.Text.Trim() != "")
                bo.IsPregnant.Value = Convert.ToInt32(this.txtIsPregnant.Text.Trim());

            if (this.txtExpectDate.Text != "")
                bo.ExpectDate.Value = Convert.ToDateTime(this.txtExpectDate.Text);

            if (this.txtVillageDate.Text != "")
                bo.VillageDate.Value = Convert.ToDateTime(this.txtVillageDate.Text);

            bo.MarrigeNo.Value = this.txtMarrigeNo.Text.Trim();

            bo.CreateUser.Value = userID;
            bo.CreateTime.Value = DateTime.Now;
            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWNewMarrige bo = new BusinessMapping.CWNewMarrige();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWNewMarrige");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                if (this.txtCWID.Text.Trim() != "")
                    bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

                bo.MaleIDCardNo.Value = this.txtMaleIDCardNo.Text.Trim();
                bo.MaleName.Value = this.txtMaleName.Text.Trim();
                bo.MaleAddress.Value = this.txtMaleAddress.Text.Trim();
                bo.MaleLinkPhone.Value = this.txtMaleLinkPhone.Text.Trim();
                bo.FemaleIDCardNo.Value = this.txtFemaleIDCardNo.Text.Trim();
                bo.FemaleName.Value = this.txtFemaleName.Text.Trim();
                bo.FemaleAddress.Value = this.txtFemaleAddress.Text.Trim();
                bo.FemaleLinkPhone.Value = this.txtFemaleLinkPhone.Text.Trim();
                if (this.txtMarrigeDate.Text != "")
                    bo.MarrigeDate.Value = Convert.ToDateTime(this.txtMarrigeDate.Text);

                if (this.txtIsPregnant.Text.Trim() != "")
                    bo.IsPregnant.Value = Convert.ToInt32(this.txtIsPregnant.Text.Trim());

                if (this.txtExpectDate.Text != "")
                    bo.ExpectDate.Value = Convert.ToDateTime(this.txtExpectDate.Text);

                if (this.txtVillageDate.Text != "")
                    bo.VillageDate.Value = Convert.ToDateTime(this.txtVillageDate.Text);

                bo.MarrigeNo.Value = this.txtMarrigeNo.Text.Trim();

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
            this.validatetxtMarrigeDate.ServerValidate += new ServerValidateEventHandler(validatetxtMarrigeDate_ServerValidate);
            this.validatetxtIsPregnant.ServerValidate += new ServerValidateEventHandler(validatetxtIsPregnant_ServerValidate);
            this.validatetxtExpectDate.ServerValidate += new ServerValidateEventHandler(validatetxtExpectDate_ServerValidate);
            this.validatetxtVillageDate.ServerValidate += new ServerValidateEventHandler(validatetxtVillageDate_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}