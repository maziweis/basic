$(document).ready(function () {

    //var editor = UE.getEditor('container', {
    //    //这里可以选择自己需要的工具按钮名称,此处仅选择如下五个  
    //    toolbars: [[
    //         //'undo', 'redo', '|', 'fontfamily', 'fontsize', '|', 'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|',
    //         //'bold', 'italic', 'underline', '|', 'insertorderedlist', 'insertunorderedlist', '|'
            
    //    ]],
    //    //focus时自动清空初始化时的内容  
    //    autoClearinitialContent: false,
    //    //关闭字数统计  
    //    wordCount: false,
    //    //关闭elementPath  
    //    elementPathEnabled: false,
    //    //默认的编辑区域高度  
    //    initialFrameHeight: 150

    //    //更多其他参数，请参考ueditor.config.js中的配置项  
    //});
    //editor.render("Overview");
    //UE.getEditor(’myEditor’) 
    var editor = KindEditor.ready(function (K) {
        K.create('textarea[name="Overview"]', {
            resizeType: 0,
            items: [],
            width: '100%',
            height:'100px',
            afterBlur: function () { this.sync(); }
        });
        $(".schoolInfo .ke-toolbar,.schoolInfo .ke-statusbar").hide();
    });
});