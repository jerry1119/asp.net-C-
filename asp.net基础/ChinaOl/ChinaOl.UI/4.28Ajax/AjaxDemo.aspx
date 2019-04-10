<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="ChinaOl.UI._4._28Ajax.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnGetDate").click(function () {
                //开始通过AJAX向服务器发送请求。
                var xhr;
                if (XMLHttpRequest) {//高版本IE，谷歌，火狐等浏览器
                    xhr = new XMLHttpRequest();
                } else {//低版本IE
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xhr.open("get", "GetDate.ashx?name=jie&age=18", true);
                xhr.send();//开始发送
                //回调函数：当服务器将数据返回给浏览器后，自动调用该方法。
                xhr.onreadystatechange = function () {
                    if(xhr.readyState == 4){//表示服务端已经将数据完整返回，并且浏览器全部接受完毕
                        if (xhr.status == 200) {//判断 响应状态码是否为200
                            alert(xhr.responseText);
                        }
                    }
                }
            });
        });
    </script>
</head>
<body>
    <script src="../Js/jquery-1.7.1.js"></script>
    <form id="form1" runat="server">
    <div>
        <script src="../Js/jquery-1.7.1.js"></script>
    <input type="button" value="获取服务时间" id="btnGetDate" />
    </div>
    </form>
</body>
</html>
