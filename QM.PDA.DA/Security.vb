

''' <summary>
''' Provides data access to the Security table in the security database.
''' </summary>

Public Class Security

    ''' <summary>
    ''' Gets a single record with the information of the User object specified.
    ''' </summary>
    ''' <param name="PDAUserName">The name of the User.</param>
    ''' <param name="PDAPassword">The password the User provided.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetUser(ByVal PDAUserName As String, ByVal PDAPassword As String) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM PDAUser WHERE PDAUserName = @PDAUserName AND PDAPassword = @PDAPassword", Common.ConfigDBConnection)

        dataAdapter.SelectCommand.Parameters.Add("@PDAUserName", SqlDbType.NVarChar).Value = PDAUserName
        dataAdapter.SelectCommand.Parameters.Add("@PDAPassword", SqlDbType.NVarChar).Value = PDAPassword

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Gets all the records with the information of the User objets.
    ''' </summary>
    ''' <returns>A <c>DataTable</c> with all the records found.</returns>

    Public Shared Function GetAll() As DataTable

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM PDAUser ORDER BY [Order]", Common.ConfigDBConnection)

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function

End Class