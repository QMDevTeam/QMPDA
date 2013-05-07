

''' <summary>
''' Gets the address of the screen
''' </summary>

Public Class ScreenTemplate

#Region " Properties "

    Private _screenTemplateID As Integer
    Private _dotNETClassName As String



    Public ReadOnly Property ScreenTemplateID() As Integer
        Get
            Return _screenTemplateID
        End Get
    End Property


    Public ReadOnly Property DotNETClassName() As String
        Get
            Return _dotNETClassName
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Set the properties values if the screen template id is correct
    ''' </summary>
    ''' <param name="screenTemplateID">the screen template id</param>

    Public Sub New(ByVal screenTemplateID As Integer)

        Dim row As DataRow = DA.ScreenTemplate.GetSingle(screenTemplateID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The ScreenTemplate with ID[{0}] does not exists", screenTemplateID))
        PopulateProperties(row)

    End Sub

#End Region

#Region " Private Methods "

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Assing the properties values
    ''' </summary>
    ''' <param name="row">DataRow with the values</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _screenTemplateID = CInt(row("ScreenTemplateID"))
        _dotNETClassName = CStr(row("DotNETClassName"))

    End Sub

#End Region

End Class