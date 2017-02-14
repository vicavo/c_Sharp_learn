<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyUnitNotic.aspx.cs" Inherits="qpoa.MyAffairs.MyUnitNotic" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">

    <script>
   function UploadComplete()
    {

            showCover();
            //控件宽
            var aw = 600;
            //控件高
            var ah = 270;
            //计算控件水平位置
            var al = (screen.width - aw)/2-100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            //内容管理
            var title = '部门通知';
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
            <div style="clear:both;text-align:left;margin-top:10px;padding-bottom:10px">\
                      &nbsp;&nbsp;&nbsp;标题：<input id="jsTitle" type="text"  style="width: 398px"/>\
                        <br>&nbsp;&nbsp;&nbsp;内容：<input id="jsContent" type="text"  style="width: 398px"/>\
                      <br><br> <div style="clear:both;text-align:center;"><input type="button" value="关闭" onclick="closeAlert(\'UploadChoose\');">\
                         <input type="button" value="查询" onclick="return  chksearchstr();closeAlert(\'UploadChoose\');"></div>\
                    </div>\
                </div>\
            </div>';
            document.body.appendChild(div);

    }



function chksearchstr()
{
var midSql="";



if(document.getElementById('jsTitle').value!='')
{
midSql=midSql+"Title="+document.getElementById('jsTitle').value+"";
}



if(document.getElementById('jsContent').value!='')
{
midSql=midSql+"&Content="+document.getElementById('jsContent').value+"";
}  

 
showwait();

window.location="MyUnitNotic.aspx?key=1&"+midSql+"";
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
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="../images/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="../main_d.aspx" class="line_b">工作台</a> >> 部门通知 >> 部门通知浏览</td>
                                                        <td width="16%">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                                                    <tr>
                                                        <td>
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
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17" style="height: 40px">
                                            &nbsp;</td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px; width: 11%;">
                                                            <button class="btn4on" onclick="javascript:window.location='MyUnitNotic.aspx';showwait();"
                                                                type="button">
                                                                <font class="shadow_but">未读通知</font></button>
                                                            <button class="btn4off" onclick="javascript:window.location='MyUnitNoticYd.aspx';showwait();"
                                                                type="button">
                                                                <font class="shadow_but">已读通知</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <a href="javascript:void(0)">
                                                                <img onclick="UploadComplete()" src="../images/button_search.jpg" border="0" id="IMG1"
                                                                    runat="server" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Title" HeaderText="标题" SortExpression="Title">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NowTimes" HeaderText="发布时间" SortExpression="NowTimes"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="所属部门" SortExpression="UnitName">
                                                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("UnitName").ToString().Replace("-", "").Replace("|", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="相关操作">
                                                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="80px" />
                                                                        <ItemTemplate>
                                                                            <a href='MyUnitNotic_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                                onclick="showwait();">查看</a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                                                <AlternatingRowStyle BackColor="#E6EDF7" />
                                                                <EmptyDataTemplate>
                                                                    <div align="center">
                                                                        <font color="white">无相关数据！</font></div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                            &nbsp;</div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <div id="printshow3">
                                    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top" background="../images/next_bg.jpg">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                            <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                                OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                                OnClick="PagerButtonClick">上一页</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                                OnClick="PagerButtonClick">下一页</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                                OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;<font color="#000000"> 页码：<asp:TextBox ID="GoPage" runat="server"
                                                                Width="25px"></asp:TextBox>
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                                    Height="20px" OnClick="Button1_Click1" />
                                                                &nbsp;&nbsp;&nbsp;每页<font color="red">12</font>条数据 &nbsp;&nbsp; 共有<font color="red"><%=CountsLabel%></font>条数据
                                                                &nbsp;&nbsp;&nbsp;当前为第<font color="red"><%=CurrentlyPageLabel%></font>页 &nbsp;&nbsp;&nbsp;
                                                                共<font color="red"><%=AllPageLabel%></font>页</font>
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
                    </table>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
	    parent.closeAlert('UploadChoose');
        </script>

    </form>
</body>
</html>
