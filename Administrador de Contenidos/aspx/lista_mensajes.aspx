<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="lista_mensajes.aspx.vb" Inherits="aspx_lista_mensajes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
    <title>
	Administrador de Contenidos(Mensajes)
	
	
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
                <td class="style9" style="height: 48px; " colspan="4" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 27px; width: 55px;">
                    </td>
                <td class="style9" style="height: 27px; width: 136px;">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Lista de Mensajes:"></asp:Label>
                    </td>
                <td class="style9" style="height: 27px">
                    &nbsp;</td>
                <td class="style9" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 55px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 136px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 55px;">
                    </td>
                <td class="style9" style="height: 18px; width: 136px;">
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="60px" CssClass="button" />
                </td>
                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

                <td class="style9" style="height: 18px; width: 46px;">
                    </td>

            </tr>
            <tr>
                <td class="style9" style="height: 18px; width: 55px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 136px;">
                    &nbsp;</td>
                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

                <td class="style9" style="height: 18px; width: 46px;">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="style9" style="width: 55px; height: 119px;">
                    </td>
                <td class="style9" style="height: 119px;" colspan="3">
                    <asp:GridView ID="gvListaMensajes" runat="server" 
                        AutoGenerateColumns="False" 
                        Height="20px" PageSize="15" Width="682px" CaptionAlign="Top" 
                        HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="ID" BackColor="White" BorderColor="#DEDFDE" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Vertical">
                        <RowStyle Height="10px" BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                Visible="False">
                                <ItemStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOMBRE_TARJETA" HeaderText="Tipo Tarjeta" >
                                <ControlStyle Height="10px" Width="250px" />
                                <HeaderStyle Height="10px" Width="20px" />
                                <ItemStyle Height="10px" Width="120px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESC_TARJETA" HeaderText="Descripción" >
                                <HeaderStyle Height="10px" Width="100px" />
                                <ItemStyle Height="10px" Width="500px" Wrap="True" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                HeaderText="Acciones" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            No se encontraron registros.
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle 
                            Height="10px" HorizontalAlign="Left" BackColor="#6B696B" Font-Bold="True" 
                            ForeColor="White" />
                        <EditRowStyle Height="10px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    </td>
                
            </tr>
            
            <tr>
                 <td class="style9" style="width: 55px">
                     &nbsp;</td>
                 <td class="style9" style="width: 136px">
                     &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
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

