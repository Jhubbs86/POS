// JScript source code
/**
	**  对任意一个表格进行排序之一：

	**  作者：emu(ston)

	**  使用：
		在网页中定义表格的时候加入如下标记：
		<TABLE sortable=true>
		该网页即可排序。

		可以指定一行为标题栏，按如下格式：
		<TR sortLine=true >
		如不指定则为表格第一行。

		默认按照字母顺序排序，如某列需按数字排序，对应的标题栏要这样定义
		<TD sortType="float">ddd</TD>

	**  注意： 
		1 如果表格中存在tHead部分，sortLine行应该在thead中
		2 如不指定sortLine，默认表格的第一行为sortLine
		3 排序算法未经优化，在表格比较大的时候速度会比较慢（优化的算法呢？下回吧。）
		4 这个版本的排序完全使用节点克隆，主要考虑到有的时候表格里面可能会有其他的元素，但是在某些版本的浏览器上这样的操作有可能不够安全。只使用简单表格的话可以试试：对任意一个表格进行排序之二

*/
var tmptables = document.all.tags("table");
for (var i=0;i<tmptables.length;i++)
	if (tmptables[i].sortable)
		attachTable(tmptables[i])
var sortLine,sortCol;

function tableToArray(tmptable)
	{
	var result = new Array();
	if (tmptable.tHead == null)
		{
		for (var i=tmptable.firstChild.children.length-1;i>sortLine;i--)
			{
			var tmptr = tmptable.firstChild.children[i];//如果不存在thead的话就把tbody中在sortLine行之下的行排序
			result[result.length] = tmptr.cloneNode(true);
			}
		}
	else
		{
		for (var i=tmptable.children[1].children.length-1;i>-1;i--)
			{
			var tmptr =tmptable.children[1].children[i]; //如果存在thead的话则默认把tbody中的全部行排序
			result[result.length] = tmptr.cloneNode(true);
			}
		}
	return result;
	}

function sortArrayFloat(arg1,arg2) //根据指定的列按浮点数排序
	{ 
	return (parseFloat(arg1.children[sortCol].innerText) - parseFloat(arg2.children[sortCol].innerText)) 
	}
function sortArrayString(arg1,arg2) //根据指定的列按串排序
	{ 
	//if (arg1.children[sortCol].innerText>arg2.children[sortCol].innerText) return 1
	//else return -1
	/*Modify by Peter 07.8.16 18:53:53 */	   
         if(isNaN(arg1.children[sortCol].innerText)== false && isNaN(arg2.children[sortCol].innerText)==false) 
	     {
            if((Number(arg1.children[sortCol].innerText) - Number(arg2.children[sortCol].innerText)) > 0)
                return 1 ;
            else
                return -1 ;
        }
        else
	        return arg1.children[sortCol].innerText.localeCompare(arg2.children[sortCol].innerText);	// Thanks to Peter       
	}
	
function arrayToTable(ar,tmptable)
	{
	if (tmptable.tHead == null)
		tmptbody = tmptable.firstChild;
	else
		tmptbody = tmptable.children[1];

	for (var i=0;i<ar.length;i++)
		{
		tmptbody.deleteRow(ar[i].rowIndex);
		}
	var tmptbody;
	for (var i=0;i<ar.length;i++)
		{
		tmptbody.insertBefore(ar[i]);
		}
	
	ResetRowColor(tmptbody);
	}

function sortTable()
{
	var elm = event.srcElement;
	var tmptr = elm.parentNode;
	tmptable = tmptr.parentNode.parentNode;
	var _index ;
	
	for (var i=0;i<tmptr.children.length; i++)
	{
		if (tmptr.children[i] == elm ){
			_index = i ;
			break}
	}	
	sortCol = i;//获得被点击的列
	if(_index == 0)  //如果是0行不排序 peter
		return ;
	sortLine = tmptable.sortLine;//获得被点击的行
	var ar = tableToArray(tmptable);//把行转换为数组
	if (elm.sortType == "float")
		ar.sort(sortArrayFloat);//排序
	else
		ar.sort(sortArrayString);//排序

	if (elm.reverse == true)
		{
		elm.reverse = false;
		ar.reverse();
		}
	else
		{
		elm.reverse = true;
		}
	arrayToTable(ar,tmptable);
	
	//Alex 2008-07-24
	for(var i = 1 ; i < tmptable.rows.length ; i++)
	{
        if(tmptable.rows[1].cells[0].children[0].type == "checkbox")
        {
		    for(var j = 1; j < tmptable.rows.length; j++)
		    {
	            if(tmptable.rows[j].cells[0].children[0].checked)
	                tmptable.rows[j].style.backgroundColor = "#70B8F0";      
		    }
        }
        
        if(tmptable.rows[1].cells[0].children[0].type == "radio")
        {
            for(var j = 1; j < tmptable.rows.length; j++)
		    {
		        if(tmptable.rows[j].cells[0].children[0].checked)
		            tmptable.rows[j].style.backgroundColor = "#70B8F0";
		    }
		    
        }
	}
}

function attachTable(tmptable)
// 为一个表格的一行添加事件
{
	var line = 0;
	for (var i=0;i<tmptable.firstChild.children.length ; i++)
		if (tmptable.firstChild.children[i].sortLine)
			line = i ;
	var tds = tmptable.firstChild.children[line].children;
	for (var i=0;i<tds.length;i++)
		{
		tds[i].attachEvent("onclick",sortTable);
		tds[i].style.cursor="hand";
		tds[i].style.fontWeight="bold"
		}
	tmptable.sortLine=line;
}

function ResetRowColor(tbody)
{
	for(var i = 0; i < tbody.rows.length; i ++)
	{
		if(i%2 == 0)
			tbody.rows[i].style.backgroundColor = "#ffffff";//itemBackColor;
		else
			tbody.rows[i].style.backgroundColor = "#e1e1e1";//alternateItemBackColor;
	}
}

String.prototype.trim = function(){  //删除左右两端的空格
 return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim = function(){  //删除左边的空格
 return this.replace(/(^\s*)/g,"");
}
String.prototype.rtrim = function(){  //删除右边的空格
 return this.replace(/(\s*$)/g,"");
}

function ShowWaiting(message)
{

	var doc=window.document;

	var div=doc.createElement("DIV");

	var info="<table style=width:"+document.body.scrollWidth+";height:"+document.body.scrollHeight+";background-color:#969696;filter:alpha(opacity=75)> <tr align=\"center\" valign=\"middle\"> <td> <table width=\"100\" height=\"100\" bgcolor=\"White\" > <tr align=\"center\" valign=\"middle\"> <td><div><img border=0 src="+message+"></img></div></td> </tr> </table> </td> </tr> </table>";		
	div.id='doing';

	div.style.position='absolute';

	div.style.z_index=100;

	div.style.width="100%";
	
	div.style.height="100%";

	div.style.left=0;

	div.style.top=0;
	
	div.style.cursor="wait";

	div.innerHTML=info;

	doc.getElementsByTagName("BODY")[0].appendChild(div); 
	//alert();
}