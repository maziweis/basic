function back() {
    history.back(-1);
}

function exit() {
    openConfirm("提示", "您确定要退出系统吗？", "worm", function () {
        $.ajax({
            type: 'post',
            url: '/SyPassport/Exit',
            dataType: 'json',
            success: function (result) {
                switch (result.flag) {
                    case 1:
                        window.location = "/SyPassport/Login";
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
    });
}

function closeDialog() {
    parent.$('#dlg1').FzDialog("close");
}

// 
//  layout.js
//  智慧校园
//  
//  Created by yaxiong.tang on 2017-02-14.
//  Copyright 2017 yaxiong.tang. All rights reserved.
// 
$.fn.isChildAndSelfOf = function (b) {
    return (this.closest(b).length > 0);
};

$(function () {
    //页头系统菜单显隐方法调用
    labelCheck();
    SNavChange();
    //左侧菜单显隐方法调用
    ChangeNav();
    $('input, textarea').placeholder();
    //$(window).scroll(function () {
    //    var srollPos = $(window).scrollTop(); //滚动条距顶部距离(页面超出窗口的高度) 
    //    var totalheight = parseFloat($(".header").height()) + parseFloat($(".topCont").height()) + 34 + 10;
    //    if (srollPos > totalheight) {
    //        $(".leftCont").css({ "position": "fixed", "top": "10px", "z-index": "1800" });
    //    }
    //    else {
    //        $(".leftCont").attr("style","");
    //    }
    //});
    $("body").click(function (event) {
        var e = event || window.event || e; // 兼容IE7
        var obj = $(e.srcElement || e.target);
        if ($(obj).isChildAndSelfOf(".selectF")) {

        } else {
            $(".selectF").removeClass("down");
        }
    });

})

function labelCheck() {
    $("label.checkbox").not(".enable").bind("click", function () {
        $this = $(this);
        if ($this.find("input:checkbox").is(":checked")) {
            $this.addClass("on");
        }
        else {
            $this.removeClass("on");
        }
    })
    $("label.checkbox input:checkbox").each(function () {
        $this = $(this);
        if ($this.is(":checked") && $this.attr("enable") == "false") {
            $this.parent().addClass("enable");
        }
        else if ($this.is(":checked")) {
            $this.parent().addClass("on");
        }
        
        
    })
}


//输入框切换状态
function ChangeVal(obj, str) {
    $(obj).focus(function () {
        if ($(this).val() == str) {
            $(this).val("");
            $(this).css("color", "#666");
        }
    }).blur(function () {
        if ($(this).val() == "") {
            $(this).val(str);
            $(this).css("color", "#999");
        }
    })
}

//主框架左侧菜单栏的动作效果
function ChangeNav() {
    //一级菜单点击效果
    $(".panel-group .panel-default").each(function () {
        if ($(this).find(".list-group-item").length == 0) {
            $(this).find(".panel-body").css("border-bottom", "0");
            $(this).find(".panel-heading").mouseenter(function () {
                $(this).addClass("hover");
            }).mouseleave(function () {
                $(this).removeClass("hover");
            })
        }
    })
}
//页头系统菜单的显隐效果
function SNavChange() {
    $(".sNavUl .li2").hover(function () {
        $(this).find('a').addClass("on");
        $(this).find("div.spanCont").slideDown();
    }, function () {
        $(this).find("div.spanCont").stop().slideUp(function () {
            $(this).prev('a').removeClass("on");
        });

    })
    var rightW = $(".sNavUl .li3").width() + $(".sNavUl .li4").width();
    $(".sNavUl .li2 .spanCont").css("right", rightW+"px");
}

//热门资源搜索
function HotSearchF() {
    $(".searchTips span b").bind("click", function () {
        var searchHotStr = $(this).text();
        console.log($(this).text());
        alert("" + searchHotStr + "-关键字跳转！");
    })
}

function UnShowCatalog() {
    $(".selectF input").unbind("click");
}
function UnCatalogFun() {
    $(".catalogD ul li a").unbind("click");
}

//树形结构的显隐
function ShowCatalog() {
    //唤醒树形目录结构
    $(".selectF input").on("click", function () {
        $(".selectF").removeClass("down");
        $(this).parent().addClass("down");
    })
}
//树形结构
function CatalogFun() {
    //选择目录
    $(".catalogD ul li a").on("click", function () {
        $(this).parents(".catalogD").find("a").removeClass("on");
        $(this).addClass("on");
        $(this).toggleClass("up");
        $(this).parent().toggleClass("open");
        $(this).prev("b").toggleClass("unhold");
        if ($(this).parent().children("ul").length == 0) {
            var txt = $(this).text();
            var id = $(this).attr("id");
            $(this).parents(".selectF").removeClass("down");
            $(this).parents(".selectF").find(".UnitName").val(txt);
            $(this).parents(".selectF").find(".UnitID").val(id);
        }
    });
    $(".catalogD ul li").each(function () {
        if ($(this).children("ul").length == 0) {
            $(this).find("a").prev("b").addClass("nothing");
        }
        else {
            $(this).find("a").prev("b").removeClass("nothing");
        }
    });
}

//筛选条件选择
function FilterSelect() {
    $(".filterCont ul li a").on("click", function () {
        if ($(this).attr("class") != "on") {
            $(this).parent().parent().find("a").removeClass("on");
            $(this).addClass("on");
        }
        $(this).parent().parent().find("input").val($(this).attr("id"));
        if (!$(this).parent().parent().parent().attr("id")) {
            $('#GridList_Pager_PageIndex').val(1);
            $("#form1").submit();
        }
          
    })
}

//点击选中事件
function ClickFun(obj) {
    $(obj).on("click", function () {
        var s = $(this)[0].tagName;
        $(this).parent().find(s).removeClass("on");
        $(this).addClass("on");
    })
}

//全选 反选
function SelectCheckbox() {
    var flag = false;
    $(".tableBody .tableRow .checkbox").on("click", function () {
        var target = $(this).parents(".tableBody").prev().find(".selectAll");
        var $this = $(this);
        if ($this.hasClass("on")) {
            uncheck($this);
        }
        else {
            checked($this);
        }
        $(".tableBody .tableRow .checkbox").each(function () {
            if ($(this).hasClass("on")) {
                flag = true;
            }
            else {
                flag = false;
                return flag;
            }
        });
        if (flag) {
            checked(target);
        }
        else {
            uncheck(target);
        }
    });
    $(".tableHead .selectAll").on("click", function () {
        var $all = $(".tableBody .tableRow .checkbox");
        var $this = $(this);
        if ($this.hasClass("on")) {
            uncheck($this);
            uncheck($all);
        }
        else {
            checked($this);
            checked($all);
        }
    });
}

//零散CheckBox选中取消操作
function modalSelect() {
    $(".form-group .checkbox").on("click", function () {
        var $this = $(this);
        if ($this.hasClass("on")) {
            uncheck($this);
        }
        else {
            checked($this);
        }
    })
}
function checked(obj) {
    obj.find("input[type='checkbox']").prop("checked", 'true');
    obj.addClass("on");
}
function uncheck(obj) {
    obj.find("input[type='checkbox']").removeAttr("checked");
    obj.removeClass("on");
}

//简易提示框
function openAlert(title, tip) {
    var htmlStr = '<div class="modal fade popupCSS alertModal"><div class="modal-dialog" style="width:300px;">';
    htmlStr += '<div class="modal-content"><div class="modal-header">';
    htmlStr += '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>';
    htmlStr += '<h4 class="modal-title">' + title + '</h4></div>';
    htmlStr += '<div class="modal-body"><p>' + tip + '</p></div>';
    htmlStr += '<div class="modal-footer"><button type="button" class="btn btn-default" data-dismiss="modal">确定</button></div>'
    htmlStr += '</div></div></div>';
    $("body").append(htmlStr);
    $(".alertModal").modal("show");
    $(".alertModal").on("hidden.bs.modal", function (e) {
        $(this).remove();
    })
}
//询问弹框
function openConfirm(title, tip, icon, callback) {
    if (icon == undefined) icon = "";
    var htmlStr = '<div class="modal fade popupCSS dialogModal"><div class="modal-dialog" style="width:300px;">';
    htmlStr += '<div class="modal-content"><div class="modal-header">';
    htmlStr += '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>';
    htmlStr += '<h4 class="modal-title">' + title + '</h4></div>';
    htmlStr += '<div class="modal-body"><p><i  class="icon ' + icon + '"></i>' + tip + '</p></div>';
    htmlStr += '<div class="modal-footer"><button type="button" class="btn btn-default sure" data-dismiss="modal">确定</button><button type="button" class="btn btn-default cancel" data-dismiss="modal">取消</button></div>'
    htmlStr += '</div></div></div>';
    $("body").append(htmlStr);
    $(".dialogModal").modal("show");
    $('.modal-footer .btn.sure').on("click",function () {
        callback();
    });
    $(".dialogModal").on("hidden.bs.modal", function (e) {
        $(this).remove();
    })
}

//自动关闭提示框
function openTimeAlert(title, tip, icon) {
    var t;
    if (icon == undefined) icon = "";
        var htmlStr = '<div class="modal fade popupCSS alertTimeModal"><div class="modal-dialog" style="width:300px;">';
        htmlStr += '<div class="modal-content"><div class="modal-header">';
        htmlStr += '<h4 class="modal-title">' + title + '</h4></div>';
        htmlStr += '<div class="modal-body"><p><i  class="icon ' + icon + '"></i>' + tip + '</p></div>';
        htmlStr += '</div></div></div>';
        $("body").append(htmlStr);
        $(".alertTimeModal").modal("show");
        clearTimeout(t);
        t = setTimeout(function () {
            $(".alertTimeModal").modal("hide");
        }, 2000);//2秒后自动关闭
        $(".alertTimeModal").on("hidden.bs.modal", function (e) {
            $(this).remove();
        })
}
