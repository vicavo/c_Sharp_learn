<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookManageSearch_show.aspx.cs" Inherits="qpoa.PublicAffairs.BookManageSearch_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
  if(document.getElementById('Name').value=='')
    {
    alert('名称不能为空');
    form1.Name.focus();
    return false;
    }	



    showwait();					
}

var  wName3;  
function  OpenSaleData3()  
{  

var num=Math.random();
var str=document.getElementById("Type").value;
wName3=window.showModalDialog("../OpenWindows/open_Bookype.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("Type").value=wName3; 
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="BookManageSearch.aspx"  class="line_b">图书信息查询</a> >> 查看图书</td>
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
                                    <font class="shadow_but">图书管理</font></button></td>
                              <td style="height: 26px" align="right" > 
                                 <a href="javascript:void(0)"><img src="../images/button_print.jpg" border= 0 onclick="printpage()"/></a></td>
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
                                    图书名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    所属部门：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="UnitName" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    图书类别：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Type" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    图书作者：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Author" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    ISBN号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ISBN" runat="server" Width="90%"></asp:Label></td>
                            </tr>                           

                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    出版社：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Publisher" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    出版日期：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <script>SetNeed('PublisherDate')</script>

                                    <asp:Label ID="PublisherDate" runat="server" Width="90%"></asp:Label></td>
                            </tr> 


                               <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    存放地点：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Storage" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                   数量：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Number" runat="server" Width="90%"></asp:Label></td>
                            </tr>              
               
                                <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    价格：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Price" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    借阅状态：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Status" runat="server" Width="90%"></asp:Label></td>
                            </tr>             
               
               
                            

                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    借阅范围：</td>
                                <td class="newtd2" height="24" width="85%"  colspan=3>
                                    <asp:Label ID="LendingName" runat="server" Width="90%"></asp:Label></td>
                               
                            </tr>
                          
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    借阅人：</td>
                                <td class="newtd2" colspan="3" style="height: 17px">
                                    <asp:Label ID="Borrowers" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                       
                            <tr  class="" id="Tr1">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    内容简介：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Introduction" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>             
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                           
                            
                            
                            
  
                           
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <input id="Button1" class="button_blue" type="button" value="返 回"  onclick="history.back()"/></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="LendingID" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  


    


    
<script language="javascript">	



var  wName_2;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('LendingID').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_UnitName_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("LendingID").value=arr[0]; 
document.getElementById("LendingName").value=arr[1]; 
}
}


</script>    

    
    </form>
</body>
</html>