Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class criterios
    Dim cn As New Funciones_Conexion
    Public Function agregarcriterio(ByVal cod As Integer, ByVal nombre As String, ByVal tipo As String, _
                                    ByRef rpta As Integer, _
                                     ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabarcriterios", True, rpta, mensaje, _
                        cod, nombre, tipo, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function agregardetallecriterio(ByVal tipo As Integer, ByVal criterio As Integer, ByVal tienda As String, _
                                    ByVal area As Integer, ByVal est As Integer, ByRef rpta As Integer, _
                                     ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_detalle_criterio", True, rpta, mensaje, _
                        tipo, criterio, tienda, area, est, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function lsitarcriterios(ByVal tipo As String, _
                                    ByVal p1 As String, ByVal p2 As String, _
                                    ByVal p3 As String, ByVal p4 As String, _
                                    ByVal est As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_criterios", tipo, p1, p2, p3, p4)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function actualizarestados(ByVal codigo As Integer, ByVal est As Integer, ByRef rpta As Integer, _
                                     ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.actualizar_estado_detalle_criterios", True, rpta, mensaje, _
                        codigo, est, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function

    Public Function DeshabilitarCriterios(ByVal idCriterio As String, ByVal nuevoEstado As Boolean) As Boolean
        Dim cn As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Update_EstadoCriterio", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@idcriterio", idCriterio)
        cmd.Parameters.AddWithValue("@estado", nuevoEstado)

        cn.Open()
        Dim i As Integer = cmd.ExecuteNonQuery()
        cn.Close()
        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


End Class
