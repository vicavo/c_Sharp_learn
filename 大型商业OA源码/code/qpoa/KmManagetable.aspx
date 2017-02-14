<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmManagetable.aspx.cs" Inherits="qpoa.KmManagetable" %>

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

		
		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/icon.gif" width=16px height=16px border=0>知识管理</a></H1>

			<asp:TreeView ID="TreeView7" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode ImageUrl="~/images/menu/loginlog.gif"  Text="&lt;a href='../KmManage/KmBigType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识大类&lt;/a&gt;" Value="jjjj1" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/loginlog.gif"  Text="&lt;a href='../KmManage/KmLittleType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识小类&lt;/a&gt;" Value="jjjj2" SelectAction="None"></asp:TreeNode>
                      <asp:TreeNode ImageUrl="~/images/menu/folder.gif"  Text="&lt;a href='../KmManage/KmTitle.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的知识&lt;/a&gt;" Value="jjjj3" NavigateUrl="~/KmManage/KmTitle.aspx" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/list.gif"  Text="&lt;a href='../KmManage/KmTitlePh.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识排行&lt;/a&gt;" Value="jjjj4" NavigateUrl="~/KmManage/KmTitlePh.aspx" SelectAction="None"></asp:TreeNode>
                          <asp:TreeNode ImageUrl="~/images/menu/zhu.gif"  Text="&lt;a href='../KmManage/KmMap.aspx' target='rform' onclick='parent.UploadComplete();'&gt;知识地图&lt;/a&gt;" Value="jjjj5" NavigateUrl="~/KmManage/KmMap.aspx" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/search.gif"  Text="&lt;a href='../KmManage/KmSearch.aspx?key=0 ' target='rform' onclick='parent.UploadComplete();'&gt;知识检索&lt;/a&gt;" Value="jjjj6" NavigateUrl="~/KmManage/KmSearch.aspx?key=0" SelectAction="None"></asp:TreeNode>
                              <asp:TreeNode ImageUrl="~/images/menu/bbs.gif"  Text="&lt;a href='../KmManage/KmBbsAll.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识互动&lt;/a&gt;" Value="jjjj7" NavigateUrl="~/KmManage/KmBbsAll.aspx" SelectAction="None"></asp:TreeNode>
                              <asp:TreeNode ImageUrl="~/images/menu/wmail.gif"  Text="&lt;a href='../KmManage/KmTitleSp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识审批&lt;/a&gt;" Value="jjjj8" NavigateUrl="~/KmManage/KmTitleSp.aspx" SelectAction="None"></asp:TreeNode>
                              <asp:TreeNode ImageUrl="~/images/menu/userlist1.gif"  Text="&lt;a href='../KmManage/KmManger.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;知识管理员&lt;/a&gt;" Value="jjjj9" NavigateUrl="~/KmManage/KmManger.aspx" SelectAction="None"></asp:TreeNode>
                              
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
