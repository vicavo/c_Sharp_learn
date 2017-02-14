<script type="text/javascript" language="javascript">
//function killErrors() {
//return true;
//}
//window.onerror = killErrors;	


var oldgridSelectedColor;
function setMouseOverColor(element) {

    oldgridSelectedColor = element.style.backgroundColor;
    element.style.backgroundColor='#BBCEEA';
   // element.style.cursor='hand';
   // element.style.textDecoration='underline';
}
function setMouseOutColor(element) {

    element.style.backgroundColor=oldgridSelectedColor;
    element.style.textDecoration='none';
}


function showwait()
{
    showCover();
    document.getElementById('doing').className="tddisp";
    if(doing.className=="")
    {
    doing.className="tddisp";
    }
    else
    {

    doing.className="";
    }

}






function printpage()
{
document.getElementById("printshow2") .style.visibility="hidden"
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow2") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}

function printaa()
{
document.getElementById("printshow2") .style.visibility="hidden"
//document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
//document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow2") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}

function changecolor(obj,color)
{
     e = event.srcElement
     if(e.checked==true)
     {
      e = e.parentElement
      e.style.background = "#C0C0FF"
     }
     else
     {
       e = e.parentElement
       e.style.background = color
     }
      
      
      
}





function checkAll()
{
	for(var i=0;i<document.form1.elements.length;i++)
	{
	
		document.form1.elements[i].checked=true;
	}
}

function fanAll()
{
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			document.form1.elements[i].checked=false;
		else
			document.form1.elements[i].checked=true;
	}
}




function delcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认删除选中项？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}

function Movecheck()
{
    if(document.getElementById('Realname').value=='')
    {
    alert('用户不能为空');
   
    return false;
    }	


	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认转移选中项到给用户["+document.getElementById('Realname').value+"]吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}




function FolderMovecheck()
{

	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("确认转移选中项吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}





function gxcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认共享选中项？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}


function qxgxcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认取消共享选中项？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}



















function updatecheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{
        if(a>1)
	    {
	    alert('此项操作只能选择一项')
	    return false;
	    }
	    else
	    {
         showwait()
	    
	    }
    }
	else
	{
		alert('请选中一项，如果你想选择一项，请点击每行数据前的选择框即可');
		return false;
	}
	
}




function closeAlert(alertid)
{
   if (typeof(eval('document.all.' + alertid))!= 'undefined')
   {
        document.getElementById(alertid).outerHTML = '';
        closeCover();
    }
}
function closeCover()
{
    if(document.getElementById('AlexCoverV1_0'))
    {
        document.getElementById('AlexCoverV1_0').style.display = 'none';
        DispalySelect(1);
    }
}
function showCover()
{
    //遮罩宽
    var sw = document.body.scrollWidth;
    //遮罩高
    var sh = document.body.scrollHeight;
    if(document.getElementById('AlexCoverV1_0'))
    {
        DispalySelect(0);
        document.getElementById('AlexCoverV1_0').style.display = 'block';
    }
    else
    {
        DispalySelect(0);
        var div = document.createElement("div");
        div.id="AlexCoverV1_0";
        div.style.position="absolute";
        div.style.top="0px";
        div.style.left="0px";
        div.style.height=sh+"px";
        div.style.width=sw+"px";
        div.style.background="#ffffff";
        div.style.filter="alpha(opacity=20)";
        document.body.appendChild(div);
    }
}

//显示和隐藏select控件
function DispalySelect(val)
{   
    var dispalyType;
   var arrdispalyType=["hidden","visible"];
   var arrObjSelect=document.getElementsByTagName("select");
   for (i=0;i<arrObjSelect.length;i++)
   {
     arrObjSelect[i].style.visibility=arrdispalyType[val];
   }
}







</script>