<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CWXT.Menu" %>

<%@ Register Assembly="M2G.Web.UI" Namespace="M2G.Web.UI" TagPrefix="M2G" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Menu</title>
    <link href="Resources/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/treeStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Resources/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" language="javascript">
        var showTopBanner = true;

        function TopBannerSwitcher() {
            var topBannerDicrection = document.getElementById("topBannerDicrection");
            if (showTopBanner) {
                showTopBanner = false;
                window.top.topFrame.rows = "0,*";
                topBannerDicrection.src = "image/toDown.gif";
                topBannerDicrection.title = topBannerDicrection.hidetitle;
            }
            else {
                showTopBanner = true;
                window.top.topFrame.rows = "59,*";
                topBannerDicrection.src = "image/toUp.gif";
                topBannerDicrection.title = topBannerDicrection.showtitle;
            }
        }
    </script>
</head>
<body class="menu" onselectstart="return false;" >
    <form id="Form1" method="post" runat="server">
        <table width="100%" border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td class="MenuHeader" id="MenuHeader">系统菜单<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<img id="topBannerDicrection" onclick="TopBannerSwitcher()" align="absmiddle" src="image/toUp.gif"
                                style="cursor: hand" title="隐藏Top Banner" showtitle="隐藏Top Banner" hidetitle="显示Top Banner"></span></td>
            </tr>
        </table>
        <!--TreeView-->
        <div id="MenuDiv" class="MenuDiv">
            <M2G:TreeView ID="TreeView1" Height="100%" Width="99%"
                DragAndDropEnabled="false"
                NodeEditingEnabled="false"
                KeyboardEnabled="true"
                CssClass="TreeView"
                NodeCssClass="TreeNode"
                NodeRowCssClass="TreeNodeRow"
                HoverNodeRowCssClass="HoverTreeNodeRow"
                SelectedNodeRowCssClass="SelectedTreeNodeRow"
                ExpandCollapseImageWidth="18"
                ExpandCollapseImageHeight="15"
                ItemSpacing="0"
                ImagesBaseUrl="image/"
                ExpandImageUrl="folder.png"
                CollapseImageUrl="folder_open.png"
                NoExpandImageUrl="Document-Edit.png"
                NodeIndent="15"
                EnableViewState="false"
                runat="server">
            </M2G:TreeView>
        </div>
    </form>
</body>
</html>
