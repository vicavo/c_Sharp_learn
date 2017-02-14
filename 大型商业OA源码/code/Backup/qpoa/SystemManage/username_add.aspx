<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="username_add.aspx.cs" Inherits="qpoa.SystemManage.username_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Username').value=='')
    {
    alert('用户名不能为空');
    form1.Username.focus();
    return false;
    }	

    if(document.getElementById('Password').value=='')
    {
    alert('用户密码不能为空');
    form1.Password.focus();
    return false;
    }	


    if(document.getElementById('Realname').value=='')
    {
    alert('用户姓名不能为空');
    form1.Realname.focus();
    return false;
    }


    if(document.getElementById('worknum').value=='')
    {
    alert('工号不能为空');
    form1.worknum.focus();
    return false;
    }

    if(document.getElementById('Unit').value=='')
    {
    alert('部门名称不能为空');
    form1.Unit.focus();
    return false;
    }


    if(document.getElementById('Respon').value=='')
    {
    alert('角色名称不能为空');
    form1.Respon.focus();
    return false;
    }

    if(document.getElementById('Post').value=='')
    {
    alert('职位不能为空');
    form1.Post.focus();
    return false;
    }

    if(document.getElementById('Email').value!='')
    {
    var objRe = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if(!objRe.test(document.getElementById('Email').value))
    {
    alert('Email格式不正确');
    form1.Email.focus();
    return false;
    }
    
    }  

    showwait();					
}
function shownextdiv()
{
    if(document.all.shownext.checked)  
    {
        document.getElementById('nextrs1').className="";
        document.getElementById('nextrs2').className="";
        document.getElementById('nextrs3').className="";
        document.getElementById('nextrs4').className="";
        document.getElementById('nextrs5').className="";
        document.getElementById('nextrs6').className="";
        document.getElementById('nextrs7').className="";
        document.getElementById('nextrs8').className="";
        document.getElementById('nextrs9').className="";
        document.getElementById('nextrs10').className="";
        document.getElementById('nextrs11').className="";
        document.getElementById('nextrs12').className="";
        document.getElementById('nextrs13').className="";
        document.getElementById('nextrs14').className="";
        document.getElementById('nextrs15').className="";
        document.getElementById('nextrs16').className="";
        document.getElementById('nextrs17').className="";
        document.getElementById('nextrs18').className="";
        document.getElementById('nextrs19').className="";
        document.getElementById('nextrs20').className="";
        document.getElementById('nextrs21').className="";
        document.getElementById('nextrs22').className="";
        document.getElementById('nextrs23').className="";

    }
    else
    {
        document.getElementById('nextrs1').className="tddisp";
        document.getElementById('nextrs2').className="tddisp";
        document.getElementById('nextrs3').className="tddisp";
        document.getElementById('nextrs4').className="tddisp";
        document.getElementById('nextrs5').className="tddisp";
        document.getElementById('nextrs6').className="tddisp";
        document.getElementById('nextrs7').className="tddisp";
        document.getElementById('nextrs8').className="tddisp";
        document.getElementById('nextrs9').className="tddisp";
        document.getElementById('nextrs10').className="tddisp";
        document.getElementById('nextrs11').className="tddisp";
        document.getElementById('nextrs12').className="tddisp";
        document.getElementById('nextrs13').className="tddisp";
        document.getElementById('nextrs14').className="tddisp";
        document.getElementById('nextrs15').className="tddisp";
        document.getElementById('nextrs16').className="tddisp";
        document.getElementById('nextrs17').className="tddisp";
        document.getElementById('nextrs18').className="tddisp";
        document.getElementById('nextrs19').className="tddisp";
        document.getElementById('nextrs20').className="tddisp";
        document.getElementById('nextrs21').className="tddisp";
        document.getElementById('nextrs22').className="tddisp";
        document.getElementById('nextrs23').className="tddisp";  

    }

}  



</script>


<%--<SCRIPT language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();


if (nameLen>0)
{
var aaaaaa="<%=fjkey%>" ;
if(aaaaaa.indexOf(rightName)== -1 )
{

alert("提示:\r不支持此格式的文件！请区分文件扩展名大小写\r只能上传<%=fjkey%>");
return(false);
uploadFile.focus;

}//不包括
showwait();	
}


}
</SCRIPT>--%>



<SCRIPT language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();



//var objRe = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(<%=fjkey%>)$/;
//if(!objRe.test(document.getElementById('uploadFile').value))
//{
//alert("提示:\r不支持此格式的文件！请区分文件扩展名大小写\r只能上传<%=fjkey%>");
//form1.uploadFile.focus();
//return false;
//}

var sAllowExt = "<%=fjkey%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	return false;
}
showwait();	



}
</SCRIPT>







<script>

function  down()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');

return false;
}
else
{

var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.open ("username_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


}

function  delfj()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');

return false;
}
else
{
if (!confirm("是否确定要删除？"))
return false;

showwait();	
var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.showModalDialog("username_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                
}


}			



</script>



