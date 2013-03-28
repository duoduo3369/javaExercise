<%@ page language="java" import="java.util.*" pageEncoding="UTF8"%>
<%
	String path = request.getContextPath();
	String basePath = request.getScheme() + "://"
			+ request.getServerName() + ":" + request.getServerPort()
			+ path + "/";
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<base href="<%=basePath%>">

<title>My JSP 'list_test.jsp' starting page</title>

<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">

<meta http-equiv="Content-Type" content="text/html" charset="utf-8">
<%@include file="duoduo/headers.html"%>
<script type="text/javascript" src="js/list_test.js"></script>
<link rel="stylesheet" type="text/css" href="css/modern.css" />
<link rel="stylesheet" type="text/css" href="css/modern-responsive.css" />
<!-- 
<link rel="stylesheet" type="text/css" href="css/theme-dark.css" />
 -->

</head>

<body>
	<div class="container">
		<div >
			<h1>List变换练习</h1>
		</div>
		<div class="row">
			<div class="span6">
				<ul id="left_list" class="unstyled">
					<li>123k</li>
					<li>32</li>
					<li>adsf</li>
					<li>sadf</li>
					<li>3wqe</li>
					<li>dasf</li>
				</ul>
			</div>
			<div class="span6">
				<ul id="right_list" class="unstyled">
					<li>123k</li>
					<li>32</li>
					<li>adsf</li>
					<li>sadf</li>
					<li>3wqe</li>
					<li>dasf</li>
				</ul>
			</div>
		</div>
	</div>

</body>
</html>
