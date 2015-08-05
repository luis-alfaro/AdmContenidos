Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.OracleClient

Public Class DataAccess
    Inherits Singleton(Of DataAccess)
    Private mCadenaConexion_ORA As String = "User ID=" & ReadAppConfig("USER_NAME_ORA") & ";Data Source=" + ReadAppConfig("SERVICE_NAME_ORA") & ";Password=" & ReadAppConfig("PASSWORD_ORA")
    'Private mCadenaConexion_ORASEF As String = "User ID=" & ReadAppConfig("USER_NAME_ORA_SEF") & ";Data Source=" + ReadAppConfig("SERVICE_NAME_ORA_SEF") & ";Password=" & ReadAppConfig("PASSWORD_ORA_SEF")


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
        Try
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

        Catch ex As Exception
            Dim rutaLog As String = ReadAppConfig("RutaLogErrores").ToString()
            Dim sw As IO.StreamWriter = New IO.StreamWriter(rutaLog, True)
            sw.WriteLine("Error al insertar Log" + ex.Message)
            sw.Close()

        End Try
        Return True
    End Function

#End Region

    Public Function GET_ESTADISTICA_ACEPTACION_SEFx(ByVal fini As String, ByVal ffin As String) As List(Of AceptacionOferta)
        Dim lista As List(Of AceptacionOferta) = New List(Of AceptacionOferta)
        Dim ack As AceptacionOferta = New AceptacionOferta()
        For index = 1 To 85
            ack = New AceptacionOferta()
            ack.O_ESTADO = "D"
            ack.O_TIP_IMP_TCK = "C"
            ack.O_MES = "Octubre"
            If index Mod 4 = 0 Then
                ack.O_FEC_CLIE_FIN = "02/10/2013"
            Else
                If index Mod 4 = 1 Then
                    ack.O_FEC_CLIE_FIN = "08/10/2014"
                Else
                    If index Mod 4 = 2 Then
                        ack.O_FEC_CLIE_FIN = "05/10/2012"
                    Else
                        ack.O_FEC_CLIE_FIN = "05/11/2012"
                        ack.O_MES = "Noviembre"
                    End If

                End If

            End If
            lista.Add(ack)
        Next
        For index = 1 To 100
            ack = New AceptacionOferta()
            ack.O_ESTADO = "A"
            ack.O_TIP_IMP_TCK = "C"
            ack.O_MES = "Octubre"
            If index Mod 4 = 0 Then
                ack.O_FEC_CLIE_FIN = "02/10/2013"
            Else
                If index Mod 4 = 1 Then
                    ack.O_FEC_CLIE_FIN = "08/10/2014"
                Else
                    If index Mod 4 = 2 Then
                        ack.O_FEC_CLIE_FIN = "05/10/2012"
                    Else
                        ack.O_FEC_CLIE_FIN = "05/11/2012"
                        ack.O_MES = "Noviembre"
                    End If

                End If

            End If
            lista.Add(ack)
        Next
        For index = 1 To 145
            ack = New AceptacionOferta()
            ack.O_ESTADO = "D"
            ack.O_TIP_IMP_TCK = "R"
            ack.O_MES = "Octubre"
            If index Mod 4 = 0 Then
                ack.O_FEC_CLIE_FIN = "02/10/2013"
            Else
                If index Mod 4 = 1 Then
                    ack.O_FEC_CLIE_FIN = "08/10/2014"
                Else
                    If index Mod 4 = 2 Then
                        ack.O_FEC_CLIE_FIN = "05/10/2012"
                    Else
                        ack.O_FEC_CLIE_FIN = "05/11/2012"
                        ack.O_MES = "Noviembre"
                    End If

                End If

            End If
            lista.Add(ack)
        Next
        For index = 1 To 68
            ack = New AceptacionOferta()
            ack.O_ESTADO = "A"
            ack.O_TIP_IMP_TCK = "R"
            ack.O_MES = "Octubre"
            If index Mod 4 = 0 Then
                ack.O_FEC_CLIE_FIN = "02/10/2013"
            Else
                If index Mod 4 = 1 Then
                    ack.O_FEC_CLIE_FIN = "08/10/2014"
                Else
                    If index Mod 4 = 2 Then
                        ack.O_FEC_CLIE_FIN = "05/10/2012"
                    Else
                        ack.O_FEC_CLIE_FIN = "05/11/2012"
                        ack.O_MES = "Noviembre"
                    End If

                End If

            End If
            lista.Add(ack)
        Next

        Return lista
    End Function
    Public Function GET_ESTADISTICA_ACEPTACION_SEF(ByVal fini As String, ByVal ffin As String) As List(Of AceptacionOferta)

        Dim conConexion_Ora As OracleConnection
        Dim ds As DataSet = New DataSet
        Dim lista As List(Of AceptacionOferta) = New List(Of AceptacionOferta)
        Try
            conConexion_Ora = New OracleConnection(mCadenaConexion_ORA)

            If Not conConexion_Ora Is Nothing Then
                conConexion_Ora.Open()

                If conConexion_Ora.State = ConnectionState.Open Then

                    'LLAMAR AL PROCEDIMIENTO PRESTAMO EN EFECTIVO
                    Using cmd_ora As New OracleCommand

                        Dim param1 As New OracleParameter
                        Dim param2 As New OracleParameter
                        Dim param_cur As New OracleParameter

                        cmd_ora.Connection = conConexion_Ora
                        cmd_ora.CommandText = "PKG_OFERTAS_PRODUCTOS.PRC_CONS_ACEPTACION_OFERTA_SEF"
                        cmd_ora.CommandType = CommandType.StoredProcedure

                        param1.ParameterName = "I_FEC_INI_CONS"
                        param1.OracleType = OracleType.VarChar
                        param1.Direction = ParameterDirection.Input
                        'Dim vFecHoy1 As Date
                        'Dim sFechaParam1 As String = ""
                        'vFecHoy1 = Date.Now.AddMonths(-5)
                        'sFechaParam1 = Right(Trim("0000" & Year(vFecHoy1).ToString), 4) & "" & Right(Trim("00" & Month(vFecHoy1).ToString), 2) & "" & Right(Trim("00" & Day(vFecHoy1).ToString), 2)
                        param1.Value = fini
                        cmd_ora.Parameters.Add(param1)

                        param2.ParameterName = "I_FEC_FIN_CONS"
                        param2.OracleType = OracleType.VarChar
                        param2.Direction = ParameterDirection.Input
                        'Dim vFecHoy As Date
                        'Dim sFechaParam As String = ""
                        'vFecHoy = Date.Now
                        'sFechaParam = Right(Trim("0000" & Year(vFecHoy).ToString), 4) & "" & Right(Trim("00" & Month(vFecHoy).ToString), 2) & "" & Right(Trim("00" & Day(vFecHoy).ToString), 2)
                        param2.Value = ffin
                        cmd_ora.Parameters.Add(param2)

                        param_cur.ParameterName = "OUT_CURSOR"
                        param_cur.OracleType = OracleType.Cursor
                        param_cur.Direction = ParameterDirection.Output
                        param_cur.Value = vbNull

                        cmd_ora.Parameters.Add(param_cur)

                        lista = New List(Of AceptacionOferta)
                        Dim ack As AceptacionOferta = New AceptacionOferta()

                        Using rd_cur As OracleDataReader = cmd_ora.ExecuteReader
                            Do While rd_cur.Read
                                ack = New AceptacionOferta()
                                ack.O_FEC_CLIE_FIN = IIf(IsDBNull(rd_cur.Item("FEC_CLIE_FIN")), "", rd_cur.Item("FEC_CLIE_FIN").ToString)
                                ack.O_MES = IIf(IsDBNull(rd_cur.Item("MES")), "", rd_cur.Item("MES").ToString)
                                ack.O_TIP_IMP_TCK = IIf(IsDBNull(rd_cur.Item("TIP_IMP_TCK")), "", rd_cur.Item("TIP_IMP_TCK").ToString)
                                ack.O_ESTADO = IIf(IsDBNull(rd_cur.Item("ESTADO")), "", rd_cur.Item("ESTADO").ToString)
                                ack.O_DATO_NUM2 = IIf(IsDBNull(rd_cur.Item("DATO_NUM2")), 0, rd_cur.Item("DATO_NUM2"))
                                ack.O_DATO_NUM6 = IIf(IsDBNull(rd_cur.Item("DATO_NUM6")), 0, rd_cur.Item("DATO_NUM6"))

                                lista.Add(ack)
                            Loop
                        End Using

                    End Using
                    conConexion_Ora.Close()
                    conConexion_Ora = Nothing
                End If
            Else
                'sResultado_ORA = "ERROR:No se pudo conectar al servidor de base de datos Oracle."
            End If
        Catch ex As Exception
            'sResultado_ORA = "ERROR:" & ex.Message.Trim
        End Try
        Return lista
    End Function

    Public Function PRUEBA_CONEXION_ORA() As String
        Dim conConexion_Ora As OracleConnection
        Dim sResultado_ORA As String
        Try
            conConexion_Ora = New OracleConnection(mCadenaConexion_ORA)

            If Not conConexion_Ora Is Nothing Then
                conConexion_Ora.Open()

                If conConexion_Ora.State = ConnectionState.Open Then conConexion_Ora.Close()

                conConexion_Ora.Close()
                conConexion_Ora = Nothing
                sResultado_ORA = "OK"

            Else

                sResultado_ORA = "ERROR:No se pudo conectar al servidor de base de datos Oracle."

            End If


        Catch err As Exception
            sResultado_ORA = "ERROR:No se pudo conectar al servidor de base de datos."

        End Try


        Return sResultado_ORA


    End Function
