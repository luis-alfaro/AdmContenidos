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

Partial Class aspx_ReporteConsultasRipleymatico
    Inherits System.Web.UI.Page

    Dim menus As New ClsReportes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
                Dim ds As New DataSet
                gvdetalle.Attributes.Add("style", "table-layout:fixed")
                Dim menus As New ClsReportes
                Dim tipos As New DataSet


                Dim dt As DataTable = Sql_Get_OpcionesMenu()


                cblopciones.Items.Clear()
                cblopciones.DataSource = Nothing
                cblopciones.DataSource = dt
                cblopciones.DataTextField = "CAMPO"
                cblopciones.DataValueField = "ID"
                cblopciones.DataBind()
                
                Call HabilitarTodos(False)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If txtfechadesde.Text.Trim() = "" Then
            'lbldesde.Visible = True
            'lbldesde.Text = "ingrese una fecha"
            lblError.Text = "ingrese un rango de fechas"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            HabilitarTodos(False)
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            'lblhasta.Visible = True
            'lblhasta.Text = "ingrese una fecha"
            lblError.Text = "ingrese un rango de fechas"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            HabilitarTodos(False)
            Exit Sub
        Else
            lblhasta.Visible = False
        End If

        Call MostrarDatos()

    End Sub

    Public Sub gvdetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For index = 0 To e.Row.Cells.Count - 1
                'If gvdetalle.HeaderRow.Cells(index).Text = "Fecha" Or gvdetalle.HeaderRow.Cells(index).Text = "Inicio Vigencia" Or gvdetalle.HeaderRow.Cells(index).Text = "Fin Vigencia" Then
                '    If e.Row.Cells(index).Text.Contains("/") Then
                '        e.Row.Cells(index).Text = String.Format("{0:d}", CType(e.Row.Cells(index).Text, Date))
                '    End If
                'End If
                If gvdetalle.HeaderRow.Cells(index).Text = "ID_KIOSKO" Then
                    gvdetalle.HeaderRow.Cells(index).Visible = False
                    e.Row.Cells(index).Visible = False
                End If
            Next
        End If
    End Sub


    Sub MostrarDatos()
        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim ids As String = ""
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))

            For Each itm As ListItem In cblopciones.Items
                If (itm.Selected) Then
                    ids = ids + "," + itm.Value
                End If
            Next
            ids = ids.Substring(1, ids.Length - 1)

            Me.gvdetalle.Visible = True

            dts.Clear()
            dts = menus.sp_get_ObtenerConsolidadoConsultasRipleymatico(f1, f2, ids)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
                Call HabilitarTodos(True)
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
                Call HabilitarTodos(False)
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace

        End Try
    End Sub

    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.BtnExporarExcel.Visible = valor
    End Sub


    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        exportarExcel()
    End Sub


    Public Sub exportarExcel()
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=ReporteConsultasRipleymatico.xls")
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
