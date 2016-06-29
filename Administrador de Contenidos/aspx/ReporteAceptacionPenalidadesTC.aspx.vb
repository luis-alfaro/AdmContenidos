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

Partial Class aspx_ReporteAceptacionPenalidadesTC
    Inherits System.Web.UI.Page

    Dim menus As New ClsReportes
    Dim pagina As Integer
    Dim paginaActual As Integer = 1
    Dim totalPaginas As Integer
    Dim totalRegistros As Integer
    Dim nroRegistros As Double = 20
    Dim tiend As New tiendas

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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

    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        If txtfechadesde.Text.Trim() = "" Then
            lblError.Text = "ingrese un rango de fechas"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            HabilitarTodos(False)
            Exit Sub
        Else
            lbldesde.Visible = False
        End If

        If txtfechahasta.Text.Trim() = "" Then
            lblError.Text = "ingrese un rango de fechas"
            Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            HabilitarTodos(False)
            Exit Sub
        Else
            lblhasta.Visible = False
        End If
        Call ContarDatos()
        Call MostrarDatos(paginaActual)
    End Sub

    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.BtnExporarExcel.Visible = valor
        Me.BtnExporarTodoExcel.Visible = valor
        Me.tblPaginacion.Visible = valor        
    End Sub


    Sub ContarDatos()

        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim nro_dni As String

            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))

            totalRegistros = menus.Usp_get_Count_ConsultaAceptacionTC(TipoList.SelectedValue, f1, f2)
            totalPaginas = Math.Ceiling(totalRegistros / nroRegistros)

            Me.lblTotal.Text = totalRegistros.ToString()
            Me.txtTotalPaginas.Text = totalPaginas.ToString()
        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + totalRegistros.ToString()

        End Try
    End Sub

    Sub MostrarDatos(ByVal page As Integer)
        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            Dim tipo As String = TipoList.SelectedValue
            Dim canal As String = TipoCanal.SelectedItem.ToString

            Me.gvdetalle.Visible = True

            dts.Clear()
            dts = menus.sp_get_ConsultaAceptacionTC(tipo, f1, f2, canal, nroRegistros, page)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
                Me.txtPagina.Text = paginaActual.ToString()
                Me.txtPaginaActual.Value = paginaActual.ToString()
                Call HabilitarTodos(True)
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
                Call HabilitarTodos(False)
            End If

        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace

        End Try
    End Sub
    
    Protected Sub BtnExporarExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExporarExcel.Click
        exportarExcel(CInt(txtPaginaActual.Value))
    End Sub

    Protected Sub BtnExporarTodoExcel_Click(sender As Object, e As System.EventArgs) Handles BtnExporarTodoExcel.Click
        exportarExcel(0)
    End Sub

    Public Sub exportarExcel(ByVal pagina As Integer)
        Try
            Response.Clear()
            Response.Buffer = True

            Response.AddHeader("content-disposition", "attachment;filename=ReporteAceptacionPenalidadesTC.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"

            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            gvdetalle.AllowPaging = False
            MostrarDatos(pagina)
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
        Catch ex As Exception

        End Try
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'Confirms that an HtmlForm control Is rendered for the specified ASP.NET Server control at run time.
    End Sub

    Protected Sub btnSalir_Click(sender As Object, e As System.EventArgs) Handles btnSalir.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As System.EventArgs) Handles btnNext.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            paginaActual = CInt(txtPaginaActual.Value)
            If paginaActual < totalPaginas Then
                paginaActual += 1
                MostrarDatos(paginaActual)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As System.EventArgs) Handles btnPrev.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            paginaActual = CInt(txtPaginaActual.Value)
            If paginaActual > 1 Then
                paginaActual -= 1
                MostrarDatos(paginaActual)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGo_Click(sender As Object, e As System.EventArgs) Handles btnGo.Click
        Try
            totalPaginas = CInt(txtTotalPaginas.Text)
            Dim pag As Integer = CInt(txtPagina.Text)
            If pag <= totalPaginas And pag >= 1 Then
                paginaActual = pag
                MostrarDatos(paginaActual)
            Else
                lblError.Text = "La página actual no puede ser cero o mayor al número total de páginas."
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
