Imports System.Data
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq

''' <summary>
''' Summary description for GrillaDinamica
''' </summary>
Public Class GrillaDinamica
    Implements ITemplate
    Private templateType As DataControlRowType
    Private columnName As String

    Public Sub New(ByVal type As DataControlRowType, ByVal colname As String)
        templateType = type
        columnName = colname
    End Sub

    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        ' Create the content for the different row types.
        Select Case templateType
            Case DataControlRowType.Header
                ' Create the controls to put in the header
                ' section and set their properties.
                Dim lc As New Literal()
                lc.Text = "<b>" & columnName & "</b>"

                ' Add the controls to the Controls collection
                ' of the container.
                container.Controls.Add(lc)
                Exit Select
            Case DataControlRowType.DataRow
                ' Create the controls to put in a data row
                ' section and set their properties.
                Dim firstName As New Label()
                Dim lastName As New Label()

                Dim spacer As New Literal()
                spacer.Text = " "

                ' To support data binding, register the event-handling methods
                ' to perform the data binding. Each control needs its own event
                ' handler.
                AddHandler firstName.DataBinding, New EventHandler(AddressOf Me.FirstName_DataBinding)
                AddHandler lastName.DataBinding, New EventHandler(AddressOf Me.LastName_DataBinding)

                ' Add the controls to the Controls collection
                ' of the container.
                container.Controls.Add(firstName)
                container.Controls.Add(spacer)
                container.Controls.Add(lastName)
                Exit Select
            Case Else

                ' Insert cases to create the content for the other 
                ' row types, if desired.

                ' Insert code to handle unexpected values.
                Exit Select
        End Select
    End Sub

    Private Sub FirstName_DataBinding(ByVal sender As [Object], ByVal e As EventArgs)
        ' Get the Label control to bind the value. The Label control
        ' is contained in the object that raised the DataBinding 
        ' event (the sender parameter).
        Dim l As Label = DirectCast(sender, Label)

        ' Get the GridViewRow object that contains the Label control. 
        Dim row As GridViewRow = DirectCast(l.NamingContainer, GridViewRow)

        ' Get the field value from the GridViewRow object and 
        ' assign it to the Text property of the Label control.
        l.Text = DataBinder.Eval(row.DataItem, "au_fname").ToString()
    End Sub

    Private Sub LastName_DataBinding(ByVal sender As [Object], ByVal e As EventArgs)
        ' Get the Label control to bind the value. The Label control
        ' is contained in the object that raised the DataBinding 
        ' event (the sender parameter).
        Dim l As Label = DirectCast(sender, Label)

        ' Get the GridViewRow object that contains the Label control.
        Dim row As GridViewRow = DirectCast(l.NamingContainer, GridViewRow)

        ' Get the field value from the GridViewRow object and 
        ' assign it to the Text property of the Label control.
        l.Text = DataBinder.Eval(row.DataItem, "au_lname").ToString()
    End Sub
End Class


Public Class ColumnaTextoTemplate
    Implements ITemplate
    Private _ColName As String
    Private _rowType As DataControlRowType
    'int _Count;
    Private _CargarData As Boolean

    Public Sub New(ByVal ColName As String, ByVal RowType As DataControlRowType, ByVal CargarData As Boolean)
        _ColName = ColName
        _rowType = RowType
        _CargarData = CargarData
    End Sub

    ''' <summary>
    ''' el metodo InstantiateIn es un metodo virtual de la interface ITemplate
    ''' </summary>
    ''' <param name="container"></param>
    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        Select Case _rowType
            Case DataControlRowType.Header
                Dim lc As New Literal()
                lc.Text = "<b>" & _ColName & "</b>"
                container.Controls.Add(lc)
                Exit Select
            Case DataControlRowType.DataRow
                Dim txt As New Label
                txt.Height = 20
                txt.Width = 40
                AddHandler txt.DataBinding, New EventHandler(AddressOf Me.txt_DataBind)
                container.Controls.Add(txt)
                Exit Select
            Case DataControlRowType.Separator
                Dim txt As New CheckBox
                txt.Height = 20
                txt.Width = 40
                AddHandler txt.DataBinding, New EventHandler(AddressOf Me.txt_DataBind)
                container.Controls.Add(txt)
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub

    Private Sub txt_DataBind(ByVal sender As [Object], ByVal e As EventArgs)
        If _CargarData = True Then
            'Label txt = (Label)sender;
            Dim txt As Label = DirectCast(sender, Label)
            Dim row As GridViewRow = DirectCast(txt.NamingContainer, GridViewRow)
            txt.Text = DataBinder.Eval(row.DataItem, _ColName).ToString()
        End If
    End Sub

End Class


