function am_modal(conent) {
    $("#my-modal").remove();
    var html = new Array();
    html.push("<div class=\"am-modal am-modal-no-btn\" tabindex=\"-1\" id=\"my-modal\">");
    html.push("<div class=\"am-modal-dialog\">");
    html.push("<div class=\"am-modal-hd\">&nbsp;<a href=\"javascript: void(0)\" class=\"am-close am-close-spin\" data-am-modal-close>&times;</a></div>");
    html.push("<div class=\"am-modal-bd\">");
    html.push(conent);
    html.push("</div>");
    html.push("</div>");
    html.push("</div>");
    $("body").append(html.join(""));
    $('#my-modal').modal();
}
function am_alert(conent, btn) {
    $("#my-alert").remove();
    var html = new Array();
    html.push("<div class=\"am-modal am-modal-alert\" tabindex=\"-1\" id=\"my-alert\">");
    html.push("<div class=\"am-modal-dialog\">");
    html.push("<div class=\"am-modal-hd\"></div>");
    html.push("<div class=\"am-modal-bd\">");
    html.push(conent);
    html.push("</div>");
    html.push("<div class=\"am-modal-footer\">");
    html.push("<span class=\"am-modal-btn\">" + btn + "</span>");
    html.push("</div>");
    html.push("</div>");
    html.push("</div>");
    $("body").append(html.join(""));
    $('#my-alert').modal({
        relatedTarget: this
    });
}
function am_confirm(conent, ok_btn, cancel_btn, ok_fun) {
    $("#my-confirm").remove();
    var html = new Array();
    html.push("<div class=\"am-modal am-modal-confirm\" tabindex=\"-1\" id=\"my-confirm\">");
    html.push("<div class=\"am-modal-dialog\">");
    html.push("<div class=\"am-modal-hd\"></div>");
    html.push("<div class=\"am-modal-bd\">");
    html.push(conent);
    html.push("</div>");
    html.push("<div class=\"am-modal-footer\">");
    html.push("<span class=\"am-modal-btn\" data-am-modal-cancel>" + cancel_btn + "</span> <span class=\"am-modal-btn\" data-am-modal-confirm>" + ok_btn + "</span>");
    html.push("</div>");
    html.push("</div>");
    html.push("</div>");
    $("body").append(html.join(""));
    $('#my-confirm').modal({
        relatedTarget: this,
        onConfirm: function (options) {
            ok_fun();
        },
        // closeOnConfirm: false,
        onCancel: function () {
            //location.href = "";
        }
    });
}

///////////////////加载中...
function am_loadding(conent) {
    $("#my-modal-loading").remove();
    var html = new Array();
    html.push("<div class=\"am-modal am-modal-loading am-modal-no-btn\" tabindex=\"-1\" id=\"my-modal-loading\">");
    html.push("<div class=\"am-modal-dialog\">");
    html.push("<div class=\"am-modal-hd\">" + conent + "</div>");
    html.push("<div class=\"am-modal-bd\">");
    html.push("<span class=\"am-icon-spinner am-icon-spin\"></span>");
    html.push("</div>");
    html.push("</div>");
    html.push("</div>");
    $("body").append(html.join(""));
    $('#my-modal-loading').modal({
        relatedTarget: this
    });
}
function am_closeloadding() {
    var $modal = $("#my-modal-loading");
    $modal.modal("close");
}
//////////////////////////////////////