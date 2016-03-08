<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSite.mobile.member.index" %>

<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="/mobile/common/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1; maximum-scale=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <link rel="apple-touch-icon" sizes="114x114" href="../images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="../images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <meta name="Keywords" content="" />
    <meta name="Description" content="" />
    <title>我的</title>
    <link rel="stylesheet" href="../css/all.css" type="text/css" media="screen" />
    <link href="../css/global.css" rel="stylesheet" />
    <link href="../css/member.css" rel="stylesheet" />
    <script language="javascript" src="../js/jquery.min.js"></script>
    <script language="javascript">
        $(document).ready(function () {
            settitle("我的");
            back();
        });
        function exitbut() {
            $("#zhezhao").show();
            $("#exitbox").show();
        }
        function rexit() {
            window.location.href = "/mobile/member/logout.aspx";
        }
        function noexit() {
            $("#zhezhao").hide();
            $("#exitbox").hide();
        }
    </script>
    <script>

        var msg_num = 0;
        var num = String(msg_num);
        window.code.getReturnMsg(String(msg_num));
    </script>
</head>
<body class="body_con" style="background-color: #eeeeee; height: 100%;">
    <uc1:header ID="header1" runat="server" />
    <div class="header-height"></div>
    <div class="sjname_bj">
        <div class="hyname snh" style="font-size: 16px; padding: 10px 10px 10px 10px;">
            <%--<div style="height: 48px; width: 48px; border-radius: 24px; box-sizing:border-box; float: left; border: 1px solid #ffffff; overflow: hidden;">
                <img src="" style="height: 48px;" />
            </div>--%>
            <div style="padding: 0 0 0 16px; height: 48px;line-height:48px;">
                <%=displayname %>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>
    <div class="content">
        <div style="height:10px;"></div>
        <ul class="hylist">
            <li><a href="../goods/goodsStuff.aspx"><span class="ico fa fa-file-text" style="color: #ff9900;"></span><span class="jt"></span>我的物品</a></li>
            <%--<li><a href="javascript:;"><span class="ico fa fa-cny" style="color: #ff9900;"></span>拥金 (0)<span class="jt"></span></a></li>
            <li><a href="member_CashRecord.aspx"><span class="ico fa fa-file-text-o" style="color: #ff9900;"></span>收支记录<span class="jt"></span></a></li>--%>
        </ul>
        <div style="height:10px;"></div>
        <ul class="hylist">
            <li><a href="myfs.aspx"><span class="ico fa fa-users" style="color: #ff9900;"></span>分享推广<span class="jt"></span></a></li>
            <li><a href="tel:"><span class="ico fa fa-phone" style="color: #ff9900;"></span>客服热线</a></li>
        </ul>
    </div>
    <div style="height: 60px;"></div>
    <footer id="footer">
        <uc2:footer ID="footer1" runat="server" />
    </footer>
</body>
</html>
