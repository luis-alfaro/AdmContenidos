<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MantSimDepositoPlazo.aspx.vb" Inherits="aspx_MantSimDepositoPlazo"
    Title="Mantenedor Simulador Depósito Plazo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Tiempos) </title>
        <script src="../js/BI.js" type="text/javascript"></script>
        <link rel="stylesheet" href="estilos/estilos.css" type="text/css" />
        <link href="../estilos/redmond/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
        <link href="../estilos/redmond/ui.jqgrid.css" rel="stylesheet" type="text/css" />
        <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
        <script src="../js/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
        <script src="../js/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
        <script src="../js/jquery.jqGrid.min.js" type="text/javascript"></script>
        <script src="../estilos/jqgrid/js/i18n/grid.locale-en.js" type="text/javascript"></script>
        <script src="../estilos/jqgrid/js/i18n/grid.locale-es.js" type="text/javascript"></script>
        <script src="../js/jquery.validate.js" type="text/javascript"></script>
        <script src="../js/jquery.validate.unobtrusive.js" type="text/javascript"></script>
        <script src="../js/JSLINQ.js" type="text/javascript"></script>
        <script src="../js/jquery.unobtrusive-ajax.js" type="text/javascript"></script>
        <script src="../js/jquery.validate.realTime.js" type="text/javascript"></script>
        <script src="../js/jquery.multiselect.js" type="text/javascript"></script>
        <script src="../js/jquery.multiselect.filter.js" type="text/javascript"></script>

        <script type="text/javascript">
            var tablaMantenimiento = "tablaMantenimiento";
            var dialogAlter = 'dialog-alert';
            var lista = new Array();
            var IDRow = 0, IDCol = 0, valorPrevio = 0;
            $(function () {
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Administrador de Contenidos'}];
                BI.CreateDialogs(arrayDialog);

                $("#guardar").bind("click", function () {
                    GuardarSimulador();
                });

                CrearTabla("#" + tablaMantenimiento);
                dibujarTabla();
            });

            function CrearTabla(tabla) {
                var c = ['IDDPF', 'Moneda', 'Descripción', 'Plazo Mínimo', 'Plazo Máximo', 'TEA', 'TREA', 'TEA2', 'TREA2'
                ,'Monto Límite', 'Monto Mínimo', 'Monto Máximo'];
                var cm = [
            { name: 'IDDPF', index: 'IDDPF', width: 12, align: 'center', hidden: true },
            { name: 'MONEDA_TEXT', index: 'MONEDA_TEXT', width: 85, align: 'center' },
            { name: 'DESCRIPCION', index: 'DESCRIPCION', width: 200, align: 'center' },
            { name: 'PLAZO_MIN', index: 'PLAZO_MIN', width: 85, align: 'center', editable: true, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 0} },
            { name: 'PLAZO_MAX', index: 'PLAZO_MAX', width: 85, align: 'center', editable: true, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 0} },
            { name: 'TEA', index: 'TEA', width: 50, align: 'center', editable: true, formatter: 'currency', formatoptions: { decimalSeparator: ",", decimalPlaces: 2, suffix: "%"} },
            { name: 'TREA', index: 'TREA', width: 50, align: 'center', editable: true, formatter: 'currency', formatoptions: { decimalSeparator: ",", decimalPlaces: 2, suffix: "%"} },
            { name: 'TEA2', index: 'TEA2', width: 50, align: 'center', editable: true, formatter: 'currency', formatoptions: { decimalSeparator: ",", decimalPlaces: 2, suffix: "%"} },
            { name: 'TREA2', index: 'TREA2', width: 50, align: 'center', editable: true, formatter: 'currency', formatoptions: { decimalSeparator: ",", decimalPlaces: 2, suffix: "%"} },
            { name: 'MONTO_LIM', index: 'MONTO_LIM', width: 100, align: 'center', editable: true, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 2} },
            { name: 'MONTO_MIN', index: 'MONTO_MIN', width: 100, align: 'center', editable: true, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 2} },
            { name: 'MONTO_MAX', index: 'MONTO_MAX', width: 100, align: 'center', editable: true, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 2} }
        ];
                tableToGrid(tabla, {
                    colNames: c,
                    colModel: cm,
                    width: 900,
                    height: 500,
                    datatype: 'local',
                    cellsubmit: "clientArray",
                    rowNum: 28,
                    pgbuttons: false,
                    viewrecords: true,
                    viewGrid: true,
                    cellEdit: true,
                    hidegrid: false,
                    pager: '#barraMantenimiento',
                    beforeEditCell: function (rowid, cellname, value, iRow, iCol) {
                        IDRow = iRow;
                        IDCol = iCol;
                        valorPrevio = value;
                    },
                    afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                            var row = jQuery("#" + tablaMantenimiento).getRowData(rowid);
                            if (!BI.ValidarDecimal(value)) {
                                row[cellname] = valorPrevio;
                                jQuery("#" + tablaMantenimiento).jqGrid('setRowData', rowid, row);
                            }

                            if (parseFloat(row['MONTO_MIN']) > parseFloat(row['MONTO_MAX'])) {
                                alert("El valor Ingresado no es válido, el monto máximo debe ser mayor al monto mínimo");
                                row[cellname] = valorPrevio;
                                jQuery("#" + tablaMantenimiento).jqGrid('setRowData', rowid, row);
                            }
                            if (parseFloat(row['PLAZO_MIN']) > parseFloat(row['PLAZO_MAX'])) {
                                alert("El valor Ingresado no es válido, el plazo máximo debe ser mayor al plazo mínimo");
                                row[cellname] = valorPrevio;
                                jQuery("#" + tablaMantenimiento).jqGrid('setRowData', rowid, row);
                            }
                    },
                    afterEditCell: function afterEditCell(rowID, cellname, value, iRow, iCol) {
                        $("#" + this.id + " tbody>tr:eq(" + iRow + ")>td:eq(" + iCol + ") input, select, textarea").select();
                    }
                });

                jQuery("#" + tablaMantenimiento).jqGrid('navGrid', '#barraMantenimiento',
            { edit: false, add: false, del: false, search: false, refresh: true },
            {}, // edit options
            {}, // add options
            {}, //del options
            {multipleSearch: true }, // search options
            {}
        );
                $(tabla).trigger('reloadGrid');
            }


            function dibujarTabla() {
                $.ajax({
                    type: "POST",
                    url: "MantSimDepositoPlazo.aspx/Obtener_SIM_DepositoPlazo",
                    data: null,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        var res = result.hasOwnProperty("d") ? result.d : result;
                        $.each(res, function (index, campo) {
                            jQuery("#" + tablaMantenimiento).jqGrid('addRowData', index, campo);
                        });

                    }
                });
                $("#" + tablaMantenimiento).trigger('reloadGrid');
            }
            function GuardarSimulador() {
                $("#" + tablaMantenimiento).jqGrid("saveCell", IDRow, IDCol);
                lista = jQuery("#" + tablaMantenimiento).jqGrid('getRowData');
                var data = { lista: lista };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "MantSimDepositoPlazo.aspx/Guardar_SIM_DepositoPlazo",
                    data: dataVal,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        var res = result.hasOwnProperty("d") ? result.d : result;
                        if (res == 1) {
                            BI.ShowAlert('',"Los datos se guardaron con éxito.");
                        }
                        else {
                            BI.ShowAlert('',"Ocurrió un error, intentelo nuevamente.");
                        }

                    }
                });
            }
        </script>
        <div id='dialog-alert' style="display: none">   
        </div>
        <div style="margin-left: 10px; padding: 10px;">
            <table>
            <tr>
                    <td colspan="2">
                        <h3>Simulador Depósito a Plazo</h3>
                    </td>
                </tr>
            </table>
            <br />
            <table id="tablaMantenimiento">
            </table>
            <div id="barraMantenimiento">
            </div>
        </div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 287px">
                    &nbsp;
                </td>
                <td style="width: 78px">
                    <input type="button" id="guardar" value="Guardar" class="button" />
                </td>
                <td>
                    <asp:Button ID="btnSalir" runat="server" Text="Cancelar" Width="66px" CssClass="button" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
