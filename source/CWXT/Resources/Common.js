function ConfrimToolbar() {
    if (event.flatIndex == 0) {
        if (confirm("是否确认导出")) {
            __doPostBack('Toolbar', event.flatIndex);
        }
        else
            return false;
    }
    else {
        __doPostBack('Toolbar', event.flatIndex);
    }
};

//报表显示明细
function showDetail(num, el) {
    var obj = $(el).parent().find("tr[parent=" + num + "]");
    if (obj.attr("isshow") == "yes") {
        obj.hide().attr("isshow", "no");
    }
    else {
        obj.show().attr("isshow", "yes");
    }
}