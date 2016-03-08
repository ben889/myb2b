<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TabsPermission.aspx.cs"
    Inherits="Permission.TabsPermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单权限</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #divlist label
        {
            float: left;
            display: block;
            height: 20px;
            margin: 2px 2px 2px 8px;
        }
        input
        {
            vertical-align: middle;
        }
    </style>
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () { selectall(); });
        function selectsub(ParentID) {
            //alert($("#selectallsub" + ParentID));
            if ($("#selectallsub" + ParentID).is(":checked")) {

                $("#td" + ParentID).find(":checkbox").attr("checked", "true");
            }
            else {
                $("#td" + ParentID).find(":checkbox").removeAttr("checked");
            }
            $("tr[name='tr" + ParentID + "']").each(function () {
                //alert($(this).attr("subname"));

                if ($("#selectallsub" + ParentID).is(":checked")) {

                    $(this).find(":checkbox").attr("checked", "true");
                }
                else {
                    $(this).find(":checkbox").removeAttr("checked");
                }
                var tabid = $(this).attr("subname");
                selectsub(tabid);
            });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <table border="0" cellpadding="2" cellspacing="0" width="100%" align="center">
            <tr>
                <td align="left">
                    <h2>
                        <asp:Literal ID="ltrRoles" runat="server"></asp:Literal>
                        权限设置</h2>
                </td>
                <td align="right">
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-bottom: 2px;">
        <%--<table border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table" width="100%"
                    align="center">
                    <tr>
                        <td align="left" width="80">
                            &nbsp;&nbsp;<b>数据权限</b>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rblDataPermissionType" runat="server" BorderWidth="0" CellPadding="0"
                                CellSpacing="0" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Selected="True">自已</asp:ListItem>
                                <asp:ListItem Value="1">公司权限</asp:ListItem>
                                <asp:ListItem Value="2">部门权限</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>--%>
    </div>
    <div style="margin-top: 4px; border-bottom: 1px solid #cccccc;">
        <div class="selectlist" style="padding: 0 4px 4px 4px;">
            <table border="0" cellspacing="1" cellpadding="2" class="DataGrid_Table" width="100%"
                align="center">
                <tr class="DataGrid_Header">
                    <td align="center" width="60">
                        <input type="checkbox" name="selectall" id="selectall" />全选</label>
                    </td>
                    <td align="center">
                        <b>菜单</b>
                    </td>
                    <td align="center">
                        <b>选择</b>
                    </td>
                </tr>
                <asp:Repeater ID="rpTabslist" runat="server" OnItemDataBound="rpTabslist_ItemDataBound">
                    <ItemTemplate>
                        <tr onmouseover="this.className='DataGrid_SelectedItem'" onmouseout="this.className='DataGrid_Item'"
                            class="DataGrid_Item" name="tr<%#Eval("ParentID") %>" subname="<%#Eval("TabID") %>">
                            <td>
                                <label>
                                    <input type="checkbox" name="selectallsub" id="selectallsub<%#Eval("TabID") %>" onclick="selectsub('<%#Eval("TabID") %>');" />全选
                                </label>
                            </td>
                            <td align="left" style="padding-left: 12px;">
                                <div style="float: left; padding-left: 10px;">
                                    &nbsp;
                                </div>
                                <div style="float: left; padding-left: 10px;">
                                    <%#Eval("TabName") %>
                                    <asp:HiddenField ID="hfTabID" runat="server" Value='<%#Eval("TabID") %>' />
                                </div>
                                <%--<div style="float: right;">
                                    
                                </div>--%>
                                <div style="clear: both;">
                                </div>
                            </td>
                            <td align="left" style="text-align: left;" id="td<%#Eval("TabID") %>">
                                <div>
                                    <asp:Literal ID="ltrlistpaermission" runat="server"></asp:Literal>
                                    <div style="clear: both;">
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <div style="margin: 4px auto; text-align: center;">
        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClientClick="return confirm('确定保存吗？');"
            OnClick="btnsave_Click" />
        <asp:Button ID="btnreturn" runat="server" Text="返回" CssClass="button cancel" OnClick="btnreturn_Click" />
    </div>
    </form>
</body>
</html>
