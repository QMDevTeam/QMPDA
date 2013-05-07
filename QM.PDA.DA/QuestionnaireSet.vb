

''' <summary>
''' Provides data access to the QuestionnaireSet table in the configuration database.
''' </summary>

Public Class QuestionnaireSet

    ''' <summary>
    ''' Gets all the records with the information of the Questionnaire Set objets that belongs to
    ''' the Study.
    ''' </summary>
    ''' <returns>A <c>SqlCeResultSet</c> with all the records found.</returns>

    Public Shared Function GetAll() As List(Of Object())

        Dim command As New SqlCeCommand("SELECT * FROM QuestionnaireSet ORDER BY [Order]", Common.ConfigDBConnection)

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