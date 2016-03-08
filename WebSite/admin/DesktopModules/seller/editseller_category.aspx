<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editseller_category.aspx.cs" Inherits="WebSite.admin.DesktopModules.seller.editseller_category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/common.js" type="text/javascript"></script>

    <%--kindeditor--%>
    <script src="../../../kindeditor/kindeditor.js"></script>
    <script src="../../../kindeditor/lang/zh_CN.js"></script>
    <link href="../../../kindeditor/themes/default/default.css" rel="stylesheet" />
    <%--/kindeditor--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnsave.ClientID %>").click(function () {
                return chcekform();
            });
        });
        function chcekform() {
            if ($.trim($("#<%=txbtypename.ClientID %>").val()) == "") {
                alert("名称不能为空！");
                $("#<%=txbtypename.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            editorinit();
        });
    </script>
    <script>
        function editorinit() {
            KindEditor.ready(function (K) {
                var editor = K.editor({
                    allowFileManager: true, //允许图片管理 开启后再挑选图片的时候可以直接从图片空间内挑选
                    width: '98%',
                    height: '350px',
                    //resizeType: 1,
                    //allowPreviewEmoticons: false,
                    allowImageUpload: true,
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                });
                //给按钮添加click事件
                //K('#image').click(function () {
                //    alert("你点我了!");
                //});
                K('#image').click(function () {
                    editor.loadPlugin('image', function () {
                        //图片弹窗的基本参数配置
                        editor.plugin.imageDialog({
                            imageUrl: K('#txbimg').val(), //如果图片路径框内有内容直接赋值于弹出框的图片地址文本框
                            //点击弹窗内”确定“按钮所执行的逻辑
                            clickFn: function (url, title, width, height, border, align) {
                                K('#txbimg').val(url);//获取图片地址
                                editor.hideDialog(); //隐藏弹窗
                            }
                        });
                    });
                });
            });
        }
    </script>

</head>
<body>
    <div class="header">
        <h2>编辑商家类型
        </h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="left" width="80">所属分类
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlproducttype" runat="server" CssClass="select"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txbtypename" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        <asp:HiddenField ID="hftypeid" runat="server" Value="0" />
                    </td>
                </tr>
                <tr>
                    <td align="left">图片
                    </td>
                    <td align="left">
                        <%=imgview %>
                        <div class="file-box">
                            <input type='text' name='txbimg' id='txbimg' class='textbox' style="width: 200px;" readonly="readonly" value='<%=img %>' />
                            <input type='button' id="image" class='btn' value='浏览...' />
                            建议尺寸:391*202px
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left">排序：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txborderby" runat="server" Width="50px" Text="99" onblur="setNumInput('txborderby')" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                        <asp:Button ID="btnreturn" runat="server" Text="返回" CssClass="button create" OnClick="btnreturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
