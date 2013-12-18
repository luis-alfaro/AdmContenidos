<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLogEnvioData.aspx.vb" Inherits="frmLogEnvioData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="Z-INDEX: 102; LEFT: 13px; OVERFLOW: auto; WIDTH: 554px; POSITION: absolute; TOP: 62px; HEIGHT: 374px" >
        <br />
        <br />
        <asp:ListBox ID="lbxTest" runat="server" Height="800px" Width="2000px"  BorderStyle="None" >
        </asp:ListBox>
        <br />
    
    </div>
    <asp:Button ID="btnTest" runat="server" Text="Mostrar Data" />
    
        <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
