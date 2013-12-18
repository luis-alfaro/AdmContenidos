
Partial Class aspx_error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sError As String
        sError = Request.QueryString("mensajeerror")
        lblMensajeError.Text = "Descripcion del Error : " + sError
    End Sub
End Class
