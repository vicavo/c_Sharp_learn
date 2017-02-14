<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoSpeechtable.aspx.cs" Inherits="qpoa.InfoSpeechtable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>无标题页</title>
<script src="prototype.lite.js" type="text/javascript"></script>
<script src="moo.fx.js" type="text/javascript"></script>
<script src="moo.fx.pack.js" type="text/javascript"></script>
<style>
body {
	font:12px Arial, Helvetica, sans-serif;
	color: #000;
}
#container {
	width: 184px;
}
H1 {
	font-size: 11px;
	margin: 0px;
	width: 184px;
	cursor: pointer;
	height: 22px;
	line-height: 20px;	
}
H1 a {
	display: block;
	padding-top: 1px;
	padding-right: 8px;
	padding-bottom: 0px;
	padding-left: 8px;	
	width: 184px;
	color: #000;
	height: 22px;
	text-decoration: none;	
	moz-outline-style: none;
	background-image: url(title.gif);
	background-repeat: repeat-x;
}
.content{
	padding-left: 8px;
}


A:link
{
	font-size: 12px;
	color: #444659;
	text-decoration: none;
}	
		
A:visited
{
	font-size: 12px;
	color: #444659;
	text-decoration: none;
}	
		
A:active
{
	color: #000000;
	font-size: 12px;
	text-decoration: none;
}	
		
A:hover
{
	color: #000000;
	font-size: 12px;
	text-decoration: none;
}	


</style>
    
    
</head>
<body >
    <form id="form1" runat="server">

		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/training.gif" width=16px height=16px border=0>信息交流</a></H1>
		
			<asp:TreeView ID="TreeView4" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="&lt;a href='../InfoSpeech/Messages.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;内部消息&lt;/a&gt;" Value="dddd1" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="&lt;a href='../InfoSpeech/NbMailAccept.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;内部邮件&lt;/a&gt;" Value="dddd2" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="&lt;a href='../InfoSpeech/WbMail.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;外部邮件&lt;/a&gt;" Value="dddd3" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode Text="内部讨论区" Value="dddd4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/bbs.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif"  Text="&lt;a href='../InfoSpeech/InsideBBS.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;讨论区&lt;/a&gt;" Value="dddd4a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif"  Text="&lt;a href='../InfoSpeech/InsideBBSBig.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;讨论区类别&lt;/a&gt;" Value="dddd4b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="互动聊天" Value="dddd5" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/chatroom.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="&lt;a href='../InfoSpeech/chatcontent.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;互动聊天&lt;/a&gt;" Value="dddd5a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="&lt;a href='../InfoSpeech/chatName.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;聊天室管理&lt;/a&gt;" Value="dddd5b" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/netdisk.gif" Text="&lt;a href='../InfoSpeech/WebDisc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;网络硬盘&lt;/a&gt;" Value="dddd6"  SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="投票管理" Value="dddd7" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/vote.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="&lt;a href='../InfoSpeech/toupiao.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;投票浏览&lt;/a&gt;" Value="dddd7a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="&lt;a href='../InfoSpeech/toupiaobt.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;投票管理&lt;/a&gt;" Value="dddd7b" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="文件传阅" Value="dddd8" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/comm.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/comm.gif"  Text="&lt;a href='../InfoSpeech/JsInfoSend.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;接收文件&lt;/a&gt;" Value="dddd8" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/comm.gif"  Text="&lt;a href='../InfoSpeech/InfoSend.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;传阅文件&lt;/a&gt;" Value="dddd8" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    
                     <asp:TreeNode Expanded="False" SelectAction="Expand" Text="手机短信管理" Value="dddd9" ImageUrl="~/images/menu/mobile_sms.gif">
                         <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../InfoSpeech/MvToEnd.aspx ' target='rform' onclick='parent.UploadComplete();'>已发送短信</a>" Value="dddd9"  SelectAction="None"></asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../InfoSpeech/MvTo.aspx' target='rform' onclick='parent.UploadComplete();'>等待发送短信</a>" Value="dddd9"  SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif"  Text="<a href='../InfoSpeech/MvToBad.aspx ' target='rform' onclick='parent.UploadComplete();'>发送失败短信</a>" Value="dddd9" SelectAction="None">  </asp:TreeNode>
                    </asp:TreeNode> 
                    
                    
            </Nodes>
        </asp:TreeView>
        
        
	<asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="<a href='../InfoSpeech/Messages.aspx ' target='_blank'>内部消息</a>" Value="dddd1" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="<a href='../InfoSpeech/NbMailAccept.aspx ' target='_blank'>内部邮件</a>" Value="dddd2" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="<a href='../InfoSpeech/WbMail.aspx ' target='_blank'>外部邮件</a>" Value="dddd3" ></asp:TreeNode>
                    <asp:TreeNode Text="内部讨论区" Value="dddd4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/bbs.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif"  Text="<a href='../InfoSpeech/InsideBBS.aspx ' target='_blank'>讨论区</a>" Value="dddd4a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif"  Text="<a href='../InfoSpeech/InsideBBSBig.aspx ' target='_blank'>讨论区类别</a>" Value="dddd4b"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="互动聊天" Value="dddd5" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/chatroom.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="<a href='../InfoSpeech/chatcontent.aspx ' target='_blank'>互动聊天</a>" Value="dddd5a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="<a href='../InfoSpeech/chatName.aspx ' target='_blank'>聊天室管理</a>" Value="dddd5b" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/netdisk.gif" Text="<a href='../InfoSpeech/NbMailAccept.aspx ' target='_blank'>网络硬盘</a>" Value="dddd6"></asp:TreeNode>
                    <asp:TreeNode Text="投票管理" Value="dddd7" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/vote.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="<a href='../InfoSpeech/toupiao.aspx ' target='_blank'>投票浏览</a>" Value="dddd7a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="<a href='../InfoSpeech/toupiaobt.aspx ' target='_blank'>投票管理</a>" Value="dddd7b" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="文件传阅" Value="dddd8" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/comm.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/comm.gif"  Text="<a href='../InfoSpeech/JsInfoSend.aspx ' target='_blank'>接收文件</a>" Value="dddd8" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/comm.gif"  Text="<a href='../InfoSpeech/InfoSend.aspx ' target='_blank'>传阅文件</a>" Value="dddd8" ></asp:TreeNode>
                    </asp:TreeNode>
                    
                    
            </Nodes>
        </asp:TreeView>     
        

    </form>
</body>
</html>
