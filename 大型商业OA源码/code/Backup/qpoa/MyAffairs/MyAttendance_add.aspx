<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttendance_add.aspx.cs" Inherits="qpoa.MyAffairs.MyAttendance_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Subject').value=='')
    {
    alert('事由不能为空');
    form1.Subject.focus();
    return false;
    }	

    if(document.getElementById('StartTime').value=='')
    {
    alert('开始时间不能为空');
    form1.StartTime.focus();
    return false;
    }	
    
    
    if(document.getElementById('EndTime').value=='')
    {
    alert('结束不能为空');
    form1.EndTime.focus();
    return false;
    }	



    if(document.getElementById('DiffTime').value=='')
    {
    alert('<%=DiffTimeName %>不能为空');
    form1.DiffTime.focus();
    return false;
    }	
   
    if(document.getElementById('DiffTime').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('DiffTime').value))
    {
    alert('<%=DiffTimeName %>只能为数字');
    form1.DiffTime.focus();
    return false;
    }
    }
    
    
    showwait();	
}  
				

</script>

<script  language="JavaScript">

    function  btnCount_Click(){  
       var bDate=  document.getElementById('StartTime').value;  
       var eDate=  document.getElementById('EndTime').value; 
       var tDiff=  document.getElementById('TDiffTime').value;   
       //alert(DateDiff(bDate,eDate,tDiff))  
       document.getElementById('DiffTime').value=DateDiff(bDate,eDate,tDiff);
       
   }  
   //计算天数的函数

   function  DateDiff(beginDate,  endDate,textDiff){    //beginDate和endDate都是2007-8-10格式

       var  arrbeginDate,  Date1,  Date2, arrendDate,  iDays  
       arrbeginDate=  beginDate.split("-")  
       Date1=  new  Date(arrbeginDate[1]  +  '-'  +  arrbeginDate[2]  +  '-'  +  arrbeginDate[0])    //转换为2007-8-10格式

      arrendDate=  endDate.split("-")  
       Date2=  new  Date(arrendDate[1]  +  '-'  +  arrendDate[2]  +  '-'  +  arrendDate[0])  
       iDays  =  parseInt(Math.abs(Date1-  Date2)  /  1000  /  60  /  60  /24)    //转换为天数 
       iHours  =  parseInt(Math.abs(Date1-  Date2)  /  1000  /  60  /  60 )    //转换为小时数 

       if(textDiff!='加班小时')
       {
       return  iDays 
       }
       else
       {
       return  iHours
       }
   }
   

</script>
<head id="Head1" runat="server">
    <title>网络办公系统</title>
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >>  个人考勤  >>  <a href=MyAttendance.aspx?type=<%=Request.QueryString["Type"]%> class="line_b"><%=Typename %></a>  >>  新增<%=Typename %></td>
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
                                <button class="btn4off6k" 
                                    type="button">
                                    <font class="shadow_but"><%=Typename%></font></button></td>
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
                                    事由：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Subject" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    开始时间：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                     <asp:TextBox ID="StartTime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('StartTime')</script>
                                      <A href="javascript:void(0)"><IMG id="StartTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A> 
																		</td>
                                  <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                      结束时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                     <asp:TextBox ID="EndTime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('EndTime')</script>
                                      <A href="javascript:void(0)" ><IMG id="EndTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
																		
																		 </td>    
                                 
                                 
                            </tr>
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    <%=DiffTimeName %>：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                     <asp:TextBox ID="DiffTime" runat="server" Width="80%" onclick="btnCount_Click()"></asp:TextBox>
                                  
																		</td>
                                  <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                      登记人：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Realname" runat="server" Width="80%" ></asp:TextBox>
																		
								 </td>    
                                 
                                 
                            </tr>   
                            
                            
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">备注： 
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:TextBox ID="Remark" runat="server" Height="81px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
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
</table>     <asp:TextBox ID="TDiffTime" runat="server"  style="DISPLAY: none"></asp:TextBox>
    </form>
</body>
</html>