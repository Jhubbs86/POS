<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MultiSelectionPicker.ascx.cs" Inherits="CWXT.CustomControls.MultiSelectionPicker" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:TextBox ID="tbxSelectedText" Runat="server" Width="80%" Height="89px" TextMode="MultiLine" CssClass="td1" ></asp:TextBox><asp:TextBox ID="tbxSelectedValue" Runat="server" style="display:none"></asp:TextBox>
<asp:Image ID="btnSelect" Runat="server" ImageUrl="search.gif.aspx" title="选择"></asp:Image>
<asp:LinkButton ID="btnRefresh" Runat="server" CausesValidation="False"></asp:LinkButton>
