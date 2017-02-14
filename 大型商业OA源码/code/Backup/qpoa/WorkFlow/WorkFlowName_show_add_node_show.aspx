<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_show.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowName_show_add_node_show" %>

<head runat="server">

<META http-equiv=Content-Type content="text/html; charset=gb2312">
<LINK href="flowcss/style.css" type=text/css rel=stylesheet>

<OBJECT id=vmlRender classid=CLSID:10072CEC-8CC1-11D1-986E-00A0C955B42E VIEWASTEXT></OBJECT>
<STYLE>vml\:* {FONT-SIZE: 12px; BEHAVIOR: url(#VMLRender)}</STYLE>

<HTML xmlns:vml = "urn:schemas-microsoft-com:vml">

<SCRIPT language=javascript src="flowcss/set_main.js"></SCRIPT>
<META content="MSHTML 6.00.3790.3041" name=GENERATOR>



    <title>无标题页</title>
</head>
<body oncontextmenu=nocontextmenu(); onmousedown=DoRightClick(); leftMargin=2 opMargin=2>
    <form id="form1" runat="server">
<vml:Line id=line1 
style="DISPLAY: none; Z-INDEX: 15; POSITION: absolute" to="0,0" from="0,0"><!--直线可视化--><vml:Stroke 
dashstyle="shortDash"></vml:Stroke></vml:Line>
<%=LineContent %>
<%=ContentLable %>



 
        <asp:TextBox ID="SET_SQL" runat="server" style="DISPLAY: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" style="DISPLAY: none"></asp:TextBox>
    </form>
</body>
</html>
