<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="WebSite.mobile.member.reg" %>

<%@ Register Src="../common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <title>注册</title>
    <link rel="stylesheet" href="../css/all.css" type="text/css" media="screen" />
    <link href="../css/form.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <link href="../../js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="../../js/dialog/js/dialog.js"></script>
    <%--<script src="../../mobile_auth/mobile_code.js"></script>--%>
    <script>
        $(document).ready(function () {
            settitle("注册");
            back("/mobile/index.aspx");
            refresh_parent_validatecode();
        });
    </script>
    <script>
        function submitform() {
            if ($.trim($("#uname").val()) == "") {
                alert("请填写您的手机号");
                $("#mobile").focus();
                return false;
            }
            if ($.trim($("#password").val()) == "") {
                alert("请填写您的密码");
                $("#password").focus();
                return false;
            }
            if ($.trim($("#confirm_password").val()) == "") {
                alert("请确认您的密码");
                $("#confirm_password").focus();
                return false;
            }
            if ($.trim($("#confirm_password").val()) != $.trim($("#password").val())) {
                alert("您的密码不一至");
                $("#password").focus();
                return false;
            }
            if ($.trim($("#auth_code").val()) == "") {
                alert("请填写手机验证码");
                $("#auth_code").focus();
                return false;
            }
            if ($.trim($("#validatecode").val()) == "") {
                alert("请填写图形验证码");
                $("#validatecode").focus();
                return false;
            }
            LoadDialog("注册中");
            document.getElementById('formUser').submit();
        }


    </script>
    <script>
        function success(info) {
            RemoveLoadDialog();
            if (info != "")
                alert(info);
            location.href = "index.aspx";
        }
        function fail(info) {
            RemoveLoadDialog();
            if (info != "")
                alert(info);
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
<body class="body_con">
    <uc1:header ID="header1" runat="server" />
    <div class="form_content">
        <form action="reg.aspx?method=reg" method="post" id="formUser" name="formUser"
            target="hd">
            <div class="form_row">
                <span class="label">手机号码</span>
                <input id="uname" type="text" placeholder="手机号用作登录使用" name="uname" class="form_input" />
                <div class="clear">
                </div>
            </div>
            <div class="col_2">
            </div>
            <div class="form_row">
                <span class="label">登录密码</span>
                <input type="password" name="password" placeholder="请输入您的密码" id="password" class="form_input" />
                <div class="clear">
                </div>
            </div>
            <div class="col_2">
            </div>
            <div class="form_row">
                <span class="label">确认密码</span>
                <input type="password" name="confirm_password" placeholder="请再次输入您的密码" id="confirm_password" class="form_input" />
                <div class="clear">
                </div>
            </div>
            <div class="col_2">
            </div>
            <div class="form_row">
                <span class="label">姓名</span>
                <input id="displayname" type="text" placeholder="请填写您的姓名" name="displayname" class="form_input" />
                <div class="clear">
                </div>
            </div>
            <div class="col_2">
            </div>
            <%if (owner_sell_id != null && owner_sell_id.Trim().Length > 0)
              { %>
            <div class="form_row">
                <span class="label">介绍人</span>
                <input type="text" placeholder="" id="owner_sell_displayname" class="form_input" readonly="readonly" value="<%=owner_sell_displayname %>" />
                <input name="sell_id" type="hidden" value="<%=owner_sell_id %>" />
                <div class="clear">
                </div>
            </div>
            <div class="col_2">
            </div>
            <%} %>
            <div style="height: 38px; margin-bottom: 10px;">
                <div class="form_row" style="width: 35%; float: left;">
                    <span class="label">图形验证码</span>
                    <input type="text" name="validatecode" placeholder="请输入右边验证码" id="validatecode" class="form_input" />

                    <div class="clear">
                    </div>
                </div>
                <div style="margin: 6px 0 0 4px; float: left;">
                    <a href="javascript:;" title="点击刷新" onclick="refresh_validatecode();"
                        style="display: block; padding-top: 0px;"><img id="yzm" src="" alt="点击刷新" border="0" height="28" /></a>
                   
                </div>
                <div class="clear">
                </div>
            </div>
            <div style="height: 38px; margin-bottom: 10px;display:none;">
                <div class="form_row" style="width: 35%; float: left;">
                    <span class="label">手机验证码</span>
                    <input type="text" name="auth_code" placeholder="请输入手机短信验证码" id="auth_code" class="form_input" />
                    <div class="clear">
                    </div>
                </div>
                <div style="margin: 6px 0 0 4px; float: left;">
                    <input id="checkcode" style="padding: 0px 4px; border: none; height: 26px; line-height: 26px; border-radius: 2px; color: #fff;"
                        class="button"
                        type="button" value="获取验证码" name="checkcode" onclick="send_mobilecode($('#uname').val(), $('#validatecode').val(), 'checkcode');" />
                </div>
                <div class="clear">
                </div>
            </div>

            <div style="text-align: left; padding: 2px; position: relative;">
                <input id="agreement" type="checkbox" name="agreement" value="1" /><font
                    style="margin-left: 10px; font-size: 12px;">己阅读并接受 <a href="/mobile/article.aspx?callindex=member_agree" style="color: #06F">&lt;&lt;用户协议&gt;&gt;</a></font>

            </div>
            <div class="col_2">
            </div>
            <div class="btn_b" style="width: 100%;">
                <input type="hidden" id="status" value="" />
                <a href="javascript:;" onclick="submitform();" class="btn_a btn_green" style="width: 100%">注册会员</a>
                <div style="clear: both;"></div>
            </div>

            <p class="form_item" style="text-align: right;">
                <a href="login.aspx" style="font-size: 12px;">已有帐号？现在登录</a>
            </p>
        </form>
        <form class="form" action="reg.aspx" method="post" id="changestate" name="changestate"
            target="hd">
            <input type="hidden" value="accode" name="accode" />
            <input type="hidden" id="sendcode_tel" name="sendcode_tel" />
            <input type="hidden" name="ac" value="sendsms" />
        </form>
        <iframe name="hd" style="display: none;"></iframe>
    </div>
</body>
</html>
