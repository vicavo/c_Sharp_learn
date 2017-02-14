<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_show.aspx.cs" Inherits="qpoa.HumanResources.Employee_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="Employee.aspx"  class="line_b">档案管理</a> >> 查看人事档案</td>
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
                                    <font class="shadow_but">档案管理</font></button></td>
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
                                    width="17%">
                                    真实姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                 
                                    <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                 
                                    <asp:Label ID="worknum" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Unit" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Respon" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Post" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    在岗状态：</td>
                                <td class="newtd2" height="17" width="35%">
                              
                                    <asp:Label ID="StardType" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    Email：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                   
                                    <asp:Label ID="Email" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    性别：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                  
                                    <asp:Label ID="Sex" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                           
                            
                           <tr class="" id="nextrs2">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    出生日期：</td>
                                <td class="newtd2" height="24" width="33%">
                               

                                    <asp:Label ID="Bothday" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    民族：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Nationality" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr  class="" id="nextrs3">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    身份证号：</td>
                                <td class="newtd2" height="17" width="33%">
                                   
                                    <asp:Label ID="IDnumber" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    婚姻状况：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Marriage" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                          
                              <tr  class="" id="nextrs4">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    政治面貌：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Politics" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    籍贯：</td>
                                <td class="newtd2" height="24" width="35%">
                                   
                                    <asp:Label ID="Nativeplace" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr  class="" id="nextrs5">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    户口所在地：</td>
                                <td class="newtd2" height="17" width="33%">
                                 
                                    <asp:Label ID="Permanents" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    学历：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Schoolrecord" runat="server" Width="90%"></asp:Label></td>
                            </tr>      
     
                              <tr  class="" id="nextrs6">
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    职称：</td>
                                <td class="newtd2" height="24" width="33%">
                                 
                                    <asp:Label ID="TitleRank" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    毕业院校：</td>
                                <td class="newtd2" height="24" width="35%">
                                  
                                    <asp:Label ID="School" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr  class="" id="nextrs7">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    专业：</td>
                                <td class="newtd2" height="17" width="33%">
                                
                                    <asp:Label ID="Specialized" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    参加工作时间：</td>
                                <td class="newtd2" height="17" width="35%">
                                  

                                    <asp:Label ID="Worktime" runat="server" Width="90%"></asp:Label></td>
                            </tr>   
     
                             <tr  class="" id="nextrs8">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    加入本单位时间：</td>
                                <td class="newtd2" height="17" width="33%">
                                                

                                    <asp:Label ID="Companytime" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    家庭电话：</td>
                                <td class="newtd2" height="17" width="35%">
                                 
                                    <asp:Label ID="Tel" runat="server" Width="90%"></asp:Label></td>
                            </tr>   
                            
                            
                            <tr  class="" id="nextrs9">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    家庭详细住址：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                 
                                    <asp:Label ID="Address" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                           
                                
                             <tr  class="" id="nextrs10">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    岗位变动情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                              
                                    <asp:Label ID="Postchange" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>   
     
                                 <tr  class="" id="nextrs11">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    教育背景：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                  
                                    <asp:Label ID="Educational" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>   
     
                            <tr  class="" id="nextrs12">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    工作简历：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                              
                                    <asp:Label ID="Wxperience" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>   
                             <tr  class="" id="nextrs13">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    社会关系：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                
                                    <asp:Label ID="Social" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>  
                              <tr  class="" id="nextrs14">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    奖惩记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                  
                                    <asp:Label ID="Rewards" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs15">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职务情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                 
                                    <asp:Label ID="Dutysituation" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                
                            
                            
                                <tr  class="" id="nextrs16">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    培训记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                 
                                    <asp:Label ID="Trains" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs17">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    担保记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                 
                                    <asp:Label ID="Guarantees" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                               
                            
                            
                           <tr  class="" id="nextrs18">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    劳动合同签订情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                               
                                    <asp:Label ID="Laborcontract" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs19">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    社保缴纳情况：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                
                                    <asp:Label ID="Society" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                     
                            
                            <tr  class="" id="nextrs20">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    体检记录：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                               
                                    <asp:Label ID="Physical" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>  
                             <tr  class="" id="nextrs21">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备 注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                
                                    <asp:Label ID="Remark1" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                            
                            
                             <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="richeng" runat="server" Width="90%"></asp:Label></td>
                          
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
<asp:TextBox ID="QxString" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="UnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ResponId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="PostId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="KeyQx" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
 
    
    
    </form>
</body>
</html>