Imports System.Data
Imports DataAccess

Partial Class aspx_users
    Inherits System.Web.UI.Page

    Private strSQL As String = ""
    Private sMensajeError As String


    Private Sub m_limpiar()
        txtusuario.Text = ""
        txtnombres.Text = ""
        txtdes.Text = ""
        txtcorreos.Text = ""
        txtcontras.Text = ""
        txtrecontra.Text = ""
        Ckhabilitar.Checked = True
        'cborol.ClearSelection()
        txtusuario.Focus()
    End Sub



    'Actualizar Registro
    Private Sub m_actualizar(ByVal ssSQL As String)
        Dim sMensajeError As String = ""
        sMensajeError = ""

        Try
            Dim oCNN As SqlClient.SqlConnection

            oCNN = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

            If sMensajeError <> "" Then
                Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If

            SQL_ExecuteNonQuery(oCNN, ssSQL)
            SQL_ConnectionClose(oCNN)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    Private Function fun_buscar_usuario(ByVal sUsuario As String) As Boolean

        fun_buscar_usuario = False

        'Realizar Conexion a la base de datos
        Dim oDT As New DataTable
        Dim oCN As SqlClient.SqlConnection
        sMensajeError = ""

        oCN = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Function
        End If

        Try

            strSQL = "SELECT * FROM app_UserAcoount WHERE UserName='" & sUsuario.Trim & "'"

            SQL_ExecuteDataTable(oCN, strSQL, oDT)
            SQL_ConnectionClose(oCN)

            If oDT.Rows.Count > 0 Then
                fun_buscar_usuario = True
            End If

            oDT.Clear()
            oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Function

    Private Sub m_fill_roles()
        'Realizar Conexion a la base de datos
        Dim oDT As New DataTable
        Dim oConexion As SqlClient.SqlConnection
        sMensajeError = ""

        oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try

            strSQL = "SELECT RoleID,Name FROM app_roles WHERE Enabled=1"

            SQL_ExecuteDataTable(oConexion, strSQL, oDT)
            SQL_ConnectionClose(oConexion)

            If oDT.Rows.Count > 0 Then
                lbxRol.DataSource = oDT
                lbxRol.DataValueField = "RoleID"
                lbxRol.DataTextField = "Name"
                lbxRol.DataBind()
            End If

            oDT.Clear()
            oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub

    Private Sub m_filtrar_registro(ByVal lCodigo As Long)

        'Realizar Conexion a la base de datos
        Dim oListItem As ListItem
        Dim oDatatable As New DataTable
        Dim oConexion As SqlClient.SqlConnection
        sMensajeError = ""

        oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try

            strSQL = "SELECT UserID,UserName,Password,FullNames,Description,eMail,RoleID,Enabled FROM app_UserAcoount WHERE USERID=" & lCodigo

            SQL_ExecuteDataTable(oConexion, strSQL, oDataTable)
            SQL_ConnectionClose(oConexion)

            If oDatatable.Rows.Count > 0 Then
                Call m_limpiar()

                txtusuario.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("UserName")), "", oDatatable.Rows(0).Item("UserName"))
                lblusername.Text = txtusuario.Text.Trim
                txtnombres.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("FullNames")), "", oDatatable.Rows(0).Item("FullNames"))
                txtdes.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Description")), "", oDatatable.Rows(0).Item("Description"))
                txtcorreos.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("eMail")), "", oDatatable.Rows(0).Item("eMail"))
                txtcontras.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Password")), "", oDatatable.Rows(0).Item("Password"))
                txtrecontra.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Password")), "", oDatatable.Rows(0).Item("Password"))
                Ckhabilitar.Checked = oDatatable.Rows(0).Item("Enabled")
                'cborol.ClearSelection()

                oListItem = lbxRol.Items.FindByValue(oDatatable.Rows(0).Item("RoleID"))
                If Not (IsDBNull(oListItem)) Then
                    lbxRol.SelectedValue = oListItem.Value
                End If

                txtusuario.Focus()

                If Session("ROLE_ID") <> 1 Then ' Solo administrador puede cambiar roles
                    lblAsignarRol.Visible = False
                    lbxRol.Visible = False
                End If
            End If

            oDatatable.Clear()
            oDatatable = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("lista_users.aspx")
    End Sub

    Protected Sub bntaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntaceptar.Click

        Dim sCadenaSQL As String = ""
        lblmsg.Text = ""


        'Validar Datos
        If lblcodigo.Text.Trim.Length > 0 Then 'Modificar
            sCadenaSQL = "UPDATE app_UserAcoount SET "
            If txtusuario.Text.Trim.ToUpper <> lblusername.Text.Trim.ToUpper Then
                If fun_buscar_usuario(txtusuario.Text.Trim) = True Then
                    lblmsg.Text = "El usuario está en uso."
                    txtusuario.Focus()
                    Exit Sub
                End If
                sCadenaSQL = sCadenaSQL & " UserName='" & txtusuario.Text.Trim & "',"
            End If
        Else

            If txtusuario.Text.Trim = "" Then
                lblmsg.Text = "Ingrese su usuario."
                txtusuario.Focus()
                Exit Sub
            End If
            If fun_buscar_usuario(txtusuario.Text.Trim) = True Then
                lblmsg.Text = "El usuario está en uso."
                txtusuario.Focus()
                Exit Sub
            End If

        End If

        If txtnombres.Text.Trim.Length = 0 Then
            lblmsg.Text = "Ingrese el nombre completo."
            txtnombres.Focus()
            Exit Sub
        End If

        If txtcontras.Text.Trim <> txtrecontra.Text.Trim Then
            lblmsg.Text = "La contraseña no se confirmo correctamente."
            txtcontras.Focus()
            Exit Sub
        End If

        sCadenaSQL = sCadenaSQL & " FullNames='" & txtnombres.Text.Trim & "',"
        sCadenaSQL = sCadenaSQL & " Description='" & txtdes.Text.Trim & "',"
        sCadenaSQL = sCadenaSQL & " eMail='" & txtcorreos.Text.Trim & "',"

        If txtcontras.Text.Trim.Length > 0 Then 'Update solo si se cambio la contraseña
            sCadenaSQL = sCadenaSQL & " Password='" & txtcontras.Text.Trim & "',"
        End If

        If lblcodigo.Text.Trim.Length = 0 Then 'Nuevo Registro
            If txtcontras.Text.Length = 0 Then
                lblmsg.Text = "Ingrese su contraseña."
                txtcontras.Focus()
                Exit Sub
            End If
        End If

        sCadenaSQL = sCadenaSQL & " RoleID=" & lbxRol.SelectedValue & ","

        If Ckhabilitar.Checked = True Then
            sCadenaSQL = sCadenaSQL & " Enabled=1"
        Else
            sCadenaSQL = sCadenaSQL & " Enabled=0"
        End If


        If lblcodigo.Text.Trim.Length > 0 Then 'Modificar 
            sCadenaSQL = sCadenaSQL & " WHERE UserID=" & CLng(lblcodigo.Text.Trim)
        Else
            'Insertar Nuevo
            sCadenaSQL = "INSERT INTO app_UserAcoount (FullNames,Description,eMail,UserName,Password,Enabled,RoleID)"
            sCadenaSQL = sCadenaSQL & " VALUES ('" & txtnombres.Text.Trim & "','" & txtdes.Text.Trim & "','" & txtcorreos.Text.Trim & "','"
            sCadenaSQL = sCadenaSQL & txtusuario.Text.Trim & "','" & txtcontras.Text.Trim & "',"

            If Ckhabilitar.Checked = True Then
                sCadenaSQL = sCadenaSQL & "1,"
            Else
                sCadenaSQL = sCadenaSQL & "0,"
            End If

            sCadenaSQL = sCadenaSQL & lbxRol.SelectedValue & ")"

        End If

        Call m_actualizar(sCadenaSQL)

        Response.Redirect("lista_users.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim sTipo As String = ""
            sTipo = Request.Item("tp")

            Call m_fill_roles()

            If sTipo.Trim = "edt" Then 'Editar

                'Realizar filtro
                Dim lUserID As Long = 0
                lUserID = Request.Item("ufil").Trim
                lblcodigo.Text = lUserID.ToString
                Call m_filtrar_registro(lUserID)

            Else
                'Nuevo registro
                lblcodigo.Text = ""
                Call m_limpiar()
  

            End If

        End If


     
    End Sub


    'Protected Sub cborol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cborol.SelectedIndexChanged

    'End Sub

    Protected Sub lbxRol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbxRol.SelectedIndexChanged

    End Sub
End Class
