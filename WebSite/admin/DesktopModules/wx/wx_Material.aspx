<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_Material.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.wx_Material" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>素材</title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            selectall();
        });
        function del() {
            if (!confirm("确定删除？"))
                return false;
        }
    </script>
</head>
<body>
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" class="selected">图文消息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div>
        <div class="am-btn-group" style="padding:18px 0 0 18px;">
            <button type="button" class="am-btn am-btn-primary" onclick="location.href='edit_wx_Material.aspx';">&nbsp;&nbsp;添加&nbsp;&nbsp;</button>
        </div>
    </div>
    <form id="form1" runat="server">
    <div class="imglist" style="padding: 10px;">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="imgtext_item" style="width: 224px; border: 1px solid #cccccc; float: left;
                    margin: 8px;">
                    <div style="text-align: left; margin-bottom: 2px;" id="imgtextdiv">
                        <div style="padding: 8px 12px;">
                            <div style="padding-bottom: 4px;">
                                <%#Eval("Name") %>
                            </div>
                            <div style="height: 120px; overflow: hidden;">
                                <img src="<%#Eval("ImgUrl") %>" width="200">
                            </div>
                        </div>
                    </div>
                    <div style="padding: 4px 12px; border-top: 1px solid #cccccc;">
                        <a href="edit_wx_Material.aspx?parentid=<%#Eval("wx_MaterialID") %>" title="编辑图文内容">
                            <img src="/admin/images/edit.gif" />
                        </a>&nbsp;&nbsp;
                        <asp:LinkButton ID="lbtn_del" runat="server" CommandArgument='<%#Eval("wx_MaterialID")%>'
                            CommandName="del" OnClientClick="return confirm('确定删除吗？');"><img src="/admin/images/delete.gif" /></asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div style="clear: both;">
        </div>
    </div>
    <div class="Pagination">
        <cc1:Pagination ID="Pagination1" runat="server" PageSize="15" />
    </div>
    </form>
</body>
</html>
