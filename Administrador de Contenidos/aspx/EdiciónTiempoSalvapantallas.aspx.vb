Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports System.Data
Imports System.Configuration
Partial Class aspx_EdiciónTiempoSalvapantallas
    Inherits System.Web.UI.Page

    Public Shared archivoTiempo As String

    Public Shared listaKioscos As List(Of ENKiosco)

    Protected Sub btnCompletar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompletar.Click


        Try
            If lblMsg.Visible = False Then
                Exit Sub
            End If

            Dim listTempKioscos As New List(Of ENKiosco)
            Dim listaFinalKioscos As New List(Of ENKiosco)


            'listaARchivos.Add("C:\RipleyMaticoDS" + directorioSeleccionado + "\data.xml")

            If rbUno.Checked = True Then


                For i As Integer = 0 To cblKioscos.Items.Count - 1
                    If cblKioscos.Items(i).Selected = True Then
                        Dim kioscoTemp As New ENKiosco
                        kioscoTemp.IpKiosco = cblKioscos.Items(i).Text
                        kioscoTemp.RutaPathArchivos = ConfigurationManager.AppSettings("RutaCarpetaControladorPanelClientes").ToString() '"\Files_videos\RipleyMaticoDS"
                        listTempKioscos.Add(kioscoTemp)
                    End If

                Next


                'For Each item As CheckBox In cblKioscos.Items
                '    If item.Checked = True Then
                '        Dim kioscoTemp As New ENKiosco
                '        kioscoTemp.IpKiosco = item.Text
                '        listTempKioscos.Add(kioscoTemp)
                '    End If
                'Next

                listaFinalKioscos = listTempKioscos
            Else
                listaFinalKioscos = listaKioscos
            End If



            Dim objEnvio As New EnvioData
            Dim contar As Integer

            objEnvio.hacerLinea("Actualizar Temporizador")

            For Each kio As ENKiosco In listaFinalKioscos


                'avance = "Enviando Kioscos " + contar.ToString() + "/" + listaKioscos.Count.ToString()

                Try
                    Dim ok As Boolean

                    kio.IpKiosco = obtenerIP(kio.IpKiosco)

                    ok = objEnvio.EnviarUnArchivo(kio, archivoTiempo, ConfigurationManager.AppSettings("RutaCarpetaControladorPanelServer").ToString() + "\", txtUsuario.Text.Trim(), txtDominio.Text.Trim(), txtPassword.Text.Trim())

                    If ok = True Then
                        contar = contar + 1

                    End If

                Catch ex As Exception

                End Try
            Next



            txtSeleccionados.Text = listaFinalKioscos.Count
            txtActualizados.Text = contar
            txtNoActualizados.Text = listaFinalKioscos.Count - contar



            cblKioscos.Visible = False
            rbTodos.Checked = True
            rbUno.Checked = False

            txtNoActualizados.Focus()

        Catch ex As Exception

        End Try


        lblMsg.Visible = False



    End Sub

    Protected Sub btnGuardarTiempo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarTiempo.Click

        Try

            If fuTiempoSalvaPantallas.HasFile = True Then

                fuTiempoSalvaPantallas.SaveAs(ConfigurationManager.AppSettings("RutaCarpetaControladorPanelServer").ToString() + "\" + fuTiempoSalvaPantallas.FileName)
                archivoTiempo = fuTiempoSalvaPantallas.FileName
                lblMsg.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then


                listaKioscos = New List(Of ENKiosco)

                Dim dt As DataTable = Sql_Get_KioscosIP()

                For Each dr As DataRow In dt.Rows
                    Dim kio As New ENKiosco()
                    kio.IpKiosco = dr(0).ToString()
                    kio.RutaPathArchivos = ConfigurationManager.AppSettings("RutaCarpetaControladorPanelClientes").ToString()

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

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub



    Private Function obtenerIP(ByVal cadena As String) As String

        Dim inicio As String = cadena.IndexOf("[") + 1
        Dim final As String = cadena.IndexOf("]") - 1

        Dim arrayTemp() As Char = cadena.ToCharArray()

        Dim IP As String = ""

        For i As Integer = inicio To final
            IP = IP + arrayTemp(i)
        Next


        Return IP
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
End Class
