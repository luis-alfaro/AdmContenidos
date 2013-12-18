<%@ Page Language="VB" AutoEventWireup="false" CodeFile="logout.aspx.vb" Inherits="aspx_logout" title="Untitled Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<title>Administrador de Contenidos</title> 
<link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />   
        <style type="text/css">
            .style1
            {
                height: 35px;
            }
            .style2
            {
                height: 623px;
                width: 834px;
            }
        </style>
</head>
<body leftMargin="0" topMargin="0" bgcolor="#545454">
		<form id="Form1" method="post" runat="server" 
        style="background-image: url('../../images/back.png')">
			<TABLE border="0" width="100%" id="table1" cellspacing="0" cellpadding="0" 
                style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; background-image: url('../../images/back.png'); height: 657px;">
				<TR>
					<TD width="100%" height="100%" vAlign="middle" align="center">
						<TABLE border="0" id="table2" cellspacing="0" cellpadding="0" 
                            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; height: 608px;" background="images/back.png"
							width="800">
							<TR>
								<TD align="center" background="../images/fondo.png" class="style2">
									<TABLE cellSpacing="0" cellPadding="0" border="0" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana"
										id="table3">
										<TBODY>
											<TR>
												<TD vAlign="middle" align="center" rowSpan="2" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana">
													<TABLE cellSpacing="1" cellPadding="0" width="470" border="0" id="table4">
														<TBODY>
															<TR>
																<TD style="FONT-WEIGHT: bold; FONT-SIZE: 18pt; COLOR: #ff0000; FONT-FAMILY: Verdana"
																	vAlign="baseline" align="center" class="style1">
																	<P>
																		su sesión ha expirado !!!.
																		<BR>
																		<IMG height="5" alt="" src="../images/spacer.gif" width="14" border="0"><BR>
																	</P>
																</TD>
															</TR>
															<TR>
																<TD vAlign="middle" align="center" colSpan="1" rowSpan="1">
																	<P>
																		<asp:Button id="btniniciar" runat="server" Text="Iniciar sesión" CssClass="button"></asp:Button>
																		&nbsp;<BR>
																	</P>
																</TD>
															</TR>
														</TBODY>
													</TABLE>
												</TD>
												<TD align="right" width="2" rowSpan="2"><IMG height="146" alt="" src="../images/mrblue.gif" width="2" border="0"></TD>
												<TD><IMG height="132" alt="" src="../images/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD><IMG height="14" alt="" src="../images/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2">&nbsp;</TD>
												<TD><IMG height="2" alt="" src="../images/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2"><IMG height="27" alt="" src="../images/spacer.gif" width="486" border="0"></TD>
												<TD><IMG height="27" alt="" src="../images/spacer.gif" width="1" border="0"></TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
	</html>


