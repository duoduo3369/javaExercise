
function isSchoolSelected() {
	return $("#schoolSelect option:selected").val() > 0;

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
$(document).ready(function() {
	$.getJSON("/skbanji/servlet/banji/GetSchools", null, function(data) {

        var schools = eval(data);
        $("#schoolSelect").empty();
        $("#schoolSelect")
                .append("<option value='-1' selected='selected'>-------------------</option>");
        $.each(schools, function(i) {
                    addOption("#schoolSelect", schools[i].id, schools[i].name);
                });

    });
	$("#schoolSelect").focus(function() {
				$("#submit").attr("disabled", "disabled");
			});
	$("#check").click(function() {
		if (!makeSureSchoolSelected()) {
			return;
		}

		$("input[name=success]").val("");
        var data={
            school_id : $("#schoolSelect option:selected").val(),
            collegename : $("input[name=collegename]").val()
        };
		$.get("/skbanji/servlet/banji/IsCollegeExisted", data, function(
						response) {

					if (response == "true") {
						$("#is_existed").html(data["collegename"] + "的信息已存在，请不要重复添加");

					} else {
						$("input[name=success]").val("a376dasf0vsdf0216");
						$("#is_existed").html("可用的学院名称");
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