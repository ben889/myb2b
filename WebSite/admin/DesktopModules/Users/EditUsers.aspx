<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="Users.EditUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑帐号</title>
    <%--<link href="../../Css/pagestyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../style/style.css" />--%>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setnavstytle("liedituser");
            //parent.selectmenu("users");
            //window.parent.document.getElementById("frmleft").contentWindow.selectmenu("users");
            $("#<%=txbUserName.ClientID %>").blur(function () {
                if ($.trim($(this).val()) != "") {
                    checkusername($.trim($("#<%=hfUserId.ClientID %>").val()), $.trim($("#<%=txbUserName.ClientID %>").val()));
                }
            });
            $("#<%=btnsave.ClientID %>").click(function () {
                return chcekform();
            });
        });
        function chcekform() {
            if ($.trim($("#<%=txbUserName.ClientID %>").val()) == "") {
                alert("帐号不能为空！");
                $("#<%=txbUserName.ClientID %>").focus();
                return false;
            }
            else {

            }
            if ($.trim($("#<%=txbPassWord.ClientID %>").val()) == "" && $("#<%=hfUserId.ClientID %>").val() == "0") {
                alert("密码不能为空！");
                $("#<%=txbPassWord.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txbPassWord2.ClientID %>").val()) == "" && $("#<%=hfUserId.ClientID %>").val() == "0") {
                alert("请输入确认密码！");
                $("#<%=txbPassWord2.ClientID %>").focus();
                return false;
            }
            if ($.trim($("#<%=txbPassWord.ClientID %>").val()) != $.trim($("#<%=txbPassWord2.ClientID %>").val()) && $("#<%=hfUserId.ClientID %>").val() == "0") {
                alert("密码不一至！");
                $("#<%=txbPassWord2.ClientID %>").focus();
                return false;
            }
            if (($.trim($("#<%=txbPassWord.ClientID %>").val()).length < 8 || $.trim($("#<%=txbPassWord2.ClientID %>").val()).length < 8) && $("#<%=hfUserId.ClientID %>").val() == "0") {
                alert("密码至少为 8 个字节！");
                return false;
            }

            return true;
        }

        var ajaxdata;
        function checkusername(useridval, usernameval) {
            var returnbool = true;
            var str = /^[a-z0-9.]*$/gi;
            if (!str.test($("#<%=txbUserName.ClientID %>").val())) {
                $("#promptinfo").html("<img src='/admin/images/deny.gif'/> <font style='color:red;'>只能輸入英文和數字﹐請改正！</font>");
                $("#<%=txbUserName.ClientID %>").focus();
                returnbool = false;
                $("#<%=btnsave.ClientID %>").attr("disabled", "disabled");
            }
            else {
                ajaxdata = { ajaxmethod: "checkusername", userid: useridval, username: usernameval };
                $.ajax({
                    type: "POST",
                    url: "<%=Request.Url.AbsoluteUri %>",
                    data: ajaxdata,
                    beforeSend: function () {
                        $("#promptinfo").html("<font style='color:red;'>检查中...</font>");
                    },
                    success: function (result) {//如果result=1表示成功
                        if (result == "0") {
                            $("#promptinfo").html("<img src='/admin/images/grant.gif'/> <font style='color:green;'>此帐号可用</font>");
                            returnbool = true;
                            $("#<%=btnsave.ClientID %>").removeAttr("disabled");
                        }
                        else if (result == "1") {
                            $("#promptinfo").html("<img src='/admin/images/deny.gif'/> <font style='color:red;'>帐号已存在！</font>");
                            $("#<%=txbUserName.ClientID %>").focus();
                            returnbool = false;
                            $("#<%=btnsave.ClientID %>").attr("disabled", "disabled");
                        }
                        else {
                            $("#promptinfo").html("<img src='/admin/images/deny.gif'/> <font style='color:red;'>异常！</font>");
                            returnbool = false;
                            $("#<%=btnsave.ClientID %>").attr("disabled", "disabled");
                        }
                    },
                    error: function () { $("#promptinfo").html("<img src='/admin/images/deny.gif'/> <font style='color:red;'>异常错误！</font>"); }
                });
            }
            return returnbool;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" class="selected">编辑帐号</a></li>
                    <%if (userid > 0)
                      { %>
                    <li><a href="EditPassWord.aspx?userid=<%=userid %>">更改密码</a></li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
    <div style="margin-bottom: 12px;">
    </div>
    <div style="padding:10px;">
        <table width="100%" border="0" cellpadding="2" cellspacing="1" class="formtable">
            <tr>
                <td width="80" align="left">
                    帐号：
                </td>
                <td align="left">
                    <asp:HiddenField ID="hfUserId" runat="server" Value="0" />
                    <asp:TextBox ID="txbUserName" runat="server" Width="180" Style="ime-mode: disabled;"
                        class="textbox"></asp:TextBox>&nbsp; <span id="promptinfo"></span>
                </td>
            </tr>
            <tr>
                <td align="left">
                    显示名称：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbDisPlayName" runat="server" Width="180" class="textbox"></asp:TextBox>
                </td>
            </tr>
            <tbody id="passrow" runat="server">
                <tr>
                    <td align="left">
                        密码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbPassWord" runat="server" TextMode="Password" Width="180" class="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        确认密码：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbPassWord2" runat="server" TextMode="Password" Width="180" class="textbox"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tr>
                <td align="left">
                    Email：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbEmail" runat="server" Width="180" class="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    姓：
                </td>
                <td align="left">
                    <asp:TextBox ID="txbFirstName" runat="server" Width="50" class="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    名：
                    <asp:TextBox ID="txbLastName" runat="server" Width="100" class="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    允许登陆：
                </td>
                <td align="left">
                    <asp:RadioButton ID="rbNoIsLockedOut" runat="server" GroupName="IsLockedOut" Checked="true"
                        Text="是" />
                    <asp:RadioButton ID="rbIsLockedOut" runat="server" GroupName="IsLockedOut" Text="否" />
                </td>
            </tr>
        </table>
    </div>
    <div style="margin: 4px 0; text-align: center;">
        <div style="text-align: left; margin-left: 124px;">
            <asp:Button ID="btnsave" runat="server" Text="添加" CssClass="button save" OnClick="btnsave_Click"  />
            <asp:Button ID="btnreturn" runat="server" Text="返回" CssClass="button create" OnClick="btnreturn_Click" />
        </div>
    </div>
    </form>
</body>
</html>
