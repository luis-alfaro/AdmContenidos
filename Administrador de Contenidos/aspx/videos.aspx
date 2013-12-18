<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="videos.aspx.vb" Inherits="aspx_videos" title="Administrador de Contenidos(Videos)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
        <title>
	        Administrador de Contenidos (Videos)
        </title>
        
          <script type="text/javascript" language="javascript" src="js/colorPicker.js"></script>
          <link rel="stylesheet" href="estilos/colorPicker.css" type="text/css"></link>
          <link rel="stylesheet" href="estilos/Estilos.css" type="text/css"></link>

         <script language='javascript' src="../js/popcalendar.js"> 
         function dateArrival_onclick() {} </script> 

        
        <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css"  rel="stylesheet" />	
	    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
	    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
	    
    </head>


    <script type="text/javascript">
    $(document).ready(DocReady);
    function DocReady()
    {
        $("input[data-entryType = 'Date']").datepicker();
    }
    </script>

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0" bgcolor="#FFFFFF">

 <TABLE border="0" id="tblBody"
            
         style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 742px; height: 938px;" cellspacing="0"
			cellpadding="0" align="left" frame="void">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="815px" Height="100px" ImageAlign="RIGHT" />
					            <img src="../../fotooooooo.png" /></TD>
			</TR>
