<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add.aspx.cs" Inherits="qpoa.WorkFlow.Form_add"
    ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function chknull()
{
    if(document.getElementById('FormName').value=='')
    {
    alert('表单名称为空');
    form1.FormName.focus();
    return false;
    }	



    showwait();					
}


function formset(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

//常规控件
if(str=="1")
{
oEditor.InsertHtml('<input id="Text1"  name="'+cValue+'"  type="text"  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

if(str=="2")
{
oEditor.InsertHtml('<textarea id="TextArea1" name="'+cValue+'"   cols="20" rows="2"  style="SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000 " ></textarea>');

}

if(str=="3")
{
oEditor.InsertHtml('<input id="Checkbox1"  name="'+cValue+'"   type="checkbox"  />');
}

if(str=="12")
{
oEditor.InsertHtml('<input id="Text1"  name="'+cValue+'"  type="text"  style="IME-MODE: disabled;border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"  onkeypress="var k=event.keyCode; return (k>=48&&k<=57)||k==46" onpaste="return !/\D/.test(clipboardData.getData(\'text\'))"  ondragenter="return false"/>');
}

if(str=="13")
{
var num=Math.random();
oEditor.InsertHtml('<input id="'+num+'" name="'+cValue+'"  type="text"  onclick="Jscript:var sID ;sID = event.srcElement.id; DateSelect(sID);"   value=""  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

 //<input id="WorkTime" type="text"  onclick="Jscript:var sID ;sID = event.srcElement.id; DateSelect(sID);" />

//宏控件




if(str=="4")
{
oEditor.InsertHtml('<input readonly id="Text2" name="'+cValue+'"  type="text" value="宏控件-用户姓名" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

if(str=="5")
{
oEditor.InsertHtml('<input readonly id="Text2" name="'+cValue+'"  type="text" value="宏控件-用户部门" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

if(str=="6")
{
oEditor.InsertHtml('<input readonly id="Text2"  name="'+cValue+'"   type="text" value="宏控件-用户角色" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

if(str=="7")
{
oEditor.InsertHtml('<input readonly id="Text2"  name="'+cValue+'"  type="text" value="宏控件-用户职位" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}


if(str=="8")
{
oEditor.InsertHtml('<input readonly id="Text2"  name="'+cValue+'"  type="text" value="宏控件-当前时间(日期)" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

//审批控件


if(str=="9")
{
oEditor.InsertHtml('<input id="Text3" type="text"   name="'+cValue+'"  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
}

if(str=="10")
{
oEditor.InsertHtml('<textarea id="TextArea3"  name="'+cValue+'"  cols="20" rows="2"  style="SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000 " ></textarea>');

}

if(str=="11")
{
oEditor.InsertHtml('<input id="Checkbox3"  name="'+cValue+'"  type="checkbox"  />');
}


if(str=="18")
{
var num=Math.random();
window.open ("DIYForm_add_bh.aspx?tmp="+num+"&Number="+cValue+"", "_blank", "height=400px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}



}




function  addfile()  
{  
var num=Math.random();
var str=""+document.getElementById('Number').value+"";
window.showModalDialog("DIYForm_add_add.aspx?tmp="+num+"&Number="+str+"","window", "dialogWidth:460px;DialogHeight=200px;status:no;scroll=yes;help:no");                

}


function  updatefile()  
{  

var num=Math.random();

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;
if(cText=="常规表单字段")
{
alert('此选项不能修改');
return false;
}
else
{
var str=""+cValue+"";
window.showModalDialog("DIYForm_add_update.aspx?tmp="+num+"&Number="+str+"","window", "dialogWidth:460px;DialogHeight=200px;status:no;scroll=yes;help:no");  
}              

}


function  delfile()  
{  
var num=Math.random();

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;
if(cText=="常规表单字段")
{
alert('此选项不能修改');
return false;
}
else
{
if (!confirm("是否确定删除“"+cText+"”？"))
return false;


var str=""+cValue+"";
window.showModalDialog("DIYForm_add_del.aspx?tmp="+num+"&Number="+str+"","window", "dialogWidth:460px;DialogHeight=200px;status:no;scroll=yes;help:no");  
}  



}

function  openyz()  
{  

    var num=Math.random();
    var oEditor = FCKeditorAPI.GetInstance('d_content');
    var littleproduct=document.getElementById("FormFile");
    var cindex = littleproduct.selectedIndex;
    var cText  = littleproduct.options[cindex].text;
    var cValue = littleproduct.options[cindex].value;

    if(cText=="常规表单字段")
    {
        alert('请先选择字段');
        form1.FormFile.focus();
        return false;
    }

    oEditor.InsertHtml('<img id="'+num+'" style="cursor: hand"  name="'+num+'" onclick="opensetyz('+num+','+cValue+')" src="/images/yz.gif" />');
}


function openqiupengmodle()
{
var num=Math.random();
window.open ("../fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
oEditor.InsertHtml(''+str+'');
}


function openlb()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_lb.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <!--#include file="../public/pleasewait.htm"-->
        <!--#include file="../public/public.js"-->

        <script language="javascript" src="../public/DateSelect.js"></script>

        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr>
                                                    <td align="center" class="newtd2" nowrap="nowrap" rowspan="5"
                                                        style="width: 14%" valign="top">
                                                        <strong>字段名<asp:LinkButton ID="LinkButton1" runat="server">[增加]</asp:LinkButton><asp:LinkButton
                                                            ID="LinkButton2" runat="server">[修改]</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton4" runat="server">[删除]</asp:LinkButton></strong>
                                                        <hr />
                                                        <asp:DropDownList ID="FormFile" runat="server" Width="153px">
                                                        </asp:DropDownList><br />
                                                        如果输入框不做条件比较<br />
                                                        可以选择"常规表单字段"
                                                        <hr />
                                                        <strong>标准控件</strong>
                                                        <hr />
                                                        <input id="Button2" onclick="formset(1)" style="width: 100px" type="button" value="插入常规输入框" />
                                                        <br />
                                                        <br />
                                                        <input id="Button14" onclick="formset(12)" style="width: 100px" type="button" value="插入数字输入框" />
                                                        <br />
                                                        <br />
                                                        <input id="Button4" onclick="formset(2)" style="width: 100px" type="button" value="插入文本输入框" /><br />
                                                        <br />
                                                        <input id="Button15" onclick="formset(13)" style="width: 100px" type="button" value="插入日期选择" />
                                                        <br />
                                                        <br />
                                                        <input id="Button5" onclick="formset(3)" style="width: 100px" type="button" value="插入复选框" />
                                                        <br />
                                                        <br />
                                                        <input id="Button12" onclick="openlb()" style="width: 100px" type="button" value="下拉列表控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button16" onclick="openyz()" style="width: 100px" type="button" value="印章域控件" />
                                                        <br />
                                                        <br />
                                                        <hr />
                                                        <strong>宏控件</strong>
                                                        <hr />
                                                        <input id="Button10" onclick="formset(18)" style="width: 100px" type="button" value="自定义宏控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button6" onclick="formset(4)" style="width: 100px" type="button" value="插入用户姓名" />
                                                        <br />
                                                        <br />
                                                        <input id="Button7" onclick="formset(5)" style="width: 100px" type="button" value="插入用户部门" />
                                                        <br />
                                                        <br />
                                                        <input id="Button8" onclick="formset(6)" style="width: 100px" type="button" value="插入用户角色" />
                                                        <br />
                                                        <br />
                                                        <input id="Button9" onclick="formset(7)" style="width: 100px" type="button" value="插入用户职位" />
                                                        <br />
                                                        <br />
                                                        <input id="Button11" onclick="formset(8)" style="width: 100px" type="button" value="当前时间(日期)" />
                                                        <br />
                                                        <hr />
                                                        <strong>表单模版</strong>
                                                        <hr />
                                                        <input id="Button13" onclick="openqiupengmodle()" style="width: 100px" type="button"
                                                            value="表单模版" />
                                                    </td>
                                                    <td class="newtd2" style="height: 17px" width="85%">
                                                        类别：<asp:DropDownList ID="FormType" runat="server" Width="90%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="85%">
                                                        名称：<asp:TextBox ID="FormName" runat="server" Width="85%" MaxLength="10"></asp:TextBox>(10字符)</td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="24">
                                                        范围：<asp:TextBox ID="openrealname" runat="server" Height="55px" TextMode="MultiLine"
                                                            Width="85%"></asp:TextBox><a href="javascript:void(0)"><img onclick="openuser1();"
                                                                alt="" src="../images/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2">
                                                        <FCKeditorV2:FCKeditor ID="d_content" runat="server" Height="350px" ToolbarSet="Qiupeng">
                                                        </FCKeditorV2:FCKeditor>
                                                        <br>
                                                        <font color="red">1.点击左边控件按钮将会把内容插入到编辑器中鼠标的光标所在处，如果鼠标的光标没有在编辑器中将不会插入内容。
                                                            <br />
                                                            2.页面中存在重复的字段，系统在流程条件判断中将取页面上第一个控件的值。如果第一个控件没有值，系统默认为未取到值。</font></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button3" class="button_blue" type="button"
                                                                    value="关 闭" onclick="javascript:window.close()" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="openusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('openusername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("openusername").value=arr[0]; 
document.getElementById("openrealname").value=arr[1]; 
}
}





        </script>

    </form>
</body>
</html>
