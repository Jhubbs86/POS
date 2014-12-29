using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Reflection;

using Wicresoft.BusinessObject;

namespace CWXT.CustomControls
{
    /// <summary>
    ///		MultiSelectionPicker 的摘要说明。
    /// </summary>
    public partial class MultiSelectionPicker : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
        }

        public bool Readonly
        {
            set
            {
                if (value)
                {
                    this.btnSelect.Visible = false;
                    //					this.btnSelect.Style["display"] = "none";
                    this.tbxSelectedText.BackColor = Enums.SystemColor.ReadonlyBackColor;
                }
                else
                {
                    this.btnSelect.Visible = true;
                    //					this.btnSelect.Style["display"] = "block";
                    this.tbxSelectedText.BackColor = Color.Empty;
                }
            }
        }

        public string Width
        {
            set { this.tbxSelectedText.Width = new Unit(value); }
        }

        public string SelectedText
        {
            get { return this.tbxSelectedText.Text.Trim(); }
        }

        public string SelectedValues
        {
            get
            {
                return this.tbxSelectedValue.Text;
            }
            set
            {
                if (value == null || value == string.Empty)
                    return;

                string[] pkids = value.Split(',');

                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                for (int i = 0; i < pkids.Length; i++)
                {
                    string pkid = pkids[i];
                    string displayValue;

                    if (!GlobalFacade.Utils.IsInt(pkid))
                        continue;

                    displayValue = this.BusinessObjectView.GetDisplayValueFromPKID(pkid);

                    sb1.Append(pkid);
                    sb1.Append(",");

                    sb2.Append(displayValue);
                    sb2.Append(",");
                }

                string values = sb1.ToString();
                string text = sb2.ToString();

                this.tbxSelectedValue.Text = (values != string.Empty) ? values.Substring(0, values.Length - 1) : string.Empty;
                this.tbxSelectedText.Text = (text != string.Empty) ? text.Substring(0, text.Length - 1) : string.Empty;
            }
        }

        public BusinessObjectCollection SelectedObjects
        {
            get
            {
                if (this.tbxSelectedValue.Text != string.Empty)
                {
                    BusinessFilter filter = new BusinessFilter(this.BusinessObjectView.BusinessObjectName);
                    filter.AddCustomerFilter("[" + this.BusinessObjectView.BusinessObjectName + "].PKID IN (" + this.tbxSelectedValue.Text + ")", AndOr.AND);

                    BusinessObjectCollection boc = new BusinessObjectCollection(this.BusinessObjectView.BusinessObjectName);
                    boc.SessionInstance = new Wicresoft.Session.Session();
                    boc.AddFilter(filter);
                    boc.Query();
                    return boc;
                }
                else
                    return new BusinessObjectCollection(this.BusinessObjectView.BusinessObjectName);
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();

                    for (int i = 0; i < value.Count; i++)
                    {
                        BusinessObject bo = value[i];
                        FieldInfo fi = bo.GetType().GetField(this.BusinessObjectView.PKField.FieldName);
                        FieldInfo fi2 = bo.GetType().GetField(this.BusinessObjectView.DisplayField.FieldName);

                        string pkid = (fi.GetValue(bo) as IntField).Value.ToString();
                        string displayValue;

                        if ((fi2.GetValue(bo) as StringField) != null)
                        {
                            displayValue = (fi2.GetValue(bo) as StringField).Value;
                        }
                        else
                            displayValue = this.BusinessObjectView.GetDisplayValueFromPKID(pkid);

                        sb1.Append(pkid);
                        sb1.Append(",");

                        sb2.Append(displayValue);
                        sb2.Append(",");
                    }

                    string pkids = sb1.ToString();
                    string text = sb2.ToString();

                    this.tbxSelectedValue.Text = (pkids != string.Empty) ? pkids.Substring(0, pkids.Length - 1) : string.Empty;
                    this.tbxSelectedText.Text = (text != string.Empty) ? text.Substring(0, text.Length - 1) : string.Empty;
                }
                else
                {
                    this.tbxSelectedValue.Text = string.Empty;
                    this.tbxSelectedText.Text = string.Empty;
                }
            }
        }

        //		public string SelectedValue
        //		{
        //			get 
        //			{
        //				return this.tbxSelectedValue.Text; 
        //			}
        //			set 
        //			{ 
        //				this.tbxSelectedValue.Text = value;
        //				this.tbxSelectedText.Text = BusinessObjectView.GetDisplayValueFromPKID(value);
        //			}
        //		}


        //		public BusinessObject BusinessObject
        //		{
        //			get { return this.BusinessObjectView.GetBindingObject("PKID", this.SelectedValue); }
        //		}

        private string viewObjectGUID
        {
            get
            {
                if (this.ViewState["viewObjectGUID"] == null)
                {
                    this.ViewState["viewObjectGUID"] = Guid.NewGuid().ToString();
                }
                return this.ViewState["viewObjectGUID"].ToString();
            }
        }
        public BusinessObjectView BusinessObjectView
        {
            get
            {
                if (Session[viewObjectGUID] == null)
                {
                    BusinessView.Common bv = new BusinessView.Common();
                    Session[viewObjectGUID] = bv.GetBusinessObjectViewFromName(this.viewName);
                }
                return Session[viewObjectGUID] as BusinessObjectView;
            }
        }

        private string viewName = string.Empty;
        public string BusinessObjectViewName
        {
            get { return this.viewName; }
            set { this.viewName = value; }
        }

        private string OpenerID
        {
            get { return this.Request.QueryString["openerId"]; }
        }

        private string Level
        {
            get
            {
                if (this.Request.QueryString["__level"] == null)
                {
                    return "1";
                }
                else
                {
                    return Convert.ToString(Convert.ToInt32(this.Request.QueryString["__level"]) + 1);
                }
            }
        }


        public bool AutoPostBack
        {
            get
            {
                if (this.ViewState["AutoPostBack"] == null)
                    this.ViewState["AutoPostBack"] = false;
                return Convert.ToBoolean(this.ViewState["AutoPostBack"]);
            }
            set { this.ViewState["AutoPostBack"] = value; }
        }


        /// <summary>
        /// PostBack事件
        /// </summary>
        public event EventHandler PostBack;


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (PostBack != null)
                PostBack(sender, e);
        }

        private void GridPicker_PreRender(object sender, EventArgs e)
        {
            this.tbxSelectedText.Attributes.Add("readonly", "true");
            this.btnSelect.Style.Add("cursor", "hand");
            this.btnSelect.Attributes.Add("onclick",
                string.Format("window.showModalDialog('{0}/CustomControls/MultiSelectionView.aspx?textControl={1}&valueControl={2}&viewName={3}&{6}={4}&__level={5}&viewObjectGUID={7}',window,'dialogWidth:720px;dialogHeight:550px;center:yes;edge:raised;help:no;resizable:no;scroll:yes;status:no;');" + ((this.AutoPostBack) ? "__doPostBack('" + this.btnRefresh.UniqueID + "','')" : string.Empty),
                Request.ApplicationPath, this.tbxSelectedText.ClientID, this.tbxSelectedValue.ClientID, this.viewName, OpenerID + "_" + this.Page.ID + "_" + this.UniqueID, this.Level, Enums.Constants.PageID, viewObjectGUID));
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
            AppendServerEvents();
        }

        private void AppendServerEvents()
        {
            this.PreRender += new EventHandler(GridPicker_PreRender);
            this.btnRefresh.Click += new EventHandler(btnRefresh_Click);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}
