<?php 
/*
	fetch remote webpage
	
	use get method to specify the page url
	if url is not specified, then the default page will be fetched
	
	usage example: http://www.example.com/pagefetcher.php?url=http://www.baidu.com
	
	Author: Lance Liao
	Last updated: 2013-06-17

*/
	$page_url = "http://www.vpngate.net/en/"; 
	$page_content = "";
	
	if(isset($_GET) && isset($_GET["url"])) 
	{
		$page_url = $_GET["url"];
	}
	
	if(function_exists('curl_version'))
	{	
		$ch = curl_init(); 
		curl_setopt ($ch, CURLOPT_URL, $page_url); 
		curl_setopt ($ch, CURLOPT_RETURNTRANSFER, 1); 
		curl_setopt ($ch, CURLOPT_CONNECTTIMEOUT,10); 
		$page_content = curl_exec($ch); 
		
		echo $page_content; 
	}
	
	else if(ini_get('allow_url_fopen'))
	{
		$handle = fopen ($page_url, "rb"); 
		while (!feof($handle)) 
		{ 
			$page_content .= fread($handle, 8192); 
		} 
		fclose($handle); 
		
		echo $page_content;
	}
	
	else
	{
		echo "Sorry, No functions on this server to fetch " . $page_url;
	}	
?> 