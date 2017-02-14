<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="qpoa.OpenWindows.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script  language="javascript">			
//var  getFromParent=window.dialogArguments;  
//function CheckSelect()
//{

//var a=0
//for(var i=0;i<document.Form1.elements.length;i++)
//{
//if(document.Form1.elements[i].checked==true)
//	{a=a+1}

//}

//if(a>0)
//{

//}
//else
//{
//alert('提交数据失败！未选中项');
//return false;
//}
//	

function CheckSelect()
{
//for(var i=0;i<window.document.Form1.elements.length;i++)
//{
//alert(e.value);
//var e = Form1.elements[i];
////if(e.value=='aaaaaa')
////{
////e.checked==true;
////}
////else
////{
////e.checked==false;
////}
////}
//} 
aa   =   document.getElementsByName("Rad");  

for   (i=0;i<aa.length;i++)  
{ 

 if(aa[i].value==document.getElementById('requeststr').value)
 {
 aa[i].checked=true;
 
 //alert(i);  
 return false;
 }
 else
 {
  aa[i].checked=false;
 }

}   








}

</script> 	
</head>
<body>
    <form id="Form1" runat="server">
    <div>
    aaaaaa<input id="Radio1" type="radio" value='aaaaaa' name="Rad"  /><br>
   vvvvvv <input id="Radio2" type="radio" value='vvvvvv' name="Rad" /><br>
     bbbbb<input id="Radio3" type="radio" value='bbbbb' name="Rad"/><br>
     <input id="Button1" type="button" value="button" onclick="return CheckSelect()"/>
        <asp:TextBox ID="requeststr" runat="server"></asp:TextBox></div>
    </form>
</body>
</html>
