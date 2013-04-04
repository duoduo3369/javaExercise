<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>

<title>My JSP 'register.jsp' starting page</title>

<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">
<%@include file="/common_headers.jsp"%>
<script type="text/javascript" src="<%=STATIC_URL%>js/register.js"></script>

</head>

<body>
	<div>
		<!-- <form id="register" action="javascript:void%200" method="post"> -->
		<form id="register" action="<%=path%>/servlet/account/register"
			method="post">
			<label for="username">用户名</label> <input name="username" type="text" />
			<div id="is_registed"></div>
			<label for="password">密码</label> <input name="password"
				type="password" /> <label for="password2">确认密码</label> <input
				name="password2" type="password" />
			<div id="password_error"></div>
			<label for="email">邮箱</label> <input name="email" type="text" /> <input
				name="success" type="hidden" />
			<button id="submit" type="submit">提交</button>
		</form>
	</div>
</body>
</html>
