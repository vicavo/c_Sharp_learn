<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sms_show.aspx.cs" Inherits="qpoa.sms_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查看短信</title>
    <LINK href="css/public.css" type="text/css" rel="stylesheet">
    
<SCRIPT language=JavaScript>
TimeStart=20;

function MyTimer()
{
   if(TimeStart==0)
      window.close();

   if(document.getElementById("TimeShow"))
      document.getElementById("TimeShow").innerHTML=TimeStart;
   TimeStart--;

   var timer=setTimeout("MyTimer()",1000);
}

</SCRIPT>
</head>
<body onload="MyTimer();">
    <form id="form1" runat="server">
    <div>
    <TABLE width="100%" align=center>
  <TBODY>
  <TR>
    <TD>
      <TABLE class=TableHeader cellSpacing=0 cellPadding=3 width="100%" 
border=0>
        <TBODY>
        <TR>
          <TD><IMG alt=个人短信 src="images/menu/comm.gif" align=absMiddle width="16"> 
            个人短信 </TD>
          <TD class=small align=right>共<SPAN class=big4><a href="javascript:void(0)" onclick="window.opener.gourl()"><%=CountsLabel%></a></SPAN>条新短信 窗口<SPAN 
            id=TimeShow 
            style="FONT-WEIGHT: bold; COLOR: #ff0000"></SPAN>&nbsp;秒后关闭
        </TD></TR></TBODY></TABLE></TD></TR>
  <TR class=TableData>
    <TD>
      <TABLE class=small cellSpacing=0 cellPadding=5 width="100%" border=0>
        <TBODY>
        <TR>
          <TD style="COLOR: #0000ff"><%=sendrealname %>&nbsp;&nbsp;<%=itimes %></TD>
          <TD style="COLOR: #0000ff" align=right>收信人：<%=acceptrealname %></TD></TR>
        <TR vAlign=top height=110>
          <TD colSpan=2><%=title %><hr/><%=content %></TD>
        </TR>
        <TR>
          <TD colSpan=2>
            <DIV align=right><asp:LinkButton ID="LinkButton4"  runat="server" OnClick="LinkButton4_Click">我知道了</asp:LinkButton>&nbsp;&nbsp; 
           <asp:LinkButton ID="LinkButton3"  runat="server" OnClick="LinkButton3_Click">回复</asp:LinkButton>&nbsp;&nbsp; 
           <asp:LinkButton ID="LinkButton2"  runat="server" OnClick="LinkButton2_Click">查看详情</asp:LinkButton>&nbsp;&nbsp; 
           <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="LinkButton1_Click">删除</asp:LinkButton>&nbsp;&nbsp; 
            </DIV></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
    </div>
    </form>
</body>
</html>
