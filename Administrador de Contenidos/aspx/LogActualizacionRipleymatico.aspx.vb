Imports System.Data
Imports System.IO

Partial Class aspx_LogActualizacionRipleymatico
    Inherits System.Web.UI.Page
    Dim kio As New kioskos
    Dim are As New Area
    Dim tiend As New tiendas


    Public Sub leer()


        Dim str As New StreamReader("C:\RipleymaticoDS\LogActualizacionRipleymatico.txt")


        Dim Data As String

        Do
            Data = str.ReadLine()
            If Not Data Is Nothing Then
                lbxError.Items.Add(Data)
            End If
        Loop Until Data Is Nothing
        str.Close()


        'Dim data As String = str.ReadToEnd()

        'lblContent.Text = data


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            leer()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
