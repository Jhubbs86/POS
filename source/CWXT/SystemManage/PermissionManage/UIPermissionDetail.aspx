<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIPermissionDetail.aspx.cs" Inherits="CWXT.SystemManage.PermissionManage.UIPermissionDetail" %>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>配置界面权限</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="WebTreeScript.js"></script>
		<script type="text/javascript">
		    function setSrc() {
		        var obj = document.getElementById("tvFunction");
		        obj.treeNodeSrc = oXML.XMLDocument.documentElement.xml;
		        obj.databind();
		    }
		</script>
	</head>
	<body class="common" onload="setSrc()">
		<form id="Form1" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td><!--标题--><span class="txtPageTitle">配置界面权限</span></td>
					<td><iewc:toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<iewc:ToolbarButton Text="&#160;保存" ImageUrl="../../image/save.gif" DefaultStyle="onclick:expression(onclick=function(){SaveMenuConfig();});border:solid 1px #f1f1f1;cursor:hand;"
								ID="btnSaveMenuConfig" ToolTip="保存"></iewc:ToolbarButton>
							<iewc:ToolbarSeparator></iewc:ToolbarSeparator>
							<iewc:ToolbarButton Text="&#160;返回" ImageUrl="../../image/AnswerIcon.gif" ID="btnReturn" ToolTip="返回"></iewc:ToolbarButton>
						</iewc:toolbar></td>
				</tr>
				<tr>
					<td colspan="2">
						<hr/>
					</td>
				</tr>
			</table>
			<iewc:tabstrip id="tsInfo" runat="server" TargetID="mpgInfo">
				<iewc:Tab Text="用户组"></iewc:Tab>
				<iewc:TabSeparator DefaultStyle="width:5px;"></iewc:TabSeparator>
				<iewc:Tab Text="权限配置"></iewc:Tab>
			</iewc:tabstrip><iewc:multipage id="mpgInfo" runat="server">
				<iewc:PageView id="pgSysRole">
					<table class="panel" id="prjInfo" cellspacing="0" cellpadding="0">
						<tr>
							<td>
								<table class="detailInfo" cellspacing="3" cellpadding="3">
									<tr>
										<td class="Field"><nobr>用户组代码</nobr></td>
										<td width="50%">
											<asp:textbox id="tbxRoleCode" Width="80%" runat="server"></asp:textbox></td>
										<td class="Field"><nobr>用户组名称</nobr></td>
										<td width="50%">
											<asp:textbox id="tbxRoleName" Width="80%" runat="server"></asp:textbox></td>
									</tr>
									<tr>
										<td class="FieldTop"><nobr>备注</nobr></td>
										<td width="50%">
											<asp:textbox id="tbxMemo" Width="80%" runat="server" Height="80px" TextMode="MultiLine"></asp:textbox></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</iewc:PageView>
				<iewc:PageView id="pgUIPermission">
					<table class="panel" cellspacing="0" cellpadding="0">
						<tr>
							<td>
								<table class="detailInfo" cellspacing="0" cellpadding="3">
									<tr>
										<td>
											<div class="ScrollDiv">
												<iewc:TreeView id="tvFunction" runat="server"></iewc:TreeView></div>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</iewc:PageView>
			</iewc:multipage>
			<input  id = "RolePKID"  type ="hidden" value = "<%= PKID %>"/>
		</form>
		<XML id="oXML">
			<% =OutXML%>
		</XML>
	</body>
</html>
