$(document).ready(function () {
    w_tabs();
    //bind_w_tabs(0);
    ajax_appmsg();
});

function bind_w_tabs(index) {
    $("#reftype").val("1");
    if (index == 1)
        $("#reftype").val("3"); //1是文本，3是图文
    select_tabs(index);
}

 function w_tabs() {
    var $div_li = $(".media_type_list li");
    $div_li.click(function () {
        var div_index = $div_li.index(this);
        bind_w_tabs(div_index);
    });
}

function select_tabs(index) {
    //alert(index);
    $(".media_type_list li").removeClass("selected");
    $(".media_type_list li").eq(index).addClass("selected");
    $(".media_type_box>div").hide();
    $(".media_type_box>div").eq(index).show();


}

//类型： 1文字，2图片，3图文，4音频，5视频
function select_material(responsetype) {
    var url = "";
    if (responsetype == 3)
        url = "/admin/DesktopModules/wx/select_wx_Material_imgtext.aspx";
    layer.open({
        type: 2,
        title: '选择',
        shadeClose: true,
        shade: 0.8,
        area: ['80%', '84%'],
        content: url //iframe的url
    });
    return false;
}



///==================选择后绑定
//绑定选择的图文
function selected_appmsg(refid) {
    $("#refid").val(refid);
    ajax_appmsg();
}
function ajax_appmsg() {
    var _refid = $("#refid").val();
    //alert(_refid);
    var ajaxdata = { ajaxmethod: "getjson_appmsg", refid: _refid };
    $.ajax({
        type: "post",
        url: "/admin/DesktopModules/wx/edit_wx_ReplyMesage.aspx",
        dataType: "json",
        data: ajaxdata,
        beforeSend: function () {
        },
        success: function (results) {
            addrows_appmsg(results);
        },
        error: function () {
        }
    });
}
function addrows_appmsg(json) {
    if (json.length > 0) {
        var results = "<div class=\"appmsg\"><div class=\"appmsg_content\">";
        for (var i = 0; i < json.length; i++) {
            if (i == 0) {
                results += "<div class=\"appmsg_info\"><em class=\"appmsg_date\">" + json[i].name + "</em></div>";
                results += "<div class=\"cover_appmsg_item\">" +
                            "<h4 class=\"appmsg_title js_title\"><a>" + json[i].name + "</a></h4>" +
                            "<div class=\"appmsg_thumb_wrp\">" +
                                "<img src=\"" + json[i].img + "\" alt=\"\" class=\"appmsg_thumb\" />" +
                            "</div>" +
                        "</div>";
            } else {
                results += "<div class=\"appmsg_item\">" +
                            "<img src=\"" + json[i].img + "\" alt=\"\" class=\"appmsg_thumb\" />" +
                            "<h4 class=\"appmsg_title js_title\"><a>" + json[i].name + "</a></h4>" +
                        "</div>";
            }
        }
        results += "</div></div>";
        $("#appmsg_list").html(results);
    }
}