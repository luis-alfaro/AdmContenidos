Imports System.Data
Imports DataAccess

Partial Class aspx_roles
    Inherits System.Web.UI.Page

    Private strSQL As String = ""
    Private sMensajeError As String


    Private Sub m_limpiar()
        txtnombre.Text = ""
        txtdes.Text = ""
        Ckhabilitar.Checked = True
        txtnombre.Focus()
    End Sub

    Private Function fun_buscar_rol_usuario(ByVal lCodRol As Long) As Boolean

        fun_buscar_rol_usuario = False

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

            strSQL = "SELECT * FROM app_UserAcoount WHERE RoleID=" & lCodRol

            SQL_ExecuteDataTable(oCN, strSQL, oDT)
            SQL_ConnectionClose(oCN)

            If oDT.Rows.Count > 0 Then
                fun_buscar_rol_usuario = True
            End If

            oDT.Clear()
            oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Function

    'Actualizar Registro
    Private Sub m_actualizar(ByVal ssSQL As String)
        Dim sMensajeError As String = ""
        sMensajeError = ""

        Try
            Dim oCNN As SqlClient.SqlConnection

            oCNN = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

            If sMensajeError <> "" Then
                Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If

            SQL_ExecuteNonQuery(oCNN, ssSQL)
            SQL_ConnectionClose(oCNN)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub



    Private Sub m_filtrar_registro(ByVal lCodigo As Long)

        'Realizar Conexion a la base de datos
        Dim oDatatable As New DataTable
        Dim oConexion As SqlClient.SqlConnection
        sMensajeError = ""

        oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try

            strSQL = "SELECT Name,Description,Enabled FROM app_Roles WHERE RoleID=" & lCodigo

            SQL_ExecuteDataTable(oConexion, strSQL, oDatatable)
            SQL_ConnectionClose(oConexion)

            If oDatatable.Rows.Count > 0 Then
                Call m_limpiar()

                txtnombre.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Name")), "", oDatatable.Rows(0).Item("Name"))
                txtdes.Text = IIf(IsDBNull(oDatatable.Rows(0).Item("Description")), "", oDatatable.Rows(0).Item("Description"))
                Ckhabilitar.Checked = oDatatable.Rows(0).Item("Enabled")
                txtnombre.Focus()

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
        Response.Redirect("lista_roles.aspx")
    End Sub

    Protected Sub bntaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntaceptar.Click

        Dim sCadenaSQL As String = ""
        lblmsg.Text = ""

        'Validar Datos
        If lblcodigo.Text.Trim.Length > 0 Then 'Modificar

            'Validar el habilitado cuando se modifique a inabilitado. si hay usuarios con ese rol si es que tubiese no se podra modificar a inabilitado.
            If Ckhabilitar.Checked = False Then
                If fun_buscar_rol_usuario(CLng(lblcodigo.Text.Trim)) = True Then
                    lblmsg.Text = "Este rol esta en uso."
                    Ckhabilitar.Checked = True
                    Exit Sub
                End If
            End If

            sCadenaSQL = "UPDATE app_Roles SET "
            If txtnombre.Text.Trim.Length = 0 Then
                lblmsg.Text = "Ingrese el nombre del rol."
                txtnombre.Focus()
                Exit Sub
            End If
            sCadenaSQL = sCadenaSQL & " Name='" & txtnombre.Text.Trim & "',"

        Else
            'Nuevo registro
            If txtnombre.Text.Trim = "" Then
                lblmsg.Text = "Ingrese el nombre del rol."
                txtnombre.Focus()
                Exit Sub
            End If
        End If

        If txtdes.Text.Trim.Length = 0 Then
            lblmsg.Text = "Ingrese la descripción del rol."
            txtdes.Focus()
            Exit Sub
        End If

        sCadenaSQL = sCadenaSQL & " Description='" & txtdes.Text.Trim & "',"

        If Ckhabilitar.Checked = True Then
            sCadenaSQL = sCadenaSQL & " Enabled=1"
        Else
            sCadenaSQL = sCadenaSQL & " Enabled=0"
        End If


        If lblcodigo.Text.Trim.Length > 0 Then 'Modificar 
            sCadenaSQL = sCadenaSQL & " WHERE RoleID=" & CLng(lblcodigo.Text.Trim)
            Call m_actualizar(sCadenaSQL)
        Else
            'Insertar Nuevo
            'sCadenaSQL = "INSERT INTO app_Roles (Name,Description,Enabled)"
            'sCadenaSQL = sCadenaSQL & " VALUES ('" & txtnombre.Text.Trim & "','" & txtdes.Text.Trim & "',"

            Dim objAccesos As New Accesos
            Dim codRole As Integer

            codRole = objAccesos.Insert_Role(txtnombre.Text.Trim, txtdes.Text.Trim, Ckhabilitar.Checked)
        End If

        Response.Redirect("lista_roles.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim sTipo As String = ""
            sTipo = Request.Item("tp")

            If sTipo.Trim = "edt" Then 'Editar

                'Realizar filtro
                Dim lID As Long = 0
                lID = Request.Item("ufil").Trim
                lblcodigo.Text = lID.ToString
                Call m_filtrar_registro(lID)

            Else
                'Nuevo registro
                lblcodigo.Text = ""
                Call m_limpiar()

            End If

        End If

    End Sub


End Class
