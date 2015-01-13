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

namespace CWXT.JHSY.CWPerInfo
{
    public partial class CWPerInfo : System.Web.UI.UserControl
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
            txtBirthDate1.Attributes.Remove("onfocus");
            txtBirthDate2.Attributes.Remove("onfocus");
            txtBirthDate3.Attributes.Remove("onfocus");
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
            BusinessMapping.CWPerInfo bo = new BusinessMapping.CWPerInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWPerInfo");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                if (bo.FK_CWID.Value > 0)
                    this.gpCWInfo.SelectedValue = bo.FK_CWID.Value.ToString();
                this.txtIDCardNo.Text = bo.IDCardNo.Value;
                this.txtName.Text = bo.Name.Value;
                if (bo.Sex.Value > 0)
                    this.ddlSex.SelectedValue = bo.Sex.Value.ToString();
                if (bo.Nation.Value > 0)
                    this.ddlNation.Text = bo.Nation.Value.ToString();
                if (bo.Politics.Value > 0)
                    this.ddlPolitics.Text = bo.Politics.Value.ToString();
                if (bo.IsHolder.Value > 0)
                    this.ddlIsHolder.Text = bo.IsHolder.Value.ToString();
                this.txtHolderName.Text = bo.HolderName.Value;
                this.txtHolderIDCardNo.Text = bo.HolderIDCardNo.Value;
                if (bo.HolderPorp.Value > 0)
                    this.ddlHolderPorp.Text = bo.HolderPorp.Value.ToString();
                this.txtHolderAddress.Text = bo.HolderAddress.Value;
                this.txtLiveAddress.Text = bo.LiveAddress.Value;
                this.txtLinkPhone.Text = bo.LinkPhone.Value;
                this.txtWorkUnit.Text = bo.WorkUnit.Value;
                if (bo.MarrigeStatus.Value > 0)
                    this.ddlMarrigeStatus.Text = bo.MarrigeStatus.Value.ToString();
                if (bo.MarrigeDate.Value != DateTime.MinValue)
                    this.txtMarrigeDate.Text = bo.MarrigeDate.Value.ToString("yyyy-MM-dd");

                this.txtMarrigeNo.Text = bo.MarrigeNo.Value;
                this.txtMarrigeName.Text = bo.MarrigeName.Value;
                this.txtMarrigeIDCardNo.Text = bo.MarrigeIDCardNo.Value;

                if (bo.Children.Value > 0)
                    this.ddlChildren.Text = bo.Children.Value.ToString();
                if (bo.IsSingle.Value > 0)
                    this.ddlIsSingle.Text = bo.IsSingle.Value.ToString();

                this.txtChildName1.Text = bo.ChildName1.Value;
                this.txtChildIDCardNo1.Text = bo.ChildIDCardNo1.Value;
                this.txtChildAddress1.Text = bo.ChildAddress1.Value;
                this.txtBirthNo1.Text = bo.BirthNo1.Value;
                if (bo.BirthDate1.Value != DateTime.MinValue)
                    this.txtBirthDate1.Text = bo.BirthDate1.Value.ToString("yyyy-MM-dd");

                this.txtAdoptNo1.Text = bo.AdoptNo1.Value;
                this.txtChildName2.Text = bo.ChildName2.Value;
                this.txtChildIDCardNo2.Text = bo.ChildIDCardNo2.Value;
                this.txtChildAddress2.Text = bo.ChildAddress2.Value;
                this.txtBirthNo2.Text = bo.BirthNo2.Value;
                if (bo.BirthDate2.Value != DateTime.MinValue)
                    this.txtBirthDate2.Text = bo.BirthDate2.Value.ToString("yyyy-MM-dd");

                this.txtAdoptNo2.Text = bo.AdoptNo2.Value;
                this.txtChildName3.Text = bo.ChildName3.Value;
                this.txtChildIDCardNo3.Text = bo.ChildIDCardNo3.Value;
                this.txtChildAddress3.Text = bo.ChildAddress3.Value;
                this.txtBirthNo3.Text = bo.BirthNo3.Value;
                if (bo.BirthDate3.Value != DateTime.MinValue)
                    this.txtBirthDate3.Text = bo.BirthDate3.Value.ToString("yyyy-MM-dd");

