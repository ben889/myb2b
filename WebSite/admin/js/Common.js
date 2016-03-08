function tabs() {
    var $div_li = $("#tab_menu ul li a");
    $div_li.click(function () {
        var div_index = $div_li.index(this);
        //$div_li.removeClass("selected");
        //$(this).addClass("selected");
        //$("#tab_box>div").hide();
        //$("#tab_box>div").eq(div_index).show();
        selected_tabs(div_index);
    });
}
function selected_tabs(index)
{
    //alert(index);
    var $div_li = $("#tab_menu ul li a");
    $div_li.removeClass("selected");
    $div_li.eq(index).addClass("selected");
    $("#tab_box>div").hide();
    $("#tab_box>div").eq(index).show();
}
function selectall() {
    ///全选全不选
    $("#selectall").click(function () {
        //alert($("#selectall").is(":checked"));
        if ($("#selectall").is(":checked")) {
            $(".selectlist :checkbox").attr("checked", "true");
            //alert("全选 ");
        } else {
            $(".selectlist :checkbox").removeAttr("checked");
        }
    });
}