Imports System.Data
Imports System.Security
Imports DataAccess

Partial Class aspx_banners
    Inherits System.Web.UI.Page

    Private strSQL As String = ""
    Private sMensajeError As String = ""

    Private Sub m_limpiar()
        txtbanner.Text = ""
        txtbanner.Focus()

    End Sub



    Private Sub m_filtrar_registro(ByVal lIDX As Long)

        Dim oDatatable As New DataTable
        Dim objBanner As New Banners

        oDatatable = objBanner.Get_BannerByIDX(lIDX)

        If oDatatable.Rows.Count > 0 Then
            m_limpiar()
            txtbanner.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Banner")), "", oDatatable.Rows(0).Item("Banner"))
            txtColor.Value = "#" & IIf(IsDBNull(oDatatable.Rows(0).Item("Color")), "", oDatatable.Rows(0).Item("Color"))
            ddlCriterios.SelectedValue = IIf(IsDBNull(oDatatable.Rows(0).Item("idcriterio")), "", oDatatable.Rows(0).Item("idcriterio"))
            txtColor.Focus()
        End If

        oDatatable.Clear()
        oDatatable = Nothing


    End Sub

    'Funcion que devuelve el total de registros + 1
    Private Function fun_total_registros() As Long

        fun_total_registros = 0

        Dim oData As New DataTable

        Dim objBanner As New Banners


        oData = objBanner.Get_TotalFilas()

        If oData.Rows.Count > 0 Then
            fun_total_registros = oData.Rows(0).Item("TOTAL")
        End If

        oData.Clear()
        oData = Nothing


    End Function

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("sec_banners.aspx")
    End Sub

    Protected Sub bntaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntaceptar.Click

        Try
            Dim sCadenaSQL As String = ""
            lblmsg.Text = ""

            Dim color As String = txtColor.Value.ToString()
            color = color.Replace("#", "")
            If color.Trim().Length = 0 Then
                color = "FFFFFF"
            End If


            'Validar Datos
            If lblcodigo.Text.Trim.Length > 0 Then 'Modificar

                If txtbanner.Text.Trim.Length = 0 Then
                    lblmsg.Text = "Ingrese descripción del banner."
                    txtbanner.Focus()
                    Exit Sub
                End If
                txtbanner.Text = Replace(txtbanner.Text, vbCrLf, "")


            Else
                'Nuevo registro
                If txtbanner.Text.Trim = "" Then
                    lblmsg.Text = "Ingrese descripción del banner."
                    txtbanner.Focus()
                    Exit Sub
                End If
                txtbanner.Text = Replace(txtbanner.Text, vbCrLf, "")

            End If


            Dim objBanner As New Banners
            If lblcodigo.Text.Trim.Length > 0 Then 'Modificar 

                objBanner.Update_BannerValues(lblcodigo.Text, txtbanner.Text.Trim(), color, Integer.Parse(ddlCriterios.SelectedValue.ToString()))
            Else

                'Insertar Nuevo 
                objBanner.Insert_Banner(txtbanner.Text, fun_total_registros, color, Integer.Parse(ddlCriterios.SelectedValue.ToString()))
            End If

            Response.Redirect("sec_banners.aspx")


        Catch ex As Exception

            'sMensajeError = ""
            'sMensajeError = ex.Message.Trim
            'Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)


        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        sMensajeError = ""
        Try


            If Not IsPostBack Then

                Dim sTipo As String = ""
                sTipo = Request.Item("tp")


                ddlCriterios.DataSource = Sql_Get_Criterios()
                ddlCriterios.DataTextField = "nombre"
                ddlCriterios.DataValueField = "idcriterio"
                ddlCriterios.DataBind()

                If sTipo.Trim = "edt" Then 'Editar

                    'Realizar filtro
                    Dim lID As Long = 0
                    lID = Request.Item("ufil").Trim
                    lblcodigo.Text = lID.ToString
                    m_filtrar_registro(lID)

                Else
                    'Nuevo registro
                    lblcodigo.Text = ""
                    m_limpiar()
                    txtColor.Value = "#FFFFFF"
                End If

            End If

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try


    End Sub


End Class
