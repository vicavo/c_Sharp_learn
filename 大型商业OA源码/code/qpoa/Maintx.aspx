<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintx.aspx.cs" Inherits="qpoa.Maintx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>网络办公系统</title>

    <LINK href="css/public.css" type="text/css" rel="stylesheet">
   
<LINK href="head/menu.css" type=text/css rel=stylesheet>
<SCRIPT language="javascript">


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
if (!confirm("是否确定要注销？"))
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
    //控件宽
    var aw = 400;
    //控件高
    var ah = 30;
    //计算控件水平位置
    var al = (screen.width - aw)/2;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    //内容管理
    var title = '';
    var icon = 'indi.gif';
    var cardID = '0';
    //输出提示框
    var div = document.createElement("div");
    div.id = "UploadChoose";
    div.innerHTML = '\
    <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:center">\
        <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
        <div style="padding-top:30px;">\
        <div style="float:left;width:60px;padding-left:50px"><img src="images/'+icon+'" alert"Cardo" /></div>\
       <div style="float:left;width:180px;margin-top:13px;padding-left:0px"><b>菜单加载中，请等待...</b></div>\
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

function sms_mon()
{

  //document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='images/menu/sms.gif'border=0 height=10> 短信</a><object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='0' height='0'><param name='movie' value='sound/<%=Sound %>'><param name=quality value=high><embed id='sms_sound' src='sound/<%=Sound%>' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";
  document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='images/menu/sms.gif'border=0 height=10><font color=#ffffff>新短消息</font></a><object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='0' height='0'><param name='movie' value='sound/<%=Sound %>'><param name=quality value=high><embed id='sms_sound' src='sound/<%=Sound%>' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";

}

function show_sms()
{
   mytop=screen.availHeight-240;
   myleft=0;
   window.open("sms_show.aspx","tixing","height=200,width=370,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
}


function gourl()
{
window.parent.rform.location.href='InfoSpeech/Messages.aspx';
}

function hfurl(suser_table,sname_table)
{
window.parent.rform.location.href='InfoSpeech/Messages_add.aspx?user='+suser_table+'&name='+sname_table+'';
}


function xianqing(str)
{
window.parent.rform.location.href=''+str+'';
}


</SCRIPT>   




<script>

function send_request(url)
{

  
    http_request=false;
    if(window.XMLHttpRequest)//Mozilla 浏览器
    {
	    http_request=new XMLHttpRequest();
	    if(http_request.overrideMimeType)//设置MiME类别
	    {
		    http_request.overrideMimeType("text/xml");
	    }
    }
    else if(window.ActiveXObject)// IE浏览器
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
    if(!http_request)// 异常，创建对象实例失败
    {
        content.innerHTML="不能创建XMLHttpRequest对象实例";
	    return false;
    }
    //指定服务器返回信息时处理程序
    http_request.onreadystatechange=processRequest;
    // 确定发送请求的方式和URL以及是否同步执行下段代码
    http_request.open("GET",url,true);
    http_request.send(null);
    
}



    function processRequest()
    {
     
        if(http_request.readyState==4)
        {				
            if(http_request.status==200)
            {			 		
                if(http_request.responseText=='1')
                {
	
                    if('<%=iftx%>'=='是')
                    {
                       show_sms();
                       sms_mon();
                       
                    }
                    else
                    {
                      document.getElementById("new_sms").innerHTML="";
                     
                    }

                }
                else
                {
                  document.getElementById("new_sms").innerHTML="";
                 
                }
            }
            else
            {

            }
        }

    }


    window.setInterval("send_request('main_tx_ajax.aspx?tmp='+Math.random())",<%=txtime%>);

</script>



</head>

<body background="images/tx.png">
<form id="form1" runat="server">
<span id="new_sms"></span><SCRIPT>send_request('main_tx_ajax.aspx?tmp='+Math.random());</SCRIPT>
    </form>
</body>
</html>
