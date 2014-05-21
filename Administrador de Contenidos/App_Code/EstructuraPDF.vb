Imports Microsoft.VisualBasic

Public Class EstructuraPDF

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _idEstructura As Integer
    Public Property IdEstructura() As Integer
        Get
            Return _idEstructura
        End Get
        Set(ByVal value As Integer)
            _idEstructura = value
        End Set
    End Property

    Private _numeroPagina As Integer
    Public Property NumeroPagina() As Integer
        Get
            Return _numeroPagina
        End Get
        Set(ByVal value As Integer)
            _numeroPagina = value
        End Set
    End Property

    Private _esTexto As Boolean
    Public Property EsTexto() As Boolean
        Get
            Return _esTexto
        End Get
        Set(ByVal value As Boolean)
            _esTexto = value
        End Set
    End Property

    Private _orden As Integer
    Public Property Orden() As Integer
        Get
            Return _orden
        End Get
        Set(ByVal value As Integer)
            _orden = value
        End Set
    End Property

    Private _nombreCampo As String
    Public Property NombreCampo() As String
        Get
            Return _nombreCampo
        End Get
        Set(ByVal value As String)
            _nombreCampo = value
        End Set
    End Property

    Private _coordenadaX As Decimal
    Public Property CoordenadaX() As Decimal
        Get
            Return _coordenadaX
        End Get
        Set(ByVal value As Decimal)
            _coordenadaX = value
        End Set
    End Property

    Private _desplazamientoX As Decimal
    Public Property DesplazamientoX() As Decimal
        Get
            Return _desplazamientoX
        End Get
        Set(ByVal value As Decimal)
            _desplazamientoX = value
        End Set
    End Property

    Private _coordenadaY As Decimal
    Public Property CoordenadaY() As Decimal
        Get
            Return _coordenadaY
        End Get
        Set(ByVal value As Decimal)
            _coordenadaY = value
        End Set
    End Property

    Private _rotacion As Decimal
    Public Property Rotacion() As Decimal
        Get
            Return _rotacion
        End Get
        Set(ByVal value As Decimal)
            _rotacion = value
        End Set
    End Property

    Private _rutaImagen As String
    Public Property RutaImagen() As String
        Get
            Return _rutaImagen
        End Get
        Set(ByVal value As String)
            _rutaImagen = value
        End Set
    End Property

    Private _porcentageEscala As Decimal
    Public Property PorcentajeEscala() As Decimal
        Get
            Return _porcentageEscala
        End Get
        Set(ByVal value As Decimal)
            _porcentageEscala = value
        End Set
    End Property

    Private _maximoCaracteres As Integer
    Public Property MaximoCaracteres() As Integer
        Get
            Return _maximoCaracteres
        End Get
        Set(ByVal value As Integer)
            _maximoCaracteres = value
        End Set
    End Property

    Private _funcion As String
    Public Property Funcion() As String
        Get
            Return _funcion
        End Get
        Set(ByVal value As String)
            _funcion = value
        End Set
    End Property

End Class
