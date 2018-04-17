function DownLoad(id) {
    if (id) {
        $.ajax({
            type: 'post',
            url: '/ResourcePreview/GetResourceById',
            data: { ResId: id },
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
                                var url = "/api/Download/" + id;
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