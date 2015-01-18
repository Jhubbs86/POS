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
            BusinessMapping.CWFamilySpecHelp bo = new BusinessMapping.CWFamilySpecHelp();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWFamilySpecHelp");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                if (bo.FK_CWID.Value > 0)
                    this.gpCWInfo.SelectedValue = bo.FK_CWID.Value.ToString();
                this.txtAppIDCardNo.Text = bo.AppIDCardNo.Value;
                this.txtAppName.Text = bo.AppName.Value;
                if (bo.Sex.Value > 0)
                    this.ddlSex.SelectedValue = bo.Sex.Value.ToString();
                if (bo.HolderPorp.Value > 0)
                    this.ddlHolderPorp.Text = bo.HolderPorp.Value.ToString();
                if (bo.HelpType.Value > 0)
                    this.ddlHelpType.Text = bo.HelpType.Value.ToString();
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

        private void validateHelpMoney_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtHelpMoney.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtHelpMoney.Text.Trim()))
            {
                args.IsValid = false;
            }
        }

        private void validateHelpYear_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtHelpYear.Text.Trim()))
            {
                args.IsValid = BusinessRule.Common.ValidateIntegerStyle(this.txtHelpYear.Text.Trim()) ? true : false;
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWFamilySpecHelp bo = new BusinessMapping.CWFamilySpecHelp();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);

            bo.AppIDCardNo.Value = this.txtAppIDCardNo.Text.Trim();
            bo.AppName.Value = this.txtAppName.Text.Trim();
            if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);

            if (this.ddlHolderPorp.SelectedValue != "" && this.ddlHolderPorp.SelectedValue != "0")
                bo.HolderPorp.Value = Convert.ToInt32(this.ddlHolderPorp.SelectedValue);

            if (this.ddlHelpType.SelectedValue != "" && this.ddlHelpType.SelectedValue != "0")
                bo.HelpType.Value = Convert.ToInt32(this.ddlHelpType.SelectedValue);

            if (this.txtRealMonth.Text.Trim() != "")
                bo.RealMonth.Value = Convert.ToInt32(this.txtRealMonth.Text.Trim());

            if (this.txtHelpMoney.Text.Trim() != "")
                bo.HelpMoney.Value = Convert.ToDecimal(this.txtHelpMoney.Text.Trim());

            bo.HelpNo.Value = this.txtHelpNo.Text.Trim();
            bo.HelpYear.Value = this.txtHelpYear.Text.Trim();

            bo.CreateUser.Value = userID;
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

                if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                    bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);
                else
                    bo.FK_CWID.Value = 0;

                bo.AppIDCardNo.Value = this.txtAppIDCardNo.Text.Trim();
                bo.AppName.Value = this.txtAppName.Text.Trim();
                if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                    bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);
                else
                    bo.Sex.Value = 0;

                if (this.ddlHolderPorp.SelectedValue != "" && this.ddlHolderPorp.SelectedValue != "0")
                    bo.HolderPorp.Value = Convert.ToInt32(this.ddlHolderPorp.SelectedValue);
                else
                    bo.HolderPorp.Value = 0;

                if (this.ddlHelpType.SelectedValue != "" && this.ddlHelpType.SelectedValue != "0")
                    bo.HelpType.Value = Convert.ToInt32(this.ddlHelpType.SelectedValue);
                else
                    bo.HelpType.Value = 0;

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

        #region 绑定下拉列表
        public static void DictionaryList(System.Web.UI.WebControls.DropDownList DropOnDictionary, string type)
        {
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("Type", type, Operation.Equal, FilterType.NumberType, AndOr.AND);

            boc.AddFilter(filter);

            DropOnDictionary.DataSource = boc.GetDataTable();
            DropOnDictionary.DataTextField = "Name";
            DropOnDictionary.DataValueField = "PKID";
            DropOnDictionary.DataBind();
            DropOnDictionary.Items.Insert(0, new ListItem(ResourceManager.Instance.GetString("PleaseSelect"), "0"));
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
            this.validateHelpMoney.ServerValidate += new ServerValidateEventHandler(validateHelpMoney_ServerValidate);
            this.validateHelpYear.ServerValidate += new ServerValidateEventHandler(validateHelpYear_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {
            DictionaryList(ddlSex, GlobalFacade.DictionaryType.Type_2.ToString());
            DictionaryList(ddlHolderPorp, GlobalFacade.DictionaryType.Type_6.ToString());
            DictionaryList(ddlHelpType, GlobalFacade.DictionaryType.Type_9.ToString());
        }
        #endregion
    }
}