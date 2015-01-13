<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CWNewMarrigeList.aspx.cs" Inherits="CWXT.JHSY.CWNewMarrige.CWNewMarrigeList" %>

<%@ Register TagPrefix="vs" Namespace="Vladsm.Web.UI.WebControls" Assembly="GroupRadioButton" %>
<%@ Register TagPrefix="uccs" TagName="CustomPaging" Src="~/CustomControls/CustomPaging.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>新婚登记</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body class="common">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <span class="txtPageTitle">新婚登记</span>
                </td>
                <td>
                    <iewc:Toolbar ID="Toolbar" runat="server" CssClass="MSToolBar">
                        <iewc:ToolbarButton ID="btnQuery" ImageUrl="../../image/AnswerIcon.gif" ToolTip="查询" Text="&nbsp;查询"></iewc:ToolbarButton>
                    </iewc:Toolbar>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
        </table>
        <table class="panel" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table class="detailInfo" cellspacing="0" cellpadding="3">
                        <tr>
                            <td>
                                <asp:Label ID="lblQueryDesc" runat="server"></asp:Label>
                            </td>
                            <td class="ToolBarStyle">
                                <asp:ImageButton ID="btnNew" runat="server" AlternateText="新增" CssClass="ImageButtonStyle" ImageUrl="~/image/BTN_NEW_UP.gif"></asp:ImageButton>
                                <asp:ImageButton ID="btnEdit" runat="server" AlternateText="编辑" CssClass="ImageButtonStyle" ImageUrl="~/image/BTN_EDIT_UP.gif"></asp:ImageButton>
                                <asp:ImageButton ID="btnDel" runat="server" AlternateText="删除" CssClass="ImageButtonStyle" ImageUrl="~/image/BTN_DEL_UP.gif"></asp:ImageButton>
                                <asp:ImageButton ID="btnView" runat="server" AlternateText="查看" CssClass="ImageButtonStyle" ImageUrl="~/image/BTN_VIEW_UP.gif"></asp:ImageButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataGrid ID="dgCWNewMarrige" CssClass="DGStyle" runat="server" AutoGenerateColumns="False" AllowCustomPaging="True">
                                    <HeaderStyle CssClass="DGHeaderStyle"></HeaderStyle>
                                    <ItemStyle CssClass="DGItemStyle"></ItemStyle>
                                    <AlternatingItemStyle CssClass="DGAlternatingItemStyle"></AlternatingItemStyle>
                                    <Columns>
                                        <asp:TemplateColumn HeaderStyle-Width="1%" HeaderStyle-Wrap="False">
                                            <ItemTemplate>
                                                <vs:GroupRadioButton ID="Radiobutton1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="PKID" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CWVillageName" HeaderText="所属村镇"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MaleIDCardNo" HeaderText="男方身份证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MaleName" HeaderText="男方姓名"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MaleAddress" HeaderText="男方户籍地址"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MaleLinkPhone" HeaderText="男方联系方式"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="FemaleIDCardNo" HeaderText="女方身份证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="FemaleName" HeaderText="女方姓名"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="FemaleAddress" HeaderText="女方户籍地址"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="FemaleLinkPhone" HeaderText="女方联系方式"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeDate" HeaderText="结婚登记日期" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IsPregnant" HeaderText="是否怀孕"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ExpectDate" HeaderText="预产期" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="VillageDate" HeaderText="村委登记日期" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeNo" HeaderText="结婚登记证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CreateUser" HeaderText="创建人"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CreateTime" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
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
