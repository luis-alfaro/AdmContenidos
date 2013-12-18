Imports System.Data
Imports System.Web.Security
Imports DataAccess


Partial Class aspx_sec_banners_ordenar
    Inherits System.Web.UI.Page

    Private sMensajeError As String = ""
    Private sSQL As String = ""


    Private Sub m_actualizar_orden()

        Dim lFila As Long = 0
        Dim sIDX As String = ""



        Dim objBanner As New Banners

        For lFila = 0 To LstBanners.Items.Count - 1
            sIDX = ""
            sIDX = LstBanners.Items.Item(lFila).Value

            Try
                
                objBanner.Update_BannerNuOrd(sIDX, lFila + 1)

            Catch ex As Exception
                sMensajeError = ex.Message.Trim
                Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            End Try

        Next

    End Sub


    Private Sub m_refresh_lista_banners()

        Dim oDataTable As New DataTable

        Dim sMensajeError As String

        sMensajeError = ""

        Dim objBanner As New Banners

        Try


            oDataTable = objBanner.Get_Banners(Integer.Parse(Request.Item("idcriterio")))


            LstBanners.Items.Clear()
            If oDataTable.Rows.Count > 0 Then
                LstBanners.DataSource = oDataTable
                LstBanners.DataValueField = "IDX"
                LstBanners.DataTextField = "Banner"
                LstBanners.DataBind()
            End If

            oDataTable.Clear()
            oDataTable = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            m_refresh_lista_banners()
        End If


    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("sec_banners.aspx")
    End Sub

    Protected Sub btnsubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubir.Click

        If LstBanners.Items.Count = 1 Then
            Exit Sub
        End If

        Dim lItemSeleccionado As Long = -1
        lItemSeleccionado = CLng(lblidselect.Text.Trim)

        Dim strListItems(1) As String

        strListItems(0) = LstBanners.Items.Item(lItemSeleccionado - 1).Text
        strListItems(1) = LstBanners.Items.Item(lItemSeleccionado - 1).Value

        LstBanners.Items.Item(lItemSeleccionado - 1).Text = LstBanners.Items.Item(lItemSeleccionado).Text
        LstBanners.Items.Item(lItemSeleccionado - 1).Value = LstBanners.Items.Item(lItemSeleccionado).Value

        LstBanners.Items.Item(lItemSeleccionado).Text = strListItems(0)
        LstBanners.Items.Item(lItemSeleccionado).Value = strListItems(1)

        LstBanners.Items.Item(lItemSeleccionado).Selected = False
        LstBanners.Items.Item(lItemSeleccionado - 1).Selected = True

        lItemSeleccionado = lItemSeleccionado - 1
        lblidselect.Text = lItemSeleccionado.ToString.Trim
        
        LstBanners_SelectedIndexChanged(sender, e)

    End Sub

   
    Protected Sub LstBanners_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstBanners.SelectedIndexChanged

        lblidselect.Text = LstBanners.SelectedIndex.ToString

        If LstBanners.Items.Count < 1 Then Exit Sub

        Select Case lblidselect.Text.Trim
            Case "0"
                btnsubir.Enabled = False
                btnbajar.Enabled = True

            Case LstBanners.Items.Count - 1

                btnsubir.Enabled = True
                btnbajar.Enabled = False

            Case Else
                btnsubir.Enabled = True
                btnbajar.Enabled = True
        End Select


    End Sub

    Protected Sub btnbajar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbajar.Click

        If LstBanners.Items.Count = 1 Then
            Exit Sub
        End If

        Dim lItemSeleccionado As Long = -1
        lItemSeleccionado = CLng(lblidselect.Text.Trim)

        Dim strListItems(1) As String

        strListItems(0) = LstBanners.Items.Item(lItemSeleccionado + 1).Text
        strListItems(1) = LstBanners.Items.Item(lItemSeleccionado + 1).Value

        LstBanners.Items.Item(lItemSeleccionado + 1).Text = LstBanners.Items.Item(lItemSeleccionado).Text
        LstBanners.Items.Item(lItemSeleccionado + 1).Value = LstBanners.Items.Item(lItemSeleccionado).Value

        LstBanners.Items.Item(lItemSeleccionado).Text = strListItems(0)
        LstBanners.Items.Item(lItemSeleccionado).Value = strListItems(1)

        LstBanners.Items.Item(lItemSeleccionado).Selected = False
        LstBanners.Items.Item(lItemSeleccionado + 1).Selected = True

        lItemSeleccionado = lItemSeleccionado + 1
        lblidselect.Text = lItemSeleccionado.ToString.Trim

        LstBanners_SelectedIndexChanged(sender, e)

    End Sub

    Protected Sub bntaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntaceptar.Click
        lblmsg.Text = ""
        If LstBanners.Items.Count > 0 Then
            m_actualizar_orden()
            Response.Redirect("sec_banners.aspx")
        Else
            lblmsg.Text = "No existen banners registrados."
        End If


    End Sub
End Class
