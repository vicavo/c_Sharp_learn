/************************************By Zheng Han Lin*****************************\
| �ð汾�������ڸ�ʽΪ��yyyy-mm-dd)
| �������ƣ�check_form
| ���������form(��)
| ����ֵ��boolean��
| �������ܣ��Զ���֤��������ֵ���ڿؼ��������֤���Լ��ɣ�����Ҫ�޸��κδ��롣
| ���÷�ʽ��onSubmit="return check_form(form1)"
| ��֤���Ը�ʽ��<input ... check_str="�ؼ�����" check_type="��֤����" can_empty="Y" equal="��һ���ؼ�������">
|     �����ͣ���дcheck_type
|     �ַ�����string,10,20
|     �����ͣ�integer,-111,120
|     �����ͣ�float,-2.1,10000
|     �����ͣ�date,2003��01��01��,2003��01��01��
|     ʱ���ԣ�time,8:30,18:30
|     ��  ����email
|     ���֤��idcard
|     ��֤���Դ����ŵı�ʾ��Сֵ�����ֵ�������ָ����д�������Ų���ʡ��
| ���ߣ�֣���� cqhanlin@163.com
| �������ڣ�2002��09��30��
|*********************************************************************************|
| �޸��ߣ�֣���� cqhanlin@163.com
| �޸����ڣ�2002��10��14��
| �޸Ĺ��ܣ�����can_empty���ԣ���ֵΪ"Y"ʱ����ʹ��check_str���ؼ���ֵҲ����Ϊ��
|	    ����Ҫ�����ǣ�Ҫô���䣬Ҫô���
|*********************************************************************************|
| �޸��ߣ�֣���� cqhanlin@163.com
| �޸����ڣ�2002��11��02��
| �޸Ĺ��ܣ�����equal���ԣ���ֵΪ��һ�ؼ������֣���֤���ǵ�ֵ�Ƿ���ȣ�������ȣ�
|*********************************************************************************|
| �޸��ߣ�֣���� cqhanlin@163.com
| �޸����ڣ�2007��01��04��
| �޸Ĺ��ܣ�����not_equal���ԣ���ֵΪ��һ�ؼ������֣���֤���ǵ�ֵ�Ƿ���ȣ�������ȣ�
|*********************************************************************************|
| �޸��ߣ�֣���� cqhanlin@163.com
| �޸����ڣ�2007��10��03��
| �޸Ĺ��ܣ��޸ĳ���֧��FireFox����form1.elements[1].check_str�޸�Ϊform1.elements[1].attributes["check_str"].value
|*********************************************************************************|
| �޸��ߣ�
| �޸����ڣ�
| �޸Ĺ��ܣ�
\*********************************************************************************/

