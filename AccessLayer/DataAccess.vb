﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class DataAccess
    Inherits Singleton(Of DataAccess)

    Public Function SQL_ConnectionOpen(ByVal sCadenaConexion As String, ByRef msgError As String) As SqlClient.SqlConnection
        Dim cnnConnection As SqlClient.SqlConnection
        Try
            cnnConnection = New SqlClient.SqlConnection
            cnnConnection.ConnectionString = sCadenaConexion
            cnnConnection.Open()
        Catch ex As Exception
            msgError = "La conexión a la base de datos No fue satisfactoria, verificar (configuración del web.config)."
            cnnConnection = Nothing
            SQL_ConnectionOpen = Nothing
            Exit Function
        End Try

        Return cnnConnection
    End Function

    Public Sub SQL_ConnectionClose(ByRef ObjectConnection As SqlClient.SqlConnection)
        If ObjectConnection.State = ConnectionState.Open Then
            ObjectConnection.Close()
        End If
        ObjectConnection = Nothing
    End Sub

    Public Function SQL_ExecuteReader(ByVal SQLCon As SqlClient.SqlConnection, ByVal commandText As String) As SqlClient.SqlDataReader
        Dim cmdSQL As New SqlClient.SqlCommand
        Dim readerSQL As SqlClient.SqlDataReader

        cmdSQL.Connection = SQLCon
        cmdSQL.CommandText = commandText
        cmdSQL.CommandType = CommandType.Text

        readerSQL = cmdSQL.ExecuteReader

        'Eliminar Variables
        cmdSQL = Nothing

        Return readerSQL
    End Function

    Public Sub SQL_ExecuteDataTable(ByVal SQLCon As SqlClient.SqlConnection, ByVal commandtext As String, ByRef myDataTable As DataTable)
        Try
            Dim daSQL As New SqlClient.SqlDataAdapter

            daSQL.SelectCommand = New SqlClient.SqlCommand(commandtext, SQLCon)
            daSQL.Fill(myDataTable)
            daSQL = Nothing
        Catch ex As Exception
            'save error
        End Try

    End Sub


    Public Sub SQL_ExecuteDataset(ByVal SQLCon As SqlClient.SqlConnection, ByVal cmdSQL As SqlClient.SqlCommand, _
    ByVal sNameProcedure As String, ByVal sNameMyData As String, ByRef myData As DataSet)

        cmdSQL.Connection = SQLCon
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = sNameProcedure

        'Llenado del dataset
        Dim daSQL As New SqlClient.SqlDataAdapter(cmdSQL)
        'Llenar dataset
        daSQL.Fill(myData, sNameMyData)

        'Eliminar
        daSQL = Nothing

    End Sub

    Public Function SQL_ExecuteNonQuery(ByVal SQLCon As SqlClient.SqlConnection, ByVal commandText As String) As Long
        Dim cmdSQL As New SqlClient.SqlCommand
        Dim myTrans As SqlClient.SqlTransaction
        Dim lAfectados As Long

        Try
            myTrans = SQLCon.BeginTransaction(IsolationLevel.ReadCommitted)
            cmdSQL.Transaction = myTrans
            cmdSQL.Connection = SQLCon
            cmdSQL.CommandText = commandText
            cmdSQL.CommandType = CommandType.Text

            lAfectados = cmdSQL.ExecuteNonQuery
            myTrans.Commit()
        Catch ex As Exception
            myTrans = Nothing
        Finally
            'Eliminar Variables
            cmdSQL = Nothing
            myTrans = Nothing
        End Try

        Return lAfectados
    End Function

    Public Function ReadAppConfig(ByVal llave As String) As String
        Dim reader As New AppSettingsReader()
        Return reader.GetValue(llave, Type.GetType("System.String")).ToString
    End Function

    Public Function Get_CadenaConexion() As String

        Dim sCadena As String = ""
        Try
            sCadena = "Data Source=" & ReadAppConfig("IPSERVER") & ";Initial Catalog=" & ReadAppConfig("BD") & ";User ID=" & ReadAppConfig("USER") & ";PASSWORD=" & ReadAppConfig("PASSWORD")
            'sCadena = "Data Source=FSIAPP24\SQLEXPRESS;Initial Catalog=kiosconet ;Uid = sa; pwd=Ripley2012"
        Catch ex As Exception
            Get_CadenaConexion = ""
        End Try
        Get_CadenaConexion = sCadena

    End Function

    Public Function ConvertirFecha(ByVal fecha As DateTime) As String
        Dim nuevaFecha, dia, mes, year As String
        dia = fecha.Day.ToString()
        mes = fecha.Month.ToString()
        year = fecha.Year.ToString()

        If dia.Length < 2 Then
            dia = "0" + dia
        End If

        If mes.Length < 2 Then
            mes = "0" + mes
        End If
        nuevaFecha = year + mes + dia
        Return nuevaFecha
    End Function

    Private cn As SqlConnection
#Region "Log "
    Public Function Get_LogRipleymatico(ByVal Identificador As String, ByVal tipo As String) As List(Of String)
        Using cn = New SqlConnection(Get_CadenaConexion())
            Dim lista As New List(Of String)
            Dim texto As String
            Using cmd_consulta As New SqlCommand
                cn.Open()
                cmd_consulta.CommandType = CommandType.StoredProcedure
                cmd_consulta.CommandText = LTrim(RTrim("Usp_Get_LogRipleymatico"))
                cmd_consulta.Connection = cn
                cmd_consulta.Parameters.AddWithValue("@IDENTIFICADOR", Identificador)
                cmd_consulta.Parameters.AddWithValue("@TIPO", tipo)
                Using read_consulta As SqlDataReader = cmd_consulta.ExecuteReader()
                    If read_consulta.HasRows Then
                        While read_consulta.Read
                            texto = read_consulta.GetString(read_consulta.GetOrdinal("DESCRIPCION"))
                            lista.Add(texto)
                        End While
                    End If
                    Get_LogRipleymatico = lista
                End Using
            End Using
        End Using
    End Function

    Public Function Insert_LogRipleymatico(ByVal Identificador As String, ByVal Descripcion As String, ByVal tipo As String) As Boolean
        Using cn = New SqlConnection(Get_CadenaConexion())
            Using cmd As New SqlCommand("Usp_Insert_LogRipleymatico", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@IDENTIFICADOR", Identificador)
                cmd.Parameters.AddWithValue("@DESCRIPCION", Descripcion)
                cmd.Parameters.AddWithValue("@TIPO", tipo)

                cn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
        Return True
    End Function

#End Region
End Class