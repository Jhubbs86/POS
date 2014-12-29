var systemName = "村务系统";


function showDialog(url, dw, dh, modeless, args) {
    if (typeof (args) == "undefined") args = window;
    if (args == null) args = window;
    var r;
    if (modeless)
        r = window.showModelessDialog(url, args, "dialogWidth:" + dw + ";dialogHeight:" + dh + ";center:yes;edge:raised;help:no;resizable:yes;scroll:yes;status:no;");
    else
        r = window.showModalDialog(url, args, "dialogWidth:" + dw + ";dialogHeight:" + dh + ";center:yes;edge:raised;help:no;resizable:no;scroll:yes;status:no;");
    return r;
}

function redirect(url) {
    window.location.assign(url);
}


/* 选中DataGrid中所有行 */
function SelectAll(obj) {
    var cbx = obj;
    while (obj.tagName != "TABLE") {
        obj = obj.parentElement;
    }
    for (var i = 1; i < obj.rows.length; i++) {
        obj.rows[i].cells[0].children[0].checked = cbx.checked;

        //Alex 2008-07-24
        for (var j = 1; j < obj.rows.length; j++) {
            if (j % 2 == 0) {
                if (obj.rows[j].cells[0].children[0].checked)
                    obj.rows[j].style.backgroundColor = "#70B8F0";
                else
                    obj.rows[j].style.backgroundColor = "#e1e1e1";
            }
            else {
                if (obj.rows[j].cells[0].children[0].checked)
                    obj.rows[j].style.backgroundColor = "#70B8F0";
                else
                    obj.rows[j].style.backgroundColor = "#ffffff";
            }
        }
    }
}

function SelectAllById(ObjID) {
    var obj = document.getElementById(ObjID);
    var cbx = document.getElementById(ObjID);
    while (obj.tagName != "TABLE") {
        obj = obj.parentElement;
    }
    for (var i = 1; i < obj.rows.length; i++) {
        obj.rows[i].cells[0].children[0].checked = cbx.checked;

        //Alex 2008-07-24
        for (var j = 1; j < obj.rows.length; j++) {
            if (j % 2 == 0) {
                if (obj.rows[j].cells[0].children[0].checked)
                    obj.rows[j].style.backgroundColor = "#70B8F0";
                else
                    obj.rows[j].style.backgroundColor = "#e1e1e1";
            }
            else {
                if (obj.rows[j].cells[0].children[0].checked)
                    obj.rows[j].style.backgroundColor = "#70B8F0";
                else
                    obj.rows[j].style.backgroundColor = "#ffffff";
            }
        }
    }
}
/* 检查DataGrid中是否有记录被选中 */
function NeedSelectionCheck(tb) {
    if (tb != "undefined" && tb != null) {
        var k = 0;
        for (var i = 1; i < tb.rows.length; i++) {
            if (tb.rows[i].cells[0].children[0].checked)
                k++;
        }
        if (k == 0) {
            window.alert("请选择一条记录，再进行操作！");
            return false;
        }
        else
            return true;
    }
}

function QueryItemClicked() {
    var tr;
    tr = window.event.srcElement;
    while (tr.tagName != "TR") {
        tr = tr.parentElement;
        if (tr == "undefined" || tr == null)
            return;
    }
    tr.cells[0].children[0].checked = true;
}

function QueryItemDescClicked() {
    var tr;
    tr = window.event.srcElement;
    while (tr.tagName != "TR") {
        tr = tr.parentElement;
        if (tr == "undefined" || tr == null)
            return;
    }
    tr.cells[0].children[0].checked = !tr.cells[0].children[0].checked;
}

function OpenModalDialog(url) {
    return showDialog(url, "720px", "550px", false, null);
}

function OpenModalDialog1(url) {
    return window.open(url, null, 'height=450, width=800, top=140,left=300,toolbar=no, menubar=no, scrollbars=yes,location=no,resizable=yes, status=no')
}

