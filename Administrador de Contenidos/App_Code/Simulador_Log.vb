Imports Microsoft.VisualBasic

Public Class Simulador_Log

    Private _idSimulador As Integer
    Public Property IdSimulador() As Integer
        Get
            Return _idSimulador
        End Get
        Set(ByVal value As Integer)
            _idSimulador = value
        End Set
    End Property

    Private _simulador As String
    Public Property Simulador() As String
        Get
            Return _simulador
        End Get
        Set(ByVal value As String)
            _simulador = value
        End Set
    End Property

    Private _valorInicial As String
    Public Property ValorInicial() As String
        Get
            Return _valorInicial
        End Get
        Set(ByVal value As String)
            _valorInicial = value
        End Set
    End Property

    Private _valorFinal As String
    Public Property ValorFinal() As String
        Get
            Return _valorFinal
        End Get
        Set(ByVal value As String)
            _valorFinal = value
        End Set
    End Property

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _IP As String
    Public Property IP() As String
        Get
            Return _IP
        End Get
        Set(ByVal value As String)
            _IP = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property


End Class
