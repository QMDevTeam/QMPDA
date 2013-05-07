

''' <summary>
''' Sets a variable values
''' </summary>

Public Class Variable

#Region " Properties "

    Private _variableName As String
    Private _dataType As String
    Private _mainText As String
    Private _helpText As String
    Private _required As Nullable(Of Boolean)
    Private _absMin As String
    Private _absMax As String
    Private _promptUnder As String
    Private _promptOver As String
    Private _legalValueTable As String



    Public ReadOnly Property VariableName() As String
        Get
            Return _variableName
        End Get
    End Property


    Public ReadOnly Property DataType() As String
        Get
            Return _dataType
        End Get
    End Property


    Public ReadOnly Property MainText() As String
        Get
            Return _mainText
        End Get
    End Property


    Public ReadOnly Property HelpText() As String
        Get
            Return _helpText
        End Get
    End Property


    Public ReadOnly Property Required() As Nullable(Of Boolean)
        Get
            Return _required
        End Get
    End Property


    Public ReadOnly Property AbsMin() As String
        Get
            Return _absMin
        End Get
    End Property


    Public ReadOnly Property AbsMax() As String
        Get
            Return _absMax
        End Get
    End Property


    Public ReadOnly Property PromptUnder() As String
        Get
            Return _promptUnder
        End Get
    End Property


    Public ReadOnly Property PromptOver() As String
        Get
            Return _promptOver
        End Get
    End Property


    Public ReadOnly Property LegalValueTable() As String
        Get
            Return _legalValueTable
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Obtains and sets the properties values of a variable
    ''' </summary>
    ''' <param name="variableName">Name of the variable</param>

    Public Sub New(ByVal variableName As String)

        Dim row As DataRow = DA.Variable.GetSingle(variableName)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The Variable with Name[{0}] does not exists", variableName))
        PopulateProperties(row)

    End Sub



    ''' <summary>
    ''' Indicates if a Variable with the specified identifier exists.
    ''' </summary>
    ''' <param name="variableName">Name of the variable</param>
    ''' <returns><c>True</c> if the variable exists, <c>False</c> otherwise.</returns>

    Public Shared Function Exists(ByVal variableName As String) As Boolean
        Return DA.Variable.Exists(variableName)
    End Function

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="row"></param>

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the propierties values
    ''' </summary>
    ''' <param name="row">DataRow with all the data</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _variableName = CStr(row("VariableName"))
        _dataType = CStr(row("DataType"))

        If TypeOf row("MainText") Is DBNull Then _mainText = Nothing Else _mainText = CStr(row("MainText"))
        If TypeOf row("HelpText") Is DBNull Then _helpText = Nothing Else _helpText = CStr(row("HelpText"))
        If TypeOf row("Required") Is DBNull Then _required = Nothing Else _required = CBool(row("Required"))
        If TypeOf row("AbsMin") Is DBNull Then _absMin = Nothing Else _absMin = CStr(row("AbsMin"))
        If TypeOf row("AbsMax") Is DBNull Then _absMax = Nothing Else _absMax = CStr(row("AbsMax"))
        If TypeOf row("PromptUnder") Is DBNull Then _promptUnder = Nothing Else _promptUnder = CStr(row("PromptUnder"))
        If TypeOf row("PromptOver") Is DBNull Then _promptOver = Nothing Else _promptOver = CStr(row("PromptOver"))
        If TypeOf row("LegalValueTable") Is DBNull Then _legalValueTable = Nothing Else _legalValueTable = CStr(row("LegalValueTable"))

    End Sub

#End Region

End Class