<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_district.aspx.cs" Inherits="WebSite.admin.DesktopModules.district.edit_district" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../../js/dialog/js/dialog.js"></script>
    <link href="../../../js/dialog/css/dialog.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnsave").click(function () {
                return save();
            });
        });

    </script>
     <script>
         function save() {
             var name = $("#txbName").val();
             if ($.trim(name) == "") {
                 alert("请填写区域名称！");
                 $("#txbName").focus();
                 return false;
             }
             LoadDialog("提交中..");
             return true;
         }
         function success(info) {
             if (info != "") {
                 alert(info);
             }
             RemoveLoadDialog();
             window.location.href = "district.aspx";
         }
         function fail(info) {
             if (info != "") {
                 alert(info);
             }
             RemoveLoadDialog();
         }
    </script>
</head>
<body>
    <div class="header">
        <h2><%=title %>
        </h2>
    </div>
    <div class="header_height"></div>
    <form id="form1" runat="server" target="hd">
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="edittable">
                <tr>
                    <td align="left" width="80">所属父区域
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddldistrict" runat="server" CssClass="select"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">名称
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbName" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        <asp:HiddenField ID="hfid" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td align="left">调用代码
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbcall_index" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">排序
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbSort" runat="server" Width="50px" Text="99" CssClass="textbox" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                        <input id="btnreturn" type="button" value="返回" class="button cancel" onclick="location.href = 'district.aspx';" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
