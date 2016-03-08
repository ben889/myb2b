<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weipay.aspx.cs" Inherits="WebSite.mobile.weixinpay.weipay" %>

<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title>微信安全支付</title>
    <script src="../../js/jquery.min.js"></script>
    <link href="../css/all.css" rel="stylesheet" />
    <%--弹窗--%>
    <script src="../../js/dialog/js/dialog.js"></script>
    <link href="../../js/dialog/css/dialog.css" rel="stylesheet" />
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <script>
        settitle("微信安全支付");
        $(".h_btn_rg").hide();
    </script>
    <div class="header-height"></div>
    <div class="m-detail-con" style="padding: 10px;">
        <form id="form1" runat="server">
            <table width="100%" cellspacing="1" cellpadding="2" border="0">
                <tr>
                    <td width="80">订单号：</td>
                    <td>
                        <asp:Label ID="lblOrderSN" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>支付金额：</td>
                    <td>
                        <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>商品描述：</td>
                    <td>
                        <asp:Label ID="lblBody" runat="server" Text=""></asp:Label></td>
                </tr>
                <tbody style="display: none;">
                    <tr>
                        <td>自定义参数：</td>
                        <td>
                            <asp:Label ID="lblAttach" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>notify：</td>
                        <td>
                            <%=domain + WeiPay.PayConfig.NotifyUrl %>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">OpenId：<%=UserOpenId %><br />
                            appId:<%=appid %>
                            <br />
                            时间戳:<%= TimeStamp %>
                            <br />
                            随机串:<%= NonceStr %>
                            <br />
                            扩展包:<%= Package %>
                            <br />
                            微信签名:<%= PaySign %>
                        </td>
                    </tr>

                </tbody>
            </table>
            <div style="margin: 10px 2px;">
                <input type="button" value="确认支付" id="getBrandWCPayRequest" onclick="SavePay()" class="btn" style="width: 100%;" /></div>
            <%--    <div class="WCPay">
    <h1 class="title"  id="getBrandWCPayRequest" onclick="SavePay()" >提交</h1>
    
<a id="getBrandWCPayRequest" href="javascript:void(0);">
            <h1 class="title" onclick="">点击提交可体验微信支付</h1>
        </a>

    </div>--%>
        </form>

    </div>
    <script type="text/javascript">

        function SavePay() {
            if (is_weixn()) {
                WeixinJSBridge.invoke('getBrandWCPayRequest', {
                    "appId": "<%=appid %>", //公众号名称，由商户传入
                    "timeStamp": "<%= TimeStamp %>", //时间戳
                    "nonceStr": "<%= NonceStr %>", //随机串
                    "package": "<%= Package %>", //扩展包
                    "signType": "MD5", //微信签名方式:1.sha1
                    "paySign": "<%= PaySign %>" //微信签名
                },
                function (res) {
                    if (res.err_msg == "get_brand_wcpay_request:ok") {
                        alert("微信支付成功!");
                        //location.href = "../member/index.aspx";
                        location.href = "../recharge_result.aspx?result=success";
                    } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                        alert("用户取消支付!");
                    } else {
                        alert(res.err_msg);
                        alert("支付失败!");
                    }
                    // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                    //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
                });
            }
            else {
                pop_alert("提示", "不是微信默认浏览器，无法完成支付", "确定");
            }
        }

        function is_weixn() {
            var ua = navigator.userAgent.toLowerCase();
            if (ua.match(/MicroMessenger/i) == "micromessenger") {
                return true;
            } else {
                return false;
            }
        }

    </script>
</body>
</html>
