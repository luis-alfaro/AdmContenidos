Imports System.Data
Partial Class aspx_MantAreas
    Inherits System.Web.UI.Page
    Dim cn As New Area
    Dim es As Integer = 0

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim rp As Integer = 2
            Dim rpp As String = ""

            If Me.CheckBox1.Checked = True Then
                es = 1
            End If
            If Me.HddIdArea.Value = 0 Then
                If cn.agregararea(Me.txtarea.Text, es, 1, 1, rp, rpp) >= 1 Then

                End If
            Else
                If cn.agregararea(Me.txtarea.Text, es, Me.HddIdArea.Value, 2, rp, rpp) >= 1 Then

                End If
            End If
            Call Actualizar()
            Response.Redirect("MantAreas.aspx")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim idareas As String = IIf(Request.QueryString("idarea") Is Nothing, "0", Request.QueryString("idarea"))


            If Not IsPostBack Then
                Me.HddIdArea.Value = idareas



                Call Actualizar()
                Dim dts As New DataSet
                dts.Clear()
                dts = cn.listarareacod(idareas)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    Me.HddIdArea.Value = idareas
                    Me.txtarea.Text = dts.Tables("consulta").Rows(0).Item("nombre").ToString
                    'MsgBox(dts.Tables("consulta").Rows(0).Item("estado").ToString)
                    If dts.Tables("consulta").Rows(0).Item("estado").ToString = 1 Then
                        Me.CheckBox1.Checked = True
                    Else
                        Me.CheckBox1.Checked = False
                    End If
                End If


                If Me.HddIdArea.Value = "0" Then
                    lblTexto.Text = "Agregar una nueva área"
                    txtarea.Text = ""
                Else
                    lblTexto.Text = "Editar área"
                End If

            End If

            chkMostrar_CheckedChanged(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub Actualizar()
        Me.GridView1.DataSource = cn.listararea(1)
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Dim cont As Integer = 0
        Dim lnkeditar As New HyperLink
        Dim lnkeliminar As New HyperLink
        Dim dts As New dataset
        dts = cn.listararea(1)
        For cont = 0 To dts.Tables("consulta").Rows.Count - 1
            lnkeditar = Me.GridView1.Rows(cont).FindControl("lnkEditar")
            lnkeditar.NavigateUrl = "MantAreas.aspx?idarea=" + dts.Tables("consulta").Rows(cont)("IdArea").ToString
        Next
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub txtarea_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarea.TextChanged

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub chkMostrar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMostrar.CheckedChanged
        Try
            'Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "4", "1", "0")
            'Me.GridView1.DataBind()

            If chkMostrar.Checked = True Then ' todos

                For Each item As GridViewRow In GridView1.Rows
                    item.Visible = True

                Next
            Else 'solo habilitados

                For Each item As GridViewRow In GridView1.Rows
                    If item.Cells(2).Text = "Deshabilitada" Then
                        item.Visible = False
                    End If
                Next


            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            If GridView1.Rows.Count > 0 Then

                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=Areas.xls")
                Response.Charset = "UTF-8"
                Response.ContentEncoding = System.Text.Encoding.Default
                Response.Write(ExportToExcel(GridView1))
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
        wControl.Columns(3).Visible = False

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
