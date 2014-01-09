Imports System.Data
Partial Class aspx_MantKioskos
    Inherits System.Web.UI.Page
    Dim rp As Integer = 0
    Dim mensaje As String = ""
    Dim areas As New Area
    Public nodo As New TreeNode
    Dim funciones_otras As New Ubigeo
    Dim tienda As New tiendas
    Dim kio As New kioskos
    Public Shared valor As String '= "N"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim tipo As String = IIf(Request.QueryString("tipo") Is Nothing, "N", Request.QueryString("tipo"))

            Dim dts As New DataSet
            Dim idkiosko As String = IIf(Request.QueryString("idkio") Is Nothing, "0", Request.QueryString("idkio"))

            'idkio=1&tipo=E
            If Not IsPostBack Then
                valor = tipo

                Me.hddkiosko.Value = idkiosko
                Me.ddlareas.DataSource = areas.listararea(2)
                Me.ddlareas.DataTextField = "Nombre"
                Me.ddlareas.DataValueField = "IdArea"
                Me.ddlareas.DataBind()

                Me.ddlConfiguracion.DataSource = kio.listarConfiguracionKioskos()
                Me.ddlConfiguracion.DataTextField = "NOMBRE"
                Me.ddlConfiguracion.DataValueField = "ID"
                Me.ddlConfiguracion.DataBind()


                If idkiosko <> "0" Then
                    dts = kio.listarkioskos("2", idkiosko, "", "", "", "")
                    If dts.Tables("consulta").Rows.Count > 0 Then
                        Me.txtnombre.Text = dts.Tables("consulta").Rows(0).Item("nombre_kiosko").ToString
                        Me.Text1.Value = dts.Tables("consulta").Rows(0).Item("piso").ToString
                        Dim c As String = "" : Dim d As String = ""
                        Dim v As Integer = 1
                        For x As Integer = 1 To 16
                            c = Mid(dts.Tables("consulta").Rows(0).Item("ip").ToString, x, 1)
                            If c <> "." And x < 16 Then
                                d = d & c
                            ElseIf v = 1 Then
                                Me.txtip1.Text = Me.txtip1.Text & d
                                d = ""
                                v = v + 1
                            ElseIf v = 2 Then
                                Me.txtip2.Text = Me.txtip2.Text & d
                                d = ""
                                v = v + 1
                            ElseIf v = 3 Then
                                Me.txtip3.Text = Me.txtip3.Text & d
                                d = ""
                                v = v + 1
                            Else : v = 4
                                Me.txtip4.Text = Me.txtip4.Text & d
                                d = ""
                                v = v + 1
                            End If
                        Next


                        Me.ddlareas.SelectedValue = dts.Tables("consulta").Rows(0).Item("idarea").ToString
                        Me.txtMAC.Text = dts.Tables("consulta").Rows(0).Item("MAC").ToString
                        Me.ddlConfiguracion.SelectedValue = dts.Tables("consulta").Rows(0).Item("CONFIGURACION_ID").ToString
                        Me.hddidtienda.Value = dts.Tables("consulta").Rows(0).Item("id_sucursal").ToString
                        dts = tienda.ListarTiendas("3", Me.hddidtienda.Value, "", "", "", "1")
                        If dts.Tables("consulta").Rows.Count > 0 Then
                            Me.txttienda.Text = dts.Tables("consulta").Rows(0).Item("sucursal").ToString
                        End If
                    End If
                End If



                nodo = New TreeNode
                Me.treetienda.Nodes.Clear()
                nodo.Value = "0"
                nodo.Text = "Ubigeo"
                Me.treetienda.Nodes.Add(nodo)
                Call mostrarnodos(nodo)
                'Me.hddtienda.Value = idtiendas

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function mostrarnodos(ByVal pad As TreeNode) As Integer
        Dim dtss As New DataSet
        Dim i As Integer = 0
        dtss = funciones_otras.listarubigeostreeview("nodos", pad.Value)
        For i = 1 To dtss.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dtss.Tables("consulta").Rows(i - 1).Item("nombre").ToString
            nodo.Value = dtss.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            'nodo.NavigateUrl = "MantDepartamento.aspx?id=" & dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            pad.ChildNodes.Add(nodo)
            mostrarnodos(nodo)
            Call mostrarnodostiendas(nodo)
        Next
        Return 0
    End Function

    Private Function mostrarnodostiendas(ByVal padre As TreeNode) As Integer
        Dim dtss As New DataSet
        Dim i As Integer = 0
        dtss = tienda.ListarTiendas("1", padre.Value, "", "", "", 1)
        For i = 1 To dtss.Tables("consulta").Rows.Count
            nodo = New TreeNode
            nodo.Text = dtss.Tables("consulta").Rows(i - 1).Item("sucursal").ToString
            nodo.Value = dtss.Tables("consulta").Rows(i - 1).Item("id").ToString
            'nodo.NavigateUrl = "MantKioskos.aspx?id=" & dts.Tables("consulta").Rows(i - 1).Item("ubigeoid").ToString
            padre.ChildNodes.Add(nodo)
            mostrarnodostiendas(nodo)
        Next
        Return 0
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.treetienda.Visible = False Then
            Me.treetienda.Visible = True
        Else
            Me.treetienda.Visible = False
        End If
    End Sub

    Protected Sub treetienda_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles treetienda.SelectedNodeChanged
        Try

            Try

                Dim ndTienda As TreeNode = treetienda.SelectedNode
                Dim ndDistrito As TreeNode = ndTienda.Parent
                Dim ndProvincia As TreeNode = ndDistrito.Parent
                Dim ndDepartamento As TreeNode = ndProvincia.Parent
                If ndDepartamento.Text.ToLower() = "ubigeo" Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try


            Me.hddidtienda.Value = Me.treetienda.SelectedNode.Value
            Me.txttienda.Text = Me.treetienda.SelectedNode.Text
            Me.treetienda.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    
    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If Me.ddlConfiguracion.SelectedValue = 0 Or Me.ddlConfiguracion.SelectedValue = "" Then
                lblError.Visible = True
                lblError.Text = "Debe ingresar una Configuración y luego relacionarla con este Kiosko"

            Else
                If valor = "N" Then
                    If kio.grabar(0, "1", Me.hddidtienda.Value, Me.txtnombre.Text, Me.Text1.Value, (Me.txtip1.Text & "." & Me.txtip2.Text & "." & Me.txtip3.Text & "." & Me.txtip4.Text), Me.ddlareas.SelectedValue, Me.ddlConfiguracion.SelectedValue, txtMAC.Text, rp, mensaje) >= 1 Then
                        Response.Redirect("ListadoKioskos.aspx")
                    End If
                Else
                    If kio.grabar(Me.hddkiosko.Value, "2", Me.hddidtienda.Value, Me.txtnombre.Text, Me.Text1.Value, (Me.txtip1.Text & "." & Me.txtip2.Text & "." & Me.txtip3.Text & "." & Me.txtip4.Text), Me.ddlareas.SelectedValue, Me.ddlConfiguracion.SelectedValue, txtMAC.Text, rp, mensaje) >= 1 Then
                        Response.Redirect("ListadoKioskos.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Hubo un error y no se pudieron guardar los cambios, intentelo más tarde."
            'MsgBox(ex.ToString)
        End Try
    End Sub

    'Protected Sub txtpiso_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpiso.TextChanged

    'End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("ListadoKioskos.aspx")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try


            Dim idkiosko As String = IIf(Request.QueryString("idkio") Is Nothing, "0", Request.QueryString("idkio"))

            'Dim resultado As Microsoft.VisualBasic.MsgBoxResult = MsgBox("¿Desea Eliminar este Kiosco?", MsgBoxStyle.YesNo, "Administrador de Contenidos")
            'If resultado = MsgBoxResult.Yes Then
            Sql_Detele_Kiosco(idkiosko)
            'End If

            Response.Redirect("ListadoKioskos.aspx")
        Catch ex As Exception
            'MsgBox(ex.Message + ex.StackTrace)
        End Try
    End Sub
End Class
