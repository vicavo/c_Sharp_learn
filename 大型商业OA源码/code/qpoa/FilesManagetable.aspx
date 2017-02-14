<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilesManagetable.aspx.cs" Inherits="qpoa.FilesManagetable" %>

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
<body class="newbody">
    <form id="form1" runat="server">

	
		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/hrms.gif" width=16px height=16px border=0>档案管理</a></H1>
		
			<asp:TreeView ID="TreeView5" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="&lt;a href='../FilesManage/FilesRoom.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;卷库管理</a>" Value="hhhh1" ></asp:TreeNode>
                    
                   
                        <asp:TreeNode ImageUrl="~/images/menu/rms.gif"  Text="&lt;a href='../FilesManage/FilesManage.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;案卷管理</a>" Value="hhhh2" ></asp:TreeNode>
                    
                        <asp:TreeNode ImageUrl="~/images/menu/infofind.gif"  Text="&lt;a href='../FilesManage/FilesManageBook.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;文件管理</a>" Value="hhhh3" ></asp:TreeNode>
                       
                                  
                    
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="案卷借阅" Value="hhhh4" ImageUrl="~/images/menu/empphoto.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/wmail.gif"  Text="&lt;a href='../FilesManage/FilesManageJy.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;案卷借阅</a>" Value="hhhh4a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/wmail.gif"  Text="&lt;a href='../FilesManage/FilesManageSp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;借阅审批</a>" Value="hhhh4b"></asp:TreeNode>
                    </asp:TreeNode>
                    
                    <asp:TreeNode ImageUrl="~/images/menu/finance.gif"  Text="档案统计" Value="hhhh5" Expanded="False" SelectAction="Expand">
                        <asp:TreeNode Text="&lt;a href='../FilesManage/FilesManageJyTj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;借阅统计</a>"  Value="hhhh5a"  ImageUrl="~/images/menu/finance.gif" ></asp:TreeNode>
                        <asp:TreeNode Text="&lt;a href='../FilesManage/FilesManageAjTj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;案卷统计</a>"  Value="hhhh5b"  ImageUrl="~/images/menu/finance.gif" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/recycle.gif"  Text="&lt;a href='../FilesManage/FilesManageBookXh.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;档案销毁</a>" Value="hhhh6" ></asp:TreeNode>
            <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="基础数据设置" Value="hhhh7" ImageUrl="~/images/menu/person_info.gif">
 <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=1' target='rform' onclick='parent.UploadComplete();'&gt;案卷密级</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=1"></asp:TreeNode>
<asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=2 ' target='rform' onclick='parent.UploadComplete();'&gt;凭证类别</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=2"></asp:TreeNode>
<asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=6 ' target='rform' onclick='parent.UploadComplete();'&gt;密级</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=6"></asp:TreeNode>
<asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=3' target='rform' onclick='parent.UploadComplete();'&gt;紧急等级</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=3"></asp:TreeNode>
<asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=4 ' target='rform' onclick='parent.UploadComplete();'&gt;文件分类</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=4"></asp:TreeNode>
<asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../FilesManage/FilesData.aspx?type=5 ' target='rform' onclick='parent.UploadComplete();'&gt;公文类别</a>" Value="hhhh7" NavigateUrl="~/FilesManage/FilesData.aspx?type=5"></asp:TreeNode>
                    </asp:TreeNode>
            
            
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
