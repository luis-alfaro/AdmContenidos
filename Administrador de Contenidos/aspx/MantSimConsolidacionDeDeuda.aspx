<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MantSimConsolidacionDeDeuda.aspx.vb" Inherits="aspx_MantSimConsolidacionDeDeuda"
    Title="Mantenedor Simulador Consolidación De Deuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Consolidación De Deuda) </title>
        <script src="../js/BI.js" type="text/javascript"></script>
        <link rel="stylesheet" href="estilos/estilos.css" type="text/css" />
        <%--<link href="../estilos/redmond/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />--%>
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
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
                var c = ['IDCDD', 'Plazo Mínimo', 'Plazo Máximo', 'TEA', 'Monto Mínimo', 'Monto Máximo','FLAG','ACTUAL_VALUE'];
                var cm = [
            { name: 'IDCDD', index: 'IDCDD', width: 12, align: 'center', hidden: true, sortable: false },
            { name: 'PLAZO_MIN', index: 'PLAZO_MIN', width: 95, align: 'center', editable: true, sortable: false, formatter: 'number', formatoptions: { decimalSeparator: ",", decimalPlaces: 0} },
            { name: 'PLAZO_MAX', index: 'PLAZO_MAX', width: 95, align: 'center', editable: true, sortable: false, formatter: 'number', formatoptions: { decimalSeparator: ",", decimalPlaces: 0} },
            { name: 'TEA', index: 'TEA', width: 50, align: 'center', editable: true, sortable: false, formatoptions: { decimalSeparator: ",", decimalPlaces: 2, suffix: "%"} },
            { name: 'MONTO_MIN', index: 'MONTO_MIN', width: 105, align: 'center', editable: true, sortable: false, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 2} },
            { name: 'MONTO_MAX', index: 'MONTO_MAX', width: 105, align: 'center', editable: true, sortable: false, formatter: 'number', formatoptions: { decimalSeparator: ",", thousandsSeparator: "'", decimalPlaces: 2} },
            { name: 'FLAG', index: 'FLAG', width: 80, align: 'center', hidden: true },
            { name: 'ACTUAL_VALUE', index: 'ACTUAL_VALUE', width: 80, align: 'center', hidden: true }
        ];
                tableToGrid(tabla, {
                    colNames: c,
                    colModel: cm,
                    width: 800,
                    height: 100,
                    datatype: 'local',
                    cellsubmit: "clientArray",
                    rowNum: 12,
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
                        if (row[cellname] != valorPrevio) {
                            row['FLAG'] = "1";
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
                    url: "MantSimConsolidacionDeDeuda.aspx/Obtener_SIM_ConsolidacionDeDeuda",
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
                    url: "MantSimConsolidacionDeDeuda.aspx/Guardar_SIM_ConsolidacionDeDeuda",
                    data: dataVal,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        var res = result.hasOwnProperty("d") ? result.d : result;
                        if (res == 1) {
                            BI.ShowAlert('', "Los datos se guardaron con éxito.");
                            $("#" + tablaMantenimiento).jqGrid("GridUnload");
                            CrearTabla("#" + tablaMantenimiento);
                            dibujarTabla(); 
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
                        <h3>Simulador Consolidación De Deuda</h3>
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
