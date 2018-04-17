$(function () {
    //全选 反选
    SelectCheckbox(); 
})
function changePageIndex(pIndex) {
    $('#GridList_Pager_PageIndex').val(pIndex);
    $("#form1").submit();
}
function changePageSize(_this) {
    $('#GridList_Pager_PageIndex').val(1);
    $('#GridList_Pager_PageSize').val($(_this).val());
    $("#form1").submit();
}
////////////////预览////////////////////
$(".resourceDet").parent().unbind();
$(".resourceDet").parent().bind("click", function () {
    var fileID = $(this).find(".resourceDet").attr("id");
    var ResID = $(this).parents(".tableRow").find("input:checkbox").attr("id");
    var url = '/ResourcePreview/Index/' + ResID;
    window.open(url);
})
///////////批量通过///////////////////
$("#ChoosedAgree").unbind();
$("#ChoosedAgree").bind("click", function () {
    var ResId = '';
    $(this).parents(".resourceTable").find(".tableBody input:checkbox").each(function (e, obj) {
        if ($(obj).is(':checked')) {
            if ($(obj).attr("id")) {
                ResId += $(obj).attr("id");
                ResId += ',';
            }
        }
    })
    if (ResId.length > 0) {
        ResId = ResId.substr(0, ResId.length - 1);
        $.ajax({
            type: 'post',
            url: '/ResourceApprove/ResApproveAgree',
            data: { Resids: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data != 0) {
                            openTimeAlert("提示", "资源审批通过", "success");
                            if (ResId.indexOf(',') > -1) {
                                ResId = ResId.split(',');
                                for (var i = 0; i < ResId.length; i++) {
                                    var top = $("#" + ResId[i]).parents(".tableRow");
                                    top.remove();
                                }

                            } else {
                                var top = $("#" + ResId).parents(".tableRow");
                                top.remove();
                            }
                            if ($(".tableBody .tableRow").length <= 0) {
                                $(".resourceTable").html('<div class="emptyTip">你没有要审核的资源....</div>');
                            }
                            // window.location.reload();
                        } else {
                            openTimeAlert("提示", "资源审批失败", "fail");
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
        return false;
    } else {
        openAlert("提示", "请选择要审批的资源");
        return false;
    }
})
///////////批量驳回///////////////////
$("#ChoosedDisAgree").unbind();
$("#ChoosedDisAgree").bind("click", function () {
    var ResId = '';
    $(this).parents(".resourceTable").find(".tableBody input:checkbox").each(function (e, obj) {
        if ($(obj).is(':checked')) {
            if ($(obj).attr("id")) {
                ResId += $(obj).attr("id");
                ResId += ',';
            }
        }
    })
    if (ResId.length > 0) {
        ResId = ResId.substr(0, ResId.length - 1);
        $.ajax({
            type: 'post',
            url: '/ResourceApprove/ResApproveDisAgree',
            data: { Resids: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data != 0) {
                            openTimeAlert("提示", "资源审批驳回", "success");
                            if (ResId.indexOf(',') > -1) {
                                ResId = ResId.split(',');
                                for (var i = 0; i < ResId.length; i++) {
                                    var top = $("#" + ResId[i]).parents(".tableRow");                                  
                                    top.remove();
                                }

                            } else {
                                var top = $("#" + ResId).parents(".tableRow");
                                top.remove();
                            }
                            if ($(".tableBody .tableRow").length <= 0) {
                                $(".resourceTable").html('<div class="emptyTip">你没有要审核的资源....</div>');
                            }
                            // window.location.reload();
                        } else {
                            openTimeAlert("提示", "资源审批失败", "fail");
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
        return false;
    } else {
        openAlert("提示", "请选择要驳回的资源！");
        return false;
    }
})
function ApproveAgree(resId) {
    $.ajax({
        type: 'post',
        url: '/ResourceApprove/ResApproveAgree',
        data: { Resids: resId },
        dataType: 'json',
        async: false,
        success: function (result) {
            switch (result.flag) {
                case 1:
                    if (result.data != 0) {
                        openTimeAlert("提示", "资源审批通过", "success");                    
                        var top = $("#" + resId).parents(".tableRow");
                        top.remove();
                        if ($(".tableBody .tableRow").length <= 0) {
                            $(".resourceTable").html('<div class="emptyTip">你没有要审核的资源....</div>');
                        }
                        // window.location.reload();
                    } else {
                        openTimeAlert("提示", "资源审批失败", "fail");
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
function ApproveDisAgree(resId) {
    $.ajax({
        type: 'post',
        url: '/ResourceApprove/ResApproveDisAgree',
        data: { Resids: resId },
        dataType: 'json',
        async: false,
        success: function (result) {
            switch (result.flag) {
                case 1:
                    if (result.data != 0) {
                        openTimeAlert("提示", "资源审批驳回", "success");                   
                        var top = $("#" + resId).parents(".tableRow");
                          top.remove();
                          if ($(".tableBody .tableRow").length <= 0) {
                              $(".resourceTable").html('<div class="emptyTip">你没有要审核的资源....</div>');
                        }
                        // window.location.reload();
                    } else {
                        openTimeAlert("提示", "资源审批失败", "fail");
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