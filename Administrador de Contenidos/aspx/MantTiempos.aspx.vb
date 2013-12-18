Imports System.Data

Partial Class aspx_MantTiempos
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            If IsPostBack = False Then
                Dim objTiempo As New tiempos
                Dim dt As DataTable = objTiempo.Obtener_Tiempos()

                lblDescripcion.Text = dt.Rows(0)(0).ToString()
                txtTiempoDoc.Text = dt.Rows(0)(1).ToString()
                txtTiempoOpc.Text = dt.Rows(0)(2).ToString()
                txtNroErrorTarjeta.Text = dt.Rows(0)(3).ToString()
                txtTiempoComisiones.Text = dt.Rows(0)(4).ToString()


            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Dim i As Integer
            Dim flagNumero As Boolean

            flagNumero = Integer.TryParse(txtNroErrorTarjeta.Text, i)
            If flagNumero = False Then
                lblMsg.Visible = True
                Exit Sub
            End If

            flagNumero = Integer.TryParse(txtTiempoDoc.Text, i)
            If flagNumero = False Then
                lblMsg.Visible = True
                Exit Sub
            End If

            flagNumero = Integer.TryParse(txtTiempoOpc.Text, i)
            If flagNumero = False Then
                lblMsg.Visible = True
                Exit Sub
            End If

            Dim objTiempo As New tiempos
            objTiempo.Actualizar_Tiempos(txtTiempoDoc.Text, txtTiempoOpc.Text, txtNroErrorTarjeta.Text, txtTiempoComisiones.Text)
            Response.Redirect("Welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Response.Redirect("Welcome.aspx")
    End Sub
End Class
