var pindex = 0;
var psize = 10;
var totalrows = 0;

//function pager_initlist() {
//    $("#list").html("");
//    pindex = 1;
//    bindlist();
//}


//function bindlist() {
//    pindex++;
//    var data = { ajaxmethod: "bindlist", pageindex: pindex, pagesize: psize };
//    var url = "select_g_order.aspx";
//    getpager(data, url);
//}

//data:{ ajaxmethod: "bindlist", pageindex: pindex, pagesize: psize };
//url: "/mobile/repair/repair.aspx",
function getpager(ajaxdata, url) {
    //alert(pindex);
    $.ajax({
        type: "post",
        url: url,
        dataType: "json",
        data: ajaxdata,
        beforeSend: function () {
            $("#loading").attr('disabled', "disabled").html("加载中...");
        },
        success: function (results) {
            totalrows = results.TotalRows;
            $('#loading').html("加载更多");
            $('#loading').removeAttr("disabled");
            //pager_addrows(results.rows);
            //console.info(results);
            pager_bind(results);
            if (results.rows.length == 0) {
                $('#loading').attr('disabled', "disabled");
                $('#loading').html("无更多数据");
                pindex--;
            }
            
            var mo = totalrows / psize;
            
            pageCount = parseInt(mo);
            if ((totalrows % psize) > 0 ) {
                pageCount = pageCount + 1;
            }
            //alert("totalrows=" + totalrows);
            if (pindex > pageCount)
                pindex = pageCount;

            if (pindex <= 0)
                pindex = 1;
            //alert(pindex);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert(textStatus);
            $('#loading').html("加载更多");
            $('#loading').removeAttr("disabled");
            pindex--;
        }
    });
}

//function pager_bind(jsons) {
//    var totalrows = results.TotalRows;
//    var json = results.rows;
//    for (var i = 0; i < json.length; i++) {

//    }
//}