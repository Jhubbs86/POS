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

namespace CWXT.JHSY.CWOneChildAward
{
    public partial class CWOneChildAward : System.Web.UI.UserControl
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

            txtBirthDate.Attributes.Remove("onfocus");
            gpCWInfo.Readonly = true;
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
            BusinessMapping.CWOneChildAward bo = new BusinessMapping.CWOneChildAward();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWOneChildAward");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                if (bo.FK_CWID.Value > 0)
                    this.gpCWInfo.SelectedValue = bo.FK_CWID.Value.ToString();
                this.txtOwnIDCardNo.Text = bo.OwnIDCardNo.Value;
                this.txtOwnName.Text = bo.OwnName.Value;
                this.txtChildIDCardNo.Text = bo.ChildIDCardNo.Value;
                this.txtChildName.Text = bo.ChildName.Value;
                if (bo.BirthDate.Value != DateTime.MinValue)
                    this.txtBirthDate.Text = bo.BirthDate.Value.ToString("yyyy-MM-dd");

                this.txtOneChildNo.Text = bo.OneChildNo.Value;
                this.txtRealMonth.Text = bo.RealMonth.Value.ToString();
                this.txtAwardFee.Text = bo.AwardFee.Value.ToString();
                this.txtLinkPhone.Text = bo.LinkPhone.Value;
                this.txtAuthName.Text = bo.AuthName.Value;
                this.txtABCNo.Text = bo.ABCNo.Value;
                this.txtAuthIDCardNo.Text = bo.AuthIDCardNo.Value;
                this.txtAwardYear.Text = bo.AwardYear.Value;
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

        private void validateCWInfo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.gpCWInfo.SelectedValue == string.Empty || this.gpCWInfo.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateRealMonth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtRealMonth.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtRealMonth.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        private void validateAwardFee_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtAwardFee.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtAwardFee.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        private void validateAwardYear_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtAwardYear.Text.Trim()))
            {
                args.IsValid = BusinessRule.Common.ValidateIntegerStyle(this.txtAwardYear.Text.Trim()) ? true : false;
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWOneChildAward bo = new BusinessMapping.CWOneChildAward();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);

            bo.OwnIDCardNo.Value = this.txtOwnIDCardNo.Text.Trim();
            bo.OwnName.Value = this.txtOwnName.Text.Trim();
            bo.ChildIDCardNo.Value = this.txtChildIDCardNo.Text.Trim();
            bo.ChildName.Value = this.txtChildName.Text.Trim();
            if (this.txtBirthDate.Text != "")
                bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

            bo.OneChildNo.Value = this.txtOneChildNo.Text.Trim();
            if (this.txtRealMonth.Text.Trim() != "")
                bo.RealMonth.Value = Convert.ToInt32(this.txtRealMonth.Text.Trim());

            if (this.txtAwardFee.Text.Trim() != "")
                bo.AwardFee.Value = Convert.ToDecimal(this.txtAwardFee.Text.Trim());

            bo.LinkPhone.Value = this.txtLinkPhone.Text.Trim();
            bo.AuthName.Value = this.txtAuthName.Text.Trim();
            bo.ABCNo.Value = this.txtABCNo.Text.Trim();
            bo.AuthIDCardNo.Value = this.txtAuthIDCardNo.Text.Trim();
            bo.AwardYear.Value = this.txtAwardYear.Text.Trim();

            bo.CreateUser.Value = userID;
            bo.CreateTime.Value = DateTime.Now;
            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWOneChildAward bo = new BusinessMapping.CWOneChildAward();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWOneChildAward");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                    bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);
                else
                    bo.FK_CWID.Value = 0;

                bo.OwnIDCardNo.Value = this.txtOwnIDCardNo.Text.Trim();
                bo.OwnName.Value = this.txtOwnName.Text.Trim();
                bo.ChildIDCardNo.Value = this.txtChildIDCardNo.Text.Trim();
                bo.ChildName.Value = this.txtChildName.Text.Trim();
                if (this.txtBirthDate.Text != "")
                    bo.BirthDate.Value = Convert.ToDateTime(this.txtBirthDate.Text);

                bo.OneChildNo.Value = this.txtOneChildNo.Text.Trim();
                if (this.txtRealMonth.Text.Trim() != "")
                    bo.RealMonth.Value = Convert.ToInt32(this.txtRealMonth.Text.Trim());

                if (this.txtAwardFee.Text.Trim() != "")
                    bo.AwardFee.Value = Convert.ToDecimal(this.txtAwardFee.Text.Trim());

                bo.LinkPhone.Value = this.txtLinkPhone.Text.Trim();
                bo.AuthName.Value = this.txtAuthName.Text.Trim();
                bo.ABCNo.Value = this.txtABCNo.Text.Trim();
                bo.AuthIDCardNo.Value = this.txtAuthIDCardNo.Text.Trim();
                bo.AwardYear.Value = this.txtAwardYear.Text.Trim();

                bo.Memo.Value = this.txtMemo.Text.Trim();

                bo.Update();

                string strSql = string.Empty;

                if (this.txtBirthDate.Text == "" && bo.BirthDate.Value != DateTime.MinValue)
                {
                    strSql += string.Format("UPDATE CWOneChildAward SET BirthDate = NULL WHERE PKID = {0}; ", this.PKID);
                }
                if (strSql != string.Empty)
                {
                    Wicresoft.Session.Session session = new Wicresoft.Session.Session();

                    session.SqlHelper.ExecuteNonQuery(strSql, CommandType.Text);
                }
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
            gpCWInfo.BusinessObjectViewName = "CWInfoDefaultView";

            this.validateCWInfo.ServerValidate += new ServerValidateEventHandler(validateCWInfo_ServerValidate);
            this.validateRealMonth.ServerValidate += new ServerValidateEventHandler(validateRealMonth_ServerValidate);
            this.validateAwardFee.ServerValidate += new ServerValidateEventHandler(validateAwardFee_ServerValidate);
            this.validateAwardYear.ServerValidate += new ServerValidateEventHandler(validateAwardYear_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}