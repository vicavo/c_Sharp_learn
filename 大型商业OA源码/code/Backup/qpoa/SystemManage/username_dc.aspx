<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="username_dc.aspx.cs" Inherits="qpoa.SystemManage.username_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>����칫ϵͳ</title>
           <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="1px" CellPadding="4" CellSpacing="2" PageSize="12" Style="font-size: 12px" Width="100%" ForeColor="Black">
            <PagerSettings Visible="False" />
            <FooterStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="realname" HeaderText="�û�����">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="�û���">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="worknum" HeaderText="����">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Unit" HeaderText="��������">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Respon" HeaderText="��ɫ����">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Post" HeaderText="ְλ">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="StardType" HeaderText="�ڸ�״̬">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Iflogin" HeaderText="�Ƿ������½">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Sex" HeaderText="�Ա�">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
                <asp:BoundField DataField="Remark" HeaderText="��ע">
                    <HeaderStyle CssClass="newtitle" ForeColor="white" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
