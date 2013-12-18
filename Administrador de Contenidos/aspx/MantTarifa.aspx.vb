Imports System.Data




Partial Class aspx_MantTarifa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then
            Try


                Dim ds As DataSet = Sql_Get_TasasSimulador()

                Dim dtSoles As DataTable = ds.Tables(0)

                txtSolesMenos1.Text = dtSoles.Rows(0)(5)
                txtSolesMenos2.Text = dtSoles.Rows(1)(5)
                txtSolesMenos3.Text = dtSoles.Rows(2)(5)
                txtSolesMenos4.Text = dtSoles.Rows(3)(5)
                txtSolesMenos5.Text = dtSoles.Rows(4)(5)
                txtSolesMenos6.Text = dtSoles.Rows(5)(5)
                txtSolesMenos7.Text = dtSoles.Rows(6)(5)
                txtSolesMenos8.Text = dtSoles.Rows(7)(5)
                txtSolesMenos9.Text = dtSoles.Rows(8)(5)

                txtSolesMax1.Text = dtSoles.Rows(0)(6)
                txtSolesMax2.Text = dtSoles.Rows(1)(6)
                txtSolesMax3.Text = dtSoles.Rows(2)(6)
                txtSolesMax4.Text = dtSoles.Rows(3)(6)
                txtSolesMax5.Text = dtSoles.Rows(4)(6)
                txtSolesMax6.Text = dtSoles.Rows(5)(6)
                txtSolesMax7.Text = dtSoles.Rows(6)(6)
                txtSolesMax8.Text = dtSoles.Rows(7)(6)
                txtSolesMax9.Text = dtSoles.Rows(8)(6)


                lblDescripcion1.Text = dtSoles.Rows(0)(2)
                lblDescripcion2.Text = dtSoles.Rows(1)(2)
                lblDescripcion3.Text = dtSoles.Rows(2)(2)
                lblDescripcion4.Text = dtSoles.Rows(3)(2)
                lblDescripcion5.Text = dtSoles.Rows(4)(2)
                lblDescripcion6.Text = dtSoles.Rows(5)(2)
                lblDescripcion7.Text = dtSoles.Rows(6)(2)
                lblDescripcion8.Text = dtSoles.Rows(7)(2)
                lblDescripcion9.Text = dtSoles.Rows(8)(2)

                Dim dtDolares As DataTable = ds.Tables(1)

                txtDolares1.Text = dtDolares.Rows(0)(0)
                txtDolares2.Text = dtDolares.Rows(1)(0)
                txtDolares3.Text = dtDolares.Rows(2)(0)
                txtDolares4.Text = dtDolares.Rows(3)(0)
                txtDolares5.Text = dtDolares.Rows(4)(0)
                txtDolares6.Text = dtDolares.Rows(5)(0)
                txtDolares7.Text = dtDolares.Rows(6)(0)
                txtDolares8.Text = dtDolares.Rows(7)(0)
                txtDolares9.Text = dtDolares.Rows(8)(0)


            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try


            Sql_Update_Tarifas(1, "S", txtSolesMenos1.Text, txtSolesMax1.Text)
            Sql_Update_Tarifas(2, "S", txtSolesMenos2.Text, txtSolesMax2.Text)
            Sql_Update_Tarifas(3, "S", txtSolesMenos3.Text, txtSolesMax3.Text)
            Sql_Update_Tarifas(4, "S", txtSolesMenos4.Text, txtSolesMax4.Text)
            Sql_Update_Tarifas(5, "S", txtSolesMenos5.Text, txtSolesMax5.Text)
            Sql_Update_Tarifas(6, "S", txtSolesMenos6.Text, txtSolesMax6.Text)
            Sql_Update_Tarifas(7, "S", txtSolesMenos7.Text, txtSolesMax7.Text)
            Sql_Update_Tarifas(8, "S", txtSolesMenos8.Text, txtSolesMax8.Text)
            Sql_Update_Tarifas(9, "S", txtSolesMenos9.Text, txtSolesMax9.Text)
            Sql_Update_Tarifas(10, "D", txtDolares1.Text, 0)
            Sql_Update_Tarifas(11, "D", txtDolares2.Text, 0)
            Sql_Update_Tarifas(12, "D", txtDolares3.Text, 0)
            Sql_Update_Tarifas(13, "D", txtDolares4.Text, 0)
            Sql_Update_Tarifas(14, "D", txtDolares5.Text, 0)
            Sql_Update_Tarifas(15, "D", txtDolares6.Text, 0)
            Sql_Update_Tarifas(16, "D", txtDolares7.Text, 0)
            Sql_Update_Tarifas(17, "D", txtDolares8.Text, 0)
            Sql_Update_Tarifas(18, "D", txtDolares9.Text, 0)




        Catch ex As Exception

        End Try
    End Sub
End Class
