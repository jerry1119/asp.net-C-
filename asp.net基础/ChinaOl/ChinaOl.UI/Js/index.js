var working = false;
$('#state').click(function () {
    //e.preventDefault();
    var userName = $("#txtusername").val();//老是忘了写  #  ,注意一下
    var userPwd = $("#txtuserpwd").val();
    if (userName != "" && userPwd != "") {
        $.post("userLogin.ashx", { "userName": userName, "userPwd": userPwd },
            function (data) {
                var serverData = data.split(':');
                if (serverData[0] == "ok") {
                    window.location.href = "/4.13autoLogin/UserInfiList.aspx";
                    //$("#msg").css("display", "block");
                }
                    //$("#msg").text(serverData[1]);
             
            });
    }
    else {
        $("#msg").css("display", "block");
        $("#msg").text("用户名密码不能为空");
    }
  
  
  var $this = $(this),
    $state = $this.find('button > .state');
  $this.addClass('loading');
  $state.html('Authenticating');
  setTimeout(function() {
    $this.addClass('ok');
    $state.html('Welcome back!');
    setTimeout(function() {
      $state.html('Log in');
      $this.removeClass('ok loading');
      working = false;
    }, 4000);
  }, 3000);
});