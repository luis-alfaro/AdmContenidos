<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListadoCriterios.aspx.vb" Inherits="aspx_ListadoCriterios" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head><script type="text/javascript" src="js/styleswitcher.js"></script><link href="estilos/Estilos.css" rel="stylesheet" type="text/css" /></head><table bgcolor="#FFFFFF" >
        <tr>
            <td>
                <table style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 828px; height: 110px;"  >
                    <tr>
                        <td style="height: 10px; " colspan="3">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/aspx/images/BannerTop.png" Width="826px" Height="100px" 
                    ImageAlign="Left" />
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 44px; " colspan="3" bgcolor="#000000">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 10px; width: 36px;">
                            </td>
                        <td style="height: 10px; " colspan="2">
                            <b><u>Listado de Criterios:</u> 
                            <asp:CheckBox ID="chkHabilitados" runat="server" AutoPostBack="True" 
                                Text="Mostrar Todos (Muestra también los criterios deshabilitados)" />
                            </b></td>
                    </tr>
                    <tr>
                        <td style="width: 36px">
                            &nbsp;</td>
                        <td style="width: 782px">

       <asp:GridView ID="GridView1" runat="server" 
           AutoGenerateColumns="False" Width="656px" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                                GridLines="Vertical"  >
           <RowStyle BackColor="#F7F7DE" />
           <Columns>
               <asp:BoundField DataField="idcriterio" HeaderText="Id" Visible="False" />
               <asp:BoundField DataField="nombre" HeaderText="Nombre del Criterio" />
               <asp:TemplateField HeaderText="Añadir">
                   <ItemTemplate>
                       <asp:HyperLink ID="lnkeditar" runat="server">Añadir</asp:HyperLink>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Seleccionar">
                   <ItemTemplate>
                       <asp:HyperLink ID="lnkseleccionar" runat="server">VerDetalle</asp:HyperLink>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Habilitar">
                   <ItemTemplate>
                       <asp:CheckBox ID="chkDeshabilitar" runat="server"  
                           Checked='<%# Bind("FlagActivo") %>' TabIndex = '<%# Bind("idcriterio") %>' 
                           oncheckedchanged="chkDeshabilitar_CheckedChanged" 
                           AutoPostBack="True" />
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
           <FooterStyle BackColor="#CCCC99" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
           <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" />
           <HeaderStyle BackColor="#6B696B" ForeColor="White" />
           <AlternatingRowStyle BackColor="White" />
       </asp:GridView>
                        </td>
                        <td style="width: 782px">

                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
<table border="0" style="width: 768px">
<tr>
<td></td>
<td>    

    <asp:Button ID="Button1" runat="server" Text="Nuevo" CssClass="button"/>    
    <asp:Button ID="Button2" runat="server" Text="Cancelar Vista de Detalle" CssClass="button" 
        Width="160px" />
    <asp:Button ID="Button3" runat="server" Text="Actualizar Estados" CssClass="button"
        Width="125px" />
    <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="61px" 
        CssClass="button" />
    </td>
<td style="width: 25px"></td>
<td></td>
</tr>
<tr>
<td colspan="3">

       &nbsp;</td>
<td></td>
</tr>
<tr>
<td colspan="3">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        Width="734px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
        style="margin-top: 0px">
        <RowStyle BackColor="#F7F7DE"/>
        <Columns>
            <asp:BoundField DataField="iddetalle_criterio" HeaderText="Id" 
                Visible="False" >
                
            </asp:BoundField>
            <asp:BoundField DataField="Sucursal" HeaderText="Nombre" >
               
            </asp:BoundField>
            <asp:BoundField DataField="Nombre del Area" HeaderText="Nombre del Área" />
            <asp:BoundField DataField="Estado del Criterio" 
                HeaderText="Estado del Criterio" />
            <asp:TemplateField HeaderText="A/I">
                <ItemTemplate>
                    <asp:CheckBox ID="chkestado" runat="server" Checked="True" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#6B696B"  ForeColor="White" Font-Bold="True" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </td>
<td></td>
</tr>
<tr>
<td>

    &nbsp;</td>
<td>    

    <asp:ListBox ID="ListBox1" runat="server" Height="16px" Visible="False" 
        Width="16px"></asp:ListBox>
    </td>
<td style="width: 25px">
    &nbsp;</td>
<td></td>
</tr>
</table>


                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 36px">
                            &nbsp;</td>
                        <td style="width: 782px">
                            &nbsp;</td>
                        <td style="width: 782px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


    </asp:Content>

