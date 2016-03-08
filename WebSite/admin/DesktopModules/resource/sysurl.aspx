<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysurl.aspx.cs" Inherits="WebSite.admin.DesktopModules.resource.sysurl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统url</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () { selectall(); });
    </script>
</head>
<body>
     <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <h2>
                        系统url</h2>
                </td>
                <td align="right">
                </td>
            </tr>
        </table>
    </div>
    <form id="form1" runat="server">
       
    <%--<div class="con_tips">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left">
                    名称：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    <asp:HiddenField ID="hfid" runat="server" Value="0" />
                </td>
                <td align="left" style="padding-left:10px;">
                    URL：
                </td>
                <td align="left">
                    <asp:TextBox ID="txburl" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
                <td align="left">
                <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                </td>
            </tr>
        </table>
    </div>--%>
     
    <div class="selectlist">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                    <tr class="DataGrid_Header">
                        <td width="30" align="center">
                            <input id="selectall" type="checkbox" title="全选/全不选" />
                        </td>
                        <%--<td width="50" align="center">
                            <strong>序号</strong>
                        </td>--%>
                        <td align="center" width="150">
                            <strong>名称</strong>
                        </td>
                        <td align="left" style="padding-left:10px;text-align:left;">
                            <strong>Url</strong>
                        </td>
                        <%--<td align="center">
                            <strong>调用代码</strong>
                        </td><td align="center" width="80">
                            <strong>操作</strong>
                        </td>--%>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                    class="DataGrid_Item">
                    <td align="center">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id")%>' />
                    </td>
                    <%--<td align="center">
                        <%#Eval("id")%>
                    </td>--%>
                    <td align="center">
                        <%#Eval("name")%>
                    </td>
                    <td align="left" style="padding-left:10px;text-align:left;">
                        <%#Eval("url")%>
                    </td>
                    <%--<td align="center">
                        <%#Eval("call_index")%>
                    </td>
                    <%--<td align="center">
                        <asp:LinkButton ID="lbtn_update" runat="server" CommandArgument='<%#Eval("id")%>'
                            CommandName="update">修改</asp:LinkButton>
                        |
                        <asp:LinkButton ID="lbtn_del" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="del"
                            OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>
                    </td>--%>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
