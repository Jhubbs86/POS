﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWNewMarrige.ascx.cs" Inherits="CWXT.JHSY.CWNewMarrige.CWNewMarrige" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtMarrigeNo" ErrorMessage="结婚登记证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateMarrigeNo" runat="server" ErrorMessage="结婚登记证号不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtMaleIDCardNo" ErrorMessage="男方身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="True" ControlToValidate="txtMaleName" ErrorMessage="男方姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="True" ControlToValidate="txtMaleAddress" ErrorMessage="男方户籍地址不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True" ControlToValidate="txtMaleLinkPhone" ErrorMessage="男方联系方式不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="True" ControlToValidate="txtFemaleIDCardNo" ErrorMessage="女方身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" EnableClientScript="True" ControlToValidate="txtFemaleName" ErrorMessage="女方户籍地址不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" EnableClientScript="True" ControlToValidate="txtFemaleAddress" ErrorMessage="女方姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" EnableClientScript="True" ControlToValidate="txtFemaleLinkPhone" ErrorMessage="女方户籍地址不能为空" Display="None"></asp:RequiredFieldValidator>
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
                        <nobr>结婚登记证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="Field">
                        <nobr>男方身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>男方姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>男方户籍地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>男方联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMaleLinkPhone" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>女方身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>女方姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>女方户籍地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>女方联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFemaleLinkPhone" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="Field">
                        <nobr>结婚登记日期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>是否怀孕</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlIsPregnant" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>预产期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtExpectDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>村委登记日期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtVillageDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
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
