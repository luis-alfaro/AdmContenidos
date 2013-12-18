Imports System.Configuration
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports Actividades
Partial Class aspx_MantCriterios
    Inherits System.Web.UI.Page
    Dim cn As New Area : Dim tienda As New tiendas : Dim funciones_otras As New Ubigeo
    Public nodo As TreeNode : Dim areas As New Area : Dim criterio As New criterios
    Dim tabIni As New DataTable : Dim mensaje As String : Dim rpta As Integer = 0
    Dim rp As Integer = 0 : Dim sms As String = "" : Dim fn As New Funciones_Conexion
    Public Shared val As String = ""
    Dim celda As Integer = 0
    Dim celda1 As Integer = 0
    Dim celd As Integer = 0
    Dim celd1 As Integer = 0
    Dim ban As Boolean = False
    Dim ubicacion As String
    Dim tiend As New tiendas
    Dim tt_crite As New tt_detallecriterio
    Dim fnn As New criterios
    Public Shared dtDetalles As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim tip As String = IIf(Request.QueryString("tipo") Is Nothing, "N", Request.QueryString("tipo"))
            Dim codcriterio As String = IIf(Request.QueryString("idcriterio") Is Nothing, "0", Request.QueryString("idcriterio"))

            Dim dts As New DataSet

            If Not IsPostBack Then

                Me.hddidcriterio.Value = codcriterio
                val = tip
                tabIni.Columns.Add("nombre")
                tabIni.Columns.Add("apellido")
                Session("tabSes") = tabIni
                Me.chklstareas.DataSource = areas.listararea(2)
                Me.chklstareas.DataTextField = "Nombre"
                Me.chklstareas.DataValueField = "IdArea"
                Me.chklstareas.DataBind()
                Me.chklstdep.DataSource = funciones_otras.listarubigeos(0, 2, 1, 0)
                Me.chklstdep.DataTextField = "Nombre"
                Me.chklstdep.DataValueField = "UbigeoId"
                Me.chklstdep.DataBind()
                If codcriterio <> 0 Then
                    dts = criterio.lsitarcriterios("3", codcriterio, "", "", "", "")
                    If dts.Tables("consulta").Rows.Count > 0 Then
                        Me.txtnomcriterio.Text = dts.Tables("consulta").Rows(0).Item("nombre").ToString
                    End If
                    Me.GridView2.DataSource = fnn.lsitarcriterios(4, codcriterio, "", "", "", "")
                    Me.GridView2.DataBind()
                End If

                dtDetalles = New DataTable

                dtDetalles.Columns.Add("UBICACION")
                dtDetalles.Columns.Add("AREA")
                dtDetalles.Columns.Add("TIENDA")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstdep.SelectedIndexChanged

        Try
            chklstdist.Items.Clear()
            chklsttiendas.Items.Clear()
            'chklstareas.Items.Clear()


            Dim dts As New DataSet
            Dim coddep As Integer = 0
            Dim indice As Integer = 0
            dts.Clear()
            coddep = Me.chklstdep.SelectedValue
            indice = Me.chklstdep.SelectedValue
            For xf As Integer = 0 To Me.chklstdep.Items.Count - 1
                Me.chklstdep.Items(xf).Selected = False
            Next
            For xf As Integer = 0 To Me.chklstdep.Items.Count - 1
                If Me.chklstdep.Items(xf).Value = indice Then
                    Me.chklstdep.Items(xf).Selected = True
                End If
            Next

            dts = funciones_otras.listarubigeos(0, 3, 2, coddep)
            Me.chklistprov.DataSource = dts
            Me.chklistprov.DataTextField = "nombre"
            Me.chklistprov.DataValueField = "UbigeoId"
            Me.chklistprov.DataBind()
            indice = 0


        Catch

        End Try
    End Sub

    Protected Sub chklistprov_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklistprov.SelectedIndexChanged

        chklstdist.Items.Clear()
        chklsttiendas.Items.Clear()
        'chklstareas.Items.Clear()


        Dim dts As New DataSet
        Dim coddep As Integer = 0
        Dim indice As Integer = 0
        coddep = Me.chklistprov.SelectedValue
        dts = funciones_otras.listarubigeos(0, 3, 3, coddep)
        Me.chklstdist.DataSource = dts
        Me.chklstdist.DataTextField = "nombre"
        Me.chklstdist.DataValueField = "UbigeoId"
        Me.chklstdist.DataBind()

    End Sub

    Protected Sub chklstdist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstdist.SelectedIndexChanged
        Call LlenarTiendas()
    End Sub

    Sub LlenarProvincias()
        Try
            Dim dts As New DataSet
            'Me.chklistprov.Items.Clear()
            'Me.chklstdist.Items.Clear()
            'Me.chklsttiendas.Items.Clear()
            ''Me.chklistprov.Items.Add("")
            'For xca As Integer = 0 To Me.chklstdep.Items.Count - 1
            'Dim coddep As Integer = Me.chklstdep.Items(xca).Value
            'If Me.chklstdep.Items(xca).Selected = True Then
            ''prov = Me.chklistprov.SelectedItem.Text
            ''dpto = Me.chklstdep.SelectedItem.Text & "/" & prov & "/"

            'dts = funciones_otras.listarubigeos(0, 3, 2, coddep)

            'If dts.Tables("consulta").Rows.Count - 1 >= 0 Then
            '    For xcaa As Integer = 0 To dts.Tables("consulta").Rows.Count - 1
            '        Dim nombre As String = dts.Tables("consulta").Rows(xcaa).Item("nombre").ToString
            '        Me.chklistprov.Items.Add(nombre)
            '        Dim valor As Integer = dts.Tables("consulta").Rows(xcaa).Item("UbigeoId").ToString
            '        Me.chklistprov.Items(xcaa).Value = valor
            '        Me.chklistprov.Items(Me.chklistprov.Items.Count - 1).Value = valor
            '    Next
            'End If
            'End If
            'Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub LlenarDistritos()
        Try
            Dim dts As New DataSet
            Me.chklstdist.Items.Clear() 'Me.chklstdist.Items.Add("")
            For xc As Integer = 0 To Me.chklistprov.Items.Count - 1
                Dim coddep As Integer = Me.chklistprov.Items(xc).Value
                If Me.chklistprov.Items(xc).Selected = True Then
                    dts = funciones_otras.listarubigeos(0, 3, 3, coddep)
                    Dim cantidad As Integer = dts.Tables("consulta").Rows.Count - 1
                    If dts.Tables("consulta").Rows.Count - 1 >= 0 Then
                        For xcaa As Integer = 0 To cantidad
                            Dim nombre As String = dts.Tables("consulta").Rows(xcaa).Item("nombre").ToString
                            Dim valor As Integer = dts.Tables("consulta").Rows(xcaa).Item("UbigeoId").ToString
                            Me.chklstdist.Items.Add(nombre)
                            Me.chklstdist.Items(xcaa).Value = valor
                            Me.chklstdist.Items(Me.chklstdist.Items.Count - 1).Value = valor
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub LlenarTiendas()
        Try
            Dim codist As Integer = 0 : Dim coddep As Integer = 0 : Me.chklsttiendas.Items.Clear()
            'For xc As Integer = 0 To Me.chklstdist.Items.Count - 1
            coddep = Me.chklstdist.SelectedValue
            'If Me.chklstdist.Items(xc).Selected = True Then
            Dim dts2 As New DataSet
            'codist = Me.chklstdist.Items(xc - 1).Value
            dts2 = tienda.ListarTiendas("5", coddep, "", "", "", 1)
            Dim cant As Integer = dts2.Tables("consulta").Rows.Count - 1
            If dts2.Tables("consulta").Rows.Count > 0 Then
                For cf As Integer = 0 To cant
                    Dim nombres As String = dts2.Tables("consulta").Rows(cf).Item("SUCURSAL").ToString
                    Dim Codigo As String = dts2.Tables("consulta").Rows(cf).Item("ID").ToString
                    Me.chklsttiendas.Items.Add(nombres)
                    Me.chklsttiendas.Items(Me.chklsttiendas.Items.Count - 1).Value = Codigo
                Next
            End If
            'End If
            'Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim c, d As String
            If val = "N" Then
                If criterio.agregarcriterio(0, Me.txtnomcriterio.Text, 1, rpta, mensaje) >= 1 Then
                    For xf As Integer = 0 To Me.ListBox1.Items.Count - 1
                        c = Me.ListBox2.Items(xf).ToString
                        d = Me.ListBox1.Items(xf).ToString
                        If criterio.agregardetallecriterio(1, rpta, c, d, 1, rp, sms) >= 1 Then
                        End If
                    Next
                End If
            Else
                If criterio.agregarcriterio(Me.hddidcriterio.Value, Me.txtnomcriterio.Text, 2, rpta, mensaje) >= 1 Then
                    For xf As Integer = 0 To Me.ListBox1.Items.Count - 1
                        c = Me.ListBox2.Items(xf).ToString
                        d = Me.ListBox1.Items(xf).ToString
                        If criterio.agregardetallecriterio(2, Me.hddidcriterio.Value, c, d, 1, rp, sms) >= 1 Then
                        End If
                    Next
                End If
            End If
            Response.Redirect("ListadoCriterios.aspx")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            Dim rp As Integer = 0
            Dim sms As String = ""
            Me.ListBox1.Items.Clear() : Me.ListBox2.Items.Clear()
            Dim cantareas As Integer = 0 : Dim canttiendas As Integer = 0 : Dim total As Integer = 0
            If tt_crite.agregartt_criterio("1", "", "", "", rp, sms) Then

            End If





            For x As Integer = 0 To Me.chklstareas.Items.Count - 1
                If Me.chklstareas.Items(x).Selected = True Then
                    Dim c, d As String
                    c = Me.chklstareas.Items(x).Value
                    d = Me.chklstareas.Items(x).Text
                    For xa As Integer = 0 To Me.chklsttiendas.Items.Count - 1
                        If Me.chklsttiendas.Items(xa).Selected = True Then
                            Dim co As Integer = Me.chklsttiendas.Items(xa).Value
                            Dim dts2 As New DataSet
                            dts2 = tiend.ListarTiendas("6", co, "", "", "", 1)
                            Dim cant As Integer = dts2.Tables("consulta").Rows.Count - 1
                            If dts2.Tables("consulta").Rows.Count > 0 Then
                                ubicacion = dts2.Tables("consulta").Rows(0).Item("ubicacion").ToString
                            End If
                            Dim codtienda As Integer = Me.chklsttiendas.Items(xa).Value
                            Dim tienda As String = Me.chklsttiendas.Items(xa).Text
                            If tt_crite.agregartt_criterio("2", ubicacion, d, tienda, rp, sms) >= 1 Then
                            End If
                            Dim ti As String = Me.chklstareas.Items(celda).Value
                            Me.ListBox1.Items.Add(c)
                            Me.ListBox2.Items.Add(codtienda)
                            celda1 = celda1 + 1
                            codtienda = 0
                            tienda = ""
                        End If
                    Next
                    celda = celda + 1
                End If
            Next



            Dim dtTemp As DataTable = tt_crite.listarareacod().Tables(0)
 


            For Each item As DataRow In dtTemp.Rows

                Dim arrayTemp(2) As String
                arrayTemp(0) = item(0)
                arrayTemp(1) = item(1)
                arrayTemp(2) = item(2)

                dtDetalles.Rows.Add(arrayTemp)
            Next

            Me.GridView1.DataSource = dtDetalles
            Me.GridView1.DataBind()
            If tt_crite.agregartt_criterio("1", "", "", "", rp, sms) Then
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim c, d As String
            If val = "N" Then
                If criterio.agregarcriterio(0, Me.txtnomcriterio.Text, 1, rpta, mensaje) >= 1 Then
                    Me.hddidcriterio.Value = rpta
                    For xf As Integer = 0 To Me.ListBox1.Items.Count - 1
                        c = Me.ListBox2.Items(xf).ToString
                        d = Me.ListBox1.Items(xf).ToString
                        If criterio.agregardetallecriterio(1, rpta, Me.ListBox2.Items(xf).ToString, Me.ListBox1.Items(xf).ToString, 1, rp, sms) >= 1 Then
                        End If
                    Next
                    Response.Redirect("MantCriterios.aspx?idcriterio=" & rpta & "&tipo=E")
                End If
            Else
                If criterio.agregarcriterio(Me.hddidcriterio.Value, Me.txtnomcriterio.Text, 2, rpta, mensaje) >= 1 Then
                    For xf As Integer = 0 To Me.ListBox1.Items.Count - 1
                        c = Me.ListBox2.Items(xf).ToString
                        d = Me.ListBox1.Items(xf).ToString
                        If criterio.agregardetallecriterio(2, Me.hddidcriterio.Value, c, d, 1, rp, sms) >= 1 Then
                        End If
                    Next
                    Response.Redirect("MantCriterios.aspx?idcriterio=" & Me.hddidcriterio.Value & "&tipo=E")
                End If

            End If

        Catch ex As Exception


        End Try
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Response.Redirect("ListadoCriterios.aspx")
    End Sub

    Protected Sub chkactivar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkactivar.CheckedChanged
        Try
            If Me.chkactivar.Checked = True Then
                For xd As Integer = 0 To Me.chklstareas.Items.Count - 1
                    Me.chklstareas.Items(xd).Selected = True
                Next
            Else
                For xd As Integer = 0 To Me.chklstareas.Items.Count - 1
                    Me.chklstareas.Items(xd).Selected = False
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub


End Class

