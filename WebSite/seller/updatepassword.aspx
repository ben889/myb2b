<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatepassword.aspx.cs" Inherits="WebSite.seller.updatepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
</head>
<body>
    <div class="main">
        <div class="header">
            <h2>商家资料
            </h2>
        </div>
        <div class="header_height"></div>
        <div>
            <form id="form1" runat="server" target="hd">
                <div>
                    <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                        <tr>
                            <td align="left">旧密码：</td>
                            <td align="left">
                                <asp:TextBox ID="txboldpass" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>

                                &nbsp;<span style="color: red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">新密码：</td>
                            <td align="left">
                                <asp:TextBox ID="txbpassword" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>

                                &nbsp;<span style="color: red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">确认新密码：</td>
                            <td align="left">
                                <asp:TextBox ID="txbpassword2" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>

                                &nbsp;<span style="color: red;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </form>

            <iframe name="hd" style="display: none;"></iframe>
        </div>
    </div>
</body>
</html>
