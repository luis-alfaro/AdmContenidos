<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="roles.aspx.vb" Inherits="aspx_roles" title="Administrador de Contenidos(Roles)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	 Administrador de Contenidos(Roles)
</title>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
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
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 810px; height: 176px;">
            <tr>
                <td class="style9" style="height: 58px; " colspan="4" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 23px; width: 42px;">
                    &nbsp;</td>
                <td class="style9" style="height: 23px; width: 127px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Registro de Roles:"></asp:Label>
                </td>
                <td class="style9" style="height: 23px; width: 520px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style9" style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 16px;">
                    </td>
                <td class="style9" style="width: 127px; height: 16px;">
                    <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                                                </td>
                <td style="height: 16px; width: 520px">
                    </td>
                <td style="height: 16px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 23px;">
                    </td>
                <td class="style9" style="width: 127px; height: 23px;">
                    Nombre de rol:</td>
                <td style="height: 23px; width: 520px;">
                    <asp:TextBox ID="txtnombre" runat="server" Width="264px"></asp:TextBox>
                    </td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 25px;">
                    &nbsp;</td>
                <td class="style9" style="width: 127px; height: 25px;">
                    Descripción:</td>
                <td style="height: 25px; width: 520px;">
                    <asp:TextBox ID="txtdes" runat="server" Width="264px"></asp:TextBox>
                    </td>
                <td style="height: 25px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 22px;">
                    </td>
                <td class="style9" style="width: 127px; height: 22px;">
                    &nbsp;</td>
                <td style="height: 22px; width: 520px;">
                    <asp:CheckBox ID="Ckhabilitar" runat="server" Text="Cuenta habilitada" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 127px; height: 22px;">
                    &nbsp;</td>
                <td style="height: 22px; width: 520px;">
                    &nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 42px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 127px; height: 22px;">
                    &nbsp;</td>
                <td style="height: 22px; width: 520px;">
                    <asp:Button ID="bntaceptar" runat="server" Text="Aceptar" Width="114px" CssClass="button" />
                    <asp:Button ID="btncancelar" runat="server" Text="Cancelar" Width="98px" CssClass="button" />
                </td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            </table>

</td>
</TR>
</TABLE>
</BODY>

</asp:Content>

