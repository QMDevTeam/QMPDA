

''' <summary>
''' Provides data access to the ScreenTemplate table in the configuration database.
''' </summary>

Public Class ScreenTemplate

    ''' <summary>
    ''' Gets a single record with the information of the ScreenTemplate object specified.
    ''' </summary>
    ''' <param name="screenTemplateID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal screenTemplateID As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM ScreenTemplate WHERE ScreenTemplateID = @ScreenTemplateID", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@ScreenTemplateID", SqlDbType.Int).Value = screenTemplateID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function

End Class