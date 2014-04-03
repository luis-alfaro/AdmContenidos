<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="welcome.aspx.vb" Inherits="aspx_welcome" title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHContenido" Runat="Server" >
    <title>
	Administrador de Contenidos
</title>
    <BODY topmargin="0" leftmargin="0" rightmargin="0" marginwidth="0">
    
		<TABLE border="0" id="tblBody" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 751px;" cellspacing="0"
			cellpadding="0" align="left">
			<TR>
				<TD style="height: 19px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/aspx/images/BannerTop.png" 
                                    Width="816px" Height="100px" ImageAlign="RIGHT" />
					</TD>
			</TR>
			<TR>
				<TD width="100%">
					<TABLE background="images/back.png" border="0" id="table1" 
                        style="margin-left: 0px; height: 638px; width: 100%;">
						<tr>
				<TD width="100%" style="height: 51px">
					<br />
                    <br />
					<TABLE border="0" width="100%" id="tblText" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; margin-left: 4px;"
						cellspacing="0" cellpadding="0" >
						<TR>
							<TD>
                                </TD>
						</TR>
						<TR>
							<TD style="height: 13px">&nbsp;</TD>
						</TR>
						<TR>
							<TD style="height: 13px"><FONT size="2"><B>Bienvenidos al Administrador de 
                                Contenidos</B></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD>Este módulo es parte del Sistema de&nbsp; Administración de Contenidos, aqui 
                                usted podrá configurar el panel publicitario<br />
                                que se visualizará en los diferentes Kioscos de Ripley, de igual manera podra 
                                dar mantenimiento a los kioscos y<br />
                                podra actualizar las imágenes de tasas, promociones, productos, lista de 
                                agencias que se van a presentar en cada
                                <br />
                                RipleyMático.</TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
						</TR>
					</TABLE>
                    <br />
                    <br />
                    <br />
                    <br />
				</TD>
			            </tr>
						<TR>
							<TD valign="top" style="height: 21px">
									</TD>
						</TR>
						<TR>
							<TD height="192" valign="top">
									&nbsp;</TD>
						</TR>
						<TR>
							<TD align="right" style="height: 72px">
								&nbsp;</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</BODY>
	
</asp:Content>

