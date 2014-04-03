<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="LogDeActualizacionRipleymatico.aspx.vb" Inherits="aspx_LogDeActualizacionRipleyMatico"
    Title="Log de Actualización de RipleyMatico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Log de Actualización RipleyMatico) </title>
        <script src="../js/BI.js" type="text/javascript"></script>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
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
            var txtfechadesde = "";
            var txtfechahasta = "";
            var txtFiltro = "";
            var IDRow = 0, IDCol = 0, valorPrevio = 0;
            $(function () {
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Administrador de Contenidos'}];
                BI.CreateDialogs(arrayDialog);

                txtfechadesde = '<%= txtfechadesde.ClientID %>';
                txtfechahasta = '<%= txtfechahasta.ClientID %>';
                txtFiltro = '<%= txtFiltro.ClientID %>';
                var BtnBuscar = '<%= BtnBuscar.ClientID %>';

                $("#" + txtfechadesde).datepicker({
                    onClose: function (selectedDate) {
                        $("#" + txtfechahasta).datepicker("option", "minDate", selectedDate);
                    }
                });

                $("#" + txtfechahasta).datepicker({
                    onClose: function (selectedDate) {
                        $("#" + txtfechadesde).datepicker("option", "maxDate", selectedDate);
                    }
                });


                $("#" + BtnBuscar).click(function (e) {
                    var desde = $("#" + txtfechadesde).val();
                    var hasta = $("#" + txtfechahasta).val();
                    var filtro = $("#" + txtFiltro).val();

                    $("#" + tablaMantenimiento).jqGrid("GridUnload");
                    CrearTabla("#" + tablaMantenimiento);
                    dibujarTabla(desde, hasta, filtro);
                    e.preventDefault();
                });

                CrearTabla("#" + tablaMantenimiento);
            });

            function CrearTabla(tabla) {
                var c = ['ID', 'FECHA', 'DESCRIPCION'];
                var cm = [
                        { name: 'ID', index: 'ID', width: 12, align: 'center', hidden: true },
                        { name: 'FechaMostrar', index: 'FechaMostrar', width: 100, align: 'center', hidden: false },
                        { name: 'Descripcion', index: 'Descripcion', width: 500, align: 'left', hidden: false }
                        ];
                tableToGrid(tabla, {
                    colNames: c,
                    colModel: cm,
                    width: 900,
                    height: 450,
                    datatype: 'local',
                    cellsubmit: "clientArray",
                    rowNum: 100,
                    viewrecords: true,
                    viewGrid: true,
                    cellEdit: false,
                    pager: '#barraMantenimiento'                    
                });

                jQuery("#" + tablaMantenimiento).jqGrid('navGrid', '#barraMantenimiento',
            { edit: false, add: false, del: false, search: false, refresh: false },
            {}, // edit options
            {}, // add options
            {}, //del options
            {multipleSearch: true }, // search options
            {}
        );
                $(tabla).trigger('reloadGrid');
            }


            function dibujarTabla(desde, hasta, filtro) {
                var data = { desde: desde, hasta: hasta, filtro: filtro };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "LogDeActualizacionRipleymatico.aspx/ObtenerLog",
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
        </script>
        <div id='dialog-alert' style="display: none">   
        </div>
        <div style="margin-left: 10px; padding: 10px;">
            <table>
                <tr>
                    <td colspan="6">
                        <h3>
                            Log de Actualización de Ripleymatico:</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        Desde:
                    </td>
                    <td colspan="2">
                        &nbsp;<asp:TextBox ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox>
                    </td>
                    <td>
                        Hasta:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtfechahasta" runat="server" data-entryType="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Filtrar por:
                    </td>
                    <td colspan="5">
                        &nbsp;<asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="6" style="text-align: center">
                        <asp:Button ID="BtnBuscar" runat="server" Text="Mostrar" Style="text-align: center"
                            CssClass="button" />
                    </th>
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
                </td>
                <td>
                    <asp:Button ID="btnSalir" runat="server" Text="Cancelar" Width="66px" CssClass="button" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
