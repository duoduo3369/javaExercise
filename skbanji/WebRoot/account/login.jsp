<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>

<title>登录</title>

<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">
<%@include file="/common_headers.jsp"%>


</head>

<body>
	<div>
		<!-- <form id="register" action="javascript:void%200" method="post"> -->
		<form id="login" action="/skbanji/servlet/account/Login" method="post">
			<label for="username">用户名</label> <input name="username" type="text" />

			<label for="password">密码</label> <input name="password"
				type="password" />
			<div id="invaild_failed"></div>
			<button id="submit" type="submit">提交</button>
		</form>
		<h1><a href="<%=path %>/account/register.jsp">注册</a></h1>
	</div>
</body>
</html>
