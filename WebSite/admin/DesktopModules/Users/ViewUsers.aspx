<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="Users.Default" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帐号管理</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //parent.selectmenu("users");
            //window.parent.document.getElementById("frmleft").contentWindow.selectmenu("users");
            $("#<%=btneidt.ClientID %>").click(function () {
                if ($("#divlist").find(":checked").size() != 1) {
                    alert("请选择一个帐号！")
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <div class="bodydiv">
        <form id="form1" runat="server">
        <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>帐号管理</h2>
                    </td>
                    <td align="right">
                    搜索：
                    <asp:DropDownList ID="ddlfield" runat="server" CssClass="select">
                            <asp:ListItem Value="O.[UserName]">帐号</asp:ListItem>
                            <asp:ListItem Value="O.[DisPlayName]">显示名称</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                            OnClick="ibtnSearch_Click" />
                        &nbsp;
                        <asp:Button ID="btnadd" runat="server" Text="添加帐号" CssClass="button save" OnClick="btnadd_Click" />
                        <asp:Button ID="btneidt" runat="server" Text="编辑" CssClass="button edit" OnClick="btneidt_Click" />
                        
                        <asp:Button ID="btndelete" runat="server" CssClass="button delete" Text="删除" OnClick="btndelete_Click"
                            OnClientClick="return confirm('确定删除帐号吗？');" />
                    </td>
                </tr>
            </table>
        </div>
        <%--<div class="search" style="margin-bottom: 4px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        
                    </td>
                    <td align="right">
                        
                    </td>
                </tr>
            </table>
        </div>--%>
        <div id="divlist">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="DataGrid_Table">
                        <tr class="DataGrid_Header">
                            <td width="12" align="center">
                                <input id="selectall" type="checkbox" title="全选/全不选" />
                            </td>
                            <td width="40" align="center">
                                <strong>ID</strong>
                            </td>
                            <td align="center">
                                <strong>帐号</strong>
                            </td>
                            <td align="center">
                                <strong>名称</strong>
                            </td>
                            <td align="center">
                                <strong>邮箱</strong>
                            </td>
                            <td align="center" width="150">
                                <strong>创建日期</strong>
                            </td>
                            <td align="center">
                                <strong>角色</strong>
                            </td>
                            <%--<td align="center">
                                <strong>所属站点</strong>
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
                            <%#Eval("UserId")%>
                            <asp:HiddenField ID="hfUserId" runat="server" Value='<%#Eval("UserId")%>' />
                            <asp:HiddenField ID="hfUserType" runat="server" Value='<%#Eval("UserType")%>' />
                        </td>
                        <td align="center">
                            <%#Eval("username") %>
                        </td>
                        <td align="center">
                            <%#Eval("displayname") %>
                        </td>
                        <td align="center">
                            <%#Eval("Email")%>
                        </td>
                        <td align="center">
                            <%#Eval("CreatedOnDate")%>
                        </td>
                        <td align="left" style="text-align: left;">
                            <a href="####" title="管理角色">
                                <%--<img src="/images/icon_securityroles_16px.gif" alt="管理角色" border="0" />--%>
                                <asp:ImageButton ID="ibtnRoles" runat="server" ImageUrl="~/admin/images/icon_securityroles_16px.gif"
                                    ToolTip="角色管理" CommandArgument='<%#Eval("UserId")%>' CommandName="touserroles"
                                    BorderWidth="0" />
                            </a>
                            <asp:Literal ID="ltrRoles" runat="server"></asp:Literal>
                        </td>
                        <%--<td align="center">
                            <%#Eval("Companyname")%>
                        </td>--%>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="Pagination">
            <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged"
                PageSize="15" />
        </div>
        <!--锁定层-->
        <div id="dialogBottomDIV" class="dialogBottomDIV">
        </div>
        </form>
    </div>
</body>
</html>
