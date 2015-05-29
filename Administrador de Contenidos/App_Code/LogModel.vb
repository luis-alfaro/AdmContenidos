Imports Microsoft.VisualBasic
Imports UtilitarioEnvioData.Entidades

Public Class LogModel

    Public Sub New()
        KioskoList = New List(Of ENKiosco)
    End Sub

    Private _fechaInicio As String
    Public Property FechaInicio() As String
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As String)
            _fechaInicio = value
        End Set
    End Property

    Private _fechaFin As String
    Public Property FechaFin() As String
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As String)
            _fechaFin = value
        End Set
    End Property

    Private _kioskoList As List(Of ENKiosco)
    Public Property KioskoList() As List(Of ENKiosco)
        Get
            Return _kioskoList
        End Get
        Set(ByVal value As List(Of ENKiosco))
            _kioskoList = value
        End Set
    End Property

    Private _tipoLog As Integer
    Public Property TipoLog() As Integer
        Get
            Return _tipoLog
        End Get
        Set(ByVal value As Integer)
            _tipoLog = value
        End Set
    End Property

    Private _modalidad As Integer
    Public Property Modalidad() As Integer
        Get
            Return _modalidad
        End Get
        Set(ByVal value As Integer)
            _modalidad = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property


End Class
