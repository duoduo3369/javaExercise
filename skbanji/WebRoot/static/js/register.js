var RegistedString = "用户名已注册";
var NotRegistedString = "可用的用户名";

function isUsernameValid() {
	var isLengthValid = $("input[name=username]").val().length > 6;
	return isLengthValid;
}

function isPasswordValid(password) {
	return password.length > 6;
}

function isEmailValid() {
	return $("input[name=email]").val().length > 0;
}
function isTwoPasswordEquals() {
	var password_1 = $("input[name=password]").val();
	var password_2 = $("input[name=password2]").val();
	return password_1 == password_2;
}
function fillPasswordError() {
	if (!isTwoPasswordEquals()) {
		$("#password_error").html("输入两次的密码不相等");
	} else {
		$("#password_error").html("");
	}
}
function isAllValid() {
	var isRegisted = (RegistedString == $("#is_registed").html());
	return isUsernameValid() && isTwoPasswordEquals() && isEmailValid();
}
$(document).ready(function() {

			$("input[name=username]").blur(function() {

						$.get("/skbanji/servlet/IsRegisted", {
									username : $(this).val()
								}, function(response) {
									if (response == "true") {
										$("#is_registed").html(RegistedString);
										return false;

									} else {
										if (!isUsernameValid()) {
											$("#is_registed").html("用户名不合法,至少六个字母");

											return false;
										} else {
											$("#is_registed")
													.html(NotRegistedString);
											return true;
										}

									}
								});

					});
			$("input[name=password]").blur(function() {
						if ($("input[name=password2]").val()) {
							fillPasswordError();
						}
					});
			$("input[name=password2]").blur(fillPasswordError);
			$("#submit").click(function() {
						if (isAllValid()) {
							$("input[name=success]").val("37655a58s7830v0216");

							$("#register").submit();
						} else {
							return false;
						}
					});

		});