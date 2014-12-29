<%@ Page Language="c#" CodeBehind="CheckPassword.aspx.cs" AutoEventWireup="True" Inherits="CWXT.SystemManage.UserManage.CheckPassword" %>

<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>CheckPassword</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
</head>
<body class="common">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <!--标题-->
                    <span class="txtPageTitle">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label></span></td>
                <td></td>
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
                            <td class="Field" width="1%">
                                <nobr>旧密码*：</nobr>
                            </td>
                            <td width="1%">
                                <asp:TextBox ID="tbxOldPassword" runat="server" Width="150" TextMode="Password"></asp:TextBox></td>
                            <td><font face="宋体">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="旧密码不能为空"
                                    ControlToValidate="tbxOldPassword"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="validatorOldPwd" runat="server" ControlToValidate="tbxOldPassword"
                                    Enabled="True"></asp:CustomValidator></font></td>
                        </tr>
                        <tr>
                            <td class="Field" width="1%">
                                <nobr>新密码*：</nobr>
                            </td>
                            <td width="1%">
                                <asp:TextBox ID="tbxNewPassword" runat="server" Width="150" TextMode="Password"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="新密码不能为空"
                                    ControlToValidate="tbxNewPassword"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="ValidatorPwd" runat="server"
                                    ControlToValidate="tbxNewPassword" Enabled="True"></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td class="Field" width="1%">
                                <nobr>再输入一次*：</nobr>
                            </td>
                            <td width="1%">
                                <asp:TextBox ID="tbxNewPasswordAgain" runat="server" Width="150" TextMode="Password"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="重复密码不能为空"
                                    ControlToValidate="tbxNewPasswordAgain"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次输入密码不一致" ControlToValidate="tbxNewPasswordAgain"
                                    ControlToCompare="tbxNewPassword"></asp:CompareValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <iewc:Toolbar ID="Toolbar1" runat="server" CssClass="MSToolBarLeft">
                        <iewc:ToolbarButton ID="btnSave" Text="&nbsp;保存" ImageUrl="../../image/AnswerIcon.gif" ToolTip="保存"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator DefaultStyle="border:solid 1px #f1f1f1;cursor:hand;"></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton ID="btnCancel" Text="&nbsp;取消" ImageUrl="../../image/cancel.gif" ToolTip="取消"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