                this.txtAdoptNo3.Text = bo.AdoptNo3.Value;
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
            if(this.gpCWInfo.SelectedValue == string.Empty || this.gpCWInfo.SelectedValue == "0")
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
                args.IsValid = rule.IsFieldExclusive("IDCardNo", this.txtIDCardNo.Text.Trim(), "CWPerInfo", true, this.PKID);
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

        private void validateNation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlNation.SelectedValue == string.Empty || this.ddlNation.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validatePolitics_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlPolitics.SelectedValue == string.Empty || this.ddlPolitics.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateIsHolder_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlIsHolder.SelectedValue == string.Empty || this.ddlIsHolder.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateHolderPorp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlHolderPorp.SelectedValue == string.Empty || this.ddlHolderPorp.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }

        private void validateMarrigeStatus_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.ddlMarrigeStatus.SelectedValue == string.Empty || this.ddlMarrigeStatus.SelectedValue == "0")
            {
                args.IsValid = false;
                return;
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWPerInfo bo = new BusinessMapping.CWPerInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            if (this.gpCWInfo.SelectedValue != string.Empty && this.gpCWInfo.SelectedValue != "0")
                bo.FK_CWID.Value = Convert.ToInt32(this.gpCWInfo.SelectedValue);

            bo.IDCardNo.Value = this.txtIDCardNo.Text.Trim();
            bo.Name.Value = this.txtName.Text.Trim();
            if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);

            if (this.ddlNation.SelectedValue != string.Empty && this.ddlNation.SelectedValue != "0")
                bo.Nation.Value = Convert.ToInt32(this.ddlNation.SelectedValue);

            if (this.ddlPolitics.SelectedValue != string.Empty && this.ddlPolitics.SelectedValue != "0")
                bo.Politics.Value = Convert.ToInt32(this.ddlPolitics.SelectedValue);

            if (this.ddlIsHolder.SelectedValue != string.Empty && this.ddlIsHolder.SelectedValue != "0")
                bo.IsHolder.Value = Convert.ToInt32(this.ddlIsHolder.SelectedValue);

            bo.HolderName.Value = this.txtHolderName.Text.Trim();
            bo.HolderIDCardNo.Value = this.txtHolderIDCardNo.Text.Trim();
            if (this.ddlHolderPorp.SelectedValue != "" && this.ddlHolderPorp.SelectedValue != "0")
                bo.HolderPorp.Value = Convert.ToInt32(this.ddlHolderPorp.SelectedValue);

            bo.HolderAddress.Value = this.txtHolderAddress.Text.Trim();
            bo.LiveAddress.Value = this.txtLiveAddress.Text.Trim();
            bo.LinkPhone.Value = this.txtLinkPhone.Text.Trim();
            bo.WorkUnit.Value = this.txtWorkUnit.Text.Trim();
            if (this.ddlMarrigeStatus.SelectedValue != string.Empty && this.ddlMarrigeStatus.SelectedValue != "0")
                bo.MarrigeStatus.Value = Convert.ToInt32(this.ddlMarrigeStatus.SelectedValue);

            if (this.txtMarrigeDate.Text != "")
                bo.MarrigeDate.Value = Convert.ToDateTime(this.txtMarrigeDate.Text);

            bo.MarrigeNo.Value = this.txtMarrigeNo.Text.Trim();
            bo.MarrigeName.Value = this.txtMarrigeName.Text.Trim();
            bo.MarrigeIDCardNo.Value = this.txtMarrigeIDCardNo.Text.Trim();

            if (this.ddlChildren.SelectedValue != string.Empty && this.ddlChildren.SelectedValue != "0")
                bo.Children.Value = Convert.ToInt32(this.ddlChildren.SelectedValue);
            if (this.ddlIsSingle.SelectedValue != string.Empty && this.ddlIsSingle.SelectedValue != "0")
                bo.IsSingle.Value = Convert.ToInt32(this.ddlIsSingle.SelectedValue);

            bo.ChildName1.Value = this.txtChildName1.Text.Trim();
            bo.ChildIDCardNo1.Value = this.txtChildIDCardNo1.Text.Trim();
            bo.ChildAddress1.Value = this.txtChildAddress1.Text.Trim();
            bo.BirthNo1.Value = this.txtBirthNo1.Text.Trim();
            if (this.txtBirthDate1.Text != "")
                bo.BirthDate1.Value = Convert.ToDateTime(this.txtBirthDate1.Text);

            bo.AdoptNo1.Value = this.txtAdoptNo1.Text.Trim();
            bo.ChildName2.Value = this.txtChildName2.Text.Trim();
            bo.ChildIDCardNo2.Value = this.txtChildIDCardNo2.Text.Trim();
            bo.ChildAddress2.Value = this.txtChildAddress2.Text.Trim();
            bo.BirthNo2.Value = this.txtBirthNo2.Text.Trim();
            if (this.txtBirthDate2.Text != "")
                bo.BirthDate2.Value = Convert.ToDateTime(this.txtBirthDate2.Text);

            bo.AdoptNo2.Value = this.txtAdoptNo2.Text.Trim();
            bo.ChildName3.Value = this.txtChildName3.Text.Trim();
            bo.ChildIDCardNo3.Value = this.txtChildIDCardNo3.Text.Trim();
            bo.ChildAddress3.Value = this.txtChildAddress3.Text.Trim();
            bo.BirthNo3.Value = this.txtBirthNo3.Text.Trim();
            if (this.txtBirthDate3.Text != "")
                bo.BirthDate3.Value = Convert.ToDateTime(this.txtBirthDate3.Text);

            bo.AdoptNo3.Value = this.txtAdoptNo3.Text.Trim();

            bo.CreateUser.Value = userID;
            bo.CreateTime.Value = DateTime.Now;

            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWPerInfo bo = new BusinessMapping.CWPerInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWPerInfo");
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
                bo.Name.Value = this.txtName.Text.Trim();
                if (this.ddlSex.SelectedValue != string.Empty && this.ddlSex.SelectedValue != "0")
                    bo.Sex.Value = Convert.ToInt32(this.ddlSex.SelectedValue);
                else
                    bo.Sex.Value = 0;

                if (this.ddlNation.SelectedValue != string.Empty && this.ddlNation.SelectedValue != "0")
                    bo.Nation.Value = Convert.ToInt32(this.ddlNation.SelectedValue);
                else
                    bo.Nation.Value = 0;

                if (this.ddlPolitics.SelectedValue != string.Empty && this.ddlPolitics.SelectedValue != "0")
                    bo.Politics.Value = Convert.ToInt32(this.ddlPolitics.SelectedValue);
                else
                    bo.Politics.Value = 0;

                if (this.ddlIsHolder.SelectedValue != string.Empty && this.ddlIsHolder.SelectedValue != "0")
                    bo.IsHolder.Value = Convert.ToInt32(this.ddlIsHolder.SelectedValue);
                else
                    bo.IsHolder.Value = 0;

                bo.HolderName.Value = this.txtHolderName.Text.Trim();
                bo.HolderIDCardNo.Value = this.txtHolderIDCardNo.Text.Trim();
                if (this.ddlHolderPorp.SelectedValue != "" && this.ddlHolderPorp.SelectedValue != "0")
                    bo.HolderPorp.Value = Convert.ToInt32(this.ddlHolderPorp.SelectedValue);
                else
                    bo.HolderPorp.Value = 0;

                bo.HolderAddress.Value = this.txtHolderAddress.Text.Trim();
                bo.LiveAddress.Value = this.txtLiveAddress.Text.Trim();
                bo.LinkPhone.Value = this.txtLinkPhone.Text.Trim();
                bo.WorkUnit.Value = this.txtWorkUnit.Text.Trim();
                if (this.ddlMarrigeStatus.SelectedValue != string.Empty && this.ddlMarrigeStatus.SelectedValue != "0")
                    bo.MarrigeStatus.Value = Convert.ToInt32(this.ddlMarrigeStatus.SelectedValue);
                else
                    bo.MarrigeStatus.Value = 0;

                if (this.txtMarrigeDate.Text != "")
                    bo.MarrigeDate.Value = Convert.ToDateTime(this.txtMarrigeDate.Text);

                bo.MarrigeNo.Value = this.txtMarrigeNo.Text.Trim();
                bo.MarrigeName.Value = this.txtMarrigeName.Text.Trim();
                bo.MarrigeIDCardNo.Value = this.txtMarrigeIDCardNo.Text.Trim();
                if (this.ddlChildren.SelectedValue != string.Empty && this.ddlChildren.SelectedValue != "0")
                    bo.Children.Value = Convert.ToInt32(this.ddlChildren.SelectedValue);
                else
                    bo.Children.Value = 0;
                if (this.ddlIsSingle.SelectedValue != string.Empty && this.ddlIsSingle.SelectedValue != "0")
                    bo.IsSingle.Value = Convert.ToInt32(this.ddlIsSingle.SelectedValue);
                else
                    bo.IsSingle.Value = 0;

                bo.ChildName1.Value = this.txtChildName1.Text.Trim();
                bo.ChildIDCardNo1.Value = this.txtChildIDCardNo1.Text.Trim();
                bo.ChildAddress1.Value = this.txtChildAddress1.Text.Trim();
                bo.BirthNo1.Value = this.txtBirthNo1.Text.Trim();
                if (this.txtBirthDate1.Text != "")
                    bo.BirthDate1.Value = Convert.ToDateTime(this.txtBirthDate1.Text);

                bo.AdoptNo1.Value = this.txtAdoptNo1.Text.Trim();
                bo.ChildName2.Value = this.txtChildName2.Text.Trim();
                bo.ChildIDCardNo2.Value = this.txtChildIDCardNo2.Text.Trim();
                bo.ChildAddress2.Value = this.txtChildAddress2.Text.Trim();
                bo.BirthNo2.Value = this.txtBirthNo2.Text.Trim();
                if (this.txtBirthDate2.Text != "")
                    bo.BirthDate2.Value = Convert.ToDateTime(this.txtBirthDate2.Text);

                bo.AdoptNo2.Value = this.txtAdoptNo2.Text.Trim();
                bo.ChildName3.Value = this.txtChildName3.Text.Trim();
                bo.ChildIDCardNo3.Value = this.txtChildIDCardNo3.Text.Trim();
                bo.ChildAddress3.Value = this.txtChildAddress3.Text.Trim();
                bo.BirthNo3.Value = this.txtBirthNo3.Text.Trim();
                if (this.txtBirthDate3.Text != "")
                    bo.BirthDate3.Value = Convert.ToDateTime(this.txtBirthDate3.Text);

                bo.AdoptNo3.Value = this.txtAdoptNo3.Text.Trim();

                bo.ModifyUser.Value = userID;
                bo.ModifyTime.Value = DateTime.Now;
                bo.Memo.Value = this.txtMemo.Text.Trim();

                bo.Update();
            }
        }

        #endregion

        #region 绑定下了列表
        public static void DictionaryList(System.Web.UI.WebControls.DropDownList DropOnDictionary,string type)
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
            this.validateNation.ServerValidate += new ServerValidateEventHandler(validateNation_ServerValidate);
            this.validatePolitics.ServerValidate += new ServerValidateEventHandler(validatePolitics_ServerValidate);
            this.validateIsHolder.ServerValidate += new ServerValidateEventHandler(validateIsHolder_ServerValidate);
            this.validateHolderPorp.ServerValidate += new ServerValidateEventHandler(validateHolderPorp_ServerValidate);
            this.validateMarrigeStatus.ServerValidate += new ServerValidateEventHandler(validateMarrigeStatus_ServerValidate);

            BindForeignKeyData();
        }

        private void BindForeignKeyData()
        {
            DictionaryList(ddlSex, GlobalFacade.DictionaryType.Type_2.ToString());
            DictionaryList(ddlNation, GlobalFacade.DictionaryType.Type_3.ToString());
            DictionaryList(ddlPolitics, GlobalFacade.DictionaryType.Type_4.ToString());
            DictionaryList(ddlIsHolder, GlobalFacade.DictionaryType.Type_5.ToString());
            DictionaryList(ddlHolderPorp, GlobalFacade.DictionaryType.Type_6.ToString());
            DictionaryList(ddlMarrigeStatus, GlobalFacade.DictionaryType.Type_7.ToString());
            DictionaryList(ddlChildren, GlobalFacade.DictionaryType.Type_8.ToString());
            DictionaryList(ddlIsSingle, GlobalFacade.DictionaryType.Type_5.ToString());
        }
        #endregion
    }
}