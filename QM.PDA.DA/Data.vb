Imports System.Text


''' <summary>
''' Provides data access services for the Data database.
''' </summary>

Public Class Data

    Public Enum SortDirection
        ASC
        DESC
    End Enum



    ''' <summary>
    ''' Creates a record in the specified data table.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="subjectID">The unique identifier of the Subject to which this record belongs to.</param>
    ''' <param name="subjectQuestionnaireInstanceID">The Questionnaire Instance identifier.</param>
    ''' <param name="initialValues">The initial values for the NOT NULL columns.</param>
    ''' <param name="user">The name of the User creating this record.</param>
    ''' <param name="version">The version of the Study to which this record belongs to.</param>
    ''' <param name="PDASerialNumber">The Serial Number of the PDA that is being used.</param>
    ''' <param name="PDAName">The Name of the PDA that is being used.</param>

    Public Shared Sub CreateRecord(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte), ByVal initialValues As Dictionary(Of String, Object), ByVal user As String, ByVal version As String, ByVal PDASerialNumber As String, ByVal PDAName As String)

        ' Add ForDeletion = 0 to the initial values.
        initialValues.Add("ForDeletion", 0)

        ' Build the initial values segments for the INSERT command
        Dim columnNames As New StringBuilder("")
        Dim parameterNames As New StringBuilder("")

        If initialValues.Count > 0 Then
            For Each key As String In initialValues.Keys
                columnNames.Append(", " & key)
                parameterNames.Append(", @" & key)
            Next
        End If

        ' If a Questionnaire Instance identifier was specified, add it.
        Dim subjectQuestionnaireInstanceIDParameter As SqlCeParameter = Nothing
        If subjectQuestionnaireInstanceID.HasValue Then
            columnNames.Append(", SubjectQuestionnaireInstanceID")
            parameterNames.Append(", @SubjectQuestionnaireInstanceID")
            subjectQuestionnaireInstanceIDParameter = New SqlCeParameter("@SubjectQuestionnaireInstanceID", SqlDbType.TinyInt)
            subjectQuestionnaireInstanceIDParameter.Value = subjectQuestionnaireInstanceID.Value
        End If


        Dim command As New SqlCeCommand("", Common.DataDBConnection)
        command.CommandText = String.Format("INSERT INTO [{0}] ( SubjectID, PDAInsertUser, PDAInsertDate, PDAInsertVersion, PDAInsertSN, PDAInsertPDAName{1})", dataTableName, columnNames) & vbCrLf
        command.CommandText &= String.Format("VALUES ( @SubjectID, @PDAInsertUser, @PDAInsertDate, @PDAInsertVersion, @PDAInsertSN, @PDAInsertPDAName{0})", parameterNames)

        command.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
        command.Parameters.Add("@PDAInsertUser", SqlDbType.NVarChar).Value = user
        command.Parameters.Add("@PDAInsertDate", SqlDbType.DateTime).Value = Now
        command.Parameters.Add("@PDAInsertVersion", SqlDbType.NVarChar).Value = version
        command.Parameters.Add("@PDAInsertSN", SqlDbType.NVarChar).Value = PDASerialNumber
        command.Parameters.Add("@PDAInsertPDAName", SqlDbType.NVarChar).Value = PDAName
        If subjectQuestionnaireInstanceIDParameter IsNot Nothing Then command.Parameters.Add(subjectQuestionnaireInstanceIDParameter)


        ' Add the initial values
        For Each key As String In initialValues.Keys
            command.Parameters.Add("@" & key, initialValues(key))
        Next


        ' Execute the command
        command.ExecuteNonQuery()
        command.Dispose()

    End Sub



    ''' <summary>
    ''' Updates a record in the specified data table.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="subjectID">The unique identifier of the Subject to which this record belongs to.</param>
    ''' <param name="subjectQuestionnaireInstanceID">The Questionnaire Instance identifier.</param>
    ''' <param name="fieldName">The name of the field to update.</param>
    ''' <param name="fieldValue">The value of the field to update.</param>
    ''' <param name="user">The name of the User updating this record.</param>
    ''' <param name="version">The version of the Study to which this record belongs to.</param>
    ''' <param name="PDASerialNumber">The Serial Number of the PDA that is being used.</param>
    ''' <param name="PDAName">The Name of the PDA that is being used.</param>

    Public Shared Sub UpdateRecord(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte), ByVal fieldName As String, ByVal fieldValue As Object, ByVal user As String, ByVal version As String, ByVal PDASerialNumber As String, ByVal PDAName As String)

        ' If a Questionnaire Instance identifier was specified, add it.
        Dim subjectQuestionnaireInstanceIDParameter As SqlCeParameter = Nothing
        Dim questionnaireInstanceFilter As String = ""
        If subjectQuestionnaireInstanceID.HasValue Then
            questionnaireInstanceFilter = "AND SubjectQuestionnaireInstanceID = @SubjectQuestionnaireInstanceID"
            subjectQuestionnaireInstanceIDParameter = New SqlCeParameter("@SubjectQuestionnaireInstanceID", SqlDbType.TinyInt)
            subjectQuestionnaireInstanceIDParameter.Value = subjectQuestionnaireInstanceID.Value
        End If


        Dim command As New SqlCeCommand("", Common.DataDBConnection)
        command.CommandText = String.Format("UPDATE [{0}] SET PDALastModifUser = @PDALastModifUser, PDALastModifDate = @PDALastModifDate, PDALastModifVersion = @PDALastModifVersion, PDALastModifSN = @PDALastModifSN, PDALastModifPDAName = @PDALastModifPDAName, ", dataTableName)
        command.CommandText &= String.Format("{0} = @{0} WHERE SubjectID = @SubjectID {1}", fieldName, questionnaireInstanceFilter)

        Dim parameterName As String = String.Format("@{0}", fieldName)
        command.Parameters.Add(parameterName, IIf(fieldValue Is Nothing, DBNull.Value, fieldValue))

        command.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
        command.Parameters.Add("@PDALastModifUser", SqlDbType.NVarChar).Value = user
        command.Parameters.Add("@PDALastModifDate", SqlDbType.DateTime).Value = Now
        command.Parameters.Add("@PDALastModifVersion", SqlDbType.NVarChar).Value = version
        command.Parameters.Add("@PDALastModifSN", SqlDbType.NVarChar).Value = PDASerialNumber
        command.Parameters.Add("@PDALastModifPDAName", SqlDbType.NVarChar).Value = PDAName
        If subjectQuestionnaireInstanceIDParameter IsNot Nothing Then command.Parameters.Add(subjectQuestionnaireInstanceIDParameter)


        ' Execute the command
        command.ExecuteNonQuery()
        command.Dispose()

        ' If the table wasn't a subjet table 'S_#', update the subject last modif metadata.
        If dataTableName.StartsWith("D_") Then

            command = New SqlCeCommand("", Common.DataDBConnection)
            command.CommandText = String.Format("UPDATE [S_{0}] SET PDALastModifUser = @PDALastModifUser, PDALastModifDate = @PDALastModifDate, PDALastModifVersion = @PDALastModifVersion, PDALastModifSN = @PDALastModifSN, PDALastModifPDAName = @PDALastModifPDAName WHERE SubjectID = @SubjectID", dataTableName(2))
            command.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
            command.Parameters.Add("@PDALastModifUser", SqlDbType.NVarChar).Value = user
            command.Parameters.Add("@PDALastModifDate", SqlDbType.DateTime).Value = Now
            command.Parameters.Add("@PDALastModifVersion", SqlDbType.NVarChar).Value = version
            command.Parameters.Add("@PDALastModifSN", SqlDbType.NVarChar).Value = PDASerialNumber
            command.Parameters.Add("@PDALastModifPDAName", SqlDbType.NVarChar).Value = PDAName
           
            ' Execute the command
            command.ExecuteNonQuery()
            command.Dispose()

        End If

    End Sub



    ''' <summary>
    ''' Gets a record from the specified data table.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="subjectID">The unique identifier of the Subject to which the record belongs.</param>
    ''' <param name="subjectQuestionnaireInstanceID">The Questionnaire Instance identifier.</param>
    ''' <returns>A <c>DataRow</c> with the record if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetRecord(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte)) As DataRow

        ' If a Questionnaire Instance identifier was specified, add it.
        Dim subjectQuestionnaireInstanceIDParameter As SqlCeParameter = Nothing
        Dim questionnaireInstanceFilter As String = ""
        If subjectQuestionnaireInstanceID.HasValue Then
            questionnaireInstanceFilter = "AND SubjectQuestionnaireInstanceID = @SubjectQuestionnaireInstanceID"
            subjectQuestionnaireInstanceIDParameter = New SqlCeParameter("@SubjectQuestionnaireInstanceID", SqlDbType.TinyInt)
            subjectQuestionnaireInstanceIDParameter.Value = subjectQuestionnaireInstanceID.Value
        End If


        Dim dataAdapter As New SqlCeDataAdapter(String.Format("SELECT * FROM [{0}] WHERE SubjectID = @SubjectID {1}", dataTableName, questionnaireInstanceFilter), Common.DataDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
        If subjectQuestionnaireInstanceIDParameter IsNot Nothing Then dataAdapter.SelectCommand.Parameters.Add(subjectQuestionnaireInstanceIDParameter)

        Dim dataTable As New DataTable(dataTableName)
        dataAdapter.Fill(dataTable)
        dataAdapter.Dispose()

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Gets a record from the specified data table.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="SASubjectID">The Study Assigned ID of the Subject that owns the record.</param>
    ''' <returns>A <c>DataRow</c> with the record if it was found, <c>Nothing</c> otherwise.</returns>
    ''' <remarks>This overload uses the Study Assigned Subject ID instead of the unique Subject ID.</remarks>

    Public Shared Function GetRecord(ByVal dataTableName As String, ByVal SASubjectID As String) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter(String.Format("SELECT * FROM [{0}] WHERE SASubjectID = @SASubjectID", dataTableName), Common.DataDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@SASubjectID", SqlDbType.NVarChar).Value = SASubjectID

        Dim dataTable As New DataTable(dataTableName)
        dataAdapter.Fill(dataTable)
        dataAdapter.Dispose()

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Gets a set of records from the specified data table.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="fields">The list of fields to select from the data table.</param>
    ''' <param name="filter">Filter expresion in SQL syntax.</param>
    ''' <param name="sortFields">The list of fields on which to sort the set of records.</param>
    ''' <param name="sortDirection">The direction of the sorting.</param>
    ''' <returns>A <c>DataTable</c> with the records.</returns>

    Public Shared Function GetRecords(ByVal dataTableName As String, ByVal fields As String(), ByVal filter As String, ByVal sortFields As String(), ByVal sortDirection As SortDirection) As DataTable

        Dim fieldsClause As String = "*"
        Dim filterClause As String = ""
        Dim orderClause As String = ""

        If fields.Length > 0 Then fieldsClause = "[" & String.Join("],[", fields) & "]"
        If Not String.IsNullOrEmpty(filter) Then filterClause = "WHERE " & filter
        If sortFields.Length > 0 Then orderClause = "ORDER BY [" & String.Join("],[", sortFields) & "] " & sortDirection.ToString()


        Dim dataAdapter As New SqlCeDataAdapter(String.Format("SELECT {0} FROM [{1}] {2} {3}", fieldsClause, dataTableName, filterClause, orderClause), Common.DataDBConnection)
        Dim dataTable As New DataTable(dataTableName)
        dataAdapter.Fill(dataTable)
        dataAdapter.Dispose()

        Return dataTable

    End Function



    ''' <summary>
    ''' Checks if a record for the specified Subject exists.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="subjectID">The unique identifier of the Subject to which the record belongs.</param>
    ''' <param name="subjectQuestionnaireInstanceID">The Questionnaire Instance identifier.</param>
    ''' <returns><c>True</c> if the a record exists, <c>False</c> otherwise.</returns>

    Public Shared Function RecordExists(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte)) As Boolean

        ' If a Questionnaire Instance identifier was specified, add it.
        Dim subjectQuestionnaireInstanceIDParameter As SqlCeParameter = Nothing
        Dim questionnaireInstanceFilter As String = ""
        If subjectQuestionnaireInstanceID.HasValue Then
            questionnaireInstanceFilter = "AND SubjectQuestionnaireInstanceID = @SubjectQuestionnaireInstanceID"
            subjectQuestionnaireInstanceIDParameter = New SqlCeParameter("@SubjectQuestionnaireInstanceID", SqlDbType.TinyInt)
            subjectQuestionnaireInstanceIDParameter.Value = subjectQuestionnaireInstanceID.Value
        End If


        Dim command As New SqlCeCommand(String.Format("SELECT 1 FROM [{0}] WHERE SubjectID = @SubjectID {1}", dataTableName, questionnaireInstanceFilter), Common.DataDBConnection)
        command.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
        If subjectQuestionnaireInstanceIDParameter IsNot Nothing Then command.Parameters.Add(subjectQuestionnaireInstanceIDParameter)

        RecordExists = command.ExecuteScalar() IsNot Nothing
        command.Dispose()

    End Function



    ''' <summary>
    ''' Checks if a record for the specified Subject exists.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="SASubjectID">The Study Assigned ID of the Subject that owns the record.</param>
    ''' <returns><c>True</c> if the a record exists, <c>False</c> otherwise.</returns>
    ''' <remarks>This overload uses the Study Assigned Subject ID instead of the unique Subject ID.</remarks>

    Public Shared Function RecordExists(ByVal dataTableName As String, ByVal SASubjectID As String) As Boolean

        Dim command As New SqlCeCommand(String.Format("SELECT 1 FROM [{0}] WHERE SASubjectID = @SASubjectID", dataTableName), Common.DataDBConnection)
        command.Parameters.Add("@SASubjectID", SqlDbType.NVarChar).Value = SASubjectID

        RecordExists = command.ExecuteScalar() IsNot Nothing
        command.Dispose()

    End Function



    ''' <summary>
    ''' Deletes the specified record.
    ''' </summary>
    ''' <param name="dataTableName">The name of the data table.</param>
    ''' <param name="subjectID">The unique identifier of the Subject to which the record belongs.</param>
    ''' <param name="subjectQuestionnaireInstanceID">The Questionnaire Instance identifier.</param>

    Public Shared Sub DeleteRecord(ByVal dataTableName As String, ByVal subjectID As Guid, ByVal subjectQuestionnaireInstanceID As Nullable(Of Byte))

        ' If a Questionnaire Instance identifier was specified, add it.
        Dim subjectQuestionnaireInstanceIDParameter As SqlCeParameter = Nothing
        Dim questionnaireInstanceFilter As String = ""
        If subjectQuestionnaireInstanceID.HasValue Then
            questionnaireInstanceFilter = "AND SubjectQuestionnaireInstanceID = @SubjectQuestionnaireInstanceID"
            subjectQuestionnaireInstanceIDParameter = New SqlCeParameter("@SubjectQuestionnaireInstanceID", SqlDbType.TinyInt)
            subjectQuestionnaireInstanceIDParameter.Value = subjectQuestionnaireInstanceID.Value
        End If


        Dim command As New SqlCeCommand(String.Format("DELETE [{0}] WHERE SubjectID = @SubjectID {1}", dataTableName, questionnaireInstanceFilter), Common.DataDBConnection)
        command.Parameters.Add("@SubjectID", SqlDbType.UniqueIdentifier).Value = subjectID
        If subjectQuestionnaireInstanceIDParameter IsNot Nothing Then command.Parameters.Add(subjectQuestionnaireInstanceIDParameter)


        ' Execute the command
        command.ExecuteNonQuery()
        command.Dispose()

    End Sub



    ''' <summary>
    ''' Executes a SQL Command that returns a table.
    ''' </summary>
    ''' <param name="commandText">The SQL Command to execute.</param>
    ''' <returns>A DataTable with the selected Rows.</returns>

    Public Shared Function ExecuteQuery(ByVal commandText As String) As DataTable

        ' Execute the command
        Dim dataAdapter As New SqlCeDataAdapter(commandText, Common.DataDBConnection)
        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function



    ''' <summary>
    ''' Executes a SQL Command that does not return a table.
    ''' </summary>
    ''' <param name="commandText">The SQL Command to execute.</param>
    ''' <returns>The number of rows affected by the SQL Command.</returns>

    Public Shared Function ExecuteNonQuery(ByVal commandText As String) As Integer

        ' Execute the command
        Dim command As New SqlCeCommand(commandText, Common.DataDBConnection)
        ExecuteNonQuery = command.ExecuteNonQuery
        command.Dispose()

    End Function



    ''' <summary>
    ''' Executes a SQL Query and returns the value in the first column of the first row
    ''' of the resulting table.
    ''' </summary>
    ''' <param name="commandText">The SQL Command to execute.</param>
    ''' <returns>The value in the first column of the first row of the resulting table.</returns>

    Public Shared Function ExecuteScalar(ByVal commandText As String) As Object

        ' Execute the command
        Dim command As New SqlCeCommand(commandText, Common.DataDBConnection)
        ExecuteScalar = command.ExecuteScalar
        command.Dispose()

    End Function

End Class
