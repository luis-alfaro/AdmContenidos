<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="prog_videos.aspx.vb" Inherits="aspx_sec_videos" title="Administrador de Contenidos(Secuencia de Videos)" ValidateRequest="false" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
    
    <title>
	    Administrador de Contenidos (Secuencia de Videos)
    </title>
    <script type="text/javascript" src="js/styleswitcher.js"></script>
    <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
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
    marginheight="0">
  
   <TABLE border="0" id="tblBody" bgcolor="#FFFFFF"
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="821px" Height="100px" ImageAlign="RIGHT" 
                                    style="margin-bottom: 0px" />
					</TD>
			</TR>
<TR>
<td colspan="14">

<table border=0 align="left" valign="top" bordercolordark="#000000" 
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 494px;">
<tr>
<td>
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 816px; height: 472px;" 
        border="0">
            <tr align="left" valign="top">
                <td class="style9" style="height: 52px; " colspan="16" bgcolor= "#000000">
                    </td>
            </tr>
            <tr align="left" valign="top">
                <td class="style9" style="height: 22px; width: 511px;">
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 487px;">
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 1426px;" valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; " valign="middle" colspan="3">
                
                    
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Programa de Horarios:"></asp:Label>
                </td>
                <td class="style9" style="height: 22px; width: 1115px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 1154px;" align="left" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 199px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 76px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px" align="center" valign="middle">
                
                    &nbsp;<td class="style9" style="height: 22px; " 
                    valign="middle" colspan="2">
                    
                                                <asp:Button ID="btnFlash" 
            runat="server" Text="Editar Flash" 
                                                    Width="121px" CssClass="button" />
                                                            </td>
                <td class="style9" style="height: 22px" align="right" valign="middle" 
                    colspan="3">
                    
                                                <asp:Button ID="btnVideos" 
            runat="server" Text="Editar Videos" 
                                                    Width="121px" CssClass="button" />
                </td>
            </tr>
            <tr align="left" valign="top">
                <td class="style9" style="height: 13px; width: 511px;">
                    </td>
                <td class="style9" style="height: 13px; width: 487px;">
                    </td>
                <td class="style9" style="height: 13px; width: 1426px;" valign="middle">
                
                    </td>
                <td class="style9" style="height: 13px; width: 1317px;" valign="middle">
                
                    
                </td>
                <td class="style9" style="height: 13px" align="right" valign="middle">
                
                    </td>
                <td class="style9" style="height: 13px; width: 169px;" align="left" 
                    valign="middle">
                
                </td>
                <td class="style9" style="height: 13px; width: 1115px;" align="right" 
                    valign="middle">
                
                    </td>
                <td class="style9" style="height: 13px; width: 1154px;" align="left" 
                    valign="middle">
                
                    </td>
                <td class="style10" style="height: 13px; " align="right" 
                    valign="middle">
                
                    </td>
                <td class="style9" style="height: 13px; width: 76px;" align="right" 
                    valign="middle">
                
                    </td>
                <td class="style9" style="height: 13px" align="center" valign="middle">
                
                    <td class="style9" style="height: 13px; width: 74px;" 
                    valign="middle">
                </td>
                <td class="style9" style="height: 13px" valign="middle">
                    
                    </td>
                <td class="style9" style="height: 13px" align="right" valign="middle">
                    </td>
                <td class="style9" style="height: 13px" valign="middle">
                    </td>
                <td class="style9" style="height: 13px" align="right" valign="middle">
                    
                    &nbsp;</td>
            </tr>
            <tr align="left" valign="top">
                <td class="style9" style="height: 22px; width: 511px;">
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 487px;">
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 1426px;" valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 1317px;" valign="middle">
                
                    
                    <asp:Label ID="lblfecha" runat="server" Visible="False"></asp:Label>
                    <br />
                    Buscar por semana:<br />
                    Día/Mes/Año</td>
                <td class="style9" style="height: 22px" align="right" valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 169px;" align="left" 
                    valign="middle">
                
                    <asp:Label ID="lblmensaje" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style9" style="height: 22px; width: 1115px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 1154px;" align="left" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 199px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px; width: 76px;" align="right" 
                    valign="middle">
                
                    &nbsp;</td>
                <td class="style9" style="height: 22px" align="center" valign="middle">
                
                    &nbsp;<td class="style9" style="height: 22px; width: 74px;" 
                    valign="middle">
                    &nbsp;</td>
                <td class="style9" style="height: 22px" valign="middle">
                    
                    &nbsp;</td>
                <td class="style9" style="height: 22px" align="right" valign="middle">
                    &nbsp;</td>
                <td class="style9" style="height: 22px" valign="middle">
                    &nbsp;</td>
                <td class="style9" style="height: 22px" align="right" valign="middle">
                    
                                                <asp:Button ID="btnRegresar" 
            runat="server" Text="Salir" 
                                                    Width="50px" CssClass="button" />
                </td>
            </tr>
            <tr align="left" valign="top">
                <td class="style9" style="height: 24px; width: 511px;">
                    </td>
                <td class="style9" style="height: 24px; width: 487px;">
                    </td>
                <td class="style9" style="height: 24px; width: 1426px;" valign="middle">
                
                    </td>
                <td class="style9" style="height: 24px; width: 1317px;" valign="middle">
                
                    
                              <asp:TextBox ID="txtFecha" runat="server" Width="104px"  CssClass="TextEntry" data-entryType="Date"></asp:TextBox>
                </td>
                <td class="style9" style="height: 24px" align="right" valign="middle">
                
                    </td>
                <td class="style9" style="height: 24px; width: 169px;" align="left" 
                    valign="middle">
                
                    Filtrar por criterio:<asp:DropDownList ID="ddlCriterios" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style9" style="height: 24px; width: 1115px;" align="right" 
                    valign="middle">
                
                    </td>
                <td class="style9" style="height: 24px; width: 1154px;" align="left" 
                    valign="middle">
                
                    Buscar por hora:</td>
                <td class="style10" style="height: 24px; " align="right" 
                    valign="middle">
                
                    Desde:</td>
                <td class="style9" style="height: 24px; width: 76px;" align="right" 
                    valign="middle">
                
                    <asp:DropDownList ID="cbohini" runat="server">

                        <asp:ListItem Selected="True">06:30</asp:ListItem>
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
                        <asp:ListItem>23:30</asp:ListItem>
                    </asp:DropDownList>
                    
                    </td>
                <td class="style9" style="height: 24px" align="center" valign="middle">
                
                    Hasta:       
                <td class="style9" style="height: 24px; width: 74px;" 
                    valign="middle">
                    <asp:DropDownList ID="cbohfin" runat="server">
                       
                        <asp:ListItem>06:30</asp:ListItem>
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
                </td>
                <td class="style9" style="height: 24px" valign="middle">
                    
                    <asp:Button ID="btnfiltrarHora" runat="server" Font-Size="8pt" Text="Filtrar" 
                        CssClass="button" />
                    
                    </td>
                <td class="style9" style="height: 24px" align="right" valign="middle">
                    </td>
                <td class="style9" style="height: 24px" valign="middle">
                    </td>
                <td class="style9" style="height: 24px" align="right" valign="middle">
                    
                    <asp:Button ID="btnNuevo" runat="server" Font-Size="8pt" Text="Nuevo" CssClass="button" />
                    
                    </td>
            </tr>
            <tr>
                <td class="style9" style="width: 511px; height: 41px;">
                    &nbsp;</td>
                <td class="style9" style="width: 487px; height: 41px;">
                    </td>
                <td class="style9" style="width: 1426px; height: 41px;" valign="top" 
                    align="left">
                    &nbsp;</td>
                
                <td class="style9" style="width: 174px; height: 41px;" valign="top" 
                    align="left" colspan="13">
                    <table style="width: 440%; height: 56px;">
                        <tr>
                            <td style="width: 132px">
                                &nbsp;</td>
                            <td style="width: 151px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 132px">
                    <asp:Button ID="btnPrevio" runat="server" Text="Anterior Semana" 
                        Width="154px" CssClass="button" />
                            </td>
                            <td style="width: 151px">
                    <asp:Button ID="btnSiguiente" runat="server" style="margin-right: 0px" 
                        Text="Siguiente Semana" CssClass="button" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 132px">
                                &nbsp;</td>
                            <td style="width: 151px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                
                <td>
                </td>
                
            </tr>
            
            <tr>
                 <td class="style9" style="width: 511px; height: 64px;">
                     </td>
                 <td class="style9" style="width: 487px; height: 64px;">
                     </td>
                <td class="style9" style="width: 1426px; height: 64px;">
                    </td>
                <td class="style9" style="width: 174px; height: 64px;" colspan="13">
                    <asp:GridView ID="gvPrograma" runat="server"
                        AutoGenerateColumns="False" 
                        Height="66px" PageSize="5" Width="745px" CaptionAlign="Top" 
                        HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="Hora" BackColor="White" BorderColor="#DEDFDE" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Vertical">
                        <RowStyle Height="10px" BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="Hora" HeaderText="Hora">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Lunes">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Lunes")) + "&tp=edt" %>'
                                    Text='<%# Eval("Lunes") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Martes">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Martes")) + "&tp=edt" %>'
                                    Text='<%# Eval("Martes") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Miercoles">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Miercoles")) + "&tp=edt" %>'
                                    Text='<%# Eval("Miercoles") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Jueves">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Jueves")) + "&tp=edt" %>'
                                    Text='<%# Eval("Jueves") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Viernes">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Viernes")) + "&tp=edt" %>'
                                    Text='<%# Eval("Viernes") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sabado">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Sabado")) + "&tp=edt" %>'
                                    Text='<%# Eval("Sabado") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Domingo">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# "videos.aspx?ufil=" + HttpUtility.UrlEncode(Eval("Domingo")) + "&tp=edt" %>'
                                    Text='<%# Eval("Domingo") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
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
                    <br />
                    <br />
                 </td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 511px">
                     &nbsp;</td>
                 <td class="style9" style="width: 487px">
                     &nbsp;</td>
                <td class="style9" style="width: 1426px">
                    &nbsp;</td>
                <td class="style9" style="width: 174px" colspan="13">
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

