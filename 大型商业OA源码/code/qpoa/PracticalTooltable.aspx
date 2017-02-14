<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PracticalTooltable.aspx.cs" Inherits="qpoa.PracticalTool.PracticalTooltable" %>

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

		
		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/vote.gif" width=16px height=16px border=0>附件程序</a></H1>

			<asp:TreeView ID="TreeView7" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif"  Text="万年历" Value="gggg2" NavigateUrl="~/PracticalTool/calendar.htm" Target="rform"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/fldb.gif"  Text="世界时间" Value="gggg3" NavigateUrl="~/PracticalTool/worldtime.htm" Target="rform"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/url.gif"  Text="&lt;a href='../FreWebsite/Website.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;常用网址浏览&lt;/a&gt;" Value="gggg4" SelectAction="None"></asp:TreeNode>
            <asp:TreeNode ImageUrl="~/images/menu/fav.gif"  Text="&lt;a href='../PracticalTool/InfoPostAreaCodes.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;邮编区号&lt;/a&gt;" Value="gggg5" SelectAction="None"></asp:TreeNode>
            <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="日常查询" Value="gggg6"  NavigateUrl="~/PracticalTool/websiteshow.htm" Target="rform"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        
        
    <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif"  Text="万年历" Value="gggg2" NavigateUrl="~/PracticalTool/calendar.htm"  Target="_blank"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/fldb.gif"  Text="世界时间" Value="gggg3" NavigateUrl="~/PracticalTool/worldtime.htm"  Target="_blank"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/url.gif"  Text="&lt;a href='../FreWebsite/Website.aspx ' target='_blank'&gt;常用网址浏览&lt;/a&gt;" Value="gggg4" SelectAction="None"></asp:TreeNode>
            <asp:TreeNode ImageUrl="~/images/menu/fav.gif"  Text="&lt;a href='../PracticalTool/InfoPostAreaCodes.aspx ' target='_blank'&gt;邮编区号&lt;/a&gt;" Value="gggg5" SelectAction="None"></asp:TreeNode>
    <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="日常查询" Value="gggg6"  NavigateUrl="~/PracticalTool/websiteshow.htm" Target="_blank"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>    
    </form>
</body>
</html>
