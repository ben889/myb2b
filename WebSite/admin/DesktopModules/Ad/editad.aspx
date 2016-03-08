<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editad.aspx.cs" Inherits="WebSite.admin.DesktopModules.Ad.editad" %>

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
            if ($.trim($("#<%=txbadname.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbadname.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
    <script>
        function success(info) {
            if (info != "")
                alert(info);
            location.href = "ad.aspx?call_index=<%=call_index %>";
        }
        function fail(info) {
            if (info != "")
                alert(info);
        }
    </script>
</head>
<body>
    <div class="header">
        <h2>
            <%=title %>
        </h2>
    </div>
     <form id="form1" runat="server" enctype="multipart/form-data" target="hd">
    <div>
        <table cellspacing="1" cellpadding="2" border="0" class="formtable">
            <tr>
                <td align="left" width="60">
                    名称
                </td>
                <td align="left">
                    <asp:TextBox ID="txbadname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    <asp:HiddenField ID="hfadid" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td align="left" >
                    广告位
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAdPosition" runat="server" CssClass="select">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    广告图
                </td>
                <td align="left">
                    <%=img %>
                    <div class="file-box">
                    <input type='text' name='txbviewadimg' id='txbviewadimg' class='txt' />
                    <input type='button' class='btn' value='浏览...' />
                    <asp:FileUpload ID="file_adimg" runat="server" CssClass="file" onchange="document.getElementById('txbviewadimg').value=this.value" />
                < 500k</div>
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    链接地址
                </td>
                <td align="left">
                    <asp:TextBox ID="txbadlink" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    打开方式
                </td>
                <td align="left">
                    <asp:RadioButton ID="rbtnadblank0" GroupName="rbtnadblank" runat="server" Text="原窗口"
                        Checked="true" />
                    <asp:RadioButton ID="rbtnadblank1" GroupName="rbtnadblank" runat="server" Text="新窗口" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    状态
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="select">
                        <asp:ListItem Value="1">开通</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    点击数
                </td>
                <td align="left">
                    <asp:TextBox ID="txbclick" runat="server" Width="40px" CssClass="textbox" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                    <input id="btn_return" type="button" class="button create" value="返回" onclick="location.href = 'ad.aspx';" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
