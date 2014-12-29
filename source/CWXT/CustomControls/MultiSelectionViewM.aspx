<%@ Page language="c#" Codebehind="MultiSelectionViewM.aspx.cs" AutoEventWireup="True" Inherits="CWXT.CustomControls.MultiSelectionViewM" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="CustomPaging" Src="CustomPaging.ascx" %>
<%@ Register TagPrefix="uc1" TagName="QueryProvider" Src="QueryProvider.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Title%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
		<script language="javascript">
<!--
			var selectedText, selectedValues;
			var aryText, aryValues;
			var textControlID, valueControlID;
			var dgUniqueID;

			function ClientInit()
			{
				dgUniqueID = "2F5872A8-BF33-4f43-8845-9469DAD8F2B6";
				
				textControlID = document.all("__textControlID").value;
				valueControlID = document.all("__valueControlID").value;
				
				selectedValues = window.dialogArguments.document.all(valueControlID).value;
				aryValues = (selectedValues == "")?new Array():selectedValues.split(",");
				
				selectedText = window.dialogArguments.document.all(textControlID).value;
				aryText = (selectedText == "")?new Array():selectedText.split(",");
			}
			
			function InitCheckbox()
			{
				var tbl = document.getElementById("2F5872A8-BF33-4f43-8845-9469DAD8F2B6");
				if(tbl)
				{
					// SortTable.js会导致排续后丢失checkbox状态，所以需要重新绑定checkbox状态
					tbl.rows[0].attachEvent("onclick",InitCheckbox);
					
					for(var i = 1; i < tbl.rows.length; i++)
					{
						if(aryValues.Contains(tbl.rows[i].cells[1].innerText))
							tbl.rows[i].cells[0].children[0].checked = true;
					}
				}
			}
			
			function SetControlText(ctlID, text)
			{
				selectedText = ProceedText(text).toString();
				window.dialogArguments.document.getElementById(ctlID).value = selectedText;
			}
			
			function SetControlValue(ctlID, value)
			{
				selectedValues = ProceedValues(value).toString();
				window.dialogArguments.document.getElementById(ctlID).value = selectedValues;
			}
			
			function SetControlTexts(ctlID, text)
			{			
			    var str = text.split(',');
			    for(var i = 0 ;i < str.length ;i++)
			    {
			        selectedText = ProceedTexts(str[i]).toString();
			    }
				window.dialogArguments.document.getElementById(ctlID).value = selectedText;
			}
			
			function SetControlValues(ctlID, value)
			{
			    var str = value.split(',');
			    for(var i = 0 ;i < str.length ;i++)
			    {
			        selectedValues = ProceedValuess(str[i]).toString();
			    }	    
				window.dialogArguments.document.getElementById(ctlID).value = selectedValues;
			}
			
			function ClearControl(ctlID)
			{
				window.dialogArguments.document.getElementById(ctlID).value = "";
			}
		
		
			Array.prototype.Contains = function(v) {
				for(var i = 0; i < this.length; i++)
				{
					if(this[i] == v)
						return true;
				}
				return false;
			}
			
			Array.prototype.Remove = function(v) {
				for(var i=0,n=0;i<this.length;i++)
				{
					if(this[i]!=v)
					{
						this[n++]=this[i]
					}
				}
				this.length-=1;
			}
			
			Array.prototype.Add = function(v) {
				this[this.length] = v;
			}
			
			function ProceedText(v) {
				if(aryText.Contains(v))
					aryText.Remove(v);
				else
					aryText.Add(v);
				return aryText;
			}
			
			function ProceedValues(v) {
				if(aryValues.Contains(v))
					aryValues.Remove(v);
				else
					aryValues.Add(v);
				return aryValues;
			}
			
			function ProceedTexts(v) {
				if(aryText.Contains(v))
					return aryText;
				else
					aryText.Add(v);
				return aryText;
			}
			
			function ProceedValuess(v) {
				if(aryValues.Contains(v))
					return aryValues;
				else
					aryValues.Add(v);
				return aryValues;
			}
//-->
		</script>
	</HEAD>
	<body class="common">
		<form id="Form" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0"> <!--工具条-->
				<tr>
					<td><!--标题--><span class="txtPageTitle"><%=Title%></span></td>
					<td><iewc:toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<IEWC:TOOLBARBUTTON id="btnSelectAll" Text="&nbsp;选中全部" ToolTip="选中全部" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnQuery" Text="&nbsp;再次查询" ToolTip="再次查询" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClear" Text="&nbsp;清除" ToolTip="清除" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnCloseWindow" Text="&nbsp;关闭" ToolTip="关闭" ImageUrl="../image/exit.png"></IEWC:TOOLBARBUTTON>
						</iewc:toolbar></td>
				</tr>
				<tr>
					<td colSpan="2">
						<hr>
					</td>
				</tr>
			</table>
			<table class="panel" cellSpacing="0" cellPadding="5"> <!--主体-->
				<tr>
					<td><uc1:QueryProvider id="ucQueryProvider" runat="server"></uc1:QueryProvider></td>
				</tr>
				<tr>
					<td>
						<%=GridViewHTML%>
						<uc1:custompaging id="ucCustomPaging" runat="server"></uc1:custompaging></td>
				</tr>
			</table>
		</form>
		<script language="javascript">
		<!--
		ClientInit();
		InitCheckbox();
		//-->
		</script>
	</body>
</HTML>