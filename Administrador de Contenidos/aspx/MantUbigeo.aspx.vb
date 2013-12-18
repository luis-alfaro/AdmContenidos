Imports System.Data
Partial Class aspx_MantUbigeo
    Inherits System.Web.UI.Page
    Dim funciones_otras As New Ubigeo
    Dim cn As New Funciones_Conexion
    Public nodo As New TreeNode

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("MantDepartamento.aspx?idtipo=1")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("MantDepartamento.aspx?idtipo=2")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Response.Redirect("MantDepartamento.aspx?idtipo=3")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "4", "1", "0")
            'Me.GridView1.DataBind()
            nodo = New TreeNode
            Me.treeubigeo.Nodes.Clear()
            Me.treeubigeo.Nodes.Add(nodo)
            nodo.Value = "0"
            nodo.Text = "Ubigeo"
            Call mostrarnodos(nodo)

            treeubigeo.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function mostrarnodos(ByVal pad As TreeNode) As Integer
        Dim dts As New DataSet
        Dim i As Integer = 0
        dts = funciones_otras.listarubigeostreeview("nodos", pad.Value)
        For i = 1 To dts.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dts.Tables("consulta").Rows(i - 1).Item("nombre").ToString
            nodo.Value = dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            'nodo.NavigateUrl = "MantDepartamento.aspx?id=" & dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            pad.ChildNodes.Add(nodo)
            mostrarnodos(nodo)
        Next
        Return 0
    End Function

    Protected Sub treeubigeo_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeubigeo.SelectedNodeChanged
        Try
            treeubigeo.ExpandAll()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
