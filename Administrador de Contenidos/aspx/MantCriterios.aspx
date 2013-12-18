<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantCriterios.aspx.vb" Inherits="aspx_MantCriterios" title="Untitled Page" %>

<%@ Register assembly="ASTreeView" namespace="Geekees.Common.Controls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">

    <script type="text/javascript" src="js/styleswitcher.js"></script>
<link href="Styles/Blue.css" rel="stylesheet" type="text/css" title="Azul"/>
<link href="Styles/Grey.css" rel="stylesheet" type="text/css" title="Gris"/>
<link href="Styles/Brown.css" rel="stylesheet" type="text/css" title="Marron"/>
<link href="Styles/Yellow.css" rel="stylesheet" type="text/css" title="Amarillo"/>
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />

<link href="devjoker.css" rel="stylesheet" type="text/css" />
    <link href="css/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
        <script src="js/flexigrid.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript"></script>
    <body>
 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 747px; height: 110px;"  
            cellspacing="0"cellpadding="0" >
			<TR><TD style="height: 19px">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/aspx/images/BannerTop.png" Width="816px" Height="100px" 
                    ImageAlign="RIGHT" />
					</TD>
			</TR>
			<tr>
			<td>
			<table border="0" >
<tr><td style="height: 53px; " colspan="6" bgcolor="#000000"  >&nbsp;</td>
</tr>
<tr><td style="height: 23px; width: 213px;"  ></td>
    <td style="height: 23px" colspan="4"  >
    <b><u>Mantenimiento de Criterios:</u></b></td>
<td style="height: 23px">
                                                </td>
</tr>
<tr><td class="style9" style="width: 213px"  ></td>
    <td style="width: 50px"  >Nombre Criterio:</td>
<td colspan="3">
    <asp:TextBox ID="txtnomcriterio" runat="server" 
        Width="420px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtnomcriterio" Display="Dynamic" 
        ErrorMessage="Ingrese Nombre del Criterio"></asp:RequiredFieldValidator>
                                                </td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td style="width: 213px" class="style9"></td>
<td colspan="4"><hr/></td>
<td>&nbsp;</td>
</tr>
<tr><td style="width: 213px" class="style9" ></td>
    <td  align="right" style="width: 50px" >Ubicación:</td>
<td style="width: 127px" >
    <div style="height:130px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important; width: 213px;">
        <asp:RadioButtonList ID="chklstdep" runat="server" AutoPostBack="True" 
            Width="100%">
        </asp:RadioButtonList>
    </div>
    </td>
<td style="width: 325px" class="style9" >
<div style="height:127px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important;">
    <asp:RadioButtonList ID="chklistprov" runat="server" AutoPostBack="True" 
        Width="100%">
    </asp:RadioButtonList>
           </div>                                     </td>
    <td style="width: 202px" >
    <div style="width:202px; height:128px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important;">
        <asp:RadioButtonList ID="chklstdist" runat="server" AutoPostBack="True" 
            Width="100%">
        </asp:RadioButtonList>
    </div>
                                                </td>
    <td style="width: 202px" >
        &nbsp;</td>
    </tr>
<tr><td style="width: 213px" class="style9" ></td>
    <td align="right" colspan="4"><hr></td>
    <td align="right">&nbsp;</td>
        </tr>
    <tr>
    <td style="width: 213px" class="style9" >
    
    </td>
    <td align="right" style="width: 50px" >
    
        &nbsp;</td>
    <td colspan="2" >
    <div style="height:144px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important;">
    
        Tienda:<asp:CheckBoxList ID="chklsttiendas" runat="server" 
            AppendDataBoundItems="True" Width="100%">
    </asp:CheckBoxList>
    </div></td>
    <td >
        Área:<div 
            style="width:201px; height:130px; overflow-x: hidden;overflow-y:scroll;overflow:-moz-scrollbars-vertical !important;">
    <asp:CheckBox ID="chkactivar" runat="server" AutoPostBack="True" Text="Activar Todos" />
    <br />
    <asp:CheckBoxList ID="chklstareas" runat="server" AppendDataBoundItems="True" 
                Height="20px" Width="100%">
    </asp:CheckBoxList>
    </div>
        
        </td>
    <td >
        &nbsp;</td>
    </tr>
    <tr><td style="width: 213px" class="style9" ></td>
    <td  align="right" colspan="4"><hr />
        <asp:Button ID="Button3" runat="server" Text="Agregar al Detalle" 
            Width="120px" CssClass="button" />
        <asp:Button ID="Button2" runat="server" Text="Grabar y Salir" Width="120px" CssClass="button"
             />
        <asp:Button ID="Button4" runat="server" Text="Grabar Sin Salir" Width="120px" 
            CssClass="button" ToolTip="Graba el Detalle Sin Salir " />
        <asp:Button ID="Button5" runat="server" Text="Cancelar" Width="120px" 
            CssClass="button" CausesValidation="False" />
            <hr />
        </td>
    <td  align="right">&nbsp;</td>
        </tr>
        <tr>
<td class="style9" style="width: 213px" >&nbsp;</td>
<td colspan="4">
<b>Detalle del Criterio</b>
<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        Width="734px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="iddetalle_criterio" HeaderText="Id" 
                Visible="False" />
            <asp:BoundField DataField="Sucursal" HeaderText="Nombre" />
            <asp:BoundField DataField="Nombre del Area" HeaderText="Nombre del Área" />
            <asp:BoundField DataField="Estado del Criterio" 
                HeaderText="Estado del Criterio" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

<hr/></td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td class="style9" style="width: 213px" ></td>
<td colspan="4"> <u>Detalle de Criterios a Grabar</u></td>
<td> &nbsp;</td>
</tr>
<tr><td class="style9" style="width: 213px"  ></td>
    <td align="right" colspan="4">
    <div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Vertical" >
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </td>
        </div>
    <td align="right">
        &nbsp;</td>
                </tr>
<tr><td style="width: 213px" class="style9" ></td>
    <td style="text-align: center;" colspan="2">
    <asp:HiddenField ID="hddidubigeo" runat="server" />

    <asp:HiddenField ID="hddidcriterio" runat="server" />
    </td>
<td style="width: 325px" class="style9" >
    <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
    </td><td style="width: 202px" >
        <asp:ListBox ID="ListBox2" runat="server" Visible="False"></asp:ListBox>
    </td>
                <td style="width: 202px" >
                    &nbsp;</td>
                </tr>
</table>
			</td>
			</tr>
</TABLE>
</body>
</asp:Content>