<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_diymenu.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.wx_diymenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script src="../../../layer/layer-v1.9.3/layer.js"></script>
    <script src="../../../amazeui/assets/js/amazeui.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            selectall();
        });
    </script>
    <script>
        function openpage(id, parentid) {

            //            var html = '<form id="form2" name="form2" action="wx_diymenu.aspx" target="hd" method="post" class="am-form" style="padding:10px;">'
            //            + '<table cellspacing="1" cellpadding="2" border="0" class="formtable" >'
            //            + '<tr>'
            //            + '<td align="left" width="100">名称：<span style="color: Red;">*</span>'
            //            + '</td>'
            //            + '<td align="left" width="250">'
            //            + '<input name="Name" type="text" />'
            //            + '</td>'
            //            + '</tr>'
            //            + '<tr>'
            //            + '<td align="left" width="100">名称：<span style="color: Red;">*</span>'
            //            + '</td>'
            //            + '<td align="left" width="250">'
            //            + '<input name="Name" type="text" />'
            //            + '</td>'
            //            + '</tr>'
            //            + '<tr>'
            //            + '<td align="left">是否可用：'
            //            + '</td>'
            //            + '<td align="left">'
            //            + '<select name="State">'
            //            + '<option value="1">是</option>'
            //            + '<option value="0">否</option>'
            //            + '</select>'
            //            + '</td>'
            //            + '</tr>'
            //            + '<tr>'
            //            + '<td align="left">排序：'
            //            + '</td>'
            //            + '<td align="left">'
            //            + '<input name="Sort" type="text" />'
            //            + '</td>'
            //            + '</tr>'
            //            + '<tr>'
            //            + '<td align="left"></td>'
            //            + '<td align="left">'
            //            + '<input name="id" type="hidden" value="' + id + '" />'
            //            + '<input name="ac" type="hidden" value="save" />'
            //            //+                '<button type="button" id="btn_save" class="am-btn am-btn-primary btn-loading-example">&nbsp;&nbsp;提交&nbsp;&nbsp;</button>'
            //            + '<button type="button" class="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner: \'circle-o-notch\', loadingText: \'提交中...\', resetText: \'&nbsp;&nbsp;提交&nbsp;&nbsp;\'}">&nbsp;&nbsp;提交&nbsp;&nbsp;</button>'
            //            + '</td>'
            //            + '</tr>'
            //            + '</table>'
            //            + '</form>';

            //            layer.open({
            //                type: 1,
            //                title: false,
            //                closeBtn: false,
            //                shadeClose: true,
            //                content: html
            //            });

            layer.open({
                type: 2,
                title: false,
                shadeClose: true,
                shade: 0.8,
                area: ['540px', '240px'],
                content: 'edit_wx_diymenu.aspx?id=' + id + "&parentid=" + parentid //iframe的url
            });

            //            $('.btn-loading-example').click(function () {
            //                save();
            //                $("#form2").submit();
            //            });

            return false;
        }

    </script>
    <script>
        function save() {
            if (!confirm("确定生成吗？"))
                return false;
            var $btn = $('.btn-loading-example');
            $btn.button('loading');
            return true;
        }
        function success(info) {
            if (info != "" && info != undefined) {
                alert(info);
            }
            window.location.href = window.location.href;
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            $('.btn-loading-example').button('reset');
        }
    </script>
    <script>
        //设置动作
        function setac(id) {
            //            layer.open({
            //                type: 2,
            //                title: false,
            //                shadeClose: true,
            //                shade: 0.8,
            //                area: ['80%', '80%'],
            //                content: 'edit_wx_diymenu_ac.aspx?id=' + id
            //            });
            location.href = "edit_wx_diymenu_ac.aspx?id=" + id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" target="hd">
    <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <h2>
                        自定义菜单</h2>
                </td>
                <td align="right">
                    <input id="btnadd" type="button" value="添加" class="button save" onclick="openpage(0,0);" />
                </td>
            </tr>
        </table>
    </div>
    <div class="selectlist">
        <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
            <tr class="DataGrid_Header">
                <td width="50" align="center">
                    <input id="selectall" type="checkbox" title="全选/全不选" />
                </td>
                <td width="50" align="center">
                    <strong>ID</strong>
                </td>
                <td align="center">
                    <strong>名称</strong>
                </td>
                <td align="center" width="70">
                    <strong>排序</strong>
                </td>
                <td align="center" width="70">
                    <strong>是否可用</strong>
                </td>
                <td align="center">
                    <strong>微信互动</strong>
                </td>
                <td align="center" width="150">
                    <strong>操作</strong>
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                        class="DataGrid_Item">
                        <td align="center">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td align="center">
                            <%#Eval("MenuId")%>
                            <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("MenuId")%>' />
                        </td>
                        <td align="left" style="text-align: left;">
                            &nbsp;&nbsp;<%#Eval("Name") %>
                        </td>
                        <td align="center">
                            <input name="menuid" type="hidden" value="<%#Eval("MenuId")%>" />
                            <input name="Sort" type="text" value="<%#Eval("Sort") %>" class="textbox" style="width: 40px;" />
                        </td>
                        <td align="center">
                            <%#BLL.wx_diymenuBLL.getState_Str(Eval("State"))%>
                        </td>
                        <td align="center">
                            <a href="javascript:;" onclick="setac(<%#Eval("MenuId")%>)">设置动作</a>
                        </td>
                        <td align="center">
                            <a href="javascript:;" onclick="openpage(0, <%#Eval("MenuId")%>)">添加子级</a> | <a href="javascript:;"
                                onclick="openpage(<%#Eval("MenuId")%>, 0)">修改</a> |
                            <asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("MenuId")%>'
                                CommandName="del" OnClientClick="return confirm('确定删除吗');">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <iframe name="hd" style="display: none;"></iframe>
    <div style="margin: 4px 0; text-align: left;" class="page-footer">
        <div class="btn-list" style="padding-left: 100px; text-align: left;">
            <asp:HiddenField ID="hfid" runat="server" Value="" />
            <asp:Button ID="btnrelease" runat="server" Text="&nbsp;&nbsp;发布&nbsp;&nbsp;" CssClass="am-btn am-btn-primary btn-loading-example"
                OnClick="btnrelease_Click" data-am-loading="{spinner:'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}"
                OnClientClick="return save();" />
            
        </div>
    </div>
    </form>
</body>
</html>
