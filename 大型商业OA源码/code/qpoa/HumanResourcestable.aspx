<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HumanResourcestable.aspx.cs" Inherits="qpoa.HumanResourcestable" %>

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

	
		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/hrms.gif" width=16px height=16px border=0>人力资源</a></H1>
		
			<asp:TreeView ID="TreeView5" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事档案" Value="eeee1" ImageUrl="~/images/menu/hrms.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;档案管理&lt;/a&gt;" Value="eeee1a" SelectAction="None"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="&lt;a href='../HumanResources/EmpContract.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;人事合同&lt;/a&gt;" Value="eeee1b" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="考勤批示" Value="eeee2" ImageUrl="~/images/menu/attendance.gif">
                    
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="&lt;a href='../HumanResources/MyAttendanceSp.aspx?type=3' target='rform' onclick='parent.UploadComplete();'&gt;出差审批&lt;/a&gt;" Value="eeee2c" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="&lt;a href='../HumanResources/MyAttendanceSp.aspx?type=4' target='rform' onclick='parent.UploadComplete();'&gt;加班审批&lt;/a&gt;" Value="eeee2d" SelectAction="None" ></asp:TreeNode>
                       <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="&lt;a href='../HumanResources/MyAttendanceSp.aspx?type=1' target='rform' onclick='parent.UploadComplete();'&gt;病假审批&lt;/a&gt;" Value="eeee2a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="&lt;a href='../HumanResources/MyAttendanceSp.aspx?type=2 ' target='rform' onclick='parent.UploadComplete();'&gt;事假审批&lt;/a&gt;" Value="eeee2b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    
                   
                        <asp:TreeNode ImageUrl="~/images/menu/finance.gif"  Text="&lt;a href='../HumanResources/TjProject.aspx?Realname=&amp;Unit=&amp;start=&amp;last= ' target='rform' onclick='parent.UploadComplete();'&gt;考勤统计&lt;/a&gt;" Value="eeee9a" SelectAction="None" ></asp:TreeNode>
                       
                                  
                    
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="薪资管理" Value="eeee6" ImageUrl="~/images/menu/pro.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="&lt;a href='../HumanResources/SalariesAdd.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;薪资录入&lt;/a&gt;" Value="eeee6a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="&lt;a href='../HumanResources/SalariesData.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;薪资数据&lt;/a&gt;" Value="eeee6b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="&lt;a href='../HumanResources/SaXzJobs.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计时工种&lt;/a&gt;" Value="eeee6c"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="&lt;a href='../HumanResources/SaXzPieces.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计件产品&lt;/a&gt;" Value="eeee6d" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="&lt;a href='../HumanResources/SaXzPiecesPro.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计件工序&lt;/a&gt;" Value="eeee6e" ></asp:TreeNode>
                    </asp:TreeNode>
                    
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="&lt;a href='../HumanResources/TrainingLog.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;培训记录&lt;/a&gt;" Value="eeee4" SelectAction="None" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="&lt;a href='../HumanResources/IncentiveLog.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;奖惩记录&lt;/a&gt;" Value="eeee5" SelectAction="None"></asp:TreeNode>
            <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="基础设置" Value="eeee8" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="考勤设置" Value="eeee8a" Expanded="False" SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../HumanResources/WorkTime.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;上下班时间&lt;/a&gt;" Value="eeee8a" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="&lt;a href='../HumanResources/WorkTimeJx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;登记间歇时间&lt;/a&gt;" Value="eeee8a">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="&lt;a href='../HumanResources/SalariesSet.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;薪资设置&lt;/a&gt;" Value="eeee8b" SelectAction="None" ></asp:TreeNode>
                     
                    </asp:TreeNode>
            
            
            </Nodes>
        </asp:TreeView>
    
    
    
<asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事档案" Value="eeee1" ImageUrl="~/images/menu/hrms.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif" Text="<a href='../HumanResources/Employee.aspx ' target='_blank'>档案管理</a>" Value="eeee1a"  ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="<a href='../HumanResources/EmpContract.aspx ' target='_blank'>人事合同</a>" Value="eeee1b" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="考勤批示" Value="eeee2" ImageUrl="~/images/menu/attendance.gif">
                    
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="<a href='../HumanResources/MyAttendanceSp.aspx?type=3' target='_blank'>出差审批</a>" Value="eeee2c" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="<a href='../HumanResources/MyAttendanceSp.aspx?type=4' target='_blank'>加班审批</a>" Value="eeee2d" ></asp:TreeNode>
                       <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="<a href='../HumanResources/MyAttendanceSp.aspx?type=1' target='_blank'>病假审批</a>" Value="eeee2a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="<a href='../HumanResources/MyAttendanceSp.aspx?type=2 ' target='_blank'>事假审批</a>" Value="eeee2b"></asp:TreeNode>
                    </asp:TreeNode>
                    
                   
                        <asp:TreeNode ImageUrl="~/images/menu/finance.gif"  Text="<a href='../HumanResources/TjProject.aspx?Realname=&Unit=&start=&last= ' target='_blank'>考勤统计</a>" Value="eeee9a" ></asp:TreeNode>
                       
                                  
                    
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="薪资管理" Value="eeee6" ImageUrl="~/images/menu/pro.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="<a href='../HumanResources/SalariesAdd.aspx ' target='_blank'>薪资录入</a>" Value="eeee6a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="<a href='../HumanResources/SalariesData.aspx ' target='_blank'>薪资数据</a>" Value="eeee6b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="<a href='../HumanResources/SaXzJobs.aspx ' target='_blank'>计时工种</a>" Value="eeee6c"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="<a href='../HumanResources/SaXzPieces.aspx ' target='_blank'>计件产品</a>" Value="eeee6d" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/pro.gif"  Text="<a href='../HumanResources/SaXzPiecesPro.aspx ' target='_blank'>计件工序</a>" Value="eeee6e" ></asp:TreeNode>
                    </asp:TreeNode>
                    
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="<a href='../HumanResources/TrainingLog.aspx ' target='_blank'>培训记录</a>" Value="eeee4" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="<a href='../HumanResources/IncentiveLog.aspx ' target='_blank'>奖惩记录</a>" Value="eeee5"></asp:TreeNode>
            <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="基础设置" Value="eeee8" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="考勤设置" Value="eeee8a" Expanded="False" SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../HumanResources/WorkTime.aspx ' target='_blank'>上下班时间</a>" Value="eeee8a" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/winexe.gif" Text="<a href='../HumanResources/WorkTimeJx.aspx ' target='_blank'>登记间歇时间</a>" Value="eeee8a">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="<a href='../HumanResources/SalariesSet.aspx ' target='_blank'>薪资设置</a>" Value="eeee8b" ></asp:TreeNode>
                     
                    </asp:TreeNode>
            
            
            </Nodes>
        </asp:TreeView>
    

    </form>
</body>
</html>
