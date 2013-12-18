Imports System.IO
Imports System.Configuration

Partial Class frmLogEnvioData
    Inherits System.Web.UI.Page

    Public Sub leer()


        Dim ruta As String = ConfigurationManager.AppSettings("RutaLogErrores").ToString()

        Try

            Dim str As New StreamReader(ruta)
            Dim Data As String

            Do
                Data = str.ReadLine()
                If Not Data Is Nothing Then
                    lbxTest.Items.Add(Data)
                End If
            Loop Until Data Is Nothing
            str.Close()



        Catch ex As Exception

            Response.Redirect("error.aspx?mensajeerror=" + "no existe log de errores" + ex.Message)

        End Try
        'Dim data As String = str.ReadToEnd()

        'lblContent.Text = data


    End Sub

    Protected Sub btnTest_Click(sender As Object, e As System.EventArgs) Handles btnTest.Click
        leer()
    End Sub
End Class