<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" onload="shownextdiv()">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
           <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="username.aspx"  class="line_b">用户管理</a> >> 新增用户信息</td>
                      <td width="81%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                    <tr> 
                      <td></td>
                    </tr>
                  </table></td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
             </div>
            </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
           <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">用户信息</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 用户信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    用户名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Username" runat="server" Width="90%" ></asp:TextBox>
                                </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    密码：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Password" runat="server" Width="90%" TextMode="Password"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    真实姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Realname" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="worknum" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    手机号：</td>
                               <td class="newtd2" colspan="3" height="17">
                                    <asp:TextBox ID="ShouJi" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>                           
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="Unit" runat="server" Width="80%" title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openunit();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Respon" runat="server" Width="80%"  title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openrespon();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Post" runat="server" Width="80%"  title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openpost();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    在岗状态：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="StardType" runat="server" Width="90%">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    Email：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Email" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    是否允许登陆：</td>
                                <td class="newtd2" width="35%" style="height: 17px"><asp:DropDownList ID="Iflogin" runat="server" Width="90%">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                    性别：</td>
                                <td class="newtd2" style="height: 17px" width="33%">
                                    <asp:DropDownList ID="Sex" runat="server" Width="90%">
                                        <asp:ListItem>男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="15%">
                                    保存为人事信息：</td>
                                <td class="newtd2" style="height: 17px" width="35%">
                                    <asp:RadioButton ID="shownext" runat="server" GroupName="1" Checked="True" Text="是" />
                           
                                    <asp:RadioButton ID="shownext1" runat="server" GroupName="1" Text="否" /></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Remark" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>
                       
                               
                          
                                     
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>人事信息</strong>
                               
							            </div> </td>
                            </tr>
                           
                            
                           <tr class="" id="nextrs2">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    出生日期：</td>
                                <td class="newtd2" height="24" width="33%">
                                <script>SetNeed('Bothday')</script>
                                    <asp:TextBox ID="Bothday" runat="server" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG id="Bothday_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    民族：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Nationality" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr  class="" id="nextrs3">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    身份证号：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="IDnumber" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    婚姻状况：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="Marriage" runat="server" Width="90%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>未婚</asp:ListItem>
                                    <asp:ListItem>已婚</asp:ListItem>
                                    <asp:ListItem>离异</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                          
                              <tr  class="" id="nextrs4">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    政治面貌：</td>
                                <td class="newtd2" height="24" width="33%"><asp:DropDownList ID="Politics" runat="server" Width="90%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>群众</asp:ListItem>
                                    <asp:ListItem>团员</asp:ListItem>
                                    <asp:ListItem>预备党员</asp:ListItem>
                                    <asp:ListItem>党员</asp:ListItem>
                                </asp:DropDownList></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    籍贯：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Nativeplace" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr  class="" id="nextrs5">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    户口所在地：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Permanents" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    学历：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="Schoolrecord" runat="server" Width="90%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>小学</asp:ListItem>
                                    <asp:ListItem>初中</asp:ListItem>
                                    <asp:ListItem>高中</asp:ListItem>
                                    <asp:ListItem>中专</asp:ListItem>
                                    <asp:ListItem>大专</asp:ListItem>
                                    <asp:ListItem>大本</asp:ListItem>
                                    <asp:ListItem>硕士</asp:ListItem>
                                    <asp:ListItem>博士</asp:ListItem>
                                    <asp:ListItem>博士后</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>      
     
                              <tr  class="" id="nextrs6">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    职称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="TitleRank" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    毕业院校：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="School" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr  class="" id="nextrs7">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    专业：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Specialized" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    参加工作时间：</td>
                                <td class="newtd2" height="17" width="35%">
                                      <script>SetNeed('Worktime')</script>
                                    <asp:TextBox ID="Worktime" runat="server" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG id="Worktime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                    
                                    
                                    </td>
                            </tr>   
     
                             <tr  class="" id="nextrs8">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    加入本单位时间：</td>
                                <td class="newtd2" height="17" width="33%">
                                                      <script>SetNeed('Companytime')</script>
                                    <asp:TextBox ID="Companytime" runat="server" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG id="Companytime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                    
                                    
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    家庭电话：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Tel" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>   
                            
                            
                            <tr  class="" id="nextrs9">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    家庭详细住址：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Address" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>                           
                                
                             <tr  class="" id="nextrs10">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    岗位变动情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Postchange" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>   
     
                                 <tr  class="" id="nextrs11">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    教育背景：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Educational" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>   
     
                            <tr  class="" id="nextrs12">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    工作简历：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Wxperience" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>   
                             <tr  class="" id="nextrs13">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    社会关系：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Social" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>  
                              <tr  class="" id="nextrs14">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    奖惩记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Rewards" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs15">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职务情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Dutysituation" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>                
                            
                            
                                <tr  class="" id="nextrs16">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    培训记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Trains" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs17">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    担保记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Guarantees" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>                               
                            
                            
                           <tr  class="" id="nextrs18">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    劳动合同签订情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Laborcontract" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs19">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    社保缴纳情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Society" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>                     
                            
                            <tr  class="" id="nextrs20">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    体检记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Physical" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs21">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备 注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark1" runat="server" TextMode="MultiLine" Width="95%" Height="40px"></asp:TextBox></td>
                          
                            </tr>                            
                            
                             <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="72%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 501px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
                            </tr>  
  
                                   
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
								</FONT>
							</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="QxString" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="UnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ResponId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="PostId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="KeyQx" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
    
<script language="javascript">	


var  wName_1;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('UnitId').value+"|"+document.getElementById('Unit').value+"|"+document.getElementById('QxString').value+"|"+document.getElementById('KeyQx').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_UnitName.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("UnitId").value=arr[0]; 
document.getElementById("Unit").value=arr[1]; 
document.getElementById("QxString").value=arr[2]; 
document.getElementById("KeyQx").value=arr[3]; 
}
}



var  wName_2;  
function  openpost()  
{  
var num=Math.random();
var str=""+document.getElementById('PostId').value+"|"+document.getElementById('Post').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_PostName.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("PostId").value=arr[0]; 
document.getElementById("Post").value=arr[1]; 
}
}



var  wName_3;  
function  openrespon()  
{  
var num=Math.random();
var str=""+document.getElementById('ResponId').value+"|"+document.getElementById('Respon').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Respon.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("ResponId").value=arr[0]; 
document.getElementById("Respon").value=arr[1]; 
}
}

</script>  
    
    
    </form>
</body>
</html>