function check_form(form1)
{

//	return false;
   try
   {
	var aa = form1.elements; //document.forms(form1.name).elements;
	var obj = null;
	var jumpFromFor = false;

	for (i=0;i<aa.length;i++)
	{
		jumpFromFor = true;  //�����;������jumpFromFor��ֵ��������Ϊtrue,��ʾ��֤δͨ��
		if(aa[i].attributes["check_str"]!=null && aa[i].attributes["check_str"].value!="")
		{
			obj = aa[i];

			if(obj.value.length==0)
			{
				if(obj.attributes["can_empty"]!=null && obj.attributes["can_empty"].value=="Y")
				{
					if(i==aa.length-1){jumpFromFor = false;}
					continue;
				}else
				{
					alert("��"+obj.attributes["check_str"].value+"������Ϊ�գ�����������","<br>");
					break;
				}
			}

			if(obj.attributes["equal"]!=null && obj.attributes["equal"].value.length>0)
			{
				var obj2 = eval(form1.name+"."+obj.attributes["equal"].value);
				if(obj2 != null)
				{
					if(obj.value != obj2.value)
					{
						alert("��"+obj.attributes["check_str"].value+"��" +
							"�����롺"+obj2.attributes["check_str"].value+"����ͬ")
						break;
					}
				}
			}

			if(obj.attributes["not_equal"]!=null && obj.attributes["not_equal"].value.length>0)
			{
				var obj2 = eval(form1.name+"."+obj.attributes["not_equal"].value);
				if(obj2 != null)
				{
					if(obj.value == obj2.value)
					{
						alert("��"+obj.attributes["check_str"].value+"��" +
							"�롺"+obj2.attributes["check_str"].value+"��������ͬ")
						break;
					}
				}
			}

			if(obj.attributes["check_type"]!=null)
			{
				if(obj.attributes["check_type"].value=="email")
				{
					if(!checkEmail(obj))
					{
						alert("������ġ�" + obj.attributes["check_str"].value+"�����ǺϷ����ʼ���ʽ","<br>");
						break;
					}
				}
			
				if(obj.attributes["check_type"].value=="idcard")
				{
					if(!checkIDCard(obj))
					{
						alert("������ġ�" + obj.attributes["check_str"].value+"�����ǺϷ������֤","<br>");
						break;
					}
				}
			
				if(/^string/.test(obj.attributes["check_type"].value))
				{
					tempArr = check_string(obj);
					if(!tempArr[0])
					{
						alert(tempArr[1]);
						break;
					}
				}

				if(/^float/.test(obj.attributes["check_type"].value))
				{
					tempArr = checkFloat(obj);
					if(!tempArr[0])
					{
						alert(tempArr[1]);
						break;
					}
				}

				if(/^integer/.test(obj.attributes["check_type"].value))
				{
					tempArr = checkInteger(obj);
					if(!tempArr[0])
					{
						alert(tempArr[1]);;
						break;
					}
				}
			
				if(/^date/.test(obj.attributes["check_type"].value))
				{
					tempArr = checkDate(obj);
					if(!tempArr[0])
					{
						alert(tempArr[1]);;
						break;
					}
				}
			
				if(/^time/.test(obj.attributes["check_type"].value))
				{
					tempArr = checkTime(obj);
					if(!tempArr[0])
					{
						alert(tempArr[1]);;
						break;
					}
				}
			}
			
		}
		jumpFromFor = false; //ѭ������������δ��ѭ��������,��֤�����ȫ������Ҫ��			
	}
	if(jumpFromFor)
	{
		try
		{
			obj.focus();
			if(obj.type=="text") {obj.select();}
		}
		catch(aa){}
		return false;
	}
	return true;
   }
   catch(err)
   {
//	alert(err+i);
	alert(err.Description);
	return false;
   }
}

function checkEmail(obj)
{
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return true;
//	return(/^([\.\S]){1,}@([\S-]){1,}(\.([\S]){1,}){1,}$/.test(obj.value));
	return(/^\w+([-.]\w+)*@([\w-]){1,}(\.([\w]){1,}){1,}$/.test(obj.value));
}

function checkIDCard(obj)
{
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return true;
	if(obj.value.length==15)
		return(/^([0-9]){15,15}$/.test(obj.value));
	if(obj.value.length==18)
		return(/^([0-9]){17,17}([0-9xX]){1,1}$/.test(obj.value));
	return false;
}

function check_string(obj)
{
	var tempArr = new Array(true,"");
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return tempArr;
	var length = obj.value.length;
	
	var arr = obj.attributes["check_type"].value.split(",");
	var smallLength = parseInt(arr[1]);
	var bigLength= parseInt(arr[2]);
	
	if(length<smallLength)
	{
		tempArr[0]=false;
		tempArr[1]="��"+ obj.attributes["check_str"].value+"�����Ȳ���С��"+smallLength+"������������";
		return tempArr;
	}
	if(length > bigLength)
	{
		tempArr[0]=false;
		tempArr[1]="��"+obj.attributes["check_str"].value+"�����Ȳ��ܴ���"+bigLength+"������������";
		return tempArr;
	}
	return tempArr;
}

