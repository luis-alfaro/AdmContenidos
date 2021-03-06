﻿BI = {
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
    confirm: function (dialogText, okFunc, cancelFunc, dialogTitle) {
        $('<div style="padding: 10px; max-width: 500px; min-width: 300px; word-wrap: break-word;">' + dialogText + '</div>').dialog({
            //draggable: false,
            modal: true,
            resizable: false,
            width: 'auto',
            title: dialogTitle || 'Confirmación',
            minHeight: 75,
            buttons: {
                OK: function () {
                    if (typeof (okFunc) == 'function') { setTimeout(okFunc, 50); }
                    $(this).dialog('destroy');
                },
                Cancel: function () {
                    if (typeof (cancelFunc) == 'function') { setTimeout(cancelFunc, 50); }
                    $(this).dialog('destroy');
                }
            }
        });
    },
    CreateDialogs: function (arrayDialog) {

        for (var i = 0; i < arrayDialog.length; i++) {
            $("#" + arrayDialog[i].name).dialog({
                autoOpen: false,
                resizable: false,
                closeOnEscape: true,
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
    },
    MostrarLoading: function () {
        $.blockUI({
            message: 'Por favor espere un momento...',
            theme: false,
            baseZ: 2000,
            css: {
                border: 'none',
                padding: '20px',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .6,
                color: '#000',
                'font-size': '12pt',
                'font-weight': 'bold'
            }
        });
    },
    OcultarLoading: function () {
        $.unblockUI();
    }
};
String.prototype.endsWith = function (pattern) {
    var d = this.length - pattern.length;
    return d >= 0 && this.lastIndexOf(pattern) === d;
};