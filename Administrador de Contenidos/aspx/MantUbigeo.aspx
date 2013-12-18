<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantUbigeo.aspx.vb" Inherits="aspx_MantUbigeo" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server"> 
     <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" 
    marginheight="0">
     <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px; width: 760px;">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
			
			<tr>
			<td>
			
			    <table style="width:100%;" >
                    <tr>
                        <td style="height: 48px;" colspan="3" bgcolor="#000000">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 33px; height: 28px;">
                            </td>
                        <td style="height: 28px">
                             <b><u>Mantenimiento de Ubigeo:</u></b> </td>
                        <td style="height: 28px">
                                                </td>
                    </tr>
                    <tr>
                        <td style="width: 33px">
                            &nbsp;</td>
                        <td>
                            Listado de Ubigeo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 100px">
                                        <asp:LinkButton ID="LinkButton1" runat="server">Departamento</asp:LinkButton>
                                    </td>
                                    <td style="width: 68px">
                    <asp:LinkButton ID="LinkButton2" runat="server">Provincia</asp:LinkButton>
                                    </td>
                                    <td style="width: 55px">
                    <asp:LinkButton ID="LinkButton3" runat="server">Distritos</asp:LinkButton>
                                    </td>
                                    <td>
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 33px; height: 163px;">
                            </td>
                        <td style="height: 163px">
			
        <asp:TreeView ID="treeubigeo" runat="server" ImageSet="Simple" ShowLines="True">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
                            ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
			
			            </td>
                        <td style="height: 163px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 33px">
                            &nbsp;</td>
                        <td>
			
			    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Vertical" BorderStyle="None">
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" 
                        HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
			
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </td>
			</tr>
						
</TABLE><br>
</BODY>
    </asp:Content>