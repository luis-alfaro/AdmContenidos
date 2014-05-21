Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Module DataAccess
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

    Public Function Sql_Get_Semana(ByVal fecha As String) As String()

        Dim sMensajeError As String = String.Empty
        Dim SQLCon As SqlConnection
        SQLCon = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)


        Dim da As New SqlDataAdapter("Usp_Get_Semana", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add(New SqlParameter("@fechaParametro", SqlDbType.Char, 8)).Value = fecha

        Dim dt As New DataTable
        da.Fill(dt)

        Dim semana() As String = dt.Rows(0)(0).ToString().Split("/")


        Return semana
    End Function

    Public Function Sql_Get_programacion(ByVal fecha As String, ByVal idCriterio As Integer) As DataTable
        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_ProgramacionByFecha", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add(New SqlParameter("@fechaParametro", SqlDbType.Char, 8)).Value = fecha
        da.SelectCommand.Parameters.Add(New SqlParameter("@idcriterio", SqlDbType.BigInt)).Value = idCriterio

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Sql_Get_Horas(ByVal horaInicio As String, ByVal horaFinal As String) As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_HorasByRange", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add(New SqlParameter("@horaInicio", SqlDbType.Char, 5)).Value = horaInicio
        da.SelectCommand.Parameters.Add(New SqlParameter("@horaFinal", SqlDbType.Char, 5)).Value = horaFinal

        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Sql_InsertarNueva_Programacion(ByVal horario() As String, ByVal codigoProgramacion As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Delete_programacion", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add(New SqlParameter("@ran_id", SqlDbType.Int)).Value = codigoProgramacion
        SQLCon.Open()
        da.SelectCommand.Transaction = SQLCon.BeginTransaction()
        Try
            da.SelectCommand.ExecuteNonQuery()


            da.SelectCommand.CommandText = "Usp_Insert_horarioProgramacion"
            Dim i As Integer = 1
            For Each item As String In horario
                da.SelectCommand.Parameters.Clear()
                da.SelectCommand.Parameters.AddWithValue("@ran_id", codigoProgramacion)
                Dim fecha As String = item.Substring(0, 10)

                fecha = ConvertirFecha(Date.Parse(fecha))

                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha)
                Dim hora1 As String = item.Substring(11, 5)
                da.SelectCommand.Parameters.AddWithValue("@hora1", hora1)
                Dim hora2 As String = item.Substring(17, 5)
                da.SelectCommand.Parameters.AddWithValue("@hora2", hora2)

                da.SelectCommand.Parameters.AddWithValue("@estado", 1)
                da.SelectCommand.Parameters.AddWithValue("@ran_item", i)
                da.SelectCommand.ExecuteNonQuery()
                i = i + 1
            Next

            da.SelectCommand.Transaction.Commit()
            Return True
        Catch ex As Exception
            da.SelectCommand.Transaction.Rollback()

            Return False
        Finally
            SQLCon.Close()
        End Try

    End Function

    Public Function Sql_InsertarNuevaLista_Video(ByVal lista(,) As String, ByVal codigoProgramacion As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())


        Dim da As New SqlDataAdapter("Usp_Delete_ListaVideos", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add(New SqlParameter("@ran_item", SqlDbType.Int)).Value = codigoProgramacion
        SQLCon.Open()
        da.SelectCommand.Transaction = SQLCon.BeginTransaction()
        Try

            da.SelectCommand.ExecuteNonQuery()
            da.SelectCommand.CommandText = "Usp_Insert_ListaVideos"

            Dim totalFilas As Integer = (lista.Length / 2) - 1
            For i As Integer = 0 To totalFilas '(lista.Length / 2) - 1
                da.SelectCommand.Parameters.Clear()
                da.SelectCommand.Parameters.AddWithValue("@ran_item", codigoProgramacion)
                da.SelectCommand.Parameters.AddWithValue("@posicion", i + 1)
                da.SelectCommand.Parameters.AddWithValue("@titulo", lista(0, i))
                da.SelectCommand.Parameters.AddWithValue("@direccion", lista(1, i))


                da.SelectCommand.ExecuteNonQuery()
                'i += i
            Next

            da.SelectCommand.Transaction.Commit()

            Return True
        Catch ex As Exception
            da.SelectCommand.Transaction.Rollback()
            Return False
        Finally
            SQLCon.Close()
        End Try


    End Function

    Public Function Sql_Insertar_listaRango(ByVal ran_id As String, _
                                          ByVal ran_desc As String, _
                                          ByVal ran_estado As String, _
                                          ByVal color As String, _
                                          ByVal idcriterio As Integer) As String

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Set_Rango_lista", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ran_id", 1)
        cmd.Parameters.AddWithValue("@ran_desc", ran_desc)
        cmd.Parameters.AddWithValue("@ran_estado", ran_estado)
        cmd.Parameters.AddWithValue("@color", color)
        cmd.Parameters.AddWithValue("@idcriterio", idcriterio)
        cmd.Parameters("@ran_id").Direction = ParameterDirection.Output
        SQLCon.Open()
        cmd.ExecuteNonQuery()
        Dim codNuevo As String = cmd.Parameters("@ran_id").Value.ToString()
        SQLCon.Close()
        Return codNuevo
    End Function

    Public Function Sql_Update_listaRango(ByVal ran_id As String, _
                                          ByVal ran_desc As String, _
                                          ByVal ran_estado As String, _
                                          ByVal color As String, _
                                          ByVal idcriterio As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim cmd As New SqlCommand("Usp_Update_Rango_lista", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ran_id", ran_id)
        cmd.Parameters.AddWithValue("@ran_desc", ran_desc)
        cmd.Parameters.AddWithValue("@ran_estado", ran_estado)
        cmd.Parameters.AddWithValue("@color", color)
        cmd.Parameters.AddWithValue("@idcriterio", idcriterio)

        SQLCon.Open()
        Dim count As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()
        If count > 0 Then
            Return True 'mas de un registro ok
        Else
            Return False 'no hubo ni un registro?
        End If

    End Function

    ''' <summary>
    ''' devuelve "True" si hay horarios y "false" si el horario esta disponible
    ''' </summary>
    ''' <param name="sDate"></param>
    ''' <param name="cbohIni"></param>
    ''' <param name="cbohFin"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fun_validar_Existe_programacion(ByVal sDate As Date, _
                                                    ByVal cbohIni As String, _
                                                    ByVal cbohFin As String, _
                                                    ByVal idCriterio As Integer) As Boolean
        Try

            Dim SQLCon As New SqlConnection(Get_CadenaConexion())

            Dim da As New SqlDataAdapter("Usp_validar_Existe_programacion", SQLCon)
            da.SelectCommand.Parameters.AddWithValue("@fecha", ConvertirFecha(sDate))
            da.SelectCommand.Parameters.AddWithValue("@horaIni", cbohIni)
            da.SelectCommand.Parameters.AddWithValue("@horaFin", cbohFin)
            da.SelectCommand.Parameters.AddWithValue("@idcriterio", idCriterio)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim dt As New DataTable
            da.Fill(dt)

            If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

        End Try

        Return True

    End Function

    Public Function Sql_obtener_ListaRango(ByVal ran_desc As String) As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_get_listaRango", SQLCon)
        da.SelectCommand.Parameters.AddWithValue("@ran_desc", ran_desc)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Sql_obtenerVideos_ListaRango(ByVal ran_item As String) As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_get_VideoslistaRango", SQLCon)
        da.SelectCommand.Parameters.AddWithValue("@ran_item", ran_item)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable
        da.Fill(dt)

        Return dt
    End Function

    Public Function Sql_Get_Criterios() As DataTable

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_Criterios", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt

    End Function

    Public Function Sql_Update_EstadoProgramacion(ByVal ran_id As Integer, ByVal ran_estado As Boolean) As Boolean
        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Set_EstadoProgramacion", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ran_id", ran_id)
        cmd.Parameters.AddWithValue("@ran_estado", ran_estado)

        SQLCon.Open()
        Dim filas As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()


        If filas > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function Sql_Get_KioscosIP() As DataTable
        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_ListaIPKioscos", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt

    End Function

    Public Function Sql_Detele_Ubigeo(ByVal UbigeoID As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_delete_Ubigeo", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@UbigeoId", UbigeoID)

        SQLCon.Open()
        Dim filas As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()


        If filas > 0 Then
            Return True
        Else
            Return False
        End If
    End Function



    '
    Public Function Sql_Detele_Kiosco(ByVal idkiosko As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Delete_kiosco", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@idkiosko", idkiosko)

        SQLCon.Open()
        Dim filas As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()

        If filas > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    'Usp_Get_TasasSimulador
    Public Function Sql_Get_TasasSimulador() As DataSet

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_TasasSimulador", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataSet

        da.Fill(dt)

        Return dt

    End Function


    Public Function Sql_Update_Tarifas(ByVal iddoc As Integer, ByVal moneda As String, ByVal trea As Decimal, ByVal trea2 As Decimal) As Boolean
        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Update_TasasSimulador", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@iddoc", iddoc)
        cmd.Parameters.AddWithValue("@moneda", moneda)
        cmd.Parameters.AddWithValue("@trea", trea)
        cmd.Parameters.AddWithValue("@trea2", trea2)

        SQLCon.Open()
        Dim filas As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()

        If filas > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Sql_Update_Reporte() As Boolean
        Try
            Dim SQLCon As New SqlConnection(Get_CadenaConexion())
            Dim cmd As New SqlCommand("Usp_actualizarReporte", SQLCon)
            cmd.CommandType = CommandType.StoredProcedure

            SQLCon.Open()
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Sql_Detele_ConfiguracionKiosco(ByVal ID As Integer) As Boolean

        Dim SQLCon As New SqlConnection(Get_CadenaConexion())
        Dim cmd As New SqlCommand("Usp_Delete_Configuracionkiosco", SQLCon)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ID", ID)

        SQLCon.Open()
        Dim filas As Integer = cmd.ExecuteNonQuery()
        SQLCon.Close()

        If filas > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Sql_Get_OpcionesMenu() As DataTable
        Dim SQLCon As New SqlConnection(Get_CadenaConexion())

        Dim da As New SqlDataAdapter("Usp_Get_OpcionesMenu", SQLCon)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim dt As New DataTable

        da.Fill(dt)

        Return dt

    End Function
End Module