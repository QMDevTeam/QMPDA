

''' <summary>
''' Provides data access to the Variable table in the configuration database.
''' </summary>

Public Class Variable

    ''' <summary>
    ''' Gets a single record with the information of the Variable object specified.
    ''' </summary>
    ''' <param name="variableName">The name of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal variableName As String) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Variable WHERE VariableName = @VariableName", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@VariableName", SqlDbType.NVarChar).Value = variableName

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    Public Shared Function Exists(ByVal variableName As String) As Boolean

        Dim command As New SqlCeCommand("SELECT 1 FROM Variable WHERE VariableName = @VariableName", Common.ConfigDBConnection)
        command.Parameters.Add("@VariableName", SqlDbType.NVarChar).Value = variableName

        Return CBool(command.ExecuteScalar())

    End Function

End Class