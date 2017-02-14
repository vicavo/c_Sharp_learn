<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyUnitNotic_show.aspx.cs" Inherits="qpoa.MyAffairs.MyUnitNotic_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Title').value=='')
    {
    alert('标题不能为空');
    form1.Title.focus();
    return false;
    }	

    if(document.getElementById('IfShare').value=='公开给其他部门')
    {
    
        if(document.getElementById('GxUnitName').value==''||document.getElementById('GxUnitName').value=='未公开')
        {
        alert('请选择公开部门');
        form1.GxUnitName.focus();
        return false;
        }	
    
    }	

    showwait();					
}



</script>












<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <META http-equiv=Pragma content=no-cache>
<META http-equiv=Cache-Control content=no-cache>
<META http-equiv=Expires content=0>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
           </td>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 部门通知 >> <a href="MyUnitNotic.aspx"  class="line_b">部门通知浏览</a> >> 查看部门通知</td>
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
                                    <font class="shadow_but">部门通知</font></button></td>
                              <td style="height: 26px" align="right" >   <a href="javascript:void(0)"><img src="../images/button_print.jpg" border= 0 onclick="printpage()"/></a></td>
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
                            width="100%" id="tableprint">
                
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    标题：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Title" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    所属部门：</td>
                               <td class="newtd2" colspan="3" height="24">
                                   <asp:Label ID="UnitName" runat="server" Width="90%"></asp:Label></td>
                            </tr>
               
                                <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    是否共享：</td>
                                <td class="newtd2" height="24" colspan="3">
                                    <asp:Label ID="IfShare" runat="server" Width="90%"></asp:Label></td>
                            </tr>             
               
               
                            

                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 24px">
                                    公开范围：</td>
                                <td class="newtd2" width="85%"  colspan=3 style="height: 24px">
                                    <asp:Label ID="GxUnitName" runat="server" Width="90%"></asp:Label></td>
                               
                            </tr>
                       
                            <tr  class="" id="Tr1">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    内容：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                               <%=d_content %>
                                
                                
                                    </td>
                          
                            </tr>             
                            
                            
                            
  
                                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>         
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
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
<asp:TextBox ID="GxUnitNameId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  
<asp:TextBox ID="Number" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>

    


    
<script language="javascript">	

function  openuser1()  
{  
if(document.getElementById('IfShare').value=='只允许本部门查看')
{
alert('请选择公开给其他部门');
form1.IfShare.focus();
return false;
}	

var  wName_2;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('GxUnitNameId').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_UnitName_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("GxUnitNameId").value=arr[0]; 
document.getElementById("GxUnitName").value=arr[1]; 
}
}


</script>    

    
    </form>
</body>
</html>