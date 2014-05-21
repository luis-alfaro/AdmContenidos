Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_LogDeAceptacionSEF
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
    Public Shared Function GetLogAceptacionSEF(ByVal desde As String, ByVal hasta As String, ByVal dni As String) As List(Of LogAceptacionSEF)
        Dim lista As New List(Of LogAceptacionSEF)
        Dim menus As New ClsReportes
        Dim fdesde As DateTime : Dim fhasta As DateTime

        fdesde = New Date(desde.Substring(6, 4), desde.Substring(3, 2), desde.Substring(0, 2))
        fhasta = New Date(hasta.Substring(6, 4), hasta.Substring(3, 2), hasta.Substring(0, 2))

        lista = menus.usp_get_Obtener_Log_AceptacionSEF(fdesde, fhasta, dni)
        Return lista
    End Function
End Class
