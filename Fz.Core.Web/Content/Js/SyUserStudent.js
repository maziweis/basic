$(document).ready(function () {
    SelectCheckbox();
    //删除
    $(document).on('click', '.btnDelete', function (e) {
        var _id = $(this).attr("dataid");
        openConfirm("标题", "您确定要删除该用户吗?","", function () {
            $.ajax({
                type: 'post',
                url: '/SyUserStudent/Delete',
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
        })
        $(this).blur();
    });

    //重置密码
    $(document).on('click', '.btnResetPwd', function (e) {
        var _id = $(this).attr("dataid");
        openConfirm("标题", "您确定要重置密码吗?", "", function () {
            $.ajax({
                type: 'post',
                url: '/SyUserStudent/ResetPwd',
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
        })
        $(this).blur();
    });


    //启用
    $(document).on('click', '.btnStart', function (e) {
        var _id = $(this).attr("dataid");
        openConfirm("标题", "您确定要恢复该用户吗?","", function () {
            $.ajax({
                type: 'post',
                url: '/SyUserStudent/Start',
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
        })
        $(this).blur();
    });

    //停用
    $(document).on('click', '.btnStop', function (e) {
        var _id = $(this).attr("dataid");
        openConfirm("标题", "您确定要停用该用户吗?", "", function () {
            $.ajax({
                type: 'post',
                url: '/SyUserStudent/Stop',
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
        })
        $(this).blur();
    });

    //批量恢复
    $(document).on('click', '#btnStarts', function (e) {
        var chk_value = [];
        $('input[name="cbs"]:checked').each(function () {
            chk_value.push($(this).val());
        });
        if (chk_value.length > 0) {
            openConfirm("标题", "您确定要恢复选中用户吗?", "", function () {
                $.ajax({
                    type: 'post',
                    url: '/SyUserStudent/Starts',
                    data: { ids: chk_value },
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
            })
        }
        else {
            openAlert("提示", "至少要选中一个要恢复的用户！");
        }
        $(this).blur();
    });

    //批量停用
    $(document).on('click', '#btnStops', function (e) {
        var chk_value = [];
        $('input[name="cbs"]:checked').each(function () {
            chk_value.push($(this).val());
        });
        if (chk_value.length > 0) {
            openConfirm("标题", "您确定要停用选中用户吗?", "", function () {
                $.ajax({
                    type: 'post',
                    url: '/SyUserStudent/Stops',
                    data: { ids: chk_value },
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
            })
        }
        else {
            openAlert("提示", "至少要选中一个要停用的用户！");
        }
        $(this).blur();
    });

    //批量删除
    $(document).on('click', '#btnDeletes', function (e) {
        var chk_value = [];
        $('input[name="cbs"]:checked').each(function () {
            chk_value.push($(this).val());
        });
        if (chk_value.length > 0) {
            openConfirm("标题", "您确定要删除选中用户吗?", "", function () {
                $.ajax({
                    type: 'post',
                    url: '/SyUserStudent/Deletes',
                    data: { ids: chk_value },
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
            })
        }
        else {
            openAlert("提示", "至少要选中一个要删除的用户！");
        }
        $(this).blur();
    });

    //全选、取消全选
    $(document).on('click', '#cball', function (e) {
        $('input[name="cbs"]').prop("checked", this.checked);
    });

    $("#myModal").on("hidden.bs.modal", function () {//隐藏modal时清除数据
        $(this).removeData("bs.modal");
    });

    //显示modal后调用check函数
    //$("#myModal").on("shown.bs.modal", function () {
    //    labelCheck();
    //});
});

function search() {
    $('#Grid_Pager_PageIndex').val(1);
    $("#form1").submit();
}

function changePageIndex(pIndex) {
    $('#Grid_Pager_PageIndex').val(pIndex);
    $("#form1").submit();
}

function changePageSize(_this) {
    $('#Grid_Pager_PageIndex').val(1);
    $('#Grid_Pager_PageSize').val($(_this).val());
    $("#form1").submit();
}

function formSuccess(result) {
    if (result.success) {
        $('#myModal').modal('hide');
        window.location = '/SyUserStudent/Index';
    }
    else {
        $('.modal-content').html(result);
        labelCheck();
    }

}

function GradeChange(_this) {
    var _gid = $(_this).val();
    $("#Class").empty();
    $("#Class").append('<option value="">--请选择--</option>');
    if (_gid != "") {
        $.ajax({
            type: 'post',
            url: '/SyClass/GetSelect',
            data: { gradeId: _gid },
            dataType: 'json',
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.length != 0) {
                            $.each(result.data, function (i, item) {
                                $("#Class").append('<option value="' + item.Value + '">' + item.Text + '</option>');
                            });
                        }
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
}