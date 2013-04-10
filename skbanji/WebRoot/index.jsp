<%@ page language="java"
	import="java.util.*,com.sinaapp.skbanji.db.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
	String basePath = request.getScheme() + "://"
			+ request.getServerName() + ":" + request.getServerPort()
			+ path + "/";
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<title>首页</title>
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">

<%@include file="common_headers.jsp"%>
<script type="text/javascript" src="<%=STATIC_URL %>js/index.js"></script>
</head>

<body>
	<div class="page">
		<h1>
			<a href="<%=path%>/account/register.jsp">注册</a>
		</h1>
		<h1>
			<a href="<%=path%>/account/login.jsp">登录</a>
		</h1>
		<h1>
			<a href="<%=path%>/servlet/account/Logout">注销</a>
		</h1>
		<div id="add_school" class="add">
			<h1>
				<a >添加学校</a>
			</h1>
		</div>
		<div id="add_college" class="add">
			<h1><a>添加学院</a></h1>
		</div>
		<div id="add_major" class="add">
			<h1><a>添加专业</a></h1>
		</div>
		
	</div>
</body>
</html>
