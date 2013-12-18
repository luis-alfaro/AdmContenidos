<%@ Page Language="VB" AutoEventWireup="false" CodeFile="errorAuthentication.aspx.vb" Inherits="aspx_errorAuthentication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<title>Administrador de Contenidos</title>
<head runat="server">
    
</head>
<BODY  bgcolor="#545454">
		<TABLE border="0" width="100%" id="table1" cellspacing="0" cellpadding="0" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana"
			height="100%" background="images/back.png">
			<TR>
				<TD width="100%" height="100%" vAlign="middle" align="center">
					<TABLE border="0" id="table2" cellspacing="0" cellpadding="0" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana"
						width="800" height="600">
						<TR>
							<TD align="center" background="../images/fondo.png" 
                                style="background-image: url('../../images/FondoFormularios.png')">
								<TABLE cellSpacing="0" cellPadding="0" border="0" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana"
									id="table3">
									<TBODY>
										<TR>
											<TD vAlign="middle" align="center" rowSpan="2" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana">
												<TABLE cellSpacing="1" cellPadding="0" width="470" border="0" id="table4">
													<TBODY>
														<TR>
															<TD style="FONT-WEIGHT: bold; FONT-SIZE: 18pt; COLOR: #ff0000; FONT-FAMILY: Verdana" align="center">
																<%=Request.QueryString("f_Caption")%>
																<BR>
																<IMG height="5" alt="" src="../images/spacer.gif" width="14" border="0"><BR>
															</TD>
														</TR>
														<TR>
															<TD style="FONT-SIZE: 8pt; COLOR: #d3d3d3; FONT-FAMILY: Verdana" align="center">
																<%=Request.QueryString("f_Message")%>
																<BR>
																<BR>
																<BR>
																&nbsp;<BR>
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
	</BODY>
</html>
