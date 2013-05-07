

''' <summary>
''' Provides data access to the Section table in the configuration database.
''' </summary>

Public Class Section

    ''' <summary>
    ''' Gets a single record with the information of the Section object specified.
    ''' </summary>
    ''' <param name="sectionID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal sectionID As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Section WHERE SectionID = @SectionID", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@SectionID", SqlDbType.Int).Value = sectionID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Gets all the records with the information of the Section objets that belongs to a
    ''' specified Questionnaire.
    ''' </summary>
    ''' <param name="questionnaireID">The unique identifier of the Questionnaire.</param>
    ''' <returns>A <c>DataTable</c> with all the records found.</returns>

    Public Shared Function GetAll(ByVal questionnaireID As Integer) As DataTable

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Section WHERE QuestionnaireID = @QuestionnaireID ORDER BY [Order]", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@QuestionnaireID", SqlDbType.Int).Value = questionnaireID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function

End Class