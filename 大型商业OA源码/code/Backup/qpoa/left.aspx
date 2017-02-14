<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="qpoa.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>网络办公系统</title>
<STYLE type=text/css>
BODY {
FONT-SIZE: 12px; MARGIN: 0px; 
}

A:link
{
	font-size: 12px;
	color: #7330FE;
	text-decoration: none;
}	
		
A:visited
{
	font-size: 12px;
	color: #7330FE;
	text-decoration: none;
}	
		
A:active
{
	color: #ff0000;
	font-size: 12px;
	text-decoration: none;
}	
		
A:hover
{
	color: #ff0000;
	font-size: 12px;
	text-decoration: none;
}	


</STYLE>
</head>
<body  background="images/left_bg.jpg">
    <form id="form1" runat="server">
    <div >
        <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人事务" Value="1111">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门通知" Value="1111b" ImageUrl="~/images/menu/notify.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/notify.gif"  Text="部门通知浏览" Value="1111b1"  NavigateUrl="~/MyAffairs/MyUnitNotic.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/notify.gif"  Text="部门通知管理" Value="1111b2"  NavigateUrl="~/MyAffairs/UnitNotic.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="公司通知" Value="1111c" ImageUrl="~/images/menu/news.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/news.gif"  Text="公司通知浏览" Value="1111c1" NavigateUrl="~/MyAffairs/MyCompanyNotic.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/news.gif"  Text="公司通知管理" Value="1111c2" NavigateUrl="~/MyAffairs/CompanyNotic.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>    
                   
                     <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子刊物" Value="1111d" ImageUrl="~/images/menu/file_folder.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif"  Text="电子刊物浏览" Value="1111d1"  NavigateUrl="~/MyAffairs/MyElecBook.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif"  Text="电子刊物管理" Value="1111d2"  NavigateUrl="~/MyAffairs/ElecBook.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>                     
                   
                     <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人考勤" Value="1111e" ImageUrl="~/images/menu/attendance.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="病假登记" Value="1111e2" NavigateUrl="~/MyAffairs/MyAttendance.aspx?type=1">
                        </asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="事假登记" Value="1111e3" NavigateUrl="~/MyAffairs/MyAttendance.aspx?type=2">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="出差登记" Value="1111e4" NavigateUrl="~/MyAffairs/MyAttendance.aspx?type=3">
                        </asp:TreeNode>                        
                    </asp:TreeNode>  
                     <asp:TreeNode ImageUrl="~/images/menu/calendar.gif"  Text="日程安排" Value="1111f"  NavigateUrl="~/MyAffairs/MyCalendar.aspx"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="工作日志" Value="1111g" NavigateUrl="~/MyAffairs/MyDiary.aspx"></asp:TreeNode>
                   <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的会议" Value="1111h" ImageUrl="~/images/menu/meeting.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="我的会议" Value="1111h1"  NavigateUrl="~/MyAffairs/MyMetting.aspx">
                        </asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/vmeet.gif"  Text="视频会议" Value="1111h3">
                        </asp:TreeNode>
                    </asp:TreeNode>                         
                    <asp:TreeNode  Text="通讯录管理" Value="1111i" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/address.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/address.gif"  Text="公司通讯录" Value="1111i1" NavigateUrl="~/MyAffairs/CompanyGroup.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/address.gif"  Text="个人通讯录" Value="1111i2" NavigateUrl="~/MyAffairs/MyGroup.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/address.gif"  Text="公共通讯录" Value="1111i3" NavigateUrl="~/MyAffairs/PublicGroup.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/address.gif"  Text="通讯录类别" Value="1111i4" NavigateUrl="~/MyAffairs/GroupType.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/file_folder.gif"  Text="个人文件柜" Value="1111k" NavigateUrl="~/MyAffairs/Folders.aspx"></asp:TreeNode>
                     <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人设置" Value="1111l" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="快捷菜单设置" Value="1111l1">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="用户提醒设置" Value="1111l2" NavigateUrl="~/MyAffairs/MyReminded.aspx">
                        </asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="密码修改" Value="1111l3" NavigateUrl="~/MyAffairs/SystemPassword.aspx">
                        </asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="邮件参数设置" Value="1111l4" NavigateUrl="~/MyAffairs/Emailprv.aspx">
                        </asp:TreeNode>
                         <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="常用审批备注" Value="1111l5" NavigateUrl="~/MyAffairs/UseSpRemark.aspx">
                        </asp:TreeNode>                       
                          <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="常用模版设置" Value="1111l6" NavigateUrl="~/MyAffairs/OftenModle.aspx">
                        </asp:TreeNode>                         
                        
                        
                    </asp:TreeNode>                        
                   
                   
                   
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作流程" Value="bbbb">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="bbbb1" ImageUrl="~/images/menu/infofind.gif">
                        <asp:TreeNode Text="印章管理" Value="bbbb1a" ImageUrl="~/images/menu/infofind.gif" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/infofind.gif"  Text="印章使用记录" Value="bbbb1b">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="表单定义" Value="bbbb2" ImageUrl="~/images/menu/calendar2.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif" NavigateUrl="~/WorkFlow/DIYForm.aspx" 
                            Text="表单设计" Value="bbbb2a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/calendar2.gif"  Text="表单类别" Value="bbbb2b" NavigateUrl="~/WorkFlow/FormType.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode  Text="工作流管理" Value="bbbb3" ImageUrl="~/images/menu/info_query.gif" NavigateUrl="~/WorkFlow/WorkFlowName.aspx"></asp:TreeNode>
                    <asp:TreeNode  Text="工作管理" Value="bbbb4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/workflow.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="新建工作" Value="bbbb4a" NavigateUrl="~/WorkFlow/AddWorkFlow.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="待办工作" Value="bbbb4b"  NavigateUrl="~/WorkFlow/WorkFlowList.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="工作查询" Value="bbbb4c" NavigateUrl="~/WorkFlow/WorkFlowSearch.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="工作监控" Value="bbbb4d" NavigateUrl="~/WorkFlow/WorkFlowJk.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif" Text="归档工作" Value="bbbb4e" NavigateUrl="~/WorkFlow/WorkFlowNodeGD.aspx" ></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
            
             <asp:TreeNode Expanded="False" SelectAction="Expand" Text="公共事务" Value="cccc">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作计划" Value="cccc1" ImageUrl="~/images/menu/work_plan.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="我的计划" Value="cccc1a" NavigateUrl="~/PublicAffairs/MyWorkPlan.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/work_plan.gif"  Text="计划管理" Value="cccc1b" NavigateUrl="~/PublicAffairs/WorkPlan.aspx"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="计划类型设置" Value="cccc1c" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SystemManage/Planningtype.aspx"
                                 Text="计划类型维护" Value="cccc1c1"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SystemManage/Planningcycle.aspx"
                                 Text="计划周期维护" Value="cccc1c2"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品管理" Value="cccc2" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif"  Text="办公用品管理" Value="cccc2a" NavigateUrl="~/PublicAffairs/OfficeThing.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记" Value="cccc2b" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="入库登记" Value="cccc2b1" NavigateUrl="~/PublicAffairs/OfficeThingCg.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="领用登记" Value="cccc2b2" NavigateUrl="~/PublicAffairs/OfficeThingLy.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="借用登记" Value="cccc2b3" NavigateUrl="~/PublicAffairs/OfficeThingJy.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="归还登记" Value="cccc2b4" NavigateUrl="~/PublicAffairs/OfficeThingGh.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="报废登记" Value="cccc2b5" NavigateUrl="~/PublicAffairs/OfficeThingBf.aspx">
                            </asp:TreeNode>
                        </asp:TreeNode>
                          <asp:TreeNode Expanded="False" SelectAction="Expand" Text="办公用品登记审批" Value="cccc2c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="入库登记审批" Value="cccc2c1" NavigateUrl="~/PublicAffairs/OfficeThingCg_sp.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="领用登记审批" Value="cccc2c2" NavigateUrl="~/PublicAffairs/OfficeThingLy_sp.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="借用登记审批" Value="cccc2c3" NavigateUrl="~/PublicAffairs/OfficeThingJy_sp.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="归还登记审批" Value="cccc2c4" NavigateUrl="~/PublicAffairs/OfficeThingGh_sp.aspx">
                            </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif"  Text="报废登记审批" Value="cccc2c5" NavigateUrl="~/PublicAffairs/OfficeThingBf_sp.aspx">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        
                        
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图书信息" Value="cccc3" ImageUrl="~/images/menu/book.gif">
                        <asp:TreeNode NavigateUrl="~/PublicAffairs/BookManageSearch.aspx" Text="图书查询" Value="cccc3a" ImageUrl="~/images/menu/book.gif" >
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/book.gif" NavigateUrl="~/PublicAffairs/Bookype.aspx"
                             Text="图书类别维护" Value="cccc3b"></asp:TreeNode>
                        <asp:TreeNode Text="图书信息管理" Value="cccc3c" ImageUrl="~/images/menu/book.gif" NavigateUrl="~/PublicAffairs/BookManage.aspx" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="会议管理" Value="cccc4" ImageUrl="~/images/menu/meeting.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="会议申请" Value="cccc4a"  NavigateUrl="~/PublicAffairs/MettingApply.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif" NavigateUrl="~/PublicAffairs/MettingApply_sp.aspx"
                             Text="会议管理" Value="cccc4f"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="会议室设置" Value="cccc4c" NavigateUrl="~/PublicAffairs/MettingHouse.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="会议室管理员" Value="cccc4a" NavigateUrl="~/PublicAffairs/MettingManager.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/meeting.gif"  Text="会议纪要" Value="cccc4e" NavigateUrl="~/PublicAffairs/MettingContent.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="车辆管理" Value="cccc5" ImageUrl="~/images/menu/vehicle.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆使用申请" Value="cccc5a" NavigateUrl="~/PublicAffairs/CarApply.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆使用查询" Value="cccc5b" NavigateUrl="~/PublicAffairs/CarSearch.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆使用管理" Value="cccc5c"  NavigateUrl="~/PublicAffairs/CarApply_sp.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆维护管理" Value="cccc5d"  NavigateUrl="~/PublicAffairs/CarRepair.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆信息管理" Value="cccc5e" NavigateUrl="~/PublicAffairs/CarInfo.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="调度人员管理" Value="cccc5f" NavigateUrl="~/PublicAffairs/CarManager.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vehicle.gif"  Text="车辆类型管理" Value="cccc5g" NavigateUrl="~/PublicAffairs/CarType.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="固定资产" Value="cccc5" ImageUrl="~/images/menu/source.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="固定资产管理" Value="cccc6a" NavigateUrl="~/PublicAffairs/Assets.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="固定资产折旧" Value="cccc6b" NavigateUrl="~/PublicAffairs/AssetsDep.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="固定资产类别" Value="cccc6c"  NavigateUrl="~/PublicAffairs/AssetsType.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/source.gif"  Text="资产折旧类别" Value="cccc6d"  NavigateUrl="~/PublicAffairs/AssetsDepType.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="信息交流" Value="dddd">
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="内部消息" Value="dddd1" NavigateUrl="~/InfoSpeech/Messages.aspx" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="内部邮件" Value="dddd2" NavigateUrl="~/InfoSpeech/NbMailAccept.aspx" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/sms.gif" Text="外部邮件" Value="dddd3" NavigateUrl="~/InfoSpeech/WbMail.aspx" ></asp:TreeNode>
                    <asp:TreeNode Text="内部讨论区" Value="dddd4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/bbs.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif" NavigateUrl="~/InfoSpeech/InsideBBS.aspx"
                             Text="讨论区" Value="dddd4a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/bbs.gif" NavigateUrl="~/InfoSpeech/InsideBBSBig.aspx"
                             Text="讨论区类别" Value="dddd4b"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="互动聊天" Value="dddd5" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/chatroom.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="互动聊天" Value="dddd5a" NavigateUrl="~/InfoSpeech/chatcontent.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/chatroom.gif"  Text="聊天室管理" Value="dddd5b"  NavigateUrl="~/InfoSpeech/chatName.aspx" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/netdisk.gif" Text="网络硬盘" Value="dddd6"  NavigateUrl="~/InfoSpeech/WebDisc.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="投票管理" Value="dddd7" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/vote.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="投票浏览" Value="dddd7a" NavigateUrl="~/InfoSpeech/toupiao.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/vote.gif"  Text="投票管理" Value="dddd7b" NavigateUrl="~/InfoSpeech/toupiaobt.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人力资源" Value="eeee">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事档案" Value="eeee1" ImageUrl="~/images/menu/hrms.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif" Text="档案管理" Value="eeee1a" NavigateUrl="~/HumanResources/Employee.aspx" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/hrms.gif"  Text="人事合同" Value="eeee1b" NavigateUrl="~/HumanResources/EmpContract.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand"  Text="考勤管理" Value="eeee2" ImageUrl="~/images/menu/attendance.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="病假审批" Value="eeee2a" NavigateUrl="~/HumanResources/MyAttendanceSp.aspx?type=1"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="事假审批" Value="eeee2b" NavigateUrl="~/HumanResources/MyAttendanceSp.aspx?type=2"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/attendance.gif"  Text="出差审批" Value="eeee2c" NavigateUrl="~/HumanResources/MyAttendanceSp.aspx?type=3"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="劳资管理" Value="eeee3"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="培训记录" Value="eeee4"   NavigateUrl="~/HumanResources/TrainingLog.aspx"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/score.gif"  Text="奖惩记录" Value="eeee5"  NavigateUrl="~/HumanResources/IncentiveLog.aspx"></asp:TreeNode>
 
                </asp:TreeNode>
                <asp:TreeNode Text="销售管理" Value="ffff" Expanded="False" SelectAction="Expand">
                    <asp:TreeNode Text="客户管理" Value="ffff1" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户基本信息" Value="ffff1a" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="客户信息管理" Value="ffff1a1"  NavigateUrl="~/SaleManage/Customer.aspx"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="客户联系人" Value="ffff1a2" NavigateUrl="~/SaleManage/CustomerLxrAll.aspx"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="客户交往记录" Value="ffff1b"  NavigateUrl="~/SaleManage/ContactsLog.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="客户服务" Value="ffff1c"  NavigateUrl="~/SaleManage/ServicesLog.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="客户转移" Value="ffff1d"  NavigateUrl="~/SaleManage/CustomerMove.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="客户忠诚度管理" Value="ffff2" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="客户关怀" Value="ffff2a"  NavigateUrl="~/SaleManage/ContactsCare.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="客户回访" Value="ffff2b"  NavigateUrl="~/SaleManage/ContactsVisit.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="客户投诉" Value="ffff2c"  NavigateUrl="~/SaleManage/ContactsComp.aspx"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="客户满意度调查" Value="ffff2d"  NavigateUrl="~/SaleManage/ContactsSurvey.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="产品信息" Value="ffff3" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif" Text="产品信息管理" Value="ffff3c"  NavigateUrl="~/SaleManage/SupplierPro.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="销售管理" Value="ffff4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="销售合同" Value="ffff4a"  NavigateUrl="~/SaleManage/SaleContract.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="销售记录管理" Value="ffff4b" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" NavigateUrl="~/SaleManage/SaleProduct.aspx"
                                 Text="常规产品" Value="ffff4b1"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="服务产品" Value="ffff4b2" NavigateUrl="~/SaleManage/SaleProductFw.aspx"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="供应商管理" Value="ffff5" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="供应商信息管理" Value="ffff5a"  NavigateUrl="~/SaleManage/Supplier.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计分析" Value="ffff6" ImageUrl="~/images/menu/finance.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="客户综合信息" Value="ffff6a"  NavigateUrl="~/SaleManage/AnalysisCustomer.aspx"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="销售统计" Value="ffff6c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="合同统计" Value="合同统计"  NavigateUrl="~/SaleManage/AttSaleContract.aspx"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="产品销售" Value="产品销售"  NavigateUrl="~/SaleManage/AttSaleProduct.aspx"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="服务销售" Value="服务销售"  NavigateUrl="~/SaleManage/AttSaleProductFw.aspx"></asp:TreeNode>
                            <asp:TreeNode Text="销售额分析" Value="销售额分析" ImageUrl="~/images/menu/training.gif"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户属性统计" Value="ffff6c5" ImageUrl="~/images/menu/diary.gif">
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleDataQy.aspx"
                                     Text="客户区域" Value="ffff6c5a"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleData.aspx?type=2"
                                     Text="客户行业" Value="ffff6c5b"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleDataKhly.aspx"
                                     Text="客户来源" Value="ffff6c5c"></asp:TreeNode>
                                 <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleDataKhzyd.aspx"
                                     Text="客户重要度" Value="ffff6c5a"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleDataXsfs.aspx"
                                     Text="销售方式" Value="ffff6c5b"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AllSaleDataQyxz.aspx"
                                     Text="企业性质" Value="ffff6c5c"></asp:TreeNode>    
                                    
                            </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户归属统计" Value="客户归属统计" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AttributionBm.aspx"
                                 Text="部门统计" Value="部门统计"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" NavigateUrl="~/SaleManage/AttributionXsz.aspx"
                                 Text="销售组统计" Value="销售组统计"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="业务员统计" Value="业务员统计" NavigateUrl="~/SaleManage/AttributionYwy.aspx"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础数据设置" Value="ffff7" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="销售组维护" Value="ffff7a"  NavigateUrl="~/SaleManage/SaleGroup.aspx"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数据字典维护" Value="ffff7b" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="区域" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=1" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="行业" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=2" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="客户来源" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=3" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="重要度" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=4" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="交往方式" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=5" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="企业性质" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=6" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="销售方式" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=7" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="服务方式" Value="ffff7b" NavigateUrl="~/SaleManage/SaleData.aspx?type=8" ></asp:TreeNode>
                             <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleData.aspx?type=9"
                                Text="计量单位" Value="ffff7b" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleData.aspx?type=10"
                                Text="产品类别" Value="ffff7b" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleData.aspx?type=11"
                                 Text="合同类型" Value="ffff7b"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="自定义字段" Value="ffff7c" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=1"
                                 Text="客户管理" Value="ffff7c1"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=2"
                                 Text="客户联系人管理" Value="ffff7c2"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=3"
                                 Text="客户服务管理" Value="ffff7c3"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=4"
                                 Text="产品管理" Value="ffff7c4"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=5"
                                 Text="服务型产品管理" Value="ffff7c5"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=6"
                                 Text="合同管理" Value="ffff7c6"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=7"
                                 Text="供应商信息管理" Value="ffff7c7"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=8"
                                 Text="供应商联系人管理" Value="ffff7c8"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=11"
                                 Text="供应商产品信息" Value="ffff7c9"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=9"
                                 Text="产品销售记录" Value="ffff7c10"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" NavigateUrl="~/SaleManage/SaleFieldDIY.aspx?type=10"
                                 Text="服务性产品销售记录" Value="ffff7c11"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="附件程序" Value="gggg" Expanded="False" SelectAction="Expand">
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="万年历" Value="gggg2" NavigateUrl="~/PracticalTool/calendar.htm"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/winexe.gif"  Text="世界时间" Value="gggg3" NavigateUrl="~/PracticalTool/worldtime.htm"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="常用网址" Value="hhhh">
                    <asp:TreeNode ImageUrl="~/images/menu/url.gif" NavigateUrl="~/FreWebsite/Website.aspx" 
                        Text="常用网址浏览" Value="hhhh1"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="系统管理" Value="iiii" Expanded="False" SelectAction="Expand">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础数据维护" Value="iiii1" ImageUrl="~/images/menu/system.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/Programtype.aspx"
                             Text="日程类型维护" Value="iiii1a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/system.gif"  Text="日志类型维护" Value="iiii1b" NavigateUrl="~/SystemManage/Diarytype.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/system.gif"  Text="重要等级维护" Value="iiii1c" NavigateUrl="~/SystemManage/Ranktype.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/OpenNotice.aspx"
                         Text="弹出公告设置" Value="iiii2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/system.gif"  Text="红头文件管理" Value="iiii3" NavigateUrl="~/SystemManage/DocumentModle.aspx">
                    </asp:TreeNode>
                    <asp:TreeNode Text="用户管理" Value="iiii4" ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/username.aspx" ></asp:TreeNode>
                    <asp:TreeNode Text="角色管理" Value="iiii5" ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/Respon.aspx" ></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/UnitName.aspx"
                         Text="部门管理" Value="iiii6"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/PostName.aspx"
                         Text="职位管理" Value="iiii7"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/images/menu/system.gif" NavigateUrl="~/SystemManage/SystemLog.aspx"
                         Text="系统日志" Value="iiii8"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
