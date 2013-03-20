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

<title>My JSP 'passwordtest.jsp' starting page</title>

<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="expires" content="0">
<meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
<meta http-equiv="description" content="This is my page">

<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
<link rel="stylesheet" type="text/css"
	href="css/bootstrap-responsive.css">
<script type="text/javascript" src="js/jquery-1.9.1.js">
	
</script>
<script type="text/javascript" src="js/bootstrap.js">
	
</script>
<script type="text/javascript" src="js/password.js">
	
</script>


</head>

<body>
	<div class="container">
		<div class="page-header">
			<h1>密码测试练习</h1>
		</div>
		<div class="passwordform">
			<form id='validation' class="form-horizontal" name="validation"
				action="javascript:void%200" method="post">
				<fieldset>
					<div id="legend" class="">
						<legend class="">密码测试</legend>
					</div>


					<div class="control-group">

						<!-- Text input-->
						<label class="control-label" for="username">用户名</label>
						<div class="controls">
							<input id="username" placeholder="用户名" class="input-xlarge"
								name="username" type="text">
							<p class="help-block">请输入用户名</p>
						</div>
					</div>

					<div class="control-group">

						<!-- Text input-->
						<label class="control-label" for="password">密码</label>
						<div class="controls">
							<input id="password" placeholder="密码" class="input-xlarge"
								name="password" type="password">
							<p class="help-block">请输入密码</p>
						</div>
					</div>

					<div class="control-group">


						<!-- Button -->
						<div class="controls">
							<button class="btn btn-success" type='submit'>提交</button>
						</div>
					</div>

				</fieldset>
			</form>
		</div>
		<div class="show"></div>
	</div>
	<footer class="footer">
	<div class="container">
		<div class="progress">
			<div class="bar"></div>
		</div>
	</div>

	</footer>
</body>
</html>
