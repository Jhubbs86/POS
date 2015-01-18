<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWOneChild.ascx.cs" Inherits="CWXT.JHSY.CWOneChild.CWOneChild" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="True" ControlToValidate="txtIDCardNo" ErrorMessage="身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateIDCardNo" runat="server" ErrorMessage="独生子女身份证号已登记，请勿重复登记" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtChildName" ErrorMessage="姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateSex" runat="server" ErrorMessage="请选择性别" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtBirthDate" ErrorMessage="出生年月不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="True" ControlToValidate="txtFathIDCardNo" ErrorMessage="父亲身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="True" ControlToValidate="txtMothIDCardNo" ErrorMessage="母亲身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="True" ControlToValidate="txtOneChildNo" ErrorMessage="光荣证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateOneChildNo" runat="server" ErrorMessage="光荣证号不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" EnableClientScript="True" ControlToValidate="txtIssueOrg" ErrorMessage="发证机关不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" EnableClientScript="True" ControlToValidate="txtInSchool" ErrorMessage="就读学校不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" EnableClientScript="True" ControlToValidate="txtFamilyAddress" ErrorMessage="家庭居住地址不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:customvalidator id="validateFamilyIncome" runat="server" display="None" enabled="True"></asp:customvalidator>
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
                        <nobr>身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>姓名*</nobr>
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
                        <asp:DropDownList ID="ddlSex" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>出生年月*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="Field">
                        <nobr>父亲身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathIDCardNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
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
                        <nobr>光荣证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOneChildNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>发证机关*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIssueOrg" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>就读学校*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtInSchool" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="100"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>家庭居住地址*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFamilyAddress" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>家庭人均收入</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFamilyIncome" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>独生子女保险卡号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtInsuNo" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
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
