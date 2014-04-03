<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="users.aspx.vb" Inherits="aspx_users" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <head>
    <title>
	Administrador de Contenidos(Users)
</title>
<link rel="Stylesheet" type="text/css" href="estilos/Estilos.css" />
</head>
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
<td colspan="2">


<table border=0 align="left" bordercolordark="#000000"
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 494px; height: 317px;">
<tr>
<td style="height: 50px" bgcolor="#000000">
    </td>    
    </tr>
<tr>
<td style="height: 121px">
    <table align="left" cellpadding="0" cellspacing="0" 
             
        
        
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 811px; height: 327px; margin-top: 0px;">
            <tr>
                <td class="style9" style="height: 23px; width: 24px;">
                    &nbsp;</td>
                <td class="style9" style="height: 23px; width: 144px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Registro de Usuarios:"></asp:Label>
                </td>
                <td class="style9" style="height: 23px">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px">
                    &nbsp;</td>
                <td class="style9" style="width: 144px">
                    <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblusername" runat="server" Visible="False"></asp:Label>
                                                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 23px;">
                    </td>
                <td class="style9" style="width: 144px; height: 23px;">
                    Nombre de usuario:</td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtusuario" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 25px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; height: 25px;">
                    Nombre completo:</td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtnombres" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 26px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; height: 26px;">
                    Descripción:</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtdes" runat="server" Width="264px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 28px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; height: 28px;">
                    Correo electrónico:</td>
                <td style="height: 28px">
                    <asp:TextBox ID="txtcorreos" runat="server" Width="264px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 26px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; height: 26px;">
                    Contraseña:</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtcontras" runat="server" TextMode="Password" Width="264px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 26px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; height: 26px;">
                    Confirmar contraseña:</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtrecontra" runat="server" TextMode="Password" Width="264px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 30px;">
                    </td>
                <td class="style9" style="width: 144px; height: 30px;">
                <span id ="lblAsignarRol" runat="server">Asignar rol:</span>
                    </td>
                <td style="height: 30px">
                    <asp:CheckBox ID="Ckhabilitar" runat="server" Text="Cuenta habilitada" />
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="width: 144px; " rowspan="2">
                    <asp:ListBox ID="lbxRol" runat="server" Height="62px" Width="156px">
                    </asp:ListBox>
                </td>
                <td style="height: 22px">
                    <asp:Button ID="bntaceptar" runat="server" Text="Aceptar" Width="114px" CssClass="button" />
                    <asp:Button ID="btncancelar" runat="server" Text="Cancelar" Width="98px" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td class="style9" style="width: 24px">
                    &nbsp;</td>
                <td>
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

