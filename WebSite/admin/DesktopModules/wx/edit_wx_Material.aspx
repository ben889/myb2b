<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_wx_Material.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.wx.edit_wx_Material" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑图文消息</title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="/kindeditor/kindeditor.js" type="text/javascript" charset="utf-8"></script>
    <script src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnsave").click(function () {
                return submitform();
            });
            editorinit();
        });
    </script>
    <script>
        function editorinit() {
            KindEditor.ready(function (K) {
                //初始化编辑器
                var editor = KindEditor.create('textarea[name="Body"]', {
                    width: '100%',
                    height: '350px',
                    resizeType: 1,
                    allowFileManager: true,
                    allowPreviewEmoticons: false,
                    allowImageUpload: true,
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_wx()%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_wx()%>'
                });
                editor.sync();
                K('#ImgUrl').click(function () {
                    editor.loadPlugin('image', function () {
                        //图片弹窗的基本参数配置
                        editor.plugin.imageDialog({
                            imageUrl: K('#ImgUrl').val(), //如果图片路径框内有内容直接赋值于弹出框的图片地址文本框
                            //点击弹窗内”确定“按钮所执行的逻辑
                            clickFn: function (url, title, width, height, border, align) {
                                K('#ImgUrl').val(url); //获取图片地址
                                editor.hideDialog(); //隐藏弹窗
                            }
                        });
                    });
                });
            });
        }
    </script>
    <script>
        function submitform() {
            if ($.trim($("#Name").val()) == "") {
                alert("标题不能为空");
                $("#Name").focus();
                return false;
            }
            LoadDialog("提交中");
            $("#form1").submit();
        }

        function del(id) {
            if (!confirm('确定删除吗？')) {
                return false;
            }
            LoadDialog("删除中");
            $("#delid").val(id);
            $("#form_del").submit();
        }
    </script>
    <script>
        function success(parentid) {
            location.href = "edit_wx_Material.aspx?parentid=" + parentid;
            RemoveLoadDialog();
        }
        function fail(info) {
            if (info != "")
                alert(info);
            RemoveLoadDialog();
        }
        function del_success() {
            location.href = location.href;
            RemoveLoadDialog();
        }
    </script>
</head>
<body>
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" class="selected">编辑图文消息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div style="position: relative;">
        <div class="imglist" style="padding: 10px; width: 250px;">
            <div class="imgtext_item" style="width: 224px; border: 1px solid #cccccc;">
                <div style="text-align: left; margin-bottom: 2px;" id="imgtextdiv">
                    <%if (info!=null&&info.wx_MaterialID>0){ %>
                    <div style="padding: 8px 12px;">
                        <div style="padding-bottom: 4px; position:relative;">
                        <%=info.Name %>
                        <div style=" position:absolute; right:2px;top:2px;">
                                <a href="?parentid=<%=parentid %>&id=<%=info.wx_MaterialID %>" title="选择图文内容">
                                    <img src="/admin/images/edit.gif" />
                                </a>&nbsp;
                            </div>
                        </div>
                        <div style="height: 120px; overflow: hidden;">
                            <img src="<%=info.ImgUrl %>" width="200"></div>
                    </div>
                    <%} %>
                    <%if(list!=null&&list.Count>0){ %>
                    <%foreach(Model.wx_MaterialInfo minfo in list){ %>
                    <div style="border-top: 1px solid #cccccc; margin-top: -1px; padding: 10px 12px;
                        height: 80px; width: auto;">
                        <div style="float: left;">
                            <div><%=minfo.Name %></div>
                            <div>
                                <a href="?parentid=<%=parentid %>&id=<%=minfo.wx_MaterialID %>" title="选择图文内容">
                                    <img src="/admin/images/edit.gif" />
                                </a>&nbsp;<a href="javascript:;" title="删除图文内容" onclick="return del('<%=minfo.wx_MaterialID %>');">
                                    <img src="/admin/images/delete.gif" />
                                </a>
                            </div>
                        </div>
                        <div style="height: 60px; width: 60px; overflow: hidden; float: right;">
                            <img src="<%=minfo.ImgUrl %>" width="60"></div>
                    </div>
                    <%} %>
                    <%} %>
                </div>
                <div style="padding: 4px 12px; border-top: 1px solid #cccccc;">
                    <a href="?parentid=<%=parentid %>&add=1" title="">
                        <img src="/admin/images/add.gif" />
                    </a>&nbsp;
                    <a href="javascript:;" title="" onclick="location.href='wx_Material.aspx'" title="返回">
                        <img src="/admin/images/action_export.gif" />
                    </a>
                    
                </div>
            </div>
            <form id="form_del" name="form_del" action="edit_wx_Material.aspx" target="hd">
            <input id="delid" name="id" type="hidden" value="0" />
            <input name="ac" type="hidden" value="del" />
            </form>
        </div>
        <%if(id>0||add.Trim().Length>0){ %>
        <div style="position: absolute; left: 250px; top: 10px; right: 12px;">
            <form id="form1" name="form1" runat="server" class="am-form" target="hd">
            <div class="am-comment-main" style="margin-left: 0;">
                <header class="am-comment-hd">
      <div class="am-comment-meta">添加图文</div>
    </header>
                <div class="am-comment-bd">
                    <div class="am-form-group">
                        <label for="title">
                            标题</label>
                        <input type="text" class="" id="Name" name="Name" placeholder="输入标题" value="<%=Name %>" />
                    </div>
                    <div class="am-input-group" style="margin-bottom: 1.5rem;">
                        <span class="am-input-group-label"><i class="am-icon-user am-icon-fw"></i></span>
                        <input type="text" class="am-form-field" placeholder="封面图" id="ImgUrl" name="ImgUrl"
                            readonly="readonly" value="<%=ImgUrl %>" />
                    </div>
                    <div class="am-form-group">
                        <label for="Paper">
                            链接地址</label>
                        <%=selecturl%>
                    </div>
                    <div class="am-form-group">
                        <label for="Paper">
                            摘要</label>
                        <textarea class="" rows="5" id="Paper" name="Paper"><%=Paper%></textarea>
                    </div>
                    <div class="am-form-group">
                        <label for="Body">
                            正文</label>
                        <textarea class="" rows="5" id="Body" name="Body"><%=Body%></textarea>
                    </div>
                    <div class="am-form-group">
                    <%--<button type="button" class="am-btn am-btn-primary" style="font-size:1.4rem;" onclick="submitform();"> &nbsp;&nbsp;保存&nbsp;&nbsp;</button>--%>
                    <asp:Button ID="btnsave" runat="server" Text="&nbsp;&nbsp;保存&nbsp;&nbsp;" CssClass="am-btn am-btn-primary" style="font-size:1.4rem;" OnClick="btnsave_Click" />
                    </div>

                </div>
            </div>
            </form>
            
        </div>
        <%} %>
        <iframe name="hd" style="display: none;"></iframe>
    </div>
</body>
</html>
