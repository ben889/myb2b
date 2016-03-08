
var pageIndex = 1;         //当前页数
var pageCount = 1;    //总页数
var totalrows;
var pageSize;
var databindcallback;

var pageshowid;
function showPages(showid, trows, pSize, callback) { //初始化属性

    totalrows = trows;
    pageSize = pSize;

    var mo = totalrows / pageSize;
    pageCount = parseInt(mo);
    //alert("totalrows=" + totalrows + " pageSize=" + pageSize + " " + totalrows % pageSize);
    if ((totalrows % pageSize) > 0) {
        pageCount = pageCount + 1;
    }

    if (pageCount <= 0)
        pageCount = 1;

    if (pageIndex <= 0)
        pageIndex = 1;

    pageshowid = showid;
    databindcallback = callback;
    document.getElementById(pageshowid).innerHTML = createHtml();
    //databindcallback();
}

function createHtml() { //生成html代码
    //alert("pageCount=" + pageCount);
    var strHtml = '', prevPage = pageIndex - 1, nextPage = pageIndex + 1;
    strHtml += '<div class="pages">';
    strHtml += '<span class="count">共' + totalrows + '条 ' + pageIndex + ' / ' + pageCount + '页</span>';
    strHtml += '<span class="number">';
    if (prevPage < 1) {
        strHtml += '<span title="First Page">&#171;</span>';
        strHtml += '<span title="Prev Page">&#139;</span>';
    } else {
        strHtml += '<span title="First Page"><a href="javascript:toPage(1);">&#171;</a></span>';
        strHtml += '<span title="Prev Page"><a href="javascript:toPage(' + prevPage + ');">&#139;</a></span>';
    }
    if (pageIndex % 10 == 0) {
        var startPage = pageIndex - 9;
    } else {
        var startPage = pageIndex - pageIndex % 10 + 1;
    }
    if (startPage > 10) strHtml += '<span title="Prev 10 Pages"><a href="javascript:toPage(' + (startPage - 1) + ');">...</a></span>';
    for (var i = startPage; i < startPage + 10; i++) {
        if (i > pageCount) break;
        if (i == pageIndex) {
            strHtml += '<span title="Page ' + i + '">[' + i + ']</span>';
        } else {
            strHtml += '<span title="Page ' + i + '"><a href="javascript:toPage(' + i + ');">[' + i + ']</a></span>';
        }
    }
    if (pageCount >= startPage + 10) strHtml += '<span title="Next 10 Pages"><a href="javascript:toPage(' + (startPage + 10) + ');">...</a></span>';
    if (nextPage > pageCount) {
        strHtml += '<span title="Next Page">&#155;</span>';
        strHtml += '<span title="Last Page">&#187;</span>';
    } else {
        strHtml += '<span title="Next Page"><a href="javascript:toPage(' + nextPage + ');">&#155;</a></span>';
        strHtml += '<span title="Last Page"><a href="javascript:toPage(' + pageCount + ');">&#187;</a></span>';
    }
    strHtml += '</span>';
    strHtml += '</div>';
    return strHtml;
}
toPage = function (currentpage) { //页面跳转
    pageIndex = currentpage;
    databindcallback();
    
}
