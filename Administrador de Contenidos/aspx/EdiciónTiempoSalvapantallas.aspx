<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EdiciónTiempoSalvapantallas.aspx.vb" Inherits="aspx_EdiciónTiempoSalvapantallas" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <style type="text/css">

        .style1
        {
            height: 264px;
        }
                
        .style18
        {
            width: 368px;
            height: 36px;
        }
        .style29
        {
            width: 52px;
            height: 14px;
        }
        .style30
        {
            height: 14px;
        }
        .style31
        {
            height: 14px;
        }
        .style34
        {
            height: 13px;
        }
        .style35
        {
            height: 12px;
        }
        .style37
        {
            width: 52px;
            height: 19px;
        }
        .style38
        {
            width: 368px;
            height: 19px;
        }
        .style39
        {
            height: 19px;
        }
        .style40
        {
            width: 52px;
            height: 17px;
        }
        .style41
        {
            width: 368px;
            height: 17px;
        }
        .style42
        {
            height: 17px;
        }
                
        .style43
        {
            width: 52px;
            height: 75px;
        }
        .style44
        {
            width: 368px;
            height: 75px;
        }
        .style45
        {
            height: 75px;
        }
        .style46
        {
            width: 11px;
        }
                
        .style47
        {
            width: 174px;
        }
        .style49
        {
        }
        .style50
        {
            width: 83px;
        }
                
        .style51
        {
            width: 52px;
            height: 11px;
        }
        .style52
        {
            width: 368px;
            height: 11px;
        }
                
        .style53
        {
            width: 11px;
            height: 27px;
        }
        .style54
        {
            width: 174px;
            height: 27px;
        }
        .style55
        {
            height: 27px;
        }
                
        .style56
        {
            height: 12px;
            width: 118px;
        }
        .style57
        {
            width: 118px;
        }
        .style58
        {
            height: 12px;
            width: 160px;
        }
        .style59
        {
            width: 160px;
        }
                
        </style>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
  
    <table style="width: 100%; height: 951px;" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 747px; height: 110px;"  >
        <tr>
            <td class="style34" style="height: 51px;" colspan="3" background = "images/toplarge.png">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />    
                </td>
        </tr>
        <tr>
            <td class="style34" style="height: 51px;" colspan="3" bgcolor="#000000">
                </td>
        </tr>
        <tr>
            <td class="style34" style="width: 52px">
                &nbsp;</td>
            <td class="style35" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style34" style="width: 52px">
            </td>
            <td class="style35" colspan="2">
                <b><table style="width:100%;">
                    <tr>
                        <td class="style50">
                            &nbsp;</td>
                        <td class="style49">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style50">
                            &nbsp;</td>
                        <td class="style49" colspan="2">
                <b><u>Actualización del Temporizador del Salvapantallas</u></b></td>
                    </tr>
                </table>
                </b></td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                &nbsp;</td>
            <td class="style4" style="width: 368px; height: 13px;">
                &nbsp;</td>
            <td style="height: 13px">
                                                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                &nbsp;</td>
            <td class="style4" style="width: 368px; height: 13px;">
                <b>PASO 1:</b> Seleccionar archivo del temporizador</td>
            <td style="height: 13px">
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
                    </td>
        </tr>
        <tr>
            <td class="style51">
                </td>
            <td class="style52">
                </td>
            <td class="style52">
                </td>
        </tr>
        <tr>
            <td class="style2" style="width: 52px; height: 8px;">
                &nbsp;</td>
            <td class="style1" style="width: 368px; height: 8px;">
                    <asp:FileUpload ID="fuTiempoSalvaPantallas" runat="server" Width="238px" />
                    </td>
            <td class="style18" style="height: 8px">
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
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <b>PASO 2:</b> Confirmar archivo seleccionado</td>
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
        <tr>
            <td class="style29" style="width: 52px">
                </td>
            <td class="style30" style="width: 368px">
                    <asp:Button ID="btnGuardarTiempo" runat="server" Text="Guardar" Width="75px" 
                        CssClass="button" />
                    </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" 
                        Text="La imagen se guardo correctamente" Visible="False"></asp:Label>
            </td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                <b>PASO 3:</b> Seleccionar kioscos</td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                    &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <asp:Panel ID="Panel1" runat="server">
                    &nbsp;<asp:RadioButton ID="rbTodos" runat="server" AutoPostBack="True" 
                        Checked="True" GroupName="seleccion" Text="Todos" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbUno" runat="server" AutoPostBack="True" 
                        GroupName="seleccion" Text="Seleccion Personalizada" />
                </asp:Panel>
                    </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style40">
                </td>
            <td class="style41">
                    </td>
            <td class="style42">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" colspan="2">
                <div>
                <asp:CheckBoxList ID="cblKioscos" runat="server" Height="198px" 
                    Width="787px" Visible="False" AppendDataBoundItems="True">
                </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <b>PASO 4:</b> Ingresar Su nombre de usuario, contraseña y Dominio al que esta 
                asignado</td>
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
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <table style="width: 106%;">
                    <tr>
                        <td class="style58">
                            Usuario autorizado:</td>
                                <td class="style56">
                                    <asp:TextBox ID="txtUsuario" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="style35">
                                </td>
                            </tr>
                            <tr>
                                <td class="style59">
                                    Contraseña del usuario:</td>
                                <td class="style57">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style59">
                                    Dominio del usuario:</td>
                        <td class="style57">
                            <asp:TextBox ID="txtDominio" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
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
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <b>PASO 5:</b> Actualizar información en kioscos</td>
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
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <asp:Button ID="btnCompletar" runat="server" Text="Actualizar" CssClass="button"/>
            </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                </td>
            <td class="style38">
                </td>
            <td class="style39">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                Resultado:</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style43">
                </td>
            <td class="style44">
                &nbsp;<table style="width: 115%;">
                    <tr>
                        <td class="style46">
                            &nbsp;</td>
                        <td class="style47">
                            <asp:Label ID="Label2" runat="server" Text="Kioscos Seleccionados:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSeleccionados" runat="server" Width="53px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style53">
                            </td>
                        <td class="style54">
                            <asp:Label ID="Label3" runat="server" Text="Kioscos Actualizados:"></asp:Label>
                        </td>
                        <td class="style55">
                            <asp:TextBox ID="txtActualizados" runat="server" Enabled="False" Width="52px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style46">
                            &nbsp;</td>
                        <td class="style47">
                            <asp:Label ID="Label4" runat="server" Text="Kioscos no Actualizados:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoActualizados" runat="server" Width="51px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                    </td>
            <td class="style45">
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
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <asp:Label ID="Label5" runat="server" ForeColor="Red" 
                    Text="Los cambios surtirán efecto en los equipos seleccionados una vez estos sean reinicializados."></asp:Label>
            </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
