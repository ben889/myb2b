<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods.aspx.cs" Inherits="WebSite.seller.goods.goods" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/pager.css" rel="stylesheet" />
</head>
<body>

    <div class="main">
        <form runat="server" method="post" action="" id="form1">
            <div class="header">
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <h2>商品</h2>
                        </td>
                        <td align="right">搜索：<asp:DropDownList ID="ddlfield" runat="server" CssClass="select">
                            <asp:ListItem Value="O.[GoodsName]">名称</asp:ListItem>
                        </asp:DropDownList>
                            <asp:TextBox ID="txbfieldval" runat="server" class="textbox"></asp:TextBox>
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                                OnClick="ibtnSearch_Click" />
                            &nbsp;
                        <input id="add" type="button" value="新增" class="button save" onclick="location.href = 'edit_goods.aspx'" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="header_height"></div>
            <!--列表-->
            <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                <tr class="DataGrid_Header">
                    <th>选择</th>
                    <td>图片</td>
                    <td>商品名称</td>
                    <td>商品类型</td>
                    <td>价格</td>
                    <td>每人限购数量</td>
                    <td>兑换数量</td>
                    <td>状态</td>
                    <td>开始日期</td>
                    <td>结束日期</td>
                    <td align="center">功能</td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item">
                            <td align="center">
                                <span class="checkall" style="vertical-align: middle;">
                                    <input id="" name="" type="checkbox">
                                </span>
                            </td>
                            <td>
                                <img src="<%#Eval("Img") %>" style="height: 50px;" />
                            </td>
                            <td>
                                <%#Eval("GoodsName") %> 
                            </td>
                            <td>
                                <%#getGoodsType(Eval("GoodsType")) %> 
                            </td>
                            <td>
                                <%#Eval("Price") %>
                            </td>

                            <td>
                                <%#Eval("purchase") %>
                            </td>
                            <td>
                                <%#Eval("totalcount") %>
                            </td>
                            <td><%#Convert.ToInt32(Eval("Status"))==1?"上架":"<span style='color:red;'>下架</span>" %></td>
                            <td><%#Eval("StartDate","{0:d}") %></td>
                            <td><%#Eval("EndDate","{0:d}") %></td>
                            <td align="center">
                                <a href="edit_goods.aspx?id=<%#Eval("GoodsId") %>">编辑</a> |
                            <asp:LinkButton ID="lbtn_del" runat="server" CommandArgument='<%#Eval("GoodsId") %>' CommandName="del" OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
            <!--/列表-->
            <!--分页-->
            <div class="Pagination">
                <cc1:Pagination ID="Pagination1" runat="server" PageSize="10" OnPageChanged="Pagination1_PageChanged" />
            </div>

        </form>
    </div>
</body>
</html>
