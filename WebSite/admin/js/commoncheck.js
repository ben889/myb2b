function setNumInput(id) {
    //var numExp = /^\d$/;
    var num = $.trim($("#" + id).val());
    if (num == "")
        return;
    var numExp = /^[0-9]*[0-9][0-9]*$/;
    if (!numExp.test(num)) {
        alert("对不起，该文本框只能输入数字！请重新输入");
        $("#" + id).val("")
        return;
    }
    countrow(i);
}