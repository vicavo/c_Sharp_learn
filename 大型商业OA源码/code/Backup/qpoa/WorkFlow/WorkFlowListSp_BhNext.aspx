<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowListSp_BhNext.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowListSp_BhNext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('FormName').value=='')
    {
    alert('没有找到下一步骤');
    form1.FormName.focus();
    return false;
    }	


    if(document.getElementById('FormName').value!='0')
    {    
        if(document.getElementById('JBRObjectName').value=='')
        {
            alert('审批人员不能为空');
            form1.JBRObjectName.focus();
            return false;
        }	
    }

    showwait();					
}

function MM_jumpMenu(targ,selObj,restore)
{
   document.getElementById('JBRObjectName').value='';
   document.getElementById('JBRObjectId').value='';
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
           
          <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%" style="height: 24px"><img src="../images/top_3.gif" ></td>
                       <td width="70%" valign="bottom" style="height: 24px"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="WorkFlowList.aspx"  class="line_b">待办工作</a> >> 办理待办工作</td>
                      <td align="right" style="height: 24px" >&nbsp;<input id="Button6" type="button" value="流程图" onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'/>
                          </td>
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
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                
  <tr>
                                <td class="newtd2" colspan="4" height="17">
                                    流水号：<%=Sequence %> － <%=Name%> － 当前步骤：<%=NodeName%></td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    选择下一步骤：</td>
                               <td class="newtd2" colspan="3" height="24"  width="85%" >
                                    <asp:DropDownList ID="FormName" runat="server" Width="95%" AutoPostBack="True" onchange="MM_jumpMenu()">
                                    </asp:DropDownList>
                                   <asp:Label ID="Label5" runat="server" Visible="False" Width="100%"></asp:Label></td>
                            </tr>
                                 <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                          
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    经办人：</td>
                                <td class="newtd2" colspan="3" height="24"><asp:TextBox ID="szJBRObjectName" runat="server" Width="80%" Height="34px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                            </tr>    
                            
                       
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 24px">
                                    经办部门：</td>
                                <td class="newtd2" width="85%"  colspan=3 style="height: 24px">
                                    <asp:TextBox ID="JBBMObjectName" runat="server" Height="34px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label2" runat="server"></asp:Label></td>
                               
                            </tr>                          
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 24px">
                                    经办角色：</td>
                                <td class="newtd2" width="85%"  colspan=3 style="height: 24px">
                                    <asp:TextBox ID="JBJSObjectName" runat="server" Height="34px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server"></asp:Label></td>
                               
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 24px"
                                    width="15%">
                                    审批接收人员：</td>
                                <td class="newtd2" colspan="3" style="height: 24px" width="85%">
                                    <asp:TextBox ID="JBRObjectName" runat="server" Height="34px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server"></asp:Label></td>
                            </tr>
                              </asp:Panel>
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="驳回" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp;<input id="Button2" class="button_blue" onclick="history.back()"
                                                type="button" value="返回" size="" />
                                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</FONT></div> </td>
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
<asp:TextBox ID="JBRObjectId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>


  <asp:TextBox ID="szJBRObjectId" runat="server" style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="JBBMObjectId" runat="server"  style="DISPLAY: none"></asp:TextBox>
      <asp:TextBox ID="JBJSObjectId" runat="server"  style="DISPLAY: none"></asp:TextBox>
   
<script language="javascript">	
var  wName_2;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('JBBMObjectId').value+"";
var str1=""+document.getElementById('JBRObjectId').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_AddWorkFlowUser_Unit.aspx?tmp="+num+"&requeststr="+str+"&usernamestr="+str1+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JBRObjectId").value=arr[0]; 
document.getElementById("JBRObjectName").value=arr[1]; 
}

}



var  wName_1;  
function  openRespon()  
{  
var num=Math.random();
var str=""+document.getElementById('JBJSObjectId').value+"";
var str1=""+document.getElementById('JBRObjectId').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_AddWorkFlowUser_Respon.aspx?tmp="+num+"&requeststr="+str+"&usernamestr="+str1+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JBRObjectId").value=arr[0]; 
document.getElementById("JBRObjectName").value=arr[1]; 
}
}


var  wName_3;  
function  openUser()  
{  
var num=Math.random();
var str=""+document.getElementById('szJBRObjectId').value+"";
var str1=""+document.getElementById('JBRObjectId').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_AddWorkFlowUser_User.aspx?tmp="+num+"&requeststr="+str+"&usernamestr="+str1+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JBRObjectId").value=arr[0]; 
document.getElementById("JBRObjectName").value=arr[1]; 
}
}


var  wName_4;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('JBRObjectId').value+"";
wName_4=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_4.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JBRObjectId").value=arr[0]; 
document.getElementById("JBRObjectName").value=arr[1]; 
}
}




</script>    

    
    </form>
</body>
</html>