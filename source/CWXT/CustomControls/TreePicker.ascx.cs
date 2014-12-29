namespace CWXT.CustomControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Wicresoft.BusinessObject;

	/// <summary>
	///		TreePicker 的摘要说明。
	/// </summary>
	public partial class TreePicker : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            this.tbxSelectedText.Attributes.Add("readonly", "true");
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);

			this.PreRender += new EventHandler(TreePicker_PreRender);
		}
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		public bool Readonly
		{
			set
			{
				if(value)
				{
//					this.btnSelect.Attributes.Remove("onclick");
//					this.btnSelect.Style.Remove("cursor");
					this.btnSelect.Visible = false;
					this.tbxSelectedText.BackColor = Enums.SystemColor.ReadonlyBackColor;
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
//			set { this.tbxSelectedText.Text = value; }
		}

		public string SelectedValue
		{
			get { return this.tbxSelectedValue.Text; }
			set 
			{ 
				BusinessRule.SystemManage.Dictionary rule = new BusinessRule.SystemManage.Dictionary();
				this.tbxSelectedText.Text = rule.GetEntryNameById(value);
				this.tbxSelectedValue.Text = value;
			}
		}


		public BusinessMapping.Dictionary BusinessObject
		{
			get
			{
				BusinessFilter filter = new BusinessFilter("Dictionary");
				filter.AddFilterItem("PKID", this.SelectedValue, Operation.Equal, FilterType.NumberType, AndOr.AND);

				BusinessMapping.Dictionary bo = new BusinessMapping.Dictionary();
				bo.SessionInstance = new Wicresoft.Session.Session();
				bo.AddFilter(filter);
				bo.Load();
				return bo;
			}
		}

		public BusinessRule.SystemManage.DictionaryType DictionaryType
		{
			get 
			{
				if(this.ViewState["DictionaryType"] == null)
					this.ViewState["DictionaryType"] = BusinessRule.SystemManage.DictionaryType.Unknown;
				return (BusinessRule.SystemManage.DictionaryType)this.ViewState["DictionaryType"]; 
			}
			set { this.ViewState["DictionaryType"] = value; }
		}

		private void TreePicker_PreRender(object sender, EventArgs e)
		{
			if(this.DictionaryType == BusinessRule.SystemManage.DictionaryType.Unknown)
			{
				throw new Exception("请指定DictionaryType！");
			}

			this.btnSelect.Style.Add("cursor", "hand");
			this.btnSelect.Attributes.Add("onclick", 
				string.Format("window.showModalDialog('{0}/CustomControls/TreeView.aspx?textControl={1}&valueControl={2}&type={3}',window,'dialogWidth:720px;dialogHeight:550px;center:yes;edge:raised;help:no;resizable:no;scroll:yes;status:no;');", 
				Request.ApplicationPath, this.tbxSelectedText.ClientID, this.tbxSelectedValue.ClientID, (int)this.DictionaryType));
		}
	}
}
