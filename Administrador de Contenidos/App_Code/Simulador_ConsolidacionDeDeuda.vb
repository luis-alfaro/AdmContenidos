Imports Microsoft.VisualBasic

Public Class Simulador_ConsolidacionDeDeuda

    Private _IDCDD As Integer
    Public Property IDCDD() As Integer
        Get
            Return _IDCDD
        End Get
        Set(ByVal value As Integer)
            _IDCDD = value
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
        valor = valor + Me.IDCDD.ToString() + " | "
        valor = valor + Me.PLAZO_MIN.ToString() + " | "
        valor = valor + Me.PLAZO_MAX.ToString() + " | "
        valor = valor + Me.TEA.ToString() + " | "
        valor = valor + Me.MONTO_MIN.ToString() + " | "
        valor = valor + Me.MONTO_MAX.ToString()
        Return valor
    End Function
End Class
