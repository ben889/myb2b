<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="WebSite.mobile.common.footer" %>
<script>
    function selectmenu(id) {
        if (id != "") {
            $("#" + id).addClass("num-25551123");
        }
    }
</script>
<ul class="clearfix" id="main-nav">
    <li style="width: 20%;"><a href="/mobile/index.aspx">
        <%--<img width="26" height="26" src="/mobile/images/home.png">--%>
        <div class="fa fa-home" style="font-size: 24px;"></div>
    </a></li>
    <li style="width: 80%; border-left: 1px solid #cccccc; box-sizing: border-box;"><a href="/mobile/member/index.aspx">
        <div>
            <span class="fa fa-user" style="font-size: 14px;height: 40px; line-height: 40px;color:#cccccc;"></span>
            <span id="m2" style="height: 40px; line-height: 40px;"> 我的</span>
        </div>
    </a></li>
</ul>