function checkFloat(obj)
{
	var tempArr = new Array(true,"");
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return tempArr;
	if(!(/^([-]){0,1}([0-9]){1,}([.]){0,1}([0-9]){0,}$/.test(obj.value))) 
	{
		tempArr[0]=false;
		tempArr[1]="���ǺϷ���ʵ�������������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	var floatValue = parseFloat(obj.value);
	var arr = obj.attributes["check_type"].value.split(",");
	var smallFloat = parseFloat(arr[1]);
	var bigFloat = parseFloat(arr[2]);
	if(floatValue<smallFloat)
	{
		tempArr[0]=false;
		tempArr[1]="����С��"+smallFloat+"�����������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	if(floatValue > bigFloat)
	{
		tempArr[0]=false;
		tempArr[1]="���ܴ���"+bigFloat+"�����������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	return tempArr;
}

function checkInteger(obj)
{
	var tempArr = new Array(true,"");
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return tempArr;
	if(!(/^([-]){0,1}([0-9]){1,}$/.test(obj.value)))
	{
		tempArr[0]=false;
		tempArr[1]="���ǺϷ������������������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	var integerValue = parseInt(obj.value);
	var arr = obj.attributes["check_type"].value.split(",");
	var smallInteger = parseInt(arr[1]);
	var bigInteger = parseInt(arr[2]);
	if(integerValue<smallInteger)
	{
		tempArr[0]=false;
		tempArr[1]="����С��"+smallInteger+"�����������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	if(integerValue > bigInteger)
	{
		tempArr[0]=false;
		tempArr[1]="���ܴ���"+bigInteger+"�����������롺" + obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	return tempArr;
}

function checkDate(obj)
{
	var tempArr = new Array(true,"");
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return tempArr;
	if(!(/^([0-9]){4,4}-([0-9]){1,2}-([0-9]){1,2}$/.test(obj.value))) 
	{
		tempArr[0] = false;
		tempArr[1] = "���ǺϷ������ڣ��밴\"YYYY-MM-DD\"�ĸ�ʽ���롺"+obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	var arr = obj.value.match(/\d+/g);
	year = Number(arr[0]);
	month = Number(arr[1]);
	day = Number(arr[2]);
	var monthDay = new Array(31,28,31,30,31,30,31,31,30,31,30,31);
	if(year%400==0||(year%4==0&&year%100!=0))	monthDay[1] = 29;
	if(year<0 || month<0 || month>12 || day>31 ||day>monthDay[month-1])
	{
		tempArr[0] = false;
		tempArr[1] = "��������һ�������ڵ����ڣ����������롺"+obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	arr = obj.attributes["check_type"].value.split(",");
	if(arr[1].length>0)
	{
		var arr2 = arr[1].match(/\d+/g);
		var smallYear = Number(arr2[0]);
		var smallMonth = Number(arr2[1]);
		var smallDay = Number(arr2[2]);
		if(smallYear>year || (smallYear==year&&smallMonth>month) || (smallYear==year&&smallMonth==month&&smallDay>day))
		{
			tempArr[0] = false;
			tempArr[1] = "���ڲ���С��"+arr[1]+"�����������롺"+obj.attributes["check_str"].value+"��";
			return tempArr;
		}
	}
	
	if(arr[2].length>0)
	{
		arr2 = arr[2].match(/\d+/g);
		var bigYear = Number(arr2[0]);
		var bigMonth = Number(arr2[1]);
		var bigDay = Number(arr2[2]);
		if(bigYear<year || (bigYear==year&&bigMonth<month) || (bigYear==year&&bigMonth==month&&bigDay<day))
		{
			tempArr[0] = false;
			tempArr[1] = "���ڲ��ܴ���"+arr[2]+"�����������롺"+obj.attributes["check_str"].value+"��";
			return tempArr;
		}
	}
	return tempArr;
}


function checkTime(obj)
{
	var tempArr = new Array(true,"");
//	if(obj.attributes["can_empty"].value=="Y" && obj.value.length==0) return tempArr;
	if(!(/^([0-9]){1,2}:([0-9]){1,2}$/.test(obj.value))) 
	{
		tempArr[0] = false;
		tempArr[1] = "���ǺϷ���ʱ�䣬�밴\"hh:mm\"�ĸ�ʽ���롺"+obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	var arr = obj.value.match(/\d+/g);
	hour = Number(arr[0]);
	minute = Number(arr[1]);
	if(hour<0 || hour>=24 || minute <0 || minute>=60)
	{
		tempArr[0] = false;
		tempArr[1] = "��������һ�������ڵ�ʱ�䣬���������롺"+obj.attributes["check_str"].value+"��";
		return tempArr;
	}
	arr = obj.attributes["check_type"].value.split(",");
	if(arr[1].length>0)
	{
		var arr2 = arr[1].match(/\d+/g);
		var smallHour = Number(arr2[0]);
		var smallMinute = Number(arr2[1]);
		if(smallHour>hour || (smallHour==hour&&smallMinute>minute))
		{
			tempArr[0] = false;
			tempArr[1] = "ʱ�䲻��С��"+arr[1]+"�����������롺"+obj.attributes["check_str"].value+"��";
			return tempArr;
		}
	}
	
	if(arr[2].length>0)
	{	
		arr2 = arr[2].match(/\d+/g);
		var bigHour = Number(arr2[0]);
		var bigMinute = Number(arr2[1]);
		if(bigHour<hour || (bigHour==hour&&bigMinute<minute))
		{
			tempArr[0] = false;
			tempArr[1] = "ʱ�䲻�ܴ���"+arr[2]+"�����������롺"+obj.attributes["check_str"].value+"��";
			return tempArr;
		}
	}
	return tempArr;
}