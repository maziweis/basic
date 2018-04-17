$(document).ready(function () {
    SelectCheckbox();
    //删除
    $(document).on('click', '.btnDelete', function (e) {
        var _id = $(this).attr("dataid");
        if (confirm("您确定要删除该记录吗？")) {
            $.ajax({
                type: 'post',
                url: '/SyRole/Delete',
                data: { id: _id },
                dataType: 'json',
                success: function (result) {
                    switch (result.flag) {
                        case 1:
                            alert("操作成功！");
                            window.location.reload();
                            break;
                        case 0:
                            alert(result.msg);
                            break;
                        case -1:
                            break;
                        case -2:
                            break;
                        case -3:
                            break;
                    }
                }
            });
        }
        $(this).blur();
    });

    //启用
    $(document).on('click', '.btnStart', function (e) {
        var _id = $(this).attr("dataid");
        if (confirm("您确定要恢复该记录吗？")) {
            $.ajax({
                type: 'post',
                url: '/SyRole/Start',
                data: { id: _id },
                dataType: 'json',
                success: function (result) {
                    switch (result.flag) {
                        case 1:
                            alert("操作成功！");
                            window.location.reload();
                            break;
                        case 0:
                            break;
                        case -1:
                            break;
                        case -2:
                            break;
                        case -3:
                            break;
                    }
                }
            });
        }
        $(this).blur();
    });

    //停用
    $(document).on('click', '.btnStop', function (e) {
        var _id = $(this).attr("dataid");
        if (confirm("您确定要停用该记录吗？")) {
            $.ajax({
                type: 'post',
                url: '/SyRole/Stop',
                data: { id: _id },
                dataType: 'json',
                success: function (result) {
                    switch (result.flag) {
                        case 1:
                            alert("操作成功！");
                            window.location.reload();
                            break;
                        case 0:
                            break;
                        case -1:
                            break;
                        case -2:
                            break;
                        case -3:
                            break;
                    }
                }
            });
        }
        $(this).blur();
    });

    //导出
    $(document).on('click', '#btnExport', function (e) {
        var ids = "";
        $('input[name="cbs"]:checked').each(function () {
            ids += $(this).val() + "_";
        });
        if (ids != "") {
            window.location.href = "/SyRole/Export/" + ids;
        }
        else {
            alert("至少要选中一个角色！");
        }
    });

    //全选、取消全选
    $(document).on('click', '#cball', function (e) {
        $('input[name="cbs"]').prop("checked", this.checked);
    });

    //隐藏modal时清除数据
    $("#myModal").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
    });
});

function search() {
    $("#form1").submit();
}

function changePageIndex(pIndex) {
    $('#Grid_Pager_PageIndex').val(pIndex);
    $("#form2").submit();
}

function changePageSize(_this) {
    $('#Grid_Pager_PageIndex').val(1);
    $('#Grid_Pager_PageSize').val($(_this).val());
    $("#form2").submit();
}