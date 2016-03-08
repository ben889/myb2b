<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="WebSite.admin.DesktopModules.member.member" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pager.css" rel="stylesheet" />
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
                        <h2>帐号</h2>
                    </td>
                    <td align="right">搜索：
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlfield" runat="server" CssClass="select">
                            <asp:ListItem Value="O.[uname]">帐号</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                            OnClick="ibtnSearch_Click" />
                        &nbsp;
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
                    <td align="center">
                        <strong>ID</strong>
                    </td>
                    <td align="center">
                        <strong>帐号</strong>
                    </td>
                    <td align="center">
                        <strong>姓名</strong>
                    </td>
                    <td align="center">
                        <strong>注册时间</strong>
                    </td>
                    <%--<td align="center">
                            <strong>类型</strong>
                        </td>--%>
                    <td align="center">
                        <strong>状态</strong>
                    </td>
                    <%--<td align="center">
                        <strong>登录次数</strong>
                    </td>--%>
                    <td align="center" width="150">
                        <strong>操作</strong>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item">
                            <td align="center">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </td>
                            <td align="center">
                                <%#Eval("uid")%>
                                <asp:HiddenField ID="hfuid" runat="server" Value='<%#Eval("uid")%>' />
                            </td>
                            <td align="center">&nbsp;&nbsp;<%#Eval("uname")%></td>
                            <td><%#Eval("displayname")%></td>
                            <td>
                                <%#Eval("addtime")%>
                            </td>
                            <%--<td align="center">
                    <%#utypestr(Eval("utype"))%>
                    </td>--%>
                            <td align="center">
                                <%#islock(Eval("islock"))%>
                            </td>
                            <%--<td align="center">
                                
                            </td>--%>
                            <td align="center">
                                <asp:LinkButton ID="lbtnislock" runat="server" CommandName="islock" CommandArgument='<%#Eval("uid")+"|"+Eval("islock")%>' OnClientClick="return confirm('确定更改状态吗？');"></asp:LinkButton><%--&nbsp;&nbsp;<a href="../owner/edit_member.aspx?uid=<%#Eval("uid")%>">查看</a>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="Pagination">
            <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged"
                PageSize="15" ShowDropDown="true" />
        </div>
    </form>
</body>
</html>
