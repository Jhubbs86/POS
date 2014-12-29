<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryRole.aspx.cs" Inherits="CWXT.SystemManage.RoleManage.QueryRole" %>

<%@ Register TagPrefix="uc1" TagName="QueryProvider" Src="~/CustomControls/QueryProvider.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>查询用户组</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<base target="_self"/>
  </head>
	<body class="common">
		<form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="100%" border="0"> <!--工具条-->
				<tr>
					<td><!--标题--><span class="txtPageTitle">查询用户组</span></td>
					<td><iewc:toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<IEWC:TOOLBARBUTTON id="btnQuery" ToolTip="查询" ImageUrl="../../image/AnswerIcon.gif" Text="&nbsp;查询"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClear" Text="&nbsp;清除" ToolTip="清除" ImageUrl="../../image/AnswerIcon.gif"></IEWC:TOOLBARBUTTON>
							<IEWC:TOOLBARSEPARATOR></IEWC:TOOLBARSEPARATOR>
							<IEWC:TOOLBARBUTTON id="btnClose" ToolTip="关闭" ImageUrl="../../image/exit.png" Text="&nbsp;关闭"></IEWC:TOOLBARBUTTON>
						</iewc:toolbar>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<hr/>
					</td>
				</tr>
			</table>
			<table class="panel" cellspacing="0" cellpadding="5"> <!--主体-->
				<tr>
					<td>
						<uc1:QueryProvider id="ucQueryProvider" runat="server"></uc1:QueryProvider>
					</td>
				</tr>
			</table>
		</form>
	</body>
    </html>