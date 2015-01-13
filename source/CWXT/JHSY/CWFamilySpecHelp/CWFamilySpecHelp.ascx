<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWFamilySpecHelp.ascx.cs" Inherits="CWXT.JHSY.CWFamilySpecHelp.CWFamilySpecHelp" %>

<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validatetxtCWID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtSex" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtHolderPorp" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtHelpType" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtRealMonth" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtHelpMoney" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
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
                        <nobr>身份证号码</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAppIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>申请人姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAppName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>性别</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtSex" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户口性质</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderPorp" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>扶助类型</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHelpType" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>享受时间</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtRealMonth" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>享受金额</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHelpMoney" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>发放证编号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHelpNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>年份</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHelpYear" runat="server" Width="80%"></asp:TextBox>
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
