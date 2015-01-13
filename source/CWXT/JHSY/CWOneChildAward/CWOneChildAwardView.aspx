﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CWOneChildAwardView.aspx.cs" Inherits="CWXT.JHSY.CWOneChildAward.CWOneChildAwardView" %>

<%@ Register TagPrefix="uccs" TagName="CWOneChildAward" Src="CWOneChildAward.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>查看独生子女奖励费统计</title>
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
                    <span class="txtPageTitle">查看独生子女奖励费统计</span></td>
                <td>
                    <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                        <iewc:ToolbarButton Text="&#160;编辑" ToolTip="编辑" ImageUrl="../../image/AnswerIcon.gif" ID="btnEdit"></iewc:ToolbarButton>
                        <iewc:ToolbarSeparator></iewc:ToolbarSeparator>
                        <iewc:ToolbarButton Text="&#160;返回" ToolTip="返回" ImageUrl="../../image/AnswerIcon.gif" ID="btnReturn"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
        </table>
        <uccs:CWOneChildAward id="ucCWOneChildAward" runat="server"></uccs:CWOneChildAward>
    </form>
</body>
</html>