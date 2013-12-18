Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Mensajes

    Public Function Get_Mensajes() As DataTable
        Dim cn As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_Mensajes", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    '
    Public Function Get_MensajesByID(ByVal ID As Integer) As DataTable
        Dim cn As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_MensajesByID", cn)

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@ID", ID)
        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Update_Mensaje(ByVal ID As Integer, ByVal DESC_TARJETA As String, ByVal INFO1_MENSAJE1 As String, ByVal INFO1_MENSAJE2 As String, ByVal INFO1_MENSAJE3 As String, ByVal INFO1_MENSAJE4 As String, ByVal INFO1_MENSAJE5 As String, _
                                 ByVal INFO2_MENSAJE1 As String, ByVal INFO2_MENSAJE2 As String, ByVal INFO2_MENSAJE3 As String, ByVal INFO2_MENSAJE4 As String, ByVal INFO2_MENSAJE5 As String, _
                                 ByVal INFO3_MENSAJE1 As String, ByVal INFO3_MENSAJE2 As String, ByVal INFO3_MENSAJE3 As String, ByVal INFO3_MENSAJE4 As String, ByVal INFO3_MENSAJE5 As String) As Boolean

        Dim cn As New SqlConnection(Get_CadenaConexion())
        '
        Dim cmd As New SqlCommand("Usp_Update_MensajeByID", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ID", ID)
        cmd.Parameters.AddWithValue("@DESC_TARJETA", DESC_TARJETA)
        cmd.Parameters.AddWithValue("@INFO1_MENSAJE1", INFO1_MENSAJE1.Trim())
        cmd.Parameters.AddWithValue("@INFO1_MENSAJE2", INFO1_MENSAJE2.Trim())
        cmd.Parameters.AddWithValue("@INFO1_MENSAJE3", INFO1_MENSAJE3.Trim())
        cmd.Parameters.AddWithValue("@INFO1_MENSAJE4", INFO1_MENSAJE4.Trim())
        cmd.Parameters.AddWithValue("@INFO1_MENSAJE5", INFO1_MENSAJE5.Trim())
        cmd.Parameters.AddWithValue("@INFO2_MENSAJE1", INFO2_MENSAJE1.Trim())
        cmd.Parameters.AddWithValue("@INFO2_MENSAJE2", INFO2_MENSAJE2.Trim())
        cmd.Parameters.AddWithValue("@INFO2_MENSAJE3", INFO2_MENSAJE3.Trim())
        cmd.Parameters.AddWithValue("@INFO2_MENSAJE4", INFO2_MENSAJE4.Trim())
        cmd.Parameters.AddWithValue("@INFO2_MENSAJE5", INFO2_MENSAJE5.Trim())
        cmd.Parameters.AddWithValue("@INFO3_MENSAJE1", INFO3_MENSAJE1.Trim())
        cmd.Parameters.AddWithValue("@INFO3_MENSAJE2", INFO3_MENSAJE2.Trim())
        cmd.Parameters.AddWithValue("@INFO3_MENSAJE3", INFO3_MENSAJE3.Trim())
        cmd.Parameters.AddWithValue("@INFO3_MENSAJE4", INFO3_MENSAJE4.Trim())
        cmd.Parameters.AddWithValue("@INFO3_MENSAJE5", INFO3_MENSAJE5.Trim())

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
