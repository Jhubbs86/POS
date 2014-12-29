<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomPaging.ascx.cs" Inherits="CWXT.CustomControls.CustomPaging" %>
<table cellpadding="0" cellspacing="0" class="panel" style="FONT-FAMILY:Tahoma">
	<tr>
		<td width="40%" align="left"><nobr><asp:Label ID="lblRecordDesc" Runat="server"></asp:Label>共&nbsp;<b><asp:Label ID="lblTotalRecords" Runat="server"></asp:Label></b>&nbsp;条</nobr></td>
		<td width="60%" align="right"><nobr>
			<asp:LinkButton ID="btnFirstPage" Runat="server" CssClass="pager" CausesValidation="False" onclick="btnFirstPage_Click">第一页</asp:LinkButton>&nbsp;
			<asp:LinkButton ID="btnPrevPage" Runat="server" CssClass="pager" CausesValidation="False" onclick="btnPrevPage_Click">上一页</asp:LinkButton>&nbsp;
			<asp:LinkButton ID="btnNextPage" Runat="server" CssClass="pager" CausesValidation="False" onclick="btnNextPage_Click">下一页</asp:LinkButton>&nbsp;
			<asp:LinkButton ID="btnLastPage" Runat="server" CssClass="pager" CausesValidation="False" onclick="btnLastPage_Click">最后一页</asp:LinkButton>&nbsp;&nbsp; 
			第&nbsp;<b><asp:Label ID="lblCurrentPage" Runat="server"></asp:Label></b> /&nbsp;<asp:Label ID="lblTotalPages" Runat="server"></asp:Label>&nbsp;页&nbsp;&nbsp;&nbsp;&nbsp;转到<asp:textbox ID="tbxNewPage" Runat="server" Width="30" MaxLength="9" autocomplete="off" ontextchanged="tbxNewPage_TextChanged"></asp:textbox>页&nbsp;&nbsp;页大小&nbsp;<asp:TextBox ID="tbxDefaultPageSize" Runat="server" Width="30" MaxLength="9" autocomplete="off"></asp:TextBox>
			<asp:Button ID="btnGo" Runat="server" Width="32px" Text="GO" CssClass="PagerGoButtonStyle" CausesValidation="False" onclick="btnGo_Click"></asp:Button>
		</nobr></td>
	</tr>
</table>
