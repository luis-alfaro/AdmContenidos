Imports UtilitarioEnvioData.Entidades
Imports UtilitarioEnvioData.EnvioData
Imports System.Data
Imports System.Configuration
Imports System.Web.Services

Partial Class aspx_EdicionRipleyMatico
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared directorioSeleccionado As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack = False Then

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


            If fuBuscar.HasFile Then


                Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()

                rutaArchivo = PathServer + directorioSeleccionado + "\" + fuBuscar.FileName

                fuBuscar.SaveAs(rutaArchivo)

                LbxImagenes.Items.Add(rutaArchivo)

            End If
            LbxImagenes.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub tvDirectorios_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvDirectorios.SelectedNodeChanged

        Try


            directorioSeleccionado = tvDirectorios.SelectedValue
            'tvDirectorios.Enabled = False

            For Each nodo As TreeNode In tvDirectorios.Nodes
                nodo.SelectAction = TreeNodeSelectAction.None

            Next
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnCompletar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompletar.Click


        Try

            If LbxImagenes.Items.Count < 1 Then
                Label1.Visible = True
                Label1.Text = "No se a seleccionado alguna imagen para enviar"
                Exit Sub
            Else
                Label1.Visible = False
            End If



            'lisTEMP.Add(kioscoTemp)


            Dim listaARchivos As New List(Of String)

            For Each item As ListItem In LbxImagenes.Items
                listaARchivos.Add(item.Text)

            Next

            'listaARchivos.Add("C:\RipleyMaticoDS" + directorioSeleccionado + "\data.xml")

            Dim objEnvio As New EnvioData


            Dim PathServer As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoServer").ToString()


            objEnvio.GenerarArchivos(listaKioscos, listaARchivos, directorioSeleccionado, PathServer)


            Dim contar As Integer = 0


            Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()


            Dim listTempKioscos As New List(Of ENKiosco)
            Dim listaFinalKioscos As New List(Of ENKiosco)


            If rbUno.Checked = True Then


                For i As Integer = 0 To cblKioscos.Items.Count - 1
                    If cblKioscos.Items(i).Selected = True Then
                        Dim kioscoTemp As New ENKiosco
                        kioscoTemp.IpKiosco = cblKioscos.Items(i).Text
                        kioscoTemp.RutaPathArchivos = pathCliente '"\Files_videos\RipleyMaticoDS"
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



            objEnvio.hacerLinea("Actualizar Imagenes RipleyMático")

            For Each kio As ENKiosco In listaFinalKioscos


                'avance = "Enviando Kioscos " + contar.ToString() + "/" + listaKioscos.Count.ToString()

                Try
                    Dim ok As Boolean

                    kio.IpKiosco = obtenerIP(kio.IpKiosco)

                    ok = objEnvio.EnviarArchivos(kio, directorioSeleccionado, PathServer, txtUsuario.Text.Trim(), txtPassword.Text.Trim(), txtDominio.Text.Trim())

                    If ok = True Then
                        contar = contar + 1

                    End If

                Catch ex As Exception

                End Try
            Next


            For Each nodo As TreeNode In tvDirectorios.Nodes
                nodo.SelectAction = TreeNodeSelectAction.Select
            Next


            LbxImagenes.Items.Clear()

            txtSeleccionados.Text = listaFinalKioscos.Count
            txtActualizados.Text = contar
            txtNoActualizados.Text = listaFinalKioscos.Count - contar



            cblKioscos.Visible = False
            rbTodos.Checked = True
            rbUno.Checked = False

            txtNoActualizados.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LbxImagenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbxImagenes.SelectedIndexChanged
        Try
            LbxImagenes.Items.RemoveAt(LbxImagenes.SelectedIndex)

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

    <WebMethod()>
    Public Shared Function ObtenerLogPantalla(ByVal identificador As String) As List(Of String)
        Dim lista As New List(Of String)
        If identificador <> "" Then
            lista = EnvioData.Instancia.ConsultarLog(identificador, DateTime.Now)
        End If
        If lista.Count = 0 Then
            lista.Add("aaaaaa")
        End If
        Return lista
    End Function
End Class
