<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeBar.aspx.cs" Inherits="CWXT.WelcomeBar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/jscript">
        var g = 0
        window.onload = function GetTodayString() {
            var oDate = new Date();
            var txtDate = "";

            txtDate += oDate.toLocaleDateString();
            txtDate += "&nbsp;&nbsp;";
            txtDate += oDate.toLocaleTimeString();
            switch (oDate.getDay()) {
                case 0: txtDate += "<span style='color:red'>&nbsp;&nbsp;星期天</span>"; break;
                case 1: txtDate += "&nbsp;&nbsp;星期一"; break;
                case 2: txtDate += "&nbsp;&nbsp;星期二"; break;
                case 3: txtDate += "&nbsp;&nbsp;星期三"; break;
                case 4: txtDate += "&nbsp;&nbsp;星期四"; break;
                case 5: txtDate += "&nbsp;&nbsp;星期五"; break;
                case 6: txtDate += "<span style='color:red'>&nbsp;&nbsp;星期六</span>"; break;
            }
            var todaySpan = document.getElementById('today');
            if (todaySpan)
                todaySpan.innerHTML = txtDate;

        }
        window.setInterval("GetTodayString()", 1000);

        var showMenu = true;

        function MenuSwitcher() {
            if (showMenu) {
                showMenu = false;
                window.top.middle.cols = "0,*";
                document.getElementById("menuDirection").src = "image/toRight.gif";
                document.getElementById("isShow").title = "显示系统菜单";
            }
            else {
                showMenu = true;
                window.top.middle.cols = "220,*";
                document.getElementById("menuDirection").src = "image/toLeft.gif";
                document.getElementById("isShow").title = "隐藏系统菜单";
            }
        }
    </script>
</head>
<body class="zeromargin" oncontextmenu="return false;" onselectstart="return false;" ondragstart="return false;"
    style="COLOR: #000000">
    <form id="Form1" method="post" runat="server">
        <table class="WelcomeBar" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <div id="isShow" title="隐藏系统菜单" style="CURSOR: hand" onclick="MenuSwitcher()">
                        <span style="PADDING-LEFT: 10px">
                            <img id="menuDirection" src="image/toLeft.gif" align="absMiddle" border="0" alt="" />&nbsp;菜单</span>
                    </div>
                </td>
                <td align="left">欢迎登录，<%=UserName%>
						！现在是<span id="today"></span>
                </td>
                <td align="right">
                    <div title="返回我的工作台" style="CURSOR: hand" onclick="top.frames['main'].location.assign('WorkSpace/MyWorkSpace.aspx');">
                        <img src="image/ic_too.gif" align="absMiddle" border="0" alt="" />&nbsp;我的工作台</div>
                </td>
                <td align="center" width="1%" nowrap>|</td>
                <td align="right" width="1%" nowrap>
                    <div title="退出系统" style="PADDING-RIGHT: 5px; CURSOR: hand">
                        <img src="image/exit.png" align="absMiddle" border="0" alt="" />&nbsp;<asp:LinkButton runat="server" ID="btnExit" CssClass="nounderline">退出系统</asp:LinkButton></div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
