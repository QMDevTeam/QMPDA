

''' <summary>
''' Represents a Questionnaire Set.
''' </summary>

Public Class QuestionnaireSet

#Region " Properties "

    Private _questionnaireSetID As Integer
    Private _order As Integer
    Private _shortName As String
    Private _name As String
    Private _preCondition As Boolean
    Private _subjectSecondaryIDField As String
    Private _subjectAlternativeSearchField As String
    Private _subjectConfirmationFields As String
    Private _newSubjectSectionID As Nullable(Of Integer)
    Private _onNewSubject As Boolean

    Private _questionnaires As List(Of Questionnaire)



    Public ReadOnly Property QuestionnaireSetID() As Integer
        Get
            Return _questionnaireSetID
        End Get
    End Property


    Public ReadOnly Property Order() As Integer
        Get
            Return _order
        End Get
    End Property


    Public ReadOnly Property ShortName() As String
        Get
            Return _shortName
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public ReadOnly Property SubjectSecondaryIDField() As String
        Get
            Return _subjectSecondaryIDField
        End Get
    End Property


    Public ReadOnly Property SubjectAlternativeSearchField() As String
        Get
            Return _subjectAlternativeSearchField
        End Get
    End Property


    Public ReadOnly Property SubjectConfirmationFields() As String
        Get
            Return _subjectConfirmationFields
        End Get
    End Property


    Public ReadOnly Property NewSubjectSectionID() As Nullable(Of Integer)
        Get
            Return _newSubjectSectionID
        End Get
    End Property


    Public ReadOnly Property Questionnaires() As List(Of Questionnaire)
        Get
            If _questionnaires Is Nothing Then _questionnaires = Questionnaire.GetAll(_questionnaireSetID)
            Return _questionnaires
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Gets all the Questionnaire Sets of the Study.
    ''' </summary>
    ''' <returns>A <c>List(Of QuestionnaireSet)</c> with all the Questionnaire Sets of the Study.</returns>

    Public Shared Function GetAll() As List(Of QuestionnaireSet)

        Dim list As New List(Of QuestionnaireSet)
        Dim records As List(Of Object()) = DA.Questionnaireset.GetAll()

        For idx As Integer = 0 To records.Count - 1
            list.Add(New QuestionnaireSet(records(idx)))
        Next

        Return list

    End Function



    ''' <summary>
    ''' Gets all the Questionnaire Sets of the Study that fulfills their Precondition.
    ''' </summary>
    ''' <returns>A <c>List(Of QuestionnaireSet)</c> with all the Questionnaire Sets of the Study that fulfills their Precondition.</returns>

    Public Shared Function GetAllValid() As List(Of QuestionnaireSet)

        Dim validQuestionnaireSets As New List(Of QuestionnaireSet)

        For Each questionnaireSet As QuestionnaireSet In GetAll()
            If questionnaireSet.EvaluatePreCondition Then validQuestionnaireSets.Add(questionnaireSet)
        Next

        Return validQuestionnaireSets

    End Function



    Public Sub ExecuteOnNewSubjectProcedure()
        If _onNewSubject Then Procedure.Execute(Context.ConstructorsDotNETClassName, "OnNewSubject_" & Me.ShortName, Nothing)
    End Sub



    Public Function EvaluatePreCondition() As Boolean
        If _preCondition Then
            Return CBool(Evaluator.EvaluateFunction(Context.PreconditionsDotNETClassName, "Precondition_" & Me.ShortName, TypeCode.Boolean, Nothing))
        Else
            Return True
        End If
    End Function

#Region " Subject "

    Public Function CreateSubject() As Subject
        Return Subject.Create(Me, Context.CurrentSite)
    End Function



    Public Function SubjectExists(ByVal SASubjectID As String) As Boolean
        Return Subject.Exists(SASubjectID, Me)
    End Function



    Public Function GetSubject(ByVal subjectID As Guid) As Subject
        Return New Subject(subjectID, Me)
    End Function



    Public Function GetSubject(ByVal SASubjectID As String) As Subject
        Return New Subject(SASubjectID, Me)
    End Function



    Public Function GetSubjects(ByVal subjectCondition As Subject.SubjectCondition, ByVal site As Site) As DataTable
        Return Subject.GetAll(subjectCondition, Me, site)
    End Function

#End Region

    Public Shared Operator =(ByVal operand1 As QuestionnaireSet, ByVal operand2 As QuestionnaireSet) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.QuestionnaireSetID = operand2.QuestionnaireSetID
    End Operator



    Public Shared Operator <>(ByVal operand1 As QuestionnaireSet, ByVal operand2 As QuestionnaireSet) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.QuestionnaireSetID <> operand2.QuestionnaireSetID
    End Operator

#End Region

#Region " Private Methods "

    Private Sub New(ByVal properties() As Object)
        PopulateProperties(properties)
    End Sub



    ''' <summary>
    ''' Sets the properties values
    ''' </summary>
    ''' <param name="properties">The array of type <c>Object</c> with the values for the properties.</param>

    Sub PopulateProperties(ByVal properties() As Object)

        _questionnaireSetID = CInt(properties(0))
        _order = CInt(properties(1))
        _shortName = CStr(properties(2))
        _name = CStr(properties(3))
        _preCondition = CBool(properties(4))
        _onNewSubject = CBool(properties(9))

        If TypeOf properties(5) Is DBNull Then _subjectSecondaryIDField = Nothing Else _subjectSecondaryIDField = CStr(properties(5))
        If TypeOf properties(6) Is DBNull Then _subjectAlternativeSearchField = Nothing Else _subjectAlternativeSearchField = CStr(properties(6))
        If TypeOf properties(7) Is DBNull Then _subjectConfirmationFields = Nothing Else _subjectConfirmationFields = CStr(properties(7))
        If TypeOf properties(8) Is DBNull Then _newSubjectSectionID = Nothing Else _newSubjectSectionID = CInt(properties(8))

    End Sub

#End Region

End Class