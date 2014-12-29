<%@ Page Language="c#" CodeBehind="UserList.aspx.cs" AutoEventWireup="True" Inherits="CWXT.SystemManage.UserManage.UserList" %>

<%@ Register TagPrefix="uccs" TagName="CustomPaging" Src="~/CustomControls/CustomPaging.ascx" %>
<%@ Register TagPrefix="uccs" TagName="GridPicker" Src="~/CustomControls/GridPicker.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>用户信息管理</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body class="common" oncontextmenu="self.event.returnValue=false" oncopy="return false;"
    oncut="return false;" onselectstart="return false;" onpaste="return false;">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <!--标题-->
                    <span class="txtPageTitle">用户信息管理</span></td>
                <td>
                    <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                        <iewc:ToolbarButton ID="btnModifyUserPasssword" ImageUrl="../../image/smsuser.gif" ToolTip="修改用户密码"
                            Text="&nbsp;修改用户密码"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton ID="btnQuery" ImageUrl="../../image/AnswerIcon.gif" ToolTip="查询" Text="&nbsp;查询"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr>
                </td>
            </tr>
        </table>
        <table class="panel" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table class="detailInfo" cellspacing="0" cellpadding="3">
                        <tr>
                            <!--工具条-->
                            <td>
                                <asp:Label ID="lblQueryDesc" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td class="ToolBarStyle">
                                <asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_NEW_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_NEW_DOWN.gif')"
                                    ID="btnNew" runat="server" AlternateText="新增" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_NEW_UP.gif"></asp:ImageButton>
                                <asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_EDIT_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_EDIT_DOWN.gif')"
                                    ID="btnEdit" runat="server" AlternateText="编辑" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_EDIT_UP.gif"></asp:ImageButton>
                                <asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_DEL_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_DEL_DOWN.gif')"
                                    ID="btnDel" runat="server" AlternateText="删除" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_DEL_UP.gif"></asp:ImageButton>
                                <asp:ImageButton onmouseup="ImgBtnOnMouseUp('../../image/BTN_VIEW_UP.gif')" onmousedown="ImgBtnOnMouseDown('../../image/BTN_VIEW_DOWN.gif')"
                                    ID="btnView" runat="server" AlternateText="查看" CssClass="ImageButtonStyle" ImageUrl="../../image/BTN_VIEW_UP.gif"></asp:ImageButton>
                            </td>
                        </tr>
                        <tr>
                            <!--DataGrid-->
                            <td colspan="3">
                                <asp:DataGrid ID="dgUser" CssClass="DGStyle" runat="server" AutoGenerateColumns="False" AllowCustomPaging="True">
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
                                        <asp:BoundColumn DataField="Alias" HeaderText="Alias"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ChineseName" HeaderText="中文名"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="性别">
                                            <ItemTemplate>
                                                <%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Gender"))?"男":"女"%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="RoleName" HeaderText="用户组"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CreateUserName" HeaderText="创建者"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CreateTime" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ModifyUserName" HeaderText="最后修改者"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ModifyTime" HeaderText="最后修改时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                    </Columns>
                                </asp:DataGrid>
                                <uccs:CustomPaging ID="ucCustomPaging" runat="server"></uccs:CustomPaging>
                                <asp:LinkButton ID="btnRefreshData" runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
