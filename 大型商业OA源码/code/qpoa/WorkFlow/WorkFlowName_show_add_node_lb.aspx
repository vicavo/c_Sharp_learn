<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_lb.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowName_show_add_node_lb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <SCRIPT language=javascript src="flowcss/set_main.js"></SCRIPT>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
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
            var title = '表单设计';
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
                   &nbsp;&nbsp;&nbsp;表单类别：<input id="jsType" type="text"   style="width: 138px"/>&nbsp;&nbsp;表单名称：<input id="jsFormName" type="text"   style="width: 138px"/>&nbsp;&nbsp;\
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

if(document.getElementById('jsType').value!='')
{
midSql=midSql+"Type="+document.getElementById('jsType').value+"";
}

if(document.getElementById('jsFormName').value!='')
{
midSql=midSql+"&FormName="+document.getElementById('jsFormName').value+"";
}  
 
showwait();

window.location="DIYForm.aspx?key=1&"+midSql+"";
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



function showfrom(str)
{
var num=Math.random();
window.open ("DIYForm_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height=650, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")
}

function updatefrom(str)
{
var num=Math.random();
window.open ("DIYForm_update.aspx?tmp="+num+"&id="+str+"", "_blank", "height=650, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")
}


function addfrom()
{
var num=Math.random();
window.open ("DIYForm_add.aspx?tmp="+num+"", "_blank", "height=650, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")


}


 </script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->

<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                       
                          <input id="Button1" type="button" value="增  加" onclick="Add_Process();"/>
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="NodeNum" HeaderText="序号" SortExpression="NodeNum">
                                        <ItemStyle Wrap="False" Width="50px" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>                                 
                                    <asp:BoundField DataField="NodeName" HeaderText="步骤名称" SortExpression="NodeName">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                         　　　　　   <asp:TemplateField HeaderText="下一步骤">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"/>
                                        <ItemTemplate>
                                            <asp:Label ID="NodeSite" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NodeSite")%>' Visible=false></asp:Label>
                                            <asp:Label ID="UpNodeNum" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UpNodeNum")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                        
                                        <ItemStyle Wrap="False" HorizontalAlign=Center/>
                                    </asp:TemplateField>                 
                                    <asp:TemplateField HeaderText="编辑该步骤的各项属性">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="220px"/>
                                        <ItemTemplate>
                                            <a href="javascript:void(0)" onclick="Edit_Process(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">基本属性</a>
                                            <a href="javascript:void(0)" onclick="set_next(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">追加步骤</a>
                                            <a href="javascript:void(0)" onclick="set_item(<%# DataBinder.Eval(Container.DataItem, "ID") %>);" title="<%# DataBinder.Eval(Container.DataItem, "WriteFileName") %>">可写字段</a>
                                            <a href="javascript:void(0)" onclick="set_condition(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">条件设置</a>
                                            <br><img src="../images/node_user.gif" />
                                            <a href="javascript:void(0)" onclick="set_user(<%# DataBinder.Eval(Container.DataItem, "ID") %>);" title="<%# DataBinder.Eval(Container.DataItem, "JBRObjectName") %>">经办人员</a>
                                            <a href="javascript:void(0)" onclick="set_dept(<%# DataBinder.Eval(Container.DataItem, "ID") %>);" title="<%# DataBinder.Eval(Container.DataItem, "JBBMObjectName") %>">经办部门</a>
                                            <a href="javascript:void(0)" onclick="set_priv(<%# DataBinder.Eval(Container.DataItem, "ID") %>);" title="<%# DataBinder.Eval(Container.DataItem, "JBJSObjectName") %>">经办角色</a>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="220px"/>
                                    </asp:TemplateField>                    
                                  
                                     <asp:TemplateField HeaderText="操作">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="40px"/>
                                        <ItemTemplate>
                                           <a href="javascript:void(0)" onclick="Del_Process(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">删除</a>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="40px"/>
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
                          
                         
                            </td>
							</tr>
						</table>
                    </td>
                    <td width="17" >
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
 <asp:TextBox ID="FlowNumber" runat="server" style="DISPLAY: none"></asp:TextBox>
    </form>
</body>
</html>
