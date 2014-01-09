Imports System.Data
Partial Class aspx_ListadoConfiguracionKioskos
    Inherits System.Web.UI.Page
    Dim kio As New kioskos
    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Response.Redirect("MantConfiguracionKioskos.aspx?tipo=N")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Call Llenar()
                Me.gvConfKioskos.DataSource = kio.listarConfiguracionKioskos()
                Me.gvConfKioskos.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub gvConfKioskos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConfKioskos.DataBound
        Dim cont As Integer = 0
        Dim lnkeditar As New HyperLink
        Dim lnkeliminar As New HyperLink
        Dim dts As New DataSet

        dts = kio.listarConfiguracionKioskos()

        For cont = 0 To dts.Tables("consulta").Rows.Count - 1
            lnkeditar = Me.gvConfKioskos.Rows(cont).FindControl("lnkEditar")
            lnkeditar.NavigateUrl = "MantConfiguracionKioskos.aspx?ID=" + dts.Tables("consulta").Rows(cont)("ID").ToString & "&tipo=E"
        Next
    End Sub


    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try

            If gvConfKioskos.Rows.Count > 0 Then

                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=Kioscos.xls")
                Response.Charset = "UTF-8"
                Response.ContentEncoding = System.Text.Encoding.Default
                Response.Write(ExportToExcel(gvConfKioskos))
                Response.End()
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Function ExportToExcel(ByVal wControl As GridView) As String
        Dim page1 As New Page
        Dim form1 As New HtmlForm

        'Dim gvTemp As New GridView
        'gvTemp.Columns.Add(wControl.Columns(0))
        'gvTemp.Columns.Add(wControl.Columns(1))
        'gvTemp.Columns.Add(wControl.Columns(2))
        'gvTemp.Columns.Add(wControl.Columns(3))
        wControl.Columns(5).Visible = False

        page1.EnableViewState = False
        page1.Controls.Add(form1)
        form1.Controls.Add(wControl)
        Dim builder1 As New System.Text.StringBuilder()
        Dim writer1 As New System.IO.StringWriter(builder1)
        Dim writer2 As New HtmlTextWriter(writer1)
        'writer2.Write("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbLf & "<html xmlns=""http://www.w3.org/1999/xhtml"">" & vbLf & "<head>" & vbLf & "<title>Datos</title>" & vbLf & "<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />" & vbLf & "<style>" & vbLf & "</style>" & vbLf & "</head>" & vbLf & "<body>" & vbLf)
        'writer2.Write("<img src=http://enlace/a/Imagen.gif>")
        'writer2.Write("<table><tr><td></td><td></td><td><font face=Arial size=5><center>Título Principal</center></font></td></tr></table><br>")
        'writer2.Write("<table>" & vbLf & "<tr>" & vbLf & "<td></td><td class=TD width=35%><b>Fecha  :</b></td><td width=65% align=left>" & Me.txtfechadesde.Text.Trim() & "</td>" & vbLf & "</tr>" & vbLf & "<tr>" & vbLf & "<td></td><td class=TD><b>Gerencia:</b></td><td>" & Me.ddltiendas.SelectedItem.ToString().Trim() & "</td>" & vbLf & "</tr>" & vbLf & "</table>" & vbLf & "<br><br>")
        page1.DesignerInitialize()
        page1.RenderControl(writer2)
        writer2.Write(vbLf & "</body>" & vbLf & "</html>")
        page1.Dispose()
        page1 = Nothing
        Return builder1.ToString()
    End Function
End Class
