



var pindex = 0;
var psize = 10;
var totalrows = 0;
//function init_goods(companyid) {
//    $(".m-row-list").html("");
//    pindex = 0;
//    totalrows = 0;
//    bind_goods(companyid);
//}
function init_goods() {
    $(".m-row-list").html("");
    pindex = 0;
    totalrows = 0;
    bind_goods();
}
//ajax加载便民服务信息
//function bind_goods(companyidval) {
function bind_goods() {
    pindex++;
    //var ajaxdata = { method: "bindgoods", companyid: companyidval, pageindex: pindex, pagesize: psize };
    var ajaxdata = { method:"bindgoods", pageindex: pindex, pagesize: psize};
    $.ajax({
        type: "POST",
        url: "goods.aspx",
        data: ajaxdata,
        dataType:"json",
        beforeSend: function () {
            $("#loading").attr('disabled', "disabled").html("加载中...");
        },
        success: function (jsons) {
            //alert(results);            
            totalrows = jsons.totalrows;
            addrows(jsons.rows);
            $('#loading').html("加载更多...");
            $('#loading').removeAttr("disabled");

            if (jsons.rows.length == 0) {
                $('#loading').attr('disabled', "disabled");
                $('#loading').html("无更多数据...");
                pindex--;
            }

            var mo = totalrows / psize;
            pageCount = parseInt(mo);

            if ((totalrows % psize) > 0) {
                pageCount = pageCount + 1;
            }

            if (pindex > pageCount)
                pindex = 1;

            if (pindex <= 0)
                pindex = 1;

        },
        error: function () {
            alert("err");
            $('#loading').html("加载更多...");
            $('#loading').removeAttr("disabled");
            pindex--;
        }
    });
}

// 绑定便民服务信息
function addrows(json) {
    if (json.length > 0) {
        for (var i = 0; i < json.length; i++) {
            if (json[i].GoodsName.length > 12)
                json[i].GoodsName = json[i].GoodsName.substring(0, 12) + "...";
            if (json[i].description.length > 40)
                json[i].description = json[i].description.substring(0, 40) + "...";
            var results = "";
            console.info(json);
            results += "<div class=\"m-row-list-item\">";
            results += "<a href=\"goodsdetail.aspx?id=" + json[i].GoodsId + "\">";
            results += "<div class=\"dealcard-img\">";
            results += "<img src=\"" + json[i].Img + "\" />";
            results += "</div>";
            results += "<div class=\"dealcard-block-right\">";
            results += "<div class=\"dealcard-title\" >" + json[i].GoodsName + "</div>";
            results += "<div class=\"text-block\" style=\"white-space:normal;word-break:break-all;overflow-x:auto;padding:0px 10px 0px 0px;height:50px;\">" + json[i].description + "</div>";
            results += "<div class=\"price\">";
            results += "<span class=\"strong\">" + json[i].Price + "</span> <span class=\"strong-color\">元</span>";
            //results += "<del>" + json[i].Price + "元</del>";
            //results += "<span class=\"line-right\">已售：" + json[i].ExchCount  + "";
            //results += "</span>";
            results += "</div>";
            results += "</div>";
            results += "</a>";
            results += "</div>";
            //alert(results);
            $(".m-row-list").append(results);
        }
    }
}

