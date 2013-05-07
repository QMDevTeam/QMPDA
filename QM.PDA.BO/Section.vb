Imports QM.PDA.BO.Context


''' <summary>
''' Represents a Section of a Questionnaire.
''' </summary>

Public Class Section

#Region " Properties "

    Private _sectionID As Integer
    Private _questionnaireID As Integer
    Private _order As Integer
    Private _startScreenID As Integer
    Private _exitScreenID As Integer
    Private _modifiable As Boolean
    Private _shortName As String
    Private _name As String
    Private _preCondition As Boolean
    Private _onNewRecord As Boolean


    Private _startScreen As Screen
    Private _exitScreen As Screen
    Private _dataTableName As String
    Private _dataRecord As DataRecord



    Public ReadOnly Property SectionID() As Integer
        Get
            Return _sectionID
        End Get
    End Property


    Public ReadOnly Property QuestionnaireID() As Integer
        Get
            Return _questionnaireID
        End Get
    End Property


    Public ReadOnly Property Order() As Integer
        Get
            Return _order
        End Get
    End Property


    Public ReadOnly Property StartScreenID() As Integer
        Get
            Return _startScreenID
        End Get
    End Property


    Public ReadOnly Property ExitScreenID() As Integer
        Get
            Return _exitScreenID
        End Get
    End Property


    Public ReadOnly Property Modifiable() As Boolean
        Get
            Return _modifiable
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


    Public ReadOnly Property StartScreen() As Screen
        Get
            If _startScreen Is Nothing Then _startScreen = New Screen(_startScreenID)
            Return _startScreen
        End Get
    End Property


    Public ReadOnly Property ExitScreen() As Screen
        Get
            If _exitScreen Is Nothing Then _exitScreen = New Screen(_exitScreenID)
            Return _exitScreen
        End Get
    End Property


    Public ReadOnly Property HasRecord() As Boolean
        Get
            If CurrentSubject Is Nothing Then Return False
            Return DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID)
        End Get
    End Property


    Public Property IsComplete() As Boolean
        Get
            If CurrentSubject Is Nothing Then Return False
            If Not DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID) Then Return False

            Dim sectionRecord As New DataRecord(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID)
            Return CBool(sectionRecord("SubjectCompletedRecord"))
        End Get
        Set(ByVal value As Boolean)
            If CurrentSubject Is Nothing Then Return
            If Not DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID) Then Return

            Dim sectionRecord As New DataRecord(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID)
            sectionRecord("SubjectCompletedRecord") = value
        End Set
    End Property


    Default Public Property Item(ByVal Name As String) As Object
        Get
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> CurrentQuestionnaire.CurrentInstanceID Then _dataRecord = Me.GetRecord
            If _dataRecord IsNot Nothing Then Return _dataRecord(Name)
            Return Nothing
        End Get
        Set(ByVal value As Object)
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> CurrentQuestionnaire.CurrentInstanceID Then _dataRecord = Me.GetRecord
            If _dataRecord IsNot Nothing Then _dataRecord(Name) = value
        End Set
    End Property


    Public ReadOnly Property DataRecord() As DataRecord
        Get
            If _dataRecord Is Nothing Then _dataRecord = Me.GetRecord()
            If _dataRecord Is Nothing OrElse _dataRecord.SubjectQuestionnaireInstanceID.Value <> CurrentQuestionnaire.CurrentInstanceID Then _dataRecord = Me.GetRecord
            Return _dataRecord
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Initializes a new instance of the Section class.
    ''' </summary>
    ''' <param name="sectionID">The unique identifier of the Section to instantiate.</param>

    Public Sub New(ByVal sectionID As Integer)

        Dim row As DataRow = DA.Section.GetSingle(sectionID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("The Section with SectionID[{0}] does not exists", sectionID))
        PopulateProperties(row)

    End Sub



    ''' <summary>
    ''' Gets all the Sections of the specified Questionnaire.
    ''' </summary>
    ''' <param name="questionnaireID">The unique identifier of the Questionnaire.</param>
    ''' <returns>A <c>List(Of Section)</c> with all the Sections of the Questionnaire.</returns>
    ''' <remarks>The resulting list might be empty but will never be <c>Null</c>.</remarks>

    Public Shared Function GetAll(ByVal questionnaireID As Integer) As List(Of Section)

        Dim list As New List(Of Section)

        For Each row As DataRow In DA.Section.GetAll(questionnaireID).Rows
            list.Add(New Section(row))
        Next

        Return list

    End Function



    ''' <summary>
    ''' Gets all the Sections of the specified Questionnaire that fulfills their Precondition.
    ''' </summary>
    ''' <param name="questionnaireID">The unique identifier of the Questionnaire.</param>
    ''' <returns>A <c>List(Of Section)</c> with all the Sections of the Questionnaire that fulfills their Precondition.</returns>

    Public Shared Function GetAllValid(ByVal questionnaireID As Integer) As List(Of Section)

        Dim validSections As New List(Of Section)

        For Each section As Section In GetAll(questionnaireID)
            If section.EvaluatePreCondition Then validSections.Add(section)
        Next

        Return validSections

    End Function



    Public Function GetRecord() As DataRecord

        ' If a Data Record for this Subject in the Section table exists, get it, else return Nothing.
        If DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID) Then
            Return New DataRecord(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID)
        Else
            Return Nothing
        End If

    End Function



    Public Function CreateRecord() As DataRecord

        ' If a Data Record for this Subject in the Section table exists, get it, else create it and execute the OnNewRecord procedure
        If DataRecord.Exists(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID) Then
            Return New DataRecord(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID)
        Else
            Dim initialValues As New Dictionary(Of String, Object)
            initialValues.Add("SubjectCompletedRecord", False)
            CreateRecord = DataRecord.Create(_dataTableName, CurrentSubject.SubjectID, CurrentQuestionnaire.CurrentInstanceID, initialValues)
            ExecuteOnNewRecordProcedure()
        End If

    End Function



    Public Function EvaluatePreCondition() As Boolean

        Dim tempCurrentSection As Section = CurrentSection
        CurrentSection = Me

        If _preCondition Then
            EvaluatePreCondition = CBool(Evaluator.EvaluateFunction(Context.PreconditionsDotNETClassName, String.Format("Precondition_{0}_{1}_{2}", Context.CurrentQuestionnaireSet.ShortName, Context.CurrentQuestionnaire.ShortName, Me.ShortName), TypeCode.Boolean, Nothing))
        Else
            Return True
        End If

        CurrentSection = tempCurrentSection

    End Function

