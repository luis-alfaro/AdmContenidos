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
End Class
