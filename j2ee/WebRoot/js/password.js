
function getData (){	
	return { username:$('#username').val(),
			 password:$('#password').val()};
}
function getResult(data)
{
	$(data).find('infomation').each(function(i){
		username = $(this).children('username').text();
		password = $(this).children('password').text();
		$('.show').append('<p>username:'+username+'</p>')
		.append('<p>password:'+password+'</p>');
	});	
}
function showPassWord()
{
	var url = "servlet/PassWordTest";
	$.post(url,getData(),getResult,'xml');
}
$(document).ready(function(){
	
	
	var $progress = $('div.progress');
	var $bar = $('div.bar');
	$($progress).hide();
	$('#validation').submit(function(event){			
		$($bar).css('width','0%');
		$($progress).show();
		event.preventDefault();
		$($bar).css('width','20%');
		showPassWord();
		$($bar).css('width','80%');
		$('div.passwordform').slideUp("slow");
		$($bar).css('width','100%');
		
	});
});
