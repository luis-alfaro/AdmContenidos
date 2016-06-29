<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ReporteAceptacionPenalidadesTC.aspx.vb" Inherits="aspx_ReporteAceptacionPenalidadesTC"
     %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" runat="server">
    <script type="text/javascript" src="js/styleswitcher.js"></script>
    <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
    <script src="../js/BI.js" type="text/javascript"></script>
    <style type="text/css">
        .Gridlayout
        {
            table-layout: inherit !important;
        }
        .style12
        {
            height: 33px;
        }
        .style13
        {
            width: 133px;
            height: 33px;
        }
        .style14
        {
            width: 268435456px;
        }
        .style16
        {
            height: 10px;
            width: 400px;
        }
        .style17
        {
            width: 42px;
        }
        .style18
        {
            width: 400px;
            height: 33px;
        }
        .style19
        {
            width: 400px;
        }
        .style20
        {
            width: 178px;
        }
        .style21
        {
            width: 400px;
            height: 23px;
        }
        .style22
        {
            height: 23px;
        }
        .style23
        {
            width: 268435456px;
            height: 23px;
        }
        .style24
        {
            width: 133px;
            height: 23px;
        }
    </style>
    <script type="text/javascript">
        var dialogAlter = 'dialog-alert';
        $(document).ready(DocReady);
        function DocReady() {
            var arrayDialog = [{ name: dialogAlter, height: 140, width: 350, title: 'Reporte Aceptación TC'}];
            BI.CreateDialogs(arrayDialog);
            var gvdetalle = '<%= gvdetalle.ClientID %>';
            $("#" + gvdetalle).addClass("Gridlayout");

            var error = '<%= lblError.ClientID %>';
            var txtfechadesde = '<%= txtfechadesde.ClientID %>';
            var txtfechahasta = '<%= txtfechahasta.ClientID %>';
            var BtnBuscar = '<%= BtnBuscar.ClientID %>';
            var BtnLimpiar = '<%= BtnLimpiar.ClientID %>';

            var txtPagina = '<%= txtPagina.ClientID %>';
            var txtPaginaActual = '<%= txtPaginaActual.ClientID %>';
            var txtTotalPaginas = '<%= txtTotalPaginas.ClientID %>';
            var btnGo = '<%= btnGo.ClientID %>';

            $("#" + txtfechadesde).prop("readonly", true);
            $("#" + txtfechahasta).prop("readonly", true);

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
                e.preventDefault();
            });

            $("#" + btnGo).click(function (e) {
                if ($("#" + txtPagina).val() == "") {
                    BI.ShowAlert('', "Ingrese un número de página a buscar.");
                    var page = $("#" + txtPaginaActual).val()
                    $("#" + txtPagina).val(page);
                    return false; e.preventDefault();
                }
                if ($("#" + txtPagina).val() == "0" || parseInt($("#" + txtPagina).val()) > parseInt($("#" + txtTotalPaginas).val())) {
                    BI.ShowAlert('', "El nro de la página no puede ser cero o mayor al nro total de páginas.");
                    var page = $("#" + txtPaginaActual).val()
                    $("#" + txtPagina).val(page);
                    return false; e.preventDefault();
                }

            });

            if ($("#" + error).text() != "") {
                BI.ShowAlert('', $("#" + error).text());
            }
        }

        function validarSiNumero(numero) {
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
                        <td colspan="9" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                        </td>
                        <td colspan="7" style="text-align: center" class="style12">
                            <h2 style="width: 595px">
                                <b>CONSULTAR ACEPTACION PENALIDADES TC&nbsp; </b>
                            </h2>
                        </td>
                        <td class="style13">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td class="style21">
                        </td>
                        <td class="style22">
                            Tipo:
                        </td>
                        <td colspan="2" class="style22">
                            <asp:DropDownList ID="TipoList" runat="server">
                                <asp:ListItem Value="0">TODAS LAS TARJETAS</asp:ListItem>
                                <asp:ListItem Value="CLASICA">CLASICA</asp:ListItem>
                                <asp:ListItem Value="SILVER MASTERCARD RSAT">SILVER MASTERCARD</asp:ListItem>
                                <asp:ListItem Value="SILVER VISA RSAT">SILVER VISA</asp:ListItem>
                                <asp:ListItem Value="GOLD MASTERCARD RSAT">GOLD MASTERCARD</asp:ListItem>
                                <asp:ListItem Value="PLATINUM VISA RSAT">PLATINUM VISA</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style22">
                            Canal:
                        </td>
                        <td colspan="2" class="style22">
                            <asp:DropDownList ID="TipoCanal" runat="server">
                                <asp:ListItem Value="0">RIPLEYMATICO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style23">
                        </td>
                        <td class="style24">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style16">
                            &nbsp;
                        </td>
                        <td>
                            Desde:
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtfechadesde" runat="server" data-entryType="Date" Height="22px"></asp:TextBox>
                        </td>
                        <td>
                            Hasta:
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtfechahasta" runat="server" data-entryType="Date" Height="22px"></asp:TextBox>
                        </td>
                        <td class="style14">
                        </td>
                        <td style="width: 133px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lbldesde" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                        </td>
                        <td class="style20">
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblhasta" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <th class="style19">
                            &nbsp;
                        </th>
                        <th colspan="7">
                            <center>
                                <asp:Button ID="BtnBuscar" runat="server" Text="Mostrar Datos" Style="text-align: center"
                                    CssClass="button" />
                                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar Campos" Style="text-align: center"
                                    CssClass="button" />
                                <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="122px" CssClass="button" />
                                &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </center>
                        </th>
                        <th style="width: 133px">
                            &nbsp;
                        </th>
                    </tr>
                    <tr>
                        <th colspan="8">
                            <table border="0">
                                <tr>
                                    <td class="style17">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style17">
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
                                            <table style="width: 100%;" id="tblPaginacion" runat="server">
                                                <tr>
                                                    <td style="width: 25%;">
                                                    </td>
                                                    <td style="width: 20px;">
                                                        <asp:Button ID="btnPrev" runat="server" Text="<<" Style="text-align: center" CssClass="button" />
                                                    </td>
                                                    <td style="width: 180px;">
                                                        <asp:Label ID="lblpagina" runat="server" Text="Página " Font-Bold="True" ForeColor="Black"
                                                            Font-Size="Smaller"></asp:Label>
                                                        <asp:HiddenField ID="txtPaginaActual" runat="server" />
                                                        <asp:TextBox ID="txtPagina" runat="server" Width="40px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        <asp:Label ID="Label1" runat="server" Text=" de " Font-Bold="True" ForeColor="Black"
                                                            Font-Size="Smaller"></asp:Label>
                                                        <asp:TextBox ID="txtTotalPaginas" runat="server" Width="40px" ReadOnly="true"></asp:TextBox>
                                                        <asp:Button ID="btnGo" runat="server" Text="ir" Style="text-align: center" CssClass="button" />
                                                    </td>
                                                    <td style="width: 20px;">
                                                        <asp:Button ID="btnNext" runat="server" Text=">>" Style="text-align: center" CssClass="button" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTotal" runat="server" Text="" Font-Bold="True" ForeColor="Black"
                                                            Font-Size="Smaller"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Button ID="BtnExporarExcel" runat="server" Text="Exportar Pagina a Excel" CssClass="button" />
                                            <asp:Button ID="BtnExporarTodoExcel" runat="server" Text="Exportar todo a Excel"
                                                CssClass="button" />
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
</asp:Content>
