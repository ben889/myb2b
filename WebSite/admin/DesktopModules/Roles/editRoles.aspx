<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editRoles.aspx.cs" Inherits="WebSite.admin.DesktopModules.Roles.editRoles" %>

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
            $(document).click(function () { $("#divicon").hide(); });
        });
        function chcekform() {
            if ($.trim($("#<%=txbRoleName.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbRoleName.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
    <script>
        function selecticon() {
            $("#divicon").css({ top: $("#openiocn").offset().top + $("#openiocn").height(), left: $("#openiocn").offset().left });
            $("#divicon").show();
        }
        function selectimg(val) {
            $("#<%=txbIconFile.ClientID %>,#<%=hfIconFile.ClientID %>").val(val);
        }
    </script>
    <script>
        function closediv() {
            //var index = parent.layer.getFrameIndex(window.name);
            //parent.layer.close(index);
            location.href = "viewroles.aspx";
        }
    </script>
</head>
<body>
    <div class="header">
        <h2>
            编辑角色
        </h2>
    </div>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="1" cellpadding="2" border="0" class="formtable">
            <tr>
                <td width="60" align="left">
                    名称
                </td>
                <td align="left">
                    <asp:TextBox ID="txbRoleName" runat="server" Width="200" CssClass="textbox"></asp:TextBox>
                    <asp:HiddenField ID="hfRoleID" runat="server" Value="0" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    说明
                </td>
                <td align="left">
                    <asp:TextBox ID="txbDescription" runat="server" Width="200" CssClass="textbox"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    图标
                </td>
                <td align="left">
                    <asp:TextBox ID="txbIconFile" runat="server" ReadOnly="true" Width="200" CssClass="textbox"></asp:TextBox>
                    <asp:HiddenField ID="hfIconFile" runat="server" Value="" />
                    <a id="openiocn" href="javascript:selecticon();">
                        <img alt="" src="/admin/images/icon_search_16px.gif" border="0" /></a>
                </td>
            </tr>
            <tr>
                <td align="left">
                </td>
                <td align="left">
                    <asp:Button ID="btnsave" runat="server" CssClass="button save" Text="提交" OnClick="btnsave_Click" />
                    <input id="btnclose" type="button" value="关闭" class="button cancel" onclick="closediv();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <div id="divicon" style="border: 1px solid #ff9900; padding: 4px 2px; width: 294px;
        z-index: 20000; position: absolute; text-align: left; background: #FFF; display: none;">
        <%=iconlist %>
    </div>
</body>
</html>
