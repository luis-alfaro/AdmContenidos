Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports System.Data
Imports System.Configuration
Imports System.Web.Services
Imports System.Threading
Imports System.IO

Partial Class aspx_ActualizacionRipleyMatico
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared listaTemp As List(Of ENKiosco)
    Public Shared directorioSeleccionado As String
    Public Shared ActualizacionFlash As String = "F"
    Public Shared modulo As String = "Actualización de Ripleymatico"
    Public Shared textoLog As String = ""
    Public Shared identificador As String = ""
    Public Shared fechaHora As DateTime = DateTime.Now
    Public Shared rptaCompletar As String = ""
    Public Shared session_id As String = ""
    Public Shared rutaTemplate As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then
                
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

        Try
            'Dim CarpetaBackup As String = "\backup\"
            'Dim CarpetaFecha As String = identificador

            Dim rutaArchivo As String
            Dim fileOK As Boolean = False

            If fuBuscar.HasFile Then

                Dim fileExtension As String
                fileExtension = System.IO.Path.GetExtension(fuBuscar.FileName).ToLower()

                If fileExtension = ".swf" Or fileExtension = ".txt" Then
                    Label1.Visible = False

                    Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

                    rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName

                    'Dim carpetaDestino As String = PathServer + CarpetaBackup + CarpetaFecha
                    'If Directory.Exists(carpetaDestino) = False Then
                    '    Directory.CreateDirectory(carpetaDestino)
                    'End If

                    'If File.Exists(rutaArchivo) Then
                    '    If File.Exists(carpetaDestino + "\" + fuBuscar.FileName) = False Then
                    '        File.Copy(rutaArchivo, carpetaDestino + "\" + fuBuscar.FileName)
                    '    End If
                    'End If

                    fuBuscar.SaveAs(rutaArchivo)

                    LbxFlash.Items.Add(rutaArchivo)
                Else
                    Label1.Visible = True
                    Label1.Text = "Debe seleccionar archivos Flash .swf"
                End If
            End If
            LbxFlash.Focus()

        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

    Public Shared Sub GuardarArchivosEnKioscos(ByVal Archivos As List(Of String), ByVal radio As String, ByVal Kioscos As List(Of String), ByVal usuario As String, ByVal password As String, ByVal dominio As String, ByVal email As String, ByVal descripcion As String, ByVal ubicacion As String)
        Dim cantidadKioskos As Integer = 0
        Dim contenido As String = 0
        Try
            rptaCompletar = ""
            If Archivos.Count < 1 Then
                EnvioData.Instancia.EscribirLog(identificador, "No ha seleccionado ningun archivo!", ActualizacionFlash)
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
            EnvioData.Instancia.GenerarArchivosFlash(listaKioscos, listaARchivos, directorioSeleccionado, PathServer)
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

            EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Actualizando Programa RipleyMático", ActualizacionFlash)
            EnvioData.Instancia.EscribirLog(identificador, "Descripción: " + descripcion, ActualizacionFlash)
            EnvioData.Instancia.EscribirLog(identificador, "-Ha seleccionado " + listaARchivos.Count.ToString() + " archivos", ActualizacionFlash)
            EnvioData.Instancia.EscribirLog(identificador, "-Se copiarán los archivos a " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionFlash)

            For Each kio As ENKiosco In listaFinalKioscos
                Try
                    Dim ok As Boolean

                    'kio.IpKiosco = obtenerIP(kio.IpKiosco)
                    Dim nombreKiosko As String = kio.IpKiosco
                    Dim kiosko As ENKiosco = kio
                    kiosko.IpKiosco = obtenerIP(kiosko.IpKiosco)
                    ok = EnvioData.Instancia.EnviarArchivosFlash(kiosko, directorioSeleccionado, PathServer, usuario, password, dominio, textoLog, listaARchivos, identificador)
                    If ok = True Then
                        contar = contar + 1
                        EnvioData.Instancia.EscribirLog(identificador, "-Terminado " + nombreKiosko + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionFlash)
                    Else
                        EnvioData.Instancia.EscribirLog(identificador, "-No se pudo terminar el kiosko " + nombreKiosko, ActualizacionFlash)
                    End If
                Catch ex As Exception
                    EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Es posible que no tenga permiso de acceso a un archivo, o haya sido borrado durante la ejecución.", ActualizacionFlash)

                End Try
            Next
            EnvioData.Instancia.EscribirLog(identificador, "-Fin Proceso: " + "Se terminó de ejecutar el proceso. ", ActualizacionFlash)
            Dim success As Boolean = GuardarEnBackUp(listaARchivos)

            rptaCompletar = "exito|" + listaFinalKioscos.Count.ToString() + "|" + contar.ToString() + "|" + (listaFinalKioscos.Count - contar).ToString()
            If contar > 0 Then
                contenido = String.Format("Se ha enviado {0} nuevos archivos para actualizar a {1} Ripleymatico(s) desde el modulo de {2}.", Archivos.Count.ToString(), cantidadKioskos.ToString(), modulo)
                EnviarEmailConfirmacion(email, Archivos, cantidadKioskos, descripcion, contenido)
            End If
            InicarIdentificador()
            Return
        Catch ex As Exception
            EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Intentelo nuevamente más tarde. " + ex.Message, ActualizacionFlash)
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
        Log.ErrorLog("EnviarEmailConfirmacion")
        Dim listaMails As List(Of DireccionCorreo)
        Dim listaDirecciones As List(Of DireccionCorreo) = ObtenerDirecciones()
        Dim remite As DireccionCorreo = New DireccionCorreo
        Dim remiten As List(Of DireccionCorreo) = listaDirecciones.Where(Function(i) i.Remitente = True).Take(1).ToList()
        Log.ErrorLog("Cantidad de remitentes = " & remiten.Count)
        If remiten.Count > 0 Then
            remite = remiten(0)
        Else
            remite = Nothing
        End If
        listaMails = listaDirecciones.Where(Function(i) i.Remitente = False).ToList()
        If String.IsNullOrEmpty(email) = False Or listaMails.Count > 0 Then
            Dim body As String = System.IO.File.ReadAllText(rutaTemplate + "EdicionTemplate.htm")
            Dim tiempo As DateTime = DateTime.Now
            body = body.Replace("#Nombre#", GetNombreUsuario())
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
            Dim asunto As String = "Actualización de Ripleymático el " + tiempo.ToShortDateString() + " a las  " + tiempo.ToShortTimeString()
            EnvioEmail.Instancia.SendEmailMasivoDefaultFrom(array, asunto, body, Nothing, remite)
        End If

    End Sub


    Public Shared Function GuardarEnBackUp(ByVal archivos As List(Of String)) As Boolean
        Dim CarpetaBackup As String = "\backup\"
        Dim CarpetaFecha As String = identificador
        Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()
        Dim carpetaDestino As String = PathServer + CarpetaBackup + CarpetaFecha
        Try
            If Directory.Exists(carpetaDestino) = False Then
                Directory.CreateDirectory(carpetaDestino)
            End If

            For Each archivo As String In archivos
                File.Copy(archivo, carpetaDestino + "\" + Path.GetFileName(archivo))
            Next
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Protected Sub LbxFlash_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbxFlash.SelectedIndexChanged
        Try
            LbxFlash.Items.RemoveAt(LbxFlash.SelectedIndex)
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
            lista = EnvioData.Instancia.ConsultarLog(identificador, ActualizacionFlash)
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
        Dim username As String = "Anónimo"
        If Not (session_id Is Nothing) Then
            Dim dtConfig As New DataTable
            Dim sMensajeError As String = ""
            dtConfig = fun_devolverDatosConfiguracion(session_id.ToString.Trim, sMensajeError) 'el Session.SessionID cambia de numero al que se guardo revisar.


            If dtConfig.Rows.Count <= 0 Then 'Su session ha expirado
                username = "Anónimo"
            Else
                username = Cryptor(dtConfig.Rows(0).Item("LOGUEADO")).ToUpper()
            End If
        End If
        Return username
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
            Log.ErrorLog("Remitente= " & correo.Remitente)
            listaCorreos.Add(correo)
        Next
        Return listaCorreos
    End Function
End Class
