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

            txtMarrigeDate.Attributes.Remove("onfocus");
            txtVillageDate.Attributes.Remove("onfocus");
            txtExpectDate.Attributes.Remove("onfocus");
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
            BusinessMapping.CWNewMarrige bo = new BusinessMapping.CWNewMarrige();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWNewMarrige");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                if (bo.FK_CWID.Value > 0)
                    this.gpCWInfo.SelectedValue = bo.FK_CWID.Value.ToString();
                this.txtMaleIDCardNo.Text = bo.MaleIDCardNo.Value;
                this.txtMaleName.Text = bo.MaleName.Value;
                this.txtMaleAddress.Text = bo.MaleAddress.Value;
                this.txtMaleLinkPhone.Text = bo.MaleLinkPhone.Value;
                this.txtFemaleIDCardNo.Text = bo.FemaleIDCardNo.Value;
                this.txtFemaleName.Text = bo.FemaleName.Value;
                this.txtFemaleAddress.Text = bo.FemaleAddress.Value;
                this.txtFemaleLinkPhone.Text = bo.FemaleLinkPhone.Value;
                if (bo.MarrigeDate.Value != DateTime.MinValue)
                    this.txtMarrigeDate.Text = bo.MarrigeDate.Value.ToString("yyyy-MM-dd");

                if (bo.IsPregnant.Value > 0)
                    this.ddlIsPregnant.SelectedValue = bo.IsPregnant.Value.ToString();

                if (bo.ExpectDate.Value != DateTime.MinValue)
                    this.txtExpectDate.Text = bo.ExpectDate.Value.ToString("yyyy-MM-dd");

                if (bo.VillageDate.Value != DateTime.MinValue)
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

        private void validateCWInfo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.gpCWInfo.SelectedValue == string.Empty || this.gpCWInfo.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateMarrigeNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtMarrigeNo.Text.Trim()))
            {
                BusinessRule.Common rule = new BusinessRule.Common();
                args.IsValid = rule.IsFieldExclusive("MarrigeNo", this.txtMarrigeNo.Text.Trim(), "CWNewMarrige", true, this.PKID);
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWNewMarrige bo = new BusinessMapping.CWNewMarrige();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);
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

            if (this.ddlIsPregnant.SelectedValue != string.Empty && this.ddlIsPregnant.SelectedValue != "0")
                bo.IsPregnant.Value = Convert.ToInt32(this.ddlIsPregnant.SelectedValue);

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

                if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                    bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);
                else
                    bo.FK_CWID.Value = 0;
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

                if (this.ddlIsPregnant.SelectedValue != string.Empty && this.ddlIsPregnant.SelectedValue != "0")
                    bo.IsPregnant.Value = Convert.ToInt32(this.ddlIsPregnant.SelectedValue);
                else
                    bo.IsPregnant.Value = 0;

                if (this.txtExpectDate.Text != "")
                    bo.ExpectDate.Value = Convert.ToDateTime(this.txtExpectDate.Text);

                if (this.txtVillageDate.Text != "")
                    bo.VillageDate.Value = Convert.ToDateTime(this.txtVillageDate.Text);

                bo.MarrigeNo.Value = this.txtMarrigeNo.Text.Trim();

                bo.Memo.Value = this.txtMemo.Text.Trim();

                bo.Update();

                string strSql = string.Empty;

                if (this.txtMarrigeDate.Text == "" && bo.MarrigeDate.Value != DateTime.MinValue)
                {
                    strSql += string.Format("UPDATE CWNewMarrige SET MarrigeDate = NULL WHERE PKID = {0}; ", this.PKID);
                }
                if (this.txtExpectDate.Text == "" && bo.ExpectDate.Value != DateTime.MinValue)
                {
                    strSql += string.Format("UPDATE CWNewMarrige SET ExpectDate = NULL WHERE PKID = {0}; ", this.PKID);
                }
                if (this.txtVillageDate.Text == "" && bo.VillageDate.Value != DateTime.MinValue)
                {
                    strSql += string.Format("UPDATE CWNewMarrige SET VillageDate = NULL WHERE PKID = {0}; ", this.PKID);
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
            this.validateMarrigeNo.ServerValidate += new ServerValidateEventHandler(validateMarrigeNo_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {
            DictionaryList(ddlIsPregnant, GlobalFacade.DictionaryType.Type_5.ToString());
        }
        #endregion
    }
}