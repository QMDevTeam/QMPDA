

''' <summary>
''' Represents a .NET Class and contains information to create
''' an instance of the class.
''' </summary>

Public Class DotNETClass

#Region " Properties "

    Private _dotNETClassID As Integer
    Private _dotNETClassName As String

    Private _classType As Type


    Public ReadOnly Property DotNETClassID() As Integer
        Get
            Return _dotNETClassID
        End Get
    End Property


    Public ReadOnly Property DotNETClassName() As String
        Get
            Return _dotNETClassName
        End Get
    End Property


    Public ReadOnly Property ClassType() As Type
        Get
            If _classType Is Nothing Then _classType = Type.GetType(_dotNETClassName)
            If _classType Is Nothing Then Throw New ApplicationException(String.Format("The .NET Class [{0}] can't be found", _dotNETClassName))
            Return _classType
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Creates an instance based on the identifier provided.
    ''' </summary>
    ''' <param name="dotNETClassID">The unique identifier of the DotNETClass object to instanciate.</param>

    Public Sub New(ByVal dotNETClassID As Integer)

        Dim row As DataRow = DA.DotNETClass.GetSingle(dotNETClassID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The DotNETClass with ID[{0}] does not exists", dotNETClassID))
        PopulateProperties(row)

    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Creates an instance using the information contained in the data row provided.
    ''' </summary>
    ''' <param name="row">A <c>DataRow</c> with the information of the object.</param>

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the values for the object's properties.
    ''' </summary>
    ''' <param name="row">A <c>DataRow</c> with the information of the object.</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _dotNETClassID = CInt(row("DotNETClassID"))
        _dotNETClassName = CStr(row("DotNETClassName"))

    End Sub

#End Region

End Class