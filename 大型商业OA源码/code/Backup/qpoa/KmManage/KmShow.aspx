<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmShow.aspx.cs" Inherits="qpoa.KmManage.KmShow" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Title').value=='')
    {
    alert('评论内容不能为空');
    form1.Title.focus();
    return false;
    }	
					
}



</script>


<head id="Head1" runat="server">
    <title>办公自动化</title>
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
            <td>&nbsp; </td>
            
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">&nbsp;
                        </td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                      <tr align="center" valign="bottom"> 
                        <td colspan="4" nowrap="nowrap" class="newtd2"  style="height: 17px"><strong><font size="2"><%=ShowTitle%></font></strong> 
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;作者：<%=Realname%></td>
                      </tr>
                      <tr> 
                        <td width="22%" align="center" valign="top" nowrap="nowrap" class="newtd2" > 
                          <table width="99%" height="182" border="0" cellpadding="0" cellspacing="1" class="newtable">
                            <tr> 
                              <td height="22px" align="center" bgcolor="#666666"><strong><font color="#FFFFFF">作者有话</font></strong></td>
                            </tr>
                            <tr> 
                              <td height="160px" align="left" valign="top" bgcolor="#FFFFFF"style="line-height:160%"><%=AthourSay %></td>
                            </tr>
                          </table>
                          
                        </td>
                        <td width="78%" colspan="3" valign="top" class="newtd2" ><table width="99%" border="0" cellspacing="0" cellpadding="4">
                            <tr> 
                              <td><strong>类别：</strong><%=LittleName%> &nbsp;&nbsp;&nbsp;<strong>总点击：</strong><%=PointNum%>   &nbsp;&nbsp;&nbsp;<strong>总推荐：</strong><%=TjNum%> &nbsp;&nbsp;&nbsp;<strong>总订阅：</strong><%=DyNum%> &nbsp;&nbsp;&nbsp;<strong>总收藏：</strong><%=ScNum%>&nbsp;&nbsp;&nbsp; <strong>最后更新：</strong><%=LastTime%>
                              </td>
                            </tr>
                            <tr> 
                              <td height="15"></td>
                            </tr>
                            <tr> 
                              <td style="line-height:180%"><%=Content%></td>
                            </tr>
                             <tr> 
                              <td>关键字：<%=KeyWord%></td>
                            </tr>
                            <tr>
                              <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="进入章节" Width="120px" OnClick="Button1_Click" />
                                  <asp:Button ID="Button2" runat="server" Text="推荐知识" Width="120px" OnClick="Button2_Click" />
                                  <asp:Button ID="Button4" runat="server" Text="订阅知识" Width="120px" OnClick="Button4_Click" />
                                  <asp:Button ID="Button5" runat="server" Text="收藏知识" Width="120px" OnClick="Button5_Click" />
                                  <asp:Button ID="Button6" runat="server" Text="禁止" Width="65px" OnClick="Button6_Click" />
                                  <asp:Button ID="Button7" runat="server" Text="推荐" Width="67px" OnClick="Button7_Click" /></td>
                            </tr>
                          </table> </td>
                      </tr>
                      <tr  id="printshow3"> 
                        <td  class="newtd2"  colspan="4" height="26"> 
                          <div >
                          
   <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#404040" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="0" CellSpacing="1" GridLines="None" 
                               
                                 PageSize="6" Style="font-size: 12px" Width="100%" ShowHeader="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" >
                                <FooterStyle BackColor="White" ForeColor="Black" />
                                <Columns>
                        
                                    <asp:TemplateField >
                                        <HeaderStyle ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
  <asp:Label ID="Lid2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
<table width="100%" height="63" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgcolor="#FFFFFF"><font color=#666666>评论人:<%#DataBinder.Eval(Container.DataItem, "Realname")%>(<%#DataBinder.Eval(Container.DataItem, "UnitName")%>)&nbsp;&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "Settime")%></font></td>
  </tr>
  <tr> 
    <td height="1px" class="newtd1"></td>
  </tr>
  <tr> 
    <td bgcolor="#FFFFFF">
   <font color=black><b><%#DataBinder.Eval(Container.DataItem, "Title")%></b></font>
    </td>
  </tr>
<tr> 
<td bgcolor="#FFFFFF" align=right>
    <asp:Label ID="Label2" runat="server" ></asp:Label>
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
                                    <div align=center><font color=white>知识评论无相关数据！</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>                         
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          
                          </div></td>
                      </tr>
                    </table>
                        <asp:TextBox ID="Title" runat="server" Width="759px"></asp:TextBox>
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="提交评论" /></td>
                    <td width="17" >&nbsp;
                        </td>
                </tr>
            </table>
          </td>
        </tr>
      </table>
 </td>
  </tr>
</table>

<asp:TextBox ID="Number" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
 

    
    </form>
</body>
</html>