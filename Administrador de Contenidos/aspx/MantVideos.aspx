<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MantVideos.aspx.vb" Inherits="aspx_MantVideos" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <style type="text/css">

        .style1
        {
            height: 8px;
            width: 303px;
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
            width: 303px;
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
            height: 19px;
        }
        .style39
        {
            height: 19px;
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
            height: 13px;
            width: 303px;
        }
        .style54
        {
            width: 303px;
            height: 11px;
        }
                
        .style55
        {
            width: 52px;
            height: 104px;
        }
        .style56
        {
            height: 104px;
        }
                
        .style57
        {
            width: 87px;
        }
                
        .style58
        {
            width: 52px;
            height: 6px;
        }
        .style60
        {
            height: 6px;
        }
        .style61
        {
            height: 6px;
            width: 303px;
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
                <b><u>Actualización de videos en el servidor</u></b></td>
                    </tr>
                </table>
                </b></td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                &nbsp;</td>
            <td class="style53">
                &nbsp;</td>
            <td style="height: 13px">
                                                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                &nbsp;</td>
            <td class="style53">
                <b>PASO 1:</b> Seleccionar video a subir</td>
            <td style="height: 13px">
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
                    </td>
        </tr>
        <tr>
            <td class="style51">
                </td>
            <td class="style54">
                </td>
            <td class="style52">
                </td>
        </tr>
        <tr>
            <td class="style2" style="width: 52px; height: 8px;">
                &nbsp;</td>
            <td class="style1">
                    <asp:FileUpload ID="fuVideo" runat="server" Width="238px" />
                    </td>
            <td class="style18" style="height: 8px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30">
                <b>PASO 2:</b> Confirmar el video subido</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style58">
                </td>
            <td class="style61">
                </td>
            <td class="style60">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                </td>
            <td class="style30">
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
                        Text="El archivo se guardo correctamente" Visible="False"></asp:Label>
            </td>
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
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                <b>
                <table style="width:100%;">
                    <tr>
                        <td class="style57">
                            &nbsp;</td>
                                <td>
                                    <b><u>Eliminación de videos en el servidor</u></b></td>
                            </tr>
                        </table>
                        </b></td>
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
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                <asp:Label ID="Label1" runat="server" Text="Lista de videos en el servidor"></asp:Label>
            </td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style55">
                </td>
            <td class="style56" colspan="2">
                    <asp:ListBox ID="lbxVideos" runat="server" Height="100px" Width="499px">
                    </asp:ListBox>
                    </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button"/>
            </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30">
                &nbsp;&nbsp; </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>