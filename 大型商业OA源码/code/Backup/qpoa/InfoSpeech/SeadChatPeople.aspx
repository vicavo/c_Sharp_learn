<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeadChatPeople.aspx.cs" Inherits="qpoa.InfoSpeech.SeadChatPeople" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<script>
            var yuser='<%=ChatName%>';
            var ysuser='<%=Request.QueryString["id"]%>';
			window.setInterval("AjaxMethod.ListPeople('"+ysuser+"','"+yuser+"',get_chat)",2000);
				
			function get_chat(response)
			{
				//updatechat();
			
				if (response.value != null)
				{					
				
				var ds = response.value;
　　　　		
				var htmlstr="<table width=100% border=0 cellpadding=4 cellspacing=0><tr><td><a href=javascript:void(0) onclick=parent.setuser('所有人','所有人')><font color=#FF00F7>所有人</font></a></td></tr>";　　
				for(var i=0; i<ds.Tables[0].Rows.length; i++)
　　　　		{
　　　　			htmlstr+="<tr>";　
　　　　　　		var sname_table=ds.Tables[0].Rows[i].realname;
　　　　　　		var suser_table=ds.Tables[0].Rows[i].username;
　　　　　　		
　　　　　　		var id=ds.Tables[0].Rows[i].id;
　　　　　　		
　　　　　　		htmlstr+="<td><a href=javascript:void(0) onclick=parent.setuser('"+suser_table+"','"+sname_table+"')><font color=#FF00F7>"+sname_table+"</font></a></td></tr>";
　　　　　　		//htmlstr=htmlstr+"</tr>";
　　　　		}
　　　　			htmlstr+="</TABLE>";
　　　　			document.getElementById('Tables_chat').innerHTML=htmlstr;
　　　　		
　				　	document.getElementById('show').style.display='none'; 
　　　　		}
　　　　		
			}
			
			
		</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <LINK href="../css/public.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" runat="server">
    <div>
    <table cellSpacing="0" borderColorDark="#ffffff" cellPadding="0" width="99%" borderColorLight="#c0c0c0"
				border="0">
				<TBODY>
				
					<TR>
						<TD vAlign="top" align="right" width="2%"></TD>
						<TD width="98%">
						
							<DIV id="Tables_chat"></DIV>
							<div id="show" style="DISPLAY: none" ><font color="#ff0000" size="2"><br><b>数据读取中....</b></font></div>
						</TD>
					</TR>
				</TBODY>
			</table>
    </div>
    </form>
        <script language="javascript">

            var yuser='<%=ChatName%>';
            var ysuser='<%=Request.QueryString["id"]%>';
            document.getElementById('show').style.display=''; 
            AjaxMethod.ListPeople('"+ysuser+"','"+yuser+"',get_chat);


        </script>
</body>
</html>
