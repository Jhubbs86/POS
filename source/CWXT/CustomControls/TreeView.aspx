<%@ Page language="c#" Codebehind="TreeView.aspx.cs" AutoEventWireup="True" Inherits="CWXT.CustomControls.TreeView" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ OutputCache Duration="1" VaryByParam="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Title%>
		</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<base target="_self">
	</HEAD>
	<body class="common">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0"> <!--工具条-->
				<tr>
					<td><!--标题--><span class="txtPageTitle"><%=Title%></span></td>
					<td><iewc:toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<IEWC:TOOLBARBUTTON id="btnClear" Text="&nbsp;清除" ToolTip="清除" ImageUrl="../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClose" Text="&nbsp;关闭" ImageUrl="../image/exit.png" DefaultStyle="border:solid 1px #f1f1f1;cursor:hand;"
								HoverStyle="border:solid 1px Gray;background-color:#e1e1e1;" SelectedStyle="border:solid 1px Gray;"
								ToolTip="关闭"></IEWC:TOOLBARBUTTON>
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
					<td>
						<iewc:TreeView id="tvControl" runat="server"></iewc:TreeView>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
