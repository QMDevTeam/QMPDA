

''' <summary>
''' Provides data access to the Questionnaire table in the configuration database.
''' </summary>

Public Class Questionnaire

    ''' <summary>
    ''' Gets a single record with the information of the Questionnaire object specified.
    ''' </summary>
    ''' <param name="questionnaireID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>SqlCeResultSet</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal questionnaireID As Integer) As Object()

        Dim command As New SqlCeCommand("Questionnaire", Common.ConfigDBConnection)
        command.CommandType = CommandType.TableDirect
        command.IndexName = "PK_Questionnaire"
        command.SetRange(DbRangeOptions.Match, New Object() {questionnaireID}, Nothing)

        Dim resultSet As SqlCeResultSet = command.ExecuteResultSet(ResultSetOptions.None)
        Dim record(resultSet.FieldCount - 1) As Object
        If resultSet.Read Then resultSet.GetValues(record)

        resultSet.Close()
        resultSet.Dispose()
        command.Dispose()

        Return record

    End Function



    ''' <summary>
    ''' Gets all the records with the information of the Questionnaire objets that belongs to a
    ''' specified Questionnaire Set.
    ''' </summary>
    ''' <param name="questionnaireSetID">The unique identifier of the Questionnaire Set.</param>
    ''' <returns>A <c>SqlCeResultSet</c> with all the records found.</returns>

    Public Shared Function GetAll(ByVal questionnaireSetID As Integer) As List(Of Object())

        Dim command As New SqlCeCommand("SELECT * FROM Questionnaire WHERE QuestionnaireSetID = @QuestionnaireSetID ORDER BY [Order]", Common.ConfigDBConnection)
        command.Parameters.Add("@QuestionnaireSetID", SqlDbType.Int).Value = questionnaireSetID

        Dim resultSet As SqlCeResultSet = command.ExecuteResultSet(ResultSetOptions.None)
        Dim records As New List(Of Object())


        While resultSet.Read()
            Dim record(resultSet.FieldCount - 1) As Object
            resultSet.GetValues(record)
            records.Add(record)
        End While


        resultSet.Dispose()
        command.Dispose()

        Return records

    End Function

End Class