Imports System.Data
Partial Class VistaImpresionIncremento
    Inherits System.Web.UI.Page
    Public menus As New ClsReportes
    Dim feet As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim suc As String = IIf(Request.QueryString("Sucursal") Is Nothing, "Todo", Request.QueryString("Sucursal"))
            Dim inicio As String = IIf(Request.QueryString("fechainicio") Is Nothing, Now.Date.ToString, Request.QueryString("fechainicio"))
            Dim fin As String = IIf(Request.QueryString("fechafin") Is Nothing, Now.Date.ToString, Request.QueryString("fechafin"))
            Dim tienda As String = IIf(Request.QueryString("tienda") Is Nothing, "0", Request.QueryString("tienda"))
            Dim dts As New DataSet

            Me.Label2.Text = suc
            Me.Label3.Text = "Del: " & inicio & " al " & fin
            Me.Label6.Text = "REPORTE ESTADÍSTICO DEL " & inicio & " al " & fin
            If Not IsPostBack Then
                Call MostrarDatos(inicio, fin, tienda)
            End If

            suc = ""
            tienda = ""
            inicio = ""
            fin = ""


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub MostrarDatos(ByVal f1 As String, ByVal f2 As String, ByVal tienda As String)
        Dim dts As New DataSet
            '/*GridView1--------------------------------------------------------------*/
            dts.Clear()
            dts = menus.sp_get_incrementoPorRypleymatico(tienda, f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
            '/*----------------------------------------------------------------------*/
    End Sub

    Public Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For index = 0 To e.Row.Cells.Count - 1
                If GridView1.HeaderRow.Cells(index).Text = "Fecha" Then
                    If e.Row.Cells(index).Text <> "" Then
                        e.Row.Cells(index).Text = String.Format("{0:d}", CType(e.Row.Cells(index).Text, Date))
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            If GridView1.Controls(0).Controls.Count < 2 Then
                Dim headerCell1 As TableCell = New TableCell()
                headerCell1.ColumnSpan = 7
                headerCell1.Text = "ESTADISTICA DE INCREMENTO LINEA POR RIPLEYMATICO"


                Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                rowHeader1.Cells.Add(headerCell1)
                rowHeader1.HorizontalAlign = HorizontalAlign.Center
                rowHeader1.Font.Bold = True
                rowHeader1.Visible = True
                GridView1.Controls(0).Controls.AddAt(0, rowHeader1)

                Dim headerCell11 As TableCell = New TableCell()
                Dim headerCell12 As TableCell = New TableCell()
                Dim headerCell13 As TableCell = New TableCell()
                Dim headerCell14 As TableCell = New TableCell()
                headerCell11.ColumnSpan = 1
                headerCell11.Text = ""
                headerCell12.ColumnSpan = 2
                headerCell12.Text = "RSAT"
                headerCell13.ColumnSpan = 2
                headerCell13.Text = "MC"
                headerCell14.ColumnSpan = 2
                headerCell14.Text = "TOTAL"

                Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
                rowHeader2.Cells.Add(headerCell11)
                rowHeader2.Cells.Add(headerCell12)
                rowHeader2.Cells.Add(headerCell13)
                rowHeader2.Cells.Add(headerCell14)
                rowHeader2.HorizontalAlign = HorizontalAlign.Center
                rowHeader2.Visible = True
                rowHeader2.Font.Bold = True

                GridView1.Controls(0).Controls.AddAt(1, rowHeader2)
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
            footerCell0.HorizontalAlign = HorizontalAlign.Center

            Dim suma1 As Integer = 0
            Dim suma2 As Integer = 0
            Dim suma3 As Integer = 0
            Dim suma4 As Integer = 0
            Dim suma5 As Integer = 0
            Dim suma6 As Integer = 0
            For i = 0 To Me.GridView1.Rows.Count - 1
                suma1 = suma1 + CInt(IIf(Me.GridView1.Rows(i).Cells(1).Text = "", 0, Me.GridView1.Rows(i).Cells(1).Text))
                suma2 = suma2 + CInt(IIf(Me.GridView1.Rows(i).Cells(2).Text = "", 0, Me.GridView1.Rows(i).Cells(2).Text))
                suma3 = suma3 + CInt(IIf(Me.GridView1.Rows(i).Cells(3).Text = "", 0, Me.GridView1.Rows(i).Cells(3).Text))
                suma4 = suma4 + CInt(IIf(Me.GridView1.Rows(i).Cells(4).Text = "", 0, Me.GridView1.Rows(i).Cells(4).Text))
                suma5 = suma5 + CInt(IIf(Me.GridView1.Rows(i).Cells(5).Text = "", 0, Me.GridView1.Rows(i).Cells(5).Text))
                suma6 = suma6 + CInt(IIf(Me.GridView1.Rows(i).Cells(6).Text = "", 0, Me.GridView1.Rows(i).Cells(6).Text))
            Next
            footerCell1.Text = suma1.ToString
            footerCell1.HorizontalAlign = HorizontalAlign.Right

            footerCell2.Text = suma2.ToString
            footerCell2.HorizontalAlign = HorizontalAlign.Right
            footerCell3.Text = suma3.ToString
            footerCell3.HorizontalAlign = HorizontalAlign.Right
            footerCell4.Text = suma4.ToString
            footerCell4.HorizontalAlign = HorizontalAlign.Right
            footerCell5.Text = suma5.ToString
            footerCell5.HorizontalAlign = HorizontalAlign.Right
            footerCell6.Text = suma6.ToString
            footerCell6.HorizontalAlign = HorizontalAlign.Right

            rowFooter1.Cells.Add(footerCell0)
            rowFooter1.Cells.Add(footerCell1)
            rowFooter1.Cells.Add(footerCell2)
            rowFooter1.Cells.Add(footerCell3)
            rowFooter1.Cells.Add(footerCell4)
            rowFooter1.Cells.Add(footerCell5)
            rowFooter1.Cells.Add(footerCell6)
            rowFooter1.Font.Bold = True
            If feet = 1 Then
                GridView1.Controls(0).Controls.Add(rowFooter1)
            End If
            feet += 1
        End If
    End Sub
End Class
