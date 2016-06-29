Imports System.Data
Partial Class aspx_VistaImpresionDetalleUsuarios
    Inherits System.Web.UI.Page
    Public menus As New ClsReportes
    Public Shared existenRegistros0 As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try           
            Dim inicio As String = IIf(Request.QueryString("fechainicio") Is Nothing, Now.Date.ToString, Request.QueryString("fechainicio"))
            Dim fin As String = IIf(Request.QueryString("fechafin") Is Nothing, Now.Date.ToString, Request.QueryString("fechafin"))            
            Dim dts As New DataSet
            Me.Label3.Text = "Del: " & inicio & " al " & fin
            Me.Label6.Text = "REPORTE DETALLE USUARIOS RIPLEYMATICO DEL " & inicio & " al " & fin
            If Not IsPostBack Then
                Call MostrarDatos(inicio, fin)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub MostrarDatos(ByVal f1 As String, ByVal f2 As String)
        Dim dts As New DataSet
        dts.Clear()
        dts = menus.sp_Reporte_Detalle_Usuarios_Canal_Ripleymaticos(f1, f2)
        If dts.Tables("consulta").Rows.Count > 0 Then
            existenRegistros0 = True
            Me.GridView1.DataSource = dts : Me.GridView1.DataBind()
        Else
            existenRegistros0 = False
            Me.GridView1.DataSource = menus.MENSAJEGRID : Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
