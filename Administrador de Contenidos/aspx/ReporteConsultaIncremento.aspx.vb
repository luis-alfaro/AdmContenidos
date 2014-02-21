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

Partial Class aspx_ReporteConsultaIncremento
    Inherits System.Web.UI.Page

    Dim menus As New ClsReportes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
                Dim ds As New DataSet
                gvdetalle.Attributes.Add("style", "table-layout:fixed")
                Call HabilitarTodos(False)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If txtnro_dni.Text.Trim() = "" And txtnro_tarjeta.Text.Trim() = "" Then
            lblNroDocumento.Visible = True
            lblNroDocumento.Text = "Ingrese un número de DNI o número de Tarjeta"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            Exit Sub
        Else
            lblNroDocumento.Visible = False
        End If

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

        Call MostrarDatos()

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
    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        'Call MOSTRAR(Me.gvdetalle)
        Call exportarExcel()
    End Sub
    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If txtnro_dni.Text.Trim() = "" And txtnro_tarjeta.Text.Trim() = "" Then
            lblNroDocumento.Visible = True
            lblNroDocumento.Text = "Ingrese un número de DNI o número de Tarjeta"
            Exit Sub
        Else
            lblNroDocumento.Visible = False
        End If

        If txtfechadesde.Text.Trim() = "" Then
            lbldesde.Visible = True
            lbldesde.Text = "Ingrese una fecha"
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            lblhasta.Visible = True
            lblhasta.Text = "Ingrese una fecha"
            Exit Sub
        Else
            lblhasta.Visible = False
        End If

        Dim cadena As String = ""
        cadena = "VistaImpresionConsultaIncremento.aspx?&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&nro_dni=" & Me.txtnro_dni.Text & "&nro_tarjeta=" & Me.txtnro_tarjeta.Text
        Response.Redirect("VistaImpresionConsultaIncremento.aspx?&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&nro_dni=" & Me.txtnro_dni.Text & "&nro_tarjeta=" & Me.txtnro_tarjeta.Text)

    End Sub

    Sub MostrarDatos()

        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim nro_dni As String : Dim nro_tarjeta As String
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            nro_dni = txtnro_dni.Text.Trim()
            nro_tarjeta = txtnro_tarjeta.Text.Trim()

            Me.gvdetalle.Visible = True

            dts.Clear()
            dts = menus.sp_get_ConsultaIncrementoPorRypleymatico(nro_dni, nro_tarjeta, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Call HabilitarTodos(True)
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
            Else
                Call HabilitarTodos(False)
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + txtnro_dni.Text + "/" + txtnro_tarjeta.Text

        End Try
    End Sub

    'Sub MOSTRAR(ByVal wControl As GridView)
    '    If wControl.Rows.Count > 0 Then
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.ContentType = "application/vnd.ms-excel"
    '        Response.AddHeader("Content-Disposition", "attachment;filename=NombreArchivo.xls")
    '        Response.Charset = "UTF-8"
    '        Response.ContentEncoding = System.Text.Encoding.Default
    '        Response.Write(ExportToExcel(wControl))
    '        Response.End()
    '    End If
    'End Sub

    'Public Function ExportToExcel(ByVal wControl As GridView) As String
    '    Dim page1 As New Page
    '    Dim form1 As New HtmlForm
    '    Me.gvdetalle.EnableViewState = False
    '    page1.EnableViewState = False
    '    page1.Controls.Add(form1)
    '    form1.Controls.Add(wControl)
    '    Dim builder1 As New System.Text.StringBuilder()
    '    Dim writer1 As New System.IO.StringWriter(builder1)
    '    Dim writer2 As New HtmlTextWriter(writer1)
    '    'writer2.Write("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbLf & "<html xmlns=""http://www.w3.org/1999/xhtml"">" & vbLf & "<head>" & vbLf & "<title>Datos</title>" & vbLf & "<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"" />" & vbLf & "<style>" & vbLf & "</style>" & vbLf & "</head>" & vbLf & "<body>" & vbLf)
    '    'writer2.Write("<img src=http://enlace/a/Imagen.gif>")
    '    'writer2.Write("<table><tr><td></td><td></td><td><font face=Arial size=5><center>Título Principal</center></font></td></tr></table><br>")
    '    'writer2.Write("<table>" & vbLf & "<tr>" & vbLf & "<td></td><td class=TD width=35%><b>Fecha  :</b></td><td width=65% align=left>" & Me.txtfechadesde.Text.Trim() & "</td>" & vbLf & "</tr>" & vbLf & "<tr>" & vbLf & "<td></td><td class=TD><b>Gerencia:</b></td><td>" & Me.ddltiendas.SelectedItem.ToString().Trim() & "</td>" & vbLf & "</tr>" & vbLf & "</table>" & vbLf & "<br><br>")
    '    page1.DesignerInitialize()
    '    page1.RenderControl(writer2)
    '    'writer2.Write(vbLf & "</body>" & vbLf & "</html>")
    '    page1.Dispose()
    '    page1 = Nothing
    '    Return builder1.ToString()
    'End Function
    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.BtnExporarExcel.Visible = valor
    End Sub
    Public Sub exportarExcel()
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=ReporteConsultaIncremento.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        gvdetalle.AllowPaging = False
        MostrarDatos()
        'gvdetalle.DataBind()

        'Ponemos toda la fila en blanco y cambiamos el color solo de las celdas de la cabecera.
        'Cambia el color de fondo de la cabecera a blanco.
        gvdetalle.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Ponemos el color de cada celda al color que tenemos en el gridview.
        For Each hcell As TableCell In gvdetalle.HeaderRow.Cells
            hcell.Style.Add("background-color", "#6B696B")
        Next

        'gvdetalle.HeaderRow.Cells(0).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(1).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(2).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(3).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(4).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(5).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(6).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(7).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(8).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(9).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(10).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(11).Style.Add("background-color", "#6B696B")
        'gvdetalle.HeaderRow.Cells(12).Style.Add("background-color", "#6B696B")

        For Each row As GridViewRow In gvdetalle.Rows
            row.BackColor = System.Drawing.Color.White
            For Each cell As TableCell In row.Cells
                cell.Attributes.Add("class", "textmode")
            Next
        Next

        gvdetalle.RenderControl(hw)

        'cambiamos el formato de las celdas, ya que el numero de tarjeta es largo y en excel se muestra como expotencial
        ' de igual manera los DNIs pueden empezar con 0(cero) y sin cambiar formato no se mostraría
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' No borrar, esto verifica si el control(gridview) se ha renderizado antes de exportar a excel
    End Sub
End Class
