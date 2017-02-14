<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoSend_show.aspx.cs" Inherits="qpoa.InfoSpeech.InfoSend_show" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
if(document.getElementById('State').value=='正在传阅')
{
    alert('当前状态正在传阅，请先终止传阅');
    form1.State.focus();
    return false;
}

if(document.getElementById('Title').value=='')
{
alert('主题不能为空');
form1.Title.focus();
return false;
}	
showwait();					
}


function ZdOrQd()
{
    if(document.getElementById('State').value=='暂停传阅')
    {
        if (!confirm("确认重新启动传阅吗？重新启动，所有接收人将会重新阅读文件。"))
        return false;
    }	
    else
    {
        if (!confirm("确认暂停传阅吗？如果再重新启动，所有接收人将会重新阅读文件。"))
        return false;
    }
				
}



</script>

<script language="javascript">	
function  openuser1()  
{  
    if(document.getElementById('State').value=='正在传阅')
    {
        alert('当前状态正在传阅，请先暂停传阅');
        form1.State.focus();
        return false;
    }

    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("InfoSend_add_people.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>&nbsp; 查看文件传阅</td>
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
                                    <font class="shadow_but">传阅文件</font></button></td>
                              <td style="height: 26px" align="right" > 
                                  <a href="javascript:void(0)"></a></td>
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
                                    当前状态：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:Label ID="State" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    主题：</td>
                                <td class="newtd2" height="17" colspan="3" width="83%">
                                    <asp:Label ID="Title" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    内容：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="d_content" runat="server" Width="99%"></asp:Label></td>
                            </tr>  
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件列表：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                                    <asp:Label ID="richeng" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>   
                            
                                                    
                            <tr>
                                <td class="newtd2" colspan="4" height="17">
                                    <asp:CheckBox ID="C1" runat="server" Text="允许编辑WORD,EXCEL,PPT附件" Checked="True" Enabled="False" />
                                    &nbsp;
                                    <asp:CheckBox ID="C2" runat="server" Text="允许接收人额外新增接收人" Checked="True" Enabled="False" />&nbsp; &nbsp;<asp:CheckBox ID="C3" runat="server" Text="允许接收人转发传阅" Checked="True" Enabled="False" Visible="False" /></td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="17">
                                  <div id="Div1" class="mainDiv">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#4D77B1"
                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="QrRealname" HeaderText="姓名" SortExpression="QrRealname">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QrTime" HeaderText="确认时间" SortExpression="QrTime">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QrContent" HeaderText="确认意见" SortExpression="QrContent">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>

                                        </Columns>
                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                        <AlternatingRowStyle BackColor="#E6EDF7" />
                                        <EmptyDataTemplate>
                                            <div align="center">
                                                <font color="white">无相关数据！</font></div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button4" runat="server" CssClass="button_blue" OnClick="Button4_Click"
                                                Text="返 回" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="acceptusername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

<asp:TextBox ID="Number" runat="server"  style="DISPLAY: none"></asp:TextBox>


    </form>
</body>
</html>