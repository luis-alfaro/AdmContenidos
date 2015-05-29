<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Access.aspx.vb" Inherits="aspx_Access"
    Title="Mantenedor de Accesos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <body topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
        <title>Administrador de Contenidos(Accesos) </title>
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
            var identificadorddlRols = "";
            var IDRow = 0, IDCol = 0, valorPrevio = 0;
            var idR = 0;
            $(function () {
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Administrador de Contenidos'}];
                BI.CreateDialogs(arrayDialog);

                identificadorddlRols = '<%= ddlRol.ClientID %>';
                $("#guardar").bind("click", function () {
                    GuardarAccess();
                });

                $("#" + identificadorddlRols).change(function () {
                    var id = $(this).val();
                    idR = id;
                    $("#" + tablaMantenimiento).jqGrid("GridUnload");
                    CrearTabla("#" + tablaMantenimiento);
                    dibujarTabla(id);
                });
                CrearTabla("#" + tablaMantenimiento);
            });

            function CrearTabla(tabla) {
                var c = ['AccessID', 'RoleID', 'MenuID', 'Nombre', 'Menu', 'Estado', 'Flag'];
                var cm = [
            { name: 'AccessID', index: 'AccessID', width: 12, align: 'center', hidden: true, sortable: false },
            { name: 'RoleID', index: 'RoleID', width: 3, align: 'center', hidden: true, sortable: false },
            { name: 'MenuID', index: 'MenuID', width: 3, align: 'center', hidden: true, sortable: false },
            { name: 'MenuNombre', index: 'MenuNombre', width: 150, align: 'center', hidden: true, editable: false, sortable: false },
            { name: 'Descripcion', index: 'Descripcion', width: 150, align: 'center', editable: false, sortable: false },
            { name: 'Estado', index: 'Estado', width: 80, align: 'center', editable: true, formatter: 'checkbox', edittype: 'checkbox', stype: 'checkbox', searchoptions: { value: "1:true;0:false"} },
            { name: 'Flag', index: 'Flag', width: 80, align: 'center', hidden: true }
        ];
            tableToGrid(tabla, {
                colNames: c,
                colModel: cm,
                width: 500,
                height: 450,
                datatype: 'local',
                cellsubmit: "clientArray",
                rowNum: 15,
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
                    var row = jQuery("#" + tablaMantenimiento).getRowData(rowid);
                    if (row[cellname] != valorPrevio) {
                        row['Flag'] = true;
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


            function dibujarTabla(idRol) {
                var data = { idRol: idRol };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "Access.aspx/ObtenerAccesos",
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
            function GuardarAccess() {
                $("#" + tablaMantenimiento).jqGrid("saveCell", IDRow, IDCol);
                lista = jQuery("#" + tablaMantenimiento).jqGrid('getRowData');
                $.each(lista, function (index, campo) {
                    console.log("los de lista", campo["Estado"], campo["flag"]);
                    if (campo["Estado"] == "Yes")
                    { campo["Estado"] = true }
                    else { campo["Estado"] = false }
                });
                var data = { lista: lista };
                var dataVal = JSON.stringify(data);
                $.ajax({
                    type: "POST",
                    url: "Access.aspx/GuardarAccess",
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
                            dibujarTabla(idR); 
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
                        <h3>Accesos:</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        Rol:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRol" runat="server">
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
