<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="district.aspx.cs" Inherits="WebSite.admin.DesktopModules.district.district" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
        });
        function del() {
            if (!confirm("确定删除吗？"))
                return false;
        }
    </script>
</head>
<body>
    <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <h2>区域</h2>
                </td>
                <td align="right">
                    
                </td>
            </tr>
        </table>
    </div>
    <div style="margin:8px auto;"><input id="btnadd" type="button" value="添加省份" class="button create" onclick="location.href = 'edit_district.aspx';" /></div>
    
        <div style="margin:2px;">
            <%=listHTML %>
        </div>
    <form id="form1" name="form1" action="district.aspx" method="post">
        <input id="ac" name="ac" type="hidden" value="del" />
        <input id="id" name="id" type="hidden" value="0" />
    </form>
    <script>
        function del(id)
        {
            if (!confirm("确定删除吗？"))
                return false;
            if (id <= 0)
                return false;
            $("#id").val(id);
            $("#form1").submit();
        }
    </script>
</body>
</html>
