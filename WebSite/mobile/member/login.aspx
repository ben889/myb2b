<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebSite.mobile.member.login" %>

<%@ Register Src="../common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1; maximum-scale=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <meta name="Keywords" content="" />
    <meta name="Description" content="" />
    <title>登陆</title>
    <link rel="stylesheet" href="../css/all.css" type="text/css" media="screen" />
    <link href="../css/form.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script language="javascript" src="../js/all.js"></script>
    <link href="../../js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="../../js/dialog/js/dialog.js"></script>
    <script>
        $(document).ready(function () {
            settitle("登录");
            back();
            refresh_parent_validatecode();
        });
        function success(info) {
            if (info != "") {
                alert(info);
            }
            window.location.href = "<%=fromurl %>";
        }
        function fail(info) {
            RemoveLoadDialog();
            if (info != "")
                alert(info);
        }
    </script>
    <script>
        function submitform() {
            if ($.trim($("#uname").val()) == "") {
                alert("请填写您的帐号/手机号");
                $("#uname").focus();
                return false;
            }
            if ($.trim($("#password").val()) == "") {
                alert("请填写您的密码");
                $("#password").focus();
                return false;
            }
            LoadDialog("登录中");
            document.getElementById('loginForm').submit();
        }
    </script>
    <script>
        function refresh_validatecode() {
            document.getElementById('yzm').src = '/inc/validatecode.aspx?' + new Date;
        }
        function refresh_parent_validatecode() {
            parent.refresh_validatecode();
        }
    </script>
</head>
<body class="body_con" style="background-color: #eeeeee; height: 100%;">
    <uc1:header ID="header1" runat="server" />
    <div class="form_content">
        <form action="login.aspx" id="loginForm" method="post" target="hd">
            <dl class="form">
                <dd>
                    <span class="tit">账号</span>
                    <input type="text" name="uname" placeholder="帐号/手机号" id="uname" class="textbox" />
                </dd>
                <dd>
                    <span class="tit">密码</span>
                    <input type="password" name="password" placeholder="请输入密码" id="password" class="textbox" />
                </dd>
            </dl>
            <dl class="form">
                <dd>
                    <span class="tit">验证码</span>
                    <input type="text" name="validatecode" placeholder="请输入验证码" id="validatecode" class="textbox" />
                    <a href="javascript:;" title="点击刷新" onclick="refresh_validatecode();" 
                        style="display:block;position:absolute;top:0px;right:8px; height:34px;margin-left: 20%;padding-top:8px;">
                    <img id="yzm" src="" alt="点击刷新" border="0" height="28" /></a>
                </dd>
            </dl>
             <div class="form_item" style="margin-top: 10px;">
                <a href="javascript:;" onclick="submitform();" class="btn_a btn_green" style="width: 60%;">登录</a>
                <a href="../member/reg.aspx" class="btn_a btn_orange" style="width: 38%; float: right;">注册</a>
                <input name="ac" type="hidden" value="login" />
            </div>
            
   
        </form>
        <iframe name="hd" style="display: none;"></iframe>
    </div>
</body>
</html>