End Class
Public Class AceptacionOferta

    Private _o_existe As Integer
    Public Property O_EXISTE() As Integer
        Get
            Return _o_existe
        End Get
        Set(ByVal value As Integer)
            _o_existe = value
        End Set
    End Property

    Private _o_mes As String
    Public Property O_MES() As String
        Get
            Return _o_mes
        End Get
        Set(ByVal value As String)
            _o_mes = value
        End Set
    End Property

    Private _o_fec_clie_fin As String
    Public Property O_FEC_CLIE_FIN() As String
        Get
            Return _o_fec_clie_fin
        End Get
        Set(ByVal value As String)
            _o_fec_clie_fin = value
        End Set
    End Property


    Private _o_year As Integer
    Public ReadOnly Property O_YEAR() As Integer
        Get
            Dim fecha As DateTime = DateTime.Parse(O_FEC_CLIE_FIN)
            _o_year = fecha.Year
            Return _o_year
        End Get
    End Property

    Private _o_month As Integer
    Public ReadOnly Property O_MONTH() As Integer
        Get
            Dim fecha As DateTime = DateTime.Parse(O_FEC_CLIE_FIN)
            _o_month = fecha.Month
            Return _o_month
        End Get
    End Property

    Private _o_tip_imp_tck As String
    Public Property O_TIP_IMP_TCK() As String
        Get
            Return _o_tip_imp_tck
        End Get
        Set(ByVal value As String)
            _o_tip_imp_tck = value
        End Set
    End Property


    Private _o_estado As String
    Public Property O_ESTADO() As String
        Get
            Return _o_estado
        End Get
        Set(ByVal value As String)
            _o_estado = value
        End Set
    End Property


    Private _o_dato_num2 As Decimal
    Public Property O_DATO_NUM2() As Decimal
        Get
            Return _o_dato_num2
        End Get
        Set(ByVal value As Decimal)
            _o_dato_num2 = value
        End Set
    End Property

    Private _o_dato_num6 As Decimal
    Public Property O_DATO_NUM6() As Decimal
        Get
            Return _o_dato_num6
        End Get
        Set(ByVal value As Decimal)
            _o_dato_num6 = value
        End Set
    End Property


End Class