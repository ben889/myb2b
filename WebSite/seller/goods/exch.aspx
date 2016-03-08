<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exch.aspx.cs" Inherits="WebSite.seller.goods.exch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>兑换</title>
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
                            <h2>兑换</h2>
                        </td>
                        <td align="right">系列号：<input name="txtKeywords" type="text" id="txtKeywords" class="textbox" runat="server" />
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
                    <th width="12%">操作</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
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
                            <td align="center">
                                <asp:LinkButton ID="lbtn_status" runat="server" CommandArgument='<%#Eval("ExchId")%>' CommandName="status" OnClientClick="return confirm('确定提交吗？');">
                                     <%#btn_status_str(Eval("status"))%>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--/列表-->
        </form>
    </div>
</body>
</html>
