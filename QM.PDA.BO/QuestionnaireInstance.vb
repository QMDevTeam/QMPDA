Imports QM.PDA.BO.Context


''' <summary>
''' Represents a Questionnaire Instance.
''' </summary>

Public Class QuestionnaireInstance

#Region " Properties "

    Private _questionnaire As Questionnaire
    Private _instanceID As Byte
    Private _instanceSAID As String
    Private _instanceSecondaryID As String



    Public ReadOnly Property InstanceID() As Byte
        Get
            Return _instanceID
        End Get
    End Property


    Public ReadOnly Property InstanceSAID() As String
        Get
            Return _instanceSAID
        End Get
    End Property


    Public ReadOnly Property InstanceSecondaryID() As String
        Get
            Return _instanceSecondaryID
        End Get
    End Property


    Public ReadOnly Property IsComplete() As Boolean
        Get
            If CurrentSubject Is Nothing Then Return False

            Dim tempCurrentQuestionnaireInstanceID As Byte = CurrentQuestionnaire.CurrentInstanceID
            CurrentQuestionnaire.CurrentInstanceID = _instanceID

            Dim result As Boolean = True
            For Each section As Section In section.GetAllValid(_questionnaire.QuestionnaireID)
                If Not section.IsComplete Then : result = False : Exit For : End If
            Next

            CurrentQuestionnaire.CurrentInstanceID = tempCurrentQuestionnaireInstanceID

            Return result

        End Get
    End Property

#End Region

#Region " Friend Methods "


    ''' <summary>
    ''' Gets all the Instances of the specified Questionnaire.
    ''' </summary>
    ''' <param name="questionnaire">The owner of the instances.</param>
    ''' <param name="questionnareDataTableName">The name of the data table for the Questionnaire.</param>
    ''' <returns>A <c>List(Of QuestionnaireInstance)</c> with all the Instances of the Questionnaire.</returns>
    ''' <remarks>The resulting list might be empty but will never be <c>Null</c>.</remarks>

    Friend Shared Function GetAll(ByVal questionnaire As Questionnaire, ByVal questionnareDataTableName As String) As List(Of QuestionnaireInstance)

        Dim list As New List(Of QuestionnaireInstance)

        For Each row As DataRow In DA.Data.GetRecords(questionnareDataTableName, New String() {"SubjectQuestionnaireInstanceID", questionnaire.InstanceSAIDField, questionnaire.InstanceSecondaryIDField}, String.Format("SubjectID = '{0}'", CurrentSubject.SubjectID), New String() {"SubjectQuestionnaireInstanceID"}, DA.Data.SortDirection.ASC).Rows
            list.Add(New QuestionnaireInstance(questionnaire, row))
        Next

        Return list

    End Function

#End Region

#Region " Private Methods "

    Private Sub New(ByVal questionnaire As Questionnaire, ByVal row As DataRow)
        PopulateProperties(questionnaire, row)
    End Sub



    ''' <summary>
    ''' Sets the values for the properties of this object.
    ''' </summary>
    ''' <param name="questionnaire">The owner of this object.</param>
    ''' <param name="row">A <c>DataRow</c> with the object properties.</param>

    Private Sub PopulateProperties(ByVal questionnaire As Questionnaire, ByVal row As DataRow)

        _questionnaire = questionnaire
        _instanceID = CByte(row(0))

        If TypeOf row(1) Is DBNull Then _instanceSAID = Nothing Else _instanceSAID = CStr(row(1))
        If TypeOf row(2) Is DBNull Then _instanceSecondaryID = Nothing Else _instanceSecondaryID = CStr(row(2))

    End Sub

#End Region

End Class