
function getData (){	
	return { username:$('#username').val(),
			 password:$('#password').val()};
}
function getResult(data)
{
	$(data).find('infomation').each(function(i){
		var username = $(this).children('username').text();
		var password = $(this).children('password').text();
		$('.show').append('<p>用户名'+username+'</p>')
		.append('<p>密码:'+password+'</p>');
	});	
}
function showPassWord()
{
	var url = "servlet/PassWordTest";
	//$.post(url,getData(),getResult,'xml');
	var inputdata = getData();
	$.post(url,inputdata,function(data){
		if(data == "OK"){
			var username = inputdata['username'];
			var password = inputdata['password'];
			$('.show').append('<p>测试成功</p>').append('<p>用户名'+username+'</p>')
			.append('<p>密码:'+password+'</p>');
		}
		else{
			$('.show').append("<p>非法用户名</p>");
		}
	});
}
$(document).ready(function(){
	
	var $progress = $('div.progress');
	var $bar = $('div.bar');
	$(".checkagain").hide();
	$($progress).hide();
	$('#validation').submit(function(event){			
		$($bar).css('width','0%');
		$($progress).show();
		event.preventDefault();
		$($bar).css('width','20%');
		showPassWord();
		$($bar).css('width','80%');
		$('div.passwordform').slideUp('slow');
		$($bar).css('width','100%');
		$($progress).hide('slow');
		$('.checkagain').show();
	});
	$('button.checkagain').click(function(){
		$('.checkagain').hide();
		$('.show').html("");
		$('div.passwordform').slideDown('slow');
	});
});
