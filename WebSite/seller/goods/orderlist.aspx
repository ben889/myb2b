<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderlist.aspx.cs" Inherits="WebSite.seller.goods.orderlist" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/pager.css" rel="stylesheet" />
</head>
<body>
    <div class="main">
        <form id="form1" runat="server">

            <div class="header">
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <h2>订单</h2>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </div>


            <!--列表-->
            <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                <tr class="DataGrid_Header">
                    <th width="6%">选择</th>
                    <th align="center">单号</th>
                    <th align="center">订单总额</th>
                    <th align="center">实际支付金额</th>
                    <th align="center">订单状态</th>
                    <th align="center">下单时间</th>
                    <th align="center">下单人</th>
                    <th width="12%">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item">
                            <td align="center">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:HiddenField ID="hforderid" runat="server" />
                            </td>
                            <td>
                                <%#Eval("orderno") %>
                            </td>
                            <td>
                                <%#Common.Utils.ObjectTodecimal(Eval("totalprice"),2)%>
                            </td>
                            <td>
                                <%#Common.Utils.ObjectTodecimal(Eval("pay_price"),2)%>
                            </td>
                            <td>
                                <%#BLL.g_orderBLL.getorderstatus_str(Eval("status"))%>
                            </td>
                            <td>
                                <%#Eval("createtime")%>
                            </td>
                            <td>
                                <%#Eval("displayname")%>
                            </td>
                            <td align="center">
                                <a href="editorder.aspx?orderid=<%#Eval("orderid") %>">查看</a> |
                        <asp:LinkButton ID="lbtndel" runat="server" CommandArgument='<%#Eval("orderid")%>' CommandName="del" OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--/列表-->
            <!--分页-->
            <div class="Pagination">
                <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged" PageSize="10" ShowDropDown="true" />
            </div>
            <!--/分页-->
        </form>
    </div>
</body>
</html>
