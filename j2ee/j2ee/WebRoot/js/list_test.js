$(document).ready(function() {
	$('ul#left_list li').each(function(i) {
				$(this).addClass("leftli fg-color-white bg-color-blue");
			});
	$('ul#right_list li').each(function(i) {
				$(this).addClass("rightli fg-color-white bg-color-green");
			});
	$('.leftli,.rightli').each(function(i) {
				$(this).click(function() {
							if ($(this).hasClass('leftli')) {
								$('ul#right_list').append($(this));
								$(this).removeClass('leftli')
										.addClass('rightli');
							} else {
								$('ul#left_list').append($(this));
								$(this).removeClass('rightli')
										.addClass('leftli');
							}
						});
			});
});
