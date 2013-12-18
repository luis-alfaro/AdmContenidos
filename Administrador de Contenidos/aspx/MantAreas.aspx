<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantAreas.aspx.vb" Inherits="aspx_MantAreas" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>

</head>

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
  
<table border=0 align="left" bordercolordark="#000000"
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 818px; height: 240px;">
<tr>
<td style="height: 51px; " colspan="2" bgcolor="#000000">
    </td>    
    </tr>
<tr>
<td style="height: 97px; width: 32px;">
    &nbsp;</td>    
<td style="height: 97px">
        <table style="width: 100%; height: 163px;">
            <tr>
                <td style="height: 15px">
        <b><u>Listado de Áreas:</u></b> 
                    </td>
                <td style="height: 15px">
                    </td>
            </tr>
            <tr>
                <td style="height: 15px">
                    <asp:CheckBox ID="chkMostrar" runat="server" AutoPostBack="True" 
                        Text="Mostrar Todos (Muestra También las áreas deshabilitadas)" />
                </td>
                <td style="height: 15px">
                    </td>
            </tr>
            <tr>
                <td style="height: 28px">
        
        <table border="0">
        <tr>
        <td style="height: 17px"></td>
        <td colspan="2" style="height: 17px">
            <asp:Label ID="lblTexto" runat="server" Text="Agregar una nueva área"></asp:Label>
            </td>
        <td style="height: 17px">       
            </td>
            <td style="height: 17px">
                </td>
            <td style="height: 17px">
                    </td>
            <td style="height: 17px">
                    &nbsp;</td>
        </tr>
        <tr>
        <td>Nombre Área</td>
        <td>
            <asp:TextBox ID="txtarea" runat="server"></asp:TextBox></td>
        <td>       Estado</td>
        <td>       
            <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Grabar" Width="65px" CssClass="button" /></td>
            <td>
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
                    </td>
            <td>
                            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="button" 
                                Height="25px" Width="84px" />
                    </td>
        </tr>
        <tr>
        <td style="height: 10px"></td>
        <td style="height: 10px">
            </td>
        <td style="height: 10px">       </td>
        <td style="height: 10px">       
            </td>
            <td style="height: 10px">
                </td>
            <td style="height: 10px">
                &nbsp;</td>
            <td style="height: 10px">
                &nbsp;</td>
        </tr>
        </table>
                </td>
                <td style="height: 28px">
                    </td>
            </tr>
            <tr>
                <td style="height: 148px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="IdArea" HeaderText="Código" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
        <asp:HiddenField ID="HddIdArea" runat="server" Value="0" />
                </td>
                <td style="height: 148px">
                    </td>
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