Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_LogDeActualizacionRipleyMatico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
               
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    <WebMethod()> _
    Public Shared Function ObtenerLog(ByVal desde As String, ByVal hasta As String, ByVal filtro As String) As List(Of LogRipleyMatico)
        Dim lista As New List(Of LogRipleyMatico)
        Dim menus As New ClsReportes

        lista = menus.sp_get_Obtener_Log_RipleyMatico("F", desde, hasta, filtro)
        Return lista
    End Function
End Class
