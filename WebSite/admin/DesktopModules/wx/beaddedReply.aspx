<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="beaddedReply.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.beaddedReply" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>被添加自动回复</title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/wx.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>
    <script src="../../../layer/layer-v1.9.3/layer.js"></script>
    <script src="../../common/wx.js" type="text/javascript"></script>
    <script src="../../../amazeui/assets/js/amazeui.min.js" type="text/javascript"></script>
    <script>
        var RefType = "<%=reftype%>";
        $(document).ready(function () {
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
            var $btn = $('.btn-loading-example');
            $btn.button('loading');
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }

            window.location.href = window.location.href;
            $('.btn-loading-example').button('reset');
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            $('.btn-loading-example').button('reset');
        }
    </script>
</head>
<body>
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" class="selected">被添加自动回复</a></li>
                    <li><a href="wx_ReplyMesage.aspx">关键词自动回复</a></li>
                </ul>
            </div>
        </div>
    </div>
    <form id="form1" runat="server" target="hd" class="am-form">
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
            <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner:'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}" OnClick="btnsave_Click" OnClientClick="return save();" />
        </div>
    </div>
    <iframe name="hd" style="display: none;"></iframe>
    </form>
</body>
</html>
