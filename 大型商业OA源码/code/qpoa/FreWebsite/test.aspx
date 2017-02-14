<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="qpoa.FreWebsite.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Unit" runat="server" Width="80%" title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openunit();" alt="" src="../images/FDJ.gif" border="0">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" /></div>
        <input id="Text1" type="text"　ReadOnly value="2132"/>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
           <asp:TextBox ID="UnitId" runat="server" Width="90%"></asp:TextBox>
    </form>
 
    <script language="javascript">	


var  wName_1;  
function  openunit()  
{  
var num=Math.random();
wName_1=window.showModalDialog("../OpenWindows/open_UnitName.aspx?tmp="+num+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("UnitId").value=arr[0]; 
document.getElementById("Unit").value=arr[1]; 
}
}


</script>  
</body>
</html>
