<%@ Page Language="C#" AutoEventWireup="true" Codebehind="main.aspx.cs" Inherits="qpoa.testmain" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����칫ϵͳ</title>
    <link href="css/public.css" type="text/css" rel="stylesheet">
    <link href="head/menu.css" type="text/css" rel="stylesheet">
    <script>
		window.resizeTo(screen.availWidth, screen.availHeight);
		window.moveTo(0, 0);
    </script>
    <script>
function killErrors() {
return true;
}
window.onerror = killErrors;	
    </script>

    <script language="javascript">


function visible_click()
{
if(td1.className=="")
{

td1.className="tddisp";


}
else
{
td1.className="";

}

}

function zx()
{
if (!confirm("�Ƿ�ȷ��Ҫע����"))
return false;
}

var OA_TIME = new Date(2008,0,19,20,14,12);

function timeview()
{
timestr=OA_TIME.toLocaleString();
timestr=timestr.substr(timestr.indexOf(":")-2);
document.getElementById("time_area").innerHTML = timestr;
OA_TIME.setSeconds(OA_TIME.getSeconds()+1);
window.setTimeout( "timeview()", 1000 );
}


function UploadComplete()
{

    showCover();
    //�ؼ���
    var aw = 400;
    //�ؼ���
    var ah = 80;
    //����ؼ�ˮƽλ��
    var al = (screen.width - aw)/2;
    //����ؼ���ֱλ��
    var at = (screen.height - ah)/5;
    //���ݹ���
    var title = '';
    var icon = 'indi.gif';
    var cardID = '0';
    //�����ʾ��
    var div = document.createElement("div");
    div.id = "UploadChoose";
    div.innerHTML = '\
    <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:center">\
        <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
        <div style="padding-top:30px;">\
        <div style="float:left;width:60px;padding-left:50px"><img src="images/'+icon+'" alert"Cardo" /></div>\
       <div style="float:left;width:180px;margin-top:13px;padding-left:0px"><b>���ݼ����У���ȴ�...</b></div>\
    <div style="clear:both;text-align:center;margin-top:10px;padding-bottom:10px">\
            </div>\
        </div>\
    </div>';
    document.body.appendChild(div);

}

