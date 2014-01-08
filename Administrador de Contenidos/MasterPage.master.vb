Imports System.Data
Imports DataAccess

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage


    Private Sub m_leer_accesos(ByVal lRoleID As Long)

        'Realizar Conexion a la base de datos
        Dim oDT As New DataTable
        Dim obCN As SqlClient.SqlConnection
        Dim sMensajeError As String = ""
        Dim strSQL As String = ""

        Dim objAccesos As New Accesos

        obCN = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try

            oDT = objAccesos.Get_AccesosByRoleID(lRoleID)

            If oDT.Rows.Count > 0 Then

                If oDT.Rows(0).Item("Pane") = True Then 'Activo
                    TViewIndice.Nodes.Item(0).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(0).SelectAction = TreeNodeSelectAction.None
                End If

                If oDT.Rows(0).Item("Svid") = True Then
                    TViewIndice.Nodes.Item(1).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(1).SelectAction = TreeNodeSelectAction.None
                End If

                If oDT.Rows(0).Item("Sban") = True Then
                    TViewIndice.Nodes.Item(2).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(2).SelectAction = TreeNodeSelectAction.None
                End If

                If oDT.Rows(0).Item("Usu") = True And oDT.Rows(0).Item("Rol") = True And oDT.Rows(0).Item("Acc") = True Then
                    TViewIndice.Nodes.Item(3).SelectAction = TreeNodeSelectAction.Select
                    If oDT.Rows(0).Item("Usu") = True Then
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.None
                    End If

                    If oDT.Rows(0).Item("Rol") = True Then
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(1).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(1).SelectAction = TreeNodeSelectAction.None
                    End If

                    If oDT.Rows(0).Item("Acc") = True Then
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(2).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(3).ChildNodes.Item(2).SelectAction = TreeNodeSelectAction.None
                    End If
                Else
                    TViewIndice.Nodes.Item(3).SelectAction = TreeNodeSelectAction.None
                    TViewIndice.Nodes.Item(3).ChildNodes.Clear()
                End If

                

                If oDT.Rows(0).Item("Ubigeo") = True And oDT.Rows(0).Item("Tiendas") = True And oDT.Rows(0).Item("Kioscos") = True And oDT.Rows(0).Item("Areas") = True Then
                    TViewIndice.Nodes.Item(4).SelectAction = TreeNodeSelectAction.Select
                    If oDT.Rows(0).Item("Ubigeo") = True Then
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.None
                    End If
                    If oDT.Rows(0).Item("Tiendas") = True Then
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(1).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(1).SelectAction = TreeNodeSelectAction.None
                    End If
                    If oDT.Rows(0).Item("Kioscos") = True Then
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(2).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(2).SelectAction = TreeNodeSelectAction.None
                    End If
                    If oDT.Rows(0).Item("Areas") = True Then
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(3).SelectAction = TreeNodeSelectAction.Select
                    Else
                        TViewIndice.Nodes.Item(4).ChildNodes.Item(3).SelectAction = TreeNodeSelectAction.None
                    End If
                Else
                    TViewIndice.Nodes.Item(4).SelectAction = TreeNodeSelectAction.None
                    TViewIndice.Nodes.Item(4).ChildNodes.Clear()
                End If

                
                If oDT.Rows(0).Item("Criterios") = True Then
                    TViewIndice.Nodes.Item(5).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(5).SelectAction = TreeNodeSelectAction.None
                End If
                If oDT.Rows(0).Item("Reporte") = True Then
                    TViewIndice.Nodes.Item(6).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(6).ChildNodes.Item(0).SelectAction = TreeNodeSelectAction.None
                End If

                If oDT.Rows(0).Item("Estadisticas") = True Then
                    TViewIndice.Nodes.Item(7).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(7).SelectAction = TreeNodeSelectAction.None
                    TViewIndice.Nodes.Item(7).ChildNodes.Clear()
                End If

                If oDT.Rows(0).Item("Consultas") = True Then
                    TViewIndice.Nodes.Item(8).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(8).SelectAction = TreeNodeSelectAction.None
                    TViewIndice.Nodes.Item(8).ChildNodes.Clear()
                End If

                If oDT.Rows(0).Item("Actualizar") = True Then
                    TViewIndice.Nodes.Item(9).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(9).SelectAction = TreeNodeSelectAction.None
                End If

                If oDT.Rows(0).Item("Temporizador") = True Then
                    TViewIndice.Nodes.Item(10).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(10).SelectAction = TreeNodeSelectAction.None
                End If
                If oDT.Rows(0).Item("Mensajes") = True Then
                    TViewIndice.Nodes.Item(11).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(11).SelectAction = TreeNodeSelectAction.None
                End If
                If oDT.Rows(0).Item("Tiempos") = True Then
                    TViewIndice.Nodes.Item(12).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(12).SelectAction = TreeNodeSelectAction.None
                End If
                
                If oDT.Rows(0).Item("Simuladores") = True Then
                    TViewIndice.Nodes.Item(13).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(13).SelectAction = TreeNodeSelectAction.None
                    TViewIndice.Nodes.Item(13).ChildNodes.Clear()
                End If
                If oDT.Rows(0).Item("Errores") = True Then
                    TViewIndice.Nodes.Item(14).SelectAction = TreeNodeSelectAction.Select
                Else
                    TViewIndice.Nodes.Item(14).SelectAction = TreeNodeSelectAction.None
                End If
                'If oDT.Rows(0).Item("Tarifas") = True Then
                '    TViewIndice.Nodes.Item(15).SelectAction = TreeNodeSelectAction.Select
                'Else
                '    TViewIndice.Nodes.Item(15).SelectAction = TreeNodeSelectAction.None
                'End If
                'RemoveChilds(TViewIndice.Nodes)
            End If

                oDT.Clear()
                oDT = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("aspx/error.aspx?mensajeerror=" + sMensajeError)
        End Try



    End Sub
    Sub RemoveChilds(ByVal childNodeCollection As TreeNodeCollection)
        For Each childNode As TreeNode In childNodeCollection
            If childNode.ChildNodes.Count > 0 Then
                RemoveChilds(childNode.ChildNodes)
                If childNode.SelectAction = TreeNodeSelectAction.None Then
                    Dim parentNode As TreeNode = childNode.Parent
                    If parentNode Is Nothing Then
                        TViewIndice.Nodes.Remove(childNode)
                    Else
                        parentNode.ChildNodes.Remove(childNode)
                    End If
                End If
            End If
        Next


    End Sub


    Protected Sub TViewIndice_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TViewIndice.SelectedNodeChanged

        Select Case TViewIndice.SelectedValue

            Case "P1" 'Configuracion del Panel
                Response.Redirect("panel.aspx")
            Case "P2" ' Programación de Videos
                Response.Redirect("prog_videos.aspx")
            Case "P3" ' Secuencia de Banners
                Response.Redirect("sec_banners.aspx")
            Case "P4" ' Estilos
                Response.Redirect("lista_estilos.aspx")
            Case "P5" ' Cuadros de Actividad
                Response.Redirect("lista_CuadroProgramacion.aspx")
            Case "S1" ' Usuarios
                Response.Redirect("lista_users.aspx")
            Case "S2" ' Roles
                Response.Redirect("lista_roles.aspx")
            Case "S3" ' Accesos
                Response.Redirect("accesos.aspx")
            Case "CS" ' Cerrar Sesión
                With Response
                    .ExpiresAbsolute = DateAdd("yyyy", -1, DateTime.Now)
                    .CacheControl = "Private"
                    .Expires = 0
                End With

                'Redirect to unathorised user page
                Session.Abandon()

                With Response
                    .Buffer = True
                    .Clear()
                    Response.Redirect("../default.aspx")
                    .End()
                End With

        End Select


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Recuperar las variables de logueo
        If Not Page.IsPostBack Then

            Dim dtConfig As New DataTable
            Dim sMensajeError As String = ""

            ''Recuperar el valor de la variable de sesión myvariable.
            If Not (Session("SESSION_ID") Is Nothing) Then

                dtConfig = fun_devolverDatosConfiguracion(Session("SESSION_ID").ToString.Trim, sMensajeError) 'el Session.SessionID cambia de numero al que se guardo revisar.

                If sMensajeError.Trim <> "" Then
                    Response.Redirect("error.aspx?mensajeerror=" & sMensajeError.Trim)
                    Exit Sub
                End If

                If dtConfig.Rows.Count <= 0 Then 'Su session ha expirado
                    Response.Redirect("logout.aspx")
                    dtConfig.Clear()
                Else
                    lbllogin.Text = Cryptor(dtConfig.Rows(0).Item("LOGUEADO"))
                End If

            Else
                Response.Redirect("logout.aspx")
            End If

            dtConfig = Nothing

            'Verificar Accesos  los indices empiezan de 0 ....
            If Not (Session("ROLE_ID") Is Nothing) Then
                Call m_leer_accesos(Session("ROLE_ID"))
            End If

        End If

    End Sub
End Class

