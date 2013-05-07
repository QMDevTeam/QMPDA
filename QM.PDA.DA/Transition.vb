

''' <summary>
''' Provides data access to the Transition table in the configuration database.
''' </summary>

Public Class Transition

    ''' <summary>
    ''' Gets a single record with the information of the Transition object specified.
    ''' </summary>
    ''' <param name="screenID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetAll(ByVal screenID As Integer) As DataTable

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Transition WHERE ScreenID = @ScreenID ORDER BY [Order]", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@ScreenID", SqlDbType.Int).Value = screenID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function

End Class