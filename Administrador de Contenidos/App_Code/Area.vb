Imports Microsoft.VisualBasic
Imports System.Data
Public Class Area
    Dim cn As New Funciones_Conexion

    Public Function agregararea(ByVal nombre As String, ByVal estado As String, _
                                  ByVal idarea As Integer, ByVal tipo As String, _
                                  ByRef rpta As Integer, _
                                  ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_mantenimiento_area", True, rpta, mensaje, _
                        nombre, estado, idarea, tipo, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function listararea(ByVal tipo As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_area", tipo)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function listarareacod(ByVal param1 As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_area_cod", param1)
        cn.cerrarconexion()
        Return dts
    End Function
End Class
