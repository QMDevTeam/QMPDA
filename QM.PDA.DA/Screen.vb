

''' <summary>
''' Provides data access to the Screen table in the configuration database.
''' </summary>

Public Class Screen

    ''' <summary>
    ''' Gets a single record with the information of the Screen object specified.
    ''' </summary>
    ''' <param name="screenID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal screenID As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Screen WHERE ScreenID = @ScreenID", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@ScreenID", SqlDbType.Int).Value = screenID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function

End Class