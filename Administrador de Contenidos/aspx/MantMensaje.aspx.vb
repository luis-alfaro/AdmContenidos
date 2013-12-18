Imports System.Data


Partial Class aspx_MantMensaje
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try

                Dim lID As Integer = 0
                lID = Request.Item("ID").Trim

                Dim objMensajes As New Mensajes
                Dim dt As DataTable = objMensajes.Get_MensajesByID(lID)

                lblDescripcion.Text = dt(0)("DESC_TARJETA").ToString()

                txtprimer1Linea.Text = dt(0)("INFO1_MENSAJE1").ToString()
                txtPrimer2linea.Text = dt(0)("INFO1_MENSAJE2").ToString()
                txtPrimer3linea.Text = dt(0)("INFO1_MENSAJE3").ToString()
                txtPrimer4linea.Text = dt(0)("INFO1_MENSAJE4").ToString()
                txtPrimer5linea.Text = dt(0)("INFO1_MENSAJE5").ToString()

                txtSegunda1linea.Text = dt(0)("INFO2_MENSAJE1").ToString()
                txtSegunda2linea.Text = dt(0)("INFO2_MENSAJE2").ToString()
                txtSegunda3linea.Text = dt(0)("INFO2_MENSAJE3").ToString()
                txtSegunda4linea.Text = dt(0)("INFO2_MENSAJE4").ToString()
                txtSegunda5linea.Text = dt(0)("INFO2_MENSAJE5").ToString()

                txtTercer1linea.Text = dt(0)("INFO3_MENSAJE1").ToString()
                txtTercer2linea.Text = dt(0)("INFO3_MENSAJE2").ToString()
                txtTercer3linea.Text = dt(0)("INFO3_MENSAJE3").ToString()
                txtTercer4linea.Text = dt(0)("INFO3_MENSAJE4").ToString()
                txtTercer5linea.Text = dt(0)("INFO3_MENSAJE5").ToString()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Try
            Response.Redirect("lista_mensajes.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            Dim lID As Integer = 0
            lID = Request.Item("ID").Trim

            Dim objMensajes As New Mensajes
            objMensajes.Update_Mensaje(lID, "", txtprimer1Linea.Text, txtPrimer2linea.Text, txtPrimer3linea.Text, txtPrimer4linea.Text, txtPrimer5linea.Text, _
                                       txtSegunda1linea.Text, txtSegunda2linea.Text, txtSegunda3linea.Text, txtSegunda4linea.Text, txtSegunda5linea.Text, _
                                       txtTercer1linea.Text, txtTercer2linea.Text, txtTercer3linea.Text, txtTercer4linea.Text, txtTercer5linea.Text)

            Response.Redirect("lista_mensajes.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
