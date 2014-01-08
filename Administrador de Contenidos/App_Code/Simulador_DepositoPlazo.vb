Imports Microsoft.VisualBasic

Public Class Simulador_DepositoPlazo

    Private _IDDPF As Integer
    Public Property IDDPF() As Integer
        Get
            Return _IDDPF
        End Get
        Set(ByVal value As Integer)
            _IDDPF = value
        End Set
    End Property

    Private _MONEDA As String
    Public Property MONEDA() As String
        Get
            Return _MONEDA
        End Get
        Set(ByVal value As String)
            _MONEDA = value
        End Set
    End Property

    Private _MONEDA_TEXT As String
    Public ReadOnly Property MONEDA_TEXT() As String
        Get
            If MONEDA = "D" Then
                _MONEDA_TEXT = "Dólares"
            Else
                _MONEDA_TEXT = "Soles"
            End If
            Return _MONEDA_TEXT
        End Get
    End Property

    Private _DESCRIPCION As String
    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCION = value
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

    Private _TEA As Decimal
    Public Property TEA() As Decimal
        Get
            Return _TEA
        End Get
        Set(ByVal value As Decimal)
            _TEA = value
        End Set
    End Property

    Private _TREA As Decimal
    Public Property TREA() As Decimal
        Get
            Return _TREA
        End Get
        Set(ByVal value As Decimal)
            _TREA = value
        End Set
    End Property

    Private _TEA2 As Decimal
    Public Property TEA2() As Decimal
        Get
            Return _TEA2
        End Get
        Set(ByVal value As Decimal)
            _TEA2 = value
        End Set
    End Property

    Private _TREA2 As Decimal
    Public Property TREA2() As Decimal
        Get
            Return _TREA2
        End Get
        Set(ByVal value As Decimal)
            _TREA2 = value
        End Set
    End Property

    Private _COMISION As Decimal
    Public Property COMISION() As Decimal
        Get
            Return _COMISION
        End Get
        Set(ByVal value As Decimal)
            _COMISION = value
        End Set
    End Property


    Private _MONTO_LIM As Decimal
    Public Property MONTO_LIM() As Decimal
        Get
            Return _MONTO_LIM
        End Get
        Set(ByVal value As Decimal)
            _MONTO_LIM = value
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