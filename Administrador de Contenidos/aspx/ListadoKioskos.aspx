<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListadoKioskos.aspx.vb" Inherits="aspx_ListadoKioskos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/styleswitcher.js"></script>

<script>
  function validarSiNumero(numero){
    if (!/^([0-9])*$/.test(numero))
      alert("El valor " + numero + " no es un número");
  }
</script>
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
			<tr>
			<td>
			<table border="0"
                    style="height: 208px; width: 818px">
			<tr>
			<td style="height: 46px; " colspan="5" bgcolor="#000000"></td>
			</tr>
			<tr>
			<td style="height: 35px; width: 30px;" ></td>
			<td style="width: 520px; height: 35px" ><b><u> Listado Kioscos por Tienda y Área:</u></b></td>
			<td style="height: 35px; width: 108px" >
                                                &nbsp;</td>
			<td style="height: 35px" >
                </td>
			    <td style="height: 35px">
                </td>
			</tr>
			<tr>
			<td style="height: 73px; width: 30px;"></td>
			<td style="width: 520px; height: 73px;">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 65px">
                            Tienda:</td>
                        <td class="style10" style="width: 175px">
                <asp:DropDownList ID="ddltienda" runat="server" Height="26px" Width="160px">
                </asp:DropDownList>
                        </td>
                        <td>
                <asp:Button ID="btnnuevo" runat="server" CssClass="button" Text="Nuevo" Width="83px" />
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="83px" CssClass="button" />
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="button" 
                                Height="25px" Width="84px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 65px">
                            Area:</td>
                        <td class="style10" style="width: 175px">
                <asp:DropDownList ID="ddlarea" runat="server" Height="26px" Width="160px">
                </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 65px">
                            &nbsp;</td>
                        <td class="style10" style="width: 175px">
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Consultar" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
			<td style="width: 108px; height: 73px;" >
                                                </td>
			<td style="height: 73px" >
                </td>
			</tr>
			<tr>
			<td style="height: 86px; width: 30px;"></td>
			<td style="width: 520px; height: 86px;">
                <asp:GridView ID="gvkioskos" runat="server" AutoGenerateColumns="False" 
                    Width="528px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="idkiosko" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="nombre_kiosko" HeaderText="Nombre del Kiosko" 
                            ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="piso" HeaderText="Piso" />
                        <asp:BoundField DataField="ip" HeaderText="IP" />
                        <asp:BoundField DataField="Ubigeo" HeaderText="Ubicación" >                        
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Configuracion" HeaderText="Configuración" >
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
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
			<td style="width: 108px; height: 86px;" >
                                                </td>
			<td style="height: 86px" >
                </td>
			</tr>
			</tr>
			</tr>
			</tr>
			</tr>
			</table>
			</td>
			</tr>
</TABLE>
</asp:Content>

