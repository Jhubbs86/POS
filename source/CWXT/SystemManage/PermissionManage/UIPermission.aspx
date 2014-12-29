<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIPermission.aspx.cs" Inherits="CWXT.SystemManage.PermissionManage.UIPermission" %>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uccs" TagName="CustomPaging" Src="~/CustomControls/CustomPaging.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>界面权限管理</title>
</head>
<body class="common" oncontextmenu="self.event.returnValue=false" oncopy="return false;"
    oncut="return false;" onselectstart="return false;" onpaste="return false;">
    <form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <!--标题-->
                <span class="txtPageTitle">界面权限管理</span>
            </td>
            <td>
                <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                    <iewc:ToolbarButton Text="&#160;配置" ToolTip="配置" ImageUrl="../../image/AnswerIcon.gif"
                        ID="btnConfig"></iewc:ToolbarButton>
                </iewc:Toolbar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr/>
            </td>
        </tr>
    </table>
    <table class="panel" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table class="detailInfo" cellspacing="0" cellpadding="3">
                    <tr>
                        <!--DataGrid-->
                        <td>
                            <asp:DataGrid ID="dgRole" CssClass="DGStyle" AllowCustomPaging="True" AutoGenerateColumns="False"
                                runat="server">
                                <HeaderStyle CssClass="DGHeaderStyle"></HeaderStyle>
                                <ItemStyle CssClass="DGItemStyle"></ItemStyle>
                                <AlternatingItemStyle CssClass="DGAlternatingItemStyle"></AlternatingItemStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderStyle-Width="1%" HeaderStyle-Wrap="False">
                                        <ItemTemplate>
                                            <asp:RadioButton runat="server" ID="Radiobutton1"></asp:RadioButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="PKID" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="RoleCode" HeaderText="用户组代码"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="RoleName" HeaderText="用户组名称"></asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                            <uccs:CustomPaging ID="ucCustomPaging" runat="server"></uccs:CustomPaging>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
