$(document).ready(function() {

	$("#submit").click(function() {
				var data = {
					username : $("input[name=username]").val(),
					password : $("input[name=password]").val()
				};

				$.post("/skbanji/servlet/account/Login", data, function(
								response) {
							if (response == "NOT OK") {
								$("#invaild_failed").html("用户名或密码错误");
								return false;
							} else {

								return true;
							}
						});
			});
});