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

Partial Class aspx_ReporteDetalleUsuariosRipleymatico
    Inherits System.Web.UI.Page

    Public cadena As String
    Public funciones_otras As New Ubigeo : Public nodo As TreeNode : Public ConsultaGrillaGeneral As String : Dim campos As String : Public ConsultaGrillaDetalle As String
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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""
            If Not IsPostBack Then
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

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtfechadesde.Text.Trim() = "" Then
            lbldesde.Visible = True
            lbldesde.Text = "Ingrese una fecha"
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
        Call MostrarDatos()        
    End Sub

    Sub MostrarDatos()
        IniciarVariables()
        Dim dts As New DataSet
        Try
            Dim f1 As DateTime : Dim f2 As DateTime
            f1 = New Date(txtfechadesde.Text.Substring(6, 4), txtfechadesde.Text.Substring(3, 2), txtfechadesde.Text.Substring(0, 2))
            f2 = New Date(txtfechahasta.Text.Substring(6, 4), txtfechahasta.Text.Substring(3, 2), txtfechahasta.Text.Substring(0, 2))            
            Call HabilitarTodos(True)
            dts.Clear()            
            dts = menus.sp_Reporte_Detalle_Usuarios_Canal_Ripleymaticos(f1, f2)
            If dts.Tables("consulta").Rows.Count > 0 Then
                existenRegistros0 = True
                Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
            Else
                existenRegistros0 = False
                Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
            End If
        Catch ex As Exception
            lblError.Text += ex.Message + "//" + ex.StackTrace
        End Try
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

    Sub HabilitarTodos(ByVal valor As Boolean)
        Me.Button8.Visible = valor
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

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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
        cadena = "VistaImpresionDetalleUsuarios.aspx?fechainicio=" & Me.txtfechadesde.Text & "&fechafin=" & Me.txtfechahasta.Text
        Response.Redirect(cadena)
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Call exportarExcel(Me.GridView1)
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'Confirms that an HtmlForm control Is rendered for the specified ASP.NET Server control at run time.
    End Sub

    Public Sub exportarExcel(ByVal wControl As GridView)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=ReporteDetalleUsuarioRipleymatico.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        wControl.AllowPaging = False
        Call IniciarVariables()
        MostrarDatos()
        wControl.HeaderRow.Style.Add("background-color", "#FFFFFF")
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
        Dim style As String = "<style>.textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
End Class
