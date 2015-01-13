<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWNewMarrige.ascx.cs" Inherits="CWXT.JHSY.CWNewMarrige.CWNewMarrige" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validatetxtCWID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtMarrigeDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtIsPregnant" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtExpectDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtVillageDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
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
                        <nobr>所属村镇</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtCWID" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>男方身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>男方姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>男方户籍地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>男方联系方式</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>女方身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>女方姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>女方户籍地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>女方联系方式</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>结婚登记日期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>是否怀孕</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIsPregnant" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>预产期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtExpectDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>村委登记日期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtVillageDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>结婚登记证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeNo" runat="server" Width="80%"></asp:TextBox>
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
