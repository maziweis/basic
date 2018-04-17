var Ggrade;
var Gedi;
var flag = false;
var navigatorName = "Microsoft Internet Explorer";
$(function () {
    //筛选条件选择
    FilterSelect();
    //全选 反选
    SelectCheckbox();
    SubjectChange("#SubjectID");
    $(".panel-group .panel-default:eq(3)").find(".panel-heading").addClass("on");
    $(".tableBody .tableRow").each(function (i, n) {
        $("#ResGrid_" + i + "__SubjectID").val("3");
        SubjectChange("#ResGrid_" + i + "__SubjectID", i);
    })
    $(".allSet").unbind();
    $(".allSet").bind("click", function () {      
        $(".tableBody .tableRow").each(function (i, n) {
            flag = true;
            Gedi = $("#EditionID").val();
            Ggrade = $("#GradeID").val();
            var unitID = $("#UnitID").val();
            var resStyle = $("#ResStyleID").val();
            var subId = $("#SubjectID").val();
            $("#ResGrid_" + i + "__SubjectID").val(subId);
            $("#ResGrid_" + i + "__UnitID").val(unitID);
            $("#ResGrid_" + i + "__ResStyleID").val(resStyle);
            $("#ResGrid_" + i + "__ResStyleID").parent().find("a").removeClass("on");
            $("#ResGrid_" + i + "__ResStyleID").parent().find("#" + resStyle).addClass("on");
            SubjectChange("#ResGrid_" + i + "__SubjectID", i);
        })
    })
    $(".save").unbind();
    $(".save").bind("click", function () {
        var flag = true;
        for(var i=0; i < $(".tableBody .tableRow").length; i++){
            var subid = $("#ResGrid_" + i + "__SubjectID").val();
            var gradeid = $("#ResGrid_" + i + "__GradeID").val();
            var ediId = $("#ResGrid_" + i + "__EditionID").val();
            var unitid = $("#ResGrid_" + i + "__UnitID").val();    
            var unitname = $("#ResGrid_" + i + "__UnitName").val();
            var style = $("#ResGrid_" + i + "__ResStyleID").val();
            var FileName = $("#ResGrid_" + i + "__FileName").val();
            var Description = $("#ResGrid_" + i + "__Description").val();
            // if (!subid || !gradeid || !ediId || !unitname || !style || !FileName) {
            //    flag = true;
            // }
            if (!ediId) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源没有选择版本！");
                } else {
                    openAlert("提示", "该资源没有选择版本！");
                }
                flag = false;
                return false;
            }
            if (!gradeid) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源没有选择年级！");
                } else {
                    openAlert("提示", "该资源没有选择年级！");
                }
                flag = false;
                return false;
            }
            if (!unitid || !unitname) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源没有选择教材！");
                } else {
                    openAlert("提示", "该资源没有选择教材！");
                }
                flag = false;
                return false;
            }
            if (!FileName) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源没有填写资源名称！");
                } else {
                    openAlert("提示", "该资源没有填写资源名称！");
                }
                flag = false;
                return false;
            }
            if (!style) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源没选择资源类型！");
                } else {
                    openAlert("提示", "该资源没选择资源类型！");
                }
                flag = false;
                return false;
            }
            if (FileName.length > 50) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源资源名称超过50个字！");
                } else {
                    openAlert("提示", "该资源资源名称超过50个字！");
                }
                flag = false;
                return false;
            }
            if (Description && Description.length > 200) {
                if ($(".tableBody .tableRow").length > 1) {
                    openAlert("提示", "第" + (i + 1) + "个资源资源描述超过200个字！");
                } else {
                    openAlert("提示", "该资源资源描述超过200个字！");
                }
                flag = false;
                return false;
            }

        }
        if (flag) {
            $("#form1").submit();
        }
        //  if (flag) {
        //    flag = false;
        //    openAlert("提示", "请先选择学科、年级、版本、教材、资源格式并填写资源名称再点击保存！");
        //  } else {

        //  }       
    })

})

