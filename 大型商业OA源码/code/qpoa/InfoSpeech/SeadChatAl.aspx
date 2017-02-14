<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeadChatAl.aspx.cs" Inherits="qpoa.InfoSpeech.SeadChatAl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<script>
		
		function ifnull()
		{

			if(document.getElementById('content').value=='')
			{
			alert('发送的内容不能为空');
			Form1.content.focus();
			}
			else
			{
			send();
			}
		}
		
		function send()
		{
					
		window.Form1.btn_AddCity.value='发送中...';
		window.Form1.btn_AddCity.disabled=true;
		
		var dt = new Date();
		
		var setime=dt.toLocaleString().replace("年","-").replace("月","-").replace("日","");
		var yuser=document.getElementById('user').value;
		var yname=document.getElementById('name').value;
		var ycontent=document.getElementById('content').value;
		var ysuser=document.getElementById('suser').value;
		var ysname=document.getElementById('sname').value;
		
		var ysChatNameId='<%=Request.QueryString["id"]%>';
		var ysChatName='<%=ChatName%>';
		
		AjaxMethod.sendmessage(ycontent,ysuser,ysname,yuser,yname,setime,ysChatNameId,ysChatName);
		
	    document.getElementById('content').value='';
		}

				
			
				
			function keydown()
			{
			 	if(event.keyCode==13)
			    {
				
				    if(document.getElementById('content').value=='')
				    {
				    alert('发送的内容不能为空');
				    Form1.content.focus();
				    }
				    else
				    {
				    send();
				    }
				
				}		
			
			}	
		

			
	        function setuser(username,realname)
			{
		
			document.getElementById('user').value=username;
			document.getElementById('name').value=realname;
			}
			
			
			
function outexcel()
{

var num=Math.random();
window.open ("SeadChatAlDc.aspx?tmp="+num+"&NameId=<%=Request.QueryString["id"]%>", "_blank", "height=1, width=1")
}	

function outexcels()
{

var num=Math.random();

var user=document.getElementById('suser').value;

window.open ("SeadChatAlDc.aspx?tmp="+num+"&NameId=<%=Request.QueryString["id"]%>&MyUser="+user+"", "_blank", "height=1, width=1")
}				
			
			
			
			
		</script>

<head  runat="server">
    <title>网络办公系统</title>
      <LINK href="../css/public.css" type="text/css" rel="stylesheet">
</head>
<body  bgcolor="#ccffff">
    <form id="Form1" runat="server">
    <div>
	
     
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
      <tr> 
        <td width="84%" height="173" align="center" valign="top">
		 <IFRAME name="rform" marginWidth="1" marginHeight="1" src="SeadChat.aspx?id=<%=Request.QueryString["id"]%>" frameBorder="0" width="99%"  height="445px" BORDERCOLOR="#EDEDED" style="height: 445px"></IFRAME>
		</td>
        <td width="16%" rowspan="1" valign="top" >
            <IFRAME  name="lform" marginWidth="1" marginHeight="1" src="SeadChatPeople.aspx?id=<%=Request.QueryString["id"]%>" frameBorder="0" width="99%"  height="445px" BORDERCOLOR="#EDEDED" style="height: 445px"></IFRAME>
            &nbsp;</td>
      </tr>
        <tr>
            <td style="height: 45px" bgcolor="#ccffff" valign="top">
            
        对<INPUT id="name" type="text" name="name" runat="server" readonly style="width: 47px">说<asp:textbox id="content" onkeydown="keydown()" runat="server" Width="398px" CssClass="TextBoxCss"></asp:textbox>
							
						<INPUT class="TextBoxCss" id="btn_AddCity" style="WIDTH: 104px; HEIGHT: 24px" onclick="ifnull()"
								type="button" value="发送(Enter)" name="btn_AddCity">&nbsp;
							 <INPUT id="user" type="text" name="user" runat="server" style="DISPLAY: none">
         	<INPUT id="suser" type="text" runat="server" style="DISPLAY: none"><INPUT id="sname" type="text" runat="server" style="DISPLAY: none">	
								
            </td>
            <td rowspan="1" valign="top" width="16%" bgcolor="#ccffff">
                <INPUT class="TextBoxCss" id="Button1" style="WIDTH: 104px; HEIGHT: 24px" onclick="outexcels()"
								type="button" value="导出我的对话" name="Button1">
            <INPUT class="TextBoxCss" id="Button2" style="WIDTH: 104px; HEIGHT: 24px" onclick="outexcel()"
								type="button" value="导出所有对话" name="Button2"></td>
        </tr>
    </table>

    
    
    
    </div>
    <IFRAME  name="reform" marginWidth="1" marginHeight="1" src="SeadChatRe.aspx?id=<%=Request.QueryString["id"]%>" frameBorder="0" width="1"  height="1" ></IFRAME>
    </form>
<script language="javascript">

var yuser=document.getElementById('user').value;
var ysuser=document.getElementById('suser').value;
//document.getElementById('show').style.display=''; 



</script>
</body>
</html>
