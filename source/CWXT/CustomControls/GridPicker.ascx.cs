using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;

using Wicresoft.BusinessObject;

namespace CWXT.CustomControls
{
    /// <summary>
    ///		GridPicker 的摘要说明。
    /// </summary>
    public partial class GridPicker : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.tbxSelectedText.Attributes.Add("readonly", "true");
        }

        public bool Readonly
        {
            set
            {
                if (value)
                {
                    this.btnSelect.Visible = false;
                    this.tbxSelectedText.BackColor = Enums.SystemColor.ReadonlyBackColor;
                }
                else
                {
                    this.btnSelect.Visible = true;
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

        public string SelectedValue
        {
            get
            {
                return this.tbxSelectedValue.Text;
            }
            set
            {
                this.tbxSelectedValue.Text = value;
                this.tbxSelectedText.Text = BusinessObjectView.GetDisplayValueFromPKID(value);
            }
        }


        public BusinessObject BusinessObject
        {
            get { return this.BusinessObjectView.GetBindingObject("PKID", this.SelectedValue); }
        }


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


        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            this.AppendServerEvents();
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

        private void GridPicker_PreRender(object sender, EventArgs e)
        {
            this.btnSelect.Style.Add("cursor", "hand");
            this.btnSelect.Attributes.Add("onclick",
                string.Format("if(window.showModalDialog('{0}/CustomControls/GridView.aspx?textControl={1}&valueControl={2}&viewName={3}&{6}={4}&__level={5}&viewObjectGUID={7}',window,'dialogWidth:720px;dialogHeight:550px;center:yes;edge:raised;help:no;resizable:no;scroll:yes;status:no;'))" + ((this.AutoPostBack) ? "{{__doPostBack('" + this.btnRefresh.UniqueID + "','');}}" : "{{}}"),
                Request.ApplicationPath, this.tbxSelectedText.ClientID, this.tbxSelectedValue.ClientID, this.viewName, OpenerID + "_" + this.Page.ID + "_" + this.UniqueID, this.Level, Enums.Constants.PageID, viewObjectGUID));
        }
    }
}
