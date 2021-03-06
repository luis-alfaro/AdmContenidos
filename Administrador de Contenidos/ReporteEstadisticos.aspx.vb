﻿Imports System
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
    Public ss As String = "" : Public sumadetalle As String : Public COD As Integer:Public c1 As String = "" : Public c2 As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                idtienda = IIf(Request.QueryString("idtienda") Is Nothing, "0", Request.QueryString("idtienda"))
                Me.hddtienda.Value = idtienda
                Dim ds As New DataSet
                Me.DDLTIENDAS.DataSource = tienda.ListarTiendas("7", "", "", "", "", 1)
                Me.DDLTIENDAS.DataTextField = "sucursal"
                Me.DDLTIENDAS.DataValueField = "id"
                Me.DDLTIENDAS.DataBind()
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
        
        Dim rep As String = ""
        rep = Microsoft.VisualBasic.Trim(Me.ddltiporeporte.SelectedItem.Text)
        Dim Suc As String = Me.ddltiendas.SelectedItem.Text
        Call MostrarDatos()
        cadena = "VistaImpresion.aspx?tiporeporte=" & Me.ddltiporeporte.SelectedValue & "&tienda=" & Me.ddltiendas.SelectedValue & "&fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text & "&Reporte=" & rep & "&Sucursal=" & Suc
    End Sub
    Sub MostrarDatos()
        Dim dts As New DataSet
        Dim f1 As String : Dim f2 As String : f1 = "" : f2 = ""
        f1 = Me.txtfechadesde.Text : f2 = Me.txtfechahasta.Text
        If Me.ddltiendas.SelectedValue = 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 1 Then
            Me.GridView4.Visible = True : Me.GridView5.Visible = True
            Me.Button11.Visible = True : Me.Button12.Visible = True
            Me.gvdetalle.Visible = False : Me.gvdetalle2.Visible = False : Me.gvdetalle3.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
            Call HabilitarTodos(True)
            Me.Button13.Visible = False : Me.Button14.Visible = False : Me.Button15.Visible = False : Me.Button16.Visible = False : Me.Button17.Visible = False
            'Mostrar Todo Reporte:Producto
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
            Else
                Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
            Else
                Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

        ElseIf Me.ddltiendas.SelectedValue = 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 2 Then
            '/*Mostrar Todo Reporte Marcas*/

            Call HabilitarTodos(False)
            Me.Button8.Visible = True : Me.Button9.Visible = True : Me.Button10.Visible = True : Me.Button11.Visible = False
            Me.Button12.Visible = False : Me.Button13.Visible = False : Me.Button14.Visible = False : Me.Button15.Visible = False : Me.Button16.Visible = False : Me.Button17.Visible = False


            Me.GridView4.Visible = False : Me.GridView5.Visible = False
            Me.Button11.Visible = False : Me.Button12.Visible = False
            Me.gvdetalle.Visible = False : Me.gvdetalle2.Visible = False : Me.gvdetalle3.Visible = False : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2-----agrupar las tarjetas---------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
        ElseIf Me.ddltiendas.SelectedValue > 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 1 Then

            Call HabilitarTodos(True)
            Me.GridView4.Visible = True : Me.GridView5.Visible = True
            'Me.Button11.Visible = True : Me.Button12.Visible = True
            Me.gvdetalle.Visible = True : Me.gvdetalle2.Visible = True : Me.gvdetalle3.Visible = True : Me.gvdetalle4.Visible = True : Me.gvdetalle5.Visible = True
            'Mostrar Todo Reporte:Producto
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
            Else
                Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
            Else
                Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
            End If
            '/*----------------------------------------------------------------------*/


            '/*gvdetalle--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle2.DataSource = dts : Me.gvdetalle2.DataBind()
            Else
                Me.gvdetalle2.DataSource = menus.MENSAJEGRID : Me.gvdetalle2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle3.DataSource = dts : Me.gvdetalle3.DataBind()
            Else
                Me.gvdetalle3.DataSource = menus.MENSAJEGRID : Me.gvdetalle3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "4", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle4.DataSource = dts : Me.gvdetalle4.DataBind()
            Else
                Me.gvdetalle4.DataSource = menus.MENSAJEGRID : Me.gvdetalle4.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "5", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle5.DataSource = dts : Me.gvdetalle5.DataBind()
            Else
                Me.gvdetalle5.DataSource = menus.MENSAJEGRID : Me.gvdetalle5.DataBind()
            End If
            '/*----------------------------------------------------------------------*/


        ElseIf Me.ddltiendas.SelectedValue > 0 And (idtienda = 0 Or idtienda = Nothing) And Me.ddltiporeporte.SelectedValue = 2 Then
            '/*Mostrar Todo Reporte Marcas*/
            Call HabilitarTodos(True)
            Me.Button11.Visible = False
            Me.Button16.Visible = False : Me.Button17.Visible = False



            Me.GridView4.Visible = False : Me.GridView5.Visible = False
            Me.Button11.Visible = False : Me.Button12.Visible = False
            Me.gvdetalle.Visible = True : Me.gvdetalle2.Visible = True : Me.gvdetalle3.Visible = True : Me.gvdetalle4.Visible = False : Me.gvdetalle5.Visible = False
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*-----------------------------------------------------------------------*/

            '/*gvdetalle----TAMBIEN SUMAR TODAS LAS TARJETAS----------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "1", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle.DataSource = dts : Me.gvdetalle.DataBind()
            Else
                Me.gvdetalle.DataSource = menus.MENSAJEGRID : Me.gvdetalle.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "2", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle2.DataSource = dts : Me.gvdetalle2.DataBind()
            Else
                Me.gvdetalle2.DataSource = menus.MENSAJEGRID : Me.gvdetalle2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "3", Me.ddltiendas.SelectedValue, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.gvdetalle3.DataSource = dts : Me.gvdetalle3.DataBind()
            Else
                Me.gvdetalle3.DataSource = menus.MENSAJEGRID : Me.gvdetalle3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
        End If
    End Sub

    Private Sub ExportToExcel2(ByVal nameReport As String, ByVal wControl As GridView)
        Try
            Dim responsePage As HttpResponse = Response
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            Dim pageToRender As New Page()
            Dim form As New HtmlForm()
            form.Controls.Add(wControl)
            pageToRender.Controls.Add(form)
            responsePage.Clear()
            responsePage.Buffer = True
            responsePage.ContentType = "application/vnd.ms-excel"
            responsePage.AddHeader("Content-Disposition", "attachment;filename=" & nameReport)
            responsePage.Charset = "UTF-8"
            Response.ContentEncoding = Encoding.Default
            pageToRender.RenderControl(htw)
            responsePage.Write(sw.ToString())
            responsePage.End()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function ExportToExcel(ByVal wControl As GridView) As String
        Dim page1 As New Page
        Dim form1 As New HtmlForm
        Me.GridView1.EnableViewState = False
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

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Call MOSTRAR(Me.GridView1)
    End Sub

    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Call MOSTRAR(Me.GridView2)
    End Sub

    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.Click
        Call MOSTRAR(Me.GridView3)
    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        Call MOSTRAR(Me.GridView4)
    End Sub

    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call MOSTRAR(Me.GridView5)
    End Sub

    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        Call MOSTRAR(Me.gvdetalle)
    End Sub

    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        Call MOSTRAR(Me.gvdetalle2)
    End Sub

    Protected Sub Button15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button15.Click
        Call MOSTRAR(Me.gvdetalle3)
    End Sub

    Protected Sub Button16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button16.Click
        Call MOSTRAR(Me.gvdetalle4)
    End Sub

    Protected Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        Call MOSTRAR(Me.gvdetalle5)
    End Sub


    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
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
        'Me.Button7.Visible = valor
        Me.Button8.Visible = valor
        Me.Button9.Visible = valor
        Me.Button10.Visible = valor
        Me.Button11.Visible = valor
        Me.Button12.Visible = valor
        Me.Button13.Visible = valor
        Me.Button14.Visible = valor
        Me.Button15.Visible = valor
        Me.Button16.Visible = valor
        Me.Button17.Visible = valor

    End Sub
End Class
