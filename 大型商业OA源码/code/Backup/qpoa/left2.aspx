<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left2.aspx.cs" Inherits="qpoa.left2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>无标题页</title>
<LINK href="menu/style.css" type=text/css rel=stylesheet>
<LINK href="menu/menu.css" type=text/css rel=stylesheet>

   
   <SCRIPT language=JavaScript>
var cur_id="";
var flag=0,sflag=0;

//-------- 菜单点击事件 -------
function c(srcelement)
{
  var targetid,srcelement,targetelement;
  var strbuf;

  //-------- 如果点击了展开或收缩按钮---------
  targetid=srcelement.id+"d";
  targetelement=document.getElementById(targetid);

  if (targetelement.style.display=="none")
  {
     srcelement.className="active";
     targetelement.style.display='';

     menu_flag=0;
     expand_text.innerHTML="收缩";
  }
  else
  {
     srcelement.className="";
     targetelement.style.display="none";

     menu_flag=1;
     expand_text.innerHTML="展开";
     var links=document.getElementsByTagName("A");
     for (i=0; i<links.length; i++)
     {
       srcelement=links[i];
       if(srcelement.parentNode.className.toUpperCase()=="L1" && srcelement.className=="active" && srcelement.id.substr(0,1)=="m")
       {
          menu_flag=0;
          expand_text.innerHTML="收缩";
          break;
       }
     }
  }
}
function set_current(id)
{
   cur_link=document.getElementById("f"+cur_id)
   if(cur_link)
      cur_link.className="";
   cur_link=document.getElementById("f"+id);
   if(cur_link)
      cur_link.className="active";
   cur_id=id;
}

//-------- 菜单全部展开/收缩 -------
var menu_flag=1;
function menu_expand()
{
  if(menu_flag==1)
     expand_text.innerHTML="收缩";
  else
     expand_text.innerHTML="展开";

  menu_flag=1-menu_flag;

  var links=document.getElementsByTagName("A");
  for (i=0; i<links.length; i++)
  {
    srcelement=links[i];
    if(srcelement.parentNode.className.toUpperCase()=="L1" || srcelement.parentNode.className.toUpperCase()=="L21")
    {
      targetelement=document.getElementById(srcelement.id+"d");
      if(menu_flag==0)
      {
        targetelement.style.display='';
        srcelement.className="active";
      }
      else
      {
        targetelement.style.display="none";
        srcelement.className="";
      }
    }
  }
}


</SCRIPT> 


</head>
<body class=panel>
<form id="form1" runat="server">
<a id="expand_link" href="javascript:menu_expand();"><u><span id="expand_text">展开</span></u></a>
<DIV id=body>
<UL id=menu>

      <LI class=L1>
          <A id=MENU_WINEXE href="javascript:c(MENU_WINEXE);"><SPAN><IMG  src="menu/winexe.gif" align=baseline> Windows快捷组</SPAN></A> 
          <UL class=U1 id=MENU_WINEXEd style="DISPLAY: none">
            <LI class=L22>
           <asp:TreeView ID="TreeView1" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" Width="100%">
              <Nodes>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门通知" Value="1111b" ImageUrl="~/images/menu/notify.gif">
                        <asp:TreeNode ImageUrl="~/images/menu/notify.gif"  Text="部门通知浏览" Value="1111b1"  NavigateUrl="~/MyAffairs/MyUnitNotic.aspx">
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/images/menu/notify.gif"  Text="部门通知管理" Value="1111b2"  NavigateUrl="~/MyAffairs/UnitNotic.aspx">
                        </asp:TreeNode>
                    </asp:TreeNode>
            </Nodes>
          </asp:TreeView>
            </LI>
          </UL>
      </LI>
      
      <LI class=L1>
     
          <A id=MENU_URL href="javascript:c(MENU_URL);"><SPAN><IMG src="menu/url.gif" align=baseline> 常用网址</SPAN></A> 
          <UL class=U1 id=MENU_URLd style="DISPLAY: none">
            <LI class=L22><A href="#" ><SPAN><IMG src="images/menu/url.gif" align=baseline> 通达科技</SPAN></A>
          </UL>
      </LI>
  
        <LI class=L1>
          <A id=MENU_HY href="javascript:c(MENU_HY);"><SPAN><IMG src="menu/url.gif" align=baseline> 会议管理</SPAN></A> 
          <UL class=U1 id=MENU_HYd style="DISPLAY: none">
            <LI class=L22><A href="#" ><SPAN><IMG src="images/menu/url.gif" align=baseline> 会议</SPAN></A>
          </UL>
      </LI> 
  
</UL>
</DIV>
    
    
    
<DIV id=bottom></DIV>



    </form>
    
</body>
</html>
