Imports System.Data
Imports System.Data.SqlClient
Imports DataAccess
Imports System.Web.UI
Imports System.Globalization

Partial Class aspx_sec_videos
    Inherits System.Web.UI.Page

    Private SQLCon As New SqlConnection
    Private sMensajeError As String
    Public Shared fechaDeplazar As Date

    Private Sub m_ejecutar_sql(ByVal sSQL As String)

        sMensajeError = ""

        Try
            SQL_ExecuteNonQuery(SQLCon, sSQL)

        Catch ex As Exception
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
        End Try

    End Sub


    Private Function fun_devolver_nombre_mes(ByVal lMes As Long) As String

        Dim sMes As String = ""

        Select Case lMes
            Case 1
                sMes = "ene"
            Case 2
                sMes = "feb"
            Case 3
                sMes = "mar"
            Case 4
                sMes = "abr"
            Case 5
                sMes = "may"
            Case 6
                sMes = "jun"
            Case 7
                sMes = "jul"
            Case 8
                sMes = "ago"
            Case 9
                sMes = "sep"
            Case 10
                sMes = "oct"
            Case 11
                sMes = "nov"
            Case 12
                sMes = "dic"
        End Select

        fun_devolver_nombre_mes = sMes

    End Function

    Private Sub m_formatear_grilla(Optional ByVal sDate As String = "")

        Try
            'Ancho de Columnas

            gvPrograma.Columns(0).ItemStyle.Width = 20 'Hora
            gvPrograma.Columns(1).ItemStyle.Width = 80 'Lunes
            gvPrograma.Columns(2).ItemStyle.Width = 80 'Martes
            gvPrograma.Columns(3).ItemStyle.Width = 80 'Miercoles
            gvPrograma.Columns(4).ItemStyle.Width = 80 'Jueves
            gvPrograma.Columns(5).ItemStyle.Width = 80 'Viernes
            gvPrograma.Columns(6).ItemStyle.Width = 80 'Sabado
            gvPrograma.Columns(7).ItemStyle.Width = 80 'Domingo

            gvPrograma.Columns(0).ItemStyle.Height = 10


            'Setear los dias de semana de la semana actual segun fecha

            Dim fecha As Date
            Dim FechaActual As Date
            Dim sDay As Integer = 0
            Dim ant As Integer = 0
            Dim desp As Integer = 0
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim sem(7) As Date
            Dim diasSem(7) As String

            Dim sFormatoSistema As String = System.Globalization.CultureInfo.GetCultureInfo(ReadAppConfig("CULTURA_FORMATO_FECHA")).DateTimeFormat.ShortDatePattern

            If ReadAppConfig("CULTURA_FORMATO_FECHA").Trim.ToUpper <> "ES-PE" And sDate.Trim.Length > 0 Then 'Si no esta en formato español
                'Formatear a ingles
                sDate = g_fun_formatearMMDDYYYY(sDate.Trim)
            End If

            If sDate.Trim.Length = 0 Then 'Usar Fecha actual
                FechaActual = DateTime.Now.Date
            Else
                'System.Globalization.CultureInfo.GetCultureInfo("es-PE").DateTimeFormat.ShortDatePattern
                FechaActual = DateTime.ParseExact(sDate.Trim, sFormatoSistema.Trim, CultureInfo.InvariantCulture)
                lblfecha.Text = sDate.Trim
            End If

            fecha = FechaActual
            sDay = Weekday(fecha, Microsoft.VisualBasic.FirstDayOfWeek.Monday) 'que empieze en lunes = 1
            ant = sDay - 1
            desp = sDay + 1

            If ant >= 1 Then
                For i = ant To 1 Step -1
                    fecha = DateAdd("d", -1, fecha)
                    sem(i) = Format(fecha, "yyyy-MM-dd")
                Next
            End If
            fecha = FechaActual
            sem(sDay) = Format(fecha, "yyyy-MM-dd")
            If desp <= 7 Then
                For i = desp To 7
                    fecha = DateAdd("d", 1, fecha)
                    sem(i) = Format(fecha, "yyyy-MM-dd")
                Next
            End If

            'Dias de semana
            diasSem(1) = "Lun"
            diasSem(2) = "Mar"
            diasSem(3) = "Mie"
            diasSem(4) = "Jue"
            diasSem(5) = "Vie"
            diasSem(6) = "Sab"
            diasSem(7) = "Dom"


            'Asignar los dias de esta semana
            For i = 1 To 7
                gvPrograma.HeaderRow.Cells(i).Text = diasSem(i) & " " & IIf(Day(sem(i)) > 9, Day(sem(i)).ToString & "-" & fun_devolver_nombre_mes(Month(sem(i))), "0" & Day(sem(i)).ToString & "-" & fun_devolver_nombre_mes(Month(sem(i))))
            Next

        Catch ex As Exception

            sMensajeError = ""
            sMensajeError = ex.Message.Trim
            Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)

        End Try





    End Sub




    Private Function convertirFecha(ByVal fecha As DateTime) As String
        Dim nuevaFecha As String
        Dim dia, mes, year As String
        dia = fecha.Day.ToString
        mes = fecha.Month.ToString
        year = fecha.Year.ToString

        If mes.Length = 1 Then
            mes = "0" & mes
        End If
        If dia.Length = 1 Then
            dia = "0" & dia
        End If
        nuevaFecha = year & mes & dia

        Return nuevaFecha
    End Function




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        sMensajeError = ""

        'SQLCon = SQL_ConnectionOpen(Get_CadenaConexion(), sMensajeError)

        Try
            If sMensajeError <> "" Then
                Response.Redirect("error.aspx?mensajeerror=" + sMensajeError)
                Exit Sub
            End If

            If Not IsPostBack Then

                ' Call m_actualizar_tabla_tempo()

                ' Call m_cargar_estructura_programacion(, "FILTRO")
                txtFecha.Text = Now.ToShortDateString()
                fechaDeplazar = Now
                cargarCriterios()
                Cargar_Semana(fechaDeplazar)

            Else

            End If
        Catch

        End Try

    End Sub




    Protected Sub btnfiltrarHora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfiltrarHora.Click


        Try

            lblmensaje.Text = ""
            Dim sFiltroDate As String = ""
            sFiltroDate = txtFecha.Text


            If sFiltroDate Is Nothing Then
                sFiltroDate = lblfecha.Text.Trim
            Else
                If sFiltroDate.Trim = "" Then
                    sFiltroDate = lblfecha.Text
                End If

            End If

            '--prueba convertir la fecha ingresada en caso de que ingresen cualquier cosa
            Dim fechaConvertir As DateTime
            DateTime.TryParse(sFiltroDate.Trim.ToString(), fechaConvertir)
            Dim fechaConvertida As String = fechaConvertir.Day & "/" & fechaConvertir.Month & "/" & fechaConvertir.Year

            If fechaConvertida.ToString() = "1/1/1" Then
                lblmensaje.Text = "¡la fecha a buscar no concuerda!"
                Exit Sub
            End If
            'Call m_actualizar_tabla_tempo(sFiltroDate.Trim)
            'Call m_cargar_estructura_programacion(sFiltroDate.Trim, "FILTRO")

            Cargar_Semana(Date.Parse(sFiltroDate.Trim))

        Catch

        End Try
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try

        
            If ddlCriterios.Items.Count < 1 Then
                Exit Sub
            End If

            Response.Redirect("videos.aspx?tp=nw")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cargar_Semana(ByVal fecha As Date)

        Dim semana() As String = Sql_Get_Semana(convertirFecha(fecha))

        Dim i As Integer = 1
        For Each item As String In semana
            gvPrograma.Columns(i).HeaderText = item
            'gvPrograma.HeaderRow.Cells(i).Text = item
            i = i + 1
        Next
        Dim listaHorario As New List(Of Horario)

        Dim horasTemp As DataTable = Sql_Get_Horas("07:00", "23:30")

        For Each item As DataRow In horasTemp.Rows ' As Integer = 0 To 24
            Dim segmento As New Horario
            segmento.Hora = item(0).ToString()
            segmento.Lunes = ""
            segmento.Martes = ""
            segmento.Miercoles = ""
            segmento.Jueves = ""
            segmento.Viernes = ""
            segmento.Sabado = ""
            segmento.Domingo = ""
            listaHorario.Add(segmento)
        Next


        Dim programacion As DataTable = Sql_Get_programacion(convertirFecha(fecha), Integer.Parse(ddlCriterios.SelectedValue))

        For Each item As DataRow In programacion.Rows

            'Select Case item("X").ToString()

            'Case 1
            For j As Integer = 0 To listaHorario.Count - 1 ' Each segmento As Horario In listaHorario
                If listaHorario(j).Hora.Substring(0, 5) = item("HoraInicio").ToString() Then

                    'listaHorario(j).Lunes = item("ran_desc").ToString()
                    Dim totalHoras As Integer = Integer.Parse(item("FilasAvanzar").ToString())

                    Select Case item("X").ToString()

                        Case 1
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Lunes = item("ran_desc").ToString()
                            Next
                        Case 2
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Martes = item("ran_desc").ToString()
                            Next
                        Case 3
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Miercoles = item("ran_desc").ToString()
                            Next
                        Case 4
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Jueves = item("ran_desc").ToString()
                            Next
                        Case 5
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Viernes = item("ran_desc").ToString()
                            Next
                        Case 6
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Sabado = item("ran_desc").ToString()
                            Next
                        Case 7
                            For k As Integer = j To totalHoras + j
                                listaHorario(k).Domingo = item("ran_desc").ToString()
                            Next
                    End Select

                    Exit For
                End If

            Next
        Next

        gvPrograma.DataSource = listaHorario
        gvPrograma.DataBind()

        For Each item As DataRow In programacion.Rows
            Dim Y As Integer = Integer.Parse(item("Y").ToString())
            Dim X As Integer = Integer.Parse(item("X").ToString())
            Dim FilasAvanzar As Integer = Integer.Parse(item("FilasAvanzar").ToString())

            For L As Integer = Y To FilasAvanzar + Y

                gvPrograma.Rows(L).Cells(X).BackColor = System.Drawing.ColorTranslator.FromHtml(item("Color").ToString())

            Next
        Next

    End Sub

    Protected Sub btnPrevio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevio.Click
        Try

     
            fechaDeplazar = fechaDeplazar.AddDays(-7)
            Cargar_Semana(fechaDeplazar)
        Catch

        End Try
    End Sub

    Protected Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Try
            fechaDeplazar = fechaDeplazar.AddDays(7)
            Cargar_Semana(fechaDeplazar)
        Catch

        End Try
    End Sub


    Private Sub cargarCriterios()
        'Dim dt As DataTable
        ddlCriterios.DataSource = Sql_Get_Criterios()
        ddlCriterios.DataTextField = "nombre"
        ddlCriterios.DataValueField = "idcriterio"
        ddlCriterios.DataBind()

    End Sub





    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Try
            Response.Redirect("welcome.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVideos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVideos.Click
        Try
            Response.Redirect("MantVideos.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFlash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFlash.Click
        Try
            Response.Redirect("MantFlash.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
