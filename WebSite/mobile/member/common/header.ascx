<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebSite.mobile.member.common.header" %>
<style>
    .h_btn_rg img {
        margin-top:8px;
    }
</style>
<div class="header" id="header">
    <a id="a1" href="javascript:history.back();" data-ajax="false" class="h_btn_lf go_back"></a>
    <h1 class="header_tit">&nbsp;&nbsp;</h1>
    <a id="a2" data-ajax="false" class="h_btn_rg"></a>
    <%--<a id="aback" data-ajax="false" class="h_btn_rg go_editor"></a>--%>
</div>

<script>
    //function goEditor(url) {
    //    $("#aback").attr("href", url);
    //}
    function setbut(imgurl,url)
    {
        if (imgurl != undefined && imgurl != "")
        {
            $("#a2").html("<img src=\"/mobile/images/wjmm.png\" height=\"28\" />");
        }
        if (url != undefined && url != "") {
            $("#a2").attr("href", url);
        }
    }
    function back(url) {
        $("#a1").attr("href", url);
    }
</script>
