<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleManagetable.aspx.cs" Inherits="qpoa.SaleManagetable" %>

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

		<H1 class="title" align=left><a href="javascript:void(0)"><IMG src="images/menu/sale_manage.gif" width=16px height=16px border=0>销售管理</a></H1>
	
<asp:TreeView ID="TreeView6" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode  Text="客户管理" Value="ffff1" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户基本信息" Value="ffff1a" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/Customer.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户信息管理&lt;/a&gt;" Value="ffff1a1" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/CustomerLxrAll.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户联系人&lt;/a&gt;" Value="ffff1a2" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/ContactsLog.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户交往记录&lt;/a&gt;" Value="ffff1b" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/ServicesLog.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户服务&lt;/a&gt;" Value="ffff1c" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/CustomerMove.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户转移&lt;/a&gt;" Value="ffff1d" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="客户忠诚度管理" Value="ffff2" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsCare.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户关怀&lt;/a&gt;" Value="ffff2a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsVisit.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户回访&lt;/a&gt;" Value="ffff2b" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsComp.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户投诉&lt;/a&gt;" Value="ffff2c" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsSurvey.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户满意度调查&lt;/a&gt;" Value="ffff2d" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="产品信息" Value="ffff3" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif" Text="&lt;a href='../SaleManage/SupplierPro.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;产品信息管理&lt;/a&gt;" Value="ffff3c" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="销售管理" Value="ffff4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/SaleContract.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售合同&lt;/a&gt;" Value="ffff4a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode Text="销售记录管理" Value="ffff4b" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/SaleProduct.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;常规产品&lt;/a&gt;" Value="ffff4b1" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/SaleProductFw.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;服务产品&lt;/a&gt;" Value="ffff4b2" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="供应商管理" Value="ffff5" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/Supplier.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;供应商信息管理&lt;/a&gt;" Value="ffff5c" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计分析" Value="ffff6" ImageUrl="~/images/menu/finance.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AnalysisCustomer.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户综合信息&lt;/a&gt;" Value="ffff6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="销售统计" Value="ffff6c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleContract.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;合同统计&lt;/a&gt;" Value="ffff6c" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProduct.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;产品销售&lt;/a&gt;" Value="ffff6c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProductFw.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;服务销售&lt;/a&gt;" Value="ffff6c" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户属性统计" Value="ffff6d" ImageUrl="~/images/menu/diary.gif">
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataQy.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户区域&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleData.aspx?type=2 '  target='rform' onclick='parent.UploadComplete();' &gt;客户行业&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataKhly.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户来源&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                 <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataKhzyd.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;客户重要度&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleDataXsfs.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售方式&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleDataQyxz.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;企业性质&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>    
                                    
                            </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户归属统计" Value="ffff6e" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                 Text="&lt;a href='../SaleManage/AttributionBm.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;部门统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                 Text="&lt;a href='../SaleManage/AttributionXsz.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售组统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../SaleManage/AttributionYwy.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;业务员统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础数据设置" Value="ffff7" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleGroup.aspx '  target='rform' onclick='parent.UploadComplete();' &gt;销售组维护&lt;/a&gt;" Value="ffff7a"  NavigateUrl="~/SaleManage/SaleGroup.aspx" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数据字典维护" Value="ffff7b" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=1 '  target='rform' onclick='parent.UploadComplete();' &gt;区域&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=2 '  target='rform' onclick='parent.UploadComplete();' &gt;行业&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=3'  target='rform' onclick='parent.UploadComplete();' &gt;客户来源&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;重要度&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=5 '  target='rform' onclick='parent.UploadComplete();' &gt;交往方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"  ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=6 '  target='rform' onclick='parent.UploadComplete();' &gt;企业性质&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=7 '  target='rform' onclick='parent.UploadComplete();' &gt;销售方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=8 '  target='rform' onclick='parent.UploadComplete();' &gt;服务方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"  ></asp:TreeNode>
                             <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" 
                                Text="&lt;a href='../SaleManage/SaleData.aspx?type=9 '  target='rform' onclick='parent.UploadComplete();' &gt;计量单位&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" 
                                Text="&lt;a href='../SaleManage/SaleData.aspx?type=10 '  target='rform' onclick='parent.UploadComplete();' &gt;产品类别&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"
                                 Text="&lt;a href='../SaleManage/SaleData.aspx?type=11 '  target='rform' onclick='parent.UploadComplete();' &gt;合同类型&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="自定义字段" Value="ffff7c" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=1 '  target='rform' onclick='parent.UploadComplete();' &gt;客户管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=2'  target='rform' onclick='parent.UploadComplete();' &gt;客户联系人管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=3 '  target='rform' onclick='parent.UploadComplete();' &gt;客户服务管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;产品管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=5'  target='rform' onclick='parent.UploadComplete();' &gt;服务型产品管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=6'  target='rform' onclick='parent.UploadComplete();' &gt;合同管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=7'  target='rform' onclick='parent.UploadComplete();' &gt;供应商信息管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=8'  target='rform' onclick='parent.UploadComplete();' &gt;供应商联系人管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=11'  target='rform' onclick='parent.UploadComplete();' &gt;供应商产品信息&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=9'  target='rform' onclick='parent.UploadComplete();' &gt;产品销售记录&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=10'  target='rform' onclick='parent.UploadComplete();' &gt;服务性产品销售记录&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
 
 
<asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            <Nodes>
                    <asp:TreeNode  Text="客户管理" Value="ffff1" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户基本信息" Value="ffff1a" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/Customer.aspx '  target='_blank'  &gt;客户信息管理&lt;/a&gt;" Value="ffff1a1" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/CustomerLxrAll.aspx '  target='_blank'  &gt;客户联系人&lt;/a&gt;" Value="ffff1a2" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/ContactsLog.aspx '  target='_blank'  &gt;客户交往记录&lt;/a&gt;" Value="ffff1b" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/ServicesLog.aspx '  target='_blank'  &gt;客户服务&lt;/a&gt;" Value="ffff1c" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/CustomerMove.aspx '  target='_blank'  &gt;客户转移&lt;/a&gt;" Value="ffff1d" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="客户忠诚度管理" Value="ffff2" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsCare.aspx '  target='_blank'  &gt;客户关怀&lt;/a&gt;" Value="ffff2a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsVisit.aspx '  target='_blank'  &gt;客户回访&lt;/a&gt;" Value="ffff2b" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsComp.aspx '  target='_blank'  &gt;客户投诉&lt;/a&gt;" Value="ffff2c" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/ContactsSurvey.aspx '  target='_blank'  &gt;客户满意度调查&lt;/a&gt;" Value="ffff2d" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="产品信息" Value="ffff3" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/office_Product.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/office_Product.gif" Text="&lt;a href='../SaleManage/SupplierPro.aspx '  target='_blank'  &gt;产品信息管理&lt;/a&gt;" Value="ffff3c" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="销售管理" Value="ffff4" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif" Text="&lt;a href='../SaleManage/SaleContract.aspx '  target='_blank'  &gt;销售合同&lt;/a&gt;" Value="ffff4a" SelectAction="None" ></asp:TreeNode>
                        <asp:TreeNode Text="销售记录管理" Value="ffff4b" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/sale_manage.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/SaleProduct.aspx '  target='_blank'  &gt;常规产品&lt;/a&gt;" Value="ffff4b1" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/sale_manage.gif"  Text="&lt;a href='../SaleManage/SaleProductFw.aspx '  target='_blank'  &gt;服务产品&lt;/a&gt;" Value="ffff4b2" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="供应商管理" Value="ffff5" ImageUrl="~/images/menu/training.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/Supplier.aspx '  target='_blank'  &gt;供应商信息管理&lt;/a&gt;" Value="ffff5c" SelectAction="None" ></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计分析" Value="ffff6" ImageUrl="~/images/menu/finance.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AnalysisCustomer.aspx '  target='_blank'  &gt;客户综合信息&lt;/a&gt;" Value="ffff6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="销售统计" Value="ffff6c" ImageUrl="~/images/menu/training.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleContract.aspx '  target='_blank'  &gt;合同统计&lt;/a&gt;" Value="ffff6c" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProduct.aspx '  target='_blank'  &gt;产品销售&lt;/a&gt;" Value="ffff6c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/training.gif" Text="&lt;a href='../SaleManage/AttSaleProductFw.aspx '  target='_blank'  &gt;服务销售&lt;/a&gt;" Value="ffff6c" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                            <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户属性统计" Value="ffff6d" ImageUrl="~/images/menu/diary.gif">
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataQy.aspx '  target='_blank'  &gt;客户区域&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleData.aspx?type=2 '  target='_blank'  &gt;客户行业&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataKhly.aspx '  target='_blank'  &gt;客户来源&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                 <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                     Text="&lt;a href='../SaleManage/AllSaleDataKhzyd.aspx '  target='_blank'  &gt;客户重要度&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleDataXsfs.aspx '  target='_blank'  &gt;销售方式&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                     Text="&lt;a href='../SaleManage/AllSaleDataQyxz.aspx '  target='_blank'  &gt;企业性质&lt;/a&gt;" Value="ffff6d" SelectAction="None"></asp:TreeNode>    
                                    
                            </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="客户归属统计" Value="ffff6e" ImageUrl="~/images/menu/diary.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif" 
                                 Text="&lt;a href='../SaleManage/AttributionBm.aspx '  target='_blank'  &gt;部门统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"
                                 Text="&lt;a href='../SaleManage/AttributionXsz.aspx '  target='_blank'  &gt;销售组统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/diary.gif"  Text="&lt;a href='../SaleManage/AttributionYwy.aspx '  target='_blank'  &gt;业务员统计&lt;/a&gt;" Value="ffff6e" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础数据设置" Value="ffff7" ImageUrl="~/images/menu/person_info.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleGroup.aspx '  target='_blank'  &gt;销售组维护&lt;/a&gt;" Value="ffff7a"  NavigateUrl="~/SaleManage/SaleGroup.aspx" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数据字典维护" Value="ffff7b" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=1 '  target='_blank'  &gt;区域&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=2 '  target='_blank'  &gt;行业&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=3'  target='_blank'  &gt;客户来源&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=4'  target='_blank'  &gt;重要度&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=5 '  target='_blank'  &gt;交往方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"  ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=6 '  target='_blank'  &gt;企业性质&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=7 '  target='_blank'  &gt;销售方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleData.aspx?type=8 '  target='_blank'  &gt;服务方式&lt;/a&gt;" Value="ffff7b" SelectAction="None"  ></asp:TreeNode>
                             <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" 
                                Text="&lt;a href='../SaleManage/SaleData.aspx?type=9 '  target='_blank'  &gt;计量单位&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" 
                                Text="&lt;a href='../SaleManage/SaleData.aspx?type=10 '  target='_blank'  &gt;产品类别&lt;/a&gt;" Value="ffff7b" SelectAction="None" ></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"
                                 Text="&lt;a href='../SaleManage/SaleData.aspx?type=11 '  target='_blank'  &gt;合同类型&lt;/a&gt;" Value="ffff7b" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="自定义字段" Value="ffff7c" Expanded="False" SelectAction="Expand" ImageUrl="~/images/menu/person_info.gif">
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=1 '  target='_blank'  &gt;客户管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=2'  target='_blank'  &gt;客户联系人管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=3 '  target='_blank'  &gt;客户服务管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=4'  target='_blank'  &gt;产品管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=5'  target='_blank'  &gt;服务型产品管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=6'  target='_blank'  &gt;合同管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=7'  target='_blank'  &gt;供应商信息管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=8'  target='_blank'  &gt;供应商联系人管理&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"  Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=11'  target='_blank'  &gt;供应商产品信息&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif"   Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=9'  target='_blank'  &gt;产品销售记录&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/images/menu/person_info.gif" Text="&lt;a href='../SaleManage/SaleFieldDIY.aspx?type=10'  target='_blank'  &gt;服务性产品销售记录&lt;/a&gt;" Value="ffff7c" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

    </form>
</body>
</html>
