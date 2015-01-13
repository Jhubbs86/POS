<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWOneChildAward.ascx.cs" Inherits="CWXT.JHSY.CWOneChildAward.CWOneChildAward" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validatetxtCWID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtBirthDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtRealMonth" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtAwardFee" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<!--页面验证结束-->
<table class="panel" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table cellspacing="0" cellpadding="5">
                <tr>
                    <td class="SmallTitle">
                        <nobr>基本信息</nobr>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table class="detailInfo" cellspacing="3" cellpadding="3">
                <tr>
                    <td class="Field">
                        <nobr></nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFKID" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>所属村镇</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtCWID" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>享受人身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOwnIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>享受人姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOwnName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>孩子身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>孩子姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>出生年月</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>独生子女光荣证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOneChildNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>享受月数</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtRealMonth" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>金额</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAwardFee" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>联系电话</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>持卡人姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAuthName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>农行卡号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtABCNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>持卡人身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAuthIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>年份</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAwardYear" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>备注</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMemo" runat="server" Width="80%" TextMode="MultiLine" Height="50"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
