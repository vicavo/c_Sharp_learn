<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaXzPieces.aspx.cs" Inherits="qpoa.HumanResources.SaPieces" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>����칫ϵͳ</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>
   function UploadComplete()
    {

            showCover();
            //�ؼ���
            var aw = 600;
            //�ؼ���
            var ah = 270;
            //����ؼ�ˮƽλ��
            var al = (screen.width - aw)/2-100;
            //����ؼ���ֱλ��
            var at = (screen.height - ah)/5;
            //���ݹ���
            var title = '�Ƽ���Ʒ';
            var icon = 'smile';
            var cardID = '0';
            //�����ʾ��
            var div = document.createElement("div");
            div.id = "UploadChoose";
            div.innerHTML = '\
            <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:left">\
                <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
                <div style="padding-top:30px;">\
               <div style="clear:both;text-align:center;margin-top:0px;padding-bottom:0px"><b>�������ѯ������û����������������</b></div>\
            <div style="clear:both;text-align:left;margin-top:10px;padding-bottom:10px">\
                   &nbsp;&nbsp;&nbsp;�������ƣ�<input id="jsSaName" type="text"   style="width: 138px"/>&nbsp;&nbsp;��Ա������<input id="jsDyRealname" type="text"   style="width: 138px"/>&nbsp;&nbsp;\
                   <br>&nbsp;&nbsp;&nbsp;�������ƣ�<input id="jsName" type="text"   style="width: 138px"/>&nbsp;&nbsp;�������ڣ�<input id="jsWorkTime" type="text"   style="width: 138px"/>&nbsp;&nbsp;\
                      <br><br> <div style="clear:both;text-align:center;"><input type="button" value="�ر�" onclick="closeAlert(\'UploadChoose\');">\
                         <input type="button" value="��ѯ" onclick="return  chksearchstr();closeAlert(\'UploadChoose\');"></div>\
                    </div>\
                </div>\
            </div>';
            document.body.appendChild(div);

    }



function chksearchstr()
{
   var midSql="";

    if(document.getElementById('jsName').value!='')
    {
    midSql=midSql+"Name="+document.getElementById('jsName').value+"";
    }
    if(document.getElementById('jsDyRealname').value!='')
    {
    midSql=midSql+"&DyRealname="+document.getElementById('jsDyRealname').value+"";
    }  

    if(document.getElementById('jsSaName').value!='')
    {
    midSql=midSql+"&SaName="+document.getElementById('jsSaName').value+"";
    } 
    
      
    if(document.getElementById('jsWorkTime').value!='')
    {
     var objRe = /^([0-9]){4,4}-([0-9]){1,2}-([0-9]){1,2}$/;
    if(!objRe.test(document.getElementById('jsWorkTime').value))
    {
    alert('���ڸ�ʽ����ȷ���밴��yyyy-mm-dd��ʽ����');
   
    return false;
    }
    
    midSql=midSql+"&WorkTime="+document.getElementById('jsWorkTime').value+"";
    }   
	showwait();
    window.location="SaXzPieces.aspx?key=1&"+midSql+"";
}



function chkyema()
{
    if(document.getElementById('GoPage').value=='')
    {
    alert('ҳ�벻��Ϊ��');
    form1.GoPage.focus();
    return false;
    }	
   
    if(document.getElementById('GoPage').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('GoPage').value))
    {
    alert('ҳ��ֻ��Ϊ����');
    form1.GoPage.focus();
    return false;
    }
    }
   
    
    showwait();	
}  

