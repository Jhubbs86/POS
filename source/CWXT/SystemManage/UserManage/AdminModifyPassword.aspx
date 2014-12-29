<%@ Page Language="c#" CodeBehind="AdminModifyPassword.aspx.cs" AutoEventWireup="True" Inherits="CWXT.SystemManage.UserManage.AdminModifyPassword" %>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>修改登录密码（管理员）</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body class="common">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <!--标题-->
                    <span class="txtPageTitle">修改登录密码（管理员）</span></td>
                <td>
                    <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                        <iewc:ToolbarButton ID="btnSave" Text="&nbsp;保存" ToolTip="保存" ImageUrl="../../image/AnswerIcon.gif"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator DefaultStyle="border:solid 1px #f1f1f1;cursor:hand;"></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton Text="&#160;返回" ToolTip="返回" ImageUrl="../../image/AnswerIcon.gif" ID="btnReturn"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                    <font face="宋体">
                        <asp:Label class="txtPageTitle" ID="Info" runat="server" ForeColor="Red"></asp:Label></font>
                </td>
            </tr>
        </table>
        <table class="panel" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table class="detailInfo" cellspacing="0" cellpadding="3">
                        <tr>
                            <td class="Field" width="1%">
                                <nobr>新密码*：</nobr>
                            </td>
                            <td width="1%">
                                <asp:TextBox ID="tbxNewPassword" Width="150" runat="server" TextMode="Password"></asp:TextBox></td>
                            <td><font face="宋体">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxNewPassword" ErrorMessage="新密码不能为空"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="ValidatorPwd" runat="server" ControlToValidate="tbxNewPassword" ErrorMessage="密码格式错误[必须包含数字、字母和特殊符号,必须大于等于8位数]"
                                    Enabled="True"></asp:CustomValidator></font></td>
                        </tr>
                        <tr>
                            <td class="Field" width="1%">
                                <nobr>再输入一次*：</nobr>
                            </td>
                            <td width="1%">
                                <asp:TextBox ID="tbxNewPasswordAgain" Width="150" runat="server" TextMode="Password"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxNewPasswordAgain"
                                    ErrorMessage="密码不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbxNewPasswordAgain" ErrorMessage="两次输入密码不一致"
                                    ControlToCompare="tbxNewPassword"></asp:CompareValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
