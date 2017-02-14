<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_lb.aspx.cs" Inherits="qpoa.WorkFlow.DIYForm_add_lb" %>

<html>
<head>
<title>下拉菜单设定</title>
  <LINK href="../css/public.css" type="text/css" rel="stylesheet">

<script>
function my_submit()
{




  var parent_window = parent.dialogArguments;

  var option_str="";
  for(i=1;i<=50;i++)
  {
      var item_str="item_"+i;
      if(document.all(item_str).value!="")
        option_str+="<option name='"+document.all(item_str).value+"'>"+document.all(item_str).value+"</option>";
  }
  control_html="<select name=\""+ITEM_NAME.value.replace("\"","&quot;")+"\" style=\"font-size:"+ITEM_SIZE.value+"\">"+option_str+"</select>";

  if(edit_flag==1)
  {
    oSelection =  parent.dialogArguments.document.selection.createRange();
    oSelection(0).name=ITEM_NAME.value;
    window.opener.qiupengmodel(control_html);
  }
  else
     window.opener.qiupengmodel(control_html);

  window.close();
}

//-- 获取控件属性 --
var edit_flag=0;
function LoadDo()
{
  document.getElementById('ITEM_NAME').value=<%=Request.QueryString["cValue"]%>;
  oSelection = dialogArguments.document.selection.createRange();
  sRangeType = dialogArguments.document.selection.type;

  if (sRangeType == "Control")
  {
  	edit_flag=1;
  	ITEM_NAME.value = oSelection(0).name;
  	ITEM_SIZE.value = oSelection(0).style.fontSize.replace("px","");

  	for (i=0; i<oSelection(0).options.length; i++)
  	{
  	    var item_str="item_"+(i+1);
  	    document.all(item_str).value =  oSelection(0).options(i).text;
  	}
  }
  ITEM_NAME.focus();
}
</script>
</head>

<body topmargin="0" onload="LoadDo();">

<table border="1" cellspacing="0" width="100%"  cellpadding="3" align="center">
    <tr>
        <td colspan="2" nowrap="nowrap">
        
        </td>
    </tr>
  <tr >
      <td nowrap colspan="2">
      <Input name="ITEM_NAME" type="text"  size="20"   style="DISPLAY: none">
      <input type="button" onclick="my_submit();" value="确 定" >
      </td>
  </tr>
  <tr >
      <td nowrap colspan="2">字体大小：
       <Input name="ITEM_SIZE" type="text"  size="20" title="可选，默认13像素">
      </td>
  </tr>
  <tr>
      <td nowrap align="center"　bgcolor="#cccccc">序号</td>
      <td nowrap align="center" title="Tab键切换输入框"　 >输入下拉菜单项目&nbsp;&nbsp;
      </td>
  </tr>
  <tr >
      <td nowrap align="center">1</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_1" type="text" size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">2</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_2" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">3</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_3" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">4</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_4" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">5</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_5" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">6</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_6" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">7</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_7" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">8</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_8" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">9</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_9" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">10</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_10" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">11</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_11" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">12</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_12" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">13</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_13" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">14</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_14" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">15</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_15" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">16</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_16" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">17</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_17" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">18</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_18" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">19</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_19" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">20</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_20" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">21</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_21" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">22</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_22" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">23</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_23" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">24</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_24" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">25</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_25" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">26</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_26" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">27</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_27" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">28</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_28" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">29</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_29" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">30</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_30" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">31</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_31" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">32</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_32" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">33</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_33" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">34</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_34" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">35</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_35" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">36</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_36" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">37</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_37" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">38</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_38" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">39</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_39" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">40</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_40" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">41</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_41" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">42</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_42" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">43</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_43" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">44</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_44" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">45</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_45" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">46</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_46" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">47</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_47" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">48</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_48" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">49</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_49" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">50</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_50" type="text"  size="30"></td>
  </tr>
    <tr>
        <td align="center" colspan="2" nowrap="nowrap" >
           <input type="button" onclick="my_submit();" value="确 定" >
        </td>
    </tr>
  

  
</table>

</body>
</html>