function outexcel()
{
showwait();
var num=Math.random();
window.open ("SaXzPieces_dc.aspx?tmp="+num+"", "_blank", "height=1, width=1")
}	
function outexcels()
{
showwait();
var num=Math.random();
window.open ("SaXzPieces_dc.aspx?tmp="+num+"&str=<%=SqlStrMid%>", "_blank", "height=1, width=1")
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
          <td height="35">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">����̨</a> >>  н�ʹ���  >>  �Ƽ���Ʒ</td>
                      <td width="16%">&nbsp;</td>
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
                <td width="17" style="height: 40px">&nbsp;</td>
                <td valign="top" style="height: 40px"> 
                   <div id="printshow2"> <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 26px; width: 11%;">
                              <button class="btn4off" onclick="javascript:window.location='SaXzPieces.aspx';showwait();"
                                    type="button">
                                    <font class="shadow_but">�Ƽ���Ʒ</font></button>
                              
                            </td>
                              <td style="height: 26px" align="right" > 
                                 
                             
                                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/button_add.jpg" OnClick="ImageButton1_Click" />
                                  <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/button_show.jpg" OnClick="ImageButton6_Click" />
                                  <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/button_update.jpg" OnClick="ImageButton2_Click" />
                                  <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/button_del.jpg" OnClick="ImageButton3_Click" />
                                  <a href="javascript:void(0)"><img onclick="UploadComplete()" src="../images/button_search.jpg"  border=0 id="IMG1" runat="server"/></a>
                                  <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/button_out.jpg" />
                                  </td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
              </tr>
            </table><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ѡ��">
                                        <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckSelect" runat="server" />
                                            <asp:Label ID="LabVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                             <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DyRealname" HeaderText="��Ա����" SortExpression="DyRealname">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>                                 
  
                                      <asp:BoundField DataField="Name" HeaderText="��������" SortExpression="Name">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>   
                                    
                                     <asp:BoundField DataField="DjMoney" HeaderText="����" SortExpression="DjMoney">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>   
                                    
                                    <asp:BoundField DataField="WorkNum" HeaderText="����" SortExpression="WorkNum">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>   
  
                                      <asp:BoundField DataField="AllMoney" HeaderText="�ܼ�" SortExpression="AllMoney">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>  
  
  
  
                                     <asp:BoundField DataField="WorkTime" HeaderText="������" SortExpression="WorkTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>    
  
  
                                  
                                    <asp:BoundField DataField="SaName" HeaderText="��������" SortExpression="SaName">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>             
                                             
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                <AlternatingRowStyle BackColor="#E6EDF7" />
                                     <EmptyDataTemplate>
                                    <div align=center><font color=white>��������ݣ�</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            &nbsp;</div>
                            </td>
							</tr>
						</table>
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
            
              <div id="printshow3">
              <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                      <td width="17" >
                          &nbsp;</td>
                      <td valign="top" background="../images/next_bg.jpg" >
                     
                          <table border="0" cellpadding="0" cellspacing="0">
                              <tr>
                                  <td >
                                
                                  </td>
                                  <td >
                                                              &nbsp;&nbsp; <a href="javascript:void(0)" onclick="checkAll()" class="line">ȫѡ</a>
                                      &nbsp;&nbsp;<a href="javascript:void(0)" onclick="fanAll()" class="line">��ѡ</a>
                                    &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first" OnClick="PagerButtonClick">��ҳ</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev" OnClick="PagerButtonClick">��һҳ</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next" OnClick="PagerButtonClick">��һҳ</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last" OnClick="PagerButtonClick">βҳ</asp:LinkButton>
                                  &nbsp;&nbsp;&nbsp;<font color="#000000"> ҳ�룺<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                      <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="��ת" Width="36px"��Height="20px" OnClick="Button1_Click1" />
                                      &nbsp;&nbsp;&nbsp;ÿҳ<font color=red>12</font>������
                                      &nbsp;&nbsp; ����<font color=red><%=CountsLabel%></font>������
                                      &nbsp;&nbsp;&nbsp;��ǰΪ��<font color=red><%=CurrentlyPageLabel%></font>ҳ 
                                      &nbsp;&nbsp;&nbsp; ��<font color=red><%=AllPageLabel%></font>ҳ</font>
                         
                                  </td>
                              </tr>
                          </table>
                          </td>
                      <td width="17" >
                          &nbsp;</td>
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
