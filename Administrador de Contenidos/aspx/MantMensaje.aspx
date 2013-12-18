<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantMensaje.aspx.vb" Inherits="aspx_MantMensaje" title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos(Tiempos)
	
	
</title>
<link rel="stylesheet" href="estilos/estilos.css" type="text/css"></link>


 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 779px; height: 300px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
<TR>
<td colspan="3">

<table border=0 align="left" bordercolordark="#000000" 
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 815px; height: 188px;" 
        >
<tr>
<td style="width: 484px; height: 218px">
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 809px; height: 206px;">
            <tr>
                <td class="style9" style="height: 48px; " colspan="3" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 27px; width: 66px;">
                    </td>
                <td class="style9" style="height: 27px; width: 793px;">
                    &nbsp;</td>
                <td class="style9" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 66px;">
                    </td>
                <td class="style9" style="height: 18px; width: 793px;">
                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Underline="True" Text="Mantenimiento de Mensajes:"></asp:Label>
&nbsp;
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                </td>
                <td class="style9" style="height: 18px; width: 46px;">
                    </td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 66px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 793px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="width: 66px; height: 64px;">
                    </td>
                <td class="style9" style="width: 793px; height: 64px;">
                    <table style="width: 133%;">
                        <tr>
                            <td style="width: 102px">
                                <asp:Label ID="Label1" runat="server" Text="Primer Grupo"></asp:Label>
                            </td>
                            <td style="width: 90px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label7" runat="server" Text="Primera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtprimer1Linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label2" runat="server" Text="Segunda Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimer2linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label4" runat="server" Text="Tercera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimer3linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label5" runat="server" Text="Cuarta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimer4linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label6" runat="server" Text="Quinta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrimer5linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                <asp:Label ID="Label18" runat="server" Text="Segundo Grupo"></asp:Label>
                            </td>
                            <td style="width: 90px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label8" runat="server" Text="Primera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSegunda1linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label9" runat="server" Text="Segunda Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSegunda2linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label10" runat="server" Text="Tercera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSegunda3linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label11" runat="server" Text="Cuarta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSegunda4linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label12" runat="server" Text="Quinta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSegunda5linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                <asp:Label ID="Label19" runat="server" Text="Tercer Grupo"></asp:Label>
                            </td>
                            <td style="width: 90px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label13" runat="server" Text="Primera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTercer1linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label14" runat="server" Text="Segunda Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTercer2linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label15" runat="server" Text="Tercera Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTercer3linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label16" runat="server" Text="Cuarta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTercer4linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 102px">
                                &nbsp;</td>
                            <td style="width: 90px">
                                <asp:Label ID="Label17" runat="server" Text="Quinta Línea"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTercer5linea" runat="server" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td class="style9" style="height: 64px;">
                    </td>
                
            </tr>
            
            <tr>
                 <td class="style9" style="width: 66px">
                     &nbsp;</td>
                 <td class="style9" style="width: 793px">
                     <table style="width:100%;">
                         <tr>
                             <td style="width: 107px">
                                 &nbsp;</td>
                             <td style="width: 78px">
                                 &nbsp;</td>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td style="width: 107px">
                                 &nbsp;</td>
                             <td style="width: 78px">
                                 <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="button" />
                             </td>
                             <td>
                                 <asp:Button ID="btnSalir" runat="server" Text="Cancelar" Width="66px" 
                                     CssClass="button" />
                             </td>
                         </tr>
                     </table>
                 </td>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            
        </table>
    </td>    
    </tr>
</table>

</td>
</TR>
</TABLE>
</BODY>

</asp:Content>
