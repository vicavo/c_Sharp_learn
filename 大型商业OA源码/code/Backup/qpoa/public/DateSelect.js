

//日期选择帮助
function DateSelect(asID)
{
	var oSendParm = new Object();
	var sFeatures = "edge: Raised; center: Yes; help: No; resizable: No; status: No;"
	var lLeft,lTop,lWidth,lHeight;
	var sDate,sArrayDate,ibDate=true,sTemp;
	
	lWidth  = 218;
	lHeight = 212;
	oSendParm.DataType = document.all(asID).DataType;
	
	if(oSendParm.DataType=="DateTime")
	{
		lHeight = 228;
		ibDate = false;
	}
			
	//*window XP的窗口必须增大
	//var pos =window.navigator.appVersion.toLowerCase().indexOf("nt");
	//var ver = window.navigator.appVersion.substring(pos +3,pos +6);

	
	
		lWidth  +=6;
		lHeight +=8;
	
	
	if(event == null)
	{
		lLeft = screen.availWidth/2  - lWidth/2;
		lTop  = screen.availHeight/2 - 98;
	}
	else
	{
		lLeft = event.screenX ;
		lTop  = event.screenY ;
	}
	
	if(lLeft + lWidth > screen.availWidth)
	{
		if(lLeft > lWidth)
			 lLeft -= lWidth;
		else
			lLeft = 0;
	}
	if(lTop + lHeight > screen.availHeight) 
	{
		if(lTop > lHeight)
			lTop -= lHeight;
		else
			lTop = 0;
	}
	
	sFeatures += "dialogHeight: " + lHeight + "px; dialogWidth: " + lWidth + "px; dialogTop: " + lTop + "px; dialogLeft: " + lLeft + "px;";	
	sDate = document.all(asID).value;
	oSendParm.LastSelect = StringToDate(sDate);
			
	oSendParm.DocumentTitle = "Time";

	var surl="DateSelect.htm";
	if (arguments.length>1){
		surl = arguments[1];
	}
	sDate = window.showModalDialog(surl,oSendParm,sFeatures);
	if(sDate != null)
		document.all(asID).value = sDate;
}

//返回日期的具体信息
function GetForDateStringArray(asDate)
{
    var sArrayDate,sTemp;
    
    sArrayDate = asDate.split("-");
	if(sArrayDate.length == 3)
	{		
		if(sArrayDate[2].indexOf(":") < 0)
			return sArrayDate;
		else
		{
			sTemp = sArrayDate[2].split(" ");
			sArrayDate[2] = sTemp[0]; //日
			sTemp = sTemp[1];
			sTemp = sTemp.split(":");
			sArrayDate[3] = sTemp[0]; //小时
			sArrayDate[4] = sTemp[1]; //分
			return sArrayDate
		}
	}
	
	return "";
}

//将字符串转换为日期
function StringToDate(asDate)
{
	var sArrayDate = GetForDateStringArray(asDate);
			
	if(sArrayDate.length == 3)
		return new Date(sArrayDate[0],parseInt(sArrayDate[1],10) - 1,parseInt(sArrayDate[2],10))
	else if(sArrayDate.length == 5)
		return new Date(sArrayDate[0],parseInt(sArrayDate[1],10) - 1,parseInt(sArrayDate[2],10),parseInt(sArrayDate[3],10),parseInt(sArrayDate[4],10))
	else
		return null;
}
      



function SetNeed(asID)
{
	var strValue;        
    strValue = document.all("__MustInput_State").value;
    if(strValue != null&&strValue != "") 
    {
		if(strValue.indexOf(asID)!=-1)
        {
			return;
        }
    }
    if(strValue != null&&strValue != "") strValue += ",";
     
    strValue += asID;
     
    document.all("__MustInput_State").value = strValue;           
}

function DelNeed(asID)
{
    var strValue  
    var reg=  new RegExp(asID);
	strValue = document.all("__MustInput_State").value;
    strValue=strValue.replace(reg,"");
    document.all("__MustInput_State").value = strValue;  
}








function closePopupBill()
{
  oPopupForBillObjAttr.hide();
}
