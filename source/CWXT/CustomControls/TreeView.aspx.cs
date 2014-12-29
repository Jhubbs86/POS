using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CWXT.CustomControls
{
	/// <summary>
	/// TreeView 的摘要说明。
	/// </summary>
	public partial class TreeView : EnterpriseWebsite.WebUI.ScrollPage
	{
		protected Microsoft.Web.UI.WebControls.ToolbarButton btnClose;
		protected Microsoft.Web.UI.WebControls.ToolbarButton btnClear;
		
		protected string Title = string.Empty;
		private string textControlID = string.Empty;
		private string valueControlID = string.Empty;
		private BusinessRule.SystemManage.DictionaryType dictionaryType;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(! this.IsPostBack)
			{

				BusinessRule.SystemManage.Dictionary rule = new BusinessRule.SystemManage.Dictionary();
				rule.Type = dictionaryType;
				rule.GenerateTree(this.tvControl);

				this.tvControl.TreeNodeTypeSrc = "TreeNodeTypesWithCheckBox.xml";
				this.tvControl.ChildType = "0";
				this.tvControl.ExpandLevel = int.MaxValue;
				this.tvControl.AutoPostBack = true;
				this.tvControl.DataBind();
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			this.AppendServerEvents();
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void AppendServerEvents()
		{
			this.btnClose.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClose_ButtonClick);
			this.btnClear.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnClear_ButtonClick);
			this.tvControl.Check += new Microsoft.Web.UI.WebControls.ClickEventHandler(tvControl_Check);

			textControlID = Request.QueryString["textControl"];
			valueControlID = Request.QueryString["valueControl"];
			dictionaryType = (BusinessRule.SystemManage.DictionaryType)int.Parse(Request.QueryString["type"]);

			AddClientScript();
			SetTitle();
		}

		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private bool btnClose_ButtonClick(object sender, EventArgs e)
		{
			Page.RegisterStartupScript("__CloseWindow", "<script>window.close();</script>");

			// event does not bubble
			return false;
		}

		private bool btnClear_ButtonClick(object sender, EventArgs e)
		{
			Page.RegisterStartupScript("__Clear", 
				string.Format("<script>SetControlText('{0}','{1}');SetControlText('{2}','{3}');window.close();</script>", 
				this.textControlID, string.Empty, this.valueControlID, string.Empty));

			return false;
		}

		private void AddClientScript()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder("<SCRIPT LANGUAGE='JavaScript'>");
			sb.Append("function SetControlText(ctlID, text)");
			sb.Append("{");
			sb.Append("var parentWnd = window.dialogArguments;");
			sb.Append("parentWnd.document.getElementById(ctlID).value=text");
			sb.Append("}");
			sb.Append("</SCRIPT>");

			Page.RegisterClientScriptBlock("__SetControlText", sb.ToString());
		}

		private void tvControl_Check(object sender, Microsoft.Web.UI.WebControls.TreeViewClickEventArgs e)
		{
			Microsoft.Web.UI.WebControls.TreeNode selectedNode = this.tvControl.GetNodeFromIndex(e.Node);

			Page.RegisterStartupScript("__SetSelectedObject",
				string.Format("<script language='javascript'>SetControlText('{0}','{1}');SetControlText('{2}','{3}');window.close();</script>", 
				this.textControlID, selectedNode.Text,
				this.valueControlID, selectedNode.NodeData));
		}

		private void SetTitle()
		{
			switch(this.dictionaryType)
			{
//				case BusinessRule.SystemManage.DictionaryType.Department:
//					this.Title = "选择部门";
//					break;
//				case BusinessRule.SystemManage.DictionaryType.Product:
//					this.Title = "选择产品";
//					break;
				case BusinessRule.SystemManage.DictionaryType.Region:
					this.Title = "选择区域";
					break;
				case BusinessRule.SystemManage.DictionaryType.Unknown:
					this.Title = "未知";
					break;
			}
		}
	}
}
