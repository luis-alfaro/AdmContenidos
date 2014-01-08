﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="ReporteEstadisticoIncremento.aspx.vb"
    Inherits="aspx_ReporteEstadisticoIncremento" %>

<asp:content id="Content1" contentplaceholderid="CPHContenido" runat="Server">

    <head>
        <script type="text/javascript" src="js/styleswitcher.js"></script>

        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css"rel="stylesheet" />
	    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
	    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
</head>
<body>
<script type="text/javascript">
    $(document).ready(DocReady);
    function DocReady() {
        $("input[data-entryType = 'Date']").datepicker();
    }
</script>

<table style="width:100%;" bgcolor="#FFFFFF">
        <tr>
            <td background="images/topLarge.png">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" Width="816px" Height="100px" ImageAlign="RIGHT" />
			</td>
        </tr>
        <tr>
            <td bgcolor="#000000" style="height: 45px">
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" bgcolor="#FFFFFF" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 747px; height: 110px;"  >
                    <tr>
                    <td>&nbsp;</td>
                    <td colspan="7"><b>Generar Reporte Estadístico de Incremento de Linea</b></td>
                    <td style="width: 133px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Desde:</td>
                        <td colspan="2"><asp:TextBox  ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox></td>
                        <td>Hasta:</td>
                        <td colspan="2"><asp:TextBox ID="txtfechahasta" runat="server" data-entryType="Date"></asp:TextBox></td>
                        <td>Tienda:</td>
                        <td><asp:DropDownList ID="ddltiendas" runat="server" ></asp:DropDownList></td>
                        <td style="width: 133px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lbldesde" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label></td>
                        <td></td>
                        <td> <asp:Label ID="lblhasta" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td><asp:HiddenField ID="hddtienda" runat="server" /></td>
                        <td style="width: 133px">&nbsp;</td>
                    </tr>
                    <tr>
                        <th colspan="8"><center>
                        <asp:Button ID="BtnBuscar" runat="server" Text="Mostrar Datos" 
                                    style="text-align:center" CssClass="button" />
                            <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir" Width="122px" 
                                    CssClass="button" />
                            <asp:Button ID="Button7" runat="server" Text="Salir" Width="122px" 
                                    CssClass="button" />
                            &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </center>
                            </th>
                        <th style="width: 133px">&nbsp;</th>
                    </tr>
                    <tr>
                        <th colspan="8">
                            <table border="0">
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                </tr>
                            <tr>
                                <td></td>
                                <td >
                                        <div class="scroll"><b>
                                            <asp:Label ID="Label2" runat="server" Text="REPORTE DETALLADO" 
                                                    Font-Bold="True" ForeColor="Black" Font-Size="Smaller"></asp:Label>
                                                </b><br />
                                            <asp:GridView ID="gvdetalle" runat="server" BackColor="White" OnRowCreated="gvdetalle_RowCreated" 
                                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                ForeColor="Black" Font-Size="Small">
                                                <RowStyle BackColor="#F7F7DE" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#6B696B"  Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                            <asp:Button ID="BtnExporarExcel" runat="server" Text="Exportar a Excel" CssClass="button"/>
                                        </div>
                                </td>
                                <td></td>
                            </tr>
                            </table>

                            </th>
                            <th style="width: 133px"> &nbsp;</th>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</body>
</asp:content>
