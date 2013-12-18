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
                        ByRef rpta As Integer, ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_kioskos", True, rpta, mensaje, _
                        idkio, tipo, tienda, nombre, piso, ip, area, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
End Class
