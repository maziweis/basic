var Ggrade;
var Gedi;
var Gunitname;
$(function () {
    //筛选条件选择
    FilterSelect();
    //按钮选中状态
    ClickFun(".actBtn");
    //排序选中状态
    ClickFun(".sortSwitch a");
    //全选 反选
    SelectCheckbox();
    //if ($("#ResourceStyle").val()) {
    //    var id = $("#ResourceStyle").val();
    //    $("#ResourceStyle").parent().find("#" + id).addClass("on");
    //}
    if ($("#ResourceStyle").val()) {
        var id = $("#ResourceStyle").val();
        $("#ResourceStyle").parent().find("#" + id).addClass("on");
    }   
    if ($("#SubjectID").val()) {
        Ggrade = $("#GradeID").val();
        Gedi = $("#EditionID").val();
        Gunitname = $("#UnitID").parent().find(".UnitName").val();
        SubjectChange("#SubjectID");
    }
})
///////////////单个取消收藏/////////////////////
function CancelCollect(ResId, obj) {
    if (ResId) {
        $.ajax({
            type: 'post',
            url: '/ResourceSearch/ResourceCancelCollect',
            data: { Resid: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data != 0) {
                            openTimeAlert("提示", "资源取消收藏成功", "success");
                            var divparent = $(obj).parents(".tableRow");
                            divparent.remove();
                            if ($(".tableBody .tableRow").length <= 0) {
                                $(".resourceTable").html(' <div class="emptyTip">空空如也...快去<a href="/ResourceSearch/Index/' + $("#SubjectID").val() + '"> 去资源库收藏资源</a>吧！</div>');
                            }
                        } else {
                            openTimeAlert("提示", "资源取消收藏失败", "fail");
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
///////////批量分享///////////////////
$("#ShareResource").unbind();
$("#ShareResource").bind("click", function () {
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
            url: '/Resource/ResourceShare',
            data: { Resids: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data != 0) {
                            openTimeAlert("提示", "资源分享成功，正在审核！","success");
                            if (ResId.indexOf(',') > -1) {
                                ResId = ResId.split(',');
                                for (var i = 0; i < ResId.length; i++) {
                                    var top = $("#" + ResId[i]).parents(".tableRow");
                                    var divparent = top.find(".relaDiv");
                                    var div = divparent.find("em");
                                    if (div.find("a").text() != "已分享") {
                                        div.remove();
                                        divparent.prepend('<em class="share"><a>未分享</a></em>');
                                    }                                  
                                }

                            } else {
                                var top = $("#" + ResId).parents(".tableRow");
                                var divparent = top.find(".relaDiv");
                                var div = divparent.find("em");
                                div.remove();
                                divparent.prepend('<em class="share"><a>未分享</a></em>');
                            }
                           // window.location.reload();
                        } else if (result.data == 0) {
                            openTimeAlert("提示", "该资源已经分享","success");
                        } else {
                            openTimeAlert("提示", "资源分享失败","fail");
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
    } else {
        openAlert("提示", "请选择要分享的资源");
    }
})
///////////////单个资源分享///////////////////
function ShareSingleRes(ResId,obj) {
    if (ResId) {
        $.ajax({
            type: 'post',
            url: '/Resource/ResourceShare',
            data: { Resids: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data != 0) {
                            openTimeAlert("提示", "资源分享成功，正在审核","success");
                            var divparent = $(obj).parents(".relaDiv");
                            var div = $(obj).parent();
                            div.remove();
                            divparent.prepend('<em class="share"><a>未分享</a></em>');
                           // window.location.reload();
                        } else {
                            openTimeAlert("提示", "资源分享失败","fail");
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

/////////////////资源下载/////////////////
function ResDownLoad(ResId) {
    var file_Url = $("#FileServer").val();
    if (ResId) {
        $.ajax({
            type: 'post',
            url: '/Resource/GetResourceById',
            data: { ResId: ResId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.IsExsitFileID) {
                            if (result.data.IsExsitFileID == 0) {
                                openAlert("提示", "你下载的文件不存在或已被删除！");
                            } else if (result.data.IsExsitFileID == 2) {
                                openTimeAlert("提示", "该资源已达下载上限", "worm");
                            } else {
                                var url = "/api/Download/" + ResId;
                                var elemIF = document.createElement("iframe");
                                elemIF.src = url;
                                elemIF.style.display = "none";
                                document.body.appendChild(elemIF);
                            }
                            // window.open(url);
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
///////////////按时间排序///////////////
$(".sortSwitch a").click(function () {
    var oderby = $("#OrderBy").val();
    if (oderby == "1") {
        oderby = 2;
    } else {
        oderby = 1;
    }
    $(".sortSwitch #OrderBy").val(oderby);
    $("#form1").submit();
})
////////////////预览////////////////////
$(".resourceDet").parent().unbind();
$(".resourceDet").parent().bind("click", function () {
    var fileID = $(this).find(".resourceDet").attr("id");
    var ResID = $(this).parents(".tableRow").find("input:checkbox").attr("id"); 
    var url = '/ResourcePreview/Index/' + ResID;
    window.open(url);
})
function Search() {
    $('#GridList_Pager_PageIndex').val(1);
    $("#form1").submit();
}
function changePageIndex(pIndex) {
    $('#GridList_Pager_PageIndex').val(pIndex);
    $("#form1").submit();
}
function DeleteUnit(obj) {
    $(obj).parent().find("#UnitName").val("");
    $(obj).parent().find("#UnitID").val("");
}
function DeleteKey(obj) {
    $(obj).parent().find("input").val("");
}
function changePageSize(_this) {
    $('#GridList_Pager_PageIndex').val(1);
    $('#GridList_Pager_PageSize').val($(_this).val());
    $("#form1").submit();
}
///////////学科/////////////
function SubjectChange(obj) {
    var subid = $(obj).val();
    var eid = $("#EditionID").val();
    var gradeId = $("#GradeID").val();
    var eids;
    var html = '';
    if (!subid) {
        $("#UnitID").val("");
        $("#UnitID").parent().find(".UnitName").val("");
        $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
        $(".selectF .catalogD").html("");
    } else {
        eids = $("#EditionID");
        eids.empty();
        eids.append('<option selected="selected" value="">全部版本</option>');
        $.ajax({
            type: 'post',
            url: '/ResourceSearch/GetSelectEditionID',
            data: { SubjectId: subid },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.length != 0) {
                            $.each(result.data, function (i, item) {
                                eids.append('<option value="' + item.ID + '">' + item.CodeName + '</option>');
                                //if (i == 0) {
                                //    eids.val(item.ID);
                                //}
                            });
                            if (Gedi) {
                                eids.val(Gedi);
                                Gedi = "";
                            }
                            EditionChange("#EditionID");
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
////选择版本
function EditionChange(obj) {
    var eid = $(obj).val();
    var subId = $("#SubjectID").val();
    var gradeId = $("#GradeID").val();
    var html = '';
    var grades;
    grades = $("#GradeID");
    //    gradeid = grades.val();
    grades.empty();
    grades.append('<option selected="selected" value="">全部年级</option>');
    if (!eid) {     
        $.ajax({
            type: 'post',
            url: '/ResourceSearch/GetSelectAllGradeID',
            data: { Subject: subId },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.length != 0) {
                            $.each(result.data, function (i, item) {
                                grades.append('<option value="' + item.ID + '">' + item.CodeName + '</option>');
                                //if (i == 0) {
                                //    grades.val(item.ID);
                                //}
                            });
                            if (Ggrade) {
                                grades.val(Ggrade);
                                Ggrade = "";
                            }
                            GradeChange("#GradeID");
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
        $("#UnitID").parent().find(".UnitName").val("");
        $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
        $(".selectF .catalogD").html("");
    } else {
        $.ajax({
            type: 'post',
            url: '/ResourceSearch/GetSelectGradeID',
            data: { editionId: eid },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.length != 0) {
                            $.each(result.data, function (i, item) {
                                grades.append('<option value="' + item.ID + '">' + item.CodeName + '</option>');
                                //if (i == 0) {
                                //    grades.val(item.ID);
                                //}
                            });
                            if (Ggrade) {
                                grades.val(Ggrade);
                                Ggrade = "";
                            }
                            GradeChange("#GradeID");
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
////选择年级
function GradeChange(obj) {
    var subID = $("#SubjectID").val();
    var gid = $(obj).val();
    var eid = $("#EditionID").val();
    var html = '';
    if (!eid || !gid || !subID) {
        $("#UnitID").val("");
        $("#UnitID").parent().find(".UnitName").val("");
        $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
        $(".selectF .catalogD").html("");
    } else {
        $.ajax({
            type: 'post',
            url: '/ResourceSearch/GetSelectBookID',
            data: { subjectId: subID, gradeId: gid, editionId: eid },
            dataType: 'json',
            async: false,
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        if (result.data.length != 0) {
                            if (!Gunitname) {
                                $("#UnitID").val("");
                                $("#UnitID").parent().find(".UnitName").val("");
                                $("#UnitID").parent().find(".UnitName").attr("placeholder", "请选择教材目录");
                            } else {
                                Gunitname = "";
                            }
                            html += '<ul class="ulS">';
                            html += '<li class="open">';
                            if (subID == 3) {
                                html += '<b class="unhold">&nbsp;</b><a class="up">英语全部章节</a>';
                            } else if (subID == 2) {
                                html += '<b class="unhold">&nbsp;</b><a class="up">数学全部章节</a>';
                            } else if (subID == 1) {
                                html += '<b class="unhold">&nbsp;</b><a class="up">语文全部章节</a>';
                            }                        
                            html += '<ul>'
                            for (var i = 0; i < result.data.length; i++) {
                                html += '<li>';
                                if (result.data[i].ID == 1) {
                                    html += '<b>&nbsp;</b><a>上册</a>';
                                } else {
                                    html += '<b>&nbsp;</b><a>下册</a>';
                                }
                                html += '<ul>';
                                $.each(result.data[i].Book, function (e, item) {
                                    if (item.PId == 0) {
                                        html += '<li>';
                                        html += '<b>&nbsp;</b><a href="javascript:void(0)" id="' + item.Id + '">' + item.Name + '</a>';
                                        if (item.Name.indexOf("Model") > -1) {
                                            html += '<ul>';
                                            $.each(result.data[i], function (q, cata) {
                                                if (item.Id == cata.PId) {
                                                    html += '<li>';
                                                    html += '<b>&nbsp;</b><a href="javascript:void(0)" id="' + item.Id + '">' + item.Name + '</a>';
                                                }
                                            });
                                            html += '</ul>';
                                        }
                                        html += '</li>';
                                    }
                                });
                                html += '</ul>';
                                html += '</li>';

                            }
                            html += '</ul>';
                            html += '</li>';
                            html += '</ul>';
                        } else {
                            $("#UnitID").val("");
                            $("#UnitID").parent().find(".UnitName").val("");
                            $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
                        }
                        $(".selectF .catalogD").html(html);
                        //树形结构选择
                        ShowCatalog();
                        CatalogFun();
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
