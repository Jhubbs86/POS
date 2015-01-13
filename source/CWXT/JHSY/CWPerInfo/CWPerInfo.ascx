<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CWPerInfo.ascx.cs" Inherits="CWXT.JHSY.CWPerInfo.CWPerInfo" %>
<%@ Register TagPrefix="uc1" TagName="GridPicker" Src="../../CustomControls/GridPicker.ascx" %>
<!--页面验证开始-->
<asp:ValidationSummary ID="ValidationSummaryList" CssClass="txt9" ShowSummary="True" HeaderText="您需要修改以下几点，才能成功保存" EnableClientScript="True" DisplayMode="BulletList" runat="server"></asp:ValidationSummary>
<asp:CustomValidator ID="validateCWInfo" runat="server" ErrorMessage="请选择所属村镇" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="True" ControlToValidate="txtIDCardNo" ErrorMessage="身份证号不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateIDCardNo" runat="server" ErrorMessage="身份证号不能重复" Display="None" Enabled="True"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="True" ControlToValidate="txtName" ErrorMessage="姓名不能为空" Display="None"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="validateSex" runat="server" ErrorMessage="请选择性别" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateNation" runat="server" ErrorMessage="请选择民族" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validatePolitics" runat="server" ErrorMessage="请选择政治面貌" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateIsHolder" runat="server" ErrorMessage="请选择是否户主" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateHolderPorp" runat="server" ErrorMessage="请选择户口性质" Display="None" Enabled="True"></asp:CustomValidator>
<asp:CustomValidator ID="validateMarrigeStatus" runat="server" ErrorMessage="请选择结婚状况" Display="None" Enabled="True"></asp:CustomValidator>
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
                        <nobr>身份证号*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>姓名*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtName" runat="server" Width="80%"></asp:TextBox>
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
                        <nobr>民族*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlNation" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>政治面貌*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlPolitics" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>是否户主*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlIsHolder" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>户主姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户主身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>户口性质*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlHolderPorp" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>户籍地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtHolderAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>居住地址</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtLiveAddress" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>联系电话</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtLinkPhone" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>工作单位</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtWorkUnit" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>结婚状况*</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlMarrigeStatus" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>结婚登记日期</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeDate" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>结婚登记证明号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>对象姓名</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeName" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>对象身份证号</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtMarrigeIDCardNo" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>子女情况</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlChildren" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>是否独生</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:DropDownList ID="ddlIsSingle" runat="server" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="Field">
                        <nobr>小孩姓名1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName1" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩身份证号1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildIDCardNo1" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩户籍地址1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildAddress1" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩出生证号1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthNo1" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>出生日期1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate1" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>收养文书号1</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAdoptNo1" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩姓名2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName2" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩身份证号2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildIDCardNo2" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩户籍地址2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildAddress2" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩出生证号2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthNo2" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>出生日期2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate2" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>收养文书号2</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAdoptNo2" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩姓名3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildName3" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩身份证号3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildIDCardNo3" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>小孩户籍地址3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtChildAddress3" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>小孩出生证号3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthNo3" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="Field">
                        <nobr>出生日期3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtBirthDate3" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" runat="server" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Field">
                        <nobr>收养文书号3</nobr>
                    </td>
                    <td style="width: 50%;">
                        <asp:TextBox ID="txtAdoptNo3" runat="server" Width="80%"></asp:TextBox>
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
