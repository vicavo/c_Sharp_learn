<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WbMail_js.aspx.cs" Inherits="qpoa.InfoSpeech.WbMail_js" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function urlset()
{
window.location = 'WbMailAccept.aspx?id=<%=strid%>'
}
</script>

<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<br><br><br><br><br><br><br><br><div align="center">
			邮件下载中，请等待 ……
			</div>
    </div>
    </form>
</body>
</html>
