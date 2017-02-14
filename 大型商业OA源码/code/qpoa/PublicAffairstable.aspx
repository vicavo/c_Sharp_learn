<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicAffairstable.aspx.cs" Inherits="qpoa.PublicAffairs.PublicAffairstable" %>

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

		<H1 class="title" align=left><A href="javascript:void(0)"><IMG src="images/menu/comm.gif" width=16px height=16px border=0>公共事务</a></H1>
	
		 <asp:TreeView ID="TreeView3" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作计划" Value="cccc1" ImageUrl="~/images/menu/work_plan.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="&lt;a href='../PublicAffairs/MyWorkPlan.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的计划&lt;/a&gt;" Value="cccc1a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="&lt;a href='../PublicAffairs/WorkPlan.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计划管理&lt;/a&gt;" Value="cccc1b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="计划类型设置" Value="cccc1c" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="&lt;a href='../SystemManage/Planningtype.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计划类型维护&lt;/a&gt;" Value="cccc1c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="&lt;a href='../SystemManage/Planningcycle.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;计划周期维护&lt;/a&gt;" Value="cccc1c" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品管理" Value="cccc2" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif"  Text="&lt;a href='../PublicAffairs/OfficeThing.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;办公用品管理" Value="cccc2a" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记" Value="cccc2b" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingCg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;入库登记&lt;/a&gt;" Value="cccc2b1" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingLy.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;领用登记&lt;/a&gt;" Value="cccc2b2" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingJy.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;借用登记&lt;/a&gt;" Value="cccc2b3" SelectAction="None">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingGh.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;归还登记&lt;/a&gt;" Value="cccc2b4" SelectAction="None">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingBf.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;报废登记&lt;/a&gt;" Value="cccc2b5" SelectAction="None" >
                            </asp:TreeNode>
                        </asp:TreeNode>
                          <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记审批" Value="cccc2c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingCg_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;入库登记审批&lt;/a&gt;" Value="cccc2c1" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingLy_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;领用登记审批&lt;/a&gt;" Value="cccc2c2" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingJy_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;借用登记审批&lt;/a&gt;" Value="cccc2c3" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingGh_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;归还登记审批&lt;/a&gt;" Value="cccc2c4" SelectAction="None" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="&lt;a href='../PublicAffairs/OfficeThingBf_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;报废登记审批&lt;/a&gt;" Value="cccc2c5" SelectAction="None" >
                            </asp:TreeNode>
                        </asp:TreeNode>
                        
                        
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图书信息" Value="cccc3" ImageUrl="~/images/menu/book.gif">
                        <asp:TreeNode Text="&lt;a href='../PublicAffairs/BookManageSearch.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图书查询&lt;/a&gt;" Value="cccc3a" ImageUrl="~/images/menu/book.gif" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/book.gif"  Text="&lt;a href='../PublicAffairs/Bookype.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图书类别维护&lt;/a&gt;" Value="cccc3b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Text="&lt;a href='../PublicAffairs/BookManage.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图书信息管理&lt;/a&gt;" Value="cccc3c" ImageUrl="~/images/menu/book.gif" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="会议管理" Value="cccc4" ImageUrl="~/images/menu/meeting.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="&lt;a href='../PublicAffairs/MettingApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议申请&lt;/a&gt;" Value="cccc4a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="&lt;a href='../PublicAffairs/MettingApply_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议管理&lt;/a&gt;" Value="cccc4f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="&lt;a href='../PublicAffairs/MettingHouse.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议室设置&lt;/a&gt;" Value="cccc4c" NavigateUrl="~/PublicAffairs/MettingHouse.aspx" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="&lt;a href='../PublicAffairs/MettingManager.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议室管理员&lt;/a&gt;" Value="cccc4a" NavigateUrl="~/PublicAffairs/MettingManager.aspx" SelectAction="None">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="&lt;a href='../PublicAffairs/MettingContent.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议纪要&lt;/a&gt;" Value="cccc4e" NavigateUrl="~/PublicAffairs/MettingContent.aspx" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vmeet.gif"  Text="&lt;a href='../PublicAffairs/NetMetting.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;网络会议&lt;/a&gt;" Value="cccc4j" NavigateUrl="~/PublicAffairs/NetMetting.aspx" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="车辆管理" Value="cccc5" ImageUrl="~/images/menu/vehicle.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆使用申请&lt;/a&gt;" Value="cccc5a" SelectAction="None">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarSearch.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆使用查询&lt;/a&gt;" Value="cccc5b" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarApply_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆使用管理&lt;/a&gt;" Value="cccc5c" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarRepair.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆维护管理&lt;/a&gt;" Value="cccc5d" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarInfo.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆信息管理&lt;/a&gt;" Value="cccc5e" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarManager.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;调度人员管理&lt;/a&gt;" Value="cccc5f" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="&lt;a href='../PublicAffairs/CarType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆类型管理&lt;/a&gt;" Value="cccc5g" SelectAction="None" >
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="固定资产" Value="cccc5" ImageUrl="~/images/menu/source.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="&lt;a href='../PublicAffairs/Assets.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;固定资产管理&lt;/a&gt;" Value="cccc6a" SelectAction="None">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="&lt;a href='../PublicAffairs/AssetsDep.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;固定资产折旧&lt;/a&gt;" Value="cccc6b" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="&lt;a href='../PublicAffairs/AssetsType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;固定资产类别&lt;/a&gt;" Value="cccc6c" SelectAction="None" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="&lt;a href='../PublicAffairs/AssetsDepType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;资产折旧类别&lt;/a&gt;" Value="cccc6d" SelectAction="None" >
                        </asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    
<asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作计划" Value="cccc1" ImageUrl="~/images/menu/work_plan.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="<a href='../PublicAffairs/MyWorkPlan.aspx ' target='_blank'>我的计划</a>" Value="cccc1a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="<a href='../PublicAffairs/WorkPlan.aspx ' target='_blank'>计划管理</a>" Value="cccc1b"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="计划类型设置" Value="cccc1c" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="<a href='../SystemManage/Planningtype.aspx ' target='_blank'>计划类型维护</a>" Value="cccc1c"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" Text="<a href='../SystemManage/Planningcycle.aspx ' target='_blank'>计划周期维护</a>" Value="cccc1c"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品管理" Value="cccc2" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif"  Text="<a href='../PublicAffairs/OfficeThing.aspx ' target='_blank'>办公用品管理" Value="cccc2a" >
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记" Value="cccc2b" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="<a href='../PublicAffairs/OfficeThingCg.aspx ' target='_blank'>入库登记</a>" Value="cccc2b1" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="<a href='../PublicAffairs/OfficeThingLy.aspx ' target='_blank'>领用登记</a>" Value="cccc2b2" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="<a href='../PublicAffairs/OfficeThingJy.aspx ' target='_blank'>借用登记</a>" Value="cccc2b3">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="<a href='../PublicAffairs/OfficeThingGh.aspx ' target='_blank'>归还登记</a>" Value="cccc2b4">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="<a href='../PublicAffairs/OfficeThingBf.aspx ' target='_blank'>报废登记</a>" Value="cccc2b5" >
                            </asp:TreeNode>
                        </asp:TreeNode>
                          <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记审批" Value="cccc2c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="<a href='../PublicAffairs/OfficeThingCg_sp.aspx ' target='_blank'>入库登记审批</a>" Value="cccc2c1" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="<a href='../PublicAffairs/OfficeThingLy_sp.aspx ' target='_blank'>领用登记审批</a>" Value="cccc2c2" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="<a href='../PublicAffairs/OfficeThingJy_sp.aspx ' target='_blank'>借用登记审批</a>" Value="cccc2c3" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="<a href='../PublicAffairs/OfficeThingGh_sp.aspx ' target='_blank'>归还登记审批</a>" Value="cccc2c4" >
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="<a href='../PublicAffairs/OfficeThingBf_sp.aspx ' target='_blank'>报废登记审批</a>" Value="cccc2c5" >
                            </asp:TreeNode>
                        </asp:TreeNode>
                        
                        
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图书信息" Value="cccc3" ImageUrl="~/images/menu/book.gif">
                        <asp:TreeNode Text="<a href='../PublicAffairs/BookManageSearch.aspx ' target='_blank'>图书查询</a>" Value="cccc3a" ImageUrl="~/images/menu/book.gif" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/book.gif"  Text="<a href='../PublicAffairs/Bookype.aspx ' target='_blank'>图书类别维护</a>" Value="cccc3b"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='../PublicAffairs/BookManage.aspx ' target='_blank'>图书信息管理</a>" Value="cccc3c" ImageUrl="~/images/menu/book.gif" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="会议管理" Value="cccc4" ImageUrl="~/images/menu/meeting.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="<a href='../PublicAffairs/MettingApply.aspx ' target='_blank'>会议申请</a>" Value="cccc4a" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="<a href='../PublicAffairs/MettingApply_sp.aspx ' target='_blank'>会议管理</a>" Value="cccc4f"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="<a href='../PublicAffairs/MettingHouse.aspx ' target='_blank'>会议室设置</a>" Value="cccc4c" NavigateUrl="~/PublicAffairs/MettingHouse.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="<a href='../PublicAffairs/MettingManager.aspx ' target='_blank'>会议室管理员</a>" Value="cccc4a" NavigateUrl="~/PublicAffairs/MettingManager.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="<a href='../PublicAffairs/MettingContent.aspx ' target='_blank'>会议纪要</a>" Value="cccc4e" NavigateUrl="~/PublicAffairs/MettingContent.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vmeet.gif"  Text="<a href='../PublicAffairs/NetMetting.aspx ' target='_blank'>网络会议</a>" Value="cccc4j" NavigateUrl="~/PublicAffairs/NetMetting.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="车辆管理" Value="cccc5" ImageUrl="~/images/menu/vehicle.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarApply.aspx ' target='_blank'>车辆使用申请</a>" Value="cccc5a">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarSearch.aspx ' target='_blank'>车辆使用查询</a>" Value="cccc5b" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarApply_sp.aspx ' target='_blank'>车辆使用管理</a>" Value="cccc5c" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarRepair.aspx ' target='_blank'>车辆维护管理</a>" Value="cccc5d" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarInfo.aspx ' target='_blank'>车辆信息管理</a>" Value="cccc5e" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarManager.aspx ' target='_blank'>调度人员管理</a>" Value="cccc5f" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="<a href='../PublicAffairs/CarType.aspx ' target='_blank'>车辆类型管理</a>" Value="cccc5g" >
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="固定资产" Value="cccc5" ImageUrl="~/images/menu/source.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="<a href='../PublicAffairs/Assets.aspx ' target='_blank'>固定资产管理</a>" Value="cccc6a">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="<a href='../PublicAffairs/AssetsDep.aspx ' target='_blank'>固定资产折旧</a>" Value="cccc6b" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="<a href='../PublicAffairs/AssetsType.aspx ' target='_blank'>固定资产类别</a>" Value="cccc6c" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="<a href='../PublicAffairs/AssetsDepType.aspx ' target='_blank'>资产折旧类别</a>" Value="cccc6d" >
                        </asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

    </form>
</body>
</html>
