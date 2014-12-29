<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="CWXT.SystemManage.RoleManage.RoleList" %>

<%@ Register TagPrefix="uccs" TagName="CustomPaging" Src="~/CustomControls/CustomPaging.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>用户组管理（查看）</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
	</head>
	<body class="common" oncontextmenu="self.event.returnValue=false" oncopy="return false;"
		oncut="return false;" onselectstart="return false;" onpaste="return false;">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr>
					<td><!--标题--><span class="txtPageTitle">用户组管理（查看）</span></td>
					<td>
						<iewc:Toolbar id="Toolbar" runat="server" CssClass="MSToolBar">
							<IEWC:TOOLBARBUTTON id="btnQuery" ImageUrl="../../image/AnswerIcon.gif" Tooltip="查询" Text="&nbsp;查询"></IEWC:TOOLBARBUTTON>
						</iewc:Toolbar>
					</td>
				</tr>
				<tr>
					<td colspan="2"><hr>
					</td>
				</tr>
			</table>
			<table class="panel" cellspacing="0" cellpadding="0">
				<tr>
					<td>
						<table class="detailInfo" cellspacing="0" cellpadding="3">
							<tr> <!--工具条-->
								<td>
									<asp:Label ID="lblQueryDesc" Runat="server"></asp:Label>
								</td>
								<td class="ToolBarStyle">
									<asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_NEW_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_NEW_DOWN.gif')"
										id="btnNew" Runat="server" AlternateText="新增" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_NEW_UP.gif"></asp:ImageButton>
									<asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_EDIT_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_EDIT_DOWN.gif')"
										id="btnEdit" Runat="server" AlternateText="编辑" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_EDIT_UP.gif"></asp:ImageButton>
									<asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_DEL_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_DEL_DOWN.gif')"
										id="btnDel" Runat="server" AlternateText="删除" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_DEL_UP.gif"></asp:ImageButton>
									<asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_VIEW_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_VIEW_DOWN.gif')"
										id="btnView" Runat="server" AlternateText="查看" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_VIEW_UP.gif"></asp:ImageButton>
								</td>
							</tr>
							<tr> <!--DataGrid-->
								<td colspan="2"><asp:datagrid id="dgRole" CssClass="DGStyle" Runat="server" AutoGenerateColumns="False" AllowCustomPaging="True">
										<HeaderStyle CssClass="DGHeaderStyle"></HeaderStyle>
										<ItemStyle CssClass="DGItemStyle"></ItemStyle>
										<AlternatingItemStyle CssClass="DGAlternatingItemStyle"></AlternatingItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderStyle-Width="1%" HeaderStyle-Wrap="False">
												<ItemTemplate>
													<asp:RadioButton Runat="server" ID="Radiobutton1"></asp:RadioButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="PKID" Visible="False"></asp:BoundColumn>
											<asp:BoundColumn DataField="RoleCode" HeaderText="用户组代码"></asp:BoundColumn>
											<asp:BoundColumn DataField="RoleName" HeaderText="用户组名称"></asp:BoundColumn>
											<asp:BoundColumn DataField="CreateUserName" HeaderText="创建者"></asp:BoundColumn>
											<asp:BoundColumn DataField="CreateTime" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
											<asp:BoundColumn DataField="ModifyUserName" HeaderText="最后修改者"></asp:BoundColumn>
											<asp:BoundColumn DataField="ModifyTime" HeaderText="最后修改时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<uccs:CustomPaging id="ucCustomPaging" runat="server"></uccs:CustomPaging>
									<asp:LinkButton ID="btnRefreshData" Runat="server"></asp:LinkButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>

