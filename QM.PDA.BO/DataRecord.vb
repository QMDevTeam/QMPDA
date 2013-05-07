Imports QM.PDA.BO.Context


Public Class DataRecord

#Region " Properties "

    Private _subjectID As Guid
    Private _subjectQuestionnaireInstanceID As Nullable(Of Byte)
    Private _dataTableName As String
    Private _values As New Dictionary(Of String, Object)
    Private _ghostRecord As Boolean



    Public ReadOnly Property SubjectID() As Guid
        Get
            Return _subjectID
        End Get
    End Property


    Public ReadOnly Property SubjectQuestionnaireInstanceID() As Nullable(Of Byte)
        Get
            Return _subjectQuestionnaireInstanceID
        End Get
    End Property


    Default Public Property Item(ByVal Name As String) As Object
        Set(ByVal value As Object)

            ' If the field doesn't exists, throw an exception
            If Not _values.ContainsKey(Name) Then Throw New ApplicationException(String.Format("The field [{0}] does not exists in the data table [{1}]", Name, _dataTableName))


            ' If the variable exists, store the value only if is different from what is already stored
            ' Note: The following 'If' block considers that the value stored in the _values
            ' collection can be Nothing. If value is Nothing it can't be compared using
            ' the Equals method.
            If (_values(Name) Is Nothing AndAlso Not value Is Nothing) OrElse _
               (Not _values(Name) Is Nothing AndAlso Not _values(Name).Equals(value)) Then

                _values(Name) = value
                DA.Data.UpdateRecord(_dataTableName, _subjectID, _subjectQuestionnaireInstanceID, Name, value, CurrentUser.PDAUserName, CurrentStudy.Version, PDASerialNumber, PDAName)
                _ghostRecord = False
            End If

        End Set
        Get
            ' If the field exists, return the value, else throw an exception
            If _values.ContainsKey(Name) Then
                Return _values(Name)
            Else
                Throw New ApplicationException(String.Format("The field [{0}] does not exists in the data table [{1}]", Name, _dataTableName))
            End If
        End Get
    End Property

#End Region

#Region " Public Methods "

    Public Function VariableExists(ByVal variableName As String) As Boolean
        Return _values.ContainsKey(variableName)
    End Function

#End Region

#Region " Friend Methods "

    Friend Sub New(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte))

        Dim row As DataRow = DA.Data.GetRecord(dataTableName, subjectID, subjectQuestionnaireInstanceID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("There isn't a record in the Table [{1}] for the SubjectID [{0}]", dataTableName, subjectID))
        PopulateProperties(row)

        _dataTableName = dataTableName
        _subjectID = subjectID
        _subjectQuestionnaireInstanceID = subjectQuestionnaireInstanceID
        _ghostRecord = TypeOf row("PDALastModifDate") Is DBNull

    End Sub



    Friend Sub New(ByVal dataTableName As String, ByVal SASubjectID As String)

        Dim row As DataRow = DA.Data.GetRecord(dataTableName, SASubjectID)

        If row Is Nothing Then Throw New ApplicationException(String.Format("There isn't a record in the Table [{1}] for the SASubjectID [{0}]", dataTableName, SASubjectID))
        PopulateProperties(row)

        _dataTableName = dataTableName
        _subjectID = CType(Item("SubjectID"), Guid)
        If VariableExists("SubjectQuestionnaireInstanceID") Then _subjectQuestionnaireInstanceID = CByte(Item("SubjectQuestionnaireInstanceID"))
        _ghostRecord = TypeOf row("PDALastModifDate") Is DBNull

    End Sub



    Friend Shared Function Exists(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte)) As Boolean
        Return DA.Data.RecordExists(dataTableName, subjectID, subjectQuestionnaireInstanceID)
    End Function



    Friend Shared Function Create(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte), ByVal initialValues As Dictionary(Of String, Object)) As DataRecord
        DA.Data.CreateRecord(dataTableName, subjectID, subjectQuestionnaireInstanceID, initialValues, CurrentUser.PDAUserName, CurrentStudy.Version, PDASerialNumber, PDAName)
        Return New DataRecord(dataTableName, subjectID, subjectQuestionnaireInstanceID)
    End Function

#End Region

#Region " Protected Methods "

    'Protected Overrides Sub Finalize()
    '    If _ghostRecord Then DA.Data.DeleteRecord(_dataTableName, _subjectID, _subjectQuestionnaireInstanceID)
    'End Sub

#End Region

#Region " Private Methods "

    Private Sub PopulateProperties(ByVal row As DataRow)

        _values.Clear()

        Dim columnName As String
        Dim value As Object
        For idx As Integer = 0 To row.Table.Columns.Count - 1

            columnName = row.Table.Columns(idx).ColumnName
            value = row(idx)

            If TypeOf value Is DBNull Then value = Nothing
            _values.Add(columnName, value)

        Next

    End Sub

#End Region

End Class
