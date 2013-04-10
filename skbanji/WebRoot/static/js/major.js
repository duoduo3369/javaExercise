function updateSelect(value, text) {

	$("#schoolSelect option:selected").removeAttr("selected");
	$("#schoolSelect").append("<option value='" + value
			+ "' selected='selected'>" + text + "</option>");
}

function isSchoolSelected() {
	return $("#schoolSelect option:selected").val() > 0;

}
function isCollegeSelected() {
	return $("#collegeSelect option:selected").val() > 0;
}
function makeSureSchoolSelected() {
	$("#submit").attr("disabled", "disabled");
	if (!isSchoolSelected()) {
		$("#is_existed").html("请先选择学校");
		$("#schoolSelect").focus();
		return false;
	}
	return true;
}
function makeSureCollegeSelected() {
	$("#submit").attr("disabled", "disabled");
	if (!isCollegeSelected()) {
		$("#is_existed").html("请先选择学院");
		$("#collegeSelect").focus();
		return false;
	}
	return true;
}
function makeSureMajorInputed() {
	$("#submit").attr("disabled", "disabled");
	if (!$("input[name=majorname]").val()) {
		$("#is_existed").html("请填写专业名称");
		$("input[name=majorname]").focus();
		return false;
	}
	return true;

}
$(document).ready(function() {
	$.getJSON("/skbanji/servlet/banji/GetSchools", null, function(data) {

		var schools = eval(data);
		$("#schoolSelect").empty();
		$("#schoolSelect")
				.append("<option value='-1' selected='selected'>-------------------</option>");
		$.each(schools, function(i) {
					$("#schoolSelect").append("<option value='" + schools[i].id
							+ "'>" + schools[i].name + "</option>");
				});
	});

	$("#schoolSelect").focus(function() {
				$("#submit").attr("disabled", "disabled");
			});
	$("input[name=majorname]").focus(function(){
        $("#submit").attr("disabled", "disabled");
        !makeSureSchoolSelected() || !makeSureCollegeSelected();
    });
	$("#schoolSelect").change(function() {
		$("#collegeSelect").empty();
		$("#collegeSelect")
				.append("<option value='-1' selected='selected'>-------------------</option>");
		if (isSchoolSelected()) {
			$("#college_message").html("");
			var schoolData = {
				school_id : $("#schoolSelect option:selected").val()
			};
			$.getJSON("/skbanji/servlet/banji/GetColleges", schoolData,
					function(data) {

						var majors = eval(data);

						$.each(majors, function(i) {
									$("#collegeSelect")
											.append("<option value='"
													+ majors[i].id + "'>"
													+ majors[i].name
													+ "</option>");
								});
					});
		}
	});
	$("#collegeSelect").focus(function() {
				$("#submit").attr("disabled", "disabled");
				if (!isSchoolSelected()) {
					$("#college_message").html("请先选择学校");
					$("#schoolSelect").focus();
				}
			});
	$("#check").click(function() {
		if (!makeSureSchoolSelected() || !makeSureCollegeSelected()
				|| !makeSureMajorInputed()) {
			return;
		}

		$("input[name=success]").val("");
		var data = {
			college_id : $("#collegeSelect option:selected").val(),
			majorname : $("input[name=majorname]").val()
		};
		$.get("/skbanji/servlet/banji/IsMajorExisted", data, function(
						response) {

					if (response == "true") {
						$("#is_existed").html($("input[name=majorname]").val()
								+ "的信息已存在，请不要重复添加");

					} else {
						$("input[name=success]").val("a376dasf0vsdf0216");
						$("#is_existed").html("可用的专业名称");
						$("#submit").removeAttr("disabled");
					}
				});
	});
	$("#add_school").click(function() {

		var win = window
				.open(
						'/skbanji/banji/add_school.jsp',
						'newwindow',
						'height=100,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
		win.focus();

	});
	$("input[name=collegename]").focus(function() {
				makeSureSchoolSelected();
			});
});