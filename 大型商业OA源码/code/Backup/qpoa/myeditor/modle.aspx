<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modle.aspx.cs" Inherits="qpoa.myeditor.modle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<LINK href="modle/style.css" type=text/css 
rel=stylesheet>
<html xmlns="http://www.w3.org/1999/xhtml" >


<SCRIPT>
<!--

var menu_enter="";

function borderize_on(e)
{
 color="#708DDF";
 source3=event.srcElement

 if(source3.className=="menulines" && source3!=menu_enter)
    source3.style.backgroundColor=color;
}

function borderize_on1(e)
{
 for (i=0; i<document.all.length; i++)
 { document.all(i).style.borderColor="";
   document.all(i).style.backgroundColor="";
   document.all(i).style.color="";
   document.all(i).style.fontWeight="";
 }

 color="#003FBF";
 source3=event.srcElement

 if(source3.className=="menulines")
 { source3.style.borderColor="black";
   source3.style.backgroundColor=color;
   source3.style.color="white";
   source3.style.fontWeight="bold";
 }

 menu_enter=source3;
}

function borderize_off(e)
{
 source4=event.srcElement

 if(source4.className=="menulines" && source4!=menu_enter)
    {source4.style.backgroundColor="";
     source4.style.borderColor="";
    }
}

//-->
</SCRIPT>

<SCRIPT language=JavaScript>
var parent_window = parent.dialogArguments;

function click_model(ID)
{

targetelement=document.all(ID);
parent_window.SetHtml(targetelement.value);
 
  window.close();
}
</SCRIPT>
<head runat="server">
    <title>选择模版</title>
</head>
<body class=bodycolor topMargin=5>
    <form id="form1" runat="server">
    <div>
        <table border="1" bordercolordark="#ffffff" bordercolorlight="#000000" cellpadding="3"
            cellspacing="0" class="small" onclick="borderize_on1(event)" onmouseout="borderize_off(event)"
            onmouseover="borderize_on(event)" width="100%">
            <tbody>
                <tr class="TableHeader">
                    <td align="middle" bgcolor="#d6e7ef">
                        <b>选择模版</b></td>
                </tr>

<%=ModelContent %>

            </tbody>
        </table>
    
    </div>
    </form>
</body>
</html>
