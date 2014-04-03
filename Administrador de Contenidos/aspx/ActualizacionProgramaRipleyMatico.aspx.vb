Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports AccessLayer
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.Services
Imports System.Threading

Partial Class aspx_ActualizacionProgramaRipleyMatico
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared directorioSeleccionado As String
    Public Shared ActualizacionPrograma As String = "P"
    Public Shared textoLog As String = ""
    Public Shared identificador As String = ""
    Public Shared fechaHora As DateTime = DateTime.Now

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then
                Dim fecha As DateTime = DateTime.Now
                fechaHora = fecha
                identificador = fecha.Year.ToString() + fecha.Month.ToString() + fecha.Minute.ToString() + fecha.Second.ToString()
                Me.loghub.Value = identificador
                Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()
                Dim carpetaPrograma As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoPrograma").ToString()


                listaKioscos = New List(Of ENKiosco)

                Dim dt As DataTable = Sql_Get_KioscosIP()

                For Each dr As DataRow In dt.Rows
                    Dim kio As New ENKiosco()
                    kio.IpKiosco = dr(0).ToString()
                    kio.RutaPathArchivos = pathCliente + carpetaPrograma

                    listaKioscos.Add(kio)
                Next

                cblKioscos.Items.Clear()
                cblKioscos.DataSource = Nothing
                cblKioscos.DataSource = listaKioscos
                cblKioscos.DataTextField = "IpKiosco"
                cblKioscos.DataBind()
            End If
        Catch ex As Exception

        End Try

    End Sub

    <WebMethod()> _
    Public Shared Function Aceptar(ByVal ruta As String) As String

        Try
            Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()
            Dim carpetaPrograma As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoPrograma").ToString()
            Dim rutaCarpetaDestino As String = PathServer + carpetaPrograma
            Dim rutaArchivoDestino As String
            If Directory.Exists(rutaCarpetaDestino) = False Then
                Directory.CreateDirectory(rutaCarpetaDestino)
            End If

            Dim fileOK As Boolean = False
            Dim files As String() = Directory.GetFiles(ruta)

            For Each archivo As String In files
                rutaArchivoDestino = rutaCarpetaDestino + Path.GetFileName(archivo)
                File.Copy(archivo, rutaArchivoDestino, True)
            Next
            Return "Ok"
        Catch ex As Exception
            Return "Error " + ex.Message
        End Try
    End Function

    <WebMethod()> _
    Public Shared Function Completar(ByVal ruta As String, ByVal radio As String, ByVal Kioscos As List(Of String), ByVal usuario As String, ByVal password As String, ByVal dominio As String) As String
        Try

            If String.IsNullOrEmpty(ruta) Then
                'Label1.Visible = True
                'Label1.Text = "No se a seleccionado alguna imagen para enviar"
                Return "No ha seleccionado ningun archivo!"
            Else
                'Label1.Visible = False
            End If


            Dim objEnvio As New EnvioData
            Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()
            Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()
            Dim carpetaPrograma As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoPrograma").ToString()
            Dim rutaServidor As String = PathServer + carpetaPrograma
            Dim cantidad = EnvioData.Instancia.GenerarArchivosPrograma(listaKioscos, ruta, carpetaPrograma, PathServer)
            Dim contar As Integer = 0

            pathCliente = pathCliente + carpetaPrograma
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
                listaFinalKioscos = listaKioscos
            End If


            EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Actualizando Programa RipleyMático", ActualizacionPrograma)
            'System.Threading.Thread.Sleep(1000)
            EnvioData.Instancia.EscribirLog(identificador, "    -Ha seleccionado " + cantidad.ToString() + " archivos", ActualizacionPrograma)
            EnvioData.Instancia.EscribirLog(identificador, "    -Se copiarán los archivos a " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionPrograma)

            For Each kio As ENKiosco In listaFinalKioscos
                Try
                    Dim ok As Boolean

                    'kio.IpKiosco = obtenerIP(kio.IpKiosco)
                    Dim kiosko As ENKiosco = kio
                    kiosko.IpKiosco = obtenerIP(kiosko.IpKiosco)
                    ok = EnvioData.Instancia.EnviarArchivosPrograma(kiosko, carpetaPrograma, PathServer, usuario, password, dominio, textoLog, rutaServidor, identificador)
                    If ok = True Then
                        contar = contar + 1
                        EnvioData.Instancia.EscribirLog(identificador, "    -Terminado " + kio.IpKiosco + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionPrograma)
                    Else
                        EnvioData.Instancia.EscribirLog(identificador, "    -No se pudo terminar el kiosko " + kio.IpKiosco, ActualizacionPrograma)
                    End If
                Catch ex As Exception
                    EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Es posible que no tenga permiso de acceso a un archivo.", ActualizacionPrograma)
                    Return "Es posible que no tenga permiso de acceso a un archivo"
                End Try
            Next
            EnvioData.Instancia.EscribirLog(identificador, "    -Fin Proceso: " + "Se terminó de ejecutar el proceso. ", ActualizacionPrograma)

            Return "exito|" + listaFinalKioscos.Count.ToString() + "|" + contar.ToString() + "|" + (listaFinalKioscos.Count - contar).ToString()
        Catch ex As Exception
            EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Intentelo nuevamente más tarde.", ActualizacionPrograma)
            Return "Error de Codigo"
        End Try
    End Function


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

    <WebMethod()> _
    Public Shared Function ObtenerLogPantalla(ByVal identificador As String) As List(Of String)
        Dim lista As New List(Of String)
        If identificador <> "" Then
            lista = EnvioData.Instancia.ConsultarLog(identificador, ActualizacionPrograma)
        End If
        Return lista
    End Function
End Class
