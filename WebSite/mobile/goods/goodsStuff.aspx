<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodsStuff.aspx.cs" Inherits="WebSite.mobile.goods.goodsStuff" %>

<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <meta name="Keywords" content="<%=base.companyname %>" />
    <meta name="Description" content="<%=base.companyname %>" />
    <title>我的物品</title>
    <script src="../js/jquery.min.js"></script>
    <link href="../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" />
    <link href="../css/all.css" rel="stylesheet" />
    <link href="../css/goods.css" rel="stylesheet" />
    <script src="goodsStuff.js"></script>
    <style>
        ul li {line-height: 24px; font-size:13px; }
        ul {width:100%;}
        .m-menu .selected{background-color: #808080; color: #ffffff;}
    </style>
    <script>
        $(function () {
            selecttab(0);
        });
        var index = 0;
        function selecttab(idx) {
            index = idx;
            //alert(index);
            $(".m-menu").children().removeClass("selected");
            $(".m-menu div").eq(index).addClass("selected");
            init_goods(index);
        }
    </script>
</head>
<body class="m-detail-body">
    <uc1:header ID="header1" runat="server" />
    <script>
        settitle("我的物品");
        back("", "/mobile/goods/cart.aspx");
    </script>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 30px; margin: 1rem 0;">
            <div style="margin: 0 auto; width: 90%; border: 1px solid #808080;  border-radius: 2px;" class="m-menu">
                <div style="float: left; line-height: 30px; width: 50%; height: 30px; text-align: center;" onclick="selecttab(0);">未使用</div>
                <div style="float: left; line-height: 30px; width: 50%; height: 30px; text-align: center;" onclick="selecttab(1);">已使用</div>
                <div style="clear: both;"></div>
            </div>
        </div>
        <div class="m-detail-con" style="padding: 10px 0;">
            <%--这里写内容--%>
        </div>
        <div class="m_pager" style="">
            <a href="javascript:void(0);" onclick="bind_goods(index);" id="loading">加载更多...</a>
        </div>
    </form>
</body>
</html>
