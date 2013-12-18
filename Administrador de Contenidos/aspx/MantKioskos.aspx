<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantKioskos.aspx.vb" Inherits="aspx_MantKioskos" title="Untitled Page" %>

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
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="827px" Height="100px" ImageAlign="RIGHT" />
					</td>
			</tr>
			<tr>
			<td style="height: 50px; " colspan="4" bgcolor="#000000" >
                &nbsp;</td>
			</tr>
			<tr>
			<td style="height: 11px; width: 38px;" >
                &nbsp;</td>
			<td style="height: 11px; width: 368px;" >
                <b><u>Mantenimiento de Kioscos:</u></b></td>
			<td style="height: 11px; width: 236px;" >
                &nbsp;</td>
			<td style="height: 11px; width: 236px;" >
                &nbsp;</td>
			</tr>
			<tr>
			<td style="width: 38px;" >
                </td>
			<td style="width: 368px;" >
                <table style="width:101%; height: 72px;">
                    <tr>
                        <td>
                            Nombre:</td>
                        <td style="width: 272px">
                <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Tienda:</td>
                        <td style="width: 272px">
                <asp:TextBox ID="txttienda" runat="server" ReadOnly="True"
                    Width="272px"></asp:TextBox>
                        </td>
                        <td>
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="..." />
                                                </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            (Solo se usa para cambiar la ubicación del kiosco)</td>
                    </tr>
                    </table>
                </td>
			<td style="width: 236px;" >
                </td>
			<td style="width: 236px;" >
                </td>
			</tr>
			<tr>
			    &nbsp;</td>
			<td style="height: 160px; width: 38px;" >
                                                &nbsp;</td>
			<td style="height: 160px; width: 368px;" >
                                                <asp:TreeView ID="treetienda" runat="server" 
                    ExpandDepth="0" ImageSet="Simple" 
                    Visible="False" NodeIndent="10">
                                                    <ParentNodeStyle Font-Bold="False" />
                                                    <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                                                    <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" 
                                                        HorizontalPadding="0px" VerticalPadding="0px" />
                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                                                        HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
                                                <asp:HiddenField ID="hddidtienda" 
                    runat="server" />
                </td>
			<td style="width: 236px; height: 160px;" ></td>
			<td style="width: 236px; height: 160px;" >&nbsp;</td>
			</tr>
			</tr>
			<td style="height: 80px; width: 38px;" >
                &nbsp;<td style="height: 80px; width: 368px;" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 13px; height: 33px;">
                            Piso:</td>
                        <td style="width: 180px; height: 33px;">
                            <input id="Text1" type="text"  
                                                    onchange="validarSiNumero(this.value);" runat="server" 
                                style="width: 38px"/></td>
                    </tr>
                    <tr>
                        <td style="width: 13px; height: 33px;">
                            IP:</td>
                        <td style="width: 180px; height: 33px;">
                            <table style="width: 169%;">
                                <tr>
                                    <td style="width: 36px">
                <asp:TextBox ID="txtip1" runat="server" MaxLength="3" 
                    Width="34px"></asp:TextBox>
                                                </td>
                                    <td style="width: 3px">
                                        .</td>
                                    <td style="width: 31px">
                                        <asp:TextBox ID="txtip2" runat="server" 
                    MaxLength="3" Width="36px"></asp:TextBox>
                                                </td>
                                    <td style="width: 3px">
                                        .</td>
                                    <td style="width: 10px">
                                        <asp:TextBox ID="txtip3" runat="server" 
                    MaxLength="3" Width="33px"></asp:TextBox>
                                                </td>
                                    <td style="width: 2px">
                                        .</td>
                                    <td style="width: 28px">
                                        <asp:TextBox ID="txtip4" runat="server" 
                    MaxLength="3" Width="34px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 13px">
                            Área:</td>
                        <td style="width: 180px">
                <asp:DropDownList ID="ddlareas" runat="server">
                </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <td style="width: 236px; height: 80px;" >
                <asp:HiddenField ID="hddkiosko" runat="server" Value="0" />
                </td>
                <td style="width: 236px; height: 80px;" >
                    &nbsp;</td>
			</tr>
			</tr>
			</tr>
			<td style="height: 8px; width: 38px;">&nbsp;</td>
			<td style="height: 8px; width: 368px;">&nbsp;</td>
			<td style="width: 236px; height: 8px;" >
                &nbsp;</td>
			<td style="width: 236px; height: 8px;" >
                &nbsp;</td>
			</tr>
			</tr>
			<td style="height: 39px; width: 38px;">
                &nbsp;</td>
			<td style="height: 39px; width: 368px;">
                <asp:Button ID="btngrabar" runat="server" CssClass="button" Text="GrabarDatos" 
                    Width="93px" />
                &nbsp;<asp:Button ID="btncancelar" runat="server" CssClass="button" Text="Cancelar" 
                    Width="93px" />
                                                &nbsp;<asp:Button ID="btnEliminar" 
                    runat="server" CssClass="button" Text="Eliminar Kiosco" Width="99px" />
                                                </td>
			<td style="width: 236px; height: 39px" >
                <asp:TextBox ID="TextBox1" runat="server" Height="16px" Visible="False" 
                    Width="16px"></asp:TextBox>
                </td>
			<td style="width: 236px; height: 39px" >
                &nbsp;</td>
			</tr>
			    </table>
			</td>
			</tr>
</TABLE>
</asp:Content>

