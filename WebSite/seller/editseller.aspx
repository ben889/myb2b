<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editseller.aspx.cs" Inherits="WebSite.seller.editseller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑商家</title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <%--kindeditor--%>
    <script src="../kindeditor/kindeditor.js"></script>
    <script src="../kindeditor/lang/zh_CN.js"></script>
    <link href="../kindeditor/themes/default/default.css" rel="stylesheet" />
    <%--/kindeditor--%>
    <script type="text/javascript">
        //初始化kingeditor
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
                    allowImageUpload: true,
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_seller()%>',
                });
                //上传二维码
                K('#wxqrcodeimage').click(function () {
                    editor.loadPlugin('image', function () {
                        //图片弹窗的基本参数配置
                        editor.plugin.imageDialog({
                            imageUrl: K('#txbimg').val(), //如果图片路径框内有内容直接赋值于弹出框的图片地址文本框
                            //点击弹窗内”确定“按钮所执行的逻辑
                            clickFn: function (url, title, width, height, border, align) {
                                K('#wxqrcode').val(url);//获取图片地址
                                editor.hideDialog(); //隐藏弹窗
                            }
                        });
                    });
                });
                //上传背景图片
                K('#sellerimage').click(function () {
                    editor.loadPlugin('image', function () {
                        //图片弹窗的基本参数配置
                        editor.plugin.imageDialog({
                            imageUrl: K('#txbimg').val(), //如果图片路径框内有内容直接赋值于弹出框的图片地址文本框
                            //点击弹窗内”确定“按钮所执行的逻辑
                            clickFn: function (url, title, width, height, border, align) {
                                K('#txbsellerimg').val(url);//获取图片地址
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
    <div class="main">
    <div class="header">
        <h2>商家资料
        </h2>
    </div>
    <div class="header_height"></div>
    <div>
        <form id="form1" runat="server" action="editSeller.aspx" target="hd">
            <div>
                <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                    <tr>
                        <td align="left">名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txbname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                            &nbsp;<span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">类型：</td>
                        <td align="left">
                            <asp:TextBox ID="txbctype" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">经营范围：</td>
                        <td align="left">
                            <asp:TextBox ID="txbbusiness" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">电话：</td>
                        <td align="left">
                            <asp:TextBox ID="txbtel" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                            &nbsp;<span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">传真：</td>
                        <td align="left">
                            <asp:TextBox ID="txbfax" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">QQ：</td>
                        <td align="left">
                            <asp:TextBox ID="txbqq" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">微信：</td>
                        <td align="left">
                            <asp:TextBox ID="txbwx" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="left">微信二维码：</td>
                        <td align="left">
                            <%=wxqrcodeimgview %>
                            <div class="file-box">
                                <input type='text' name='wxqrcode' id='wxqrcode' class='textbox' style="width: 200px;" readonly="readonly" value='<%=wxqrcode %>' />
                                <input type='button' id="wxqrcodeimage" class='btn' value='浏览...' />
                                建议尺寸:
                            </div>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="left">商家背景图片：</td>
                        <td align="left">
                            <%=sellerimgview %>
                            <div class="file-box">
                                <input type='text' name='txbsellerimg' id='txbsellerimg' class='textbox' style="width: 300px;" readonly="readonly" value='<%=sellerimg %>' />
                                <input type='button' id="sellerimage" class='btn' value='浏览...' />
                                建议尺寸:360*160px 
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">地址：</td>
                        <td align="left">
                            <asp:TextBox ID="txbAddress" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">描述：</td>
                        <td align="left">
                            <asp:TextBox ID="txbDescription" runat="server" Width="600px" Height="100px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
    <iframe name="hd" style="display: none;"></iframe>
        </div>
</body>
</html>
