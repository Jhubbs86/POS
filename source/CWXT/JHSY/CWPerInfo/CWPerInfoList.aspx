<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CWPerInfoList.aspx.cs" Inherits="CWXT.JHSY.CWPerInfo.CWPerInfoList" %>

<%@ Register TagPrefix="vs" Namespace="Vladsm.Web.UI.WebControls" Assembly="GroupRadioButton" %>
<%@ Register TagPrefix="uccs" TagName="CustomPaging" Src="~/CustomControls/CustomPaging.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>人员信息</title>
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
                    <span class="txtPageTitle">人员信息</span>
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
                                <asp:DataGrid ID="dgCWPerInfo" CssClass="DGStyle" runat="server" AutoGenerateColumns="False" AllowCustomPaging="True">
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
                                        <asp:BoundColumn DataField="IDCardNo" HeaderText="身份证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Name" HeaderText="姓名"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="SexInfo" HeaderText="性别"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="NationInfo" HeaderText="民族"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="PoliticsInfo" HeaderText="政治面貌"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IsHolderInfo" HeaderText="是否户主"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="HolderName" HeaderText="户主姓名"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="HolderIDCardNo" HeaderText="户主身份证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="HolderPorpInfo" HeaderText="户口性质"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="HolderAddress" HeaderText="户籍地址"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="LiveAddress" HeaderText="居住地址"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="LinkPhone" HeaderText="联系电话"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="WorkUnit" HeaderText="工作单位"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeStatusInfo" HeaderText="结婚状况"></asp:BoundColumn>
                                        <%--<asp:BoundColumn DataField="MarrigeDate" HeaderText="结婚登记日期" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeNo" HeaderText="结婚登记证明号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeName" HeaderText="对象姓名"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="MarrigeIDCardNo" HeaderText="对象身份证号"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Children" HeaderText="子女情况"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IsSingle" HeaderText="是否独生"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildName1" HeaderText="小孩姓名1"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildIDCardNo1" HeaderText="小孩身份证号1"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildAddress1" HeaderText="小孩户籍地址1"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthNo1" HeaderText="小孩出生证号1"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthDate1" HeaderText="出生日期1" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ></asp:BoundColumn>
                                            <asp:BoundColumn DataField="AdoptNo1" HeaderText="收养文书号1"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildName2" HeaderText="小孩姓名2"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildIDCardNo2" HeaderText="小孩身份证号2"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildAddress2" HeaderText="小孩户籍地址2"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthNo2" HeaderText="小孩出生证号2"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthDate2" HeaderText="出生日期2" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ></asp:BoundColumn>
                                            <asp:BoundColumn DataField="AdoptNo2" HeaderText="收养文书号2"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildName3" HeaderText="小孩姓名3"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildIDCardNo3" HeaderText="小孩身份证号3"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ChildAddress3" HeaderText="小孩户籍地址3"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthNo3" HeaderText="小孩出生证号3"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="BirthDate3" HeaderText="出生日期3" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ></asp:BoundColumn>
                                            <asp:BoundColumn DataField="AdoptNo3" HeaderText="收养文书号3"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CreateUserName" HeaderText="创建人"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ModifyUserName" HeaderText="修改人"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CreateTime" HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ModifyTime" HeaderText="修改时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundColumn>--%>
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
