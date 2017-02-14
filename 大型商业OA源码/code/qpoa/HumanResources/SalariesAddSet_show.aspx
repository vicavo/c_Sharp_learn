<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalariesAddSet_show.aspx.cs" Inherits="qpoa.HumanResources.SalariesAddSet_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('薪资名称不能为空');
    form1.Name.focus();
    return false;
    }	


    showwait();					
}





//function updatefrom(str)
//{
//var num=Math.random();
//window.open ("SalariesAddSet_add_Jbupdate.aspx?tmp="+num+"&id="+str+"", "_blank", "height=650, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=100,left=120")
//}

//function showfrom(str)
//{
//var num=Math.random();
//window.open ("SalariesAddSet_add_update.aspx?tmp="+num+"&id="+str+"", "_blank", "height=280, width=500,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=100,left=250")
//}
</script>





<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              查看薪资明细</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    帐套名称：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="SaName" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    薪资名称：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Name" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    状态：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="State" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    审批人：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="SpRealname" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                              <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    审批意见：</td>
                                <td class="newtd2" colspan="3" height="24">
                                    <asp:Label ID="SpRemark" runat="server" Width="99%"></asp:Label>
                            </tr>                          
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    对应年月：</td>
                                <td class="newtd2" colspan="3" height="24">

                                    <asp:Label ID="DyTime" runat="server" Width="78%"></asp:Label><INPUT onclick="javascript:getXlsFromTbl('tableExcel',null);" type="button" value="导出到EXCEL"></td>
                            </tr>
                            <tr>
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%" valign="top">
                                    <asp:Label ID="mx" runat="server"></asp:Label></td>
                            </tr>
  
                                   
                      
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <input id="Button3" class="button_blue" onclick="javascript:window.close()" type="button"
                                                value="关闭窗口" />&nbsp;</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table>
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="SaNumber" runat="server" Visible="False"></asp:TextBox></td>
  </tr>
</table>




<SCRIPT LANGUAGE="javascript">



function getXlsFromTbl(inTblId, inWindow) {

    try {

        var allStr = "";

        var curStr = "";

 

        //alert("getXlsFromTbl");

        if (inTblId != null && inTblId != "" && inTblId != "null") {

            curStr = getTblData(inTblId, inWindow);

        }

 

        if (curStr != null) {

            allStr += curStr;

        }

        else {

            alert("你要导出的表不存在！");

            return;

        }

 

        var fileName = getExcelFileName();

        doFileExport(fileName, allStr);

 

    }

    catch(e) {

        alert("导出发生异常:" + e.name + "->" + e.description + "!");

    }

}

function getTblData(inTbl, inWindow) {

    var rows = 0;

 

    //alert("getTblData is " + inWindow);

    var tblDocument = document;

 

    if (!!inWindow && inWindow != "") {

        if (!document.all(inWindow)) {

            return null;

        }

        else {

            tblDocument = eval(inWindow).document;

        }

    }

 

    var curTbl = tblDocument.getElementById(inTbl);

 

    var outStr = "";

 

    if (curTbl != null) {

        for (var j = 0; j < curTbl.rows.length; j++) {

            //alert("j is " + j);

            for (var i = 0; i < curTbl.rows[j].cells.length; i++) {

                //alert("i is " + i);

                if (i == 0 && rows > 0) {

                    outStr += " \t";

                    rows -= 1;

                }

                outStr += curTbl.rows[j].cells[i].innerText + "\t";

                if (curTbl.rows[j].cells[i].colSpan > 1) {

                    for (var k = 0; k < curTbl.rows[j].cells[i].colSpan - 1; k++) {

                        outStr += " \t";

                    }

                }

                if (i == 0) {

                    if (rows == 0 && curTbl.rows[j].cells[i].rowSpan > 1) {

                        rows = curTbl.rows[j].cells[i].rowSpan - 1;

                    }

                }

            }

            outStr += "\r\n";

        }

    }

    else {

        outStr = null;

        alert(inTbl + "不存在!");

    }

    return outStr;

}

function getExcelFileName() {

    var d = new Date();

 

    var curYear = d.getYear();

    var curMonth = "" + (d.getMonth() + 1);

    var curDate = "" + d.getDate();

    var curHour = "" + d.getHours();

    var curMinute = "" + d.getMinutes();

    var curSecond = "" + d.getSeconds();

 

    if (curMonth.length == 1) {

        curMonth = "0" + curMonth;

    }

    if (curDate.length == 1) {

        curDate = "0" + curDate;

    }

    if (curHour.length == 1) {

        curHour = "0" + curHour;

    }

    if (curMinute.length == 1) {

        curMinute = "0" + curMinute;

    }

    if (curSecond.length == 1) {

        curSecond = "0" + curSecond;

    }

 


  
      var fileName = "薪资报表"

            + ".xls";

    //alert(fileName);

    return fileName;

}

 

function doFileExport(inName, inStr) {

    var xlsWin = null;

 

    if (!!document.all("glbHideFrm")) {

        xlsWin = glbHideFrm;

    }

    else {

        var width = 6;

        var height = 4;

        var openPara = "left=" + (window.screen.width / 2 - width / 2)

                + ",top=" + (window.screen.height / 2 - height / 2)

                + ",scrollbars=no,width=" + width + ",height=" + height;

        xlsWin = window.open("", "_blank", openPara);

    }

 

    xlsWin.document.write(inStr);

    xlsWin.document.close();

    xlsWin.document.execCommand('Saveas', true, inName);

    xlsWin.close();

}

			</SCRIPT>			





    </form>
</body>
</html>