<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%
	String path = request.getContextPath();
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>

<title>My JSP 'add_school.jsp' starting page</title>

<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">

<%@include file="/common_headers.jsp"%>
<script type="text/javascript" src="<%=STATIC_URL %>js/school.js"></script>

</head>

<body>
	<div>
		<form id="add_school" name="add_school" action="<%=path%>/servlet/banji/AddSchool"
			method="post">
			<label for="schoolname">学校名称</label> <input name="schoolname"
				type="text" />
			<div id="is_existed"></div>
			<input name="success" type="hidden" />
			<button id="check" type="button">检验学校名称</button>
			<button id="submit" type="submit" disabled="disabled">提交</button>
		</form>
	</div>
</body>
</html>
