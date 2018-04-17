$(function () {
    $(".searchC .searchD a").unbind("");
    $(".searchC .searchD a").bind("click", function () {
        $("#form1").submit();
    });
    $(".panel-group .panel-default:first-child .panel-heading").addClass("on");

    // 基于准备好的dom，初始化echarts实例
    $.ajax({
        type:"post",
        url: '/ResourceHome/GetResourceStatic',
        dataType: 'json',
        success: function (result) {
            switch (result.flag) {
                case 1:
                    if (result.data.length != 0) {
                        idata = [];
                        for (var i = 0; i < result.data.length; i++) {
                            if (0 == i) {
                                SchoolText;
                                SchoolText.push(result.data[i].CodeName + result.data[i].ID);
                            } else {
                                var subjectStatic;
                                subjectStatic = { "value": result.data[i].ID, "name": result.data[i].CodeName };
                                idata.push(subjectStatic);

                            }

                        }
                        var myChart = echarts.init(document.getElementById('mainChart'));
                        // 指定图表的配置项和数据
                        option = {
                            title: {
                                text: SchoolText,
                                x: 'center',
                                y: 'top'
                            },
                            tooltip: {
                                trigger: 'item',
                                formatter: "{a} <br/>{b}: {c} ({d}%)"
                            },
                            legend: {
                                orient: 'vertical',
                                x: 'left',
                                y: '30px',
                                data: idata
                            },
                            series: [
                                {
                                    name: '资源总量',
                                    type: 'pie',
                                    radius: ['50%', '70%'],
                                    avoidLabelOverlap: false,
                                    label: {
                                        normal: {
                                            show: false,
                                            position: 'center'
                                        },
                                        emphasis: {
                                            show: true,
                                            textStyle: {
                                                fontSize: '30',
                                                fontWeight: 'bold'
                                            }
                                        }
                                    },
                                    labelLine: {
                                        normal: {
                                            show: false
                                        }
                                    },
                                    data: idata
                                }
                            ]
                        };
                        // 填充数据
                        myChart.setOption(option);
                    } else {
                        alert("暂无数据！");
                    }
                    break;
            }
        }
    });
})

var idata = []; //[{ value: 335, name: '语文' }, { value: 310, name: '数学' }, { value: 1000, name: '外语' }, { value: 135, name: '物理' }, { value: 548, name: '化学' }, { value: 1000, name: '生物' }, { value: 80, name: '政治' }, { value: 348, name: '历史' }, { value: 148, name: '地理' }];
var SchoolText = [];
function SubjectChange(obj) {
    var SubjectID = $(obj).val();
    var html = '';
    $.ajax({
        type: 'post',
        url: '/ResourceHome/GetResourceDynamic',
        data: { SubjectId: SubjectID },
        dataType: 'json',
        async: false,
        success: function (result) {
            switch (result.flag) {
                case 1:
                    if (result.data.length != 0) {
                        $.each(result.data, function (i, item) {
                            if (item.DynamicType == 1) {
                                if (item.ResourceList.length > 0) {
                                    html += '<li id="' + item.ResourceList[0].ResourceUrl + '">资源分享：' + item.ResourceList[0].ResourceName + '</li>';
                                }
                            } else if (item.DynamicType == 2) {
                                if (item.ResourceList.length > 0) {
                                    html += '<li id="' + item.ResourceList[0].ResourceUrl + '">资源收藏：' + item.ResourceList[0].ResourceName + '</li>';
                                }

                            } else if (item.DynamicType == 3) {
                                if (item.ResourceList.length > 0) {
                                    html += '<li id="' + item.ResourceList[0].ResourceUrl + '">资源下载：' + item.ResourceList[0].ResourceName + '</li>';
                                }
                            }
                        });                     
                        if (result.data[0].ResourceList.length > 0 || result.data[1].ResourceList.length > 0 || result.data[2].ResourceList.length > 0) {
                            $(".moreA").html('更多<b>…</b>');
                            $(".moreA").attr("href", "/ResourceDynamic/Index/" + SubjectID);
                        } else {
                            html += '<li><div class="emptyTip">暂时没有动态...</div> </li>';
                            $(".moreA").html('');
                            $(".moreA").removeAttr("href");
                        }
                        $(".dynamicUl").html(html);
                    }
                    break;
            }
        }
    });
}


 
