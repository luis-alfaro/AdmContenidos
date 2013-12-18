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

End Class
