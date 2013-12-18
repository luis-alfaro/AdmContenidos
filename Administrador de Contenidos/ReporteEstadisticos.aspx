<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReporteEstadisticos.aspx.vb" Inherits="ReporteEstadisticos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

<head>
        <script type="text/javascript" src="js/styleswitcher.js"></script>
        <link href="aspx/Styles/Blue.css"rel="stylesheet" type="text/css" title="Azul"/>
        <link href="aspx/Styles/Grey.css" rel="stylesheet" type="text/css" title="Gris"/>
        <link href="aspx/Styles/Brown.css" rel="stylesheet" type="text/css" title="Marron"/>
        <link href="aspx/Styles/Yellow.css" rel="stylesheet" type="text/css" title="Amarillo"/>
        <link href="aspx/estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <link href="aspx/estilos/Estilos.css"   rel="stylesheet" type="text/css" title="Azul"/>
        <link type="text/css" href="aspx/css/css/ui-lightness/jquery-ui-1.8.16.custom.css"rel="stylesheet" />
	    <script type="text/javascript" src="aspx/css/js/jquery-1.6.2.min.js"></script>
	    <script type="text/javascript" src="aspx/css/js/jquery-ui-1.8.16.custom.min.js"></script>
</head>
<body>

<script type="text/javascript">
    $(document).ready(DocReady);
    function DocReady()
    {
        $("input[data-entryType = 'Date']").datepicker();
    }
    </script>
    
    
    
<br />
<b>Generar Reportes Estadísticos</b>
<br>
<table border="0">
<tr>
<td>Desde:</td>
<td>
    
    &nbsp;<asp:TextBox  ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox>
                                    </td>
<td>Hasta:</td>
<td>
    <asp:TextBox 
        ID="txtfechahasta" runat="server" data-entryType="Date"></asp:TextBox>
                                    </td>
<td>Tipo Reporte:</td>
<td>
    <asp:DropDownList ID="ddltiporeporte" runat="server">
    </asp:DropDownList>
                                                </td>
<td>Tienda:</td>
<td>
        <asp:DropDownList ID="ddltiendas" runat="server" >
        </asp:DropDownList>
        
                                    </td>
</tr>
<tr>
<td></td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtfechadesde" ErrorMessage="Ingrese Fecha  Inicio"></asp:RequiredFieldValidator>
    </td>
<td></td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtfechahasta" Display="Dynamic" 
        ErrorMessage="Ingrese Fecha  Fin"></asp:RequiredFieldValidator>
    </td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<th colspan="8"><center>
<asp:Button ID="Button2" runat="server" Text="Mostrar Datos" 
            style="text-align: right" CssClass="button" />
    <asp:Button ID="Button5" runat="server" Text="Imprimir" Width="122px" 
            CssClass="button" />
    <asp:Button ID="Button7" runat="server" Text="Salir" Width="116px" 
            CssClass="button" />
    &nbsp;</center>
    </th>
</tr>
</table>



<table border="0">
<tr>
<td></td>
<td>

<div class="scrolling" runat="server" id="divPrint">
    <asp:Label ID="Label1" runat="server" Text="REPORTE GENERAL" Font-Bold="True" 
        Font-Size="Smaller" ForeColor="Red"></asp:Label>
    
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:TemplateField HeaderText="Acciones" Visible="False">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkver0" runat="server">Detalles</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

    <asp:Button ID="Button8" runat="server" Text="Exportar a Excel" 
        CssClass="button" />
    </div><br><br />
    <div class="scrolling">
    <asp:GridView ID="GridView2" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button9" runat="server" Text="Exportar a Excel" CssClass="button"/>
    </div><br><br>
    <div class="scrolling">
    <asp:GridView ID="GridView3" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button10" runat="server" Text="Exportar a Excel" CssClass="button"/>
    </div><br><br>
    <div class="scrolling">

    <asp:GridView ID="GridView4" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button11" runat="server" Text="Exportar a Excel" CssClass="button"/>
    </div><br><br>
    <div class="scrolling">
    <asp:GridView ID="GridView5" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        Font-Size="Small" ForeColor="Black">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:HiddenField ID="hddtienda" runat="server" />
        
        <asp:Button ID="Button12" runat="server" Text="Exportar a Excel" CssClass="button"/>
</div>
                                    </td>
<td></td>
</tr>
<tr>
<td></td>
<td >
<br><br><div class="scroll">
    <asp:Label ID="Label2" runat="server" Text="REPORTE DETALLADO POR KIOSKO" 
            Font-Bold="True" ForeColor="Red" Font-Size="Smaller"></asp:Label>
        </b>
    <asp:GridView ID="gvdetalle" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:Button ID="Button13" runat="server" Text="Exportar a Excel" CssClass="button"/>
    
    </div><br><br>
    <div class="scroll">

    <asp:GridView ID="gvdetalle2" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button14" runat="server" Text="Exportar a Excel" CssClass="button"/>
    
    </div><br><br>
    <div class="scroll">

    <asp:GridView ID="gvdetalle3" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button15" runat="server" Text="Exportar a Excel" CssClass="button"/>
    
    </div><br><br>
    <div class="scroll">

    <asp:GridView ID="gvdetalle4" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button16" runat="server" Text="Exportar a Excel" CssClass="button"/>
    
    </div><br><br>
    <div class="scroll">
    <asp:GridView ID="gvdetalle5" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:Button ID="Button17" runat="server" Text="Exportar a Excel" CssClass="button" />
    
    </div>
</td>
<td></td>
</tr>
</table>

</body>
</asp:Content>

