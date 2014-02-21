BI = {  
    ValidarDecimal: function (numero) {
        var patron = /^([0-9])*[.]?[0-9]*$/;
        if (patron.test(numero))
            return true;
        return false;
    },

    ValidarFecha: function (fecha) {
        var patron = /^((([0][1-9]|[12][\d])|[3][01])[-\/]([0][13578]|[1][02])[-\/][1-9]\d\d\d)|((([0][1-9]|[12][\d])|[3][0])[-\/]([0][13456789]|[1][012])[-\/][1-9]\d\d\d)|(([0][1-9]|[12][\d])[-\/][0][2][-\/][1-9]\d([02468][048]|[13579][26]))|(([0][1-9]|[12][0-8])[-\/][0][2][-\/][1-9]\d\d\d)$/;
        if (patron.test(fecha))
            return true;
        return false;
    },

    ValidarEntero: function (numero) {
        var patron = /^\d+$/;
        if (patron.test(numero))
            return true;
        return false;
    },

    ShowAlert: function (dialog, mensaje) {
        if (dialog == '') {
            dialog = 'dialog-alert';
        }

        $('#' + dialog).html("");
        $('#' + dialog).append("<br/>" + mensaje);
        $('#' + dialog).dialog("open");
    },
    CreateDialogs: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            $("#" + arrayDialog[i].name).dialog({
                autoOpen: false,
                resizable: false,
                closeOnEscape:true,
                height: arrayDialog[i].height,
                width: arrayDialog[i].width,
                title: arrayDialog[i].title,
                modal: true,
                open: function () {
                    //$(this).parent().appendTo($('#aspnetForm'));
                },
                close: function () {
                    var name = $(this).attr('id');
                    $.each(arrayDialog, function (index, v) {
                        if (v.name == name) {
                            if (v.closePopUp != null && typeof (v.closePopUp) == "function") {
                                v.closePopUp(name);
                                //return false;
                            }
                            else {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
            });
        }
    },
    CreateDialogLog: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            $("#" + arrayDialog[i].name).dialog({
                autoOpen: false,
                resizable: true,
                closeOnEscape: false,
                height: arrayDialog[i].height,
                width: arrayDialog[i].width,
                title: arrayDialog[i].title,
                modal: false,
                open: function () {
                    //$(this).parent().appendTo($('#aspnetForm'));
                },
                close: function () {
                    var name = $(this).attr('id');
                    $.each(arrayDialog, function (index, v) {
                        if (v.name == name) {
                            if (v.closePopUp != null && typeof (v.closePopUp) == "function") {
                                v.closePopUp(name);
                                //return false;
                            }
                            else {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
            });
        }
    },
    AjaxJson: function (type, url, parameters, async, methodSuccess) {
        var rsp;
        $.ajax({
            type: type,
            url: url,
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: async,
            data: JSON.stringify(parameters),
            success: methodSuccess,
            failure: function (msg) {
                rsp = -1;
            }
        });
        return rsp;
    }
};