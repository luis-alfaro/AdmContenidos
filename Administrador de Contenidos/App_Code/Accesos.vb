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
                                   ByVal Mensajes As Boolean, ByVal Tiempos As Boolean, ByVal Estadisticas As Boolean, _
                                   ByVal ConfiguracionKiosko As Boolean, ByVal Errores As Boolean, ByVal ConsultaAceptacionIncremento As Boolean, _
                                   ByVal ActualizacionRipleymatico As Boolean, _
                                   ByVal SIM_DPF As Boolean, ByVal SIM_Reprogramaciones As Boolean, _
                                   ByVal SIM_Diferido As Boolean, ByVal SIM_SEF As Boolean, _
                                   ByVal SIM_Compras As Boolean, ByVal SIM_EFEX As Boolean, _
                                   ByVal SIM_PEF As Boolean, ByVal SIM_CDD As Boolean) As Boolean
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
        cmd.Parameters.AddWithValue("@Estadisticas", Estadisticas)
        cmd.Parameters.AddWithValue("@ConfiguracionKiosko", ConfiguracionKiosko)
        cmd.Parameters.AddWithValue("@Errores", Errores)
        cmd.Parameters.AddWithValue("@ConsultaAceptacionIncremento", ConsultaAceptacionIncremento)
        cmd.Parameters.AddWithValue("@ActualizacionRipleymatico", ActualizacionRipleymatico)

        cmd.Parameters.AddWithValue("@SIM_DPF", SIM_DPF)
        cmd.Parameters.AddWithValue("@SIM_Reprogramaciones", SIM_Reprogramaciones)
        cmd.Parameters.AddWithValue("@SIM_Diferido", SIM_Diferido)
        cmd.Parameters.AddWithValue("@SIM_SEF", SIM_SEF)
        cmd.Parameters.AddWithValue("@SIM_Compras", SIM_Compras)
        cmd.Parameters.AddWithValue("@SIM_EFEX", SIM_EFEX)
        cmd.Parameters.AddWithValue("@SIM_PEF", SIM_PEF)
        cmd.Parameters.AddWithValue("@SIM_CDD", SIM_CDD)


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


    Public Function GetAccessByRoleID(ByVal IdRole As Integer) As List(Of AppAccess)
        Dim entidad As AppAccess
        Dim lista As List(Of AppAccess) = New List(Of AppAccess)
        Using cn = New SqlConnection(Get_CadenaConexion())
            cn.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandText = "Usp_GetAccessByRoleID"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@RoleID", IdRole)

            Using dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read
                        entidad = New AppAccess
                        entidad.AccessID = IIf(dr.IsDBNull(dr.GetOrdinal("AccessID")), 0, dr.GetInt32(dr.GetOrdinal("AccessID")))
                        entidad.RoleID = IIf(dr.IsDBNull(dr.GetOrdinal("RoleID")), 0, dr.GetInt32(dr.GetOrdinal("RoleID")))
                        entidad.MenuID = IIf(dr.IsDBNull(dr.GetOrdinal("MenuID")), 0, dr.GetInt32(dr.GetOrdinal("MenuID")))
                        entidad.MenuNombre = IIf(dr.IsDBNull(dr.GetOrdinal("MenuNombre")), "", dr.GetString(dr.GetOrdinal("MenuNombre")))
                        entidad.Descripcion = IIf(dr.IsDBNull(dr.GetOrdinal("Descripcion")), "", dr.GetString(dr.GetOrdinal("Descripcion")))
                        entidad.Node = IIf(dr.IsDBNull(dr.GetOrdinal("Node")), 0, dr.GetInt32(dr.GetOrdinal("Node")))
                        entidad.ChildNode = IIf(dr.IsDBNull(dr.GetOrdinal("ChildNode")), 0, dr.GetInt32(dr.GetOrdinal("ChildNode")))
                        entidad.Estado = IIf(dr.IsDBNull(dr.GetOrdinal("Estado")), False, dr.GetBoolean(dr.GetOrdinal("Estado")))
                        lista.Add(entidad)
                    End While
                End If
            End Using
        End Using
        Return lista
    End Function

    Public Function GuardarAccess(ByVal lista As List(Of AppAccess)) As Integer
        Dim resultado As Integer
        Dim lst As List(Of AppAccess) = New List(Of AppAccess)
        For Each access As AppAccess In lista
            If access.Flag = "1" Then
                lst.Add(access)
            End If
        Next
        Try
            Using cn = New SqlConnection(Get_CadenaConexion())
                cn.Open()
                Dim cmd As SqlCommand
                For Each entidad As AppAccess In lst
                    cmd = New SqlCommand
                    cmd.Connection = cn
                    cmd.CommandText = "Usp_UpdateAccessByID"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@AccessID", entidad.AccessID)
                    cmd.Parameters.AddWithValue("@RoleID", entidad.RoleID)
                    cmd.Parameters.AddWithValue("@Estado", entidad.Estado)
                    cmd.ExecuteNonQuery()
                Next
            End Using
            resultado = 1
        Catch ex As Exception
            resultado = 0
        End Try

        Return resultado
    End Function

End Class
