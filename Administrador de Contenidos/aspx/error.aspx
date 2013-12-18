<%@ Page Language="VB" AutoEventWireup="false" CodeFile="error.aspx.vb" Inherits="aspx_error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<title>Administrador de Contenidos</title>
<head runat="server">
    
</head>
<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblMensajeError" style="Z-INDEX: 100; LEFT: 88px; POSITION: absolute; TOP: 72px"
				runat="server" Width="632px" ForeColor="Red" Height="32px" Font-Size="14pt"></asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 88px; POSITION: absolute; TOP: 32px" runat="server"
				Width="632px" ForeColor="Red" Height="32px" Font-Size="14pt">Ocurrio un Error  !!!</asp:Label>&nbsp;
		</form>
	</body>
</html>
