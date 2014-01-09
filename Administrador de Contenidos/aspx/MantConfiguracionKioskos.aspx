<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantConfiguracionKioskos.aspx.vb" Inherits="aspx_MantConfiguracionKioskos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
<script>
  function validarSiNumero(numero){
    if (!/^([0-9])*$/.test(numero))
      alert("El valor " + numero + " no es un número");
  }
</script>
</head>
    <TABLE border="0" id="tblBody"
            
    style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 819px; margin-right: 0px;" cellspacing="0"
			cellpadding="0" align="left">
			<tr>
			<td>
			<table border="0"  style="height: 547px">
			<tr>
			    <td style="height: 50px; " colspan="4" bgcolor="#000000" >
                     <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" Width="827px" Height="100px" ImageAlign="RIGHT" />
			    </td>
			</tr>
			<tr>
			    <td style="height: 50px; " colspan="4" bgcolor="#000000" > &nbsp;</td>
			</tr>
            <tr>
			    <td style="height: 10px; " colspan="4"> &nbsp;</td>
			</tr>
			<tr>
			    <td style="height: 11px; width: 38px;" >&nbsp;</td>
			    <td style="height: 11px; width: 620px;" ><b><u>Mantenimiento de Configuración de Kioskos:</u></b></td>
			    <td style="height: 11px; width: 50px;" >&nbsp;</td>
			    <td style="height: 11px; width: 50px;" >&nbsp;</td>
			</tr>
            <tr>
			    <td style="height: 10px; " colspan="4"> &nbsp;</td>
			</tr>
			<tr>
			<td style="width: 38px; height="10px" >
                </td>
			<td style="width: 620px;" >
                <table style="width:100%; height: 72px;">
                    <tr>
                        <td style="width: 160px">Nombre:</td>
                        <td style="width: 320px">
                            <asp:HiddenField ID="hddID" runat="server" Value="0" />
                            <asp:TextBox ID="txtnombre" runat="server" Width="272px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Servidor:</td>
                        <td style="width: 320px">
                            <asp:TextBox ID="txtServer" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Servidor Simulador:</td>
                        <td style="width: 320px">
                            <asp:TextBox ID="txtServerSimulador" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Servidor de Impresión:</td>
                        <td style="width: 320px">
                            <asp:TextBox ID="txtServerPrint" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Servidor de Comisiones:</td>
                        <td style="width: 320px">
                            <asp:TextBox ID="txtServerCom" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    </table>
                </td>
			<td style="width: 50px;" >
                </td>
			<td style="width: 50px;" >
                </td>
			</tr>
			<tr>
			    <td style="height: 10px; width: 38px;" >&nbsp;</td>
			    <td style="height: 10px; width: 620px;" ></td>
			    <td style="width: 50px; height: 10px;" ></td>
			    <td style="width: 50px; height: 10px;" >&nbsp;</td>
			</tr>
            <tr>
			    <td style="width: 38px;" >
                </td>
			    <td style="width: 620px;" >
                <table style="width:100%; height: 72px;">
                    <tr>
                        <td style="width: 160px">Bin 1:</td>
                        <td style="width: 320px">
                            <input id="txtBin1" type="text" runat="server" style="width: 90%"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Longitud Tarjeta Bin 1:</td>
                        <td style="width: 320px">
                            <input id="txtLongitudTarjetaBin1" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Posicion Inicial Bin 1:</td>
                        <td style="width: 320px">
                            <input id="txtPosicionInicialBin1" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Longitud Tarjeta Bin 1:</td>
                        <td style="width: 320px">
                            <input id="txtLongitudBinBin1" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    </table>
                </td>
			    <td style="width: 50px;" >
                </td>
			    <td style="width: 50px;" >
                </td>
			</tr>
			
            <tr>
			    <td style="height: 10px; width: 38px;" >&nbsp;</td>
			    <td style="height: 10px; width: 620px;" ></td>
			    <td style="width: 50px; height: 10px;" ></td>
			    <td style="width: 50px; height: 10px;" >&nbsp;</td>
			</tr>
            <tr>
			    <td style="width: 38px;" >
                </td>
			    <td style="width: 620px;" >
                <table style="width:100%; height: 72px;">
                    <tr>
                        <td style="width: 160px">Bin 2:</td>
                        <td style="width: 320px">
                            <input id="txtBin2" type="text" runat="server" style="width: 40%"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Longitud Tarjeta Bin 2:</td>
                        <td style="width: 320px">
                            <input id="txtLongitudTarjetaBin2" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Posicion Inicial Bin 2:</td>
                        <td style="width: 320px">
                            <input id="txtPosicionInicialBin2" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 160px">Longitud Tarjeta Bin 2:</td>
                        <td style="width: 320px">
                            <input id="txtLongitudBinBin2" type="text" onchange="validarSiNumero(this.value);" runat="server" style="width: 80px"/>
                        </td>
                        <td></td>
                    </tr>
                    </table>
                </td>
			    <td style="width: 50px;" >
                </td>
			    <td style="width: 50px;" >
                </td>
			</tr>
			<tr>
			    <td style="height: 8px; width: 38px;">&nbsp;</td>
			    <td style="height: 8px; width: 620px;">&nbsp;</td>
			    <td style="width: 50px; height: 8px;" >&nbsp;</td>
			    <td style="width: 50px; height: 8px;" >&nbsp;</td>
			</tr>
			<tr>
			    <td style="height: 39px; width: 38px;">
                    &nbsp;</td>
			    <td style="height: 39px; width: 620px;">
                    <asp:Button ID="btngrabar" runat="server" CssClass="button" Text="GrabarDatos" Width="93px" />
                    &nbsp;
                    <asp:Button ID="btncancelar" runat="server" CssClass="button" Text="Cancelar" Width="93px" />
                    &nbsp;
                    <asp:Button ID="btnEliminar" runat="server" CssClass="button" Text="Eliminar Configuración" Width="130px" />
                </td>
			    <td style="width: 50px; height: 39px" ></td>
			    <td style="width: 50px; height: 39px" >&nbsp;</td>
			</tr>
            <tr>
			    <td style="height: 39px; width: 38px;">&nbsp;</td>
			    <td style="height: 39px; width: 620px;">
                    <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                </td>
			    <td style="width: 50px; height: 39px" ></td>
			    <td style="width: 50px; height: 39px" >&nbsp;</td>
			</tr>
			</table>
			</td>
			</tr>
</TABLE>
</asp:Content>

