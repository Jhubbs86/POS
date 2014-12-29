<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="User.ascx.cs" Inherits="CWXT.SystemManage.UserManage.User" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="MultiSelectionPicker" Src="../../CustomControls/MultiSelectionPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" EnableClientScript="True"
    HeaderText="您需要修改以下几点，才能成功保存" ShowSummary="True" CssClass="txt9"></asp:ValidationSummary>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="tbxAlias" ErrorMessage="Alias不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" EnableClientScript="True" ControlToValidate="tbxChineseName" ErrorMessage="中文名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateAlias" runat="server" ErrorMessage="Alias不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateRole" runat="server" ErrorMessage="用户组不能为空" Display="None" Enabled="True"></asp:CustomValidator>
<!--页面验证结束-->
<table class="panel" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table cellspacing="0" cellpadding="5">
                <tr>
                    <td class="SmallTitle">
                        <nobr>基本信息</nobr>
                    </td>
                    <!--小标题-->
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table class="detailInfo" cellspacing="3" cellpadding="3">
                <tr>
                    <td class="Field">
                        <nobr>Alias*</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxAlias" runat="server" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>中文名*</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxChineseName" runat="server" Width="80%"></asp:TextBox></td>
                    <td class="Field">
                        <nobr>英文名</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxEnglishName" runat="server" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>性别</nobr>
                    </td>
                    <td width="50%">
                        <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatColumns="2" Font-Size="9pt">
                            <asp:ListItem Value="true">男</asp:ListItem>
                            <asp:ListItem Value="false">&lt;nobr&gt;女&lt;/nobr&gt;</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td class="Field">
                        <nobr>手机号</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxMobile" runat="server" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>用户组*</nobr>
                    </td>
                    <td width="50%">
                        <uc1:GridPicker ID="gpRole" runat="server"></uc1:GridPicker>
                    </td>
                    <td class="Field">
                        <nobr>职位</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxTitle" runat="server" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>电子邮件</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxEmail" runat="server" Width="80%"></asp:TextBox></td>
                    <td class="Field">
                        <nobr>联系地址</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxAddress" runat="server" Width="80%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>生日</nobr>
                    </td>
                    <td width="50%">
                        <%--<asp:TextBox ID="tbxBirthday" onfocus="calendar();" runat="server" Width="80%"></asp:TextBox></td>--%>
                        <asp:TextBox ID="tbxBirthday" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    <td class="Field">
                        <nobr>是否在职</nobr>
                    </td>
                    <td width="50%">
                        <asp:CheckBox ID="cbxIsActive" runat="server" Width="80%"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td class="FieldTop">
                        <nobr>备注</nobr>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="tbxMemo" runat="server" Width="80%" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
