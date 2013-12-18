Imports System.Data
Imports System.Configuration
Imports DataAccess

Public Module Funciones
    Private cnnConnection As SqlClient.SqlConnection


    Public Function fun_devolverDatosConfiguracion(ByVal IDSESSION As String, ByRef merror As String) As DataTable

        Dim strSQL As String
        Dim oMyTabla As New DataTable

        Try
            cnnConnection = SQL_ConnectionOpen(Get_CadenaConexion(), merror)

            If merror <> "" Then
                fun_devolverDatosConfiguracion = Nothing
                Exit Function
            End If

            strSQL = "SELECT IDSESION,SERVER,IPSERVER,BD,USUARIO,PSW,CADENA,LOGUEADO FROM app_cadenas_con WHERE IDSESION='" & IDSESSION.Trim & "'"

            SQL_ExecuteDataTable(cnnConnection, strSQL, oMyTabla)

            'SQL_ConnectionClose(cnnConnection)

        Catch ex As Exception
            merror = "fun_devolverDatosConfiguracion:" & ex.Message.Trim
        End Try

        Return oMyTabla
    End Function



    Public Sub m_delete_configuracion_con(ByVal idsession As String, ByRef merror As String)
        Dim strSQL As String

        Try
            cnnConnection = SQL_ConnectionOpen(Get_CadenaConexion(), merror)

            If merror <> "" Then
                Exit Sub
            End If

            strSQL = "DELETE FROM app_cadenas_con WHERE IDSESION='" & idsession & "'"

            SQL_ExecuteNonQuery(cnnConnection, strSQL)

            SQL_ConnectionClose(cnnConnection)

        Catch ex As Exception
            merror = "m_delete_configuracion_con: " & ex.Message.Trim
        End Try

    End Sub

    Public Function Cryptor(ByVal Text As String) As String
        Dim strTempChar As String = "" 'Declaración de la variable
        Dim i As Single
        'Crea un ciclo para cada uno de los caracteres dentro de la cadena
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If
            Mid$(Text, i, 1) = Chr(strTempChar)
        Next i
        'Indica cual es la funcion de crypt

        Cryptor = Text
    End Function

    Public Function g_fun_format_fecha(ByVal dia As Long, ByVal mes As Long, ByVal anio As Long) As String
        Dim sDia As String
        Dim sMes As String
        Dim sAnio As String
        Dim sFechaFormateada As String

        sDia = dia
        sMes = mes
        sAnio = anio

        Select Case dia
            Case 1, 2, 3, 4, 5, 6, 7, 8, 9
                sDia = Trim("0" & Trim(Str(dia)))
        End Select

        Select Case mes
            Case 1, 2, 3, 4, 5, 6, 7, 8, 9
                sMes = Trim("0" & Trim(Str(mes)))
        End Select

        sFechaFormateada = Trim(sDia & "/" & sMes & "/" & sAnio)

        Return sFechaFormateada

    End Function

    Public Function g_fun_extrae_dia_mes(ByVal Fecha As String, ByVal sDiaMesFormato As String) As String
        Dim sDia As String
        Dim sMes As String
        Dim sAnio As String
        Dim sSalida As String
        sSalida = "0"
        Select Case sDiaMesFormato.ToUpper
            Case "DD"
                sDia = Left(Fecha.Trim, 2)
                sSalida = sDia
            Case "MM"
                sMes = Mid(Fecha.Trim, 4, 2)
                sSalida = sMes
            Case "YY"
                sAnio = Mid(Fecha.Trim, 7)
                sSalida = sAnio
        End Select

        Return sSalida
    End Function

    Public Function g_fun_formatearDDMMYYYY(ByVal Fecha As String) As String
        Dim sDia As String
        Dim sMes As String
        Dim sAnio As String
        Dim sFechaFormateada As String

        sDia = Left(Fecha.Trim, 2)
        sMes = Mid(Fecha.Trim, 4, 2)
        sAnio = Mid(Fecha.Trim, 7)

        'Unir fechas
        sFechaFormateada = sDia.Trim & "/" & sMes.Trim & "/" & sAnio.Trim

        Return sFechaFormateada

    End Function

    Public Function g_fun_formatearMMDDYYYY(ByVal Fecha As String) As String
        Dim sDia As String
        Dim sMes As String
        Dim sAnio As String
        Dim sFechaFormateada As String

        sDia = Left(Fecha.Trim, 2)
        sMes = Mid(Fecha.Trim, 4, 2)
        sAnio = Mid(Fecha.Trim, 7)

        'Unir fechas
        sFechaFormateada = sMes.Trim & "-" & sDia.Trim & "-" & sAnio.Trim

        Return sFechaFormateada

    End Function

    'Esta funcion valida si la fecha esta escrita correctamente  DD/MM/YYYY
    Public Function g_fun_validar_fecha(ByVal sFecha As String) As Boolean
        Dim sDia As String
        Dim sMes As String
        Dim sAnio As String
        Dim iDia As Long = 0
        Dim iMes As Long = 0
        Dim iAnio As Long = 0
        Dim lMaxDiaMes As Long

        Dim bValidado As Boolean

        'Validar Fechas
        bValidado = False
        If sFecha.Trim.Length = 10 Then
            bValidado = True
            'Extraer dia
            sDia = Left(sFecha.Trim, 2)
            'Extraer Mes
            sMes = Mid(sFecha.Trim, 4, 2)
            'Extraer Año
            sAnio = Mid(sFecha.Trim, 7)

            'Validar si no son numeros
            If Not IsNumeric(sDia.Trim) Then 'Validar Dia
                bValidado = False
            ElseIf Not IsNumeric(sMes.Trim) Then 'Validar Mes
                bValidado = False
            ElseIf Not IsNumeric(sAnio.Trim) Then 'Validar Año
                bValidado = False
            End If

            If bValidado = True Then
                'Validar que el mes tenga 12 numeros
                If (Convert.ToInt64(sMes.Trim) < 1) Or (Convert.ToInt64(sMes.Trim)) > 12 Then 'Validar Mes
                    bValidado = False
                End If

                'Validar que el año sea desde 1900 hacia adelante
                If (Convert.ToInt64(sAnio.Trim) < 1900) Then 'Validar Anio
                    bValidado = False
                End If

                If bValidado = True Then
                    'Maximo dia de un mes
                    lMaxDiaMes = g_fun_maximo_dia(Convert.ToInt64(sMes.Trim), Convert.ToInt64(sAnio.Trim))
                    'Evaluar si esta en el rango de los dias del mes ingresado
                    If (Convert.ToInt64(sDia.Trim) < 1) Or (Convert.ToInt64(sDia.Trim) > lMaxDiaMes) Then 'Validar Dia
                        bValidado = False
                    End If
                End If

            End If

        End If


        Return bValidado

    End Function

    'Obtener el maximo dia de un mes
    Public Function g_fun_maximo_dia(ByVal lMes As Long, ByVal lAnio As Long) As Long
        Dim lMaxDia As Long

        Select Case lMes
            Case 1 : lMaxDia = 31
            Case 2
                If lAnio Mod 4 = 0 Then
                    lMaxDia = 29
                Else
                    lMaxDia = 28
                End If
            Case 3 : lMaxDia = 31

            Case 4 : lMaxDia = 30

            Case 5 : lMaxDia = 31

            Case 6 : lMaxDia = 30

            Case 7 : lMaxDia = 31

            Case 8 : lMaxDia = 31

            Case 9 : lMaxDia = 30

            Case 10 : lMaxDia = 31

            Case 11 : lMaxDia = 30

            Case 12 : lMaxDia = 31

        End Select

        Return lMaxDia

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


End Module
