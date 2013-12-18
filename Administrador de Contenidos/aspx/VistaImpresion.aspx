<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VistaImpresion.aspx.vb" Inherits="VistaImpresion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    alert("Lo siento, pero a tu navegador no se le puede ordenar imprimir" +
      " desde la web. Actualizate o hazlo desde los menús");
}
function imprimir(){
  if (parseInt(navigator.appVersion)>4)
    window.print();
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table border="0">
           <tr>
           <td colspan="3" style="text-align: center">
        <asp:Label ID="Label6" runat="server" 
            Font-Names="courier new,courier,monospace" Font-Size="X-Large" Font-Bold="True" 
                   Font-Underline="True"></asp:Label>
                       </td>
           </tr>
    <tr>
    <td style="text-align: right; font-family: 'Courier New', Courier, monospace; font-size: small;">Tipo Reporte:</td>
    <td>
        <asp:Label ID="Label1" runat="server" 
            Font-Names="courier new, courier, monospace" Font-Size="Small"></asp:Label>
                       </td>
    <td></td>
    </tr>
    <tr>
    <td style="text-align: right; courier: ; font-family: 'Courier New', Courier, monospace; font-size: small;">Tienda:</td>
    <td>
        <asp:Label ID="Label2" runat="server" 
            Font-Names="courier new,courier,monospace" Font-Size="Small"></asp:Label>
                       </td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td style="font-family: 'Courier New', Courier, monospace; font-size: small; text-align: right;">
        Fecha:</td>
    <td>
        <asp:Label ID="Label3" runat="server" 
            Font-Names="courier new,courier,monospace" Font-Size="Small"></asp:Label>
                       </td>
    <td></td>
    </tr> 
        <tr>
    <td>
        <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" Width="108px" 
            CssClass="button" 
            onclientclick="imprimirPagina;" />
    
            </td>
    <td>

        
    
    </td>
    <td></td>
    </tr>         
    <tr>
    <td>

        <asp:Button ID="Button2" runat="server" Text="IMPRIMIR" Width="108px" 
            CssClass="button" 
            onclientclick="imprimir;" Visible="False" />
    
        </td>
    <td>
    <asp:Label ID="Label4" runat="server" 
            Font-Names="courier new,courier,monospace" Font-Size="Small">REPORTE GENERAL</asp:Label>
    <BR>
        <asp:GridView ID="GridView1" runat="server" Font-Names="font-family: 'courier new', courier, monospace; font-size: small; text-align: center" 
            Font-Size="Small" Font-Overline="False" Font-Strikeout="False" 
            Font-Underline="False">
        </asp:GridView>
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        
        <asp:GridView ID="GridView2" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView>
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView3" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView>
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView4" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView>
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView5" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br />
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
    <asp:Label ID="Label5" runat="server" 
            Font-Names="courier new,courier,monospace" Font-Size="Small"></asp:Label>
            <BR>
        <asp:GridView ID="GridView6" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br />
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView7" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br />
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView8" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br />
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView9" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br />
        </td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td>
        <asp:GridView ID="GridView10" runat="server" Font-Names="font-family: 'Courier New',Courier,monospace; font-size: small; text-align: center" 
            Font-Size="Small">
        </asp:GridView><Br /></td>
    <td></td>
    </tr>
    </table>
           <br />
    
    </div>
    </form>
</body>
</html>
