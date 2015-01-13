<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWBirthInfo.ascx.cs" Inherits="CWXT.JHSY.CWBirthInfo.CWBirthInfo" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validatetxtCWID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtSex" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtBirthDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtIsPlan" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtExpectDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
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
                        <asp:TextBox ID="txtCWID" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>性别*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtSex" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>出生年月*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>出生证编号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>是否计划</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIsPlan" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>预产期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtExpectDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>户籍地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户主姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>户主身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>父亲姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>父亲身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>父亲户籍地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>父亲联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>母亲姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>母亲身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>母亲户籍地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>母亲联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldTop">
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
