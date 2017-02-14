<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeThing_update.aspx.cs" Inherits="qpoa.PublicAffairs.OfficeThing_update" %>
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

    if(document.getElementById('Limits').value=='')
    {
    alert('库警参数不能为空，没有请填为０');
    form1.Limits.focus();
    return false;
    }	
 
    if(document.getElementById('Inventory').value=='')
    {
    alert('当前库存不能为空，没有请填为０');
    form1.Inventory.focus();
    return false;
    }
   
    if(document.getElementById('Limits').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('Limits').value))
    {
    alert("提示:\r库警参数只能为正数");
    form1.Limits.focus();
    return false;
    }

    }      
   
    
    if(document.getElementById('Inventory').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('Inventory').value))
    {
    alert("提示:\r当前库存只能为正数");
    form1.Inventory.focus();
    return false;
    }

    }   
    
    	   
    showwait();	
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >>  办公用品管理  >>  <a href=OfficeThing.aspx class="line_b">办公用品管理</a>  >>  新增办公用品</td>
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
                                    <font class="shadow_but">办公用品</font></button></td>
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
                                    办公用品名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">办公用品描述：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:TextBox ID="Content" runat="server" Height="76px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">计量单位： 
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:TextBox ID="Measurement" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                               <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">供应商： 
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:TextBox ID="CompanyName" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">库警参数： 
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Limits" runat="server" Width="90%">0</asp:TextBox></td>
                                  <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">当前库存： 
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Inventory" runat="server" Width="90%">0</asp:TextBox></td>    
                                 
                                 
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
</table>

    
    
    </form>
</body>
</html>