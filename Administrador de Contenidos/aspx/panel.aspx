<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="panel.aspx.vb" Inherits="aspx_panel" title="Administrador de Contenidos(Panels)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

    <title>
	Administrador de Contenidos (Panels)
</title>
<head>

<script type="text/javascript" language="javascript" src="js/colorPicker.js"></script>
<link rel="stylesheet" href="estilos/colorPicker.css" type="text/css"></link>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />

</head>		

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" bgcolor="#FFFFFF"
    marginheight="0">
  
 <TABLE border="0" id="tblBody" backcolor="#000000" 
            
         style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 587px; height: 276px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
<td>

<table border=0 align="left" bordercolordark="#000000" bgcolor="#FFFFFF"
         
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 823px; height: 750px;">

<td style="width: 565px; height: 99px" valign="top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="859px" Height="99px" 
        ImageAlign="RIGHT" style="margin-left: 0px" />
    </td>    
   
    <tr>

<td style="width: 565px; height: 88px" valign="top">
    <table align="left" cellpadding="0" cellspacing="0" border= "0"
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 864px; height: 726px;">
            <tr>
                <td class="style9" bgcolor="#000000"
                    style="height: 45px; text-decoration: underline; " 
                    align="left">
                    &nbsp;</td>
                <td class="style9" bgcolor="#000000"
                    style="height: 45px; text-decoration: underline; " 
                    align="left" colspan="8">
                    </td>
            </tr>
            <tr>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 672px;" 
                    align="left">
                    &nbsp;</td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 672px;" 
                    align="left">
                    </td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; " 
                    align="left" colspan="3">
                    <b>Administrador del Panel:</b> </td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; " 
                    align="left">
                    </td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 1036px;" 
                    align="left">
                    </td>
                <td class="style9" style="height: 18px; " colspan="2">
                    </td>
            </tr>
            <tr style="background-color: #C0C0C0">
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 672px;" 
                    align="left">
                    &nbsp;</td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 672px;" 
                    align="left">
                    &nbsp;</td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 575px;" 
                    align="left">
                    General:</td>
                <td class="style9" style="height: 18px; " colspan="2">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                <td class="style9" style="height: 18px; ">
                    &nbsp;</td>
                <td class="style9" 
                    style="height: 18px; text-decoration: underline; width: 1036px;" 
                    align="left">
                    Fecha y Hora:</td>
                <td class="style9" style="height: 18px; " colspan="2">
                    <asp:CheckBox ID="chkRelog" runat="server" Font-Bold="True" 
                        Text=" Reloj Visible" />
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 672px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 672px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 575px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; " colspan="2">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; ">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 1036px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 178px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 75px;" align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 672px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 672px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 575px;">
                    Color de borde:</td>
                <td class="style9" style="height: 24px; " colspan="2">
                    <br />
                    <input id="txtColorBordePanel" style="width: 201px" type="text"  onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly" /><br />
                </td>
                <td class="style9" style="height: 24px; ">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 1036px;" align="left">
                    Color de fondo:</td>
                <td class="style9" style="height: 24px; width: 178px;">
                    <input id="txtColorFondoRelog" style="width: 201px" type="text" onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly"  /></td>
                <td class="style9" style="height: 24px; width: 75px;" align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="width: 672px; height: 22px;" valign="top" 
                    align="left">
                    &nbsp;</td>
                
                <td class="style9" style="width: 672px; height: 22px;" valign="top" 
                    align="left">
                    &nbsp;</td>
                
                <td class="style9" style="width: 575px; height: 22px;" valign="top" 
                    align="left">
                    &nbsp;</td>
                
                <td class="style9" style="width: 188px; height: 22px;" valign="top">
                    <br />
                    <br />
                </td>
                
                <td class="style9" style="width: 2px; height: 22px;" valign="top" align="left">
                    <br />
                </td>
                
                <td class="style9" style="width: 2px; height: 22px;" valign="top" align="left">
                    &nbsp;</td>
                
                <td class="style9" style="width: 1036px; height: 22px;">
                    Fuente:</td>
                
                <td class="style9" style="height: 22px;" colspan="2">
                    <asp:DropDownList ID="cboRJFuente" runat="server" 
                        Height="22px" Width="210px">
                    </asp:DropDownList>
                </td>
                
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 17px;" valign="top">
                    &nbsp;</td>
                
                <td class="style9" style="width: 672px; height: 17px;" valign="top">
                    &nbsp;</td>
                
                <td class="style9" style="width: 575px; height: 17px;" valign="top">
                    <asp:Button ID="btnmostrar" runat="server" Height="23px" Text="Archivo Flash" 
                        Width="87px" CssClass="button" />
                 </td>
                
                <td class="style9" style="height: 17px;" valign="top" colspan="2">
                    <asp:TextBox ID="txtrutaflash" runat="server" TextMode="MultiLine" 
                        Width="274px" Height="54px"></asp:TextBox>
                </td>
                
                <td class="style9" style="height: 17px;" valign="top">
                    &nbsp;</td>
                
                <td class="style9" style="width: 1036px; height: 17px;" align="left">
                    Tamaño de letra:</td>
                
                <td class="style9" style="height: 17px;" colspan="2">
                    <asp:DropDownList ID="cboRJTamano" runat="server" 
                        Height="22px" Width="210px">
                    </asp:DropDownList>
                                                </td>
                
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; " align="left" rowspan="2">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; " align="left" rowspan="2">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; " align="left" rowspan="2">
                    &nbsp;</td>
                <td class="style9" align="left" colspan="2" rowspan="2">
                    <asp:Panel ID="PanFilesFlash" runat="server" Height="77px" Visible="False" 
                        Width="270px">
                        <table align="left" cellpadding="0" cellspacing="0" 
    class="style8" style="height: 81px">
                            <tr>
                                <td>
                                    <asp:ListBox ID="lstFilesFlash" runat="server" AutoPostBack="True" 
                                        Width="271px"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
                <td class="style9" align="left" rowspan="2">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 16px;" align="left" 
                     valign="middle">
                    Color de letra:</td>
                <td class="style9" style="width: 178px; height: 16px;">
                    <input id="txtColorLetraReloj" style="width: 201px" type="text" onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly"  /></td>
                <td class="style9" style="width: 75px; height: 16px;">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 1036px; height: 40px;" align="left" 
                     valign="middle">
                    Negrita:</td>
                <td class="style9" style="height: 40px;" colspan="2">
                    <asp:CheckBox ID="ckRJnegrita" runat="server" />
                 </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 35px;">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 35px;">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 35px;">
                    &nbsp;</td>
                <td class="style9" style="height: 35px;" colspan="2">
                                    <table __designer:mapid="1dd" style="width:148%;">
                                        <tr __designer:mapid="1de">
                                            <td __designer:mapid="1df" colspan="2">
                                                <asp:CheckBox ID="chkFlash" runat="server" 
                                                    Font-Bold="True" Text="Flash Visible" />
                                            </td>
                                            <td __designer:mapid="1e0" style="width: 160px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr __designer:mapid="1e2">
                                            <td __designer:mapid="1e3" style="width: 137px">
                                                Reloj:</td>
                                            <td __designer:mapid="1e4" style="width: 160px">
                                                <asp:CheckBox ID="chkHoraLarga" runat="server" 
                                                    Text="Hora Larga" />
                                            </td>
                                            <td __designer:mapid="1e4" style="width: 160px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr __designer:mapid="1e6">
                                            <td __designer:mapid="1e7" style="width: 137px; height: 23px">
                                                &nbsp;</td>
                                            <td __designer:mapid="1e8" style="width: 160px; height: 23px">
                                                <asp:CheckBox ID="chkMostrarFecha" runat="server" 
                                                    Text="Mostrar Fecha" />
                                            </td>
                                            <td __designer:mapid="1e8" style="width: 160px; height: 23px">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                 </td>
                <td class="style9" style="height: 35px;">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 35px;" align="center">
                    <asp:Button ID="btnRJVistaPrevia" runat="server" Height="23px" Text="Vista Previa" 
                        Width="87px" CssClass="button" />
                    </td>
                <td class="style9" style="height: 35px;" colspan="2">
                    <asp:TextBox ID="txtRJPrevioFuente" runat="server" Height="67px" Width="213px"></asp:TextBox>
                    </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; ">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; ">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; ">
                    &nbsp;</td>
                <td class="style9" colspan="2">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; ">
                    &nbsp;</td>
                <td class="style9" colspan="2">
                    <asp:CheckBox ID="chkLogo" runat="server" Font-Bold="True" 
                        Text="Logo Visible" />
                    &nbsp;&nbsp;&nbsp; </td>
            </tr>
            
            <tr style="background-color: #C0C0C0">
                <td class="style9" 
                     style="width: 672px; text-decoration: underline; height: 18px;" 
                     align="left">
                    &nbsp;</td>
                <td class="style9" 
                     style="width: 672px; text-decoration: underline; height: 18px;" 
                     align="left">
                    &nbsp;</td>
                <td class="style9" 
                     style="width: 575px; text-decoration: underline; height: 18px;" 
                     align="left">
                    Banner:</td>
                <td class="style9" colspan="2" style="height: 18px">
                    &nbsp;</td>
                <td class="style9" style="height: 18px">
                    &nbsp;</td>
                <td class="style9" 
                     style="width: 1036px; text-decoration: underline; height: 18px;" 
                    align="left">
                    Video:</td>
                <td class="style9" style="height: 18px;" colspan="2">
                    </td>
            </tr>
            
            <tr>
                <td class="style9" align="left" style="width: 672px">
                    &nbsp;</td>
                <td class="style9" align="left" style="width: 672px">
                    &nbsp;</td>
                <td class="style9" align="left" style="width: 575px">
                    Color de fondo:</td>
                <td class="style9" style="height: 31px; width: 188px;">
                    <input id="txtColorFondoBanner" style="width: 201px" type="text" onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly" /></td>
                <td class="style9" style="height: 31px; width: 2px;">
                    &nbsp;</td>
                <td class="style9" style="height: 31px; width: 2px;">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 31px;" align="left">
                    Color de fondo:</td>
                <td class="style9" style="width: 178px; height: 31px;">
                    <input id="txtColorFondoVideo" style="width: 201px" type="text"  onclick="startColorPicker(this)" 
                        onkeyup="maskedHex(this)" runat =server readonly="readonly" /></td>
                <td class="style9" style="width: 75px; height: 31px;">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 36px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 36px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 36px;" align="left">
                    Fuente:</td>
                <td class="style9" colspan="2" style="height: 36px">
                    <asp:DropDownList ID="cboMQFuente" runat="server" 
                        Height="22px" Width="210px">
                    </asp:DropDownList>
                 </td>
                <td class="style9" style="height: 36px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 36px;" align="left">
                    Volumen:</td>
                <td class="style9" style="height: 36px;" colspan="2">
                    <asp:DropDownList ID="cboVDVolumen" runat="server" 
                        Height="22px" Width="65px">
                    </asp:DropDownList>
                 </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 34px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 34px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 34px;" align="left">
                    Tamaño de letra:</td>
                <td class="style9" colspan="2" style="height: 34px">
                    <asp:DropDownList ID="cboMQTamano" runat="server" 
                        Height="22px" Width="210px">
                    </asp:DropDownList>
                 </td>
                <td class="style9" style="height: 34px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 34px;" align="left">
                    Posición<br />
                    Derecha / Izquierda:</td>
                <td class="style9" style="height: 34px;" colspan="2">
                    <asp:CheckBox ID="ckVDDerecha" runat="server" AutoPostBack="True" 
                        Text="Izquierda" />
                 </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 26px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 26px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 26px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 26px; width: 188px;">
                    &nbsp;</td>
                <td class="style9" style="height: 26px; width: 2px;">
                    &nbsp;</td>
                <td class="style9" style="height: 26px; width: 2px;">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 26px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 26px;" colspan="2">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 27px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 27px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 27px;" align="left">
                    Negrita:</td>
                <td class="style9" colspan="2" style="height: 27px">
                    <asp:CheckBox ID="ckMQnegrita" runat="server" />
                 </td>
                <td class="style9" style="height: 27px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 27px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 27px;" colspan="2">
                    <asp:DropDownList ID="cboVDOrigen" runat="server" 
                        Height="22px" Width="130px" Visible="False">
                        <asp:ListItem Value="1">Archivo de Video</asp:ListItem>
                        <asp:ListItem Value="2">Archivo de Imagen</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 65px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 65px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 65px;" align="left">
                    &nbsp;</td>
                <td class="style9" colspan="2" style="height: 65px">
                    <asp:CheckBox ID="chkBanner" runat="server" Font-Bold="True" 
                        Text="Banner Visible" />
                 </td>
                <td class="style9" style="height: 65px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 65px;" align="left">
                    <asp:Button ID="btnmostrarIMG" runat="server" Height="23px" Text="Archivo Imagen" 
                        Width="96px" CssClass="button" Visible="False" />
                    </td>
                <td class="style9" style="height: 65px;" colspan="2">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="70px" CssClass="button" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="61px" CssClass="button" />
                    <asp:TextBox ID="txtrutaIMG" runat="server" TextMode="MultiLine" 
                        Width="274px" Height="43px" Visible="False"></asp:TextBox>
                    </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 39px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 39px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 39px;" align="left">
                    Velocidad
                    <br />
                    (mili seg):</td>
                <td class="style9" colspan="2" style="height: 39px">
                    <asp:DropDownList ID="cboMQvelocidad" runat="server" 
                        Height="22px" Width="65px">
                    </asp:DropDownList>
                    &nbsp;</td>
                <td class="style9" style="height: 39px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 39px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 39px;" colspan="2">
                                    <asp:ListBox ID="lstFilesIMG" runat="server" AutoPostBack="True" 
                                        Width="271px" Height="56px" Visible="False"></asp:ListBox>
                    </td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 21px;" align="left">
                    Posición<br />
                    Arriba / Abajo:</td>
                <td class="style9" colspan="2" style="height: 21px">
                    <asp:CheckBox ID="ckMQArriba" runat="server" AutoPostBack="True" Text="Abajo" />
                 </td>
                <td class="style9" style="height: 21px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 178px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 75px; height: 21px;" align="left">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style9" style="width: 672px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 672px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 575px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" colspan="2" style="height: 21px">
                    <asp:TextBox ID="txtnombre" runat="server" Width="156px" Visible="False"></asp:TextBox>
                    </td>
                <td class="style9" style="height: 21px">
                    &nbsp;</td>
                <td class="style9" style="width: 1036px; height: 21px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="width: 178px; height: 21px;" align="left">
                    <asp:TextBox ID="txtdes" runat="server" TextMode="MultiLine" Width="123px" 
                        Visible="False"></asp:TextBox>
                </td>
                <td class="style9" style="width: 75px; height: 21px;" align="left">
                    &nbsp;</td>
            </tr>
            
        </table>
    </td>    
   
    </tr>
   
</table>

</td> 
</TR>
</table>

</asp:Content>

