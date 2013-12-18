Imports System.Data
Imports System.Web.Security
Imports DataAccess

Partial Class aspx_sec_banners
    Inherits System.Web.UI.Page

    Private sMensajeError As String = ""
    Private sSQL As String = ""



    Private Sub m_formatear_grilla()

        Try
            'Ancho de Columnas
            gvListaBanners.Columns(0).ItemStyle.Width = 1 'IDX
            gvListaBanners.Columns(1).ItemStyle.Width = 280 'Banner
            gvListaBanners.Columns(2).ItemStyle.Width = 10 'NuOrd
            gvListaBanners.Columns(3).ItemStyle.Width = 10 'Filtrar
            gvListaBanners.Columns(4).ItemStyle.Width = 10 'Eliminar
            gvListaBanners.Columns(0).ItemStyle.Height = 10

        Catch
            ' Report error.
        End Try

    End Sub

    Private Sub m_actualizar_orden_banners()

        Dim lFila As Long = 0
        Dim sIDX As String = ""

        Dim objBanner As New Banners

        For lFila = 0 To gvListaBanners.Rows.Count - 1
            sIDX = gvListaBanners.DataKeys(lFila).Value

            objBanner.Update_BannerNuOrd(lFila + 1, sIDX)


        Next

    End Sub


    Private Sub m_refresh_lista_banners(Optional ByVal sFiltro As String = "%")

        Dim oDataTable As DataTable

        'Realizar Conexion a la base de datos

        Dim objBanner As New Banners
        oDataTable = objBanner.Get_Banners(ddlCriterios.SelectedValue)

        If oDataTable IsNot Nothing Then
            gvListaBanners.DataSource = oDataTable
            gvListaBanners.DataBind()

            m_formatear_grilla()

        End If

        oDataTable.Clear()
        oDataTable = Nothing


    End Sub


    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click

        Try

            Response.Redirect("banners.aspx?tp=nw")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            If Not IsPostBack Then
                lblparam.Text = "%"

                ddlCriterios.DataSource = Sql_Get_Criterios()
                ddlCriterios.DataTextField = "nombre"
                ddlCriterios.DataValueField = "idcriterio"
                ddlCriterios.DataBind()

                m_refresh_lista_banners(lblparam.Text.Trim)


            End If



        Catch ex As Exception

        End Try


    End Sub


    Protected Sub gvListaBanners_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvListaBanners.RowCommand

        Try

                If e.CommandName = "Delete" Then
                lblcomand.Text = "DELETE"
            End If

            If e.CommandName = "Select" Then
                lblcomand.Text = "EDITAR"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvListaBanners_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListaBanners.RowDeleting
        Dim sMensajeError As String
        Try

            If lblcomand.Text = "DELETE" Then

                Dim lFila As Long = e.RowIndex
                Dim lID As Long = 0
                lID = gvListaBanners.DataKeys(lFila).Value
                'eliminar y refresh
                Dim objBanner As New Banners

                objBanner.Delete_Banner(lID)

                m_refresh_lista_banners(lblparam.Text.Trim)
                m_actualizar_orden_banners()
                m_refresh_lista_banners(lblparam.Text.Trim)

            End If

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub

    Protected Sub gvListaBanners_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaBanners.SelectedIndexChanged

        Dim sID As String = ""

        Try

            'Evaluar si es editar
            Select Case lblcomand.Text.Trim
                Case "EDITAR"
                    sID = gvListaBanners.SelectedDataKey("IDX")
                    Response.Redirect("banners.aspx?ufil=" & sID.Trim & "&tp=edt&idCriterio=" & ddlCriterios.SelectedValue)
            End Select


        Catch ex As Exception
            'save error
        End Try

    End Sub
    
    Protected Sub btnOrdenarSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOrdenarSec.Click
        Response.Redirect("sec_banners_ordenar.aspx?idCriterio=" & ddlCriterios.SelectedValue)
    End Sub

    Protected Sub ddlCriterios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCriterios.SelectedIndexChanged
        Try
            m_refresh_lista_banners(lblparam.Text.Trim)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
