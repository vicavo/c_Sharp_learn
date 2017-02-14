<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProManagetable.aspx.cs"
    Inherits="qpoa.ProManagetable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
        <h1 class="title" align="left">
            <a href="javascript:void(0)">
                <img src="images/menu/pro.gif" width="16px" height="16px" border="0">项目管理</a></h1>
        <asp:TreeView ID="TreeView7" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode ImageUrl="~/images/menu/pro.gif" Text="&lt;a href='../ProManage/ProManageMG.aspx' target='rform' onclick='parent.UploadComplete();'&gt;项目创建&lt;/a&gt;"
                    Value="kkkk1" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/vote.gif" Text="&lt;a href='../ProManage/ProManageLL.aspx' target='rform' onclick='parent.UploadComplete();'&gt;项目浏览&lt;/a&gt;"
                    Value="kkkk2" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/icon.gif" Text="&lt;a href='../ProManage/ProManageGG.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目公告&lt;/a&gt;"
                    Value="kkkk3" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/infofind.gif" Text="&lt;a href='../ProManage/ProManageJD.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目进度&lt;/a&gt;"
                    Value="kkkk8" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/asset.gif" Text="&lt;a href='../ProManage/ProManageZY.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目资源&lt;/a&gt;"
                    Value="kkkk4" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="&lt;a href='../ProManage/ProManageYS.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目预算&lt;/a&gt;"
                    Value="kkkk5" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../ProManage/ProManageRW.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;任务计划&lt;/a&gt;"
                    Value="kkkk6" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/pro.gif" Text="&lt;a href='../ProManage/ProManageWB.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目外包&lt;/a&gt;"
                    Value="kkkk7" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/Menu49.gif" Text="&lt;a href='../ProManage/ProManageLR.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;项目利润&lt;/a&gt;"
                    Value="kkkk9" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/Menu50.gif" Text="&lt;a href='../ProManage/ProManageFY.aspx?XmName=' target='rform' onclick='parent.UploadComplete();'&gt;费用报销&lt;/a&gt;"
                    Value="kkkka1" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/Menu50.gif" Text="&lt;a href='../ProManage/ProManageFYGL.aspx' target='rform' onclick='parent.UploadComplete();'&gt;报销管理&lt;/a&gt;"
                    Value="kkkka2" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数据字典" Value="kkkka3" ImageUrl="~/images/menu/winexe.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=9 '  target='rform' onclick='parent.UploadComplete();' &gt;项目类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=1 '  target='rform' onclick='parent.UploadComplete();' &gt;评审级别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=2 '  target='rform' onclick='parent.UploadComplete();' &gt;公告类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=8 '  target='rform' onclick='parent.UploadComplete();' &gt;项目阶段&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=3 '  target='rform' onclick='parent.UploadComplete();' &gt;预算类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;资源类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=5'  target='rform' onclick='parent.UploadComplete();' &gt;报销类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=6 '  target='rform' onclick='parent.UploadComplete();' &gt;任务类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../ProManage/ProData.aspx?type=7 '  target='rform' onclick='parent.UploadComplete();' &gt;外包类别&lt;/a&gt;"
                        Value="kkkka3" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
