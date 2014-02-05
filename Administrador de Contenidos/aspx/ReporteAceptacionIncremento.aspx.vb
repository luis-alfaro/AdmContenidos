Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.String

Partial Class aspx_ReporteAceptacionIncremento
    Inherits System.Web.UI.Page

    Dim menus As New ClsReportes
    Dim pagina As Integer
    Dim paginaActual As Integer = 1
    Dim totalPaginas As Integer
    Dim totalRegistros As Integer
    Dim nroRegistros As Integer = 20

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
                Dim ds As New DataSet
                gvdetalle.Attributes.Add("style", "table-layout:fixed")
                Me.tblPaginacion.Visible = False
                Dim menus As New ClsReportes
                Dim tipos As New DataSet
                tipos = menus.listar_TipoSistemaTarjeta()
                Me.ddltipo.DataSource = tipos.Tables(0).DefaultView.ToTable()
                Me.ddltipo.DataTextField = "TIPO"
                Me.ddltipo.DataValueField = "ID"
                Me.ddltipo.DataBind()

                Call HabilitarTodos(False)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If txtfechadesde.Text.Trim() = "" Then
            lbldesde.Visible = True
            lbldesde.Text = "ingrese una fecha"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            lblhasta.Visible = True
            lblhasta.Text = "ingrese una fecha"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            Exit Sub
        Else
            lblhasta.Visible = False
        End If
        Call ContarDatos()
        Call MostrarDatos(paginaActual)

    End Sub
    Public Sub gvdetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For index = 0 To e.Row.Cells.Count - 1
                If gvdetalle.HeaderRow.Cells(index).Text = "Fecha" Or gvdetalle.HeaderRow.Cells(index).Text = "Inicio Vigencia" Or gvdetalle.HeaderRow.Cells(index).Text = "Fin Vigencia" Then
                    If e.Row.Cells(index).Text.Contains("/") Then
                        e.Row.Cells(index).Text = String.Format("{0:d}", CType(e.Row.Cells(index).Text, Date))
                    End If
                End If
            Next
        End If
    End Sub
    'Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
    '    Call MOSTRAR(Me.gvdetalle)
    'End Sub
    'Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
    '    If txtfechadesde.Text.Trim() = "" Then
    '        lbldesde.Visible = True
    '        lbldesde.Text = "Ingrese una fecha"
    '        Exit Sub
    '    Else
    '        lbldesde.Visible = False
    '    End If

    '    If txtfechahasta.Text.Trim() = "" Then
    '        lblhasta.Visible = True
    '        lblhasta.Text = "Ingrese una fecha"
    '        Exit Sub
    '    Else
    '        lblhasta.Visible = False
    '    End If

    '    Dim cadena As String = ""
    '    cadena = "VistaImpresionConsultaIncremento.aspx?&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text
    '    Response.Redirect("VistaImpresionConsultaIncremento.aspx?&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text)

    'End Sub

    Sub MostrarDatos(ByVal page As Integer)
        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim tipo As String : Dim nro As Integer
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            nro = ddltipo.SelectedIndex
            If nro = 0 Then
                tipo = ""
            Else
                tipo = ddltipo.SelectedItem.ToString()
            End If

            Me.gvdetalle.Visible = True

            dts.Clear()
            dts = menus.sp_get_ConsultaAceptacionIncremento(tipo, f1, f2, nroRegistros, page)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
                Me.tblPaginacion.Visible = True
                Me.txtPagina.Text = paginaActual.ToString()
                Call HabilitarTodos(True)
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
                Me.tblPaginacion.Visible = False
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + ddltipo.SelectedValue

        End Try
    End Sub

    Sub MOSTRAR(ByVal wControl As GridView)
        If wControl.Rows.Count > 0 Then
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("Content-Disposition", "attachment;filename=NombreArchivo.xls")
            Response.Charset = "UTF-8"
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.Write(ExportToExcel(wControl))
            Response.End()
        End If
    End Sub

    Public Function ExportToExcel(ByVal wControl As GridView) As String
        Dim page1 As New Page
        Dim form1 As New HtmlForm
        Me.gvdetalle.EnableViewState = False
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
        'writer2.Write(vbLf & "</body>" & vbLf & "</html>")
        page1.Dispose()
        page1 = Nothing
        Return builder1.ToString()
    End Function

    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.BtnExporarExcel.Visible = valor
        Me.BtnExporarTodoExcel.Visible = valor
    End Sub

    Sub ContarDatos()

        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim tipo As String : Dim nro As Integer
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            nro = ddltipo.SelectedIndex
            If nro = 0 Then
                tipo = ""
            Else
                tipo = ddltipo.SelectedItem.ToString()
            End If

            totalRegistros = menus.Usp_get_Count_ConsultaAceptacionIncremento(tipo, f1, f2)
            totalPaginas = totalRegistros / nroRegistros
            Me.lblTotal.Text = totalRegistros.ToString()
            Me.txtTotalPaginas.Text = totalPaginas.ToString()
        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + totalRegistros.ToString()

        End Try
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            paginaActual = CInt(txtPagina.Text)
            If paginaActual > 1 Then
                paginaActual -= 1
                MostrarDatos(paginaActual)
            End If
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            paginaActual = CInt(txtPagina.Text)
            If paginaActual < totalPaginas Then
                paginaActual += 1
                MostrarDatos(paginaActual)
            End If
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            Dim pag As Integer = CInt(txtPagina.Text)
            If pag <= totalPaginas And pag >= 1 Then
                paginaActual = pag
                MostrarDatos(paginaActual)
            Else
                lblError.Text = "La página actual no puede ser mayor al número total de páginas."
                lblError.Visible = True
            End If
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        exportarExcel(paginaActual)
    End Sub

    Protected Sub BtnExporarTodoExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarTodoExcel.Click
        exportarExcel(0)
    End Sub


    Public Sub exportarExcel(ByVal pagina As Integer)
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        gvdetalle.AllowPaging = False
        MostrarDatos(pagina)
        'gvdetalle.DataBind()

        'Change the Header Row back to white color
        gvdetalle.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Apply style to Individual Cells
        gvdetalle.HeaderRow.Cells(0).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(1).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(2).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(3).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(4).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(5).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(6).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(7).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(8).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(9).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(10).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(11).Style.Add("background-color", "#6B696B")
        gvdetalle.HeaderRow.Cells(12).Style.Add("background-color", "#6B696B")

        For Each row As GridViewRow In gvdetalle.Rows
            row.BackColor = System.Drawing.Color.White
            For Each cell As TableCell In row.Cells
                cell.Attributes.Add("class", "textmode")
            Next
        Next

        gvdetalle.RenderControl(hw)

        'style to format numbers to string
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' No borrar, esto verifica si el control(gridview) se ha renderizado antes de exportar a excel
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvdetalle.PageIndex = e.NewPageIndex
        gvdetalle.DataBind()
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
