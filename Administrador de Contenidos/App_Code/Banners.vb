Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Banners

    Dim SQLCon As SqlConnection


    Public Function Get_Banners(ByVal idcriterio As Integer) As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("USP_Get_BannersAdministrador", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@idcriterio", idcriterio)

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt
    End Function

    Public Function Update_BannerNuOrd(ByVal IDX As Integer, ByVal NuOrd As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Update_BannerNuOrd", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@IDX", IDX)
        cmd.Parameters.AddWithValue("@NuOrd", NuOrd)

        SQLCon.Open()
        If cmd.ExecuteNonQuery() > 0 Then
            SQLCon.Close()
            Return True
        Else
            SQLCon.Close()
            Return False
        End If


    End Function

    Public Function Delete_Banner(ByVal IDX As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Delete_Banner", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@IDX", IDX)


        SQLCon.Open()
        If cmd.ExecuteNonQuery() > 0 Then
            SQLCon.Close()
            Return True
        Else
            SQLCon.Close()
            Return False
        End If


    End Function

    Public Function Update_BannerValues(ByVal IDX As Integer, ByVal MensajeBanner As String, ByVal Color As String, ByVal idcriterio As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Update_BannerValues", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@IDX", IDX)
        cmd.Parameters.AddWithValue("@Banner", MensajeBanner)
        cmd.Parameters.AddWithValue("@Color", Color)
        cmd.Parameters.AddWithValue("@idcriterio", idcriterio)
        SQLCon.Open()
        If cmd.ExecuteNonQuery() > 0 Then
            SQLCon.Close()
            Return True
        Else
            SQLCon.Close()
            Return False
        End If

    End Function


    Public Function Insert_Banner(ByVal MensajeBanner As String, ByVal NuOrd As String, ByVal Color As String, ByVal idcriterio As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Set_Banner", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@BannerID", 1)
        cmd.Parameters.AddWithValue("@Banner", MensajeBanner)
        cmd.Parameters.AddWithValue("@NuOrd", NuOrd)
        cmd.Parameters.AddWithValue("@Color", Color)
        cmd.Parameters.AddWithValue("@idcriterio", idcriterio)

        SQLCon.Open()
        If cmd.ExecuteNonQuery() > 0 Then
            SQLCon.Close()
            Return True

        Else
            SQLCon.Close()
            Return False

        End If


    End Function


    Public Function Get_BannerByIDX(ByVal IDX As Integer) As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_BannerByIDX", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@IDX", IDX)

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt
    End Function




    Public Function Get_TotalFilas() As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_TotalFilasBanner", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt
    End Function

End Class
