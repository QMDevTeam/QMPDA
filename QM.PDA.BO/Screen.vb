

''' <summary>
''' Represents a Screen to be displayed in a Questionnaire.
''' Provides access to the properties and methods that rule
''' the behavior of the Screen.
''' </summary>

Public Class Screen

#Region " Properties "

    Public Enum VariableLocation
        Subject
        Record
    End Enum


    Public Enum VariableScopeType As Integer
        Subject = 2
        Questionnaire = 3
        Section = 4
    End Enum


    Private _screenID As Integer
    Private _sectionID As Integer
    Private _name As String
    Private _type As String
    Private _number As String
    Private _screenTemplateID As Nullable(Of Integer)
    Private _arguments As String
    Private _variableScope As Nullable(Of Integer)
    Private _variableName As String
    Private _dataType As String
    Private _mainText As String
    Private _mainTextColor As String
    Private _otherText1 As String
    Private _otherText1Color As String
    Private _otherText2 As String
    Private _otherText2Color As String
    Private _otherText3 As String
    Private _otherText3Color As String
    Private _helpText As String
    Private _required As Nullable(Of Boolean)
    Private _absMin As Boolean
    Private _absMax As Boolean
    Private _promptUnder As Boolean
    Private _promptOver As Boolean
    Private _legalValueTable As String
    Private _customValidation As Boolean
    Private _customValidationFailMessage As String
    Private _onChange As Boolean
    Private _onLoad As Boolean
    Private _onUnload As Boolean
    Private _confirmChange As Nullable(Of Boolean)
    Private _hideNext As Nullable(Of Boolean)
    Private _hideBack As Nullable(Of Boolean)
    Private _confirmNext As Nullable(Of Boolean)
    Private _confirmBack As Nullable(Of Boolean)


    Private _screenTemplate As ScreenTemplate
    Private _variable As Variable

    Private _transitions As List(Of Transition)
    Private _argumentsDictionary As Specialized.StringDictionary



    Public ReadOnly Property ScreenID() As Integer
        Get
            Return _screenID
        End Get
    End Property


    Public ReadOnly Property SectionID() As Integer
        Get
            Return _sectionID
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public ReadOnly Property Type() As String
        Get
            Return _type
        End Get
    End Property


    Public ReadOnly Property Number() As String
        Get
            Return _number
        End Get
    End Property


    Public ReadOnly Property Arguments(ByVal argumentName As String) As String
        Get
            ' This property expects to find an arguments string in the _arguments field
            ' of the following form: key1=value1;key2=value2;key3=value3

            ' If the arguments cache list has not been created, create it
            If _argumentsDictionary Is Nothing Then

                ' If there are arguments for the Screen, create the arguments cache list
                If Not String.IsNullOrEmpty(_arguments) Then

                    ' Create the arguments cache list
                    _argumentsDictionary = New Specialized.StringDictionary

                    ' Split into argument pairs: key=value
                    Dim argumentPairs As String() = _arguments.Split(";"c)
                    Dim argumentPair As String()


                    ' Split each argument pair and add it to the cache list
                    For idx As Integer = 0 To argumentPairs.Length - 1
                        argumentPair = argumentPairs(idx).Split("="c)
                        If argumentPair.Length = 2 Then _argumentsDictionary.Add(argumentPair(0).Trim, argumentPair(1).Trim)
                    Next

                    ' Return the specified argument
                    Return _argumentsDictionary(argumentName)


                Else ' If there are no arguments for the Screen, return Nothing as a value for the argument
                    Return Nothing
                End If


            Else ' If the arguments cache list already exists, return the specified argument
                Return _argumentsDictionary(argumentName)
            End If

        End Get

    End Property


    Public ReadOnly Property ArgumentsString() As String
        Get
            Return _arguments
        End Get
    End Property


    Public ReadOnly Property VariableScope() As VariableScopeType
        Get
            Return CType(_variableScope, VariableScopeType)
        End Get
    End Property


    Public ReadOnly Property VariableName() As String
        Get
            Return _variableName
        End Get
    End Property


    Public ReadOnly Property DataType() As String
        Get
            If _dataType Is Nothing Then
                If Not Variable Is Nothing Then _dataType = Variable.DataType
            End If
            Return _dataType
        End Get
    End Property


    Public ReadOnly Property MainText() As String
        Get
            If _mainText Is Nothing Then
                If Not Variable Is Nothing Then _mainText = Variable.MainText
            End If
            Return _mainText
        End Get
    End Property


    Public ReadOnly Property MainTextColor() As String
        Get
            Return _mainTextColor
        End Get
    End Property


    Public ReadOnly Property OtherText1() As String
        Get
            Return _otherText1
        End Get
    End Property


    Public ReadOnly Property OtherText1Color() As String
        Get
            Return _otherText1Color
        End Get
    End Property


    Public ReadOnly Property OtherText2() As String
        Get
            Return _otherText2
        End Get
    End Property


    Public ReadOnly Property OtherText2Color() As String
        Get
            Return _otherText2Color
        End Get
    End Property


    Public ReadOnly Property OtherText3() As String
        Get
            Return _otherText3
        End Get
    End Property


    Public ReadOnly Property OtherText3Color() As String
        Get
            Return _otherText3Color
        End Get
    End Property


    Public ReadOnly Property HelpText() As String
        Get
            If _helpText Is Nothing Then
                If Not Variable Is Nothing Then _helpText = Variable.HelpText
            End If
            Return _helpText
        End Get
    End Property


    Public ReadOnly Property Required() As Nullable(Of Boolean)
        Get
            If Not _required.HasValue Then
                If Not Variable Is Nothing Then _required = Variable.Required
            End If
            Return _required
        End Get
    End Property


    Public ReadOnly Property AbsMin() As Boolean
        Get
            Return _absMin
        End Get
    End Property


    Public ReadOnly Property AbsMax() As Boolean
        Get
            Return _absMax
        End Get
    End Property


    Public ReadOnly Property PromptUnder() As Boolean
        Get
            Return _promptUnder
        End Get
    End Property


    Public ReadOnly Property PromptOver() As Boolean
        Get
            Return _promptOver
        End Get
    End Property


    Public ReadOnly Property LegalValueTable() As String
        Get
            If _legalValueTable Is Nothing Then
                If Not Variable Is Nothing Then _legalValueTable = Variable.LegalValueTable
            End If
            Return _legalValueTable
        End Get
    End Property


    Public ReadOnly Property ConfirmChange() As Nullable(Of Boolean)
        Get
            Return _confirmChange
        End Get
    End Property


    Public ReadOnly Property HideNext() As Nullable(Of Boolean)
        Get
            Return _hideNext
        End Get
    End Property


    Public ReadOnly Property HideBack() As Nullable(Of Boolean)
        Get
            Return _hideBack
        End Get
    End Property


    Public ReadOnly Property ConfirmNext() As Nullable(Of Boolean)
        Get
            Return _confirmNext
        End Get
    End Property


    Public ReadOnly Property ConfirmBack() As Nullable(Of Boolean)
        Get
            Return _confirmBack
        End Get
    End Property


    Public ReadOnly Property ScreenTemplate() As ScreenTemplate
        Get
            If _screenTemplateID.HasValue AndAlso _screenTemplate Is Nothing Then _screenTemplate = New ScreenTemplate(_screenTemplateID.Value)
            Return _screenTemplate
        End Get
    End Property


    Public ReadOnly Property Variable() As Variable
        Get
            If _variable Is Nothing Then
                If Not String.IsNullOrEmpty(_variableName) AndAlso Variable.Exists(_variableName) Then
                    _variable = New Variable(_variableName)
                End If
            End If
            Return _variable
        End Get
    End Property

    Public ReadOnly Property CustomValidationFailMessage() As String
        Get
            Return _customValidationFailMessage
        End Get
    End Property

    Public ReadOnly Property Transitions() As List(Of Transition)
        Get
            If _transitions Is Nothing Then _transitions = Transition.GetAll(_screenID)
            Return _transitions
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Creates an instance based on the identifier provided.
    ''' </summary>
    ''' <param name="screenID">The unique identifier of the Screen object to instanciate.</param>

    Public Sub New(ByVal screenID As Integer)

        Dim row As DataRow = DA.Screen.GetSingle(screenID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The Screen with ID[{0}] does not exists", screenID))
        PopulateProperties(row)

    End Sub



    ''' <summary>
    ''' Gets a table with the items in the Legal Value Table for this Screen.
    ''' </summary>
    ''' <returns>A <c>DataTable</c> with the items in the Legal Value Table.</returns>

    Public Function GetLegalValueTableItems() As DataTable

        ' Get the filter variable, if there is one.
        Dim filterVariableName As String = Me.Arguments("filterVariable")
        Dim filterVariableValue As String = Nothing
        If Not String.IsNullOrEmpty(filterVariableName) Then
            Select Case True
                Case Context.CurrentSection.DataRecord.VariableExists(filterVariableName) : filterVariableValue = CStr(Context.CurrentSection(filterVariableName))
                Case Context.CurrentQuestionnaire.DataRecord.VariableExists(filterVariableName) : filterVariableValue = CStr(Context.CurrentQuestionnaire(filterVariableName))
                Case Context.CurrentSubject.DataRecord.VariableExists(filterVariableName) : filterVariableValue = CStr(Context.CurrentSubject(filterVariableName))
                Case Else : Throw New ApplicationException(String.Format("The Filter Variable [{0}] for the Screen [{1}] can not be found", filterVariableName, Me.ScreenID))
            End Select
        End If


        ' If the Legal Value Table is not defined return no data.
        If LegalValueTable Is Nothing OrElse LegalValueTable.Length = 0 Then Return Nothing

        ' Return the data from the specified Legal Value Table. 
        Return DA.Common.GetLegalValueTableItems(LegalValueTable, filterVariableValue)

    End Function



    ''' <summary>
    ''' Inserts a new item into a Legal Value Table.
    ''' </summary>
    ''' <param name="table">The name of the Legal Value Table.</param>
    ''' <param name="value">The Value for the new item.</param>
    ''' <param name="order">The Order for the new item.</param>
    ''' <param name="text">The Text for the new item.</param>
    ''' <param name="shortName">The Short Name for the new item.</param>
    ''' <param name="group">The Group for the new item.</param>

    Public Shared Sub InsertLegalValueTableItem(ByVal table As String, ByVal value As Integer, ByVal order As Integer, ByVal text As String, Optional ByVal shortName As String = Nothing, Optional ByVal group As String = Nothing)
        DA.Common.InsertLegalValueTableItem(table, value, order, text, shortName, group)
    End Sub



    ''' <summary>
    ''' Gets the value of the Variable that this Screen access.
    ''' </summary>
    ''' <returns>An <c>Object</c> if there is a value,<c>Nothing</c> otherwise.</returns>
    ''' <remarks>This overload uses the Variable asigned to this Screen.</remarks>

    Public Function GetInitialValue() As Object
        Return GetInitialValue(_variableName)
    End Function



    ''' <summary>
    ''' Gets the value of the specified Variable.
    ''' </summary>
    ''' <param name="variableName">The name of the variable.</param>
    ''' <returns>An <c>Object</c> if there is a value,<c>Nothing</c> otherwise.</returns>
    ''' <remarks>If there is no Variable assigned to this Screen, this method will return <c>Nothing</c>.</remarks>

    Public Function GetInitialValue(ByVal variableName As String) As Object

        ' If there isn't a Variable Name, return Nothing.
        If String.IsNullOrEmpty(variableName) OrElse Not Variable.Exists(variableName) Then Return Nothing

        Select Case VariableScope
            Case VariableScopeType.Section : Return Context.CurrentSection(variableName)
            Case VariableScopeType.Questionnaire : Return Context.CurrentQuestionnaire(variableName)
            Case VariableScopeType.Subject : Return Context.CurrentSubject(variableName)
            Case Else : Return Nothing
        End Select

    End Function



    ''' <summary>
    ''' Stores the value that the user provided in the Variable that this Screen access.
    ''' </summary>
    ''' <param name="value">The value to store in the Variable.</param>
    ''' <remarks>This overload uses the Variable asigned to this Screen.</remarks>

    Public Sub StoreValue(ByVal value As Object)
        StoreValue(_variableName, value)
    End Sub



    ''' <summary>
    ''' Stores the value that the user provided in the specified Variable.
    ''' </summary>
    ''' <param name="variableName">The name of the Variable.</param>
    ''' <param name="value">The value to store in the Variable.</param>
    ''' <remarks>This overload determines the location of the Variable using the Screen settings.</remarks>

    Public Sub StoreValue(ByVal variableName As String, ByVal value As Object)

        ' If there isn't a Variable Name, do nothing.
        If String.IsNullOrEmpty(variableName) OrElse Not Variable.Exists(variableName) Then Return

        Select Case VariableScope
            Case VariableScopeType.Section : Context.CurrentSection(variableName) = value
            Case VariableScopeType.Questionnaire : Context.CurrentQuestionnaire(variableName) = value
            Case VariableScopeType.Subject : Context.CurrentSubject(variableName) = value
        End Select

    End Sub



    ''' <summary>
    ''' Evaluates the Custom Validation and returns the result.
    ''' </summary>
    ''' <param name="inputValue">The user input in the Screen.</param>
    ''' <returns>The result of the evaluation of the External Validation.</returns>

    Public Function EvaluateCustomValidation(ByVal inputValue As Object) As Boolean
        If Me._customValidation Then
            Return CBool(Evaluator.EvaluateFunction(Context.ValidationsDotNETClassName, "CustomValidation" & Context.MethodNameSufix, TypeCode.Boolean, New Object() {inputValue}))
        Else
            Return True
        End If
    End Function



    Public Sub ExecuteOnChangeProcedure()
        If _onChange Then Procedure.Execute(Context.EventsDotNETClassName, "OnChange" & Context.MethodNameSufix, Nothing)
    End Sub



    Public Sub ExecuteOnLoadProcedure()
        If _onLoad Then Procedure.Execute(Context.EventsDotNETClassName, "OnLoad" & Context.MethodNameSufix, Nothing)
    End Sub



    Public Sub ExecuteOnUnloadProcedure()
        If _onUnload Then Procedure.Execute(Context.EventsDotNETClassName, "OnUnload" & Context.MethodNameSufix, Nothing)
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

        _screenID = CInt(row("ScreenID"))
        _sectionID = CInt(row("SectionID"))
        _name = CStr(row("Name"))
        _type = CStr(row("Type"))
        _onChange = CBool(row("OnChange"))
        _onLoad = CBool(row("OnLoad"))
        _onUnload = CBool(row("OnUnload"))
        _customValidation = CBool(row("CustomValidation"))
        _customValidationFailMessage = row("CustomValidationFailMessage").ToString

        If TypeOf row("Number") Is DBNull Then _number = Nothing Else _number = CStr(row("Number"))
        If TypeOf row("ScreenTemplateID") Is DBNull Then _screenTemplateID = Nothing Else _screenTemplateID = CInt(row("ScreenTemplateID"))
        If TypeOf row("Arguments") Is DBNull Then _arguments = Nothing Else _arguments = CStr(row("Arguments"))
        If TypeOf row("VariableScope") Is DBNull Then _variableScope = Nothing Else _variableScope = CInt(row("VariableScope"))
        If TypeOf row("VariableName") Is DBNull Then _variableName = Nothing Else _variableName = CStr(row("VariableName"))
        If TypeOf row("DataType") Is DBNull Then _dataType = Nothing Else _dataType = CStr(row("DataType"))
        If TypeOf row("MainText") Is DBNull Then _mainText = Nothing Else _mainText = CStr(row("MainText"))
        If TypeOf row("MainTextColor") Is DBNull Then _mainTextColor = Nothing Else _mainTextColor = CStr(row("MainTextColor"))
        If TypeOf row("OtherText1") Is DBNull Then _otherText1 = Nothing Else _otherText1 = CStr(row("OtherText1"))
        If TypeOf row("OtherText1Color") Is DBNull Then _otherText1Color = Nothing Else _otherText1Color = CStr(row("OtherText1Color"))
        If TypeOf row("OtherText2") Is DBNull Then _otherText2 = Nothing Else _otherText2 = CStr(row("OtherText2"))
        If TypeOf row("OtherText2Color") Is DBNull Then _otherText2Color = Nothing Else _otherText2Color = CStr(row("OtherText2Color"))
        If TypeOf row("OtherText3") Is DBNull Then _otherText3 = Nothing Else _otherText3 = CStr(row("OtherText3"))
        If TypeOf row("OtherText3Color") Is DBNull Then _otherText3Color = Nothing Else _otherText3Color = CStr(row("OtherText3Color"))
        If TypeOf row("HelpText") Is DBNull Then _helpText = Nothing Else _helpText = CStr(row("HelpText"))
        If TypeOf row("Required") Is DBNull Then _required = Nothing Else _required = CBool(row("Required"))
        If TypeOf row("AbsMin") Is DBNull Then _absMin = False Else _absMin = CBool(row("AbsMin"))
        If TypeOf row("AbsMax") Is DBNull Then _absMax = False Else _absMax = CBool(row("AbsMax"))
        If TypeOf row("PromptUnder") Is DBNull Then _promptUnder = False Else _promptUnder = CBool(row("PromptUnder"))
        If TypeOf row("PromptOver") Is DBNull Then _promptOver = False Else _promptOver = CBool(row("PromptOver"))
        If TypeOf row("LegalValueTable") Is DBNull Then _legalValueTable = Nothing Else _legalValueTable = CStr(row("LegalValueTable"))
        If TypeOf row("ConfirmChange") Is DBNull Then _confirmChange = Nothing Else _confirmChange = CBool(row("ConfirmChange"))
        If TypeOf row("HideNext") Is DBNull Then _hideNext = Nothing Else _hideNext = CBool(row("HideNext"))
        If TypeOf row("HideBack") Is DBNull Then _hideBack = Nothing Else _hideBack = CBool(row("HideBack"))
        If TypeOf row("ConfirmNext") Is DBNull Then _confirmNext = Nothing Else _confirmNext = CBool(row("ConfirmNext"))
        If TypeOf row("ConfirmBack") Is DBNull Then _confirmBack = Nothing Else _confirmBack = CBool(row("ConfirmBack"))

    End Sub

#End Region

End Class