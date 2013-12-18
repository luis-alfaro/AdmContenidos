<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantTarifa.aspx.vb" Inherits="aspx_MantTarifa" title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos(Tiempos)
	
	
</title>
<link rel="stylesheet" href="estilos/estilos.css" type="text/css"></link>


 <TABLE border="0" id="tblBody" 
            
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 888px; height: 551px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 2px; width: 774px;">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="897px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
			<TR>
				<TD style="height: 2px; width: 774px;">
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 898px; height: 327px;">
            <tr>
                <td class="style9" style="height: 48px; " colspan="3" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 27px; width: 114px;">
                    </td>
                <td class="style9" style="height: 27px; width: 854px;">
                    &nbsp;</td>
                <td class="style9" style="height: 27px; width: 672px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 114px;">
                    </td>
                <td class="style9" style="height: 18px; width: 854px;">
                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Underline="True" Text="Mantenimiento de Tasas:    DEPÓSITOS A PLAZO"></asp:Label>
&nbsp;
                    </td>

                <td class="style9" style="height: 18px; width: 672px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 114px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 854px;">
                    &nbsp;</td>

                <td class="style9" style="height: 18px; width: 672px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 114px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 854px;">
                    <table style="border-style: groove; border-color: #C0C0C0; width: 108%; height: 280px; border-top-width: thin;" 
                        border = "1">
                        <tr>
                            <td style="width: 686px; " align="center" bgcolor="#DEDEDE" rowspan="2">
                                <asp:Label ID="Label21" runat="server" Text="DESCRIPCIÓN"></asp:Label>
                            </td>
                            <td style="height: 20px;" align="center" bgcolor="#DEDEDE" colspan="2">
                                <asp:Label ID="Label22" runat="server" Text="SOLES"></asp:Label>
                            </td>
                            <td align="center" bgcolor="#DEDEDE" style="height: 20px; width: 177px">
                                <asp:Label ID="Label23" runat="server" Text="DOLARES"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 181px; height: 21px;" align="center" bgcolor="#DEDEDE">
                                De 1,000 a 10,000</td>
                            <td style="width: 143px; height: 21px;" align="center" bgcolor="#DEDEDE">
                                Mas de 10,000</td>
                            <td style="width: 177px; height: 21px;" align="center" bgcolor="#DEDEDE">
                                Desde 300</td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 21px;">
                                <asp:Label ID="lblDescripcion1" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMenos1" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMax1" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 21px;" align="center">
                                <asp:TextBox ID="txtDolares1" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 21px;">
                                <asp:Label ID="lblDescripcion2" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMenos2" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMax2" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 21px;" align="center">
                                <asp:TextBox ID="txtDolares2" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 19px;">
                                <asp:Label ID="lblDescripcion3" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMenos3" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMax3" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 19px;" align="center">
                                <asp:TextBox ID="txtDolares3" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 15px;">
                                <asp:Label ID="lblDescripcion4" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 15px;" align="center">
                                <asp:TextBox ID="txtSolesMenos4" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 15px;" align="center">
                                <asp:TextBox ID="txtSolesMax4" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 15px;" align="center">
                                <asp:TextBox ID="txtDolares4" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 19px;">
                                <asp:Label ID="lblDescripcion5" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMenos5" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMax5" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 19px;" align="center">
                                <asp:TextBox ID="txtDolares5" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 12px;">
                                <asp:Label ID="lblDescripcion6" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 12px;" align="center">
                                <asp:TextBox ID="txtSolesMenos6" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 12px;" align="center">
                                <asp:TextBox ID="txtSolesMax6" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 12px;" align="center">
                                <asp:TextBox ID="txtDolares6" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 21px;">
                                <asp:Label ID="lblDescripcion7" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMenos7" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 21px;" align="center">
                                <asp:TextBox ID="txtSolesMax7" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 21px;" align="center">
                                <asp:TextBox ID="txtDolares7" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 19px;">
                                <asp:Label ID="lblDescripcion8" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMenos8" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 19px;" align="center">
                                <asp:TextBox ID="txtSolesMax8" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 19px;" align="center">
                                <asp:TextBox ID="txtDolares8" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 686px; height: 22px;">
                                <asp:Label ID="lblDescripcion9" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 181px; height: 22px;" align="center">
                                <asp:TextBox ID="txtSolesMenos9" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 143px; height: 22px;" align="center">
                                <asp:TextBox ID="txtSolesMax9" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td style="width: 177px; height: 22px;" align="center">
                                <asp:TextBox ID="txtDolares9" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                    </td>

                <td class="style9" style="height: 18px; width: 672px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 114px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 854px;">
                    &nbsp;</td>

                <td class="style9" style="height: 18px; width: 672px;">
                    &nbsp;</td>

            </tr>
            
            <tr>
                 <td class="style9" style="width: 114px">
                     &nbsp;</td>
                 <td class="style9" style="width: 854px">
                     <table style="width:100%;">
                         <tr>
                             <td style="width: 287px">
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
                 <td class="style9" style="width: 672px">
                     &nbsp;</td>
            </tr>
            
        </table>
					</TD>
			</TR>
<TR>
<td style="width: 774px">

    &nbsp;</td>
</TR>
</TABLE>
</BODY>

</asp:Content>
