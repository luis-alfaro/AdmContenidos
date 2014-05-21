
Imports System.Data
Partial Class aspx_MantTiendas
    Inherits System.Web.UI.Page
    Dim fn As New Funciones_Conexion
    Dim cn As New tiendas
    Dim areas As New Area
    Dim funciones_otras As New Ubigeo
    Public nodo As New TreeNode
    Public rp As Integer = 0
    Public rpp As String = ""
    Public rps As Integer = 0
    Public rppp As String = ""

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If txttienda.Text.Trim() = "" Then
                lblmsg.Text = "Ingrese el nombre de Tienda"
                lblmsg.Visible = True
            Else
                lblmsg.Visible = False
            End If

            If txtubigeo.Text.Trim() = "" Then
                lblmsg.Text = "Ingrese la ubicación de la tienda"
                lblmsg.Visible = True
            Else
                lblmsg.Visible = False
            End If

            Dim es As Integer = 2
            If Me.CheckBox1.Checked = True Then
                es = 1
            Else
                es = 2
            End If
            If Me.hddtienda.Value > 0 Then
                'cambio v2
                If cn.grabar(Me.txtdireccion.Text, Me.hddtienda.Value, Me.txttienda.Text, Me.hddidubigeo.Value, es, Me.txtcod_suc_banco.Text, txtHor1Inicio.Text, txtHor1Fin.Text, txtHor2Inicio.Text, txtHor2Fin.Text, txthini_cli.Text, txthfin_cli.Text, 2, rp, rpp) >= 1 Then
                    'edita
                    For cant As Integer = 0 To Me.chklstareas.Items.Count - 1
                        Dim val As Integer
                        If Me.chklstareas.Items(cant).Selected = True Then
                            val = 1
                        Else
                            val = 2
                        End If
                        cn.grabareastienda(val, "2", hddtienda.Value, Me.chklstareas.Items(cant).Value, "1", rps, rppp)

                    Next
                    Response.Redirect("ListadoTiendas.aspx")
                End If
            Else

                If cn.grabar(Me.txtdireccion.Text, 0, Me.txttienda.Text, Me.hddidubigeo.Value, es, Me.txtcod_suc_banco.Text, txtHor1Inicio.Text, txtHor1Fin.Text, txtHor2Inicio.Text, txtHor2Fin.Text, txthini_cli.Text, txthfin_cli.Text, 1, rp, rpp) >= 1 Then
                    For cant As Integer = 0 To Me.chklstareas.Items.Count - 1
                        If Me.chklstareas.Items(cant).Selected = True Then
                            If Me.chklstareas.Items(cant).Selected = True Then
                                cn.grabareastienda(0, "1", rp, Me.chklstareas.Items(cant).Value, "1", rps, rppp)
                            End If
                        End If
                    Next
                End If
                Response.Redirect("ListadoTiendas.aspx")
            End If

            
        Catch ex As Exception
            'MsgBox(ex.ToString)

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.chklstareas.DataSource = areas.listararea(2)
                Me.chklstareas.DataTextField = "Nombre"
                Me.chklstareas.DataValueField = "IdArea"
                Me.chklstareas.DataBind()

               
                Dim tipooper As String = IIf(Request.QueryString("tipoope") Is Nothing, "0", Request.QueryString("tipoope"))
                Dim idtiendas As String = IIf(Request.QueryString("idtienda") Is Nothing, "0", Request.QueryString("idtienda"))
                nodo = New TreeNode
                Me.treeubigeo.Nodes.Clear()
                nodo.Value = "0"
                nodo.Text = "Ubigeo"
                Me.treeubigeo.Nodes.Add(nodo)
                Call mostrarnodos(nodo)
                Me.hddtienda.Value = idtiendas

                'Dim dts As New DataSet
                'dts = cn.ListarTiendas("3", hddtienda.Value, "", "", "", 0)
                'If dts.Tables("consulta").Rows.Count > 0 Then
                '    Me.txttienda.Text = dts.Tables("consulta").Rows(0).Item("sucursal").ToString
                '    Me.txtdireccion.Text = dts.Tables("consulta").Rows(0).Item("direccion").ToString
                '    Me.hddidubigeo.Value = dts.Tables("consulta").Rows(0).Item("IdUbigeo").ToString
                '    If dts.Tables("consulta").Rows(0).Item("esttienda").ToString = "1" Then
                '        Me.CheckBox1.Checked = True
                '    Else
                '        Me.CheckBox1.Checked = False
                '    End If
                '    dts = funciones_otras.obtenerubigeo(Me.hddidubigeo.Value)
                '    If dts.Tables("consulta").Rows.Count > 0 Then
                '        Me.txtubigeo.Text = dts.Tables("consulta").Rows(0).Item("ubicacion").ToString
                '    End If
                '    dts = cn.listarareastienda("1", hddtienda.Value, "", "", "")
                '    Dim xarea, xare As Integer
                '    Dim xest As Integer
                '    For xcant As Integer = 0 To dts.Tables("consulta").Rows.Count - 1
                '        xarea = dts.Tables("consulta").Rows(xcant).Item("idarea").ToString
                '        xest = dts.Tables("consulta").Rows(xcant).Item("estareatienda").ToString
                '        For xcat As Integer = 0 To Me.chklstareas.Items.Count - 1
                '            xare = Me.chklstareas.Items(xcat).Value
                '            If xest = 1 And xarea = xare Then
                '                Me.chklstareas.Items(xcat).Selected = True
                '                xcat = Me.chklstareas.Items.Count - 1
                '            End If
                '        Next
                '    Next
                'End If
                Dim dts As New DataTable
                dts = cn.ObtenerTiendaByID(hddtienda.Value)
                If dts.Rows.Count > 0 Then
                    Me.txttienda.Text = dts.Rows(0).Item("sucursal").ToString()
                    Me.txtdireccion.Text = dts.Rows(0).Item("direccion").ToString()
                    Me.txtcod_suc_banco.Text = dts.Rows(0).Item("cod_sucursal_banco").ToString()
                    Me.hddidubigeo.Value = dts.Rows(0).Item("IdUbigeo").ToString()
                    txtHor1Inicio.Text = dts.Rows(0).Item("hini_com1").ToString()
                    txtHor1Fin.Text = dts.Rows(0).Item("hfin_com1").ToString()
                    txtHor2Inicio.Text = dts.Rows(0).Item("hini_com2").ToString()
                    txtHor2Fin.Text = dts.Rows(0).Item("hfin_com2").ToString()
                    txthini_cli.Text = dts.Rows(0).Item("hini_cli").ToString()
                    txthfin_cli.Text = dts.Rows(0).Item("hfin_cli").ToString()
                    If dts.Rows(0).Item("esttienda").ToString() = "1" Then
                        Me.CheckBox1.Checked = True
                    Else
                        Me.CheckBox1.Checked = False
                    End If
                    dts = funciones_otras.obtenerubigeo(Me.hddidubigeo.Value).Tables(0)
                    If dts.Rows.Count > 0 Then
                        Me.txtubigeo.Text = dts.Rows(0).Item("ubicacion").ToString()
                    End If
                    dts = cn.listarareastienda("1", hddtienda.Value, "", "", "").Tables(0)
                    Dim xarea, xare As Integer
                    Dim xest As Integer
                    For xcant As Integer = 0 To dts.Rows.Count - 1
                        xarea = dts.Rows(xcant).Item("idarea").ToString()
                        xest = dts.Rows(xcant).Item("estareatienda").ToString()
                        For xcat As Integer = 0 To Me.chklstareas.Items.Count - 1
                            xare = Me.chklstareas.Items(xcat).Value
                            If xest = 1 And xarea = xare Then
                                Me.chklstareas.Items(xcat).Selected = True
                                xcat = Me.chklstareas.Items.Count - 1
                            End If
                        Next
                    Next
                End If


            End If
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
            Dim dts As New DataSet
            dts = funciones_otras.obtenerubigeo(Me.treeubigeo.SelectedNode.Value)
            If dts.Tables("consulta").Rows.Count > 0 Then
                Me.txtubigeo.Text = dts.Tables("consulta").Rows(0).Item("ubicacion").ToString
                Me.hddidubigeo.Value = Me.treeubigeo.SelectedNode.Value
                Me.treeubigeo.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.treeubigeo.ExpandDepth = 1
        If Me.treeubigeo.Visible = False Then
            Me.treeubigeo.Visible = True
        Else
            Me.treeubigeo.Visible = False
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            For xa As Integer = 0 To Me.chklstareas.Items.Count - 1
                Me.chklstareas.Items(xa).Selected = True
            Next
        Else
            For xa As Integer = 0 To Me.chklstareas.Items.Count - 1
                Me.chklstareas.Items(xa).Selected = False
            Next
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("ListadoTiendas.aspx")
    End Sub
End Class
