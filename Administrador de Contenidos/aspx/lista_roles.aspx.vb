Imports System.Data
Imports System.Web.Security
Imports DataAccess

Partial Class aspx_lista_roles
    Inherits System.Web.UI.Page


    Private Sub m_formatear_grilla()

        Try
            'Ancho de Columnas
            gvListaRoles.Columns(0).ItemStyle.Width = 1 'RolID
            gvListaRoles.Columns(1).ItemStyle.Width = 35 'Nombre
            gvListaRoles.Columns(2).ItemStyle.Width = 250 'Descripcion
            gvListaRoles.Columns(3).ItemStyle.Width = 15 'Habilitado
            gvListaRoles.Columns(4).ItemStyle.Width = 10 'Editar
            gvListaRoles.Columns(0).ItemStyle.Height = 10

        Catch
            ' Report error.
        End Try

    End Sub

    'Crear procedimientos
    Private Sub m_refresh_lista_roles(Optional ByVal sFiltro As String = "%")

        Dim oDataTable As New DataTable
        Dim strSQL As String = ""
        Dim sMensajeError As String

        'Realizar Conexion a la base de datos
        Dim oConexion As SqlClient.SqlConnection
        sMensajeError = ""

        oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try
            'If sFiltro.Trim <> "" Then
            '    strSQL = "SELECT RoleID,Name,Description,Enabled FROM app_Roles"
            '    strSQL = strSQL & " WHERE Name LIKE '" & sFiltro.Trim & "%'"
            'End If

            Dim objAccesos As New Accesos

            oDataTable = objAccesos.Get_RolesFull()
            'SQL_ExecuteDataTable(oConexion, strSQL, oDataTable)


            If oDataTable.Rows.Count > 0 Then
                gvListaRoles.DataSource = oDataTable
                gvListaRoles.DataBind()

                Call m_formatear_grilla()

            End If

            SQL_ConnectionClose(oConexion)
            oDataTable.Clear()
            oDataTable = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Response.Redirect("roles.aspx?tp=nw")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            lblparam.text = "%"
            m_refresh_lista_roles(lblparam.Text.Trim)
        Else
            m_refresh_lista_roles(lblparam.Text.Trim)
        End If



    End Sub

    Protected Sub gvListaRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvListaRoles.RowCommand

        If e.CommandName = "Select" Then
            lblcomand.Text = "EDITAR"
        End If

    End Sub

    Protected Sub gvListaUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaRoles.SelectedIndexChanged

        Dim sID As String = ""

        Try

            'Evaluar si es editar
            Select Case lblcomand.Text.Trim
                Case "EDITAR"
                    sID = gvListaRoles.SelectedDataKey("RoleID")
                    Response.Redirect("roles.aspx?ufil=" & sID.Trim & "&tp=edt")
            End Select


        Catch ex As Exception
            'save error
        End Try

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try

    End Sub
End Class
