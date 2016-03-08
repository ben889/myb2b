<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datainit.aspx.cs" Inherits="WebSite.admin.DesktopModules.console.datainit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script>
        function save() {
            if (!confirm("确定刷新吗？"))
                return false;
            LoadDialog("提交中.."); // 现实加载进度
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog(); // 隐藏加载进度
            location.href = location.href;
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog(); // 隐藏加载进度
        }
    </script>
</head>
<body>
     <div class="header" style="border-bottom:1px solid #cccccc;padding:12px;">
        <h2>
           刷新基础数据
        </h2>
    </div>
    <form id="form1" runat="server" target="hd" >
    <div style="padding: 12px 0 12px 2px;">
    <asp:Button ID="btn_init" runat="server" Text="点击刷新基础数据" CssClass="button save" OnClientClick="return save();" OnClick="btn_init_Click" />
    </div>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
