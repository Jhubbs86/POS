<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateRole.aspx.cs" Inherits="CWXT.SystemManage.RoleManage.CreateRole" %>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uccs" TagName="Role" Src="Role.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>新增用户组</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
  </head>
	<body class="common">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td><!--标题--><span class="txtPageTitle">新增用户组</span></td>
					<td><iewc:Toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<iewc:ToolbarButton Text="&#160;保存" Tooltip="保存" ImageUrl="../../image/AnswerIcon.gif" ID="btnSave"></iewc:ToolbarButton>
							 <IEWC:TOOLBARSEPARATOR DefaultStyle="border:solid 1px #f1f1f1;cursor:hand;"></IEWC:TOOLBARSEPARATOR>
							<iewc:ToolbarButton Text="&#160;返回" Tooltip="返回" ImageUrl="../../image/AnswerIcon.gif" ID="btnReturn"></iewc:ToolbarButton>
						</iewc:Toolbar></td>
				</tr>
				<tr>
					<td colspan="2"><hr/>
					</td>
				</tr>
			</table>
			<uccs:Role id="ucRole" runat="server"></uccs:Role>
		</form>
	</body>
</html>