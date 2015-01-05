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

namespace CWXT.JHSY.CWInfoManage
{
    public partial class CWInfo : System.Web.UI.UserControl
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
            SetDateControlStyle();
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
            BusinessMapping.CWInfo bo = new BusinessMapping.CWInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWInfo");
            filter.AddFilterItem("PKID", pkid.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                txtVillageName.Text = bo.VillageName.Value;
                txtLocation.Text = bo.Location.Value;
                if (bo.District.Value > 0)
                {
                    ddlDistrict.SelectedValue = bo.District.Value.ToString();
                }
                if (bo.TotalPeps.Value > 0)
                {
                    txtTotalPeps.Text = bo.TotalPeps.Value.ToString();
                }
                if (bo.IndusValue.Value > 0)
                {
                    txtIndusValue.Text = bo.IndusValue.Value.ToString();
                }
                txtVillageChief.Text = bo.VillageChief.Value;
                txtMemo.Text = bo.Memo.Value;
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

        private void validateVillageName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtVillageName.Text.Trim()))
            {
                BusinessRule.Common rule = new BusinessRule.Common();
                args.IsValid = rule.IsFieldExclusiveM("VillageName", this.txtVillageName.Text.Trim(), "CWInfo", true, this.PKID);
            }
        }

        private void validatetxtDistrict_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
        }

        private void validatetxtTotalPeps_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtTotalPeps.Text.Trim()))
            {
                this.validatetxtTotalPeps.ErrorMessage = ResourceManager.Instance.GetString("TotalPepsStyle");
                args.IsValid = BusinessRule.Common.ValidateIntegerStyle(this.txtTotalPeps.Text.Trim()) ? true : false;
            }
        }

        private void validatetxtIndusValue_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtIndusValue.Text.Trim()) && !GlobalFacade.Utils.IsDecimal(this.txtIndusValue.Text.Trim()))
            {
                this.validatetxtIndusValue.ErrorMessage = ResourceManager.Instance.GetString("IndusValueStyle");
                args.IsValid = false;
            }
        }
        #endregion

        #region Save | Update

        public void Save()
        {
            int userID = GlobalFacade.SystemContext.GetContext().UserID;
            BusinessMapping.CWInfo bo = new BusinessMapping.CWInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            bo.VillageName.Value = this.txtVillageName.Text.Trim();
            bo.Location.Value = this.txtLocation.Text.Trim();
            if (this.ddlDistrict.SelectedValue != "" && this.ddlDistrict.SelectedValue != "0")
                bo.District.Value = Convert.ToInt32(this.ddlDistrict.SelectedValue);

            if (this.txtTotalPeps.Text.Trim() != "")
                bo.TotalPeps.Value = Convert.ToInt32(this.txtTotalPeps.Text.Trim());

            if (this.txtIndusValue.Text.Trim() != "")
                bo.IndusValue.Value = Convert.ToDecimal(this.txtIndusValue.Text.Trim());

            bo.VillageChief.Value = this.txtVillageChief.Text.Trim();

            bo.Memo.Value = this.txtMemo.Text.Trim();

            bo.CreateTime.Value = DateTime.Now;
            bo.ModifyTime.Value = DateTime.Now;
            bo.CreateUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
            bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;

            bo.Insert();
        }

        public void Update()
        {
            BusinessMapping.CWInfo bo = new BusinessMapping.CWInfo();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("CWInfo");
            filter.AddFilterItem("PKID", this.PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
            {
                int userID = GlobalFacade.SystemContext.GetContext().UserID;

                bo.VillageName.Value = this.txtVillageName.Text.Trim();
                bo.Location.Value = this.txtLocation.Text.Trim();
                if (this.ddlDistrict.SelectedValue != "" && this.ddlDistrict.SelectedValue != "0")
                    bo.District.Value = Convert.ToInt32(this.ddlDistrict.SelectedValue);
                else
                    bo.District.Value = 0;

                if (this.txtTotalPeps.Text.Trim() != "")
                    bo.TotalPeps.Value = Convert.ToInt32(this.txtTotalPeps.Text.Trim());

                if (this.txtIndusValue.Text.Trim() != "")
                    bo.IndusValue.Value = Convert.ToDecimal(this.txtIndusValue.Text.Trim());

                bo.VillageChief.Value = this.txtVillageChief.Text.Trim();

                bo.ModifyTime.Value = DateTime.Now;
                bo.Memo.Value = this.txtMemo.Text.Trim();

                bo.ModifyTime.Value = DateTime.Now;
                bo.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;

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
            this.validateVillageName.ServerValidate += new ServerValidateEventHandler(validateVillageName_ServerValidate);
            this.validatetxtDistrict.ServerValidate += new ServerValidateEventHandler(validatetxtDistrict_ServerValidate);
            this.validatetxtTotalPeps.ServerValidate += new ServerValidateEventHandler(validatetxtTotalPeps_ServerValidate);
            this.validatetxtIndusValue.ServerValidate += new ServerValidateEventHandler(validatetxtIndusValue_ServerValidate);

            BindForeignKeyData();
        }

        private void SetDateControlStyle()
        {

        }

        private void BindForeignKeyData()
        {
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("Type", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            boc.AddFilter(filter);

            ddlDistrict.DataSource = boc.GetDataTable();
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "PKID";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem(ResourceManager.Instance.GetString("PleaseSelect"), "0"));
        }

        #endregion
    }
}