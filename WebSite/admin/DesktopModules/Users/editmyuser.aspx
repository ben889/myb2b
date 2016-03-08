<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editmyuser.aspx.cs" Inherits="WebSite.admin.DesktopModules.Users.editmyuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="2" border="0" class="formtable">
            <tr>
                <td align="right">
                    帐号：
                </td>
                <td align="left">
                    <asp:Label ID="lbusername" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfuserid" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Email：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbEmail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    名称：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbDisplayName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    状态：
                </td>
                <td align="left">
                    <asp:Label ID="lbIsLockedOut" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnsave" runat="server" Text="更改" CssClass="button save" OnClick="btnsave_Click" />
                    <input id="Button1" type="button" class="button create" value="返回" onclick="location.href = 'agent.aspx';" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
