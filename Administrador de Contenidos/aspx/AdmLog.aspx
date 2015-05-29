<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AdmLog.aspx.vb" Inherits="aspx_AdmLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">    
    
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <link type="text/css" href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link type="text/css" href="css/bootstrap/bootstrap-theme.min.css" rel="stylesheet" />    
    <link type="text/css" href="css/MhiosysForm.css" rel="stylesheet" />
    <link type="text/css" href="estilos/Estilos.css" rel="stylesheet" />

    <div id="dialog-alert" style="display:none;"></div>
    <div id="question" style="display:none; cursor: default"> 
        <div class="ui-dialog-titlebar ui-widget-header"><h1>Confirmar</h1></div>
        <div style="width: auto; min-height: 0px; height: 140px;" class="ui-dialog-content ui-widget-content" scrolltop="0" scrollleft="0">
            <br /><h1>¿Está seguro que desea realizar esta operación?.</h1><br />
            <table width="100%">
                <tr>
                    <td><input type="button" style="width:100px;" class="buttonConstellation" id="yes" value="Si" /> </td>
                    <td ></td>
                    <td><input type="button" style="width:100px;" class="buttonConstellation" id="no" value="No" /></td>
                </tr>
            </table>
    
    
        </div>
    </div> 

    <div id="execution" style="display:none; cursor: default"> 
        <div class="ui-dialog-titlebar ui-widget-header"><h1>Eliminar</h1></div>
        <div style="width: auto; min-height: 0px; height: 50px;" class="ui-dialog-content ui-widget-content" scrolltop="0" scrollleft="0">
            <br /><h1>Eliminando Archivos Log...<span id="lblStatusDialog"></span></h1><br />
        </div>
    </div> 
    <div class="MhiosysForm" style="padding:20px;">
        <table class="tablelayout" style="margin:0px; width:1000px;">
            <tr>
                <td style="width:100px; text-align:right;"><b>Fecha Inicio</b></td>
                <td><input type="text" id="FechaInicio" /></td>
                <td style="width:100px; text-align:right;"><b>Fecha Fin</b></td>
                <td><input type="text" id="FechaFin" /></td>
                <td style="width:100px; text-align:right;">Tipo</td>
                <td>
                    <select  id="TipoList">
                        <optgroup label="Flash">
                        <option value="<%=ComunLayer.Enum.TipoLog.FLogAlternativo%>">LogAlternativo</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.FLogEnvioData%>">LogEnvioData</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.FLogErrorFlash%>">LogErrorFlash</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.FLogActualizacionRipleymatico%>">LogActualizacionRipleymatico</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.FLogBiometrico%>">LogBiometrico</option>
                        </optgroup>
                        <optgroup label="Web Service">
                        <option value="<%=ComunLayer.Enum.TipoLog.WSLog%>">Log</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.WSLogRMIL%>">Log_RMIL</option>
                        </optgroup>
                        <optgroup label="Web Service Impresión">
                        <option value="<%=ComunLayer.Enum.TipoLog.WSILog%>">Log</option>
                        <option value="<%=ComunLayer.Enum.TipoLog.WSICard%>">Card</option>
                        </optgroup>
                    </select>
                </td>
            </tr>
            <tr id="FilaModalidad">
                <td colspan="2"><b>Seleccionar modalidad para el(los) Kiosko(s)</b></td>
                <td><input type="radio" id="rbTodos" name="kioskos" checked="checked" value="rbTodos" />Todos </td>
                <td><input type="radio" id="rbUno" name="kioskos" value="rbUno" />Personalizado </td>
                <td><input type="radio" id="rbLima" name="kioskos" value="rbLima" />Lima </td>
                <td><input type="radio" id="rbProvincia" name="kioskos" value="rbProvincia" />Provincias </td>               
            </tr>
            <tr id="FilaKioskos" style="display:none;">
                <td colspan="6">
                    <div id="listaKioskos" class="DivKioskos"></div>
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
                <td><input type="button" class="buttonConstellation" value="Procesar" style="cursor:pointer;" id="btnProcesar" /></td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="6">
                    <div id="progressbar"></div>
                    <div id="result"></div><br/>
                    <span id="lblStatus"></span>
                </td>
            </tr>
        </table>                
    </div>    
    <%--<input type="checkbox" data-off-label="false" data-on-label="false" data-off-icon-class="glyphicon glyphicon-thumbs-down" data-on-icon-class="glyphicon glyphicon-thumbs-up">--%>
    
    <%--<script src="../js/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap-checkbox.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
    <script src="../js/BI.js" type="text/javascript"></script>
    <script src="../js/jquery.blockUI.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var modalidad = 0;
        $(document).ready(function () {
            var arrayDialog = [{ name: 'dialog-alert', height: 180, width: 350, title: 'Alerta'}];
            BI.CreateDialogs(arrayDialog);

            $("#progressbar").progressbar({ value: 0 });
            $("#progressbar").hide();
            $("#btnProcesar").click(function (e) {
                if ($("#FechaInicio").val() == "" || $("#FechaFin").val() == "") {
                    BI.ShowAlert("dialog-alert", "Debe ingresar un rango de fechas válido");
                    e.preventDefault();
                } else {
                    $.blockUI({ message: $('#question'), css: { width: '275px'} });
                }
                return false;
            });

            $('#yes').click(function () {
                $("#progressbar").progressbar({ value: 0 });
                $("#lblStatus").show();
                $.blockUI({ message: $('#execution') });

                $("#btnProcesar").prop("disabled", true);
                $("#progressbar").show();
                $("#result").html('');
                var arrayFecha = $("#FechaInicio").val().split('/');
                var fechaInicioString = arrayFecha[2] + "" + arrayFecha[1] + "" + arrayFecha[0];
                arrayFecha = $("#FechaFin").val().split('/');
                var fechaFinString = arrayFecha[2] + "" + arrayFecha[1] + "" + arrayFecha[0];

                var kioskoList = new Array();
                $("div#listaKioskos").find('input:checked').each(function (index, item) {
                    var kioskoBN = new Object();
                    kioskoBN.IpKiosco = $(this).prop("title");
                    kioskoBN.Nombre = $(this).prop("value");
                    kioskoList.push(kioskoBN);
                });

                var model = new Object();
                model.FechaInicio = fechaInicioString;
                model.FechaFin = fechaFinString;
                model.KioskoList = kioskoList;
                model.TipoLog = parseInt($("#TipoList").val());
                model.Modalidad = modalidad;

                var intervalID = setInterval(updateProgress, 250);
                $.ajax({
                    type: "POST",
                    url: "AdmLog.aspx/EliminarArchivosLog",
                    data: JSON.stringify({ model: model }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (msg) {
                        $("#progressbar").progressbar("value", 100);
                        $("#lblStatus").hide();
                        $("#result").text(msg.d);
                        clearInterval(intervalID);
                        $("#btnProcesar").prop("disabled", false);
                        $.unblockUI();
                    }
                });
            });

            $('#no').click(function () {
                $.unblockUI();
                return false;
            });

            $("#FechaInicio").prop("readonly", true);
            $("#FechaFin").prop("readonly", true);

            $("#FechaInicio").datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("#FechaFin").datepicker("option", "minDate", selectedDate);
                }
            });

            $("#FechaFin").datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("#FechaInicio").datepicker("option", "maxDate", selectedDate);
                }
            });

            $("#TipoList").change(function (e) {
                switch ($(this).val()) {
                    case ('<%=ComunLayer.Enum.TipoLog.FLogAlternativo%>'):
                    case ('<%=ComunLayer.Enum.TipoLog.FLogEnvioData%>'):
                    case ('<%=ComunLayer.Enum.TipoLog.FLogErrorFlash%>'):
                    case ('<%=ComunLayer.Enum.TipoLog.FLogActualizacionRipleymatico%>'):
                    case ('<%=ComunLayer.Enum.TipoLog.FLogBiometrico%>'):
                        $("#FilaModalidad").show();
                        if ($("#rbUno").prop("checked")) {
                            $("#FilaKioskos").show();
                        }
                        break;
                    default:
                        $("#FilaModalidad, #FilaKioskos").hide();
                        break;
                }
            });

            $("input[name='kioskos']").change(function (e) {
                switch ($(this).prop("id")) {
                    case 'rbTodos':
                        modalidad = parseInt('<%=ComunLayer.Enum.TipoModalidad.Todos%>');
                        $("#FilaKioskos").hide();
                        break;
                    case 'rbUno':
                        modalidad = parseInt('<%=ComunLayer.Enum.TipoModalidad.Personalizado%>');
                        $("#FilaKioskos").show();
                        break;
                    case 'rbLima':
                        modalidad = parseInt('<%=ComunLayer.Enum.TipoModalidad.Lima%>');
                        $("#FilaKioskos").hide();
                        break;
                    case 'rbProvincia':
                        modalidad = parseInt('<%=ComunLayer.Enum.TipoModalidad.Provincia%>');
                        $("#FilaKioskos").hide();
                        break;
                    default:
                        modalidad = parseInt('<%=ComunLayer.Enum.TipoModalidad.Todos%>');
                        $("#FilaKioskos").hide();
                        break;
                }


                //                if ($(this).prop("id") == "rbUno") {
                //                    $("#FilaKioskos").show();
                //                } else {
                //                    $("#FilaKioskos").hide();
                //                }
            });

            obtenerListaKioskos();
        });

        function updateProgress() {
            var value = $("#progressbar").progressbar("option", "value");
            if (value < 100) {
                $("#progressbar").progressbar("value", value + 1);
                $("#lblStatus").text((value + 1).toString() + "%");
                $("#lblStatusDialog").text((value + 1).toString() + "%");                
            }
        }

        function obtenerListaKioskos() {
            $.ajax({
                type: "POST",
                url: "AdmLog.aspx/ObtenerListaKioskos",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (response) {
                    var respuesta = response.d;
                    $.each(respuesta.Data, function (index, item) {
                        $("#listaKioskos").append("<input type='checkbox' title='" + item.IpKiosco + "' id='" + item.Id + "' value='" + item.Nombre + "' /> " + item.Nombre + "<br/>");
                    });
                    $(':checkbox').checkboxpicker();
                }
            });
        }     
        
    </script>
</asp:Content>

