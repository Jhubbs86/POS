<%@ Page language="c#" Codebehind="GridView.aspx.cs" AutoEventWireup="false" Inherits="CWXT.CustomControls.GridView" %>
<%@ Register TagPrefix="uc1" TagName="QueryProvider" Src="QueryProvider.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="CustomPaging" Src="CustomPaging.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>
			<%=Title%>
		</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<base target="_self"/>
	</head>
	<body class="common">
		<form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="100%" border="0"> <!--工具条-->
				<tr>
					<td><!--标题--><span class="txtPageTitle"><%=Title%></span></td>
					<td><iewc:toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<IEWC:TOOLBARBUTTON id="btnQuery" Text="&nbsp;再次查询" ToolTip="再次查询" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClear" Text="&nbsp;清除" ToolTip="清除" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClose" Text="&nbsp;关闭" ToolTip="关闭" ImageUrl="../image/exit.png"></IEWC:TOOLBARBUTTON>
						</iewc:toolbar></td>
				</tr>
				<tr>
					<td colspan="2">
						<hr/>
					</td>
				</tr>
			</table>
			<table class="panel" cellspacing="0" cellpadding="5"> <!--主体-->
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
	</body>
</html>
