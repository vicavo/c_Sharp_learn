<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreWebsitetable.aspx.cs" Inherits="qpoa.FreWebsitetable" %>

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
<body>
    <form id="form1" runat="server">

		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/url.gif" width=16px height=16px border=0>常用网址</a></H1>
		
			<asp:TreeView ID="TreeView8" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/url.gif" NavigateUrl="~/FreWebsite/Website.aspx" 
                        Text="常用网址浏览" Value="hhhh1"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>

    </form>
</body>
</html>
