<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_category.aspx.cs" Inherits="WebSite.admin.DesktopModules.article.article_category" %>

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
            if (!confirm("本操作会删除本类别及下属子类别，是否继续？"))
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
                        <h2>文章类型</h2>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnadd" runat="server" Text="添加" CssClass="button save" OnClick="btnadd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="selectlist">

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
                    <td align="center" width="70">
                        <strong>排序</strong>
                    </td>
                    <td align="center" width="150">
                        <strong>所属站点</strong>
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
                                <%#Eval("id")%>
                                <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id")%>' />
                            </td>
                            <td align="left" style="text-align: left;">&nbsp;&nbsp;<%#Eval("title") %>
                            </td>
                            <td align="center">
                                <input id="txborderby" name="orderby" type="text" value="<%#Eval("orderby") %>" class="textbox" style="width: 40px;" />
                            </td>
                            <td align="center">
                                <%#Eval("CompanyName") %>
                            </td>
                            <td align="center">
                                <a href="editarticle_category.aspx?parentid=<%#Eval("id")%>">添加子级</a> | 
                            <asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="del" OnClientClick="return del();">删除</asp:LinkButton>
                                | 
                            <a href="editarticle_category.aspx?id=<%#Eval("id")%>">修改</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>

