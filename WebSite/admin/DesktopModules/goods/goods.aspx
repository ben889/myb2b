<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods.aspx.cs" Inherits="WebSite.admin.DesktopModules.goods.goods" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/pager.css" rel="stylesheet" />
</head>
<body>
    <form runat="server" method="post" action="" id="form1">
        <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2>体验馆商品</h2>
                    </td>
                    <td align="right">
                        搜索：<asp:DropDownList ID="ddlfield" runat="server">
                        <asp:ListItem Value="O.[goodsname]">商品名称</asp:ListItem>
                    </asp:DropDownList>
                        <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                            OnClick="ibtnSearch_Click" />
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>

        <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
            <tr class="DataGrid_Header">
                <td>
                    <input id="selectall" type="checkbox" />
                </td>
                <td>产品名称
                </td>
                <td>商品类型    
                </td>
                <td>商品分类    
                </td>
                <td>所属商家    
                </td>
                <td>操作
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr class="DataGrid_Item">
                        <td>
                            <input id="Checkbox1" type="checkbox" />
                        </td>
                        <td>
                            <div>
                                <div style="width: 40px; height: 40px; overflow: hidden; float: left; margin-right: 8px; border: 1px solid #eeeeee;">
                                    <img src="<%#Eval("img") %>" height="40" width="40" />
                                </div>
                                <div style="height: 40px; overflow: hidden; float: left; margin-right: 8px; line-height: 40px;"><%#Eval("Goodsname") %></div>
                                <div style="clear: both;"></div>
                            </div>
                        </td>
                        <td><%#BLL.goodsBLL.get_GoodsType_Str(Eval("GoodsType")) %>
                        </td>
                        <td><%#Eval("goods_category_name") %>
                        </td>
                        <td><%#Eval("sellername") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtnred" runat="server" CommandArgument='<%#Eval("GoodsId")+","+Eval("is_red") %>' CommandName="isred">
                           <%#is_red(Eval("is_red"))%>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--分页-->
        <div class="Pagination">
            <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged" PageSize="10" ShowDropDown="true" />
        </div>
        <!--/分页-->
    </form>
</body>
</html>
