<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWInfo.ascx.cs" Inherits="CWXT.JHSY.CWInfoManage.CWInfo" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtVillageName" ErrorMessage="村名称不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateVillageName" runat="server" ErrorMessage="村名称不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:customvalidator id="validatetxtDistrict" runat="server" display="None" enabled="True"></asp:customvalidator>
<asp:customvalidator id="validatetxtTotalPeps" runat="server" display="None" enabled="True"></asp:customvalidator>
<asp:customvalidator id="validatetxtIndusValue" runat="server" display="None" enabled="True"></asp:customvalidator>
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
                        <nobr>村名称*</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtVillageName" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>地理位置</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtLocation" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>所属行政区</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:DropDownList ID="ddlDistrict" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>总人数</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtTotalPeps" runat="server" Width="80%" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>工业总产值</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtIndusValue" runat="server" Width="80%" ></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>村长</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtVillageChief" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FieldTop">
                        <nobr>备注</nobr>
                    </td>
                    <td style="width:50%;">
                        <asp:TextBox ID="txtMemo" runat="server" Width="80%" TextMode="MultiLine" Height="50" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
