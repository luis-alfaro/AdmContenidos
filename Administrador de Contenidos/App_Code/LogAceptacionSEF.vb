Imports Microsoft.VisualBasic

Public Class LogAceptacionSEF
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _ip As String
    Public Property IP() As String
        Get
            Return _ip
        End Get
        Set(ByVal value As String)
            _ip = value
        End Set
    End Property

    Private _nombreKiosko As String
    Public Property NombreKiosko() As String
        Get
            Return _nombreKiosko
        End Get
        Set(ByVal value As String)
            _nombreKiosko = value
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

    Private _sufijo As String
    Public Property Sufijo() As String
        Get
            Return _sufijo
        End Get
        Set(ByVal value As String)
            _sufijo = value
        End Set
    End Property

    Private _dni As String
    Public Property DNI() As String
        Get
            Return _dni
        End Get
        Set(ByVal value As String)
            _dni = value
        End Set
    End Property

    Private _cliente As String
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property

End Class
