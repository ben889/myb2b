<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodsdetail.aspx.cs" Inherits="WebSite.mobile.goods.goodsdetail" %>

<%@ Register Src="/mobile/common/header.ascx" TagName="header" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title><%=name %></title>
    <link href="../css/all.css" rel="stylesheet" />
    <link href="../css/goods.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <style>
        #mcover {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,0.7);
            display: none;
            z-index: 20000;
        }

            #mcover img {
                position: fixed;
                right: 18px;
                top: 5px;
                width: 260px!important;
                height: 180px!important;
                z-index: 20001;
            }
            #prd pre{
            white-space:inherit;
        }
        #prd img{
              max-width:100%;
              min-width:100%;
              word-break:break-all;
        }
    </style>
</head>
<body class="m-detail-body">
    <uc1:header ID="header1" runat="server" />
    <script>
        back("", "/mobile/goods/goods.aspx");
        settitle("<%=name %>");
    </script>
    <div id="productimg" class="productimg">
        <img src="<%=info.Img %>" style="width: 100%;" />
        <div class="productimg-desc"><%=name %></div>
    </div>
    <div id="content" class="m-detail-con" style="position: relative;">
        <div class="m-detail-price">
            <strong><%=info.Price %>元</strong>
        </div>
        <a href="goods_submitorder.aspx?id=<%=id %>" class="m-buy-btn" id="add-cart">立即抢购</a>
    </div>
    <div class="m-detail-con m-detail-con-margin m-abstracts">
        <h1><%=name %></h1>
        <p><%=info.Description %></p>
        <div class="m-share" onclick="document.getElementById('mcover').style.display='block';">
            <a href="javascript:;"><i class="fa fa-share-alt"></i>分享</a>
        </div>
    </div>
    <%--商家信息--%>
    <div id="sellerinfo" class="m-detail-con m-detail-con-margin m-seller-message">
        <h3>商家信息</h3>
        <div class="m-seller-ta">
            <div class="m-seller-con">
                <a href="../mall/sellerdetail.aspx?sellerid=<%=sInfo.sellerid %>">
                    <h1><%=sInfo.name %><span style="font-size: 12px; margin-left: 8px; color: #333333;">(点击进入商家)</span></h1>
                </a>
                <p><i class="fa fa-map-marker" style="font-size: 15px;"></i> <%=sInfo.address %></p>
            </div>
            <div class="m-seller-phone"><a href="tel:"><i class="fa fa-phone" style="font-size: 47px; line-height: 68px; color: #2BB2A3;"></i></a></div>
            <div style="clear: both;"></div>
        </div>
    </div>
    <%--产品描述--%>
    <div id="ss" class="m-detail-con m-detail-con-margin m-seller-desc">
        <h3>商品内容</h3>
        <div class="m-seller-desc-con">
            <div id="prd" style="margin: 10px 18px; font-size: 14px; color: #333333; text-align:justify;">
                <%=info.Content %>
            </div>
        </div>
    </div>
    <div style="height:60px;"></div>
    <%--分享遮罩层--%>
    <div id="mcover" onclick="document.getElementById('mcover').style.display='';" style="display: none;">
        <img src="../images/guide.png"/>
    </div>
</body>
</html>
