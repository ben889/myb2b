<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="WebSite.mobile.article" %>

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
    <title><%=title %></title>
    <link rel="stylesheet" href="css/all.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/form.css" type="text/css" media="screen" />
    <script language="javascript" src="js/jquery.min.js"></script>
    <style>
        #content img {
            max-width: 300px;
        }
    </style>
    <script language="javascript">
        $(document).ready(function () {
            back("more.aspx");
        });
    </script>
</head>
<body>
    <uc1:header ID="header" runat="server" />
    <div class="content">
        <center style="margin:5px 0px 5px 0px;">
            <h3><%=title %></h3>
            <%--<em style="color: #a4a4a4; font-size: 13px;">(about us)</em>--%>
        </center>
        <hr class="hr" />
        <div style="font-size: 14px; padding:8px 12px; line-height:1.6em;" id="content">
            <%=content%>
        </div>
    </div>
</body>
</html>
