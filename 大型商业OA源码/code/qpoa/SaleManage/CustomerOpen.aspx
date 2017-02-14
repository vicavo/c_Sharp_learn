<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerOpen.aspx.cs" Inherits="qpoa.SaleManage.CustomerOpen" %>



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
            var title = '客户查询';
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
                      客户名称：<input id="jsname" type="text"  style="width: 158px"/>&nbsp;业务员：<input id="jsywrealname" type="text"  style="width: 158px"/>\
                         <br>客户编号：<input id="jscustomernumber" type="text"  style="width: 158px"/>&nbsp;行&nbsp;&nbsp;&nbsp;业：<input id="jsindustry" type="text"  style="width: 138px"/><A href="javascript:void(0)"><IMG onclick="OpenSaleData2()" src="../images/FDJ.gif" border="0"></A>\
                          <br> 客户来源：<input id="jscsource" type="text"   style="width: 138px"/><A href="javascript:void(0)"><IMG onclick="OpenSaleData3()" src="../images/FDJ.gif" border="0"></A>&nbsp;重要度：<input id="jscimportant" type="text"   style="width: 138px"/><A href="javascript:void(0)"><IMG onclick="OpenSaleData4()" src="../images/FDJ.gif" border="0"></A>\
                         <br>销售方式：<input id="jssales" type="text" /><A href="javascript:void(0)"><IMG onclick="OpenSaleData7()" src="../images/FDJ.gif" border="0"></A>&nbsp;企业性质：<input id="jsnature" type="text" /><A href="javascript:void(0)"><IMG onclick="OpenSaleData6()" src="../images/FDJ.gif" border="0"></A>\
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
    midSql=midSql+"Name="+document.getElementById('jsname').value+"";
    }
    if(document.getElementById('jsywrealname').value!='')
    {
    midSql=midSql+"&YwRealname="+document.getElementById('jsywrealname').value+"";
    }  
    if(document.getElementById('jscustomernumber').value!='')
    {
    midSql=midSql+"&CustomerNumber="+document.getElementById('jscustomernumber').value+"";
    }    
    if(document.getElementById('jsindustry').value!='')
    {
    midSql=midSql+"&Industry="+document.getElementById('jsindustry').value+"";
    }   
    if(document.getElementById('jssales').value!='')
    {
    midSql=midSql+"&Sales="+document.getElementById('jssales').value+"";
    }  
    if(document.getElementById('jsnature').value!='')
    {
    midSql=midSql+"&Nature="+document.getElementById('jsnature').value+"";
    }   
     
    if(document.getElementById('jscsource').value!='')
    {
    midSql=midSql+"&CSource="+document.getElementById('jscsource').value+"";
    }   
   
    if(document.getElementById('jscimportant').value!='')
    {
    midSql=midSql+"&CImportant="+document.getElementById('jscimportant').value+"";
    }   
   
    
    showwait();
    	
    window.location="CustomerOpen.aspx?key=1&"+midSql+"";
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

function outexcel()
{
showwait();
var num=Math.random();
window.open ("CustomerOpen_dc.aspx?tmp="+num+"", "_blank", "height=1, width=1")
}	
function outexcels()
{
showwait();
var num=Math.random();
window.open ("CustomerOpen_dc.aspx?tmp="+num+"&str=<%=SqlStrMid%>", "_blank", "height=1, width=1")
}	


//var  wName;  
//function  OpenSaleData(strtext,type)  
//{  

//var num=Math.random();
//var str=document.getElementById(""+strtext+"").value;
//wName=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type="+type+"","window", "dialogWidth:900px;DialogHeight=480px;status:yes;scroll=yes;help:no");               
//if(wName!=null && wName!= "undefined")
//{
//document.getElementById(""+strtext+"").value=wName; 
//}

//}


var  wName6;  
function  OpenSaleData6()  
{  

var num=Math.random();
var str=document.getElementById("jsnature").value;
wName6=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=6","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName6!=null && wName6!= "undefined")
{
document.getElementById("jsnature").value=wName6; 
}

}


var  wName3;  
function  OpenSaleData3()  
{  

var num=Math.random();
var str=document.getElementById("jscsource").value;
wName3=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=3","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("jscsource").value=wName3; 
}

}



var  wName4;  
function  OpenSaleData4()  
{  

var num=Math.random();
var str=document.getElementById("jscimportant").value;
wName4=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=4","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName4!=null && wName4!= "undefined")
{
document.getElementById("jscimportant").value=wName4; 
}

}



var  wName7;  
function  OpenSaleData7()  
{  

var num=Math.random();
var str=document.getElementById("jssales").value;
wName7=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=7","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName7!=null && wName7!= "undefined")
{
document.getElementById("jssales").value=wName7; 
}

}


var  wName2;  
function  OpenSaleData2()  
{  

var num=Math.random();
var str=document.getElementById("jsindustry").value;
wName2=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=2","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName2!=null && wName2!= "undefined")
{
document.getElementById("jsindustry").value=wName2; 
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 客户管理 >>  客户信息管理 >>  公开客户</td>
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
                              <button class="btn4off" onclick="javascript:window.location='Customer.aspx';showwait();"
                                    type="button">
                                    <font class="shadow_but">客户信息</font></button>
                                <button class="btn4off" onclick="javascript:window.location='CustomerPublic.aspx';showwait();" type="button"><font class="shadow_but">共享客户</font></button>
                                  <button class="btn4on" onclick="javascript:window.location='CustomerOpen.aspx';showwait();" type="button"><font class="shadow_but">公开客户</font></button>
                            </td>
                              <td style="height: 26px" align="right" > 
                                  <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/button_show.jpg" OnClick="ImageButton6_Click" />
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
                        <div id="Div1" >
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" >
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
                                             <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="客户名称" SortExpression="Name">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CustomerNumber" HeaderText="客户编号" SortExpression="CustomerNumber">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="YwRealname" HeaderText="业务员" SortExpression="YwRealname">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tel" HeaderText="电话" SortExpression="Tel">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    
                                       <asp:TemplateField HeaderText="其他信息">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Width="120px" />
                                        <ItemTemplate>
                                            <a href='CustomerOpenLxr.aspx?KeyId=<%# DataBinder.Eval(Container.DataItem, "id") %>' onclick="showwait();">联系人信息</a>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" Wrap="False" HorizontalAlign=Center/>
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
                     
                          <table border="0" cellpadding="0" cellspacing="0">
                              <tr>
                                  <td >
                                
                                  </td>
                                  <td >
                                                              &nbsp;&nbsp; <a href="javascript:void(0)" onclick="checkAll()" class="line">全选</a>
                                      &nbsp;&nbsp;<a href="javascript:void(0)" onclick="fanAll()" class="line">反选</a>
                                    &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first" OnClick="PagerButtonClick">首页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev" OnClick="PagerButtonClick">上一页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next" OnClick="PagerButtonClick">下一页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last" OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                  &nbsp;&nbsp;&nbsp;<font color="#000000"> 页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                      <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"　Height="20px" OnClick="Button1_Click1" />
                                      &nbsp;&nbsp;&nbsp;每页<font color=red>12</font>条数据
                                      &nbsp;&nbsp; 共有<font color=red><%=CountsLabel%></font>条数据
                                      &nbsp;&nbsp;&nbsp;当前为第<font color=red><%=CurrentlyPageLabel%></font>页 
                                      &nbsp;&nbsp;&nbsp; 共<font color=red><%=AllPageLabel%></font>页</font>
                         
                                  </td>
                              </tr>
                          </table>
                          </td>
                      <td width="17">
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>
