<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReporteDetalleUsuariosRipleymatico.aspx.vb" Inherits="aspx_ReporteDetalleUsuariosRipleymatico" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
        <script type="text/javascript" src="js/styleswitcher.js"></script>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css"rel="stylesheet" />
	    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
	    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
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
            $(document).ready(DocReady);
            function DocReady() {
                $("input[data-entryType = 'Date']").datepicker();
            }
        </script>
    </head>
    <body>
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
                            <td colspan="9" style="height:10px;">
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="7" style="text-align:center"><h2><b>GENERAR REPORTES USUARIOS UNICOS</b></h2></td>
                            <td style="width: 133px">&nbsp;</td>
                        </tr>
                        <tr>                    
                            <td colspan="9" style="height:10px;">
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                Desde:</td>
                            <td>
                                <asp:TextBox  ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox>
                            </td>
                            <td>
                                Hasta:</td>
                            <td>
                                <asp:TextBox ID="txtfechahasta" runat="server" data-entryType="Date"></asp:TextBox>
                            </td>
                            <td>
                                 &nbsp;</td>
                            <td style="width: 133px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lbldesde" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblhasta" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td></td>
                            <td style="width: 133px">&nbsp;</td>
                        </tr>
                        <tr>
                            <th colspan="8">
                                <center>
                                    <asp:Button ID="Button2" runat="server" Text="Mostrar Datos" style="text-align:center" CssClass="button" />
                                    <asp:Button ID="Button5" runat="server" Text="Imprimir" Width="122px" CssClass="button" />
                                    <asp:Button ID="Button7" runat="server" Text="Salir" Width="122px" CssClass="button" />
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                </center>
                            </th>
                            <th style="width: 133px">&nbsp;</th>
                        </tr>
                        <tr>
                            <th colspan="8">
                                <table border="0">
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div class="scrolling" runat="server" id="divPrint">
                                                <h3><b>REPORTE GENERAL</b></h3>
                                                <br>                                              
                                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" Font-Size="Small">
                                                    <RowStyle BackColor="#F7F7DE" />
                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                                <br/>                                                          
                                                  <br />         
                                                  <br />                   
                                                <asp:Button ID="Button8" runat="server" Text="Exportar a Excel" CssClass="button" />
                                            </div><br/><br />
                                            <div class="scrolling">    
                                                <asp:HiddenField ID="hddtienda" runat="server" />        
                                            </div>                                            
                                        </td>
                                        <td></td>
                                    </tr>                                    
                                </table>
                            </th>
                            <th style="width: 133px">&nbsp;</th>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
