<%@page import="java.sql.Connection,javax.naming.InitialContext,javax.sql.DataSource"%>
<%@ page language="java" import="java.util.*,com.sinaapp.skbanji.db.util.*" pageEncoding="ISO-8859-1"%>
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
		
DBManager dbManager = new DBManager();
Connection connection = dbManager.getConnection();
connection.close();
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
  <head>
    <base href="<%=basePath%>">
    
    <title>My JSP 'index.jsp' starting page</title>
	<meta http-equiv="pragma" content="no-cache">
	<meta http-equiv="cache-control" content="no-cache">
	<meta http-equiv="expires" content="0">    
	<meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
	<meta http-equiv="description" content="This is my page">
	<!--
	<link rel="stylesheet" type="text/css" href="styles.css">
	-->
	<%@include file="common_headers.jsp"%>
  </head>
  
  <body>
    path <%=path %>/static/css <%=basePath%> <br>
  </body>
</html>
