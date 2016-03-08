<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods.aspx.cs" Inherits="WebSite.mobile.goods.goods" %>

<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="/mobile/common/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0"/>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title>商品列表</title>
    <%--<link href="../css/mall.css" rel="stylesheet" />--%>
    <link href="../css/all.css" rel="stylesheet" />
    <link href="../css/mall_menu.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <link href="../css/goods.css" rel="stylesheet" />
    <script src="wx_goods.js"></script>
    <style>
        .m-row-list-item {
            padding: 8px 8px;
            border-bottom: 1px solid #DDD8CE;
            overflow: hidden;
            font-weight: 400;
            position: relative;
        }

    </style>
    <script>
        $(function () {
            init_goods();
        });
    </script>
</head>
<body class="m-detail-body">
    <div>
        <uc1:header ID="header_mall1" runat="server" />
        <script>
            settitle("兑换商品列表");
            back("", "/mobile/index.aspx");
        </script>
    </div>

    <%--列表--%>
    <div class="m-row-list">
        
    </div>
    <div class="m_pager" style="">
        <a href="javascript:void(0);" onclick="bind_goods();" id="loading">加载更多...</a>
    </div>
    <%--<script src="../../bootstrap/js/bootstrap.min.js"></script>--%>
</body>
</html>

