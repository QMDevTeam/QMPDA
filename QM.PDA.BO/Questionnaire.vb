Imports QM.PDA.BO.Context


''' <summary>
''' Represents a Questionnaire of a Questionnaire Set.
''' </summary>

Public Class Questionnaire

#Region " Properties "

    Private _questionnaireID As Integer
    Private _questionnaireSetID As Integer
    Private _order As Integer
    Private _multipleInstances As Boolean
    Private _shortName As String
    Private _name As String
    Private _preCondition As Boolean
    Private _instanceSAIDField As String
    Private _instanceSecondaryIDField As String
    Private _onNewRecord As Boolean

    Private _currentInstanceID As Byte
    Private _sections As List(Of Section)
    Private _dataTableName As String
    Private _dataRecord As DataRecord



    Public ReadOnly Property QuestionnaireID() As Integer
        Get
            Return _questionnaireID
        End Get
    End Property


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


    Public ReadOnly Property MultipleInstances() As Boolean
        Get
            Return _multipleInstances
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


    Public ReadOnly Property PreCondition() As Boolean
        Get
            Return _preCondition
        End Get
    End Property


    Public ReadOnly Property InstanceSAIDField() As String
        Get
            Return _instanceSAIDField
        End Get
    End Property


    Public ReadOnly Property InstanceSecondaryIDField() As String
        Get
            Return _instanceSecondaryIDField
        End Get
    End Property


    Public Property CurrentInstanceID() As Byte
        Get
            Return _currentInstanceID
        End Get
        Set(ByVal value As Byte)
            _currentInstanceID = value
        End Set
    End Property


    Public ReadOnly Property Instances() As List(Of QuestionnaireInstance)
        Get
            'If Not _multipleInstances Then Return Nothing
            Return QuestionnaireInstance.GetAll(Me, _dataTableName)
        End Get
    End Property


    Public ReadOnly Property Sections() As List(Of Section)
        Get
            If _sections Is Nothing Then _sections = Section.GetAll(_questionnaireID)
            Return _sections
        End Get
    End Property


    Public ReadOnly Property HasRecord() As Boolean
        Get
            If CurrentSubject Is Nothing Then Return False

            Dim result As Boolean = False
            Dim tempCurrentQuestionnaire As Questionnaire = CurrentQuestionnaire
            CurrentQuestionnaire = Me

            For Each section As Section In Sections
                If section.HasRecord Then : result = True : Exit For : End If
            Next
            CurrentQuestionnaire = tempCurrentQuestionnaire

            Return result

        End Get
    End Property


    Public ReadOnly Property IsComplete() As Boolean
        Get
            If CurrentSubject Is Nothing Then Return False

            Dim result As Boolean = True
            Dim tempCurrentQuestionnaire As Questionnaire = CurrentQuestionnaire
            Dim tempCurrentQuestionnaireInstanceID As Byte
            If CurrentQuestionnaire IsNot Nothing Then tempCurrentQuestionnaireInstanceID = CurrentQuestionnaire.CurrentInstanceID
            CurrentQuestionnaire = Me


            ' Commented to evaluate only the current Questionnaire Instance
            'If _multipleInstances Then

            '    For Each instance As QuestionnaireInstance In Me.Instances
            '        CurrentQuestionnaire.CurrentInstanceID = instance.InstanceID
            '        For Each section As Section In section.GetAllValid(Me.QuestionnaireID)
            '            If Not section.IsComplete Then : result = False : Exit For : End If
            '        Next
            '    Next
            'Else
            For Each section As Section In section.GetAllValid(Me.QuestionnaireID)
                If Not section.IsComplete Then : result = False : Exit For : End If
            Next
            'End If


            CurrentQuestionnaire = tempCurrentQuestionnaire
            If CurrentQuestionnaire IsNot Nothing Then CurrentQuestionnaire.CurrentInstanceID = tempCurrentQuestionnaireInstanceID

            Return result

        End Get
    End Property


    Default Public Property Item(ByVal Name As String) As Object
        Get
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> _currentInstanceID Then _dataRecord = Me.GetRecord
            If _dataRecord IsNot Nothing Then Return _dataRecord(Name)
            Return Nothing
        End Get
        Set(ByVal value As Object)
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> _currentInstanceID Then _dataRecord = Me.GetRecord
            If _dataRecord IsNot Nothing Then _dataRecord(Name) = value
        End Set
    End Property


    Public ReadOnly Property DataRecord() As DataRecord
        Get
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> _currentInstanceID Then _dataRecord = Me.GetRecord
            Return _dataRecord
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Creates an instance based on the identifier provided.
    ''' </summary>
    ''' <param name="questionnaireID">The identifier of the Questionnaire to instanciate.</param>

    Public Sub New(ByVal questionnaireID As Integer)

        Dim properties() As Object = DA.Questionnaire.GetSingle(questionnaireID)

        If properties Is Nothing Then Throw New ApplicationException(String.Format("The Questionnaire with QuestionnaireID[{0}] does not exists", questionnaireID))
        PopulateProperties(properties)
        'todo: meassure the GC Bytes collected after the method ends to evaluate the change of data access method in the DA layer.

    End Sub



    ''' <summary>
    ''' Gets all the Questionnaires of the specified Questionnaire Set.
    ''' </summary>
    ''' <param name="questionnaireSetID">The unique identifier of the Questionnaire Set to which the Questionnaires belongs to.</param>
    ''' <returns>A <c>List(Of Questionnaire)</c> with all the Questionnaires of the Questionnaire Set.</returns>

    Public Shared Function GetAll(ByVal questionnaireSetID As Integer) As List(Of Questionnaire)

        Dim list As New List(Of Questionnaire)
        Dim records As List(Of Object()) = DA.Questionnaire.GetAll(questionnaireSetID)

        For idx As Integer = 0 To records.Count - 1
            list.Add(New Questionnaire(records(idx)))
        Next

        Return list

    End Function



    ''' <summary>
    ''' Gets all the Questionnaires of the specified Questionnaire Set that fulfills their Precondition.
    ''' </summary>
    ''' <param name="questionnaireSetID">The unique identifier of the Questionnaire Set to which the Questionnaires belongs to.</param>
    ''' <returns>A <c>List(Of Questionnaire)</c> with all the Questionnaires of the Questionnaire Set that fulfills their Precondition.</returns>

    Public Shared Function GetAllValid(ByVal questionnaireSetID As Integer) As List(Of Questionnaire)

        Dim validQuestionnaires As New List(Of Questionnaire)

        For Each questionnaire As Questionnaire In GetAll(questionnaireSetID)
            If questionnaire.EvaluatePreCondition Then validQuestionnaires.Add(questionnaire)
        Next

        Return validQuestionnaires

    End Function



    Public Function GetRecord() As DataRecord

        ' If a Data Record for this Subject in the Questionnaire table exists, get it, else return Nothing.
        If DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, _currentInstanceID) Then
            Return New DataRecord(_dataTableName, CurrentSubject.SubjectID, _currentInstanceID)
        Else
            Return Nothing
        End If

    End Function



    Public Function CreateRecord() As DataRecord

        ' If a Data Record for this Subject in the Questionnaire table exists, get it, else create it and execute the OnNewRecord procedure
        If DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, _currentInstanceID) Then
            Return New DataRecord(_dataTableName, CurrentSubject.SubjectID, _currentInstanceID)
        Else
            Dim initialValues As New Dictionary(Of String, Object)
            initialValues.Add("SubjectCompletedRecord", False)
            CreateRecord = DataRecord.Create(_dataTableName, CurrentSubject.SubjectID, _currentInstanceID, initialValues)
            ExecuteOnNewRecordProcedure()
        End If

    End Function


    Public Function EvaluatePreCondition() As Boolean

        Dim tempCurrentQuestionnaire As Questionnaire = CurrentQuestionnaire
        CurrentQuestionnaire = Me

        If _preCondition Then
            EvaluatePreCondition = CBool(Evaluator.EvaluateFunction(Context.PreconditionsDotNETClassName, String.Format("Precondition_{0}_{1}", Context.CurrentQuestionnaireSet.ShortName, Me.ShortName), TypeCode.Boolean, Nothing))
        Else
            EvaluatePreCondition = True
        End If

        CurrentQuestionnaire = tempCurrentQuestionnaire

    End Function



    Public Sub CreateInstance()

        If Not _multipleInstances Then Throw New ApplicationException(String.Format("The Questionnaire [{0}] does not support multiple instances.", _questionnaireID))

        If Instances.Count = 0 Then
            _currentInstanceID = 1
        Else
            _currentInstanceID = Instances(Instances.Count - 1).InstanceID + CByte(1)
        End If

        Me.CreateRecord()

    End Sub

#End Region

#Region " Private Methods "

    Private Sub ExecuteOnNewRecordProcedure()
        If _onNewRecord Then
            Dim methodName As String = String.Format("OnNewRecord_{0}_{1}", Context.CurrentQuestionnaireSet.ShortName, Me.ShortName)
            Procedure.Execute(Context.ConstructorsDotNETClassName, methodName, Nothing)
        End If
    End Sub



    Private Sub New(ByVal properties() As Object)
        PopulateProperties(properties)
    End Sub



    ''' <summary>
    ''' Sets the values of the properties.
    ''' </summary>
    ''' <param name="properties">The array of type <c>Object</c> with the values to populate the properties.</param>

    Private Sub PopulateProperties(ByVal properties() As Object)

        _questionnaireID = CInt(properties(0))
        _questionnaireSetID = CInt(properties(1))
        _order = CInt(properties(2))
        _multipleInstances = CBool(properties(3))
        _shortName = CStr(properties(4))
        _name = CStr(properties(5))
        _preCondition = CBool(properties(6))
        _onNewRecord = CBool(properties(9))

        If TypeOf properties(7) Is DBNull Then _instanceSAIDField = Nothing Else _instanceSAIDField = CStr(properties(7))
        If TypeOf properties(8) Is DBNull Then _instanceSecondaryIDField = Nothing Else _instanceSecondaryIDField = CStr(properties(8))

        _currentInstanceID = 1

        _dataTableName = String.Format("D_{0}_{1}", CurrentQuestionnaireSet.QuestionnaireSetID, _questionnaireID)

    End Sub

#End Region

End Class