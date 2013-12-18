Imports Microsoft.VisualBasic

Public Class Actividades
    Public Structure Actividad

        Public Property m_() As String
            Get
                Return m__
            End Get
            Set(ByVal value As String)
                m__ = value
            End Set
        End Property
        Private m__ As String
    End Structure
End Class
