<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="memberheader.ascx.cs" Inherits="WebSite.mobile.member.common.memberheader" %>
<script language="javascript">
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
    function back(url) {
        if (url != "")
            $("#aback").attr("href", url);
    }
</script>
<div class="header">
    <a href="../index.aspx" id="aback" class="h_btn_lf go_back"></a>
    <a href="javascript:void(0)" onclick="exitbut()" class="h_btn_rg go_exit"></a>
    <h1 class="header_tit"><%=title %></h1>
</div>

<div id="exitbox">
    <p class="p_tips">提示</p>
    <p class="p_queren">确认退出该账号吗？</p>
    <div class="box_but">
        <a href="javascript:void(0)" onclick="rexit()">退出</a>
        <a href="javascript:void(0)" onclick="noexit()">取消</a>
    </div>
</div>
<div id="zhezhao"></div>
