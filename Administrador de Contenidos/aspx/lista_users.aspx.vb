
Imports System.Data
Imports System.Web.Security
Imports DataAccess

Partial Class aspx_lista_users
    Inherits System.Web.UI.Page

    Dim oEstado As Boolean = True

    Private Sub m_eliminar_registro(ByVal lCodigo As Long)

        Dim sMensajeError As String = ""
        Dim sSQL As String = ""
        sMensajeError = ""

        Try
            Dim ocnx As SqlClient.SqlConnection
            
            ocnx = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

            If sMensajeError <> "" Then
                Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If


            If gvListaUsers.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim objUser As New Usuarios
            objUser.Delete_Usuario(lCodigo)

            m_refresh_lista_usuarios()

            'sSQL = "UPDATE app_UserAcoount SET Flag_ToDelete=1 WHERE USERID=" & lCodigo

            'SQL_ExecuteNonQuery(ocnx, sSQL)
            'SQL_ConnectionClose(ocnx)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub

    Private Sub m_formatear_grilla()

        Try
            'Ancho de Columnas
            gvListaUsers.Columns(0).ItemStyle.Width = 1 'Usuario
            gvListaUsers.Columns(1).ItemStyle.Width = 20 'Usuario
            gvListaUsers.Columns(2).ItemStyle.Width = 250 'Nombres
            gvListaUsers.Columns(3).ItemStyle.Width = 15 'Habilitado
            gvListaUsers.Columns(4).ItemStyle.Width = 10 'Filtrar
            gvListaUsers.Columns(5).ItemStyle.Width = 10 'Eliminar

            gvListaUsers.Columns(0).ItemStyle.Height = 10

        Catch
            ' Report error.
        End Try

    End Sub

    'Crear procedimientos
    Private Sub m_refresh_lista_usuarios(Optional ByVal sFiltro As String = "%")

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
            '    strSQL = "SELECT UserID,LTRIM(UserName) AS UserName,LTRIM(FullNames) AS FullNames,Description,eMail,RoleID,Enabled FROM app_UserAcoount"
            '    strSQL = strSQL & " WHERE Flag_ToDelete=0 "
            'End If
            'SQL_ExecuteDataTable(oConexion, strSQL, oDataTable)
            Dim role As Integer = Session("ROLE_ID")
            Dim user As Integer = Session("USER_ID")
            Dim objUser As New Usuarios
            oDataTable = objUser.Get_usuarios(role, user)

            'If oDataTable.Rows.Count > 0 Then
            gvListaUsers.DataSource = oDataTable
            gvListaUsers.DataBind()

            Call m_formatear_grilla()

            'End If

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
        Response.Redirect("users.aspx?tp=nw")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            lblparam.text = "%"
            Call m_refresh_lista_usuarios(lblparam.Text.Trim)
        Else
            Call m_refresh_lista_usuarios(lblparam.Text.Trim)
        End If



    End Sub




    Protected Sub gvListaUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvListaUsers.RowCommand

        If e.CommandName = "Delete" Then
            lblcomand.Text = "DELETE"
        End If

        If e.CommandName = "Select" Then
            lblcomand.Text = "EDITAR"
        End If
        
    End Sub

    Protected Sub gvListaUsers_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListaUsers.RowDeleting

        If lblcomand.Text = "DELETE" Then



            Dim lFila As Long = e.RowIndex
            Dim lUserID As Long = 0
            lUserID = gvListaUsers.DataKeys(lFila).Value
            'call eliminar y refresh
            Call m_eliminar_registro(lUserID)
            lblparam.Text = "%"
            Call m_refresh_lista_usuarios(lblparam.Text.Trim)


        End If
        
    End Sub

    Protected Sub gvListaUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaUsers.SelectedIndexChanged

        Dim sUserID As String = ""

        Try

            'Evaluar si es editar
            Select Case lblcomand.Text.Trim
                Case "EDITAR"
                    sUserID = gvListaUsers.SelectedDataKey("UserID")
                    Response.Redirect("users.aspx?ufil=" & sUserID.Trim & "&tp=edt")
                Case "ELIMINAR"

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
