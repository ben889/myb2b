<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodsExch.aspx.cs" Inherits="WebSite.seller.goods.goodsExch" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>兑换记录</title>
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
                            <h2>兑换记录</h2>
                        </td>
                        <td align="right">
                            系列号：<input name="txtKeywords" type="text" id="txtKeywords" class="textbox" runat="server" />
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/admin/images/icon_search_16px.gif"
                                OnClick="lbtn_search_Click" />
                        </td>
                    </tr>
                </table>
            </div>

            <!--列表-->
            <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                <tr class="DataGrid_Header">
                    <th>套餐</th>
                    <th>系列号</th>
                    <th>状态</th>
                    <th>兑换时间</th>
                    <th>所属商家</th>
                    <%--<th width="12%">操作</th>--%>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item">
                            <td>
                                <div style="float: left; border: 1px solid #cccccc; width: 100px; height: 80px; margin-left: 10px; overflow: hidden;"><%#bind_goodsimg(Eval("img")) %></div>
                                <div style="float: left; height: 80px; margin-left: 10px;"><%#Eval("goodsname") %></div>
                            </td>
                            <td>
                                <%#Eval("Sequence") %>
                            </td>
                            <td>
                                <%#BLL.goodsExchBLL.getstatus_str(Eval("status"))%>
                            </td>
                            <td>
                                <%#Eval("ExchTime")%>
                            </td>
                            <td>
                                <%#Eval("sellername") %>
                            </td>
                            <%--<td align="center">
                                <asp:LinkButton ID="lbtn_status" runat="server" CommandArgument='<%#Eval("ExchId")%>' CommandName="status" OnClientClick="return confirm('确定更改吗？');">未使用</asp:LinkButton>
                            </td>--%>
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
