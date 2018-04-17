$(".dynamicList ul li a").bind("click", function () {
    var ResId = $(this).parent().attr("id");
    var url = '/ResourcePreview/Index/' + ResId;
    window.open(url);

})