<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="LogDeAceptacionSEF.aspx.vb" Inherits="aspx_LogDeAceptacionSEF"
    Title="Log de Aceptación Super Efectivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Log de Aceptación Super Efectivo) </title>
        
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <%--<link href="../estilos/redmond/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />--%>
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
        <link href="../estilos/redmond/ui.jqgrid.css" rel="stylesheet" type="text/css" />
        <link href="../estilos/BlockUI.css" rel="stylesheet" type="text/css" />
        <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
        <script src="../js/BI.js" type="text/javascript"></script>
        <script src="../js/jquery.blockUI.js" type="text/javascript"></script>
        
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
            var txtdni = "";
            var IDRow = 0, IDCol = 0, valorPrevio = 0;
            $(function () {
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Administrador de Contenidos'}];
                BI.CreateDialogs(arrayDialog);

                txtfechadesde = '<%= txtfechadesde.ClientID %>';
                txtfechahasta = '<%= txtfechahasta.ClientID %>';
                txtdni = '<%= txtdni.ClientID %>';
                var BtnBuscar = '<%= BtnBuscar.ClientID %>';

                $("#" + txtfechadesde).prop("readonly", true);
                $("#" + txtfechahasta).prop("readonly", true);

                $("#" + txtfechadesde).datepicker({
                    dateFormat: 'dd/mm/yy',
                    onClose: function (selectedDate) {
                        $("#" + txtfechahasta).datepicker("option", "minDate", selectedDate);
                    }
                });

                $("#" + txtfechahasta).datepicker({
                    dateFormat: 'dd/mm/yy',
                    onClose: function (selectedDate) {
                        $("#" + txtfechadesde).datepicker("option", "maxDate", selectedDate);
                    }
                });


                $("#" + BtnBuscar).click(function (e) {
                   
                    var desde = $("#" + txtfechadesde).val();
                    var hasta = $("#" + txtfechahasta).val();
                    var dni = $("#" + txtdni).val();

                    if (desde == "" || hasta == "") {                        
                        BI.ShowAlert('', "Ingrese un rango de fechas");
                        return false;
                        e.preventDefault();
                    }
                    BI.MostrarLoading();
                    $("#" + tablaMantenimiento).jqGrid("GridUnload");
                    CrearTabla("#" + tablaMantenimiento);
                    dibujarTabla(desde, hasta, dni);

                    e.preventDefault();
                });

                CrearTabla("#" + tablaMantenimiento);
            });

            function CrearTabla(tabla) {
                var c = ['ID', 'IP', 'Nombre Kiosko', 'Fecha','Sufijo','DNI', 'Cliente'];
                var cm = [
                        { name: 'ID', index: 'ID', width: 12, align: 'center', hidden: true },
                        { name: 'IP', index: 'IP', width: 120, align: 'center', hidden: false },
                        { name: 'NombreKiosko', index: 'NombreKiosko', width: 100, align: 'center', hidden: false },
                        { name: 'Fecha', index: 'Fecha', width: 90, align: 'center', hidden: false,formatter: 'date',format:'dd/MM/yy' },
                        { name: 'Sufijo', index: 'Sufijo', width: 90, align: 'left', hidden: false },
                        { name: 'DNI', index: 'DNI', width: 90, align: 'left', hidden: false },
                        { name: 'Cliente', index: 'Cliente', width: 200, align: 'left', hidden: false }
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
            { edit: false, add: false, del: false, search: false, refresh: false ,loadui:true},
            {}, // edit options
            {}, // add options
            {}, //del options
            {multipleSearch: true }, // search options
            {}
        );
                $(tabla).trigger('reloadGrid');
            }


            function dibujarTabla(desde, hasta, dni) {
                var data = { desde: desde, hasta: hasta, dni: dni };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "LogDeAceptacionSEF.aspx/GetLogAceptacionSEF",
                    data: dataVal,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        var res = result.hasOwnProperty("d") ? result.d : result;
                        BI.OcultarLoading();
                        if (res.length > 0) {
                            $.each(res, function (index, campo) {
                                jQuery("#" + tablaMantenimiento).jqGrid('addRowData', index, campo);
                            });
                        }
                        else {
                            BI.ShowAlert('', "No se encontraron datos con los filtros de búsqueda especificados.");
                        }
                        
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
                            Log de Aceptación SEF:</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        Desde:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox>
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
                        DNI(opcional):
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtdni" runat="server"></asp:TextBox>
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
