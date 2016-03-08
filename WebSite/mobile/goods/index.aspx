<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSite.mobile.goods.index" %>
<%@ Register Src="../common/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../common/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=1, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon.png" />
    <link rel="apple-touch-startup-image" href="images/apple-touch-startup-image.png" />
    <meta name="author" content="FamousThemes" />
    <title><%=base.site_title %></title>
    <link rel="stylesheet" href="../css/all.css" type="text/css" media="screen" />
    <link href="../css/goods.css" rel="stylesheet" />
    <link href="/css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script language="javascript" src="../js/jquery.min.js"></script>
    <script language="javascript" src="../js/transport_mobile.js"></script>
    <script type="text/javascript" src="../js/touchScroll.min.js"></script>
    <script type="text/javascript" src="../js/touchslider.dev.min.js"></script>
    <script type="text/javascript" src="../js/banner.js"></script>
    <script>
        $(function () {
            settitle("O2O");
        });
    </script>
</head>
<body>
    <uc1:header ID="header_mall1" runat="server" />
    <div id="banner" class="checks banner" style="height: 200px; overflow: hidden; padding: 0px!important;">
        <div class="ban_list" style="margin: 0px !important;">
            <dl id="silder">
                <%System.Data.DataTable addt = BLL.AdBLL.GetDt("index_hdp");
                  if (addt != null)
                  {
                      foreach (System.Data.DataRow dow in addt.Rows)
                      {
                %>
                <dd><a href="<%=dow["adlink"].ToString() %>" title="" data-ajax="false">
                    <img src="<%=dow["adimg"].ToString() %>"></a></dd>
                <%}
                  } %>
                <%--<dd><a href="http://www.51ujf.cn/mobile/shop.php?id=10" title="1" data-ajax="false">
                    <img src="images/20140414wtivmp.jpg"></a></dd>
                <dd><a href="http://www.51ujf.cn/mobile/shop.php?id=112" title="2" data-ajax="false">
                    <img src="images/20140716dpcldd.jpg"></a></dd>
                <dd><a href="http://www.51ujf.cn/mobile/shop.php?id=116" title="3" data-ajax="false">
                    <img src="images/20140716todjsm.jpg"></a></dd>
                <dd><a href="http://www.51ujf.cn/mobile/shop.php?id=78" title="4" data-ajax="false">
                    <img src="images/20140415kyfdpo.jpg"></a></dd>
                <dd><a href="http://www.51ujf.cn/mobile/shop.php?id=10" title="5" data-ajax="false">
                    <img src="images/20140414umjfmx.jpg"></a></dd>--%>
            </dl>
        </div>
    </div>

    <%--<div class="nav-cens" style="clear: both;">
        <div class="nav-cen">
            <div style="margin: 6px auto; text-align: center; padding: 10px;">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" valign="top" class="li_border_rightbottom">
                            <div style="position: relative;" onclick="location.href='member/message.aspx?category=0'">
                                <a href="member/message.aspx?category=0" data-ajax="false">
                                    <img src="images/sms.png" width="40"></a>
                                <p><a href="member/message.aspx?category=0" data-ajax="false">代理商公告</a></p>
                                <span id="sms_count"></span>
                            </div>
                        </td>
                        <td align="center" valign="top" class="li_border_rightbottom">
                            <div>
                                <a href="fastdelivery.aspx?gg=mp.weixin.qq.com" data-ajax="false">
                                    <img width="40" src="images/kj_05.png"></a>
                                <p><a href="fastdelivery.aspx?gg=mp.weixin.qq.com" data-ajax="false">便民服务</a></p>
                            </div>
                        </td>
                        <td align="center" valign="top" class="li_border_rightbottom">
                            <div>
                                <a href="member/repair.aspx" data-ajax="false">
                                    <img width="40" src="images/kj_07.png"></a>
                                <p><a href="member/repair.aspx" data-ajax="false">维修服务</a></p>
                            </div>
                        </td>
                        <td align="center" valign="top" class="li_border_bottom">
                            <div>
                                <a href="member/complaints.aspx" data-ajax="false">
                                    <img width="40" src="images/kj_09.png"></a>
                                <p><a href="member/complaints.aspx" data-ajax="false">代理商投诉</a></p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" class="li_border_right">
                            <div>
                                <a href="member/feedback.aspx" data-ajax="false">
                                    <img width="40" src="images/kj_04.png"></a>
                                <p><a href="member/feedback.aspx" data-ajax="false">意见反馈</a></p>
                            </div>
                        </td>
                        <td width="25%" align="center" valign="top" class="li_border_right">
                            <div>
                                <a href="mall/index.aspx" data-ajax="false">
                                    <img width="40" src="images/kj_06.png"></a>
                                <p><a href="mall/index.aspx" data-ajax="false">生活娱乐</a></p>
                            </div>
                        </td>
                        <td align="center" valign="top" class="li_border_right">
                            <div>
                                <a href="/mobile/goods/goods.aspx" data-ajax="false">
                                    <img width="40" src="images/ljb.png"></a>
                                <p><a href="/mobile/goods/goods.aspx" data-ajax="false">抵用券</a></p>
                            </div>
                        </td>

                        <td align="center" valign="top" class="li_border_none">
                            <div>
                                <a href="zone/index.aspx" data-ajax="false">
                                    <img width="40" src="images/friend.png"></a>
                                <p><a href="zone/index.aspx" data-ajax="false">邻居圈</a></p>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>--%>
    <div class="row_hr"></div>
    <%--广告位--%>
    <div class="row_con">
        <div class="index_ad">
            <%System.Data.DataTable addt1 = BLL.AdBLL.GetDt("index_ad1"); 
          if (addt1!=null && addt1.Rows.Count>0){
              System.Data.DataRow dr1=addt1.Rows[0];
              %>
            <a style="height: 160px;" href="<%=dr1["adlink"] %>">
                <div class="section" style="height: 154px;">
                    <img src="<%=dr1["adimg"] %>" />
                </div>
            </a>
            <%}%>
            <%System.Data.DataTable addt2 = BLL.AdBLL.GetDt("index_ad2");
              if (addt2 != null && addt2.Rows.Count > 0)
              {
                  for (int i = 0; i < addt2.Rows.Count; i++)
                  {
                      string link = addt2.Rows[i]["adlink"] != DBNull.Value ? addt2.Rows[i]["adlink"].ToString() : "javascript:void(0);";
            %>
            <a style="height: 80px;" href="<%=link %>">
                <div class="section" style="height: 74px;">
                    <img src="<%=addt2.Rows[i]["adimg"] %>" style="width: 100%;" />
                </div>
            </a>
            <%}
              }%>
            <div style="clear: both;"></div>
        </div>
    </div>
    <%--end广告位--%>
    <div class="row_hr"></div>
    <div class="content clear mtop">


        <%--热门商品--%>
        <div class="row_con">
            <div class="index_tts">热门商品<span class="more"><a href="mall/orders.aspx" class="b">更多></a></span> </div>
            <div class="thelist clear">
                <ul>
                    <%List<Model.goodsInfo> productsSP = BLL.goodsBLL.GetList(2, "1=1", " GoodsId desc"); %>
                    <%foreach (Model.goodsInfo info in productsSP)
                      { %>
                    <li><%--if (json[i].name.length > 12)
                json[i].name = json[i].name.substring(0, 12) + "...";
            if (json[i].abstracts.length > 40)
                json[i].abstracts = json[i].abstracts.substring(0, 40) + "...";--%>
                        <a href="goods/goodsdetail.aspx?id=<%=info.GoodsId %>" data-ajax="false">
                            <div class="thelist-img">
                                <img src="<%=info.Img %>" width="100%" height="90">
                            </div>
                            <div class="thelist-msg">
                                <p class="t_01"><%= info.GoodsName.Length>12?info.GoodsName.Substring(0,12)+"...":info.GoodsName %></p>
                                <p class="t_02">￥<%=info.Price %></p>
                                <p class="t_02"><%=info.Description.Length>16?info.Description.Substring(0,16)+"...":info.Description %></p>
                            </div>
                        </a>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
        <%--end热门商品--%>
        <div class="row_hr"></div>
        <%--热门商家--%>
        <div class="row_con">
            <div class="index_tts">热门商家<span class="more"><a href="mall/sellers.aspx" class="b">更多></a></span> </div>
            <div class="thelist clear">
                <ul>
                    <%List<Model.SellerInfo> products1 = BLL.SellerBLL.GetList(3, "recommend =1  and islock <> 1 ", "  orderby asc,sellerid desc"); %>
                    <%foreach (Model.SellerInfo info in products1)
                      { %>
                    <li>
                        <a href="mall/sellerdetail.aspx?sellerid=<%=info.sellerid %>">
                            <div class="thelist-img">
                                <img src="<%=info.sellerimg %>" width="100" height="90">
                            </div>
                            <div class="thelist-msg">
                                <p class="t_01"><%= info.name.Length>12?info.name.Substring(0,12)+"...":info.name %></p>
                                <p class="t_02">类型：<%=info.ctype.Length>40?info.ctype.Substring(0,40)+"...":info.ctype %></p>
                                <p class="t_02">电话：<%=info.tel %></p>
                                <p class="t_02">地址：<%=info.address.Length>16?info.address.Substring(0,16)+"...":info.address %></p>
                            </div>
                        </a>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
        <%--end热门商家--%>
    </div>
    <div style="height:50px;"></div>
    <footer class="shadow-footer" id="footer">
        <uc2:footer ID="footer1" runat="server" />
    </footer>
</body>
</html>
