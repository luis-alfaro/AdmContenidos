<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReporteEstadisticos.aspx.vb" Inherits="ReporteEstadisticos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

    <head>
        <script type="text/javascript" src="js/styleswitcher.js"></script>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css"rel="stylesheet" />
	    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
	    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
        <script type="text/javascript">
            $(document).ready(DocReady);
            function DocReady()
            {
                $("input[data-entryType = 'Date']").datepicker();
            }
        </script>
    </head>
<body>

    <table style="width:100%;" bgcolor="#FFFFFF">
        <tr>
            <td background="images/topLarge.png">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />
					</td>
        </tr>
        <tr>
            <td bgcolor="#000000" style="height: 45px">
                </td>
        </tr>
        <tr>
            <td>
<table border="0" bgcolor="#FFFFFF" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 747px; height: 110px;"  >
    <tr>                    
        <td colspan="9" style="height:10px;">
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="7" style="text-align:center"><h2><b>GENERAR REPORTES ESTADÍSTICOS</b></h2></td>
        <td style="width: 133px">&nbsp;</td>
    </tr>
    <tr>                    
        <td colspan="9" style="height:10px;">
        </td>
    </tr>
<tr>
<td>Desde:</td>
<td>
    <asp:TextBox  ID="txtfechadesde" runat="server" data-entryType="Date"></asp:TextBox>
                                    </td>
<td>Hasta:</td>
<td>
    <asp:TextBox ID="txtfechahasta" runat="server" data-entryType="Date"></asp:TextBox>
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
<td style="width: 133px">
        &nbsp;</td>
</tr>
<tr>
<td></td>
<td>
    <asp:Label ID="lbldesde" runat="server" ForeColor="#FF3300" Text="Label" 
        Visible="False"></asp:Label>
    </td>
<td></td>
<td>
    <asp:Label ID="lblhasta" runat="server" ForeColor="Red" Text="Label" 
        Visible="False"></asp:Label>
    </td>
<td></td>
<td></td>
<td></td>
<td></td>
<td style="width: 133px">&nbsp;</td>
</tr>
<tr>
<th colspan="8"><center>
<asp:Button ID="Button2" runat="server" Text="Mostrar Datos" 
            style="text-align:center" CssClass="button" />
    <asp:Button ID="Button5" runat="server" Text="Imprimir" Width="122px" 
            CssClass="button" />
    <asp:Button ID="Button7" runat="server" Text="Salir" Width="122px" 
            CssClass="button" />
    &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </center>
    </th>
<th style="width: 133px">&nbsp;</th>
</tr>
<tr>
<th colspan="8">



<table border="0">
<tr>
<td></td>
<td>

<div class="scrolling" runat="server" id="divPrint">
    <h3><b>REPORTE GENERAL</b></h3>
    <%--<asp:Label ID="Label1" runat="server" Text="REPORTE GENERAL" Font-Bold="True" 
        Font-Size="Smaller" ForeColor="Black"></asp:Label>--%>
    <br><br />
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
    
    <asp:GridView ID="grdClasicaChip" runat="server" BackColor="White" 
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
    <asp:Button ID="btnClasicaChip" runat="server" Text="Exportar a Excel" 
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
    <h3><b>REPORTE DETALLADO POR KIOSKO</b></h3>
    <%--<asp:Label ID="Label2" runat="server" Text="REPORTE DETALLADO POR KIOSKO" 
            Font-Bold="True" ForeColor="Black" Font-Size="Smaller"></asp:Label>--%>
        <br><br />
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
    <asp:GridView ID="grdClasicaChipDetalle" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" Font-Size="Small">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:Button ID="btnClasicaChipDetalle" runat="server" Text="Exportar a Excel" CssClass="button"/>    
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

    </th>
<th style="width: 133px">



    &nbsp;</th>
</tr>
</table>



            </td>
        </tr>
    </table>


</body>
</asp:Content>

