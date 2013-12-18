<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MantTiendas.aspx.vb" Inherits="aspx_MantTiendas" title="Untitled Page" %>

<%@ Register assembly="ASTreeView" namespace="Geekees.Common.Controls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server">
 
 
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
    <script src="js/flexigrid.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript"></script>
    <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
    
    <script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.maskedinput-1.2.2.min.js" type="text/javascript"></script>
    
        <%--Cambio--%>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            $("#txtHor1Inicio").mask("99:99");
            $("#txtHor1Fin").mask("99:99");
            $("#txtHor2Inicio").mask("99:99");
            $("#txtHor2Fin").setMask("99:99");


        });
    </script>
    <%--Cambio--%>

<script type="text/JavaScript" language="javascript">



    function launch(newURL, newName, newFeatures, orgName) {
        var remote = open(newURL, newName, newFeatures);
        if (remote.opener == null)
            remote.opener = window;
        remote.opener.name = orgName;
        return remote;
    }


    function launchRemote() {
        myRemote = launch("TreeViewUbigeEmerg.aspx", "myRemote", "height=450,width=200,channelmode=0,dependent=0,directories=1,fullscreen=0,location=1,menubar=0,resizable=0,scrollbars=0,status=0,toolbar=0", "myWindow");
    }

    function Cancelar_onclick() {

    }



</script>


    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0" marginheight="0">
 <TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 816px;"  cellspacing="0"
            cellpadding="0" align="left">
			<TR><TD style="height: 19px">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/aspx/images/BannerTop.png" Width="828px" Height="100px" 
                    ImageAlign="Left" />
					</TD>
			</TR>
			<tr>
			<td>
			
			
			
			    <table style="width: 105%; height: 649px;">
                    <tr>
                        <td style="height: 42px;" colspan="3" bgcolor="#000000">
			
			
			
			
			
			
			                </td>
                    </tr>
                    <tr>
                        <td style="width: 30px; height: 30px">
			
			
			
			
			
			
                        </td>
                        <td style="height: 30px; width: 623px;">
			
			
			
			
			
			
			               <b><u>Mantenimiento de Tiendas:</u></b> </td>
                        <td style="height: 30px">
                                                </td>
                    </tr>
                    <tr>
                        <td style="width: 30px; height: 379px;">
                            </td>
                        <td style="height: 379px; width: 623px">
        <table border="0" style="width: 659px; height: 410px; margin-bottom: 0px;" >
        <tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">Tienda</td>
            <td style="width: 323px">
            <asp:TextBox ID="txttienda" runat="server"></asp:TextBox>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Text="Label" 
                    Visible="False"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">Dirección</td>
            <td style="width: 323px">
                <asp:TextBox ID="txtdireccion" runat="server" Width="342px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 323px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 323px">
                <table style="width: 148%;">
                    <tr>
                        <td style="height: 17px; width: 78px">
                            Horario 1</td>
                        <td style="height: 17px; width: 82px">
                        </td>
                        <td style="height: 17px; width: 73px">
                            Horario 2</td>
                        <td style="height: 17px; width: 64px">
                            &nbsp;</td>
                        <td style="height: 17px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 78px">
                            Inicio:
                        </td>
                        <td style="width: 82px">
                            Fin:</td>
                        <td style="width: 73px">
                            Inicio:</td>
                        <td style="width: 64px">
                            Fin:</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 78px">
                            <asp:TextBox ID="txtHor1Inicio" runat="server" Width="65px" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style="width: 82px">
                            <asp:TextBox ID="txtHor1Fin" runat="server" Width="65px" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style="width: 73px">
                            <asp:TextBox ID="txtHor2Inicio" runat="server" Width="65px" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style="width: 64px">
                            <asp:TextBox ID="txtHor2Fin" runat="server" Width="65px" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 323px">
                &nbsp;</td>
        </tr><tr>
            <td style="width: 17px">&nbsp;</td>
            <td style="width: 17px">Ubigeo</td>
            <td style="width: 323px">
                <asp:TextBox ID="txtubigeo" runat="server" Width="294px" ReadOnly="True" 
                    CssClass="textbox_disabled"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" style="width: 26px" Text="..." CssClass="button" />
                </td>
        </tr>
        <tr>
        <td style="width: 17px">
        
            &nbsp;</td>
        <td style="width: 17px">
        
        </td>
        <td>
        <asp:TreeView ID="treeubigeo" runat="server" ImageSet="Simple" ShowLines="True" 
            Visible="False">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
                            ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
            </td>
        </tr>
        
        
        <tr>
            <td >&nbsp;</td>
            <td >Estado
            
            </td>
            <td >       
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" />
                </td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
            <td >       
            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                    Text="Todas las Áreas" />
                </td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >Seleccione Áreas:</td>
            <td >
                <asp:CheckBoxList ID="chklstareas" runat="server">
                </asp:CheckBoxList>
                </td>
        </tr>
        <tr>
        <td style="width: 17px; height: 40px;"></td>
        <td style="width: 17px; height: 40px;"></td>
        <td style="height: 40px">
                <asp:Button ID="Button1" runat="server" Text="Grabar Datos" CssClass="button"  
                    />
                <asp:Button ID="Button3" runat="server" Text="Cancelar" CssClass="button" Width="104px"  
                    /></td>
        </tr>
        <tr>
        <td style="width: 17px">&nbsp;</td>
        <td style="width: 17px">&nbsp;</td>
        <td>
                &nbsp;</td>
        </tr>
        </table>
        
                        </td>
                        <td style="height: 379px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">
                            &nbsp;</td>
                        <td style="width: 623px">
            <asp:HiddenField ID="hddtienda" runat="server" Value="0" />
                
                                        <asp:HiddenField ID="hddidubigeo" runat="server" Value="0" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
        
    </td>
			</tr>
			
</TABLE>
    
    </BODY>
</asp:Content>

