function datosAjax(fn, paramArray, successFn, errorFn)
{
    var paramList = "";
    if (paramArray.length > 0){
        for (var i = 0; i < paramArray.length; i+=2){
            if (paramList.length > 0) paramList += ",";
            paramList += "'" + paramArray[i] + "':'" + paramArray[i+1] + "'";
        }
    }
    paramList = "{" + paramList + "}";
    $.ajax({
        type: "POST",
        url: fn, 
        contentType: "application/json; charset=utf-8",
        data: paramList, 
        dataType: "json",
        success: successFn, 
        error: errorFn
    });
}

function cargarFlexiGrid(tabla, alto, colModelo){ 
    $("#" + tabla).flexigrid({
        height:alto,
        resizable: false,
        showToggleBtn: false,
        nowrap:false,
        colModel: colModelo
    });
}

function margenflexi(tabla, alto) {
    galto = $("#" + tabla).height();
    if (alto >= galto)
	    $("#" + tabla).parent().css({ "padding-right": "16px" });    
	else if (alto < galto)
	    $("#" + tabla).parent().css({ "padding-right": "0px" });
}
function cargarDatePicker(ctrl) {
    $(ctrl).datepicker(
        {
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            showMonthAfterYear: false,
            showOn: 'button',
            buttonImage: 'img/calendar.gif',
            buttonImageOnly: true,
            buttonText: 'Seleccionar fecha'
        },
        $.datepicker.regional['es']
    );
}

function validarFecha(Cadena){  
    var Fecha = new String(Cadena);
    var RealFecha = new Date();
    var Ano= new String(Fecha.substring(Fecha.lastIndexOf("/") + 1, Fecha.length));
    var Mes= new String(Fecha.substring(Fecha.indexOf("/") + 1, Fecha.lastIndexOf("/")));
    var Dia= new String(Fecha.substring(0,Fecha.indexOf("/")));
    
    if (isNaN(Ano) || Ano.length < 4 || parseFloat(Ano) < 1900){  
        alert('Año inválido');
        return false;
    }
    if (isNaN(Mes) || parseFloat(Mes) < 1 || parseFloat(Mes) > 12){  
        alert('Mes inválido');
        return false;
    }
    if (isNaN(Dia) || parseInt(Dia, 10) < 1 || parseInt(Dia, 10) > 31){  
        alert('Día inválido');
        return false;
    }
    if (Mes == 4 || Mes == 6 || Mes == 9 || Mes == 11 || Mes == 2) {  
        if ((Ano % 4) != 0 && Mes == 2 && Dia > 28 || Dia > 30) {  
            alert('Día inválido');
            return false;
        }
        else if ((Ano % 4) == 0 && Mes == 2 && Dia > 29 || Dia > 30) {  
            alert('Día inválido');
            return false;
        } 
    }
    return true;
}

function habilitarControl(idcontrol, flag) {
    if (flag == true)
        $(idcontrol).removeAttr("disabled");
    else
        $(idcontrol).attr("disabled","-1");
}

function dialogo(capa, ancho, alto, titulo) {
    $(capa).removeClass("oculto");
    $(capa).dialog('open');
    $(capa).dialog({
        bgiframe: true,
        draggable: true,
        title: titulo,
        width: ancho,
        height: alto,
        position: 'center',
        modal: true,
        resizable: false,
        hide: 'slide',
        overlay: {
            backgroundColor: '#336699',
            opacity: 0.5
        },
        create: function(){
            $(capa).parent().appendTo("form[0]");
        },
        close: function() {
            $(capa).addClass("oculto");
            $(capa).dialog('destroy');
        }
    });
}


function bloquear(capa){
    $(capa).block({ 
        message: '<h1>Procesando...</h1>', 
        css: { 
            'border': '1px solid #999999'
        } 
    });
}