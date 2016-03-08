<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goods_submitorder.aspx.cs" Inherits="WebSite.mobile.goods.goods_submitorder" %>

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
    <title>提交订单</title>
    <link href="../css/all.css" rel="stylesheet" />
    <link href="../css/goods.css" rel="stylesheet" />
    
</head>
<body style="background-color: #f2f0f0;">
    <uc1:header runat="server" ID="header" />
    <script>
        initheader("提交订单", "", "","");
        $(function () {
            $("#moneysum").html(parseInt($(".inputcount").val()) * parseFloat($("#unitprice").html()));
        });
        function count(sign) {
            var countext = parseInt($(".inputcount").val());
            var unitprice = parseFloat($("#unitprice").html());
            if (sign == "+") {
                $(".inputcount").val((parseInt(countext) + 1));
                $("#moneysum").html((unitprice * (countext + 1)));
            }
            else {
                if ((parseInt(countext) > 1)) {
                    $(".inputcount").val((parseInt(countext) - 1));
                    $("#moneysum").html((unitprice * (countext - 1)));
                }
            }
        }

        var bo = true;
        function tijiao() {
            $("#h_moneysum").val($("#moneysum").html());
            $("#selectname").val("tijiaodata");
            if (bo)
                bo = false;
            else
                return false;
            return true;
        }
        function successful(orderid)
        {
            window.location.href = "goods_payway.aspx?orderid=" + orderid;
        }
        function successful2(orderid) {
            window.location.href = "goodsStuff.aspx";
        }
        function fail(info)
        {
            alert(info);
        }
    </script>
    <form id="form1" action="goods_submitorder.aspx" onsubmit="return tijiao()"  target="if1" method="post">
    <div style="width: 100%; height: auto;">
        <div class="li">
            <ul>
                <li class="index-li-first" style="box-sizing:border-box;padding-left:10px;">
                    <img src="<%=gi.Img %>" style="width:100%; height:110px; vertical-align: middle;box-sizing:border-box;padding:1px;border:1px solid #ffebe3; border-radius:2px;" />
                </li>
                <li class="index-li-second">
                    <ul>
                        <li style="line-height: 55px;"><strong style="font-size: 16px; color: #808080;"><%=gi.GoodsName %></strong>
                            <span style="float: right; color: #808080;"><500M</span>
                        </li>
                        <li style="line-height: initial; height: 54px;"><span style="color: #808080;"><%=gi.Description %></span></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>

    <div class="goods_functiondiv">
        <div style="border-bottom: #dedede;">
            <div><span style="color: #808080;">单价：</span></div>
            <div><span style="color: #ff4401; float: right;">元</span><span id="unitprice" style="color: #ff4401; float: right;"><%=gi.Price %></span></div>
        </div>
        <div class="hrgray"></div>
        <div style="border-bottom: #dedede;">
            <div ><span style="color: #808080;">数量：</span></div>
            <div >
                <div style="color: #ff4401; display: inline-block; line-height: 80px;  min-width:110px; float: right; ">
                    <img src="../images/yellowjia.png" style="width: 32px;" onclick="count('-')" />
                    <input type="text" class="inputcount" id="inputcount" name="inputcount" style="width: 30px; text-align: center;" value="1" />
                    <img src="../images/yellowjian.png" style="width: 32px;" onclick="count('+')" />
                </div>
            </div>
        </div>
        <div class="hrgray"></div>
        <div style="border-bottom: #dedede;">
            <div><span style="color: #808080;">金额：</span></div>
            <div><span style="color: #ff4401; float: right;">元</span><span id="moneysum" style="color: #ff4401; float: right;"></span></div>
        </div>
        <div class="hrgray"></div>
        <div style="border-bottom: #dedede;">
            <div style="width:100%;"><span style="color: #808080;">您的手机号码：<%=base.mobile %></span></div>
        </div>
        <div class="hrgray"></div>
    </div>
    
        <input type="hidden" id="h_moneysum" name="h_moneysum" value="" />
        <input type="hidden" id="selectname" name="selectname" value="" />
        <input type="hidden" id="hidoosid" name="hidoosid" value="<%=goodsid %>" />
        <input type="submit" onclick="" class="mybutton" value="提交" style=""/>
    </form>
    <iframe id="if1" name="if1" style="display:none;"></iframe>
    <div style="width: 100%; height: 30px;"></div>
</body>
</html>
