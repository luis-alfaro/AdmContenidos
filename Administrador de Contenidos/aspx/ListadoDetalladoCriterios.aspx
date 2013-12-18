<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ListadoDetalladoCriterios.aspx.vb" Inherits="aspx_ListadoDetalladoCriterios" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <head>

<link href="estilos/Estilos.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR><TD style="height: 19px">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                    Width="843px" Height="100px" ImageAlign="Right" />
			</TD></TR>
			<tr><td>
			<table border="0" 
                    style="width: 846px; height: 526px">
			<tr>
			<td style="height: 47px; " colspan="3" bgcolor="#000000">&nbsp;</td>
			</tr>
			<tr>
			<td style="height: 26px; width: 318px;">
                &nbsp;</td>
			<td style="height: 26px; width: 270px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Underline="True" 
                    Text="Lista de Kioscos con Criterios:"></asp:Label>
                </td>
			<td style="width: 446px; height: 26px;">
                </td>
			</tr>
			<tr>
			<td style="width: 318px; height: 28px;"></td>
			<td style="width: 270px; height: 28px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seleccione Kiosko:</td>
			<td style="width: 446px; height: 28px;">
                <asp:Button ID="btnAtras" runat="server" Text="Atrás" CssClass="button"  />
                <asp:Button ID="btnAvanzar" runat="server" Text="Adelante" 
                    style="width: 77px" CssClass="button" />
                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="61px" CssClass="button" />
                </td>
			</tr>
			<tr>
			<td style="width: 318px; height: 321px;">
			    &nbsp;</td>
			<td style="width: 270px; height: 321px;">
			<div style="width:195px; height:380px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important;">
        <asp:TreeView ID="treetienda" runat="server" ImageSet="Simple" ShowLines="True" 
                    ExpandDepth="1" Height="380px" Width="195px">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
                            ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
			</div>
			</td>
			<td style="width: 446px; height: 321px;">
			<div style="border:1px solid black;width:400;height:376px; overflow-y:scroll;overflow-x:scroll;">
                <asp:GridView ID="GridView1" runat="server"  Width="500px" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                    GridLines="Vertical">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="idkiosko" HeaderText="Id" />
                        <asp:BoundField DataField="KioscoNombre" HeaderText="Kiosco" />
                        <asp:BoundField HeaderText="Lunes" DataField="Lunes" />
                        <asp:BoundField HeaderText="Martes" DataField="Martes" />
                        <asp:BoundField HeaderText="Miercoles" DataField="Miercoles" />
                        <asp:BoundField HeaderText="Jueves" DataField="Jueves" />
                        <asp:BoundField HeaderText="Viernes" DataField="Viernes" />
                        <asp:BoundField HeaderText="Sabado" DataField="Sabado" />
                        <asp:BoundField HeaderText="domingo" DataField="Domingo" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
			</div>
			</td>
			</tr>
			</table>
			</td>
			</tr>
</TABLE>
</body>
</asp:Content>

