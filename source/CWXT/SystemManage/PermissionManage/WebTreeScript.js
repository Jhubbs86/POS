

function SetAllChildCheckBox(arrayChildren,checked){
    var currentChild;
    arrayChildren.setAttribute("checked",checked);
    arrayChildren = arrayChildren.getChildren();
    for (var i = 0; i < arrayChildren.length; i++){
        currentChild = arrayChildren[i];
        SetAllChildCheckBox(currentChild,checked);
   }
}

function ExpandTreeNode(tnTarget){
	var oColl=tnTarget.getChildren();
	tnTarget.setAttribute("Expanded",true);
	for (var i=0;i<oColl.length;i++){
		ExpandTreeNode(oColl[i]);
	}
}

function GetTreeNode( trView, index)
{
	return trView.getTreeNode(index);
}



function SetNodeAttribute(trNode,attribute,value)
{
	trNode.setAttribute(attribute,value,1);
}

function SetTreeAttribute(trView,index,attribute,value)
{
	var trNode;
	trNode = GetTreeNode(trView,index);
	SetNodeAttribute(trNode,attribute,value);
}



function GetNodeAttribute(trNode,attribute)
{
	return trNode.getAttribute(attribute);
}

function GetTreeAttribute(trView,index,attribute)
{
	var trNode;
	var returnvalue;
	trNode = GetTreeNode(trView,index);
	returnvalue = GetNodeAttribute(trNode,attribute);
	return returnvalue;
}
	



function  GetParentNode(trView,index)
{
	var pos = index.lastIndexOf(".");
	var trNode ;
	if (pos < 0)
		return null;
	else
		index = index.substring(0,pos);
	trNode = GetTreeNode(trView,index);
	return trNode;
}


function  GetParentIndex(index)
{
	var pos = index.lastIndexOf(".");
	var trNode ;
	if (pos<0)
		return null;
	else
		index = index.substring(0,pos);
	return index;
}

function CancelAllParent(trView,index)
{
	var currentindex ; 
	
	currentindex = GetParentIndex(index);
	if (currentindex == null)
		return ;
	SetTreeAttribute(trView,currentindex,"checked",false);
	CancelAllParent(trView,currentindex);
}

function WhenOneNodeUnChecked(trView,index)
{
	CurrentNode = GetTreeNode(trView,index);
	SetAllChildCheckBox(CurrentNode,false);
	CancelAllParent(trView,index);
	
}



function WhenOneNodeChecked(trView,index)
{
	CurrentNode = GetTreeNode(trView,index);
	SetAllChildCheckBox(CurrentNode,true);
	CheckAllParentNendCheck(trView,index);
}

function CheckAllParentNendCheck(trView,index)
{
	var ParentNode;
	var ParentIndex; 
	var arrayChildren = new Array();
	var currentChild ; 
	var allchecked ; 
	ParentIndex = GetParentIndex(index);
	
	if (ParentIndex != null )
	{
		ParentNode = GetParentNode(trView,index);
		arrayChildren = ParentNode.getChildren();
		allchecked = true ;
		
		for ( var i = 0 ;i < arrayChildren.length ; i++)
		{
			currentChild = arrayChildren[i];
			allchecked = currentChild.getAttribute("checked");
			if ( allchecked == false)
			{
				break ;
			}
		}	
		if (allchecked == true)
		{
			SetTreeAttribute(trView,ParentIndex,"checked",true);
			CheckAllParentNendCheck(trView,ParentIndex);
		}
		else 
			return ;
	}
	else
		return ;
}



function OnRegionCheck() {
	var index ; 
	var trView = event.srcElement
	index = event.treeNodeIndex ; 
	SetAllParentChecked(trView,index);
}

function SetAllParentChecked(trView,index)
{
	var pos;
	var currentchecked ;
	var currentNode =GetTreeNode(trView,index); 
	currentchecked =  GetTreeAttribute(trView,index,"checked");
	
	if (currentchecked == false )
	{
		SetAllChildCheckBox(currentNode,false);
		return ;
	}
	SetAllChildCheckBox(currentNode,true);
	pos = index.lastIndexOf(".");
	
	while(pos != -1)
	{
		index = index.substring(0,pos);
		SetTreeAttribute(trView,index,"checked",true);
		pos = index.lastIndexOf(".");	
	}
}
/*********************************************************************/
var CheckedMenuArray ;
var index ;
function SaveMenuConfig()
{
	var tree;
	var rolepkid ;
	var rolepkidobj ;
	index = 0
	CheckedMenuArray = new Array()
	tree = document.getElementById("tvFunction");
	GetMenuChecked(tree.getChildren());
	rolepkidobj = document.getElementById("RolePKID");
	rolepkid = rolepkidobj.value;
	BusinessRule.SystemManage.AjaxMenuRight.SaveConfig(CheckedMenuArray,rolepkid);
}

function GetMenuChecked(arrayChildren){
    var currentChild;
    for (var i = 0; i < arrayChildren.length; i++){
        currentChild = arrayChildren[i];
        GetMenuChecked(currentChild.getChildren());
        if (currentChild.getAttribute("checked") == true)
        {
			CheckedMenuArray[index] = currentChild.getAttribute("nodedata");
			index = index + 1;
        }
    }
}


/************************************************************************/

var CheckedRegionArray ;
function AjaxSaveRegionConfig()
{
	var tree ; 
	var userpkid ; 
	var userobject ; 
	index = 0 ;
	CheckedRegionArray = new Array();
	
	tree = document.getElementById("tvRegion");
	GetRegionChecked(tree.getChildren());
	userobject = document.getElementById("RolePKID");
	userpkid = userobject.value ; 
	BusinessRule.SystemManage.AjaxRegionRight.SaveRegionConfig(CheckedRegionArray,userpkid);
}


function GetRegionChecked(arrayChildren){
    var currentChild;
    for (var i = 0; i < arrayChildren.length; i++){
        currentChild = arrayChildren[i];
        GetRegionChecked(currentChild.getChildren());
        if (currentChild.getAttribute("checked") == true)
        {
			CheckedRegionArray[index] = currentChild.getAttribute("nodedata");
			index = index + 1;
        }
    }
}

/*************************************************************************/

var CheckedProductArray ;
function AjaxSaveProductConfig()
{
	var tree ; 
	var userpkid ; 
	var userobject ; 
	index = 0 ;
	CheckedProductArray = new Array();
	
	tree = document.getElementById("tvProduct");
	GetProductChecked(tree.getChildren());
	userobject = document.getElementById("UserPKID");
	userpkid = userobject.value ; 
	BusinessRule.SystemManage.AjaxProductRight.SaveProductConfig(CheckedProductArray,userpkid);
}


function GetProductChecked(arrayChildren){
    var currentChild;
    for (var i = 0; i < arrayChildren.length; i++){
        currentChild = arrayChildren[i];
        GetProductChecked(currentChild.getChildren());
        if (currentChild.getAttribute("checked") == true)
        {
			CheckedProductArray[index] = currentChild.getAttribute("nodedata");
			index = index + 1;
        }
    }
}
function SaveRegionProductConfig()
{
	AjaxSaveProductConfig();
	AjaxSaveRegionConfig();
	
}



/*****************************************************************************/
function onchecked()
{
	var checked ;
	var index ; 
	index = event.treeNodeIndex ; 
	var trNode = event.srcElement.getTreeNode(index);
	checked  = trNode.getAttribute("checked");
	if (checked == false)
	{
		WhenOneNodeUnChecked(event.srcElement,index);
	}
	else if (checked == true)
		WhenOneNodeChecked(event.srcElement,index);
}

