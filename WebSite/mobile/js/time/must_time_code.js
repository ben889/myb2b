$(function () {
    var dateScroll = function () {
        var date = new Date();
        var curr = new Date().getFullYear(),
            d = date.getDate(),
            m = date.getMonth();
        $('#appoitment').scroller('destroy').scroller({
            preset: 'datehour',
            minDate: new Date(curr, m, d, 8, 00),
            maxDate: new Date(curr, m, d + 7),
            invalid: [{ d: new Date(), start: '00:00', end: (date.getHours() + 2) + ':' + date.getMinutes() }],
            theme: "android-ics light",
            mode: "scroller",
            lang: 'zh',
            display: "bottom",
            animate: "slideup",
            stepMinute: 30,
            dateOrder: 'MMDdd',
            timeWheels: 'HHii',
            rows: 3
        });
    }
    dateScroll();//时间选择控件
});