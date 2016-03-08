<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editcompanys.aspx.cs" Inherits="WebSite.admin.DesktopModules.Companys.editcompanys" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑代理商</title>
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
            if ($.trim($("#<%=txbCompanyName.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbCompanyName.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
    <script src="../../../js/fourSelect/fourSelect.js"></script>
    <script>
        var fourSelectData = <%=dist_json %>;
        var defaults = {
            s1: 'Select1',
            s2: 'Select2',
            v1: "<%=ProvinceId%>",
            v2: "<%=CityId%>"
        };
        //绑定代理商
    </script>
</head>
<body>
    <div class="header">
        <h2><%=title %>
        </h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="left" width="80">名称
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbCompanyName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>&nbsp;<span style="color: red;">*</span>
                        <asp:HiddenField ID="hfCompanyID" runat="server" Value="0" />
                    </td>
                </tr>
                <%if (id <= 0)
                  { %>
                <tr>
                    <td align="left" >帐号
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbUserName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>&nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="left" >登陆密码
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbPassWord" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>&nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="left">区域：</td>
                    <td align="left">
                        <select id="Select1" name="Select1" class="select"></select>
                        <select id="Select2" name="Select2" class="select"></select>
                    </td>
                </tr>
                <tr>
                    <td align="left">Email：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbEmail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">网址：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbWebsite" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">联系人：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbContact" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">电话：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbPhone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">手机：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbMobile" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">传真：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbFax" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">地址：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbAddress" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                    <td align="left">域名：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbdomain" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>&nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>--%>
                
                <tr>
                    <td align="left">状态：
                    </td>
                    <td align="left">
                        <asp:Literal ID="ltrstatus" runat="server"></asp:Literal>
                    </td>
                </tr>
                <%if (1==2)
                  { %>
                <tr>
                    <td align="left">余额：
                    </td>
                    <td align="left">
                        <asp:Literal ID="ltrtotalamount" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="left">二维码：
                    </td>
                    <td align="left">
                        <%=qrcodeimg %>
                        <asp:Button ID="btqrcode" runat="server" Text="刷新" OnClick="btqrcode_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left">微信二维码：
                    </td>
                    <td align="left">
                        <%=wxqrcodeimg %>
                        <asp:FileUpload ID="fuwxqrcode" runat="server" />
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td></td>
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
