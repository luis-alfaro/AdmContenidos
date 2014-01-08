Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Accesos

    Private cn As SqlConnection

    Public Function Get_AccesosByRoleID(ByVal IdRole As Integer) As DataTable
        cn = New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Get_AccessByRoleId", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@RoleID", IdRole)

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function


    Public Function Get_RolesFull() As DataTable
        cn = New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Get_RolesFull", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Get_Roles() As DataTable
        cn = New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Get_Roles", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Insert_Acceso(ByVal RoleID As Integer, ByVal Pane As Boolean, ByVal Svid As Boolean, ByVal Sban As Boolean, ByVal Usu As Boolean, ByVal Rol As Boolean, _
                                   ByVal Acc As Boolean, ByVal Ubigeo As Boolean, ByVal Tiendas As Boolean, ByVal Kioscos As Boolean, ByVal Areas As Boolean, _
                                   ByVal Criterios As Boolean, ByVal consultas As Boolean, ByVal reporte As Boolean, ByVal Actualizar As Boolean) As Boolean
        cn = New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Insert_Accesos", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@AccessID", RoleID)
        'cmd.Parameters.AddWithValue("@RoleID", RoleID)
        cmd.Parameters.AddWithValue("@Pane", Pane)
        cmd.Parameters.AddWithValue("@Svid", Svid)
        cmd.Parameters.AddWithValue("@Sban", Sban)
        cmd.Parameters.AddWithValue("@Usu", Usu)
        cmd.Parameters.AddWithValue("@Rol", Rol)
        cmd.Parameters.AddWithValue("@Acc", Acc)
        cmd.Parameters.AddWithValue("@Ubigeo", Ubigeo)
        cmd.Parameters.AddWithValue("@Tiendas", Tiendas)
        cmd.Parameters.AddWithValue("@Kioscos", Kioscos)
        cmd.Parameters.AddWithValue("@Areas", Areas)
        cmd.Parameters.AddWithValue("@Criterios", Criterios)
        cmd.Parameters.AddWithValue("@Consultas", consultas)
        cmd.Parameters.AddWithValue("@Reporte", reporte)
        cmd.Parameters.AddWithValue("@Actualizar", Actualizar)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Return True
    End Function



    Public Function Update_Accesos(ByVal AccesoID As Integer, ByVal Pane As Boolean, ByVal Svid As Boolean, ByVal Sban As Boolean, ByVal Usu As Boolean, ByVal Rol As Boolean, _
                                   ByVal Acc As Boolean, ByVal Ubigeo As Boolean, ByVal Tiendas As Boolean, ByVal Kioscos As Boolean, ByVal Areas As Boolean, _
                                   ByVal Criterios As Boolean, ByVal consultas As Boolean, ByVal reporte As Boolean, ByVal Actualizar As Boolean, ByVal Temporizador As Boolean, _
                                   ByVal Mensajes As Boolean, ByVal Tiempos As Boolean, ByVal Simuladores As Boolean, ByVal Estadisticas As Boolean, ByVal Errores As Boolean) As Boolean
        cn = New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Update_Accesos", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@AccessID", AccesoID)
        'cmd.Parameters.AddWithValue("@RoleID", )
        cmd.Parameters.AddWithValue("@Pane", Pane)
        cmd.Parameters.AddWithValue("@Svid", Svid)
        cmd.Parameters.AddWithValue("@Sban", Sban)
        cmd.Parameters.AddWithValue("@Usu", Usu)
        cmd.Parameters.AddWithValue("@Rol", Rol)
        cmd.Parameters.AddWithValue("@Acc", Acc)
        cmd.Parameters.AddWithValue("@Ubigeo", Ubigeo)
        cmd.Parameters.AddWithValue("@Tiendas", Tiendas)
        cmd.Parameters.AddWithValue("@Kioscos", Kioscos)
        cmd.Parameters.AddWithValue("@Areas", Areas)
        cmd.Parameters.AddWithValue("@Criterios", Criterios)
        cmd.Parameters.AddWithValue("@Consultas", consultas)
        cmd.Parameters.AddWithValue("@Reporte", reporte)
        cmd.Parameters.AddWithValue("@Actualizar", Actualizar)
        cmd.Parameters.AddWithValue("@Temporizador", Temporizador)
        cmd.Parameters.AddWithValue("@Mensajes", Mensajes)
        cmd.Parameters.AddWithValue("@Tiempos", Tiempos)
        'cmd.Parameters.AddWithValue("@Tarifas", Tarifas)
        cmd.Parameters.AddWithValue("@Simuladores", Simuladores)
        cmd.Parameters.AddWithValue("@Estadisticas", Estadisticas)
        cmd.Parameters.AddWithValue("@Errores", Errores)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


        Return True

    End Function


    Public Function Insert_Role(ByVal name As String, ByVal Description As String, ByVal Enabled As Boolean) As Integer
        cn = New SqlConnection(Get_CadenaConexion())
        Dim da As New SqlDataAdapter("Usp_Set_Role", cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.AddWithValue("@Name", name)
        da.SelectCommand.Parameters.AddWithValue("@Description", Description)
        da.SelectCommand.Parameters.AddWithValue("@Enabled", Enabled)

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt(0)(0)

    End Function


End Class