function closeAlert(alertid)
{
    document.getElementById(alertid).outerHTML = '';
    closeCover();
}


    </script>

    <script>
	
			function send_request(url)
			{
				http_request=false;
				if(window.XMLHttpRequest)//Mozilla �����
				{
					http_request=new XMLHttpRequest();
					if(http_request.overrideMimeType)//����MiME���
					{
						http_request.overrideMimeType("text/xml");
					}
				}
				else if(window.ActiveXObject)// IE�����
				{
					try
					{
						http_request=new ActiveXObject("Msxml2.XMLHTTP");
					}
					catch(e)
					{
						try
						{
							http_request=new ActivexObject("Microsoft.XMLHTTP");
						}
						catch(e)
						{}
					}
				}
				if(!http_request)// �쳣����������ʵ��ʧ��
				{
				    content.innerHTML="���ܴ���XMLHttpRequest����ʵ��";
					//window.alert("���ܴ���XMLHttpRequest����ʵ��");
					return false;
				}
				//ָ��������������Ϣʱ�������
				http_request.onreadystatechange=processRequest;
				// ȷ����������ķ�ʽ��URL�Լ��Ƿ�ͬ��ִ���¶δ���
				http_request.open("GET",url,true);
				http_request.send(null);
			}
			
			
			
			function processRequest()
			{
				if(http_request.readyState==4)
				{					
					if(http_request.status==200)
					{						
				
					//content.innerHTML=http_request.responseText;
					
					if(http_request.responseText=='notuser')
					{
					alert('��½��ʱ');window.parent.location = 'default.aspx' }
					}
					else
					{
						//window.parent.location = 'default.aspx' 
						
					window.parent.location = 'default.aspx'
					content.innerHTML="���������ҳ�����쳣�������µ�½����";
					}
				}
			}
			
		
			window.setInterval("send_request('user_online_update.aspx?tmp='+Math.random())",3000);
			
			
			
			
    function useronline()
    {
    mytop=screen.availHeight-500;
    myleft=0;
    window.open("user_online.aspx","online","height=370,width=170,status=0,toolbar=no,menubar=no,location=no,top="+mytop+",left="+myleft+",resizable=yes,scrollbars=yes");
    }
    
    function userall()
    {
    mytop=screen.availHeight-500;
    myleft=0;
    window.open("user_all.aspx","online","height=370,width=170,status=0,toolbar=no,menubar=no,location=no,top="+mytop+",left="+myleft+",resizable=yes,scrollbars=yes");
    }
    
    
	function openuser()
	{
        mytop=screen.availHeight-500;
        myleft=250;
        window.open("MyDataUpdate.aspx","tixing","height=500,width=600,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
	}   
    
    
    	
    </script>

    <script language="JavaScript">
var obj = self.parent;
var popWin = null;

function showWizard(url){
	var width = 250 ;
	var height = screen.availHeight;

	var szFeatures = "top=0," ; 
	szFeatures +="left="+(screen.availWidth-width)+"," ;
	szFeatures +="width="+width+"," ;
	szFeatures +="height="+height+"," ;
	szFeatures +="directories=no," ;
	szFeatures +="status=yes," ;
	szFeatures +="menubar=no," ;
	szFeatures +="scrollbars=yes," ;
	szFeatures +="resizable=yes" ;

	try{
		if(popWin!=null){
			popWin.focus();
			popWin.resizeTo(250,screen.availHeight);
			popWin.moveTo(screen.availWidth-width,0);
			popWin.location = url;
		}else{
			popWin = window.open(url,"a",szFeatures) ;
			popWin.focus();
		}
	}catch(exception){
		popWin = null;
		popWin = window.open(url,"a",szFeatures) ;
		popWin.focus();
	}

	var newWidth = screen.availWidth - width;
  	obj.moveTo(0,0);
  	obj.resizeTo(newWidth,height);
    parent.guidewin=popWin;
    //alert(parent.guidewin.name);
}

    </script>

    <script>
function card()
{
var num=Math.random();
window.showModalDialog("Desk/card.aspx?tmp="+num+"","window","dialogWidth:417px;DialogHeight=400px;status:no;scroll=no;help:no");  
}

function keystr()
{
var num=Math.random();
window.showModalDialog("Desk/KeyStr.aspx?tmp="+num+"","window","dialogWidth:417px;DialogHeight=400px;status:no;scroll=no;help:no");  
}

function openplugin()
{
mytop=screen.availHeight-500;
myleft=250;
window.open("Desk/plugin.aspx","plugin","height=300,width=600,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="public/public.js"-->
        <!--#include file="public/pleasewait.htm"-->
        <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" height="90">
                                <table width="100%" height="90" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" height="70" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top" background="images/m_bg1.jpg">
                                                        <table width="100%" height="70" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="73%">
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                             <img src="images/logo.png">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="27%" valign="top" class="headtd">
                                                                    <br>
                                                                    <span id="ShowTime"></span>

                                                                    <script>

var aa=DateDemo();
document.getElementById("ShowTime").innerHTML=" <font color='#ffffff'>�����ǣ�<%=showtime %>&nbsp;&nbsp;"+aa+"</font>&nbsp;&nbsp;";
function DateDemo(){
var d, day, x, s = " ";
var x = new Array("������", "����һ", "���ڶ�");
var x = x.concat("������","������", "������");
var x = x.concat("������");
d = new Date();
day = d.getDay();
return(s += x[day]);
}
                                                                    </script>

                                                                    <span id="time_area"></span><span id="liveclock"></span>

                                                                    <script language="javascript">                      
function www_helpor_net()                      
{                      
var Digital=new Date()                      
var hours=Digital.getHours()                      
var minutes=Digital.getMinutes()                      
var seconds=Digital.getSeconds()                      

if(minutes<=9)                      
minutes="0"+minutes                      
if(seconds<=9)                      
seconds="0"+seconds                      
myclock="<font color='#ffffff'>"+hours+":"+minutes+":"+seconds+"</font>"                      
if(document.layers){document.layers.liveclock.document.write(myclock)                      
document.layers.liveclock.document.close()                      
}else if(document.all)                      
liveclock.innerHTML=myclock                      
setTimeout("www_helpor_net()",1000)                      
}                      
www_helpor_net();                      
//-->                      
                                                                    </script>
<br>
                                                                    <br>
                                                                    <div>
                                                                        <font color='#ffffff'>��ӭ����
                                                                            <%=showpost%>
                                                                            &gt;
                                                                            <%=showrealname%>
                                                                        </font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<iframe name="tx" marginwidth="0"
                                                                            marginheight="0" src="Maintx.aspx" frameborder="0" width="70px" bordercolor="#EDEDED"
                                                                            height="11px" style="border-style: none" scrolling="no"></iframe>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="38" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="images/head_bg.jpg">
                                                        <table width="100%" height="38" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="50">
                                                                    <img src="images/logo.jpg" width="50" height="38" border="0"></td>
                                                                <td width="939" class="headtd" align="left">
                                                                    <asp:Label ID="oaurl" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="16" border="0" cellpadding="0" cellspacing="0" background="images/head_line2.jpg">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="61">
                                                                    <a href="javascript:void(0)">
                                                                        <img src="images/head_line8.jpg" width="59" height="15" border="0" onclick="card()"
                                                                            alt="��������"></a></td>
                                                                <td width="61">
                                                                    <a href="javascript:void(0)">
                                                                        <img src="images/head_line9.jpg" width="59" height="15" border="0" onclick="openplugin()"
                                                                            alt="����������"></a></td>
                                                                <td width="61">
                                                                    <a href="DIYMould/DIYMould.aspx" target="rform" onclick="UploadComplete();">
                                                                        <img src="images/head_line10.jpg" width="59" height="15" border="0" alt="����̨����ģ������"></a></td>
                                                                <td width="61">
                                                                    <a href="Desk/MyQx.aspx" target="rform" onclick="UploadComplete();">
                                                                        <img src="images/head_line11.jpg" width="59" height="15" border="0" alt="�ҵ�Ȩ��"></a></td>
                                                                <td width="629" background="images/head_line2.jpg">
                                                                </td>
                                                                <td width="66">
                                                                    <a href="main_d.aspx" target="rform">
                                                                        <img src="images/head_line3.jpg" width="66" height="16" border="0"></a></td>
                                                                <td width="59">
                                                                    <a href="javascript:void(0)" onclick="history.back()">
                                                                        <img src="images/head_line4.jpg" width="59" height="16" border="0"></a></td>
                                                                <td width="61">
                                                                    <a href="javascript:void(0)" onclick="history.forward()">
                                                                        <img src="images/head_line5.jpg" width="61" height="16" border="0"></a></td>
                                                                <td width="59">
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/head_line6.jpg"
                                                                        OnClick="ImageButton1_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="200" valign="top" class="" id="td1">
                                                        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="40" valign="top">
                                                                    <table width="100%" height="40" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="77">
                                                                                <a href="user_online.aspx" class="line_b" target="lform">
                                                                                    <img src="images/a1a.jpg" width="77" height="40" border="0" /></a></td>
                                                                            <td width="62">
                                                                               <a href="user_all.aspx" class="line_b" target="lform">
                                                                                    <img src="images/a1b.jpg" width="62" height="40" border="0" /></a></td>
                                                                            <td>
                                                                                 <a href="MyAffairs/SystemPassword.aspx" class="line_b" target="rform">
                                                                                    <img src="images/a1c.jpg" width="77" height="40" border="0" /></a></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top"  background="images/a4.jpg">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" height="100%">
                                                                        <tr>
                                                                            <td width="11">
                                                                                &nbsp;</td>
                                                                            <td>
                                                                                <iframe name="lform" marginwidth="0" marginheight="0" src="MyAffairstable.aspx" frameborder="0"
                                                                                    width="200px" bordercolor="#EDEDED" height="100%" style="border-style: none"></iframe>
                                                                            </td>
                                                                            <td width="8">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="48" valign="bottom">
                                                                    <table width="100%" height="48" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="74">
                                                                                <a href="WinGround.aspx" class="line_b" target="rform">
                                                                                    <img src="images/a5a.jpg" width="74" height="48" border="0" /></a></td>
                                                                            <td width="62">
                                                                                <a href="javascript:void(0)" class="line_b" onclick="openuser()">
                                                                                    <img src="images/a5b.jpg" width="62" height="48" border="0" /></a></td>
                                                                            <td>
                                                                                <a href="IfOpen.aspx" class="line_b" target="rform">
                                                                                    <img src="images/a5c.jpg" width="80" height="48" border="0" /></a></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="9" class="newbody">
                                                        <a href="javascript:void(0)">
                                                            <img src="images/g2.jpg" width="9" height="100%" border="0" onclick="visible_click()"></a>
                                                    </td>
                                                    <td valign="top">
                                                        <iframe frameborder="0" name="rform" marginwidth="0" marginheight="0" src="main_d.aspx"
                                                            width="100%" height="100%" scrolling="auto"></iframe>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" height="23">
                                <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" background="images/tail_bg.jpg">
                                            <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
