<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editwx_config.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.editwx_config" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信参数配置</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/commoncheck.js"></script>
</head>
<body>
    <div class="header">
        <h2>微信参数配置
        </h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td>MchId：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbMchId" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>&nbsp;微信支付商户号
                    </td>
                </tr>
                <tr>
                    <td>AppId：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbAppId" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>&nbsp;
                    <br />
                        应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
                    </td>
                </tr>
                <tr>
                    <td>AppSecret：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbAppSecret" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>&nbsp;
                    <br />
                        应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
                    </td>
                </tr>
                <tr>
                    <td>AppKey：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbAppKey" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>&nbsp;
                    <br />
                        API密钥，在微信商户平台中“账户设置”--“账户安全”--“设置API密钥”，只能修改不能查看
                    </td>
                </tr>
                <tr>
                    <td>Token：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbToken" runat="server" Width="200px" CssClass="textbox" placeholder="自动生成" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>微信公众平台服务配置URL：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbwxapiurl" runat="server" Width="500px" CssClass="textbox" placeholder="自动生成" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 4px 0; text-align: left;" class="page-footer">
            <div class="btn-list" style="padding-left: 100px;">
                <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                <input id="Button1" type="button" class="button create" value="返回" onclick="location.href = 'companys.aspx';" />
            </div>
        </div>
    </form>
</body>
</html>
