Imports System.Data
Imports System.Configuration
Imports System.Web.Security
Imports DataAccess
Imports AdministradorContenidos.ActiveDirectory

Public Class _Default
    Inherits System.Web.UI.Page


    Private Sub m_guardar_configuracion_con(ByVal sCadenaCon As String, ByVal idsession As String, ByVal server As String, _
    ByVal ipserver As String, ByVal bd As String, ByVal usuario As String, ByVal psw As String, _
    ByVal cadena As String, ByVal logueado As String)

        Dim sqlInsert As String
        Dim sMensajeError As String = ""
        'Evaluar si existe el id de session guardada si existe eliminar para volver a insertar la nueva
        'llamar a la funcion de configuracion para jalar la cadena de conexion segun el id de session
        Dim dtConfig As New DataTable
        dtConfig = fun_devolverDatosConfiguracion(idsession, sMensajeError)
        If sMensajeError.Trim <> "" Then
            Response.Redirect("aspx/error.aspx?mensajeerror=" & sMensajeError)
            Exit Sub
        End If
        If dtConfig.Rows.Count > 0 Then
            'Eliminar cosigo de la session
            sMensajeError = ""
            Call m_delete_configuracion_con(idsession, sMensajeError)
            If sMensajeError.Trim <> "" Then
                Response.Redirect("aspx/error.aspx?mensajeerror=" & sMensajeError)
                Exit Sub
            End If
            dtConfig.Clear()
        End If
        dtConfig = Nothing
        Try
            Dim ocn As SqlClient.SqlConnection
            sMensajeError = ""
            ocn = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)
            If sMensajeError <> "" Then
                Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If
            'Encriptar los campos para su insercion
            sqlInsert = "INSERT INTO app_cadenas_con VALUES('" & idsession & "','" & Cryptor(server) & "','" & Cryptor(ipserver) & "','" & Cryptor(bd) & "','" & Cryptor(usuario) & "','" & Cryptor(psw) & "','" & Cryptor(cadena) & "','" & Cryptor(logueado.Trim) & "')"
            SQL_ExecuteNonQuery(ocn, sqlInsert)
            SQL_ConnectionClose(ocn)
        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
        End Try
    End Sub

    Private Sub m_ValidarUsuario()
        Dim username As String = txtLogin.Value
        Dim password As String = txtPassword.Value
        Dim IsLoggedAD As Boolean = False

        'Codigo4545
        'Active Directory
        '----------------
        'Try
        '    IsLoggedAD = UsuarioAD.Instance.Login(username, password)
        'Catch ex As Exception
        '    Log.ErrorLog(ex.Message)
        '    Response.Redirect("aspx/error.aspx?mensajeerror=" + ex.Message)
        '    Return
        'End Try


        Dim oDataTable As New DataTable
        Dim strSQL As String
        Dim sMensajeError As String

        'Realizar Conexion a la base de datos
        Dim oConexion As SqlClient.SqlConnection
        sMensajeError = ""
        oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)
        If sMensajeError <> "" Then
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If
        Try
            strSQL = "SELECT app_UserAcoount.UserID, app_UserAcoount.FullNames, app_UserAcoount.Enabled, app_UserAcoount.Owner, app_UserAcoount.ChangePassword, app_UserAcoount.RoleID"
            strSQL = strSQL & " FROM  app_UserAcoount"
            strSQL = strSQL & " WHERE (app_UserAcoount.Flag_ToDelete = 0) AND (app_UserAcoount.UserName = '" & username & "') AND (app_UserAcoount.Password = '" & password & "')"
            SQL_ExecuteDataTable(oConexion, strSQL, oDataTable)
            SQL_ConnectionClose(oConexion)
        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
        End Try

        If oDataTable Is Nothing Then
            Response.Redirect("aspx/errorAuthentication.aspx?f_Caption=Acceso No Autorizado&f_Message=Lo sentimos, usted no esta autorizado a ver el contenido de este módulo.")
        End If
        If oDataTable.Rows.Count > 0 Then
            If oDataTable.Rows(0).Item("Enabled") = True Then 'Verificar si el usuario esta activo
                'Guardar configuracion inicial
                Session("SESSION_ID") = Session.SessionID.Trim
                Session("ROLE_ID") = oDataTable.Rows(0).Item("RoleID")
                Session("USER_ID") = oDataTable.Rows(0).Item("UserID")
                Call m_guardar_configuracion_con(Get_CadenaConexion(), Session("SESSION_ID"), ReadAppConfig("SERVER"), ReadAppConfig("IPSERVER"), ReadAppConfig("BD"), ReadAppConfig("USER"), ReadAppConfig("PASSWORD"), Get_CadenaConexion(), oDataTable.Rows(0).Item("FullNames"))
                Response.Redirect("aspx/welcome.aspx") 'Master Page
            Else
                oDataTable.Clear()
                oDataTable = Nothing
                'Authentication del formulario de logueo por error
                Response.Redirect("aspx/errorAuthentication.aspx?f_Caption=Acceso No Autorizado&f_Message=Lo sentimos, usted no esta autorizado a ver el contenido de este módulo.")
                'Response.Write("<script language=javascript>window.open('aspx/errorAuthentication.aspx?f_Caption=Acceso No Autorizado&f_Message=Lo sentimos, usted no esta autorizado a ver el contenido de este web site','_parent');</script>")
            End If
        Else
            'FormsAuthentication.RedirectFromLoginPage("Error", False)
            Response.Redirect("aspx/errorAuthentication.aspx?f_Caption=Acceso No Autorizado&f_Message=Lo sentimos, usted no esta autorizado a ver el contenido de este módulo.")
        End If
    End Sub

    Protected Sub btniniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btniniciar.Click
        'Iniciar la validacion del usuario

        Log.ErrorLog("btniniciar_Click")
        Call m_ValidarUsuario()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
