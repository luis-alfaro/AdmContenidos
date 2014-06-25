Imports Microsoft.VisualBasic

Public Class Simulador_Compras

    Private _IDDCOM As Integer
    Public Property IDDCOM() As Integer
        Get
            Return _IDDCOM
        End Get
        Set(ByVal value As Integer)
            _IDDCOM = value
        End Set
    End Property

    Private _IDPCOM As Integer
    Public Property IDPCOM() As Integer
        Get
            Return _IDPCOM
        End Get
        Set(ByVal value As Integer)
            _IDPCOM = value
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

    Private _FLAG As String
    Public Property FLAG() As String
        Get
            Return _FLAG
        End Get
        Set(ByVal value As String)
            _FLAG = value
        End Set
    End Property

    Private _ACTUAL_VALUE As String
    Public Property ACTUAL_VALUE() As String
        Get
            Return _ACTUAL_VALUE
        End Get
        Set(ByVal value As String)
            _ACTUAL_VALUE = value
        End Set
    End Property

    Public Function ObtenerValorRegistro() As String
        Dim valor As String = ""
        valor = valor + Me.IDDCOM.ToString() + " | "
        valor = valor + Me.IDPCOM.ToString() + " | "
        valor = valor + Me.TIPO_TARJETA.ToString() + " | "
        valor = valor + Me.REVOLVENTE.ToString() + " | "
        valor = valor + Me.FECHA_HORA.ToString() + " | "
        valor = valor + Me.PLAZO_MIN.ToString() + " | "
        valor = valor + Me.PLAZO_MAX.ToString() + " | "
        valor = valor + Me.ENVIO_EECC.ToString() + " | "
        valor = valor + Me.SEG_DESG.ToString() + " | "
        valor = valor + Me.TEM.ToString() + " | "
        valor = valor + Me.TEA.ToString() + " | "
        valor = valor + Me.MEMBRECIA.ToString() + " | "
        valor = valor + Me.COM_ATM.ToString() + " | "
        valor = valor + Me.MONTO_MIN.ToString() + " | "
        valor = valor + Me.MONTO_MAX.ToString() + " | "
        valor = valor + Me.PRODUCTO
        Return valor
    End Function
End Class
