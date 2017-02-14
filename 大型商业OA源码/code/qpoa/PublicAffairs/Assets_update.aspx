<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assets_update.aspx.cs" Inherits="qpoa.PublicAffairs.Assets_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Number').value=='')
    {
    alert('资产编号不能为空');
    form1.Number.focus();
    return false;
    }	


    if(document.getElementById('Name').value=='')
    {
    alert('资产名称不能为空');
    form1.Name.focus();
    return false;
    }	

    if(document.getElementById('DepType').value=='')
    {
    alert('折旧类型不能为空');
    form1.DepType.focus();
    return false;
    }	
    
    
    if(document.getElementById('DepStartDate').value=='')
    {
    alert('开始折旧日期不能为空');
    form1.DepStartDate.focus();
    return false;
    }	   







    if(document.getElementById('ActualMoney').value=='')
    {
    alert('资产原值不能为空，没有请填为０');
    form1.ActualMoney.focus();
    return false;
    }	
 
    if(document.getElementById('MinMoney').value=='')
    {
    alert('资产最低值不能为空，没有请填为０');
    form1.MinMoney.focus();
    return false;
    }
   
    if(document.getElementById('ActualMoney').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('ActualMoney').value))
    {
    alert("资产原值只能为正数");
    form1.ActualMoney.focus();
    return false;
    }

    }      
   
    
    if(document.getElementById('MinMoney').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('MinMoney').value))
    {
    alert("资产最低值只能为正数");
    form1.MinMoney.focus();
    return false;
    }

    }   





    showwait();					
}

var  wName;  
function  OpenSaleData()  
{  
var num=Math.random();
var str=document.getElementById('AssetType').value;
wName=window.showModalDialog("../OpenWindows/open_PlanCycle.aspx?tmp="+num+"&requeststr="+str+"&type=4","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName!=null && wName!= "undefined")
{
document.getElementById("AssetType").value=wName; 
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="Assets.aspx"  class="line_b">固定资产</a> >> 修改固定资产</td>
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
                                    <font class="shadow_but">固定资产</font></button></td>
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
                                    <b> 基本信息</b></td>
                            </tr>
         
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    资产编号：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Number" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    资产名称：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    规格型号：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="AssetModel" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    资产类别：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="AssetType" runat="server" Width="85%"></asp:TextBox>  <A href="javascript:void(0)"><IMG onclick="OpenSaleData()" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    制造厂商：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="MadeCompany" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    出厂日期：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                   <asp:TextBox ID="MadeTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('MadeTime')</script>
                                      <A href="javascript:void(0)"><IMG id="MadeTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    置办日期：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                   <asp:TextBox ID="SetTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('SetTime')</script>
                                      <A href="javascript:void(0)"><IMG id="SetTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                
                                
                                    </td>
                            </tr>
           
                              
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>折旧信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    折旧类型：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="DepType" runat="server" Width="85%"></asp:TextBox> <A href="javascript:void(0)"><IMG onclick="opentype()" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    折旧率：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="DepRate" runat="server" Width="90%"></asp:TextBox>
                                    %</td>
                            </tr>                       
                                
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    折旧周期：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="DepCycle" runat="server" Width="90%"></asp:TextBox>
                                    天</td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    开始折旧日期：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="DepStartDate" runat="server" Width="95%" ></asp:TextBox>
                                    <script>SetNeed('DepStartDate')</script>
                                
                                    </td>
                            </tr>  
  
                              <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    资产原值：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="ActualMoney" runat="server" Width="90%">0</asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    资产最低值：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="MinMoney" runat="server" Width="90%">0</asp:TextBox></td>
                            </tr>                               
                      
  
  
                           <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>其他信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    所属部门：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:DropDownList ID="UnitName" runat="server" Width="95%">
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    保管人：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="BgRealname" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>                       
                                
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    备注：</td>
                                <td class="newtd2" width="33%" style="height: 17px" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                        
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

<asp:TextBox ID="DepTypeID" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>


<script language="javascript">	



var  wName_2;  
function  opentype()  
{  
var num=Math.random();
var str=""+document.getElementById('DepTypeID').value+"|"+document.getElementById('DepType').value+"|"+document.getElementById('DepRate').value+"|"+document.getElementById('DepCycle').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_AssetsDepType.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("DepTypeID").value=arr[0]; 
document.getElementById("DepType").value=arr[1]; 
document.getElementById("DepRate").value=arr[2]; 
document.getElementById("DepCycle").value=arr[3]; 

}
}


</script>  
    
    
    </form>
</body>
</html>