<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ad.aspx.cs" Inherits="WebSite.admin.DesktopModules.Ad.ad" %>
<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () { selectall(); });
    </script>
</head>
<body>
     <form id="form1" runat="server">
        <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <h2><%=title %></h2>
                    </td>
                    <td align="right">
                    搜索：<asp:DropDownList ID="ddlfield" runat="server">
                            <asp:ListItem Value="O.[adname]">名称</asp:ListItem>
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
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
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
                            <td align="center">
                                <strong>所属广告位</strong>
                            </td>
                            <td align="center">
                                <strong>状态</strong>
                            </td>
                            <td align="center" width="80">
                                <strong>操作</strong>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                        class="DataGrid_Item">
                        <td align="center">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:HiddenField ID="hfadid" runat="server" Value='<%#Eval("adid")%>' />
                        </td>
                        <td align="center">
                            <%#Eval("adid")%>
                        </td>
                        <td align="center">
                            <div style="float:left;width:50px;height:50px;overflow:hidden;border:1px solid #eeeeee;"><%#showimg(Eval("adimg"), Eval("suffix"), Eval("adlink"))%></div>
                            <div style="float:left;width:50px;height:50px;overflow:hidden;"><%#Eval("adname")%></div>
                            <div style="clear:both;"></div>
                        </td>
                        <td align="center">
                            <%#Eval("positionname")%>
                        </td>
                        <td align="center">
                            <%#status(Eval("status"))%>
                        </td>
                        <td align="center">
                            <a href="editAd.aspx?adid=<%#Eval("adid")%>">修改</a> | 
                            <asp:LinkButton ID="lbtnexec" runat="server" CommandArgument='<%#Eval("adid")%>' CommandName="del" OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>
                        </td>
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
        </form>
</body>
</html>
