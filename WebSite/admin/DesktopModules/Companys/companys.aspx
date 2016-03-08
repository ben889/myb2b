<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="companys.aspx.cs" Inherits="WebSite.admin.DesktopModules.Companys.companys" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理商</title>
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
                        <h2>代理商</h2>
                    </td>
                    <td align="right">搜索：<asp:DropDownList ID="ddlfield" runat="server" CssClass="select">
                        <asp:ListItem Value="O.[companyname]">名称</asp:ListItem>
                    </asp:DropDownList>
                        <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                            OnClick="ibtnSearch_Click" />
                        &nbsp;
                        <%if (userinfo.UserType == Common.enumUserType.admin.ToString() || userinfo.UserType == Common.enumUserType.host.ToString()){ %>
                        <asp:Button ID="btnadd" runat="server" Text="添加" CssClass="button save" OnClick="btnadd_Click" />
                        <%} %>
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
                    <td align="center">
                        <strong>帐号</strong>
                    </td>
                    <td align="center">
                        <strong>状态</strong>
                    </td>
                    <td align="center" width="150">
                        <strong>操作</strong>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                    OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item">
                            <td align="center">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </td>
                            <td align="center">
                                <%#Eval("companyid")%>
                                <asp:HiddenField ID="hfcompanyid" runat="server" Value='<%#Eval("companyid")%>' />
                            </td>
                            <td align="left" style="text-align: left;">&nbsp;&nbsp;<%#Eval("companyname")%>
                            </td>
                            <td align="center">
                                <%#Eval("username")%>

                            </td>
                            <td align="center">
                                <%#status(Eval("status"))%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnstatus" runat="server" CommandName="status" CommandArgument='<%#Eval("companyid")+"|"+Eval("status")%>'
                                    OnClientClick="return confirm('确定更改状态吗？');"></asp:LinkButton>&nbsp;&nbsp;<a href="editcompanys.aspx?id=<%#Eval("companyid")%>">修改</a>
                                <%if (base.UserType == Common.enumUserType.host.ToString() || base.UserType == Common.enumUserType.admin.ToString())
                                  { %>
                                |
                                <asp:LinkButton ID="lbtn_login" runat="server" CommandArgument='<%#Eval("companyid")%>' CommandName="login">进入代理商后台</asp:LinkButton>
                                <%} %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="Pagination">
            <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged" PageSize="15" />
        </div>
    </form>
</body>
</html>
