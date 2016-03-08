<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdPosition.aspx.cs" Inherits="WebSite.admin.DesktopModules.Ad.AdPosition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
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
    <form id="form1" runat="server">
    <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>广告位</h2>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnadd" runat="server" Text="添加" CssClass="button save" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
        </div>
    <div class="selectlist">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                        <tr class="DataGrid_Header">
                            <td width="12" align="center">
                                <input id="selectall" type="checkbox" title="全选/全不选" />
                            </td>
                            <td width="30" align="center">
                                <strong>ID</strong>
                            </td>
                            <td align="center">
                                <strong>名称</strong>
                            </td>
                            <td align="center">
                                <strong>调用别名</strong>
                            </td>
                            <td align="center" width="120">
                                <strong>大小</strong>
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
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td align="center">
                            <%#Eval("id")%>
                            <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id")%>' />
                        </td>
                        <td align="left" style="text-align:left;">
                            &nbsp;&nbsp;<%#Eval("name") %>
                        </td>
                        <td align="center">
                            <%#Eval("call_index")%>
                        </td>
                        <td align="center">
                            <%#Eval("width") %>px * <%#Eval("height")%>px
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="del" OnClientClick="return del();">删除</asp:LinkButton> | 
                            <a href="editAdPosition.aspx?id=<%#Eval("id")%>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
