Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_MantSimDepositoPlazo
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
    Public Shared Function Obtener_SIM_DepositoPlazo() As List(Of Simulador_DepositoPlazo)
        Dim lista As New List(Of Simulador_DepositoPlazo)
        Dim sim As New Simulador_DepositoPlazo()
        Dim menus As New ClsReportes
        lista = menus.sp_get_Obtener_SIM_DepositoPlazo()
        Return lista
    End Function

    <WebMethod()>
    Public Shared Function Guardar_SIM_DepositoPlazo(ByVal lista As List(Of Simulador_DepositoPlazo)) As Integer
        Dim nro As New Integer
        Dim sim As New Simulador_DepositoPlazo()
        Dim menus As New ClsReportes
        nro = menus.sp_get_Guardar_SIM_DepositoPlazo(lista)
        Return nro
    End Function
End Class
