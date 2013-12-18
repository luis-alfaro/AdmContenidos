Imports System.Data

Partial Class aspx_videos
    Inherits System.Web.UI.Page

    'Private flagGuardar As Boolean = False

    Public Shared tipo As String
    Private nombre As String
    Public Shared dtReproduccion As DataTable
    Public Shared listHorarioAnterior As List(Of String)
    'Public Shared dtHorario As DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If IsPostBack Then
                Exit Sub
            End If


            tipo = Request.Item("tp").ToString() '.Trim.Substring(3)

            m_cargar_archivos_videos()

            cargarCriterios()

            If tipo = "nw" Then 'nuevo
                dtReproduccion = New DataTable
                dtReproduccion.Columns.Add("posicion")
                dtReproduccion.Columns.Add("titulo")
                dtReproduccion.Columns.Add("direccion")
                gvListaPresentacion.DataSource = dtReproduccion
                gvListaPresentacion.DataBind()

            Else 'modificar
                nombre = Request.Item("ufil")

                Dim myTabla As DataTable = Sql_obtener_ListaRango(nombre)
                Dim lCodigoRan_Item As Long = 0
                Dim sFFecha As String = ""


                If myTabla.Rows.Count > 0 Then
                    txtnombre.Text = IIf(IsDBNull(myTabla.Rows(0).Item("ran_desc")), "", myTabla.Rows(0).Item("ran_desc"))
                    lCodigoRan_Item = IIf(IsDBNull(myTabla.Rows(0).Item("ran_item")), 0, myTabla.Rows(0).Item("ran_item"))
                    lblcodDetalle.Text = lCodigoRan_Item.ToString
                    lblcodigo.Text = IIf(IsDBNull(myTabla.Rows(0).Item("ran_id")), "", myTabla.Rows(0).Item("ran_id"))
                    ddlCriterios.SelectedValue = IIf(IsDBNull(myTabla.Rows(0).Item("idcriterio")), "", myTabla.Rows(0).Item("idcriterio"))
                    txtColor.Value = IIf(IsDBNull(myTabla.Rows(0).Item("color")), "", myTabla.Rows(0).Item("color"))
                    Session("FFECHA") = sFFecha
                    For i As Integer = 0 To myTabla.Rows.Count - 1
                        cbohini.Text = IIf(IsDBNull(myTabla.Rows(i).Item("hora1")), "00:00", myTabla.Rows(i).Item("hora1"))
                        cbohfin.Text = IIf(IsDBNull(myTabla.Rows(i).Item("hora2")), "23:30", myTabla.Rows(i).Item("hora2"))
                        sFFecha = IIf(IsDBNull(myTabla.Rows(i).Item("fecha")), "", myTabla.Rows(i).Item("fecha"))
                        lbxHorarios.Items.Add(sFFecha + " " + cbohini.Text + "-" + cbohfin.Text)
                        'listHorarioAnterior.Add(sFFecha + " " + cbohini.Text + "-" + cbohfin.Text)
                    Next

                    'dtHorario = myTabla.Copy()

                    dtReproduccion = Sql_obtenerVideos_ListaRango(lblcodigo.Text)
                    gvListaPresentacion.DataSource = dtReproduccion
                    gvListaPresentacion.DataBind()

                End If

                myTabla.Clear()
                myTabla = Nothing


            End If

        Catch

        End Try

    End Sub

    Protected Sub btnagregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnagregar.Click

        Try

            'añadir videos a la lista

            If lbxHorarios.Items.Count < 1 Then
                lblmsg.Text = "Para agregar videos, primero añada los horarios que tendra la programación"
                Exit Sub
            End If

            Dim ruta As String
            Dim titulo As String
            ruta = lstFilesVideos.SelectedItem.Text
            Dim stringTmp() = ruta.Split("\")
            titulo = stringTmp(stringTmp.Length - 1)
            Dim fila(2) As String
            fila(0) = dtReproduccion.Rows.Count + 1
            fila(1) = titulo
            fila(2) = ruta

            dtReproduccion.Rows.Add(fila)
            gvListaPresentacion.DataSource = dtReproduccion
            gvListaPresentacion.DataBind()


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click


        Try

            If lbxHorarios.Items.Count < 1 Then
                lblmsg.Text = "Debe haber al menos un dia asignado para la programación"
                Exit Sub
            End If

            Dim nuevoHorario As New List(Of String)
            For i As Integer = 0 To lbxHorarios.Items.Count - 1
                nuevoHorario.Add(lbxHorarios.Items(i).Text)
            Next

            Dim listaVideo(1, gvListaPresentacion.Rows.Count - 1) As String

            For i As Integer = 0 To gvListaPresentacion.Rows.Count - 1
                listaVideo(0, i) = gvListaPresentacion.Rows(i).Cells(1).Text
                listaVideo(1, i) = gvListaPresentacion.Rows(i).Cells(2).Text
            Next

            'si salio bien, es true, sino false
            Dim resultado As Boolean

            If tipo = "nw" Then

                lblcodigo.Text = Sql_Insertar_listaRango(lblcodigo.Text, txtnombre.Text, 1, txtColor.Value.ToString(), ddlCriterios.SelectedValue)
                resultado = Sql_InsertarNueva_Programacion(nuevoHorario.ToArray(), lblcodigo.Text)
                resultado = Sql_InsertarNuevaLista_Video(listaVideo, lblcodigo.Text)
                Response.Redirect("prog_videos.aspx")

            Else

                Sql_Update_listaRango(lblcodigo.Text, txtnombre.Text, 1, txtColor.Value.ToString(), ddlCriterios.SelectedValue)
                Sql_InsertarNueva_Programacion(nuevoHorario.ToArray(), lblcodigo.Text)
                Sql_InsertarNuevaLista_Video(listaVideo, lblcodigo.Text)

            End If


            'Flag para Actualizar Videos
            'Sql_Update_FlagRefreshVideos()

            lblmsg.Text = "grabado exitoso"

        Catch ex As Exception

            Dim sMensajeError As String = ex.Message.Trim
            'Response.Redirect("error.aspx?mensajeerror=" + sMensajeError + " " + ex.StackTrace)

        End Try
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("prog_videos.aspx")
    End Sub

    Protected Sub gvListaPresentacion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListaPresentacion.RowDeleting
        Try

            dtReproduccion.Rows.RemoveAt(e.RowIndex)
            gvListaPresentacion.DataSource = dtReproduccion
            gvListaPresentacion.DataBind()

        Catch ex As Exception

        End Try

    End Sub
      
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Sql_Update_EstadoProgramacion(Integer.Parse(lblcodigo.Text), False)
            Response.Redirect("prog_videos.aspx")
        Catch

        End Try
    End Sub

    Protected Sub gvListaPresentacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaPresentacion.SelectedIndexChanged


    End Sub

    Protected Sub btnAgregarHorario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarHorario.Click
        'validamos si los rangos de hora estan bien

        Try

            Dim d1, d2 As Date
            d1 = CDate(cbohini.Text)
            d2 = CDate(cbohfin.Text)

            lblmsg.Text = ""
            Dim datePick1 As String = txtFechaInicio.Text
            Dim datePick2 As String = txtFechaFinal.Text

            Dim primeraFecha As Date = DateTime.Parse(datePick1)
            Dim UltimaFecha As Date = DateTime.Parse(datePick2) 'Date.Parse(Request.Item("dateArrivalFinal"))

            Dim TotalDias As TimeSpan = UltimaFecha - primeraFecha

            Dim fechaTemp As Date = primeraFecha

            For i As Integer = 0 To TotalDias.Days

                Dim existeFecha As Boolean = False


                Dim ite As ListItem = Nothing

                ite = lbxHorarios.Items.FindByText(fechaTemp.ToShortDateString() + " " + cbohini.Text + "-" + cbohfin.Text)
                If ite Is Nothing Then
                    If fun_validar_Existe_programacion(fechaTemp, cbohini.Text, cbohfin.Text, ddlCriterios.SelectedValue) = False Then
                        lbxHorarios.Items.Add(fechaTemp.ToShortDateString() + " " + cbohini.Text + "-" + cbohfin.Text)
                    Else
                        lblmsg.Text = "Algunas fechas no estan siendo agregadas debido a que se cruzan con alguna otra programación"
                    End If

                End If


                fechaTemp = fechaTemp.AddDays(1)
            Next


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnQuitarHorario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarHorario.Click
        Try

            lbxHorarios.Items.RemoveAt(lbxHorarios.SelectedIndex)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub m_cargar_archivos_videos()

        Try

            Dim sRutaFileVideos As String
            Dim sDirectorio As String
            sRutaFileVideos = ReadAppConfig("PATH_FILES_VIDEOS")

            sDirectorio = ""

            Dim dir As New System.IO.DirectoryInfo(sRutaFileVideos)

            lstFilesVideos.Items.Clear()
            For Each file As System.IO.FileInfo In dir.GetFiles()
                sDirectorio = ""
                'Formatos de videos (mpg,wmv, mov, mpeg, divx, mp4, flv, vob, avi)
                'Agregar item
                If file.Extension.ToUpper.Trim = ".MPG" Or file.Extension.ToUpper.Trim = ".WMV" Or file.Extension.ToUpper.Trim = ".MOV" Or file.Extension.ToUpper.Trim = ".MPEG" Or file.Extension.ToUpper.Trim = ".DIVX" Or file.Extension.ToUpper.Trim = ".MP4" Or file.Extension.ToUpper.Trim = ".FLV" Or file.Extension.ToUpper.Trim = ".VOB" Or file.Extension.ToUpper.Trim = ".AVI" Or file.Extension.ToUpper.Trim = ".PPT" Then
                    sDirectorio = file.FullName
                    lstFilesVideos.Items.Add(New ListItem(sDirectorio, file.Name))
                End If
            Next

        Catch ex As Exception
            'sMensajeError = ex.Message.Trim
            'Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try
    End Sub


    Private Sub cargarCriterios()
        'Dim dt As DataTable
        ddlCriterios.DataSource = Sql_Get_Criterios()
        ddlCriterios.DataTextField = "nombre"
        ddlCriterios.DataValueField = "idcriterio"
        ddlCriterios.DataBind()

    End Sub



    Protected Sub ddlCriterios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCriterios.SelectedIndexChanged

        Try
            If IsPostBack = True Then

                lbxHorarios.Items.Clear()
                'Dim totalFechas As Integer = lbxHorarios.Items.Count - 1
                'For i As Integer = 0 To totalFechas

                '    lbxHorarios.Items.RemoveAt(i)


                'Next
            End If
        Catch
        End Try
    End Sub
End Class
