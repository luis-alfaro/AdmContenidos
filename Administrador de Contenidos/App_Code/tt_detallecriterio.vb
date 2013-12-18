Imports Microsoft.VisualBasic
Imports System.Data
Public Class tt_detallecriterio
    Dim cn As New Funciones_Conexion
    Public Function listarareacod() As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_tt_detalle_criterios")
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function agregartt_criterio(ByVal tipo As String, ByVal ubicacion As String, _
                                  ByVal area As String, ByVal tienda As String, _
                                  ByRef rpta As String, _
                                  ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.SP_GRABAR_tt_detalle_criterios", True, rpta, mensaje, _
                        tipo, ubicacion, area, tienda, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
End Class
