
var pindex = 0;
var psize = 10;
var totalrows = 0;
function init_goods(status) {
    $(".m-detail-con").html("");
    pindex = 0;
    totalrows = 0;
    bind_goods(status);
}
//ajax加载
function bind_goods(status) {
    pindex++;
    var ajaxdata = { method: "bindgoods", pageindex: pindex, pagesize: psize, status: status };
    $.ajax({
        type: "POST",
        url: "goodsStuff.aspx",
        data: ajaxdata,
        dataType:'json',
        beforeSend: function () {
            $("#loading").attr('disabled', "disabled").html("加载中...");
        },
        success: function (results) {
            //var jsons = eval(results);
            totalrows = results.pagesize; //返回总行数
            
            binding(results.content);// 调用绑定方法
            $('#loading').html("加载更多...");
            $('#loading').removeAttr("disabled");

            if (results.content.length == 0) {
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
            $('#loading').html("加载更多...");
            $('#loading').removeAttr("disabled");
            pindex--;
        }
    });
}


//绑定
function binding(json)
{
    var html = "";
    for (var i = 0; i < json.length; i++)
    {
        html += '<div class="s-item" style=""><div class="" style="float: left; margin: 10px 10px;width:100px;height:100px; overflow:hidden;border:1px solid #eeeeee;"><img src="' + json[i].Img + '" style="height: 100px;border-radius:1px;" /></div><div class="" style="float: left; margin: 7px 4px 0px 4p;"><h4>' + json[i].GoodsName + '</h4> <ul><li>  <span style="font-size: 10px; color: #e4e0e0;">门店价：<del>' + json[i].Price + '元</del></span></li><li>' + json[i].sellername + '</li><li>有效时间：' + modification_Date(json[i].EndDate) + '</li> <li>兑换时间：' + json[i].ExchTime + '</li> <li>兑换序列号：' + sub_Sequence(json[i].Sequence) + '</li></ul> </div><div style="clear: both;"></div></div> <div class="m-detail-com-hr"></div>';
    }
    $(".m-detail-con").append(html);

    //<div class="s-item" style="">
    //            <div class="" style="float: left; margin: 10px 10px;">
    //<img src="'+json[i].Img+'" style="height: 60px;" />
    //            </div>
    //            <div class="" style="float: left; margin: 15px 4px">
    //                <h4>'+json[i].GoodsName+'</h4>
    //                <ul>
    //                    <li><span style="color: #4bdbef; font-weight: bold;">直接领取</span>  <span style="font-size: 10px; color: #e4e0e0;">门店价：'+json[i].Price+'元</span></li>
    //                    <li>'+json[i].GoodsName+'</li>
    //                    <li></li>
    //                    <li>兑换数量：'+json[i].goods_count+'</li>
    //                    <li>兑换时间：'+json[i].ExchTime+'</li>
    //                    <li>兑换序列号：'+json[i].GoodsName+'</li>
    //                    <li>
    //                       <%-- <a href="javascript:void(0);" class="m-btn btn_green" style=" background-color:#fff;border:1px solid #4bdbef; color:#4bdbef;">查看兑换二维码</a>--%>
    //                    </li>
    //                </ul>

    //            </div>
    //            <div style="clear: both;"></div>
    //        </div>
    //        <div class="m-detail-com-hr"></div>
}

function sub_Sequence(Sequence)
{
    var newstr = "";
    if (Sequence.length < 4)
        return Sequence;
    newstr = Sequence.substring(0, 4) + " " + Sequence.substring(4, 8) + " " + Sequence.substring(8, Sequence.length);
    return newstr;
}

function modification_Date(value) {
    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    var year = date.getFullYear(); //获取年
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1; //获取月
    var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate(); //获取日
    var Hour = date.getHours(); //时
    var Minute = date.getMinutes(); //分
    var Second = date.getSeconds(); //秒
    return year + "-" + month + "-" + day + "  " + Hour + ":" + Minute + ":" + Second;
}






