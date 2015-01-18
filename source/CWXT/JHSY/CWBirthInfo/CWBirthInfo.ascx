<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWBirthInfo.ascx.cs" Inherits="CWXT.JHSY.CWBirthInfo.CWBirthInfo" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtChildName" ErrorMessage="小孩姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateSex" runat="server" ErrorMessage="请选择性别" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtBirthDate" ErrorMessage="出生年月不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="True" ControlToValidate="txtBirthNo" ErrorMessage="出生证编号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateBirthNo" runat="server" ErrorMessage="出生证编号不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="True" ControlToValidate="txtFathName" ErrorMessage="父亲姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True" ControlToValidate="txtFathIDCardNo" ErrorMessage="父亲身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="True" ControlToValidate="txtFathAddress" ErrorMessage="父亲户籍地址不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" EnableClientScript="True" ControlToValidate="txtFathLinkPhone" ErrorMessage="父亲联系方式不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" EnableClientScript="True" ControlToValidate="txtMothName" ErrorMessage="母亲姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" EnableClientScript="True" ControlToValidate="txtMothIDCardNo" ErrorMessage="母亲身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" EnableClientScript="True" ControlToValidate="txtMothAddress" ErrorMessage="母亲户籍地址不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" EnableClientScript="True" ControlToValidate="txtMothLinkPhone" ErrorMessage="母亲联系方式不能为空" Display="None"></asp:RequiredFieldValidator>
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
                        <nobr>小孩姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>性别*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlSex" runat="server" Width="80%"></asp:DropDownList>
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
                        <nobr>出生证编号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>是否计划</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlIsPlan" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>预产期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtExpectDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户籍地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
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
                        <asp:TextBox ID="txtFathAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>父亲联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathLinkPhone" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>母亲姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothName" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>母亲身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>母亲户籍地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>母亲联系方式*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothLinkPhone" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
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
