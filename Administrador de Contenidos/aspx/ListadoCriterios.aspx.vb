Imports System.Data
Partial Class aspx_ListadoCriterios
    Inherits System.Web.UI.Page
    Dim fn As New criterios
    Public val As Integer
    Dim rp As Integer = 0
    Dim rpta As String = ""
    Public codigo(1000) As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codcriterio As String = IIf(Request.QueryString("idcriterio") Is Nothing, "0", Request.QueryString("idcriterio"))
        val = codcriterio
        If Not IsPostBack Then
            Call CargarGrid()

            Call VerDetalle(val)

        End If
        chkHabilitados_CheckedChanged(sender, e)
    End Sub
    Sub VerDetalle(ByVal valor As Integer)
        Me.GridView2.DataSource = fn.lsitarcriterios(2, valor, "", "", "", "")
        Me.GridView2.DataBind()
        Dim f As Integer = 0
        Dim r As Integer = 0
        f = 0
        For Each row As GridViewRow In Me.GridView2.Rows
            Dim check As CheckBox = TryCast(row.FindControl("chkestado"), CheckBox)
            Dim est As String = Me.GridView2.Rows(f).Cells(3).Text
            If est = "Deshabilitada" Then
                check.Checked = False
            Else
                check.Checked = True
            End If
            f = f + 1
        Next
    End Sub
    Sub CargarGrid()
        Try
            Dim dts As New DataSet
            dts = fn.lsitarcriterios(1, "", "", "", "", "")
            Me.GridView1.DataSource = dts.Tables("consulta")
            Me.GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("MantCriterios.aspx?tipo=N")
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Dim cont As Integer = 0
        Dim lnkeditar As New HyperLink
        Dim lnkseleccionar As New HyperLink
        Dim dts As New DataSet

        Try

            dts = fn.lsitarcriterios(1, "", "", "", "", "")




            For cont = 0 To dts.Tables("consulta").Rows.Count - 1
                lnkeditar = Me.GridView1.Rows(cont).FindControl("lnkEditar")
                lnkeditar.NavigateUrl = "MantCriterios.aspx?idcriterio=" & dts.Tables("consulta").Rows(cont)("idcriterio").ToString & "&tipo=E"
            Next
            For cont = 0 To dts.Tables("consulta").Rows.Count - 1
                lnkseleccionar = Me.GridView1.Rows(cont).FindControl("lnkseleccionar")
                lnkseleccionar.NavigateUrl = "ListadoCriterios.aspx?idcriterio=" + dts.Tables("consulta").Rows(cont)("idcriterio").ToString
            Next

            If IsPostBack = False Then
                GridView2.Focus()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call VerDetalle(0)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim chkestado As New CheckBox
        Try
            Dim r, f As Integer
            Dim c As Integer
            r = 0
            f = 0
            For Each row As GridViewRow In Me.GridView2.Rows
                Dim check As CheckBox = TryCast(row.FindControl("chkestado"), CheckBox)
                If check.Checked = True Then
                    c = Me.ListBox1.Items(r).Text
                    If fn.actualizarestados(c, 1, rp, rpta) >= 1 Then
                        r = r + 1
                    End If
                Else
                    c = Me.ListBox1.Items(r).Text
                    If fn.actualizarestados(c, 2, rp, rpta) >= 1 Then
                        r = r + 1
                    End If
                End If
                f = f + 1

            Next
            Call VerDetalle(val)
            f = 0
            For Each row As GridViewRow In Me.GridView2.Rows
                r = r + 1
                Dim check As CheckBox = TryCast(row.FindControl("chkestado"), CheckBox)
                Dim est As String = Me.GridView2.Rows(f).Cells(3).Text
                If est = "Deshabilitada" Then
                    check.Checked = False
                Else
                    check.Checked = True
                End If
                f = f + 1
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub GridView2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.DataBound
        Try
            Me.ListBox1.Items.Clear()
            Dim cont As Integer = 0
            Dim dts As New DataSet
            dts = fn.lsitarcriterios(2, val, "", "", "", "")
            ReDim Preserve codigo(dts.Tables("consulta").Rows.Count - 1)
            For cont = 0 To dts.Tables("consulta").Rows.Count - 1
                'codigo(cont) = dts.Tables("consulta").Rows(cont)("iddetalle_criterio").ToString
                Me.ListBox1.Items.Add(dts.Tables("consulta").Rows(cont)("iddetalle_criterio").ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub chkDeshabilitar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim chk As CheckBox = sender

            Dim objCriterios As New criterios()
            objCriterios.DeshabilitarCriterios(chk.TabIndex, chk.Checked)

            chk.Focus()

        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub chkHabilitados_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHabilitados.CheckedChanged
        Try
            'Me.GridView1.DataSource = funciones_otras.listarubigeos("1", "4", "1", "0")
            'Me.GridView1.DataBind()

            If chkHabilitados.Checked = True Then ' todos

                For Each item As GridViewRow In GridView1.Rows
                    item.Visible = True

                Next
            Else 'solo habilitados

                For Each item As GridViewRow In GridView1.Rows
                    'If item.Cells(2).Then Then
                    'item.Visible = False
                    'End If
                    Dim objchk As CheckBox = item.FindControl("chkDeshabilitar")

                    If objchk.Checked = False Then
                        item.Visible = False
                    End If
                Next


            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
