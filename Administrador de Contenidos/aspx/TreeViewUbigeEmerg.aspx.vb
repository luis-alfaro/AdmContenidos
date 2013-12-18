Imports System.Data
Partial Class aspx_TreeViewUbigeEmerg
    Inherits System.Web.UI.Page
    Dim funciones_otras As New Ubigeo
    Dim cn As New Funciones_Conexion
    Public nodo As New TreeNode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            nodo = New TreeNode
            Me.TreeView1.Nodes.Clear()
            nodo.Value = "0"
            nodo.Text = "Ubigeo"
            Me.TreeView1.Nodes.Add(nodo)
            Call mostrarnodos(nodo)
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
            nodo.NavigateUrl = "TreeViewUbigeEmerg.aspx"
            pad.ChildNodes.Add(nodo)
            mostrarnodos(nodo)
        Next
        Return 0
    End Function

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Try
            Dim valor_variable As Integer = Me.TreeView1.SelectedValue
            valor_variable = Me.TreeView1.SelectedValue
            Session.Add("TreeViewUbigeEmerg.aspx", valor_variable)
        Catch ex As Exception

        End Try
    End Sub
End Class
