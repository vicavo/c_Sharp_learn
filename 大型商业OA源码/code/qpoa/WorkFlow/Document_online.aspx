<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Document_online.aspx.cs"
    Inherits="qpoa.WorkFlow.Document_online" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>网络办公系统</title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script src="../public/ParametersOnClient.js"></script>

    <script>
			 //******************************************************************************************\\
			//code by qiupeng , you can copy code, but the author to retain information please;(2006-11-5)\\
		   //**********************************************************************************************\\


		function chknull()
		{
			
			document.all.FramerControl1.caption = "在线编辑：<%=forname%>";
			var serverpath=window.location.host+v_online_path; 
			
			var num=Math.random();
			document.all.FramerControl1.Open("http://"+serverpath+"/WorkFlow/AddWorkFlowFj/<%=forfile%>?tmp="+num+"", true);
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
    
              
           document.all.FramerControl1.HttpPost("http://"+serverpath+"/WorkFlow/Document_online_save.aspx?file=<%=forfile%>&number=<%=number%>&forname=<%=forname%>");
      
	
      
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
        
		 function OpenToWeb()
		 {
		 
			if (document.getElementById('DropDownList1').value=="请选择")
			{
				alert("请先选择红头文件！"); 
				return(false); 
			} 
			else
			{
			    if (!confirm("插入红头文件到光标停留处？"))
                return false;
                
				var openurl = document.getElementById('DropDownList1').value; 
				var serverpath=window.location.host+v_online_path; 
				
				document.all.FramerControl1.InSertFile("http://"+serverpath+"/SystemManage/DocumentModle/"+openurl+"",0);
			}
		
    
		 }        
        
        function openyz()
        {
            //控件宽
            var aw = 420;
            //控件高
            var ah = 320;
            //计算控件水平位置
            var al = (screen.width - aw)/2-100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            
            mytop=screen.availHeight-500;
            myleft=200;
            window.open("WorkFlowListSpYz.aspx?Number=<%=number%>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
       
        }
 
 
        function OpenSealToWeb(name){
           var serverpath=window.location.host+v_online_path; 
           document.all.FramerControl1.InSertFile("http://"+serverpath+"/WorkFlow/CompanySeal/"+name+"",8);
        }	
    </script>

</head>
<body onload="chknull();">
    <form id="Form1" method="post" runat="server">
        <!--#include file="../public/public.js"-->
        <!--#include file="../public/pleasewait.htm"-->
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    在线编辑</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center">
                    <table height="26" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <input style="width: 84px" onclick="openyz()" type="button" value="我的印章" id="Button10"
                                    runat="server">
                                <input style="width: 100px" onclick="Track()" type="button" value="进入留痕" id="Button8"
                                    runat="server">
                                <input style="width: 100px" onclick="UnTrack()" type="button" value="取消留痕" id="Button9"
                                    runat="server">
                                <input style="width: 100px" onclick="clearTrack()" type="button" value="清除留痕" id="Button7"
                                    runat="server">
                                <input style="width: 100px" type="button" value="打印文档" id="Button6" language="javascript"
                                    onclick="return print()" size="" runat="server">
                                <input type="button" value="插入红头文件" onclick="OpenToWeb()" style="width: 100px;" id="Button3"
                                    runat="server">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="208px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <table cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
                        <tr bgcolor="#f3f8fe">
                            <td align="center" style="height: 8px">
                                <object id="FramerControl1" codebase="dsoframer.ocx" height="600px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
                                    <param name="_ExtentX" value="16960">
                                    <param name="_ExtentY" value="13600">
                                    <param name="BorderColor" value="-2147483632">
                                    <param name="BackColor" value="-2147483643">
                                    <param name="ForeColor" value="-2147483640">
                                    <param name="TitlebarColor" value="-2147483635">
                                    <param name="TitlebarTextColor" value="-2147483634">
                                    <param name="BorderStyle" value="1">
                                    <param name="Titlebar" value="0">
                                    <param name="Toolbars" value="1">
                                    <param name="Menubar" value="1">
                                </object>
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td width="39%">
                                &nbsp;</td>
                            <td width="9%">
                                <asp:Button ID="Button1" runat="server" Text="提　交" OnClick="Button1_Click" />
                            </td>
                            <td width="52%">
                                <input id="Button2" type="button" value="关　闭" onclick="window.close()" /></td>
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
</html>
