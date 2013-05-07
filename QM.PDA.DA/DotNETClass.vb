

''' <summary>
''' Provides data access to the DotNETClass table in the configuration database.
''' </summary>

Public Class DotNETClass

    ''' <summary>
    ''' Gets a single record with the information of the DotNETClass object specified.
    ''' </summary>
    ''' <param name="dotNETClassID">The unique identifier of the object in the database.</param>
    ''' <returns>A <c>DataRow</c> with the information of the object if it was found, <c>Nothing</c> otherwise.</returns>

    Public Shared Function GetSingle(ByVal dotNETClassID As Integer) As DataRow

        Dim dataAdapter As New SqlCeDataAdapter("SELECT * FROM DotNETClass WHERE DotNETClassID = @DotNETClassID", Common.ConfigDBConnection)
        dataAdapter.SelectCommand.Parameters.Add("@DotNETClassID", SqlDbType.Int).Value = dotNETClassID

        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)

        If dataTable.Rows.Count > 0 Then Return dataTable.Rows(0) Else Return Nothing

    End Function

End Class