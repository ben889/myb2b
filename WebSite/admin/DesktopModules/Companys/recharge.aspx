<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recharge.aspx.cs" Inherits="WebSite.admin.DesktopModules.Companys.recharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充值</title>
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
            if ($.trim($("#<%=txbamount.ClientID %>").val()) == "") {
                alert("请输入金额！");
                $("#<%=txbamount.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <div class="header">
        <h2>
            代理商充值
        </h2>
    </div>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="2" border="0" class="formtable">
            <tr>
                <td align="left" width="60">
                    代理商
                </td>
                <td align="left">
                    <asp:Label ID="lbcompanyname" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfCompanyID" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    余额
                </td>
                <td align="left">
                    <asp:Label ID="lbtotalamount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" width="60">
                    充值金额
                </td>
                <td align="left">
                    <asp:TextBox ID="txbamount" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                    <input id="Button1" type="button" class="button create" value="返回" onclick="location.href = 'companys.aspx';" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
