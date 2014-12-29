<%@ Control Language="c#" AutoEventWireup="false" Codebehind="GridPicker.ascx.cs" Inherits="CWXT.CustomControls.GridPicker" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:TextBox ID="tbxSelectedText" Runat="server" Width="80%"></asp:TextBox><asp:TextBox ID="tbxSelectedValue" Runat="server" style="display: none;"></asp:TextBox>
<asp:Image ID="btnSelect" Runat="server" ImageUrl="search.gif.aspx" title="选择"></asp:Image>
<asp:LinkButton ID="btnRefresh" Runat="server" CausesValidation="False"></asp:LinkButton>