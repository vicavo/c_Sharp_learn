<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyAffairstable.aspx.cs"
    Inherits="qpoa.MyAffairstable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>

    <script>
function killErrors() {
return true;
}
window.onerror = killErrors;	
    </script>

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
                <img src="images/menu/netchat.gif" width="16px" height="16px" border="0">个人事务</a></h1>
        <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门通知" Value="1111b" ImageUrl="~/images/menu/notify.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/notify.gif" Text="&lt;a href='../MyAffairs/MyUnitNotic.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;部门通知浏览&lt;/a&gt;"
                        Value="1111b1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/notify.gif" Text="&lt;a href='../MyAffairs/UnitNotic.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;部门通知管理&lt;/a&gt;"
                        Value="1111b2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="公司通知" Value="1111c" ImageUrl="~/images/menu/news.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/news.gif" Text="&lt;a href='../MyAffairs/MyCompanyNotic.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;公司通知浏览&lt;/a&gt;"
                        Value="1111c1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/news.gif" Text="&lt;a href='../MyAffairs/CompanyNotic.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;公司通知管理&lt;/a&gt;"
                        Value="1111c2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子刊物" Value="1111d" ImageUrl="~/images/menu/file_folder.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="&lt;a href='../MyAffairs/MyElecBook.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;电子刊物浏览&lt;/a&gt;"
                        Value="1111d1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="&lt;a href='../MyAffairs/ElecBook.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;电子刊物管理&lt;/a&gt;"
                        Value="1111d2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人考勤" Value="1111e" ImageUrl="~/images/menu/attendance.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="&lt;a href='../MyAffairs/WorkTimeDj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;上下班登记&lt;/a&gt;"
                        Value="1111e6"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="&lt;a href='../MyAffairs/MyAttendance.aspx?type=3 ' target='rform' onclick='parent.UploadComplete();'&gt;出差登记&lt;/a&gt;"
                        Value="1111e4"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="&lt;a href='../MyAffairs/MyAttendance.aspx?type=4 ' target='rform' onclick='parent.UploadComplete();'&gt;加班登记&lt;/a&gt;"
                        Value="1111e5"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="&lt;a href='../MyAffairs/MyAttendance.aspx?type=1 ' target='rform' onclick='parent.UploadComplete();'&gt;病假登记&lt;/a&gt;"
                        Value="1111e2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="&lt;a href='../MyAffairs/MyAttendance.aspx?type=2 ' target='rform' onclick='parent.UploadComplete();'&gt;事假登记&lt;/a&gt;"
                        Value="1111e3"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="日程安排" Value="1111f" ImageUrl="~/images/menu/calendar.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/calendar.gif" Text="&lt;a href='../MyAffairs/MyCalendar.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的日程&lt;/a&gt;"
                        Value="1111f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/calendar.gif" Text="&lt;a href='../MyAffairs/MyCalendarJK.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;日程监控&lt;/a&gt;"
                        Value="1111f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作日志" Value="1111g" ImageUrl="~/images/menu/diary.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="&lt;a href='../MyAffairs/MyDiary.aspx' target='rform' onclick='parent.UploadComplete();'&gt;日志上报"
                        Value="1111g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="&lt;a href='../MyAffairs/MyDiaryCY.aspx' target='rform' onclick='parent.UploadComplete();'&gt;日志查阅"
                        Value="1111g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的会议" Value="1111h" ImageUrl="~/images/menu/meeting.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/meeting.gif" Text="&lt;a href='../MyAffairs/MyMetting.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的会议&lt;/a&gt;"
                        Value="1111h1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/vmeet.gif" Text="&lt;a href='../MyAffairs/MyNetMetting.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;网络会议&lt;/a&gt;"
                        Value="1111h3" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="通讯录管理" Value="1111i" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/address.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="&lt;a href='../MyAffairs/CompanyGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;公司通讯录&lt;/a&gt;"
                        Value="1111i1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="&lt;a href='../MyAffairs/MyGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;个人通讯录&lt;/a&gt;"
                        Value="1111i2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="&lt;a href='../MyAffairs/PublicGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;公共通讯录&lt;/a&gt;"
                        Value="1111i3"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="&lt;a href='../MyAffairs/GroupType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通讯录类别&lt;/a&gt;"
                        Value="1111i4"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="&lt;a href='../MyAffairs/Folders.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;个人文件柜&lt;/a&gt;"
                    Value="1111k" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人设置" Value="1111l" ImageUrl="~/images/menu/person_info.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="快捷菜单设置" Value="1111l1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../MyAffairs/MyReminded.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;用户提醒设置&lt;/a&gt;"
                        Value="1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../MyAffairs/SystemPassword.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;密码修改&lt;/a&gt;"
                        Value="1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../MyAffairs/Emailprv.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;邮件参数设置&lt;/a&gt;"
                        Value="1111l4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../MyAffairs/UseSpRemark.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;常用审批备注&lt;/a&gt;"
                        Value="1111l5" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../MyAffairs/OftenModle.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;常用模版设置&lt;/a&gt;"
                        Value="1111l6" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        <asp:TreeView ID="TreeView2" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门通知" Value="1111b" ImageUrl="~/images/menu/notify.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/notify.gif" Text="<a href='../MyAffairs/MyUnitNotic.aspx ' target='_blank'>部门通知浏览</a>"
                        Value="1111b1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/notify.gif" Text="<a href='../MyAffairs/UnitNotic.aspx ' target='_blank'>部门通知管理</a>"
                        Value="1111b2"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="公司通知" Value="1111c" ImageUrl="~/images/menu/news.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/news.gif" Text="<a href='../MyAffairs/MyCompanyNotic.aspx ' target='_blank'>公司通知浏览</a>"
                        Value="1111c1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/news.gif" Text="<a href='../MyAffairs/CompanyNotic.aspx ' target='_blank'>公司通知管理</a>"
                        Value="1111c2"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子刊物" Value="1111d" ImageUrl="~/images/menu/file_folder.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="<a href='../MyAffairs/MyElecBook.aspx ' target='_blank'>电子刊物浏览</a>"
                        Value="1111d1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="<a href='../MyAffairs/ElecBook.aspx ' target='_blank'>电子刊物管理</a>"
                        Value="1111d2"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人考勤" Value="1111e" ImageUrl="~/images/menu/attendance.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="<a href='../MyAffairs/WorkTimeDj.aspx ' target='_blank'>上下班登记</a>"
                        Value="1111e6"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="<a href='../MyAffairs/MyAttendance.aspx?type=3 ' target='_blank'>出差登记</a>"
                        Value="1111e4"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="<a href='../MyAffairs/MyAttendance.aspx?type=4 ' target='_blank'>加班登记</a>"
                        Value="1111e5"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="<a href='../MyAffairs/MyAttendance.aspx?type=1 ' target='_blank'>病假登记</a>"
                        Value="1111e2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/attendance.gif" Text="<a href='../MyAffairs/MyAttendance.aspx?type=2 ' target='_blank'>事假登记</a>"
                        Value="1111e3"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="日程安排" Value="1111f" ImageUrl="~/images/menu/calendar.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/calendar.gif" Text="<a href='../MyAffairs/MyCalendar.aspx ' target='_blank'>我的日程</a>"
                        Value="1111f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/calendar.gif" Text="<a href='../MyAffairs/MyCalendarJK.aspx ' target='_blank'>日程监控</a>"
                        Value="1111f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作日志" Value="1111g" ImageUrl="~/images/menu/diary.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="<a href='../MyAffairs/MyDiary.aspx' target='_blank'>日志上报"
                        Value="1111g"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="<a href='../MyAffairs/MyDiaryCY.aspx' target='_blank'>日志查阅"
                        Value="1111g"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的会议" Value="1111h" ImageUrl="~/images/menu/meeting.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/meeting.gif" Text="<a href='../MyAffairs/MyMetting.aspx ' target='_blank'>我的会议</a>"
                        Value="1111h1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/vmeet.gif" Text="<a href='../MyAffairs/MyNetMetting.aspx ' target='_blank'>网络会议</a>"
                        Value="1111h3"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="通讯录管理" Value="1111i" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/address.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="<a href='../MyAffairs/CompanyGroup.aspx ' target='_blank'>公司通讯录</a>"
                        Value="1111i1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="<a href='../MyAffairs/MyGroup.aspx ' target='_blank'>个人通讯录</a>"
                        Value="1111i2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="<a href='../MyAffairs/PublicGroup.aspx ' target='_blank'>公共通讯录</a>"
                        Value="1111i3"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/address.gif" Text="<a href='../MyAffairs/GroupType.aspx ' target='_blank'>通讯录类别</a>"
                        Value="1111i4"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif" Text="<a href='../MyAffairs/Folders.aspx ' target='_blank'>个人文件柜</a>"
                    Value="1111k"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人设置" Value="1111l" ImageUrl="~/images/menu/person_info.gif">
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="快捷菜单设置" Value="1111l1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../MyAffairs/MyReminded.aspx ' target='_blank'>用户提醒设置</a>"
                        Value="1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../MyAffairs/SystemPassword.aspx ' target='_blank'>密码修改</a>"
                        Value="1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../MyAffairs/Emailprv.aspx ' target='_blank'>邮件参数设置</a>"
                        Value="1111l4"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../MyAffairs/UseSpRemark.aspx ' target='_blank'>常用审批备注</a>"
                        Value="1111l5"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../MyAffairs/OftenModle.aspx ' target='_blank'>常用模版设置</a>"
                        Value="1111l6"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>
