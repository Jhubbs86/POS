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
                this.txtCWID.Text = bo.FK_CWID.Value.ToString();
                this.txtOwnIDCardNo.Text = bo.OwnIDCardNo.Value;
                this.txtOwnName.Text = bo.OwnName.Value;
                this.txtChildIDCardNo.Text = bo.ChildIDCardNo.Value;
                this.txtChildName.Text = bo.ChildName.Value;
                if (bo.BirthDate.Value.ToString("yyyy-MM-dd") != "0001-01-01")
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

        private void validatetxtCWID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if()
            //{
            //    this.validatetxtCWID.ErrorMessage = "请选择所属村镇";
            //    args.IsValid = false;
            //    return;
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

        private void validatetxtRealMonth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtRealMonth.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtRealMonth.Text.Trim()))
            //{
            //    this.validatetxtRealMonth.ErrorMessage = "享受月数只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtAwardFee_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if(!string.IsNullOrEmpty(this.txtAwardFee.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtAwardFee.Text.Trim()))
            //{
            //    this.validatetxtAwardFee.ErrorMessage = "金额只能为数字类型";
            //    args.IsValid = false;
            //}
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWOneChildAward bo = new BusinessMapping.CWOneChildAward();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.txtCWID.Text.Trim() != "")
                bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

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

                if (this.txtCWID.Text.Trim() != "")
                    bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

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
            this.validatetxtBirthDate.ServerValidate += new ServerValidateEventHandler(validatetxtBirthDate_ServerValidate);
            this.validatetxtRealMonth.ServerValidate += new ServerValidateEventHandler(validatetxtRealMonth_ServerValidate);
            this.validatetxtAwardFee.ServerValidate += new ServerValidateEventHandler(validatetxtAwardFee_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}