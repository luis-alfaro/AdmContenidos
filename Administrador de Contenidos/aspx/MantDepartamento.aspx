<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantDepartamento.aspx.vb" Inherits="aspx_MantDepartamento" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <title>
	Administrador de Contenidos (Lista Roles)
</title>

<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />

 <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
 <table  border="0" id="tblBody" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0" cellpadding="0" align="left">
        <tr>
            <td>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />    
            </td>
        </tr>
        <tr>
            <td>
                 <table style="width: 100%; margin-right: 0px; height: 284px;" 
                    >
        <tr>
            <td style="height: 47px; " colspan="3" bgcolor="#000000">
            </td>
        </tr>
        <tr>
            <td style="width: 35px; height: 8px;" ></td>
            <td style="height: 8px" ><b><u>Mantenimiento de Departamentos:</u></b></td>
            <td style="height: 8px" >
            </td>
        </tr>
        <tr>
            <td style="width: 35px; height: 97px;" ></td>
            <td style="height: 97px" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 66px; height: 21px;">
                    <asp:Button ID="btnGrabar" runat="server" CssClass="button" Text="Grabar" 
                                Height="21px" />
                        </td>
                        <td style="width: 196px; height: 78px;">
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Cancelar" 
                        Width="70px" />
                        </td>
                        <td style="height: 78px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 66px">
                            <span style="height: 24px; ">
              <asp:Label ID="Label2" runat="server"></asp:Label>
            </span>
                        </td>
                        <td style="width: 196px">
                            <asp:DropDownList ID="ddldepartamento" runat="server" AutoPostBack="True" 
                    Width="103%" Height="29px" >
            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 66px">
                            <span style="height: 35px; ">
              <asp:Label ID="Label3" runat="server"></asp:Label>
            </span>
                        </td>
                        <td style="width: 196px">
                            <asp:DropDownList ID="ddlprovincia" runat="server" Height="25px" 
                    AutoPostBack="True" Width="103%">
            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 66px">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                        <td style="width: 196px">
                  <asp:TextBox ID="txtubigeo" runat="server" Width="208px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
            </td>
            <td style="height: 97px" >
                </td>
        </tr>
        <tr>
        <td style="width: 35px; height: 118px;"></td>
        <td style="height: 118px">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                GridLines="Vertical" Width="263px" DataKeyNames="ubigeoid">
                <RowStyle BackColor="#F7F7DE" />
                <Columns>
                    <asp:BoundField DataField="UbigeoId" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </td>
        <td style="height: 118px"></td>
        </tr>
        </table>
            </td>
        
        </tr>
    </table>

</BODY>



</asp:Content>

