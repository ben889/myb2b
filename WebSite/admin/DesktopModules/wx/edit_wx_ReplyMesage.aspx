<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_wx_ReplyMesage.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.wx.edit_wx_ReplyMesage" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>自动回复规则</title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/wx.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script src="../../../layer/layer-v1.9.3/layer.js"></script>
    <script src="../../common/wx.js" type="text/javascript"></script>
    <script type="text/javascript">
        var RefType = "<%=reftype%>";
        $(document).ready(function () {
            $("#<%=btnsave.ClientID %>").click(function () {
                return save();
            });
            media_type_list_bind();
        });
    </script>
    <script>
        function media_type_list_bind() {
            bind_w_tabs(0);
            if (RefType == "1")//如果是文字
            {
                bind_w_tabs(0);
            }
            else if (RefType == "3")//如果是图文
            {
                bind_w_tabs(1);
            }
        }
    </script>
    <script>
        function save() {
            LoadDialog("提交中.."); // 现实加载进度
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog(); // 隐藏加载进度
            window.location.href = "wx_ReplyMesage.aspx";
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog(); // 隐藏加载进度
        }
    </script>
</head>
<body>
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" class="selected">编辑自动回复规则</a></li>
                </ul>
            </div>
        </div>
    </div>
    <form id="form1" runat="server" target="hd" class="am-form">
    <div style="margin-top: 10px; width: 600px;">
        <table cellspacing="1" cellpadding="2" border="0" class="formtable" width="600">
            <tr>
                <td align="left" width="100">
                    名称：<span style="color: Red;">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txbName" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    是否可用：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="select">
                        <asp:ListItem Value="1">可用</asp:ListItem>
                        <asp:ListItem Value="0">不可用</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div style="padding: 8px 0 8px 0;">
            <ul class="media_type_list">
                <li class="tab_text selected" title="文字"><a href="javascript:;" class="Js_reply_add">
                    &nbsp;<i class="icon_msg_sender"></i></a></li>
                <%--<li class="tab_img" data-tooltip="图片"><a href="javascript:;" data-type="2" data-id="208091005"
                    class="Js_reply_add">&nbsp;<i class="icon_msg_sender"></i></a></li>
                <li class="tab_audio" data-tooltip="语音"><a href="javascript:;" data-type="3" data-id="208091005"
                    class="Js_reply_add">&nbsp;<i class="icon_msg_sender"></i></a></li>
                <li class="tab_video" data-tooltip="视频"><a href="javascript:;" data-type="7" data-id="208091005"
                    class="Js_reply_add">&nbsp;<i class="icon_msg_sender"></i></a></li>--%>
                <li class="tab_appmsg" title="图文"><a href="javascript:;" class="Js_reply_add" onclick="select_material(3);">
                    &nbsp;<i class="icon_msg_sender"></i></a></li>
            </ul>
            <div class="media_type_box">
                <div id="c_0" style="padding: 8px; border: 1px solid #cccccc;">
                    <asp:TextBox ID="txbBody" runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </div>
                <div id="c_1" style="display: none;">
                    <div id="appmsg_list" style="width: 400px;">
                    </div>
                </div>
            </div>
        </div>
        <div style="margin: 4px 0; text-align: left;" class="page-footer">
            <div class="btn-list" style="padding-left: 100px; text-align: left;">
                <asp:HiddenField ID="hfid" runat="server" Value="" />
                <input id="reftype" name="reftype" type="hidden" value="<%=reftype %>" />
                <input id="refid" name="refid" type="hidden" value="<%=refid %>" />
                <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                <input id="btn_return" type="button" class="button create" value="返回" onclick="history.go(-1);" />
            </div>
        </div>
        <iframe name="hd" style="display: none;"></iframe>
    </div>
    </form>
</body>
</html>
