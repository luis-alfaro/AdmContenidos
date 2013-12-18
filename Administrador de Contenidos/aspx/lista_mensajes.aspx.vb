Imports System.Data

Partial Class aspx_lista_mensajes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim objMensajes As New Mensajes
            Dim dt As DataTable = objMensajes.Get_Mensajes
            gvListaMensajes.DataSource = dt
            gvListaMensajes.DataBind()

        End If

    End Sub

    Protected Sub gvListaMensajes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaMensajes.SelectedIndexChanged
        Dim sID As String = ""

        Try

            'Evaluar si es editar
            sID = gvListaMensajes.SelectedDataKey("ID")
            Response.Redirect("MantMensaje.aspx?id=" & sID.Trim)


        Catch ex As Exception
            'save error
        End Try

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("Welcome.aspx")
    End Sub
End Class
