Imports System.Data
Public Class Ubigeo
    Dim cn As New Funciones_Conexion

    Public Function AgregarUbigeo(ByVal nombre As String, ByVal tipo As String, _
                                  ByVal padre As String, ByVal tipoope As String, _
                                  ByRef rpta As Integer, _
                                  ByRef mensaje As String) As Integer
        Dim r As Integer = 0
        Try
            cn.abrirconexion()
            cn.ejecutar("dbo.sp_mantenimiento_ubigeo", True, rpta, mensaje, _
                        nombre, tipo, padre, tipoope, 0, "")
            cn.cerrarconexion()
            r = 1
        Catch ex As Exception
            r = 0
            MsgBox(ex.ToString)
        End Try
        Return r
    End Function
    Public Function listarubigeos(ByVal param1 As String, ByVal tipo As Integer, _
                                    ByVal tipoubi As Integer, ByVal padre As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_listarubigeo_ep", param1, tipo, tipoubi, padre)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function listarubigeostreeview(ByVal tipo As String, ByVal param1 As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.pa_ubigeo_listar", tipo, param1)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function obtenerubigeo(ByVal codigo As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_obtenerubigeo", codigo)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function ubigeotemporal(ByVal codigo As Integer) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_ubigetemporal", codigo)
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function fechaserver() As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.sp_fecha_server")
        cn.cerrarconexion()
        Return dts
    End Function
    Public Function nombrefecha(ByVal fecha As String) As DataSet
        Dim dts As New DataSet
        cn.abrirconexion()
        dts = cn.consultar("dbo.Usp_Get_Dia", fecha)
        cn.cerrarconexion()
        Return dts
    End Function
End Class