function DeleteUnit(obj, n) {
    if (n == undefined) {
        $(obj).parent().find("#UnitName").val("");
        $(obj).parent().find("#UnitID").val("");
    } else {
        $(obj).parent().find("#ResGrid_" + n + "__UnitName").val("");
        $(obj).parent().find("#ResGrid_" + n + "__UnitID").val("");
    }
   
}
function SubjectChange(obj, n) {
    var subid;
    var eid;
    var html = '';
    //////////全局学科选项///////////
    if (n == undefined) {
        subid = $("#SubjectID").val();
        if (subid) {
            eid = $("#EditionID");
            eid.empty();
            eid.append('<option selected="selected" value="">全部版本</option>');
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
                                    eid.append('<option value="' + item.ID + '">' + item.CodeName + '</option>');
                                    //if (i == 0) {
                                    //    eid.val(item.ID);
                                    //}
                                });
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
        } else {
            $("#UnitID").val("");
            $("#UnitID").parent().find(".UnitName").val("");
            $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
            $(".selectF .catalogD").html("");
        }
    }/////////////资源学科选项////////
    else {
        subid = $("#ResGrid_" + n + "__SubjectID").val();
        if (subid) {
            eid = $("#ResGrid_" + n + "__EditionID");
            eid.empty();
            eid.append('<option selected="selected" value="">全部版本</option>');
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
                                    eid.append('<option value="' + item.ID + '">' + item.CodeName + '</option>');
                                    //if (i == 0) {
                                    //    eid.val(item.ID);
                                    //}
                                });
                                if (Gedi) {
                                    eid.val(Gedi);
                                    Gedi = "";
                                }
                                EditionChange("#ResGrid_" + n + "__EditionID", n);
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
            $("#ResGrid_" + n + "__UnitID").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
            $(".selectF #catalogD-" + n + "").html("");
        }
    }
}
function EditionChange(obj, n) {
    var eid = $(obj).val();
    var grades;   
    var gradeid;
    if (n == undefined) {
        var subId = $("#SubjectID").val();
        grades = $("#GradeID");
        gradeid = grades.val();
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
                                //if (gradeid) {
                                //    grades.val(gradeid)
                                //}
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
            $("#UnitID").val("");
            $("#UnitID").parent().find(".UnitName").val("");
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
                                //if (gradeid) {
                                //    grades.val(gradeid)
                                //  }
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
    } else {
        grades = $("#ResGrid_" + n + "__GradeID");
        var subId = $("#ResGrid_" + n + "__SubjectID").val();
        // gradeid = grades.val();
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
                                GradeChange("#ResGrid_" + n + "__GradeID",n);
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
            $("#ResGrid_" + n + "__UnitID").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
            $(".selectF .catalogD-" + n + "").html("");
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
                                GradeChange("#ResGrid_" + n + "__GradeID", n);
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

}
function GradeChange(obj, n) {
    var subid;
    var eid;
    var gradeid;
    var html = '';
    if (n == undefined) {
        subid = $("#SubjectID").val();
        eid = $("#EditionID").val();
        gradeid = $("#GradeID").val();
        if (subid && eid && gradeid) {
            $.ajax({
                type: 'post',
                url: '/ResourceSearch/GetSelectBookID',
                data: { subjectId: subid, gradeId: gradeid, editionId: eid },
                dataType: 'json',
                async: false,
                success: function (result) {
                    switch (result.flag) {
                        case 1:
                            if (result.data.length != 0) {
                                $("#UnitID").val("");
                                $("#UnitID").parent().find(".UnitName").val("");
                                 $("#UnitID").parent().find(".UnitName").attr("placeholder", "请选择教材目录");
                                html += '<ul class="ulS">';
                                html += '<li class="open">';
                                if (subid == 3) {
                                    html += '<b class="unhold">&nbsp;</b><a class="up">英语全部章节</a>';
                                } else if (subid == 2) {
                                    html += '<b class="unhold">&nbsp;</b><a class="up">数学全部章节</a>';
                                } else if (subid == 1) {
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
                            $(".selectF #catalogD").html(html);
                            //树形结构选择
                          //  ShowCatalog();
                          //  CatalogFun();
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
            $("#UnitID").val("");
            $("#UnitID").parent().find(".UnitName").val("");
            $("#UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
            $(".selectF #catalogD").html("");
        }
    } else {
        subid = $("#ResGrid_" + n + "__SubjectID").val();
        eid = $("#ResGrid_" + n + "__EditionID").val();
        gradeid = $("#ResGrid_" + n + "__GradeID").val();
        if (subid && eid && gradeid) {
            $.ajax({
                type: 'post',
                url: '/ResourceSearch/GetSelectBookID',
                data: { subjectId: subid, gradeId: gradeid, editionId: eid },
                dataType: 'json',
                async: false,
                success: function (result) {
                    switch (result.flag) {
                        case 1:
                            if (result.data.length != 0) {
                                if (flag) {
                                    if ($("#UnitName").val()) {
                                        $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val($("#UnitName").val());        
                                    } else {
                                        $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
                                        $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "请选择教材目录");
                                    }
                                    flag = false;
                                } else {
                                    $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
                                     $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "请选择教材目录");
                                }                          
                                html += '<ul class="ulS">';
                                html += '<li class="open">';
                                if (subid == 3) {
                                    html += '<b class="unhold">&nbsp;</b><a class="up">英语全部章节</a>';
                                } else if (subid == 2) {
                                    html += '<b class="unhold">&nbsp;</b><a class="up">数学全部章节</a>';
                                } else if (subid == 1) {
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
                                $("#ResGrid_" + n + "__UnitID").val("");
                                $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
                                $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
                            }
                            $(".selectF #catalogD-" + n + "").html(html);
                            //树形结构选择                          
                           // ShowCatalog();
                           // CatalogFun();
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
            $("#ResGrid_" + n + "__UnitID").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").val("");
            $("#ResGrid_" + n + "__UnitID").parent().find(".UnitName").attr("placeholder", "当前没有教材目录");
            $(".selectF #catalogD-" + n + "").html("");
           
         
        }
    }
    UnShowCatalog();
    UnCatalogFun();
    ShowCatalog();
   CatalogFun();
}
