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
    Public Shared directorioSeleccionado As String
    Public Shared ActualizacionFlash As String = "F"
    Public Shared textoLog As String = ""
    Public Shared identificador As String = ""
    Public Shared fechaHora As DateTime = DateTime.Now

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then
                Dim fecha As DateTime = DateTime.Now
                fechaHora = fecha
                identificador = ConvertirFechaHora(fechaHora)
                Me.loghub.Value = identificador
                Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()


                listaKioscos = New List(Of ENKiosco)

                Dim dt As DataTable = Sql_Get_KioscosIP()

                For Each dr As DataRow In dt.Rows
                    Dim kio As New ENKiosco()
                    kio.IpKiosco = dr(0).ToString()
                    kio.RutaPathArchivos = pathCliente

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

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Dim CarpetaBackup As String = "\backup\"
            Dim CarpetaFecha As String = identificador

            Dim rutaArchivo As String
            Dim fileOK As Boolean = False

            If fuBuscar.HasFile Then

                Dim fileExtension As String
                fileExtension = System.IO.Path.GetExtension(fuBuscar.FileName).ToLower()

                If fileExtension = ".swf" Or fileExtension = ".txt" Then
                    Label1.Visible = False

                    Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

                    rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName

                    Dim carpetaDestino As String = PathServer + CarpetaBackup + CarpetaFecha
                    If Directory.Exists(carpetaDestino) = False Then
                        Directory.CreateDirectory(carpetaDestino)
                    End If

                    If File.Exists(rutaArchivo) Then
                        If File.Exists(carpetaDestino + "\" + fuBuscar.FileName) = False Then
                            File.Copy(rutaArchivo, carpetaDestino + "\" + fuBuscar.FileName)
                        End If
                    End If

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


    <WebMethod()> _
    Public Shared Function Completar(ByVal Archivos As List(Of String), ByVal radio As String, ByVal Kioscos As List(Of String), ByVal usuario As String, ByVal password As String, ByVal dominio As String) As String
        Try

            If Archivos.Count < 1 Then
                Return "No ha seleccionado ningun archivo!"
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
                listaFinalKioscos = listaKioscos
            End If


            EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Actualizando Programa RipleyMático", ActualizacionFlash)
            EnvioData.Instancia.EscribirLog(identificador, "    -Ha seleccionado " + listaARchivos.Count.ToString() + " archivos", ActualizacionFlash)
            EnvioData.Instancia.EscribirLog(identificador, "    -Se copiarán los archivos a " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionFlash)

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
                        EnvioData.Instancia.EscribirLog(identificador, "    -Terminado " + nombreKiosko + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionFlash)
                    Else
                        EnvioData.Instancia.EscribirLog(identificador, "    -No se pudo terminar el kiosko " + nombreKiosko, ActualizacionFlash)
                    End If
                Catch ex As Exception
                    EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Es posible que no tenga permiso de acceso a un archivo.", ActualizacionFlash)
                    Return "Es posible que no tenga permiso de acceso a un archivo"
                End Try
            Next
            EnvioData.Instancia.EscribirLog(identificador, "    -Fin Proceso: " + "Se terminó de ejecutar el proceso. ", ActualizacionFlash)

            Return "exito|" + listaFinalKioscos.Count.ToString() + "|" + contar.ToString() + "|" + (listaFinalKioscos.Count - contar).ToString()
        Catch ex As Exception
            EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Intentelo nuevamente más tarde.", ActualizacionFlash)
            Return "Error de Codigo"
        End Try
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
            'Dim thread As Thread = New ThreadStart()
            lista = EnvioData.Instancia.ConsultarLog(identificador, ActualizacionFlash)
        End If
        Return lista
    End Function

    Public Function ConvertirFechaHora(ByVal fecha As DateTime) As String
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
End Class
