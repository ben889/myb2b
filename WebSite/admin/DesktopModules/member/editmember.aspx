<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editmember.aspx.cs" Inherits="WebSite.admin.DesktopModules.member.editmember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员编辑</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/commoncheck.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnsave.ClientID %>").click(function () {
                return chcekform();
            });
        });
        function chcekform() {
            if ($.trim($("#<%=txbuname.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbuname.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <div class="header">
        <h2>
            <%=title %>
        </h2>
    </div>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="2" border="0" class="formtable">
            <%if (id <= 0)
              { %>
            <tr>
                <td align="left" width="60">
                    用户名
                </td>
                <td align="left">
                    <asp:TextBox ID="txbuname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbpassword" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    房号：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbuno" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    
                </td>
            </tr>
            <%} %>
            <tr>
                <td align="left">
                    邮箱：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    手机：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbmobile" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    电话：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbtel" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <%if (id > 0)
              { %>
            <tr>
                <td align="left">
                    总金额：
                </td>
                <td align="left">
                    <asp:Label ID="lbbalance" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    开通日期：
                </td>
                <td align="left">
                    <asp:Label ID="lbaddtime" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <%} %>
            <tr>
                <td align="left">
                    是否锁定：
                </td>
                <td align="left">
                    <asp:CheckBox ID="chkislock" Text="是" runat="server" Checked="False" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:HiddenField ID="hfuid" runat="server" Value="0" />
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                    <input id="Button1" type="button" class="button create" value="返回" onclick="location.href = 'agent.aspx';" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
