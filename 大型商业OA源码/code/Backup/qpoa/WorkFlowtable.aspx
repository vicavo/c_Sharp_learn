<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowtable.aspx.cs" Inherits="qpoa.WorkFlowtable" %>

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

		<H1 class="title" align=left><A href="javascript:void(0)"><IMG src="images/menu/workflow.gif" width=16px height=16px border=0>工作流程</a></H1>

			<asp:TreeView ID="TreeView2" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
            
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="bbbb1" ImageUrl="~/images/menu/infofind.gif">
                        <asp:TreeNode Text="&lt;a href='../WorkFlow/YinZhang.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的印章&lt;/a&gt;" Value="bbbb1a" ImageUrl="~/images/menu/infofind.gif" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/infofind.gif"  Text="&lt;a href='../WorkFlow/SealUseLog.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;印章使用记录&lt;/a&gt;" Value="bbbb1b" SelectAction="None">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="表单定义" Value="bbbb2" ImageUrl="~/images/menu/calendar2.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif" NavigateUrl="~/WorkFlow/DIYForm.aspx"   Text="&lt;a href='../WorkFlow/DIYForm.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;表单设计&lt;/a&gt;" Value="bbbb2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif"  Text="&lt;a href='../WorkFlow/FormType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;表单类别&lt;/a&gt;" Value="bbbb2b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode  Text="&lt;a href='../WorkFlow/WorkFlowName.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作流管理" Value="bbbb3" ImageUrl="~/images/menu/info_query.gif" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode  Text="工作管理" Value="bbbb4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/workflow.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/AddWorkFlow.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;新建工作&lt;/a&gt;" Value="bbbb4a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/WorkFlowList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;待办工作&lt;/a&gt;" Value="bbbb4b" SelectAction="None"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/WorkFlowSearch.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作查询&lt;/a&gt;" Value="bbbb4c" SelectAction="None"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/WorkFlowJk.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作监控&lt;/a&gt;" Value="bbbb4d" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/WorkFlowNodeGD.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;归档工作&lt;/a&gt;" Value="bbbb4e" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="&lt;a href='../WorkFlow/WorkFlowWtUsername.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;委托设置&lt;/a&gt;" Value="bbbb4f" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
	
	
	

        		<asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
            
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="bbbb1" ImageUrl="~/images/menu/infofind.gif">
                        <asp:TreeNode Text="<a href='../WorkFlow/YinZhang.aspx ' target='_blank'>我的印章</a>" Value="bbbb1a" ImageUrl="~/images/menu/infofind.gif"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/infofind.gif"  Text="<a href='../WorkFlow/SealUseLog.aspx ' target='_blank'>印章使用记录</a>" Value="bbbb1b">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="表单定义" Value="bbbb2" ImageUrl="~/images/menu/calendar2.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif" NavigateUrl="~/WorkFlow/DIYForm.aspx"   Text="<a href='../WorkFlow/YinZhang.aspx ' target='_blank'>表单设计</a>" Value="bbbb2a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif"  Text="<a href='../WorkFlow/FormType.aspx ' target='_blank'>表单类别</a>" Value="bbbb2b" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode  Text="<a href='../WorkFlow/WorkFlowName.aspx ' target='_blank'>工作流管理" Value="bbbb3" ImageUrl="~/images/menu/info_query.gif" ></asp:TreeNode>
                    <asp:TreeNode  Text="工作管理" Value="bbbb4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/workflow.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/AddWorkFlow.aspx ' target='_blank'>新建工作</a>" Value="bbbb4a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/WorkFlowList.aspx ' target='_blank'>待办工作</a>" Value="bbbb4b"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/WorkFlowSearch.aspx ' target='_blank'>工作查询</a>" Value="bbbb4c"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/WorkFlowJk.aspx ' target='_blank'>工作监控</a>" Value="bbbb4d" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/WorkFlowNodeGD.aspx ' target='_blank'>归档工作</a>" Value="bbbb4e" ></asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="<a href='../WorkFlow/WorkFlowWtUsername.aspx ' target='_blank'>委托设置</a>" Value="bbbb4f"></asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

    </form>
</body>
</html>
