<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lista_users.aspx.vb" Inherits="aspx_lista_users" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <title>
	Administrador de Contenidos(Lista Users)
</title>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">

 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="820px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
<TR>
<td colspan="2">
  
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 818px; height: 84px;">
            <tr>
                <td class="style9" colspan="5" style="height: 54px" bgcolor="#000000">
                </td>
            </tr>
            <tr>
                <td class="style9" style="height: 3px; width: 67px;">
                    &nbsp;</td>
                <td class="style9" colspan="3" style="height: 3px">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Lista de usuarios:"></asp:Label>
                    <asp:Label ID="lblparam" runat="server" Text="%" Visible="False"></asp:Label>
                    <asp:Label ID="lblcomand" runat="server" Text="%" Visible="False"></asp:Label>
                </td>
                <td class="style9" style="height: 3px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 7px; width: 67px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 49px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 202px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 22px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 7px; width: 67px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 49px;">
                    <table style="width: 702%;">
                        <tr>
                            <td style="width: 32px">
                    <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" Width="60px" CssClass="button" />
                            </td>
                            <td style="width: 30px">
                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="61px" CssClass="button" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style9" style="height: 7px; width: 202px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 22px;">
                    </td>
                <td class="style9" style="height: 7px">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 7px; width: 67px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 49px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 202px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px; width: 22px;">
                    &nbsp;</td>
                <td class="style9" style="height: 7px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 125px; width: 67px;">
                    &nbsp;</td>
                
                <td class="style9" style="height: 125px;" colspan="3">
                    <asp:GridView ID="gvListaUsers" runat="server" 
                        AutoGenerateColumns="False" 
                        Height="20px" PageSize="15" Width="641px" CaptionAlign="Top" 
                        HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="UserID" BackColor="White" BorderColor="#DEDFDE" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Vertical">
                        <RowStyle Height="10px" BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" 
                                Visible="False">
                                <ItemStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UserName" HeaderText="Usuario" >
                                <HeaderStyle Height="10px" Width="20px" />
                                <ItemStyle Height="10px" Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FullNames" HeaderText="Nombres" >
                                <ControlStyle Height="10px" Width="250px" />
                                <HeaderStyle Height="10px" Width="100px" />
                                <ItemStyle Height="10px" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Enabled" HeaderText="Habilitado" >
                                <HeaderStyle Height="10px" Width="20px" />
                                <ItemStyle Height="10px" Width="20px" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                HeaderText="Acciones" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" 
                                HeaderText="Eliminar" />
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
                
                <td class="style9" style="width: 174px; height: 125px;">
                    &nbsp;</td>
                
            </tr>
            
            </table>
    <br />

</td>
</TR>
</TABLE>
</BODY>

</asp:Content>

