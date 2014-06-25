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
Imports UtilitarioEnvioData

Partial Class aspx_ReporteEstadisticoAceptacionSEF
    Inherits System.Web.UI.Page

    Public tienda As New tiendas : Dim menus As New ClsReportes
    Public idtienda As String : Dim feet As Integer = 0
    Public Shared existenRegistros As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
                idtienda = IIf(Request.QueryString("idtienda") Is Nothing, "1", Request.QueryString("idtienda"))
                Me.hddtienda.Value = idtienda

                Dim dt As DataTable = New DataTable("consulta")
                dt.Columns.Add(New DataColumn("id", GetType(Integer)))
                dt.Columns.Add(New DataColumn("nombre", GetType(String)))
                Dim dr As DataRow = dt.NewRow()
                dr("id") = 1
                dr("nombre") = "Por Fecha"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("id") = 2
                dr("nombre") = "Por Mes"
                dt.Rows.Add(dr)


                Me.ddltiendas.DataSource = dt
                Me.ddltiendas.DataTextField = "nombre"
                Me.ddltiendas.DataValueField = "id"
                Me.ddltiendas.DataBind()
                gvdetalle.Attributes.Add("style", "table-layout:fixed")
                Call HabilitarTodos(False)

                'Dim dst As DataSet = New DataSet
                'dst = EnvioData.EnvioData.Instancia.CONSULTA_PRESTAMO_EFECTIVO()
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
        feet = 0
        Call MostrarDatos()

    End Sub
    Public Sub gvdetalle_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowCreated
        If existenRegistros Then

            If e.Row.RowType = DataControlRowType.Header Then
                If gvdetalle.Controls(0).Controls.Count < 2 Then
                    Dim headerCell1 As TableCell = New TableCell()
                    headerCell1.ColumnSpan = 13
                    headerCell1.Text = "ESTADISTICA DE DESEMBOLSO DE SUPER EFECTIVO"
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
                    Dim headerCell15 As TableCell = New TableCell()
                    headerCell11.ColumnSpan = 1
                    headerCell11.ForeColor = Drawing.Color.Maroon
                    headerCell11.Text = "SUPEREFECTIVO"
                    headerCell11.BackColor = Drawing.Color.Maroon
                    headerCell12.ColumnSpan = 3
                    headerCell12.Text = "CAJA"
                    headerCell12.BackColor = Drawing.Color.Maroon
                    headerCell13.ColumnSpan = 3
                    headerCell13.Text = "RIPLEYMATICO"
                    headerCell13.BackColor = Drawing.Color.Maroon
                    headerCell14.ColumnSpan = 3
                    headerCell14.Text = "OTROS"
                    headerCell14.BackColor = Drawing.Color.Maroon
                    headerCell15.ColumnSpan = 3
                    headerCell15.Text = "TOTAL"
                    headerCell15.BackColor = Drawing.Color.Maroon

                    Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
                    rowHeader2.Cells.Add(headerCell11)
                    rowHeader2.Cells.Add(headerCell12)
                    rowHeader2.Cells.Add(headerCell13)
                    rowHeader2.Cells.Add(headerCell14)
                    rowHeader2.Cells.Add(headerCell15)
                    rowHeader2.ForeColor = Drawing.Color.White
                    rowHeader2.HorizontalAlign = HorizontalAlign.Center
                    rowHeader2.Visible = True
                    rowHeader2.Font.Bold = True

                    gvdetalle.Controls(0).Controls.AddAt(1, rowHeader2)
                End If

            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listFooterCell As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell = New TableCell()

                For index = 0 To 12
                    footerCell = New TableCell()
                    listFooterCell.Add(footerCell)
                Next
                listFooterCell(0).ColumnSpan = 1
                listFooterCell(0).Text = "TOTAL"
                listFooterCell(0).BackColor = Drawing.Color.LightGray

                'Dim footerCell0 As TableCell = New TableCell()
                'Dim footerCell1 As TableCell = New TableCell()
                'Dim footerCell2 As TableCell = New TableCell()
                'Dim footerCell3 As TableCell = New TableCell()
                'Dim footerCell4 As TableCell = New TableCell()
                'Dim footerCell5 As TableCell = New TableCell()
                'Dim footerCell6 As TableCell = New TableCell()
                'Dim footerCell7 As TableCell = New TableCell()
                'Dim footerCell8 As TableCell = New TableCell()
                'Dim footerCell9 As TableCell = New TableCell()
                'Dim footerCell10 As TableCell = New TableCell()
                'Dim footerCell11 As TableCell = New TableCell()
                'Dim footerCell12 As TableCell = New TableCell()

                'footerCell0.ColumnSpan = 1
                'footerCell0.Text = "TOTAL"
                'footerCell0.BackColor = Drawing.Color.LightGray
                Dim listSumas As List(Of Decimal) = New List(Of Decimal)
                For index = 0 To 12 - 1
                    listSumas.Add(0)
                Next

                'Dim suma1 As Integer = 0
                'Dim suma2 As Integer = 0
                'Dim suma3 As Integer = 0
                'Dim suma4 As Integer = 0
                'Dim suma5 As Integer = 0
                'Dim suma6 As Integer = 0
                'Dim suma7 As Integer = 0
                'Dim suma8 As Integer = 0
                'Dim suma9 As Integer = 0
                'Dim suma10 As Integer = 0
                'Dim suma11 As Integer = 0
                'Dim suma12 As Integer = 0
                For i = 0 To Me.gvdetalle.Rows.Count - 1

                    For index = 0 To 12 - 1
                        listSumas(index) = listSumas(index) + CInt(IIf(Me.gvdetalle.Rows(i).Cells(index).Text = "", 0, Me.gvdetalle.Rows(i).Cells(index).Text))
                    Next

                    'suma1 = suma1 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(1).Text = "", 0, Me.gvdetalle.Rows(i).Cells(1).Text))
                    'suma2 = suma2 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(2).Text = "", 0, Me.gvdetalle.Rows(i).Cells(2).Text))
                    'suma3 = suma3 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(3).Text = "", 0, Me.gvdetalle.Rows(i).Cells(3).Text))
                    'suma4 = suma4 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(4).Text = "", 0, Me.gvdetalle.Rows(i).Cells(4).Text))
                    'suma5 = suma5 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(5).Text = "", 0, Me.gvdetalle.Rows(i).Cells(5).Text))
                    'suma6 = suma6 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(6).Text = "", 0, Me.gvdetalle.Rows(i).Cells(6).Text))
                    'suma7 = suma7 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(7).Text = "", 0, Me.gvdetalle.Rows(i).Cells(7).Text))
                    'suma8 = suma8 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(8).Text = "", 0, Me.gvdetalle.Rows(i).Cells(8).Text))
                    'suma9 = suma9 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(9).Text = "", 0, Me.gvdetalle.Rows(i).Cells(9).Text))
                    'suma10 = suma10 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(10).Text = "", 0, Me.gvdetalle.Rows(i).Cells(10).Text))
                    'suma11 = suma11 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(11).Text = "", 0, Me.gvdetalle.Rows(i).Cells(11).Text))
                    'suma12 = suma12 + CInt(IIf(Me.gvdetalle.Rows(i).Cells(12).Text = "", 0, Me.gvdetalle.Rows(i).Cells(12).Text))
                Next

                For index = 1 To 12
                    listFooterCell(index).Text = listSumas(index - 1).ToString()
                    listFooterCell(index).HorizontalAlign = HorizontalAlign.Right
                    listFooterCell(index).BackColor = Drawing.Color.LightGray
                Next

                'footerCell1.Text = suma1.ToString
                'footerCell1.HorizontalAlign = HorizontalAlign.Right
                'footerCell1.BackColor = Drawing.Color.LightGray

                'footerCell2.Text = suma2.ToString
                'footerCell2.HorizontalAlign = HorizontalAlign.Right
                'footerCell2.BackColor = Drawing.Color.LightGray
                'footerCell3.Text = suma3.ToString
                'footerCell3.HorizontalAlign = HorizontalAlign.Right
                'footerCell3.BackColor = Drawing.Color.LightGray
                'footerCell4.Text = suma4.ToString
                'footerCell4.HorizontalAlign = HorizontalAlign.Right
                'footerCell4.BackColor = Drawing.Color.LightGray
                'footerCell5.Text = suma5.ToString
                'footerCell5.HorizontalAlign = HorizontalAlign.Right
                'footerCell5.BackColor = Drawing.Color.LightGray
                'footerCell6.Text = suma6.ToString
                'footerCell6.HorizontalAlign = HorizontalAlign.Right
                'footerCell6.BackColor = Drawing.Color.LightGray
                'footerCell7.Text = suma7.ToString
                'footerCell7.HorizontalAlign = HorizontalAlign.Right
                'footerCell7.BackColor = Drawing.Color.LightGray
                'footerCell8.Text = suma8.ToString
                'footerCell8.HorizontalAlign = HorizontalAlign.Right
                'footerCell8.BackColor = Drawing.Color.LightGray
                'footerCell9.Text = suma9.ToString
                'footerCell9.HorizontalAlign = HorizontalAlign.Right
                'footerCell9.BackColor = Drawing.Color.LightGray
                'footerCell10.Text = suma10.ToString
                'footerCell10.HorizontalAlign = HorizontalAlign.Right
                'footerCell10.BackColor = Drawing.Color.LightGray
                'footerCell11.Text = suma11.ToString
                'footerCell11.HorizontalAlign = HorizontalAlign.Right
                'footerCell11.BackColor = Drawing.Color.LightGray
                'footerCell12.Text = suma12.ToString
                'footerCell12.HorizontalAlign = HorizontalAlign.Right
                'footerCell12.BackColor = Drawing.Color.LightGray

                For Each cell As TableCell In listFooterCell
                    rowFooter1.Cells.Add(cell)
                Next
                'rowFooter1.Cells.Add(footerCell0)
                'rowFooter1.Cells.Add(footerCell1)
                'rowFooter1.Cells.Add(footerCell2)
                'rowFooter1.Cells.Add(footerCell3)
                'rowFooter1.Cells.Add(footerCell4)
                'rowFooter1.Cells.Add(footerCell5)
                'rowFooter1.Cells.Add(footerCell6)
                'rowFooter1.Cells.Add(footerCell7)
                'rowFooter1.Cells.Add(footerCell8)
                'rowFooter1.Cells.Add(footerCell9)
                'rowFooter1.Cells.Add(footerCell10)
                'rowFooter1.Cells.Add(footerCell11)
                'rowFooter1.Cells.Add(footerCell12)
                'feet += 1
                If feet = 0 Then
                    gvdetalle.Controls(0).Controls.Add(rowFooter1)
                    feet = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For index = 0 To e.Row.Cells.Count - 1
                If gvdetalle.HeaderRow.Cells(index).Text.Contains("Fecha") Then
                    If e.Row.Cells(index).Text <> "" Then
                        e.Row.Cells(index).Text = String.Format("{0:d}", CType(e.Row.Cells(index).Text, Date))
                    End If
                End If
                e.Row.Cells(index).HorizontalAlign = HorizontalAlign.Right
            Next
        End If
    End Sub
    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        Call exportarExcel()
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
            Dim fini As String : Dim ffin As String
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))

            fini = f1.Year.ToString() + f1.Month.ToString().PadLeft(2, "0") + f1.Day.ToString().PadLeft(2, "0")
            ffin = f2.Year.ToString() + f2.Month.ToString().PadLeft(2, "0") + f2.Day.ToString().PadLeft(2, "0")

            Me.gvdetalle.Visible = True
            Call HabilitarTodos(True)
            Me.BtnExporarExcel.Visible = True
            dts.Clear()
            dts = menus.sp_get_incrementoPorRypleymatico(Me.ddltiendas.SelectedValue, f1, f2)
            dts = EnvioData.EnvioData.Instancia.GET_ESTADISTICA_ACEPTACION_SEF(fini, ffin, Me.ddltiendas.SelectedValue)
            If dts.Tables("consulta").Rows.Count > 0 Then
                existenRegistros = True
                Me.gvdetalle.DataSource = dts
                Me.gvdetalle.DataBind()
            Else
                existenRegistros = False
                Me.gvdetalle.DataSource = menus.MENSAJEGRID
                Me.gvdetalle.DataBind()
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + ddltiendas.SelectedItem.Value

        End Try
    End Sub

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

    Public Sub exportarExcel()
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=ReporteEstadisticoIncremento.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        gvdetalle.AllowPaging = False
        feet = 0
        MostrarDatos()
        'gvdetalle.DataBind()

        'Ponemos toda la fila en blanco y cambiamos el color solo de las celdas de la cabecera.
        'Cambia el color de fondo de la cabecera a blanco.
        gvdetalle.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Ponemos el color de cada celda al color que tenemos en el gridview.
        For Each hcell As TableCell In gvdetalle.HeaderRow.Cells
            hcell.Style.Add("background-color", "#6B696B")
        Next

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

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
