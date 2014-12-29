<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Role.ascx.cs" Inherits="CWXT.SystemManage.RoleManage.Role" %>
<!--页面验证开始-->
<asp:validationsummary id="ValidationSummary1" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存"
	EnableClientScript="True" DisplayMode="BulletList" Runat="server"></asp:validationsummary>
<asp:requiredfieldvalidator id="RequiredFieldValidator1" EnableClientScript="True" Runat="server" Display="None"
	ErrorMessage="用户组代码不能为空" ControlToValidate="tbxRoleCode"></asp:requiredfieldvalidator>
<asp:requiredfieldvalidator id="Requiredfieldvalidator2" EnableClientScript="True" Runat="server" Display="None"
	ErrorMessage="用户组名称不能为空" ControlToValidate="tbxRoleName"></asp:requiredfieldvalidator>
<asp:customvalidator id="valiateRoleCode" Runat="server" Display="None" ErrorMessage="用户组代码不能重复" Enabled="True"></asp:customvalidator>
<asp:customvalidator id="valiateRoleName" Runat="server" Display="None" ErrorMessage="用户组名称不能重复" Enabled="True"></asp:customvalidator>
<!--页面验证结束-->
<table class="panel" cellspacing="0" cellpadding="0">
	<tr>
		<td>
			<table cellspacing="0" cellpadding="5">
				<tr>
					<td class="SmallTitle"><nobr>基本信息</nobr></td> <!--小标题--></tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>
			<table class="detailInfo" cellspacing="3" cellpadding="3">
				<tr>
					<td class="Field"><nobr>用户组代码*</nobr></td>
					<td width="50%"><asp:textbox id="tbxRoleCode" Width="80%" runat="server"></asp:textbox></td>
					<td class="Field"><nobr>用户组名称*</nobr></td>
					<td width="50%"><asp:textbox id="tbxRoleName" Width="80%" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td class="FieldTop"><nobr>备注</nobr></td>
					<td width="50%"><asp:textbox id="tbxMemo" Width="80%" runat="server" Height="80px" TextMode="MultiLine"></asp:textbox></td>
				</tr>
			</table>
		</td>
	</tr>
</table>