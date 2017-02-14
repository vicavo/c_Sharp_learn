<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeadChat.aspx.cs" Inherits="qpoa.InfoSpeech.SeadChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<script>
            var yuser='<%=ChatName%>';
            var ysuser='<%=Request.QueryString["id"]%>';
			window.setInterval("AjaxMethod.Getchat('"+ysuser+"','"+yuser+"',get_chat)",2000);
				
			function get_chat(response)
			{
				//updatechat();
			
				if (response.value != null)
				{					
				
				var ds = response.value;
　　　　		
				var htmlstr="<table width=100% border=0 cellpadding=4 cellspacing=0>";　　
				for(var i=0; i<ds.Tables[0].Rows.length; i++)
　　　　		{
　　　　			htmlstr+="<tr>";　
　　　　			var time_table=ds.Tables[0].Rows[i].setime.toLocaleString().replace("年","-").replace("月","-").replace("日","");
　　　　　　		var sname_table=ds.Tables[0].Rows[i].seadname;
　　　　　　		var suser_table=ds.Tables[0].Rows[i].senduser;
　　　　　　		
　　　　　　		var aname_table=ds.Tables[0].Rows[i].atpname;
　　　　　　		var auser_table=ds.Tables[0].Rows[i].atpuser;
　　　　　　		
　　　　　　		var content_table=ds.Tables[0].Rows[i].content.replace('\n','<br>').replace(' ','&nbsp;&nbsp;');
　　　　　　		var id=ds.Tables[0].Rows[i].id;
　　　　　　		
　　　　　　		htmlstr+="<td>[<a href=javascript:void(0) onclick=parent.setuser('"+suser_table+"','"+sname_table+"')><font color=#FF00F7>"+sname_table+"</font></a>]对[<a href=javascript:void(0) onclick=parent.setuser('"+auser_table+"','"+aname_table+"')><font color=#0000FF>"+aname_table+"</font></a>]说："+content_table+"<font color=#FF0000>("+time_table+")</font></td></tr>";
　　　　　　		//htmlstr=htmlstr+"</tr>";
　　　　		}
　　　　			htmlstr+="</TABLE>";
　　　　			document.getElementById('Tables_chat').innerHTML=htmlstr;
　　　　			//window.Form1.content.value='';
　　　　			//window.Form1.content.focus();
　　　　			parent.Form1.btn_AddCity.value='发送(Enter)';
　				　	parent.Form1.btn_AddCity.disabled=false;
　				　	
　				　	document.getElementById('show').style.display='none'; 
　　　　		}
　　　　		
              
               parent.rform.scroll(0,1000);
　　　　		
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
							<div id="show" style="DISPLAY: none" ><font color="#ff0000" size="2"><br><b>数据读取中 .......</b></font></div>
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
            AjaxMethod.Getchat('"+ysuser+"','"+yuser+"',get_chat);


        </script>
</body>
</html>
