<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Header.aspx.cs" Inherits="CWXT.Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Header</title>
    <script language="javascript">
        function MenuItemClick(obj,url)
        {
            obj.target = "main";
            obj.href = url;
            obj.click();
        }
    </script>
</head>

<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divContainer" runat="server">
        </div>
    </form>
</body>
</html>
