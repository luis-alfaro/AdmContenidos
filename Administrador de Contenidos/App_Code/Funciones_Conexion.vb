Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Funciones_Conexion
    Dim cn As New SqlConnection
    Dim tsql As SqlClient.SqlTransaction
    Dim transaccion As Boolean
    Public Function Get_CadenaConexion() As String
        Dim sCadena As String = ""
        Try
            sCadena = "Data Source=" & ReadAppConfig("IPSERVER") & ";Initial Catalog=" & ReadAppConfig("BD") & ";User ID=" & ReadAppConfig("USER") & ";PASSWORD=" & ReadAppConfig("PASSWORD")
        Catch ex As Exception
            Get_CadenaConexion = ""
        End Try
        Get_CadenaConexion = sCadena

    End Function


    Public Sub abrirconexion()
        cn.ConnectionString = (Get_CadenaConexion())
        cn.Open()
        transaccion = False
    End Sub

    Public Sub cerrarconexion()
        transaccion = False
        cn.Close()
        cn.Dispose()
    End Sub

    Public Sub abrirconexiontrans()
        cn.ConnectionString = (Get_CadenaConexion())
        cn.Open()
        tsql = cn.BeginTransaction()
        transaccion = True
    End Sub

    Public Sub cancelarconexiontrans()
        transaccion = False
        If transaccion = True Then
            tsql.Rollback()
        End If
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Sub cerrarconexiontrans()
        transaccion = False
        tsql.Commit()
        cn.Close()
    End Sub

    Public Function consultar(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As DataSet
        Dim cmd_consulta As New SqlCommand
        Dim adap_consulta As New SqlDataAdapter
        Dim dts_consulta As New DataSet
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        adap_consulta.SelectCommand = cmd_consulta
        adap_consulta.Fill(dts_consulta, "Consulta")
        consultar = dts_consulta
        cmd_consulta = Nothing
    End Function

    Public Function ejecutar(ByVal procedimiento As String, _
                             ByVal devuelve_valor As Boolean, _
                             ByRef rpta As Integer, _
                             ByRef mensaje As String, _
                             ByVal ParamArray x() As Object) As Object
        'Try
        Dim cmd_consulta As New SqlCommand
        Dim dts_consulta As New DataSet
        Dim i As Integer = 0
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.Connection = cn
        cmd_consulta.CommandText = procedimiento
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim prpta As New SqlParameter
        Dim pmensaje As New SqlParameter
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        cmd_consulta.ExecuteNonQuery()
        For Each y In cmd_consulta.Parameters
            Select Case y.ParameterName
                Case "@rpta"
                    rpta = y.Value
                Case "@mensaje"
                    mensaje = y.Value
            End Select
        Next
        If devuelve_valor = True Then
            ejecutar = cmd_consulta.Parameters(cmd_consulta.Parameters.Count - 1).Value
        Else
            ejecutar = 1
        End If
        'Return 0
        'Catch ex As Exception
        '   throw
        'End Try
    End Function
    Public Function Procedimiento(ByVal SQL As String) As Integer
        Dim r As Integer
        Dim sc As New SqlCommand
        cn.ConnectionString = Get_CadenaConexion()
        cn.Open()
        Try
            sc = New SqlCommand(SQL, cn)
            sc.CommandType = CommandType.Text
            r = sc.ExecuteNonQuery()
            cn.Close()
            Return r
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            Return -1
        End Try
    End Function
    Public Function Listado(ByVal NombreProc As String, ByVal ParamArray xParam() As Object) As DataTable
        'Dim i As Integer
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim sc As New SqlCommand
        cn.ConnectionString = Get_CadenaConexion()
        cn.Open()
        dt.Clear()
        sc = New System.Data.SqlClient.SqlCommand(NombreProc, cn)
        sc.CommandType = CommandType.Text
        'SqlCommandBuilder.DeriveParameters(sc)
        Try
            'If Not xParam Is Nothing Then
            '    With sc
            '        For i = 0 To xParam.Length - 1
            '            Try
            '                CType(.Parameters(i + 1), System.Data.SqlClient.SqlParameter).Value = xParam(i)
            '            Catch ex As Exception
            '                Throw (ex)
            '            End Try
            '        Next
            '    End With
            'End If
            da = New SqlDataAdapter(sc)
            da.Fill(dt)
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            Listado = Nothing
        End Try
    End Function


#Region "Mantenedor_Simuladores"

    Public Function consultarReprogramaciones(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_Reprogramacion)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_Reprogramacion)
        Dim sim As New Simulador_Reprogramacion
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_Reprogramacion()
                sim.IDDREP = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDREP"))
                sim.IDPREP = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPREP"))
                sim.TIPO_TARJETA = read_consulta.GetInt32(read_consulta.GetOrdinal("TIPO_TARJETA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")) Then
                    sim.PRODUCTO = ""
                Else
                    sim.PRODUCTO = read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO"))
                End If
                'sim.PRODUCTO = IIf(read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")), "", read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO")))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.ENVIO_EECC = read_consulta.GetDecimal(read_consulta.GetOrdinal("ENVIO_EECC"))
                sim.SEG_DESG = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_DESG"))
                sim.TEM = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEM"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MEMBRECIA = read_consulta.GetDecimal(read_consulta.GetOrdinal("MEMBRECIA"))
                sim.COM_ATM = read_consulta.GetDecimal(read_consulta.GetOrdinal("COM_ATM"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultarReprogramaciones = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardarReprogramaciones(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_Reprogramacion)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        Dim fechahora As DateTime = DateTime.Now
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_Reprogramacion In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDREP", a.IDDREP)
                cmd.Parameters.AddWithValue("@IDPREP", a.IDPREP)
                cmd.Parameters.AddWithValue("@TIPO_TARJETA", a.TIPO_TARJETA)
                cmd.Parameters.AddWithValue("@PRODUCTO", a.PRODUCTO)
                cmd.Parameters.AddWithValue("@FECHA_HORA", fechahora)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@ENVIO_EECC", a.ENVIO_EECC)
                cmd.Parameters.AddWithValue("@SEG_DESG", a.SEG_DESG)
                cmd.Parameters.AddWithValue("@TEM", a.TEM)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MEMBRECIA", a.MEMBRECIA)
                cmd.Parameters.AddWithValue("@COM_ATM", a.COM_ATM)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_Diferido(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_Diferido)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_Diferido)
        Dim sim As New Simulador_Diferido
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_Diferido()
                sim.IDDDIF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDDIF"))
                sim.IDPDIF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPDIF"))
                sim.TIPO_TARJETA = read_consulta.GetInt32(read_consulta.GetOrdinal("TIPO_TARJETA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")) Then
                    sim.PRODUCTO = ""
                Else
                    sim.PRODUCTO = read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO"))
                End If
                'sim.PRODUCTO = IIf(read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")), "", read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO")))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.ENVIO_EECC = read_consulta.GetDecimal(read_consulta.GetOrdinal("ENVIO_EECC"))
                sim.SEG_DESG = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_DESG"))
                sim.TEM = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEM"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MEMBRECIA = read_consulta.GetDecimal(read_consulta.GetOrdinal("MEMBRECIA"))
                sim.COM_ATM = read_consulta.GetDecimal(read_consulta.GetOrdinal("COM_ATM"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_Diferido = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_Diferido(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_Diferido)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        Dim fechahora As DateTime = DateTime.Now
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_Diferido In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDDIF", a.IDDDIF)
                cmd.Parameters.AddWithValue("@IDPDIF", a.IDPDIF)
                cmd.Parameters.AddWithValue("@TIPO_TARJETA", a.TIPO_TARJETA)
                cmd.Parameters.AddWithValue("@PRODUCTO", a.PRODUCTO)
                cmd.Parameters.AddWithValue("@FECHA_HORA", fechahora)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@ENVIO_EECC", a.ENVIO_EECC)
                cmd.Parameters.AddWithValue("@SEG_DESG", a.SEG_DESG)
                cmd.Parameters.AddWithValue("@TEM", a.TEM)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MEMBRECIA", a.MEMBRECIA)
                cmd.Parameters.AddWithValue("@COM_ATM", a.COM_ATM)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_SuperEfectivo(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_SuperEfectivo)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_SuperEfectivo)
        Dim sim As New Simulador_SuperEfectivo
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_SuperEfectivo()
                sim.IDDSEF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDSEF"))
                sim.IDPSEF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPSEF"))
                sim.TIPO_TARJETA = read_consulta.GetInt32(read_consulta.GetOrdinal("TIPO_TARJETA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")) Then
                    sim.PRODUCTO = ""
                Else
                    sim.PRODUCTO = read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO"))
                End If
                'sim.PRODUCTO = IIf(read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")), "", read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO")))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.ENVIO_EECC = read_consulta.GetDecimal(read_consulta.GetOrdinal("ENVIO_EECC"))
                sim.SEG_DESG = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_DESG"))
                sim.SEG_PROT = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_PROT"))
                sim.TEM = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEM"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_SuperEfectivo = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_SuperEfectivo(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_SuperEfectivo)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        Dim fechahora As DateTime = DateTime.Now
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_SuperEfectivo In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDSEF", a.IDDSEF)
                cmd.Parameters.AddWithValue("@IDPSEF", a.IDPSEF)
                cmd.Parameters.AddWithValue("@TIPO_TARJETA", a.TIPO_TARJETA)
                cmd.Parameters.AddWithValue("@PRODUCTO", a.PRODUCTO)
                cmd.Parameters.AddWithValue("@FECHA_HORA", fechahora)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@ENVIO_EECC", a.ENVIO_EECC)
                cmd.Parameters.AddWithValue("@SEG_DESG", a.SEG_DESG)
                cmd.Parameters.AddWithValue("@SEG_PROT", a.SEG_PROT)
                cmd.Parameters.AddWithValue("@TEM", a.TEM)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_Compras(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_Compras)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_Compras)
        Dim sim As New Simulador_Compras
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_Compras()
                sim.IDDCOM = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDCOM"))
                sim.IDPCOM = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPCOM"))
                sim.TIPO_TARJETA = read_consulta.GetInt32(read_consulta.GetOrdinal("TIPO_TARJETA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")) Then
                    sim.PRODUCTO = ""
                Else
                    sim.PRODUCTO = read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO"))
                End If
                'sim.PRODUCTO = IIf(read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")), "", read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO")))
                sim.REVOLVENTE = read_consulta.GetBoolean(read_consulta.GetOrdinal("REVOLVENTE"))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.ENVIO_EECC = read_consulta.GetDecimal(read_consulta.GetOrdinal("ENVIO_EECC"))
                sim.SEG_DESG = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_DESG"))
                sim.TEM = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEM"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MEMBRECIA = read_consulta.GetDecimal(read_consulta.GetOrdinal("MEMBRECIA"))
                sim.COM_ATM = read_consulta.GetDecimal(read_consulta.GetOrdinal("COM_ATM"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_Compras = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_Compras(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_Compras)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        Dim fechahora As DateTime = DateTime.Now
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_Compras In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDCOM", a.IDDCOM)
                cmd.Parameters.AddWithValue("@IDPCOM", a.IDPCOM)
                cmd.Parameters.AddWithValue("@TIPO_TARJETA", a.TIPO_TARJETA)
                cmd.Parameters.AddWithValue("@PRODUCTO", a.PRODUCTO)
                cmd.Parameters.AddWithValue("@FECHA_HORA", fechahora)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@ENVIO_EECC", a.ENVIO_EECC)
                cmd.Parameters.AddWithValue("@SEG_DESG", a.SEG_DESG)
                cmd.Parameters.AddWithValue("@TEM", a.TEM)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MEMBRECIA", a.MEMBRECIA)
                cmd.Parameters.AddWithValue("@COM_ATM", a.COM_ATM)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_EfectivoExpress(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_EfectivoExpress)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_EfectivoExpress)
        Dim sim As New Simulador_EfectivoExpress
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_EfectivoExpress()
                sim.IDDEFE = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDEFE"))
                sim.IDPEFE = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPEFE"))
                sim.TIPO_TARJETA = read_consulta.GetInt32(read_consulta.GetOrdinal("TIPO_TARJETA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")) Then
                    sim.PRODUCTO = ""
                Else
                    sim.PRODUCTO = read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO"))
                End If
                'sim.PRODUCTO = IIf(read_consulta.IsDBNull(read_consulta.GetOrdinal("PRODUCTO")), "", read_consulta.GetString(read_consulta.GetOrdinal("PRODUCTO")))
                sim.REVOLVENTE = read_consulta.GetBoolean(read_consulta.GetOrdinal("REVOLVENTE"))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.ENVIO_EECC = read_consulta.GetDecimal(read_consulta.GetOrdinal("ENVIO_EECC"))
                sim.SEG_DESG = read_consulta.GetDecimal(read_consulta.GetOrdinal("SEG_DESG"))
                sim.TEM = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEM"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MEMBRECIA = read_consulta.GetDecimal(read_consulta.GetOrdinal("MEMBRECIA"))
                sim.COM_ATM = read_consulta.GetDecimal(read_consulta.GetOrdinal("COM_ATM"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_EfectivoExpress = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_EfectivoExpress(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_EfectivoExpress)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        Dim fechahora As DateTime = DateTime.Now
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_EfectivoExpress In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDEFE", a.IDDEFE)
                cmd.Parameters.AddWithValue("@IDPEFE", a.IDPEFE)
                cmd.Parameters.AddWithValue("@TIPO_TARJETA", a.TIPO_TARJETA)
                cmd.Parameters.AddWithValue("@PRODUCTO", a.PRODUCTO)
                cmd.Parameters.AddWithValue("@FECHA_HORA", fechahora)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@ENVIO_EECC", a.ENVIO_EECC)
                cmd.Parameters.AddWithValue("@SEG_DESG", a.SEG_DESG)
                cmd.Parameters.AddWithValue("@TEM", a.TEM)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MEMBRECIA", a.MEMBRECIA)
                cmd.Parameters.AddWithValue("@COM_ATM", a.COM_ATM)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_PrestamoEfectivo(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_PrestamoEfectivo)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_PrestamoEfectivo)
        Dim sim As New Simulador_PrestamoEfectivo
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_PrestamoEfectivo()
                sim.IDPEF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDPEF"))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_PrestamoEfectivo = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_PrestamoEfectivo(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_PrestamoEfectivo)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_PrestamoEfectivo In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDPEF", a.IDPEF)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_ConsolidacionDeDeuda(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_ConsolidacionDeDeuda)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_ConsolidacionDeDeuda)
        Dim sim As New Simulador_ConsolidacionDeDeuda
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_ConsolidacionDeDeuda()
                sim.IDCDD = read_consulta.GetInt32(read_consulta.GetOrdinal("IDCDD"))
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_ConsolidacionDeDeuda = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_ConsolidacionDeDeuda(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_ConsolidacionDeDeuda)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_ConsolidacionDeDeuda In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDCDD", a.IDCDD)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

    Public Function consultar_SIM_DepositoPlazo(ByVal procedimiento As String, _
                              ByVal ParamArray x() As Object) As List(Of Simulador_DepositoPlazo)
        Dim cmd_consulta As New SqlCommand
        Dim lista As New List(Of Simulador_DepositoPlazo)
        Dim sim As New Simulador_DepositoPlazo
        cmd_consulta.CommandType = CommandType.StoredProcedure
        cmd_consulta.CommandText = LTrim(RTrim(procedimiento))
        cmd_consulta.Connection = cn
        If transaccion = True Then
            cmd_consulta.Transaction = tsql
        End If
        Dim y As SqlParameter
        SqlCommandBuilder.DeriveParameters(cmd_consulta)
        Dim i As Integer = 0
        For Each y In cmd_consulta.Parameters
            If y.ParameterName <> "@RETURN_VALUE" Then
                y.Value = x(i)
                i = i + 1
            End If
        Next
        Dim read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
        If read_consulta.HasRows Then
            While read_consulta.Read
                sim = New Simulador_DepositoPlazo()
                sim.IDDPF = read_consulta.GetInt32(read_consulta.GetOrdinal("IDDPF"))
                sim.MONEDA = read_consulta.GetString(read_consulta.GetOrdinal("MONEDA"))
                If read_consulta.IsDBNull(read_consulta.GetOrdinal("DESCRIPCION")) Then
                    sim.DESCRIPCION = ""
                Else
                    sim.DESCRIPCION = read_consulta.GetString(read_consulta.GetOrdinal("DESCRIPCION"))
                End If
                sim.PLAZO_MIN = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MIN"))
                sim.PLAZO_MAX = read_consulta.GetInt32(read_consulta.GetOrdinal("PLAZO_MAX"))
                sim.TEA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA"))
                sim.TREA = read_consulta.GetDecimal(read_consulta.GetOrdinal("TREA"))
                sim.TEA2 = read_consulta.GetDecimal(read_consulta.GetOrdinal("TEA2"))
                sim.TREA2 = read_consulta.GetDecimal(read_consulta.GetOrdinal("TREA2"))
                sim.COMISION = read_consulta.GetDecimal(read_consulta.GetOrdinal("COMISION"))
                sim.MONTO_LIM = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_LIM"))
                sim.MONTO_MIN = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MIN"))
                sim.MONTO_MAX = read_consulta.GetDecimal(read_consulta.GetOrdinal("MONTO_MAX"))
                lista.Add(sim)
            End While
        End If
        consultar_SIM_DepositoPlazo = lista
        read_consulta.Close()
        cmd_consulta = Nothing
    End Function

    Public Function guardar_SIM_DepositoPlazo(ByVal procedimiento As String, _
                              ByVal lista As List(Of Simulador_DepositoPlazo)) As Integer
        Dim resultado As Integer = 0
        Dim trans As SqlTransaction
        Dim cmd As New SqlCommand
        trans = cn.BeginTransaction()
        Try
            For Each a As Simulador_DepositoPlazo In lista
                cmd = New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = LTrim(RTrim(procedimiento))
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.Parameters.AddWithValue("@IDDPF", a.IDDPF)
                'cmd.Parameters.AddWithValue("@MONEDA", a.MONEDA)
                cmd.Parameters.AddWithValue("@DESCRIPCION", a.DESCRIPCION)
                cmd.Parameters.AddWithValue("@PLAZO_MIN", a.PLAZO_MIN)
                cmd.Parameters.AddWithValue("@PLAZO_MAX", a.PLAZO_MAX)
                cmd.Parameters.AddWithValue("@TEA", a.TEA)
                cmd.Parameters.AddWithValue("@TREA", a.TREA)
                cmd.Parameters.AddWithValue("@TEA2", a.TEA2)
                cmd.Parameters.AddWithValue("@TREA2", a.TREA2)
                cmd.Parameters.AddWithValue("@COMISION", a.COMISION)
                cmd.Parameters.AddWithValue("@MONTO_LIM", a.MONTO_LIM)
                cmd.Parameters.AddWithValue("@MONTO_MIN", a.MONTO_MIN)
                cmd.Parameters.AddWithValue("@MONTO_MAX", a.MONTO_MAX)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next
            trans.Commit()
            resultado = 1
        Catch ex As Exception
            trans.Rollback()
            resultado = 0
        End Try
        trans.Dispose()
        cmd.Dispose()
        Return resultado
    End Function

#End Region
End Class
