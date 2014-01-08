﻿Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_MantSimReprogramaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                Dim menus As New ClsReportes
                Dim tarjetas As New DataSet
                tarjetas = menus.listar_TipoTarjetas()
                Me.ddlTarjeta.DataSource = tarjetas.Tables(0).DefaultView.ToTable()
                Me.ddlTarjeta.DataTextField = "NOMBRE_TARJETA"
                Me.ddlTarjeta.DataValueField = "TIPO_TARJETA"
                Me.ddlTarjeta.DataBind()
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
    Public Shared Function ObtenerReprogramaciones(ByVal idTarjeta As Integer) As List(Of Simulador_Reprogramacion)
        Dim lista As New List(Of Simulador_Reprogramacion)
        Dim sim As New Simulador_Reprogramacion()
        Dim menus As New ClsReportes
        lista = menus.sp_get_Obtener_SIM_Reprogramaciones(idTarjeta)
        Return lista
    End Function

    <WebMethod()>
    Public Shared Function GuardarReprogramaciones(ByVal lista As List(Of Simulador_Reprogramacion)) As Integer
        Dim nro As New Integer
        Dim sim As New Simulador_Reprogramacion()
        Dim menus As New ClsReportes
        nro = menus.sp_get_Guardar_SIM_Reprogramaciones(lista)
        Return nro
    End Function
End Class
