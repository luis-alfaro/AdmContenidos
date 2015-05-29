Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports System.Data
Imports System.Configuration
Imports System.Web.Services
Imports System.Threading
Imports System.IO

Partial Class aspx_EdicionRipleyMatico
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared listaTemp As List(Of ENKiosco)
    Public Shared directorioSeleccionado As String
    Public Shared ActualizacionImagenes As String = "I"
    Public Shared modulo As String = "Actualización de Imágenes"
    Public Shared prefijo As String = ""
    Public Shared textoLog As String = ""
    Public Shared identificador As String = ""
    Public Shared fechaHora As DateTime = DateTime.Now
    Public Shared rptaCompletar As String = ""
    Public Shared session_id As String = ""
    Public Shared username As String = ""
    Public Shared rutaTemplate As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then
                'Dim fecha As DateTime = DateTime.Now
                'fechaHora = fecha
                'identificador = fecha.Year.ToString() + fecha.Month.ToString() + fecha.Minute.ToString() + fecha.Second.ToString()
                'Me.loghub.Value = identificador
                Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()

                InicarIdentificador()
                listaKioscos = New List(Of ENKiosco)
                listaTemp = New List(Of ENKiosco)
                Dim dt As DataTable = Sql_Get_KioscosIP()

                For Each dr As DataRow In dt.Rows
                    Dim kio As New ENKiosco()
                    kio.IpKiosco = dr(0).ToString()
                    kio.RutaPathArchivos = pathCliente

                    listaKioscos.Add(kio)

                    kio.Ubicacion = dr(2).ToString()
                    listaTemp.Add(kio)
                Next

                cblKioscos.Items.Clear()
                cblKioscos.DataSource = Nothing
                cblKioscos.DataSource = listaKioscos
                cblKioscos.DataTextField = "IpKiosco"
                cblKioscos.DataBind()

                rutaTemplate = Server.MapPath("~\Templates\")
                session_id = Session("SESSION_ID")
                username = GetNombreUsuario()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub InicarIdentificador()
        Dim fecha As DateTime = DateTime.Now
        fechaHora = fecha
        identificador = ConvertirFechaHora(fechaHora)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim ok As Boolean = False
        Dim rutaArchivo As String
        Try
            If String.IsNullOrEmpty(prefijo) Then
                txthidden.Value = "Debe seleccionar una carpeta antes de subir un archivo."
            Else
                txthidden.Value = ""
                If fuBuscar.HasFile Then
                   
                    If directorioSeleccionado.StartsWith("\documentosSEF") Then
                        If LbxImagenes.Items.Count = 0 Then
                            If prefijo & ".jpg" = fuBuscar.FileName Then

                                Dim rutaTemporal As String = String.Format("{0}{1}{2}", System.Web.HttpContext.Current.Request.PhysicalApplicationPath, "Temp\", fuBuscar.FileName)
                                fuBuscar.SaveAs(rutaTemporal)
                                Dim imageDocumentoSEF As System.Drawing.Image
                                Dim widthDocumentoSEF As String
                                imageDocumentoSEF = System.Drawing.Image.FromFile(rutaTemporal)
                                widthDocumentoSEF = imageDocumentoSEF.Width.ToString()

                                If Convert.ToInt32(widthDocumentoSEF) <= Convert.ToInt32("760") Then
                                    'Guardar en Disco Final
                                    Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()
                                    rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName
                                    fuBuscar.SaveAs(rutaArchivo)
                                    LbxImagenes.Items.Add(rutaArchivo)


                                    ''EliminarArchivoTemporal
                                    'If (System.IO.File.Exists(rutaTemporal)) Then
                                    '    System.IO.File.Delete(rutaTemporal)
                                    'End If

                                Else
                                    txthidden.Value = "El ancho del archivo debe ser máximo de 760 px"
                                End If
                            Else
                                txthidden.Value = "El archivo debe llamarse " & prefijo & ".jpg"
                            End If
                        Else
                            txthidden.Value = "Sólo se permite agregar un archivo a esta carpeta"
                        End If

                    ElseIf directorioSeleccionado.StartsWith("\CambioProducto") Then
                        If LbxImagenes.Items.Count < 4 Then
                            If prefijo & "_1.jpg" = fuBuscar.FileName Or prefijo & "_2.jpg" = fuBuscar.FileName Or prefijo & "_3.jpg" = fuBuscar.FileName Or prefijo & "_4.jpg" = fuBuscar.FileName Then

                                Dim rutaTemporal As String = String.Format("{0}{1}{2}", System.Web.HttpContext.Current.Request.PhysicalApplicationPath, "Temp\", fuBuscar.FileName)
                                fuBuscar.SaveAs(rutaTemporal)
                                Dim imageCambioProducto As System.Drawing.Image
                                Dim widthCambioProducto As String
                                imageCambioProducto = System.Drawing.Image.FromFile(rutaTemporal)
                                widthCambioProducto = imageCambioProducto.Width.ToString()

                                If Convert.ToInt32(widthCambioProducto) <= Convert.ToInt32("760") Then
                                    'Guardar en Disco Final
                                    Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()
                                    rutaArchivo = PathServer & directorioSeleccionado & "\" & fuBuscar.FileName
                                    fuBuscar.SaveAs(rutaArchivo)
                                    LbxImagenes.Items.Add(rutaArchivo)


                                    ''EliminarArchivoTemporal
                                    'If (System.IO.File.Exists(rutaTemporal)) Then
                                    '    System.IO.File.Delete(rutaTemporal)
                                    'End If

                                Else
                                    txthidden.Value = "El ancho del archivo debe ser máximo de 760 px"
                                End If
                            Else
                                txthidden.Value = "El archivo puede llamarse:<br/><b>" & prefijo & "_1.jpg<b/><br/><b>" & prefijo & "_2.jpg<b/><br/><b>" & prefijo & "_3.jpg<b/><br/><b>" & prefijo & "_4.jpg"
                            End If
                        Else
                            txthidden.Value = "Sólo se permite agregar 4 archivos a esta carpeta"
                        End If

                    Else

                        If fuBuscar.FileName.StartsWith(prefijo) Then
                            Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

                            rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName

                            fuBuscar.SaveAs(rutaArchivo)

                            Dim arch As FileInfo = New FileInfo(rutaArchivo)
                            Dim ext As String = Path.GetExtension(fuBuscar.FileName)
                            Dim width As String
                            Dim height As String
                            Dim size As String
                            Dim image As System.Drawing.Image
                            size = arch.Length.ToString()

                            Select Case ext.ToLower()
                                Case ".jpg"
                                    image = System.Drawing.Image.FromFile(rutaArchivo)
                                    width = image.Width.ToString()
                                    height = image.Height.ToString()

                                    If width = "910" And height = "555" Then
                                        ok = True
                                    Else
                                        txthidden.Value = "Las dimensiones del archivo no pueden ser admitidas."
                                        ok = False
                                    End If
                                Case ".png"
                                    image = System.Drawing.Image.FromFile(rutaArchivo)
                                    width = image.Width.ToString()
                                    height = image.Height.ToString()
                                    If width = "910" And height = "555" Then
                                        ok = True
                                    Else
                                        txthidden.Value = "Las dimensiones del archivo no pueden ser admitidas."
                                        ok = False
                                    End If
                                Case ".wmv"
                                    size = arch.Length.ToString()
                                    If size < "80000000" Then
                                        ok = True
                                    Else
                                        txthidden.Value = "La extensión del archivo no es admitida, por favor revisar."
                                        ok = False
                                    End If

                                Case Else
                                    txthidden.Value = "La extensión del archivo no es admitida, por favor revisar."
                                    ok = False

                            End Select
                            If ok Then
                                LbxImagenes.Items.Add(rutaArchivo)
                            End If

                        Else
                            txthidden.Value = "El archivo escogido no cumple con las especificaciones requeridas para esta carpeta, por favor revisar."
                        End If

                    End If
                End If
            End If
            LbxImagenes.Focus()

        Catch ex As Exception

        End Try
    End Sub

    <WebMethod()> _
    Public Shared Sub GuardarArchivosEnKioscos(ByVal Archivos As List(Of String), ByVal radio As String, ByVal Kioscos As List(Of String), ByVal usuario As String, ByVal password As String, ByVal dominio As String, ByVal email As String, ByVal descripcion As String, ByVal ubicacion As String)
        Dim cantidadKioskos As Integer = 0
        Dim contenido As String = ""
        Try
            rptaCompletar = ""
            If Archivos.Count < 1 Then
                EnvioData.Instancia.EscribirLog(identificador, "-No se seleccionaron imagenes.", ActualizacionImagenes)
                Return
            Else
                'Label1.Visible = False
            End If

            Dim listaARchivos As New List(Of String)

            For Each item As String In Archivos
                listaARchivos.Add(item)
            Next

            Dim objEnvio As New EnvioData
            Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

            If Not (directorioSeleccionado.StartsWith("\documentosSEF") Or directorioSeleccionado.StartsWith("\CambioProducto")) Then
                EnvioData.Instancia.GenerarArchivos(listaKioscos, listaARchivos, directorioSeleccionado, PathServer)
            End If


            Dim contar As Integer = 0
            Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()
            Dim listTempKioscos As New List(Of ENKiosco)
            Dim listaFinalKioscos As New List(Of ENKiosco)


            If radio = "Uno" Then
                If Kioscos.Count > 0 Then
                    For Each Kiosco As String In Kioscos
                        Dim kioscoTemp As New ENKiosco
                        kioscoTemp.IpKiosco = Kiosco
                        kioscoTemp.RutaPathArchivos = pathCliente '"\Files_videos\RipleyMaticoDS"
                        listTempKioscos.Add(kioscoTemp)
                    Next
                    listaFinalKioscos = listTempKioscos
                End If
            Else
                If ubicacion = "T" Then
                    listaFinalKioscos = listaTemp
                Else
                    listaFinalKioscos = listaTemp.Where(Function(y) y.Ubicacion = ubicacion).ToList()
                End If

            End If
            cantidadKioskos = listaFinalKioscos.Count

            EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Actualizando Imágenes RipleyMático", ActualizacionImagenes)
            EnvioData.Instancia.EscribirLog(identificador, "Descripción: " + descripcion, ActualizacionImagenes)
            EnvioData.Instancia.EscribirLog(identificador, "-Ha seleccionado " + listaARchivos.Count.ToString() + " archivos", ActualizacionImagenes)
            EnvioData.Instancia.EscribirLog(identificador, "-Se copiarán los archivos a " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionImagenes)

            For Each kio As ENKiosco In listaFinalKioscos
                Dim ok As Boolean
                Dim nombreKiosko As String = kio.IpKiosco
                Try

                    Dim kiosko As ENKiosco = kio
                    kiosko.IpKiosco = obtenerIP(kiosko.IpKiosco)

                    ok = EnvioData.Instancia.EnviarArchivos(kiosko, directorioSeleccionado, PathServer, usuario, password, dominio, textoLog, listaARchivos, identificador)
                    If ok = True Then
                        contar = contar + 1
                        EnvioData.Instancia.EscribirLog(identificador, "-Terminado " + nombreKiosko + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionImagenes)
                    Else
                        EnvioData.Instancia.EscribirLog(identificador, "-No se pudo terminar el kiosko " + nombreKiosko, ActualizacionImagenes)
                    End If
                Catch ex As Exception
                    EnvioData.Instancia.EscribirLog(identificador, "Error: " + nombreKiosko + " Es posible que no tenga permiso de acceso a un archivo, o haya sido borrado durante la ejecución.", ActualizacionImagenes)
                End Try
            Next
            EnvioData.Instancia.EscribirLog(identificador, "-Fin Proceso: " + "Se terminó de ejecutar el proceso. ", ActualizacionImagenes)

            rptaCompletar = "exito|" + listaFinalKioscos.Count.ToString() + "|" + contar.ToString() + "|" + (listaFinalKioscos.Count - contar).ToString()
            If contar > 0 Then
                contenido = String.Format("Se ha enviado {0} nuevos archivos para actualizar a {1} Ripleymatico(s) desde el modulo de {2}.", Archivos.Count.ToString(), cantidadKioskos.ToString(), modulo)
                EnviarEmailConfirmacion(email, Archivos, cantidadKioskos, descripcion, contenido)
            End If
            InicarIdentificador()
            Return
        Catch ex As Exception
            EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Intentelo nuevamente más tarde. " + ex.Message, ActualizacionImagenes)
            rptaCompletar = "Ha ocurrido un error en el código, revise las fuentes." + ex.Message
            contenido = String.Format("Ha ocurrido un error en el proceso de {0}. Revisar el Log para mayor detalle.", modulo)
            EnviarEmailConfirmacion(email, Archivos, cantidadKioskos, descripcion, contenido)
            Return
        End Try
    End Sub

    <WebMethod()> _
    Public Shared Sub Completar(ByVal Archivos As List(Of String), ByVal radio As String, ByVal Kioscos As List(Of String), ByVal usuario As String, ByVal password As String, ByVal dominio As String, ByVal email As String, ByVal descripcion As String, ByVal ubicacion As String)
        Dim t As New Thread(New ThreadStart(Sub() GuardarArchivosEnKioscos(Archivos, radio, Kioscos, usuario, password, dominio, email, descripcion, ubicacion)))
        t.Start()
    End Sub

    Public Shared Sub EnviarEmailConfirmacion(ByVal email As String, ByVal Archivos As List(Of String), ByVal cantidadKioskos As Integer, ByVal descripcion As String, ByVal contenido As String)
        Dim listaMails As List(Of DireccionCorreo)
        Dim listaDirecciones As List(Of DireccionCorreo) = ObtenerDirecciones()
        Dim remite As DireccionCorreo = New DireccionCorreo
        Dim remiten As List(Of DireccionCorreo) = listaDirecciones.Where(Function(i) i.Remitente = True).Take(1).ToList()
        If remiten.Count > 0 Then
            remite = remiten(0)
        Else
            remite = Nothing
        End If
        listaMails = listaDirecciones.Where(Function(i) i.Remitente = False).ToList()
        If String.IsNullOrEmpty(email) = False Or listaMails.Count > 0 Then
            Dim body As String = ""
            body = System.IO.File.ReadAllText(rutaTemplate + "EdicionTemplate.htm")
            Dim tiempo As DateTime = DateTime.Now
            body = body.Replace("#Nombre#", username)
            body = body.Replace("#Contenido#", contenido)
            body = body.Replace("#Descripcion#", descripcion)
            body = body.Replace("#Fecha#", tiempo.ToShortDateString())
            body = body.Replace("#Hora#", tiempo.ToShortTimeString())

            Dim array As List(Of EmailMessage) = New List(Of EmailMessage)
            Dim eMessage As EmailMessage
            Dim cantidadCorreos As String() = Split(email, ";", , CompareMethod.Binary)
            For y As Integer = 0 To cantidadCorreos.Length - 1 Step +1
                If String.IsNullOrEmpty(cantidadCorreos(y)) = False Then
                    eMessage = New EmailMessage
                    If cantidadCorreos(y).Contains("@") Then
                        eMessage.To = cantidadCorreos(y)
                    Else
                        eMessage.To = cantidadCorreos(y) + "@bancoripley.com.pe"
                    End If

                    array.Add(eMessage)
                End If
            Next
            For Each Mail As DireccionCorreo In listaMails
                eMessage = New EmailMessage
                eMessage.To = Mail.Direccion
                array.Add(eMessage)
            Next
            array = array.Distinct().ToList()
            Dim asunto As String = "Actualización de Imágenes de " + tiempo.ToShortDateString() + " a las  " + tiempo.ToShortTimeString()
            EnvioEmail.Instancia.SendEmailMasivoDefaultFrom(array, asunto, body, Nothing, remite)
        End If

    End Sub

    Protected Sub LbxImagenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbxImagenes.SelectedIndexChanged
        Try
            LbxImagenes.Items.RemoveAt(LbxImagenes.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub tvDirectorios_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvDirectorios.SelectedNodeChanged

        Try
            If tvDirectorios.SelectedValue.StartsWith("\documentosSEF") Then
                directorioSeleccionado = "\documentosSEF"
            Else
            directorioSeleccionado = tvDirectorios.SelectedValue
            End If

            prefijo = tvDirectorios.SelectedNode.ToolTip
            'tvDirectorios.Enabled = False
            For Each nodo As TreeNode In tvDirectorios.Nodes
                nodo.SelectAction = TreeNodeSelectAction.None
            Next
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub rbUno_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbUno.CheckedChanged
        Try
            cblKioscos.Visible = True
            cblKioscos.Items.Clear()
            cblKioscos.DataSource = listaKioscos
            cblKioscos.DataTextField = "IpKiosco"
            cblKioscos.DataBind()

            cblKioscos.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rbTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged
        cblKioscos.Visible = False
        cblKioscos.Focus()
    End Sub
    Protected Sub rbLima_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbLima.CheckedChanged
        cblKioscos.Visible = False
        cblKioscos.Focus()
    End Sub
    Protected Sub rbProvincia_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbProvincia.CheckedChanged
        cblKioscos.Visible = False
        cblKioscos.Focus()
    End Sub
    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cblKioscos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblKioscos.SelectedIndexChanged

    End Sub

    Public Shared Function obtenerIP(ByVal cadena As String) As String

        Dim inicio As String = cadena.IndexOf("[") + 1
        Dim final As String = cadena.IndexOf("]") - 1

        Dim arrayTemp() As Char = cadena.ToCharArray()

        Dim IP As String = ""

        For i As Integer = inicio To final
            IP = IP + arrayTemp(i)
        Next


        Return IP
    End Function

    <WebMethod()>
    Public Shared Function ObtenerLogPantalla(ByVal identificadorx As String) As List(Of String)
        Dim lista As New List(Of String)
        If identificador <> "" Then
            lista = EnvioData.Instancia.ConsultarLog(identificador, ActualizacionImagenes)
        End If
        Return lista
    End Function

    Public Shared Function ConvertirFechaHora(ByVal fecha As DateTime) As String
        Dim nuevaFecha, dia, mes, year, hora, minuto As String
        dia = fecha.Day.ToString()
        mes = fecha.Month.ToString()
        year = fecha.Year.ToString()
        hora = fecha.Hour.ToString()
        minuto = fecha.Minute.ToString()

        If (dia.Length < 2) Then
            dia = "0" + dia
        End If
        If (mes.Length < 2) Then
            mes = "0" + mes
        End If
        If (hora.Length < 2) Then
            hora = "0" + hora
        End If

        If (minuto.Length < 2) Then
            minuto = "0" + minuto
        End If

        nuevaFecha = year + mes + dia + hora + minuto
        Return nuevaFecha
    End Function

    Public Shared Function GetNombreUsuario() As String
        Dim usern As String = "Anónimo"
        If Not (session_id Is Nothing) Then
            Dim dtConfig As New DataTable
            Dim sMensajeError As String = ""
            dtConfig = fun_devolverDatosConfiguracion(session_id.ToString.Trim, sMensajeError) 'el Session.SessionID cambia de numero al que se guardo revisar.


            If dtConfig.Rows.Count <= 0 Then 'Su session ha expirado
                usern = "Anónimo"
            Else
                usern = Cryptor(dtConfig.Rows(0).Item("LOGUEADO")).ToUpper()
            End If
        End If
        Return usern
    End Function

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Try
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function ObtenerDirecciones() As List(Of DireccionCorreo)
        Dim listaCorreos = New List(Of DireccionCorreo)

        Dim dt As DataTable = Sql_Get_DireccionesCorreo()

        For Each dr As DataRow In dt.Rows
            Dim correo As New DireccionCorreo()
            correo.ID = dr("ID")
            correo.Nombre = dr("NOMBRE")
            correo.Direccion = dr("DIRECCION")
            correo.Password = dr("PASSWORD")
            correo.Server = dr("SERVER")
            correo.Puerto = dr("PUERTO")
            correo.Remitente = dr("REMITENTE")

            listaCorreos.Add(correo)
        Next
        Return listaCorreos
    End Function
End Class