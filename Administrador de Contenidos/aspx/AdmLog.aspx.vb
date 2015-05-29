Imports System.IO
Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Xml
Imports System.Web
Imports System.Web.Services.Protocols
Imports UtilitarioEnvioData.Entidades
Imports ComunLayer
Imports System.Data
Imports ComunLayer.Enum
Imports UtilitarioEnvioData.EnvioData

Partial Class aspx_AdmLog
    Inherits System.Web.UI.Page

    Public Shared listaKioscos As List(Of ENKiosco)
    Public Shared listaTemp As List(Of ENKiosco)
    Public Shared identificador As String = ""
    Public Shared fechaHora As DateTime = DateTime.Now
    Public Shared session_id As String = ""
    Public Shared username As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()

                InicarIdentificador()
                listaKioscos = New List(Of ENKiosco)
                listaTemp = New List(Of ENKiosco)
                Dim contador As Integer = 1
                Dim dt As DataTable = Sql_Get_KioscosIP()

                For Each dr As DataRow In dt.Rows
                    Dim kio As New ENKiosco()
                    kio.Id = "Kiosko" & contador.ToString()
                    kio.IpKiosco = dr(1).ToString()
                    kio.Nombre = dr(0).ToString()
                    listaKioscos.Add(kio)

                    kio.RutaPathArchivos = pathCliente
                    kio.Ubicacion = dr(2).ToString()
                    listaTemp.Add(kio)

                    contador += 1
                Next

                session_id = Session("SESSION_ID")
                username = GetNombreUsuario()
            End If
        Catch ex As Exception

        End Try
    End Sub

    <WebMethod(Description:="Eliminar archivos log de un rango de fecha")> _
    Public Shared Function EliminarArchivosLog(ByVal model As LogModel) As String

        Dim cantidadKioskos As Integer = 0
        Dim fechaInicial As String = model.FechaInicio
        Dim fechaFinal As String = model.FechaFin
        Dim pathServer As String = "\\10.25.2.204\C:\inetpub\wwwroot\WSRIPLEY_VMS4\Log"
        Dim pathCliente As String = ConfigurationManager.AppSettings("RutaCarpetaRipleyMaticoClientes").ToString()
        Dim nombreLogSearch As String = "\LogAlternativo_"
        Dim extension As String = ".txt"
        Dim destino As String = String.Empty
        Dim listaArchivoCumple As New List(Of String)
        Dim listTempKioscos As New List(Of ENKiosco)
        Dim listaFinalKioscos As New List(Of ENKiosco)

        Select Case model.TipoLog
            Case TipoLog.FLogAlternativo
            Case TipoLog.FLogEnvioData
            Case TipoLog.FLogErrorFlash
            Case TipoLog.FLogActualizacionRipleymatico
            Case TipoLog.FLogBiometrico

                Select Case model.Modalidad
                    Case TipoModalidad.Personalizado
                        If model.KioskoList.Count > 0 Then
                            For Each kiosko As ENKiosco In model.KioskoList
                                kiosko.RutaPathArchivos = pathCliente
                                listTempKioscos.Add(kiosko)
                            Next
                            listaFinalKioscos = listTempKioscos
                        End If

                    Case TipoModalidad.Todos
                        listaFinalKioscos = listaTemp

                    Case TipoModalidad.Lima
                        listaFinalKioscos = listaTemp.Where(Function(p) p.Ubicacion = "L").ToList()

                    Case TipoModalidad.Provincia
                        listaFinalKioscos = listaTemp.Where(Function(p) p.Ubicacion = "P").ToList()
                    Case Else

                End Select

                cantidadKioskos = listaFinalKioscos.Count

                EnvioData.Instancia.EscribirLog(identificador, "- " + DateTime.Now + " - Eliminación de Log RipleyMático", EliminarArchivosLog)
                EnvioData.Instancia.EscribirLog(identificador, "Descripción: " + model.Descripcion, EliminarArchivosLog)
                EnvioData.Instancia.EscribirLog(identificador, "-Ha seleccionado " + cantidadKioskos.ToString() + " archivos Log", EliminarArchivosLog)
                EnvioData.Instancia.EscribirLog(identificador, "-Se eliminarán los archivos de " + listaFinalKioscos.Count.ToString() + " Kioskos", EliminarArchivosLog)

                'For Each kio As ENKiosco In listaFinalKioscos
                '    Dim ok As Boolean
                '    Dim nombreKiosko As String = kio.IpKiosco
                '    Try

                '        Dim kiosko As ENKiosco = kio
                '        kiosko.IpKiosco = obtenerIP(kiosko.IpKiosco)

                '        ok = EnvioData.Instancia.EnviarArchivos(kiosko, directorioSeleccionado, pathServer, usuario, password, dominio, textoLog, listaARchivos, identificador)
                '        If ok = True Then
                '            contar = contar + 1
                '            EnvioData.Instancia.EscribirLog(identificador, "-Terminado " + nombreKiosko + " | " + contar.ToString() + " de " + listaFinalKioscos.Count.ToString() + " Kioskos", ActualizacionImagenes)
                '        Else
                '            EnvioData.Instancia.EscribirLog(identificador, "-No se pudo terminar el kiosko " + nombreKiosko, ActualizacionImagenes)
                '        End If
                '    Catch ex As Exception
                '        EnvioData.Instancia.EscribirLog(identificador, "Error: " + nombreKiosko + " Es posible que no tenga permiso de acceso a un archivo, o haya sido borrado durante la ejecución.", ActualizacionImagenes)
                '    End Try
                'Next

                'If model.KioskoList.Count > 0 Then
                '    For Each kiosko As String In model.KioskoList
                '        destino = "\\" & kiosko & pathCliente
                '        archivofechaInicial = destino & nombreLogSearch & fechaInicial & extension
                '        archivofechaFinal = destino & nombreLogSearch & fechaFinal & extension

                '        listaArchivo = Directory.GetFiles(destino, "*.txt")

                '        For Each archivo As String In listaArchivo

                '            If archivo >= archivofechaInicial And archivo <= archivofechaFinal Then
                '                System.Threading.Thread.Sleep(1000)
                '                listaArchivoCumple.Add(archivo)
                '                File.Delete(archivo)
                '                End If
                '        Next

                '    Next
                'Else
                '    listaArchivo = Directory.GetFiles(pathServer, "*.txt")
                '    archivofechaInicial = pathServer & nombreLogSearch & fechaInicial & extension
                '    archivofechaFinal = pathServer & nombreLogSearch & fechaFinal & extension

                '    For Each archivo As String In listaArchivo

                '        If archivo >= archivofechaInicial And archivo <= archivofechaFinal Then
                '            System.Threading.Thread.Sleep(1000)
                '            listaArchivoCumple.Add(archivo)
                '            File.Delete(archivo)
                '            End If
                '    Next
                '    End If

            Case TipoLog.WSLog


            Case Else

        End Select
                Return "Se eliminaron " & listaArchivoCumple.Count & " archivo(s)."
    End Function

    <WebMethod(Description:="Eliminar archivos log de un rango de fecha")> _
    <System.Xml.Serialization.XmlInclude(GetType(List(Of ENKiosco)))> _
    <System.Xml.Serialization.XmlInclude(GetType(ENKiosco))> _
    <System.Xml.Serialization.XmlInclude(GetType(Response))> _
    Public Shared Function ObtenerListaKioskos() As Response
        Dim respuesta As New Response
        respuesta.Success = False
        respuesta.Warning = False
        respuesta.Message = String.Empty

        Try
            respuesta.Success = True
            respuesta.Data = listaKioscos
        Catch ex As Exception
            respuesta.Message = Constantes.ErrorServidor
            Log.ErrorLog(String.Format(respuesta.Message & " Excepcion = {0}", ex.Message))
        End Try

        Return respuesta

    End Function

    Public Shared Sub InicarIdentificador()
        Dim fecha As DateTime = DateTime.Now
        fechaHora = fecha
        identificador = ConvertirFechaHora(fechaHora)
    End Sub

    Public Shared Function ConvertirFechaHora(ByVal fecha As DateTime) As String
        Dim nuevaFecha, dia, mes, year, hora, minuto As String
        dia = fecha.Day.ToString()
        mes = fecha.Month.ToString()
        year = fecha.Year.ToString()
        hora = fecha.Hour.ToString()
        minuto = fecha.Minute.ToString()

        If (dia.Length < 2) Then
            dia = "0" + dia
        End If
        If (mes.Length < 2) Then
            mes = "0" + mes
        End If
        If (hora.Length < 2) Then
            hora = "0" + hora
        End If

        If (minuto.Length < 2) Then
            minuto = "0" + minuto
        End If

        nuevaFecha = year + mes + dia + hora + minuto
        Return nuevaFecha
    End Function

    Public Shared Function GetNombreUsuario() As String
        Dim usern As String = "Anónimo"
        If Not (session_id Is Nothing) Then
            Dim dtConfig As New DataTable
            Dim sMensajeError As String = ""
            dtConfig = fun_devolverDatosConfiguracion(session_id.ToString.Trim, sMensajeError) 'el Session.SessionID cambia de numero al que se guardo revisar.


            If dtConfig.Rows.Count <= 0 Then 'Su session ha expirado
                usern = "Anónimo"
            Else
                usern = Cryptor(dtConfig.Rows(0).Item("LOGUEADO")).ToUpper()
            End If
        End If
        Return usern
    End Function

End Class
