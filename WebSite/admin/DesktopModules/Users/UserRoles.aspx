<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRoles.aspx.cs" Inherits="Users.UserRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帐号角色管理</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        img
        {
            vertical-align: middle;
        }
    </style>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body>
    <div class="bodydiv">
        <form id="form1" runat="server">
        <div class="header" style="margin-bottom: 2px;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>帐号角色管理 -
                            <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                        </h2>
                        <asp:HiddenField ID="hfUserId" runat="server" Value="0" />
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="select">
                        </asp:DropDownList>
                        <asp:ImageButton ID="ibtnAddRolesToUser" runat="server" ImageUrl="~/admin/images/add.gif"
                            ToolTip="添加角色到帐号" OnClick="ibtnAddRolesToUser_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divlist">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table border="0" cellpadding="2" cellspacing="1" class="DataGrid_Table" width="100%">
                        <tr class="DataGrid_Header">
                            <td align="center" width="30">
                                &nbsp;
                            </td>
                            <td align="center" width="50">
                                <b>ID</b>
                            </td>
                            <td align="center">
                                <b>角色名称</b>
                            </td>
                            <td align="center">
                                <b>所属公司</b>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                        class="DataGrid_Item">
                        <td align="center">
                            <asp:ImageButton ID="ibtnRoles" runat="server" ImageUrl="~/admin/images/delete.gif"
                                OnClientClick="return confirm('确定移除吗？');" ToolTip="移除角色" CommandArgument='<%#Eval("UserRoleID")%>'
                                CommandName="Remove" />
                        </td>
                        <td align="center">
                            <%#Eval("RoleID")%>
                            <asp:HiddenField ID="hfRoleID" runat="server" Value='<%#Eval("RoleID")%>' />
                        </td>
                        <td align="center">
                            <%#Eval("RoleName")%>
                        </td>
                        <td align="center">
                            <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="foot" style="text-align: right;">
            <asp:LinkButton ID="lbtnreturn" runat="server" OnClick="lbtnreturn_Click"><img src="/admin/images/action_export.gif" border="0" /> 返回</asp:LinkButton>
        </div>
        </form>
    </div>
</body>
</html>
