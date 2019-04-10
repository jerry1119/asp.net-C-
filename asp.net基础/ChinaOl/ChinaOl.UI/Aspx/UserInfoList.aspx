<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoList.aspx.cs" Inherits="ChinaOl.UI.Aspx.UserInfoList" %>

<!DOCTYPE html>
<%@ Import Namespace="ChinaOl.Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        //window.onload = function () {
        //    var datas = document.getElementByClassName("deletes");
        //    var dataLength = datas.dataLength;
        //    for (var i = 0; i < dataLength; i++) {
        //        datas[i].onclick = function () {
        //            if (!confirm("确定要删除吗？")) {
        //                return false;
        //            }
        //        }
        //    }

        //};
    </script>
    <link href="../Css/tableStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <a href="AddUserInfo.aspx">添加</a>
    <table>
        <tr>
            <th>编号</th>
            <th>用户名</th>
            <th>密码</th>
            <th>邮箱</th>
            <th>时间</th>
            <th>详细</th>
            <th>删除</th>
            <th>编辑</th>
        </tr>

      <%--  <%=StrHtml %>--%>
        <%foreach (UserInfo userinfo in UserList){ %>
        <tr>
            <td><%=userinfo.UserId %></td>
            <td><%=userinfo.UserName %></td>
            <td><%=userinfo.UserPwd %></td>
            <td><%=userinfo.Email %></td>
            <td><%=userinfo.RegTime.ToShortDateString() %></td>
            <td><a href="Delete.ashx?id=<%=userinfo.UserId %>"class="deletes">删除</a></td>
            <td>详细</td>
            <td><a href="EditUser.aspx?id=<%=userinfo.UserId %>">编辑</a></td>
        </tr>


        <%} %>
    </table>
    </div>
    </form>
</body>
</html>
