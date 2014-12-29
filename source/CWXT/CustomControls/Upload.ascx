<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Upload.ascx.cs" Inherits="CWXT.CustomControls.Upload" %>
<script language="JavaScript">
    function addFile() {
        var str = '<input type="file" style="WIDTH: 80%" NAME="upload">';
        document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", str)
    }
</script>
<table cellspacing="0" cellpadding="3" width="100%" border="0">
	<tr>
		<td>
			<asp:Repeater ID="rptExistedAttachments" Runat="server">
				<ItemTemplate>
					<asp:CheckBox ID="CheckBox1" Runat="server" Checked='<%#DataBinder.Eval(Container.DataItem, "Checked")%>'>
					</asp:CheckBox>
					<asp:Label ID="Label1" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FileFullName")%>' Visible="False">
					</asp:Label>
					<asp:HyperLink ID="HyperLink1" Runat="server" Target="_blank" NavigateUrl='<%#"~/" + System.Configuration.ConfigurationSettings.AppSettings["UploadFolder"] + "/" + DataBinder.Eval(Container.DataItem, "FileFullName")%>' Text='<%#DataBinder.Eval(Container.DataItem, "FileName")%>' CssClass="txt9" ForeColor="Navy" alt="点击这里进行下载">
					</asp:HyperLink>
					<asp:Label ID="Label2" Runat="server" Text='<%#"&nbsp;&nbsp;&nbsp;&nbsp;" + DataBinder.Eval(Container.DataItem, "FileLength")%>' CssClass="txt9" ForeColor="Navy">
					</asp:Label>
					<br>
				</ItemTemplate>
			</asp:Repeater>
		</td>
	</tr>
	<asp:Panel ID="uploadDiv" Runat="server">
  <tr>
    <td>
      <P id="MyFile"><input style="width: 80%" type="file" 
  name="upload"></P></td></tr>
<asp:Panel id="addAnotherDiv" Runat="server">
  <tr>
    <td><A class="attach" 
  href="javascript:addFile()">添加另一个附件</A></td></tr></asp:Panel>
	</asp:Panel>
</table>
