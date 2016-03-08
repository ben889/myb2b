<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRoles.aspx.cs" Inherits="Roles.ViewRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script src="../../../layer/layer-v1.9.3/layer.js" type="text/javascript"></script>
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //parent.selectmenu("users");
            //window.parent.document.getElementById("frmleft").contentWindow.selectmenu("roles");  
            ///全选全不选
            $("#selectall").click(function () {
                //alert($("#selectall").attr("checked"));
                if ($("#selectall").attr("checked") != "checked") {
                    $("#divlist").find(":checkbox").removeAttr("checked");
                }
                else {
                    $("#divlist").find(":checkbox").attr("checked", 'checked');
                }
            });
            $("#<%=lbtndelete.ClientID %>").click(function () {
                if ($("#divlist").find(":checked").size() > 0) {
                    return confirm('确定删除吗？');
                }
                else {
                    alert("请选择要删除的信息！")
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%" style="margin-bottom: 4px;">
            <tr>
                <td align="left">
                    <h2>
                        角色管理</h2>
                </td>
                <td align="right">
                    <a href="editRoles.aspx"><img src="/admin/images/add.gif" border="0" /> 添加</a>&nbsp;
                    <asp:LinkButton ID="lbtndelete" runat="server" OnClick="lbtndelete_Click"><img src="/admin/images/delete.gif" border="0" /> 删除</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnedit" runat="server" OnClick="lbtnedit_Click"><img src="/admin/images/edit.gif" border="0" /> 编辑</asp:LinkButton>&nbsp;
                    <span style="display: none;">
                        <asp:LinkButton ID="lbtnuser" runat="server"><img src="/admin/images/icon_users_16px.gif" border="0" /> 管理用户</asp:LinkButton>&nbsp;</span>
                    <asp:LinkButton ID="lbtnTabsRoles" runat="server" OnClick="lbtnTabsRoles_Click"><img src="/admin/images/icon_authentication_16px.gif" border="0" /> 权限</asp:LinkButton>&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divlist">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                    <tr class="DataGrid_Header">
                        <td width="30" align="center">
                            <input id="selectall" type="checkbox" title="全选/全不选" />
                        </td>
                        <td width="50" align="center">
                            <strong>ID</strong>
                        </td>
                        <td align="center" width="100">
                            <strong>名称</strong>
                        </td>
                        <td align="center">
                            <strong>说明</strong>
                        </td>
                        <td align="center" width="150">
                            <strong>创建日期</strong>
                        </td>
                        <%--<td align="center" width="100">
                            <strong>所属公司</strong>
                        </td>--%>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                    class="DataGrid_Item">
                    <td align="center">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    <td align="center">
                        <%#Eval("RoleID")%>
                        <asp:HiddenField ID="hfRoleID" runat="server" Value='<%#Eval("RoleID")%>' />
                    </td>
                    <td align="center">
                        <%#Eval("RoleName")%>
                    </td>
                    <td align="center">
                        <%#Eval("Description")%>
                    </td>
                    <td align="center">
                        <%#Eval("CreatedOnDate")%>
                    </td>
                    <%--<td align="center">
                    </td>--%>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="footdiv" style="text-align: right;">
    </div>
    </form>
</body>
</html>
