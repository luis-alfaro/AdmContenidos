﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ReporteConsultasRipleymatico.aspx.vb" Inherits="aspx_ReporteConsultasRipleymatico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="Server">
    <head>
        <script type="text/javascript" src="js/styleswitcher.js"></script>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
        <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
        <script src="../js/BI.js" type="text/javascript"></script>
        <style type="text/css">
            .Gridlayout
            {
                table-layout:inherit !important;
                }
        </style>
    </head>
    <body>
        <script type="text/javascript">
            var dialogAlter = 'dialog-alert';
            $(document).ready(DocReady);
            function DocReady() {
//                $("input[data-entryType = 'Date']").datepicker();
                var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Reporte de Consultas en Ripleymatico'}];
                BI.CreateDialogs(arrayDialog);
                var gvdetalle = '<%= gvdetalle.ClientID %>';
                $("#" + gvdetalle).addClass("Gridlayout");

                var error = '<%= lblError.ClientID %>';
                var txtfechadesde = '<%= txtfechadesde.ClientID %>';
                var txtfechahasta = '<%= txtfechahasta.ClientID %>';
                var BtnBuscar = '<%= BtnBuscar.ClientID %>';
                var BtnLimpiar = '<%= BtnLimpiar.ClientID %>';

                var cblopciones = '<%= cblopciones.ClientID %>';

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
                    var values = $('input:checkbox:checked').map(function () {
                        return $('label[for="' + $(this).attr("id") + '"]').html();
                    }).get();
                    if (values.length == 0) {
                        BI.ShowAlert('', "Debe seleccionar por lo menos una opción.");
                        return false;
                        e.preventDefault();
                    }
                    $("#" + gvdetalle).addClass("Gridlayout");
                    if ($("#" + txtfechadesde).val() == "" || $("#" + txtfechahasta).val() == "") {
                        BI.ShowAlert('', "Ingrese un rango de fechas");
                        return false;
                    e.preventDefault();
                    }
                });
            
                $("#" + BtnLimpiar).click(function (e) {
                    $("#" + txtfechadesde).val('');
                    $("#" + txtfechahasta).val('');
                    $("#" + cblopciones).val('');
                    e.preventDefault();
                }); 


                if ($("#" + error).text() != "") {
                    BI.ShowAlert('', $("#" + error).text());
                }
            }
            function validarSiNumero(numero){
                if (!/^([0-9])*$/.test(numero)) {
                    alert("El valor " + numero + " no es un número");
                    return "";
                }
            }
            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }
        </script>
        <div id='dialog-alert' style="display: none">   
        </div>
        <table style="width: 100%;" bgcolor="#FFFFFF">
            <tr>
                <td background="images/topLarge.png">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" Width="816px"
                        Height="100px" ImageAlign="RIGHT" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#000000" style="height: 45px">
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" bgcolor="#FFFFFF" style="font-size: 8pt; font-family: Verdana;
                        width: 747px; height: 110px;">
                    <tr>                    
                        <td colspan="9" style="height:10px;">
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="7" style="text-align:center"><h2><b>CONSULTAS EN RIPLEYMATICO</b></h2></td>
                        <td style="width: 133px">&nbsp;</td>
                    </tr>
                    <tr>                    
                        <td colspan="9" style="height:10px;">
                        </td>
                    </tr>
                        <tr>
                            <td>
                                Opciones:
                            </td>
                            <td colspan="2">
                                <asp:CheckBoxList ID="cblopciones" runat="server" Height="198px" Width="822px" Visible="True"
                                    AppendDataBoundItems="True">
                                </asp:CheckBoxList>
                            </td>
                            <td>
                            </td>
                            <td colspan="2">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 133px">
                                &nbsp;
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
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 133px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbldesde" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblhasta" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>                                
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 133px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <th colspan="8">
                                <center>
                                    <asp:Button ID="BtnBuscar" runat="server" Text="Mostrar Datos" Style="text-align: center"
                                        CssClass="button" />
                                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar Campos" 
                                        style="text-align:center" CssClass="button" />
                                    <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="122px" CssClass="button" />
                                    &nbsp;<div style="display:none;"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
                                </center>
                            </th>
                            <th style="width: 133px">
                                &nbsp;
                            </th>
                        </tr>
                        <tr>
                            <th colspan="8">
                                <table border="0" style="width:100%">
                                    <tr>
                                        <td style="width:20%;">
                                        </td>
                                        <td style="width:60%;">
                                        </td>
                                        <td style="width:20%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <div class="scroll">
                                                <b>
                                                    <asp:Label ID="Label2" runat="server" Text="REPORTE DETALLADO" Font-Bold="True" ForeColor="Black"
                                                        Font-Size="Smaller"></asp:Label>
                                                </b>
                                                <br />
                                                <asp:GridView ID="gvdetalle" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" Font-Size="Small">
                                                    <RowStyle BackColor="#F7F7DE" />
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                                <asp:Button ID="BtnExporarExcel" runat="server" Text="Exportar a Excel" CssClass="button" />
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </th>
                            <th style="width: 133px">
                                &nbsp;
                            </th>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
