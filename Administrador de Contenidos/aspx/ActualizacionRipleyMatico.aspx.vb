Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports System.Data
Imports System.Configuration
Imports System.Web.Services
Imports System.Threading

Partial Class aspx_ActualizacionRipleyMatico
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared directorioSeleccionado As String
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

            Dim rutaArchivo As String
            Dim fileOK As Boolean = False

            If fuBuscar.HasFile Then

                Dim fileExtension As String
                fileExtension = System.IO.Path.GetExtension(fuBuscar.FileName).ToLower()

                If fileExtension = ".swf" Or fileExtension = ".txt" Then
                    Label1.Visible = False

                    Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

                    rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName

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
                'Label1.Visible = True
                'Label1.Text = "No se a seleccionado alguna imagen para enviar"
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


            EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Actualizando Programa RipleyMático")
            'System.Threading.Thread.Sleep(1000)
            EnvioData.Instancia.EscribirLog(identificador, "    -Ha seleccionado " + listaARchivos.Count.ToString() + " archivos")
            EnvioData.Instancia.EscribirLog(identificador, "    -Se copiarán los archivos a " + listaFinalKioscos.Count.ToString() + " Kioskos")

            For Each kio As ENKiosco In listaFinalKioscos
                Try
                    Dim ok As Boolean

                    'kio.IpKiosco = obtenerIP(kio.IpKiosco)
                    Dim kiosko As ENKiosco = kio
                    kiosko.IpKiosco = obtenerIP(kiosko.IpKiosco)
                    'ok = objEnvio.EnviarArchivosFlash(kiosko, directorioSeleccionado, PathServer, txtUsuario.Text.Trim(), txtPassword.Text.Trim(), txtDominio.Text.Trim(), textoLog, listaARchivos, identificador)
                    ok = EnvioData.Instancia.EnviarArchivosFlash(kiosko, directorioSeleccionado, PathServer, "ripleymatico", "Saldomatico01", "bancoripley", textoLog, listaARchivos, identificador)
                    If ok = True Then
                        contar = contar + 1
                        EnvioData.Instancia.EscribirLog(identificador, "    -Terminado " + kio.IpKiosco + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos")
                    Else
                        EnvioData.Instancia.EscribirLog(identificador, "    -No se pudo terminar el kiosko " + kio.IpKiosco)
                    End If
                Catch ex As Exception
                    EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Es posible que no tenga permiso de acceso a un archivo.")
                    Return "Es posible que no tenga permiso de acceso a un archivo"
                End Try
            Next
            EnvioData.Instancia.EscribirLog(identificador, "    -Fin Proceso: " + "Se terminó de ejecutar el proceso. ")

            Return "exito|" + listaFinalKioscos.Count.ToString() + "|" + contar.ToString() + "|" + (listaFinalKioscos.Count - contar).ToString()
        Catch ex As Exception
            EnvioData.Instancia.EscribirLog(identificador, "Error: " + "Intentelo nuevamente más tarde.")
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

    
End Class
