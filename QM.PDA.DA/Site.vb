

''' <summary>
''' Provides data access to the Site table in the configuration database.
''' </summary>

Public Class Site

    ''' <summary>
    ''' Gets a single record with the information of the Site object specified.
    ''' </summary>
    ''' <param name="siteID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal siteID As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Site WHERE SiteID = @SiteID", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@SiteID", SqlDbType.Int).Value = siteID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function



    ''' <summary>
    ''' Checks if a Site object with the specified identifier exists.
    ''' </summary>
    ''' <param name="siteID">The unique identifier of the object in the database.</param>
    ''' <returns><c>True</c> if the a record exists, <c>False</c> otherwise.</returns>

    Public Shared Function Exists(ByVal siteID As Integer) As Boolean

        Dim command As New SqlCeCommand("SELECT COUNT(*) FROM Site WHERE SiteID = @SiteID", Common.ConfigDBConnection)
        command.Parameters.Add("@SiteID", SqlDbType.Int).Value = siteID

        Exists = CBool(command.ExecuteScalar())
        
    End Function



    ''' <summary>
    ''' Gets all the records with the information of the Site objets.
    ''' </summary>
    ''' <returns>A <c>DataTable</c> with all the records found.</returns>

    Public Shared Function GetAll() As DataTable

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM Site", Common.ConfigDBConnection)

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        Return dataTable

    End Function

End Class