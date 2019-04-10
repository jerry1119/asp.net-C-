﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChinaOl.UI._4._13autoLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type ="text/javascript">
        window.onload = function () {
            var validateCode = document.getElementById("validateCode");
            validateCode.onclick = function () {
                document.getElementById("imgCode").src = "ValidateCode.ashx?d=" + new Date().getMilliseconds();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名：<input type="text" name="txtName" value="<%=LonginUserName %>"/><br/>
        密码：<input type="password" name="txtPwd" /><br/> 
        验证码：<input type="text" name="txtCode" /><img src="ValidateCode.ashx" id="imgCode"/><a href="javascript:void(0)" id="validateCode">看不清</a><br/>
        <input type ="checkbox" name="autoLogin" value="auto"/>3天内自动登录<br/>
        <input type="submit" value="登录" /><span style="font-size:14px;color:red"><%=Msg %></span>
    </div>
    </form>
</body>
</html>
