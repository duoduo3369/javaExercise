function getData() {

	return {
		schoolname : $("input[name=schoolname]").val(),
		success : $("input[name=success]").val()
	};

}

$(document).ready(function() {

	
	$("#check").click(function() {

		var data = getData();
		$("input[name=success]").val("");

		$.get("/skbanji/servlet/banji/IsSchoolExisted", data,
				function(response) {

					if (response == "true") {
						$("#is_existed").html(data["schoolname"]
								+ "的信息已存在，请不要重复添加");

					} else {
						$("input[name=success]").val("a376dasf0v0216");
                        $("#is_existed").html("可用的学校名称");
						$("#submit").removeAttr("disabled");
					}
				});

	});

});
