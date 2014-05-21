Imports System.Data
Partial Class aspx_ListadoKioskos
    Inherits System.Web.UI.Page
    Dim kio As New kioskos
    Dim are As New Area
    Dim tiend As New tiendas
    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Response.Redirect("MantKioskos.aspx?tipo=N")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Call Llenar()

                Dim dsTempAreas As DataSet = are.listararea(3)

                Me.ddlarea.DataSource = dsTempAreas
                Me.ddlarea.DataTextField = "Nombre"
                Me.ddlarea.DataValueField = "IdArea"
                Me.ddlarea.DataBind()


                Dim dsTempTienda As DataSet = tiend.ListarTiendas("2", "", "", "", "", "0")
                Dim dtTempTienda As New DataTable

                dtTempTienda.Columns.Add("ID")
                dtTempTienda.Columns.Add("CIUDAD")
                dtTempTienda.Columns.Add("SUCURSAL")
                dtTempTienda.Columns.Add("IdUbigeo")
                dtTempTienda.Columns.Add("esttienda")
                dtTempTienda.Columns.Add("direccion")
                dtTempTienda.Columns.Add("Ubicacion")
                dtTempTienda.Columns.Add("Estado")

                For Each item As DataRow In dsTempTienda.Tables(0).Rows
                    If item("Estado") = "Habilitada" Then
                        Dim arrTemp(7) As String
                        arrTemp(0) = item(0).ToString()
                        arrTemp(1) = item(1).ToString()
                        arrTemp(2) = item(2).ToString()
                        arrTemp(3) = item(3).ToString()
                        arrTemp(4) = item(4).ToString()
                        arrTemp(5) = item(5).ToString()
                        arrTemp(6) = item(6).ToString()
                        arrTemp(7) = item(7).ToString()
                        dtTempTienda.Rows.Add(arrTemp)
                    End If
                Next


                'todos
                Dim arrayTiendaTodos(7) As String
                arrayTiendaTodos(0) = "0"
                arrayTiendaTodos(1) = "TODOS"
                arrayTiendaTodos(2) = "TODOS"
                arrayTiendaTodos(3) = "0"
                arrayTiendaTodos(4) = "1"
                arrayTiendaTodos(5) = "PERU"
                arrayTiendaTodos(6) = "PERU"
                arrayTiendaTodos(7) = "Habilitada"

                dtTempTienda.Rows.Add(arrayTiendaTodos)


                Me.ddltienda.DataSource = dtTempTienda
                Me.ddltienda.DataTextField = "sucursal"
                Me.ddltienda.DataValueField = "id"
                Me.ddltienda.DataBind()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub Llenar()
        Me.gvkioskos.DataSource = kio.listarkioskos("1", "", "", "", "", "")
        Me.gvkioskos.DataBind()
    End Sub

    Protected Sub gvkioskos_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvkioskos.DataBound
        Dim cont As Integer = 0
        Dim lnkeditar As New HyperLink
        Dim lnkeliminar As New HyperLink
        Dim dts As New DataSet
        'dts = kio.listarkioskos("1", "", "", "", "", "")
        'MsgBox(dts.Tables("consulta").Rows.Count)

        Dim c As Integer = Me.ddlarea.SelectedValue
        Dim d As Integer = Me.ddltienda.SelectedValue
        If c = 0 Then
            dts = kio.listarkioskos("7", c, d, "", "", 0)
        Else
            dts = kio.listarkioskos("3", c, d, "", "", 0)

        End If


        Dim j As String = ddlarea.SelectedValue.ToString()
        Dim k As String = ddltienda.SelectedValue.ToString()

        For cont = 0 To dts.Tables("consulta").Rows.Count - 1
            lnkeditar = Me.gvkioskos.Rows(cont).FindControl("lnkEditar")
            lnkeditar.NavigateUrl = "MantKioskos.aspx?idkio=" + dts.Tables("consulta").Rows(cont)("idkiosko").ToString & "&tipo=E"
        Next
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim c As Integer = Me.ddlarea.SelectedValue
            Dim d As Integer = Me.ddltienda.SelectedValue

            If d = 0 Then

            End If

            If c = 0 Then
                Me.gvkioskos.DataSource = kio.listarkioskos("7", c, d, "", "", 0)
                Me.gvkioskos.DataBind()
            Else
                Me.gvkioskos.DataSource = kio.listarkioskos("3", c, d, "", "", 0)
                Me.gvkioskos.DataBind()
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try

            If gvkioskos.Rows.Count > 0 Then

                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=Kioscos.xls")
                Response.Charset = "UTF-8"
                Response.ContentEncoding = System.Text.Encoding.Default
                Response.Write(ExportToExcel(gvkioskos))
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
