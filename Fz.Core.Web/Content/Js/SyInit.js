function fileChange(target) {
    var fileSize = 0;
    if (target.files) {
        fileSize = target.files[0].size;
    }  
    var size = fileSize / 1024;
    if (size > 2048) {
        openAlert("提示","文件不能大于2M");
        target.value = "";
        return
    }
    var name = target.value;
    var fileName = name.substring(name.lastIndexOf(".") + 1).toLowerCase();
    if (fileName != "jpg" && fileName != "jpeg" && fileName != "png") {
        openAlert("提示", "请选择图片格式文件上传(支持jpg,png,jpeg)！");
        target.value = "";
        return
    }
}