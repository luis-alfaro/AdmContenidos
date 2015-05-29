<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>Administrador de Contenidos</title>
	    <style type="text/css">
            .style4
            {
                height: 15px;
                width: 189px;
            }
            .style5
            {
                height: 179px;
                width: 189px;
            }
            .style9
            {
                width: 158px;
            }
            .style10
            {
                height: 15px;
                width: 44px;
            }
            .style11
            {
                height: 15px;
            }
            #table5
            {
                height: 192px;
            }
            .style15
            {
                height: 67px;
            }
            .style19
            {
                height: 17px;
            }
        </style>
        <link href="estilos/Estilos.css" rel=Stylesheet type="text/css" />
	</HEAD>
	<BODY leftMargin="0" topMargin="0" bgcolor="#545454"><center>
		z<TABLE background="images/back.png"id="table1" 
            style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; height: 616px; width: 85%;" 
            cellSpacing="0" width:1024px;
			cellPadding="0" border="0">
			<TR>
				<TD vAlign="middle" align="center" width="100%" height="100%">
											<FORM id="FORM1" name="Login" method="post" encType="application/x-www-form-urlencoded" runat="server">
					<TABLE id="table2" style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; width: 850px; height: 500px;" cellSpacing="0"
						cellPadding="0" border="0">
                        <tr>
                            <td style="width:28%;"></td>
                            <td></td>
                            <td style="width:32%;"></td>
                        </tr>
						<tr>
                            <td style="width:28%;"></td>
							<td align="center"  >
                                <table>
                                    <tr>
                                        <td>
                                            </td>
                                        <td>
                                            </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            </td>
                                                                    <td>
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/title.png" />
                                                                    </td>
                                                                    <td>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                        </td>
                                                                    <td>
                                                                        </td>
                                                                </tr>
                                                            </table>
                                                            
								<TABLE id="table3" style="FONT-SIZE: 8pt; WIDTH: 401px; FONT-FAMILY: Verdana; HEIGHT: 248px"
									cellSpacing="1" cellPadding="0" border="0" align="center" background="images/back_sesion.png">
									<TR>
										<TD vAlign="top" align="left" width="13" class="style11"></TD>
										<TD vAlign="top" align="left" class="style4">
											<TABLE id="table4" cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #002276; FONT-FAMILY: Verdana"
														vAlign="top" align="left"><IMG height="10" alt="" width="1" border="0">
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" align="left" class="style10"></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="left" style="HEIGHT: 179px"></TD>
										<TD vAlign="bottom" class="style5">
											<!-- Form of Send START -->
												<TABLE id="table5" cellPadding="0" width="305" border="0">
													<TR>
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; FONT-FAMILY: Verdana" vAlign="middle"
															align="right" ></TD>
														<TD vAlign="bottom" width="156" class="style15"><FONT face="Verdana" size="1"><INPUT id="txtLogin" 
                                                                style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" type="text" size="24"
																	name="txtLogin" runat="server" value=""><br />
                                                            </FONT></TD>
													</TR>
													<TR>
														<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; FONT-FAMILY: Verdana" vAlign="middle"
															align="right" class="style19" ></TD>
														<TD width="156" class="style19" ><FONT face="Verdana" size="1">
                                                            <br />
                                                            <br />
                                                            <INPUT id="txtPassword" 
                                                                style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" type="password" size="24"
																	name="txtPassword" runat="server" value="welcome"></FONT></TD>
													</TR>
													<TR>
														<TD vAlign="bottom" align="left" class="style9">&nbsp;</TD>
														<TD vAlign="bottom" width="156">
															<P align="right" style="height: 67px; width: 151px"><FONT face="Verdana" size="1"><asp:button id="btniniciar" 
                                                                    style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana" runat="server" Text="Iniciar Sesión"
																		Width="156px" BackColor="#CB0C35" ForeColor="White" Height="26px"></asp:button></FONT></P>
														</TD>
													</TR>
												</TABLE>
											<!-- Form of Send END --> </TD>
										<TD vAlign="top" align="right" ></TD>
									</TR>
								</TABLE>
							</td>
							<td style="width:32%;"></td>
						</tr>
						<tr>
                            <td  style="width:28%;">
                            </td>
                            <td></td>
						    <td  style="width:32%;">
                            <p style="text-align:left;">
                            <label style="color:#4A4A4A">Recomendamos utilizar Google Chrome para obtener todas las funcionalidades. 
                            También puede utilizar IE8 o superior y Firefox.</label> </p>                      
                            </td>
						</tr>
					</TABLE>
											</FORM>
				</TD>
				
			</TR>
		</TABLE></center>
		</BODY>
</HTML>
