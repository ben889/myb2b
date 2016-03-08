<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebSite.mobile.goods.cart" %>


<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title></title>
    <link href="../css/all.css" rel="stylesheet" />
    
    <link href="../css/goods.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <link href="../../js/dialog/css/dialog.css" rel="stylesheet" />
    <script src="../../js/dialog/js/dialog.js"></script>
    <script>

        $(document).ready(function () {
            count();
        });
        function updatenumber(ac) {
            var number = parseInt($("#number").val(), 0);
            if (ac == 1) {
                number++;
            }
            else {
                number--;
            }
            if (number < 1)
                number = 1;
            $("#number").val(number);
            count();
        }
    </script>
    <script>
        //提交
        function tijiao()
        {
            LoadDialog("提交中..");
            //document.getElementById("cartsubmit").onclick;
            $("#abtn_save").attr("onclick","");
            var num = $("#number").val();
            var sum = $("#total_price").html();
            $.ajax({
                type: "post",
                url: "cart.aspx",
                data: {ajaxmethod:"addcart",id:<%=id%>,number:num,total_price:sum},
                async: false,
                dataType: "json",
                success: function (data) {
                    //alert(data);
                    $("#abtn_save").attr("onclick","tijiao();");
                    RemoveLoadDialog();
                    if(data.result>0)
                        window.location.href = "goodsStuff.aspx";
                    else{
                        alert(data.msg);
                    }
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    alert("提交失败！" + textStatus);
                    RemoveLoadDialog();
                    $("#abtn_save").attr("onclick","tijiao();");
                }
            });
        }
        

    </script>
    <script>
        function count()
        {
            var price=<%=price%>;
            var number = parseInt($("#number").val(), 0);
            
            var total_price=price*number;
            $("#total_price").html(total_price);
        }
    </script>
</head>
<body class="m-detail-body">
    <uc1:header ID="header1" runat="server" />
    <script>
        settitle("提交订单");
    </script>
    <form  method="post" id="form1" name="form1"  class="am-form">
        <div class="m-detail-con" style="padding: 10px 0;">
            <div class="s-item">
                <div class="sitem-l"><%=name %></div>
                <div class="sitem-r"><%=price %> 元</div>
                <div style="clear: both;"></div>
            </div>
            <div class="m-detail-com-hr"></div>
            <div class="s-item" style="">
                <div class="sitem-l">数量</div>
                <div class="sitem-r">
                    <div>
                        <div style="float: left; width: 25px; height: 25px; line-height:23px; border-radius: 3px; background-color: #f90; text-align: center;" onclick="updatenumber(1);"><span style="color: #fff;" >+</span></div>
                        <div style="float: left;text-align: center;">
                            <input id="number" name="number" type="text" value="1" style="width: 40px; border: 0; height: 25px; line-height: 25px; text-align: center;" />
                        </div>
                        <div style="float: left; width: 25px; height: 25px;line-height:23px; border-radius: 3px; background-color: #f90; text-align: center;" onclick="updatenumber(0);"><span style="color: #fff;" >-</span></div>
                        <div style="clear: none;"></div>
                    </div>
                </div>
                <div style="clear: both;"></div>
            </div>
            <div class="m-detail-com-hr"></div>
            <div class="s-item">
                <div class="sitem-l">小计</div>
                <div class="sitem-r"><span id="total_price">0</span> 元</div>
                <div style="clear: both;"></div>
            </div>
        </div>
        <%--<div class="m-detail-con m-detail-con-margin" style="padding: 10px 0;">

        <div class="s-item">
            <div class="sitem-l">抵用卷</div>
            <div class="sitem-r">使用抵用卷</div>
            <div style="clear: both;"></div>
        </div>
        <div class="m-detail-com-hr"></div>
        <div class="s-item">
            <div class="sitem-l">使用积分</div>
            <div class="sitem-r">现有积分40</div>
            <div style="clear: both;"></div>
        </div>
        <div class="m-detail-com-hr"></div>
        <div class="s-item">
            <div class="sitem-l">总价</div>
            <div class="sitem-r">(共一张)9.9</div>
            <div style="clear: both;"></div>
        </div>

    </div>--%>

        <%--<div style="height: 30px; line-height: 30px; margin-left: 18px;">绑定你的手机号码</div>
    <div class="m-detail-con m-detail-con-margin" style="padding: 10px 0;">

        <div class="s-item">
            <div class="sitem-l">绑定手机</div>
            <div class="sitem-r">绑定手机新号</div>
            <div style="clear: both;"></div>
        </div>

    </div>--%>
        <div style="padding:8px 8px;">
            <a href="javascript:void(0);" id="abtn_save" class="m-btn btn_green" onclick="tijiao()" style="background-color:#339900;">提交</a>
        </div>
        <input type="submit" id="cartsubmit" style="display:none;" />
    </form>

</body>
</html>
