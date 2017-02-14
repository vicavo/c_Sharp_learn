<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toupiao_tp.aspx.cs" Inherits="qpoa.InfoSpeech.toupiao_tp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
	<script language="javascript">

			function fanAll()
			{
				var a=0
				for(var i=0;i<document.Form1.elements.length;i++)
				{
					if(document.Form1.elements[i].checked==true)
						{a=a+1}
					
				}
				
				if(a>0)
				{
				
			             if(document.getElementById('TextBox1').value=='单选')
			             {
			      
								if(a>1)
								{
								alert('此投票主题只能选择一项')
								return false;
								}
			            
			             }
			  
			      
				
				}
				else
				{
					alert('请至少选种一项');
					return false;
				}
				
			}
			
			


function tpcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{
         if(document.getElementById('TextBox1').value=='单选')
         {
  
				if(a>1)
				{
				alert('此投票主题只能选择一项')
				return false;
				}
        
         }

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}

	
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
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
        <tr> 
          <td style="height: 35px">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17" >&nbsp;</td>
                <td valign="top" > 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 投票浏览&nbsp; &gt;&gt;&nbsp; 参与投票</td>
                      <td width="16%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                    <tr> 
                      <td></td>
                    </tr>
                  </table></td>
                <td width="17" >&nbsp;</td>
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
                             
       <button class="btn4off" onclick="javascript:window.location='toupiao.aspx';showwait();"
                                    type="button"><font class="shadow_but">投票浏览</font></button>
                              
                            </td>
                              <td style="height: 26px" align="right" > 
                                  <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/button_tp.jpg"
                                      OnClick="ImageButton3_Click" /></td>
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
								<div align=center><STRONG><FONT face="宋体" color="#ff0000"><%=title%></FONT> </STRONG></div>
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" OnRowCommand="GridView1_RowCommand" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="选择">
                                        <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckSelect" runat="server" />
                                            <asp:Label ID="LabVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                             <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "title") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="选项">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"/>
                                        <ItemTemplate>
<TABLE BORDER="0" CELLSPACING="0" CELLPADDING="4">
    <TR>
        
        <td ><%#DataBinder.Eval(Container.DataItem, "title")%></td>
        <TD>
            <TABLE WIDTH="<%#int.Parse(Eval("piaoshu").ToString())*5%>" BORDER="0" CELLSPACING="0" CELLPADDING="0" height=10 bgcolor="<%#DataBinder.Eval(Container.DataItem, "color")%>">
            <TR>
            <TD></TD>
            </TR>
            </TABLE>
        </TD>
        <TD><%#DataBinder.Eval(Container.DataItem, "piaoshu")%>票</TD>
    </TR>
</TABLE> 
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>    
                                    
                                    
                                    
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                <AlternatingRowStyle BackColor="#E6EDF7" />
                                     <EmptyDataTemplate>
                                    <div align=center><font color=white>无相关数据！</font></div>
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
                      <td valign="top" background="../images/next_bg.jpg">
                          </td>
                      <td width="17">
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              <asp:TextBox ID="TextBox1" runat="server" style="DISPLAY: none"></asp:TextBox></td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>
