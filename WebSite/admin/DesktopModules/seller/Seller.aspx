<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="WebSite.admin.DesktopModules.seller.Seller" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery.min.js"></script>
    <link href="../../css/style.css" rel="stylesheet" />
    <title>商家管理</title>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>商家</h2>
                    </td>
                    <td align="right">搜索：
                        <asp:DropDownList ID="ddlfield" runat="server"  CssClass="select">
                            <asp:ListItem Value="O.[name]">名称</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif" />
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnadd" type="button" value="添加" class="button save" onclick="location.href = 'editSeller.aspx'" />
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
                    <td align="center" width="120">
                        <strong>帐号</strong>
                    </td>
                    <td align="center">
                        <strong>类型</strong>
                    </td>
                    <%--<td align="center">
                        <strong>经营范围</strong>
                    </td>
                    <td align="center">
                        <strong>电话</strong>
                    </td>
                    <td align="center">
                        <strong>传真</strong>
                    </td>
                    <td align="center">
                        <strong>QQ</strong>
                    </td>
                    <td align="center">
                        <strong>微信</strong>
                    </td>
                    <td align="center">
                        <strong>微信二维码</strong>
                    </td>--%>
                    <td align="center">
                        <strong>区域</strong>
                    </td>
                    <td align="center">
                        <strong>排序</strong>
                    </td>
                    <td align="center" class="auto-style1">
                        <strong>推荐</strong>
                    </td>
                    <td align="center" width="200">
                        <strong>操作</strong>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"  class="DataGrid_Item">
                            <td align="center">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </td>
                            <td align="center">
                                <%#Eval("sellerid") %>
                            </td>
                            <td align="center">
                                <%#Eval("name") %>
                            </td>
                            <td align="center">
                                <%#Eval("uname") %>
                            </td>
                            <td align="center">
                                <%#Eval("categoryname") %>
                            </td>
                            <td align="center">
                                <%#Eval("distname") %>
                            </td>
                            <td align="center">
                                <%#Eval("orderby") %>
                            </td>
                            <td>
                                <asp:LinkButton ID="LBtrecommend" runat="server" CommandName="LBtrecommend" CommandArgument='<%#Eval("recommend")+"|"+Eval("sellerid") %>' OnClientClick="return confirm('确定更改推荐状态吗？');"><%# BLL.SellerBLL.initrecommend(Eval("recommend"))%></asp:LinkButton> 
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnislock" runat="server" CommandName="islock" CommandArgument='<%#Eval("islock")+"|"+Eval("sellerid") %>' OnClientClick="return confirm('确定更改锁定状态吗？');"><%# BLL.SellerBLL.initlock(Eval("islock"))%></asp:LinkButton> |
                                <a href="editSeller.aspx?id=<%#Eval("sellerid")%>">查看</a>
                                <%if (base.UserType==Common.enumUserType.host.ToString()||base.UserType==Common.enumUserType.admin.ToString()){ %>
                                | <asp:LinkButton ID="lbtn_gotoseller" runat="server" CommandArgument='<%#Eval("sellerid")%>' CommandName="gotoseller">进入商家后台</asp:LinkButton>
                                <%--<asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("sellerid")%>' CommandName="del" OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>--%>
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
