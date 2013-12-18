Imports Microsoft.VisualBasic
Imports System.Data
Public Class ClsReportes
    Dim cn As New Funciones_Conexion

    Public Function MENSAJEGRID() As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.LISTAR_MENSJEGRID")
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function listartabla(ByVal tipo As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_tablas", tipo)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function listar_menus(ByVal tipo As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_menus", tipo)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function agregarrpt(ByVal cod As Integer, _
                                      ByRef rpta As Integer, _
                                      ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_rpt", True, rpta, mensaje, _
                        cod, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function sp_contar_consultas(ByVal tipo As String, _
                                        ByVal tipoReporte As Integer, _
                                        ByVal Orden As Integer, _
                                        ByVal suc As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        'Dim d1, d2, d4, d3 As String
        'd1 = "" : d2 = ""
        'Dim a, b, c, d As Integer
        'a = Day(f1)
        'b = Day(f2)
        'c = Month(f1)
        'd = Month(f2)
        'If a < 10 Then
        '    d1 = "0" & Day(f1)
        'Else
        '    d1 = a
        'End If

        'If b < 10 Then
        '    d2 = "0" & Day(f2)
        'Else
        '    d2 = b
        'End If

        'If c < 10 Then
        '    d3 = "0" & Month(f1)
        'Else
        '    d3 = c
        'End If

        'If d < 10 Then
        '    d4 = "0" & Month(f2)
        'Else
        '    d4 = d
        'End If

        'f1 = d1 & "-" & d3 & "-" & Year(f1)
        'f2 = d2 & "-" & d4 & "-" & Year(f2)
        dts = cn.consultar("dbo.SP_Reporte_Cabeza_Detalle", tipo, tipoReporte, Orden, suc, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function agregardetallereporte(ByVal tipo As Integer, ByVal idkio As String, _
                                      ByVal kio As String, ByRef rpta As Integer, _
                                      ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_rptreportedetalle", True, rpta, mensaje, _
                        tipo, idkio, kio, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function sp_get_incrementoPorRypleymatico(ByVal tipo As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_IncrementoLineaPorRipleymatico", tipo, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function
End Class
