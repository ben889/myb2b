<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_wx_diymenu.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.wx.edit_wx_diymenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../../amazeui/assets/js/amazeui.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('.btn-loading-example').click(function () {
                save();
            });
        });
    </script>
    <script>
        function save() {
            var $btn = $('.btn-loading-example');
            $btn.button('loading');
            //            setTimeout(function () {
            //                $btn.button('reset');
            //            }, 5000);
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }
            //RemoveLoadDialog(); // 隐藏加载进度
            parent.location.href = "wx_diymenu.aspx";
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            //RemoveLoadDialog(); // 隐藏加载进度
            $('.btn-loading-example').button('reset');
        }
    </script>
</head>
<body>
    <form id="form1" name="form1" action="edit_wx_diymenu.aspx" target="hd" 
    class="am-form" style="padding: 10px;" runat="server">
    <table cellspacing="1" cellpadding="2" border="0" class="formtable" width="500">
        <tr>
            <td align="left" width="100">
                父级菜单：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlparentid" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" width="100">
                名称：<span style="color: Red;">*</span>
            </td>
            <td align="left">
                <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                是否可用：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                排序：
            </td>
            <td align="left">
                <asp:TextBox ID="txbSort" runat="server" style="width:80px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                <asp:Button ID="btn_save" runat="server" OnClick="btnsave_Click" Text="&nbsp;&nbsp;提交&nbsp;&nbsp;" CssClass="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner: 'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}"/>
            </td>
        </tr>
    </table>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
