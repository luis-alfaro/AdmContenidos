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
        #Continuar-botton
        {
            margin:100px;
            padding:100px;
            text-align:center;
         }
        </style>
        <link href="estilos/Estilos.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
    <script src="../js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../js/BI.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var dialogAlter = 'dialog-alert';
        var inicializador = "<div id='logPantallaDiv'><ul id='logPantalla'></ul></div>";
        var consultarlog = true;
        var imageList = new Array();
        var radio = "Todos";
        var ubicacion = "T";
        var cont = 1;
        var logPantalla = 'logPantalla';
        var btnCompletar = '<%= btnCompletar.ClientID %>';
        var LbxImagenes = '<%= LbxImagenes.ClientID %>';
        var rbUno = '<%= rbUno.ClientID %>';
        var rbTodos = '<%= rbTodos.ClientID %>';
        var rbLima = '<%= rbLima.ClientID %>';
        var rbProvincia = '<%= rbProvincia.ClientID %>';
        var cblKioscos = '<%= cblKioscos.ClientID %>';
        var txtUsuario = '<%= txtUsuario.ClientID %>';
        var txtPassword = '<%= txtPassword.ClientID %>';
        var txtDominio = '<%= txtDominio.ClientID %>';
        var txtEmail = '<%= txtEmail.ClientID %>';
        var txtDescripcion = '<%= txtDescripcion.ClientID %>';
        var loghub = '<%= loghub.ClientID %>';
        var btnContinuar = '<%= btnContinuar.ClientID %>';
        var txthidden = '<%= txthidden.ClientID %>';

        $(function () {
            $("#Continuar").hide();

            var arrayDialog = [{ name: dialogAlter, height: 250, width: 600, title: 'Log de Edición Ripleymatico'}];
            BI.CreateDialogLog(arrayDialog);
            if ($("#" + txthidden).val() != '') {
                BI.ShowAlert('', $("#" + txthidden).val());
                $("#" + txthidden).val('')
            }

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
                var email = $("#" + txtEmail).val();
                var descripcion = $("#" + txtDescripcion).val();


                if (usuario == "" || password == "" || dominio == "") {
                    BI.ShowAlert('', "Debe ingresar sus credenciales para poder actualizar.");
                    return false;
                }

                if (descripcion == "" || descripcion.length < 20) {
                    BI.ShowAlert('', "Debe ingresar una descripción de la actualización de 20 caracteres como mínimo.");
                    return false;
                }

                if ($("#" + rbUno).is(":checked")) {
                    radio = "Uno";
                    if (values.length == 0) {
                        BI.ShowAlert('', "Debe seleccionar por lo menos un Ripleymático.");
                        return false;
                    }
                    Ejecutar(imageList, radio, values, usuario, password, dominio, email, descripcion, ubicacion);
                } else if ($("#" + rbLima).is(":checked")) {
                    radio = "Todos";
                    ubicacion = "L";
                    Ejecutar(imageList, radio, values, usuario, password, dominio, email, descripcion, ubicacion);
                } else if ($("#" + rbProvincia).is(":checked")) {
                    radio = "Todos";
                    ubicacion = "P";
                    Ejecutar(imageList, radio, values, usuario, password, dominio, email, descripcion, ubicacion);
                } else if ($("#" + rbTodos).is(":checked")) {
                    radio = "Todos";
                    ubicacion = "T";
                    BI.confirm("¿Está seguro de querer actualizar todos los kioskos?", function () {
                        Ejecutar(imageList, radio, values, usuario, password, dominio, email, descripcion, ubicacion);
                    }, function () { }, "");
                }

                e.preventDefault();
            });

            $("#" + btnCompletar).click(function (e) { });
        });
        function Ejecutar(imageList, radio, values, usuario, password, dominio, email, descripcion,ubicacion) {
            BI.ShowAlert('', inicializador);
            $("#" + logPantalla).append("<li>" + "-Espere mientras se procesa la actualización..." + "</li>");
            var parameters = { Archivos: imageList, radio: radio, Kioscos: values, usuario: usuario, password: password, dominio: dominio, email: email, descripcion: descripcion,ubicacion:ubicacion };
            $.ajax({
                type: "POST",
                url: "EdicionRipleyMatico.aspx/Completar",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(parameters),
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    var res = result.hasOwnProperty("d") ? result.d : result;
                }
            });
            setInterval(EscribirLog, 500);
        }



        function rpta(resultado) {
            var res = resultado.hasOwnProperty("d") ? resultado.d : resultado;
            if (!$('#' + dialogAlter).is(":visible")) {
                if (res.length > 0) {
                    BI.ShowAlert('', inicializador);
                }
            }
            $.each(res, function (index, campo) {
                $("#" + logPantalla).append("<li>" + campo + "</li>");
                if (campo.indexOf("Fin Proceso") >= 0) {
                    consultarlog = false;
                    limpiarCampos();
                }
            });
        }
        function EscribirLog() {
            if (consultarlog == true) {
                var identificadorx = $('#loghub').val();
                var url = "EdicionRipleyMatico.aspx/ObtenerLogPantalla";
                var parameters = { identificadorx: identificadorx };
                BI.AjaxJson("POST", url, parameters, false, rpta);
            }
        }

        function limpiarCampos() {
            $('#' + txtUsuario).val('');
            $('#' + txtPassword).val('');
            $('#' + txtDominio).val('');
            $('#' + txtDescripcion).val('');
            $('#' + txtEmail).val('');
            $('#' + LbxImagenes + ' > option').remove();
            $("#" + rbTodos).attr("checked", "checked");
            $("#" + cblKioscos).hide();
            $("#controles").hide();
            $("#Continuar").show();            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="loghub" runat="server" />
    <div>
    <div id='dialog-alert' style="display:none">
        </div>
  <div id = "controles">
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
                <asp:HiddenField ID="txthidden" runat="server" />
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
                            <asp:TreeNode Text="Ahora o Nunca" Value="\Promociones\Ahora_Nunca" ToolTip="pan"></asp:TreeNode>
                            <asp:TreeNode Text="Productos Financieros" Value="\Promociones\producto_financiero" ToolTip="ppf">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Ofertas de Seguros" Value="\Promociones\ofertas_seguro" ToolTip="pos">
                            </asp:TreeNode>
                            <asp:TreeNode Text="Establecimientos" Value="\Promociones\establecimientos" ToolTip="pes"></asp:TreeNode>
                            <asp:TreeNode Text="Otras Promociones" Value="\Promociones\otras_promociones" ToolTip="pop"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Productos" Value="\productos">
                            <asp:TreeNode Text="Ripley Clásica" Value="\productos\ripley_clasica"  ToolTip="dcl"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\productos\ripley_silver_visa" ToolTip="dsv"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" Value="\productos\ripley_silver_mc" ToolTip="dsm"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\productos\ripley_gold_mc" ToolTip="dgm"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun " Value="\productos\ripley_platinum_visa" ToolTip="dpl"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\productos\cts" ToolTip="dct"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\productos\deposito_plazo" ToolTip="ddp"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\productos\ahorros" ToolTip="dah"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivos" Value="\productos\prestamos" ToolTip="dpe"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Tasas y Tarifas" Value="\tasas_tarifas">
                            <asp:TreeNode Text="Ripley Clásica" Value="\tasas_tarifas\t_clasica" ToolTip="tcl"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Visa" Value="\tasas_tarifas\t_silver_visa" ToolTip="tsv"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Silver Mastercard" Value="\tasas_tarifas\t_silver_mc" ToolTip="tsm"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Gold MasterCard" Value="\tasas_tarifas\t_gold_mc" ToolTip="tgm"></asp:TreeNode>
                            <asp:TreeNode Text="Ripley Platinun" Value="\tasas_tarifas\t_platinum" ToolTip="tpl"></asp:TreeNode>
                            <asp:TreeNode Text="CTS" Value="\tasas_tarifas\cts" ToolTip="tct"></asp:TreeNode>
                            <asp:TreeNode Text="Depósito a Plazo" Value="\tasas_tarifas\deposito_plazo" ToolTip="tdp"></asp:TreeNode>
                            <asp:TreeNode Text="Ahorros" Value="\tasas_tarifas\ahorros" ToolTip="tah"></asp:TreeNode>
                            <asp:TreeNode Text="Préstamos en Efectivo" Value="\tasas_tarifas\prestamo_efectivo" ToolTip="tpe"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Agencias" Value="\agencias" ToolTip="aag"></asp:TreeNode>
                        <asp:TreeNode Text="Documentos SEF" Value="\documentosSEF">
                            <asp:TreeNode Text="Hoja Resumen" Value="\documentosSEF\SEF0001" ToolTip="SEF0001"></asp:TreeNode>
                            <asp:TreeNode Text="Seguro Desgravamen" Value="\documentosSEF\SEF0002" ToolTip="SEF0002"></asp:TreeNode>
                            <asp:TreeNode Text="Seguro Protección de Pagos" Value="\documentosSEF\SEF0003" ToolTip="SEF0003"></asp:TreeNode>
                            <asp:TreeNode Text="Declaración Jurada" Value="\documentosSEF\SEF0004" ToolTip="SEF0004"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Cambio Producto" Value="\CambioProducto">
                            <asp:TreeNode Text="GOLD MASTERCARD" Value="\CambioProducto\GOLDMC" ToolTip="GOLDMC"></asp:TreeNode>
                            <asp:TreeNode Text="SILVER MASTERCARD" Value="\CambioProducto\SILVERMC" ToolTip="SILVERMC"></asp:TreeNode>
                            <asp:TreeNode Text="PLATINUM VISA" Value="\CambioProducto\PLAVISA" ToolTip="PLAVI"></asp:TreeNode>
                            <asp:TreeNode Text="SILVER VISA" Value="\CambioProducto\SILVERVISA" ToolTip="SILVERVISA"></asp:TreeNode>
                            <asp:TreeNode Text="SILVER MASTERCARD RSAT" Value="\CambioProducto\SILVERMCR" ToolTip="SILVERMCR"></asp:TreeNode>
                            <asp:TreeNode Text="GOLD MASTERCARD RSAT" Value="\CambioProducto\GOLDMCR" ToolTip="GOLDMCR"></asp:TreeNode>
                            <asp:TreeNode Text="SILVER VISA RSAT" Value="\CambioProducto\SILVERVISAR" ToolTip="SILVERVISAR"></asp:TreeNode>
                            <asp:TreeNode Text="PLATINUM VISA RSAT" Value="\CambioProducto\PLAVISAR" ToolTip="PLAVISAR"></asp:TreeNode>
                            <asp:TreeNode Text="CLÁSICA" Value="\CambioProducto\CLASICA" ToolTip="CLASICA"></asp:TreeNode>
                            <asp:TreeNode Text="PLATINUM MASTERCARD" Value="\CambioProducto\PLAMC" ToolTip="PLAMC"></asp:TreeNode>
                        </asp:TreeNode>
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
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbLima" runat="server" AutoPostBack="True" 
                        GroupName="seleccion" Text="Lima" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbProvincia" runat="server"  AutoPostBack="True" 
                        GroupName="seleccion" Text="Provincia" />
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
                <table style="width: 106%;">
                    <tr>
                        <td class="style58">
                            Descripción del pase:</td>
                        <td class="style56">
                            <textarea id="txtDescripcion" rows="3" cols="80" runat="server"></textarea>
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style58">
                            Email(s):</td>
                        <td class="style56">
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" Text="@bancoripley.com.pe"></asp:Label> 
                        </td>
                        <td class="style35">
                        </td>
                    </tr>
                    <tr>
                        <td class="style58" colspan="3">
                           <i><asp:Label ID="lblMsgEmail" runat="server" Text="Ingrese el correo o los correos separados por ';'(punto y coma), y sin el dominio. Si no desea confirmación, dejar vacío."></asp:Label></i>
                        </td>                        
                    </tr>
                </table>                            
                                
            </td>
            <td class="style31">&nbsp;
                </td>
        </tr>
        <tr>
            <td class="style29" style="width: 52px">
                &nbsp;</td>
            <td class="style30" style="width: 368px">
                               
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
                <asp:Button ID="btnCompletar" runat="server" Text="Actualizar" CssClass="button"/>
            </td>
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
    <div id="Continuar">
        <table style="width: 100%; height: 140px;" style="font-size: 8pt; font-family: Verdana; width: 747px; height: 110px;">
            <tr>
                <td class="style34" style="height: 51px;" colspan="3" background="images/toplarge.png">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/aspx/images/BannerTop.png" Width="816px"
                        Height="100px" ImageAlign="RIGHT" />
                </td>
            </tr>
            <tr>
                <td class="style34" style="height: 51px;" colspan="3" bgcolor="#000000">
                </td>
            </tr>
            </table>
        <div id ="Continuar-botton">
            <asp:Button ID="btnContinuar" runat="server" Text="Continuar" Width="77px" CssClass="button"/>
        </div>
        </div>

    </div>
    </form>
</body>
</html>