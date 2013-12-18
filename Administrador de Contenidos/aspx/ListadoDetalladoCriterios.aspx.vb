Imports System.Data
Partial Class aspx_ListadoDetalladoCriterios
    Inherits System.Web.UI.Page
    Public nodo As New TreeNode
    Dim funciones_otras As New Ubigeo
    Dim tienda As New tiendas
    Dim kio As New kioskos
    Public Shared fecha As Date
    Public Shared valor As Integer = 0

    Public Sub ArmarCalendario(ByVal val As Integer)
        Try
            Dim semanaArray() As String = Sql_Get_Semana(ConvertirFecha(fecha))
            Dim dt As DataSet = kio.listarkioskos("5", val, "", "", "", "")
            'arma grid titulos
            For i As Integer = 1 To semanaArray.Length - 1
                Me.GridView1.Columns(i + 1).HeaderText = semanaArray(i)
            Next
            'cargando  kioscos
            Dim listaFechasKioscos As New List(Of ConsultaCriterioKiosco)
            For i As Integer = 0 To dt.Tables("consulta").Rows.Count - 1
                Dim codkio As Integer = 0
                Dim objKioscoCriterioConsulta As New ConsultaCriterioKiosco
                objKioscoCriterioConsulta.KioscoNombre = dt.Tables("consulta").Rows(i)("nombre_kiosko").ToString()
                objKioscoCriterioConsulta.idKiosko = dt.Tables("consulta").Rows(i)("idkiosko").ToString()
                listaFechasKioscos.Add(objKioscoCriterioConsulta)
            Next
            Me.GridView1.DataSource = listaFechasKioscos
            Me.GridView1.DataBind()

            Dim dtts As New DataSet
            dtts = kio.listarkioskos("6", valor, "", "", "", "0")

            For cf As Integer = 0 To dtts.Tables("consulta").Rows.Count - 1
                Dim idkio As String = dtts.Tables("consulta").Rows(cf).Item("idkiosko").ToString
                Dim nombre As String = dtts.Tables("consulta").Rows(cf).Item("nombre").ToString
                Dim CadFecha As String = dtts.Tables("consulta").Rows(cf).Item("fecha").ToString
                Dim dtss As New DataSet
                dtss = funciones_otras.nombrefecha(CadFecha)
                CadFecha = dtss.Tables("consulta").Rows(0).Item(0).ToString
                For xfila As Integer = 0 To Me.GridView1.Rows.Count - 1
                    Dim colidkio As String = Me.GridView1.Rows(xfila).Cells(0).Text
                    For xcol As Integer = 2 To Me.GridView1.Columns.Count - 1
                        Dim fechaCad As String = Me.GridView1.Columns(xcol).HeaderText
                        If (colidkio = idkio) And CadFecha = fechaCad Then
                            Me.GridView1.Rows(xfila).Cells(xcol).Text = nombre
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim dts As New DataSet
                dts = funciones_otras.fechaserver()
                fecha = dts.Tables("consulta").Rows(0).Item(0).ToString

                nodo = New TreeNode
                Me.treetienda.Nodes.Clear()
                nodo.Value = "0"
                nodo.Text = "Ubigeo"
                Me.treetienda.Nodes.Add(nodo)
                Call mostrarnodos(nodo)
                'ArmarCalendario()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function mostrarnodos(ByVal pad As TreeNode) As Boolean
        Dim dtss As New DataSet
        Dim i As Integer = 0
        dtss = funciones_otras.listarubigeostreeview("nodos", pad.Value)
        For i = 1 To dtss.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dtss.Tables("consulta").Rows(i - 1).Item("nombre").ToString
            nodo.Value = dtss.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            'nodo.NavigateUrl = "ListadoDetalladoCriterios.aspx"
            pad.ChildNodes.Add(nodo)
            mostrarnodos(nodo)
            Call mostrarnodostiendas(nodo)
        Next
        Return True
    End Function

    Private Function mostrarnodostiendas(ByVal padre As TreeNode) As Boolean
        Dim dtss As New DataSet
        Dim i As Integer = 0
        dtss = tienda.ListarTiendas("1", padre.Value, "", "", "", 1)
        For i = 1 To dtss.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dtss.Tables("consulta").Rows(i - 1).Item("sucursal").ToString
            nodo.Value = dtss.Tables("consulta").Rows(i - 1).Item("id").ToString
            'nodo.NavigateUrl = "#"
            padre.ChildNodes.Add(nodo)
            MOSTRARKIOSKOS(nodo)
        Next
        Return True
    End Function

    Private Function MOSTRARKIOSKOS(ByVal padreE As TreeNode) As Boolean
        Dim dtss As New DataSet
        Dim i As Integer = 0
        dtss = kio.listarkioskos("4", padreE.Value, "", "", "", 0)
        For i = 1 To dtss.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dtss.Tables("consulta").Rows(i - 1).Item("nombre_kiosko").ToString
            nodo.Value = dtss.Tables("consulta").Rows(i - 1).Item("idkiosko").ToString
            'nodo.NavigateUrl = "#"
            padreE.ChildNodes.Add(nodo)
            'MOSTRARKIOSKOS(nodo)
        Next
        Return True
    End Function
    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles treetienda.SelectedNodeChanged
        Try

            valor = Me.treetienda.SelectedNode.Value
            Call ArmarCalendario(valor)
            'Me.TextBox1.Text = Me.treetienda.SelectedNode.Value
            'MsgBox(Me.treetienda.Nodes(Me.treetienda.SelectedNode.Value).ChildNodes)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnAvanzar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvanzar.Click
        fecha = fecha.AddDays(7)
        ArmarCalendario(valor)
    End Sub

    Protected Sub btnAtras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        fecha = fecha.AddDays(-7)
        ArmarCalendario(valor)
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
