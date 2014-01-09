Imports System.Data
Partial Class aspx_MantConfiguracionKioskos
    Inherits System.Web.UI.Page
    Dim rp As Integer = 0
    Dim mensaje As String = ""
    Dim kio As New kioskos
    Public Shared valor As String '= "N"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim tipo As String = IIf(Request.QueryString("tipo") Is Nothing, "N", Request.QueryString("tipo"))

            Dim dts As New DataSet
            Dim ID As String = IIf(Request.QueryString("ID") Is Nothing, "0", Request.QueryString("ID"))

            'idkio=1&tipo=E
            If Not IsPostBack Then
                valor = tipo

                Me.hddID.Value = ID


                If ID <> "0" Then
                    dts = kio.GetConfiguracionKioskoPorID(ID)
                    If dts.Tables("consulta").Rows.Count > 0 Then
                        Me.txtnombre.Text = dts.Tables("consulta").Rows(0).Item("NOMBRE").ToString
                        Me.txtServer.Text = dts.Tables("consulta").Rows(0).Item("SERVER").ToString
                        Me.txtServerSimulador.Text = dts.Tables("consulta").Rows(0).Item("SERVER_SIMULADOR").ToString
                        Me.txtServerPrint.Text = dts.Tables("consulta").Rows(0).Item("SERVER_PRINT").ToString
                        Me.txtServerCom.Text = dts.Tables("consulta").Rows(0).Item("SERVER_COM").ToString

                        Me.txtBin1.Value = dts.Tables("consulta").Rows(0).Item("BIN1").ToString
                        Me.txtLongitudTarjetaBin1.Value = dts.Tables("consulta").Rows(0).Item("LONGITUD_TARJETA_BIN1").ToString
                        Me.txtPosicionInicialBin1.Value = dts.Tables("consulta").Rows(0).Item("POSINI_BIN1").ToString
                        Me.txtLongitudBinBin1.Value = dts.Tables("consulta").Rows(0).Item("LONGITUD_BIN_BIN1").ToString

                        Me.txtBin2.Value = dts.Tables("consulta").Rows(0).Item("BIN2").ToString
                        Me.txtLongitudTarjetaBin2.Value = dts.Tables("consulta").Rows(0).Item("LONGITUD_TARJETA_BIN2").ToString
                        Me.txtPosicionInicialBin2.Value = dts.Tables("consulta").Rows(0).Item("POSINI_BIN2").ToString
                        Me.txtLongitudBinBin2.Value = dts.Tables("consulta").Rows(0).Item("LONGITUD_BIN_BIN2").ToString

                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If valor = "N" Then
                If kio.grabarConfiguracionKiosko(0, txtnombre.Text, txtServer.Text, txtServerSimulador.Text, txtServerPrint.Text, txtServerCom.Text, txtBin1.Value, txtLongitudTarjetaBin1.Value, txtPosicionInicialBin1.Value, txtLongitudBinBin1.Value, txtBin2.Value, txtLongitudTarjetaBin2.Value, txtPosicionInicialBin2.Value, txtLongitudBinBin2.Value, rp, mensaje) >= 1 Then
                    Response.Redirect("ListadoConfiguracionKioskos.aspx")
                End If
            Else
                If kio.grabarConfiguracionKiosko(Me.hddID.Value, txtnombre.Text, txtServer.Text, txtServerSimulador.Text, txtServerPrint.Text, txtServerCom.Text, txtBin1.Value, txtLongitudTarjetaBin1.Value, txtPosicionInicialBin1.Value, txtLongitudBinBin1.Value, txtBin2.Value, txtLongitudTarjetaBin2.Value, txtPosicionInicialBin2.Value, txtLongitudBinBin2.Value, rp, mensaje) >= 1 Then
                    Response.Redirect("ListadoConfiguracionKioskos.aspx")
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = "Hubo un error y no se pudieron guardar los cambios, intentelo más tarde."
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("ListadoConfiguracionKioskos.aspx")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim ID As String = IIf(Request.QueryString("ID") Is Nothing, "0", Request.QueryString("ID"))

            Sql_Detele_ConfiguracionKiosco(ID)

            Response.Redirect("ListadoConfiguracionKioskos.aspx")
        Catch ex As Exception
            'MsgBox(ex.Message + ex.StackTrace)
            lblError.Visible = True
            lblError.Text = "No se pudo eliminar la configuración, es posible que un kiosko la esté utilizando."
        End Try
    End Sub
End Class
