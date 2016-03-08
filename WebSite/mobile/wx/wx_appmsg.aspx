<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_appmsg.aspx.cs" Inherits="WebSite.mobile.wx.wx_appmsg" %>

<%@ Register Src="~/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1; maximum-scale=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <meta name="Keywords" content="" />
    <meta name="Description" content="" />
    <title><%=Name %></title>
    <link rel="stylesheet" href="../css/all.css" type="text/css" media="screen" />
    <link href="../css/article.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/jquery.min.js"></script>
    <style>
        .article_content img,.article_img img {
            width: 100%;
            height:auto;
        }
    </style>
    <script language="javascript">
        $(document).ready(function () {
            back();
            settitle("<%=Name %>");
        });
    </script>
</head>
<body>
    <uc1:header ID="header" runat="server" />
    <div class="header-height"></div>
    <div class="article-detail-con">
        <div class="article_title_con">
            <h3 class="article_title"><%=Name %></h3>
            <div class="article_subtitle"><span class="article_subtitle_small"><%=CreateTime%></span></div>
        </div>
        <div class="article_img"><%=ImgUrl%></div>
        <div class="article_content">
            <%=Body%>
        </div>
    </div>
</body>
</html>
