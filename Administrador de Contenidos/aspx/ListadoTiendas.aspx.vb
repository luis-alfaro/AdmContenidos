Imports System.Data
Partial Class aspx_ListadoTiendas
    Inherits System.Web.UI.Page
    Dim cn As New tiendas
    Dim funciones_otras As New Ubigeo
    Public nodo As New TreeNode
    Dim tipo As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "4", "1", "0")
            'Me.GridView1.DataBind()
            nodo = New TreeNode
            'Me.treeubigeo.Nodes.Clear()
            nodo.Value = "0"
            nodo.Text = "Ubigeo"
            'Me.treeubigeo.Nodes.Add(nodo)
            Call mostrarnodos(nodo)
            'Me.treeubigeo.ExpandDepth = 1

            Dim dts As New DataSet
            dts = cn.ListarTiendas("2", "", "", "", "", "0")

            'Dim dtTemp As DataTable = limpiarDT(dts.Tables(0))



            Me.dgvtiendas.DataSource = dts
            Me.dgvtiendas.DataBind()
            chkMostrarTodos_CheckedChanged(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function mostrarnodos(ByVal pad As TreeNode) As Integer
        Dim dts As New DataSet
        Dim i As Integer = 0
        dts = funciones_otras.listarubigeostreeview("nodos", pad.Value)

        'Dim dtTemp As DataTable = limpiarDT(dts.Tables(0))

        For i = 1 To dts.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dts.Tables("consulta").Rows(i - 1).Item("nombre").ToString
            nodo.Value = dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            'nodo.NavigateUrl = "MantDepartamento.aspx?id=" & dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            pad.ChildNodes.Add(nodo)
            mostrarnodos(nodo)
        Next
        Return 0
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("MantTiendas.aspx")
    End Sub

    Protected Sub dgvtiendas_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvtiendas.DataBound
        Try
            Dim cont As Integer = 0
            Dim lnkeditar As New HyperLink
            Dim lnkeliminar As New HyperLink
            Dim dts As New DataSet
            If tipo = 1 Then 'todos
                dts = cn.ListarTiendas("2", "", "", "", "", "0")

                'Dim dtTemp As DataTable = limpiarDT(dts.Tables(0))

                For cont = 0 To dts.Tables(0).Rows.Count - 1
                    lnkeditar = Me.dgvtiendas.Rows(cont).FindControl("lnkEditar")
                    lnkeditar.NavigateUrl = "MantTiendas.aspx?idtienda=" + dts.Tables(0).Rows(cont)("id").ToString & "&tipoope=2"
                Next
            Else

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '1 - graba
        '2 - edita
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub chkMostrarTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMostrarTodos.CheckedChanged
        Try
            'Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "4", "1", "0")
            'Me.GridView1.DataBind()

            If chkMostrarTodos.Checked = True Then ' todos

                For Each item As GridViewRow In dgvtiendas.Rows
                    item.Visible = True

                Next
            Else 'solo habilitados

                For Each item As GridViewRow In dgvtiendas.Rows
                    If item.Cells(5).Text = "Deshabilitada" Then
                        item.Visible = False
                    End If
                Next


            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function limpiarDT(ByVal dt As DataTable) As DataTable

        Dim dtTemp As New DataTable
        dtTemp.Columns.Add("ID")
        dtTemp.Columns.Add("CIUDAD")
        dtTemp.Columns.Add("SUCURSAL")
        dtTemp.Columns.Add("IdUbigeo")
        dtTemp.Columns.Add("esttienda")
        dtTemp.Columns.Add("direccion")
        dtTemp.Columns.Add("Ubicacion")
        dtTemp.Columns.Add("Estado")
        If chkMostrarTodos.Checked = False Then 'mostrar solo habilitados
            'Estado
            'Habilitada
            For Each item As DataRow In dt.Rows

                If item("estado").ToString() = "Habilitada" Then

                    Dim arrayTemp(7) As String
                    arrayTemp(0) = item("ID").ToString()
                    arrayTemp(1) = item("CIUDAD").ToString()
                    arrayTemp(2) = item("SUCURSAL").ToString()
                    arrayTemp(3) = item("IdUbigeo").ToString()
                    arrayTemp(4) = item("esttienda").ToString()
                    arrayTemp(5) = item("direccion").ToString()
                    arrayTemp(6) = item("Ubicacion").ToString()
                    arrayTemp(7) = item("Estado").ToString()
                    dtTemp.Rows.Add(arrayTemp)
                End If
            Next
        Else
            dtTemp = dt ' todos

        End If

        Return dtTemp
    End Function

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Try

            If dgvtiendas.Rows.Count > 0 Then

                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=Tiendas.xls")
                Response.Charset = "UTF-8"
                Response.ContentEncoding = System.Text.Encoding.Default
                Response.Write(ExportToExcel(dgvtiendas))
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
        wControl.Columns(6).Visible = False

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
