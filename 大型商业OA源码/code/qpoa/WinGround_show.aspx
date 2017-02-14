<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinGround_show.aspx.cs" Inherits="qpoa.WinGround_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>运行Windows程序</title>
    <script>
function win_run()
{
  form1.CoolRun.Path="<%=MathRoad %>";
  form1.CoolRun.RunPath();
  window.setTimeout(' window.close();',3000);
}
</script>
</head>
<body onload="win_run()">
    <form id="form1" runat="server">
     <object classid="clsid:4AB8AC1A-AE97-49ff-A74C-1F3C0CFC9870" id="CoolRun" codebase="public/CoolRun.ocx#version=1,0,0,0"></object>
    <div align=center>
  运行<font color=red><%=Name%></font>请等待.......
    </div>
    </form>
</body>
</html>
