function addOption(domId, value, text, isSelected) {
	if (isSelected) {
		var seleted = domId + " option:selected";
		$(seleted).removeAttr("selected");
		$(domId).append("<option value='" + value + "' selected='selected'>"
				+ text + "</option>");
	} else {
		$(domId).append("<option value='" + value + "'>" + text + "</option>");
	}

}
function updateSelect(domId, value, text) {
	addOption(domId, value, text, true);
}
function updataSchoolOptions() {

	$.getJSON("/skbanji/servlet/banji/GetSchools", null, function(data) {

		var schools = eval(data);
		$("#schoolSelect").empty();
		$("#schoolSelect")
				.append("<option value='-1' selected='selected'>-------------------</option>");
		$.each(schools, function(i) {
					addOption("#schoolSelect", schools[i].id, schools[i].name);
				});

	});
}