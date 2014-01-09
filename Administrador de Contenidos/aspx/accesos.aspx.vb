Imports System.Data
Imports DataAccess

Partial Class aspx_accesos
    Inherits System.Web.UI.Page

    Private sMensajeError As String = ""
    Private strSQL As String = ""

    Private Sub m_limpiar()
        CkPanel.Checked = False
        CkSvideo.Checked = False
        CkSbanner.Checked = False
        CkUsuario.Checked = False
        CkRoles.Checked = False
        CkAccesos.Checked = False

    End Sub


    'Insertar / Actualizar Registro
    Private Sub m_actualizar_insertar(ByVal ssSQL As String)
        Dim sMensajeError As String = ""
        sMensajeError = ""

        Try
            Dim oCNNX As SqlClient.SqlConnection

            oCNNX = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

            If sMensajeError <> "" Then
                Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If

            SQL_ExecuteNonQuery(oCNNX, ssSQL)
            SQL_ConnectionClose(oCNNX)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    Private Sub m_fill_roles()
        'Realizar Conexion a la base de datos
        Dim oDT As New DataTable
        Dim lCodigoAccesoID As Long = 0
        sMensajeError = ""



        Dim objAcceso As New Accesos

        Try

            oDT = objAcceso.Get_Roles()


            If oDT.Rows.Count > 0 Then
                lbxRoles.DataSource = oDT
                lbxRoles.DataValueField = "RoleID"
                lbxRoles.DataTextField = "Name"
                lbxRoles.DataBind()

                'lblmsg.Text = "RoleID:" & cborol.SelectedValue.ToString filtrar los accesos del primer rol

                lCodigoAccesoID = fun_buscar_acceso_rol(oDT(0)(0))
                lblcodacceso.Text = lCodigoAccesoID.ToString.Trim

            End If

            oDT.Clear()
            oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    'Busca y pinta datos de los accesos del rol seleccionado.
    'Si el rol tiene accesos registrados retorna el codigo de acceso generado para su actualizacion
    Private Function fun_buscar_acceso_rol(ByVal lRoleID As Long) As Long

        fun_buscar_acceso_rol = -1

        'Realizar Conexion a la base de datos
        Dim oDT As New DataTable
        Dim oCNN As SqlClient.SqlConnection
        sMensajeError = ""


        oCNN = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Function
        End If

        Try

            Dim objAccesos As New Accesos
            oDT = objAccesos.Get_AccesosByRoleID(lRoleID)

            If oDT.Rows.Count > 0 Then

                CkPanel.Checked = oDT.Rows(0).Item("Pane")
                CkSvideo.Checked = oDT.Rows(0).Item("Svid")
                CkSbanner.Checked = oDT.Rows(0).Item("Sban")
                CkUsuario.Checked = oDT.Rows(0).Item("Usu")
                CkRoles.Checked = oDT.Rows(0).Item("Rol")
                CkAccesos.Checked = oDT.Rows(0).Item("Acc")
                ckUbigeo.Checked = oDT.Rows(0).Item("Ubigeo")
                ckTiendas.Checked = oDT.Rows(0).Item("Tiendas")
                ckKioscos.Checked = oDT.Rows(0).Item("Kioscos")
                ckAreas.Checked = oDT.Rows(0).Item("Areas")
                ckCriterios.Checked = oDT.Rows(0).Item("Criterios")
                ckTemporizador.Checked = oDT.Rows(0).Item("Consultas")
                ckReporte.Checked = oDT.Rows(0).Item("Reporte")
                ckActualizar.Checked = oDT.Rows(0).Item("Actualizar")
                ckTiempos.Checked = oDT.Rows(0).Item("Tiempos")
                ckMensajes.Checked = oDT.Rows(0).Item("Mensajes")
                ckTarifas.Checked = oDT.Rows(0).Item("Tarifas")
                ckSimuladores.Checked = oDT.Rows(0).Item("Simuladores")
                ckEstadisticas.Checked = oDT.Rows(0).Item("Estadisticas")
                ckConfiguracionKiosko.Checked = oDT.Rows(0).Item("ConfiguracionKiosko")
                ckErrores.Checked = oDT.Rows(0).Item("Errores")
                fun_buscar_acceso_rol = oDT.Rows(0).Item("AccessID")
            Else

                m_limpiar()

            End If

            oDT.Clear()
            oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            m_fill_roles()
        End If


    End Sub

    'Protected Sub cborol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cborol.SelectedIndexChanged
    '    'lblmsg.Text = ""
    '    'Dim lCodigoAccesoID As Long = -1

    '    'lCodigoAccesoID = fun_buscar_acceso_rol(cborol.SelectedValue)
    '    'lblcodacceso.Text = lCodigoAccesoID.ToString.Trim

    'End Sub

    Protected Sub bntaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntaceptar.Click

        lblmsg.Text = ""
        strSQL = ""


        Dim objAccesos As New Accesos

        'Validar si es nuevo registro o  se modifica los accesos
        'If lblcodacceso.Text.Trim = -1 Then 'Nuevo Registro


        '  Else


        Try


            objAccesos.Update_Accesos(lblcodacceso.Text, CkPanel.Checked, CkSvideo.Checked, CkSbanner.Checked, CkUsuario.Checked, CkRoles.Checked, CkAccesos.Checked, ckUbigeo.Checked, ckTiendas.Checked, ckKioscos.Checked, ckAreas.Checked, ckCriterios.Checked, ckTemporizador.Checked, ckReporte.Checked, ckActualizar.Checked, ckTemporizador.Checked, ckMensajes.Checked, ckTiempos.Checked, ckSimuladores.Checked, ckEstadisticas.Checked, ckConfiguracionKiosko.Checked, ckErrores.Checked)

            'strSQL = "UPDATE  app_Accesos SET Pane=" & IIf(CkPanel.Checked = True, 1, 0) & ",Svid=" & IIf(CkSvideo.Checked = True, 1, 0)
            'strSQL = strSQL & ",Sban=" & IIf(CkSbanner.Checked = True, 1, 0) & ",Usu=" & IIf(CkUsuario.Checked = True, 1, 0)
            'strSQL = strSQL & ",Rol=" & IIf(CkRoles.Checked = True, 1, 0)
            'strSQL = strSQL & ",Acc=" & IIf(CkAccesos.Checked = True, 1, 0)
            'strSQL = strSQL & " WHERE AccessID=" & lblcodacceso.Text.Trim

            'End If

            'Ejecutar la insercion o actualizacion
            lblmsg.Text = "Accesos actualizados"
            m_actualizar_insertar(strSQL)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub lbxRoles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbxRoles.SelectedIndexChanged

        Try

            lblmsg.Text = ""
            Dim lCodigoAccesoID As Long = -1

            lCodigoAccesoID = fun_buscar_acceso_rol(lbxRoles.SelectedValue)
            lblcodacceso.Text = lCodigoAccesoID.ToString.Trim

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