/* 格式化提示（title, alt） */
var pltsPop = null;
var pltsoffsetX = 10;
var pltsoffsetY = 15;
var pltsPopbg = "#FFFFEE";
var pltsPopfg = "#111111";
var pltsTitle = "";
document.write('<div id=pltsTipLayer style="display: none;position: absolute; z-index:10001; font-size:12px;font-family: Tahoma;"></div>');
function pltsinits() {
    document.onmouseover = plts;
    document.onmousemove = moveToMouseLoc;
}
function plts() {
    var o = event.srcElement;
    if (o == null) return;

    if (o.alt != null && o.alt != "") { o.dypop = o.alt; o.alt = "" };
    if (o.title != null && o.title != "") { o.dypop = o.title; o.title = "" };
    pltsPop = o.dypop;
    if (pltsPop != null && pltsPop != "" && typeof (pltsPop) != "undefined") {
        pltsTipLayer.style.left = -1000;
        pltsTipLayer.style.display = '';
        var Msg = pltsPop.replace(/\n/g, "<br>");
        Msg = Msg.replace(/\0x13/g, "<br>");
        var re = /\{(.[^\{]*)\}/ig;
        if (!re.test(Msg)) pltsTitle = systemName;
        else {
            re = /\{(.[^\{]*)\}(.*)/ig;
            pltsTitle = Msg.replace(re, "$1") + "&nbsp;";
            re = /\{(.[^\{]*)\}/ig;
            Msg = Msg.replace(re, "");
            Msg = Msg.replace("<br>", "");
        }
        var attr = (document.location.toString().toLowerCase().indexOf("list.asp") > 0 ? "nowrap" : "");
        var content =
      	'<table style="FILTER:alpha(opacity=90) shadow(color=#bbbbbb,direction=135);" id=toolTipTalbe border=0><tr><td width="100%"><table class=youqing cellspacing="1" cellpadding="0" style="width:100%" style="font size:11px;">' +
      	'<tr id=pltsPoptop><th height=18 valign=bottom><p id=topleft align=left>↖' + pltsTitle + '</p><p id=topright align=right style="display:none">' + pltsTitle + '↗</font></th></tr>' +
      	'<tr><td "+attr+" class=f_one style="padding-left:10px;padding-right:10px;padding-top: 4px;padding-bottom:4px;line-height:135%">' + Msg + '</td></tr>' +
      	'<tr id=pltsPopbot style="display:none"><th height=18 valign=bottom><p id=botleft align=left>↙' + pltsTitle + '</p><p id=botright align=right style="display:none">' + pltsTitle + '↘</font></th></tr>' +
      	'</table></td></tr></table>';
        pltsTipLayer.innerHTML = content;
        toolTipTalbe.style.width = Math.min(pltsTipLayer.clientWidth, document.body.clientWidth / 2.2);
        moveToMouseLoc();
        return true;
    }
    else {
        pltsTipLayer.innerHTML = '';
        pltsTipLayer.style.display = 'none';
        return true;
    }
}

function moveToMouseLoc() {
    if (pltsTipLayer.innerHTML == '') return true;
    var MouseX = event.x;
    var MouseY = event.y;
    //window.status=event.y;
    var popHeight = pltsTipLayer.clientHeight;
    var popWidth = pltsTipLayer.clientWidth;
    if (MouseY + pltsoffsetY + popHeight > document.body.clientHeight) {
        popTopAdjust = -popHeight - pltsoffsetY * 1.5;
        pltsPoptop.style.display = "none";
        pltsPopbot.style.display = "";
    }
    else {
        popTopAdjust = 0;
        pltsPoptop.style.display = "";
        pltsPopbot.style.display = "none";
    }
    if (MouseX + pltsoffsetX + popWidth > document.body.clientWidth) {
        popLeftAdjust = -popWidth - pltsoffsetX * 2;
        topleft.style.display = "none";
        botleft.style.display = "none";
        topright.style.display = "";
        botright.style.display = "";
    }
    else {
        popLeftAdjust = 0;
        topleft.style.display = "";
        botleft.style.display = "";
        topright.style.display = "none";
        botright.style.display = "none";
    }
    pltsTipLayer.style.left = MouseX + pltsoffsetX + document.body.scrollLeft + popLeftAdjust;
    pltsTipLayer.style.top = MouseY + pltsoffsetY + document.body.scrollTop + popTopAdjust;
    return true;
}
pltsinits();

/*
输入框检验*/
function CheckMaxlength(obj, maxlength) {
    if (event.propertyName != "value") return;
    if (obj.value.length > maxlength) obj.value = obj.value.substr(0, maxlength);
}



/*MSN like Alert script*/
var popupBoboldonloadHndlr = window.onload, popupBobpopupHgt, popupBobactualHgt, popupBobtmrId = -1, popupBobresetTimer;
var popupBobtitHgt, popupBobcntDelta, popupBobtmrHide = -1, popupBobhideAfter = 10000, popupBobhideAlpha, popupBobhasFilters = true;
var popupBobnWin, popupBobshowBy = null, popupBobdxTimer = -1, popupBobpopupBottom;
var popupBobnText, popupBobnMsg, popupBobnTitle, popupBobbChangeTexts = false;
var popupBoboldonscrollHndr = window.onscroll;
window.onscroll = popupBobespopup_winScroll;

function popupBobespopup_winScroll() {
    if (popupBoboldonscrollHndr != null) popupBoboldonscrollHndr();
    if (popupBobtmrHide != -1) {
        el = document.getElementById('popupBob');
        el.style.display = 'none'; el.style.display = 'block';
    }
}

function popupBobespopup_ShowPopup(show) {
    if (popupBobdxTimer != -1) { el.filters.blendTrans.stop(); }

    if ((popupBobtmrHide != -1) && ((show != null) && (show == popupBobshowBy))) {
        clearInterval(popupBobtmrHide);
        popupBobtmrHide = setInterval(popupBobespopup_tmrHideTimer, popupBobhideAfter);
        return;
    }
    if (popupBobtmrId != -1) return;
    popupBobshowBy = show;

    elCnt = document.getElementById('popupBob_content')
    elTit = document.getElementById('popupBob_header');
    el = document.getElementById('popupBob');
    el.style.left = '';
    el.style.top = '';
    el.style.filter = '';

    if (popupBobtmrHide != -1) clearInterval(popupBobtmrHide); popupBobtmrHide = -1;

    document.getElementById('popupBob_header').style.display = 'none';
    document.getElementById('popupBob_content').style.display = 'none';

    if (navigator.userAgent.indexOf('Opera') != -1)
        el.style.bottom = (document.body.scrollHeight * 1 - document.body.scrollTop * 1
                            - document.body.offsetHeight * 1 + 1 * popupBobpopupBottom) + 'px';

    if (popupBobbChangeTexts) {
        popupBobbChangeTexts = false;
        document.getElementById('popupBobaCnt').innerHTML = popupBobnMsg;
        document.getElementById('popupBobtitleEl').innerHTML = popupBobnTitle;
    }

    popupBobactualHgt = 0; el.style.height = popupBobactualHgt + 'px';
    el.style.visibility = '';
    if (!popupBobresetTimer) el.style.display = '';
    popupBobtmrId = setInterval(popupBobespopup_tmrTimer, (popupBobresetTimer ? 1000 : 20));
}

function popupBobespopup_winLoad() {
    if (popupBoboldonloadHndlr != null) popupBoboldonloadHndlr();

    elCnt = document.getElementById('popupBob_content')
    elTit = document.getElementById('popupBob_header');
    el = document.getElementById('popupBob');
    popupBobpopupBottom = el.style.bottom.substr(0, el.style.bottom.length - 2);

    popupBobtitHgt = elTit.style.height.substr(0, elTit.style.height.length - 2);
    popupBobpopupHgt = el.style.height;
    popupBobpopupHgt = popupBobpopupHgt.substr(0, popupBobpopupHgt.length - 2);
    popupBobactualHgt = 0;
    popupBobcntDelta = popupBobpopupHgt - (elCnt.style.height.substr(0, elCnt.style.height.length - 2));

    if (true) {
        popupBobresetTimer = true;
        popupBobespopup_ShowPopup(null);
    }
}

function popupBobespopup_tmrTimer() {
    el = document.getElementById('popupBob');
    if (popupBobresetTimer) {
        el.style.display = '';
        clearInterval(popupBobtmrId); popupBobresetTimer = false;
        popupBobtmrId = setInterval(popupBobespopup_tmrTimer, 20);
    }
    popupBobactualHgt += 5;
    if (popupBobactualHgt >= popupBobpopupHgt) {
        popupBobactualHgt = popupBobpopupHgt; clearInterval(popupBobtmrId); popupBobtmrId = -1;
        document.getElementById('popupBob_content').style.display = '';
        if (popupBobhideAfter != -1) popupBobtmrHide = setInterval(popupBobespopup_tmrHideTimer, popupBobhideAfter);
    }
    if (popupBobtitHgt < popupBobactualHgt - 6)
        document.getElementById('popupBob_header').style.display = '';
    if ((popupBobactualHgt - popupBobcntDelta) > 0) {
        elCnt = document.getElementById('popupBob_content')
        elCnt.style.display = '';
        elCnt.style.height = (popupBobactualHgt - popupBobcntDelta) + 'px';
    }
    el.style.height = popupBobactualHgt + 'px';
}

function popupBobespopup_tmrHideTimer() {
    clearInterval(popupBobtmrHide); popupBobtmrHide = -1;
    el = document.getElementById('popupBob');
    if (popupBobhasFilters) {
        backCnt = document.getElementById('popupBob_content').innerHTML;
        backTit = document.getElementById('popupBob_header').innerHTML;
        document.getElementById('popupBob_content').innerHTML = '';
        document.getElementById('popupBob_header').innerHTML = '';
        el.style.filter = 'blendTrans(duration=1)';
        el.filters.blendTrans.apply();
        el.style.visibility = 'hidden';
        el.filters.blendTrans.play();
        document.getElementById('popupBob_content').innerHTML = backCnt;
        document.getElementById('popupBob_header').innerHTML = backTit;

        popupBobdxTimer = setInterval(popupBobespopup_dxTimer, 1000);
    }
    else el.style.visibility = 'hidden';
}

function popupBobespopup_dxTimer() {
    clearInterval(popupBobdxTimer); popupBobdxTimer = -1;
}

function popupBobespopup_Close() {
    if (popupBobtmrId == -1) {
        el = document.getElementById('popupBob');
        el.style.filter = '';
        el.style.display = 'none';
        if (popupBobtmrHide != -1) clearInterval(popupBobtmrHide); popupBobtmrHide = -1;

    }
}

var popupBobmousemoveBack, popupBobmouseupBack;
var popupBobofsX, popupBobofsY;
function popupBobespopup_DragDrop(e) {
    popupBobmousemoveBack = document.body.onmousemove;
    popupBobmouseupBack = document.body.onmouseup;
    ox = (e.offsetX == null) ? e.layerX : e.offsetX;
    oy = (e.offsetY == null) ? e.layerY : e.offsetY;
    popupBobofsX = ox; popupBobofsY = oy;

    document.body.onmousemove = popupBobespopup_DragDropMove;
    document.body.onmouseup = popupBobespopup_DragDropStop;
    if (popupBobtmrHide != -1) clearInterval(popupBobtmrHide);
}

function popupBobespopup_DragDropMove(e) {
    el = document.getElementById('popupBob');
    if (e == null && event != null) {
        el.style.left = (event.clientX * 1 + document.body.scrollLeft - popupBobofsX) + 'px';
        el.style.top = (event.clientY * 1 + document.body.scrollTop - popupBobofsY) + 'px';
        event.cancelBubble = true;
    }
    else {
        el.style.left = (e.pageX * 1 - popupBobofsX) + 'px';
        el.style.top = (e.pageY * 1 - popupBobofsY) + 'px';
        e.cancelBubble = true;
    }
    if ((event.button & 1) == 0) popupBobespopup_DragDropStop();
}

function popupBobespopup_DragDropStop() {
    document.body.onmousemove = popupBobmousemoveBack;
    document.body.onmouseup = popupBobmouseupBack;
}


//Alex 2008-07-24
function dgLoad() {
    var tbs = document.getElementsByTagName("table");
    if (tbs.length > 0) {
        for (var i = 0; i < tbs.length; i++) {
            if (tbs[i].className == "DGStyle" && tbs[i].rows.length > 1) {
                if (tbs[i].rows[1].cells[0].children[0].type == "checkbox") {
                    for (var j = 1; j < tbs[i].rows.length; j++) {
                        if (tbs[i].rows[j].cells[0].children[0].checked)
                            tbs[i].rows[j].style.backgroundColor = "#70B8F0";
                    }
                }

                if (tbs[i].rows[1].cells[0].children[0].type == "radio") {
                    for (var j = 1; j < tbs[i].rows.length; j++) {
                        if (tbs[i].rows[j].cells[0].children[0].checked)
                            tbs[i].rows[j].style.backgroundColor = "#70B8F0";
                    }

                }
            }
        }
    }
}

//Alex 2008-07-28
var DGxmlHttp;
function createDGXMLHttpRequest() {
    if (window.ActiveXObject)
        DGxmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    else
        DGxmlHttp = new XMLHttpRequest();
}
function DGGetAjaxData(id, pkid) {
    createDGXMLHttpRequest();
    var url = "/CWXT/WelcomeBarAjax.aspx?dgID=" + id + "&dgPKID=" + pkid + "&rnd=" + Math.random();
    DGxmlHttp.open("GET", url, true);
    DGxmlHttp.onreadystatechange = callDGAjaxData;
    DGxmlHttp.send(null);
}
function callDGAjaxData() {
    if (DGxmlHttp.readyState == 4) {
        if (DGxmlHttp.status == 200 || DGxmlHttp.status == 0) {
        }
    }
}
