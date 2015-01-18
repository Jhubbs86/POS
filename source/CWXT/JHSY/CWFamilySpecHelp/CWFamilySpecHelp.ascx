<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWFamilySpecHelp.ascx.cs" Inherits="CWXT.JHSY.CWFamilySpecHelp.CWFamilySpecHelp" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtAppIDCardNo" ErrorMessage="身份证号码不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateRealMonth" runat="server" ErrorMessage="享受时间必须是数字" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateHelpMoney" runat="server" ErrorMessage="享受金额必须是数值" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtHelpYear" ErrorMessage="年份不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateHelpYear" runat="server" ErrorMessage="年份必须是数字" Display="None" Enabled="True"></asp:CustomValidator>

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
                        <nobr>所属村镇*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <uc1:GridPicker ID="gpCWInfo" runat="server"></uc1:GridPicker>
                    </td>
                    <td class="Field">
                        <nobr>身份证号码*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAppIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>申请人姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAppName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>性别</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlSex" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户口性质</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlHolderPorp" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>扶助类型</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlHelpType" runat="server" Width="80%"></asp:DropDownList>
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
                        <asp:TextBox ID="txtHelpNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>年份*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHelpYear" runat="server" Width="80%" MaxLength="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>备注</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMemo" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
