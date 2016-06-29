Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Transactions

Public Class ClsReportes
    Dim cn As New Funciones_Conexion

    Public Function MENSAJEGRID() As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.LISTAR_MENSJEGRID")
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function listartabla(ByVal tipo As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_tablas", tipo)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function listar_menus(ByVal tipo As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listar_menus", tipo)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function agregarrpt(ByVal cod As Integer, _
                                      ByRef rpta As Integer, _
                                      ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_rpt", True, rpta, mensaje, _
                        cod, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function sp_contar_consultas(ByVal tipo As String, _
                                        ByVal tipoReporte As Integer, _
                                        ByVal Orden As Integer, _
                                        ByVal suc As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()        
        dts = cn.consultar("dbo.SP_Reporte_Cabeza_Detalle", tipo, tipoReporte, Orden, suc, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function sp_Reporte_Usuarios_Canal_Ripleymaticos(ByVal tipo As String, _
                                        ByVal tipoReporte As Integer, _
                                        ByVal Orden As Integer, _
                                        ByVal suc As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.SP_Reporte_Usuarios_Canal_Ripleymatico", tipo, tipoReporte, Orden, suc, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function sp_Reporte_Detalle_Usuarios_Canal_Ripleymaticos(ByVal f1 As DateTime, ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.SP_RPT_DETALLE_USUARIOS_RIPLEYMATICO", f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function agregardetallereporte(ByVal tipo As Integer, ByVal idkio As String, _
                                      ByVal kio As String, ByRef rpta As Integer, _
                                      ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_grabar_rptreportedetalle", True, rpta, mensaje, _
                        tipo, idkio, kio, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function sp_get_incrementoPorRypleymatico(ByVal tipo As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_IncrementoLineaPorRipleymatico", tipo, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function sp_get_ConsultaIncrementoPorRypleymatico(ByVal nro_DNI As String, ByVal nro_tarjeta As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaIncrementoPorRipleymatico", nro_DNI, nro_tarjeta, f1, f2)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function sp_get_ConsultaCambioProductoPorRypleymatico(ByVal nro_DNI As String, ByVal nro_tarjeta As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal tienda As Integer, _
                                        ByVal nro_contrato As String, _
                                        ByVal nroRegistros As Integer, _
                                        ByVal pagina As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaCambioProductoPorRipleymatico", nro_DNI, nro_tarjeta, f1, f2, tienda, nro_contrato, nroRegistros, pagina)
        cn.cerrarconexion()
        Return dts
    End Function

    Public Function sp_get_ConsultaLPDP(ByVal nro_DNI As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal tipo As Integer, _
                                        ByVal nroRegistros As Integer, _
                                        ByVal pagina As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaLPDP", nro_DNI, f1, f2, tipo, nroRegistros, pagina)
        cn.cerrarconexion()
        Return dts
    End Function


    Public Function sp_get_ConsultaAceptacionTC(ByVal tipo As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal canal As String, _
                                        ByVal nroRegistros As Integer, _
                                        ByVal pagina As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaAceptacionTC", tipo, f1, f2, nroRegistros, pagina)
        cn.cerrarconexion()
        Return dts
    End Function


    Public Function sp_get_ConsultaAceptacionIncremento(ByVal tipo As String, _
                                                        ByVal canal As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal nroRegistros As Integer, _
                                        ByVal pagina As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaAceptacionIncremento", tipo, canal, f1, f2, nroRegistros, pagina)
        cn.cerrarconexion()
        Return dts
    End Function

#Region "Mantenedor Simuladores"

    Public Function listar_TipoTarjetas() As DataSet
        Try
            Dim dts As New DataSet
            cn.abrirconexion()
            dts = cn.consultar("dbo.Usp_Get_TipoTarjetas")
            cn.cerrarconexion()
            Dim nrow As DataRow = dts.Tables(0).NewRow()

            nrow("TIPO_TARJETA") = "0"
            nrow("NOMBRE_TARJETA") = "--Seleccionar--"

            dts.Tables(0).Rows.Add(nrow)
            dts.Tables(0).DefaultView.Sort = "TIPO_TARJETA"
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function

    Public Function sp_get_Obtener_SIM_Compras(ByVal idTarjeta As Integer) As List(Of Simulador_Compras)
        Dim lista As New List(Of Simulador_Compras)
        cn.abrirconexion()
        lista = cn.consultar_SIM_Compras("dbo.Usp_Get_Obtener_SIM_Compras", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_Compras(ByVal lista As List(Of Simulador_Compras), ByVal user As String, ByVal ip As String) As Integer
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now

        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_Compras) = New List(Of Simulador_Compras)
                For Each sim As Simulador_Compras In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_Compras In lst
                    sim.FECHA_HORA = fecha
                    resultado = cn.guardar_SIM_Compras("dbo.Usp_Get_Guardar_SIM_Compras", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDCOM
                        log.Simulador = "KIO_SIM_DET_TAR_COMPRAS"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = sim.FECHA_HORA
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using

        cn.cerrarconexion()

        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_ConsolidacionDeDeuda() As List(Of Simulador_ConsolidacionDeDeuda)
        Dim lista As New List(Of Simulador_ConsolidacionDeDeuda)
        cn.abrirconexion()
        lista = cn.consultar_SIM_ConsolidacionDeDeuda("dbo.Usp_Get_Obtener_SIM_ConsolidacionDeDeuda")
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_ConsolidacionDeDeuda(ByVal lista As List(Of Simulador_ConsolidacionDeDeuda), ByVal user As String, ByVal ip As String) As Integer
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now

        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_ConsolidacionDeDeuda) = New List(Of Simulador_ConsolidacionDeDeuda)
                For Each sim As Simulador_ConsolidacionDeDeuda In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_ConsolidacionDeDeuda In lst
                    resultado = cn.guardar_SIM_ConsolidacionDeDeuda("dbo.Usp_Get_Guardar_SIM_ConsolidacionDeDeuda", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDCDD
                        log.Simulador = "KIO_SIM_DET_CDD"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = fecha
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()
        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_DepositoPlazo() As List(Of Simulador_DepositoPlazo)
        Dim lista As New List(Of Simulador_DepositoPlazo)
        cn.abrirconexion()
        lista = cn.consultar_SIM_DepositoPlazo("dbo.Usp_Get_Obtener_SIM_DepositoPlazo")
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_DepositoPlazo(ByVal lista As List(Of Simulador_DepositoPlazo), ByVal user As String, ByVal ip As String) As Integer
        'resultado = cn.guardar_SIM_DepositoPlazo("dbo.Usp_Get_Guardar_SIM_DepositoPlazo", lista)
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_DepositoPlazo) = New List(Of Simulador_DepositoPlazo)
                For Each sim As Simulador_DepositoPlazo In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_DepositoPlazo In lst
                    resultado = cn.guardar_SIM_DepositoPlazo("dbo.Usp_Get_Guardar_SIM_DepositoPlazo", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDPF
                        log.Simulador = "KIO_SIM_DET_DPF"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = fecha
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()
        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_Diferido(ByVal idTarjeta As Integer) As List(Of Simulador_Diferido)
        Dim lista As New List(Of Simulador_Diferido)
        cn.abrirconexion()
        lista = cn.consultar_SIM_Diferido("dbo.Usp_Get_Obtener_SIM_Diferido", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_Diferido(ByVal lista As List(Of Simulador_Diferido), ByVal user As String, ByVal ip As String) As Integer
        'resultado = cn.guardar_SIM_Diferido("dbo.Usp_Get_Guardar_SIM_Diferido", lista)
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_Diferido) = New List(Of Simulador_Diferido)
                For Each sim As Simulador_Diferido In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_Diferido In lst
                    sim.FECHA_HORA = fecha
                    resultado = cn.guardar_SIM_Diferido("dbo.Usp_Get_Guardar_SIM_Diferido", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDDIF
                        log.Simulador = "KIO_SIM_DET_TAR_DIFERIDO"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = sim.FECHA_HORA
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()

        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_EfectivoExpress(ByVal idTarjeta As Integer) As List(Of Simulador_EfectivoExpress)
        Dim lista As New List(Of Simulador_EfectivoExpress)
        cn.abrirconexion()
        lista = cn.consultar_SIM_EfectivoExpress("dbo.Usp_Get_Obtener_SIM_EfectivoExpress", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_EfectivoExpress(ByVal lista As List(Of Simulador_EfectivoExpress), ByVal user As String, ByVal ip As String) As Integer
        'resultado = cn.guardar_SIM_EfectivoExpress("dbo.Usp_Get_Guardar_SIM_EfectivoExpress", lista)
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_EfectivoExpress) = New List(Of Simulador_EfectivoExpress)
                For Each sim As Simulador_EfectivoExpress In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_EfectivoExpress In lst
                    sim.FECHA_HORA = fecha
                    resultado = cn.guardar_SIM_EfectivoExpress("dbo.Usp_Get_Guardar_SIM_EfectivoExpress", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDEFE
                        log.Simulador = "KIO_SIM_DET_TAR_EFEX"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = sim.FECHA_HORA
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()

        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_PrestamoEfectivo() As List(Of Simulador_PrestamoEfectivo)
        Dim lista As New List(Of Simulador_PrestamoEfectivo)
        cn.abrirconexion()
        lista = cn.consultar_SIM_PrestamoEfectivo("dbo.Usp_Get_Obtener_SIM_PrestamoEfectivo")
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_PrestamoEfectivo(ByVal lista As List(Of Simulador_PrestamoEfectivo), ByVal user As String, ByVal ip As String) As Integer
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_PrestamoEfectivo) = New List(Of Simulador_PrestamoEfectivo)
                For Each sim As Simulador_PrestamoEfectivo In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_PrestamoEfectivo In lst
                    resultado = cn.guardar_SIM_PrestamoEfectivo("dbo.Usp_Get_Guardar_SIM_PrestamoEfectivo", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDPEF
                        log.Simulador = "KIO_SIM_DET_TAR_PEF"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = fecha
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()

        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_Reprogramaciones(ByVal idTarjeta As Integer) As List(Of Simulador_Reprogramacion)
        Dim lista As New List(Of Simulador_Reprogramacion)
        cn.abrirconexion()
        lista = cn.consultarReprogramaciones("dbo.Usp_Get_Obtener_SIM_Reprogramaciones", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_Reprogramaciones(ByVal lista As List(Of Simulador_Reprogramacion), ByVal user As String, ByVal ip As String) As Integer
        'resultado = cn.guardarReprogramaciones("dbo.Usp_Get_Guardar_SIM_Reprogramaciones", lista)
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_Reprogramacion) = New List(Of Simulador_Reprogramacion)
                For Each sim As Simulador_Reprogramacion In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_Reprogramacion In lst
                    sim.FECHA_HORA = fecha
                    resultado = cn.guardarReprogramaciones("dbo.Usp_Get_Guardar_SIM_Reprogramaciones", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDREP
                        log.Simulador = "KIO_SIM_DET_TAR_REPROGRAMACIONES"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = fecha
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()

        Return resultado
    End Function

    Public Function sp_get_Obtener_SIM_SuperEfectivo(ByVal idTarjeta As Integer) As List(Of Simulador_SuperEfectivo)
        Dim lista As New List(Of Simulador_SuperEfectivo)
        cn.abrirconexion()
        lista = cn.consultar_SIM_SuperEfectivo("dbo.Usp_Get_Obtener_SIM_SuperEfectivo", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_SuperEfectivo(ByVal lista As List(Of Simulador_SuperEfectivo), ByVal user As String, ByVal ip As String) As Integer
        'resultado = cn.guardar_SIM_SuperEfectivo("dbo.Usp_Get_Guardar_SIM_SuperEfectivo", lista)
        Dim resultado As Integer
        Dim log As Simulador_Log
        Dim fecha As DateTime = DateTime.Now


        Dim options As TransactionOptions = New TransactionOptions
        options.IsolationLevel = Transactions.IsolationLevel.ReadCommitted
        options.Timeout = New TimeSpan(0, 15, 0)
        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required)
            Try
                Dim lst As List(Of Simulador_SuperEfectivo) = New List(Of Simulador_SuperEfectivo)
                For Each sim As Simulador_SuperEfectivo In lista
                    If sim.FLAG = "1" Then
                        lst.Add(sim)
                    End If
                Next
                cn.abrirconexion()
                For Each sim As Simulador_SuperEfectivo In lst
                    sim.FECHA_HORA = fecha
                    resultado = cn.guardar_SIM_SuperEfectivo("dbo.Usp_Get_Guardar_SIM_SuperEfectivo", sim)
                    If resultado = 1 Then
                        log = New Simulador_Log
                        log.IdSimulador = sim.IDDSEF
                        log.Simulador = "KIO_SIM_DET_TAR_SEF"
                        log.ValorInicial = sim.ACTUAL_VALUE
                        log.ValorFinal = sim.ObtenerValorRegistro()
                        log.Usuario = user
                        log.IP = ip
                        log.Fecha = fecha
                        resultado = cn.guardar_LOG_SIM("dbo.Usp_Guardar_LOG_SIM", log)
                        If resultado = 0 Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next
                If resultado = 0 Then
                    scope.Dispose()
                Else
                    scope.Complete()
                End If

            Catch ex As Exception
                resultado = 0
                scope.Dispose()
            End Try
        End Using
        cn.cerrarconexion()

        Return resultado
    End Function

#End Region

    Public Function listar_TipoSistemaTarjeta() As DataSet
        Try
            Dim dts As New DataSet
            cn.abrirconexion()
            dts = cn.consultar("dbo.Usp_Get_TipoSistemaTarjeta")
            cn.cerrarconexion()
            Dim nrow As DataRow = dts.Tables(0).NewRow()

            nrow("ID") = "0"
            nrow("TIPO") = "--Seleccionar--"

            dts.Tables(0).Rows.Add(nrow)
            dts.Tables(0).DefaultView.Sort = "ID"
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function

    Public Function Usp_get_Count_ConsultaAceptacionIncremento(ByVal tipo As String, _
                                                               ByVal canal As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As Integer
        Try
            Dim nro As New Integer
            cn.abrirconexion()
            nro = cn.contarRegistros("dbo.Usp_get_Count_ConsultaAceptacionIncremento", tipo, canal, f1, f2)
            cn.cerrarconexion()

            Return nro
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Public Function Usp_get_Count_ConsultaAceptacionTC(ByVal tipo As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As Integer
        Try
            Dim nro As New Integer
            cn.abrirconexion()
            nro = cn.contarRegistros("dbo.Usp_get_Count_ConsultaAceptacionTC", tipo, f1, f2)
            cn.cerrarconexion()

            Return nro
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Public Function Usp_get_Count_ConsultaCambioProductoPorRipleymatico(ByVal nro_dni As String, _
                                        ByVal nro_tarjeta As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal tienda As Integer, _
                                        ByVal nro_contrato As String) As Integer
        Try
            Dim nro As New Integer
            cn.abrirconexion()
            nro = cn.contarRegistros("dbo.Usp_get_Count_ConsultaCambioProductoPorRipleymatico", nro_dni, nro_tarjeta, f1, f2, tienda, nro_contrato)
            cn.cerrarconexion()

            Return nro
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Public Function Usp_get_Count_ConsultaLPDP(ByVal nro_dni As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal tipo As Integer) As Integer
        Try
            Dim nro As New Integer
            cn.abrirconexion()
            nro = cn.contarRegistros("dbo.Usp_get_Count_ConsultaLPDP", nro_dni, f1, f2, tipo)
            cn.cerrarconexion()

            Return nro
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Function listar_EstrucutraPDFs() As DataSet
        Try
            Dim dts As New DataSet
            cn.abrirconexion()
            dts = cn.consultar("dbo.Usp_Get_ListaEstructuraPDFs")
            cn.cerrarconexion()
            Dim nrow As DataRow = dts.Tables(0).NewRow()

            nrow("ID") = "0"
            nrow("NOMBRE") = "--Seleccionar--"

            dts.Tables(0).Rows.Add(nrow)
            dts.Tables(0).DefaultView.Sort = "ID"
            Return dts
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return New DataSet
    End Function

    Public Function Usp_Get_Obtener_EstructuraPDF(ByVal idTarjeta As Integer) As List(Of EstructuraPDF)
        Dim lista As New List(Of EstructuraPDF)
        cn.abrirconexion()
        lista = cn.Usp_Get_Obtener_EstructuraPDF("dbo.Usp_Get_Obtener_EstructuraPDF", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function Usp_Get_Guardar_EstructuraPDF(ByVal lista As List(Of EstructuraPDF)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.Usp_Get_Guardar_EstructuraPDF("dbo.Usp_Get_Guardar_EstructuraPDF", lista)
        cn.cerrarconexion()
        Return resultado
    End Function

    Function sp_get_Obtener_Log_RipleyMatico(ByVal tipo As String, ByVal desde As String, ByVal hasta As String, ByVal filtro As String) As List(Of LogRipleyMatico)
        Dim lista As New List(Of LogRipleyMatico)
        cn.abrirconexion()
        lista = cn.sp_get_Obtener_Log_RipleyMatico("dbo.Usp_Get_Obtener_Log_RipleyMatico", tipo, desde, hasta, filtro)
        cn.cerrarconexion()
        Return lista
    End Function


    Function usp_get_Obtener_Log_AceptacionSEF(ByVal desde As String, ByVal hasta As String, ByVal dni As String) As List(Of LogAceptacionSEF)
        Dim lista As New List(Of LogAceptacionSEF)
        cn.abrirconexion()
        lista = cn.usp_get_Obtener_Log_AceptacionSEF("dbo.USP_GET_ACEPTACION_SEF", desde, hasta, dni)
        cn.cerrarconexion()
        Return lista
    End Function


    Public Function sp_get_ObtenerConsolidadoConsultasRipleymatico(ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal ids As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_get_ObtenerConsolidadoConsultasRipleymatico", f1, f2, ids)
        cn.cerrarconexion()
        Return dts
    End Function
End Class
