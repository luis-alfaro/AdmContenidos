Imports Microsoft.VisualBasic

Public Class Simulador_EfectivoExpress

    Private _IDDEFE As Integer
    Public Property IDDEFE() As Integer
        Get
            Return _IDDEFE
        End Get
        Set(ByVal value As Integer)
            _IDDEFE = value
        End Set
    End Property

    Private _IDPEFE As Integer
    Public Property IDPEFE() As Integer
        Get
            Return _IDPEFE
        End Get
        Set(ByVal value As Integer)
            _IDPEFE = value
        End Set
    End Property

    Private _TIPO_TARJETA As Integer
    Public Property TIPO_TARJETA() As Integer
        Get
            Return _TIPO_TARJETA
        End Get
        Set(ByVal value As Integer)
            _TIPO_TARJETA = value
        End Set
    End Property

    Private _REVOLVENTE As Integer
    Public Property REVOLVENTE() As Integer
        Get
            Return _REVOLVENTE
        End Get
        Set(ByVal value As Integer)
            _REVOLVENTE = value
        End Set
    End Property
    Private _REVOLVENTE_TEXT As String
    Public ReadOnly Property REVOLVENTE_TEXT() As String
        Get
            If REVOLVENTE = True Then
                Return "SI"
            Else
                Return "NO"
            End If
        End Get
    End Property

    Private _FECHA_HORA As DateTime
    Public Property FECHA_HORA() As DateTime
        Get
            Return _FECHA_HORA
        End Get
        Set(ByVal value As DateTime)
            _FECHA_HORA = value
        End Set
    End Property

    Private _PRODUCTO As String
    Public Property PRODUCTO() As String
        Get
            Return _PRODUCTO
        End Get
        Set(ByVal value As String)
            _PRODUCTO = value
        End Set
    End Property

    Private _PLAZO_MIN As Integer
    Public Property PLAZO_MIN() As Integer
        Get
            Return _PLAZO_MIN
        End Get
        Set(ByVal value As Integer)
            _PLAZO_MIN = value
        End Set
    End Property

    Private _PLAZO_MAX As Integer
    Public Property PLAZO_MAX() As Integer
        Get
            Return _PLAZO_MAX
        End Get
        Set(ByVal value As Integer)
            _PLAZO_MAX = value
        End Set
    End Property

    Private _ENVIO_EECC As Decimal
    Public Property ENVIO_EECC() As Decimal
        Get
            Return _ENVIO_EECC
        End Get
        Set(ByVal value As Decimal)
            _ENVIO_EECC = value
        End Set
    End Property

    Private _SEG_DESG As Decimal
    Public Property SEG_DESG() As Decimal
        Get
            Return _SEG_DESG
        End Get
        Set(ByVal value As Decimal)
            _SEG_DESG = value
        End Set
    End Property

    Private _TEM As Decimal
    Public Property TEM() As Decimal
        Get
            Return _TEM
        End Get
        Set(ByVal value As Decimal)
            _TEM = value
        End Set
    End Property

    Private _TEA As Decimal
    Public Property TEA() As Decimal
        Get
            Return _TEA
        End Get
        Set(ByVal value As Decimal)
            _TEA = value
        End Set
    End Property

    Private _MEMBRECIA As Decimal
    Public Property MEMBRECIA() As Decimal
        Get
            Return _MEMBRECIA
        End Get
        Set(ByVal value As Decimal)
            _MEMBRECIA = value
        End Set
    End Property

    Private _COM_ATM As Decimal
    Public Property COM_ATM() As Decimal
        Get
            Return _COM_ATM
        End Get
        Set(ByVal value As Decimal)
            _COM_ATM = value
        End Set
    End Property

    Private _MONTO_MIN As Decimal
    Public Property MONTO_MIN() As Decimal
        Get
            Return _MONTO_MIN
        End Get
        Set(ByVal value As Decimal)
            _MONTO_MIN = value
        End Set
    End Property

    Private _MONTO_MAX As Decimal
    Public Property MONTO_MAX() As Decimal
        Get
            Return _MONTO_MAX
        End Get
        Set(ByVal value As Decimal)
            _MONTO_MAX = value
        End Set
    End Property

End Class
