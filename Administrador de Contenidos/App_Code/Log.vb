Imports Microsoft.VisualBasic
Imports System.IO

Public Class Log

    Public Shared Sub ErrorLog(ByVal mensaje As String)
        Try
            Dim directorio As String = AppDomain.CurrentDomain.BaseDirectory & "Log"
            If Not Directory.Exists(directorio) Then
                Directory.CreateDirectory(directorio)
            End If

            Dim archivo As String = directorio & "\" & +Date.Now.Year.ToString("0000") & Date.Now.Month.ToString("00") & Date.Now.Day.ToString("00") + ".log"
            Dim streamWriter As StreamWriter = New StreamWriter(archivo, True)
            streamWriter.WriteLine(Date.Now.ToShortTimeString() & " " & mensaje)
            streamWriter.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
