<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="editarticle.aspx.cs"
    Inherits="WebSite.admin.DesktopModules.article.editarticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="/kindeditor/kindeditor.js" type="text/javascript" charset="utf-8"></script>
    <script src="/kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../../js/common.js"></script>
    <script src="../../js/commoncheck.js" type="text/javascript"></script>
    <link href="/js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="/js/dialog/js/dialog.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnsave.ClientID %>").click(function () {
                return submitform();
            });
            tabs();
            editorinit();
        });
    </script>
    <script>
        function editorinit()
        {
            KindEditor.ready(function (K) {
                //初始化编辑器
                var editor = KindEditor.create('textarea[name="content"]', {
                    width: '98%',
                    height: '350px',
                    resizeType: 1,
                    allowFileManager: true,
                    allowPreviewEmoticons: false,
                    allowImageUpload: true,
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_article()%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_article()%>'
                });
                     editor.sync();
                     K('#image').click(function () {
                         editor.loadPlugin('image', function () {
                             //图片弹窗的基本参数配置
                             editor.plugin.imageDialog({
                                 imageUrl: K('#img_url').val(), //如果图片路径框内有内容直接赋值于弹出框的图片地址文本框
                                 //点击弹窗内”确定“按钮所执行的逻辑
                                 clickFn: function (url, title, width, height, border, align) {
                                     K('#img_url').val(url);//获取图片地址
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
            if ($.trim($("#txbtitle").val()) == "") {
                alert("标题不能为空");
                $("#txbtitle").focus();
                return false;
            }
            LoadDialog("提交中");
            $("#form1").submit();
        }


    </script>
    <script>
        function success(info) {
            if (info != "")
                alert(info);
            location.href = "article.aspx";
            RemoveLoadDialog();
        }
        function fail(info) {
            if (info != "")
                alert(info);
            RemoveLoadDialog();
        }
    </script>
</head>
<body>
    <div class="header">
        <h2>
            编辑文章
        </h2>
    </div>
    <form id="form1" name="form1" runat="server" enctype="multipart/form-data" target="hd">
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap" id="tab_menu">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">详细描述</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">SEO选项</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="tab_box">
        <div class="tab-content">
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="right">
                        标题：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbtitle" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
                        <asp:HiddenField ID="hfid" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        内容摘要：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbzhaiyao" runat="server" Width="400px" Height="80" CssClass="textbox"
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        排序：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txborderby" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        浏览次数：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbclick" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        状态：
                    </td>
                    <td align="left">
                        <asp:RadioButton ID="rbtnstatus0" GroupName="status" runat="server" Text="正常" Checked="true" />
                        <asp:RadioButton ID="rbtnstatus1" GroupName="status" runat="server" Text="未审核" />
                        <asp:RadioButton ID="rbtnstatus2" GroupName="status" runat="server" Text="锁定" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        其它设置：
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="ckbis_top" runat="server" Text="置顶" />
                        <asp:CheckBox ID="ckbis_red" runat="server" Text="推荐" />
                        <asp:CheckBox ID="ckbis_hot" runat="server" Text="热门" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right">
                        幻灯片：
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="ckbis_slide" runat="server" Text="是" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        类别：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlcategory" runat="server" CssClass="select">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        调用别名：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbcall_index" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        <span style="color: red;">注：此处如非开发人员，请不要随意更改</span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        所属站点
                    </td>
                    <td align="left">
                        <%=CompanyControls %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        外部链接：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txblink_url" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        图片：
                    </td>
                    <td align="left">
                        <%=img %>
                        <input type="text" name="img_url" id="img_url" value="<%=img_url %>" readonly="readonly"
                            class="textbox" style="width: 300px;" />
                        <input type="button" id="image" value="选择图片" />
                        < 500k
                    </td>
                </tr>
            </table>
        </div>
        <div class="tab-content" style="display: none;">
            <table cellspacing="1" cellpadding="2" border="0" class="formtable" width="100%">
                <tr>
                    <td align="left" width="70">
                        内容
                    </td>
                    <td align="left">
                        <textarea id="content" name="content" rows="8"><%=content%></textarea>
                        <br />
                        限制3000字内
                    </td>
                </tr>
            </table>
        </div>
        <div class="tab-content" style="display: none;">
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="left" width="70">
                        SEO标题
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbseo_title" runat="server" Width="500px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        SEO关健字
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbseo_keywords" runat="server" Width="600px" CssClass="textbox"
                            TextMode="MultiLine" Height="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        SEO描述
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbseo_description" runat="server" Width="600px" CssClass="textbox"
                            TextMode="MultiLine" Height="80"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="margin: 4px 0; text-align: left;" class="page-footer">
        <div class="btn-list" style="padding-left: 100px;">
            <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
            <input id="btnreturn" type="button" class="button create" value="返回" onclick="location.href = 'article.aspx';" />
        </div>
    </div>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
