<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CWNewMarrigeQuery.aspx.cs" Inherits="CWXT.JHSY.CWNewMarrige.CWNewMarrigeQuery" %>

<%@ Register TagPrefix="uc1" TagName="QueryProvider" Src="~/CustomControls/QueryProvider.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>查询新婚登记</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <base target="_self" />
</head>
<body class="common">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <!--工具条-->
            <tr>
                <td><span class="txtPageTitle">查询新婚登记</span></td>
                <td>
                    <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                        <iewc:ToolbarButton ID="btnQuery" ToolTip="查询" ImageUrl="../../image/AnswerIcon.gif" Text="&nbsp;查询"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton ID="btnClear" Text="&nbsp;清除" ToolTip="清除" ImageUrl="<%RelativeLevel%>image/AnswerIcon.gif"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton ID="btnClose" ToolTip="关闭" ImageUrl="../../image/exit.png" Text="&nbsp;关闭"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
        </table>
        <table class="panel" cellspacing="0" cellpadding="5">
            <tr>
                <td>
                    <uc1:QueryProvider ID="ucQueryProvider" runat="server"></uc1:QueryProvider>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
