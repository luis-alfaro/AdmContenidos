<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListadoTiendas.aspx.vb" Inherits="aspx_ListadoTiendas" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <link href="estilos/grilla.css" rel="stylesheet" type="text/css" />
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="js/styleswitcher.js"></script>
<link href="Styles/Blue.css" rel="stylesheet" type="text/css" title="Azul"/>
<link href="Styles/Grey.css" rel="stylesheet" type="text/css" title="Gris"/>
<link href="Styles/Brown.css" rel="stylesheet" type="text/css" title="Marron"/>
<link href="Styles/Yellow.css" rel="stylesheet" type="text/css" title="Amarillo"/>

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
  
 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="827px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
<TR>
<td>
<table border="0" style="height: 599px; width: 827px">
<tr>
    <td style="height: 46px" colspan="2" bgcolor="#000000">
    
        &nbsp;</td>
</tr>
<tr>
    <td style="height: 33px; width: 32px;">
    
        &nbsp;</td>
    <td style="height: 33px">
    
        <u><b>Listado de Tiendas:</b></u> </td>
</tr>
<tr>
    <td style="height: 30px; width: 32px;">
    
        &nbsp;</td>
    <td style="height: 30px">
    
        <asp:Button ID="Button1" runat="server" Text="Nuevo" CssClass="button" 
            Width="76px"/>
    
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
    
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="button" 
                                Height="25px" Width="84px" />
                        <asp:CheckBox ID="chkMostrarTodos" runat="server" AutoPostBack="True" 
            Text="Mostrar Todos (Muestra también las tiendas deshabilitadas)" />
    
    </td>
</tr>
<tr>
    <td style="height: 108px; width: 32px;">
    
        &nbsp;</td>
    <td style="height: 108px">
    
        <asp:GridView ID="dgvtiendas" runat="server" 
            AutoGenerateColumns="False" Width="780px" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Vertical">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código Sucursal" />
                <asp:BoundField DataField="sucursal" HeaderText="Nombre Tienda" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Dirección" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_sucursal_banco" HeaderText="Cod Banco" >
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEditar" runat="server">Editar</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </td>
</tr>
<tr>
    <td style="width: 32px">
    
        &nbsp;</td>

    <td>
    
        &nbsp;</td>

</tr>
</table>
</td>
</TR>
</TABLE>

</BODY>
</asp:Content>

