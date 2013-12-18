
Partial Class aspx_frmTemp
    Inherits System.Web.UI.Page

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim rutaArchivo As String


        If FileUpload1.HasFile Then

            rutaArchivo = "C:\RipleyMaticoDS\" + FileUpload1.FileName

            FileUpload1.SaveAs(rutaArchivo)

            LbxImagenes.Items.Add(rutaArchivo)

        End If

    End Sub
End Class
