<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_zj.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowName_show_add_node_zj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('NodeNum').value=='')
    {
    alert('步骤序号不能为空');
    form1.NodeNum.focus();
    return false;
    }	
   
    if(document.getElementById('NodeNum').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('NodeNum').value))
    {
    alert('步骤序号只能为数字');
    form1.NodeNum.focus();
    return false;
    }
    }


    if(document.getElementById('EndtimeSet').value=='')
    {
    alert('结束时间设置不能为空');
    form1.EndtimeSet.focus();
    return false;
    }	
   
    if(document.getElementById('EndtimeSet').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('EndtimeSet').value))
    {
    alert('结束时间设置只能为数字');
    form1.EndtimeSet.focus();
    return false;
    }
    }








    if(document.getElementById('NodeName').value=='')
    {
    alert('步骤名称不能为空');
    form1.NodeName.focus();
    return false;
    }	
    
    
    
    
    showwait();	
}  
				

</script>


<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <base target=_self />	
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    步骤序号：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="NodeNum" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    步骤名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="NodeName" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    步骤位置：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="NodeSite" runat="server" Width="90%">
                                        <asp:ListItem>开始</asp:ListItem>
                                        <asp:ListItem>中间段</asp:ListItem>
                                        <asp:ListItem>结束</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    下一步骤：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" style="width: 113px" valign="top">
                                                <strong>待选步骤</strong></td>
                                            <td align="center" style="width: 42px" valign="top">
                                            </td>
                                            <td align="center" style="width: 100px" valign="top">
                                                <strong>已选步骤</strong></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 113px" valign="top">
                                                <asp:ListBox ID="SourceListBox" runat="server" Height="171px" Width="157px"></asp:ListBox></td>
                                            <td align="center" style="width: 42px" valign="top">
                                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text=">" Width="58px" /><br />
                                                <br />
                                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                                <br />
                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                                <br />
                                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                            </td>
                                            <td align="center" style="width: 100px" valign="top">
                                                <asp:ListBox ID="TargetListBox" runat="server" Height="171px" Width="157px"></asp:ListBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    评审模式：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:DropDownList ID="SpModle" runat="server" Width="90%">
                                        <asp:ListItem>只要有一人通过审批即可向下流转</asp:ListItem>
                                        <asp:ListItem>只要全部人员通过审批即可向下流转</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批人员选择：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="SpChoice" runat="server" Width="90%">
                                       
                                        <asp:ListItem>审批时由当前用户从指定人员中选择人员</asp:ListItem>
                                        <asp:ListItem>审批时由当前用户指定人员</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>                           
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    结束时间设置：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    当前节点，<asp:TextBox ID="EndtimeSet" runat="server" Width="29px" ></asp:TextBox>小时未审批自动结束</td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    是否允许编辑文档附件：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                   <asp:DropDownList ID="AllowFile" runat="server" Width="90%">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:DropDownList>
                                   </td>
                            </tr>   
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    是否允许删除文档附件：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                   <asp:DropDownList ID="AllowDelFile" runat="server" Width="90%">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:DropDownList>
                                   </td>
                            </tr>                              
                                                    
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT></div> </td>
                            </tr>
                          
                        </table>
              <asp:TextBox ID="NodeNumber" runat="server" Visible="False"></asp:TextBox></td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table><asp:DropDownList ID="StopSp" runat="server" Width="90%" Visible="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
  </tr>
</table>
<asp:TextBox ID="FormId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormNumber" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormName" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowNumber" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowName" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="shangbu" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('QxUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("QxUsername").value=arr[0]; 
document.getElementById("QxRealname").value=arr[1]; 
}
}





</script> 
 
    
    
    </form>
</body>
</html>