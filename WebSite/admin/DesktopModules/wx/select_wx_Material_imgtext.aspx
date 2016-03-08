<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_wx_Material_imgtext.aspx.cs" Inherits="WebSite.admin.DesktopModules.wx.select_wx_Material_imgtext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../amazeui/assets/css/amazeui.min.css" rel="stylesheet" />
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/wx.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script>
        var mid;
        function select_item(id) {
            $(".appmsg_col").children().removeClass("selected");
            $("#appmsg_item_" + id).addClass("selected");
            mid = id;
        }
        function confirm_selected() {
            parent.selected_appmsg(mid);
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        }
    </script>
</head>
<body>

    <div>
        <%if (list != null && list.Count > 0)
          { %>
        <%foreach (Model.wx_MaterialInfo info in list)
          { %>
        <div class="appmsg_col">
            <div class="appmsg" id="appmsg_item_<%=info.wx_MaterialID %>" onclick="select_item('<%=info.wx_MaterialID %>');">
                <div class="appmsg_content">
                    <div class="appmsg_info">
                        <em class="appmsg_date"><%=info.Name %></em>
                    </div>
                    <div class="cover_appmsg_item">
                        <h4 class="appmsg_title js_title"><a><%=info.Name %></a></h4>
                        <div class="appmsg_thumb_wrp">
                            <img src="<%=info.ImgUrl %>" alt="" class="appmsg_thumb" />
                        </div>
                    </div>
                    <% List<Model.wx_MaterialInfo> list2 = BLL.wx_MaterialBLL.GetList(-1, "parentid=" + info.wx_MaterialID, "CreateTime asc"); %>
                    <%if (list2 != null && list2.Count > 0)
                      { %>
                    <%foreach (Model.wx_MaterialInfo info2 in list2)
                      { %>
                    <div class="appmsg_item">
                        <img src="<%=info2.ImgUrl %>" alt="" class="appmsg_thumb" />
                        <h4 class="appmsg_title js_title"><a><%=info2.Name %></a></h4>
                    </div>
                    <%} %>
                    <%} %>
                </div>
                <div class="appmsg_mask"></div>
                <i class="icon_card_selected">已选择</i>
            </div>
        </div>
        <%} %>
        <%} %>
        <div style="clear: both;"></div>
    </div>
    <div style="height:60px;"></div>
    <div class="page-footer">
        <div class="btn-list" style="padding: 10px; text-align:center;">
            <button type="button" class="am-btn am-btn-primary" onclick="confirm_selected();">&nbsp;&nbsp;确定&nbsp;&nbsp;</button>
        </div>
    </div>
</body>
</html>
