LMS.EntityBase = {
    Configurations: function () {
        this.EntityURL = '';
    },
    PageName: function () {
        return window.URL;
    },
    ShowMessageBox: function (title, message) {
        jQuery.fancybox({
            'modal': true,
            'content': "<div style=\"margin:1px;width:240px;\">" + message + "<div style=\"text-align:right;margin-top:10px;\"><input style=\"margin:3px;padding:0px;\" type=\"button\" onclick=\"jQuery.fancybox.close();\" value=\"Ok\"></div></div>"
        });
    }
};