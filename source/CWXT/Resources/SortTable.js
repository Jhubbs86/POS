// JScript source code
/**
	**  ������һ������������֮һ��

	**  ���ߣ�emu(ston)

	**  ʹ�ã�
		����ҳ�ж������ʱ��������±�ǣ�
		<TABLE sortable=true>
		����ҳ��������

		����ָ��һ��Ϊ�������������¸�ʽ��
		<TR sortLine=true >
		�粻ָ����Ϊ����һ�С�

		Ĭ�ϰ�����ĸ˳��������ĳ���谴�������򣬶�Ӧ�ı�����Ҫ��������
		<TD sortType="float">ddd</TD>

	**  ע�⣺ 
		1 �������д���tHead���֣�sortLine��Ӧ����thead��
		2 �粻ָ��sortLine��Ĭ�ϱ��ĵ�һ��ΪsortLine
		3 �����㷨δ���Ż����ڱ��Ƚϴ��ʱ���ٶȻ�Ƚ������Ż����㷨�أ��»ذɡ���
		4 ����汾��������ȫʹ�ýڵ��¡����Ҫ���ǵ��е�ʱ����������ܻ���������Ԫ�أ�������ĳЩ�汾��������������Ĳ����п��ܲ�����ȫ��ֻʹ�ü򵥱��Ļ��������ԣ�������һ������������֮��

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
			var tmptr = tmptable.firstChild.children[i];//���������thead�Ļ��Ͱ�tbody����sortLine��֮�µ�������
			result[result.length] = tmptr.cloneNode(true);
			}
		}
	else
		{
		for (var i=tmptable.children[1].children.length-1;i>-1;i--)
			{
			var tmptr =tmptable.children[1].children[i]; //�������thead�Ļ���Ĭ�ϰ�tbody�е�ȫ��������
			result[result.length] = tmptr.cloneNode(true);
			}
		}
	return result;
	}

function sortArrayFloat(arg1,arg2) //����ָ�����а�����������
	{ 
	return (parseFloat(arg1.children[sortCol].innerText) - parseFloat(arg2.children[sortCol].innerText)) 
	}
function sortArrayString(arg1,arg2) //����ָ�����а�������
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
	sortCol = i;//��ñ��������
	if(_index == 0)  //�����0�в����� peter
		return ;
	sortLine = tmptable.sortLine;//��ñ��������
	var ar = tableToArray(tmptable);//����ת��Ϊ����
	if (elm.sortType == "float")
		ar.sort(sortArrayFloat);//����
	else
		ar.sort(sortArrayString);//����

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
// Ϊһ������һ������¼�
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

String.prototype.trim = function(){  //ɾ���������˵Ŀո�
 return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim = function(){  //ɾ����ߵĿո�
 return this.replace(/(^\s*)/g,"");
}
String.prototype.rtrim = function(){  //ɾ���ұߵĿո�
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