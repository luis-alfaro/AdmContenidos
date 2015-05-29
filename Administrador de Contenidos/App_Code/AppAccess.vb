Imports Microsoft.VisualBasic

Public Class AppAccess
    Private _AccessID As Integer
    Public Property AccessID() As Integer
        Get
            Return _AccessID
        End Get
        Set(ByVal value As Integer)
            _AccessID = value
        End Set
    End Property

    Private _RoleID As Integer
    Public Property RoleID() As Integer
        Get
            Return _RoleID
        End Get
        Set(ByVal value As Integer)
            _RoleID = value
        End Set
    End Property

    Private _MenuID As Integer
    Public Property MenuID() As Integer
        Get
            Return _MenuID
        End Get
        Set(ByVal value As Integer)
            _MenuID = value
        End Set
    End Property

    Private _MenuNombre As String
    Public Property MenuNombre() As String
        Get
            Return _MenuNombre
        End Get
        Set(ByVal value As String)
            _MenuNombre = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _estado As Boolean
    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _flag As Boolean
    Public Property Flag() As Boolean
        Get
            Return _flag
        End Get
        Set(ByVal value As Boolean)
            _flag = value
        End Set
    End Property

    Private _node As Integer
    Public Property Node() As Integer
        Get
            Return _node
        End Get
        Set(ByVal value As Integer)
            _node = value
        End Set
    End Property

    Private _childNode As Integer
    Public Property ChildNode() As Integer
        Get
            Return _childNode
        End Get
        Set(ByVal value As Integer)
            _childNode = value
        End Set
    End Property

End Class
