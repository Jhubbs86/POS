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
            BusinessMapping.CWOneChild bo = new BusinessMapping.CWOneChild();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWOneChild");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                if (bo.FK_CWID.Value > 0)
                    this.gpCWInfo.SelectedValue = bo.FK_CWID.Value.ToString();
                this.txtIDCardNo.Text = bo.IDCardNo.Value;
                this.txtChildName.Text = bo.ChildName.Value;
                if (bo.Sex.Value > 0)
                    this.ddlSex.SelectedValue = bo.Sex.Value.ToString();
                this.txtFathIDCardNo.Text = bo.FathIDCardNo.Value;
                this.txtMothIDCardNo.Text = bo.MothIDCardNo.Value;
                this.txtOneChildNo.Text = bo.OneChildNo.Value;
                this.txtIssueOrg.Text = bo.IssueOrg.Value;
                if (bo.BirthDate.Value != DateTime.MinValue)
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

        private void validateCWInfo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.gpCWInfo.SelectedValue == string.Empty || this.gpCWInfo.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateIDCardNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtIDCardNo.Text.Trim()))
            {
                BusinessRule.Common rule = new BusinessRule.Common();
                args.IsValid = rule.IsFieldExclusive("IDCardNo", this.txtIDCardNo.Text.Trim(), "CWOneChild", true, this.PKID);
            }
        }

        private void validateSex_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlSex.SelectedValue == string.Empty || this.ddlSex.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateOneChildNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtOneChildNo.Text.Trim()))
            {
                BusinessRule.Common rule = new BusinessRule.Common();
                args.IsValid = rule.IsFieldExclusive("OneChildNo", this.txtOneChildNo.Text.Trim(), "CWOneChild", true, this.PKID);
            }
        } 

        private void validateFamilyIncome_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtFamilyIncome.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtFamilyIncome.Text.Trim()))
            {
                this.validateFamilyIncome.ErrorMessage = ResourceManager.Instance.GetString("validateFamilyIncome");
                args.IsValid = false;
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWOneChild bo = new BusinessMapping.CWOneChild();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);

            bo.IDCardNo.Value = this.txtIDCardNo.Text.Trim();
            bo.ChildName.Value = this.txtChildName.Text.Trim();
            if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);

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

                if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                    bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);
                else
                    bo.FK_CWID.Value = 0;

                bo.IDCardNo.Value = this.txtIDCardNo.Text.Trim();
                bo.ChildName.Value = this.txtChildName.Text.Trim();
                if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                    bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);
                else
                    bo.Sex.Value = 0;

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

                string strSql = string.Empty;

                if (this.txtBirthDate.Text == "" && bo.BirthDate.Value != DateTime.MinValue)
                {
                    strSql += string.Format("UPDATE CWOneChild SET BirthDate = NULL WHERE PKID = {0}; ", this.PKID);
                }
                if (strSql != string.Empty)
                {
                    Wicresoft.Session.Session session = new Wicresoft.Session.Session();

                    session.SqlHelper.ExecuteNonQuery(strSql, CommandType.Text);
                }
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
            this.validateIDCardNo.ServerValidate += new ServerValidateEventHandler(validateIDCardNo_ServerValidate);
            this.validateSex.ServerValidate += new ServerValidateEventHandler(validateSex_ServerValidate);
            this.validateOneChildNo.ServerValidate += new ServerValidateEventHandler(validateOneChildNo_ServerValidate);
            this.validateFamilyIncome.ServerValidate += new ServerValidateEventHandler(validateFamilyIncome_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {
            DictionaryList(ddlSex, GlobalFacade.DictionaryType.Type_2.ToString());
        }
        #endregion
    }
}