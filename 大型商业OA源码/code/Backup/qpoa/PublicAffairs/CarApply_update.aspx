<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarApply_update.aspx.cs" Inherits="qpoa.PublicAffairs.CarApply_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
if(document.getElementById('CarNum').value=='')
{
alert('车牌号不能为空');
form1.CarNum.focus();
return false;
}	


	

if(document.getElementById('ManagerName').value=='')
{
alert('调度员不能为空');
form1.ManagerName.focus();
return false;
}	


if(document.getElementById('Starttime').value=='')
{
alert('开始时间不能为空');
form1.Starttime.focus();
return false;
}	

if(document.getElementById('Endtime').value=='')
{
alert('结束时间不能为空');
form1.Endtime.focus();
return false;
}	



return check_Date(document.getElementById('Starttime').value,document.getElementById('Endtime').value,"开始时间","结束时间")

showwait();					



}
function check_Date(date1,date2,date1Text,date2Text)
{
    var date1,date2,date1Text,date2Text;
    date1=date1.replace(/\-/g,"/");
    date2=date2.replace(/\-/g,"/");
    if(Date.parse(date1) > Date.parse(date2))
    {
        alert("错误！"+date1Text+"应在"+date2Text+"之前！")
        return false;
    }

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="CarApply.aspx"  class="line_b">车辆使用申请</a> >> 修改车辆使用</td>
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
                                    <font class="shadow_but">车辆申请</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    车牌号：</td>
                                <td class="newtd2" height="17"  width="35%">
                                     <asp:TextBox ID="CarNum" runat="server" Width="85%"></asp:TextBox> <A href="javascript:void(0)"><IMG onclick="Opencar()" src="../images/FDJ.gif" border="0"></A></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    司机：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:TextBox ID="Drivers" runat="server" Width="95%"></asp:TextBox></td>                           
                                    
                                    
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    用车人：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:TextBox ID="Carpeople" runat="server" Width="95%"></asp:TextBox></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    用车部门：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:DropDownList ID="UnitName" runat="server" Width="95%">
                                    </asp:DropDownList></td>                           
                                    
                                    
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Starttime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Starttime')</script>
                                      <A href="javascript:void(0)"><IMG id="Starttime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    目的地：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:TextBox ID="Destination" runat="server" Width="95%"></asp:TextBox></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    里程：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:TextBox ID="Miles" runat="server" Width="95%"></asp:TextBox></td>                           
                                    
                                    
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    调度员：</td>
                                <td class="newtd2"  width="35%" style="height: 17px">
                                    <asp:TextBox ID="ManagerName" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                                    
                                         <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    申请人：</td>
                                <td class="newtd2"  width="35%" style="height: 17px">
                                    <asp:TextBox ID="Realname" runat="server" Width="95%"></asp:TextBox></td>                           
                                    
                                    
                            </tr>





                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">事由：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="Subject" runat="server" Height="78px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>
   
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
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
      </table>
        <asp:TextBox ID="State" runat="server" Visible="False"></asp:TextBox></td>
  </tr>
</table>
<asp:TextBox ID="CarId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  
<script language="javascript">	


var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('ManagerUser').value+"|"+document.getElementById('ManagerName').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_car.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("ManagerUser").value=arr[0]; 
document.getElementById("ManagerName").value=arr[1]; 
}
}


var  wName_2;  
function  Opencar()  
{  
var num=Math.random();
var str=""+document.getElementById('CarId').value+"|"+document.getElementById('CarNum').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_CarInfo.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("CarId").value=arr[0]; 
document.getElementById("CarNum").value=arr[1]; 
}
}



</script>  
    </form>
</body>
</html>