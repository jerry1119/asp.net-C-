var working = false;
$('#state').click(function () {
    //e.preventDefault();
    var userName = $("#txtusername").val();//��������д  #  ,ע��һ��
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
        $("#msg").text("�û������벻��Ϊ��");
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