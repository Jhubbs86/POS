<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWOneChild.ascx.cs" Inherits="CWXT.JHSY.CWOneChild.CWOneChild" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validatetxtFKID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtCWID" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtSex" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtBirthDate" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatetxtFamilyIncome" runat="server" Display="None" Enabled="True"></asp:CustomValidator>
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
                        <nobr>身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>性别</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtSex" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>父亲身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFathIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>母亲身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMothIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>光荣证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtOneChildNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>发证机关</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIssueOrg" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>出生年月</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>就读学校</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtInSchool" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>家庭居住地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtFamilyAddress" runat="server" Width="80%"></asp:TextBox>
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
                        <asp:TextBox ID="txtInsuNo" runat="server" Width="80%"></asp:TextBox>
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
