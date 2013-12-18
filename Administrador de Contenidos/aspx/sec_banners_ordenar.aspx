<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="sec_banners_ordenar.aspx.vb" Inherits="aspx_sec_banners_ordenar" title="Administrador de Contenidos(Banners)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <head>
    <title>
	Administrador de Contenidos(Banners)
</title>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
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
<td colspan="3">

    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 813px; height: 202px;">
            <tr>
                <td class="style9" style="height: 45px; " colspan="5" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 31px; width: 61px;">
                    </td>
                <td class="style9" style="height: 31px" colspan="2">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Ordenar Banners:"></asp:Label>
                </td>
                <td class="style9" style="height: 31px; width: 358px;">
                    </td>
                <td class="style9" style="height: 31px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 26px;">
                    </td>
                <td class="style9" colspan="2" style="height: 26px">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblidselect" runat="server" Visible="False"></asp:Label>
                                                </td>
                <td class="style9" style="width: 358px; height: 26px;">
                    </td>
                <td style="height: 26px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 23px;">
                    </td>
                <td class="style9" style="height: 23px; text-decoration: underline;" 
                    colspan="2">
                    Secuencia de Banners:</td>
                <td style="height: 23px; width: 358px;">
                    &nbsp;</td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 25px;">
                    &nbsp;</td>
                <td class="style9" colspan="2" rowspan="3">
                    <asp:ListBox ID="LstBanners" runat="server" AutoPostBack="True" Height="180px" 
                        Rows="10" Width="439px"></asp:ListBox>
                </td>
                <td align="left" rowspan="2" valign="bottom" class="style9" 
                    style="width: 358px">
                    <asp:Button ID="btnsubir" runat="server" Enabled="False" Text="Subir" 
                        Width="46px" CssClass="button"/>
                    </td>
                <td align="left" rowspan="2" valign="bottom">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 65px;">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 100px;">
                    </td>
                <td style="height: 100px; width: 358px;" valign="top">
                    <asp:Button ID="btnbajar" runat="server" Enabled="False" Text="Bajar" 
                        Width="46px"  CssClass="button"  />
                </td>
                <td style="height: 100px" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 22px;">
                    &nbsp;</td>
                <td class="style9" style="height: 22px;" colspan="2">
                    &nbsp;</td>
                <td style="height: 22px; width: 358px;">
                    &nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 61px; height: 38px;">
                    </td>
                <td class="style9" style="width: 378px; height: 38px;" align="right">
                    <asp:Button ID="bntaceptar" runat="server" Text="Aceptar" Width="98px"  CssClass="button" />
                    </td>
                <td class="style9" style="width: 18px; height: 38px;">
                    <asp:Button ID="btncancelar" runat="server" Text="Cancelar" Width="98px" CssClass="button"  />
                </td>
                <td style="height: 38px; width: 358px;" align="right">
                    </td>
                <td style="height: 38px" align="right">
                    </td>
            </tr>
            </table>

</td>
</TR>
</TABLE>
</BODY>


</asp:Content>

