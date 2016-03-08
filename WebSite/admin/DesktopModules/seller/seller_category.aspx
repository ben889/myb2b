<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seller_category.aspx.cs" Inherits="WebSite.admin.DesktopModules.seller.seller_category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            selectall();
        });
        function del() {
            if (!confirm("本操作会删除本类别及下属子类别，是否继续？"))
                return false;
        }
        function add()
        {
            location.href = "editseller_category.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>商家类型</h2>
                    </td>
                    <td align="right">
                        <%if(add){ %>
                        <input id="Button1" type="button" value="添加" class="button save" onclick="add()" />
                        <%} %>
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
                            <td align="center" width="40">
                                <strong>图片</strong>
                            </td>
                            <td align="center" width="70">
                                <strong>排序</strong>
                            </td>
                            <%if (add || del || update){ %>
                            <td align="center" width="150">
                                <strong>操作</strong>
                            </td>
                            <%} %>
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
                            <asp:HiddenField ID="hftypeid" runat="server" Value='<%#Eval("id")%>' />
                        </td>
                        <td align="left" style="text-align:left;">
                            &nbsp;&nbsp;<%#Eval("name") %>
                        </td>
                        <td align="center">
                            <img src='<%#Eval("img") %>' width="40" height="40"/>
                        </td>
                        <td align="center">
                            <input id="txborderby" name="orderby" type="text" value="<%#Eval("orderby") %>" class="textbox" style="width:40px;" />
                        </td>
                         <%if (add || del || update){ %>
                        <td align="center">
                            <%if (add){ %>
                            <a href="editseller_category.aspx?parentid=<%#Eval("id")%>">添加子级</a> | 
                            <%} %>
                            <%if (del){ %>
                            <asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="del" OnClientClick="return del();">删除</asp:LinkButton> | 
                            <%} %>
                            <%if (update){ %>
                            <a href="editseller_category.aspx?id=<%#Eval("id")%>">修改</a>
                            <%} %>
                        </td>
                        <%} %>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
