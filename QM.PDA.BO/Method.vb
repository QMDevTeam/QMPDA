Imports System.Reflection


''' <summary>
''' Represents a Method with .NET code that can be invoked
''' to performe actions in the different extensibility points
''' of a Questionnaire.
''' </summary>

Public Class Method

#Region " Properties "

    Private _methodName As String
    Private _dotNETClassID As Integer
    Private _dotNETMethodName As String

    Private _dotNETClass As DotNETClass
    Private _methodInfo As MethodInfo



    Public ReadOnly Property MethodName() As String
        Get
            Return _methodName
        End Get
    End Property


    Public ReadOnly Property DotNETClassID() As Integer
        Get
            Return _dotNETClassID
        End Get
    End Property


    Public ReadOnly Property DotNETMethodName() As String
        Get
            Return _dotNETMethodName
        End Get
    End Property


    Public ReadOnly Property DotNETClass() As DotNETClass
        Get
            If _dotNETClass Is Nothing Then _dotNETClass = New DotNETClass(_dotNETClassID)
            Return _dotNETClass
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Creates an instance based on the unique Method name provided.
    ''' </summary>
    ''' <param name="methodName">The unique name of the Method to instanciate.</param>

    Public Sub New(ByVal methodName As String)

        Dim row As DataRow = DA.Method.GetSingle(methodName)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The Method with Name[{0}] does not exists", methodName))
        PopulateProperties(row)

        _methodInfo = DotNETClass.ClassType.GetMethod(_dotNETMethodName)
        If _methodInfo Is Nothing Then Throw New ApplicationException(String.Format("The .NET Method [{0}] does not exists in the Class[{1}]", _dotNETMethodName, DotNETClass.ClassType.FullName))
        If Not _methodInfo.IsStatic Then Throw New ApplicationException(String.Format("The .NET Method [{0}] in the Class [{1}] must be Static (Shared in VB)", _dotNETMethodName, DotNETClass.ClassType.FullName))

    End Sub



    Public Function Invoke(ByVal parameters As Object()) As Object

        ' Check if the amount of provided parameters match the amount of parameters the method expect.
        Dim providedParametersCount As Integer = 0
        Dim expectedParametersCount As Integer = 0
        Dim methodParameters() As ParameterInfo = _methodInfo.GetParameters

        If parameters IsNot Nothing Then providedParametersCount = parameters.Length
        If methodParameters IsNot Nothing Then expectedParametersCount = methodParameters.Length

        If providedParametersCount <> expectedParametersCount Then Throw New ApplicationException(String.Format("The amount of parameters provided [{0}] does not match the amount of expected parameters [{1}].", providedParametersCount, expectedParametersCount))


        ' Convert the parameters to the expected type
        Dim values() As Object = Nothing
        If expectedParametersCount > 0 Then

            ReDim values(expectedParametersCount - 1)

            For idx As Integer = 0 To parameters.Length - 1
                If parameters(idx) IsNot Nothing Then values(idx) = Convert.ChangeType(parameters(idx), methodParameters(idx).ParameterType, Nothing)
            Next
        End If


        ' Invoke the Method
        Return _methodInfo.Invoke(Nothing, values)

    End Function

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

        _methodName = CStr(row("MethodName"))
        _dotNETClassID = CInt(row("DotNETClassID"))
        _dotNETMethodName = CStr(row("DotNETMethodName"))

    End Sub

#End Region

End Class