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
'Imports System.IO.StreamWriter

Partial Class ReporteEstadisticos
    Inherits System.Web.UI.Page
    Public cadena As String
    Public funciones_otras As New Ubigeo : Public nodo As TreeNode:Public ConsultaGrillaGeneral As String : Dim campos As String : Public ConsultaGrillaDetalle As String
    Public tienda As New tiendas : Dim menus As New ClsReportes : Public cd, A As String : Public strSQL, strsql2 As String
    Public tabla, TABLA2 As String : Public funciones As New Funciones_Conexion : Dim rp As Integer = 0 : Dim sms As String = "" : Dim kiosko As New kioskos
    Public tABLADETALLE As String : Public s As String : Public nombre As String : Public idtienda As String
    Public ss As String = "" : Public sumadetalle As String : Public COD As Integer : Public c1 As String = "" : Public c2 As String = ""

    Dim feet0 As Integer = 0
    Dim feetClasicaChip As Integer = 0
    Dim feet1 As Integer = 0
    Dim feet2 As Integer = 0
    Dim feet3 As Integer = 0
    Dim feet4 As Integer = 0
    Dim feet5 As Integer = 0
    Dim feetClasicaChipDetalle As Integer = 0
    Dim feet6 As Integer = 0
    Dim feet7 As Integer = 0
    Dim feet8 As Integer = 0
    Dim feet9 As Integer = 0
    Public Shared existenRegistrosClasicaChip As Boolean = True
    Public Shared existenRegistrosClasicaChipDetalle As Boolean = True
    Public Shared existenRegistros0 As Boolean = True
    Public Shared existenRegistros1 As Boolean = True
    Public Shared existenRegistros2 As Boolean = True
    Public Shared existenRegistros3 As Boolean = True
    Public Shared existenRegistros4 As Boolean = True
    Public Shared existenRegistros5 As Boolean = True
    Public Shared existenRegistros6 As Boolean = True
    Public Shared existenRegistros7 As Boolean = True
    Public Shared existenRegistros8 As Boolean = True
    Public Shared existenRegistros9 As Boolean = True

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
                Me.ddltiporeporte.DataSource = menus.listartabla("TipoReporte")
                Me.ddltiporeporte.DataTextField = "denominacion"
                Me.ddltiporeporte.DataValueField = "codigo"
                Me.ddltiporeporte.DataBind()
                GridView1.Attributes.Add("style", "table-layout:fixed")
                Call HabilitarTodos(False)
                'Call Crear()
                If idtienda > 0 Then
                    'Call MostrarDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
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


        Dim rep As String = ""
        rep = Microsoft.VisualBasic.Trim(Me.ddltiporeporte.SelectedItem.Text)
        Dim Suc As String = Me.ddltiendas.SelectedItem.Text
        Call MostrarDatos()
        cadena = "VistaImpresion.aspx?tiporeporte=" & Me.ddltiporeporte.SelectedValue & "&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Reporte=" & rep & "&Sucursal=" & Suc
    End Sub

    Sub MostrarDatos()
        IniciarVariables()
        Dim dts As New DataSet

        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))

            If Me.ddltiendas.SelectedValue = 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 1 Then
                Call HabilitarTodos(True)
                Me.grdClasicaChip.Visible = True : Me.GridView4.Visible = True : Me.GridView5.Visible = True
                Me.gvdetalle.Visible = False : Me.grdClasicaChipDetalle.Visible = False : Me.gvdetalle2.Visible = False : Me.gvdetalle3.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
                Me.Button13.Visible = False : Me.btnClasicaChipDetalle.Visible = False : Me.Button14.Visible = False : Me.Button15.Visible = False : Me.Button16.Visible = False : Me.Button17.Visible = False

                'Mostrar Todo Reporte:Producto
                '/*GridView1--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros0 = True
                    Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
                Else
                    existenRegistros0 = False
                    Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*grdClasicaChip--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "7", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistrosClasicaChip = True
                    Me.grdClasicaChip.DataSource = dts : Me.grdClasicaChip.DataBind()
                Else
                    existenRegistrosClasicaChip = False
                    Me.grdClasicaChip.DataSource = menus.MENSAJEGRID : Me.grdClasicaChip.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView2--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros1 = True
                    Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
                Else
                    existenRegistros1 = False
                    Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView3--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros2 = True
                    Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
                Else
                    existenRegistros2 = False
                    Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView4--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros3 = True
                    Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
                Else
                    existenRegistros3 = False
                    Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView5--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros4 = True
                    Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
                Else
                    existenRegistros4 = False
                    Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
            ElseIf Me.ddltiendas.SelectedValue = 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 2 Then
                '/*Mostrar Todo Reporte Marcas*/
                Call HabilitarTodos(False)
                Me.GridView2.Visible = True : Me.GridView3.Visible = True
                Me.Button8.Visible = True : Me.Button9.Visible = True : Me.Button10.Visible = True
                Me.grdClasicaChip.Visible = False : Me.GridView4.Visible = False : Me.GridView5.Visible = False
                Me.gvdetalle.Visible = False : Me.grdClasicaChipDetalle.Visible = False : Me.gvdetalle2.Visible = False : Me.gvdetalle3.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False

                '/*GridView1--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros0 = True
                    Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
                Else
                    existenRegistros0 = False
                    Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
                '/*GridView2-----agrupar las tarjetas---------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros1 = True
                    Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
                Else
                    existenRegistros1 = False
                    Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
                '/*GridView3--------------------------------------------------------------*/
                'lblError.Text = "1-2-3-" + Me.ddltiendas.SelectedValue + " - " + f1 + " - " + f2
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros2 = True
                    Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
                Else
                    existenRegistros2 = False
                    Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
            ElseIf Me.ddltiendas.SelectedValue > 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 1 Then
                Call HabilitarTodos(True)
                Me.grdClasicaChip.Visible = True : Me.GridView4.Visible = True : Me.GridView5.Visible = True
                Me.gvdetalle.Visible = True : Me.grdClasicaChipDetalle.Visible = True : Me.gvdetalle2.Visible = True : Me.gvdetalle3.Visible = True : Me.gvdetalle4.Visible = True : Me.gvdetalle5.Visible = True

                'Mostrar Todo Reporte:Producto
                '/*GridView1--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros0 = True
                    Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
                Else
                    existenRegistros0 = False
                    Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*grdClasicaChip--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "7", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistrosClasicaChip = True
                    Me.grdClasicaChip.DataSource = dts : Me.grdClasicaChip.DataBind()
                Else
                    existenRegistrosClasicaChip = False
                    Me.grdClasicaChip.DataSource = menus.MENSAJEGRID : Me.grdClasicaChip.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView2--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros1 = True
                    Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
                Else
                    existenRegistros1 = False
                    Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView3--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros2 = True
                    Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
                Else
                    existenRegistros2 = False
                    Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView4--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros3 = True
                    Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
                Else
                    existenRegistros3 = False
                    Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView5--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros4 = True
                    Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
                Else
                    existenRegistros4 = False
                    Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
                End If
                '/*----------------------------------------------------------------------*/


                '/*gvdetalle--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros5 = True
                    Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
                Else
                    existenRegistros5 = False
                    Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*grdClasicaChipDetalle--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "7", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros5 = True
                    Me.grdClasicaChipDetalle.DataSource = dts : Me.grdClasicaChipDetalle.DataBind()
                Else
                    existenRegistros5 = False
                    Me.grdClasicaChipDetalle.DataSource = menus.MENSAJEGRID : Me.grdClasicaChipDetalle.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle2--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros6 = True
                    Me.gvdetalle2.DataSource = dts : Me.gvdetalle2.DataBind()
                Else
                    existenRegistros6 = False
                    Me.gvdetalle2.DataSource = menus.MENSAJEGRID : Me.gvdetalle2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle3--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros7 = True
                    Me.gvdetalle3.DataSource = dts : Me.gvdetalle3.DataBind()
                Else
                    existenRegistros7 = False
                    Me.gvdetalle3.DataSource = menus.MENSAJEGRID : Me.gvdetalle3.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle4--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros8 = True
                    Me.gvdetalle4.DataSource = dts : Me.gvdetalle4.DataBind()
                Else
                    existenRegistros8 = False
                    Me.gvdetalle4.DataSource = menus.MENSAJEGRID : Me.gvdetalle4.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle5--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros9 = True
                    Me.gvdetalle5.DataSource = dts : Me.gvdetalle5.DataBind()
                Else
                    existenRegistros9 = False
                    Me.gvdetalle5.DataSource = menus.MENSAJEGRID : Me.gvdetalle5.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
            ElseIf Me.ddltiendas.SelectedValue > 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 2 Then
                '/*Mostrar Todo Reporte Marcas*/
                Call HabilitarTodos(True)
                Me.grdClasicaChip.Visible = False : Me.GridView4.Visible = False : Me.GridView5.Visible = False
                Me.btnClasicaChip.Visible = False : Me.Button11.Visible = False : Me.Button12.Visible = False
                Me.gvdetalle.Visible = True : Me.gvdetalle2.Visible = True : Me.gvdetalle3.Visible = True
                Me.grdClasicaChipDetalle.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
                Me.btnClasicaChipDetalle.Visible = False : Me.Button16.Visible = False : Me.Button17.Visible = False

                '/*GridView1--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros0 = True
                    Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
                Else
                    existenRegistros0 = False
                    Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView2--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros1 = True
                    Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
                Else
                    existenRegistros1 = False
                    Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*GridView3--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("1", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros2 = True
                    Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
                Else
                    existenRegistros2 = False
                    Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
                End If
                '/*-----------------------------------------------------------------------*/

                '/*gvdetalle----TAMBIEN SUMAR TODAS LAS TARJETAS----------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros5 = True
                    Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
                Else
                    existenRegistros5 = False
                    Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle2--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros6 = True
                    Me.gvdetalle2.DataSource = dts : Me.gvdetalle2.DataBind()
                Else
                    existenRegistros6 = False
                    Me.gvdetalle2.DataSource = menus.MENSAJEGRID : Me.gvdetalle2.DataBind()
                End If
                '/*----------------------------------------------------------------------*/

                '/*gvdetalle3--------------------------------------------------------------*/
                dts.Clear()
                dts = menus.sp_contar_consultas("2", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros7 = True
                    Me.gvdetalle3.DataSource = dts : Me.gvdetalle3.DataBind()
                Else
                    existenRegistros7 = True
                    Me.gvdetalle3.DataSource = menus.MENSAJEGRID : Me.gvdetalle3.DataBind()
                End If
                '/*----------------------------------------------------------------------*/
            End If
            If Me.ddltiporeporte.SelectedValue = 3 Then
                Call HabilitarTodos(False)
                Me.grdClasicaChip.Visible = False : Me.GridView4.Visible = False : Me.GridView5.Visible = False
                Me.gvdetalle.Visible = False : Me.grdClasicaChipDetalle.Visible = False : Me.gvdetalle2.Visible = False : Me.gvdetalle3.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
                'Mostrar Todo Reporte:Producto
                '/*GridView1--------------------------------------------------------------*/
                dts.Clear()
                Dim entero As String
                If Me.ddltiendas.SelectedValue > 0 Then
                    entero = "2"
                Else
                    entero = "1"
                End If
                dts = menus.sp_contar_consultas(entero, "3", "1", Me.ddltiendas.SelectedValue, f1, f2)
                If dts.Tables("consulta").Rows.Count > 0 Then
                    existenRegistros0 = True
                    Me.GridView1.DataSource = dts : Me.GridView1.DataBind()

                Else
                    existenRegistros0 = False
                    Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace + "/" + ddltiendas.SelectedItem.Value + "-" + ddltiporeporte.SelectedItem.Value

        End Try
    End Sub

    'Private Sub ExportToExcel2(ByVal nameReport As String, ByVal wControl As GridView)
    '    Try
    '        Dim responsePage As HttpResponse = Response
    '        Dim sw As New StringWriter()
    '        Dim htw As New HtmlTextWriter(sw)
    '        Dim pageToRender As New Page()
    '        Dim form As New HtmlForm()
    '        form.Controls.Add(wControl)
    '        pageToRender.Controls.Add(form)
    '        responsePage.Clear()
    '        responsePage.Buffer = True
    '        responsePage.ContentType = "application/vnd.ms-excel"
    '        responsePage.AddHeader("Content-Disposition", "attachment;filename=" & nameReport)
    '        responsePage.Charset = "UTF-8"
    '        Response.ContentEncoding = Encoding.Default
    '        pageToRender.RenderControl(htw)
    '        responsePage.Write(sw.ToString())
    '        responsePage.End()
    '    Catch ex As Exception
    '        'MsgBox(ex.ToString)
    '    End Try
    'End Sub

    'Public Function ExportToExcel(ByVal wControl As GridView) As String
    '    Dim page1 As New Page
    '    Dim form1 As New HtmlForm
    '    Me.GridView1.EnableViewState = False
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
    '    writer2.Write(vbLf & "</body>" & vbLf & "</html>")
    '    page1.Dispose()
    '    page1 = Nothing
    '    Return builder1.ToString()
    'End Function

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

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Call MOSTRAR(Me.GridView1)
        Call exportarExcel(Me.GridView1)
    End Sub
    Protected Sub btnClasicaChip_Click(sender As Object, e As System.EventArgs) Handles btnClasicaChip.Click
        Call exportarExcel(Me.grdClasicaChip)
    End Sub
    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Call MOSTRAR(Me.GridView2)
        Call exportarExcel(Me.GridView2)
    End Sub
    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Call MOSTRAR(Me.GridView3)
        Call exportarExcel(Me.GridView3)
    End Sub
    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        'Call MOSTRAR(Me.GridView4)
        Call exportarExcel(Me.GridView4)
    End Sub
    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        'Call MOSTRAR(Me.GridView5)
        Call exportarExcel(Me.GridView5)
    End Sub
    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        'Call MOSTRAR(Me.gvdetalle)
        Call exportarExcel(Me.gvdetalle)
    End Sub
    Protected Sub btnClasicaChipDetalle_Click(sender As Object, e As System.EventArgs) Handles btnClasicaChipDetalle.Click
        Call exportarExcel(Me.grdClasicaChipDetalle)
    End Sub
    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        'Call MOSTRAR(Me.gvdetalle2)
        Call exportarExcel(Me.gvdetalle2)
    End Sub
    Protected Sub Button15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button15.Click
        'Call MOSTRAR(Me.gvdetalle3)
        Call exportarExcel(Me.gvdetalle3)
    End Sub
    Protected Sub Button16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button16.Click
        'Call MOSTRAR(Me.gvdetalle4)
        Call exportarExcel(Me.gvdetalle4)
    End Sub
    Protected Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        'Call MOSTRAR(Me.gvdetalle5)
        Call exportarExcel(Me.gvdetalle5)
    End Sub


    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
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

        Dim rep As String = ""
        rep = Microsoft.VisualBasic.Trim(Me.ddltiporeporte.SelectedItem.Text)
        Dim Suc As String = Me.ddltiendas.SelectedItem.Text
        'Dim Fechas As String = "Desde el: " & Me.txtfechadesde.Text & " al"
        cadena = "VistaImpresion.aspx?tiporeporte=" & Me.ddltiporeporte.SelectedValue & "&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Reporte=" & rep & "&Sucursal=" & Suc
        Response.Redirect("VistaImpresion.aspx?tiporeporte=" & Me.ddltiporeporte.SelectedValue & "&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Reporte=" & rep & "&Sucursal=" & Suc)
        'Dim sb As New StringBuilder()
        'Dim salida As New System.IO.StringWriter(sb)
        'Dim htw As New HtmlTextWriter(salida)
        'Dim pag As New Page()
        'Dim form As New HtmlForm()
        'Me.GridView1.EnableViewState = False
        'pag.EnableEventValidation = False
        'pag.DesignerInitialize()
        'pag.Controls.Add(form)
        'form.Controls.Add(Me.GridView1)
        'form.Controls.Add(Me.GridView2)
        'form.Controls.Add(Me.GridView3)
        'form.Controls.Add(Me.GridView4)
        'pag.RenderControl(htw)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/text/HTML"
        'Response.AddHeader("Content-Type", "text/html")
        'Response.Charset = "MS-Windows"
        'Response.ContentEncoding = Encoding.Default
        'Response.Write("<script language='JavaScript'>window.open('VistaImpresion.aspx?tiporeporte=" & Me.ddltiporeporte.SelectedValue & "&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "')</script>" + sb.ToString())
        'Response.End()
    End Sub
    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.GridView2.Visible = valor
        Me.GridView3.Visible = valor
        'Me.Button7.Visible = valor
        Me.Button8.Visible = valor
        Me.btnClasicaChip.Visible = valor
        Me.Button9.Visible = valor
        Me.Button10.Visible = valor
        Me.Button11.Visible = valor
        Me.Button12.Visible = valor
        Me.Button13.Visible = valor
        Me.btnClasicaChipDetalle.Visible = valor
        Me.Button14.Visible = valor
        Me.Button15.Visible = valor
        Me.Button16.Visible = valor
        Me.Button17.Visible = valor

    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception
        End Try
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

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' No borrar, esto verifica si el control(gridview) se ha renderizado antes de exportar a excel
    End Sub
    Public Sub exportarExcel(ByVal wControl As GridView)
        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=ReporteEstadistico.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        wControl.AllowPaging = False
        Call IniciarVariables()
        MostrarDatos()
        'gvdetalle.DataBind()

        'Ponemos toda la fila en blanco y cambiamos el color solo de las celdas de la cabecera.
        'Cambia el color de fondo de la cabecera a blanco.
        wControl.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'Ponemos el color de cada celda al color que tenemos en el gridview.
        For Each hcell As TableCell In wControl.HeaderRow.Cells
            hcell.Style.Add("background-color", "#6B696B")
        Next

        For Each row As GridViewRow In wControl.Rows
            row.BackColor = System.Drawing.Color.White
            For Each cell As TableCell In row.Cells
                cell.Attributes.Add("class", "textmode")
            Next
        Next

        wControl.RenderControl(hw)

        'cambiamos el formato de las celdas, ya que el numero de tarjeta es largo y en excel se muestra como expotencial
        ' de igual manera los DNIs pueden empezar con 0(cero) y sin cambiar formato no se mostraría
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    Public Sub IniciarVariables()
        feet0 = 0
        feetClasicaChip = 0
        feet1 = 0
        feet2 = 0
        feet3 = 0
        feet4 = 0
        feet5 = 0
        feetClasicaChipDetalle = 0
        feet6 = 0
        feet7 = 0
        feet8 = 0
        feet9 = 0
    End Sub

    Public Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If existenRegistros0 Then
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 3
                Dim colsHidden As Integer = 1

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.GridView1.Rows.Count - 1
                    For j As Integer = colsTexto To Me.GridView1.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.GridView1.Rows(i).Cells(j).Text = "" Or Me.GridView1.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.GridView1.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet0 = 0 Then
                    GridView1.Controls(0).Controls.Add(rowFooter1)
                    feet0 = 1
                End If
            End If
        End If
    End Sub
    Protected Sub grdClasicaChip_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClasicaChip.RowCreated
        If existenRegistrosClasicaChip Then
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 3
                Dim colsHidden As Integer = 1

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.grdClasicaChip.Rows.Count - 1
                    For j As Integer = colsTexto To Me.grdClasicaChip.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.grdClasicaChip.Rows(i).Cells(j).Text = "" Or Me.grdClasicaChip.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.grdClasicaChip.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feetClasicaChip = 0 Then
                    grdClasicaChip.Controls(0).Controls.Add(rowFooter1)
                    feetClasicaChip = 1
                End If
            End If
        End If
    End Sub
    Public Sub GridView2_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If existenRegistros1 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.GridView2.Rows.Count - 1
                    For j As Integer = colsTexto To Me.GridView2.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.GridView2.Rows(i).Cells(j).Text = "" Or Me.GridView2.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.GridView2.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet1 = 0 Then
                    GridView2.Controls(0).Controls.Add(rowFooter1)
                    feet1 = 1
                End If
            End If
        End If
    End Sub
    Public Sub GridView3_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowCreated
        If existenRegistros2 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.GridView3.Rows.Count - 1
                    For j As Integer = colsTexto To Me.GridView3.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.GridView3.Rows(i).Cells(j).Text = "" Or Me.GridView3.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.GridView3.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet2 = 0 Then
                    GridView3.Controls(0).Controls.Add(rowFooter1)
                    feet2 = 1
                End If
            End If
        End If
    End Sub
    Public Sub GridView4_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowCreated
        If existenRegistros3 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.GridView4.Rows.Count - 1
                    For j As Integer = colsTexto To Me.GridView4.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.GridView4.Rows(i).Cells(j).Text = "" Or Me.GridView4.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.GridView4.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet3 = 0 Then
                    GridView4.Controls(0).Controls.Add(rowFooter1)
                    feet3 = 1
                End If
            End If
        End If
    End Sub
    Public Sub GridView5_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowCreated
        If existenRegistros4 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.GridView5.Rows.Count - 1
                    For j As Integer = colsTexto To Me.GridView5.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.GridView5.Rows(i).Cells(j).Text = "" Or Me.GridView5.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.GridView5.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet4 = 0 Then
                    GridView5.Controls(0).Controls.Add(rowFooter1)
                    feet4 = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle.RowCreated
        If existenRegistros5 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.gvdetalle.Rows.Count - 1
                    For j As Integer = colsTexto To Me.gvdetalle.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.gvdetalle.Rows(i).Cells(j).Text = "" Or Me.gvdetalle.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.gvdetalle.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet5 = 0 Then
                    gvdetalle.Controls(0).Controls.Add(rowFooter1)
                    feet5 = 1
                End If
            End If
        End If
    End Sub
    Protected Sub grdClasicaChipDetalle_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdClasicaChipDetalle.RowCreated
        If existenRegistrosClasicaChipDetalle Then
            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray

                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.grdClasicaChipDetalle.Rows.Count - 1
                    For j As Integer = colsTexto To Me.grdClasicaChipDetalle.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.grdClasicaChipDetalle.Rows(i).Cells(j).Text = "" Or Me.grdClasicaChipDetalle.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.grdClasicaChipDetalle.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feetClasicaChipDetalle = 0 Then
                    grdClasicaChipDetalle.Controls(0).Controls.Add(rowFooter1)
                    feetClasicaChipDetalle = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle2_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle2.RowCreated
        If existenRegistros6 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.gvdetalle2.Rows.Count - 1
                    For j As Integer = colsTexto To Me.gvdetalle2.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.gvdetalle2.Rows(i).Cells(j).Text = "" Or Me.gvdetalle2.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.gvdetalle2.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet6 = 0 Then
                    gvdetalle2.Controls(0).Controls.Add(rowFooter1)
                    feet6 = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle3_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle3.RowCreated
        If existenRegistros7 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.gvdetalle3.Rows.Count - 1
                    For j As Integer = colsTexto To Me.gvdetalle3.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.gvdetalle3.Rows(i).Cells(j).Text = "" Or Me.gvdetalle3.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.gvdetalle3.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet7 = 0 Then
                    gvdetalle3.Controls(0).Controls.Add(rowFooter1)
                    feet7 = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle4_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle4.RowCreated
        If existenRegistros8 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.gvdetalle4.Rows.Count - 1
                    For j As Integer = colsTexto To Me.gvdetalle4.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.gvdetalle4.Rows(i).Cells(j).Text = "" Or Me.gvdetalle4.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.gvdetalle4.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet8 = 0 Then
                    gvdetalle4.Controls(0).Controls.Add(rowFooter1)
                    feet8 = 1
                End If
            End If
        End If
    End Sub
    Public Sub gvdetalle5_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvdetalle5.RowCreated
        If existenRegistros9 Then

            If e.Row.RowType = DataControlRowType.Footer Then
                Dim cantColumnas As Integer = e.Row.Cells.Count
                Dim colsTexto As Integer = 2
                Dim colsHidden As Integer = 0

                Dim rowFooter1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal)
                Dim listaCeldas As List(Of TableCell) = New List(Of TableCell)
                Dim footerCell As TableCell
                For index = 0 To cantColumnas - 1
                    footerCell = New TableCell()
                    listaCeldas.Add(footerCell)
                Next

                listaCeldas(0).ColumnSpan = (colsTexto - colsHidden)
                listaCeldas(0).Text = "TOTAL"
                listaCeldas(0).HorizontalAlign = HorizontalAlign.Center
                listaCeldas(0).BackColor = Drawing.Color.LightGray


                Dim listaSumas As List(Of Integer) = New List(Of Integer)
                Dim footerSum As Integer
                For index = 0 To cantColumnas - (colsTexto + 1)
                    footerSum = 0
                    listaSumas.Add(footerSum)
                Next

                For i = 0 To Me.gvdetalle5.Rows.Count - 1
                    For j As Integer = colsTexto To Me.gvdetalle5.Rows(i).Cells.Count - 1
                        listaSumas(j - colsTexto) = listaSumas(j - colsTexto) + CInt(IIf(Me.gvdetalle5.Rows(i).Cells(j).Text = "" Or Me.gvdetalle5.Rows(i).Cells(j).Text = "&nbsp;", 0, Me.gvdetalle5.Rows(i).Cells(j).Text))
                    Next
                Next

                rowFooter1.Cells.Add(listaCeldas(0))

                For index = 0 To listaCeldas.Count - (colsTexto + 1)
                    listaCeldas(index + colsTexto).Text = listaSumas(index)
                    listaCeldas(index + colsTexto).BackColor = Drawing.Color.LightGray
                    rowFooter1.Cells.Add(listaCeldas(index + colsTexto))
                Next

                If feet9 = 0 Then
                    gvdetalle5.Controls(0).Controls.Add(rowFooter1)
                    feet9 = 1
                End If
            End If
        End If
    End Sub

End Class
