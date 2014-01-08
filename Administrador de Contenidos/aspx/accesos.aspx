<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="accesos.aspx.vb" Inherits="aspx_accesos" title="Administrador de Contenidos(Accesos)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos(Accesos)
	
	
</title>
<link rel="stylesheet" href="estilos/estilos.css" type="text/css"></link>

 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 779px; height: 496px;" cellspacing="0"
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
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 815px; height: 463px;" 
        >
<tr>
<td style="width: 484px; height: 218px">
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 809px; height: 448px;">
            <tr>
                <td class="style9" style="height: 44px; " colspan="4" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 2px; width: 24px;">
                    </td>
                <td class="style9" style="height: 2px; width: 173px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Registro de Accesos:"></asp:Label>
                </td>
                <td class="style9" style="height: 2px; width: 222px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style9" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 10px;">
                    </td>
                <td class="style9" style="width: 173px; height: 10px;">
                    <asp:Label ID="lblcodacceso" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="height: 10px; width: 222px;">
                    &nbsp;</td>
                <td style="height: 10px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 10px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 10px;">
                    <table style="width: 134%;">
                        <tr>
                            <td style="width: 56px">
                    <asp:Button ID="bntaceptar" runat="server" Text="Aceptar" Width="60px" CssClass="button"/>
                            </td>
                            <td style="width: 56px">
                    <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="61px" CssClass="button" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td style="height: 10px; width: 222px;">
                    &nbsp;</td>
                <td style="height: 10px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 3px;">
                    </td>
                <td class="style9" style="width: 173px; height: 3px;">
                    Seleccionar Rol:</td>
                <td style="height: 3px; width: 222px;">
                    </td>
                <td style="height: 3px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 4px;">
                    </td>
                <td class="style9" 
                    style="width: 173px; height: 4px; text-decoration: underline;">
                    <asp:ListBox ID="lbxRoles" runat="server" AutoPostBack="True" Height="68px" 
                        Width="167px"></asp:ListBox>
                    </td>
                <td style="height: 4px; width: 222px;">
                    </td>
                <td style="height: 4px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 25px;">
                    &nbsp;</td>
                <td class="style9" 
                    style="width: 173px; height: 25px; text-decoration: underline;">
                    Activar o Desactivar Accesos:</td>
                <td style="height: 25px; width: 222px;">
                    &nbsp;</td>
                <td style="height: 25px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 8px;">
                    </td>
                <td class="style9" style="width: 173px; height: 8px;">
                    </td>
                <td style="height: 8px; width: 222px;">
                    </td>
                <td style="height: 8px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    </td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="CkPanel" runat="server" Text="Panel" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="CkUsuario" runat="server" Text="Usuarios" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="CkSvideo" runat="server" Text="Secuencia de Videos" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="CkRoles" runat="server" Text="Roles" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="CkSbanner" runat="server" Text="Secuencia de Banners" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="CkAccesos" runat="server" Text="Accesos" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckUbigeo" runat="server" Text="Ubigeo" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckTiendas" runat="server" Text="Tiendas/Sucursales" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckKioscos" runat="server" Text="Kioscos" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckAreas" runat="server" Text="Áreas" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckCriterios" runat="server" Text="Criterios" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckActualizar" runat="server" Text="Actualizar Imágenes" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckReporte" runat="server" Text="Reporte Estadístico" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckTemporizador" runat="server" 
                        Text="Temporizador" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckMensajes" runat="server" Text="Mensajes Ticket" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckTiempos" runat="server" Text="Tiempos de Inactividad" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckTarifas" Visible="false" runat="server" Text="Tarifas DPF" />
                    <asp:CheckBox ID="ckEstadisticas" runat="server" Text="Estadísticas" />
                </td>
                <td style="height: 22px; width: 222px;">
                    <asp:CheckBox ID="ckSimuladores" runat="server" Text="Simuladores" /></td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 173px; height: 22px;">
                    <asp:CheckBox ID="ckErrores" runat="server" Text="Errores" />
                </td>
                <td style="height: 22px; width: 222px;"></td>
                <td style="height: 22px">
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

