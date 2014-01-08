Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_MantSimConsolidacionDeDeuda
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

    <WebMethod()>
    Public Shared Function Obtener_SIM_ConsolidacionDeDeuda() As List(Of Simulador_ConsolidacionDeDeuda)
        Dim lista As New List(Of Simulador_ConsolidacionDeDeuda)
        Dim sim As New Simulador_ConsolidacionDeDeuda()
        Dim menus As New ClsReportes
        lista = menus.sp_get_Obtener_SIM_ConsolidacionDeDeuda()
        Return lista
    End Function

    <WebMethod()>
    Public Shared Function Guardar_SIM_ConsolidacionDeDeuda(ByVal lista As List(Of Simulador_ConsolidacionDeDeuda)) As Integer
        Dim nro As New Integer
        Dim sim As New Simulador_ConsolidacionDeDeuda()
        Dim menus As New ClsReportes
        nro = menus.sp_get_Guardar_SIM_ConsolidacionDeDeuda(lista)
        Return nro
    End Function
End Class
