<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemManagetable.aspx.cs"
    Inherits="qpoa.SystemManagetable" %>

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
                <img src="images/menu/system.gif" width="16px" height="16px" border="0">系统管理</a></h1>
        <asp:TreeView ID="TreeView9" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="iiiia1" ImageUrl="~/images/menu/score.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealSp.aspx ' target='rform' onclick='parent.UploadComplete();'>印章审批</a>"
                        Value="iiiia1a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="印章维护" Value="iiiia1b" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealManage.aspx ' target='rform' onclick='parent.UploadComplete();'>私章维护</a>"
                            Value="iiiia1b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealManagePb.aspx ' target='rform' onclick='parent.UploadComplete();'>公章维护</a>"
                            Value="iiiia1b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealUseLog.aspx ' target='rform' onclick='parent.UploadComplete();'>印章使用日志</a>"
                        Value="iiiia1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="<a href='../SystemManage/DocumentModle.aspx ' target='rform' onclick='parent.UploadComplete();'>红头文件管理</a>"
                    Value="iiii3" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="<a href='../SystemManage/username.aspx ' target='rform' onclick='parent.UploadComplete();'>用户管理</a>"
                    Value="iiii4" ImageUrl="~/images/menu/comm.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="<a href='../SystemManage/Respon.aspx ' target='rform' onclick='parent.UploadComplete();'>角色管理</a>"
                    Value="iiii5" ImageUrl="~/images/menu/meeting.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/info.gif" SelectAction="None" Text="<a href='../SystemManage/UnitName.aspx ' target='rform' onclick='parent.UploadComplete();'>部门管理</a>"
                    Value="iiii6"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/hrms.gif" SelectAction="None" Text="<a href='../SystemManage/PostName.aspx ' target='rform' onclick='parent.UploadComplete();'>职位管理</a>"
                    Value="iiii7"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/info_query.gif" SelectAction="None" Text="<a href='../SystemManage/FjKey.aspx ' target='rform' onclick='parent.UploadComplete();'>附件类型</a>"
                    Value="iiii9"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" SelectAction="None" Text="<a href='../SystemManage/SystemLog.aspx ' target='rform' onclick='parent.UploadComplete();'>系统日志</a>"
                    Value="iiii8"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="手机短信管理" Value="iiiia1d"
                    ImageUrl="~/images/menu/mobile_sms.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_Update.aspx ' target='rform' onclick='parent.UploadComplete();'>是否启动手机短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_SeadedOut.aspx ' target='rform' onclick='parent.UploadComplete();'>已发送短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_Out.aspx ' target='rform' onclick='parent.UploadComplete();'>等待发送短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_BadOut.aspx ' target='rform' onclick='parent.UploadComplete();'>发送失败短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_In.aspx ' target='rform' onclick='parent.UploadComplete();'>接收短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="iiiia1" ImageUrl="~/images/menu/score.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealSp.aspx ' target='_blank'>印章审批</a>"
                        Value="iiiia1a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="印章维护" Value="iiiia1b" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealManage.aspx ' target='_blank'>私章维护</a>"
                            Value="iiiia1b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealManagePb.aspx ' target='_blank'>公章维护</a>"
                            Value="iiiia1b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif" Text="<a href='../SystemManage/SealUseLog.aspx ' target='_blank'>印章使用日志</a>"
                        Value="iiiia1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="<a href='../SystemManage/DocumentModle.aspx ' target='_blank'>红头文件管理</a>"
                    Value="iiii3" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="<a href='../SystemManage/username.aspx ' target='_blank'>用户管理</a>"
                    Value="iiii4" ImageUrl="~/images/menu/comm.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="<a href='../SystemManage/Respon.aspx ' target='_blank'>角色管理</a>"
                    Value="iiii5" ImageUrl="~/images/menu/meeting.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/info.gif" SelectAction="None" Text="<a href='../SystemManage/UnitName.aspx ' target='_blank'>部门管理</a>"
                    Value="iiii6"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/hrms.gif" SelectAction="None" Text="<a href='../SystemManage/PostName.aspx ' target='_blank'>职位管理</a>"
                    Value="iiii7"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/info_query.gif" SelectAction="None" Text="<a href='../SystemManage/FjKey.aspx ' target='_blank'>附件类型</a>"
                    Value="iiii9"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" SelectAction="None" Text="<a href='../SystemManage/SystemLog.aspx ' target='_blank'>系统日志</a>"
                    Value="iiii8"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="手机短信管理" Value="iiiia1d"
                    ImageUrl="~/images/menu/mobile_sms.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_Update.aspx ' target='_blank' onclick='parent.UploadComplete();'>是否启动手机短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_SeadedOut.aspx ' target='_blank' onclick='parent.UploadComplete();'>已发送短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_Out.aspx ' target='_blank' onclick='parent.UploadComplete();'>等待发送短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_BadOut.aspx ' target='_blank' onclick='parent.UploadComplete();'>发送失败短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/mobile_sms.gif" Text="<a href='../SystemManage/Sms_In.aspx ' target='_blank' onclick='parent.UploadComplete();'>接收短信</a>"
                        Value="iiiia1d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
