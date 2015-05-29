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
                Dim menus As New ClsReportes
                Dim tipos As New DataSet
                tipos = menus.listar_TipoSistemaTarjeta()
                Me.ddltipo.DataSource = tipos.Tables(0).DefaultView.ToTable()
                Me.ddltipo.DataTextField = "TIPO"
                Me.ddltipo.DataValueField = "ID"
                Me.ddltipo.DataBind()

                'Dim dt As DataTable = New DataTable("consulta")
                'dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
                'dt.Columns.Add(New DataColumn("TIPO", GetType(String)))
                'Dim dr As DataRow = dt.NewRow()
                'dr("ID") = 1
                'dr("TIPO") = "Ripleymatico"
                'dt.Rows.Add(dr)
                'dr = dt.NewRow()
                'dr("ID") = 2
                'dr("TIPO") = "Plataforma"
                'dt.Rows.Add(dr)
                'dr = dt.NewRow()
                'dr("ID") = 3
                'dr("TIPO") = "Cajero"
                'dt.Rows.Add(dr)
                'Me.ddlCanal.DataSource = tipos.Tables(0).DefaultView.ToTable()
                'Me.ddlCanal.DataTextField = "TIPO"
                'Me.ddlCanal.DataValueField = "ID"
                'Me.ddlCanal.DataBind()

                Dim dt As DataTable
                dt = menus.listartabla("TipoCanal").Tables("Consulta")
                Dim dr As DataRow = dt.NewRow()
                dr("codigo") = 0
                dr("denominacion") = "--Seleccionar--"
                dt.Rows.InsertAt(dr, 0)

                Me.ddlCanal.DataSource = dt
                Me.ddlCanal.DataTextField = "denominacion"
                Me.ddlCanal.DataValueField = "codigo"
                Me.ddlCanal.DataBind()

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

    Sub MostrarDatos(ByVal page As Integer)
        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim tipo As String : Dim nro As Integer : Dim canal As String
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            nro = ddltipo.SelectedIndex
            If nro = 0 Then
                tipo = ""
            Else
                tipo = ddltipo.SelectedItem.ToString()
            End If

            nro = ddlCanal.SelectedIndex
            If nro = 0 Then
                canal = ""
            Else
                canal = ddlCanal.SelectedItem.ToString().Substring(0, 1)
            End If
            Me.gvdetalle.Visible = True

            dts.Clear()
            dts = menus.sp_get_ConsultaAceptacionIncremento(tipo, canal, f1, f2, nroRegistros, page)
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
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + ddltipo.SelectedValue

        End Try
    End Sub

    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.BtnExporarExcel.Visible = valor
        Me.BtnExporarTodoExcel.Visible = valor
        Me.tblPaginacion.Visible = valor
    End Sub

    Sub ContarDatos()

        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            Dim tipo As String : Dim nro As Integer : Dim canal As String
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))
            nro = ddltipo.SelectedIndex
            If nro = 0 Then
                tipo = ""
            Else
                tipo = ddltipo.SelectedItem.ToString()
            End If
            nro = ddlCanal.SelectedIndex
            If nro = 0 Then
                canal = ""
            Else
                canal = ddlCanal.SelectedItem.ToString().Substring(0, 1)
            End If


            totalRegistros = menus.Usp_get_Count_ConsultaAceptacionIncremento(tipo, canal, f1, f2)
            totalPaginas = totalRegistros / nroRegistros
            If totalRegistros Mod nroRegistros > 0 Then
                totalPaginas += 1
            End If

            Me.lblTotal.Text = totalRegistros.ToString()
            Me.txtTotalPaginas.Text = totalPaginas.ToString()
        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + totalRegistros.ToString()

        End Try
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
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

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
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

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
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

    Protected Sub BtnExporarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarExcel.Click
        exportarExcel(CInt(txtPaginaActual.Value))
    End Sub

    Protected Sub BtnExporarTodoExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExporarTodoExcel.Click
        exportarExcel(0)
    End Sub


    Public Sub exportarExcel(ByVal pagina As Integer)
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=ReporteAceptacionIncremento.xls")
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
