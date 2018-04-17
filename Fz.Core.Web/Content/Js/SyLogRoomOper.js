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