#End Region

#Region " Private Methods "

    Private Sub ExecuteOnNewRecordProcedure()
        If _onNewRecord Then
            Dim methodName As String = String.Format("OnNewRecord_{0}_{1}_{2}", Context.CurrentQuestionnaireSet.ShortName, Context.CurrentQuestionnaire.ShortName, Me.ShortName)
            Procedure.Execute(Context.ConstructorsDotNETClassName, methodName, Nothing)
        End If
    End Sub



    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the values for the properties of this instance of a Section.
    ''' </summary>
    ''' <param name="row">A <c>DataRow</c> with the Section properties.</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _sectionID = CInt(row("SectionID"))
        _questionnaireID = CInt(row("QuestionnaireID"))
        _order = CInt(row("Order"))
        _startScreenID = CInt(row("StartScreenID"))
        _exitScreenID = CInt(row("ExitScreenID"))
        _modifiable = CBool(row("Modifiable"))
        _shortName = CStr(row("ShortName"))
        _name = CStr(row("Name"))
        _preCondition = CBool(row("PreCondition"))
        _onNewRecord = CBool(row("OnNewRecord"))
        _dataTableName = String.Format("D_{0}_{1}_{2}", CurrentQuestionnaireSet.QuestionnaireSetID, _questionnaireID, _sectionID)

    End Sub

#End Region

End Class