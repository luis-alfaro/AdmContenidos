<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EdicionRipleyMatico.aspx.vb" 
Inherits="aspx_EdicionRipleyMatico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style9
        {
            width: 183px;
        }
        .style10
        {
        }
        .style1
        {
            height: 264px;
        }
                
        .style11
        {
            width: 52px;
            height: 50px;
        }
        .style12
        {
            width: 368px;
            height: 50px;
        }
        .style13
        {
            height: 50px;
        }
        .style14
        {
            width: 52px;
            height: 48px;
        }
        .style16
        {
            height: 15px;
        }
        .style18
        {
            width: 368px;
            height: 36px;
        }
        .style19
        {
            width: 52px;
            height: 15px;
        }
        .style20
        {
            width: 368px;
            height: 15px;
        }
                        
        .style23
        {
            width: 52px;
            height: 21px;
        }
        .style24
        {
            width: 368px;
            height: 21px;
        }
        .style25
        {
            height: 21px;
        }
        .style26
        {
            width: 52px;
            height: 18px;
        }
        .style27
        {
            width: 368px;
            height: 18px;
        }
        .style28
        {
            height: 18px;
        }
        .style29
        {
            width: 52px;
            height: 14px;
        }
        .style30
        {
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
            width: 368px;
            height: 19px;
        }
        .style39
        {
            height: 19px;
        }
        .style40
        {
            width: 52px;
            height: 17px;
        }
        .style41
        {
            width: 368px;
            height: 17px;
        }
        .style42
        {
            height: 17px;
        }
                
        .style43
        {
            width: 52px;
            height: 75px;
        }
        .style44
        {
            width: 368px;
            height: 75px;
        }
        .style45
        {
            height: 75px;
        }
        .style46
        {
            width: 11px;
        }
                
        .style47
        {
            width: 174px;
        }
        .style49
        {
            width: 326px;
        }
        .style50
        {
            width: 83px;
        }
                
        .style51
        {
            width: 52px;
            height: 23px;
        }
        .style52
        {
            width: 368px;
            height: 23px;
        }
        .style53
        {
            height: 23px;
        }
                
        .style58
        {
            height: 12px;
            width: 160px;
        }
        .style56
        {
            height: 12px;
            width: 118px;
        }
        .style59
        {
            width: 160px;
        }
        .style57
        {
            width: 118px;
        }
        #logPantallaDiv ul
        {
            list-style-type: none;
        }
        </style>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
 <%--   <script src="../Scripts/jquery-1.6.4.js" type="text/javascript"></script>--%>
    <script src="../js/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
    <script src="../js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../js/BI.js" type="text/javascript"></script>
    <%--<script src="../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>--%>
    <!--Reference the SignalR library. -->
