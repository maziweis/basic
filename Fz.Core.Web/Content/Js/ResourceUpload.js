var resourceUpload;
$(function () {
    resourceUpload = new ResourceUpload();
    resourceUpload.Init();
    $(".panel-group .panel-default:eq(3)").find(".panel-heading").addClass("on");
});
function isIE() { //ie?
    if (!!window.ActiveXObject || "ActiveXObject" in window)
        return true;
    else
        return false;
}
var ResourceUpload = function () {
    var Current = this;
    this.file_Url;
    this.UpLoadResourceList = [];
    this.SelectFileNum = 0;
    this.Init = function () {
        //Current.file_Url = $("#FileServerUrl").val();
        Current.file_Url = "/api/Upload";
        Current.InitUpLoad();    
    }
    this.InitUpLoad = function () {
        ////上传文件到测试服务器
        $('#uploadFile').uploadify({
            width: 145,
            height: 30,
            queueSizeLimit: 20,
            uploadLimit: 20,
            fileSizeLimit: '50MB',
            buttonText: "选择上传资源",
            fileTypeExts: '*.*;',
            auto: false,
            multi: true,
            requeueErrors: true,
            overrideEvents:['onDialogClose','onSelectError' ],
            cancelImg: '/Content/Tools/uploadify/uploadify-cancel.png',
            progressData: 'percentage',
            swf: '/Content/Tools/uploadify/uploadify.swf',
            uploader: Current.file_Url,//Current.file_Url + 'UploadHandler.ashx?rand=' + Math.random(),
            onSelect: function (file) {              
                $(".step2 .img").hide();
                $(".step2 #uploadFile-queue").css("visibility", "hidden");
                $(".step2 .tips").hide();              
                if (isIE()) {
                    $("#uploadFile").attr("style", "width:0px;height:0px;overflow:hidden");
                } else {
                    $("#uploadFile").css("visibility", "hidden");
                }             
                Current.SelectFileNum++;
                $(".resourceList1 .step1").show();
                var html = '';
                html += '<tr id="Key' + file.index + '"><td><font>' + Current.SelectFileNum + '</font></td>';
                html += '<td>' + unescape(file.name) + '</td>';
                html += ' <td>' + file.type + '</td>';
                html += '<td>' + Math.floor(file.size / 1024) + 'KB</td>';
                html += '<td id="res' + file.index + '">0%</td>';
                html += '<td><a class="deleA" onclick="resourceUpload.del(\''+ file.id + '\')">删除</a></td>';
                html += '</tr>';
                $("#uploadContent").append(html);
                if (file.name.length >= 50) {
                    openAlert("提示", "文件名过长，请修改文件名再上传！");
                    resourceUpload.del(file.id);
                    return false;
                }
            },
            onCancel: function (file) {
                Current.SelectFileNum--;
                var div = $("#res" + file.index).parent();
                $(div).remove();
                if (Current.SelectFileNum == 0) {
                    $(".resourceList1 .step1").hide();
                    $(".step2 .img").show();
          //          $(".step2 #uploadFile-queue").show();
                    $(".step2 .tips").show();                  
                    if (isIE()) {
                        $(".uploadify-queue").css("margin-bottom", "10px");
                        $("#uploadFile").attr("style", "height:35px;width: 120px");
                    } else {
                       $("#uploadFile").css("visibility", "visible");
                    }             
                }                 
            },
            //////上传进度////////
            onUploadProgress: function (file, fileBytesLoaded, fileTotalBytes) {
                var timer = new Date();
                var newTime = timer.getTime();
                var lapsedTime = newTime - this.timer;
                if (lapsedTime > 1000) {
                    this.timer = newTime;
                }
                $("#res" + file.index).html(Math.round(fileBytesLoaded / fileTotalBytes * 100)+ "%");
            },
            //////////资源上传成功执行//////////
            onUploadSuccess: function (file, data, respone) {
                if (respone) {
                    data = $.parseJSON(data);
                    if (data.Success) {
                        Current.UpLoadResourceList.push(data.Data);
                    }                   
                }
            },
            //////////资源上传失败执行//////////
            onUploadError: function (file, errorCode, erorMsg, errorString) {           
                //alert(erorMsg);
            },
            /////////////选择文件报错
            onSelectError: function (file, errorCode, erorMsg, errorString) {
                switch (errorCode) {
                    case -100:
                        openAlert("提示", "选择上传的文件不可以超过" + erorMsg + "个！");
                        break;
                    case -110:
                        openAlert("提示", "选择上传的单个文件大小超过50M将无法加入到上传队列！");
                        break;
                    case -120:
                        openAlert("提示", "上传文件是空的");
                        break;                 
                    default:
                        break;
                }
            },
            //////////所有资源上传完毕后执行//////////
            onQueueComplete: function (queueData) {
                if (Current.UpLoadResourceList.length != 0) {                  
                    window.location.href = "/ResourceUpLoad/Add?ResourceList=" + encodeURIComponent(JSON.stringify(Current.UpLoadResourceList));
                } else {
                    alert("资源上传失败！")
                   // $(".step2 .img").show();
                   // $(".step2 #uploadFile-queue").show();
                   //$(".step2 .tips").show();
                   // $("#uploadFile").css("visibility", "visible");
                }
            }
        });
    };
    this.del = function (id) {      
        $('#uploadFile').uploadify('cancel', id);
    };
}