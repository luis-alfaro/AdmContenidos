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

Partial Class aspx_ReporteEstadisticoIncremento
    Inherits System.Web.UI.Page

    Public tienda As New tiendas : Dim menus As New ClsReportes
    Public idtienda As String : Dim feet As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
                idtienda = IIf(Request.QueryString("idtienda") Is Nothing, "0", Request.QueryString("idtienda"))
                Me.hddtienda.Value = idtienda
                Dim ds As New DataSet
                Me.ddltiendas.DataSource = ObtenerHabilitados(tienda.ListarTiendas("7", "", "", "", "", 1).Tables(0))
                Me.ddltiendas.DataTextField = "sucursal"
                Me.ddltiendas.DataValueField = "id"
                Me.ddltiendas.DataBind()
                gvdetalle.Attributes.Add("style", "table-layout:fixed")
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
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            lblhasta.Visible = True
            lblhasta.Text = "ingrese una fecha"
            Exit Sub
        Else
            lblhasta.Visible = False
        End If

        Call MostrarDatos()

    End Sub
    Public Sub gvdetalle_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            If gvdetalle.Controls(0).Controls.Count < 2 Then
                Dim headerCell1 As TableCell = New TableCell()
                headerCell1.ColumnSpan = 7
                headerCell1.Text = "ESTADISTICA DE INCREMENTO LINEA POR RIPLEYMATICO"
                headerCell1.BackColor = Drawing.Color.LightGray


                Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                rowHeader1.Cells.Add(headerCell1)
                rowHeader1.ForeColor = Drawing.Color.Black
                rowHeader1.HorizontalAlign = HorizontalAlign.Center
                rowHeader1.Font.Bold = True
                rowHeader1.Visible = True
                gvdetalle.Controls(0).Controls.AddAt(0, rowHeader1)

                Dim headerCell11 As TableCell = New TableCell()
                Dim headerCell12 As TableCell = New TableCell()
                Dim headerCell13 As TableCell = New TableCell()
                Dim headerCell14 As TableCell = New TableCell()
                headerCell11.ColumnSpan = 1
                headerCell11.Text = ""
                headerCell11.BackColor = Drawing.Color.Maroon
                headerCell12.ColumnSpan = 2
                headerCell12.Text = "RSAT"
                headerCell12.BackColor = Drawing.Color.Maroon
                headerCell13.ColumnSpan = 2
                headerCell13.Text = "MC"
                headerCell13.BackColor = Drawing.Color.Maroon
                headerCell14.ColumnSpan = 2
                headerCell14.Text = "TOTAL"
                headerCell14.BackColor = Drawing.Color.Maroon

                Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
                rowHeader2.Cells.Add(headerCell11)
                rowHeader2.Cells.Add(headerCell12)
                rowHeader2.Cells.Add(headerCell13)
                rowHeader2.Cells.Add(headerCell14)
                rowHeader2.ForeColor = Drawing.Color.White
                rowHeader2.HorizontalAlign = HorizontalAlign.Center
                rowHeader2.Visible = True
                rowHeader2.Font.Bold = True

                gvdetalle.Controls(0).Controls.AddAt(1, rowHeader2)
            End If

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim rowFooter1 As GridViewRow = New GridViewRow(0, 1, DataControlRowType.Footer, DataControlRowState.Normal)
            Dim footerCell0 As TableCell = New TableCell()
            Dim footerCell1 As TableCell = New TableCell()
            Dim footerCell2 As TableCell = New TableCell()
            Dim footerCell3 As TableCell = New TableCell()
            Dim footerCell4 As TableCell = New TableCell()
            Dim footerCell5 As TableCell = New TableCell()
            Dim footerCell6 As TableCell = New TableCell()

            footerCell0.ColumnSpan = 1
            footerCell0.Text = "TOTAL"
            footerCell0.BackColor = Drawing.Color.LightGray

            Dim suma1 As Integer = 0
            Dim suma2 As Integer = 0
            Dim suma3 As Integer = 0
            Dim suma4 As Integer = 0
            Dim suma5 As Integer = 0
            Dim suma6 As Integer = 0
            For i = 0 To Me.gvdetalle.Rows.Count - 1
                suma1 = suma1 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(1).Text = "", 0, Me.gvdetalle.Rows(i).Cells(1).Text))
                suma2 = suma2 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(2).Text = "", 0, Me.gvdetalle.Rows(i).Cells(2).Text))
                suma3 = suma3 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(3).Text = "", 0, Me.gvdetalle.Rows(i).Cells(3).Text))
                suma4 = suma4 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(4).Text = "", 0, Me.gvdetalle.Rows(i).Cells(4).Text))
                suma5 = suma5 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(5).Text = "", 0, Me.gvdetalle.Rows(i).Cells(5).Text))
                suma6 = suma6 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(6).Text = "", 0, Me.gvdetalle.Rows(i).Cells(6).Text))
            Next
            footerCell1.Text = suma1.ToString
            footerCell1.BackColor = Drawing.Color.LightGray
            footerCell2.Text = suma2.ToString
            footerCell2.BackColor = Drawing.Color.LightGray
            footerCell3.Text = suma3.ToString
            footerCell3.BackColor = Drawing.Color.LightGray
            footerCell4.Text = suma4.ToString
            footerCell4.BackColor = Drawing.Color.LightGray
            footerCell5.Text = suma5.ToString
            footerCell5.BackColor = Drawing.Color.LightGray
            footerCell6.Text = suma6.ToString
            footerCell6.BackColor = Drawing.Color.LightGray

            rowFooter1.Cells.Add(footerCell0)
            rowFooter1.Cells.Add(footerCell1)
            rowFooter1.Cells.Add(footerCell2)
            rowFooter1.Cells.Add(footerCell3)
            rowFooter1.Cells.Add(footerCell4)
            rowFooter1.Cells.Add(footerCell5)
            rowFooter1.Cells.Add(footerCell6)
            If feet = 1 Then
                gvdetalle.Controls(0).Controls.Add(rowFooter1)
            End If
            feet += 1
        End If
    End Sub
    Public Sub gvdetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For index = 0 To e.Row.Cells.Count - 1
                If gvdetalle.HeaderRow.Cells(index).Text = "Fecha" Then
                    If e.Row.Cells(index).Text <> "" Then
                        e.Row.Cells(index).Text = String.Format("{0:d}", CType(e.Row.Cells(index).Text, Date))
                    End If
                End If
            Next
        End If
    End Sub
    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        Call MOSTRAR(Me.gvdetalle)
    End Sub
    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If txtfechadesde.Text.Trim() = "" Then
            lbldesde.Visible = True
            lbldesde.Text = "ingrese una fecha"
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            lblhasta.Visible = True
            lblhasta.Text = "ingrese una fecha"
            Exit Sub
        Else
            lblhasta.Visible = False
        End If

        Dim cadena As String = ""
        Dim Suc As String = Me.ddltiendas.SelectedItem.Text
        cadena = "VistaImpresionIncremento.aspx?&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Sucursal=" & Suc
        Response.Redirect("VistaImpresionIncremento.aspx?&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Sucursal=" & Suc)

    End Sub

    Sub MostrarDatos()

        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))


            Me.gvdetalle.Visible = True
            Call HabilitarTodos(True)
            Me.BtnExporarExcel.Visible = True
            dts.Clear()
            dts = menus.sp_get_incrementoPorRypleymatico(Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + ddltiendas.SelectedItem.Value

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
    End Sub
    Private Function ObtenerHabilitados(ByVal dt As DataTable) As DataTable
        Dim dtTempTienda As New DataTable

        dtTempTienda.Columns.Add("ID")
        dtTempTienda.Columns.Add("CIUDAD")
        dtTempTienda.Columns.Add("SUCURSAL")
        dtTempTienda.Columns.Add("IdUbigeo")
        dtTempTienda.Columns.Add("esttienda")
        dtTempTienda.Columns.Add("direccion")
        dtTempTienda.Columns.Add("Ubicacion")
        dtTempTienda.Columns.Add("Estado")
        dtTempTienda.Columns.Add("ID1")

        For Each item As DataRow In dt.Rows
            If item("Estado") = "Habilitada" Then
                Dim arrTemp(8) As String
                arrTemp(0) = item(0).ToString()
                arrTemp(1) = item(1).ToString()
                arrTemp(2) = item(2).ToString()
                arrTemp(3) = item(3).ToString()
                arrTemp(4) = item(4).ToString()
                arrTemp(5) = item(5).ToString()
                arrTemp(6) = item(6).ToString()
                arrTemp(7) = item(7).ToString()
                arrTemp(8) = item(7).ToString()
                dtTempTienda.Rows.Add(arrTemp)
            End If
        Next
        Return dtTempTienda
    End Function
End Class
