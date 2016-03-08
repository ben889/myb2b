<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_wx_ReplyKey.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.wx.edit_wx_ReplyKey" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>自动回复关键字</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script>
        $(document).ready(function () {
            $("#<%=btnsave.ClientID %>").click(function () {
                return save();
            });
        });
        function del() {
            if (!confirm("确定删除？"))
                return false;
        }
    </script>
    <script>
        function del() {
            if (confirm('确定删除吗？')) {
                LoadDialog("提交中..");
                return true;
            }
            return false;
        }
        function save() {
            LoadDialog("提交中.."); // 现实加载进度
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog(); // 隐藏加载进度
            window.location.href = window.location.href;
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
    <form id="form1" runat="server" target="hd">
    <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <h2>
                        <%=title %>
                        - 自动回复关键字</h2>
                </td>
                <td align="right">
                    关键字：
                    <asp:TextBox ID="txbName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    <asp:Button ID="btnsave" runat="server" Text="添加" CssClass="button save" OnClick="btnsave_Click" />
                    &nbsp;&nbsp;
                    <input id="btn_return" type="button" value="返回" class="button cancel" onclick="location.href='wx_ReplyMesage.aspx'" />
                </td>
            </tr>
        </table>
    </div>
    <div class="selectlist">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                    <tr class="DataGrid_Header">
                        <td align="center">
                            <strong>ID</strong>
                        </td>
                        <td align="center">
                            <strong>关键字</strong>
                        </td>
                        <td align="center" width="150">
                            <strong>操作</strong>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                    class="DataGrid_Item">
                    <td align="center">
                        <%#Eval("wx_ReplyKeyID")%>
                    </td>
                    <td align="center">
                        <%#Eval("Name")%>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtn_del" runat="server" CommandArgument='<%#Eval("wx_ReplyKeyID")%>'
                            CommandName="del" OnClientClick="return del();">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <iframe name="hd" style="display: none;"></iframe>
    </form>
</body>
</html>
