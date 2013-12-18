<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="sec_banners.aspx.vb" Inherits="aspx_sec_banners" title="Administrador de Contenidos(Secuencia de Banners)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>
 <title>
	Administrador de Contenidos (Secuencia de Banners)
</title>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
</head>

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
  
 <TABLE border="0" id="tblBody" bgcolor="#FFFFFF"
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="832px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
<TR>
<td colspan="2">

<table border=0 align="left" bordercolordark="#000000" 
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 830px; height: 156px;">
<tr>
<td style="height: 200px">
    <table align="left" cellpadding="0" cellspacing="0"
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 830px; height: 64px;">
            <tr>
                <td class="style9" style="height: 50px; " colspan="6" bgcolor="#000000">
                    </td>
            </tr>
            <tr>
                <td class="style9" style="height: 23px; width: 71px;">
                    &nbsp;</td>
                <td class="style9" colspan="4" style="height: 23px">
                    <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Lista de banners:"></asp:Label>
                    <asp:Label ID="lblcomand" runat="server" Text="%" Visible="False"></asp:Label>
                    <asp:Label ID="lblparam" runat="server" Text="%" Visible="False"></asp:Label>
                </td>
                <td class="style9" style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" style="height: 24px; width: 71px;">
                    </td>
                <td class="style9" style="height: 24px; width: 177px;" align="left">
                    <table style="width: 220%;">
                        <tr>
                            <td colspan="3">
                    Criterios :
                    <asp:DropDownList ID="ddlCriterios" runat="server" AutoPostBack="True" 
                        Height="24px" Width="111px">
                    </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 60px">
                    <asp:Button ID="btnnuevo" runat="server" Text="Nuevo" Width="60px" CssClass="button" />
                            </td>
                            <td style="width: 25px">
                                <asp:Button ID="btnOrdenarSec" runat="server" Text="Ordenar" Width="60px" CssClass="button" />
                            </td>
                            <td style="width: 47px">
    <asp:Button ID="Button7" runat="server" Text="Salir" Width="71px" 
            CssClass="button" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style9" style="height: 24px; width: 202px;" align="left">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 46px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px; width: 41px;">
                    &nbsp;</td>
                <td class="style9" style="height: 24px">
                    &nbsp;</td>
            </tr>
            
            <tr>
                 <td class="style9" style="width: 71px; height: 82px;">
                     </td>
                <td class="style9" style="height: 82px;" colspan="4">
                    <asp:GridView ID="gvListaBanners" runat="server"
                        AutoGenerateColumns="False"
                        Height="20px" PageSize="15" Width="667px" CaptionAlign="Top" 
                        HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="IDX" BackColor="White" BorderColor="#DEDFDE" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Vertical">
                        <RowStyle Height="10px" BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="IDX" HeaderText="ID" ReadOnly="True" 
                                Visible="False">
                                <ItemStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Banner" HeaderText="Banner" >
                                <ControlStyle Height="10px" Width="250px" />
                                <HeaderStyle Height="10px" Width="100px" />
                                <ItemStyle Height="10px" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NuOrd" HeaderText="Orden" Visible="False" >
                                <HeaderStyle Height="10px" Width="20px" />
                                <ItemStyle Height="10px" Width="20px" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" 
                                HeaderText="Editar" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" 
                                HeaderText="Eliminar" />
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
                 </td>
                <td class="style9" style="width: 174px; height: 82px;">
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

