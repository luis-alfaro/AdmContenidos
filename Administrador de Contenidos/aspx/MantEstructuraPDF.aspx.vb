Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_MantEstructuraPDF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                Dim menus As New ClsReportes
                Dim tarjetas As New DataSet
                tarjetas = menus.listar_EstrucutraPDFs()
                Me.ddlPDFs.DataSource = tarjetas.Tables(0).DefaultView.ToTable()
                Me.ddlPDFs.DataTextField = "NOMBRE"
                Me.ddlPDFs.DataValueField = "ID"
                Me.ddlPDFs.DataBind()
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
    Public Shared Function Obtener_EstructuraPDF(ByVal idEstructura As Integer) As List(Of EstructuraPDF)
        Dim lista As New List(Of EstructuraPDF)
        Dim sim As New EstructuraPDF()
        Dim menus As New ClsReportes
        lista = menus.Usp_Get_Obtener_EstructuraPDF(idEstructura)
        Return lista
    End Function

    <WebMethod()>
    Public Shared Function Guardar_EstructuraPDF(ByVal lista As List(Of EstructuraPDF)) As Integer
        Dim nro As New Integer
        Dim sim As New EstructuraPDF()
        Dim menus As New ClsReportes
        nro = menus.Usp_Get_Guardar_EstructuraPDF(lista)
        Return nro
    End Function
End Class
