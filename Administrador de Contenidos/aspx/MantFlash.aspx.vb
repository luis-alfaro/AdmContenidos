Imports System.Configuration
Imports UtilitarioEnvioData.EnvioData

Partial Class aspx_MantFlash
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Try
                cargarLista()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try

            Dim objUtil As New UtilitarioVideos
            objUtil.Delete_video(lbxVideos.SelectedItem.Text)


            cargarLista()
            lblMsg.Text = "Eliminado Exitoso"
            lblMsg.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarLista()
  
        Dim rutaVideos As String = ConfigurationManager.AppSettings("PATH_FILES_FLASH").ToString()
        Dim objUtil As New UtilitarioVideos
        Dim listavideos() As String = objUtil.Get_videos(rutaVideos)
        lbxVideos.DataSource = listavideos
        lbxVideos.DataBind()
    End Sub


    Protected Sub btnGuardarTiempo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarTiempo.Click
        Try

            Dim rutaVideos As String = ConfigurationManager.AppSettings("PATH_FILES_FLASH").ToString()

            If fuVideo.HasFile Then
                fuVideo.SaveAs(rutaVideos + fuVideo.FileName)

            End If
            cargarLista()
            lblMsg.Text = "Guardado Exitoso"
            lblMsg.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("prog_videos.aspx")
        Catch

        End Try
    End Sub
End Class
