Imports System.IO
Imports System.Data
Imports DataAccess
Imports System.Drawing

Partial Class aspx_panel
    Inherits System.Web.UI.Page


    Private strSQL As String = ""
    Private sMensajeError As String

    Private Sub RJ_VISTA_PREVIA()
        Try
            txtRJPrevioFuente.Text = "AaBbYyZz"
            txtRJPrevioFuente.BackColor = ColorTranslator.FromHtml(txtColorFondoRelog.Value.ToString()) 'Color.FromName(cboRJColorFondo.SelectedItem.Text.Trim)
            txtRJPrevioFuente.ForeColor = ColorTranslator.FromHtml(txtColorLetraReloj.Value.ToString()) 'Color.FromName(cboRJColorLetra.SelectedItem.Text.Trim)

            txtRJPrevioFuente.Font.Name = cboRJFuente.SelectedItem.Text.Trim
            txtRJPrevioFuente.Font.Size = cboRJTamano.SelectedItem.Text.Trim

            If ckRJnegrita.Checked = True Then
                txtRJPrevioFuente.Font.Bold = True
            Else
                txtRJPrevioFuente.Font.Bold = False
            End If
        Catch ex As Exception
            'save error
        End Try

    End Sub

    Private Sub MQ_VISTA_PREVIA()

        Try
            'txtMQPrevioFuente.Text = "AaBbYyZz"
            'txtMQPrevioFuente.BackColor = Color.FromName(cboMQColorFondo.SelectedItem.Text.Trim)
            'txtMQPrevioFuente.ForeColor = Color.FromName(cboMQColorLetra.SelectedItem.Text.Trim)

            '            txtMQPrevioFuente.Font.Name = cboMQFuente.SelectedItem.Text.Trim
            '           txtMQPrevioFuente.Font.Size = cboMQTamano.SelectedItem.Text.Trim

            If ckMQnegrita.Checked = True Then
                '              txtMQPrevioFuente.Font.Bold = True
            Else
                '             txtMQPrevioFuente.Font.Bold = False
            End If

        Catch ex As Exception
            'save error
        End Try

    End Sub

    Private Sub m_poblar_tipos_letras(ByRef cboFuente As DropDownList)

        Try
            Dim installedFonts As New Drawing.Text.InstalledFontCollection()
            ' Obtenemos un array con los objetos FontFamily
            Dim fontFamilies() As FontFamily = installedFonts.Families
            cboFuente.Items.Clear()
            For Each font As FontFamily In fontFamilies
                cboFuente.Items.Add(font.Name)
            Next
        Catch ex As Exception
            'save error
        End Try

    End Sub

    Private Sub m_poblar_tamanos(ByRef obCombo As DropDownList)

        obCombo.Items.Clear()
        Dim lFila As Long = 0

        For lFila = 1 To 100
            obCombo.Items.Add(lFila.ToString)
        Next

    End Sub

    Private Sub m_cargar_colores(ByRef cboCombo As DropDownList)

        cboCombo.Items.Clear()

        Try
            Dim listadoColores As New List(Of String)

            For Each c As Drawing.Color In System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).GetStandardValues()
                listadoColores.Add(c.ToString.Substring(7, (c.ToString.Length - 8)))
                'listadoColores.Add(c.ToString)
            Next

            cboCombo.DataSource = listadoColores
            cboCombo.DataBind()

        Catch ex As Exception
            'save error
        End Try


    End Sub

    Private Sub m_cargar_archivos_flash()

        Try

            Dim sRutaFileFlash As String
            Dim sDirectorio As String
            sRutaFileFlash = ReadAppConfig("PATH_FILES_FLASH")
            sDirectorio = ""

            Dim dir As New DirectoryInfo(sRutaFileFlash)

            lstFilesFlash.Items.Clear()
            For Each file As FileInfo In dir.GetFiles()
                sDirectorio = ""
                'Agregar item
                If file.Extension.ToUpper.Trim = ".SWF" Or file.Extension.ToUpper.Trim = ".JPG" Then
                    sDirectorio = file.FullName
                    lstFilesFlash.Items.Add(sDirectorio)
                End If
            Next

        Catch ex As Exception
            'save error
        End Try
        
    End Sub


    Private Sub m_cargar_archivos_imagen()

        Try

            Dim sRutaFileIMG As String
            Dim sDirectorio As String
            sRutaFileIMG = ReadAppConfig("PATH_FILES_IMAGENES")
            sDirectorio = ""

            Dim dir As New DirectoryInfo(sRutaFileIMG)

            lstFilesIMG.Items.Clear()
            For Each file As FileInfo In dir.GetFiles()
                sDirectorio = ""
                'Agregar item
                If file.Extension.ToUpper.Trim = ".JPG" Or file.Extension.ToUpper.Trim = ".PNG" Or file.Extension.ToUpper.Trim = ".GIF" Or file.Extension.ToUpper.Trim = ".BMP" Or file.Extension.ToUpper.Trim = ".JPEG" Then
                    sDirectorio = file.FullName
                    lstFilesIMG.Items.Add(sDirectorio)
                End If
            Next

        Catch ex As Exception
            'save error
        End Try

    End Sub



    'Buscar Datos del panel
    Private Sub m_filtrar_registro()

        'Realizar Conexion a la base de datos
        Dim oData As New DataTable
        Dim oCon As SqlClient.SqlConnection
        sMensajeError = ""

        oCon = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        If sMensajeError <> "" Then
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
            Exit Sub
        End If

        Try

            strSQL = "SELECT PanelID,SectorID,Name,Description,FlashFile,FlashPath,"
            strSQL = strSQL & " BorderColor,Enabled,RJBackColor,RJFontName,RJFontSize,RJFontBold,"
            strSQL = strSQL & " RJFontUnderline,RJFontColor,MQIntervalo,MQBackColor,MQFontName,MQFontSize,"
            strSQL = strSQL & " MQFontBold,MQFontItalic,MQFontColor,MQTopDown,VDBackColor,VDRightLeft,VDVolumen,"
            strSQL = strSQL & " Flag_Refresh,Flag_ToDelete,VDOrigen,VDImgPath,Flag_Banner,Flag_Flash,Flag_Logo,Flag_Relog,Flag_HoraLarga,Flag_FechaRelog FROM app_Panels "
            strSQL = strSQL & " WHERE Flag_ToDelete = 0 And Enabled = 1 And PanelID = 1"


            SQL_ExecuteDataTable(oCon, strSQL, oData)
            SQL_ConnectionClose(oCon)

            If oData.Rows.Count > 0 Then
                Dim sBorderColor As String = ""
                Dim sRJBackColor As String = ""
                Dim sRJFontName As String = ""
                Dim lRJFontSize As Long = 0
                Dim lRJFontBold As Boolean = False
                Dim sRJFontColor As String = ""

                Dim lMQIntervalo As Long = 0
                Dim sMQBackColor As String = ""
                Dim sMQFontName As String = ""
                Dim lMQFontSize As Long = 0
                Dim lMQFontBold As Boolean = False
                Dim sMQFontColor As String = ""
                Dim lMQTopDown As Boolean = False

                Dim sVDBackColor As String = ""
                Dim lVDRightLeft As Boolean = False
                Dim lVDVolumen As Long = 0
                Dim lFlag_Refresh As Boolean = False
                Dim oListItem As ListItem

                '----Miguel 24/02/11------
                Dim FlagBanner As Boolean
                Dim FlagFlash As Boolean
                Dim FlagLogo As Boolean
                Dim FlagRelog As Boolean
                Dim flagHoraLarga As Boolean
                Dim flagMostrarFecha As Boolean

                Boolean.TryParse(oData.Rows(0).Item("Flag_Banner").ToString(), FlagBanner)
                Boolean.TryParse(oData.Rows(0).Item("Flag_Logo").ToString(), FlagLogo)
                Boolean.TryParse(oData.Rows(0).Item("Flag_Flash").ToString(), FlagFlash)
                Boolean.TryParse(oData.Rows(0).Item("Flag_Relog").ToString(), FlagRelog)
                Boolean.TryParse(oData.Rows(0).Item("Flag_HoraLarga").ToString(), flagHoraLarga)
                Boolean.TryParse(oData.Rows(0).Item("Flag_FechaRelog").ToString(), flagMostrarFecha)



                chkBanner.Checked = FlagBanner
                chkLogo.Checked = FlagLogo
                chkFlash.Checked = FlagFlash
                chkRelog.Checked = FlagRelog
                chkHoraLarga.Checked = flagHoraLarga
                chkMostrarFecha.Checked = flagMostrarFecha
                '-------------------------


                txtnombre.Text = IIf(IsDBNull(oData.Rows(0).Item("Name")), "Panel", oData.Rows(0).Item("Name"))
                txtdes.Text = IIf(IsDBNull(oData.Rows(0).Item("Description")), "Panel", oData.Rows(0).Item("Description"))
                txtrutaflash.Text = IIf(IsDBNull(oData.Rows(0).Item("FlashPath")), "", oData.Rows(0).Item("FlashPath"))
                sBorderColor = IIf(IsDBNull(oData.Rows(0).Item("BorderColor")), "#FFFFFF", oData.Rows(0).Item("BorderColor"))
                'cboColorBorde.Text = sBorderColor
                txtColorBordePanel.Value = sBorderColor

                Try
                    'txtprevioBorder.BorderColor = Color.FromName(sBorderColor)
                Catch ex As Exception
                    'save error
                End Try

                'FECHA Y HORA
                sRJBackColor = IIf(IsDBNull(oData.Rows(0).Item("RJBackColor")), "#000000", oData.Rows(0).Item("RJBackColor"))
                'cboRJColorFondo.Text = sRJBackColor
                txtColorFondoRelog.Value = sRJBackColor

                Try
                    'txtRJPrevioColorFondo.BackColor = Color.FromName(sRJBackColor)
                Catch ex As Exception
                    'save error
                End Try

                sRJFontName = IIf(IsDBNull(oData.Rows(0).Item("RJFontName")), "Arial", oData.Rows(0).Item("RJFontName"))
                cboRJFuente.Text = sRJFontName.Trim
                lRJFontSize = IIf(IsDBNull(oData.Rows(0).Item("RJFontSize")), 12, oData.Rows(0).Item("RJFontSize"))
                cboRJTamano.Text = lRJFontSize
                lRJFontBold = IIf(IsDBNull(oData.Rows(0).Item("RJFontBold")), False, oData.Rows(0).Item("RJFontBold"))
                ckRJnegrita.Checked = lRJFontBold
                sRJFontColor = IIf(IsDBNull(oData.Rows(0).Item("RJFontColor")), "#FFFFFF", oData.Rows(0).Item("RJFontColor"))
                'cboRJColorLetra.Text = sRJFontColor
                txtColorLetraReloj.Value = sRJFontColor

                Try
                    'txtRJPrevioColorLetra.ForeColor = Color.FromName(sRJFontColor.Trim)
                    'txtRJPrevioColorLetra.BorderColor = Color.Black
                Catch ex As Exception
                    'save error
                End Try

                'MARQUESINA (BANNER)
                lMQIntervalo = IIf(IsDBNull(oData.Rows(0).Item("MQIntervalo")), 30, oData.Rows(0).Item("MQIntervalo"))
                cboMQvelocidad.Text = lMQIntervalo.ToString
                sMQBackColor = IIf(IsDBNull(oData.Rows(0).Item("MQBackColor")), "#FFFFFF", oData.Rows(0).Item("MQBackColor"))
                'cboMQColorFondo.Text = sMQBackColor

                txtColorFondoBanner.Value = sMQBackColor

                Try
                    ' txtMQPrevioColorFondo.BackColor = Color.FromName(sMQBackColor)
                Catch ex As Exception
                    'save error
                End Try

                sMQFontName = IIf(IsDBNull(oData.Rows(0).Item("MQFontName")), "Arial", oData.Rows(0).Item("MQFontName"))
                cboMQFuente.Text = sMQFontName.Trim

                lMQFontSize = IIf(IsDBNull(oData.Rows(0).Item("MQFontSize")), 12, oData.Rows(0).Item("MQFontSize"))
                cboMQTamano.Text = lMQFontSize.ToString

                lMQFontBold = IIf(IsDBNull(oData.Rows(0).Item("MQFontBold")), False, oData.Rows(0).Item("MQFontBold"))
                ckMQnegrita.Checked = lMQFontBold

                sMQFontColor = IIf(IsDBNull(oData.Rows(0).Item("MQFontColor")), "#FFFFFF", oData.Rows(0).Item("MQFontColor"))
                ' cboMQColorLetra.Text = sMQFontColor


                Try
                    'txtMQPrevioColorLetra.ForeColor = Color.FromName(sMQFontColor)
                    ' txtMQPrevioColorLetra.BorderColor = Color.Black
                Catch ex As Exception
                    'save error
                End Try


                lMQTopDown = IIf(IsDBNull(oData.Rows(0).Item("MQTopDown")), False, oData.Rows(0).Item("MQTopDown"))
                ckMQArriba.Checked = lMQTopDown
                If lMQTopDown = True Then
                    ckMQArriba.Text = "Arriba"
                Else
                    ckMQArriba.Text = "Abajo"
                End If

                'VIDEO
                cboVDOrigen.ClearSelection()

                Try
                    oListItem = cboVDOrigen.Items.FindByValue(oData.Rows(0).Item("VDOrigen"))
                    If Not (IsDBNull(oListItem)) Then
                        cboVDOrigen.SelectedValue = oListItem.Value
                    End If
                Catch ex As Exception
                    'error
                End Try
                

                txtrutaIMG.Text = IIf(IsDBNull(oData.Rows(0).Item("VDImgPath")), "", oData.Rows(0).Item("VDImgPath"))

                sVDBackColor = IIf(IsDBNull(oData.Rows(0).Item("VDBackColor")), "#FFFFFF", oData.Rows(0).Item("VDBackColor"))

                'cboVDColorFondo.Text = sVDBackColor
                txtColorFondoVideo.Value = sVDBackColor

                Try
                    'txtVDPrevioColorFondo.BackColor = Color.FromName(sVDBackColor)
                Catch ex As Exception
                    'save error
                End Try


                lVDRightLeft = IIf(IsDBNull(oData.Rows(0).Item("VDRightLeft")), False, oData.Rows(0).Item("VDRightLeft"))
                ckVDDerecha.Checked = lVDRightLeft
                If lVDRightLeft = True Then
                    ckVDDerecha.Text = "Derecha"
                Else
                    ckVDDerecha.Text = "Izquierda"
                End If

                lVDVolumen = IIf(IsDBNull(oData.Rows(0).Item("VDVolumen")), 30, oData.Rows(0).Item("VDVolumen"))
                cboVDVolumen.Text = lVDVolumen

                lFlag_Refresh = IIf(IsDBNull(oData.Rows(0).Item("Flag_Refresh")), False, oData.Rows(0).Item("Flag_Refresh"))
                'ckVDUpdateOnLine.Checked = lFlag_Refresh

                Call RJ_VISTA_PREVIA()
                Call MQ_VISTA_PREVIA()

            End If

            oData.Clear()
            oData = Nothing

        Catch ex As Exception
            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    'Actualizar Registro
    Private Sub m_actualizar_panel(ByVal ssSQL As String)

        sMensajeError = ""

        Try
            Dim oConexion As SqlClient.SqlConnection

            oConexion = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

            If sMensajeError <> "" Then
                Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If

            SQL_ExecuteNonQuery(oConexion, ssSQL)
            SQL_ConnectionClose(oConexion)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Call m_cargar_archivos_flash()
            Call m_cargar_archivos_imagen()
            'Call m_cargar_colores(cboColorBorde)
            'Call m_cargar_colores(cboRJColorFondo)
            'Call m_cargar_colores(cboRJColorLetra)
            Call m_poblar_tamanos(cboRJTamano)
            Call m_poblar_tipos_letras(cboRJFuente)

            ' Call m_cargar_colores(cboMQColorFondo)
            ' Call m_cargar_colores(cboMQColorLetra)
            Call m_poblar_tipos_letras(cboMQFuente)
            Call m_poblar_tamanos(cboMQTamano)
            Call m_poblar_tamanos(cboMQvelocidad)

            'Call m_cargar_colores(cboVDColorFondo)
            Call m_poblar_tamanos(cboVDVolumen)

            'Buscar los datos del panel
            Call m_filtrar_registro()

        Else

        End If

    End Sub

    Protected Sub btnmostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmostrar.Click
        If PanFilesFlash.Visible = False Then
            PanFilesFlash.Visible = True
        Else
            PanFilesFlash.Visible = False
        End If
    End Sub

 
    Protected Sub lstFilesFlash_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilesFlash.SelectedIndexChanged
        txtrutaflash.Text = ""
        txtrutaflash.Text = lstFilesFlash.SelectedItem.Text
        PanFilesFlash.Visible = False

    End Sub

    'Protected Sub cboColorBorde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColorBorde.SelectedIndexChanged
    '    Try
    '        txtprevioBorder.BorderColor = Color.FromName(cboColorBorde.SelectedItem.Text.Trim)
    '    Catch ex As Exception
    '        'save error
    '    End Try

    'End Sub


    'Protected Sub cboRJColorFondo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRJColorFondo.SelectedIndexChanged
    '    Try
    '        txtRJPrevioColorFondo.BackColor = Color.FromName(cboRJColorFondo.SelectedItem.Text.Trim)
    '    Catch ex As Exception
    '        'save error
    '    End Try

    'End Sub

    Protected Sub btnRJVistaPrevia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRJVistaPrevia.Click
        Call RJ_VISTA_PREVIA()
    End Sub

    'Protected Sub cboRJColorLetra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRJColorLetra.SelectedIndexChanged
    '    Try

    '        txtRJPrevioColorLetra.ForeColor = Color.FromName(cboRJColorLetra.SelectedItem.Text.Trim)
    '        txtRJPrevioColorLetra.BorderColor = Color.Black

    '    Catch ex As Exception
    '        'save error
    '    End Try

    'End Sub

    Protected Sub ckMQArriba_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckMQArriba.CheckedChanged
        If ckMQArriba.Checked = True Then
            ckMQArriba.Text = "Arriba"
        Else
            ckMQArriba.Text = "Abajo"
        End If
    End Sub

    'Protected Sub btnMQVistaPrevia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMQVistaPrevia.Click

    '    Call MQ_VISTA_PREVIA()

    'End Sub

    'Protected Sub cboMQColorFondo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMQColorFondo.SelectedIndexChanged
    '    Try
    '        txtMQPrevioColorFondo.BackColor = Color.FromName(cboMQColorFondo.SelectedItem.Text.Trim)
    '    Catch ex As Exception
    '        'save error
    '    End Try
    'End Sub

    'Protected Sub cboMQColorLetra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMQColorLetra.SelectedIndexChanged

    '    Try
    '        txtMQPrevioColorLetra.ForeColor = Color.FromName(cboMQColorLetra.SelectedItem.Text.Trim)
    '        txtMQPrevioColorLetra.BorderColor = Color.Black
    '    Catch ex As Exception
    '        'save error
    '    End Try

    'End Sub

    Protected Sub ckVDDerecha_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckVDDerecha.CheckedChanged

        If ckVDDerecha.Checked = True Then
            ckVDDerecha.Text = "Derecha"
        Else
            ckVDDerecha.Text = "Izquierda"
        End If

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        lblmsg.Text = ""
        'Validaciones
        If txtnombre.Text.Trim.Length = 0 Then
            lblmsg.Text = "Ingrese nombre."
            Exit Sub
        End If

        If txtdes.Text.Trim.Length = 0 Then
            lblmsg.Text = "Ingrese descripción."
            Exit Sub
        End If

        If txtrutaflash.Text.Trim.Length = 0 Then
            lblmsg.Text = "Seleccione la ruta del archivo flash (.swf)."
            Exit Sub
        End If

        Try

            'Formar cadena de actualización
            strSQL = "UPDATE app_Panels SET Name='" & txtnombre.Text.Trim & "',Description='" & txtdes.Text.Trim & "'"
            strSQL = strSQL & ",FlashPath='" & txtrutaflash.Text.Trim & "',BorderColor='" & txtColorBordePanel.Value.ToString() & "'"
            strSQL = strSQL & ",RJBackColor='" & txtColorFondoRelog.Value.ToString() & "',RJFontName='" & cboRJFuente.Text.Trim & "'"
            strSQL = strSQL & ",RJFontSize=" & CLng(cboRJTamano.Text.Trim) & ",RJFontBold=" & IIf(ckRJnegrita.Checked, 1, 0) & ""
            strSQL = strSQL & ",RJFontColor='" & txtColorLetraReloj.Value.ToString() & "',MQIntervalo=" & CLng(cboMQvelocidad.Text.Trim) & ""
            strSQL = strSQL & ",MQBackColor='" & txtColorFondoBanner.Value.ToString() & "',MQFontName='" & cboMQFuente.Text.Trim & "'"
            strSQL = strSQL & ",MQFontSize=" & CLng(cboMQTamano.Text.Trim) & ",MQFontBold=" & IIf(ckMQnegrita.Checked, 1, 0) & ""
            strSQL = strSQL & ",MQTopDown=" & IIf(ckMQArriba.Checked, 1, 0) & ""
            strSQL = strSQL & ",VDBackColor='" & txtColorFondoVideo.Value.ToString() & "',VDRightLeft=" & IIf(ckVDDerecha.Checked, 1, 0) & ""
            strSQL = strSQL & ",VDVolumen=" & CLng(cboVDVolumen.Text.Trim) & ",Flag_Refresh=1"

            '------Miguel 24/02/11-----------
            strSQL = strSQL & ", Flag_Banner=" & IIf(chkBanner.Checked, "1", "0")
            strSQL = strSQL & ", Flag_Flash=" & IIf(chkFlash.Checked, "1", "0")
            strSQL = strSQL & ", Flag_Logo=" & IIf(chkLogo.Checked, "1", "0")
            strSQL = strSQL & ", Flag_Relog=" & IIf(chkRelog.Checked, "1", "0")
            strSQL = strSQL & ", Flag_HoraLarga=" & IIf(chkHoraLarga.Checked, "1", "0")
            strSQL = strSQL & ", Flag_FechaRelog=" & IIf(chkMostrarFecha.Checked, "1", "0")

            '--------------------------------

            strSQL = strSQL & ",VDOrigen='" & cboVDOrigen.SelectedValue & "',VDImgPath='" & IIf(txtrutaIMG.Text.Length = 0, "", txtrutaIMG.Text) & "'"

            strSQL = strSQL & " WHERE PanelID=1"

            Call m_actualizar_panel(strSQL)

        Catch ex As Exception
            'save error

            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)

        End Try
        

        'Response.Redirect("welcome.aspx")
    End Sub

    'Protected Sub cboVDColorFondo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVDColorFondo.SelectedIndexChanged
    '    Try
    '        txtVDPrevioColorFondo.BackColor = Color.FromName(cboVDColorFondo.SelectedItem.Text.Trim)
    '    Catch ex As Exception
    '        'save error
    '    End Try
    'End Sub

    'Protected Sub cboRJColorFondo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRJColorFondo.TextChanged
    '    Try
    '        txtRJPrevioColorFondo.BackColor = Color.FromName(cboRJColorFondo.SelectedItem.Text.Trim)
    '    Catch ex As Exception
    '        'save error
    '    End Try

    'End Sub

    Protected Sub btnmostrarIMG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmostrarIMG.Click
        If lstFilesIMG.Visible = False Then
            lstFilesIMG.Visible = True
        Else
            lstFilesIMG.Visible = False
        End If


    End Sub

    Protected Sub lstFilesIMG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilesIMG.SelectedIndexChanged
        txtrutaIMG.Text = ""
        txtrutaIMG.Text = lstFilesIMG.SelectedItem.Text
        lstFilesIMG.Visible = False

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
