Imports System.Data
Partial Class aspx_MantDepartamento
    Inherits System.Web.UI.Page
    Dim funciones_otras As New Ubigeo
    Public iddep As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idtip As String = IIf(Request.QueryString("idtipo") Is Nothing, "0", Request.QueryString("idtipo"))
        Dim dts As New DataSet

        If Not IsPostBack Then
            Me.ddldepartamento.DataSource = funciones_otras.listarubigeos("1", "2", "1", "0")
            Me.ddldepartamento.DataTextField = "nombre"
            Me.ddldepartamento.DataValueField = "ubigeoid"
            Me.ddldepartamento.DataBind()
        End If
        If idtip = 1 Then
            Me.Label1.Text = "Dpto:"
            Me.Label2.Text = ""
            Me.Label3.Text = ""
            Me.ddldepartamento.Visible = False
            Me.ddldepartamento_SelectedIndexChanged(sender, e)
            'Dim dsUbigeo As dataset
            Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "2", "1", "0")
            Me.GridView1.DataBind()

            Me.ddlprovincia.Visible = False
        ElseIf idtip = 2 Then
            Me.Label1.Text = "Provincia:"
            Me.Label2.Text = "Dpto:"
            Me.Label3.Text = ""
            Me.ddldepartamento.Visible = True
            'If ddlprovincia.Items.Count > 0 Then
            Me.ddldepartamento_SelectedIndexChanged(sender, e)
            'End If
            Me.ddlprovincia.Visible = False

        ElseIf idtip = 3 Then
            Me.Label2.Text = "Dpto:"
            Me.Label3.Text = "Provincia:"
            Me.Label1.Text = "Distrito:"
            Me.ddldepartamento.Visible = True
            Me.ddldepartamento_SelectedIndexChanged(sender, e)
            Me.ddlprovincia.Visible = True
            'Me.ddlprovincia_SelectedIndexChanged(sender, e)
        End If
        Dim variable As Integer
        variable = Session.Item("TreeViewUbigeEmerg")
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            Dim tipo As String = IIf(Request.QueryString("idtipo") Is Nothing, "0", Request.QueryString("idtipo"))
            Dim rp As Integer = 0
            Dim rpp As String = ""
            If txtubigeo.Text.ToString().Trim() = "" Then

                Exit Sub
            End If

            If tipo = 1 Then
                If funciones_otras.AgregarUbigeo(Me.txtubigeo.Text, tipo, "0", 1, rp, rpp) > 0 Then

                End If
            ElseIf tipo = 2 Then
                If funciones_otras.AgregarUbigeo(Me.txtubigeo.Text, tipo, Me.ddldepartamento.SelectedValue, 1, rp, rpp) > 0 Then

                End If
            ElseIf tipo = 3 Then
                If funciones_otras.AgregarUbigeo(Me.txtubigeo.Text, tipo, Me.ddlprovincia.SelectedValue, 1, rp, rpp) > 0 Then

                End If
            End If
            'MsgBox(rpp)
            Response.Redirect("MantUbigeo.aspx")
            Me.txtubigeo.Text = ""
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub ddldepartamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldepartamento.SelectedIndexChanged
        Try
            iddep = Me.ddldepartamento.SelectedValue

            Dim dsTempPrinvicias As DataSet = funciones_otras.listarubigeos("1", "3", "2", iddep)
            '''''''''''
            Dim tipo As String = IIf(Request.QueryString("idtipo") Is Nothing, "0", Request.QueryString("idtipo"))
            If dsTempPrinvicias.Tables(0).Rows.Count > 0 Then
                Me.ddlprovincia.DataSource = dsTempPrinvicias
                Me.ddlprovincia.DataTextField = "nombre"
                Me.ddlprovincia.DataValueField = "ubigeoid"
                Me.ddlprovincia.DataBind()
                Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "3", "2", iddep)
                Me.GridView1.DataBind()




                If tipo = "3" Then
                    ddlprovincia_SelectedIndexChanged(sender, e)
                End If

                txtubigeo.Enabled = True
            Else
                ddlprovincia.Items.Clear()
                ddlprovincia.Items.Add("(Vacio)")

                If tipo = "3" Then
                    txtubigeo.Enabled = False
                End If

                GridView1.DataSource = Nothing
                GridView1.DataBind()

            End If
            ''''''''''''''''


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub ddlprovincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlprovincia.SelectedIndexChanged
        Try
            ''''''''''
            If Me.ddlprovincia.SelectedValue = "(Vacio)" Then
                txtubigeo.Enabled = False
                Exit Sub
            Else
                txtubigeo.Enabled = True
            End If

            iddep = Me.ddlprovincia.SelectedValue
            ''''''''''''

            Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "3", "3", iddep)
            Me.GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("MantUbigeo.aspx")
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Try
            Dim lFila As Long = e.RowIndex
            Dim lUbigeo As Long = 0
            lUbigeo = GridView1.DataKeys(lFila).Value
            Sql_Detele_Ubigeo(lUbigeo)

            Dim tempDT As DataSet = GridView1.DataSource

            For Each item As DataRow In tempDT.Tables(0).Rows
                If item(0) = lUbigeo Then
                    tempDT.Tables(0).Rows.Remove(item)
                    Exit For
                End If
            Next

            GridView1.DataSource = tempDT
            GridView1.DataBind()

            'call eliminar y refresh



        Catch ex As Exception

        End Try
    End Sub
End Class
