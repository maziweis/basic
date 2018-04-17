$(document).ready(function () {

    //删除
    $(document).on('click', '.btnDelete', function (e) {
        var _id = $(this).attr("dataid");
        if (confirm("您确定要删除该记录吗？")) {
            $.ajax({
                type: 'post',
                url: '/SyGrade/Delete',
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
    });

    //隐藏modal时清除数据
    $("#myModal").on("hidden.bs.modal", function () {
        $(this).removeData("bs.modal");
    });
});

function formSuccess(result) {
    if (result.success) {
        $('#myModal').modal('hide');
        location.reload();
    } else {
        $('.modal-content').html(result);
    }
}