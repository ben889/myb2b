<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_payway.aspx.cs" Inherits="WebSite.mobile.goods.goods_payway" %>

<%@ Register Src="~/mobile/common/header.ascx" TagPrefix="uc1" TagName="header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title></title>
    <link href="goods.css" rel="stylesheet" />
</head>
<body>
    <uc1:header runat="server" ID="header" />
    <script>
        initheader("支付订单", "", "");
        function aaa(name,thiss) {
            $("#hiddenradio").val(name);
            $("img[src='../images/isyes.png']").attr("src",'../images/isno.png');
            $(thiss).attr("src", '../images/isyes.png');
        }
        function tijiao()
        {
            //提交处理
            var payname = $("#hiddenradio").val();
            switch (payname)
            {
                case "微信": wx_pay("<%=go.orderno%>", "<%=go.pay_price %>","<%=base.uid%>"); break;
            }
            
        }
    </script>
    
    <script>
        function wx_pay(orderno, total_price, uid) {
            location.href = "/mobile/weixinpay/send.aspx?orderno=" + orderno + "&price=" + total_price + "&model=goods&uid=" + uid;
        }
    </script>
    <div class="goods_functiondiv">
        <input  type="hidden" id="hiddenradio" name="hiddenradio" value="微信"/>
        <div style="border-bottom: #dedede;height: 90px;margin-top:6px;width: 100%;">
            <div style="margin-top:10px;width: 100%;">
                <p><span style="margin-left:10px; font-weight:bold;">订单名称：<%=goods.GoodsName %></span></p> 
                <p><span style="margin-left:10px;font-weight:bold;">订单金额：<%=go.totalprice %>元</span></p>
            </div>
        </div>
        
        <div style="border-bottom: #dedede; margin-top:5px;width: 100%;">
            <div style="width: 100%;" ><span style="color: #ff4401; font-weight:bold;">支付金额：<%=go.pay_price %>元</span></div>
        </div>
        <div class="hrgray"></div>
        <div style="border-bottom: #dedede;">
            <div><span style="color: #808080;">微信支付：</span></div>
            <div style="text-align:right;">
                <img src="../images/isyes.png" style="color: #ff4401;margin-top:28px;width:22px; " onclick="aaa('微信',this)"/>
            </div>
        </div>
        <%--<div class="hrgray"></div>
        <div style="border-bottom: #dedede;">
            <div><span style="color: #808080;">支付宝支付：</span></div>
            <div style="text-align:right;">
                <img src="../images/isno.png" style="color: #ff4401;margin-top:28px;width:22px; "  onclick="aaa('支付宝',this)"/>
            </div>
        </div>
        <div class="hrgray"></div>

        <div style="border-bottom: #dedede;">
            <div><span style="color: #808080;">已绑定银行卡：</span></div>
            <div style="text-align:right;">
                <img src="../images/isno.png" style="color: #ff4401;margin-top:28px;width:22px; " onclick="aaa('银行卡',this)"/>
            </div>
        </div>--%>
        <div class="hrgray"></div>
    </div>
    <button    class="mybutton" onclick="tijiao()" >确认支付</button>
    <div style="width: 100%; height: 30px;"></div>
</body>
</html>
