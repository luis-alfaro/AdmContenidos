Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class tiendas
    Dim cn As New Funciones_Conexion
    Public Function grabar(ByVal direccion As String, ByVal idtienda As Integer, ByVal nombre As String, ByVal idubigeo As Integer, _
                           ByVal estado As String,
                           ByVal hora1ini As String,
                           ByVal hora1fin As String,
                           ByVal hora2ini As String,
                           ByVal hora2fin As String,
                           ByVal hini_cli As String,
                           ByVal hfin_cli As String,
                           ByVal tipo As String, _
                        ByRef rpta As Integer, ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_mantenimiento_tienda", True, rpta, mensaje, _
                        direccion, idtienda, nombre, idubigeo, estado, tipo, 0, hora1ini, hora1fin, hora2ini, hora2fin, hini_cli, hfin_cli, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function ListarTiendas(ByVal tipo As String, ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal p4 As String, ByVal est As String) As DataSet
        Try
            Dim dts As DataSet
            cn.abrirconexion()
            dts = cn.consultar("sp_listar_tiendas", tipo, p1, p2, p3, p4, est)
            cn.cerrarconexion()
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function
    Public Function grabareastienda(ByVal val As Integer, ByVal tipo As Integer, ByVal idtienda As Integer, _
                                    ByVal idarea As Integer, ByVal est As Integer, _
                        ByRef rpta As Integer, ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_areas_tienda", True, rpta, mensaje, _
                        val, tipo, idtienda, idarea, est, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function

    Public Function listarareastienda(ByVal tipo As String, ByVal p1 As String, _
                                      ByVal p2 As String, ByVal p3 As String, _
                                      ByVal p4 As String) As DataSet
        Try
            Dim dts As DataSet
            cn.abrirconexion()
            dts = cn.consultar("sp_listar_areas_tienda", tipo, p1, p2, p3, p4)
            cn.cerrarconexion()
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function

    ''' <summary>
    ''' ini-parte2-Ripleymatico
    ''' </summary>
    ''' <param name="idTienda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ObtenerTiendaByID(ByVal idTienda As String) As DataTable


        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Get_TiendaByID", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@id_Tienda", idTienda)

        Dim dt As New DataTable

        SQLCon.Open()
        da.Fill(dt)
        SQLCon.Close()

        Return dt
    End Function
    ''fin-parte2-Ripleymatico

End Class
