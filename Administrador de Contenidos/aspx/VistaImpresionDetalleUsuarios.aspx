<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VistaImpresionDetalleUsuarios.aspx.vb" Inherits="aspx_VistaImpresionDetalleUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vista de Impresion</title>
    <link href="aspx/estilos/Estilos.css" rel="stylesheet" type="text/css" />   
    <link href="aspx/estilos/Estilos.css"   rel="stylesheet" type="text/css" title="Azul"/>
    <script type="text/javascript" language=javascript>
        function imprimirPagina() {
            if (window.print)
               window.print();
            else
               alert("Lo siento, pero a tu navegador no se le puede ordenar imprimir desde la web. Actualizate o hazlo desde los menús");
            }
      </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table border="0">
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="Label6" runat="server" Font-Names="courier new,courier,monospace" Font-Size="X-Large" Font-Bold="True" Font-Underline="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; font-family: 'Courier New', Courier, monospace; font-size: small;">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: right; courier: ; font-family: 'Courier New', Courier, monospace; font-size: small;">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>   
                <tr>
                    <td style="text-align: right; courier: ; font-family: 'Courier New', Courier, monospace; font-size: small;">Fecha:</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Names="courier new,courier,monospace" Font-Size="Small"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr> 
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" Width="108px" CssClass="button" onclientclick="imprimirPagina;" />    
                    </td>
                    <td>            
                    </td>
                    <td></td>
                </tr>                         
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Names="courier new,courier,monospace" Font-Size="Small">REPORTE GENERAL</asp:Label>
                        <BR>
                        <asp:GridView ID="GridView1" runat="server" Font-Names="font-family: 'courier new', courier, monospace; font-size: small; text-align: center" Font-Size="Small" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                        </asp:GridView>
                    </td>
                    <td></td>
                </tr>               
            </table>    
        </div>
    </form>
</body>
</html>
