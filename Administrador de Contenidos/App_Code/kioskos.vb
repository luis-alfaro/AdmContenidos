Imports Microsoft.VisualBasic
Imports System.Data
Public Class kioskos
    Dim cn As New Funciones_Conexion
    Public Function listarkioskos(ByVal tipo As String, _
                                  ByVal p1 As String, _
                                  ByVal p2 As String, _
                                  ByVal p3 As String, _
                                  ByVal p4 As String, _
                                  ByVal est As String) As DataSet
        Try
            Dim dts As DataSet
            cn.abrirconexion()
            dts = cn.consultar("sp_listar_kioskos", tipo, p1, p2, p3, p4, est)
            cn.cerrarconexion()
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function
    Public Function grabar(ByVal idkio As Integer, ByVal tipo As Integer, ByVal tienda As Integer, _
                           ByVal nombre As String, ByVal piso As Integer, _
                           ByVal ip As String, _
                           ByVal area As Integer, _
                           ByVal CONFIGURACION_ID As Integer, _
                           ByVal MAC As String, _
                        ByRef rpta As Integer, ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_kioskos", True, rpta, mensaje, _
                        idkio, tipo, tienda, nombre, piso, ip, area, CONFIGURACION_ID, MAC, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function

    Public Function listarConfiguracionKioskos() As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_listar_Kio_Configuraciones")
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function GetConfiguracionKioskoPorID(ByVal ID As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_Kio_ConfiguracionKioskoPorID", ID)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function grabarConfiguracionKiosko(ByVal ID As Integer, _
                           ByVal NOMBRE As String, _
                           ByVal SERVER As String, _
                           ByVal SERVER_SIMULADOR As String, _
                           ByVal SERVER_PRINT As String, _
                           ByVal SERVER_COM As String, _
                           ByVal BIN1 As String, _
                           ByVal LONGITUD_TARJETA_BIN1 As Integer, _
                           ByVal POSINI_BIN1 As Integer, _
                           ByVal LONGITUD_BIN_BIN1 As Integer, _
                           ByVal BIN2 As String, _
                           ByVal LONGITUD_TARJETA_BIN2 As Integer, _
                           ByVal POSINI_BIN2 As Integer, _
                           ByVal LONGITUD_BIN_BIN2 As Integer, _
                        ByRef rpta As Integer, ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.Usp_grabar_ConfiguracionKiosko", True, rpta, mensaje, _
                        ID, NOMBRE, SERVER, SERVER_SIMULADOR, SERVER_PRINT, SERVER_COM, _
                        BIN1, LONGITUD_TARJETA_BIN1, POSINI_BIN1, LONGITUD_BIN_BIN1, _
                        BIN2, LONGITUD_TARJETA_BIN2, POSINI_BIN2, LONGITUD_BIN_BIN2, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
End Class
