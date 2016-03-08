<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_wx_diymenu_ac.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.wx.edit_wx_diymenu_ac" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置菜单内容</title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/wx.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../../layer/layer-v1.9.3/layer.js"></script>
    <script src="../../common/wx.js"></script>
    <script src="../../js/Common.js"></script>
    <script src="../../../amazeui/assets/js/amazeui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var RefType = "<%=RefType%>"; //0自定义链接， 1文字，2图片，3图文，4音频，5视频
        $(document).ready(function () {
            tabs();
            bindtabs();
        });
    </script>
    <script>
        //选择选项卡
        function bindtabs() {

            var index = 0;
            if (RefType == "1" || RefType == "2" || RefType == "3") {
                index = 1;
            }
            selected_tabs(index);
            media_type_list_bind();
        }
        function media_type_list_bind() {
            if (RefType == "1")//如果是文字
            {
                select_tabs(0);
            }
            else if (RefType == "3")//如果是图文
            {
                select_tabs(1);
            }
        }
    </script>
    <script>
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
    <div style="padding: 10px;">
        <div class="am-cf am-padding" style="padding: 0.4rem;">
            <div class="am-fl am-cf">
                <strong class="am-text-primary am-text-lg">自定义菜单(<%=Name %>)</strong> / <small>设置菜单内容</small>
            </div>
        </div>
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap" id="tab_menu">
                    <ul>
                        <li><a href="javascript:;" class="selected">跳转到网页</a></li>
                        <li><a href="javascript:;">发送消息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="tab_box">
            <div class="tab-content">
                <form id="form1" name="form1" action="edit_wx_diymenu_ac.aspx" target="hd" method="post"
                class="am-form" style="padding: 10px;">
                <table cellspacing="1" cellpadding="2" border="0" class="formtable" width="500">
                    <tr>
                        <td align="left" width="100">
                            页面地址
                        </td>
                        <td align="left">
                            <input name="URL" type="text" value="<%=URL %>" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <input name="ac" type="hidden" value="updateurl" />
                            <input name="id" type="hidden" value="<%=id %>" />
                            <button type="submit" class="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner:'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}">
                                &nbsp;&nbsp;提交&nbsp;&nbsp;</button> 
                            <button type="button" class="am-btn am-btn-warning" onclick="history.go(-1);">
                &nbsp;&nbsp;返回&nbsp;&nbsp;</button>

                        </td>
                    </tr>
                </table>
                </form>
            </div>
            <div class="tab-content" style="display: none;">
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
                        <form id="form3" name="form3" action="edit_wx_diymenu_ac.aspx" target="hd" method="post"
                        class="am-form" style="padding: 10px;">
                        <input name="Body" type="text" value="<%=Body %>" />
                        <div style="margin: 10px 0;">
                            <input name="ac" type="hidden" value="update_text" />
                            <input name="id" type="hidden" value="<%=id %>" />
                            <button type="submit" class="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner:'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}">
                                &nbsp;&nbsp;提交&nbsp;&nbsp;</button> 
                            <button type="button" class="am-btn am-btn-warning" onclick="history.go(-1);">
                &nbsp;&nbsp;返回&nbsp;&nbsp;</button>
                        </div>
                        </form>
                    </div>
                    <div id="c_1" style="display: none;">
                        <form id="form2" name="form2" action="edit_wx_diymenu_ac.aspx" target="hd" method="post"
                        class="am-form" style="padding: 10px;">
                        <div id="appmsg_list" style="width: 400px;">
                        </div>
                        <div style="margin: 10px 0;">
                            <input name="ac" type="hidden" value="updateimg_text" />
                            <input name="id" type="hidden" value="<%=id %>" />
                            <%--<input id="reftype" name="reftype" type="hidden" value="<%=RefType %>" />--%>
                            <input id="refid" name="refid" type="hidden" value="<%=RefID %>" />
                            <button type="submit" class="am-btn am-btn-primary btn-loading-example" data-am-loading="{spinner:'circle-o-notch', loadingText: '提交中...', resetText: '&nbsp;&nbsp;提交&nbsp;&nbsp;'}">
                                &nbsp;&nbsp;提交&nbsp;&nbsp;</button>
                                <button type="button" class="am-btn am-btn-warning" onclick="history.go(-1);">
                &nbsp;&nbsp;返回&nbsp;&nbsp;</button>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
