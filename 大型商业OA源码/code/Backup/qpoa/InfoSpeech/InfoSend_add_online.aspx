<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoSend_add_online.aspx.cs" Inherits="qpoa.InfoSpeech.InfoSend_add_online" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>网络办公系统</title>
		 		<META HTTP-EQUIV="Pragma" CONTENT="no-cache">
		<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache">
		<META HTTP-EQUIV="Expires" CONTENT="0">
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
		<base target=_self />	
		<script src="../public/ParametersOnClient.js" ></script>
				<script>
			 //******************************************************************************************\\
			//code by qiupeng , you can copy code, but the author to retain information please;(2006-11-5)\\
		   //**********************************************************************************************\\


		function chknull()
		{
			
			document.all.FramerControl1.caption = "在线编辑：<%=forname%>";
			var serverpath=window.location.host+v_online_path; 
			
			var num=Math.random();
			document.all.FramerControl1.Open("http://"+serverpath+"/InfoSpeech/InfoSendFj/<%=forfile%>?tmp="+num+"", true);
			//document.all.FramerControl1.Open("http://192.168.1.111/SystemManage/DocumentModle/20081222315147148009.doc?tmp="+num+"", true);
			//alert("http://"+serverpath+"/SystemManage/DocumentModle/<%=forfile%>?tmp="+num+"");
			
	
			
		}              
 

	
//		function Track()
//		{
//	        document.all.FramerControl1.SetTrackRevisions(1);
//			document.all.FramerControl1.SetCurrUserName("<%=realname%>");	
//          document.all.FramerControl1.SetCurrTime("2006:02:07 11:11:11");

//		}	
			
	
		            
      
        function SaveToWeb()
        {
          showwait();	
			document.all.FramerControl1.SetTrackRevisions(0);
            var serverpath=window.location.host+v_online_path; 
            document.all.FramerControl1.HttpInit();
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","李局长");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "bbb.doc");
    
              
           document.all.FramerControl1.HttpPost("http://"+serverpath+"/InfoSpeech/InfoSend_add_online_save.aspx?file=<%=forfile%>&number=<%=number%>&forname=<%=forname%>");
      
	
      
        } 
        
        function Track(){
            document.all.FramerControl1.SetTrackRevisions(1);
			document.all.FramerControl1.SetCurrUserName("<%=realname%>");	
        }
        function UnTrack(){
            document.all.FramerControl1.SetTrackRevisions(0);
          
        }

        function print(){
        document.all.FramerControl1.PrintOut();
           
         }
         function printview(){
        
        document.all.FramerControl1.PrintPreview();
           
         }
         function printviewexit(){
        
        document.all.FramerControl1.PrintPreviewExit();
           
         }

        
        function clearTrack(){
           document.all.FramerControl1.SetTrackRevisions(4);
        }	
        
       
        
		</script>

</HEAD>
	<body onload="chknull();">
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"-->
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　在线编辑</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    			<table height="26" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
											<INPUT style="WIDTH: 100px" onclick="Track()" type="button" value="进入留痕" id="Button8" runat="server">
											<INPUT style="WIDTH: 100px" onclick="UnTrack()" type="button" value="取消留痕" id="Button9" runat="server">
											<INPUT style="WIDTH: 100px" onclick="clearTrack()" type="button" value="清除留痕" id="Button7" runat="server">
											<INPUT style="WIDTH: 100px" type="button" value="打印文档" id="Button6" language="javascript" onclick="return print()" size="" runat="server">
											</td>
										</tr>
										
										
									</table>
						<table cellSpacing="1" cellPadding="4" width="100%" bgColor="#d8e1e8" border="0">
							
							<tr bgColor="#f3f8fe">
								<td align="center" style="height: 8px">
								<OBJECT id="FramerControl1" codeBase="dsoframer.ocx" height="600px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
                            <PARAM NAME="_ExtentX" VALUE="16960">
                            <PARAM NAME="_ExtentY" VALUE="13600">
                            <PARAM NAME="BorderColor" VALUE="-2147483632">
                            <PARAM NAME="BackColor" VALUE="-2147483643">
                            <PARAM NAME="ForeColor" VALUE="-2147483640">
                            <PARAM NAME="TitlebarColor" VALUE="-2147483635">
                            <PARAM NAME="TitlebarTextColor" VALUE="-2147483634">
                            <PARAM NAME="BorderStyle" VALUE="1">
                            <PARAM NAME="Titlebar" VALUE="0">
                            <PARAM NAME="Toolbars" VALUE="1">
                            <PARAM NAME="Menubar" VALUE="1">
                        </OBJECT>
								</td>
							</tr>
						</table>
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="39%">&nbsp;</td>
											<td width="9%">
                                                <asp:Button ID="Button1" runat="server" Text="提　交" OnClick="Button1_Click" />
												</td>
											<td width="52%">
                                                <input id="Button2" type="button" value="关　闭" OnClick="window.close()"/></td>
										</tr>
									</table>			
									
			    </td>
				</tr>
				<tr>
					<td height="22" background="../images/show_02.gif">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>