<%--    <script src="../Scripts/jquery.signalR-1.1.4.js" type="text/javascript"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>--%>
    <script type="text/javascript" language="javascript">
        var dialogAlter = 'dialog-alert';
        var inicializador = "<div id='logPantallaDiv'><ul id='logPantalla'></ul></div>";
        var consultarlog = true;
        var imageList = new Array();
        var radio = "Todos";
        var cont = 1;
        var logPantalla = 'logPantalla';
        var btnCompletar = '<%= btnCompletar.ClientID %>';
        var LbxImagenes = '<%= LbxImagenes.ClientID %>';
        var rbUno = '<%= rbUno.ClientID %>';
        var rbTodos = '<%= rbTodos.ClientID %>';
        var txtUsuario = '<%= txtUsuario.ClientID %>';
        var txtPassword = '<%= txtPassword.ClientID %>';
        var txtDominio = '<%= txtDominio.ClientID %>';
        var txtSeleccionados = '<%= txtSeleccionados.ClientID %>';
        var txtActualizados = '<%= txtActualizados.ClientID %>';
        var txtNoActualizados = '<%= txtNoActualizados.ClientID %>';
        var loghub = '<%= loghub.ClientID %>';

        $(function () {


            //            var logh = $.connection.logHub;
            //            // Create a function that the hub can call to broadcast messages.
            //            logh.client.broadcastLog = function (res) {
            //                if (cont == 1) {
            //                    BI.ShowAlert('', inicializador);
            //                    console.log("debio haber levantado el popup");
            //                    cont = 2;
            //                }
            //                console.log("respondio el loghub");
            //                $.each(res, function (index, campo) {
            //                    console.log(campo, "campope");
            //                    $("#" + logPantalla).append("<li>" + campo + "</li>");
            //                });
            //            };

            var arrayDialog = [{ name: dialogAlter, height: 250, width: 600, title: 'Log de Edicion Ripleymatico'}];
            BI.CreateDialogLog(arrayDialog);


            $("#" + btnCompletar).click(function (e) {
                imageList = new Array();
                $('#' + LbxImagenes + ' option').each(function (i, option) {
                    imageList.push($(option).text());
                });
                if (imageList.length == 0) {
                    BI.ShowAlert('', "Debe seleccionar archivos a actualizar.");
                    return false;
                }
                var values = $('input:checkbox:checked').map(function () {
                    return $('label[for="' + $(this).attr("id") + '"]').html();
                }).get();
                var usuario = $("#" + txtUsuario).val();
                var password = $("#" + txtPassword).val();
                var dominio = $("#" + txtDominio).val();
                if ($("#" + rbUno).is(":checked")) {
                    radio = "Uno";
                    if (values.length == 0) {
                        BI.ShowAlert('', "Debe seleccionar por lo menos un Ripleymático.");
                        return false;
                    }
                } else if ($("#" + rbTodos).is(":checked")) {
                    radio = "Todos";
                }

                if (usuario == "" || password == "" || dominio == "") {
                    BI.ShowAlert('', "Debe ingresar sus credenciales para poder actualizar.");
                    return false;
                }
                var parameters = { Archivos: imageList, radio: radio, Kioscos: values, usuario: usuario, password: password, dominio: dominio };
                console.log("start");
                $.ajax({
                    //async: true,
                    type: "POST",
                    //cache:false,
                    url: "EdicionRipleyMatico.aspx/Completar",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(parameters),
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        var res = result.hasOwnProperty("d") ? result.d : result;
                        var arr = res.split("|");
                        $("#" + txtSeleccionados).val(arr[1]);
                        $("#" + txtActualizados).val(arr[2]);
                        $("#" + txtNoActualizados).val(arr[3]);
                        console.log("end");
                        //$.connection.hub.stop();
                    }
                });
                setInterval(EscribirLog, 500);


                //                // Start the connection.
                //                $.connection.hub.start().done(function () {
                //                    console.log("hub starteo");
                //                    setInterval(function () {
                //                        logh.server.send($('#loghub').val());
                //                    }, 1000);
                //                });

                e.preventDefault();
            });


        });
        function rpta(resultado) {
            var res = resultado.hasOwnProperty("d") ? resultado.d : resultado;
            if (!$('#' + dialogAlter).is(":visible")) {
                if (res.length > 0) {
                    BI.ShowAlert('', inicializador);
                }
            }
            $.each(res, function (index, campo) {
                console.log("campo", campo);
                $("#" + logPantalla).append("<li>" + campo + "</li>");
                if (campo.indexOf("Fin Proceso") >= 0) {
                    consultarlog = false;
                }
            });
        }
        function EscribirLog() {
            console.log("log");
            if (consultarlog == true) {
                var identificador = $('#loghub').val();
                var url = "EdicionRipleyMatico.aspx/ObtenerLogPantalla";
                var parameters = { identificador: identificador };
                BI.AjaxJson("POST", url, parameters, false, rpta);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="loghub" runat="server" />
    <div>
    <div id='dialog-alert' style="display:none">
        </div>
  
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
                &nbsp;</td>
            <td class="style35" colspan="2">
                &nbsp;</td>
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
                        <td class="style49">
                <b><u>Actualización de Imágenes en los RipleyMáticos</u></b></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </b></td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                &nbsp;</td>
            <td class="style4" style="width: 368px; height: 13px;">
                &nbsp;</td>
            <td style="height: 13px">
                                                <asp:Button ID="btnRegresar" runat="server" Text="Salir" 
                                                    Width="77px" CssClass="button" />
                    </td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 13px;">
                </td>
            <td class="style4" style="width: 368px; height: 13px;">
                <b>PASO 1:</b> Escoger Carpeta a actualizar</td>
            <td style="height: 13px">
                                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" 
                                                    Visible="False"></asp:Label>
                                                </td>
        </tr>
        <tr>
            <td class="style3" style="width: 52px; height: 416px;">
            </td>
            <td class="style4" style="width: 368px; height: 416px;">
                <asp:TreeView ID="tvDirectorios" runat="server" ImageSet="Arrows" Width="269px">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <Nodes>
                        <asp:TreeNode Text="Promociones" Value="\Promociones">
                            <asp:TreeNode Text="Ahora o Nunca" Value="\Promociones\Ahora_Nunca"></asp:TreeNode>
                            <asp:TreeNode Text="Productos Financieros" 
                                Value="\Promociones\producto_financiero">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ofertas de Seguros" Value="\Promociones\ofertas_seguro">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Establecimientos" Value="\Promociones\establecimientos"></asp:TreeNode>
                            <asp:TreeNode Text="Otras Promociones" Value="\Promociones\otras_promociones"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Productos" Value="\productos">
                            <asp:TreeNode Text="Ripley Clásica" Value="\productos\ripley_clasica"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\productos\ripley_silver_visa">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" 
                                Value="\productos\ripley_silver_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\productos\ripley_gold_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun " Value="\productos\ripley_platinum_visa"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\productos\cts"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\productos\deposito_plazo"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\productos\ahorros"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivos" Value="\productos\prestamos">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Tasas y Tarifas" Value="\tasas_tarifas">
                                                    <asp:TreeNode Text="Ripley Clásica" Value="\tasas_tarifas\t_clasica"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\tasas_tarifas\t_silver_visa">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" Value="\tasas_tarifas\t_silver_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\tasas_tarifas\t_gold_mc">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun" Value="\tasas_tarifas\t_platinum"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\tasas_tarifas\cts"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\tasas_tarifas\deposito_plazo"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\tasas_tarifas\ahorros"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivo" Value="\tasas_tarifas\prestamo_efectivo">
                            </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Agencias" Value="\agencias"></asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </td>
            <td class="style14" style="height: 416px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style23" style="width: 52px">
            </td>
            <td class="style24" style="width: 368px">
            </td>
            <td class="style25">
            </td>
        </tr>
        <tr>
            <td class="style51">
                </td>
            <td class="style52">
                <b>PASO 2:</b>
                Seleccionar archivos a transferir</td>
            <td class="style53">
                </td>
        </tr>
        <tr>
            <td class="style37">
            </td>
            <td class="style38">
                <asp:FileUpload ID="fuBuscar" runat="server" Height="24px" Width="369px" CssClass="button" />
            </td>
            <td class="style38">
                </td>
        </tr>
        <tr>
            <td class="style19">
            </td>
            <td class="style20">
            </td>
            <td class="style16">
                </td>
        </tr>
        <tr>
            <td class="style11">
            </td>
            <td class="style12">
                <b>PASO 3: </b> Aceptar archivos seleccionados<br />
                <asp:Button ID="btnAceptar" runat="server" 
                    Text="Aceptar" style="width: 67px" Height="26px" 
                    Width="105px" CssClass="button" />
            &nbsp;</td>
            <td class="style13">
                </td>
        </tr>
        <tr>
            <td class="style26" style="width: 52px">
            </td>
            <td class="style27" style="width: 368px">
                Ruta en el Servidor:</td>
            <td class="style28">
            </td>
        </tr>
        <tr>
            <td class="style9" style="width: 52px">
                </td>
            <td class="style10" colspan="2">
                <asp:ListBox ID="LbxImagenes" runat="server" Height="106px" Width="767px" 
                    AutoPostBack="True">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 52px; height: 8px;">
                &nbsp;</td>
            <td class="style1" style="width: 368px; height: 8px;">
                &nbsp;</td>
            <td class="style18" style="height: 8px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                </td>
            <td class="style30" style="width: 368px">
                <b>PASO 4:</b>
                Seleccionar Kioscos</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                </td>
            <td class="style38">
                    &nbsp;</td>
            <td class="style39">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <asp:Panel ID="Panel1" runat="server">
                    &nbsp;<asp:RadioButton ID="rbTodos" runat="server" AutoPostBack="True" 
                        Checked="True" GroupName="seleccion" Text="Todos" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbUno" runat="server" AutoPostBack="True" 
                        GroupName="seleccion" Text="Seleccion Personalizada" />
                </asp:Panel>
                    </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style40">
                </td>
            <td class="style41">
                    </td>
            <td class="style42">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" colspan="2">
                <div>
                <asp:CheckBoxList ID="cblKioscos" runat="server" Height="198px" 
                    Width="822px" Visible="False" AppendDataBoundItems="True">
                </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <b>PASO 5:</b> Ingresar Su nombre de usuario, contraseña y Dominio al que esta 
                asignado</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <table style="width: 106%;">
                    <tr>
                        <td class="style58">
                            Usuario autorizado:</td>
                        <td class="style56">
                            <asp:TextBox ID="txtUsuario" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style59">
                            Contraseña del usuario:</td>
                        <td class="style57">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style59">
                            Dominio del usuario:</td>
                        <td class="style57">
                            <asp:TextBox ID="txtDominio" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <b>PASO 6:</b> Actualizar información en kioscos</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                <asp:Button ID="btnCompletar" runat="server" Text="Actualizar" CssClass="button"/>
            </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                </td>
            <td class="style38">
                </td>
            <td class="style39">
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                Resultado:</td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style43">
                </td>
            <td class="style44">
                &nbsp;<table style="width: 115%;">
                    <tr>
                        <td class="style46">
                            &nbsp;</td>
                        <td class="style47">
                            <asp:Label ID="Label2" runat="server" Text="Kioscos Seleccionados:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSeleccionados" runat="server" Width="53px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style46">
                            &nbsp;</td>
                        <td class="style47">
                            <asp:Label ID="Label3" runat="server" Text="Kioscos Actualizados:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtActualizados" runat="server" Enabled="False" Width="52px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style46">
                            &nbsp;</td>
                        <td class="style47">
                            <asp:Label ID="Label4" runat="server" Text="Kioscos no Actualizados:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoActualizados" runat="server" Width="51px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                    </td>
            <td class="style45">
                    </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                &nbsp;&nbsp; </td>
            <td class="style31">
                &nbsp;</td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>