<TR>
<TD colspan="2">

  
    <table align="left" cellpadding="0" cellspacing="0"
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 813px; height: 827px;">
            <tr>
                <td class="style9" style="height: 48px; " colspan="6" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 227px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 689px;">
                    
                    <table style="width: 371%; height: 402px;">
                        <tr>
                            <td style="width: 142px">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Nuevo Programa:"></asp:Label>
                            </td>
                            <td style="width: 232px">
                                &nbsp;</td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                    <asp:Label ID="lblfecha" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblcodDetalle" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 232px">
                    <asp:Label ID="lbltipo" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblcodigo" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td colspan="2">
                
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Nombre:</td>
                            <td style="width: 232px">
                
                    <asp:TextBox ID="txtnombre" runat="server" MaxLength="50" Width="235px"></asp:TextBox>
                            </td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Color:</td>
                            <td style="width: 232px">
                
                    <input id="txtColor" type="text" onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly"/></td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Criterio:</td>
                            <td style="width: 232px">
                
                    <asp:DropDownList ID="ddlCriterios" runat="server" Height="25px" Width="133px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                                                            </td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 164px; width: 142px">
                                Fecha:</td>
                            <td style="height: 164px; width: 232px">
                
                    <br />
                                Fecha Inicio:<br />

                    <asp:TextBox ID="txtFechaInicio" runat="server" Height="22px" 
                        CssClass="TextEntry" data-entryType="Date" ></asp:TextBox>
                    <br />
                                &nbsp;<br />
                                Fecha Final:<br />
                    <asp:TextBox ID="txtFechaFinal" runat="server" Height="22px" 
                        CssClass="TextEntry" data-entryType="Date" ></asp:TextBox>
                    <br />
                    <br />
                    <br />
                
                                Desde:<asp:DropDownList ID="cbohini" runat="server">
                        <asp:ListItem>07:00</asp:ListItem>
                        <asp:ListItem>07:30</asp:ListItem>
                        <asp:ListItem Selected="True">08:00</asp:ListItem>
                        <asp:ListItem>08:30</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>09:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem>23:30</asp:ListItem>
                    </asp:DropDownList>
                        <br />
                    <br />
                
                                Hasta:                     <asp:DropDownList ID="cbohfin" runat="server" style="margin-left: 0px">
           
                        <asp:ListItem>07:00</asp:ListItem>
                        <asp:ListItem>07:30</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>08:30</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>09:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>12:30</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>13:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>17:30</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>18:30</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>19:30</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>20:30</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>21:30</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>22:30</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                        <asp:ListItem Selected="True">23:30</asp:ListItem>
                    </asp:DropDownList>
                        <br />
                    <br />
                        
                                                            </td>
                                                            <td style="height: 164px; width: 81px">
                                                                </td>
                                                            <td style="height: 164px; width: 249px">
                
                
                   
                
                
                                                                <asp:ListBox ID="lbxHorarios" runat="server" Height="191px" Width="187px">
                                                                </asp:ListBox>
                
                
                   
                
                
                                                            </td>
                                                            <td style="height: 164px">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 142px">
                
                
                    Horario:</td>
                            <td style="width: 232px">
                
                    <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar Horario" 
                        Width="136px" CssClass="button"  />
                                        
                            </td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                
                
          
                
                
                                             <asp:Button ID="btnQuitarHorario" runat="server" Text="Quitar Horario" 
                        Width="87px" CssClass="button" />     
                
                
          
                
                
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td style="width: 232px">
                                &nbsp;</td>
                            <td style="width: 81px">
                                &nbsp;</td>
                            <td style="width: 249px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    
                    </td>
                <td class="style9" style="height: 24px; " colspan="4">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 227px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 689px;">
                    
                    Seleccione sus videos:
                                    
                    </td>
                <td class="style9" style="height: 24px; " colspan="4">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 227px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 689px;">
                    
                                    <asp:ListBox ID="lstFilesVideos" runat="server" 
                                        Width="660px" Height="107px" SelectionMode="Multiple"></asp:ListBox>
                    
                    </td>
                <td class="style9" style="height: 24px; " colspan="4">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 227px;">
                    </td>
                <td class="style9" style="height: 24px; width: 689px;">
                    
                    <asp:Button ID="btnagregar" runat="server" Font-Size="8pt" Text="Agregar"  CssClass="button"/>
                    
                    </td>
                <td class="style9" style="height: 24px; " colspan="4">
                    
                    &nbsp;</td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 227px">
                     &nbsp;</td>
                <td class="style9" style="width: 689px">
                    &nbsp;</td>
                <td class="style9" colspan="4">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style9" style="height: 8px; width: 227px;">
                    </td>
                <td class="style9" style="height: 8px; width: 689px;">
                    <asp:GridView ID="gvListaPresentacion" runat="server" CssClass="letranormal" 
                        AutoGenerateColumns="False" 
                        Height="20px" PageSize="15" Width="660px" CaptionAlign="Top" 
                        HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="Vertical" 
                        style="margin-top: 0px">
                        <RowStyle Height="10px" BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="posicion" HeaderText="Posicion" Visible="False">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="titulo" HeaderText="Titulo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="direccion" HeaderText="Ruta">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle 
                            Height="10px" HorizontalAlign="Left" BackColor="#6B696B" Font-Bold="True" 
                            ForeColor="White" />
                        <EditRowStyle Height="10px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                 </td>
                <td class="style9" style="height: 8px; ">
                    </td>
                <td class="style9" style="height: 8px; ">
                    &nbsp;</td>
                <td class="style9" style="height: 8px; ">
                
                    &nbsp;<td class="style9" style="height: 8px; width: 156px;" align="right">
                
                
                    </td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 227px">
                     &nbsp;</td>
                <td class="style9" style="width: 689px">
                    &nbsp;</td>
                <td class="style9" colspan="4">
                    &nbsp;</td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 227px">
                     &nbsp;</td>
                <td class="style9" style="width: 689px">
                    
                    <asp:Button ID="btnGuardar" runat="server" Font-Size="8pt" Text="Guardar" 
                        Height="26px" CssClass="button" />
                    
                    <asp:Button ID="btnCancelar" runat="server" Font-Size="8pt" Text="Cancelar" CssClass="button" />
                    
                    <asp:Button ID="btnEliminar" runat="server" Font-Size="8pt" Text="Eliminar" 
                        CssClass="button" />
                    
                    </td>
                <td class="style9" colspan="3">
                    
                    &nbsp;</td>
                <td class="style10" style="width: 156px">
                    
                    &nbsp;</td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 227px">
                     &nbsp;</td>
                <td class="style9" style="width: 689px">
                    &nbsp;</td>
                <td class="style9" colspan="4">
                    &nbsp;</td>
            </tr>
            
        </table>

</TD>
</TR>
</TABLE>
</BODY>


</asp:Content>

