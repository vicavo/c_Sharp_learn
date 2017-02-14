<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmSearch.aspx.cs" Inherits="qpoa.KmManage.KmSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
        <script>
function chknull()
{
    if(document.getElementById('Title').value=='')
    {
    alert('搜索内容不能为空');
    form1.Title.focus();
    return false;
    }	
  showwait();					
}

function showfrom(str)
{
var num=Math.random();
window.open ("KmShow.aspx?tmp="+num+"&id="+str+"", "_blank", "height=700, width=900,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=80,left=60")
}       
        </script> 
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
<!--#include file="../public/pleasewait.htm"-->
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35" align="center">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top" align="left"> 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom" align="left"><a href="../main_d.aspx" class="line_b">工作台</a> >> 知识搜索</td>
                      <td width="16%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                    <tr> 
                      <td></td>
                    </tr>
                  </table>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td >
                            
                            </td>
                        </tr>
                        <tr>
                            <td align=center style="height: 23px">
                                <asp:TextBox ID="Title" runat="server" Width="354px"></asp:TextBox>
                             
                                <asp:Button ID="Button1" runat="server" Text="快速搜索" OnClick="Button1_Click" /></td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 23px">
                                <asp:RadioButtonList ID="RadioList" runat="server" RepeatDirection="Horizontal" Width="508px">
                                    <asp:ListItem Value="1" Selected="True">知识标题</asp:ListItem>
                                    <asp:ListItem Value="2">知识描述</asp:ListItem>
                                    <asp:ListItem Value="3">作者</asp:ListItem>
                                    <asp:ListItem Value="4">关键字</asp:ListItem>
                                    <asp:ListItem Value="5">综合搜索</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 23px">
                                搜索条件：<font color=red><%=KeyStr%></font>&nbsp;&nbsp;&nbsp;搜索内容：<font color=red><%=TitleStr%></font></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#404040" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="0" CellSpacing="1" GridLines="None" 
                               
                                 PageSize="6" Style="font-size: 12px" Width="100%" ShowHeader="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" >
                                <FooterStyle BackColor="White" ForeColor="Black" />
                                <Columns>
                        
                                    <asp:TemplateField >
                                        <HeaderStyle ForeColor="white" Wrap="False" />
                                        <ItemTemplate>

<table width="100%" height="63" border="0" cellpadding="4" cellspacing="0">
 
  <tr>
    <td bgcolor="#FFFFFF"> <%# (Container.DataItemIndex+1).ToString()%>.<font color=#0000FF size=1> <a href="javascript:void(0)" onclick="showfrom(<%# DataBinder.Eval(Container.DataItem, "id") %>);"><font color=#0000FF size=1><%#DataBinder.Eval(Container.DataItem, "Title")%></font></a> &nbsp;&nbsp;/&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "Realname")%>&nbsp;&nbsp;/&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "LittleName")%></font></td>
  </tr>
  <tr> 
    <td height="1px" class="newtd1"></td>
  </tr>
  
  <tr> 
  <td bgcolor="#FFFFFF">
   
   <font color=#000000><%#DataBinder.Eval(Container.DataItem, "Content")%></font>
    </td>
  </tr>
 
  <tr> 
  <td bgcolor="#FFFFFF">
   
   <font color=#000000>最后更新时间：<%#DataBinder.Eval(Container.DataItem, "LastTime")%> －关键字：<%#DataBinder.Eval(Container.DataItem, "KeyWord")%></font>
    </td>
  </tr>

</table>
             </ItemTemplate>
                                        <ItemStyle Wrap="False"  />
                                    </asp:TemplateField>   
                                    
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <SelectedRowStyle Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="Transparent" HorizontalAlign="Right" BackColor="White" />
                                <HeaderStyle Font-Bold="True" Wrap="False" />
                                     <EmptyDataTemplate>
                                    <div align=center><font color=white>无相关数据！</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                    
                </td>
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
            
              <div id="printshow3">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            &nbsp;</div>
                            </td>
							</tr>
						</table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
	<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    </form>
</body>
</html>
