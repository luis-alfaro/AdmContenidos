Imports System.Data
Partial Class VistaImpresion
    Inherits System.Web.UI.Page
    Public menus As New ClsReportes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim suc As String = IIf(Request.QueryString("Sucursal") Is Nothing, "Vacio", Request.QueryString("Sucursal"))
            Dim tr As String = IIf(Request.QueryString("reporte") Is Nothing, "Vacio", Request.QueryString("reporte"))
            Dim reporte As String = IIf(Request.QueryString("tiporeporte") Is Nothing, "0", Request.QueryString("tiporeporte"))
            Dim inicio As String = IIf(Request.QueryString("fechainicio") Is Nothing, Now.Date.ToString, Request.QueryString("fechainicio"))
            Dim fin As String = IIf(Request.QueryString("fechafin") Is Nothing, Now.Date.ToString, Request.QueryString("fechafin"))
            Dim tienda As String = IIf(Request.QueryString("tienda") Is Nothing, "0", Request.QueryString("tienda"))
            Dim dts As New DataSet
            Me.Label1.Text = tr
            Me.Label2.Text = suc
            Me.Label3.Text = "Del: " & inicio & " al " & fin
            Me.Label6.Text = "REPORTE ESTADÍSTICO DEL " & inicio & " al " & fin
            If Not IsPostBack Then
                Call MostrarDatos(inicio, fin, reporte, tienda)
            End If
            'dts.Clear()
            'If reporte = 1 Then
            '    dts = menus.sp_contar_consultas("1", reporte, "1", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > tienda Then
            '        Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            '    Else
            '        Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*GridView2--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("1", reporte, "2", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > tienda Then
            '        Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            '    Else
            '        Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*GridView3--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("1", reporte, "3", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > tienda Then
            '        Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            '    Else
            '        Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*GridView4--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("1", reporte, "4", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > tienda Then
            '        Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
            '    Else
            '        Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*GridView5--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("1", reporte, "5", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > tienda Then
            '        Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
            '    Else
            '        Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
            '    End If
            'End If

            '/*-------------------------------------------------------------------------------*/

            'If tienda > 0 Then
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("2", reporte, "1", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > 0 Then
            '        Me.GridView6.DataSource = dts : Me.GridView6.DataBind()
            '    Else
            '        Me.GridView6.DataSource = menus.MENSAJEGRID : Me.GridView6.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*gvdetalle2--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("2", reporte, "2", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > 0 Then
            '        Me.GridView7.DataSource = dts : Me.GridView7.DataBind()
            '    Else
            '        Me.GridView7.DataSource = menus.MENSAJEGRID : Me.GridView7.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*gvdetalle3--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("2", reporte, "3", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > 0 Then
            '        Me.GridView8.DataSource = dts : Me.GridView8.DataBind()
            '    Else
            '        Me.GridView8.DataSource = menus.MENSAJEGRID : Me.GridView8.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*gvdetalle4--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("2", reporte, "4", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > 0 Then
            '        Me.GridView9.DataSource = dts : Me.GridView9.DataBind()
            '    Else
            '        Me.GridView9.DataSource = menus.MENSAJEGRID : Me.GridView9.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/

            '    '/*gvdetalle5--------------------------------------------------------------*/
            '    dts.Clear()
            '    dts = menus.sp_contar_consultas("2", reporte, "5", tienda, inicio, fin)
            '    If dts.Tables("consulta").Rows.Count > 0 Then
            '        Me.GridView10.DataSource = dts : Me.GridView10.DataBind()
            '    Else
            '        Me.GridView10.DataSource = menus.MENSAJEGRID : Me.GridView10.DataBind()
            '    End If
            '    '/*----------------------------------------------------------------------*/
            'End If

            reporte = ""
            suc = ""
            tr = ""
            tienda = ""
            inicio = ""
            fin = ""


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub MostrarDatos(ByVal f1 As String, ByVal f2 As String, ByVal tiporeporte As String, ByVal tienda As String)
        Dim dts As New DataSet
        'Dim f1 As String : Dim f2 As String : f1 = "" : f2 = ""
        'f1 = Me.txtfechadesde.Text : f2 = Me.txtfechahasta.Text
        If tienda = 0 And tiporeporte = 1 Then
            'Mostrar Todo Reporte:Producto
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "4", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
            Else
                Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "5", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
            Else
                Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
            End If
            Me.Label5.Text = ""
            '/*----------------------------------------------------------------------*/

        ElseIf tienda = 0 And tiporeporte = 2 Then
            '/*Mostrar Todo Reporte Marcas*/
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            Me.Label5.Text = ""
            '/*----------------------------------------------------------------------*/
        ElseIf tienda > 0 And tiporeporte = 1 Then
            
            'Mostrar Todo Reporte:Producto
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "4", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView4.DataSource = dts : Me.GridView4.DataBind()
            Else
                Me.GridView4.DataSource = menus.MENSAJEGRID : Me.GridView4.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "1", "5", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView5.DataSource = dts : Me.GridView5.DataBind()
            Else
                Me.GridView5.DataSource = menus.MENSAJEGRID : Me.GridView5.DataBind()
            End If
            '/*----------------------------------------------------------------------*/


            '/*gvdetalle--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView6.DataSource = dts : Me.GridView6.DataBind()
            Else
                Me.GridView6.DataSource = menus.MENSAJEGRID : Me.GridView6.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView7.DataSource = dts : Me.GridView7.DataBind()
            Else
                Me.GridView7.DataSource = menus.MENSAJEGRID : Me.GridView7.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView8.DataSource = dts : Me.GridView8.DataBind()
            Else
                Me.GridView8.DataSource = menus.MENSAJEGRID : Me.GridView8.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle4--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "4", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView9.DataSource = dts : Me.GridView9.DataBind()
            Else
                Me.GridView9.DataSource = menus.MENSAJEGRID : Me.GridView9.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle5--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "1", "5", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView10.DataSource = dts : Me.GridView10.DataBind()
            Else
                Me.GridView10.DataSource = menus.MENSAJEGRID : Me.GridView10.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
            Me.Label5.Text = "REPORTE DETALLADO"

        ElseIf tienda > 0 And tiporeporte = 2 Then
            Me.Label5.Text = "REPORTE DETALLADO"
            '/*Mostrar Todo Reporte Marcas*/
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView2.DataSource = dts : Me.GridView2.DataBind()
            Else
                Me.GridView2.DataSource = menus.MENSAJEGRID : Me.GridView2.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*GridView3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("1", "2", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView3.DataSource = dts : Me.GridView3.DataBind()
            Else
                Me.GridView3.DataSource = menus.MENSAJEGRID : Me.GridView3.DataBind()
            End If
            '/*-----------------------------------------------------------------------*/

            '/*gvdetalle--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "1", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView6.DataSource = dts : Me.GridView6.DataBind()
            Else
                Me.GridView6.DataSource = menus.MENSAJEGRID : Me.GridView6.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle2--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "2", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView7.DataSource = dts : Me.GridView7.DataBind()
            Else
                Me.GridView7.DataSource = menus.MENSAJEGRID : Me.GridView7.DataBind()
            End If
            '/*----------------------------------------------------------------------*/

            '/*gvdetalle3--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_contar_consultas("2", "2", "3", tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView8.DataSource = dts : Me.GridView8.DataBind()
            Else
                Me.GridView8.DataSource = menus.MENSAJEGRID : Me.GridView8.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
        End If
    End Sub
End Class
