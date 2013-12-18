<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LogEnvioData.aspx.vb" Inherits="aspx_LogEnvioData" title="Untitled Page" %>

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
			<td style="height: 46px; " colspan="4" bgcolor="#000000"></td>
			</tr>
			<tr>
			<td style="height: 35px; width: 43px;" ></td>
			<td style="width: 670px; height: 35px" ><b><u> Registro de Errores:</u></b></td>
			<td style="height: 35px" >
                </td>
			    <td style="height: 35px">
                </td>
			</tr>
			<tr>
			<td style="height: 27px; width: 43px;"></td>
			<td style="width: 670px; height: 27px;">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 65px">
                            &nbsp;</td>
                        <td class="style10" style="width: 483px">
                            &nbsp;</td>
                        <td>
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="83px" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 65px">
                            &nbsp;</td>
                        <td class="style10" style="width: 483px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
			<td style="height: 27px" >
                </td>
			</tr>
			<tr>
			<td style="height: 86px; width: 43px;"></td>
			<td style="width: 670px; height: 86px;">
            <div style="Overflow-x: scroll;  Overflow-y: scroll; height:357px ; width:673px">
                <asp:ListBox ID="lbxError" runat="server" Height="357px" Width="1032px">
                </asp:ListBox>
                </div>
                </td>
			<td style="height: 86px" >
                </td>
			</tr>
			</tr>
			</tr>
			</tr>
			</tr>
			<tr>
			<td style="height: 86px; width: 43px;">&nbsp;</td>
			<td style="width: 670px; height: 86px;">


                &nbsp;</td>
			<td style="height: 86px" >
                &nbsp;</td>
			</tr>
			</table>
			</td>
			</tr>
</TABLE>
</asp:Content>

