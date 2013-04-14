<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
	<head>

		<title>新用户注册</title>

		<meta http-equiv="pragma" content="no-cache">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="expires" content="0">

	</head>

	<body>
		<div>
			<form id="register" action="Register.action" method="post">
				<label for="user.name">
					用户名
				</label>
				<input name="user.name" type="text" />
				<div id="is_registed"></div>
				<label for="user.password">
					密码
				</label>
				<input name="user.password" type="password" />
				<!-- <label for="password2">
					确认密码
				</label>
				<input name="password2" type="password" />
				 -->
				<div id="password_error"></div>
				<label for="user.userEmail">
					邮箱
				</label>
				<input name="user.userEmail" type="text" />
				<input name="success" type="hidden" />
				<button id="submit" type="submit">
					提交
				</button>
			</form>
		</div>
	</body>
</html>
