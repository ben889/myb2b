//ajax加载
function bindmenu() {
    var ajaxdata = { ajaxmethod: "bindmenu" };
    $.ajax({
        type: "POST",
        url: "index.aspx",
        data: ajaxdata,
        beforeSend: function () {
            $("#menu").html("加载中...");
        },
        success: function (results) {
            //alert(results);
            var json = eval(results);
            var html = setmenuhtml(json);
            $('#menu').html(html);
        },
        error: function () {
            $('#menu').html("加载错误");
        }
    });
}
function bindsubmenu(mid) {
    subresulthtml = "";
    var ajaxdata = { ajaxmethod: "bindsubmenu", parentid: mid };
    $.ajax({
        type: "POST",
        url: "index.aspx",
        data: ajaxdata,
        beforeSend: function () {
            $("#submenu").html("加载中...");
        },
        success: function (results) {
            //alert(results);
            var json = eval(results);
            var html = setleftmenuhtml(json, 1);
            selected(mid);
            $('#submenu').html(html);

        },
        error: function () {
            $('#submenu').html("加载错误");
        }
    });
}

//function bindleftmenu(parentid) {
//    resulthtml = "";
//    $("#submenu").html("");
//    var json = [{ "id": 1, "name": "aaaaa", "submenu": [{ "id": 3, "name": "cccc", "submenu": [] }, { "id": 4, "name": "ddddd", "submenu": [] }] }, { "id": 2, "name": "bbbb", "submenu": [] }];
//    var html = setleftmenuhtml(json);
//    //alert(html);
//    $("#submenu").html(html);
//}

var resulthtml = "";
var subresulthtml = "";

//一级菜单
function setmenuhtml(json) {

    if (json == undefined || json.length == 0)
        return "";
    //alert(json);
    resulthtml += "<ul>";
    for (var i = 0; i < json.length; i++) {
        resulthtml += "<li><a href=\"javascript:bindsubmenu('" + json[i].id + "');\" id=\"" + json[i].id + "\">" + json[i].name + "</a>";
        resulthtml += "</li>";
        if (i == 0)
            bindsubmenu(json[i].id);
    }
    resulthtml += "</ul>";
    return resulthtml;
}
var lev = 0;
//子级菜单
function setleftmenuhtml(subjson, showul) {

    if (subjson == undefined || subjson.length == 0)
        return "";
    var dtlength = subjson.length;
    if (dtlength > 0) {
        lev++;

        var display = "";
        if (showul == 1)
            display = "style=\"display:block;\"";
        //alert(lev + "-" + showul + "-" + display);
        subresulthtml += "<ul " + display + ">";
        var clickfun = "";
        for (var i = 0; i < dtlength; i++) {
            //alert(resulthtml);
            if (lev == 1) {
                clickfun = "submenutoggle('" + subjson[i].id + "');";
            }
            var subj = subjson[i].submenu;
            subresulthtml += "<li><a href=\"" + subjson[i].url + "\" id=\"" + subjson[i].id + "\" target=\"mainframe\" onclick=\"" + clickfun + "\">" + subjson[i].name + "</a>";
            var isshow = 0;
            if (lev == 2 && i == 0) {
                isshow = 1;
                //alert("这里要显示了isshow = 1");
            }
            //alert(lev + "-" + i + "-" + isshow);
            setleftmenuhtml(subj, isshow);
            subresulthtml += "</li>";
        }
        subresulthtml += "</ul>";
        //alert(subresulthtml);
        lev--;
    }
    return subresulthtml;
}
//子菜单收展
function submenutoggle(mid) {
    $("#submenu ul li ul").hide();
    $("#" + mid).next().show();
}

function selected(mid) {
    $("#menu ul li").removeClass("selected");
    $("#" + mid).parent().addClass("selected");
}