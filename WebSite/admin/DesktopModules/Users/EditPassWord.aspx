<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPassWord.aspx.cs" Inherits="Users.EditPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑帐号密码</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setnavstytle("liupdatepassword");
            $("#<%=btnsave.ClientID %>").click(function () {
                return chcekform();
            });
        });
        function chcekform() {
            if ($.trim($("#<%=txbPassWord.ClientID %>").val()) == "") {
                alert("密码不能为空！");
                $("#<%=txbPassWord.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txbPassWord2.ClientID %>").val()) == "") {
                alert("请输入确认密码！");
                $("#<%=txbPassWord2.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txbPassWord.ClientID %>").val()) != $.trim($("#<%=txbPassWord2.ClientID %>").val())) {
                alert("密码不一至！");
                $("#<%=txbPassWord2.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txbPassWord.ClientID %>").val()).length < 8 || $.trim($("#<%=txbPassWord2.ClientID %>").val()).length < 8) {
                alert("密码至少为 8 个字节！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="EditUsers.aspx?userid=<%=userid %>">编辑帐号</a></li>
                    <li><a href="javascript:;" class="selected">更改密码</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div style="margin-bottom: 12px;">
    </div>
    <div style="padding:10px;">
        <table border="0" cellpadding="2" cellspacing="1" class="formtable">
            <tr>
                <td colspan="2" align="left">
                    <h2>
                        <b>管理密码 -
                            <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
                        </b>
                    </h2>
                    <asp:HiddenField ID="hfUserId" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding: 0px;">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left" height="28">
                    <h2>
                        <b>更改密码 </b>
                    </h2>
                </td>
            </tr>
            <tr>
                <td align="left">
                    密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbPassWord" runat="server" Width="180" TextMode="Password"  CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    确认密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbPassWord2" runat="server" Width="180" TextMode="Password"  CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="btnsave" runat="server" Text="修改" CssClass="button save" OnClick="btnsave_Click" />
                    <asp:Button ID="btnreturn" runat="server" Text="返回" CssClass="button create" OnClick="btnreturn_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
