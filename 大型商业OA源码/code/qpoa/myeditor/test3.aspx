<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test3.aspx.cs" Inherits="qpoa.myeditor.test3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Œﬁ±ÍÃ‚“≥</title>

</head>
<body onload="Load_Do()">
    <form id="form1" runat="server">
    <div>
     <iframe name="EDIT_HTML" width="100%" height=260 src="updateeditor.htm" viewastext type="text/x-scriptlet"></iframe>
      <input  name="CONTRACT_CONTENT"  value="<p>aadsdasdasda</p><p>111111</p><p>2222</p>">
    </div>
        <input id="Button1" type="button" value="button" onclick="Load_Do();"/>
      <asp:TextBox ID="TextBox1" runat="server" Height="203px" TextMode="MultiLine" Width="613px"></asp:TextBox>
      <script>

function Load_Do()
{
setTimeout("Load_Do()",0);
var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
document.getElementById("TextBox1").value=content;
}



</script>
    </form>
</body>
</html>
