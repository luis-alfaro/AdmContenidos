<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="banners.aspx.vb" Inherits="aspx_banners" title="Administrador de Contenidos(Banners)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos (Banners)
</title>

<script type="text/javascript" language="javascript" src="js/colorPicker.js"></script>
<link rel="stylesheet" href="estilos/colorPicker.css" type="text/css"></link>
<link rel="stylesheet" href="estilos/Estilos.css" type="text/css"></link>

 <TABLE border="0" id="tblBody" 
            
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px; height: 383px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
<TR>
<td colspan="3">

    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 808px; height: 344px;">
            <tr>
                <td class="style9" style="height: 38px; " colspan="4" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 7px; width: 91px;">
                    </td>
                <td class="style9" style="height: 7px; width: 258px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Registro de Banners :"></asp:Label>
                </td>
                <td class="style9" style="height: 7px; width: 309px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style9" style="height: 7px; width: 540px;">
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 6px;">
                    </td>
                <td class="style9" style="width: 258px; height: 6px;">
                    <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                                                </td>
                <td style="width: 309px; height: 6px">
                    </td>
                <td style="width: 540px; height: 6px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 14px;">
                    </td>
                <td class="style9" style="width: 258px; height: 14px;">
                                        Criterio</td>
                <td style="width: 309px; height: 14px">
                    <asp:DropDownList ID="ddlCriterios" runat="server" Height="23px" Width="130px" 
                        DataTextField="nombre" DataValueField="idcriterio">
                    </asp:DropDownList>
                                                            </td>
                <td style="width: 540px; height: 14px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 15px;">
                    </td>
                <td class="style9" style="width: 258px; height: 15px;">
                    </td>
                <td style="width: 309px; height: 15px">
                    </td>
                <td style="width: 540px; height: 15px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 39px;">
                    </td>
                <td class="style9" style="width: 258px; height: 39px;" valign="top">
                    Descripción:
                                                            </td>
                <td style="height: 39px; width: 309px;" align="justify">
                    <asp:TextBox ID="txtbanner" runat="server" Height="94px" TextMode="MultiLine" 
                        Width="378px"></asp:TextBox>
                    </td>
                <td style="height: 39px; width: 540px;" align="justify">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 258px; height: 22px;">
                    &nbsp;</td>
                <td style="height: 22px; width: 309px;">
                    <asp:Button ID="bntaceptar" runat="server" Text="Aceptar"  Width="100px" 
                        CssClass="button" />
                    <asp:Button ID="btncancelar" runat="server" Text="Cancelar" Width="100px" 
                        CssClass="button"  />
                </td>
                <td style="height: 22px; width: 540px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 9px;">
                    </td>
                <td class="style9" style="width: 258px; height: 9px;">
                    </td>
                <td style="width: 309px; height: 9px">
                    </td>
                <td style="width: 540px; height: 9px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 91px; height: 41px;">
                    </td>
                <td class="style9" style="width: 258px; height: 41px;">
                    </td>
                <td style="width: 309px; height: 41px">
                    &nbsp;Color del Texto:
                    <input id="txtColor" type="text" onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly" />

                </td>
                    
                <td style="width: 540px; height: 41px">
                    &nbsp;</td>
                    
            </tr>
            </table>

</td>
</TR>
</TABLE>
</BODY>

</asp:Content>

