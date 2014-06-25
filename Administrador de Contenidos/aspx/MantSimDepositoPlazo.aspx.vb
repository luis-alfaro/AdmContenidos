Imports System.Data
Imports System.Collections.Generic
Imports System.Web.Services


Partial Class aspx_MantSimDepositoPlazo
    Inherits System.Web.UI.Page
    Public Shared session_id As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                session_id = Session("SESSION_ID")
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
        nro = menus.sp_get_Guardar_SIM_DepositoPlazo(lista, GetNombreUsuario(), GetIp())
        Return nro
    End Function

    Public Shared Function GetNombreUsuario() As String
        Dim usern As String = "Anónimo"
        If Not (session_id Is Nothing) Then
            Dim dtConfig As New DataTable
            Dim sMensajeError As String = ""
            dtConfig = fun_devolverDatosConfiguracion(session_id.ToString.Trim, sMensajeError) 'el Session.SessionID cambia de numero al que se guardo revisar.

            If dtConfig.Rows.Count <= 0 Then 'Su session ha expirado
                usern = "Anónimo"
            Else
                usern = Cryptor(dtConfig.Rows(0).Item("LOGUEADO")).ToUpper()
            End If
        End If
        Return usern
    End Function

    Public Shared Function GetIp() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIpAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIpAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIpAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function
End Class
