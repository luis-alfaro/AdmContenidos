Imports Microsoft.VisualBasic

Public Class ConsultaCriterioKiosco

    Sub New()
        _KioscoNombre = ""
        _lunes = ""
        _martes = ""
        _miercoles = ""
        _jueves = ""
        _viernes = ""
        _sabado = ""
        _domingo = ""
    End Sub


    Private _idkiosko As String
    Public Property idKiosko() As String
        Get
            Return _idkiosko
        End Get
        Set(ByVal value As String)
            _idkiosko = value
        End Set
    End Property



    Private _KioscoNombre As String
    Public Property KioscoNombre() As String
        Get
            Return _KioscoNombre
        End Get
        Set(ByVal value As String)
            _KioscoNombre = value
        End Set
    End Property


    Private _lunes As String
    Public Property Lunes() As String
        Get
            Return _lunes
        End Get
        Set(ByVal value As String)
            _lunes = value
        End Set
    End Property


    Private _martes As String
    Public Property Martes() As String
        Get
            Return _martes
        End Get
        Set(ByVal value As String)
            _martes = value
        End Set
    End Property


    Private _miercoles As String
    Public Property Miercoles() As String
        Get
            Return _miercoles
        End Get
        Set(ByVal value As String)
            _miercoles = value
        End Set
    End Property


    Private _jueves As String
    Public Property Jueves() As String
        Get
            Return _jueves
        End Get
        Set(ByVal value As String)
            _jueves = value
        End Set
    End Property


    Private _viernes As String
    Public Property Viernes() As String
        Get
            Return _viernes
        End Get
        Set(ByVal value As String)
            _viernes = value
        End Set
    End Property


    Private _sabado As String
    Public Property Sabado() As String
        Get
            Return _sabado
        End Get
        Set(ByVal value As String)
            _sabado = value
        End Set
    End Property


    Private _domingo As String
    Public Property Domingo() As String
        Get
            Return _domingo
        End Get
        Set(ByVal value As String)
            _domingo = value
        End Set
    End Property


End Class
