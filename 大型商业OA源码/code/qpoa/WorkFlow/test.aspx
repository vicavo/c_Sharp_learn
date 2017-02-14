<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="qpoa.WorkFlow.test"  validateRequest="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
 // alert(document.getElementById('FormContent').value);
 
var dd = document.getElementById("printshow2").innerHTML

alert(dd);
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
    <input id="Button1" type="button" value="button" onclick="chknull();"/>
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
            <div id="printshow2"> sadasdas
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" style="width: 918px" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1" style="width: 86%">
                
                           
               
                                <tr>
                                <td class="newtd2" >
                                    <asp:Label ID="FormContent" runat="server" Width="90%"></asp:Label>
                                    
                                    <div id="strhtm"><%=ddstr %></div>
                                    
                                    </td>
                            </tr>             
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <input id="Button3" class="button_blue" type="button"
                                                value="关 闭" />
                             
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
<asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
<asp:TextBox ID="ContractContent" runat="server" Height="14px" TextMode="MultiLine" Width="305px"  ></asp:TextBox>

<SCRIPT>


function Load_Do()
{

setTimeout("Load_Do()",0);
//var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value; 

var content = document.getElementById("strhtm").innerHTML


//var  content=document.getElementById("FormContent").value; 
document.getElementById("ContractContent").value=content;  
}


</SCRIPT>  

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="动态框值" />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    </form>
</body>
</html>