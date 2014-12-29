<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CWXT.Login" %>

<%@ Register TagPrefix="uc1" TagName="VerificationCodeManager" Src="CustomControls/VerificationCodeManager.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-Frameset.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=CWXT.ResourceManager.Instance.GetString("ApplicationName")%>
    </title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            RedirectToLoginPage();

            if (document.all.tbxUserName.value == "")
                document.all.tbxUserName.focus();
        }

        document.onselectstart = document.ondragstart = document.oncontextmenu = function () { window.event.returnValue = null; }
    </script>
    <script language="javascript" type="text/javascript">
        function RedirectToLoginPage() {
            if (window != window.parent)
                window.parent.location.assign('Login.aspx');
        }
    </script>
    <style type="text/css">
        <!--
        body, td, th
        {
            font-size: 12px;
            color: #333333;
        }

        body
        {
            margin-left: auto;
            margin-top: 180px;
            margin-right: auto;
            margin-bottom: 0px;
        }

        a
        {
            font-size: 12px;
            color: 0;
        }

            a:link
            {
                text-decoration: none;
            }

            a:visited
            {
                text-decoration: none;
                color: 0;
            }

            a:hover
            {
                text-decoration: underline;
                color: 0;
            }

            a:active
            {
                text-decoration: none;
                color: 0;
            }
        -->
    </style>
</head>
<body onpaste="return false;" style="text-align: center">
    <form id="Form1" method="post" runat="server">
        <table width="225" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" height="100%">
                        <tr>
                            <td valign="center">
                                <div style="text-align: left">
                                    <table class="txt" width="100%">
                                        <tr>
                                            <td width="40">用户名
                                            </td>
                                            <td width="120">
                                                <asp:TextBox ID="tbxUserName" TabIndex="1" autocomplete="off" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40" align="right">密&nbsp;&nbsp;&nbsp;&nbsp;码
                                            </td>
                                            <td width="120">
                                                <asp:TextBox ID="tbxPassword" TabIndex="2" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                        <td width="40">
                                            验证码
                                        </td>
                                        <td width="120">
                                            <nobr><asp:textbox id="tbxVerifyNumber" tabIndex="3" autocomplete="off" Runat="server" Width="50%"></asp:textbox>&nbsp;&nbsp;<uc1:verificationcodemanager id="ucVerificationCodeManager" runat="server"></uc1:verificationcodemanager></nobr>
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td width="40"></td>
                                            <td align="right">&nbsp;&nbsp;<asp:ImageButton ID="btnLogin" TabIndex="4" runat="server" Width="44"
                                                ImageUrl="image/login.gif" Height="44" BorderStyle="None"></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="padding-top: 30px" class="txt">
            <asp:RequiredFieldValidator ID="valUserId" runat="server" Display="Dynamic" EnableClientScript="True"
                ErrorMessage="请输入用户名；" ControlToValidate="tbxUserName"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="valUserPwd" runat="server" Display="Dynamic" EnableClientScript="True"
                ErrorMessage="请输入密码；" ControlToValidate="tbxPassword"></asp:RequiredFieldValidator>
            <%--<asp:RequiredFieldValidator ID="valVerifyNumber" runat="server" Display="Dynamic"
            EnableClientScript="True" ErrorMessage="请输入验证码；" ControlToValidate="tbxVerifyNumber"></asp:RequiredFieldValidator>--%>
        </div>
    </form>
</body>
</html>
