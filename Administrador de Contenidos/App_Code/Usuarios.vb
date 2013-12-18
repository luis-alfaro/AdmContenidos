Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Usuarios


    Public Function Delete_Usuario(ByVal IdUser As Integer) As Boolean

        Dim cn As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Delete_User", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@USERID", IdUser)


        cn.Open()
        cmd.ExecuteNonQuery()

        cn.Close()


        Return True

    End Function



    Public Function Get_usuarios() As DataTable

        Dim cn As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_Users", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure



        Dim dt As New DataTable
        da.Fill(dt)

        Return dt

    End Function

End Class
