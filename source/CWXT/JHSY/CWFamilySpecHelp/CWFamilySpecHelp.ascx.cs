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

namespace CWXT.JHSY.CWFamilySpecHelp
{
    public partial class CWFamilySpecHelp : System.Web.UI.UserControl
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
            BusinessMapping.CWFamilySpecHelp bo = new BusinessMapping.CWFamilySpecHelp();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWFamilySpecHelp");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                this.txtCWID.Text = bo.FK_CWID.Value.ToString();
                this.txtAppIDCardNo.Text = bo.AppIDCardNo.Value;
                this.txtAppName.Text = bo.AppName.Value;
                this.txtSex.Text = bo.Sex.Value.ToString();
                this.txtHolderPorp.Text = bo.HolderPorp.Value.ToString();
                this.txtHelpType.Text = bo.HelpType.Value.ToString();
                this.txtRealMonth.Text = bo.RealMonth.Value.ToString();
                this.txtHelpMoney.Text = bo.HelpMoney.Value.ToString();
                this.txtHelpNo.Text = bo.HelpNo.Value;
                this.txtHelpYear.Text = bo.HelpYear.Value;
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

        private void validatetxtHolderPorp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtHolderPorp.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtHolderPorp.Text.Trim()))
            //{
            //    this.validatetxtHolderPorp.ErrorMessage = "户口性质只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtHelpType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtHelpType.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtHelpType.Text.Trim()))
            //{
            //    this.validatetxtHelpType.ErrorMessage = "扶助类型只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtRealMonth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtRealMonth.Text.Trim()) && !GlobalFacade.Utils.IsInt(this.txtRealMonth.Text.Trim()))
            //{
            //    this.validatetxtRealMonth.ErrorMessage = "享受时间只能为数字类型";
            //    args.IsValid = false;
            //}
        }

        private void validatetxtHelpMoney_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //if (!string.IsNullOrEmpty(this.txtHelpMoney.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtHelpMoney.Text.Trim()))
            //{
            //    this.validatetxtHelpMoney.ErrorMessage = "享受金额只能为数字类型";
            //    args.IsValid = false;
            //}
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWFamilySpecHelp bo = new BusinessMapping.CWFamilySpecHelp();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.txtCWID.Text.Trim() != "")
                bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

            bo.AppIDCardNo.Value = this.txtAppIDCardNo.Text.Trim();
            bo.AppName.Value = this.txtAppName.Text.Trim();
            if (this.txtSex.Text.Trim() != "")
                bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

            if (this.txtHolderPorp.Text.Trim() != "")
                bo.HolderPorp.Value = Convert.ToInt32(this.txtHolderPorp.Text.Trim());

            if (this.txtHelpType.Text.Trim() != "")
                bo.HelpType.Value = Convert.ToInt32(this.txtHelpType.Text.Trim());

            if (this.txtRealMonth.Text.Trim() != "")
                bo.RealMonth.Value = Convert.ToInt32(this.txtRealMonth.Text.Trim());

            if (this.txtHelpMoney.Text.Trim() != "")
                bo.HelpMoney.Value = Convert.ToDecimal(this.txtHelpMoney.Text.Trim());

            bo.HelpNo.Value = this.txtHelpNo.Text.Trim();
            bo.HelpYear.Value = this.txtHelpYear.Text.Trim();

            bo.CreateTime.Value = DateTime.Now;
            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWFamilySpecHelp bo = new BusinessMapping.CWFamilySpecHelp();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWFamilySpecHelp");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                if (this.txtCWID.Text.Trim() != "")
                    bo.FK_CWID.Value = Convert.ToInt32(this.txtCWID.Text.Trim());

                bo.AppIDCardNo.Value = this.txtAppIDCardNo.Text.Trim();
                bo.AppName.Value = this.txtAppName.Text.Trim();
                if (this.txtSex.Text.Trim() != "")
                    bo.Sex.Value = Convert.ToInt32(this.txtSex.Text.Trim());

                if (this.txtHolderPorp.Text.Trim() != "")
                    bo.HolderPorp.Value = Convert.ToInt32(this.txtHolderPorp.Text.Trim());

                if (this.txtHelpType.Text.Trim() != "")
                    bo.HelpType.Value = Convert.ToInt32(this.txtHelpType.Text.Trim());

                if (this.txtRealMonth.Text.Trim() != "")
                    bo.RealMonth.Value = Convert.ToInt32(this.txtRealMonth.Text.Trim());

                if (this.txtHelpMoney.Text.Trim() != "")
                    bo.HelpMoney.Value = Convert.ToDecimal(this.txtHelpMoney.Text.Trim());

                bo.HelpNo.Value = this.txtHelpNo.Text.Trim();
                bo.HelpYear.Value = this.txtHelpYear.Text.Trim();

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
            this.validatetxtHolderPorp.ServerValidate += new ServerValidateEventHandler(validatetxtHolderPorp_ServerValidate);
            this.validatetxtHelpType.ServerValidate += new ServerValidateEventHandler(validatetxtHelpType_ServerValidate);
            this.validatetxtRealMonth.ServerValidate += new ServerValidateEventHandler(validatetxtRealMonth_ServerValidate);
            this.validatetxtHelpMoney.ServerValidate += new ServerValidateEventHandler(validatetxtHelpMoney_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {

        }
        #endregion
    }
}