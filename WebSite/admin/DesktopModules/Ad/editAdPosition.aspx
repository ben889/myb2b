<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editAdPosition.aspx.cs" Inherits="WebSite.admin.DesktopModules.Ad.editAdPosition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
            if ($.trim($("#<%=txbname.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbname.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <div class="header">
        <h2>编辑广告位
        </h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="left" width="60">名称
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        <asp:HiddenField ID="hfid" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td align="left">调用别名
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbcall_index" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">大小
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbwidth" runat="server" Width="50px" Text="" onblur="setNumInput('txbwidth')" CssClass="textbox"></asp:TextBox> px * 
                        <asp:TextBox ID="txbheight" runat="server" Width="50px" Text="" onblur="setNumInput('txbheight')" CssClass="textbox"></asp:TextBox> px
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnreturn" runat="server" Text="返回" CssClass="button create" OnClick="btnreturn_Click" />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
