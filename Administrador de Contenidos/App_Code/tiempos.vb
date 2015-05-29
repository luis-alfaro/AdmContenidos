Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class tiempos

    '
    Public Function Obtener_Tiempos() As DataTable
        Dim cn As New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Get_Tiempos", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Actualizar_Tiempos(ByVal TIEMPO_DOC As Integer, ByVal TIEMPO_OPCIONES As Integer, ByVal NRO_ERROR_TARJETA As Integer, ByVal TIEMPO_COMISIONES As Integer, ByVal TIEMPO_OFERTAS As Integer) As Boolean
        Dim cn As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Update_Tiempos", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@TIEMPO_DOC", TIEMPO_DOC)
        cmd.Parameters.AddWithValue("@TIEMPO_OPCIONES", TIEMPO_OPCIONES)
        cmd.Parameters.AddWithValue("@NRO_ERROR_TARJETA", NRO_ERROR_TARJETA)
        cmd.Parameters.AddWithValue("@TIEMPO_COMISIONES", TIEMPO_COMISIONES)
        cmd.Parameters.AddWithValue("@TIEMPO_OFERTAS", TIEMPO_OFERTAS)
        '@TIEMPO_COMISIONES
        cn.Open()
        Dim n As Integer = cmd.ExecuteNonQuery()
        cn.Close()

        If n > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
