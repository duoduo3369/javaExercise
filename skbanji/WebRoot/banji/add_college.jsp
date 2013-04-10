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
<script type="text/javascript" src="<%=STATIC_URL%>js/updateOptions.js"></script>
<script type="text/javascript" src="<%=STATIC_URL%>js/college.js"></script>

</head>

<body>
	<div>
		<form id="add_college" action="<%=path%>/servlet/banji/AddCollege"
			method="post">

			<label for="school_id">学校</label> <select id="schoolSelect"
				name="school_id">
				<option value="-1" selected="selected">-------------------</option>
			</select>

			<div id="add_school">
				<h1>
					<a>添加学校</a>
				</h1>
			</div>

			<label for="collegename">学院名称</label> <input name="collegename"
				type="text" />
			<div id="is_existed"></div>
			<input name="success" type="hidden" />
			<button id="check" type="button">检验学院名称</button>
			<button id="submit" type="submit" disabled="disabled">提交</button>
		</form>
	</div>
</body>
</html>
