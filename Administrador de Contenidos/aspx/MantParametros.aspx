<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantParametros.aspx.vb" Inherits="aspx_MantParametros" title="Página sin título" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos(Parametros)
	
	
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
                <td class="style9" style="height: 27px; width: 15px;">
                    </td>
                <td class="style9" style="height: 27px; width: 390px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Actualizar Tiempos"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" 
                        Text="Uno de los valores ingresados es incorrecto" Visible="False"></asp:Label>
                    </td>
                <td class="style9" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 15px;">
                    </td>
                <td class="style9" style="height: 18px; width: 390px;">
                    <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Descripción"></asp:Label>
                &nbsp;
                </td>
                <td class="style9" style="height: 18px; width: 46px;">
                    </td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 15px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 390px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="width: 15px; height: 64px;">
                    </td>
                <td class="style9" style="width: 390px; height: 64px;">
                    <table style="width: 128%;">
                        <tr>
                            <td style="width: 234px">
                                Usuario Autorizado</td>
                            <td style="width: 27px">
                                <asp:TextBox ID="txtTiempoDoc" runat="server" Width="34px" Height="24px" 
                                    Wrap="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;seg.&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 234px">
                                &nbsp;</td>
                            <td style="width: 27px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 234px">
                                Nombre del Dominio</td>
                            <td style="width: 27px">
                                <asp:TextBox ID="txtTiempoOpc" runat="server" Height="21px" Width="34px" 
                                    Wrap="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;seg.&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 234px">
                                &nbsp;</td>
                            <td style="width: 27px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 234px">
                                Contraseña del Usuario</td>
                            <td style="width: 27px">
                                <asp:TextBox ID="txtNroErrorTarjeta" runat="server" Width="34px" Height="22px" 
                                    Wrap="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;veces&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 234px">
                                &nbsp;</td>
                            <td style="width: 27px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label5" runat="server" ForeColor="Red" 
                                    Text="Los cambios surtirán efecto en los equipos seleccionados una vez estos sean reinicializados."></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td class="style9" style="height: 64px;">
                    </td>
                
            </tr>
            
            <tr>
                 <td class="style9" style="width: 15px">
                     &nbsp;</td>
                 <td class="style9" style="width: 390px">
                     <table style="width:100%;">
                         <tr>
                             <td style="width: 69px">
                                 &nbsp;</td>
                             <td style="width: 78px">
                                 &nbsp;</td>
                             <td>
                                 &nbsp;</td>
                         </tr>
                         <tr>
                             <td style="width: 69px">
                                 &nbsp;</td>
                             <td style="width: 78px">
                                 <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="button" />
                             </td>
                             <td>
                                 <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="66px" 
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
