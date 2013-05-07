

''' <summary>
''' Provides data access to the Method table in the configuration database.
''' </summary>

Public Class Method

    ''' <summary>
    ''' Gets a single record with the information of the Method object specified.
    ''' </summary>
    ''' <param name="methodName">The name of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal methodName As String) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Method WHERE MethodName = @MethodName", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@MethodName", SqlDbType.NVarChar).Value = methodName

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function

End Class