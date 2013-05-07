

''' <summary>
''' Represents the Subject of a Study.
''' </summary>

Public Class Subject

#Region " Properties "

    Public Enum SubjectCondition
        WithSASubjectID
        WithoutSASubjectID
    End Enum



    Private _subjectID As Guid
    Private _dataRecord As DataRecord

    Private _site As Site
    Private _questionnaireSet As QuestionnaireSet


    Public ReadOnly Property SubjectID() As Guid
        Get
            Return _subjectID
        End Get
    End Property


    Public ReadOnly Property SASubjectID() As String
        Get
            Return CStr(_dataRecord("SASubjectID"))
        End Get
    End Property


    Public ReadOnly Property SiteCode() As String
        Get
            Return _site.Code
        End Get
    End Property


    Public ReadOnly Property SecondaryID() As String
        Get
            If String.IsNullOrEmpty(_questionnaireSet.SubjectSecondaryIDField) Then Return Nothing
            Return CStr(_dataRecord(_questionnaireSet.SubjectSecondaryIDField))
        End Get
    End Property


    Public ReadOnly Property AlternativeSearchField() As String
        Get
            If String.IsNullOrEmpty(_questionnaireSet.SubjectAlternativeSearchField) Then Return Nothing
            Return CStr(_dataRecord(_questionnaireSet.SubjectAlternativeSearchField))
        End Get
    End Property


    Default Public Property Item(ByVal Name As String) As Object
        Get
            Return _dataRecord(Name)
        End Get
        Set(ByVal value As Object)
            _dataRecord(Name) = value
        End Set
    End Property


    Public ReadOnly Property QuestionnaireSet() As QuestionnaireSet
        Get
            Return _questionnaireSet
        End Get
    End Property


    Public ReadOnly Property DataRecord() As DataRecord
        Get
            Return _dataRecord
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Shared Operator =(ByVal operand1 As Subject, ByVal operand2 As Subject) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.SubjectID = operand2.SubjectID
    End Operator



    Public Shared Operator <>(ByVal operand1 As Subject, ByVal operand2 As Subject) As Boolean
        If operand1 Is Nothing OrElse operand2 Is Nothing Then Return False
        Return operand1.SubjectID <> operand2.SubjectID
    End Operator

#End Region

#Region " Friend Methods "

    Public Sub New(ByVal subjectID As Guid, ByVal questionnaireSet As QuestionnaireSet)

        Dim dataTableName As String = "S_" & questionnaireSet.QuestionnaireSetID
        _dataRecord = New DataRecord(dataTableName, subjectID, Nothing)

        _subjectID = subjectID
        _questionnaireSet = questionnaireSet
        _site = New Site(CInt(_dataRecord("SubjectSiteID")))

    End Sub



    Public Sub New(ByVal SASubjectID As String, ByVal questionnaireSet As QuestionnaireSet)

        Dim dataTableName As String = "S_" & questionnaireSet.QuestionnaireSetID
        _dataRecord = New DataRecord(dataTableName, SASubjectID)

        _subjectID = CType(_dataRecord("SubjectID"), Guid)
        _questionnaireSet = questionnaireSet
        _site = New Site(CInt(_dataRecord("SubjectSiteID")))

    End Sub



    Friend Shared Function Create(ByVal questionnaireSet As QuestionnaireSet, ByVal site As Site) As Subject

        Dim subjectID As Guid = Guid.NewGuid
        Dim dataTableName As String = "S_" & questionnaireSet.QuestionnaireSetID
        Dim initialValues As New Dictionary(Of String, Object)

        initialValues.Add("SubjectSiteID", site.SiteID)
        initialValues.Add("SubjectCompletedStudy", False)

        DataRecord.Create(dataTableName, subjectID, Nothing, initialValues)
        Return New Subject(subjectID, questionnaireSet)

    End Function



    Friend Shared Function Exists(ByVal SASubjectID As String, ByVal questionnaireSet As QuestionnaireSet) As Boolean
        Dim dataTableName As String = "S_" & questionnaireSet.QuestionnaireSetID
        Return DA.Data.RecordExists(dataTableName, SASubjectID)
    End Function



    Friend Shared Function GetAll(ByVal subjectCondition As SubjectCondition, ByVal questionnaireSet As QuestionnaireSet, ByVal site As Site) As DataTable

        Dim dataTableName As String = "S_" & questionnaireSet.QuestionnaireSetID
        Dim fields As String() = {"SubjectID", "SASubjectID", questionnaireSet.SubjectAlternativeSearchField}
        Dim filter As String = Nothing
        Dim sortFields(0) As String
        Dim sortDirection As DA.Data.SortDirection
        Dim list As New List(Of Subject)


        Select Case subjectCondition

            Case Subject.SubjectCondition.WithSASubjectID
                filter = "SASubjectID IS NOT NULL"
                sortFields(0) = "SASubjectID"
                sortDirection = DA.Data.SortDirection.DESC

            Case Subject.SubjectCondition.WithoutSASubjectID
                filter = "SASubjectID IS NULL"
                sortFields(0) = questionnaireSet.SubjectAlternativeSearchField
                sortDirection = DA.Data.SortDirection.ASC

        End Select

        If site IsNot Nothing Then filter &= " AND SubjectSiteID = " & site.SiteID

        Return DA.Data.GetRecords(dataTableName, fields, filter, sortFields, sortDirection)

    End Function

#End Region

End Class