<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_ReplyMesage.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.wx_ReplyMesage" %>

<%@ Register Assembly="WebControls" Namespace="UCP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>关键词自动回复</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
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
<div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="beaddedReply.aspx">被添加自动回复</a></li>
                    <li><a href="javascript:;" class="selected">关键词自动回复</a></li>
                </ul>
            </div>
        </div>
    </div>

    <form id="form1" runat="server">
        <div class="header">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <%--<h2>关键词自动回复</h2>--%>
                    </td>
                    <td align="right">
                    <input id="btn_add" type="button" value="添加" class="button create" onclick="location.href='edit_wx_ReplyMesage.aspx'" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="selectlist">
            
                    <table width="100%" border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table">
                        <tr class="DataGrid_Header">
                            <td width="50" align="center">
                                <input id="selectall" type="checkbox" title="全选/全不选" />
                            </td>
                            <td align="center">
                                <strong>ID</strong>
                            </td>
                            <td align="center">
                                <strong>规则名称</strong>
                            </td>
                            <td align="center">
                                <strong>关键字</strong>
                            </td>
                            <%--<td align="center">
                                <strong>回复类型</strong>
                            </td>
                            <td align="center">
                                <strong>可用</strong>
                            </td>--%>
                            <td align="center" width="150">
                                <strong>操作</strong>
                            </td>
                        </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                        class="DataGrid_Item">
                        <td align="center">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td align="center">
                            <%#Eval("ReplyID")%>
                        </td>
                        <td align="center">
                            <%#Eval("Name")%>
                        </td>
                        <td align="center">
                            <%#BLL.wx_ReplyKeyBLL.getkeyword(Eval("ReplyID"))%>
                        </td>
                        <%--<td align="center">
                            <%#Eval("ReplyType")%>
                        </td>
                        <td align="center">
                            <%#BLL.wx_ReplyMesageBLL.getState_str(Eval("State"))%>
                        </td>--%>
                        <td align="center">

                            <a href="edit_wx_ReplyMesage.aspx?id=<%#Eval("ReplyID")%>">编辑</a> | 
                            <a href="edit_wx_ReplyKey.aspx?replyid=<%#Eval("ReplyID")%>">关键字</a> | 
                            <asp:LinkButton ID="lbtn_del" runat="server" CommandArgument='<%#Eval("ReplyID")%>' CommandName="del" OnClientClick="return confirm('确定删除吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </div>
        <div class="Pagination">
            <cc1:Pagination ID="Pagination1" runat="server" OnPageChanged="Pagination1_PageChanged"
                PageSize="15" />
        </div>
    </form>
</body>
</html>