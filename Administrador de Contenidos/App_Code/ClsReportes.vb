Imports Microsoft.VisualBasic
Imports System.Data
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
        'Dim d1, d2, d4, d3 As String
        'd1 = "" : d2 = ""
        'Dim a, b, c, d As Integer
        'a = Day(f1)
        'b = Day(f2)
        'c = Month(f1)
        'd = Month(f2)
        'If a < 10 Then
        '    d1 = "0" & Day(f1)
        'Else
        '    d1 = a
        'End If

        'If b < 10 Then
        '    d2 = "0" & Day(f2)
        'Else
        '    d2 = b
        'End If

        'If c < 10 Then
        '    d3 = "0" & Month(f1)
        'Else
        '    d3 = c
        'End If

        'If d < 10 Then
        '    d4 = "0" & Month(f2)
        'Else
        '    d4 = d
        'End If

        'f1 = d1 & "-" & d3 & "-" & Year(f1)
        'f2 = d2 & "-" & d4 & "-" & Year(f2)
        dts = cn.consultar("dbo.SP_Reporte_Cabeza_Detalle", tipo, tipoReporte, Orden, suc, f1, f2)
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
    Public Function sp_get_ConsultaAceptacionIncremento(ByVal tipo As String, _
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime, _
                                        ByVal nroRegistros As Integer, _
                                        ByVal pagina As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_ConsultaAceptacionIncremento", tipo, f1, f2, nroRegistros, pagina)
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


    Public Function sp_get_Obtener_SIM_Reprogramaciones(ByVal idTarjeta As Integer) As List(Of Simulador_Reprogramacion)
        Dim lista As New List(Of Simulador_Reprogramacion)
        cn.abrirconexion()
        lista = cn.consultarReprogramaciones("dbo.Usp_Get_Obtener_SIM_Reprogramaciones", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_Reprogramaciones(ByVal lista As List(Of Simulador_Reprogramacion)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardarReprogramaciones("dbo.Usp_Get_Guardar_SIM_Reprogramaciones", lista)
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

    Public Function sp_get_Guardar_SIM_Diferido(ByVal lista As List(Of Simulador_Diferido)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_Diferido("dbo.Usp_Get_Guardar_SIM_Diferido", lista)
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

    Public Function sp_get_Guardar_SIM_SuperEfectivo(ByVal lista As List(Of Simulador_SuperEfectivo)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_SuperEfectivo("dbo.Usp_Get_Guardar_SIM_SuperEfectivo", lista)
        cn.cerrarconexion()
        Return resultado
    End Function


    Public Function sp_get_Obtener_SIM_Compras(ByVal idTarjeta As Integer) As List(Of Simulador_Compras)
        Dim lista As New List(Of Simulador_Compras)
        cn.abrirconexion()
        lista = cn.consultar_SIM_Compras("dbo.Usp_Get_Obtener_SIM_Compras", idTarjeta)
        cn.cerrarconexion()
        Return lista
    End Function

    Public Function sp_get_Guardar_SIM_Compras(ByVal lista As List(Of Simulador_Compras)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_Compras("dbo.Usp_Get_Guardar_SIM_Compras", lista)
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

    Public Function sp_get_Guardar_SIM_EfectivoExpress(ByVal lista As List(Of Simulador_EfectivoExpress)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_EfectivoExpress("dbo.Usp_Get_Guardar_SIM_EfectivoExpress", lista)
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

    Public Function sp_get_Guardar_SIM_PrestamoEfectivo(ByVal lista As List(Of Simulador_PrestamoEfectivo)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_PrestamoEfectivo("dbo.Usp_Get_Guardar_SIM_PrestamoEfectivo", lista)
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

    Public Function sp_get_Guardar_SIM_ConsolidacionDeDeuda(ByVal lista As List(Of Simulador_ConsolidacionDeDeuda)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_ConsolidacionDeDeuda("dbo.Usp_Get_Guardar_SIM_ConsolidacionDeDeuda", lista)
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

    Public Function sp_get_Guardar_SIM_DepositoPlazo(ByVal lista As List(Of Simulador_DepositoPlazo)) As Integer
        Dim resultado As Integer
        cn.abrirconexion()
        resultado = cn.guardar_SIM_DepositoPlazo("dbo.Usp_Get_Guardar_SIM_DepositoPlazo", lista)
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
                                        ByVal f1 As DateTime, _
                                        ByVal f2 As DateTime) As Integer
        Try
            Dim nro As New Integer
            cn.abrirconexion()
            nro = cn.contarRegistros("dbo.Usp_get_Count_ConsultaAceptacionIncremento", tipo, f1, f2)
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

    Function sp_get_Obtener_Log_RipleyMatico(tipo As String, desde As String, hasta As String, filtro As String) As List(Of LogRipleyMatico)
        Dim lista As New List(Of LogRipleyMatico)
        cn.abrirconexion()
        lista = cn.sp_get_Obtener_Log_RipleyMatico("dbo.Usp_Get_Obtener_Log_RipleyMatico", tipo, desde, hasta, filtro)
        cn.cerrarconexion()
        Return lista
    End Function

End Class
