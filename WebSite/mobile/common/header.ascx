<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebSite.mobile.common.header" %>
<link href="/css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
<div class="header" id="header">
    <%--<ul>
            <li class="img"></li>
            <li class="search"><a style="display: block; width: 44px; height: 44px;" href="./search.php" data-ajax="false" class="ui-link"></a> </li>
        </ul>
        <span class="qy"></span><span class="tit"><a href="/" data-ajax="false" class="ui-link">&nbsp;&nbsp;</a></span>--%>
    <a id="aback" href="javascript:history.back();" data-ajax="false" class="h_btn_lf go_back"></a>
    <%--<a id="aback" href="javascript:history.go(-1);" data-ajax="false" class="h_btn_lf go_back"></a>--%>
    <h1 class="header_tit">&nbsp;&nbsp;</h1>
    <div class="h_btn_rg" onclick="header_menu_slide();">
        <a id="a2" href="javascript:void(0);" class="fa fa-list"></a>
        <ul id="header_menu">
            <li><a href="/mobile/index.aspx"><i class="fa fa-home" ></i>首页</a></li>
            <li><a href="/mobile/member/index.aspx" ><i class="fa fa-user" ></i>个人中心</a></li>
        </ul>
    </div>
</div>

<script>
    function back(url) {
        if (url != "" && url != undefined)
            $("#aback").attr("href", url);
    }
    function settitle(title) {
        $(".header_tit").html(title);
    }
    function header_menu_slide() {
        $("#header_menu").slideToggle(200);
    }
</script>
