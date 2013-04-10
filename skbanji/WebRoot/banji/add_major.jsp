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
<script type="text/javascript" src="<%=STATIC_URL%>js/major.js"></script>

</head>

<body>
	<div>
		<form id="add_major" action="<%=path%>/servlet/banji/AddMajor"
			method="post">
			<div>
				<label for="school_id">学校</label> <select id="schoolSelect"
					name="school_id">
					<option value="-1" selected="selected">-------------------</option>
				</select>
				<div id="add_school">
					<h1>
						<a>添加学校</a>
					</h1>
				</div>
			</div>
			<div>
				<label for="college_id">学院</label> <select id="collegeSelect"
					name="college_id">
					<option value="-1" selected="selected">-------------------</option>
				</select>
				<div id="college_message"></div>
				<div id="add_college">
					<h1>
						<a>添加学院</a>
					</h1>
				</div>
			</div>
			<label for="majorname">专业名称</label> <input name="majorname" type="text" />
			<div id="is_existed"></div>
			<input name="success" type="hidden" />
			<button id="check" type="button">检验专业名称</button>
			<button id="submit" type="submit" disabled="disabled">提交</button>
		</form>
	</div>
</body>
</html>
