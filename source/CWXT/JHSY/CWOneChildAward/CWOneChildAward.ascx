<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWOneChildAward.ascx.cs" Inherits="CWXT.JHSY.CWOneChildAward.CWOneChildAward" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtOwnIDCardNo" ErrorMessage="享受人身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtOwnName" ErrorMessage="享受人姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="True" ControlToValidate="txtChildIDCardNo" ErrorMessage="孩子身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="True" ControlToValidate="txtChildName" ErrorMessage="孩子姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True" ControlToValidate="txtBirthDate" ErrorMessage="出生年月不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="True" ControlToValidate="txtOneChildNo" ErrorMessage="独生子女光荣证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" EnableClientScript="True" ControlToValidate="txtRealMonth" ErrorMessage="享受月数不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateRealMonth" runat="server" ErrorMessage="享受月数必须是数字" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" EnableClientScript="True" ControlToValidate="txtAwardFee" ErrorMessage="金额不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateAwardFee" runat="server" ErrorMessage="金额必须是数值" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" EnableClientScript="True" ControlToValidate="txtLinkPhone" ErrorMessage="联系电话不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" EnableClientScript="True" ControlToValidate="txtAuthName" ErrorMessage="持卡人姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" EnableClientScript="True" ControlToValidate="txtABCNo" ErrorMessage="农行卡号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" EnableClientScript="True" ControlToValidate="txtAuthIDCardNo" ErrorMessage="持卡人身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" EnableClientScript="True" ControlToValidate="txtAwardYear" ErrorMessage="年份不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateAwardYear" runat="server" ErrorMessage="年份必须是数字" Display="None" Enabled="True"></asp:CustomValidator>

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
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>享受人身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOwnIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>享受人姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOwnName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>孩子身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>孩子姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>出生年月*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>独生子女光荣证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOneChildNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>享受月数*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtRealMonth" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>金额*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAwardFee" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>联系电话*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtLinkPhone" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>持卡人姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAuthName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>农行卡号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtABCNo" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>持卡人身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAuthIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>年份*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAwardYear" runat="server" Width="80%" MaxLength="4"></asp:TextBox>
                    </td>
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
