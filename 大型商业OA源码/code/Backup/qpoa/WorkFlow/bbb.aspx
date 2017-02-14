<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bbb.aspx.cs" Inherits="qpoa.WorkFlow.bbb" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<script language="javascript"> 
function InsertHTML()
{
	// Get the editor instance that we want to interact with.
	var oEditor = FCKeditorAPI.GetInstance('FCKeditor1') ;

	// Check the active editing mode.
	if ( oEditor.EditMode == FCK_EDITMODE_WYSIWYG )
	{
		// Insert the desired HTML.
		oEditor.InsertHtml( '- This is some <a href="/Test1.html">sample</a> HTML -' ) ;
	}
	else
		alert( 'You must be on WYSIWYG mode!' ) ;
}
</script> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="450px">
        </FCKeditorV2:FCKeditor>
      <input type="button" value="Insert HTML" onclick="InsertHTML();" /></div>
    </form>
</body>
</html>
