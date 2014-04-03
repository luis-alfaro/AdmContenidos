<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MantEstructuraPDF.aspx.vb" Inherits="aspx_MantEstructuraPDF"
    Title="Mantenedor Estructura PDFs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Estructura PDFs) </title>
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
            var identificadorddlPDFs = "";
            var IDRow = 0, IDCol = 0, valorPrevio = 0;
            $(function () {
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Administrador de Contenidos'}];
                BI.CreateDialogs(arrayDialog);

                identificadorddlPDFs = '<%= ddlPDFs.ClientID %>';
                $("#guardar").bind("click", function () {
                    GuardarEstructuraPDF();
                });

                $("#" + identificadorddlPDFs).change(function () {
                    var id = $(this).val();
                    $("#" + tablaMantenimiento).jqGrid("GridUnload");
                    CrearTabla("#" + tablaMantenimiento);
                    dibujarTabla(id);
                });
                CrearTabla("#" + tablaMantenimiento);
            });

            function CrearTabla(tabla) {
                var c = ['ID', 'IdEstructura', 'Número Pagina','Orden', 'Es Texto?',  'NombreCampo', 'CoordenadaX'
                        , 'DesplazamientoX', 'CoordenadaY', 'Rotación', 'Ruta Imagen', 'Porcentaje Escala', 'Máximo Caracteres'];
                var cm = [
            { name: 'ID', index: 'ID', width: 12, align: 'center', hidden: true },
            { name: 'IdEstructura', index: 'IdEstructura', width: 3, align: 'center', hidden: true },
            { name: 'NumeroPagina', index: 'NumeroPagina', width: 75, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'Orden', index: 'Orden', width: 60, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'EsTexto', index: 'EsTexto', width: 75, align: 'center', editable: true, formatter: 'select', stype: 'select', edittype: 'select', editoptions: { value: "false:No;true:Si"} },
            { name: 'NombreCampo', index: 'NombreCampo', width: 160, align: 'left', editable: true },
            { name: 'CoordenadaX', index: 'CoordenadaX', width: 95, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'DesplazamientoX', index: 'DesplazamientoX', width: 115, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'CoordenadaY', index: 'CoordenadaY', width: 95, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'Rotacion', index: 'Rotacion', width: 75, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'RutaImagen', index: 'RutaImagen', width: 150, align: 'left', editable: true },
            { name: 'PorcentajeEscala', index: 'PorcentajeEscala', width: 90, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} },
            { name: 'MaximoCaracteres', index: 'MaximoCaracteres', width: 95, align: 'center', editable: true, formatter: 'integer', formatoptions: { defaultValue: '0'} }
        ];
                tableToGrid(tabla, {
                    colNames: c,
                    colModel: cm,
                    width: 1100,
                    height: 400,
                    datatype: 'local',
                    cellsubmit: "clientArray",
                    rowNum: 25,
                    viewrecords: true,
                    viewGrid: true,
                    cellEdit: true,
                    pager: '#barraMantenimiento',
                    beforeEditCell: function (rowid, cellname, value, iRow, iCol) {
                        IDRow = iRow;
                        IDCol = iCol;
                        valorPrevio = value;
                    },
                    afterSaveCell: function (rowid, cellname, value, iRow, iCol) {
                        if (cellname != "NombreCampo" && cellname != "RutaImagen" && cellname != "EsTexto") {
                            var row = jQuery("#" + tablaMantenimiento).getRowData(rowid);
                            if (!BI.ValidarDecimal(value)) {
                                row[cellname] = valorPrevio;
                                jQuery("#" + tablaMantenimiento).jqGrid('setRowData', rowid, row);
                            }
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


            function dibujarTabla(idEstructura) {
                var data = { idEstructura: idEstructura };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "MantEstructuraPDF.aspx/Obtener_EstructuraPDF",
                    data: dataVal,
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
            function GuardarEstructuraPDF() {
                $("#" + tablaMantenimiento).jqGrid("saveCell", IDRow, IDCol);
                lista = jQuery("#" + tablaMantenimiento).jqGrid('getRowData');
                var data = { lista: lista };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "MantEstructuraPDF.aspx/Guardar_EstructuraPDF",
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
                        <h3>Estrucutra PDFs:</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        PDF:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPDFs" runat="server">
                        </asp:DropDownList>
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
