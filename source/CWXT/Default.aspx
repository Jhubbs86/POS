<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CWXT.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>
        <%=CWXT.ResourceManager.Instance.GetString("ApplicationName")%>
    </title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
</head>
<frameset name="topFrame" rows="89,*" border="0">
		<frame name="header" src="Header.aspx" scrolling="no" frameborder="0" noresize>
		<frameset id="middle" name="middle" cols="220,*"">
			<frame id="menu" name="menu" src="Menu.aspx" scrolling="no" height="76%" style="BORDER-RIGHT:#C9C9C9 1px solid; cursor:w-resize;">
     <frameset name="contentFrame" rows="25,0,100%" style="BORDER-LEFT:#D9D9D9 1px solid; cursor:w-resize;">
				<frame id="welcome" name="welcome" src="WelcomeBar.aspx" scrolling="no">
                <frame id="ocx" name="ocx" src=""  scrolling="yes">
				<frame id="main" name="main" src=""  scrolling="yes">
			</frameset>
		</frameset>
		<noframes>
			<p id="p1">
				此 HTML 框架集显示多个 Web 页。若要查看此框架集，请使用支持 HTML 4.0 及更高版本的 Web 浏览器。
			</p>
		</noframes>
	</frameset>
</html>
