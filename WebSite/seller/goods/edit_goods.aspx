<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_goods.aspx.cs" Inherits="WebSite.seller.goods.edit_goods" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/jquery.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <script src="../js/Common.js"></script>
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../../kindeditor/kindeditor.js"></script>
    <script src="../../kindeditor/lang/zh_CN.js"></script>
    <link href="../../kindeditor/themes/default/default.css" rel="stylesheet" />
    <link href="../../js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="../../js/dialog/js/dialog.js"></script>

    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../js/My97DatePicker/skin/default/datepicker.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            tabs();
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
                    uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_goods(sellerid)%>',
                    fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_goods(sellerid)%>',
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

                //图片批量上传
                //var url_list = ""; // 保存所有图片路径
                //K('#J_selectImage').click(function () {
                //    editor.loadPlugin('multiimage', function () {
                //        editor.plugin.multiImageDialog({
                //            clickFn: function (urlList) {
                //                //var div = K('#J_imageView');
                //                //div.html('');
                //                K.each(urlList, function (i, data) {
                //                    //div.append('<img src="' + data.url + '">');
                //                    //url_list += data.url + ","; // 拼接链接
                //                    addphoto(data.url, "");
                //                });
                //                editor.hideDialog();
                //            }
                //        });
                //    });
                //});
                //end 图片批量上传
            });


            //初始化编辑器
            var editor = KindEditor.create('textarea[name="content"]', {
                width: '98%',
                height: '260px',
                resizeType: 1,
                allowFileManager: true,
                allowPreviewEmoticons: false,
                allowImageUpload: true,
                uploadJson: '/kindeditor/asp.net/upload_json.ashx?root=<%=Common.Constant.URL_goods(sellerid)%>',
                fileManagerJson: '/kindeditor/asp.net/file_manager_json.ashx?root=<%=Common.Constant.URL_goods(sellerid)%>',
            });

        }
    </script>
    <script>
        function save() {
            LoadDialog(); // 现实加载进度
            return true;
        }
        function success(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog();// 隐藏加载进度
            window.location.href = "goods.aspx";
        }
        function fail(info) {
            if (info != "") {
                alert(info);
            }
            RemoveLoadDialog();// 隐藏加载进度
        }
    </script>
</head>
<body>
    <div class="main">
        <div class="header">
            <h2>商品信息
            </h2>
        </div>
        <div class="header_height"></div>
        <div>
            <form id="form1" runat="server" enctype="multipart/form-data" target="hd">
                <div class="content-tab-wrap">
                    <div id="floatHead" class="content-tab">
                        <div class="content-tab-ul-wrap" id="tab_menu">
                            <ul>
                                <li><a href="javascript:;" class="selected">基本信息</a></li>
                                <li><a href="javascript:;">商品内容</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="tab_box">
                    <div class="tab-content">
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" class="formtable">
                            <tr>
                                <td align="left" width="120">商品名称：</td>
                                <td align="left">
                                    <asp:TextBox ID="txbGoodsName" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="left">商品类型：</td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGoodsType" runat="server" CssClass="select">
                                        <asp:ListItem Value="1">免费体验卷</asp:ListItem>
                                        <asp:ListItem Value="2">付费商品</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">商品类别：</td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlgoods_category" runat="server" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">图片：</td>
                                <td align="left">
                                    <%=imgview %>
                                    <div class="file-box">
                                        <input type='text' name='txbimg' id='txbimg' class='textbox' style="width: 200px;" readonly="readonly" value='<%=img %>' />
                                        <input type='button' id="image" class='btn' value='浏览...' />
                                        建议尺寸:400*200px
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">价格：</td>
                                <td align="left">
                                    <asp:TextBox ID="txbPrice" runat="server" Width="100px" CssClass="textbox" Text="0"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="left">描述：</td>
                                <td align="left">
                                    <asp:TextBox ID="txbDescription" runat="server" Width="500px" CssClass="textbox" TextMode="MultiLine" Style="width: 500px; height: 100px;"></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td align="left">兑换总数量：</td>
                                <td align="left">
                                    <asp:TextBox ID="txbTotalCount" runat="server" Width="100px" CssClass="textbox" Text="0"></asp:TextBox>
                                    0表示无限

                                </td>
                            </tr>
                            <tbody>
                                <tr>
                                    <td align="left">已经兑换的数量：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txbExchCount" runat="server" Width="100px" CssClass="textbox" Enabled="false" Text="0"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                            <%--<tr>
                        <td align="left">浏览数：</td>
                        <td align="left">
                            <asp:TextBox ID="txbViewCount" runat="server" Width="100px" CssClass="textbox" Enabled="false" Text="0"></asp:TextBox>

                        </td>
                    </tr>--%>
                            <tr>
                                <td align="left">上架：</td>
                                <td align="left">
                                    <asp:CheckBox ID="cbxStatus" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">每人限购数量：</td>
                                <td align="left">
                                    <asp:TextBox ID="txbPurchase" runat="server" Width="100px" CssClass="textbox" Text="0"></asp:TextBox>
                                    0为不限制
                                </td>
                            </tr>

                            <tr>
                                <td align="left">开始日期：</td>
                                <td align="left">
                                    <input id="StartDate" type="text" onclick="WdatePicker()" runat="server" class="textbox" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">结束日期：</td>
                                <td align="left">
                                    <input id="EndDate" type="text" onclick="WdatePicker()" runat="server" class="textbox" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tab-content" style="display: none;">
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" class="formtable">
                            <tr>
                                <td align="left">内容：</td>
                                <td align="left">
                                    <textarea id="content" name="content" rows="8"><%=content %></textarea>
                                    <br />
                                    限制3000字内
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <!--工具栏-->
                <div class="page-footer">
                    <div class="btn-list">
                        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" OnClientClick="return save()" />
                        <%--<input name="btnReturn" value="返回" class="btn yellow" onclick="history.go(-1);" type="button" />--%>
                    </div>
                    <div class="clear"></div>
                </div>
                <!--/工具栏-->


            </form>
            <iframe name="hd" style="display: none;"></iframe>
        </div>
    </div>
</body>
</html>
