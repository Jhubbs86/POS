<!--仿MSN提示-->
<div onselectstart="return false;" onmousedown="return popupBobespopup_DragDrop(event);"
	id="popupBob" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #ffc080 1px solid; DISPLAY: none; Z-INDEX: 9999; BACKGROUND: #ff9900; RIGHT: 0px; BORDER-LEFT: #ffc080 1px solid; WIDTH: 256px; BOTTOM: 0px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 150px">
	<div id="popupBob_header" style="DISPLAY: none;FILTER:progid:dximagetransform.microsoft.gradient(gradienttype=0,startcolorstr='#ffff9900',endcolorstr='#fffbeebb'); LEFT: 2px;FONT: 12px arial,sans-serif;WIDTH: 250px;CURSOR: default;COLOR: #000000;POSITION: absolute;TOP: 2px;HEIGHT: 14px;TEXT-DECORATION: none">
		<span id="popupBobtitleEl"></span><span onmousedown="event.cancelBubble=true;" onmouseover="style.color='#000000';" style="RIGHT: 3px; FONT: bold 12px arial,sans-serif; CURSOR: pointer; COLOR: #804000; POSITION: absolute; TOP: 0px"
			onclick="popupBobespopup_Close()" onmouseout="style.color='#804000';">X</span>&nbsp;村务系统
	</div>
	<div onmousedown="event.cancelBubble=true;" id="popupBob_content" style="BORDER-RIGHT: #ffc080 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #804000 1px solid; DISPLAY: none; PADDING-LEFT: 2px; BACKGROUND: #ff9900; FILTER:progid:dximagetransform.microsoft.gradient(gradienttype=0,startcolorstr='#ffff9900',endcolorstr='#fffbeebb'); LEFT: 2px; PADDING-BOTTOM: 2px; OVERFLOW: hidden; BORDER-LEFT: #804000 1px solid; WIDTH: 250px; PADDING-TOP: 2px; BORDER-BOTTOM: #ffc080 1px solid; POSITION: absolute; TOP: 20px; HEIGHT: 126px; TEXT-ALIGN: center">
		<A id="popupBobaCnt" onmouseover="style.textDecoration='underline';" style="FONT: 12px arial,sans-serif; COLOR: #000000; TEXT-DECORATION: none"
			onmouseout="style.textDecoration='none';" href="/CWXT/WorkSpace/MyWorkSpace.aspx" target="main" onclick="popupBobespopup_Close()">
			<b><br><span style="FONT-SIZE:11pt">系统信息</span></b><br><br>{0}
		</A>
	</div>
</div>