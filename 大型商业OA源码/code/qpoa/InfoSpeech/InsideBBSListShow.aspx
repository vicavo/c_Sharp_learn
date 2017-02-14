<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsideBBSListShow.aspx.cs" Inherits="qpoa.InfoSpeech.InsideBBSListShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>
   function UploadComplete()
    {

            showCover();
            //控件宽
            var aw = 500;
            //控件高
            var ah = 270;
            //计算控件水平位置
            var al = (screen.width - aw)/2;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            //内容管理
            var title = '讨论区查询';
            var icon = 'smile';
            var cardID = '0';
            //输出提示框
            var div = document.createElement("div");
            div.id = "UploadChoose";
            div.innerHTML = '\
            <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:left">\
                <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
                <div style="padding-top:30px;">\
               <div style="clear:both;text-align:center;margin-top:0px;padding-bottom:0px"><b>请输入查询条件，没有输入的项将不做处理</b></div>\
            <div style="clear:both;text-align:center;margin-top:10px;padding-bottom:10px">\
                      标题：<input id="jsname" type="text" />\
                       <br><br> <input type="button" value="关闭" onclick="closeAlert(\'UploadChoose\');">\
                        <input type="button" value="查询" onclick="chksearchstr();closeAlert(\'UploadChoose\');">\
                    </div>\
                </div>\
            </div>';
            document.body.appendChild(div);

    }



function chksearchstr()
{
   
    var midSql="";

    if(document.getElementById('jsname').value!='')
    {
    midSql=midSql+"Title="+document.getElementById('jsname').value+"";
    }
     showwait();	
    window.location="InsideBBSList.aspx?key=1&"+midSql+"&id=<%=Request.QueryString["id"] %>";
}

function chkyema()
{
    if(document.getElementById('GoPage').value=='')
    {
    alert('页码不能为空');
    form1.GoPage.focus();
    return false;
    }	
   
    if(document.getElementById('GoPage').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('GoPage').value))
    {
    alert('页码只能为数字');
    form1.GoPage.focus();
    return false;
    }
    }
   
    
    showwait();	
}  

</script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" style="height: 564px"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> <a href="InsideBBS.aspx" class="line_b">讨论区</a> >> <%=Name %></td>
                      <td width="16%" align="right">&nbsp;<asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" /></td>
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
            </div></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17" >
                        &nbsp;</td>
                    <td valign="top" >
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#404040" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="0" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                 PageSize="5" Style="font-size: 12px" Width="100%" ShowHeader="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" >
                                <FooterStyle BackColor="White" ForeColor="Black" />
                                <Columns>
                        
                                    <asp:TemplateField >
                                        <HeaderStyle ForeColor="DarkSlateGray" Wrap="False" />
                                        <ItemTemplate>
                                          <asp:Label ID="Lid2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
<table width="100%" height="63" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgcolor="#FFFFFF"><font color=#666666>发帖人:<%#DataBinder.Eval(Container.DataItem, "Realname")%>&nbsp;&nbsp;&nbsp;<%#DataBinder.Eval(Container.DataItem, "Settime")%></font></td>
  </tr>
  <tr> 
    <td height="1px" bgcolor="#CCCCCC"></td>
  </tr>
  <tr> 
    <td bgcolor="#FFFFFF">
   <br> <font color=black><b><%#DataBinder.Eval(Container.DataItem, "Title")%></b></font><br><br>
    <%#DataBinder.Eval(Container.DataItem, "Content")%><br><br>
    附件下载：<br>
       <asp:Label ID="Label1" runat="server" ></asp:Label><br><br>
    
    </td>
  </tr>
<tr> 
<td bgcolor="#FFFFFF" align=right>
    <asp:Label ID="Label2" runat="server" ></asp:Label>
    </td>
  </tr>
</table>
           <br>
                                      
                                           
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
                            &nbsp;</div>
                            </td>
							</tr>
						</table>
                    </td>
                    <td width="17"  >
                        &nbsp;</td>
                </tr>
            </table>
            
              <div id="printshow3">
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>
