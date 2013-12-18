<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmTemp.aspx.vb" Inherits="aspx_frmTemp" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
    <p>
        &nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <p>
        <br />
    <table align="left" cellpadding="0" cellspacing="0" 
             
        style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 685px; height: 428px;">
            <tr>
                <td class="style9" style="height: 24px; width: 116px;">

  
    <table style="width: 100%; height: 951px;">
        <tr>
            <td class="style34" style="width: 52px; height: 51px;">
                </td>
            <td class="style35" style="width: 368px; height: 51px;">
                </td>
            <td class="style36" style="height: 51px">
                </td>
            <td class="style37" style="height: 51px">
                </td>
        </tr>
        <tr>
            <td class="style34" style="width: 52px">
            </td>
            <td class="style35" style="width: 368px">
                <b><u>Actualización de Imagenes en los RipleyMáticos</u></b></td>
            <td class="style36">
            </td>
            <td class="style37">
            </td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                </td>
            <td class="style4" style="width: 368px; height: 13px;">
                <b>PASO 1:</b></td>
            <td style="height: 13px">
                                                </td>
            <td style="height: 13px">
                                                </td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 416px;">
            </td>
            <td class="style4" style="width: 368px; height: 416px;">
                <asp:TreeView ID="tvDirectorios" runat="server" ImageSet="Arrows" Width="269px">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <Nodes>
                        <asp:TreeNode Text="Promociones" Value="\Promociones">
                            <asp:TreeNode Text="Ahora o Nunca" Value="\Promociones\Ahora_Nunca"></asp:TreeNode>
                            <asp:TreeNode Text="Productos Financieros" 
                                Value="\Promociones\producto_financiero">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ofertas de Seguros" Value="\Promociones\ofertas_seguro">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Establecimientos" Value="\Promociones\establecimientos"></asp:TreeNode>
                            <asp:TreeNode Text="Otras Promociones" Value="\Promociones\otras_promociones"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Productos" Value="\productos">
                            <asp:TreeNode Text="Ripley Clásica" Value="\productos\ripley_clasica"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\productos\ripley_silver_visa">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" 
                                Value="\productos\ripley_silver_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\productos\ripley_gold_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun " Value="\productos\ripley_platinum_visa"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\productos\cts"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\productos\deposito_plazo"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\productos\ahorros"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivos" Value="\productos\prestamos">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Tasas y Tarifas" Value="\tasas_tarifas">
                                                    <asp:TreeNode Text="Ripley Clásica" Value="\tasas_tarifas\t_clasica"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\tasas_tarifas\t_silver_visa">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" Value="\tasas_tarifas\t_silver_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\tasas_tarifas\t_gold_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun" Value="\tasas_tarifas\t_platinum"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\tasas_tarifas\cts"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\tasas_tarifas\deposito_plazo"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\tasas_tarifas\ahorros"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivos" Value="\tasas_tarifas\prestamo_efectivo">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Agencias" Value="\agencias"></asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </td>
            <td class="style14" style="height: 416px">
                &nbsp;</td>
            <td style="height: 416px">
            </td>
        </tr>
        <tr>
            <td class="style23" style="width: 52px">
            </td>
            <td class="style24" style="width: 368px">
                &nbsp;</td>
            <td class="style25">
            </td>
            <td class="style22">
            </td>
        </tr>
        <tr>
            <td class="style23" style="width: 52px">
                &nbsp;</td>
            <td class="style24" style="width: 368px">
                <b>PASO 2:</b>
                Selección de archivos</td>
            <td class="style25">
                <b>PASO 3:</b></td>
            <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6" style="width: 52px">
            </td>
            <td style="width: 368px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:FileUpload ID="fuBuscar" runat="server" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="0">
                        </asp:ScriptManager>
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td class="style15">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" style="width: 67px" />
            </td>
        </tr>
        <tr>
            <td class="style12" style="width: 52px">
            </td>
            <td class="style13" style="width: 368px">
            </td>
            <td class="style16">
            </td>
        </tr>
        <tr>
            <td class="style26" style="width: 52px">
            </td>
            <td class="style27" style="width: 368px">
                Ruta en el Servidor:</td>
            <td class="style28">
            </td>
        </tr>
        <tr>
            <td class="style9" style="width: 52px">
                </td>
            <td class="style10" style="width: 368px">
                <asp:ListBox ID="LbxImagenes" runat="server" Height="106px" Width="414px">
                </asp:ListBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 52px; height: 13px;">
                </td>
            <td class="style1" style="width: 368px; height: 13px;">
                <b>PASO 4:</b></td>
            <td style="height: 13px">
                </td>
        </tr>
        <tr>
            <td class="style2" style="width: 52px; height: 8px;">
                </td>
            <td class="style1" style="width: 368px; height: 8px;">
                <asp:Button ID="btnCompletar" runat="server" Text="Actualizar " />
            </td>
            <td class="style18" style="height: 8px">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                </td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
    </table>

                    </td>
            </tr>
                        
        </table>
    </p>
</asp:Content>

